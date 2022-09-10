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
Public Class Quickfix
    Private file As String
    Dim conn As SQLiteConnection
    Private connString As String = "Data Source=#FILE#;Version=3;"

    Dim cmd As New SQLiteCommand
    Public Sub New(ByVal fname As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.file = fname
        connString = connString.Replace("#FILE#", file)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            conn = New SQLiteConnection(connString)
            conn.Open()
            Dim cmd As New SQLiteCommand
            cmd.Connection = conn
            cmd.CommandText = FastColoredTextBox1.Text
            Dim cnt As Integer = cmd.ExecuteNonQuery
            MsgBox("Executed command successfully [Affected data:" & cnt & "]", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            If Not conn Is Nothing Then
                conn.Close()
                conn.Dispose()
            End If
        End Try
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.Close()
    End Sub
End Class