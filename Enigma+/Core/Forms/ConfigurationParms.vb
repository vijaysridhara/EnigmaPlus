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
Public Class ConfigurationParms

    Private _commands() As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub butOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOK.Click
        Dim aarr() As String
        If lstCommands.Items.Count = 0 Then
            _commands = Nothing
            Exit Sub
        End If
        Dim i As Integer = 0
        ReDim _commands(lstCommands.Items.Count)
        For Each li As String In lstCommands.Items
            _commands(i) = li
            i += 1
        Next
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub lstCommands_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCommands.SelectedIndexChanged
        If lstCommands.SelectedItem Is Nothing Then
            butRemove.Enabled = False
        Else
            butRemove.Enabled = True
        End If
    End Sub

    Private Sub butRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRemove.Click
        If lstCommands.SelectedItem Is Nothing Then Exit Sub
        lstCommands.Items.RemoveAt(lstCommands.SelectedIndex)
    End Sub

    Private Sub butAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAdd.Click
        If String.IsNullOrEmpty(txtCommandName.TextLength) Then
            MsgBox("The name cannot be empty", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim cmd As String = txtCommandName.Text & Chr(254) & txtProgramname.Text & Chr(255) & txtCommandline.Text & Chr(255) & IIf(chkCapture.Checked, "Y", "N")
        lstCommands.Items.Add(cmd)
    End Sub
    Public Property Commands() As String()
        Get
            Return _commands
        End Get
        Set(ByVal value() As String)
            For Each itm As String In value
                lstCommands.Items.Add(itm)
            Next
        End Set
    End Property

    Private Sub butProg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butProg.Click
        Dim ofd As New OpenFileDialog
        ofd.Title = "Select the program"
        ofd.Filter = "Executable files(*.exe)|*.exe|Batch files(*.bat)|*.bat"
        With ofd
            If .ShowDialog = DialogResult.OK Then
                txtProgramname.Text = .FileName
            End If
        End With
    End Sub

    Private Sub PROJDIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROJDIRToolStripMenuItem.Click
        txtCommandline.SelectedText = PROJDIRToolStripMenuItem.Text
    End Sub

    Private Sub FILEFULLPATHToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FILEFULLPATHToolStripMenuItem.Click
        txtCommandline.SelectedText = FILEFULLPATHToolStripMenuItem.Text
    End Sub

    Private Sub FILENAMENEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FILENAMENEToolStripMenuItem.Click
        txtCommandline.SelectedText = FILENAMENEToolStripMenuItem.Text
    End Sub

    Private Sub FILENAMEWEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FILENAMEWEToolStripMenuItem.Click
        txtCommandline.SelectedText = FILENAMEWEToolStripMenuItem.Text
    End Sub

    Private Sub INPUTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INPUTToolStripMenuItem.Click
        txtCommandline.SelectedText = INPUTToolStripMenuItem.Text
    End Sub
    Public Sub New(ByVal ldpjFile As String)
        InitializeComponent()
        Try

            Dim sr As New IO.StreamReader(ldpjFile)
            Dim i As Integer = 0

            While sr.EndOfStream = False
                Dim ln As String = sr.ReadLine.Trim
                If ln.Length > 8 Then
                    If ln.Substring(0, 8) = "COMMAND:" Then
                        lstCommands.Items.Add(ln.Substring(8))
                    End If
                End If
            End While
            sr.Close()
            sr.Dispose()
        Catch ex As Exception
            DE(ex)
        End Try

    End Sub
    Private Sub ConfigurationParms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class