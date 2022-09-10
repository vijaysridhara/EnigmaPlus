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
Public Class StandbyForm
    Private mf As MainForm
    Public Sub New(ByVal mf As MainForm)
        InitializeComponent()
        Me.mf = mf
        mf.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub StandbyForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub StandbyForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        mf.WindowState = FormWindowState.Normal
    End Sub
    Private Sub StandbyForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each kv As Language In LanguagesSupported.Values
            Dim le As New ToolStripMenuItem

            le.Text = kv.Name
            le.Tag = kv.Name


            LanguageToolStripMenuItem.DropDownItems.Add(le)

            AddHandler le.Click, AddressOf language_clicked

        Next

    End Sub
    Private Sub language_clicked(ByVal sender As Object, ByVal e As EventArgs)
        Try

            Dim lang As String = CType(sender, ToolStripMenuItem).Tag.ToString
            Buntilla1.ClearStylesBuffer()
            Buntilla1.Range.ClearStyle()
            Buntilla1.Range.ClearFoldingMarkers()

            If LanguagesSupported.ContainsKey(lang) Then
                Select Case lang
                    Case "VB"
                        Buntilla1.Language = FastColoredTextBoxNS.Language.VB
                    Case "JS"
                        Buntilla1.Language = FastColoredTextBoxNS.Language.JS
                    Case "CSharp"
                        Buntilla1.Language = FastColoredTextBoxNS.Language.CSharp
                    Case "SQL"
                        Buntilla1.Language = FastColoredTextBoxNS.Language.SQL
                    Case "PHP"
                        Buntilla1.Language = FastColoredTextBoxNS.Language.PHP
                    Case "HTML"
                        Buntilla1.Language = FastColoredTextBoxNS.Language.HTML
                    Case Else
                        Buntilla1.Language = FastColoredTextBoxNS.Language.Custom
                        Buntilla1.DescriptionFile = LanguagesSupported(lang).FilePAth
                End Select
                Buntilla1.OnTextChanged()
                Buntilla1.Tag = CType(sender, ToolStripMenuItem).Tag.ToString

            End If

        Catch ex As Exception
            DE(ex)
        End Try


    End Sub

    Private Sub CopyDataToNewFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyDataToNewFileToolStripMenuItem.Click
        mf.CreateNeFile(Nothing, Nothing)
        mf.CurrentEditControl.Text = Buntilla1.Text
        Me.Close()
    End Sub

    Private Sub CopyToWorkspaceAndRefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToWorkspaceAndRefreshToolStripMenuItem.Click
        mf.CreateNeFile(Nothing, Nothing)
        mf.CurrentEditControl.Text = Buntilla1.Text
        Buntilla1.Clear()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class