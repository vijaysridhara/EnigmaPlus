<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IssueForm
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
        Me.butSubmit = New System.Windows.Forms.Button()
        Me.dtpRaisedon = New System.Windows.Forms.DateTimePicker()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblResolution = New System.Windows.Forms.Label()
        Me.lblRaisedBy = New System.Windows.Forms.Label()
        Me.lblRaisedon = New System.Windows.Forms.Label()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.lblLastUpdated = New System.Windows.Forms.Label()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtRaisedBy = New System.Windows.Forms.TextBox()
        Me.txtResolution = New System.Windows.Forms.TextBox()
        Me.txtSummary = New System.Windows.Forms.TextBox()
        Me.dgdItems = New System.Windows.Forms.DataGridView()
        Me.lblCreatedOn = New System.Windows.Forms.Label()
        Me.butNew = New System.Windows.Forms.Button()
        Me.blobFile = New Blobber()
        Me.colHID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHSummary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHRaisedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHRaisedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHResolution = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butSubmit
        '
        Me.butSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSubmit.Location = New System.Drawing.Point(471, 345)
        Me.butSubmit.Name = "butSubmit"
        Me.butSubmit.Size = New System.Drawing.Size(91, 27)
        Me.butSubmit.TabIndex = 56
        Me.butSubmit.Text = "&Add issue"
        Me.butSubmit.UseVisualStyleBackColor = True
        '
        'dtpRaisedon
        '
        Me.dtpRaisedon.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtpRaisedon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRaisedon.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRaisedon.Location = New System.Drawing.Point(87, 185)
        Me.dtpRaisedon.Name = "dtpRaisedon"
        Me.dtpRaisedon.Size = New System.Drawing.Size(150, 22)
        Me.dtpRaisedon.TabIndex = 54
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "ASSIGNED", "INPROGRESS", "RESOLVED", "REJECTED"})
        Me.cboStatus.Location = New System.Drawing.Point(87, 320)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(121, 24)
        Me.cboStatus.TabIndex = 47
        '
        'lblResolution
        '
        Me.lblResolution.AutoSize = True
        Me.lblResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResolution.Location = New System.Drawing.Point(9, 216)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(72, 16)
        Me.lblResolution.TabIndex = 45
        Me.lblResolution.Text = "Resol&ution"
        '
        'lblRaisedBy
        '
        Me.lblRaisedBy.AutoSize = True
        Me.lblRaisedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaisedBy.Location = New System.Drawing.Point(254, 190)
        Me.lblRaisedBy.Name = "lblRaisedBy"
        Me.lblRaisedBy.Size = New System.Drawing.Size(70, 16)
        Me.lblRaisedBy.TabIndex = 42
        Me.lblRaisedBy.Text = "Raised &by"
        '
        'lblRaisedon
        '
        Me.lblRaisedon.AutoSize = True
        Me.lblRaisedon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaisedon.Location = New System.Drawing.Point(7, 187)
        Me.lblRaisedon.Name = "lblRaisedon"
        Me.lblRaisedon.Size = New System.Drawing.Size(70, 16)
        Me.lblRaisedon.TabIndex = 43
        Me.lblRaisedon.Text = "Raised &on"
        '
        'lblDetails
        '
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetails.Location = New System.Drawing.Point(7, 37)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(50, 16)
        Me.lblDetails.TabIndex = 36
        Me.lblDetails.Text = "Details"
        '
        'lblLastUpdated
        '
        Me.lblLastUpdated.AutoSize = True
        Me.lblLastUpdated.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastUpdated.Location = New System.Drawing.Point(266, 381)
        Me.lblLastUpdated.Name = "lblLastUpdated"
        Me.lblLastUpdated.Size = New System.Drawing.Size(28, 16)
        Me.lblLastUpdated.TabIndex = 35
        Me.lblLastUpdated.Text = "UU"
        Me.lblLastUpdated.Visible = False
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFile.Location = New System.Drawing.Point(7, 356)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(30, 16)
        Me.lblFile.TabIndex = 40
        Me.lblFile.Text = "&File"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(7, 323)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(45, 16)
        Me.lblStatus.TabIndex = 41
        Me.lblStatus.Text = "&Status"
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSummary.Location = New System.Drawing.Point(7, 11)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(65, 16)
        Me.lblSummary.TabIndex = 38
        Me.lblSummary.Text = "&Summary"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(87, 34)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(475, 144)
        Me.txtDescription.TabIndex = 49
        '
        'txtRaisedBy
        '
        Me.txtRaisedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRaisedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRaisedBy.Location = New System.Drawing.Point(330, 187)
        Me.txtRaisedBy.Name = "txtRaisedBy"
        Me.txtRaisedBy.Size = New System.Drawing.Size(232, 22)
        Me.txtRaisedBy.TabIndex = 51
        '
        'txtResolution
        '
        Me.txtResolution.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResolution.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResolution.Location = New System.Drawing.Point(87, 216)
        Me.txtResolution.Multiline = True
        Me.txtResolution.Name = "txtResolution"
        Me.txtResolution.Size = New System.Drawing.Size(475, 98)
        Me.txtResolution.TabIndex = 52
        '
        'txtSummary
        '
        Me.txtSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSummary.Location = New System.Drawing.Point(87, 8)
        Me.txtSummary.Name = "txtSummary"
        Me.txtSummary.Size = New System.Drawing.Size(378, 22)
        Me.txtSummary.TabIndex = 53
        '
        'dgdItems
        '
        Me.dgdItems.AllowUserToAddRows = False
        Me.dgdItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHID, Me.colHSummary, Me.colHRaisedOn, Me.colHRaisedBy, Me.colHResolution, Me.colHStatus})
        Me.dgdItems.Location = New System.Drawing.Point(0, 400)
        Me.dgdItems.Name = "dgdItems"
        Me.dgdItems.ReadOnly = True
        Me.dgdItems.RowHeadersVisible = False
        Me.dgdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdItems.Size = New System.Drawing.Size(577, 183)
        Me.dgdItems.TabIndex = 57
        '
        'lblCreatedOn
        '
        Me.lblCreatedOn.AutoSize = True
        Me.lblCreatedOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedOn.Location = New System.Drawing.Point(7, 381)
        Me.lblCreatedOn.Name = "lblCreatedOn"
        Me.lblCreatedOn.Size = New System.Drawing.Size(26, 16)
        Me.lblCreatedOn.TabIndex = 59
        Me.lblCreatedOn.Text = "CC"
        Me.lblCreatedOn.Visible = False
        '
        'butNew
        '
        Me.butNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butNew.Image = My.Resources.Resources.note
        Me.butNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butNew.Location = New System.Drawing.Point(471, 3)
        Me.butNew.Name = "butNew"
        Me.butNew.Size = New System.Drawing.Size(91, 29)
        Me.butNew.TabIndex = 58
        Me.butNew.Text = "New item"
        Me.butNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.butNew.UseVisualStyleBackColor = True
        '
        'blobFile
        '
        Me.blobFile.Blob = Nothing
        Me.blobFile.BlobSize = CType(0, Long)
        Me.blobFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.blobFile.IsClob = False
        Me.blobFile.Location = New System.Drawing.Point(87, 352)
        Me.blobFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.blobFile.Name = "blobFile"
        Me.blobFile.Size = New System.Drawing.Size(262, 20)
        Me.blobFile.TabIndex = 55
        '
        'colHID
        '
        Me.colHID.HeaderText = "ID"
        Me.colHID.Name = "colHID"
        Me.colHID.ReadOnly = True
        Me.colHID.Width = 40
        '
        'colHSummary
        '
        Me.colHSummary.HeaderText = "Summary"
        Me.colHSummary.Name = "colHSummary"
        Me.colHSummary.ReadOnly = True
        Me.colHSummary.Width = 200
        '
        'colHRaisedOn
        '
        Me.colHRaisedOn.HeaderText = "Raisedon"
        Me.colHRaisedOn.Name = "colHRaisedOn"
        Me.colHRaisedOn.ReadOnly = True
        Me.colHRaisedOn.Width = 150
        '
        'colHRaisedBy
        '
        Me.colHRaisedBy.HeaderText = "Raised by"
        Me.colHRaisedBy.Name = "colHRaisedBy"
        Me.colHRaisedBy.ReadOnly = True
        '
        'colHResolution
        '
        Me.colHResolution.HeaderText = "Resolution"
        Me.colHResolution.Name = "colHResolution"
        Me.colHResolution.ReadOnly = True
        Me.colHResolution.Width = 200
        '
        'colHStatus
        '
        Me.colHStatus.HeaderText = "Status"
        Me.colHStatus.Name = "colHStatus"
        Me.colHStatus.ReadOnly = True
        '
        'IssueForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblCreatedOn)
        Me.Controls.Add(Me.butNew)
        Me.Controls.Add(Me.dgdItems)
        Me.Controls.Add(Me.blobFile)
        Me.Controls.Add(Me.butSubmit)
        Me.Controls.Add(Me.dtpRaisedon)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.lblResolution)
        Me.Controls.Add(Me.lblRaisedBy)
        Me.Controls.Add(Me.lblRaisedon)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.lblLastUpdated)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtRaisedBy)
        Me.Controls.Add(Me.txtResolution)
        Me.Controls.Add(Me.txtSummary)
        Me.Name = "IssueForm"
        Me.Size = New System.Drawing.Size(577, 584)
        CType(Me.dgdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents blobFile As Blobber
    Friend WithEvents butSubmit As System.Windows.Forms.Button
    Friend WithEvents dtpRaisedon As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents lblRaisedBy As System.Windows.Forms.Label
    Friend WithEvents lblRaisedon As System.Windows.Forms.Label
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdated As System.Windows.Forms.Label
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblSummary As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtRaisedBy As System.Windows.Forms.TextBox
    Friend WithEvents txtResolution As System.Windows.Forms.TextBox
    Friend WithEvents txtSummary As System.Windows.Forms.TextBox
    Friend WithEvents dgdItems As System.Windows.Forms.DataGridView
    Friend WithEvents butNew As System.Windows.Forms.Button
    Friend WithEvents lblCreatedOn As System.Windows.Forms.Label
    Friend WithEvents colHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHSummary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHRaisedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHRaisedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHResolution As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHStatus As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
