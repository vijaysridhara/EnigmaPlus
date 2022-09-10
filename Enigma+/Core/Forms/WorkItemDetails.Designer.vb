<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkItemDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkItemDetails))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.txtTask = New System.Windows.Forms.TextBox()
        Me.txtDefect = New System.Windows.Forms.TextBox()
        Me.txtIssue = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(699, 366)
        Me.WebBrowser1.TabIndex = 0
        '
        'txtTask
        '
        Me.txtTask.Location = New System.Drawing.Point(141, 35)
        Me.txtTask.Name = "txtTask"
        Me.txtTask.Size = New System.Drawing.Size(100, 20)
        Me.txtTask.TabIndex = 1
        Me.txtTask.Text = resources.GetString("txtTask.Text")
        Me.txtTask.Visible = False
        '
        'txtDefect
        '
        Me.txtDefect.Location = New System.Drawing.Point(281, 35)
        Me.txtDefect.Name = "txtDefect"
        Me.txtDefect.Size = New System.Drawing.Size(100, 20)
        Me.txtDefect.TabIndex = 1
        Me.txtDefect.Text = resources.GetString("txtDefect.Text")
        Me.txtDefect.Visible = False
        '
        'txtIssue
        '
        Me.txtIssue.Location = New System.Drawing.Point(401, 55)
        Me.txtIssue.Name = "txtIssue"
        Me.txtIssue.Size = New System.Drawing.Size(100, 20)
        Me.txtIssue.TabIndex = 1
        Me.txtIssue.Text = resources.GetString("txtIssue.Text")
        Me.txtIssue.Visible = False
        '
        'WorkItemDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 366)
        Me.Controls.Add(Me.txtIssue)
        Me.Controls.Add(Me.txtDefect)
        Me.Controls.Add(Me.txtTask)
        Me.Controls.Add(Me.WebBrowser1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "WorkItemDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WorkItemDetails"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents txtTask As System.Windows.Forms.TextBox
    Friend WithEvents txtDefect As System.Windows.Forms.TextBox
    Friend WithEvents txtIssue As System.Windows.Forms.TextBox
End Class
