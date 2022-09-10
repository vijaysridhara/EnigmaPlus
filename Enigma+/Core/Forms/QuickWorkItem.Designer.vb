<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuickWorkItem
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
        Me.txtSummary = New System.Windows.Forms.TextBox()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboReleaseID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboFreq = New System.Windows.Forms.ComboBox()
        Me.cboSubFreq = New System.Windows.Forms.ComboBox()
        Me.dtpOnetime = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "&Summary"
        '
        'txtSummary
        '
        Me.txtSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSummary.Location = New System.Drawing.Point(69, 76)
        Me.txtSummary.Name = "txtSummary"
        Me.txtSummary.Size = New System.Drawing.Size(456, 22)
        Me.txtSummary.TabIndex = 7
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(369, 104)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(75, 23)
        Me.butOK.TabIndex = 8
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.DialogResult =DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(450, 104)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 23)
        Me.butCancel.TabIndex = 9
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "&Release"
        '
        'cboReleaseID
        '
        Me.cboReleaseID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReleaseID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReleaseID.FormattingEnabled = True
        Me.cboReleaseID.Location = New System.Drawing.Point(69, 4)
        Me.cboReleaseID.Name = "cboReleaseID"
        Me.cboReleaseID.Size = New System.Drawing.Size(200, 24)
        Me.cboReleaseID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "&Frequency"
        '
        'cboFreq
        '
        Me.cboFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFreq.Enabled = False
        Me.cboFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFreq.FormattingEnabled = True
        Me.cboFreq.Items.AddRange(New Object() {"TODAY", "WEEKLY", "MONTHLY", "ONETIME"})
        Me.cboFreq.Location = New System.Drawing.Point(69, 38)
        Me.cboFreq.Name = "cboFreq"
        Me.cboFreq.Size = New System.Drawing.Size(200, 24)
        Me.cboFreq.TabIndex = 3
        '
        'cboSubFreq
        '
        Me.cboSubFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubFreq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSubFreq.FormattingEnabled = True
        Me.cboSubFreq.Items.AddRange(New Object() {"TODAY", "WEEKLY", "MONTHLY", "ONETIME"})
        Me.cboSubFreq.Location = New System.Drawing.Point(348, 38)
        Me.cboSubFreq.Name = "cboSubFreq"
        Me.cboSubFreq.Size = New System.Drawing.Size(126, 24)
        Me.cboSubFreq.TabIndex = 5
        Me.cboSubFreq.Visible = False
        '
        'dtpOnetime
        '
        Me.dtpOnetime.CustomFormat = "dd-MMM-yyyy"
        Me.dtpOnetime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpOnetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOnetime.Location = New System.Drawing.Point(348, 38)
        Me.dtpOnetime.Name = "dtpOnetime"
        Me.dtpOnetime.Size = New System.Drawing.Size(96, 22)
        Me.dtpOnetime.TabIndex = 4
        Me.dtpOnetime.Visible = False
        '
        'QuickWorkItem
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(537, 139)
        Me.Controls.Add(Me.dtpOnetime)
        Me.Controls.Add(Me.cboSubFreq)
        Me.Controls.Add(Me.cboFreq)
        Me.Controls.Add(Me.cboReleaseID)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.txtSummary)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "QuickWorkItem"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "QuickWorkItem"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSummary As System.Windows.Forms.TextBox
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboReleaseID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboFreq As System.Windows.Forms.ComboBox
    Friend WithEvents cboSubFreq As System.Windows.Forms.ComboBox
    Friend WithEvents dtpOnetime As System.Windows.Forms.DateTimePicker
End Class
