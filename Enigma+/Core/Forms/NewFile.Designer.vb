<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Filename
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.cboNewFileType = New System.Windows.Forms.ComboBox()
        Me.butOk = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File &name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Type"
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(87, 24)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(251, 20)
        Me.txtFilename.TabIndex = 1
        '
        'cboNewFileType
        '
        Me.cboNewFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNewFileType.FormattingEnabled = True
        Me.cboNewFileType.Location = New System.Drawing.Point(87, 58)
        Me.cboNewFileType.Name = "cboNewFileType"
        Me.cboNewFileType.Size = New System.Drawing.Size(175, 21)
        Me.cboNewFileType.TabIndex = 3
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(182, 106)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(75, 30)
        Me.butOk.TabIndex = 4
        Me.butOk.Text = "O&K"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.DialogResult =DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(263, 106)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 30)
        Me.butCancel.TabIndex = 5
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'Filename
        '
        Me.AcceptButton = Me.butOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(347, 148)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.cboNewFileType)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Filename"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filename"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents cboNewFileType As System.Windows.Forms.ComboBox
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
End Class
