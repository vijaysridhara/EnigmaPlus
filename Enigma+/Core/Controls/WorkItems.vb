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
Imports VijaySridhara.Libraries
Public Class WorkItems
    Private CONN As System.Data.SQLite.SQLiteConnection
    Private CMD As New SQLiteCommand
    Private RDR As SQLiteDataReader
    Private connString As String = "Data Source=#FILE#;Version=3;"
    Private LoadedTaskFilters As New Collection
    Private LoadedDefectFilters As New Collection
    Private LoadedIssueFilters As New Collection
    Private Sub LoadFreqTasks()
        Try
            Dim curDate As Date = Date.Now
            Dim todaynum As Integer = curDate.Day
            Dim wkday As DayOfWeek = curDate.DayOfWeek
            Dim wkno As Integer
            If Int(curDate.Day / 7) * 7 = curDate.Day Then
                wkno = curDate.Day / 7
            Else
                wkno = curDate.Day / 7 + 1
            End If
            Dim islastwk As Boolean
            If curDate.AddDays(7).Month > curDate.Month Then
                islastwk = True
            End If
            Dim tag As String = IIf(islastwk, "L", wkno) & "-" & [Enum].GetName(GetType(DayOfWeek), wkday).Substring(0, 3).ToUpper
            Dim tag1 As String = "A-" & [Enum].GetName(GetType(DayOfWeek), wkday).Substring(0, 3).ToUpper
            CMD.Parameters.Clear()
            CMD.CommandText = "SELECT RELID,SUMMARY,TASKFREQ,ONDAY FROM FREQTASKS WHERE " &
                "(TASKFREQ='WEEKLY' AND (ONDAY='" & tag & "' OR ONDAY='" & tag1 & "')) OR (TASKFREQ='MONTHLY' AND ONDAY='" & todaynum & "')" &
                " OR (TASKFREQ='ONETIME' AND ONDAY='" & Format(curDate, "yyyy-MM-dd") & "')"
            RDR = CMD.ExecuteReader
            Dim cmd1 As New SQLiteCommand
            Dim rdr1 As SQLiteDataReader
            cmd1.Connection = CONN
            While RDR.Read
                cmd1.Parameters.Clear()
                cmd1.CommandText = "SELECT 1 FROM TASKS WHERE DATE(CREATEDON)='" & Format(curDate, "yyyy-MM-dd") & "'" &
                    " AND SUMMARY='" & RDR(1) & "' AND RELID='" & RDR(0) & "'"
                rdr1 = cmd1.ExecuteReader
                If rdr1.Read Then
                    rdr1.Close()
                Else
                    rdr1.Close()

                    cmd1.CommandText = "INSERT INTO TASKS(RELID,SUMMARY,DETAILS,SDATE,EDATE,ASSIGNEDTO,HOURS,EMAIL,STATUS,FILE,CREATEDON,LASTUPT)" &
             "VALUES(@RELID,@SUMMARY,@DETAILS,@SDATE,@EDATE,@ASSIGNEDTO,@HOURS,@EMAIL,@STATUS,@FILE,@CREATEDON,@LASTUPT)"
                    With cmd1.Parameters
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
                        .Item("RELID").Value = RDR(0)
                        .Item("SUMMARY").Value = RDR(1)
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
                    cmd1.ExecuteNonQuery()
                End If
            End While
            RDR.Close()

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub tlstpTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlstpTasks.Click
        TaskForm1.Show()
        DefectForm1.Hide()
        IssueForm1.Hide()
        TaskForm1.Dock = DockStyle.Fill
        lblTitle.Text = "Tasks"
        tvwMain.Tag = "Tasks"
        LoadFreqTasks()
        LoadItems("Tasks")


    End Sub

    Private Sub tlstpDefects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlstpDefects.Click
        TaskForm1.Hide()
        DefectForm1.Show()
        IssueForm1.Hide()
        DefectForm1.Dock = DockStyle.Fill
        LoadItems("Defects")
        lblTitle.Text = "Defects"

    End Sub

    Private Sub tlstpIssues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tlstpIssues.Click
        TaskForm1.Hide()
        DefectForm1.Hide()
        IssueForm1.Show()
        IssueForm1.Dock = DockStyle.Fill
        LoadItems("Issues")
        lblTitle.Text = "Issues"

    End Sub

    Private Sub pnlRight_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error Resume Next
        For Each c As Control In pnlRight.Controls
            c.Location = New Point(0, 0)
        Next
    End Sub


    Private Sub Task_Allotment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            connString = connString.Replace("#FILE#", UserWorkItems)
            CONN = New SQLiteConnection(connString)
            CONN.Open()
            LoadREleases()
            tlstpTasks_Click(Nothing, Nothing)

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub LoadItems(ByVal type As String)
        Dim CM As New ClosingMsg("Loading", "Loading " & type & "...")

        Try
            CM.Show(Me)
            tvwMain.Nodes.Clear()
            tvwMain.Tag = type
            Dim rootimindex As Integer = IIf(type = "Tasks", 0, IIf(type = "Defects", 1, 2))
            Dim rn As New TreeNode(type, rootimindex, rootimindex)
            tvwMain.Nodes.Add(rn)
            CMD.CommandText = "SELECT NAME, FILTER,PRELOAD FROM FILTERS WHERE CATEGORY='" + type + "'"
            CMD.Connection = CONN
            RDR = CMD.ExecuteReader
            While RDR.Read
                Dim cn As TreeNode = rn.Nodes.Add(RDR(0).ToString & ":(Not loaded)")
                cn.Tag = RDR(1)
                cn.ImageIndex = 3
                cn.SelectedImageIndex = 3
                If RDR(2) = "Y" Then
                    Select Case tvwMain.Tag
                        Case "Tasks"
                            If LoadedTaskFilters.Contains(RDR(0)) = False Then
                                LoadedTaskFilters.Add(RDR(0))
                            End If
                        Case "Defects"
                            If LoadedDefectFilters.Contains(RDR(0)) = False Then
                                LoadedDefectFilters.Add(RDR(0))
                            End If
                        Case "Issues"
                            If LoadedIssueFilters.Contains(RDR(0)) = False Then
                                LoadedIssueFilters.Add(RDR(0))
                            End If
                    End Select
                End If
            End While
            RDR.Close()

            If tvwMain.Tag = "Tasks" Then
                TaskForm1.LoadReleases()
            ElseIf tvwMain.Tag = "Defects" Then
                DefectForm1.LoadReleases()
            End If

            rn.Expand()
            If tvwMain.Nodes(0).Nodes.Count > 0 Then
                tvwMain.SelectedNode = tvwMain.Nodes(0).Nodes(0)
                Dim fx As Collection = IIf(tvwMain.Tag = "Tasks", LoadedTaskFilters, IIf(tvwMain.Tag = "Defects", LoadedDefectFilters, LoadedIssueFilters))
                For Each st As String In fx
                    For Each nd As TreeNode In tvwMain.Nodes(0).Nodes
                        If nd.Text.Split(":")(0) = st Then
                            LoadChildren(nd)
                            Exit For
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            DE(ex)
        Finally
            CM.Close()
        End Try
    End Sub

    Private Sub LoadChildren(ByVal nd As TreeNode)
        Try
            nd.Nodes.Clear()
            nd.Text = nd.Text.Split(":")(0) & ":(Loaded)"
            Select Case tvwMain.Tag
                Case "Tasks"
                    If LoadedTaskFilters.Contains(nd.Text.Split(":")(0)) Then Exit Select
                    LoadedTaskFilters.Add(nd.Text.Split(":")(0), nd.Text.Split(":")(0))
                Case "Defects"
                    If LoadedDefectFilters.Contains(nd.Text.Split(":")(0)) Then Exit Select
                    LoadedDefectFilters.Add(nd.Text.Split(":")(0), nd.Text.Split(":")(0))
                Case "Issues"
                    If LoadedIssueFilters.Contains(nd.Text.Split(":")(0)) Then Exit Select
                    LoadedIssueFilters.Add(nd.Text.Split(":")(0), nd.Text.Split(":")(0))
            End Select
            CMD.CommandText = "SELECT ID,SUMMARY,STATUS FROM " & tvwMain.Tag & " WHERE " & nd.Tag
            RDR = CMD.ExecuteReader
            While RDR.Read
                Dim NEWND As TreeNode
                Select Case RDR(2)
                    Case "OPEN"
                        NEWND = New TreeNode(RDR(1), 6, 6)
                    Case "ASSIGNED"
                        NEWND = New TreeNode(RDR(1), 7, 7)
                    Case "INPROGRESS"
                        NEWND = New TreeNode(RDR(1), 8, 8)
                    Case "COMPLETED", "RESOLVED"
                        NEWND = New TreeNode(RDR(1), 9, 9)
                    Case "REJECTED"
                        NEWND = New TreeNode(RDR(1), 10, 10)
                    Case Else
                        NEWND = New TreeNode(RDR(1), 6, 6)
                End Select
                NEWND.Tag = RDR(0)
                nd.Nodes.Add(NEWND)
            End While
            nd.Expand()
            RDR.Close()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        If String.IsNullOrEmpty(txtFilter.Text) Or String.IsNullOrEmpty(txtFilterName.Text) Then
            MsgBox("One of the fields is empty", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            CMD.CommandText = "INSERT INTO FILTERS(NAME,CATEGORY,FILTER,PRELOAD) VALUES(@NAME,@CATEGORY,@FILTER,@PRELOAD)"
            CMD.Parameters.Clear()
            CMD.Parameters.Add("NAME", Data.DbType.String)
            CMD.Parameters.Add("CATEGORY", Data.DbType.String)
            CMD.Parameters.Add("FILTER", Data.DbType.String)
            CMD.Parameters.Add("PRELOAD", Data.DbType.String)
            With CMD.Parameters
                .Item("NAME").Value = txtFilterName.Text
                .Item("CATEGORY").Value = tvwMain.Tag
                .Item("FILTER").Value = txtFilter.Text
                .Item("PRELOAD").Value = IIf(chkPreload.Checked, "Y", "N")
            End With
            CMD.ExecuteNonQuery()
            txtFilterName.Clear()
            txtFilter.Clear()
            LoadItems(tvwMain.Tag)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub tvwMain_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwMain.AfterSelect
        If e.Node.ImageIndex = 3 Or e.Node.SelectedImageIndex = 4 Then
            txtFilterName.Text = e.Node.Text.Split(":")(0)
            txtFilter.Text = e.Node.Tag
            txtFilter.Enabled = True
            txtFilterName.Enabled = True
            chkPreload.Checked = GetPreloadfor(txtFilterName.Text)
            Try
                Select Case tvwMain.Tag
                    Case "Tasks"
                        TaskForm1.ClearControls()
                        TaskForm1.LoadItems(e.Node.Tag)

                    Case "Defects"
                        DefectForm1.ClearControls()
                        DefectForm1.LoadItems(e.Node.Tag)
                    Case "Issues"
                        IssueForm1.ClearControls()
                        IssueForm1.LoadItems(e.Node.Tag)
                End Select
            Catch ex As Exception
                DE(ex)

            End Try

        ElseIf e.Node.ImageIndex > 4 Then
            txtFilterName.Clear()
            txtFilter.Clear()
            txtFilter.Enabled = False
            txtFilterName.Enabled = False

            Try
                Select Case tvwMain.Tag
                    Case "Tasks"
                        TaskForm1.LoadItems(e.Node.Parent.Tag, e.Node.Tag)
                    Case "Defects"
                        DefectForm1.LoadItems(e.Node.Parent.Tag, e.Node.Tag)
                    Case "Issues"
                        IssueForm1.LoadItems(e.Node.Parent.Tag, e.Node.Tag)

                End Select
            Catch ex As Exception
                DE(ex)

            End Try

        ElseIf e.Node.ImageIndex < 3 Then
            txtFilterName.Clear()
            txtFilter.Clear()
            txtFilter.Enabled = False
            txtFilterName.Enabled = False
        End If
    End Sub
    Private Function GetPreloadfor(ByVal nme As String) As Boolean
        Try
            CMD.CommandText = "SELECT PRELOAD FROM FILTERS WHERE NAME=@NAME AND CATEGORY=@CATEGORY"
            CMD.Parameters.Clear()
            CMD.Parameters.Add("NAME", Data.DbType.String)
            CMD.Parameters.Add("CATEGORY", Data.DbType.String)
            CMD.Parameters("NAME").Value = txtFilterName.Text
            CMD.Parameters("CATEGORY").Value = tvwMain.Tag
            RDR = CMD.ExecuteReader
            Dim RT As Boolean = False
            If RDR.Read Then
                RT = IIf(RDR(0) = "Y", True, False)
            End If
            RDR.Close()
            Return RT
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub tvwMain_BeforeCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvwMain.BeforeCollapse
        If e.Node.Nodes.Count > 0 And e.Node.ImageIndex > 2 Then
            e.Node.ImageIndex = 3
            e.Node.SelectedImageIndex = 3
        End If
    End Sub

    Private Sub tvwMain_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvwMain.BeforeExpand
        If e.Node.Nodes.Count > 0 And e.Node.ImageIndex > 2 Then
            e.Node.ImageIndex = 4
            e.Node.SelectedImageIndex = 4
        End If
    End Sub
    Private Sub LoadREleases()
        Try
            cboReleases.Items.Clear()
            CMD.Connection = CONN
            CMD.CommandText = "SELECT RELID FROM RELEASES ORDER BY LASTUPT DESC"
            RDR = CMD.ExecuteReader
            cboReleases.Items.Clear()
            While RDR.Read
                cboReleases.Items.Add(RDR(0))
            End While
            RDR.Close()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub butModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butModify.Click
        If String.IsNullOrEmpty(txtFilter.Text) Or String.IsNullOrEmpty(txtFilterName.Text) Then
            MsgBox("One of the fields is empty", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If tvwMain.SelectedNode.ImageIndex <> 3 And tvwMain.SelectedNode.ImageIndex <> 4 Then
            MsgBox("Select a filter node to modify", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            CMD.Parameters.Clear()
            CMD.CommandText = "UPDATE FILTERS SET NAME=@NAME,FILTER=@FILTER,PRELOAD=@PRELOAD WHERE NAME=@OLDNAME AND CATEGORY=@CATEGORY"

            CMD.Parameters.Add("NAME", Data.DbType.String)
            CMD.Parameters.Add("CATEGORY", Data.DbType.String)
            CMD.Parameters.Add("FILTER", Data.DbType.String)
            CMD.Parameters.Add("OLDNAME", Data.DbType.String)
            CMD.Parameters.Add("PRELOAD", Data.DbType.String)
            With CMD.Parameters
                .Item("NAME").Value = txtFilterName.Text
                .Item("FILTER").Value = txtFilter.Text
                .Item("PRELOAD").Value = IIf(chkPreload.Checked, "Y", "N")
                .Item("OLDNAME").Value = tvwMain.SelectedNode.Text.Split(":")(0)
                .Item("CATEGORY").Value = tvwMain.Tag
            End With
            CMD.ExecuteNonQuery()
            txtFilterName.Clear()
            txtFilter.Clear()
            LoadItems(tvwMain.Tag)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDelete.Click
        Try
            If tvwMain.SelectedNode.ImageIndex <> 3 And tvwMain.SelectedNode.ImageIndex <> 4 Then
                MsgBox("Select a filter node to modify", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            CMD.CommandText = "DELETE FROM FILTERS WHERE NAME=@NAME AND CATEGORY=@CATEGORY"
            CMD.Parameters.Clear()
            With CMD.Parameters
                CMD.Parameters.Add("NAME", Data.DbType.String)
                CMD.Parameters.Add("CATEGORY", Data.DbType.String)
                .Item("NAME").Value = txtFilterName.Text
                .Item("CATEGORY").Value = tvwMain.Tag
            End With
            CMD.ExecuteNonQuery()
            txtFilterName.Clear()
            txtFilter.Clear()
            LoadItems(tvwMain.Tag)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub TaskForm1_UpdatedItem() Handles TaskForm1.UpdatedItem, DefectForm1.UpdatedItem, IssueForm1.UpdatedItem
        Try
            LoadItems(tvwMain.Tag)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxTree_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxTree.Opening
        If tvwMain.SelectedNode Is Nothing Then
            e.Cancel = True
            Exit Sub
        End If

        If tvwMain.SelectedNode.ImageIndex <= 4 Then
            DeleteToolStripMenuItem.Enabled = False
            MarkToolStripMenuItem.Enabled = False
            ShowDetailsToolStripMenuItem.Enabled = False
        ElseIf tvwMain.SelectedNode.ImageIndex > 4 Then
            DeleteToolStripMenuItem.Enabled = True
            MarkToolStripMenuItem.Enabled = True
            ShowDetailsToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Dim ndid As Integer = tvwMain.SelectedNode.Tag
            If MsgBox("Do you want to delete this item?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            CMD.CommandText = "DELETE FROM " & tvwMain.Tag & " WHERE ID=" & ndid
            CMD.ExecuteNonQuery()
            Select Case tvwMain.Tag
                Case "Tasks"
                    TaskForm1.LoadItems(tvwMain.SelectedNode.Parent.Tag)
                    TaskForm1.ClearControls()
                Case "Defects"
                    DefectForm1.LoadItems(tvwMain.SelectedNode.Parent.Tag)
                    DefectForm1.ClearControls()
                Case "Issues"
                    IssueForm1.LoadItems(tvwMain.SelectedNode.Parent.Tag)
                    IssueForm1.ClearControls()
            End Select
            LoadItems(tvwMain.Tag)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            CMD.CommandText = "UPDATE " & tvwMain.Tag & " SET STATUS='OPEN' WHERE ID=" & tvwMain.SelectedNode.Tag
            CMD.ExecuteNonQuery()

            ReloadForms()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ClosedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClosedToolStripMenuItem.Click
        Try
            If tvwMain.Tag = "Issues" Then
                CMD.CommandText = "UPDATE " & tvwMain.Tag & " SET STATUS='RESOLVED' WHERE ID=" & tvwMain.SelectedNode.Tag
            Else
                CMD.CommandText = "UPDATE " & tvwMain.Tag & " SET STATUS='COMPLETED' WHERE ID=" & tvwMain.SelectedNode.Tag
            End If

            CMD.ExecuteNonQuery()

            ReloadForms()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub RejectedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RejectedToolStripMenuItem.Click
        Try
            CMD.CommandText = "UPDATE " & tvwMain.Tag & " SET STATUS='REJECTED' WHERE ID=" & tvwMain.SelectedNode.Tag
            CMD.ExecuteNonQuery()

            ReloadForms()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub AssignedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssignedToolStripMenuItem.Click
        Try
            CMD.CommandText = "UPDATE " & tvwMain.Tag & " SET STATUS='ASSIGNED' WHERE ID=" & tvwMain.SelectedNode.Tag
            CMD.ExecuteNonQuery()

            ReloadForms()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub InProgressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InProgressToolStripMenuItem.Click
        Try
            CMD.CommandText = "UPDATE " & tvwMain.Tag & " SET STATUS='INPROGRESS' WHERE ID=" & tvwMain.SelectedNode.Tag
            CMD.ExecuteNonQuery()

            ReloadForms()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub ReloadForms()

        Select Case tvwMain.Tag
            Case "Tasks"
                TaskForm1.LoadItems(tvwMain.SelectedNode.Parent.Tag)
                TaskForm1.ClearControls()
            Case "Defects"
                DefectForm1.LoadItems(tvwMain.SelectedNode.Parent.Tag)
                DefectForm1.ClearControls()
            Case "Issues"
                IssueForm1.LoadItems(tvwMain.SelectedNode.Parent.Tag)
                IssueForm1.ClearControls()
        End Select
        LoadItems(tvwMain.Tag)
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Select Case tvwMain.Tag
            Case "Tasks"
                TaskForm1.ClearControls()
                TaskForm1.Controls(0).Focus()
            Case "Defects"
                DefectForm1.ClearControls()
                DefectForm1.Controls(0).Focus()
            Case "Issues"
                IssueForm1.ClearControls()
                IssueForm1.Controls(0).Focus()
        End Select
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        If tvwMain.SelectedNode.ImageIndex < 3 Then
            LoadItems(tvwMain.Tag)

        ElseIf tvwMain.SelectedNode.ImageIndex < 5 Then
            LoadChildren(tvwMain.SelectedNode)

            Select Case tvwMain.Tag
                Case "Tasks"
                    TaskForm1.ClearAll()
                    TaskForm1.LoadItems(tvwMain.SelectedNode.Tag)
                Case "Defects"
                    DefectForm1.ClearAll()
                    DefectForm1.LoadItems(tvwMain.SelectedNode.Tag)
                Case "Issues"
                    IssueForm1.ClearAll()
                    IssueForm1.LoadItems(tvwMain.SelectedNode.Tag)
            End Select
        ElseIf tvwMain.SelectedNode.ImageIndex >= 5 Then
            Select Case tvwMain.Tag
                Case "Tasks"
                    TaskForm1.ClearAll()
                    TaskForm1.LoadItems(tvwMain.SelectedNode.Parent.Tag, tvwMain.SelectedNode.Tag)
                Case "Defects"
                    DefectForm1.ClearAll()
                    DefectForm1.LoadItems(tvwMain.SelectedNode.Parent.Tag, tvwMain.SelectedNode.Tag)
                Case "Issues"
                    IssueForm1.ClearAll()
                    IssueForm1.LoadItems(tvwMain.SelectedNode.Parent.Tag, tvwMain.SelectedNode.Tag)
            End Select
        End If



    End Sub

    Private Sub ShowDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowDetailsToolStripMenuItem.Click
        Try
            Select Case tvwMain.Tag
                Case "Tasks"
                    TaskForm1.ShowItem()

                Case "Defects"
                    DefectForm1.ShowItem()
                Case "Issues"
                    IssueForm1.ShowItem()
            End Select
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub


    Private Sub butAddRElease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAddRElease.Click
        Try
            If String.IsNullOrEmpty(txtRelname.Text) Then
                MsgBox("The release name should be specified", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            CMD.CommandText = "INSERT INTO RELEASES(RELID,RELNAME,LASTUPT) VALUES(@RELID,@RELNAME,@LASTUPT)"
            CMD.Parameters.Clear()
            With CMD.Parameters
                .Add("RELID", Data.DbType.String)
                .Add("RELNAME", Data.DbType.String)
                .Add("LASTUPT", Data.DbType.DateTime)
                CMD.Parameters("RELID").Value = txtRelname.Text
                CMD.Parameters("RELNAME").Value = txtRelname.Text
                CMD.Parameters("LASTUPT").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                CMD.ExecuteNonQuery()
            End With
            cboReleases.Items.Add(txtRelname.Text)
            txtRelname.Clear()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butDeleteRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDeleteRelease.Click
        Try
            If String.IsNullOrEmpty(cboReleases.Text) Then
                MsgBox("The release name should be specified", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If MsgBox("The delete of releasename would delete all children from tasks and defects. Do you want to continue?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            CMD.Parameters.Clear()
            CMD.CommandText = "DELETE FROM RELEASES WHERE RELID='" & cboReleases.Text & "'"
            CMD.ExecuteNonQuery()
            CMD.CommandText = "DELETE FROM TASKS WHERE RELID='" & cboReleases.Text & "'"
            CMD.ExecuteNonQuery()
            CMD.CommandText = "DELETE FROM DEFECTS WHERE RELID='" & cboReleases.Text & "'"
            CMD.ExecuteNonQuery()
            LoadItems(tvwMain.Tag)
            cboReleases.Items.RemoveAt(cboReleases.SelectedIndex)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub QuickAddToolstripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuickAddToolstripMenuItem.Click
        Try
            Dim Qi As New QuickWorkItem(tvwMain.Tag)
            Qi.Location = MousePosition

            If Qi.ShowDialog = DialogResult.OK Then
                Select Case tvwMain.Tag
                    Case "Tasks"
                        LoadFreqTasks()
                    Case "Defects"
                        CMD.Parameters.Clear()
                        CMD.CommandText = "INSERT INTO Defects(RELID,SUMMARY,DETAILS,MODULE,ASSIGNEDTO,RAISEDON,RAISEDBY,ESTIMATE,EMAIL,STATUS,FILE,CREATEDON,LASTUPT)" &
                 "VALUES(@RELID,@SUMMARY,@DETAILS,@MODULE,@ASSIGNEDTO,@RAISEDON,@RAISEDBY,@ESTIMATE,@EMAIL,@STATUS,@FILE,@CREATEDON,@LASTUPT)"
                        With CMD.Parameters
                            .Add("RELID", Data.DbType.String)
                            .Add("SUMMARY", Data.DbType.String)
                            .Add("DETAILS", Data.DbType.String)
                            .Add("MODULE", Data.DbType.String)
                            .Add("ASSIGNEDTO", Data.DbType.String)
                            .Add("RAISEDON", Data.DbType.DateTime)
                            .Add("RAISEDBY", Data.DbType.String)
                            .Add("ESTIMATE", Data.DbType.String)
                            .Add("EMAIL", Data.DbType.String)
                            .Add("STATUS", Data.DbType.String)
                            .Add("FILE", Data.DbType.Binary)
                            .Add("CREATEDON", Data.DbType.DateTime)
                            .Add("LASTUPT", Data.DbType.DateTime)
                            .Item("RELID").Value = Qi.cboReleaseID.Text
                            .Item("SUMMARY").Value = Qi.txtSummary.Text
                            .Item("DETAILS").Value = ""
                            .Item("MODULE").Value = ""
                            .Item("RAISEDON").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                            .Item("RAISEDBY").Value = ""
                            .Item("ESTIMATE").Value = ""
                            .Item("EMAIL").Value = ""
                            .Item("ASSIGNEDTO").Value = ""
                            .Item("STATUS").Value = "OPEN"
                            .Item("FILE").Value = Nothing
                            .Item("CREATEDON").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                            .Item("LASTUPT").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                        End With
                        CMD.ExecuteNonQuery()
                    Case "Issues"
                        CMD.Parameters.Clear()
                        CMD.CommandText = "INSERT INTO ISSUES(SUMMARY,DETAILS,RAISEDON,RAISEDBY,RESOLUTION,STATUS,FILE,CREATEDON,LASTUPT)" &
                 "VALUES(@SUMMARY,@DETAILS,@RAISEDON,@RAISEDBY,@RESOLUTION,@STATUS,@FILE,@CREATEDON,@LASTUPT)"
                        With CMD.Parameters
                            .Add("CREATEDON", Data.DbType.DateTime)
                            .Add("SUMMARY", Data.DbType.String)
                            .Add("DETAILS", Data.DbType.String)
                            .Add("RAISEDON", Data.DbType.DateTime)
                            .Add("RAISEDBY", Data.DbType.String)
                            .Add("RESOLUTION", Data.DbType.String)
                            .Add("STATUS", Data.DbType.String)
                            .Add("FILE", Data.DbType.Binary)
                            .Add("LASTUPT", Data.DbType.DateTime)
                            .Item("SUMMARY").Value = Qi.txtSummary.Text
                            .Item("DETAILS").Value = ""
                            .Item("RAISEDON").Value = Date.Now
                            .Item("RAISEDBY").Value = ""
                            .Item("RESOLUTION").Value = ""
                            .Item("STATUS").Value = "OPEN"
                            .Item("FILE").Value = Nothing
                            .Item("CREATEDON").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                            .Item("LASTUPT").Value = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                        End With
                        CMD.ExecuteNonQuery()
                End Select


                If tvwMain.Nodes.Count > 0 Then
                    If tvwMain.Nodes(0).Nodes.Count = 0 Then Exit Sub
                Else
                    Exit Sub
                End If
                For Each nd As TreeNode In tvwMain.Nodes(0).Nodes
                    If nd.Text.Contains(":") Then
                        If nd.Text.Split(":")(1) = "(Loaded)" Then
                            LoadChildren(nd)
                        End If
                    End If
                Next

            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub tvwMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvwMain.KeyDown
        If e.KeyCode = Keys.Delete Then
            If tvwMain.SelectedNode Is Nothing Then Exit Sub
            If tvwMain.SelectedNode.ImageIndex > 4 Then
                DeleteToolStripMenuItem_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub tvwMain_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvwMain.MouseDown
        If tvwMain.HitTest(e.Location).Node Is Nothing Then Exit Sub
        tvwMain.SelectedNode = tvwMain.HitTest(e.Location).Node
    End Sub

    Private Sub butExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExport.Click
        Try
            Dim htmlpub As New Libraries.HTMLPublisher
            htmlpub.Data.Clear()
            htmlpub.ColumnHeaders.Clear()
            Dim datagridview1 As DataGridView
            Select Case tvwMain.Tag
                Case "Tasks"
                    datagridview1 = TaskForm1.dgdItems
                Case "Defects"
                    datagridview1 = DefectForm1.dgdItems
                Case Else
                    datagridview1 = IssueForm1.dgdItems
            End Select
            If datagridview1.RowCount <= 0 Then
                MsgBox("No rows to export", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
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

            htmlpub.HeaderText = tvwMain.Tag & " report on" & Date.Now
            Dim sfd As New SaveFileDialog
            Dim fname As String = ""
            With sfd
                .Filter = "HTML Files(*.htm)|*.htm"
                .FileName = "Untitled"
                If .ShowDialog = DialogResult.OK Then
                    fname = .FileName
                Else
                    Exit Sub
                End If
            End With
            If htmlpub.PublishFile(fname) = HTMLPublisher.ECodes.Success Then
                MsgBox("File saved successfully", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim ft As New FrequentTasks
        ft.Show(Me)
    End Sub



    Private Sub WorkItems_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = False Then
            Try


                CMD.CommandText = "VACUUM"
                CMD.ExecuteNonQuery()
                CMD.Dispose()
                CONN.Close()


            Catch ex As Exception

            End Try
        Else
            Try
                connString = connString.Replace("#FILE#", UserWorkItems)
                CONN = New SQLiteConnection(connString)
                CONN.Open()
                CMD = New SQLiteCommand
                CMD.Connection = CONN
                LoadREleases()
                tlstpTasks_Click(Nothing, Nothing)
            Catch ex As Exception
                DE(ex)
            End Try
        End If
    End Sub


End Class
