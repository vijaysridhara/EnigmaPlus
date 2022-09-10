<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrequentTasks
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.colHRelID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHSummary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHFrequency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHSubFrequency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.butOK = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHRelID, Me.colHSummary, Me.colHFrequency, Me.colHSubFrequency})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(594, 277)
        Me.DataGridView1.TabIndex = 0
        '
        'colHRelID
        '
        Me.colHRelID.HeaderText = "Release"
        Me.colHRelID.Name = "colHRelID"
        Me.colHRelID.ReadOnly = True
        '
        'colHSummary
        '
        Me.colHSummary.HeaderText = "Summary"
        Me.colHSummary.Name = "colHSummary"
        Me.colHSummary.ReadOnly = True
        Me.colHSummary.Width = 250
        '
        'colHFrequency
        '
        Me.colHFrequency.HeaderText = "Frequency"
        Me.colHFrequency.Name = "colHFrequency"
        Me.colHFrequency.ReadOnly = True
        '
        'colHSubFrequency
        '
        Me.colHSubFrequency.HeaderText = "Details"
        Me.colHSubFrequency.Name = "colHSubFrequency"
        Me.colHSubFrequency.ReadOnly = True
        '
        'butOK
        '
        Me.butOK.DialogResult =DialogResult.Cancel
        Me.butOK.Location = New System.Drawing.Point(507, 283)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(75, 23)
        Me.butOK.TabIndex = 1
        Me.butOK.Text = "E&xit"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'FrequentTasks
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butOK
        Me.ClientSize = New System.Drawing.Size(594, 317)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrequentTasks"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrequentTasks"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents colHRelID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHSummary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHFrequency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHSubFrequency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents butOK As System.Windows.Forms.Button
End Class
