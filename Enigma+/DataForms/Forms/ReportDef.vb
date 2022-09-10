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
Public Class ReportDef
    Private connString As String
    Private conn As SQLiteConnection
    Private cmd As SQLiteCommand
    Private rdr As SQLiteDataReader

    Public Sub New(ByVal connSTring As String)
        InitializeComponent()
        Me.connString = connSTring
    End Sub
    Private Sub ReportDef_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            conn = New SQLiteConnection(connString)
            conn.Open()
            cmd = New SQLiteCommand

            cmd.Connection = conn
            cmd.CommandText = "SELECT NAME FROM FORM_REPORTS ORDER BY NAME"
            rdr = cmd.ExecuteReader
            While rdr.Read
                cboReportName.Items.Add(rdr(0))
            End While
            rdr.Close()
            conn.Close()
            If cboReportName.Items.Count > 0 Then
                cboReportName.SelectedIndex = 0
            End If

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butAddReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAddReport.Click
        Try
            If cboReportName.Text.Trim = "" Or txtSQL.Text.Trim = "" Then
                MsgBox("Both required fields are empty", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            conn = New SQLiteConnection(connString)
            conn.Open()
            cmd = New SQLiteCommand

            cmd.Connection = conn
            cmd.CommandText = "SELECT NAME FROM FORM_REPORTS WHERE NAME='" & cboReportName.Text.Trim & "'"
            rdr = cmd.ExecuteReader
            If rdr.HasRows Then
                MsgBox("The report name is already in the Form, use a different name", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                rdr.Close()
                conn.Close()
                conn.Dispose()
                Exit Sub
            End If
            conn = New SQLiteConnection(connString)
            conn.Open()
            cmd = New SQLiteCommand

            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO FORM_REPORTS(NAME,FIELDS,INBUILT) VALUES(@NAME,@FIELDS,@INBUILT)"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("NAME", Data.DbType.String)
            cmd.Parameters.Add("FIELDS", Data.DbType.String)
            cmd.Parameters("NAME").Value = cboReportName.Text.Trim
            cmd.Parameters("FIELDS").Value = txtSQL.Text.Trim
            cmd.Parameters("INBUILT").Value = "N"
            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            MsgBox("This requires reopeing of the form, to see new report", MsgBoxStyle.Exclamation)
            Exit Sub
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butModifyReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butModifyReport.Click
        Try
            If cboReportName.Text.Trim = "" Or txtSQL.Text.Trim = "" Then
                MsgBox("Both required fields are empty", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            conn = New SQLiteConnection(connString)
            conn.Open()
            cmd = New SQLiteCommand

            cmd.Connection = conn
            cmd.Connection = conn
            cmd.CommandText = "SELECT NAME FROM FORM_REPORTS WHERE NAME='" & cboReportName.Text.Trim & "'"
            rdr = cmd.ExecuteReader
            If rdr.HasRows = False Then
                MsgBox("The report doesn't exist to be modified. Use insert instead", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                rdr.Close()
                conn.Close()
                conn.Dispose()
                Exit Sub
            End If
            conn = New SQLiteConnection(connString)
            conn.Open()
            cmd = New SQLiteCommand

            cmd.Connection = conn
            cmd.CommandText = "UPDATE FORM_REPORTS SET FIELDS=@VALUES WHERE NAME=@NAME"
            cmd.Parameters.Clear()
            cmd.Parameters.Add("NAME", Data.DbType.String)
            cmd.Parameters.Add("FIELDS", Data.DbType.String)
            cmd.Parameters("NAME").Value = cboReportName.Text.Trim
            cmd.Parameters("FIELDS").Value = txtSQL.Text.Trim
            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            MsgBox("This requires reopeing of the form, to see modified report", MsgBoxStyle.Exclamation)
            Exit Sub
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butDeleteReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDeleteReport.Click
        Try
            If cboReportName.Text.Trim Then
                MsgBox("Name is empty", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            conn = New SQLiteConnection(connString)
            conn.Open()
            cmd = New SQLiteCommand

            cmd.Connection = conn
            cmd.Connection = conn
            cmd.CommandText = "DELETE FROM FORM_REPORTS WHERE NAME='" & cboReportName.Text.Trim & "'"
            cmd.ExecuteNonQuery()
            cboReportName.Items.Remove(cboReportName.SelectedItem)
            conn.Close()
            conn.Dispose()
            MsgBox("This requires reopeing of the form, remove the deleted report", MsgBoxStyle.Exclamation)
            Exit Sub
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub cboReportName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.SelectedIndexChanged
        Try
            conn = New SQLiteConnection(connString)
            conn.Open()
            cmd = New SQLiteCommand

            cmd.Connection = conn
            cmd.Connection = conn
            cmd.CommandText = "SELECT FIELDS FROM FORM_REPORTS WHERE NAME='" & cboReportName.Text.Trim & "'"
            rdr = cmd.ExecuteReader
            If rdr.Read Then
                txtSQL.Text = rdr(0)
            End If
            rdr.Close()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
End Class