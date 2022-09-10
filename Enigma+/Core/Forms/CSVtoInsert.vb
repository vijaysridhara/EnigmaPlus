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
Public Class CSVtoInsert
    Dim Headers() As String
    Dim Lines() As String
    Dim insertSTring As String = "INSERT INTO #TABLE#(#NAMESTRING#) VALUES(#VALSTRING#);"
    Dim NAMESTRING As String
    Dim VALUESTRING As String
    Private Sub butSelectCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSelectCSV.Click
        Dim ofd As New OpenFileDialog()
        With ofd
            .Filter = "Comma Separated Values(*.csv)|*.csv"
            .InitialDirectory = My.Settings.CurrentProjDir
            If .ShowDialog = DialogResult.OK Then
                txtCSV.Text = .FileName
                Dim sr As New IO.StreamReader(.FileName)
                Lines = sr.ReadToEnd.Split(vbLf)
                sr.Close()
                sr.Dispose()
                If Lines.Length < 2 Then
                    MsgBox("Only one line is present so cannot generate", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                Headers = Lines(0).Split(",")
                If Headers.Length <= 1 Then
                    MsgBox("There are only one or two headers and I dont like this", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                chkCSV.Items.Clear()
                For Each hd As String In Headers
                    chkCSV.Items.Add(hd)
                Next
                butGen.Enabled = True
                txtTable.Enabled = True
                chkCSV.Enabled = True
            End If
        End With
    End Sub

    Private Sub butExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()

    End Sub

    Private Sub butGen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGen.Click
        Try
            NAMESTRING = ""
            For Each hdr In Headers
                NAMESTRING += "," & hdr
            Next
            NAMESTRING = NAMESTRING.Substring(1)
            Dim workItems As New List(Of String)
            Dim insItem As String
            Dim LN As String, VALS() As String
            For I As Integer = 1 To Lines.Length - 1
                LN = Lines(I).Trim
                VALS = LN.Split(",")
                If Headers.Length <> VALS.Length Then
                    txtErrors.Text = "No of items mismatch at line: " & CStr(I + 2) + vbCrLf
                    Continue For
                End If
                VALUESTRING = ""
                Dim j As Integer = 0
                For Each hd As String In Headers
                    If chkCSV.CheckedItems.Contains(hd) Then
                        VALUESTRING += "," & VALS(j)
                    Else
                        VALUESTRING += ",'" & VALS(j) & "'"
                    End If
                    j += 1
                Next
                VALUESTRING = VALUESTRING.Substring(1)
                insItem = insertSTring.Replace("#TABLE#", txtTable.Text).Replace("#NAMESTRING#", NAMESTRING).Replace("#VALSTRING#", VALUESTRING)
                workItems.Add(insItem)
            Next
            txtOutput.Lines = workItems.ToArray

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)

        End Try
    End Sub
End Class