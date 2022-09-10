<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LenDelimitedtoTab
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
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.butSelectCSV = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.butGen = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCSV = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtText
        '
        Me.txtText.Location = New System.Drawing.Point(106, 25)
        Me.txtText.Name = "txtText"
        Me.txtText.ReadOnly = True
        Me.txtText.Size = New System.Drawing.Size(479, 20)
        Me.txtText.TabIndex = 1
        '
        'butSelectCSV
        '
        Me.butSelectCSV.Location = New System.Drawing.Point(591, 49)
        Me.butSelectCSV.Name = "butSelectCSV"
        Me.butSelectCSV.Size = New System.Drawing.Size(45, 23)
        Me.butSelectCSV.TabIndex = 2
        Me.butSelectCSV.Text = "..."
        Me.butSelectCSV.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutput.Location = New System.Drawing.Point(15, 126)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(621, 119)
        Me.txtOutput.TabIndex = 11
        Me.txtOutput.WordWrap = False
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(12, 28)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(88, 13)
        Me.lblFile.TabIndex = 0
        Me.lblFile.Text = "Length delimit file"
        '
        'butGen
        '
        Me.butGen.Location = New System.Drawing.Point(480, 78)
        Me.butGen.Name = "butGen"
        Me.butGen.Size = New System.Drawing.Size(75, 23)
        Me.butGen.TabIndex = 7
        Me.butGen.Text = "&Generate"
        Me.butGen.UseVisualStyleBackColor = True
        '
        'butExit
        '
        Me.butExit.DialogResult =DialogResult.Cancel
        Me.butExit.Location = New System.Drawing.Point(561, 78)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(75, 23)
        Me.butExit.TabIndex = 8
        Me.butExit.Text = "E&xit"
        Me.butExit.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "&Messages"
        '
        'txtCSV
        '
        Me.txtCSV.Location = New System.Drawing.Point(106, 51)
        Me.txtCSV.Name = "txtCSV"
        Me.txtCSV.ReadOnly = True
        Me.txtCSV.Size = New System.Drawing.Size(479, 20)
        Me.txtCSV.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(591, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CSV &file"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Output &delimiter"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Tab", "Comma", "Semicolon", "Colon", "Chr(255)"})
        Me.ComboBox1.Location = New System.Drawing.Point(106, 88)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 12
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(245, 91)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Info
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(106, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(435, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "I would read headers,delimited by space(s) first and do the processing on the res" & _
            "t of the file"
        '
        'LenDelimitedtoTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butExit
        Me.ClientSize = New System.Drawing.Size(648, 257)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butGen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFile)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.butSelectCSV)
        Me.Controls.Add(Me.txtCSV)
        Me.Controls.Add(Me.txtText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "LenDelimitedtoTab"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Length Delimited to Character Delimited"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents butSelectCSV As System.Windows.Forms.Button
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents butGen As System.Windows.Forms.Button
    Friend WithEvents butExit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCSV As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
