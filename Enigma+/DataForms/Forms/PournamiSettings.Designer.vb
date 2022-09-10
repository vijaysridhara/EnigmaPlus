<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PournamiSettings
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
        Me.butFont = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'butFont
        '
        Me.butFont.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butFont.Location = New System.Drawing.Point(24, 12)
        Me.butFont.Name = "butFont"
        Me.butFont.Size = New System.Drawing.Size(83, 26)
        Me.butFont.TabIndex = 0
        Me.butFont.Text = "&Font"
        Me.butFont.UseVisualStyleBackColor = True
        '
        'PournamiSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 307)
        Me.Controls.Add(Me.butFont)
        Me.Name = "EnigmaPlusSettings"
        Me.Text = "Enigma+ Settings"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents butFont As System.Windows.Forms.Button
End Class
