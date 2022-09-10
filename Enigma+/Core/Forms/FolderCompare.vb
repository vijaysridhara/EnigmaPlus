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
Public Class FolderCompare

    Private Sub butSelFolder1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSelFolder1.Click
        Dim fd As New FolderBrowserDialog
        fd.SelectedPath = IIf(String.IsNullOrEmpty(txtFolder1.Text), "C:\", txtFolder1.Text)
        If fd.ShowDialog = DialogResult.OK Then
            txtFolder1.Text = fd.SelectedPath
        End If
    End Sub

    Private Sub butSelFolder2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSelFolder2.Click
        Dim fd As New FolderBrowserDialog
        fd.SelectedPath = IIf(String.IsNullOrEmpty(txtFolder2.Text), "C:\", txtFolder2.Text)
        If fd.ShowDialog = DialogResult.OK Then
            txtFolder2.Text = fd.SelectedPath
        End If
    End Sub
    Dim rootDir1, rootDir2 As String
    Private Sub butCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCompare.Click
        If String.IsNullOrEmpty(txtFolder1.Text) Or String.IsNullOrEmpty(txtFolder2.Text) Then
            MsgBox("Please select the two folders and execute", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IO.Directory.Exists(txtFolder1.Text) = False Or IO.Directory.Exists(txtFolder2.Text) = False Then
            MsgBox("One of the directories are not present", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        DataGridView1.Rows.Clear()
        dirDict1.Clear()
        dirdict2.Clear()
        rootDir1 = txtFolder1.Text
        rootDir2 = txtFolder2.Text
        DataGridView1.Hide()
        ProgressBar1.Show()
        ProgressBar1.Refresh()
        RunCompare(rootDir1, rootDir2)
        ProgressBar1.Hide()
        DataGridView1.Show()
    End Sub
    Private dirDict1 As New Collection
    Private dirdict2 As New Collection
    Dim progVal As Integer
    Private Function RunCompare(ByVal dir1 As String, ByVal dir2 As String)
        Try

            Dim dirs1() As String = IO.Directory.GetDirectories(dir1)
            Dim dirs2() As String = IO.Directory.GetDirectories(dir2)
            Dim unqualified As String
            Dim dgrow As DataGridViewRow

            Dim txtCol1, txtCol2, txtcolFZ1, txtcolFZ2 As DataGridViewTextBoxCell
            Dim imgCol1, imgCol2 As DataGridViewImageCell
            Dim cnt As Integer = dirs1.Length
            Dim i As Long = 0
            For Each dr As String In dirs1
                i += 1
                ProgressBar1.Value = CInt(i / cnt) * 100
                dgrow = New DataGridViewRow
                unqualified = dr.Replace(rootDir1 & "\", "")
                dirDict1.Add(unqualified, unqualified)
                If IO.Directory.Exists(rootDir2 & "\" & unqualified) Then
                    imgCol1 = New DataGridViewImageCell
                    imgCol1.Value = ImageList1.Images(0)
                    imgCol2 = New DataGridViewImageCell
                    imgCol2.Value = ImageList1.Images(0)
                    txtCol1 = New DataGridViewTextBoxCell
                    txtCol1.Value = unqualified
                    txtCol2 = New DataGridViewTextBoxCell
                    txtCol2.Value = unqualified
                    txtcolFZ1 = New DataGridViewTextBoxCell
                    txtcolFZ2 = New DataGridViewTextBoxCell
                    With dgrow.Cells
                        .Add(imgCol1)
                        .Add(txtCol1)
                        .Add(txtcolFZ1)
                        .Add(imgCol2)
                        .Add(txtCol2)
                        .Add(txtcolFZ2)
                    End With
                    DataGridView1.Rows.Add(dgrow)
                    RunCompare(dr, rootDir2 & "\" & unqualified)
                Else
                    imgCol1 = New DataGridViewImageCell
                    imgCol1.Value = ImageList1.Images(0)
                    imgCol2 = New DataGridViewImageCell
                    imgCol2.Value = ImageList1.Images(1)
                    txtCol1 = New DataGridViewTextBoxCell
                    txtCol1.Value = unqualified
                    txtCol2 = New DataGridViewTextBoxCell
                    txtCol2.Value = unqualified
                    txtcolFZ1 = New DataGridViewTextBoxCell
                    txtcolFZ2 = New DataGridViewTextBoxCell
                    With dgrow.Cells
                        .Add(imgCol1)
                        .Add(txtCol1)
                        .Add(txtcolFZ1)
                        .Add(imgCol2)
                        .Add(txtCol2)
                        .Add(txtcolFZ2)
                    End With
                    DataGridView1.Rows.Add(dgrow)
                End If

            Next
            cnt = dir2.Length
            i = 0
            For Each dr As String In dirs2
                i += 1
                ProgressBar1.Value = CInt(i / cnt) * 100
                dgrow = New DataGridViewRow
                unqualified = dr.Replace(rootDir2 & "\", "")
                If dirDict1.Contains(unqualified) Then Continue For
                dirDict1.Add(unqualified, unqualified)
                imgCol1 = New DataGridViewImageCell
                imgCol1.Value = ImageList1.Images(1)
                imgCol2 = New DataGridViewImageCell
                imgCol2.Value = ImageList1.Images(0)
                txtCol1 = New DataGridViewTextBoxCell
                txtCol1.Value = unqualified
                txtCol2 = New DataGridViewTextBoxCell
                txtCol2.Value = unqualified
                txtcolFZ1 = New DataGridViewTextBoxCell
                txtcolFZ2 = New DataGridViewTextBoxCell
                With dgrow.Cells
                    .Add(imgCol1)
                    .Add(txtCol1)
                    .Add(txtcolFZ1)
                    .Add(imgCol2)
                    .Add(txtCol2)
                    .Add(txtcolFZ2)
                End With
                DataGridView1.Rows.Add(dgrow)
            Next
            Dim fls() As String = IO.Directory.GetFiles(dir1)
            cnt = fls.Length
            i = 0
            Dim fname As String
            For Each fl As String In fls
                i += 1
                ProgressBar1.Value = CInt(i / cnt) * 100
                dgrow = New DataGridViewRow
                Dim flinfo As IO.FileInfo
                fname = IO.Path.GetFileName(fl)
                unqualified = fl.Replace(rootDir1 & "\", "")
                dirdict2.Add(unqualified, unqualified)
                If IO.File.Exists(rootDir2 & "\" & unqualified) Then
                    imgCol1 = New DataGridViewImageCell
                    imgCol1.Value = ImageList1.Images(2)
                    imgCol2 = New DataGridViewImageCell
                    imgCol2.Value = ImageList1.Images(2)
                    txtCol1 = New DataGridViewTextBoxCell
                    txtCol1.Value = fname
                    txtCol2 = New DataGridViewTextBoxCell
                    txtCol2.Value = fname
                    txtcolFZ1 = New DataGridViewTextBoxCell
                    flinfo = New IO.FileInfo(fl)
                    Dim l1, l2 As Long, d1, d2 As Date
                    l1 = flinfo.Length
                    d1 = flinfo.LastWriteTime
                    txtcolFZ1.Value = Format(flinfo.LastWriteTime, "yyyy-MM-dd HH:mm:ss") & " [" & flinfo.Length & " bytes]"
                    flinfo = New IO.FileInfo(rootDir2 & "\" & unqualified)
                    txtcolFZ2 = New DataGridViewTextBoxCell
                    txtcolFZ2.Value = Format(flinfo.LastWriteTime, "yyyy-MM-dd HH:mm:ss") & " [" & flinfo.Length & " bytes]"
                    l2 = flinfo.Length
                    d2 = flinfo.LastWriteTime
                    If l1 <> l2 Then
                        dgrow.DefaultCellStyle.BackColor = Color.Bisque
                    ElseIf d1 <> d2 Then
                        dgrow.DefaultCellStyle.BackColor = Color.Beige
                    End If

                    With dgrow.Cells
                        .Add(imgCol1)
                        .Add(txtCol1)
                        .Add(txtcolFZ1)
                        .Add(imgCol2)
                        .Add(txtCol2)
                        .Add(txtcolFZ2)
                    End With

                    DataGridView1.Rows.Add(dgrow)
                Else
                    imgCol1 = New DataGridViewImageCell
                    imgCol1.Value = ImageList1.Images(2)
                    imgCol2 = New DataGridViewImageCell
                    imgCol2.Value = ImageList1.Images(3)
                    txtCol1 = New DataGridViewTextBoxCell
                    txtCol1.Value = fname
                    txtCol2 = New DataGridViewTextBoxCell
                    txtCol2.Value = fname
                    txtcolFZ1 = New DataGridViewTextBoxCell
                    flinfo = New IO.FileInfo(fl)

                    txtcolFZ1.Value = Format(flinfo.LastWriteTime, "yyyy-MM-dd HH:mm:ss") & " [" & flinfo.Length & " bytes]"
                    'flinfo = New IO.FileInfo(rootDir2 & "\" & unqualified)
                    txtcolFZ2 = New DataGridViewTextBoxCell
                    'txtcolFZ2.Value = Format(flinfo.LastWriteTime, "yyyy-MM-dd HH:mm:ss") & "[" & flinfo.Length & " bytes]"
                    With dgrow.Cells
                        .Add(imgCol1)
                        .Add(txtCol1)
                        .Add(txtcolFZ1)
                        .Add(imgCol2)
                        .Add(txtCol2)
                        .Add(txtcolFZ2)
                    End With
                    dgrow.DefaultCellStyle.BackColor = Color.BurlyWood
                    DataGridView1.Rows.Add(dgrow)
                End If
            Next
            fls = IO.Directory.GetFiles(dir2)
            cnt = fls.Length
            i = 0

            For Each fl As String In fls
                i += 1
                ProgressBar1.Value = CInt(i / cnt) * 100
                dgrow = New DataGridViewRow
                unqualified = fl.Replace(rootDir2 & "\", "")
                fname = IO.Path.GetFileName(fl)
                If dirdict2.Contains(unqualified) Then Continue For
                dirdict2.Add(unqualified, unqualified)
                imgCol1 = New DataGridViewImageCell
                imgCol1.Value = ImageList1.Images(3)
                imgCol2 = New DataGridViewImageCell
                imgCol2.Value = ImageList1.Images(2)
                txtCol1 = New DataGridViewTextBoxCell
                txtCol1.Value = fname
                txtCol2 = New DataGridViewTextBoxCell
                txtCol2.Value = fname
                txtcolFZ1 = New DataGridViewTextBoxCell
                'flinfo = New IO.FileInfo(fl)
                'txtcolFZ1.Value = Format(flinfo.LastWriteTime, "yyyy-MM-dd HH:mm:ss") & "[" & flinfo.Length & " bytes]"
                Dim flinfo As IO.FileInfo = New IO.FileInfo(fl)
                txtcolFZ2 = New DataGridViewTextBoxCell
                txtcolFZ2.Value = Format(flinfo.LastWriteTime, "yyyy-MM-dd HH:mm:ss") & " [" & flinfo.Length & " bytes]"
                With dgrow.Cells
                    .Add(imgCol1)
                    .Add(txtCol1)
                    .Add(txtcolFZ1)
                    .Add(imgCol2)
                    .Add(txtCol2)
                    .Add(txtcolFZ2)
                End With
                dgrow.DefaultCellStyle.BackColor = Color.BurlyWood
                DataGridView1.Rows.Add(dgrow)
            Next
        Catch ex As Exception

        End Try
    End Function
End Class
