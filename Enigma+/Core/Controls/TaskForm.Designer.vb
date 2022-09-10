<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskForm
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
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.butSubmit = New System.Windows.Forms.Button()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboReleaseID = New System.Windows.Forms.ComboBox()
        Me.lblHours = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.lblEMail = New System.Windows.Forms.Label()
        Me.lblAssignedTo = New System.Windows.Forms.Label()
        Me.lblLastUpdated = New System.Windows.Forms.Label()
        Me.lblCreatedOn = New System.Windows.Forms.Label()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.lblReleaseID = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtHors = New System.Windows.Forms.TextBox()
        Me.txtAssignedTo = New System.Windows.Forms.TextBox()
        Me.txtSummary = New System.Windows.Forms.TextBox()
        Me.dgdItems = New System.Windows.Forms.DataGridView()
        Me.butNew = New System.Windows.Forms.Button()
        Me.blobFile = New Blobber()
        Me.colHSno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHSummary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHAssignedto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtpEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(301, 216)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(167, 22)
        Me.dtpEnd.TabIndex = 10
        '
        'butSubmit
        '
        Me.butSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSubmit.Location = New System.Drawing.Point(520, 346)
        Me.butSubmit.Name = "butSubmit"
        Me.butSubmit.Size = New System.Drawing.Size(74, 26)
        Me.butSubmit.TabIndex = 21
        Me.butSubmit.Text = "&Add task"
        Me.butSubmit.UseVisualStyleBackColor = True
        '
        'dtpStart
        '
        Me.dtpStart.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtpStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(93, 216)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(151, 22)
        Me.dtpStart.TabIndex = 8
        '
        'lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnd.Location = New System.Drawing.Point(263, 221)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(32, 16)
        Me.lblEnd.TabIndex = 9
        Me.lblEnd.Text = "&End"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "ASSIGNED", "INPROGRESS", "COMPLETED", "REJECTED"})
        Me.cboStatus.Location = New System.Drawing.Point(93, 320)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(178, 24)
        Me.cboStatus.TabIndex = 18
        '
        'cboReleaseID
        '
        Me.cboReleaseID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReleaseID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReleaseID.FormattingEnabled = True
        Me.cboReleaseID.Location = New System.Drawing.Point(89, 8)
        Me.cboReleaseID.Name = "cboReleaseID"
        Me.cboReleaseID.Size = New System.Drawing.Size(121, 24)
        Me.cboReleaseID.TabIndex = 1
        '
        'lblHours
        '
        Me.lblHours.AutoSize = True
        Me.lblHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHours.Location = New System.Drawing.Point(11, 242)
        Me.lblHours.Name = "lblHours"
        Me.lblHours.Size = New System.Drawing.Size(44, 16)
        Me.lblHours.TabIndex = 11
        Me.lblHours.Text = "&Hours"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStart.Location = New System.Drawing.Point(11, 218)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(35, 16)
        Me.lblStart.TabIndex = 7
        Me.lblStart.Text = "&Start"
        '
        'lblDetails
        '
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetails.Location = New System.Drawing.Point(11, 68)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(50, 16)
        Me.lblDetails.TabIndex = 5
        Me.lblDetails.Text = "Details"
        '
        'lblEMail
        '
        Me.lblEMail.AutoSize = True
        Me.lblEMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEMail.Location = New System.Drawing.Point(11, 297)
        Me.lblEMail.Name = "lblEMail"
        Me.lblEMail.Size = New System.Drawing.Size(42, 16)
        Me.lblEMail.TabIndex = 15
        Me.lblEMail.Text = "&Email"
        '
        'lblAssignedTo
        '
        Me.lblAssignedTo.AutoSize = True
        Me.lblAssignedTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssignedTo.Location = New System.Drawing.Point(11, 271)
        Me.lblAssignedTo.Name = "lblAssignedTo"
        Me.lblAssignedTo.Size = New System.Drawing.Size(79, 16)
        Me.lblAssignedTo.TabIndex = 13
        Me.lblAssignedTo.Text = "Assigned &to"
        '
        'lblLastUpdated
        '
        Me.lblLastUpdated.AutoSize = True
        Me.lblLastUpdated.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastUpdated.Location = New System.Drawing.Point(318, 381)
        Me.lblLastUpdated.Name = "lblLastUpdated"
        Me.lblLastUpdated.Size = New System.Drawing.Size(28, 16)
        Me.lblLastUpdated.TabIndex = 23
        Me.lblLastUpdated.Text = "UU"
        Me.lblLastUpdated.Visible = False
        '
        'lblCreatedOn
        '
        Me.lblCreatedOn.AutoSize = True
        Me.lblCreatedOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedOn.Location = New System.Drawing.Point(11, 381)
        Me.lblCreatedOn.Name = "lblCreatedOn"
        Me.lblCreatedOn.Size = New System.Drawing.Size(26, 16)
        Me.lblCreatedOn.TabIndex = 22
        Me.lblCreatedOn.Text = "CC"
        Me.lblCreatedOn.Visible = False
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFile.Location = New System.Drawing.Point(11, 356)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(30, 16)
        Me.lblFile.TabIndex = 19
        Me.lblFile.Text = "&File"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(11, 323)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(45, 16)
        Me.lblStatus.TabIndex = 17
        Me.lblStatus.Text = "&Status"
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSummary.Location = New System.Drawing.Point(11, 42)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(65, 16)
        Me.lblSummary.TabIndex = 3
        Me.lblSummary.Text = "&Summary"
        '
        'lblReleaseID
        '
        Me.lblReleaseID.AutoSize = True
        Me.lblReleaseID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReleaseID.Location = New System.Drawing.Point(11, 11)
        Me.lblReleaseID.Name = "lblReleaseID"
        Me.lblReleaseID.Size = New System.Drawing.Size(60, 16)
        Me.lblReleaseID.TabIndex = 0
        Me.lblReleaseID.Text = "Releas&e"
        '
        'txtDescription
        '
        Me.txtDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(93, 65)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(501, 144)
        Me.txtDescription.TabIndex = 6
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(93, 294)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(501, 22)
        Me.txtEmail.TabIndex = 16
        '
        'txtHors
        '
        Me.txtHors.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHors.Location = New System.Drawing.Point(93, 242)
        Me.txtHors.Name = "txtHors"
        Me.txtHors.Size = New System.Drawing.Size(61, 22)
        Me.txtHors.TabIndex = 12
        '
        'txtAssignedTo
        '
        Me.txtAssignedTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAssignedTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssignedTo.Location = New System.Drawing.Point(93, 268)
        Me.txtAssignedTo.Name = "txtAssignedTo"
        Me.txtAssignedTo.Size = New System.Drawing.Size(501, 22)
        Me.txtAssignedTo.TabIndex = 14
        '
        'txtSummary
        '
        Me.txtSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSummary.Location = New System.Drawing.Point(93, 39)
        Me.txtSummary.Name = "txtSummary"
        Me.txtSummary.Size = New System.Drawing.Size(501, 22)
        Me.txtSummary.TabIndex = 4
        '
        'dgdItems
        '
        Me.dgdItems.AllowUserToAddRows = False
        Me.dgdItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHSno, Me.colHSummary, Me.colHStart, Me.colHHours, Me.colHAssignedto, Me.colHStatus})
        Me.dgdItems.Location = New System.Drawing.Point(0, 409)
        Me.dgdItems.Name = "dgdItems"
        Me.dgdItems.ReadOnly = True
        Me.dgdItems.RowHeadersVisible = False
        Me.dgdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdItems.Size = New System.Drawing.Size(609, 164)
        Me.dgdItems.TabIndex = 24
        '
        'butNew
        '
        Me.butNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butNew.Image = My.Resources.Resources.note
        Me.butNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butNew.Location = New System.Drawing.Point(503, 3)
        Me.butNew.Name = "butNew"
        Me.butNew.Size = New System.Drawing.Size(91, 29)
        Me.butNew.TabIndex = 2
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
        Me.blobFile.Location = New System.Drawing.Point(93, 352)
        Me.blobFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.blobFile.Name = "blobFile"
        Me.blobFile.Size = New System.Drawing.Size(273, 20)
        Me.blobFile.TabIndex = 20
        '
        'colHSno
        '
        Me.colHSno.HeaderText = "ID"
        Me.colHSno.Name = "colHSno"
        Me.colHSno.ReadOnly = True
        Me.colHSno.Width = 40
        '
        'colHSummary
        '
        Me.colHSummary.HeaderText = "Summary"
        Me.colHSummary.Name = "colHSummary"
        Me.colHSummary.ReadOnly = True
        Me.colHSummary.Width = 200
        '
        'colHStart
        '
        Me.colHStart.HeaderText = "Start date"
        Me.colHStart.Name = "colHStart"
        Me.colHStart.ReadOnly = True
        Me.colHStart.Width = 150
        '
        'colHHours
        '
        Me.colHHours.HeaderText = "Hours"
        Me.colHHours.Name = "colHHours"
        Me.colHHours.ReadOnly = True
        Me.colHHours.Width = 50
        '
        'colHAssignedto
        '
        Me.colHAssignedto.HeaderText = "Assignedto"
        Me.colHAssignedto.Name = "colHAssignedto"
        Me.colHAssignedto.ReadOnly = True
        Me.colHAssignedto.Width = 200
        '
        'colHStatus
        '
        Me.colHStatus.HeaderText = "Status"
        Me.colHStatus.Name = "colHStatus"
        Me.colHStatus.ReadOnly = True
        '
        'TaskForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.butNew)
        Me.Controls.Add(Me.dgdItems)
        Me.Controls.Add(Me.blobFile)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.butSubmit)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.cboReleaseID)
        Me.Controls.Add(Me.lblHours)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.lblEMail)
        Me.Controls.Add(Me.lblAssignedTo)
        Me.Controls.Add(Me.lblLastUpdated)
        Me.Controls.Add(Me.lblCreatedOn)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.lblReleaseID)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtHors)
        Me.Controls.Add(Me.txtAssignedTo)
        Me.Controls.Add(Me.txtSummary)
        Me.Name = "TaskForm"
        Me.Size = New System.Drawing.Size(609, 574)
        CType(Me.dgdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents blobFile As Blobber
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents butSubmit As System.Windows.Forms.Button
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboReleaseID As System.Windows.Forms.ComboBox
    Friend WithEvents lblHours As System.Windows.Forms.Label
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents lblEMail As System.Windows.Forms.Label
    Friend WithEvents lblAssignedTo As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdated As System.Windows.Forms.Label
    Friend WithEvents lblCreatedOn As System.Windows.Forms.Label
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblSummary As System.Windows.Forms.Label
    Friend WithEvents lblReleaseID As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtHors As System.Windows.Forms.TextBox
    Friend WithEvents txtAssignedTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSummary As System.Windows.Forms.TextBox
    Friend WithEvents dgdItems As System.Windows.Forms.DataGridView
    Friend WithEvents butNew As System.Windows.Forms.Button
    Friend WithEvents colHSno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHSummary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHAssignedto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHStatus As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
