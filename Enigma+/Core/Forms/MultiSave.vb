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
Public Class MultiSave

    Private _Files() As FileItem
    Public Sub New(ByVal fls() As FileItem)
        InitializeComponent()
        If fls Is Nothing Then Me.Close() : Exit Sub
        For Each fl As FileItem In fls
            chkSelectedFiles.Items.Add(fl, True)
        Next
    End Sub
    Public ReadOnly Property SelectedFiles() As FileItem()
        Get
            Return _Files
        End Get
    End Property
    Private Sub butSaveSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSaveSelected.Click
        If chkSelectedFiles.CheckedItems.Count = 0 Then
            _Files = Nothing
        Else
            ReDim _Files(chkSelectedFiles.CheckedItems.Count)
            Dim i As Integer = 0
            For Each ci As FileItem In chkSelectedFiles.CheckedItems
                _Files(i) = ci
                i += 1
            Next
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub
End Class