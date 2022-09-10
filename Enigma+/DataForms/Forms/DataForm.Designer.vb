Imports VijaySridhara.Controls
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataForm
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgdData = New System.Windows.Forms.DataGridView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkShowGrid = New System.Windows.Forms.CheckBox()
        Me.lblFormVer = New System.Windows.Forms.Label()
        Me.butDeleteRecord = New System.Windows.Forms.Button()
        Me.butQuickfix = New System.Windows.Forms.Button()
        Me.butImport = New System.Windows.Forms.Button()
        Me.butCreateReport = New System.Windows.Forms.Button()
        Me.butNewRecord = New System.Windows.Forms.Button()
        Me.butSaveRecord = New System.Windows.Forms.Button()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Toolbox1 = New Toolbox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(699, 145)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgdData)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(691, 119)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "All data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgdData
        '
        Me.dgdData.AllowUserToAddRows = False
        Me.dgdData.AllowUserToDeleteRows = False
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdData.Location = New System.Drawing.Point(3, 3)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.ReadOnly = True
        Me.dgdData.Size = New System.Drawing.Size(685, 113)
        Me.dgdData.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.SystemColors.Control
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 290)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(699, 3)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'tabMain
        '
        Me.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Location = New System.Drawing.Point(0, 36)
        Me.tabMain.Multiline = True
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(597, 254)
        Me.tabMain.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.chkShowGrid)
        Me.Panel1.Controls.Add(Me.lblFormVer)
        Me.Panel1.Controls.Add(Me.butDeleteRecord)
        Me.Panel1.Controls.Add(Me.butQuickfix)
        Me.Panel1.Controls.Add(Me.butImport)
        Me.Panel1.Controls.Add(Me.butCreateReport)
        Me.Panel1.Controls.Add(Me.butNewRecord)
        Me.Panel1.Controls.Add(Me.butSaveRecord)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(597, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(102, 254)
        Me.Panel1.TabIndex = 1
        '
        'chkShowGrid
        '
        Me.chkShowGrid.AutoSize = True
        Me.chkShowGrid.Checked = True
        Me.chkShowGrid.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowGrid.Location = New System.Drawing.Point(3, 34)
        Me.chkShowGrid.Name = "chkShowGrid"
        Me.chkShowGrid.Size = New System.Drawing.Size(73, 17)
        Me.chkShowGrid.TabIndex = 7
        Me.chkShowGrid.Text = "S&how grid"
        Me.chkShowGrid.UseVisualStyleBackColor = True
        '
        'lblFormVer
        '
        Me.lblFormVer.BackColor = System.Drawing.Color.Transparent
        Me.lblFormVer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFormVer.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFormVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormVer.ForeColor = System.Drawing.Color.Black
        Me.lblFormVer.Location = New System.Drawing.Point(0, 0)
        Me.lblFormVer.Name = "lblFormVer"
        Me.lblFormVer.Size = New System.Drawing.Size(102, 31)
        Me.lblFormVer.TabIndex = 6
        Me.lblFormVer.Text = "Data Ver:"
        Me.lblFormVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'butDeleteRecord
        '
        Me.butDeleteRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butDeleteRecord.BackColor = System.Drawing.Color.Transparent
        Me.butDeleteRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butDeleteRecord.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butDeleteRecord.ForeColor = System.Drawing.Color.Black
        Me.butDeleteRecord.Location = New System.Drawing.Point(6, 197)
        Me.butDeleteRecord.Name = "butDeleteRecord"
        Me.butDeleteRecord.Size = New System.Drawing.Size(83, 23)
        Me.butDeleteRecord.TabIndex = 4
        Me.butDeleteRecord.Text = "&Delete record"
        Me.butDeleteRecord.UseVisualStyleBackColor = False
        '
        'butQuickfix
        '
        Me.butQuickfix.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butQuickfix.BackColor = System.Drawing.Color.Transparent
        Me.butQuickfix.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butQuickfix.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butQuickfix.ForeColor = System.Drawing.Color.Black
        Me.butQuickfix.Location = New System.Drawing.Point(6, 222)
        Me.butQuickfix.Name = "butQuickfix"
        Me.butQuickfix.Size = New System.Drawing.Size(83, 23)
        Me.butQuickfix.TabIndex = 5
        Me.butQuickfix.Text = "&Quickfix"
        Me.butQuickfix.UseVisualStyleBackColor = False
        '
        'butImport
        '
        Me.butImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butImport.BackColor = System.Drawing.Color.Transparent
        Me.butImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butImport.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butImport.ForeColor = System.Drawing.Color.Black
        Me.butImport.Location = New System.Drawing.Point(6, 97)
        Me.butImport.Name = "butImport"
        Me.butImport.Size = New System.Drawing.Size(83, 23)
        Me.butImport.TabIndex = 0
        Me.butImport.Text = "&Import data"
        Me.butImport.UseVisualStyleBackColor = False
        '
        'butCreateReport
        '
        Me.butCreateReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butCreateReport.BackColor = System.Drawing.Color.Transparent
        Me.butCreateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butCreateReport.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCreateReport.ForeColor = System.Drawing.Color.Black
        Me.butCreateReport.Location = New System.Drawing.Point(6, 122)
        Me.butCreateReport.Name = "butCreateReport"
        Me.butCreateReport.Size = New System.Drawing.Size(83, 23)
        Me.butCreateReport.TabIndex = 1
        Me.butCreateReport.Text = "Create &Report"
        Me.butCreateReport.UseVisualStyleBackColor = False
        '
        'butNewRecord
        '
        Me.butNewRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butNewRecord.BackColor = System.Drawing.Color.Transparent
        Me.butNewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butNewRecord.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butNewRecord.ForeColor = System.Drawing.Color.Black
        Me.butNewRecord.Location = New System.Drawing.Point(6, 147)
        Me.butNewRecord.Name = "butNewRecord"
        Me.butNewRecord.Size = New System.Drawing.Size(83, 23)
        Me.butNewRecord.TabIndex = 2
        Me.butNewRecord.Text = "&New record"
        Me.butNewRecord.UseVisualStyleBackColor = False
        '
        'butSaveRecord
        '
        Me.butSaveRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butSaveRecord.BackColor = System.Drawing.Color.Transparent
        Me.butSaveRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSaveRecord.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSaveRecord.ForeColor = System.Drawing.Color.Black
        Me.butSaveRecord.Location = New System.Drawing.Point(6, 172)
        Me.butSaveRecord.Name = "butSaveRecord"
        Me.butSaveRecord.Size = New System.Drawing.Size(83, 23)
        Me.butSaveRecord.TabIndex = 3
        Me.butSaveRecord.Text = "&Save record"
        Me.butSaveRecord.UseVisualStyleBackColor = False
        '
        'pnlTop
        '

        Me.pnlTop.BackgroundImage = My.Resources.Resources.formtitle
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(699, 36)
        Me.pnlTop.TabIndex = 2
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Aqua
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(598, 36)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Aqua
        Me.Label1.Location = New System.Drawing.Point(598, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Forms Ver:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Toolbox1
        '
        Me.Toolbox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Toolbox1.InnerControl = Me.TabControl1
        Me.Toolbox1.IsMinimized = False
        Me.Toolbox1.Location = New System.Drawing.Point(0, 293)
        Me.Toolbox1.Name = "Toolbox1"
        Me.Toolbox1.Size = New System.Drawing.Size(699, 161)
        Me.Toolbox1.TabIndex = 3
        Me.Toolbox1.Title = "Edit and Export data"
        '
        'DataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Toolbox1)
        Me.Name = "DataForm"
        Me.Size = New System.Drawing.Size(699, 454)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents butDeleteRecord As System.Windows.Forms.Button
    Friend WithEvents butSaveRecord As System.Windows.Forms.Button
    Friend WithEvents butNewRecord As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
    Friend WithEvents lblFormVer As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents butCreateReport As System.Windows.Forms.Button
    Friend WithEvents butImport As System.Windows.Forms.Button
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butQuickfix As System.Windows.Forms.Button
    Friend WithEvents Toolbox1 As Toolbox
    Friend WithEvents chkShowGrid As System.Windows.Forms.CheckBox

End Class
