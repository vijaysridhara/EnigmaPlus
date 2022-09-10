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
Public Class QuickWorkItem
    Private conn As SQLiteConnection
    Private cmd As New SQLiteCommand
    Private rdr As SQLiteDataReader
    Private connString As String = "Data Source=#FILE#;Version=3;"
    Dim entrytype As String
    Private Sub butOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        If String.IsNullOrEmpty(txtSummary.Text) Then Exit Sub
        If cboReleaseID.Enabled Then If cboReleaseID.SelectedIndex = -1 Then Exit Sub
        If entrytype = "Tasks" Then
            Select Case cboFreq.Text
                Case "TODAY"
                    cmd.CommandText = "INSERT INTO TASKS(RELID,SUMMARY,DETAILS,SDATE,EDATE,ASSIGNEDTO,HOURS,EMAIL,STATUS,FILE,CREATEDON,LASTUPT)" & _
                   "VALUES(@RELID,@SUMMARY,@DETAILS,@SDATE,@EDATE,@ASSIGNEDTO,@HOURS,@EMAIL,@STATUS,@FILE,@CREATEDON,@LASTUPT)"
                    With cmd.Parameters
                        .Add("CREATEDON", Data.DbType.DateTime)
                        .Add("RELID", Data.DbType.String)
                        .Add("SUMMARY", Data.DbType.String)
                        .Add("DETAILS", Data.DbType.String)
                        .Add("SDATE", Data.DbType.DateTime)
                        .Add("EDATE", Data.DbType.DateTime)
                        .Add("ASSIGNEDTO", Data.DbType.String)
                        .Add("HOURS", Data.DbType.Decimal)
                        .Add("EMAIL", Data.DbType.String)
                        .Add("STATUS", Data.DbType.String)
                        .Add("FILE", Data.DbType.Binary)
                        .Add("LASTUPT", Data.DbType.DateTime)
                        .Item("RELID").Value = cboReleaseID.Text
                        .Item("SUMMARY").Value = txtSummary.Text
                        .Item("DETAILS").Value = ""
                        .Item("SDATE").Value = Date.Now
                        .Item("EDATE").Value = Date.Now.AddDays(1)
                        .Item("HOURS").Value = 8
                        .Item("EMAIL").Value = ""
                        .Item("ASSIGNEDTO").Value = ""
                        .Item("STATUS").Value = "OPEN"
                        .Item("FILE").Value = Nothing
                        .Item("CREATEDON").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                        .Item("LASTUPT").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                    End With
                    cmd.ExecuteNonQuery()
                Case "WEEKLY", "MONTHLY", "ONETIME"
                    cmd.CommandText = "INSERT INTO FREQTASKS(RELID,SUMMARY,TASKFREQ,ONDAY) VALUES(@RELID,@SUMMARY,@TASKFREQ,@ONDAY)"
                    cmd.Parameters.Clear()
                    With cmd.Parameters
                        .Add("RELID", Data.DbType.String)
                        .Add("SUMMARY", Data.DbType.String)
                        .Add("TASKFREQ", Data.DbType.String)
                        .Add("ONDAY", Data.DbType.String)
                        cmd.Parameters("RELID").Value = cboReleaseID.Text
                        cmd.Parameters("SUMMARY").Value = txtSummary.Text
                        cmd.Parameters("TASKFREQ").Value = cboFreq.Text
                        Dim DT As String
                        If cboFreq.Text = "ONETIME" Then
                            DT = Format(dtpOnetime.Value, "yyyy-MM-dd")
                        Else
                            DT = cboSubFreq.Text
                        End If
                        cmd.Parameters("ONDAY").Value = DT
                    End With
                    cmd.ExecuteNonQuery()
            End Select
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub QuickWorkItem_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If cmd IsNot Nothing Then cmd.Dispose()
        If conn IsNot Nothing Then conn.Close()

    End Sub
    Public Sub New(ByVal tp As String)
        InitializeComponent()
        entrytype = tp
        If tp = "Tasks" Then
            cboFreq.Enabled = True
        ElseIf tp = "Issues" Then
            cboReleaseID.Enabled = False
        End If
    End Sub

    Private Sub QuickWorkItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If cboReleaseID.Enabled Then
                LoadReleases()
            End If
            cboFreq.SelectedIndex = 0
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public Sub LoadReleases()
        Try
            If CONN Is Nothing Then
                CONN = New SQLiteConnection
                connString = connString.Replace("#FILE#", UserWorkItems)
                CONN.ConnectionString = connString
                CONN.Open()
            ElseIf CONN.State = Data.ConnectionState.Closed Then
                CONN.Open()
            End If
            cboReleaseID.Items.Clear()
            CMD.Connection = CONN
            CMD.CommandText = "SELECT RELID FROM RELEASES ORDER BY LASTUPT DESC"
            RDR = CMD.ExecuteReader
            cboReleaseID.Items.Clear()
            While RDR.Read
                cboReleaseID.Items.Add(rdr(0))

            End While
           

            If cboReleaseID.Items.Count > 0 Then
                cboReleaseID.SelectedIndex = 0
            End If

            rdr.Close()

        Catch ex As Exception
            DE(ex)


        End Try
    End Sub
    Dim WKITMS = "A-MON,1-MON,2-MON,3-MON,4-MON,L-MON,A-TUE," & _
        "1-TUE,2-TUE,3-TUE,4-TUE,L-TUE,A-WED,1-WED,2-WED,3-WED," & _
        "4-WED,L-WED,A-THU,1-THU,2-THU,3-THU,4-THU,L-THU,A-FRI,1-FRI," & _
        "2-FRI,3-FRI,4-FRI,L-FRI,A-SAT,1-SAT,2-SAT,3-SAT,4-SAT,L-SAT,1-SUN,2-SUN,3-SUN,4-SUN,L-SUN"
    Private Sub cboFreq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFreq.SelectedIndexChanged
        Select Case cboFreq.Text
            Case "TODAY"
                dtpOnetime.Hide()
                cboSubFreq.Hide()
            Case "WEEKLY"
                cboSubFreq.Show()
                dtpOnetime.Hide()
                cboSubFreq.Items.Clear()
                Dim ST() As String = WKITMS.SPLIT(",")
                For Each S As String In ST
                    cboSubFreq.Items.Add(S)
                Next
                cboSubFreq.SelectedIndex = 0
            Case "MONTHLY"
                cboSubFreq.Show()
                dtpOnetime.Hide()
                cboSubFreq.Items.Clear()
                For I As Integer = 1 To 31
                    cboSubFreq.Items.Add(I)
                Next
                cboSubFreq.SelectedIndex = 0
            Case "ONETIME"
                dtpOnetime.Show()
                cboSubFreq.Hide()
                dtpOnetime.Value = Date.Now
        End Select
    End Sub
End Class