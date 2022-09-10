<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigurationParms
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
        Me.components = New System.ComponentModel.Container()
        Me.lstCommands = New System.Windows.Forms.ListBox()
        Me.txtCommandName = New System.Windows.Forms.TextBox()
        Me.txtCommandline = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PROJDIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FILEFULLPATHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FILENAMENEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FILENAMEWEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INPUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.butRemove = New System.Windows.Forms.Button()
        Me.chkCapture = New System.Windows.Forms.CheckBox()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.lblProjectExec = New System.Windows.Forms.Label()
        Me.txtProgramname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.butProg = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstCommands
        '
        Me.lstCommands.FormattingEnabled = True
        Me.lstCommands.Location = New System.Drawing.Point(9, 36)
        Me.lstCommands.Name = "lstCommands"
        Me.lstCommands.Size = New System.Drawing.Size(415, 186)
        Me.lstCommands.TabIndex = 1
        '
        'txtCommandName
        '
        Me.txtCommandName.Location = New System.Drawing.Point(428, 36)
        Me.txtCommandName.Name = "txtCommandName"
        Me.txtCommandName.Size = New System.Drawing.Size(121, 20)
        Me.txtCommandName.TabIndex = 3
        '
        'txtCommandline
        '
        Me.txtCommandline.ContextMenuStrip = Me.ContextMenuStrip1
        Me.txtCommandline.Location = New System.Drawing.Point(428, 115)
        Me.txtCommandline.Name = "txtCommandline"
        Me.txtCommandline.Size = New System.Drawing.Size(204, 20)
        Me.txtCommandline.TabIndex = 8
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PROJDIRToolStripMenuItem, Me.FILEFULLPATHToolStripMenuItem, Me.FILENAMENEToolStripMenuItem, Me.FILENAMEWEToolStripMenuItem, Me.INPUTToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(169, 136)
        '
        'PROJDIRToolStripMenuItem
        '
        Me.PROJDIRToolStripMenuItem.Name = "PROJDIRToolStripMenuItem"
        Me.PROJDIRToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.PROJDIRToolStripMenuItem.Text = "$PROJDIR"
        '
        'FILEFULLPATHToolStripMenuItem
        '
        Me.FILEFULLPATHToolStripMenuItem.Name = "FILEFULLPATHToolStripMenuItem"
        Me.FILEFULLPATHToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.FILEFULLPATHToolStripMenuItem.Text = "$FILE_FULL_PATH"
        '
        'FILENAMENEToolStripMenuItem
        '
        Me.FILENAMENEToolStripMenuItem.Name = "FILENAMENEToolStripMenuItem"
        Me.FILENAMENEToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.FILENAMENEToolStripMenuItem.Text = "$FILE_NAME_NE"
        '
        'FILENAMEWEToolStripMenuItem
        '
        Me.FILENAMEWEToolStripMenuItem.Name = "FILENAMEWEToolStripMenuItem"
        Me.FILENAMEWEToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.FILENAMEWEToolStripMenuItem.Text = "$FILE_NAME_WE"
        '
        'INPUTToolStripMenuItem
        '
        Me.INPUTToolStripMenuItem.Name = "INPUTToolStripMenuItem"
        Me.INPUTToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.INPUTToolStripMenuItem.Text = "$INPUT"
        '
        'butAdd
        '
        Me.butAdd.Location = New System.Drawing.Point(428, 164)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(32, 23)
        Me.butAdd.TabIndex = 10
        Me.butAdd.Text = "+"
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'butRemove
        '
        Me.butRemove.Location = New System.Drawing.Point(428, 193)
        Me.butRemove.Name = "butRemove"
        Me.butRemove.Size = New System.Drawing.Size(32, 23)
        Me.butRemove.TabIndex = 11
        Me.butRemove.Text = "-"
        Me.butRemove.UseVisualStyleBackColor = True
        '
        'chkCapture
        '
        Me.chkCapture.AutoSize = True
        Me.chkCapture.Location = New System.Drawing.Point(430, 141)
        Me.chkCapture.Name = "chkCapture"
        Me.chkCapture.Size = New System.Drawing.Size(96, 17)
        Me.chkCapture.TabIndex = 9
        Me.chkCapture.Text = "&Capture output"
        Me.chkCapture.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(476, 199)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(75, 23)
        Me.butOK.TabIndex = 12
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.DialogResult = DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(557, 199)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 23)
        Me.butCancel.TabIndex = 13
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'lblProjectExec
        '
        Me.lblProjectExec.AutoSize = True
        Me.lblProjectExec.Location = New System.Drawing.Point(7, 20)
        Me.lblProjectExec.Name = "lblProjectExec"
        Me.lblProjectExec.Size = New System.Drawing.Size(114, 13)
        Me.lblProjectExec.TabIndex = 0
        Me.lblProjectExec.Text = "&Executable commands"
        '
        'txtProgramname
        '
        Me.txtProgramname.Location = New System.Drawing.Point(428, 76)
        Me.txtProgramname.Name = "txtProgramname"
        Me.txtProgramname.Size = New System.Drawing.Size(123, 20)
        Me.txtProgramname.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(425, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Command &name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(427, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "&Program to execute"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(427, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Command &text"
        '
        'butProg
        '
        Me.butProg.Location = New System.Drawing.Point(557, 73)
        Me.butProg.Name = "butProg"
        Me.butProg.Size = New System.Drawing.Size(32, 23)
        Me.butProg.TabIndex = 6
        Me.butProg.Text = "..."
        Me.butProg.UseVisualStyleBackColor = True
        '
        'ConfigurationParms
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(646, 235)
        Me.Controls.Add(Me.lblProjectExec)
        Me.Controls.Add(Me.butProg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butRemove)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCommandName)
        Me.Controls.Add(Me.lstCommands)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butAdd)
        Me.Controls.Add(Me.txtProgramname)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.txtCommandline)
        Me.Controls.Add(Me.chkCapture)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ConfigurationParms"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Project Configuration"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstCommands As System.Windows.Forms.ListBox
    Friend WithEvents txtCommandName As System.Windows.Forms.TextBox
    Friend WithEvents txtCommandline As System.Windows.Forms.TextBox
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PROJDIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FILEFULLPATHToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FILENAMENEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FILENAMEWEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents INPUTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butRemove As System.Windows.Forms.Button
    Friend WithEvents chkCapture As System.Windows.Forms.CheckBox
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents lblProjectExec As System.Windows.Forms.Label
    Friend WithEvents txtProgramname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents butProg As System.Windows.Forms.Button
End Class
