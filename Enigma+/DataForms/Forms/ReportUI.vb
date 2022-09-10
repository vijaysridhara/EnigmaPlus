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
Imports System.Net
Imports VijaySridhara.Libraries.PForms
Imports VijaySridhara.Libraries
Friend Class ReportUI
    Event MEssageSent(ByVal msg As String)
    Private WithEvents htmlpub As New HTMLPublisher
    Private conn As SQLiteConnection
    Private ConnString As String
    Private metaform As Meta
    Private repname As String
    Private Function ExportData() As String
        Try
            Dim namestring As String = ""
            Dim finalSTring As String = ""
            Dim rp As String = metaform.GridReport(repname).ImportDataStore
            Dim insText As String = vbLf & "INSERT INTO " + rp & " (#NAMESTRING#) VALUES(#VALUEDATA#)"
            Dim userselected As Boolean
            Dim lastuptselected As Boolean
            For Each cl As DataGridViewColumn In datagridview1.Columns
                namestring += "," + cl.HeaderText
                If cl.HeaderText = "USER" Then
                    userselected = True
                ElseIf cl.HeaderText = "LASTUPT" Then
                    lastuptselected = True
                End If
            Next
            namestring = namestring.Substring(1)
            Dim VALUEDATA As String = ""

            For Each dr As DataGridViewRow In datagridview1.Rows
                VALUEDATA = ""
                For Each dgcell As DataGridViewTextBoxCell In dr.Cells
                    If dgcell.Tag = "DECIMAL" Then
                        VALUEDATA += "," + dgcell.Value.ToString
                    Else
                        VALUEDATA += ",'" + dgcell.Value.ToString.Replace("'", "\'") + "'"
                    End If

                Next
                VALUEDATA = VALUEDATA.Substring(1)
                finalSTring += Replace(insText, "#NAMESTRING#", namestring).Replace("#VALUEDATA#", VALUEDATA)
            Next
            If finalSTring.Length > 0 Then
                finalSTring = finalSTring.Substring(1)
            End If



            Dim sign As String

            sign = "Reportname:" & Me.repname & vbLf & "Ver:" + metaform.Version & vbCrLf & "Data belongs to:" + metaform.Username + vbCrLf + "Date:" + Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & vbCrLf
            Dim temppath As String = UserTempData & "\temp"
            temppath += "\" + "Export_" & metaform.Username & "_" & Format(Date.Now, "yyyy_MM_dd_HH_mm_ss") + ".pf2"
            Dim sw As New IO.StreamWriter(temppath)
            sw.Write(sign & finalSTring)
            sw.Close()
            sw.Dispose()
            Return temppath

            Return ""
        Catch ex As Exception
            DE(ex)
            Return ""
        End Try
    End Function
    Public Sub Initiate(ByVal metaf As Meta, ByVal connSTring As String, ByVal repname As String)
        Me.ConnString = connSTring
        Me.repname = repname
        Me.metaform = metaf

    End Sub
    Public Sub LoadfromQuery()
        Try
            Dim rp As Report = metaform.GridReport(Me.repname)
            RaiseEvent MEssageSent("Retrieving reports of your selection...")
            If rp.Inbuilt Then butSend.Enabled = True Else butSend.Enabled = False
            Me.ConnString = ConnString
            Me.conn = New SQLiteConnection(ConnString)
            Me.conn.Open()
            datagridview1.Rows.Clear()
            datagridview1.Columns.Clear()
            Dim cmd As New SQLiteCommand
            cmd.CommandText = rp.SQL
            cmd.Connection = conn
            Dim rdr As SQLiteDataReader
            rdr = cmd.ExecuteReader
            For i As Integer = 0 To rdr.FieldCount - 1
                Dim dgdCol As New DataGridViewTextBoxColumn
                dgdCol.HeaderText = rdr.GetName(i)
                datagridview1.Columns.Add(dgdCol)
            Next
            While rdr.Read
                Dim dgdRow As New DataGridViewRow
                For i As Integer = 0 To rdr.FieldCount - 1
                    Dim dgdCell As New DataGridViewTextBoxCell
                    If rdr.GetFieldType(i).ToString = "System.DateTime" Then
                        dgdCell.Value = Format(rdr(i), "yyyy-MM-dd HH:mm:ss")
                        If dgdCell.Value.ToString.Contains("00:00:00") Then
                            dgdCell.Value = dgdCell.Value.ToString.Substring(0, 10)
                        End If
                    Else
                        dgdCell.Value = rdr(i)
                    End If
                    If rdr.GetFieldType(i).ToString() = "System.Decimal" Then
                        dgdCell.Tag = "DECIMAL"
                    Else
                        dgdCell.Tag = "STRING"
                    End If
                    dgdRow.Cells.Add(dgdCell)
                Next
                datagridview1.Rows.Add(dgdRow)
            End While
            conn.Close()
            conn.Dispose()
            RaiseEvent MEssageSent("Report loaded...")
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
            If conn.State <> System.Data.ConnectionState.Closed Then
                conn.Close()
                conn.Dispose()
            End If
        End Try
        If datagridview1.Rows.Count = 0 Then
            cboSaveDatato.Enabled = False
        Else
            cboSaveDatato.Enabled = True
        End If
    End Sub

    Private Sub cboSaveDatato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSaveDatato.SelectedIndexChanged
        If datagridview1.Rows.Count = 0 And cboSaveDatato.SelectedIndex > 0 Then
            MsgBox("No data rows present to export", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            If cboSaveDatato.Text = "Save data as..." Then Exit Sub
            Select Case cboSaveDatato.Text
                Case "Comma Separated Values"
                    Dim sfd As New SaveFileDialog
                    Dim fname As String = ""
                    Dim fnstr As String = ""
                    With sfd
                        .Filter = "Comma Separated Files(*.csv)|*.csv"
                        .FileName = "Untitled"
                        If .ShowDialog = DialogResult.OK Then
                            fname = .FileName
                        Else
                            Exit Select
                        End If
                    End With
                    Dim fl As New IO.StreamWriter(fname)



                    For j As Integer = 0 To datagridview1.Columns.Count - 1
                        If j < datagridview1.Columns.Count - 1 Then

                            fnstr += datagridview1.Columns(j).HeaderText.Replace(vbCrLf, "_") & ","
                        Else
                            fnstr += datagridview1.Columns(j).HeaderText.Replace(vbCrLf, "_")
                        End If
                    Next
                    fl.WriteLine(fnstr)

                    For i As Integer = 0 To datagridview1.Rows.Count - 1
                        fnstr = ""
                        For j As Integer = 0 To datagridview1.Columns.Count - 1
                            If j < datagridview1.Columns.Count - 1 Then
                                fnstr += datagridview1.Rows(i).Cells(j).Value & ","
                            Else
                                fnstr += datagridview1.Rows(i).Cells(j).Value
                            End If
                        Next
                        fl.WriteLine(fnstr)
                    Next

                    fl.Close()
                    fl.Dispose()
                Case "CSV with quotes"
                    Dim sfd As New SaveFileDialog
                    Dim fname As String = ""
                    Dim fnstr As String = ""
                    With sfd
                        .Filter = "Comma Separated Files(*.csv)|*.csv"
                        .FileName = "Untitled"
                        If .ShowDialog = DialogResult.OK Then
                            fname = .FileName
                        Else
                            Exit Select
                        End If
                    End With
                    Dim fl As New IO.StreamWriter(fname)



                    For j As Integer = 0 To datagridview1.Columns.Count - 1
                        If j < datagridview1.Columns.Count - 1 Then

                            fnstr += datagridview1.Columns(j).HeaderText.Replace(vbCrLf, "_") & ","
                        Else
                            fnstr += datagridview1.Columns(j).HeaderText.Replace(vbCrLf, "_")
                        End If
                    Next
                    fl.WriteLine(fnstr)

                    For i As Integer = 0 To datagridview1.Rows.Count - 1
                        fnstr = ""
                        For j As Integer = 0 To datagridview1.Columns.Count - 1
                            If j < datagridview1.Columns.Count - 1 Then

                                fnstr += """" & datagridview1.Rows(i).Cells(j).Value & """" & ","

                            Else
                                fnstr += """" & datagridview1.Rows(i).Cells(j).Value & """"
                            End If
                        Next
                        fl.WriteLine(fnstr)
                    Next

                    fl.Close()
                    fl.Dispose()
                Case "Tab Separated Values"
                    Dim sfd As New SaveFileDialog
                    Dim fname As String = ""
                    Dim fnstr As String = ""
                    With sfd
                        .Filter = "Tab Separated Files(*.txt)|*.txt"
                        .FileName = "Untitled"
                        If .ShowDialog = DialogResult.OK Then
                            fname = .FileName
                        Else
                            Exit Select
                        End If
                    End With
                    Dim fl As New IO.StreamWriter(fname)


                    For j As Integer = 0 To datagridview1.Columns.Count - 1
                        If j < datagridview1.Columns.Count - 1 Then
                            fnstr += datagridview1.Columns(j).HeaderText.Replace(vbCrLf, "_") & vbTab
                        Else
                            fnstr += datagridview1.Columns(j).HeaderText.Replace(vbCrLf, "_") & vbCrLf
                        End If
                    Next
                    fl.WriteLine(fnstr)

                    For i As Integer = 0 To datagridview1.Rows.Count - 1
                        fnstr = ""
                        For j As Integer = 0 To datagridview1.Columns.Count - 1
                            If j < datagridview1.Columns.Count - 1 Then
                                fnstr += datagridview1.Rows(i).Cells(j).Value & vbTab
                            Else
                                fnstr += datagridview1.Rows(i).Cells(j).Value & vbCrLf
                            End If
                        Next
                        fl.WriteLine(fnstr)
                    Next

                    fl.Close()
                    fl.Dispose()
                Case "HTML File"
                    htmlpub.Data.Clear()
                    htmlpub.ColumnHeaders.Clear()
                    For j As Integer = 0 To datagridview1.Columns.Count - 1
                        htmlpub.ColumnHeaders.Add(datagridview1.Columns(j).HeaderText)
                    Next
                    Dim dr As HTMLPublisher.DataRow
                    For i As Integer = 0 To datagridview1.Rows.Count - 1
                        dr = New HTMLPublisher.DataRow
                        For j As Integer = 0 To datagridview1.Columns.Count - 1
                            dr.Fields.Add(datagridview1.Rows(i).Cells(j).Value)
                        Next
                        htmlpub.Data.Add(dr)
                    Next
                    htmlpub.HeaderNeeded = True
                    htmlpub.LineNumbering = True

                    htmlpub.HeaderText = "Result saved from Enigma+ on " & Date.Now
                    Dim sfd As New SaveFileDialog
                    Dim fname As String = ""
                    With sfd
                        .Filter = "HTML Files(*.htm)|*.htm"
                        .FileName = "Untitled"
                        If .ShowDialog = DialogResult.OK Then
                            fname = .FileName
                        Else
                            Exit Select
                        End If
                    End With
                    If htmlpub.PublishFile(fname) = HTMLPublisher.ECodes.Success Then
                        RaiseEvent MEssageSent("File Saved successfully")
                    End If
                Case "Character separated"
                    Dim sfd As New SaveFileDialog
                    Dim fname As String = ""
                    Dim fnstr As String = ""
                    Dim splChar As String = InputBox("Provide a special character", "Special Character", Chr(233))
                    If splChar.Length = 0 Then
                        MsgBox("No special character provided, so exiting", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    With sfd
                        .Filter = "Special Character Separated Files(*.*)|*.*"
                        .FileName = "Untitled"
                        If .ShowDialog = DialogResult.OK Then
                            fname = .FileName
                        Else
                            Exit Select
                        End If
                    End With
                    Dim fl As New IO.StreamWriter(fname)


                    For j As Integer = 0 To datagridview1.Columns.Count - 1
                        If j < datagridview1.Columns.Count - 1 Then
                            fnstr += datagridview1.Columns(j).HeaderText.Replace(vbCrLf, "_") & splChar
                        Else
                            fnstr += datagridview1.Columns(j).HeaderText.Replace(vbCrLf, "_") & vbCrLf
                        End If
                    Next
                    fl.WriteLine(fnstr)

                    For i As Integer = 0 To datagridview1.Rows.Count - 1
                        fnstr = ""
                        For j As Integer = 0 To datagridview1.Columns.Count - 1
                            If j < datagridview1.Columns.Count - 1 Then
                                fnstr += datagridview1.Rows(i).Cells(j).Value & splChar
                            Else
                                fnstr += datagridview1.Rows(i).Cells(j).Value & vbCrLf
                            End If
                        Next
                        fl.WriteLine(fnstr)
                    Next

                    fl.Close()
                    fl.Dispose()
            End Select
            cboSaveDatato.SelectedIndex = 0
        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub


    Private Sub butRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefresh.Click
        LoadfromQuery()

    End Sub

    Private Sub butSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSend.Click
        Try
            If datagridview1.RowCount = 0 Then
                MsgBox("No rows to send, so exiting", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim fl As String = ExportData()
            If fl Is Nothing Then RaiseEvent MEssageSent("No file is generated to send") : Exit Sub

            Dim ms As New MailSelect
            If ms.ShowDialog = DialogResult.OK Then
                If ms.IsLotus Then


                    Dim UserName As String
                    Dim MailDbName As String
                    Dim Maildb As Object
                    Dim MailDoc As Object
                    Dim AttachME As Object
                    Dim Session As Object
                    Dim EmbedObj1 As Object

                    ' Open and locate current LOTUS NOTES User

                    Session = CreateObject("Notes.NotesSession")
                    UserName = Session.UserName
                    MailDbName = UserName & ".nsf"
                    Dim MyName = UserName.Substring(0, InStr(UserName, "/") - 1).Split("=")(1)
                    Maildb = Session.GETDATABASE("", "")
                    If Maildb.IsOpen = True Then
                    Else
                        Maildb.OPENMAIL()
                    End If

                    ' Create New Mail and Address Title Handlers

                    MailDoc = Maildb.CreateDocument

                    MailDoc.Form = "Memo"
                    MailDoc.SendTo = ms.ToEmail


                    MailDoc.Subject = "PF2Document"
                    ' MailDoc.Body = vbLf & "Please find the attached pf2 document" & vbLf

                    ' Select Workbook to Attach to E-Mail



                    AttachME = MailDoc.CREATERICHTEXTITEM(IO.Path.GetFileName(fl))
                    EmbedObj1 = AttachME.embedobject(1454, IO.Path.GetFileName(fl), fl, "") 'Required File Name
                    Dim workspace = CreateObject("Notes.NotesUIWorkspace")
                    Call workspace.EDITDOCUMENT(True, MailDoc).GOTOFIELD("Body")
                    MailDoc.Body = vbLf & "Please find the attached pf2 document" & vbLf

errorhandler1:

                    Maildb = Nothing
                    MailDoc = Nothing
                    AttachME = Nothing
                    Session = Nothing
                    EmbedObj1 = Nothing



                Else
                    Dim pi As New ProcessStartInfo
                    pi.UseShellExecute = True
                    pi.FileName = "mailto:" & ms.ToEmail & "?subject=PF2File&body=Please find the file attached&attachment=""" + fl + """"
                    Process.Start(pi)
                End If

            End If
            RaiseEvent MEssageSent("Created mail message...")

        Catch ex As Exception
            RaiseEvent MEssageSent(ex.Message)
        End Try
    End Sub
End Class
