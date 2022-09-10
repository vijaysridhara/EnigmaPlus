<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Blobber
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.butSave = New System.Windows.Forms.Button
        Me.butUpload = New System.Windows.Forms.Button
        Me.butView = New System.Windows.Forms.Button
        Me.txtSize = New System.Windows.Forms.TextBox
        Me.txtData = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'butSave
        '
        Me.butSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.butSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSave.Location = New System.Drawing.Point(140, 0)
        Me.butSave.Name = "butSave"
        Me.butSave.Size = New System.Drawing.Size(20, 20)
        Me.butSave.TabIndex = 3
        Me.butSave.UseVisualStyleBackColor = True
        '
        'butUpload
        '
        Me.butUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.butUpload.Dock = System.Windows.Forms.DockStyle.Right
        Me.butUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butUpload.Location = New System.Drawing.Point(120, 0)
        Me.butUpload.Name = "butUpload"
        Me.butUpload.Size = New System.Drawing.Size(20, 20)
        Me.butUpload.TabIndex = 2
        Me.butUpload.UseVisualStyleBackColor = True
        '
        'butView
        '
        Me.butView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.butView.Dock = System.Windows.Forms.DockStyle.Right
        Me.butView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butView.Location = New System.Drawing.Point(160, 0)
        Me.butView.Name = "butView"
        Me.butView.Size = New System.Drawing.Size(20, 20)
        Me.butView.TabIndex = 4
        Me.butView.UseVisualStyleBackColor = True
        '
        'txtSize
        '
        Me.txtSize.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtSize.Location = New System.Drawing.Point(0, 0)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(73, 20)
        Me.txtSize.TabIndex = 0
        '
        'txtData
        '
        Me.txtData.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtData.Location = New System.Drawing.Point(73, 0)
        Me.txtData.Name = "txtData"
        Me.txtData.ReadOnly = True
        Me.txtData.Size = New System.Drawing.Size(47, 20)
        Me.txtData.TabIndex = 1
        '
        'Blobber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtData)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.butUpload)
        Me.Controls.Add(Me.butSave)
        Me.Controls.Add(Me.butView)
        Me.Name = "Blobber"
        Me.Size = New System.Drawing.Size(180, 20)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butSave As System.Windows.Forms.Button
    Friend WithEvents butUpload As System.Windows.Forms.Button
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents txtData As System.Windows.Forms.TextBox
    Friend WithEvents butView As Button

End Class
