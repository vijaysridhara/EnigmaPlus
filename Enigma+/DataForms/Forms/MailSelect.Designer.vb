<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MailSelect
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
        Me.radLotus = New System.Windows.Forms.RadioButton()
        Me.radOthers = New System.Windows.Forms.RadioButton()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'radLotus
        '
        Me.radLotus.AutoSize = True
        Me.radLotus.Checked = True
        Me.radLotus.Location = New System.Drawing.Point(43, 27)
        Me.radLotus.Name = "radLotus"
        Me.radLotus.Size = New System.Drawing.Size(80, 17)
        Me.radLotus.TabIndex = 0
        Me.radLotus.TabStop = True
        Me.radLotus.Text = "&Lotus notes"
        Me.radLotus.UseVisualStyleBackColor = True
        '
        'radOthers
        '
        Me.radOthers.AutoSize = True
        Me.radOthers.Location = New System.Drawing.Point(43, 50)
        Me.radOthers.Name = "radOthers"
        Me.radOthers.Size = New System.Drawing.Size(56, 17)
        Me.radOthers.TabIndex = 1
        Me.radOthers.Text = "&Others"
        Me.radOthers.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(33, 125)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(75, 23)
        Me.butOK.TabIndex = 4
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.Location = New System.Drawing.Point(114, 125)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 23)
        Me.butCancel.TabIndex = 5
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(12, 93)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(20, 13)
        Me.lblTo.TabIndex = 2
        Me.lblTo.Text = "&To"
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(57, 90)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(150, 20)
        Me.txtTo.TabIndex = 3
        '
        'MailSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 179)
        Me.Controls.Add(Me.txtTo)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.radOthers)
        Me.Controls.Add(Me.radLotus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MailSelect"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MailSelect"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents radLotus As System.Windows.Forms.RadioButton
    Friend WithEvents radOthers As System.Windows.Forms.RadioButton
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents txtTo As System.Windows.Forms.TextBox
End Class
