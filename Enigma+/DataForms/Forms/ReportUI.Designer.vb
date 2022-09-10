<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportUI
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.butSend = New System.Windows.Forms.Button()
        Me.butRefresh = New System.Windows.Forms.Button()
        Me.cboSaveDatato = New System.Windows.Forms.ComboBox()
        Me.datagridview1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.datagridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.butSend)
        Me.Panel1.Controls.Add(Me.butRefresh)
        Me.Panel1.Controls.Add(Me.cboSaveDatato)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(496, 29)
        Me.Panel1.TabIndex = 0
        '
        'butSend
        '
        Me.butSend.Location = New System.Drawing.Point(84, 3)
        Me.butSend.Name = "butSend"
        Me.butSend.Size = New System.Drawing.Size(75, 23)
        Me.butSend.TabIndex = 1
        Me.butSend.Text = "X&fer data"
        Me.butSend.UseVisualStyleBackColor = True
        '
        'butRefresh
        '
        Me.butRefresh.Location = New System.Drawing.Point(3, 3)
        Me.butRefresh.Name = "butRefresh"
        Me.butRefresh.Size = New System.Drawing.Size(75, 23)
        Me.butRefresh.TabIndex = 0
        Me.butRefresh.Text = "&Refresh"
        Me.butRefresh.UseVisualStyleBackColor = True
        '
        'cboSaveDatato
        '
        Me.cboSaveDatato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSaveDatato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSaveDatato.Enabled = False
        Me.cboSaveDatato.FormattingEnabled = True
        Me.cboSaveDatato.Items.AddRange(New Object() {"Save data as...", "Comma Separated Values", "CSV with quotes", "Tab Separated Values", "HTML File", "Character separated"})
        Me.cboSaveDatato.Location = New System.Drawing.Point(313, 3)
        Me.cboSaveDatato.Name = "cboSaveDatato"
        Me.cboSaveDatato.Size = New System.Drawing.Size(180, 21)
        Me.cboSaveDatato.TabIndex = 2
        '
        'datagridview1
        '
        Me.datagridview1.AllowUserToAddRows = False
        Me.datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridview1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridview1.Location = New System.Drawing.Point(0, 29)
        Me.datagridview1.Name = "datagridview1"
        Me.datagridview1.ReadOnly = True
        Me.datagridview1.Size = New System.Drawing.Size(496, 244)
        Me.datagridview1.TabIndex = 1
        '
        'ReportUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.datagridview1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ReportUI"
        Me.Size = New System.Drawing.Size(496, 273)
        Me.Panel1.ResumeLayout(False)
        CType(Me.datagridview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents datagridview1 As System.Windows.Forms.DataGridView
    Friend WithEvents cboSaveDatato As System.Windows.Forms.ComboBox
    Friend WithEvents butRefresh As System.Windows.Forms.Button
    Friend WithEvents butSend As System.Windows.Forms.Button

End Class
