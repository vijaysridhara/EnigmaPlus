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
Public Class NewFolder2
    Dim filts() As String
    Public ReadOnly Property Foldername As String
        Get
            Return txtFilename.Text

        End Get
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()



        txtFilename.Text = "New Folder"
    End Sub
    Public Sub New(ByVal oldfname As String)
        InitializeComponent()
        txtFilename.Text = oldfname
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