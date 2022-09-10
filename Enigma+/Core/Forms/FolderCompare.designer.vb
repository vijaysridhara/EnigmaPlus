<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FolderCompare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FolderCompare))
        Me.butSelFolder1 = New System.Windows.Forms.Button()
        Me.txtFolder1 = New System.Windows.Forms.TextBox()
        Me.txtFolder2 = New System.Windows.Forms.TextBox()
        Me.butSelFolder2 = New System.Windows.Forms.Button()
        Me.butCompare = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colHIcon1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colHFolder1File = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHSizeMod1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHIcon2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colHFolder2File = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHSizeandMod2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butSelFolder1
        '
        Me.butSelFolder1.Location = New System.Drawing.Point(277, 12)
        Me.butSelFolder1.Name = "butSelFolder1"
        Me.butSelFolder1.Size = New System.Drawing.Size(33, 20)
        Me.butSelFolder1.TabIndex = 0
        Me.butSelFolder1.Text = "..."
        Me.butSelFolder1.UseVisualStyleBackColor = True
        '
        'txtFolder1
        '
        Me.txtFolder1.Location = New System.Drawing.Point(14, 12)
        Me.txtFolder1.Name = "txtFolder1"
        Me.txtFolder1.ReadOnly = True
        Me.txtFolder1.Size = New System.Drawing.Size(245, 20)
        Me.txtFolder1.TabIndex = 1
        '
        'txtFolder2
        '
        Me.txtFolder2.Location = New System.Drawing.Point(316, 12)
        Me.txtFolder2.Name = "txtFolder2"
        Me.txtFolder2.ReadOnly = True
        Me.txtFolder2.Size = New System.Drawing.Size(245, 20)
        Me.txtFolder2.TabIndex = 3
        '
        'butSelFolder2
        '
        Me.butSelFolder2.Location = New System.Drawing.Point(567, 11)
        Me.butSelFolder2.Name = "butSelFolder2"
        Me.butSelFolder2.Size = New System.Drawing.Size(33, 20)
        Me.butSelFolder2.TabIndex = 2
        Me.butSelFolder2.Text = "..."
        Me.butSelFolder2.UseVisualStyleBackColor = True
        '
        'butCompare
        '
        Me.butCompare.Location = New System.Drawing.Point(606, 10)
        Me.butCompare.Name = "butCompare"
        Me.butCompare.Size = New System.Drawing.Size(75, 23)
        Me.butCompare.TabIndex = 4
        Me.butCompare.Text = "Compare"
        Me.butCompare.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHIcon1, Me.colHFolder1File, Me.colHSizeMod1, Me.colHIcon2, Me.colHFolder2File, Me.colHSizeandMod2})
        Me.DataGridView1.Location = New System.Drawing.Point(2, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(819, 373)
        Me.DataGridView1.TabIndex = 5
        '
        'colHIcon1
        '
        Me.colHIcon1.HeaderText = "Exists"
        Me.colHIcon1.Name = "colHIcon1"
        Me.colHIcon1.ReadOnly = True
        Me.colHIcon1.Width = 20
        '
        'colHFolder1File
        '
        Me.colHFolder1File.HeaderText = "Folder 1 File"
        Me.colHFolder1File.Name = "colHFolder1File"
        Me.colHFolder1File.ReadOnly = True
        Me.colHFolder1File.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colHFolder1File.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colHFolder1File.Width = 300
        '
        'colHSizeMod1
        '
        Me.colHSizeMod1.HeaderText = "Size and Mod"
        Me.colHSizeMod1.Name = "colHSizeMod1"
        Me.colHSizeMod1.ReadOnly = True
        Me.colHSizeMod1.Width = 200
        '
        'colHIcon2
        '
        Me.colHIcon2.HeaderText = "Exists"
        Me.colHIcon2.Name = "colHIcon2"
        Me.colHIcon2.ReadOnly = True
        Me.colHIcon2.Width = 20
        '
        'colHFolder2File
        '
        Me.colHFolder2File.HeaderText = "Folder 2 File"
        Me.colHFolder2File.Name = "colHFolder2File"
        Me.colHFolder2File.ReadOnly = True
        Me.colHFolder2File.Width = 300
        '
        'colHSizeandMod2
        '
        Me.colHSizeandMod2.HeaderText = "Size and Mod"
        Me.colHSizeandMod2.Name = "colHSizeandMod2"
        Me.colHSizeandMod2.ReadOnly = True
        Me.colHSizeandMod2.Width = 200
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folderexists.ico")
        Me.ImageList1.Images.SetKeyName(1, "folderdoesntesxist.ico")
        Me.ImageList1.Images.SetKeyName(2, "fileexists.ico")
        Me.ImageList1.Images.SetKeyName(3, "filedoesntexist.ico")
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(94, 95)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(604, 21)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 6
        Me.ProgressBar1.Value = 10
        Me.ProgressBar1.Visible = False
        '
        'FolderCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 414)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.butCompare)
        Me.Controls.Add(Me.txtFolder2)
        Me.Controls.Add(Me.butSelFolder2)
        Me.Controls.Add(Me.txtFolder1)
        Me.Controls.Add(Me.butSelFolder1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Name = "FolderCompare"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Folder Compare"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butSelFolder1 As System.Windows.Forms.Button
    Friend WithEvents txtFolder1 As System.Windows.Forms.TextBox
    Friend WithEvents txtFolder2 As System.Windows.Forms.TextBox
    Friend WithEvents butSelFolder2 As System.Windows.Forms.Button
    Friend WithEvents butCompare As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents colHIcon1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colHFolder1File As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHSizeMod1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHIcon2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colHFolder2File As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHSizeandMod2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
