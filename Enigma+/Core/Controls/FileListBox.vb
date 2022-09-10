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
Public Class FileListBox
    Private _lastfolder As String = "C:\"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        With Unwantedfiles
            .Add(".dll", ".dll")
            .Add(".exe", ".exe")
            .Add(".ppt", ".ppt")
            .Add(".doc", ".doc")
            .Add(".ocx", ".ocx")
            .Add(".xls", ".xls")
            .Add(".vsd", ".vsd")
            .Add(".flv", ".flv")
            .Add(".swf", ".swf")
            .Add(".mov", ".mov")
            .Add(".jpg", ".jpg")
            .Add(".mpg", ".mpg")
            .Add(".gif", ".gif")
            .Add(".bmp", ".bmp")
            .Add(".psd", ".psd")
            .Add(".svg", ".svg")
            .Add(".rar", ".rar")
            .Add(".zip", ".zip")
            .Add(".7z", ".7z")
            .Add(".emf", ".emf")
            .Add(".msi", ".msi")
            .Add(".cab", ".cab")
            .Add(".sys", ".sys")
            .Add(".png", ".png")
            .Add(".reg", ".reg")
            .Add(".ttf", ".ttf")
        End With
        LoadExtensions()
        FileTree1.LoadFiles()
    End Sub
    Public ReadOnly Property LastFolderSelected()
        Get
            Return _lastfolder
        End Get
    End Property
    Public Sub SetCurrentFolder(ByVal folder As String)
        Try
            Dim dirs() As String = folder.Split("\")
            dirs(0) = dirs(0) & "\"
            Dim i As Integer = 0

            For Each nd As TreeNode In FileTree1.Nodes
                If nd.Text = dirs(0) Then
                    SEarchNodes(nd, dirs, i + 1)
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SEarchNodes(ByVal nd As TreeNode, ByVal dirs() As String, ByVal i As Integer)
        nd.Expand()
        If i >= dirs.Length Then
            FileTree1.SelectedNode = nd
            Exit Sub
        End If
        For Each nd1 As TreeNode In nd.Nodes
            If dirs(i).ToLower = nd1.Text.ToLower Then
                SEarchNodes(nd1, dirs, i + 1)
                Exit Sub
            End If
        Next
        FileTree1.SelectedNode = nd

    End Sub
    Private Sub LoadExtensions()
        Dim filts() As String
        filts = AvailableExtensions.Split("|")
        Dim secondelement As Boolean = True
        For Each fk As String In filts
            If secondelement Then
                secondelement = False
            Else
                cboFilter.Items.Add(fk)
                secondelement = True
            End If
        Next
        cboFilter.Text = "*.*"
    End Sub

    Private Sub cboFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilter.Click

    End Sub

    Private Sub cboFilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFilter.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If FileTree1.SelectedNode Is Nothing Then Exit Sub
                AddFileitems()
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub cboFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilter.SelectedIndexChanged
        Try
            If Not FileTree1.SelectedNode Is Nothing Then
                AddFileitems()
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub FileTree1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles FileTree1.AfterSelect
        If Not FileTree1.SelectedNode Is Nothing Then
            AddFileitems()
        Else
            ListView1.Items.Clear()
        End If
    End Sub
    Private Sub AddFileitems()
        Try
            ListView1.Items.Clear()
            ListView1.SmallImageList = ImageList1

            Dim fls() As String = IO.Directory.GetFiles(FileTree1.SelectedNode.Tag, cboFilter.Text)
            _lastfolder = FileTree1.SelectedNode.Tag
            Dim img As Image
            For Each fl As String In fls
                Dim ext = IO.Path.GetExtension(fl).ToLower

                If ext = "" Then ext = ".dat"
                Dim td As ListViewItem = New ListViewItem(fl.Substring(InStrRev(fl, "\")))
                Dim finfo As Date = IO.File.GetLastWriteTime(fl)
                Dim fattr As IO.FileInfo
                fattr = New IO.FileInfo(fl)

                td.SubItems.Add(Format(finfo, "yyyy-MM-dd HH:mm:ss"))
                td.SubItems.Add(fattr.Length)
                If ImageList1.Images.ContainsKey(ext) Then
                    td.ImageKey = ext
                    td.ImageKey = ext
                Else
                    img = Drawing.Icon.ExtractAssociatedIcon(fl).ToBitmap
                    ImageList1.Images.Add(ext, img)
                    td.ImageKey = ext

                End If
                td.Tag = fl
                ListView1.Items.Add(td)
            Next
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Try
            If FileTree1.SelectedNode Is Nothing Then Exit Sub
            If FileTree1.SelectedNode.ImageIndex > 0 Then
                ctxDeleteFolder.Enabled = True
                ctxNewFolder.Enabled = True
                ctxRenameFolder.Enabled = True
            Else
                ctxDeleteFolder.Enabled = False
                ctxNewFolder.Enabled = False
                ctxRenameFolder.Enabled = False
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxNewFolder.Click
        Try
            Dim tn As TreeNode = FileTree1.SelectedNode
            Dim nf As New NewFolder2
            If nf.SHOWdIALOG = DialogResult.OK Then
                MkDir(tn.Tag & "\" & nf.Foldername)
            End If
            Dim nfnode As New TreeNode(nf.Foldername)
            nfnode.Tag = tn.Tag & "\" & nf.Foldername
            nfnode.ImageIndex = 1
            nfnode.SelectedImageIndex = 1
            nfnode.Nodes.Add("dummy", "dummy")
            tn.Nodes.Add(nfnode)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxDeleteFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxDeleteFolder.Click
        Try
            Dim tn As TreeNode = FileTree1.SelectedNode
            If MsgBox("Do you really want to delete the folder and its contents", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            RmDir(tn.Tag)
            tn.Remove()
            RaiseEvent FolderDeleteClicked(tn.Tag)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxOpeninExplorer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxOpeninExplorer.Click
        Try
            Dim tn As TreeNode = FileTree1.SelectedNode
            Process.Start("explorer.exe ", """" & tn.Tag & """")
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxRenameFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxRenameFolder.Click
        Try
            Dim tn As TreeNode = FileTree1.SelectedNode
            Dim nf As New NewFolder2(tn.Text)
            If nf.SHOWdIALOG = DialogResult.OK Then
                If nf.Foldername.ToUpper = tn.Text.ToUpper Then
                    Exit Sub
                Else
                    Rename(tn.Tag, IO.Path.GetDirectoryName(tn.Tag) & "\" & nf.Foldername)
                    tn.Tag = IO.Path.GetDirectoryName(tn.Tag) & "\" & nf.Foldername
                    tn.Text = nf.Foldername
                    FileTree1.SelectedNode = tn
                    FileTree1.Reload()
                    RefreshToolStripMenuItem_Click(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ContextMenuStrip2_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip2.Opening
        If FileTree1.SelectedNode Is Nothing Then
            ctxNewFile.Enabled = False
        Else
            ctxNewFile.Enabled = True
        End If
        If ListView1.SelectedItems.Count = 0 Then
            ctxOpenfile.Enabled = False
            ctxDeleteFile.Enabled = False

        Else

            ctxOpenfile.Enabled = True
            ctxDeleteFile.Enabled = True
        End If
    End Sub
    Event FolderDeleteClicked(ByVal foldname As String)
    Event FileOpenClicked(ByVal fname As String)
    Event FileDeleteClicked(ByVal fname As String)
    Private Sub ctxOpenfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxOpenfile.Click
        Try
            RaiseEvent FileOpenClicked(ListView1.SelectedItems(0).Tag)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxDeleteFile.Click
        Try
            If MsgBox("Do you really want to delete the file?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            IO.File.Delete(ListView1.SelectedItems(0).Tag)
            RaiseEvent FileDeleteClicked(ListView1.SelectedItems(0).Tag)
            ListView1.SelectedItems(0).Remove()

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub


    Private Sub ctxNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxNewFile.Click
        Try
Start:
            Dim nf As New Filename(AvailableExtensions)
            If nf.SHOWdIALOG = DialogResult.OK Then
                Dim tn As TreeNode = FileTree1.SelectedNode
                If IO.File.Exists(tn.Tag & "\" & nf.Filename) Then
                    MsgBox("The file already exists", MsgBoxStyle.Exclamation)
                    GoTo Start
                Else
                    Dim sw As New IO.StreamWriter(tn.Tag & "\" & nf.Filename, False)
                    sw.Close()
                    sw.Dispose()
                    If IO.File.Exists(tn.Tag & "\" & nf.Filename) Then
                        Dim lsv As New ListViewItem(IO.Path.GetFileName(nf.Filename))
                        lsv.Tag = tn.Tag & "\" & nf.Filename
                        Dim ext As String = IO.Path.GetExtension(lsv.Tag)
                        Dim finfo As Date = IO.File.GetLastWriteTime(tn.Tag & "\" & nf.Filename)
                        Dim fattr As IO.FileInfo = New IO.FileInfo(tn.Tag & "\" & nf.Filename)

                        lsv.SubItems.Add(Format(finfo, "yyyy-MM-dd HH:mm:ss"))
                        lsv.SubItems.Add(fattr.Length)
                        If ImageList1.Images.ContainsKey(ext) Then
                            lsv.ImageKey = ext
                            lsv.ImageKey = ext
                        Else
                            Dim img As Image
                            img = Drawing.Icon.ExtractAssociatedIcon(lsv.Tag).ToBitmap
                            ImageList1.Images.Add(ext, img)
                            lsv.ImageKey = ext

                        End If
                        ListView1.Items.Add(lsv)
                    End If
                End If
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Try
            If ListView1.SelectedItems.Count = 0 Then Exit Sub
            Try
                RaiseEvent FileOpenClicked(ListView1.SelectedItems(0).Tag.ToString.ToLower)
            Catch ex As Exception
                DE(ex)
            End Try
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            RaiseEvent FileOpenClicked(ListView1.SelectedItems(0).Tag)
        End If
    End Sub


    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub FileTree1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles FileTree1.MouseDown
        Try
            Dim tv As TreeViewHitTestInfo
            tv = FileTree1.HitTest(e.Location)
            If tv.Node Is Nothing Then Exit Sub
            FileTree1.SelectedNode = tv.Node
        Catch ex As Exception
            DE(ex)
        End Try

    End Sub

    Private Sub RefreshToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem1.Click
        Try

            FileTree1.Reload()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Try
            AddFileitems()
        Catch ex As Exception
            DE(ex)
        End Try

    End Sub


End Class
