<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataShow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataShow))
        Me.txtMessages = New System.Windows.Forms.TextBox()
        Me.DataForm1 = New DataForm()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'txtMessages
        '
        Me.txtMessages.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtMessages.Location = New System.Drawing.Point(0, 554)
        Me.txtMessages.Multiline = True
        Me.txtMessages.Name = "txtMessages"
        Me.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessages.Size = New System.Drawing.Size(805, 35)
        Me.txtMessages.TabIndex = 2
        '
        'DataForm1
        '
        Me.DataForm1.BackColor = System.Drawing.SystemColors.Control
        Me.DataForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataForm1.Location = New System.Drawing.Point(0, 0)
        Me.DataForm1.Name = "DataForm1"
        Me.DataForm1.Size = New System.Drawing.Size(805, 554)
        Me.DataForm1.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'DataShow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 589)
        Me.Controls.Add(Me.DataForm1)
        Me.Controls.Add(Me.txtMessages)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DataShow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DataShow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataForm1 As DataForm
    Friend WithEvents txtMessages As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
