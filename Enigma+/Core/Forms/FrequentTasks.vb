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
Public Class FrequentTasks
    Private conn As SQLiteConnection
    Private cmd As New SQLiteCommand
    Private rdr As SQLiteDataReader
    Private connString As String = "Data Source=#FILE#;Version=3;"
    Private Sub butOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        Me.Close()

    End Sub

    Private Sub FrequentTasks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            rdr.Close()

            cmd.Dispose()
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrequentTasks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If conn Is Nothing Then
                conn = New SQLiteConnection
                connString = connString.Replace("#FILE#", UserWorkItems)
                conn.ConnectionString = connString
                conn.Open()
            ElseIf conn.State = Data.ConnectionState.Closed Then
                conn.Open()
            End If

            cmd.Connection = conn
            LoadFQT()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub LoadFQT()
        Try
            DataGridView1.Rows.Clear()
            cmd.CommandText = "SELECT ID,RELID,SUMMARY,TASKFREQ,ONDAY FROM FREQTASKS ORDER BY TASKFREQ,RELID"
            rdr = cmd.ExecuteReader
            While rdr.Read
                Dim DGR As New DataGridViewRow
                For I As Integer = 1 To rdr.FieldCount - 1
                    Dim DGT As New DataGridViewTextBoxCell
                    DGT.Value = rdr(I)
                    DGR.Cells.Add(DGT)

                Next
                DGR.Tag = rdr(0)
                DataGridView1.Rows.Add(DGR)
            End While
            rdr.Close()

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Try

            If e.KeyCode <> Keys.Delete Then Exit Sub
            If DataGridView1.SelectedRows.Count = 0 Then
                MsgBox("Select a row to delete", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If MsgBox("Do you really want to delete this entry?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            For Each dr As DataGridViewRow In DataGridView1.SelectedRows
                cmd.CommandText = "DELETE FROM FREQTASKS WHERE ID=" & dr.Tag
                cmd.ExecuteNonQuery()
            Next
            LoadFQT()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
End Class