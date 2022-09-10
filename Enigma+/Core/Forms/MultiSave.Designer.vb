<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiSave
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
        Me.chkSelectedFiles = New System.Windows.Forms.CheckedListBox()
        Me.butSaveSelected = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'chkSelectedFiles
        '
        Me.chkSelectedFiles.FormattingEnabled = True
        Me.chkSelectedFiles.Location = New System.Drawing.Point(12, 12)
        Me.chkSelectedFiles.Name = "chkSelectedFiles"
        Me.chkSelectedFiles.Size = New System.Drawing.Size(292, 274)
        Me.chkSelectedFiles.TabIndex = 0
        '
        'butSaveSelected
        '
        Me.butSaveSelected.Location = New System.Drawing.Point(310, 12)
        Me.butSaveSelected.Name = "butSaveSelected"
        Me.butSaveSelected.Size = New System.Drawing.Size(102, 30)
        Me.butSaveSelected.TabIndex = 1
        Me.butSaveSelected.Text = "&Save selected"
        Me.butSaveSelected.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.DialogResult =DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(310, 85)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(102, 28)
        Me.butCancel.TabIndex = 1
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(310, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "&Dont save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MultiSave
        '
        Me.AcceptButton = Me.butSaveSelected
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(421, 294)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.butSaveSelected)
        Me.Controls.Add(Me.chkSelectedFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MultiSave"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MultiSave"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkSelectedFiles As System.Windows.Forms.CheckedListBox
    Friend WithEvents butSaveSelected As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
