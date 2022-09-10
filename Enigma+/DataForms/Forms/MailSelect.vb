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
Public Class MailSelect
    Private _isLotus As Boolean = True

    Public ReadOnly Property IsLotus As Boolean
        Get
            Return _isLotus
        End Get
    End Property
    Public ReadOnly Property ToEmail As String
        Get
            Return txtTo.Text
        End Get
    End Property
    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub butOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        Me.DialogResult = DialogResult.OK
        My.Settings.ToEmail = txtTo.Text
        Me.Close()

    End Sub

    Private Sub radOthers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radOthers.CheckedChanged
        If radOthers.Checked Then
            _isLotus = False
        End If
    End Sub

    Private Sub radLotus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radLotus.CheckedChanged
        If radLotus.Checked Then
            _isLotus = True
        End If
    End Sub

    Private Sub MailSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTo.Text = My.Settings.ToEmail
    End Sub
End Class