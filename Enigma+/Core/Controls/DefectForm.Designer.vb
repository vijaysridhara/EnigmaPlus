Imports VijaySridhara
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DefectForm
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
        Me.cboReleaseID = New System.Windows.Forms.ComboBox()
        Me.lblEstimate = New System.Windows.Forms.Label()
        Me.lblRaisedon = New System.Windows.Forms.Label()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.lblEMail = New System.Windows.Forms.Label()
        Me.lblAssignedTo = New System.Windows.Forms.Label()
        Me.lblLastUpdated = New System.Windows.Forms.Label()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.lblReleaseID = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtEstimate = New System.Windows.Forms.TextBox()
        Me.txtAssignedTo = New System.Windows.Forms.TextBox()
        Me.txtSummary = New System.Windows.Forms.TextBox()
        Me.lblRaisedBy = New System.Windows.Forms.Label()
        Me.txtRaisedBy = New System.Windows.Forms.TextBox()
        Me.dgdItems = New System.Windows.Forms.DataGridView()
        Me.lblModule = New System.Windows.Forms.Label()
        Me.txtModule = New System.Windows.Forms.TextBox()
        Me.lblCreatedOn = New System.Windows.Forms.Label()
        Me.butNew = New System.Windows.Forms.Button()
        Me.blobFile = New Blobber()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHSummary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHRaisedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHRaisedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHAssignedTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butSubmit
        '
        Me.butSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSubmit.Location = New System.Drawing.Point(449, 403)
        Me.butSubmit.Name = "butSubmit"
        Me.butSubmit.Size = New System.Drawing.Size(95, 26)
        Me.butSubmit.TabIndex = 23
        Me.butSubmit.Text = "&Add defect"
        Me.butSubmit.UseVisualStyleBackColor = True
        '
        'dtpRaisedon
        '
        Me.dtpRaisedon.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtpRaisedon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRaisedon.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRaisedon.Location = New System.Drawing.Point(89, 244)
        Me.dtpRaisedon.Name = "dtpRaisedon"
        Me.dtpRaisedon.Size = New System.Drawing.Size(150, 22)
        Me.dtpRaisedon.TabIndex = 12
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"OPEN", "ASSIGNED", "INPROGRESS", "COMPLETED", "REJECTED"})
        Me.cboStatus.Location = New System.Drawing.Point(89, 380)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(121, 24)
        Me.cboStatus.TabIndex = 20
        '
        'cboReleaseID
        '
        Me.cboReleaseID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReleaseID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReleaseID.FormattingEnabled = True
        Me.cboReleaseID.Location = New System.Drawing.Point(85, 11)
        Me.cboReleaseID.Name = "cboReleaseID"
        Me.cboReleaseID.Size = New System.Drawing.Size(121, 24)
        Me.cboReleaseID.TabIndex = 1
        '
        'lblEstimate
        '
        Me.lblEstimate.AutoSize = True
        Me.lblEstimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstimate.Location = New System.Drawing.Point(7, 271)
        Me.lblEstimate.Name = "lblEstimate"
        Me.lblEstimate.Size = New System.Drawing.Size(60, 16)
        Me.lblEstimate.TabIndex = 15
        Me.lblEstimate.Text = "Est&imate"
        '
        'lblRaisedon
        '
        Me.lblRaisedon.AutoSize = True
        Me.lblRaisedon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaisedon.Location = New System.Drawing.Point(7, 246)
        Me.lblRaisedon.Name = "lblRaisedon"
        Me.lblRaisedon.Size = New System.Drawing.Size(70, 16)
        Me.lblRaisedon.TabIndex = 11
        Me.lblRaisedon.Text = "Raised &on"
        '
        'lblDetails
        '
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetails.Location = New System.Drawing.Point(7, 71)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(50, 16)
        Me.lblDetails.TabIndex = 5
        Me.lblDetails.Text = "Details"
        '
        'lblEMail
        '
        Me.lblEMail.AutoSize = True
        Me.lblEMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEMail.Location = New System.Drawing.Point(7, 357)
        Me.lblEMail.Name = "lblEMail"
        Me.lblEMail.Size = New System.Drawing.Size(42, 16)
        Me.lblEMail.TabIndex = 17
        Me.lblEMail.Text = "&Email"
        '
        'lblAssignedTo
        '
        Me.lblAssignedTo.AutoSize = True
        Me.lblAssignedTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssignedTo.Location = New System.Drawing.Point(245, 218)
        Me.lblAssignedTo.Name = "lblAssignedTo"
        Me.lblAssignedTo.Size = New System.Drawing.Size(79, 16)
        Me.lblAssignedTo.TabIndex = 9
        Me.lblAssignedTo.Text = "Assigned &to"
        '
        'lblLastUpdated
        '
        Me.lblLastUpdated.AutoSize = True
        Me.lblLastUpdated.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastUpdated.Location = New System.Drawing.Point(287, 443)
        Me.lblLastUpdated.Name = "lblLastUpdated"
        Me.lblLastUpdated.Size = New System.Drawing.Size(28, 16)
        Me.lblLastUpdated.TabIndex = 12
        Me.lblLastUpdated.Text = "UU"
        Me.lblLastUpdated.Visible = False
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFile.Location = New System.Drawing.Point(7, 416)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(30, 16)
        Me.lblFile.TabIndex = 21
        Me.lblFile.Text = "&File"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(7, 383)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(45, 16)
        Me.lblStatus.TabIndex = 19
        Me.lblStatus.Text = "&Status"
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSummary.Location = New System.Drawing.Point(7, 45)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(65, 16)
        Me.lblSummary.TabIndex = 3
        Me.lblSummary.Text = "&Summary"
        '
        'lblReleaseID
        '
        Me.lblReleaseID.AutoSize = True
        Me.lblReleaseID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReleaseID.Location = New System.Drawing.Point(7, 14)
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
        Me.txtDescription.Location = New System.Drawing.Point(89, 68)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(455, 144)
        Me.txtDescription.TabIndex = 6
        '
        'txtEmail
        '
        Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(89, 354)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(455, 22)
        Me.txtEmail.TabIndex = 18
        '
        'txtEstimate
        '
        Me.txtEstimate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEstimate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstimate.Location = New System.Drawing.Point(89, 271)
        Me.txtEstimate.Multiline = True
        Me.txtEstimate.Name = "txtEstimate"
        Me.txtEstimate.Size = New System.Drawing.Size(455, 77)
        Me.txtEstimate.TabIndex = 16
        '
        'txtAssignedTo
        '
        Me.txtAssignedTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAssignedTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssignedTo.Location = New System.Drawing.Point(330, 218)
        Me.txtAssignedTo.Name = "txtAssignedTo"
        Me.txtAssignedTo.Size = New System.Drawing.Size(214, 22)
        Me.txtAssignedTo.TabIndex = 10
        '
        'txtSummary
        '
        Me.txtSummary.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSummary.Location = New System.Drawing.Point(89, 42)
        Me.txtSummary.Name = "txtSummary"
        Me.txtSummary.Size = New System.Drawing.Size(455, 22)
        Me.txtSummary.TabIndex = 4
        '
        'lblRaisedBy
        '
        Me.lblRaisedBy.AutoSize = True
        Me.lblRaisedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRaisedBy.Location = New System.Drawing.Point(245, 245)
        Me.lblRaisedBy.Name = "lblRaisedBy"
        Me.lblRaisedBy.Size = New System.Drawing.Size(70, 16)
        Me.lblRaisedBy.TabIndex = 13
        Me.lblRaisedBy.Text = "Raised &by"
        '
        'txtRaisedBy
        '
        Me.txtRaisedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRaisedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRaisedBy.Location = New System.Drawing.Point(330, 246)
        Me.txtRaisedBy.Name = "txtRaisedBy"
        Me.txtRaisedBy.Size = New System.Drawing.Size(214, 22)
        Me.txtRaisedBy.TabIndex = 14
        '
        'dgdItems
        '
        Me.dgdItems.AllowUserToAddRows = False
        Me.dgdItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colHSummary, Me.colHRaisedOn, Me.colHRaisedBy, Me.colHAssignedTo, Me.colHStatus})
        Me.dgdItems.Location = New System.Drawing.Point(3, 462)
        Me.dgdItems.Name = "dgdItems"
        Me.dgdItems.ReadOnly = True
        Me.dgdItems.RowHeadersVisible = False
        Me.dgdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdItems.Size = New System.Drawing.Size(556, 163)
        Me.dgdItems.TabIndex = 24
        '
        'lblModule
        '
        Me.lblModule.AutoSize = True
        Me.lblModule.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModule.Location = New System.Drawing.Point(7, 215)
        Me.lblModule.Name = "lblModule"
        Me.lblModule.Size = New System.Drawing.Size(53, 16)
        Me.lblModule.TabIndex = 7
        Me.lblModule.Text = "M&odule"
        '
        'txtModule
        '
        Me.txtModule.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModule.Location = New System.Drawing.Point(89, 217)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(150, 22)
        Me.txtModule.TabIndex = 8
        '
        'lblCreatedOn
        '
        Me.lblCreatedOn.AutoSize = True
        Me.lblCreatedOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedOn.Location = New System.Drawing.Point(7, 443)
        Me.lblCreatedOn.Name = "lblCreatedOn"
        Me.lblCreatedOn.Size = New System.Drawing.Size(26, 16)
        Me.lblCreatedOn.TabIndex = 25
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
        Me.butNew.Location = New System.Drawing.Point(453, 6)
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
        Me.blobFile.Location = New System.Drawing.Point(89, 412)
        Me.blobFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.blobFile.Name = "blobFile"
        Me.blobFile.Size = New System.Drawing.Size(255, 20)
        Me.blobFile.TabIndex = 22
        '
        'colID
        '
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 40
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
        'colHAssignedTo
        '
        Me.colHAssignedTo.HeaderText = "Assigned to"
        Me.colHAssignedTo.Name = "colHAssignedTo"
        Me.colHAssignedTo.ReadOnly = True
        Me.colHAssignedTo.Width = 150
        '
        'colHStatus
        '
        Me.colHStatus.HeaderText = "Status"
        Me.colHStatus.Name = "colHStatus"
        Me.colHStatus.ReadOnly = True
        '
        'DefectForm
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
        Me.Controls.Add(Me.cboReleaseID)
        Me.Controls.Add(Me.lblEstimate)
        Me.Controls.Add(Me.lblRaisedBy)
        Me.Controls.Add(Me.lblRaisedon)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.lblEMail)
        Me.Controls.Add(Me.lblModule)
        Me.Controls.Add(Me.lblAssignedTo)
        Me.Controls.Add(Me.lblLastUpdated)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.lblReleaseID)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtRaisedBy)
        Me.Controls.Add(Me.txtEstimate)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.txtAssignedTo)
        Me.Controls.Add(Me.txtSummary)
        Me.Name = "DefectForm"
        Me.Size = New System.Drawing.Size(562, 627)
        CType(Me.dgdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents blobFile As Blobber
    Friend WithEvents butSubmit As System.Windows.Forms.Button
    Friend WithEvents dtpRaisedon As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboReleaseID As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstimate As System.Windows.Forms.Label
    Friend WithEvents lblRaisedon As System.Windows.Forms.Label
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents lblEMail As System.Windows.Forms.Label
    Friend WithEvents lblAssignedTo As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdated As System.Windows.Forms.Label
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblSummary As System.Windows.Forms.Label
    Friend WithEvents lblReleaseID As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtEstimate As System.Windows.Forms.TextBox
    Friend WithEvents txtAssignedTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSummary As System.Windows.Forms.TextBox
    Friend WithEvents lblRaisedBy As System.Windows.Forms.Label
    Friend WithEvents txtRaisedBy As System.Windows.Forms.TextBox
    Friend WithEvents dgdItems As System.Windows.Forms.DataGridView
    Friend WithEvents butNew As System.Windows.Forms.Button
    Friend WithEvents lblModule As System.Windows.Forms.Label
    Friend WithEvents txtModule As System.Windows.Forms.TextBox
    Friend WithEvents lblCreatedOn As System.Windows.Forms.Label
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHSummary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHRaisedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHRaisedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHAssignedTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHStatus As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
