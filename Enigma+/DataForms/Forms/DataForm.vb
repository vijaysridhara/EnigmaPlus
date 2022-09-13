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
Imports System.Data.SQLite
Imports VijaySridhara.Controls
Imports VijaySridhara.Libraries.PForms

Public Class DataForm
    Private dbfile As String
    Private conString As String
    Dim conn As SQLiteConnection
    Private connString As String = "Data Source=#FILE#;Version=3;"
    Event MEssageSent(ByVal msg As String)
    Dim cmd As New SQLiteCommand
    Dim rdr As SQLiteDataReader
    Dim MetaForm As Meta
    Private _userdefined As Boolean

    Public ReadOnly Property UserDefined As Boolean
        Get
            Return _userdefined
        End Get
    End Property
    Public Sub Cleanup()
        On Error Resume Next
        If cmd IsNot Nothing Then cmd.Dispose()
        If rdr IsNot Nothing Then rdr.Close()
        If conn IsNot Nothing Then conn.Close() : conn.Dispose()


    End Sub
    Private WithEvents compDef As New Initiator
    Public Sub InitiateForm(ByVal ffile As String)

        Try
            'Panel1.BackgroundImage = My.Resources.formtoolbar
            'Panel1.BackgroundImageLayout = ImageLayout.Stretch
            dbfile = ffile
            connString = connString.Replace("#FILE#", ffile)
            MetaForm = compDef.ReadForm(dbfile)
            If MetaForm Is Nothing Then
                MsgBox("Some error in processing")
                Exit Sub
            End If
            If MetaForm.Username = "#UNDEFINED#" Then
                Dim uname As String = InputBox("This form requires username to own the data, please provide a username", "Data owner", "VSS")
                If String.IsNullOrEmpty(uname) Then
                    MsgBox("Impex enabled form requires a user to own the data", MsgBoxStyle.Exclamation)

                    _userdefined = False
                    compDef = Nothing
                    Cleanup()



                    Exit Sub
                Else
                    conn = New SQLiteConnection(connString)
                    conn.Open()
                    cmd.Connection = conn
                    cmd.CommandText = "UPDATE META SET USER='" & uname & "'"
                    cmd.ExecuteNonQuery()
                    MetaForm.Username = uname
                    My.Settings.FormUserName = uname
                    My.Settings.Save()
                    _userdefined = True
                    cmd.Dispose()
                    conn.Close()

                End If
            Else
                _userdefined = True
            End If
            Me.Parent.Text = MetaForm.Name
            lblTitle.Text = MetaForm.Name
            Label1.Text = "FVer:" + MetaForm.FormsVer
            lblFormVer.Text = "DVer:" + MetaForm.Version
            For Each fdef As FormDef In MetaForm.Forms.Values
                Dim tbp As New TabPage(fdef.Title)
                tbp.AutoScroll = True
                Dim lPos As New Point(10, 10)
                Dim txtPos As New Point(150, 10)
                Dim gap As New Point(0, 10)
                For Each FD As Field In fdef.Fields.Values
                    Dim lbl As New Label
                    Dim txt As Control
                    ' lbl.BackColor = Color.Transparent
                    lbl.Location = lPos
                    lbl.Text = FD.Name.Substring(0, 1).ToUpper & FD.Name.Substring(1).ToLower
                    Select Case FD.FieldType
                        Case PDFieldType.Check
                            txt = New CheckBox
                            txt.Text = lbl.Text
                            lbl.Visible = False
                            ' CType(txt, CheckBox).BackColor = Color.Transparent
                        Case PDFieldType.Radio
                            txt = New RadioButton
                            txt.Text = lbl.Text
                            lbl.Visible = False
                            ' CType(txt, RadioButton).BackColor = Color.Transparent
                        Case PDFieldType.Combo, PDFieldType.ROCombo, PDFieldType.List
                            txt = New ComboBox
                            populateValues(txt, FD)
                            txt.Size = New Size(200, 20)
                        Case PDFieldType.Text
                            txt = New TextBox
                            txt.Size = New Size(200, 20)
                        Case PDFieldType.Numeric
                            txt = New TextBox
                            CType(txt, TextBox).TextAlign = HorizontalAlignment.Right
                            txt.Text = "0.0"
                            txt.Size = New Size(200, 20)
                        Case PDFieldType.Picture, PDFieldType.File
                            txt = New Blobber
                        Case PDFieldType.Multiline
                            txt = New TextBox
                            CType(txt, TextBox).Multiline = True
                            txt.Size = New Size(300, 130)
                            CType(txt, TextBox).ScrollBars = ScrollBars.Vertical
                        Case PDFieldType.Largetext
                            txt = New TextBox
                            CType(txt, TextBox).Multiline = True
                            CType(txt, TextBox).ScrollBars = ScrollBars.Both
                            CType(txt, TextBox).Size = New Size(600, 300)
                            CType(txt, TextBox).WordWrap = False

                        Case PDFieldType.Date
                            txt = New DateTimePicker
                            CType(txt, DateTimePicker).Format = DateTimePickerFormat.Custom
                            CType(txt, DateTimePicker).CustomFormat = "yyyy-MM-dd"
                            txt.Size = New Size(200, 20)
                        Case PDFieldType.Label, PDFieldType.Timestamp
                            If FD.Name = "LASTUPT" Or FD.Name = "USER" Then lbl.Hide()
                            txt = New Label
                            CType(txt, Label).AutoSize = True
                            CType(txt, Label).BackColor = Color.Transparent
                        Case PDFieldType.Serial
                            txt = New Label
                            txt.Size = New Size(50, 20)
                            CType(txt, Label).AutoSize = False
                            CType(txt, Label).BorderStyle = BorderStyle.FixedSingle
                            CType(txt, Label).TextAlign = ContentAlignment.MiddleRight
                            CType(txt, Label).BackColor = Color.Transparent
                        Case PDFieldType.MonthYear
                            txt = New YearMonth
                            txt.Size = New Size(100, 15)
                            CType(txt, YearMonth).YMType = YearMonth.YMFormat.MMSepYYYY
                            CType(txt, YearMonth).DateSeparator = "-"
                        Case PDFieldType.RichText
                            txt = New RichTextPlus

                            CType(txt, RichTextPlus).RichArea.WordWrap = False

                            CType(txt, RichTextPlus).Size = New Size(600, 300)
                            CType(txt, RichTextPlus).RichArea.ScrollBars = ScrollBars.Both
                            'CType(txt, RichTextPlus).BorderStyle = BorderStyle.FixedSingle
                    End Select
                    txt.Font = New Font("Arial,Verdana", 10)
                    lbl.Font = New Font("Arial,Verdana", 10)
                    txt.Tag = FD.Name
                    txt.Location = txtPos

                    FD.Control = txt

                    lPos = New Point(lPos.X, txtPos.Y + txt.Height + gap.Y)
                    txtPos = New Point(txtPos.X, txtPos.Y + txt.Height + gap.Y)
                    tbp.Font = New Font("Verdana", 10, FontStyle.Bold)
                    tbp.Controls.Add(lbl)
                    tbp.Controls.Add(txt)

                    'tbp.BackColor = Color.White
                    ' tbp.BackgroundImage = My.Resources.formtoolbar
                    ' tbp.BackgroundImageLayout = ImageLayout.Stretch
                Next
                tabMain.TabPages.Add(tbp)

                If fdef.AllFieldsLabels Then
                    For Each fd As Field In fdef.Fields.Values
                        fd.Control.text = fd.DataSource
                    Next
                End If
            Next

            LoadDataRows()
            If MetaForm.GridReport.Count > 0 Then
                For Each rp As Report In MetaForm.GridReport.Values
                    Dim tbp1 As New TabPage(rp.Title)
                    Dim rpui As New ReportUI
                    AddHandler rpui.MEssageSent, AddressOf MS
                    rpui.Dock = DockStyle.Fill
                    rpui.Initiate(MetaForm, connString, rp.Title)
                    rpui.LoadfromQuery()
                    tbp1.Controls.Add(rpui)
                    TabControl1.TabPages.Add(tbp1)
                Next
            End If
            RaiseEvent MEssageSent("Your form is ready to work with")
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        Finally

        End Try
    End Sub
    Private Sub populateValues(ByVal cb As ComboBox, ByVal FD As Field)
        Try
            cb.Sorted = True
            cb.Items.Clear()
            If FD.FieldType = PDFieldType.Combo Or FD.FieldType = PDFieldType.ROCombo Then
                Dim SQL As String = FD.DataSource
                Dim CN1 As New SQLiteConnection(connString)
                CN1.Open()
                Dim CMD1 As New SQLiteCommand(FD.DataSource, CN1)
                Dim RDR1 As SQLiteDataReader
                RDR1 = CMD1.ExecuteReader

                While RDR1.Read
                    cb.Items.Add(RDR1(0))
                End While
                RDR1.Close()
                CN1.Close()
            ElseIf FD.FieldType = PDFieldType.List Then
                Dim STRINGS() As String = FD.DataSource.Split(",")
                For Each ST As String In STRINGS
                    cb.Items.Add(ST)
                Next
            End If
            If FD.FieldType = PDFieldType.ROCombo Or FD.FieldType = PDFieldType.List Then
                cb.DropDownStyle = ComboBoxStyle.DropDownList
            End If
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub
    Private Sub MS(ByVal message As String)
        RaiseEvent MEssageSent(message)
    End Sub
    Private Sub LoadDataRows()
        Try
            RaiseEvent MEssageSent("Refreshing  records for " & tabMain.SelectedTab.Text & ", please wait...")
            dgdData.Columns.Clear()



            conn = New SQLiteConnection(connString)
            conn.Open()
            cmd = New SQLiteCommand
            cmd.Connection = conn
            dgdData.Rows.Clear()
            cmd.CommandText = "SELECT "
            Dim fdef As FormDef = MetaForm.Forms(tabMain.SelectedTab.Text)
            For Each FD As Field In fdef.Fields.Values
                Dim dgdCol As New DataGridViewTextBoxColumn
                dgdCol.HeaderText = FD.Name
                dgdData.Columns.Add(dgdCol)
                cmd.CommandText += FD.Name & ","
            Next
            cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
            cmd.CommandText += " FROM " & fdef.DataStore
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim I As Integer = -1

                Dim DGR As New DataGridViewRow
                For Each FD As Field In fdef.Fields.Values
                    I += 1
                    Dim TBC As New DataGridViewTextBoxCell
                    If rdr.IsDBNull(I) Then TBC.Tag = "NULL" Else TBC.Tag = ""
                    If FD.FieldType = PDFieldType.File Then
                        TBC.Value = "[BLOB]"
                        TBC.Tag = rdr(FD.Name)
                    ElseIf FD.FieldType = PDFieldType.RichText Then
                        TBC.Value = "[Rich Text]"
                        TBC.Tag = rdr(FD.Name)
                    ElseIf FD.FieldType = PDFieldType.Date Then

                        TBC.Value = Format(rdr(FD.Name), "yyyy-MM-dd")
                    ElseIf FD.FieldType = PDFieldType.Timestamp Then
                        If rdr.IsDBNull(I) Then
                            TBC.Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                        Else
                            TBC.Value = Format(rdr(FD.Name), "yyyy-MM-dd HH:mm:ss")
                        End If

                    Else
                        If rdr.IsDBNull(I) Then
                            TBC.Value = ""
                        Else
                            TBC.Value = rdr(FD.Name)
                        End If

                    End If
                    DGR.Cells.Add(TBC)
                Next

                dgdData.Rows.Add(DGR)
            End While
            rdr.Close()
            RaiseEvent MEssageSent("Completed loading")
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub


    Private Sub butNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNewRecord.Click
        Try
            Dim fdef As FormDef = MetaForm.Forms(tabMain.SelectedTab.Text)
            RaiseEvent MEssageSent("Adding a new record...")
            conn = New SQLiteConnection(connString)
            conn.Open()
            Dim CMD As New SQLiteCommand
            CMD.Connection = conn
            CMD.CommandText = "INSERT INTO " & fdef.DataStore & " ("
            Dim NAMESTRING As String = ""
            Dim VALSTRING As String = ""
            For Each FD As Field In fdef.Fields.Values
                If FD.FieldType = PDFieldType.Serial Then Continue For
                NAMESTRING += "," + FD.Name
                VALSTRING += ",@" + FD.Name
                If FD.FieldType = PDFieldType.File Then
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.Object)
                    CMD.Parameters(FD.Name).Value = CType(FD.Control, Blobber).Blob
                ElseIf FD.FieldType = PDFieldType.Check Then
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.String)
                    CMD.Parameters(FD.Name).Value = IIf(CType(FD.Control, CheckBox).Checked, "Y", "N")
                ElseIf FD.FieldType = PDFieldType.Radio Then
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.String)
                    CMD.Parameters(FD.Name).Value = IIf(CType(FD.Control, RadioButton).Checked, "Y", "N")
                ElseIf FD.FieldType = PDFieldType.Timestamp Then
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.DateTime)
                    CMD.Parameters(FD.Name).Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                ElseIf FD.FieldType = PDFieldType.Label And FD.Name = "USER" Then
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.String)
                    CMD.Parameters(FD.Name).Value = MetaForm.Username
                ElseIf FD.FieldType = PDFieldType.Numeric Then
                    CMD.Parameters.Add(FD.Name, Data.DbType.Decimal)
                    CMD.Parameters(FD.Name).Value = IIf(String.IsNullOrEmpty(FD.Control.TEXT), 0, FD.Control.text)
                ElseIf FD.FieldType = PDFieldType.MonthYear Then
                    CMD.Parameters.Add(FD.Name, Data.DbType.String)
                    CMD.Parameters(FD.Name).Value = CType(FD.Control, YearMonth).YearMonthValue
                ElseIf FD.FieldType = PDFieldType.RichText Then
                    Dim enc As New System.Text.UTF8Encoding()
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.Object)
                    CMD.Parameters(FD.Name).Value = enc.GetBytes(FD.Control.rtf)


                Else
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.String)

                    CMD.Parameters(FD.Name).Value = FD.Control.text
                End If
            Next
            NAMESTRING = NAMESTRING.Substring(1)
            VALSTRING = VALSTRING.Substring(1)
            CMD.CommandText += NAMESTRING & ") VALUES(" & VALSTRING & ")"
            CMD.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            For Each fd As Field In fdef.Fields.Values
                If fd.FieldType <> PDFieldType.Date Then
                    If fd.FieldType = PDFieldType.File Or fd.FieldType = PDFieldType.Picture Then
                        CType(fd.Control, Blobber).Blob = Nothing
                    ElseIf fd.FieldType <> PDFieldType.User Then
                        fd.Control.text = ""
                    End If
                End If
            Next
            RaiseEvent MEssageSent("Completed adding record to " & fdef.Title)
            tabMain.SelectedTab.Controls(1).Focus()
            LoadDataRows()
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        Finally
            ' 
        End Try '
    End Sub

    Private Sub dgdData_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdData.RowHeaderMouseClick
        Try
            Dim fdef As FormDef = MetaForm.Forms(tabMain.SelectedTab.Text)
            Dim dgRow As DataGridViewRow = dgdData.Rows(e.RowIndex)
            If dgRow Is Nothing Then Exit Sub
            For Each dc As DataGridViewCell In dgRow.Cells
                Select Case fdef.Fields(dc.OwningColumn.HeaderText).FieldType
                    Case PDFieldType.Check, PDFieldType.Radio
                        fdef.Fields(dc.OwningColumn.HeaderText).Control.checked = IIf(dc.Value = "Y", True, False)
                    Case PDFieldType.File
                        fdef.Fields(dc.OwningColumn.HeaderText).Control.blob = dc.Tag
                    Case PDFieldType.Date
                        fdef.Fields(dc.OwningColumn.HeaderText).Control.value = dc.Value
                    Case PDFieldType.RichText
                        Dim enc As New System.Text.UTF8Encoding

                        fdef.Fields(dc.OwningColumn.HeaderText).Control.rtf = enc.GetString(dc.Tag)
                    Case Else
                        fdef.Fields(dc.OwningColumn.HeaderText).Control.text = dc.Value
                End Select
            Next
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub

    Private Sub butSaveRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSaveRecord.Click
        If dgdData.SelectedRows.Count = 0 Then
            MsgBox("No Row Selected to update. If this is a new row, use <Insert record>instead", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            Dim dgRow As DataGridViewRow = dgdData.Rows(dgdData.SelectedRows(0).Index)
            If dgRow Is Nothing Then Exit Sub
            Dim fdef As FormDef = MetaForm.Forms(tabMain.SelectedTab.Text)
            RaiseEvent MEssageSent("Updating the record...")
            conn = New SQLiteConnection(connString)
            conn.Open()
            Dim CMD As New SQLiteCommand
            CMD.Connection = conn
            CMD.CommandText = "UPDATE " & fdef.DataStore & " SET "
            Dim NAMESTRING As String = ""
            Dim WHERESTRING As String = ""
            Dim I As Integer = 0
            For Each FD As Field In fdef.Fields.Values
                If FD.FieldType <> PDFieldType.Serial Then
                    NAMESTRING += "," + FD.Name + "=@" + FD.Name
                End If

                If FD.FieldType <> PDFieldType.File And FD.FieldType <> PDFieldType.Picture And FD.FieldType <> PDFieldType.RichText And FD.Control.TAG <> "NULL" Then
                    If FD.FieldType = PDFieldType.Numeric Or FD.FieldType = PDFieldType.Serial Then
                        WHERESTRING += " AND " & FD.Name & "=" & dgRow.Cells(I).Value
                    Else
                        WHERESTRING += " AND " & FD.Name & "=@OLD" & FD.Name
                        CMD.Parameters.Add("OLD" & FD.Name, Data.DbType.String)
                        CMD.Parameters("OLD" & FD.Name).Value = dgRow.Cells(I).Value
                    End If

                ElseIf FD.Control.TAG = "NULL" Then
                    WHERESTRING += " AND " & FD.Name & " IS NULL"
                End If

                If FD.FieldType = PDFieldType.File Or FD.FieldType = PDFieldType.Picture Then
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.Object)
                    CMD.Parameters(FD.Name).Value = CType(FD.Control, Blobber).Blob

                ElseIf FD.FieldType = PDFieldType.Check Then
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.String)
                    CMD.Parameters(FD.Name).Value = IIf(CType(FD.Control, CheckBox).Checked, "Y", "N")
                ElseIf FD.FieldType = PDFieldType.Radio Then
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.String)
                    CMD.Parameters(FD.Name).Value = IIf(CType(FD.Control, RadioButton).Checked, "Y", "N")
                ElseIf FD.FieldType = PDFieldType.Timestamp Then
                    CMD.Parameters.Add(FD.Name, Data.DbType.DateTime)
                    CMD.Parameters(FD.Name).Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                ElseIf FD.FieldType = PDFieldType.Numeric Then
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.Decimal)
                    CMD.Parameters(FD.Name).Value = FD.Control.text
                ElseIf FD.FieldType = PDFieldType.MonthYear Then
                    CMD.Parameters.Add(FD.Name, Data.DbType.String)
                    CMD.Parameters(FD.Name).Value = CType(FD.Control, YearMonth).YearMonthValue
                ElseIf FD.FieldType = PDFieldType.RichText Then
                    Dim enc As New System.Text.UTF8Encoding()
                    CMD.Parameters.Add(FD.Name, System.Data.DbType.Object)
                    CMD.Parameters(FD.Name).Value = enc.GetBytes(FD.Control.rtf)
                Else

                    CMD.Parameters.Add(FD.Name, System.Data.DbType.String)
                    CMD.Parameters(FD.Name).Value = FD.Control.text
                End If
                I += 1
            Next
            NAMESTRING = NAMESTRING.Substring(1)
            WHERESTRING = " WHERE " + WHERESTRING.Substring(4)
            CMD.CommandText += NAMESTRING & WHERESTRING
            RaiseEvent MEssageSent(CMD.ExecuteNonQuery & " rows affected")
            conn.Close()
            conn.Dispose()
            RaiseEvent MEssageSent("Completed update of " & fdef.Title)
            For Each fd As Field In fdef.Fields.Values
                If fd.FieldType <> PDFieldType.Date Then
                    If fd.FieldType = PDFieldType.File Or fd.FieldType = PDFieldType.Picture Then
                        CType(fd.Control, Blobber).Blob = Nothing
                    ElseIf fd.FieldType <> PDFieldType.User Then
                        fd.Control.text = ""
                    End If
                End If
            Next
            tabMain.SelectedTab.Controls(1).Focus()
            LoadDataRows()
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub

    Private Sub butDeleteRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDeleteRecord.Click
        Try
            If dgdData.SelectedRows.Count = 0 Then
                MsgBox("No Row Selected to delete", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If MsgBox("Do you really want to delete the selected records?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            RaiseEvent MEssageSent("Deleting the records...")
            Dim CMD As New SQLiteCommand
            conn = New SQLiteConnection(connString)
            conn.Open()
            For Each dgRow In dgdData.SelectedRows
                ' Dim dgRow As DataGridViewRow = dgdData.Rows(dgdData.SelectedRows(0).Index)
                If dgRow Is Nothing Then Exit Sub


                Dim fdef As FormDef = MetaForm.Forms(tabMain.SelectedTab.Text)

                CMD.Connection = conn
                CMD.CommandText = "DELETE FROM " & fdef.DataStore & " WHERE "

                Dim WHERESTRING As String = ""
                Dim I As Integer = 0

                For Each FD As Field In fdef.Fields.Values
                    If FD.FieldType <> PDFieldType.File And FD.FieldType <> PDFieldType.Picture And FD.FieldType <> PDFieldType.RichText Then
                        If dgRow.Cells(I).TAG = "NULL" Then
                            WHERESTRING += " AND " & FD.Name & " IS NULL"
                        ElseIf FD.FieldType = PDFieldType.Numeric Or FD.FieldType = PDFieldType.Serial Then
                            WHERESTRING += " AND " & FD.Name & "=" & dgRow.Cells(I).Value
                        Else
                            WHERESTRING += " AND " & FD.Name & "=@OLD" & FD.Name
                            CMD.Parameters.Add("OLD" & FD.Name, Data.DbType.String)
                            CMD.Parameters("OLD" & FD.Name).Value = dgRow.Cells(I).Value
                        End If

                    End If
                    I += 1
                Next

                WHERESTRING = WHERESTRING.Substring(4)
                CMD.CommandText += WHERESTRING
                RaiseEvent MEssageSent(CMD.ExecuteNonQuery & " rows affected")


                RaiseEvent MEssageSent("Completed deletion in " & fdef.Title)
                For Each fd As Field In fdef.Fields.Values
                    If fd.FieldType <> PDFieldType.Date Then
                        If fd.FieldType = PDFieldType.File Or fd.FieldType = PDFieldType.Picture Then
                            CType(fd.Control, Blobber).Blob = Nothing
                        ElseIf fd.FieldType <> PDFieldType.User Then
                            fd.Control.text = ""
                        End If
                    End If
                Next
            Next
            conn.Close()
            conn.Dispose()
            LoadDataRows()

        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub

    Private Sub butCreateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCreateReport.Click
        Try
            Dim RP As New ReportDef(connString)
            RP.ShowDialog()
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub

    Private Sub butImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butImport.Click
        Try
            Dim fod As New OpenFileDialog
            Dim fname As String
            With fod
                .InitialDirectory = My.Settings.ImpexDir
                .Filter = "Enigma+ Form Data Exported files(*.pf2)|*.pf2)|Comma separated values(*.csv)|*.csv"
                If .ShowDialog = DialogResult.OK Then
                    fname = .FileName
                Else
                    Exit Sub
                End If

                If IO.Path.GetExtension(fname) = ".pf2" Then
                    ImportPF2(fname)
                Else
                    ImportCSV(fname)
                End If
            End With

        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub
    Private Sub ImportCSV(ByVal fname As String)
        Try

            Dim impCSV As New ImportCSV(MetaForm, fname, dbfile)
            impCSV.Show()
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub
    Private Sub ImportPF2(ByVal fname As String)
        Try
            Dim sr As New IO.StreamReader(fname)
            Dim content = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            Dim lines() As String = content.Split(vbLf)
            If lines.Count <= 4 Then
                MsgBox("The file is too small to be a import file", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim Conf As New ConfirmImport()
            Conf.TextBox1.Text = lines(0) & vbLf & lines(1) & vbLf & lines(2) & vbLf & lines(3)
            Conf.TextBox1.Text += vbLf & vbLf & "No of incoming records : " & lines.Count - 4
            If Conf.ShowDialog = DialogResult.Cancel Then Exit Sub
            Dim conn = New SQLiteConnection
            conn.ConnectionString = connString
            conn.Open()
            cmd = New SQLiteCommand
            cmd.Connection = conn
            Dim inserted As Integer, rejected As Integer
            For i As Integer = 4 To lines.Count - 1

                cmd.CommandText = lines(i).Trim
                Try
                    cmd.ExecuteNonQuery()
                    inserted += 1
                Catch ex As Exception
                    RaiseEvent MEssageSent(ex.Message)
                    rejected += 1
                End Try

            Next
            cmd.Dispose()
            conn.Close()
            RaiseEvent MEssageSent("Records processed:" & inserted)
            RaiseEvent MEssageSent("Records rejected:" & rejected)
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub
    Private Sub dgdData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdData.CellContentClick

    End Sub

    Private Sub tabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.SelectedIndexChanged

        Dim fdef As FormDef = MetaForm.Forms(tabMain.SelectedTab.Text)
        If fdef.AllFieldsLabels Then
            butNewRecord.Enabled = False
            butSaveRecord.Enabled = False
            butDeleteRecord.Enabled = False
            dgdData.Enabled = False
            For Each fd As Field In fdef.Fields.Values
                If fd.Name = "USER" Or fd.Name = "LASTUPT" Then Continue For
                fd.Control.TEXT = fd.DataSource
            Next
            Exit Sub
        Else
            butNewRecord.Enabled = True
            butSaveRecord.Enabled = True
            butDeleteRecord.Enabled = True
            dgdData.Enabled = True
        End If
        For Each fd As Field In fdef.Fields.Values
            If fd.FieldType = PDFieldType.ROCombo Or fd.FieldType = PDFieldType.Combo Then
                populateValues(fd.Control, fd)
            End If
        Next
        LoadDataRows()


    End Sub
    Public Sub Vacuum()
        Try
            conn = New SQLiteConnection(connString)
            conn.Open()
            cmd = New SQLiteCommand("VACUUM", conn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            conn.Close()
            conn.Dispose()
            MetaForm = Nothing
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex > 0 Then
            butDeleteRecord.Enabled = False
            butNewRecord.Enabled = False
            butSaveRecord.Enabled = False
        Else
            butDeleteRecord.Enabled = True
            butNewRecord.Enabled = True
            butSaveRecord.Enabled = True
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub compDef_ClearMessagearea() Handles compDef.ClearMessagearea

    End Sub

    Private Sub compDef_MessageSent(ByVal msg As String) Handles compDef.MessageSent
        RaiseEvent MEssageSent(msg)
    End Sub

    Private Sub butQuickfix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butQuickfix.Click
        Try
            Dim qf As New Quickfix(dbfile)
            qf.ShowDialog()
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub

    Private Sub chkShowGrid_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowGrid.CheckedChanged
        If chkShowGrid.Checked Then
            Toolbox1.Show()
            Splitter1.Show()
        Else
            Toolbox1.Hide()
            Splitter1.Hide()
        End If
    End Sub
End Class
