'***********************************************************************
'Copyright 2005-2022 Vijay Sridhara

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at

'http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
'WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'***********************************************************************
Imports VijaySridhara.Libraries.PForms
Imports System.Data.SQLite

Friend Class ImportCSV
    Private mf As Meta
    Private file As String
    Dim lines() As String
    Private connString As String = "Data Source=#FILE#;Version=3;"
    Public Sub New(ByVal mf As Meta, ByVal flname As String, ByVal dbfile As String)
        InitializeComponent()
        Me.mf = mf
        Me.file = flname
        connString = connString.Replace("#FILE#", dbfile)
    End Sub
    Private Sub SetStat(ByVal ms As String)
        txtStatus.Text += vbCrLf & ms
        txtStatus.SelectionStart = txtStatus.Text.Length
        txtStatus.ScrollToCaret()
    End Sub

    Private Sub butOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        Try
            Dim insStatement As String = "INSERT INTO " & CurrentDataStore.DataStore & " (QueryString) VALUES (ValueString)"

            Dim ixCol As New Collection
            Dim nameCol As New Collection
            Dim colvals As String = ""
            Dim valVals As String = ""
            For Each ctl As Control In pnlMAin.Controls
                If TypeOf ctl Is ComboBox Then
                    If String.IsNullOrEmpty(CType(ctl, ComboBox).Text) Then
                        Continue For
                    End If
                    colvals += "," & CType(ctl, ComboBox).Text
                    valVals += ",@" & CType(ctl, ComboBox).Text
                    ixCol.Add(CType(ctl, ComboBox).Tag, CType(ctl, ComboBox).Text)
                    nameCol.Add(CType(ctl, ComboBox).Text, CType(ctl, ComboBox).Text)
                End If
            Next
            If colvals.Length = 0 Then
                MsgBox("No columns selected", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            colvals = colvals.Substring(1)
            valVals = valVals.Substring(1)
            Dim conn As New SQLiteConnection(connString)
            conn.Open()
            Dim cmd As New SQLiteCommand
            cmd.Connection = conn
            cmd.CommandText = insStatement.Replace("QueryString", colvals).Replace("ValueString", valVals)
            For Each pm As String In nameCol
                If CurrentDataStore.Fields(pm).FieldType = PDFieldType.Numeric Then
                    cmd.Parameters.Add(pm, Data.DbType.Decimal)
                Else
                    cmd.Parameters.Add(pm, Data.DbType.String)
                End If
            Next
            For i As Integer = 1 To lines.Length - 1
                Dim ln As String = lines(i)

                ln = ln.Trim
                Dim lnVals() As String = ln.Split(",")
                If lnVals.Length < ixCol.Count Then Continue For
                For j As Integer = 1 To nameCol.Count
                    cmd.Parameters(nameCol(j).ToString).Value = lnVals(ixCol(j))
                Next
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    SetStat("Line: " & (i + 1) & "[" & ex.Message & "]")
                End Try
            Next
            cmd.Dispose()
            conn.Close()
            conn.Dispose()
            Me.DialogResult = DialogResult.OK
            butOK.Enabled = False
            SetStat("Completed import successfully... now restart the form")
        Catch ex As Exception
            SetStat(ex.Message)

        End Try

    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ImportCSV_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            For Each fd As FormDef In mf.Forms.Values
                cboTabke.Items.Add(fd.Title)
            Next

        Catch ex As Exception
            SetStat(ex.Message)
        End Try
    End Sub
    Private CurrentDataStore As FormDef
    Private Sub cboTabke_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTabke.SelectedIndexChanged
        Try
            pnlMAin.Controls.Clear()
            CurrentDataStore = mf.Forms(cboTabke.SelectedItem)
            Dim sr As New IO.StreamReader(file)
            lines = sr.ReadToEnd.Split(vbLf)
            sr.Close()
            sr.Dispose()
            Dim headers() = lines(0).Split(",")
            Dim toppos As Integer = 10
            Dim left As Integer = 50
            Dim index As Integer = 0
            For Each hdr As String In headers
                Dim lbl As New Label()
                lbl.AutoSize = True
                lbl.Text = hdr
                lbl.Location = New Point(left, toppos)

                Dim ct As New ComboBox
                ct.DropDownStyle = ComboBoxStyle.DropDownList
                For Each fld As Field In CurrentDataStore.Fields.Values
                    If fld.FieldType <> PDFieldType.File And fld.FieldType <> PDFieldType.Picture And fld.FieldType <> PDFieldType.RichText Then
                        ct.Items.Add(fld.Name)
                        If fld.Name = hdr Then
                            ct.SelectedText = hdr
                        End If
                    End If
                Next
                ct.Tag = index
                index += 1
                ct.Location = New Point(left + 150, toppos)
                pnlMAin.Controls.AddRange({lbl, ct})
                toppos += ct.Height + 10
            Next

        Catch ex As Exception
            SetStat(ex.Message)
        End Try
    End Sub
End Class