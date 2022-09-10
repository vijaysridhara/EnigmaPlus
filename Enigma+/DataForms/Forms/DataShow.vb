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
Friend Class DataShow


    Private file As String
    Public Sub New(ByVal file As String)
        InitializeComponent()
        Me.file = file
    End Sub

    Public ReadOnly Property FileUsed As String
        Get
            Return file
        End Get
    End Property
    Public Sub LoadContents()
        Dim cf As New ClosingMsg
        Try
            cf.Text = "Opening form please wait"
            cf.Label1.Text = "Opening the form, and loading content. Please wait..."
            cf.Show(Me)
            cf.Label1.Refresh()
            Me.Show()
            DataForm1.InitiateForm(file)

        Catch ex As Exception
            DataForm1_MEssageSent(ex.Message)
            Me.Close()
        Finally
            cf.Close()
        End Try

    End Sub
    Private Sub DataForm1_MEssageSent(ByVal msg As String) Handles DataForm1.MEssageSent
        txtMessages.Text += vbCrLf + msg
        txtMessages.SelectionStart = txtMessages.TextLength
        txtMessages.ScrollToCaret()
    End Sub


    Private Sub DataShow_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim cf As New ClosingMsg
        cf.Show(Me)
        cf.Label1.Refresh()
        DataForm1.Vacuum()
        DataForm1.Cleanup()
    End Sub

    Private Sub DataForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataForm1.Load

    End Sub
End Class