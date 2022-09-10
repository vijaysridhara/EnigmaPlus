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
Imports System.IO
Imports System.Security.AccessControl

Public Class FileTree
    Inherits TreeView
    Private components As System.ComponentModel.IContainer
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

    Event FileDoubleClicked(ByVal node As TreeNode, ByVal flname As String)

    Public Sub New()
        InitializeComponent()
     
     
        LoadFiles()
    End Sub
    Public Sub Reload()
        Dim tv As TreeNode = SelectedNode
        If tv Is Nothing Then
            LoadFiles()
        Else
            tv.Nodes.Clear()
            GetFilesAndDir(tv)
            tv.Expand()
        End If
    End Sub
    Public Sub LoadFiles()
        Nodes.Clear()

        Me.ImageList = ImageList1
        Dim driNfo() As DriveInfo = System.IO.DriveInfo.GetDrives
        For Each dr As DriveInfo In driNfo
            Dim td As TreeNode = New TreeNode(dr.Name, 0, 0)
            td.Tag = dr.Name
            Me.Nodes.Add(td)
            td.Nodes.Add("dummy", "")
        Next
    End Sub
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileTree))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Upload.ico")
        Me.ImageList1.Images.SetKeyName(1, "folderclose.ico")
        Me.ImageList1.Images.SetKeyName(2, "folderopen.ico")
        Me.ImageList1.Images.SetKeyName(3, "Text.ico")
        '
        'FileTree
        '
        Me.ItemHeight = 20
        Me.LineColor = System.Drawing.Color.Black
        Me.ResumeLayout(False)

    End Sub

    Private Sub FileTree_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Me.AfterCollapse
        If e.Node.ImageIndex = 2 Then
            e.Node.ImageIndex = 1
        End If
    End Sub

    Private Sub FileTree_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Me.AfterExpand
        If e.Node.ImageIndex = 1 Then
            e.Node.ImageIndex = 2
        End If
    End Sub



    Private Sub FileTree_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles Me.BeforeExpand
        If e.Node.ImageIndex = 0 Or e.Node.ImageIndex = 1 Or e.Node.ImageIndex = 2 Then
            e.Node.Nodes.Clear()
            GetFilesAndDir(e.Node)
        End If
    End Sub
    Private Sub GetFilesAndDir(ByVal sender As TreeNode)
        Try
            Dim dirs() As String = IO.Directory.GetDirectories(sender.Tag)
            For Each dr As String In dirs

                Dim di As DirectoryInfo = New DirectoryInfo(dr)

                
                If di.Attributes = (IO.FileAttributes.Hidden Or FileAttributes.Directory Or FileAttributes.System) Or _
                    di.Attributes = (IO.FileAttributes.ReadOnly Or IO.FileAttributes.Hidden Or FileAttributes.Directory Or FileAttributes.NotContentIndexed) Or _
                    di.Attributes = (IO.FileAttributes.Hidden Or IO.FileAttributes.System Or IO.FileAttributes.Directory Or IO.FileAttributes.ReparsePoint Or FileAttributes.NotContentIndexed) Or _
                    di.Attributes = (IO.FileAttributes.Hidden Or IO.FileAttributes.System Or IO.FileAttributes.Directory Or FileAttributes.NotContentIndexed) Then
                    Continue For
                End If
                Dim td As TreeNode = New TreeNode(dr.Substring(InStrRev(dr, "\")), 1, 1)
                td.Tag = dr

                sender.Nodes.Add(td)
                td.Nodes.Add("dummy", "", -1, -1)
            Next
       
        Catch ex As Exception
            DE(ex)
        End Try
      
    End Sub

    Private Sub FileTree_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles Me.NodeMouseDoubleClick
        If e.Node.ImageIndex > 3 Then
            RaiseEvent FileDoubleClicked(e.Node, e.Node.Tag)
        End If
    End Sub
End Class
