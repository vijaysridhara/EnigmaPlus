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
Public Class Comparator
    Dim Lst1 As New Collection, Lst2 As New Collection
    Dim dict As New Dictionary(Of String, String)
    Dim Result As New Collection
    Dim whichtbox As Integer
    Private Sub butRemoveDups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRemoveDups.Click
        butRemoveDups.Enabled = False
        butCompare.Enabled = False
        ClearAllLists()
        ReadList(1, True)
        ClearallUI()
        S("Creating list")
        Dim str() As String
        'For i As Integer = 1 To Result.Count
        '    Application.DoEvents()
        '    If i > 1 Then
        '        txtResult.Text = txtResult.Text & Result(i) & vbCrLf
        '    Else
        '        txtResult.Text = Result(i) & vbCrLf
        '    End If
        '    PGBCOMPARE.Value = (i / Result.Count) * 100
        'Next
        For i As Integer = 1 To Result.Count
            Application.DoEvents()
            ReDim Preserve str(0 To (i - 1))
            str(i - 1) = Result(i)

            PGBCOMPARE.Value = (i / Result.Count) * 100
        Next
        If Result.Count > 0 Then txtResult.Lines = str
        Dim CT(0 To dict.Values.Count - 1) As String
        If dict.Values.Count = 0 Then
            txtList2.Text = "No duplicates found"
            S()
            Exit Sub
        End If
        dict.Values.CopyTo(CT, 0)
        S("Creating duplicate list")
        For i As Integer = 0 To CT.GetUpperBound(0)
            CT(i) = CT(i).Replace("`", "------")
            If i > 0 Then
                txtList2.Text = txtList2.Text & CT(i) & vbCrLf
            Else
                txtList2.Text = CT(i) & vbCrLf
            End If
            PGBCOMPARE.Value = ((i + 1) / (CT.GetUpperBound(0) + 1)) * 100

        Next
        S()

    End Sub
    Private Sub S(Optional ByVal msg As String = "Ready")
        tlstpMessage.Text = msg
        PGBCOMPARE.Value = 0
        If msg = "Ready" Then
            butRemoveDups.Enabled = True
            butCompare.Enabled = True
        End If
    End Sub

    Private Sub ClearAllLists()
        Lst1.Clear()
        Lst2.Clear()
        dict.Clear()
        Result.Clear()

    End Sub
    Private Sub ClearallUI()
        txtList2.Clear()
        txtResult.Clear()
    End Sub
    Private Sub ReadList(ByVal listno As Integer, Optional ByVal forDups As Boolean = False)
        Dim str() As String
        Dim ct() As String
        Select Case listno
            Case 1
                S("Reading Big list")
                str = txtList1.Lines
                'str = Split(txtList1.Text, vbLf)
                For i As Integer = 0 To str.GetUpperBound(0)
                    str(i) = str(i).Trim
                    If str(i) = "" Then Continue For
                    If forDups Then
                        If Result.Contains(str(i)) Then
                            If dict.ContainsKey(str(i)) Then
                                ct = dict(str(i)).ToString.Split("`")
                                ct(1) = CInt(ct(1)) + 1
                                dict(str(i)) = ct(0) & "`" & ct(1)
                            Else
                                dict.Add(str(i), str(i) & "`2")
                            End If
                        Else
                            Result.Add(str(i), str(i))
                        End If
                    Else
                        If Not Lst1.Contains(str(i)) Then
                            Lst1.Add(str(i), str(i))
                        End If
                    End If
                    PGBCOMPARE.Value = ((i + 1) / (str.GetUpperBound(0) + 1)) * 100

                Next
            Case 2
                str = txtList2.Lines
                'str = txtList2.Text.Split(vbLf)
                S("Reading Small list")

                For i As Integer = 0 To str.GetUpperBound(0)
                    str(i) = str(i).Trim
                    If str(i) = "" Then Continue For
                    If Not Lst2.Contains(str(i)) Then
                        Lst2.Add(str(i), str(i))
                    End If
                    PGBCOMPARE.Value = ((i + 1) / (str.GetUpperBound(0) + 1)) * 100

                Next
        End Select
    End Sub

    Private Sub butCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCompare.Click
        butCompare.Enabled = False
        butRemoveDups.Enabled = False
        ClearAllLists()
        ReadList(1)
        ReadList(2)
        Result.Add("****************************************************")
        Result.Add("           Biglist Items not in Smalllist")
        Result.Add("****************************************************")
        S("Finding missing from list2")
        For I As Integer = 1 To Lst1.Count
            Application.DoEvents()
            If Lst2.Contains(Lst1(I)) Then
                Continue For
            Else
                Result.Add(Lst1(I))
            End If
            PGBCOMPARE.Value = (I / Lst1.Count) * 100
        Next
        If Result.Count = 3 Then
            Result.Add("            Nothing found")
        End If
        Result.Add(" ")

        Result.Add("#####################################################")
        Result.Add("           Smalllist Items not in Biglist")
        Result.Add("****************************************************")
        S("Finding missing from list1")
        For I As Integer = 1 To Lst2.Count
            Application.DoEvents()
            If Lst1.Contains(Lst2(I)) Then
                Continue For
            Else
                Result.Add(Lst2(I))
            End If
            PGBCOMPARE.Value = (I / Lst2.Count) * 100
        Next
        If Result.Count = 8 Then
            Result.Add("            Nothing found")
        End If
        Result.Add("****************************************************")
        S("Creating list")
        Dim str() As String
        'For i As Integer = 1 To Result.Count
        '    If i > 1 Then
        '        txtResult.Text = txtResult.Text & Result(i) & vbCrLf
        '    Else
        '        txtResult.Text = Result(i) & vbCrLf
        '    End If
        '    PGBCOMPARE.Value = (i / Result.Count) * 100

        'Next
        For i As Integer = 1 To Result.Count
            ReDim Preserve str(0 To (i - 1))
            str(i - 1) = Result(i)

            PGBCOMPARE.Value = (i / Result.Count) * 100

        Next
        If Result.Count > 0 Then txtResult.Lines = str
        S()
    End Sub



    Private Sub txtList1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        whichtbox = 1
    End Sub


    Private Sub txtList1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ctxMain_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxMain.Opened

    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Select Case whichtbox
            Case 1
                Clipboard.SetText(txtList1.SelectedText)
            Case 2
                Clipboard.SetText(txtList2.SelectedText)
            Case 3
                Clipboard.SetText(txtResult.SelectedText)
        End Select
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Select Case whichtbox
            Case 1
                Clipboard.SetText(txtList1.SelectedText)
                txtList1.SelectedText = ""
            Case 2
                Clipboard.SetText(txtList2.SelectedText)
                txtList2.SelectedText = ""
            Case 3
                Clipboard.SetText(txtResult.SelectedText)
                txtResult.SelectedText = ""
        End Select
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Select Case whichtbox
            Case 1
                txtList1.SelectedText = Clipboard.GetText
            Case 2
                txtList2.SelectedText = Clipboard.GetText
            Case 3
                txtResult.SelectedText = Clipboard.GetText
        End Select
    End Sub

    Private Sub txtList2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtList2.GotFocus
        whichtbox = 2
    End Sub

    Private Sub txtList2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtList2.MouseDown
        If e.Button = MouseButtons.Right Then
            txtList2.Focus()
        End If
    End Sub
    Private Sub txtList1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtList1.MouseDown
        If e.Button = MouseButtons.Right Then
            txtList1.Focus()
        End If
    End Sub

    Private Sub txtResult_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtResult.MouseDown
        If e.Button = MouseButtons.Right Then
            txtResult.Focus()

        End If
    End Sub

    Private Sub txtResult_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResult.GotFocus
        whichtbox = 3
    End Sub



    Private Sub ctxMain_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxMain.Opening
        If Clipboard.GetText() <> "" Then
            PasteToolStripMenuItem.Enabled = True
        Else
            PasteToolStripMenuItem.Enabled = False
        End If

        Select Case whichtbox
            Case 1
                If txtList1.Text <> "" Then
                    SelectallToolStripMenuItem.Enabled = True
                Else
                    SelectallToolStripMenuItem.Enabled = False
                End If
                If txtList1.SelectedText <> "" Then
                    CutToolStripMenuItem.Enabled = True
                    CopyToolStripMenuItem.Enabled = True
                Else
                    CutToolStripMenuItem.Enabled = False
                    CopyToolStripMenuItem.Enabled = False
                End If
            Case 2
                If txtList2.Text <> "" Then
                    SelectallToolStripMenuItem.Enabled = True
                Else
                    SelectallToolStripMenuItem.Enabled = False
                End If
                If txtList2.SelectedText <> "" Then
                    CutToolStripMenuItem.Enabled = True
                    CopyToolStripMenuItem.Enabled = True
                Else
                    CutToolStripMenuItem.Enabled = False
                    CopyToolStripMenuItem.Enabled = False
                End If
            Case 3
                If txtResult.Text <> "" Then
                    SelectallToolStripMenuItem.Enabled = True
                Else
                    SelectallToolStripMenuItem.Enabled = False
                End If
                If txtResult.SelectedText <> "" Then
                    CutToolStripMenuItem.Enabled = True
                    CopyToolStripMenuItem.Enabled = True
                Else
                    CutToolStripMenuItem.Enabled = False
                    CopyToolStripMenuItem.Enabled = False
                End If

        End Select
    End Sub

    Private Sub butClearLists_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClearLists.Click
        ClearallUI()
        txtList1.Clear()
    End Sub

    Private Sub txtResult_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SelectallToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectallToolStripMenuItem.Click
        Select Case whichtbox
            Case 1
                txtList1.SelectAll()
            Case 2
                txtList2.SelectAll()
            Case 3
                txtResult.SelectAll()
        End Select
    End Sub

    Private Sub txtList1_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtList1.GotFocus
        whichtbox = 1
    End Sub
End Class
