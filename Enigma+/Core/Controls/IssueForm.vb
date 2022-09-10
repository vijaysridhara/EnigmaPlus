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
Public Class IssueForm
    Private CONN As System.Data.SQLite.SQLiteConnection
    Private CMD As New SQLiteCommand
    Private RDR As SQLiteDataReader
    Private connString As String = "Data Source=#FILE#;Version=3;"
    Private currentFilter As String
    Private ismodify As Boolean
    Private currentID As Integer
    Event UpdatedItem()
    Public Sub LoadItems(ByVal filter As String)
        Dim cm As New ClosingMsg("Populating", "Populating grid...")
        Try
            If CONN Is Nothing Then
                CONN = New SQLiteConnection
                connString = connString.Replace("#FILE#", UserWorkItems)
                CONN.ConnectionString = connString
                CONN.Open()
            ElseIf CONN.State = Data.ConnectionState.Closed Then
                CONN.Open()
            End If
            CMD.Parameters.Clear()
            dgdItems.Rows.Clear()

            cm.Show(Me.Parent)
            CMD.Connection = CONN
            CMD.CommandText = "SELECT ID,SUMMARY,RAISEDON,RAISEDBY,RESOLUTION,STATUS FROM ISSUES WHERE " + filter
            currentFilter = filter
            RDR = CMD.ExecuteReader
            While RDR.Read
                Dim DGDR As New DataGridViewRow
                For I As Integer = 0 To RDR.FieldCount - 1
                    Dim DGC As New DataGridViewTextBoxCell
                    DGC.Style.Font = New Font("MS Sans Serif", 9)
                    If RDR.GetDataTypeName(I) = "DATETIME" Then
                        DGC.Value = Format(RDR(I), "dd-MMM-yyyy HH:mm:ss")
                    Else
                        DGC.Value = RDR(I).ToString
                    End If
                    DGDR.Cells.Add(DGC)
                Next
                DGDR.Tag = RDR(0)
                dgdItems.Rows.Add(DGDR)
            End While
            RDR.Close()

        Catch ex As Exception
            DE(ex)
        Finally
            cm.Close()
        End Try
    End Sub
 

    Public Sub LoadItems(ByVal SERIAL As Integer)
        Try

            ismodify = True
            CMD.Parameters.Clear()
            CMD.CommandText = "SELECT ID,SUMMARY,DETAILS,RAISEDON,RAISEDBY,RESOLUTION,STATUS,FILE,CREATEDON,LASTUPT FROM ISSUES WHERE ID=" & SERIAL
            currentID = SERIAL
            RDR = CMD.ExecuteReader
            If RDR.Read Then
                txtSummary.Text = RDR(1)
                txtDescription.Text = RDR(2).ToString
                dtpRaisedon.Value = RDR(3)
                txtRaisedBy.Text = RDR(4)
                txtResolution.Text = RDR(5)
                cboStatus.Text = RDR(6)
                blobFile.Blob = RDR(7)
                lblCreatedOn.Text = "Created on: " + Format(RDR(8), "dd-MMM-yyyy HH:mm:ss")
                lblLastUpdated.Text = "Updated on: " + Format(RDR(9), "dd-MMM-yyyy HH:mm:ss")
                lblCreatedOn.Show()
                lblLastUpdated.Show()
            End If
            butSubmit.Text = "Modif&y"
            RDR.Close()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public Sub LoadItems(ByVal filter As String, ByVal serial As Integer)
        Try
            If currentFilter <> filter Then LoadItems(filter)
            ismodify = True
            LoadItems(serial)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public Sub ClickSubmit(ByVal newStatus As String)
        cboStatus.Text = newStatus
        butSubmit_Click(Nothing, Nothing)
    End Sub
    Private Sub butSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSubmit.Click
        Try
            If String.IsNullOrEmpty(txtSummary.Text) Then
                MsgBox("Summary is empty", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            CMD.Parameters.Clear()
            If ismodify Then

                CMD.CommandText = "UPDATE ISSUES SET  SUMMARY=@SUMMARY,DETAILS=@DETAILS," & _
                    "RAISEDON=@RAISEDON,RAISEDBY=@RAISEDBY,RESOLUTION=@RESOLUTION,LASTUPT=@LASTUPT, " & _
                    "STATUS=@STATUS,FILE=@FILE WHERE ID=" & currentID
            Else
                CMD.CommandText = "INSERT INTO ISSUES(SUMMARY,DETAILS,RAISEDON,RAISEDBY,RESOLUTION,STATUS,FILE,CREATEDON,LASTUPT)" & _
                    "VALUES(@SUMMARY,@DETAILS,@RAISEDON,@RAISEDBY,@RESOLUTION,@STATUS,@FILE,@CREATEDON,@LASTUPT)"
                With CMD.Parameters
                    .Add("CREATEDON", Data.DbType.DateTime)
                    .Item("CREATEDON").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                End With
            End If
            With CMD.Parameters

                .Add("SUMMARY", Data.DbType.String)
                .Add("DETAILS", Data.DbType.String)
                .Add("RAISEDON", Data.DbType.DateTime)
                .Add("RAISEDBY", Data.DbType.String)
                .Add("RESOLUTION", Data.DbType.String)
                .Add("STATUS", Data.DbType.String)
                .Add("FILE", Data.DbType.Binary)
                .Add("LASTUPT", Data.DbType.DateTime)
                .Item("SUMMARY").Value = txtSummary.Text
                .Item("DETAILS").Value = IIf(String.IsNullOrEmpty(txtDescription.Text), "", txtDescription.Text)
                .Item("RAISEDON").Value = dtpRaisedon.Value
                .Item("RAISEDBY").Value = IIf(String.IsNullOrEmpty(txtRaisedBy.Text.Trim), "", txtRaisedBy.Text)
                .Item("RESOLUTION").Value = IIf(String.IsNullOrEmpty(txtResolution.Text.Trim), "", txtResolution.Text)
                .Item("STATUS").Value = IIf(String.IsNullOrEmpty(cboStatus.Text), "OPEN", cboStatus.Text)
                .Item("FILE").Value = blobFile.Blob
                .Item("LASTUPT").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
            End With
            CMD.ExecuteNonQuery()
            ClearControls()
            LoadItems(currentFilter)
            RaiseEvent UpdatedItem()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public Sub ClearAll()
        ClearControls()
        dgdItems.Rows.Clear()
    End Sub
    Public Sub ShowItem()
        Dim wi As New WorkItemDetails
        Dim fst As String = wi.txtIssue.Text

        fst = fst.Replace("#ID#", currentID)
        fst = fst.Replace("#SUMMARY#", txtSummary.Text)

        fst = fst.Replace("#DETAILS#", txtDescription.Text.Replace(vbLf, "<br>"))

        fst = fst.Replace("#RAISEDON#", "<br>" & Format(dtpRaisedon.Value, "dd-MMM-yyyy HH:mm:ss"))
        fst = fst.Replace("#RAISEDBY#", "<br>" & txtRaisedBy.Text)
        fst = fst.Replace("#RESOLUTION#", "<br>" & txtResolution.Text.Replace(vbLf, "<br>"))
        fst = fst.Replace("#STATUS#", "<br>" & cboStatus.Text)
        fst = fst.Replace("#CREATED#", "<br>" & lblCreatedOn.Text)
        wi.WebBrowser1.DocumentText = fst
        wi.Show()
    End Sub
    Public Sub ClearControls()
        For Each ct As Control In Me.Controls
            If TypeOf ct Is TextBox Then
                ct.Text = ""
            ElseIf TypeOf ct Is Blobber Then
                CType(ct, Blobber).Blob = Nothing
            End If
        Next

        lblCreatedOn.Hide()

        lblLastUpdated.Hide()
        ismodify = False
        butSubmit.Text = "&Add issue"
    End Sub
    Private Sub butNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNew.Click

        ClearControls()
    End Sub

    Private Sub dgdItems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdItems.CellClick
        If e.RowIndex = -1 Then Exit Sub
        Dim fil As Integer = dgdItems.Rows(e.RowIndex).Tag
        LoadItems(currentFilter, fil)

    End Sub

    Private Sub IssueForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        'On Error Resume Next
        'CMD.Dispose()
        'CONN.Close()

    End Sub
End Class
