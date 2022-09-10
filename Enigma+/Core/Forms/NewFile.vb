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
Public Class Filename
    Dim filts() As String
    Public ReadOnly Property Filename As String
        Get
            Return txtFilename.Text & "." & cboNewFileType.Text

        End Get
    End Property


    Public Sub New(ByVal filter As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        filts = filter.Split("|")
        Dim secondelement As Boolean = True
        For Each fk As String In filts
            If secondelement Then
                secondelement = False
            Else
                If fk = "*.*" Then Continue For
                Dim dks() As String = fk.Split(".")
                Dim fks() As String = dks(1).Split(",")
                cboNewFileType.Items.Add(fks(0).Trim)
                secondelement = True
            End If
        Next
        cboNewFileType.SelectedIndex = 0
        txtFilename.Text = "Untitled"
    End Sub
    Public Shadows Function SHOWdIALOG()
        Return MyBase.ShowDialog()
    End Function

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class