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
Public Class FileCompare

    Dim OldFile As New Dictionary(Of Integer, LineElement)
    Dim NewFile As New Dictionary(Of Integer, LineElement)
    Private Sub butCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCompare.Click
        Try
            OldFile.Clear()
            NewFile.Clear()
            FastColoredTextBox1.Range.ClearStyle()
            FastColoredTextBox2.Range.ClearStyle()
            FastColoredTextBox1.ClearStylesBuffer()
            FastColoredTextBox2.ClearStylesBuffer()
            FastColoredTextBox1.OnTextChanged()
            FastColoredTextBox2.OnTextChanged()
            Dim I As UInteger = 0
            Dim le As LineElement
            For Each ln As String In FastColoredTextBox1.Lines
                I += 1
                le = New LineElement
                With le
                    .LineNo = I
                    .Value = IIf(chkTrimlines.CheckAlign, ln.Trim, ln)
                End With
                OldFile.Add(le.LineNo, le)
            Next
            I = 0
            For Each ln As String In FastColoredTextBox2.Lines
                I += 1
                le = New LineElement
                With le
                    .LineNo = I
                    .Value = IIf(chkTrimlines.CheckAlign, ln.Trim, ln)
                End With
                NewFile.Add(le.LineNo, le)
            Next
            Dim k As Integer = 0
            Dim foundItem As Integer = 0

            For Each ele As LineElement In OldFile.Values
                For k = foundItem To NewFile.Values.Count - 1
                    If ele.Value = NewFile.Values(k).Value Then
                        NewFile.Values(k).LineSTatus = LineElement.LST.Found
                        ele.LineSTatus = LineElement.LST.Found
                        foundItem = k + 1
                        GoTo LineFound
                    Else
                        NewFile.Values(k).LineSTatus = LineElement.LST.Inserted
                    End If
                Next
                ele.LineSTatus = LineElement.LST.Deleted
LineFound:
            Next
            k = 0
            foundItem = 0
            For Each ele As LineElement In NewFile.Values
                If ele.LineSTatus = LineElement.LST.Found Then Continue For
                If ele.LineSTatus = LineElement.LST.Inserted Then Continue For
                For k = foundItem To OldFile.Values.Count - 1
                    If OldFile.Values(k).LineSTatus = LineElement.LST.Found Then Continue For
                    If OldFile.Values(k).LineSTatus = LineElement.LST.Deleted Then Continue For
                    If OldFile.Values(k).Value = ele.Value Then
                        OldFile.Values(k).LineSTatus = LineElement.LST.Found
                        ele.LineSTatus = LineElement.LST.Found
                        GoTo LineFound1
                    Else
                        OldFile.Values(k).LineSTatus = LineElement.LST.Inserted
                    End If
                Next
                ele.LineSTatus = LineElement.LST.Deleted
LineFound1:
            Next
            Dim rng As FastColoredTextBoxNS.Range
            For Each ele As LineElement In OldFile.Values
                If ele.LineSTatus = LineElement.LST.Deleted Then
                    rng = New FastColoredTextBoxNS.Range(FastColoredTextBox1, 0, ele.LineNo - 1, FastColoredTextBox1.Lines(ele.LineNo - 1).Length, ele.LineNo - 1)
                    rng.SetStyle(New DeletedStyle, ".*")
                ElseIf ele.LineSTatus = LineElement.LST.Inserted Then
                    rng = New FastColoredTextBoxNS.Range(FastColoredTextBox1, 0, ele.LineNo - 1, FastColoredTextBox1.Lines(ele.LineNo - 1).Length, ele.LineNo - 1)
                    rng.SetStyle(New InsertedSTyle, ".*")
                End If
            Next
            For Each ele As LineElement In NewFile.Values
                If ele.LineSTatus = LineElement.LST.Deleted Then
                    rng = New FastColoredTextBoxNS.Range(FastColoredTextBox2, 0, ele.LineNo - 1, FastColoredTextBox2.Lines(ele.LineNo - 1).Length, ele.LineNo - 1)
                    rng.SetStyle(New DeletedStyle, ".*")
                ElseIf ele.LineSTatus = LineElement.LST.Inserted Then
                    rng = New FastColoredTextBoxNS.Range(FastColoredTextBox2, 0, ele.LineNo - 1, FastColoredTextBox2.Lines(ele.LineNo - 1).Length, ele.LineNo - 1)
                    rng.SetStyle(New InsertedSTyle, ".*")
                End If
            Next
            FastColoredTextBox1.OnTextChanged()
            FastColoredTextBox2.OnTextChanged()
            OldFile.Clear()
            NewFile.Clear()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
End Class