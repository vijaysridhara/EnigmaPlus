<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CSVtoInsert
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
        Me.txtCSV = New System.Windows.Forms.TextBox()
        Me.butSelectCSV = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkCSV = New System.Windows.Forms.CheckedListBox()
        Me.butGen = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTable = New System.Windows.Forms.TextBox()
        Me.butExit = New System.Windows.Forms.Button()
        Me.txtErrors = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCSV
        '
        Me.txtCSV.Location = New System.Drawing.Point(65, 25)
        Me.txtCSV.Name = "txtCSV"
        Me.txtCSV.ReadOnly = True
        Me.txtCSV.Size = New System.Drawing.Size(650, 20)
        Me.txtCSV.TabIndex = 1
        '
        'butSelectCSV
        '
        Me.butSelectCSV.Location = New System.Drawing.Point(721, 22)
        Me.butSelectCSV.Name = "butSelectCSV"
        Me.butSelectCSV.Size = New System.Drawing.Size(45, 23)
        Me.butSelectCSV.TabIndex = 2
        Me.butSelectCSV.Text = "..."
        Me.butSelectCSV.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutput.Location = New System.Drawing.Point(12, 226)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(754, 219)
        Me.txtOutput.TabIndex = 11
        Me.txtOutput.WordWrap = False
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(12, 28)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(44, 13)
        Me.lblFile.TabIndex = 0
        Me.lblFile.Text = "CSV &file"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Check &numeric columns"
        '
        'chkCSV
        '
        Me.chkCSV.Enabled = False
        Me.chkCSV.FormattingEnabled = True
        Me.chkCSV.Location = New System.Drawing.Point(15, 64)
        Me.chkCSV.Name = "chkCSV"
        Me.chkCSV.Size = New System.Drawing.Size(298, 154)
        Me.chkCSV.TabIndex = 4
        '
        'butGen
        '
        Me.butGen.Enabled = False
        Me.butGen.Location = New System.Drawing.Point(610, 62)
        Me.butGen.Name = "butGen"
        Me.butGen.Size = New System.Drawing.Size(75, 23)
        Me.butGen.TabIndex = 7
        Me.butGen.Text = "&Generate"
        Me.butGen.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(319, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "&Table name"
        '
        'txtTable
        '
        Me.txtTable.Enabled = False
        Me.txtTable.Location = New System.Drawing.Point(322, 64)
        Me.txtTable.Name = "txtTable"
        Me.txtTable.Size = New System.Drawing.Size(282, 20)
        Me.txtTable.TabIndex = 6
        '
        'butExit
        '
        Me.butExit.DialogResult =DialogResult.Cancel
        Me.butExit.Location = New System.Drawing.Point(691, 62)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(75, 23)
        Me.butExit.TabIndex = 8
        Me.butExit.Text = "E&xit"
        Me.butExit.UseVisualStyleBackColor = True
        '
        'txtErrors
        '
        Me.txtErrors.Enabled = False
        Me.txtErrors.Location = New System.Drawing.Point(322, 103)
        Me.txtErrors.Multiline = True
        Me.txtErrors.Name = "txtErrors"
        Me.txtErrors.ReadOnly = True
        Me.txtErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtErrors.Size = New System.Drawing.Size(444, 115)
        Me.txtErrors.TabIndex = 10
        Me.txtErrors.WordWrap = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(319, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "&Ignored lines"
        '
        'CSVtoInsert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butExit
        Me.ClientSize = New System.Drawing.Size(778, 457)
        Me.Controls.Add(Me.txtErrors)
        Me.Controls.Add(Me.txtTable)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butGen)
        Me.Controls.Add(Me.chkCSV)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.butSelectCSV)
        Me.Controls.Add(Me.txtCSV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CSVtoInsert"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CSVtoInsert"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCSV As System.Windows.Forms.TextBox
    Friend WithEvents butSelectCSV As System.Windows.Forms.Button
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkCSV As System.Windows.Forms.CheckedListBox
    Friend WithEvents butGen As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTable As System.Windows.Forms.TextBox
    Friend WithEvents butExit As System.Windows.Forms.Button
    Friend WithEvents txtErrors As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
