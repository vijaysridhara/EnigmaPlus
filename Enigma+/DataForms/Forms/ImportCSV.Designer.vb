<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportCSV
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butOK = New System.Windows.Forms.Button()
        Me.pnlMAin = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTabke = New System.Windows.Forms.ComboBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.butCancel)
        Me.Panel1.Controls.Add(Me.butOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 297)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(401, 46)
        Me.Panel1.TabIndex = 0
        '
        'butCancel
        '
        Me.butCancel.DialogResult =DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(318, 11)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 23)
        Me.butCancel.TabIndex = 0
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(237, 11)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(75, 23)
        Me.butOK.TabIndex = 0
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'pnlMAin
        '
        Me.pnlMAin.AutoScroll = True
        Me.pnlMAin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMAin.Location = New System.Drawing.Point(0, 35)
        Me.pnlMAin.Name = "pnlMAin"
        Me.pnlMAin.Size = New System.Drawing.Size(401, 221)
        Me.pnlMAin.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cboTabke)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(401, 35)
        Me.Panel2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "&Select datastore"
        '
        'cboTabke
        '
        Me.cboTabke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTabke.FormattingEnabled = True
        Me.cboTabke.Location = New System.Drawing.Point(102, 8)
        Me.cboTabke.Name = "cboTabke"
        Me.cboTabke.Size = New System.Drawing.Size(193, 21)
        Me.cboTabke.TabIndex = 0
        '
        'txtStatus
        '
        Me.txtStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtStatus.Location = New System.Drawing.Point(0, 256)
        Me.txtStatus.Multiline = True
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtStatus.Size = New System.Drawing.Size(401, 41)
        Me.txtStatus.TabIndex = 3
        '
        'ImportCSV
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(401, 343)
        Me.Controls.Add(Me.pnlMAin)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ImportCSV"
        Me.Text = "ImportCSV"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents pnlMAin As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTabke As System.Windows.Forms.ComboBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
End Class
