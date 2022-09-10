<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StandbyForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyDataToNewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToWorkspaceAndRefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LanguageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Buntilla1 = New Buntilla()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolToolStripMenuItem, Me.LanguageToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(706, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolToolStripMenuItem
        '
        Me.ToolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyDataToNewFileToolStripMenuItem, Me.CopyToWorkspaceAndRefreshToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem"
        Me.ToolToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.ToolToolStripMenuItem.Text = "&Tool"
        '
        'CopyDataToNewFileToolStripMenuItem
        '
        Me.CopyDataToNewFileToolStripMenuItem.Name = "CopyDataToNewFileToolStripMenuItem"
        Me.CopyDataToNewFileToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.CopyDataToNewFileToolStripMenuItem.Text = "&Copy to workspace and close"
        '
        'CopyToWorkspaceAndRefreshToolStripMenuItem
        '
        Me.CopyToWorkspaceAndRefreshToolStripMenuItem.Name = "CopyToWorkspaceAndRefreshToolStripMenuItem"
        Me.CopyToWorkspaceAndRefreshToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.CopyToWorkspaceAndRefreshToolStripMenuItem.Text = "&Copy to workspace and refresh"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(237, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'LanguageToolStripMenuItem
        '
        Me.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem"
        Me.LanguageToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.LanguageToolStripMenuItem.Text = "Language"
        '
        'Buntilla1
        '
        Me.Buntilla1.AllowDrop = True
        Me.Buntilla1.AutoScrollMinSize = New System.Drawing.Size(27, 15)
        Me.Buntilla1.BackBrush = Nothing
        Me.Buntilla1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Buntilla1.CurrentLocation = New System.Drawing.Point(0, 1)
        Me.Buntilla1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Buntilla1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Buntilla1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Buntilla1.Font = New System.Drawing.Font("Courier New", 10.0!)
        Me.Buntilla1.JustFileName = "Untitled"
        Me.Buntilla1.Location = New System.Drawing.Point(0, 24)
        Me.Buntilla1.Name = "Buntilla1"
        Me.Buntilla1.Paddings = New System.Windows.Forms.Padding(0)
        Me.Buntilla1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Buntilla1.Size = New System.Drawing.Size(706, 290)
        Me.Buntilla1.TabIndex = 0
        '
        'StandbyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 314)
        Me.Controls.Add(Me.Buntilla1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "StandbyForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Helper Form"
        Me.TopMost = True
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Buntilla1 As Buntilla
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents LanguageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyDataToNewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToWorkspaceAndRefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
