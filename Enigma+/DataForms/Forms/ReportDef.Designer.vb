<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportDef
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
        Me.lblReportNam = New System.Windows.Forms.Label()
        Me.lblSQL = New System.Windows.Forms.Label()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.butAddReport = New System.Windows.Forms.Button()
        Me.butDeleteReport = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.butModifyReport = New System.Windows.Forms.Button()
        Me.cboReportName = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblReportNam
        '
        Me.lblReportNam.AutoSize = True
        Me.lblReportNam.Location = New System.Drawing.Point(12, 31)
        Me.lblReportNam.Name = "lblReportNam"
        Me.lblReportNam.Size = New System.Drawing.Size(35, 13)
        Me.lblReportNam.TabIndex = 0
        Me.lblReportNam.Text = "&Name"
        '
        'lblSQL
        '
        Me.lblSQL.AutoSize = True
        Me.lblSQL.Location = New System.Drawing.Point(12, 60)
        Me.lblSQL.Name = "lblSQL"
        Me.lblSQL.Size = New System.Drawing.Size(28, 13)
        Me.lblSQL.TabIndex = 2
        Me.lblSQL.Text = "&SQL"
        '
        'txtSQL
        '
        Me.txtSQL.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSQL.Location = New System.Drawing.Point(57, 60)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.Size = New System.Drawing.Size(264, 181)
        Me.txtSQL.TabIndex = 3
        '
        'butAddReport
        '
        Me.butAddReport.Location = New System.Drawing.Point(327, 60)
        Me.butAddReport.Name = "butAddReport"
        Me.butAddReport.Size = New System.Drawing.Size(75, 23)
        Me.butAddReport.TabIndex = 4
        Me.butAddReport.Text = "&Add"
        Me.butAddReport.UseVisualStyleBackColor = True
        '
        'butDeleteReport
        '
        Me.butDeleteReport.Location = New System.Drawing.Point(327, 116)
        Me.butDeleteReport.Name = "butDeleteReport"
        Me.butDeleteReport.Size = New System.Drawing.Size(75, 23)
        Me.butDeleteReport.TabIndex = 6
        Me.butDeleteReport.Text = "&Delete"
        Me.butDeleteReport.UseVisualStyleBackColor = True
        '
        'butExit
        '
        Me.butExit.DialogResult =DialogResult.Cancel
        Me.butExit.Location = New System.Drawing.Point(327, 218)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(75, 23)
        Me.butExit.TabIndex = 7
        Me.butExit.Text = "E&xit"
        Me.butExit.UseVisualStyleBackColor = True
        '
        'butModifyReport
        '
        Me.butModifyReport.Location = New System.Drawing.Point(327, 87)
        Me.butModifyReport.Name = "butModifyReport"
        Me.butModifyReport.Size = New System.Drawing.Size(75, 23)
        Me.butModifyReport.TabIndex = 5
        Me.butModifyReport.Text = "&Modify"
        Me.butModifyReport.UseVisualStyleBackColor = True
        '
        'cboReportName
        '
        Me.cboReportName.FormattingEnabled = True
        Me.cboReportName.Location = New System.Drawing.Point(61, 32)
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(260, 21)
        Me.cboReportName.TabIndex = 8
        '
        'ReportDef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butExit
        Me.ClientSize = New System.Drawing.Size(436, 257)
        Me.Controls.Add(Me.cboReportName)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butDeleteReport)
        Me.Controls.Add(Me.butModifyReport)
        Me.Controls.Add(Me.butAddReport)
        Me.Controls.Add(Me.txtSQL)
        Me.Controls.Add(Me.lblSQL)
        Me.Controls.Add(Me.lblReportNam)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReportDef"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReportDef"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblReportNam As System.Windows.Forms.Label
    Friend WithEvents lblSQL As System.Windows.Forms.Label
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents butAddReport As System.Windows.Forms.Button
    Friend WithEvents butDeleteReport As System.Windows.Forms.Button
    Friend WithEvents butExit As System.Windows.Forms.Button
    Friend WithEvents butModifyReport As System.Windows.Forms.Button
    Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
End Class
