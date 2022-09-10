<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkItems
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkItems))
        Me.ctxTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.QuickAddToolstripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssignedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InProgressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClosedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RejectedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tlstpTasks = New System.Windows.Forms.ToolStripButton()
        Me.tlstpDefects = New System.Windows.Forms.ToolStripButton()
        Me.tlstpIssues = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.DefectForm1 = New VijaySridhara.Applications.DefectForm()
        Me.TaskForm1 = New VijaySridhara.Applications.TaskForm()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.tvwMain = New System.Windows.Forms.TreeView()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.tabBottom = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRelname = New System.Windows.Forms.TextBox()
        Me.butDeleteRelease = New System.Windows.Forms.Button()
        Me.butAddRElease = New System.Windows.Forms.Button()
        Me.cboReleases = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.chkPreload = New System.Windows.Forms.CheckBox()
        Me.butDelete = New System.Windows.Forms.Button()
        Me.butModify = New System.Windows.Forms.Button()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.txtFilterName = New System.Windows.Forms.TextBox()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.lblFilterName = New System.Windows.Forms.Label()
        Me.butExport = New System.Windows.Forms.Button()
        Me.IssueForm1 = New VijaySridhara.Applications.IssueForm()
        Me.ctxTree.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.tabBottom.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctxTree
        '
        Me.ctxTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuickAddToolstripMenuItem, Me.NewToolStripMenuItem, Me.MarkToolStripMenuItem, Me.ShowDetailsToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.ToolStripMenuItem1, Me.DeleteToolStripMenuItem})
        Me.ctxTree.Name = "ctxTree"
        Me.ctxTree.Size = New System.Drawing.Size(141, 142)
        '
        'QuickAddToolstripMenuItem
        '
        Me.QuickAddToolstripMenuItem.Name = "QuickAddToolstripMenuItem"
        Me.QuickAddToolstripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.QuickAddToolstripMenuItem.Text = "&Quick add"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'MarkToolStripMenuItem
        '
        Me.MarkToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.AssignedToolStripMenuItem, Me.InProgressToolStripMenuItem, Me.ClosedToolStripMenuItem, Me.RejectedToolStripMenuItem})
        Me.MarkToolStripMenuItem.Name = "MarkToolStripMenuItem"
        Me.MarkToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.MarkToolStripMenuItem.Text = "&Mark"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'AssignedToolStripMenuItem
        '
        Me.AssignedToolStripMenuItem.Name = "AssignedToolStripMenuItem"
        Me.AssignedToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.AssignedToolStripMenuItem.Text = "&Assigned"
        '
        'InProgressToolStripMenuItem
        '
        Me.InProgressToolStripMenuItem.Name = "InProgressToolStripMenuItem"
        Me.InProgressToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.InProgressToolStripMenuItem.Text = "&In progress"
        '
        'ClosedToolStripMenuItem
        '
        Me.ClosedToolStripMenuItem.Name = "ClosedToolStripMenuItem"
        Me.ClosedToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ClosedToolStripMenuItem.Text = "&Closed"
        '
        'RejectedToolStripMenuItem
        '
        Me.RejectedToolStripMenuItem.Name = "RejectedToolStripMenuItem"
        Me.RejectedToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.RejectedToolStripMenuItem.Text = "&Rejected"
        '
        'ShowDetailsToolStripMenuItem
        '
        Me.ShowDetailsToolStripMenuItem.Name = "ShowDetailsToolStripMenuItem"
        Me.ShowDetailsToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ShowDetailsToolStripMenuItem.Text = "&Show details"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ReloadToolStripMenuItem.Text = "&Reload"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(137, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "tasks.ico")
        Me.ImageList1.Images.SetKeyName(1, "bugs.ico")
        Me.ImageList1.Images.SetKeyName(2, "issues.ico")
        Me.ImageList1.Images.SetKeyName(3, "Assignedbyme.ico")
        Me.ImageList1.Images.SetKeyName(4, "Assigned-otherrs.ico")
        Me.ImageList1.Images.SetKeyName(5, "tasks1.ico")
        Me.ImageList1.Images.SetKeyName(6, "Unassigned.ico")
        Me.ImageList1.Images.SetKeyName(7, "assignedtoothers.ico")
        Me.ImageList1.Images.SetKeyName(8, "Progress.ico")
        Me.ImageList1.Images.SetKeyName(9, "Complete.ico")
        Me.ImageList1.Images.SetKeyName(10, "Concern.ico")
        Me.ImageList1.Images.SetKeyName(11, "FileS1.ico")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlstpTasks, Me.tlstpDefects, Me.tlstpIssues, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(932, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tlstpTasks
        '
        Me.tlstpTasks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tlstpTasks.Image = CType(resources.GetObject("tlstpTasks.Image"), System.Drawing.Image)
        Me.tlstpTasks.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpTasks.Name = "tlstpTasks"
        Me.tlstpTasks.Size = New System.Drawing.Size(38, 22)
        Me.tlstpTasks.Text = "&Tasks"
        '
        'tlstpDefects
        '
        Me.tlstpDefects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tlstpDefects.Image = CType(resources.GetObject("tlstpDefects.Image"), System.Drawing.Image)
        Me.tlstpDefects.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpDefects.Name = "tlstpDefects"
        Me.tlstpDefects.Size = New System.Drawing.Size(50, 22)
        Me.tlstpDefects.Text = "&Defects"
        '
        'tlstpIssues
        '
        Me.tlstpIssues.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tlstpIssues.Image = CType(resources.GetObject("tlstpIssues.Image"), System.Drawing.Image)
        Me.tlstpIssues.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpIssues.Name = "tlstpIssues"
        Me.tlstpIssues.Size = New System.Drawing.Size(42, 22)
        Me.tlstpIssues.Text = "&Issues"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(87, 22)
        Me.ToolStripButton1.Text = "&Frequent tasks"
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlRight)
        Me.pnlMain.Controls.Add(Me.Splitter2)
        Me.pnlMain.Controls.Add(Me.pnlLeft)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 25)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(932, 662)
        Me.pnlMain.TabIndex = 2
        '
        'pnlRight
        '
        Me.pnlRight.AutoScroll = True
        Me.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRight.Controls.Add(Me.IssueForm1)
        Me.pnlRight.Controls.Add(Me.DefectForm1)
        Me.pnlRight.Controls.Add(Me.TaskForm1)
        Me.pnlRight.Controls.Add(Me.lblTitle)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(305, 0)
        Me.pnlRight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(627, 662)
        Me.pnlRight.TabIndex = 6
        '
        'DefectForm1
        '
        Me.DefectForm1.Location = New System.Drawing.Point(237, 223)
        Me.DefectForm1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DefectForm1.Name = "DefectForm1"
        Me.DefectForm1.Size = New System.Drawing.Size(83, 94)
        Me.DefectForm1.TabIndex = 5
        '
        'TaskForm1
        '
        Me.TaskForm1.Location = New System.Drawing.Point(34, 83)
        Me.TaskForm1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TaskForm1.Name = "TaskForm1"
        Me.TaskForm1.Size = New System.Drawing.Size(195, 176)
        Me.TaskForm1.TabIndex = 3
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(625, 26)
        Me.lblTitle.TabIndex = 2
        Me.lblTitle.Text = "Tasks"
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(301, 0)
        Me.Splitter2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(4, 662)
        Me.Splitter2.TabIndex = 5
        Me.Splitter2.TabStop = False
        '
        'pnlLeft
        '
        Me.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLeft.Controls.Add(Me.tvwMain)
        Me.pnlLeft.Controls.Add(Me.Splitter1)
        Me.pnlLeft.Controls.Add(Me.tabBottom)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(301, 662)
        Me.pnlLeft.TabIndex = 1
        '
        'tvwMain
        '
        Me.tvwMain.ContextMenuStrip = Me.ctxTree
        Me.tvwMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.tvwMain.HideSelection = False
        Me.tvwMain.HotTracking = True
        Me.tvwMain.ImageIndex = 0
        Me.tvwMain.ImageList = Me.ImageList1
        Me.tvwMain.Location = New System.Drawing.Point(0, 0)
        Me.tvwMain.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tvwMain.Name = "tvwMain"
        Me.tvwMain.SelectedImageIndex = 0
        Me.tvwMain.Size = New System.Drawing.Size(299, 445)
        Me.tvwMain.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 445)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(299, 3)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'tabBottom
        '
        Me.tabBottom.Controls.Add(Me.TabPage1)
        Me.tabBottom.Controls.Add(Me.TabPage2)
        Me.tabBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabBottom.Location = New System.Drawing.Point(0, 448)
        Me.tabBottom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tabBottom.Name = "tabBottom"
        Me.tabBottom.SelectedIndex = 0
        Me.tabBottom.Size = New System.Drawing.Size(299, 212)
        Me.tabBottom.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtRelname)
        Me.TabPage1.Controls.Add(Me.butDeleteRelease)
        Me.TabPage1.Controls.Add(Me.butAddRElease)
        Me.TabPage1.Controls.Add(Me.cboReleases)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabPage1.Size = New System.Drawing.Size(291, 184)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Releases"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'txtRelname
        '
        Me.txtRelname.Location = New System.Drawing.Point(8, 33)
        Me.txtRelname.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtRelname.Name = "txtRelname"
        Me.txtRelname.Size = New System.Drawing.Size(202, 23)
        Me.txtRelname.TabIndex = 1
        '
        'butDeleteRelease
        '
        Me.butDeleteRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butDeleteRelease.Location = New System.Drawing.Point(218, 65)
        Me.butDeleteRelease.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.butDeleteRelease.Name = "butDeleteRelease"
        Me.butDeleteRelease.Size = New System.Drawing.Size(64, 27)
        Me.butDeleteRelease.TabIndex = 4
        Me.butDeleteRelease.Text = "&Delete"
        Me.butDeleteRelease.UseVisualStyleBackColor = True
        '
        'butAddRElease
        '
        Me.butAddRElease.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butAddRElease.Location = New System.Drawing.Point(218, 31)
        Me.butAddRElease.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.butAddRElease.Name = "butAddRElease"
        Me.butAddRElease.Size = New System.Drawing.Size(64, 27)
        Me.butAddRElease.TabIndex = 3
        Me.butAddRElease.Text = "&Add"
        Me.butAddRElease.UseVisualStyleBackColor = True
        '
        'cboReleases
        '
        Me.cboReleases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReleases.FormattingEnabled = True
        Me.cboReleases.Location = New System.Drawing.Point(7, 65)
        Me.cboReleases.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cboReleases.Name = "cboReleases"
        Me.cboReleases.Size = New System.Drawing.Size(204, 23)
        Me.cboReleases.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.pnlBottom)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabPage2.Size = New System.Drawing.Size(291, 184)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Filters"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pnlBottom
        '
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBottom.Controls.Add(Me.chkPreload)
        Me.pnlBottom.Controls.Add(Me.butDelete)
        Me.pnlBottom.Controls.Add(Me.butModify)
        Me.pnlBottom.Controls.Add(Me.butAdd)
        Me.pnlBottom.Controls.Add(Me.txtFilter)
        Me.pnlBottom.Controls.Add(Me.txtFilterName)
        Me.pnlBottom.Controls.Add(Me.lblFilter)
        Me.pnlBottom.Controls.Add(Me.lblFilterName)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBottom.Location = New System.Drawing.Point(4, 3)
        Me.pnlBottom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(283, 178)
        Me.pnlBottom.TabIndex = 0
        '
        'chkPreload
        '
        Me.chkPreload.AutoSize = True
        Me.chkPreload.Location = New System.Drawing.Point(78, 31)
        Me.chkPreload.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkPreload.Name = "chkPreload"
        Me.chkPreload.Size = New System.Drawing.Size(66, 19)
        Me.chkPreload.TabIndex = 4
        Me.chkPreload.Text = "Preload"
        Me.chkPreload.UseVisualStyleBackColor = True
        '
        'butDelete
        '
        Me.butDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butDelete.Location = New System.Drawing.Point(142, 146)
        Me.butDelete.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(64, 27)
        Me.butDelete.TabIndex = 7
        Me.butDelete.Text = "&Delete"
        Me.butDelete.UseVisualStyleBackColor = True
        '
        'butModify
        '
        Me.butModify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butModify.Location = New System.Drawing.Point(71, 146)
        Me.butModify.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.butModify.Name = "butModify"
        Me.butModify.Size = New System.Drawing.Size(64, 27)
        Me.butModify.TabIndex = 6
        Me.butModify.Text = "&Modify"
        Me.butModify.UseVisualStyleBackColor = True
        '
        'butAdd
        '
        Me.butAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butAdd.Location = New System.Drawing.Point(0, 146)
        Me.butAdd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(64, 27)
        Me.butAdd.TabIndex = 5
        Me.butAdd.Text = "&Add"
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtFilter.Location = New System.Drawing.Point(4, 51)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtFilter.Multiline = True
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(273, 88)
        Me.txtFilter.TabIndex = 3
        '
        'txtFilterName
        '
        Me.txtFilterName.Location = New System.Drawing.Point(78, 3)
        Me.txtFilterName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtFilterName.Name = "txtFilterName"
        Me.txtFilterName.Size = New System.Drawing.Size(116, 23)
        Me.txtFilterName.TabIndex = 1
        '
        'lblFilter
        '
        Me.lblFilter.AutoSize = True
        Me.lblFilter.Location = New System.Drawing.Point(4, 32)
        Me.lblFilter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(33, 15)
        Me.lblFilter.TabIndex = 2
        Me.lblFilter.Text = "&Filter"
        '
        'lblFilterName
        '
        Me.lblFilterName.AutoSize = True
        Me.lblFilterName.Location = New System.Drawing.Point(4, 7)
        Me.lblFilterName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFilterName.Name = "lblFilterName"
        Me.lblFilterName.Size = New System.Drawing.Size(66, 15)
        Me.lblFilterName.TabIndex = 0
        Me.lblFilterName.Text = "Filter &name"
        '
        'butExport
        '
        Me.butExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.butExport.Location = New System.Drawing.Point(841, 0)
        Me.butExport.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.butExport.Name = "butExport"
        Me.butExport.Size = New System.Drawing.Size(88, 28)
        Me.butExport.TabIndex = 1
        Me.butExport.Text = "E&xport"
        Me.butExport.UseVisualStyleBackColor = True
        '
        'IssueForm1
        '
        Me.IssueForm1.Location = New System.Drawing.Point(359, 68)
        Me.IssueForm1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.IssueForm1.Name = "IssueForm1"
        Me.IssueForm1.Size = New System.Drawing.Size(151, 191)
        Me.IssueForm1.TabIndex = 6
        '
        'WorkItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.butExport)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "WorkItems"
        Me.Size = New System.Drawing.Size(932, 687)
        Me.ctxTree.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        Me.tabBottom.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ctxTree As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents QuickAddToolstripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssignedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InProgressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClosedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RejectedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tlstpTasks As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpDefects As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpIssues As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents tvwMain As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents tabBottom As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRelname As System.Windows.Forms.TextBox
    Friend WithEvents butDeleteRelease As System.Windows.Forms.Button
    Friend WithEvents butAddRElease As System.Windows.Forms.Button
    Friend WithEvents cboReleases As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents butDelete As System.Windows.Forms.Button
    Friend WithEvents butModify As System.Windows.Forms.Button
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents txtFilterName As System.Windows.Forms.TextBox
    Friend WithEvents lblFilter As System.Windows.Forms.Label
    Friend WithEvents lblFilterName As System.Windows.Forms.Label
    Friend WithEvents butExport As System.Windows.Forms.Button
    Friend WithEvents chkPreload As System.Windows.Forms.CheckBox
    Friend WithEvents DefectForm1 As DefectForm
    Friend WithEvents TaskForm1 As TaskForm
    Friend WithEvents IssueForm1 As IssueForm
End Class
