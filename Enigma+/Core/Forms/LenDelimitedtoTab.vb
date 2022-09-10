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
Public Class LenDelimitedtoTab
    Dim lines() As String
    Dim Fields As New List(Of LenField)
    Dim FINALlENGTH As Integer
    Private Sub butSelectCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ofd As New OpenFileDialog()
        With ofd
            .Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"
            .InitialDirectory = My.Settings.CurrentProjDir
            If .ShowDialog = DialogResult.OK Then
                txtText.Text = .FileName
                Dim sr As New IO.StreamReader(.FileName)
                lines = sr.ReadToEnd.Split(vbLf)
                sr.Close()
                sr.Dispose()
                Try

                    For Each ln As String In lines
                        ln = ln.Trim
                        If ln.Length = 0 Then Continue For
                        Dim hdrs() = ln.Split(" ")
                        For Each hd As String In hdrs
                            If String.IsNullOrEmpty(hd) Then Continue For
                            Dim fd As New LenField
                            fd.Name = hd
                            fd.StartPos = ln.IndexOf(hd)
                            Dim ix As Integer = fd.StartPos + hd.Length
                            If ix = ln.Length Then GoTo AddField
                            Dim ch As Char = ln.Substring(ix, 1)

                            While ch = " " And ix < ln.Length - 1
                                ix += 1
                                ch = ln.Substring(ix, 1)
                            End While
AddField:
                            If ix = ln.Length Then
                                fd.Length = ix - fd.StartPos
                            Else
                                fd.Length = ix - fd.StartPos - 1
                            End If
                            FINALlENGTH += fd.Length

                            Fields.Add(fd)

                        Next
                        Exit Sub
                    Next
                Catch ex As Exception
                    DE(ex)
                End Try
            End If
        End With
    End Sub

    Private Sub butExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()

    End Sub

    Private Sub butGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGen.Click
        Try
            If txtCSV.Text = "" Or txtText.Text = "" Then
                MsgBox("Please select both input and output files", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            txtOutput.Clear()
            Dim sw As New IO.StreamWriter(txtCSV.Text)
            Dim i As Integer = -1
            Dim header As String
            Dim FLDVAL As String
            Dim delimter As String
            Select Case ComboBox1.Text
                Case "Tab"
                    delimter = vbTab
                Case "Comma"
                    delimter = ","
                Case "Semicolon"
                    delimter = ";"
                Case "Colon"
                    delimter = ":"
                Case "Char(255)"
                    delimter = Chr(255)
                Case Else
                    delimter = vbTab
            End Select
            For Each ln As String In lines
                'ln = ln.Trim
                header = ""
                i += 1
                lblCount.Text = i
                lblCount.Refresh()

                If ln.Length < FINALlENGTH Then
                    txtOutput.Text += "Length doesnt match for line:" & i & vbCrLf
                    Continue For
                End If
                For Each hdr As LenField In Fields
                    'If hdr.Name = "FILE_NAME" Then
                    '    MsgBox("HI")
                    'End If
                    FLDVAL = ln.Substring(hdr.StartPos, hdr.Length).Trim
                    header += delimter + IIf(String.IsNullOrEmpty(FLDVAL), "NULL", FLDVAL)
                Next
                header = header.Substring(1)
                sw.WriteLine(header)
            Next
            sw.Close()
            sw.Dispose()
            MsgBox("Completed...", MsgBoxStyle.Exclamation)
        Catch ex As System.IO.IOException

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butSelectCSV_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSelectCSV.Click
        Try
            Dim ofd As New SaveFileDialog()
            With ofd
                .Filter = "All Files(*.*)|*.*"
                .InitialDirectory = My.Settings.CurrentProjDir
                If .ShowDialog = DialogResult.OK Then
                    txtCSV.Text = .FileName
                End If
            End With
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
End Class