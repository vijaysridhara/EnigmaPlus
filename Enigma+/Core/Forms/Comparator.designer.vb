<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Comparator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Comparator))
        Me.butRemoveDups = New System.Windows.Forms.Button()
        Me.butCompare = New System.Windows.Forms.Button()
        Me.lblFirst = New System.Windows.Forms.Label()
        Me.lblSecondList = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.ctxMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtList2 = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tlstpMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PGBCOMPARE = New System.Windows.Forms.ToolStripProgressBar()
        Me.butClearLists = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.txtList1 = New System.Windows.Forms.RichTextBox()
        Me.txtResult = New System.Windows.Forms.RichTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ctxMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'butRemoveDups
        '
        Me.butRemoveDups.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butRemoveDups.Location = New System.Drawing.Point(422, 3)
        Me.butRemoveDups.Name = "butRemoveDups"
        Me.butRemoveDups.Size = New System.Drawing.Size(146, 24)
        Me.butRemoveDups.TabIndex = 0
        Me.butRemoveDups.Text = "&Remove Dups"
        Me.butRemoveDups.UseVisualStyleBackColor = True
        '
        'butCompare
        '
        Me.butCompare.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butCompare.Location = New System.Drawing.Point(574, 3)
        Me.butCompare.Name = "butCompare"
        Me.butCompare.Size = New System.Drawing.Size(124, 24)
        Me.butCompare.TabIndex = 1
        Me.butCompare.Text = "&Compare"
        Me.butCompare.UseVisualStyleBackColor = True
        '
        'lblFirst
        '
        Me.lblFirst.AutoSize = True
        Me.lblFirst.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFirst.Location = New System.Drawing.Point(0, 0)
        Me.lblFirst.Name = "lblFirst"
        Me.lblFirst.Size = New System.Drawing.Size(41, 13)
        Me.lblFirst.TabIndex = 0
        Me.lblFirst.Text = "&Big List"
        '
        'lblSecondList
        '
        Me.lblSecondList.AutoSize = True
        Me.lblSecondList.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSecondList.Location = New System.Drawing.Point(0, 0)
        Me.lblSecondList.Name = "lblSecondList"
        Me.lblSecondList.Size = New System.Drawing.Size(51, 13)
        Me.lblSecondList.TabIndex = 0
        Me.lblSecondList.Text = "&Small List"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(3, 9)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(37, 13)
        Me.lblResult.TabIndex = 2
        Me.lblResult.Text = "R&esult"
        '
        'ctxMain
        '
        Me.ctxMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ToolStripMenuItem1, Me.SelectallToolStripMenuItem})
        Me.ctxMain.Name = "ctxMain"
        Me.ctxMain.Size = New System.Drawing.Size(121, 98)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.CutToolStripMenuItem.Text = "Cu&t"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.CopyToolStripMenuItem.Text = "&Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.PasteToolStripMenuItem.Text = "&Paste"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(117, 6)
        '
        'SelectallToolStripMenuItem
        '
        Me.SelectallToolStripMenuItem.Name = "SelectallToolStripMenuItem"
        Me.SelectallToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.SelectallToolStripMenuItem.Text = "Select &all"
        '
        'txtList2
        '
        Me.txtList2.ContextMenuStrip = Me.ctxMain
        Me.txtList2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtList2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtList2.HideSelection = False
        Me.txtList2.Location = New System.Drawing.Point(0, 13)
        Me.txtList2.Name = "txtList2"
        Me.txtList2.Size = New System.Drawing.Size(464, 222)
        Me.txtList2.TabIndex = 1
        Me.txtList2.Text = "PRAVEEN" & Global.Microsoft.VisualBasic.ChrW(10) & "VIJAY" & Global.Microsoft.VisualBasic.ChrW(10) & "PRAVEEN" & Global.Microsoft.VisualBasic.ChrW(10) & "SHIVA" & Global.Microsoft.VisualBasic.ChrW(10) & "RAVI" & Global.Microsoft.VisualBasic.ChrW(10) & "NAG" & Global.Microsoft.VisualBasic.ChrW(10) & "ANIL" & Global.Microsoft.VisualBasic.ChrW(10) & "VIJAY" & Global.Microsoft.VisualBasic.ChrW(10) & "GURU" & Global.Microsoft.VisualBasic.ChrW(10) & "RAGHU" & Global.Microsoft.VisualBasic.ChrW(10) & "HEMA" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlstpMessage, Me.PGBCOMPARE})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 546)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(702, 22)
        Me.StatusStrip1.TabIndex = 8
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tlstpMessage
        '
        Me.tlstpMessage.Name = "tlstpMessage"
        Me.tlstpMessage.Size = New System.Drawing.Size(385, 17)
        Me.tlstpMessage.Spring = True
        Me.tlstpMessage.Text = "Ready"
        Me.tlstpMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PGBCOMPARE
        '
        Me.PGBCOMPARE.Name = "PGBCOMPARE"
        Me.PGBCOMPARE.Size = New System.Drawing.Size(300, 16)
        '
        'butClearLists
        '
        Me.butClearLists.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butClearLists.Location = New System.Drawing.Point(256, 3)
        Me.butClearLists.Name = "butClearLists"
        Me.butClearLists.Size = New System.Drawing.Size(160, 24)
        Me.butClearLists.TabIndex = 3
        Me.butClearLists.Text = "C&lear lists"
        Me.butClearLists.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtResult)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(702, 546)
        Me.SplitContainer1.SplitterDistance = 235
        Me.SplitContainer1.TabIndex = 9
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtList1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblFirst)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtList2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblSecondList)
        Me.SplitContainer2.Size = New System.Drawing.Size(702, 235)
        Me.SplitContainer2.SplitterDistance = 234
        Me.SplitContainer2.TabIndex = 0
        '
        'txtList1
        '
        Me.txtList1.ContextMenuStrip = Me.ctxMain
        Me.txtList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtList1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtList1.HideSelection = False
        Me.txtList1.Location = New System.Drawing.Point(0, 13)
        Me.txtList1.Name = "txtList1"
        Me.txtList1.Size = New System.Drawing.Size(234, 222)
        Me.txtList1.TabIndex = 4
        Me.txtList1.Text = "VIJAY" & Global.Microsoft.VisualBasic.ChrW(10) & "GURU" & Global.Microsoft.VisualBasic.ChrW(10) & "RAGHU" & Global.Microsoft.VisualBasic.ChrW(10) & "PRAMILA" & Global.Microsoft.VisualBasic.ChrW(10) & "PRAVEEN" & Global.Microsoft.VisualBasic.ChrW(10) & "VIJAY" & Global.Microsoft.VisualBasic.ChrW(10) & "PRAVEEN" & Global.Microsoft.VisualBasic.ChrW(10) & "SHIVA" & Global.Microsoft.VisualBasic.ChrW(10) & "SRIDHAR" & Global.Microsoft.VisualBasic.ChrW(10) & "RAVI" & Global.Microsoft.VisualBasic.ChrW(10) & "NAG" & Global.Microsoft.VisualBasic.ChrW(10) & "ANIL" & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtResult
        '
        Me.txtResult.ContextMenuStrip = Me.ctxMain
        Me.txtResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResult.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResult.HideSelection = False
        Me.txtResult.Location = New System.Drawing.Point(0, 28)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(702, 279)
        Me.txtResult.TabIndex = 0
        Me.txtResult.Text = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.butClearLists)
        Me.Panel1.Controls.Add(Me.butRemoveDups)
        Me.Panel1.Controls.Add(Me.lblResult)
        Me.Panel1.Controls.Add(Me.butCompare)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(702, 28)
        Me.Panel1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(52, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 30)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "I can remove duplicates from Big list and can compare Big and Small lists"
        '
        'Comparator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 568)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Comparator"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comparator"
        Me.ctxMain.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butRemoveDups As System.Windows.Forms.Button
    Friend WithEvents butCompare As System.Windows.Forms.Button
    Friend WithEvents lblFirst As System.Windows.Forms.Label
    Friend WithEvents lblSecondList As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents txtList2 As System.Windows.Forms.RichTextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tlstpMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PGBCOMPARE As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents butClearLists As System.Windows.Forms.Button
    Friend WithEvents ctxMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SelectallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtResult As System.Windows.Forms.RichTextBox
    Friend WithEvents txtList1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
