<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileCompare
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
        Me.butSelectCSV = New System.Windows.Forms.Button()
        Me.txtCSV = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.FastColoredTextBox1 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FastColoredTextBox2 = New FastColoredTextBoxNS.FastColoredTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.chkTrimlines = New System.Windows.Forms.CheckBox()
        Me.butCompare = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'butSelectCSV
        '
        Me.butSelectCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSelectCSV.Location = New System.Drawing.Point(348, 3)
        Me.butSelectCSV.Name = "butSelectCSV"
        Me.butSelectCSV.Size = New System.Drawing.Size(32, 23)
        Me.butSelectCSV.TabIndex = 4
        Me.butSelectCSV.Text = "..."
        Me.butSelectCSV.UseVisualStyleBackColor = True
        '
        'txtCSV
        '
        Me.txtCSV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCSV.Location = New System.Drawing.Point(0, 3)
        Me.txtCSV.Name = "txtCSV"
        Me.txtCSV.ReadOnly = True
        Me.txtCSV.Size = New System.Drawing.Size(342, 20)
        Me.txtCSV.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.FastColoredTextBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.FastColoredTextBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(818, 325)
        Me.SplitContainer1.SplitterDistance = 383
        Me.SplitContainer1.TabIndex = 5
        '
        'FastColoredTextBox1
        '
        Me.FastColoredTextBox1.AllowDrop = True
        Me.FastColoredTextBox1.AutoScrollMinSize = New System.Drawing.Size(179, 14)
        Me.FastColoredTextBox1.BackBrush = Nothing
        Me.FastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.FastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FastColoredTextBox1.Location = New System.Drawing.Point(0, 29)
        Me.FastColoredTextBox1.Name = "FastColoredTextBox1"
        Me.FastColoredTextBox1.Paddings = New System.Windows.Forms.Padding(0)
        Me.FastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FastColoredTextBox1.Size = New System.Drawing.Size(383, 296)
        Me.FastColoredTextBox1.TabIndex = 5
        Me.FastColoredTextBox1.Text = "FastColoredTextBox1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtCSV)
        Me.Panel1.Controls.Add(Me.butSelectCSV)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(383, 29)
        Me.Panel1.TabIndex = 6
        '
        'FastColoredTextBox2
        '
        Me.FastColoredTextBox2.AllowDrop = True
        Me.FastColoredTextBox2.AutoScrollMinSize = New System.Drawing.Size(179, 14)
        Me.FastColoredTextBox2.BackBrush = Nothing
        Me.FastColoredTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FastColoredTextBox2.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.FastColoredTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FastColoredTextBox2.Location = New System.Drawing.Point(0, 29)
        Me.FastColoredTextBox2.Name = "FastColoredTextBox2"
        Me.FastColoredTextBox2.Paddings = New System.Windows.Forms.Padding(0)
        Me.FastColoredTextBox2.SelectionColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FastColoredTextBox2.Size = New System.Drawing.Size(431, 296)
        Me.FastColoredTextBox2.TabIndex = 5
        Me.FastColoredTextBox2.Text = "FastColoredTextBox1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(431, 29)
        Me.Panel2.TabIndex = 7
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(0, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(390, 20)
        Me.TextBox1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(396, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.butCompare)
        Me.Panel3.Controls.Add(Me.chkTrimlines)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 328)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(818, 119)
        Me.Panel3.TabIndex = 6
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 325)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(818, 3)
        Me.Splitter1.TabIndex = 7
        Me.Splitter1.TabStop = False
        '
        'chkTrimlines
        '
        Me.chkTrimlines.AutoSize = True
        Me.chkTrimlines.Location = New System.Drawing.Point(666, 6)
        Me.chkTrimlines.Name = "chkTrimlines"
        Me.chkTrimlines.Size = New System.Drawing.Size(149, 17)
        Me.chkTrimlines.TabIndex = 0
        Me.chkTrimlines.Text = "&Trim lines while comparing"
        Me.chkTrimlines.UseVisualStyleBackColor = True
        '
        'butCompare
        '
        Me.butCompare.Location = New System.Drawing.Point(666, 31)
        Me.butCompare.Name = "butCompare"
        Me.butCompare.Size = New System.Drawing.Size(140, 23)
        Me.butCompare.TabIndex = 1
        Me.butCompare.Text = "&Compare"
        Me.butCompare.UseVisualStyleBackColor = True
        '
        'FileCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(818, 447)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "FileCompare"
        Me.Text = "FileCompare"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents butSelectCSV As System.Windows.Forms.Button
    Friend WithEvents txtCSV As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents FastColoredTextBox1 As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents FastColoredTextBox2 As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents butCompare As System.Windows.Forms.Button
    Friend WithEvents chkTrimlines As System.Windows.Forms.CheckBox
End Class
