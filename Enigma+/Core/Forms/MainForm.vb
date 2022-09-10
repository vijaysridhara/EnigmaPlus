
'***********************************************************************
'Copyright 2005-2022 Vijay Sridhara

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at

'http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
'WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'***********************************************************************

Imports VijaySridhara.Libraries
Imports VitalLogic.Libraries

Public Class MainForm
    Private WithEvents sc As Buntilla 'This name is weird, but started projext with Scintilla, later changed to FCTB
    Private WithEvents WI As New WorkItems
    Private currentFile As Buntilla
    Private Sub sc_FileModified(ByVal sender As Object)
        If CType(sender, Buntilla).IsDirty And CType(CType(sender, Buntilla).Parent, TabPage).ImageIndex <> 0 Then
            CType(CType(sender, Buntilla).Parent, TabPage).ImageIndex = 0
            ' CType(CType(sender, Buntilla).Parent, TabPage).Text = CType(sender, Buntilla).JustFileName
        ElseIf CType(CType(sender, Buntilla).Parent, TabPage).ImageIndex <> 1 And CType(sender, Buntilla).IsDirty = False Then
            CType(CType(sender, Buntilla).Parent, TabPage).ImageIndex = 1
            ' CType(CType(sender, Buntilla).Parent, TabPage).Text = CType(sender, Buntilla).JustFileName
        End If

    End Sub
    Private Sub sc_PlaceChanged(ByVal loc As Point)
        tlstpColNo.Text = loc.X
        tlstpLineNo.Text = loc.Y
    End Sub
    Public ReadOnly Property CurrentEditControl() As Buntilla
        Get
            Return currentFile
        End Get
    End Property
    Private Sub sc_FileSaved(ByVal sender As Object)

        CType(CType(sender, Buntilla).Parent, TabPage).Text = CType(sender, Buntilla).JustFileName


    End Sub
    Private Sub sc_FileNameChanged(ByVal sender As Object)

        If CType(sender, Buntilla).IsDirty Then
            CType(CType(sender, Buntilla).Parent, TabPage).ImageIndex = 0
            CType(CType(sender, Buntilla).Parent, TabPage).Text = CType(sender, Buntilla).JustFileName
        Else
            CType(CType(sender, Buntilla).Parent, TabPage).ImageIndex = 1
            CType(CType(sender, Buntilla).Parent, TabPage).Text = CType(sender, Buntilla).JustFileName
        End If

    End Sub

    Private Sub SetEvents()

    End Sub
    Private Sub SetSettingS()

    End Sub
    'Private Sub sc_CloseClicked(ByVal sender As Object)
    '    Try
    '        currentFile = sender
    '        If currentFile Is Nothing Then Exit Sub
    '        If currentFile.IsDirty Then
    '            Dim res As MsgBoxResult = MsgBox("Do you want to save the file", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
    '            If res = MsgBoxResult.Yes Then
    '                If SaveCurrentFile() Then
    '                    tabMain.Controls.RemoveAt(tabMain.SelectedIndex)
    '                End If
    '            ElseIf res = MsgBoxResult.Cancel Then
    '                Exit Sub
    '            ElseIf res = MsgBoxResult.No Then
    '                tabMain.Controls.RemoveAt(tabMain.SelectedIndex)
    '            End If
    '        Else
    '            tabMain.Controls.RemoveAt(tabMain.SelectedIndex)
    '        End If
    '        If tabMain.TabPages.Count = 0 Then
    '            EnableDisableMenus(False)
    '        End If
    '    Catch ex As Exception
    '        DE(ex)
    '    End Try
    'End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If tabMain.TabPages.Count > 0 Then
            Dim _fls() As FileItem
            Dim i As Integer = 0
            For Each tb As TabPage In tabMain.TabPages
                If CType(tb.Controls(0), Buntilla).IsDirty Then
                    ReDim Preserve _fls(i)
                    Dim fi As New FileItem
                    fi.Path = CType(tb.Controls(0), Buntilla).FilePath
                    fi.Name = CType(tb.Controls(0), Buntilla).JustFileName
                    _fls(i) = fi
                    i += 1
                End If
            Next
            If _fls Is Nothing Then Exit Sub
            Dim ms As New MultiSave(_fls)
            Dim res As DialogResult = ms.ShowDialog
            WriteStatusLable("Saving files...")
            If res = DialogResult.Cancel Then e.Cancel = True : Exit Sub
            If res = DialogResult.OK Then
                _fls = ms.SelectedFiles
            Else
                tabMain.TabPages.Clear()
                _fls = Nothing
                Exit Sub
            End If

            If _fls Is Nothing Then Exit Sub
            For Each fi As FileItem In _fls
                If fi Is Nothing Then Continue For
                For Each tb As TabPage In tabMain.TabPages
                    If CType(tb.Controls(0), Buntilla).FilePath = fi.Path Then
                        If fi.Path = "" Then
                            tabMain.SelectedTab = tb
                            If SaveCurrentFile() = False Then
                                e.Cancel = True : Exit Sub
                            Else
                                Exit For
                            End If
                        Else
                            CType(tb.Controls(0), Buntilla).SaveFile(CType(tb.Controls(0), Buntilla).FilePath)
                        End If
                        Exit For
                    End If

                Next
            Next
        End If
        My.Settings.FileExplorerDir = FileListBox1.LastFolderSelected
        My.Settings.Save()
        WriteStatusLable()
    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Control And e.Shift Then
                If e.KeyCode = Keys.F5 Then
                    CloseAllToolStripMenuItem_Click(Nothing, Nothing)
                End If
            ElseIf e.Control = True Then
                If e.KeyCode = Keys.N Then
                    CreateNeFile(Nothing, Nothing)
                ElseIf e.KeyCode = Keys.O Then

                    OpenFile()
                ElseIf e.KeyCode = Keys.F4 Then
                    CloseToolStripMenuItem_Click(Nothing, Nothing)
                ElseIf e.KeyCode = Keys.S Then
                    SaveToolStripMenuItem_Click(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GetLangs()

            AvailableExtensions = "Text files|*.txt|Data files|*.dat|Batch files|*.bat|CPP files|*.cpp|C files|*.c|Php files|*.php,*.php3|HTML files|*.htm,*.html|XML files|*.xml|ASPNET files|*.aspx|CSharp files|*.cs|VB files|*.vb|SQL Files|*.sql|Java files|*.java|Javascript files|*.js|All files|*.*"
            If Not IO.Directory.Exists(UserDocuments) Then
                MkDir(UserDocuments)
            End If
            If Not IO.Directory.Exists(UserTempData) Then
                MkDir(UserTempData)
            End If
            If Not IO.Directory.Exists(UserTempData & "\temp") Then
                MkDir(UserTempData & "\temp")
            End If
            If Not IO.Directory.Exists(UserDocuments & "\Forms") Then
                MkDir(UserDocuments & "\Forms")
            End If
            If Not IO.Directory.Exists(UserDocuments & "\Projects") Then
                MkDir(UserDocuments & "\Projects")
            End If
            If Not IO.Directory.Exists(UserDocuments & "\Impex") Then
                MkDir(UserDocuments & "\Impex")
            End If
            If IO.File.Exists(UserWorkItems) = False Then
                Dim fst As IO.BinaryWriter = New IO.BinaryWriter(New IO.FileStream(UserWorkItems, IO.FileMode.CreateNew))
                fst.Write(My.Resources.IsTaBu)
                fst.Dispose()

            End If
            If My.Settings.CurrentProjDir = "None" Then
                My.Settings.CurrentProjDir = UserDocuments & "\Projects"
            End If
            If My.Settings.OpenFileDir = "None" Then
                My.Settings.OpenFileDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            End If
            If My.Settings.FileExplorerDir = "None" Then
                My.Settings.FileExplorerDir = UserDocuments
            End If
            If My.Settings.FormsDir = "None" Then
                My.Settings.FormsDir = UserDocuments & "\Forms"
            End If
            If My.Settings.ImpexDir = "None" Then
                My.Settings.ImpexDir = UserDocuments & "\Impex"
            End If
            If My.Settings.TempDir = "None" Then
                My.Settings.TempDir = UserTempData
            End If
            Dim le3 As New ToolStripSeparator

            NewToolStripMenuItem.DropDownItems.Add(le3)
            For Each kv As Language In LanguagesSupported.Values
                Dim le, le1 As New ToolStripMenuItem
                Dim le4 As New ToolStripMenuItem
                le.Text = kv.Name
                le.Tag = kv.Name
                le1.Text = kv.Name + " file"
                le4.Tag = kv.Name
                le4.Text = kv.Name + " file"
                le1.Tag = kv.Name
                LanguageToolStripMenuItem.DropDownItems.Add(le)
                NewToolStripMenuItem.DropDownItems.Add(le1)
                NewToolstripDropDownButton.DropDownItems.Add(le4)
                AddHandler le.Click, AddressOf language_clicked
                AddHandler le1.Click, AddressOf CreateNeFile
                AddHandler le4.Click, AddressOf CreateNeFile
            Next
            EnableDisableMenus(False)

            ToolStrip1.ImageList = ImageList1
            NewToolstripDropDownButton.ImageIndex = 0
            OpenToolStripDropDownButton.ImageIndex = 1
            SaveToolStripDropDownButton.ImageIndex = 2
            PrintPreviewBut.ImageIndex = 3
            PrintBut.ImageIndex = 4
            CutBut.ImageIndex = 5
            CopyBut.ImageIndex = 6
            PasteBut.ImageIndex = 7
            UndoBut.ImageIndex = 8
            RedoBut.ImageIndex = 9
            FindBut.ImageIndex = 10
            ReplaceBut.ImageIndex = 11
            NewProjBut.ImageIndex = 12
            OpenProjBut.ImageIndex = 13
            CloseProjBut.ImageIndex = 14
            butSwitchExplorer.ImageIndex = 15
            SettingsBut.ImageIndex = 16

            FileBrowserToolStripMenuItem.Checked = My.Settings.ShowFileExplorer

            OutputWindowToolStripMenuItem.Checked = My.Settings.ShowOutputWindow
            Toolbox1.Visible = My.Settings.ShowFileExplorer
            Toolbox3.Visible = My.Settings.ShowOutputWindow
            If Toolbox1.Visible Then
                Toolbox1.SendToBack()

            End If
            If My.Settings.ProjExplorerRight Then
                Toolbox1.Dock = DockStyle.Left

                Splitter1.Dock = DockStyle.Left
                Toolbox1.SendToBack()
            Else
                Toolbox1.Dock = DockStyle.Right
                Splitter1.Dock = DockStyle.Right
                Toolbox1.SendToBack()
            End If
            If FileQueue.Count > 0 Then
                For Each fl As String In FileQueue
                    OpenFile(fl)
                Next
                FileQueue.Clear()
            End If
            LoadForms()
            FileListBox1.SetCurrentFolder(My.Settings.FileExplorerDir)
            If IO.File.Exists(My.Settings.DefaultProjectFile) Then
                OpenProjecTFile(My.Settings.DefaultProjectFile)
            End If
            WI.Visible = False
            WI.Dock = DockStyle.Fill
            Me.Controls.Add(WI)
        Catch ex As Exception
            comFun.DE(ex)
        End Try

    End Sub
    Private Sub language_clicked(ByVal sender As Object, ByVal e As EventArgs)
        Try
            currentFile = tabMain.ActiveControl
            Dim lang As String = CType(sender, ToolStripMenuItem).Tag.ToString
            currentFile.ClearStylesBuffer()
            currentFile.Range.ClearStyle()
            currentFile.Range.ClearFoldingMarkers()

            If LanguagesSupported.ContainsKey(lang) Then
                Select Case lang
                    Case "VB"
                        currentFile.Language = FastColoredTextBoxNS.Language.VB
                    Case "JS"
                        currentFile.Language = FastColoredTextBoxNS.Language.JS
                    Case "CSharp"
                        currentFile.Language = FastColoredTextBoxNS.Language.CSharp
                    Case "SQL"
                        currentFile.Language = FastColoredTextBoxNS.Language.SQL
                    Case "PHP"
                        currentFile.Language = FastColoredTextBoxNS.Language.PHP
                    Case "HTML"
                        currentFile.Language = FastColoredTextBoxNS.Language.HTML
                    Case Else
                        currentFile.Language = FastColoredTextBoxNS.Language.Custom
                        currentFile.DescriptionFile = LanguagesSupported(lang).FilePAth
                End Select
                currentFile.OnTextChanged()
                currentFile.Tag = CType(sender, ToolStripMenuItem).Tag.ToString
                SetLanguageinStatusBar()
            End If

        Catch ex As Exception
            DE(ex)
        End Try


    End Sub
    Public Sub CreateNeFile(ByVal sender As System.Object, ByVal e As System.EventArgs)

        WriteStatusLable("Creating new file...")
        sc = New Buntilla
        Dim tb As New TabPage

        tb.Controls.Add(sc)
        sc.Dock = DockStyle.Fill
        'tabMain.TabPages.Add(tb)

        tb.Text = sc.JustFileName
        'tabMain.SelectedTab = tb
        currentFile = sc
        If sender Is Nothing Then
            sc.Tag = "Text"

        Else

            Dim lang As String = CType(sender, ToolStripMenuItem).Tag.ToString
            If LanguagesSupported.ContainsKey(lang) Then
                If LanguagesSupported(lang).IsInbuilt Then
                    Select Case lang
                        Case "VB"
                            sc.Language = FastColoredTextBoxNS.Language.VB
                        Case "JS"
                            sc.Language = FastColoredTextBoxNS.Language.JS
                        Case "CSharp"
                            sc.Language = FastColoredTextBoxNS.Language.CSharp
                        Case "SQL"
                            sc.Language = FastColoredTextBoxNS.Language.SQL
                        Case "PHP"
                            sc.Language = FastColoredTextBoxNS.Language.PHP
                        Case "HTML"
                            sc.Language = FastColoredTextBoxNS.Language.HTML
                    End Select
                Else
                    currentFile.Range.ClearFoldingMarkers()
                    currentFile.Range.ClearStyle()
                    currentFile.Language = FastColoredTextBoxNS.Language.Custom
                    currentFile.DescriptionFile = LanguagesSupported(lang).FilePAth

                End If

            End If
            sc.Tag = CType(sender, ToolStripMenuItem).Tag.ToString

        End If

        AddHandler sc.FileModified, AddressOf sc_FileModified
        AddHandler sc.FileSaved, AddressOf sc_FileSaved
        AddHandler sc.FileNameChanged, AddressOf sc_FileNameChanged
        AddHandler sc.MessageSent, AddressOf sc_MessageSent
        AddHandler sc.PlaceChanged, AddressOf sc_PlaceChanged
        tabMain.TabPages.Add(tb)
        'AddHandler sc.CloseKeyClicked, AddressOf sc_CloseClicked
        ' AddHandler sc.SaveClicked, AddressOf sc_SavEClicked
        tabMain.SelectedTab = tb
        tb.ImageIndex = 1
        tb.Controls(0).Focus()
        WriteStatusLable()
    End Sub
    'Private Sub sc_SaveClicked(ByVal sender As Object)
    '    currentFile = sender
    '    SaveCurrentFile()
    'End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFile()
    End Sub
    Private Sub OpenFile(Optional ByVal fname As String = "")
        If String.IsNullOrEmpty(fname) Then
            Dim ofd As New OpenFileDialog
            With ofd
                .Filter = AvailableExtensions
                If .ShowDialog = vbOK Then
                    fname = .FileName
                    My.Settings.OpenFileDir = IO.Path.GetDirectoryName(fname)
                Else : Exit Sub
                End If
            End With
        End If
        If IO.Path.GetExtension(fname).ToLower = ".pf1" Then
            OpenDF(fname)
            Exit Sub
        End If
        For Each fd As TabPage In tabMain.TabPages
            If CType(fd.Controls(0), Buntilla).FilePath = fname Then
                tabMain.SelectedTab = fd
                Exit Sub
            End If
        Next

        If IO.File.Exists(fname) = False Then
            DE(New IO.FileNotFoundException)
            Exit Sub
        End If
        WriteStatusLable("Opening file....")
        Dim cf As New ClosingMsg
        cf.Label1.Text = "Opening the file, please wait..."
        cf.Text = "Opening file..."
        cf.Show(Me)
        cf.Label1.Refresh()
        sc = New Buntilla
        Dim tb As New TabPage
        tb.Controls.Add(sc)
        sc.Dock = DockStyle.Fill

        AddHandler sc.FileModified, AddressOf sc_FileModified
        AddHandler sc.FileSaved, AddressOf sc_FileSaved
        AddHandler sc.FileNameChanged, AddressOf sc_FileNameChanged
        AddHandler sc.MessageSent, AddressOf sc_MessageSent
        AddHandler sc.PlaceChanged, AddressOf sc_PlaceChanged
        'AddHandler sc.CloseKeyClicked, AddressOf sc_CloseClicked
        ' AddHandler sc.SaveClicked, AddressOf sc_SaveClicked
        sc.LoadFile(fname)
        tabMain.SelectedTab = tb
        tabMain.TabPages.Add(tb)
        tb.Controls(0).Focus()
        WriteStatusLable()
        cf.Close()
    End Sub
    Private Sub OpenDF(ByVal fname As String)
        Try
            For Each fm As Form In Application.OpenForms
                If TypeOf fm Is DataShow Then
                    If CType(fm, DataShow).FileUsed = fname Then
                        fm.Activate()
                        Exit Sub
                    End If
                End If
            Next
            Dim ds As New DataShow(fname)
            ds.LoadContents()
            If ds.DataForm1.UserDefined = False Then
                ds.Close()
            End If

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        currentFile = tabMain.ActiveControl
        If currentFile Is Nothing Then Exit Sub
        If currentFile.IsDirty Then
            Dim res As MsgBoxResult = MsgBox("Do you want to save the file", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
            If res = MsgBoxResult.Yes Then

                If SaveCurrentFile() Then
                    tabMain.Controls.RemoveAt(tabMain.SelectedIndex)
                End If
            ElseIf res = MsgBoxResult.Cancel Then
                Exit Sub
            ElseIf res = MsgBoxResult.No Then
                tabMain.Controls.RemoveAt(tabMain.SelectedIndex)
            End If
        Else
            tabMain.Controls.RemoveAt(tabMain.SelectedIndex)
        End If
        If tabMain.TabPages.Count = 0 Then
            EnableDisableMenus(False)
        End If
    End Sub

    Private Function SaveCurrentFile(Optional ByVal saveas As Boolean = False) As Boolean
        Try
            currentFile = tabMain.ActiveControl
            If currentFile Is Nothing Then Return False
            If currentFile.FilePath Is Nothing Or saveas = True Then
                Dim langu As Language
                Dim fld As New SaveFileDialog
                If LanguagesSupported.ContainsKey(currentFile.Tag) Then
                    langu = LanguagesSupported(currentFile.Tag)
                Else
                    langu = New Language(currentFile.Tag)
                    langu.Extensions = currentFile.Tag & " files(*." & currentFile.Tag & ")|*." & currentFile.Tag
                End If
                Dim finfil As String = langu.Extensions

                If finfil.Length > 0 Then
                    fld.Filter = finfil & "|All files|*.*"
                Else
                    fld.Filter = "Text files|*.txt|All files|*.*"
                End If
                fld.FileName = currentFile.JustFileName
                If Not currentFile.FilePath Is Nothing Then
                    fld.InitialDirectory = IO.Path.GetDirectoryName(currentFile.FilePath)
                End If
                If fld.ShowDialog = vbOK Then
                    WriteStatusLable("Saving file...")
                    currentFile.SaveFile(fld.FileName)
                    WriteStatusLable()
                    Return True
                Else
                    WriteStatusLable()
                    Return False
                End If
            Else
                WriteStatusLable("Saving file...")
                currentFile.SaveFile(currentFile.FilePath)
                WriteStatusLable()
                Return True
            End If
        Catch ex As Exception
            DE(ex)
            Return False
        End Try


    End Function

    Private Sub EnableDisableMenus(ByVal enable As Boolean)
        For Each mnu As ToolStripMenuItem In LanguageToolStripMenuItem.DropDownItems
            mnu.Enabled = enable
        Next
        If Not enable Then
            tlstpColNo.Text = 0
            tlstpLineNo.Text = 0

        End If
        CloseToolStripMenuItem.Enabled = enable
        CloseAllToolStripMenuItem.Enabled = enable
        SaveToolStripMenuItem.Enabled = enable
        SaveAsToolStripMenuItem.Enabled = enable
        PrintToolStripMenuItem.Enabled = enable
        PrintPreviewToolStripMenuItem.Enabled = enable
        CutToolStripMenuItem.Enabled = enable
        CopyToolStripMenuItem.Enabled = enable
        PasteToolStripMenuItem.Enabled = enable
        FindInFilesToolStripMenuItem.Enabled = enable
        ReplaceToolStripMenuItem.Enabled = enable
        SelectAllToolStripMenuItem.Enabled = enable
        PrintPreviewBut.Enabled = enable
        PrintBut.Enabled = enable
        CutBut.Enabled = enable
        CopyBut.Enabled = enable
        PasteBut.Enabled = enable
        UndoBut.Enabled = enable
        RedoBut.Enabled = enable
        FindBut.Enabled = enable
        FindToolStripMenuItem.Enabled = enable
        ReplaceBut.Enabled = enable
        SaveToolStripDropDownButton.Enabled = enable
        tabMain.Visible = enable
        LanguageToolStripMenuItem.Enabled = enable
    End Sub






    Private Sub Print(ByVal preview As Boolean)
        currentFile = tabMain.ActiveControl

        If preview Then
            Dim ds As New FastColoredTextBoxNS.PrintDialogSettings
            ds.ShowPrintPreviewDialog = True
            ds.ShowPageSetupDialog = True
            currentFile.Print(ds)
        Else
            WriteStatusLable("Printing file...")
            currentFile.Print()
            WriteStatusLable()
        End If

    End Sub


    Private Sub Cut()
        currentFile = tabMain.ActiveControl
        currentFile.Cut()
    End Sub
    Private Sub Copy()
        currentFile = tabMain.ActiveControl
        currentFile.Copy()
    End Sub
    Private Sub PAste()
        currentFile = tabMain.ActiveControl
        currentFile.Paste()

    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        currentFile = tabMain.ActiveControl
        currentFile.SelectAll()
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        currentFile = tabMain.ActiveControl
        currentFile.ShowFindDialog()
    End Sub






    Private Sub FindBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindBut.Click
        currentFile = tabMain.ActiveControl
        currentFile.ShowFindDialog()



    End Sub

    Private Sub ReplaceBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceBut.Click
        currentFile = tabMain.ActiveControl
        currentFile.ShowReplaceDialog()

    End Sub

    Private Sub sc_MessageSent(ByVal msg As String, ByVal iserror As Boolean)
        WriteSTatus(msg)
    End Sub

    Private Sub NewProjBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProjBut.Click
        CreateNewProject()
    End Sub
    Private Sub CreateNewProject()
        Try



            Dim sfd As New SaveFileDialog, fname As String
            With sfd

                .InitialDirectory = My.Settings.FileExplorerDir
                .Filter = "Pournami Project files(*.ppf)|*.ppf"
                .FileName = "New project"
                If .ShowDialog = DialogResult.OK Then
                    fname = .FileName
                Else : Exit Sub
                End If
            End With
            Dim dirname As String = IO.Path.GetDirectoryName(fname)
            Dim projname As String = IO.Path.GetFileNameWithoutExtension(fname)
            Dim projdir As String
            If dirname.Substring(dirname.Length - 1, 1) = "\" Then
                projdir = dirname & projname
            Else
                projdir = dirname & "\" & projname

            End If
            If IO.Directory.Exists(projdir) = False Then
                MkDir(projdir)
            End If

            WriteStatusLable("Project file creating...")
            My.Settings.FileExplorerDir = dirname
            WriteSTatus("Project created, and a folder created. All your files go in that folder")
            Dim sw As New IO.StreamWriter(fname)
            sw.WriteLine("# Pournami project Created on " & Format(Date.Now, "yyyy-MM-dd HH:mm:ss"))
            Dim commands() As String, HASCOMMANDS As Boolean
            If MsgBox("Do you want to set run configurations for this project?", vbYesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                Dim cfg As New ConfigurationParms
                With cfg
                    If .ShowDialog = DialogResult.OK Then
                        If Not .Commands Is Nothing Then
                            commands = .Commands
                            HASCOMMANDS = True
                        End If
                    End If
                End With
                If HASCOMMANDS Then
                    For Each LI As String In commands
                        If LI Is Nothing Then Continue For
                        sw.WriteLine("COMMAND:" & LI)
                    Next
                End If
            End If

            sw.Close()
            sw.Dispose()
            WriteStatusLable()
            OpenProjecTFile(fname)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub exec_click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim cmds() As String = sender.tag.split(Chr(255))
            If cmds Is Nothing Then Exit Sub

            If cmds(2) = "Y" Then
                Dim SW As IO.StreamWriter
                Dim SR As IO.StreamReader
                Dim cmd As New Process
                With cmd
                    With .StartInfo
                        .FileName = "cmd"
                        .UseShellExecute = False
                        .RedirectStandardInput = True
                        .RedirectStandardOutput = True
                        .CreateNoWindow = False

                    End With
                    .Start()
                    SR = .StandardOutput
                    SW = .StandardInput
                    SW.WriteLine(cmds(0) & " " & GetCommand(cmds(1)))

                    SW.Dispose()
                    cmd.WaitForExit(1000)
                    cmd.Dispose()
                    Do Until SR.EndOfStream
                        WriteSTatus(SR.ReadLine)
                    Loop
                    SR.Dispose()

                End With
            Else
                Process.Start(cmds(0), GetCommand(cmds(1)))
            End If

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Function GetCommand(ByVal cline As String) As String
        Dim projdir As String = ""
        Dim filename As String = ""
        Dim fnamewe As String = ""
        Dim fnamewoe As String = ""

        projdir = IO.Path.GetDirectoryName(TreeView2.Nodes(0).Tag) & "\" & IO.Path.GetFileNameWithoutExtension(TreeView2.Nodes(0).Tag)
        If TreeView2.SelectedNode Is Nothing Then

        ElseIf TreeView2.SelectedNode.ImageIndex < 0 Or TreeView2.SelectedNode.ImageIndex > 2 Then
            filename = TreeView2.SelectedNode.Tag
            fnamewe = IO.Path.GetFileName(filename)
            fnamewoe = IO.Path.GetFileNameWithoutExtension(filename)
        End If
        cline = cline.Replace("$PROJDIR", projdir)
        cline = cline.Replace("$FILE_FULL_PATH", filename)
        cline = cline.Replace("$FILE_NAME_WE", fnamewe)
        cline = cline.Replace("$FILE_NAME_WOE", fnamewoe)
        If cline.Contains("$INPUT") Then
            Dim inp As String = InputBox("Provide input for string", "Input")
            cline = cline.Replace("$INPUT", inp)
        End If
        Return cline

    End Function
    Private Sub ClearExecConfig()
        ExecuteToolStripMenuItem.Enabled = False
        ExecuteToolStripMenuItem1.Enabled = False
        ExecuteToolStripMenuItem.DropDownItems.Clear()
        ExecuteToolStripMenuItem1.DropDownItems.Clear()
    End Sub

    Private Sub OpenProjecTFile(ByVal fname As String, Optional ByVal force As Boolean = False)
        Try
            If force = False Then
                If CloseCurrentProject() = False Then Exit Sub
            Else
                TreeView2.Nodes.Clear()
            End If
            ClearExecConfig()
            WriteStatusLable("Opening project file...")
            Dim rootNode As TreeNode = New TreeNode(IO.Path.GetFileNameWithoutExtension(fname))
            rootNode.ImageIndex = 0
            rootNode.SelectedImageIndex = 0
            rootNode.Tag = fname
            TreeView2.Nodes.Add(rootNode)
            Dim sr As New IO.StreamReader(fname)
            Dim str() As String = sr.ReadToEnd.Split(vbLf)
            Dim img As Image
            Dim td As TreeNode
            For Each ln As String In str
                ln = ln.Trim
                If ln.Length = 0 Then Continue For
                If ln.Substring(0, 1) = "#" Then Continue For
                If ln.Length < 8 Then Continue For 'just for the sake of having good length not less than 5,6
                If ln.Substring(0, 8) = "COMMAND:" Then
                    Dim cmd1 As String = ln.Substring(8)
                    Dim cmd() As String = cmd1.Split(Chr(254))
                    Dim cmdname As String = cmd(0)
                    Dim drpitem, drpitm2 As New ToolStripMenuItem(cmdname)
                    drpitem.Tag = cmd(1)
                    drpitm2.Tag = cmd(1)
                    AddHandler drpitem.Click, AddressOf exec_click
                    AddHandler drpitm2.Click, AddressOf exec_click
                    ExecuteToolStripMenuItem.DropDownItems.Add(drpitem)
                    ExecuteToolStripMenuItem1.DropDownItems.Add(drpitm2)
                End If
            Next
            sr.Close()
            sr.Dispose()
            If ExecuteToolStripMenuItem.DropDownItems.Count > 0 Then
                ExecuteToolStripMenuItem.Enabled = True
                ExecuteToolStripMenuItem1.Enabled = True
            End If
            CloseProjBut.Enabled = True

            Dim projDirname As String = IO.Path.GetDirectoryName(fname) & "\" & IO.Path.GetFileNameWithoutExtension(fname)
            My.Settings.CurrentProjDir = projDirname
            LoadProjFiles(projDirname, rootNode)
            TreeView2.Nodes(0).Expand()
            WriteStatusLable()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Public Sub LoadProjFiles(ByVal projdir As String, ByVal addtonode As TreeNode)

        Try
            WriteStatusLable("Loading project files...")
            addtonode.Nodes.Clear()
            Dim dirs() As String = IO.Directory.GetDirectories(projdir)
            For Each dr In dirs
                Dim tnd As New TreeNode(dr.Substring(InStrRev(dr, "\")), 1, 1)
                tnd.ImageIndex = 1
                tnd.SelectedImageIndex = 1
                tnd.Tag = dr
                tnd.Nodes.Add("dummy", "")
                addtonode.Nodes.Add(tnd)
            Next
            Dim fls() As String = IO.Directory.GetFiles(projdir)
            For Each fl As String In fls
                Dim tnd1 As New TreeNode(fl.Substring(InStrRev(fl, "\")))
                tnd1.ImageKey = Geticonkey(fl)
                tnd1.SelectedImageKey = tnd1.ImageKey
                tnd1.Tag = fl
                addtonode.Nodes.Add(tnd1)
            Next
            WriteStatusLable()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Function Geticonkey(ByVal flname As String) As String
        Dim ext = IO.Path.GetExtension(flname).ToLower
        If ext = "" Then ext = ".dat"
        If ImageList2.Images.ContainsKey(ext) Then
            Return ext
        Else
            Dim img As Image
            img = Drawing.Icon.ExtractAssociatedIcon(flname).ToBitmap
            ImageList2.Images.Add(ext, img)
            Return ext
        End If
    End Function

    Private Sub WriteSTatus(ByVal msg As String)
        txtMessages.Text += vbCrLf & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") + ": " + msg
        txtMessages.SelectionStart = txtMessages.TextLength
        txtMessages.ScrollToCaret()
    End Sub
    Private Sub DeleteFileFromDisk()
        Try
            If MsgBox("Do you want to delete the file from the disk?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            WriteStatusLable("Deleting the file...")
            Dim sn As TreeNode = TreeView2.SelectedNode
            For Each fn As TabPage In tabMain.TabPages
                If ContainedinProjecT(CType(fn.Controls(0), Buntilla).Tag, sn.Parent) Then
                    tabMain.TabPages.Remove(fn)
                End If
            Next
            IO.File.Delete(sn.Tag)
            TreeView2.SelectedNode.Remove()
            WriteStatusLable()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub NewFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewFileToolStripMenuItem.Click
        AddNewFileToProject()

    End Sub
    Private Sub AddNewFileToProject()
        Try
            Dim SN As TreeNode = TreeView2.SelectedNode
            Dim DIRNAME As String
            If SN.ImageIndex = 0 Then
                DIRNAME = IO.Path.GetDirectoryName(SN.Tag) & IO.Path.GetFileNameWithoutExtension(SN.Tag)
            ElseIf SN.ImageIndex <= 2 Then
                DIRNAME = SN.Tag
            Else
                Exit Sub
            End If
            Dim sfd As New Filename(AvailableExtensions)
            With sfd
                If .SHOWdIALOG() = DialogResult.OK Then
                    WriteStatusLable("Adding new file...")
                    Dim sw As New IO.StreamWriter(DIRNAME & "\" & .Filename, False)

                    sw.Close()
                    sw.Dispose()
                    Dim TN As New TreeNode(IO.Path.GetFileName(DIRNAME & "\" & .Filename))
                    TN.ImageKey = Geticonkey(DIRNAME & "\" & .Filename)
                    TN.SelectedImageKey = TN.ImageKey
                    TN.Tag = DIRNAME & "\" & .Filename
                    SN.Nodes.Add(TN)
                End If
            End With
            WriteStatusLable()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub


    Private Sub ProjectToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProjectToolStripMenuItem.DropDownOpening
        If TreeView2.Nodes.Count = 0 Then
            CloseProjBut.Enabled = False
            CloseProjectToolStripMenuItem.Enabled = False
            ExecuteToolStripMenuItem.Enabled = False
            DeleteFolderToolStripMenuItem.Enabled = False
            DeleteFileFromDiskToolStripMenuItem.Enabled = False
        Else
            CloseProjBut.Enabled = True
            CloseProjectToolStripMenuItem.Enabled = True
        End If
        If TreeView2.SelectedNode Is Nothing Then
            AddNewFileToolStripMenuItem.Enabled = False
            ExecuteToolStripMenuItem.Enabled = False
            DeleteFolderToolStripMenuItem.Enabled = False
            DeleteFileFromDiskToolStripMenuItem.Enabled = False
            DeleteFolderToolStripMenuItem.Enabled = False
        ElseIf TreeView2.SelectedNode.ImageIndex > 2 Or TreeView2.SelectedNode.ImageIndex < 0 Then
            AddNewFileToolStripMenuItem.Enabled = False

            DeleteFolderToolStripMenuItem.Enabled = False
            DeleteFileFromDiskToolStripMenuItem.Enabled = True
            If ExecuteToolStripMenuItem.HasDropDownItems Then
                ExecuteToolStripMenuItem.Enabled = True
            Else
                ExecuteToolStripMenuItem.Enabled = False
            End If
        Else
            AddNewFileToolStripMenuItem.Enabled = True

            DeleteFileFromDiskToolStripMenuItem.Enabled = False
            DeleteFolderToolStripMenuItem.Enabled = True
        End If
    End Sub



    Private Sub NewToolstripDropDownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolstripDropDownButton.Click

    End Sub

    Private Sub ctxProj_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxProj.Opening
        If TreeView2.SelectedNode Is Nothing Then
            ctxProjAddFile.Enabled = False
            ctxProjAddfolder.Enabled = False
            ExecuteToolStripMenuItem1.Enabled = False
            ctxDeleteFile.Enabled = False
            ctxDeletFolder.Enabled = False
            PropertiesToolStripMenuItem.Enabled = False
            ReloadProjectToolStripMenuItem.Enabled = False
            ReloadFolderToolStripMenuItem.Enabled = False
            SetdefaultToolStripMenuItem.Enabled = False

        ElseIf TreeView2.SelectedNode.ImageIndex > 2 Or TreeView2.SelectedNode.ImageIndex < 0 Then
            ctxProjAddFile.Enabled = False
            ctxProjAddfolder.Enabled = False
            ExecuteToolStripMenuItem1.Enabled = True
            ctxDeleteFile.Enabled = True
            ctxDeletFolder.Enabled = False
            PropertiesToolStripMenuItem.Enabled = False
            ReloadProjectToolStripMenuItem.Enabled = False
            ReloadFolderToolStripMenuItem.Enabled = False
            SetdefaultToolStripMenuItem.Enabled = False

        ElseIf TreeView2.SelectedNode.ImageIndex = 0 Or TreeView2.SelectedNode.ImageIndex = 1 Or TreeView2.SelectedNode.ImageIndex = 2 Then
            ctxProjAddFile.Enabled = True
            ctxProjAddfolder.Enabled = True
            ExecuteToolStripMenuItem1.Enabled = True
            ctxDeleteFile.Enabled = False
            ctxDeletFolder.Enabled = True


            If TreeView2.SelectedNode.ImageIndex = 0 Then
                PropertiesToolStripMenuItem.Enabled = True
                ReloadProjectToolStripMenuItem.Enabled = True
                ReloadFolderToolStripMenuItem.Enabled = False
                SetdefaultToolStripMenuItem.Enabled = True
            Else
                PropertiesToolStripMenuItem.Enabled = False
                ReloadProjectToolStripMenuItem.Enabled = False
                ReloadFolderToolStripMenuItem.Enabled = True
                SetdefaultToolStripMenuItem.Enabled = False
            End If
        End If
    End Sub


    Private Sub AddFoldertoProject()
        Try
            Dim SN As TreeNode = TreeView2.SelectedNode
            Dim DIRNAME As String
            If SN.ImageIndex = 0 Then
                DIRNAME = IO.Path.GetDirectoryName(SN.Tag) & "\" & IO.Path.GetFileNameWithoutExtension(SN.Tag)
            ElseIf SN.ImageIndex <= 2 Then
                DIRNAME = SN.Tag
            Else
                Exit Sub
            End If
            Dim nf As New NewFolder2
            If nf.SHOWdIALOG = DialogResult.OK Then
                WriteStatusLable("Adding folder...")
                MkDir(DIRNAME & "\" & nf.Foldername)
                Dim tn As New TreeNode(nf.Foldername)
                tn.ImageIndex = 1
                tn.Tag = DIRNAME & "\" & nf.Foldername
                tn.SelectedImageIndex = 1
                tn.Nodes.Add("dummy", "")
                SN.Nodes.Add(tn)
            End If
            WriteStatusLable()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub


    Private Sub OpenProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjectToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Pournami Project files |*.ppf"
        With ofd
            If .ShowDialog() = DialogResult.OK Then
                OpenProjecTFile(.FileName)
            End If
        End With
    End Sub

    Private Sub CloseProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseProjectToolStripMenuItem.Click
        CloseCurrentProject()
    End Sub
    Private Function CloseCurrentProject() As Boolean
        Try
            If TreeView2.Nodes.Count = 0 Then Return True
            Dim _fls() As FileItem, i As Integer = 0
            WriteStatusLable("Closing project...")
            For Each tb As TabPage In tabMain.TabPages
                tabMain.SelectedTab = tb
                If CType(tb.Controls(0), Buntilla).IsDirty Then
                    If ContainedinProjecT(CType(tb.Controls(0), Buntilla).FilePath, TreeView2.Nodes(0)) Then
                        Dim flitm As New FileItem
                        flitm.Name = tb.Text
                        flitm.Path = CType(tb.Controls(0), Buntilla).FilePath
                        ReDim Preserve _fls(i)
                        _fls(i) = flitm
                        i += 1
                    Else : Continue For

                    End If
                Else
                    If ContainedinProjecT(CType(tb.Controls(0), Buntilla).FilePath, TreeView2.Nodes(0)) Then
                        tabMain.TabPages.Remove(tb)
                        If tabMain.TabPages.Count = 0 Then EnableDisableMenus(False)
                    Else : Continue For
                    End If

                End If
            Next
            If Not _fls Is Nothing Then
                Dim ms As New MultiSave(_fls)
                Dim res As DialogResult = ms.ShowDialog
                If res = DialogResult.OK Then
                    _fls = ms.SelectedFiles
                ElseIf res = DialogResult.No Then
                    For Each ft As TabPage In tabMain.TabPages
                        For Each ti As FileItem In _fls
                            If CType(ft.Controls(0), Buntilla).FilePath = ti.Path Then
                                tabMain.TabPages.Remove(ft)
                                Exit For
                            End If
                        Next
                    Next
                    TreeView2.Nodes.Clear()
                    If tabMain.TabPages.Count = 0 Then EnableDisableMenus(False)
                    WriteStatusLable()
                    Return True
                Else
                    WriteStatusLable()
                    Return False
                End If
            End If
            If _fls Is Nothing Then
                TreeView2.Nodes.Clear()
            Else
                For Each ft As TabPage In tabMain.TabPages
                    For Each ti As FileItem In _fls
                        If CType(ft.Controls(0), Buntilla).FilePath = ti.Path Then
                            CType(ft.Controls(0), Buntilla).SaveFile(CType(ft.Controls(0), Buntilla).FilePath)
                            tabMain.TabPages.Remove(ft)
                            Exit For
                        End If
                    Next
                Next
                If tabMain.TabPages.Count = 0 Then EnableDisableMenus(False)
                TreeView2.Nodes.Clear()
            End If
            CloseProjBut.Enabled = False
            WriteStatusLable()
            Return True
        Catch ex As Exception
            DE(ex)
        End Try
    End Function

    Private Function ContainedinProjecT(ByVal filename As String, ByVal tnode As TreeNode) As Boolean
        Try
            For Each nd As TreeNode In tnode.Nodes
                If nd.ImageIndex > 2 Or nd.ImageIndex < 0 Then
                    If nd.Tag = filename Then Return True
                Else
                    Dim rt As Boolean = ContainedinProjecT(filename, nd)
                    If rt Then Return True
                End If
            Next
        Catch ex As Exception
            DE(ex)
            Return False
        End Try
    End Function



    Private Sub OpenProjBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenProjBut.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Pournami Project files |*.ppf"
        With ofd
            If .ShowDialog() = DialogResult.OK Then
                OpenProjecTFile(.FileName)

            End If
        End With
    End Sub

    Private Sub TreeView2_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView2.BeforeExpand
        If e.Node.ImageIndex = 1 Then
            e.Node.ImageIndex = 2
            LoadProjFiles(e.Node.Tag, e.Node)
        End If
    End Sub

    Private Sub DeleteSelectedFolder()
        Try
            Dim res As MsgBoxResult = MsgBox("Do you want to delete the folder and its contents from disk?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
            If res = MsgBoxResult.No Then Exit Sub
            Dim sn As TreeNode = TreeView2.SelectedNode
            WriteStatusLable("Deleting folder...")
            For Each fn As TabPage In tabMain.TabPages

                If ContainedinProjecT(CType(fn.Controls(0), Buntilla).Tag, sn) Then
                    tabMain.TabPages.Remove(fn)
                End If

            Next
            IO.Directory.Delete(sn.Tag)
            TreeView2.SelectedNode.Remove()
            WriteStatusLable()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub AddExistingFileToProjecT()
        Try
            Dim SN As TreeNode = TreeView2.SelectedNode
            Dim DIRNAME As String
            If SN.ImageIndex = 0 Then
                DIRNAME = IO.Path.GetDirectoryName(SN.Tag) & IO.Path.GetFileNameWithoutExtension(SN.Tag)
            ElseIf SN.ImageIndex <= 2 Then
                DIRNAME = SN.Tag
            Else
                Exit Sub
            End If
            Dim ofd As New OpenFileDialog

            With ofd
                .InitialDirectory = DIRNAME
                .Filter = AvailableExtensions
                If .ShowDialog() = DialogResult.OK Then
                    WriteStatusLable("Add existing file...")
                    IO.File.Copy(.FileName, DIRNAME & "\" & IO.Path.GetFileName(.FileName))
                    Dim TN As New TreeNode(IO.Path.GetFileName(DIRNAME & "\" & .FileName))
                    TN.ImageKey = Geticonkey(.FileName)
                    TN.SelectedImageKey = TN.ImageKey
                    TN.Tag = DIRNAME & "\" & IO.Path.GetFileName(.FileName)
                    SN.Nodes.Add(TN)
                End If
            End With
            WriteStatusLable()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub CloseProjBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseProjBut.Click
        CloseCurrentProject()
    End Sub
    Private Sub ctxProjAddExisting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxProjAddExisting.Click
        AddExistingFileToProjecT()
    End Sub
    Private Sub ctxProjAddNewFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxProjAddNewFile.Click
        AddNewFileToProject()
    End Sub

    Private Sub ExistingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExistingToolStripMenuItem.Click
        AddExistingFileToProjecT()
    End Sub
    Private Sub FolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FolderToolStripMenuItem.Click
        AddFoldertoProject()
    End Sub

    Private Sub DeleteFileFromDiskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteFileFromDiskToolStripMenuItem.Click
        DeleteFileFromDisk()
    End Sub

    Private Sub NewProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewProjectToolStripMenuItem.Click
        CreateNewProject()
    End Sub
    Private Sub ctxProjAddfolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxProjAddfolder.Click
        AddFoldertoProject()
    End Sub
    Private Sub tabMain_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles tabMain.ControlAdded
        tabMain.Show()
        EnableDisableMenus(True)
        tabMain_SelectedIndexChanged(Nothing, Nothing)
    End Sub
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveCurrentFile()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveCurrentFile(True)
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        Print(True)
    End Sub
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click

        Print(False)
    End Sub

    Private Sub OpenToolStripDropDownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripDropDownButton.Click
        OpenFile()
    End Sub

    Private Sub SaveToolStripDropDownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripDropDownButton.Click
        SaveCurrentFile()
    End Sub

    Private Sub PrintPreviewBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewBut.Click
        Print(True)
    End Sub

    Private Sub PrintBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBut.Click
        Print(False)
    End Sub

    Private Sub CutBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutBut.Click

        Cut()

    End Sub

    Private Sub CopyBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyBut.Click
        Copy()
    End Sub

    Private Sub PasteBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteBut.Click
        PAste()

    End Sub

    Private Sub ctxDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxDeleteFile.Click
        DeleteFileFromDisk()
    End Sub

    Private Sub ctxDeletFolder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ctxDeletFolder.Click
        DeleteSelectedFolder()
    End Sub

    Private Sub DeleteFolderToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteFolderToolStripMenuItem.Click
        DeleteSelectedFolder()
    End Sub

    Private Sub TreeView2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView2.MouseDoubleClick

    End Sub


    Private Sub TreeView2_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView2.NodeMouseDoubleClick
        Try
            If e.Node.ImageIndex < 0 Or e.Node.ImageIndex > 2 Then

                OpenFile(e.Node.Tag)
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub


    Private Sub tabMain_ControlRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles tabMain.ControlRemoved

        If tabMain.TabPages.Count = 0 Then
            EnableDisableMenus(False)
            tabMain.Hide()
        End If
        tabMain_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        If tabMain.TabPages.Count > 0 Then
            Dim _fls() As FileItem
            Dim i As Integer = 0
            WriteStatusLable("Closing all files...")
            For Each tb As TabPage In tabMain.TabPages
                If CType(tb.Controls(0), Buntilla).IsDirty Then
                    ReDim Preserve _fls(i)
                    Dim fi As New FileItem
                    fi.Path = CType(tb.Controls(0), Buntilla).FilePath
                    fi.Name = CType(tb.Controls(0), Buntilla).JustFileName
                    _fls(i) = fi
                    i += 1
                End If
            Next
            If _fls Is Nothing Then
                For Each tb As TabPage In tabMain.TabPages
                    tabMain.TabPages.Remove(tb)
                Next
                tabMain.Hide()
                Exit Sub
            End If
            Dim ms As New MultiSave(_fls)
            Dim ds As DialogResult = ms.ShowDialog
            If ds = DialogResult.Cancel Then Exit Sub
            If ds = DialogResult.No Then
                _fls = Nothing
                tabMain.TabPages.Clear()
                EnableDisableMenus(True)
            Else
                _fls = ms.SelectedFiles
            End If

            If _fls Is Nothing Then Exit Sub
            For Each fi As FileItem In _fls
                If fi Is Nothing Then Continue For
                For Each tb As TabPage In tabMain.TabPages
                    If CType(tb.Controls(0), Buntilla).FilePath = fi.Path Then
                        If fi.Path = "" Then
                            tabMain.SelectedTab = tb
                            If SaveCurrentFile() = False Then
                                GoTo innerexit
                            Else
                                tabMain.TabPages.Remove(tb)
                                Exit For
                            End If
                        Else
                            CType(tb.Controls(0), Buntilla).SaveFile(CType(tb.Controls(0), Buntilla).FilePath)
                            tabMain.TabPages.Remove(tb)
                        End If
                        Exit For
                    End If

                Next
innerexit:
            Next
        End If
        If tabMain.TabPages.Count = 0 Then
            EnableDisableMenus(False)

        End If
        WriteStatusLable()
    End Sub



    Private Sub FileListBox1_FileDeleteClicked(ByVal fname As String) Handles FileListBox1.FileDeleteClicked
        Try
            For Each tb As TabPage In tabMain.TabPages
                If CType(tb.Controls(0), Buntilla).FilePath.ToLower = fname.ToLower Then
                    tabMain.TabPages.Remove(tb)
                    Exit Sub
                End If
            Next
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub FileListBox1_FileOpenClicked(ByVal fname As String) Handles FileListBox1.FileOpenClicked
        Try
            Dim ext As String = IO.Path.GetExtension(fname)
            If Unwantedfiles.ContainsKey(ext) Then
                If MsgBox("This file cannot be opened in the editor. Do you want to open it outside?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
                Process.Start(fname)
                Exit Sub
            End If
            For Each tb As TabPage In tabMain.TabPages
                If CType(tb.Controls(0), Buntilla).FilePath Is Nothing Then Continue For
                If CType(tb.Controls(0), Buntilla).FilePath.ToLower = fname.ToLower Then
                    tabMain.SelectedTab = tb
                    Exit Sub
                End If
            Next
            OpenFile(fname)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub FileListBox1_FolderDeleteClicked(ByVal foldname As String) Handles FileListBox1.FolderDeleteClicked
        Try
            For Each tb As TabPage In tabMain.TabPages
                If CType(tb.Controls(0), Buntilla).FilePath.Contains(foldname.ToLower) Then
                    tabMain.TabPages.Remove(tb)
                End If
            Next
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub


    Private Sub PropertiesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertiesToolStripMenuItem.Click
        Try
            Dim commands() As String, hascommands As Boolean
            Dim cfg As New ConfigurationParms(TreeView2.SelectedNode.Tag)


            With cfg
                If .ShowDialog = DialogResult.OK Then
                    If Not .Commands Is Nothing Then
                        commands = .Commands
                        hascommands = True
                    End If
                Else
                    Exit Sub
                End If
            End With
            Dim sw As New IO.StreamWriter(TreeView2.SelectedNode.Tag, False)
            sw.WriteLine("# Pournami project modified on " & Format(Date.Now, "yyyy-MM-dd HH:mm:ss"))
            ClearExecConfig()
            If hascommands Then
                For Each LI As String In commands
                    If LI Is Nothing Then Continue For
                    sw.WriteLine("COMMAND:" & LI)
                    Dim cmd1 As String = LI
                    Dim cmd() As String = cmd1.Split(Chr(254))
                    Dim cmdname As String = cmd(0)
                    Dim drpitem, drpitm2 As New ToolStripMenuItem(cmdname)
                    drpitem.Tag = cmd(1)
                    drpitm2.Tag = cmd(1)
                    AddHandler drpitem.Click, AddressOf exec_click
                    AddHandler drpitm2.Click, AddressOf exec_click
                    ExecuteToolStripMenuItem.DropDownItems.Add(drpitem)
                    ExecuteToolStripMenuItem1.DropDownItems.Add(drpitm2)
                Next
            End If
            sw.Close()
            sw.Dispose()
            If ExecuteToolStripMenuItem.DropDownItems.Count > 0 Then
                ExecuteToolStripMenuItem.Enabled = True
                ExecuteToolStripMenuItem1.Enabled = True
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub





    Private Sub FileBrowserToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileBrowserToolStripMenuItem.CheckedChanged
        If FileBrowserToolStripMenuItem.Checked Then
            My.Settings.ShowFileExplorer = True
            Toolbox1.Show()
            Toolbox1.SendToBack()
        Else
            My.Settings.ShowFileExplorer = False
            Toolbox1.Hide()
        End If
        My.Settings.Save()
    End Sub


    Private Sub Undo()
        currentFile = tabMain.ActiveControl
        currentFile.Undo()
    End Sub
    Private Sub Redo()
        currentFile = tabMain.ActiveControl
        currentFile.Redo()
    End Sub
    Private Sub UndoBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoBut.Click
        Undo()
    End Sub

    Private Sub RedoBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoBut.Click
        Redo()
    End Sub


    Private Sub butSwitchExplorer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSwitchExplorer.Click

        Toolbox1.Hide()
        If My.Settings.ProjExplorerRight Then
            My.Settings.ProjExplorerRight = False
        Else
            My.Settings.ProjExplorerRight = True
        End If
        If My.Settings.ProjExplorerRight Then

            Toolbox1.Dock = DockStyle.Left
            FileBrowserToolStripMenuItem.Checked = True
            Splitter1.Dock = DockStyle.Left
            Toolbox1.SendToBack()


        Else

            Toolbox1.Dock = DockStyle.Right
            Splitter1.Dock = DockStyle.Right
            FileBrowserToolStripMenuItem.Checked = True
            Toolbox1.SendToBack()

            My.Settings.ProjExplorerRight = False
        End If
        Toolbox1.Show()

    End Sub

    Private Sub DE(ByVal ex As Exception)
        tlstpErrorlabel.Text = ex.Message
    End Sub
    Private Sub WriteStatusLable(Optional ByVal msg As String = "Ready")
        tlstpErrorlabel.Text = msg
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub TreeView2_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView2.AfterSelect

    End Sub

    Private Sub TreeView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView2.KeyDown
        If TreeView2.SelectedNode Is Nothing Then Exit Sub
        If (TreeView2.SelectedNode.ImageIndex < 0 Or TreeView2.SelectedNode.ImageIndex > 2) And e.KeyCode = Keys.Enter Then
            OpenFile(TreeView2.SelectedNode.Tag)
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim ab As New AboutBox1
        ab.ShowDialog()
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        MsgBox("Will you help me in writing one?", MsgBoxStyle.Exclamation Or MsgBoxStyle.Question)

    End Sub

    Private Sub ctxAddnewfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAddnewfile.Click
        Try
            WriteStatusLable("Adding new file...")
            sc = New Buntilla
            Dim tb As New TabPage

            tb.Controls.Add(sc)
            sc.Dock = DockStyle.Fill
            'tabMain.TabPages.Add(tb)
            tabMain.TabPages.Add(tb)
            tb.Text = sc.JustFileName
            'tabMain.SelectedTab = tb
            currentFile = sc

            sc.Language = FastColoredTextBoxNS.Language.Custom
            sc.Tag = "Custom"
            AddHandler sc.FileModified, AddressOf sc_FileModified
            AddHandler sc.FileSaved, AddressOf sc_FileSaved
            AddHandler sc.FileNameChanged, AddressOf sc_FileNameChanged
            AddHandler sc.MessageSent, AddressOf sc_MessageSent
            AddHandler sc.PlaceChanged, AddressOf sc_PlaceChanged
            '  AddHandler sc.CloseKeyClicked, AddressOf sc_CloseClicked
            WriteStatusLable()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxCloseTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxCloseTab.Click
        Try
            CloseToolStripMenuItem_Click(sender, e)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub tabMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tabMain.MouseUp
        Try
            If e.Button = MouseButtons.Right Then
                ActivateClickedTab(e.Location)
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub ActivateClickedTab(ByVal clickpoint As Point)
        If tabMain.TabCount = 0 Then Exit Sub
        For i As Integer = 0 To tabMain.TabPages.Count - 1
            If tabMain.GetTabRect(i).Contains(clickpoint) Then
                tabMain.SelectedIndex = i
            End If
        Next
        ctxTab.Show(tabMain.Location + clickpoint + New Point(0, ToolStrip1.Height + MenuStrip1.Height + MenuStrip1.Top))
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        PAste()
    End Sub

    Private Sub ReplaceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReplaceToolStripMenuItem.Click
        currentFile = tabMain.ActiveControl
        currentFile.ShowFindDialog()
    End Sub

    Private Sub ctxCloseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxCloseAll.Click
        CloseAllToolStripMenuItem_Click(sender, e)
    End Sub


    Private Sub TreeView2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView2.MouseDown
        Try
            Dim tv As TreeViewHitTestInfo
            tv = TreeView2.HitTest(e.Location)
            If tv.Node Is Nothing Then Exit Sub
            TreeView2.SelectedNode = tv.Node
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub OutputWindowToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OutputWindowToolStripMenuItem.CheckedChanged
        If OutputWindowToolStripMenuItem.Checked Then
            Toolbox3.Show()
            My.Settings.ShowOutputWindow = True
        Else
            My.Settings.ShowOutputWindow = False
            Toolbox3.Hide()
        End If
        My.Settings.Save()
    End Sub

    Private Sub ReloadProjectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadProjectToolStripMenuItem.Click
        Try
            OpenProjecTFile(TreeView2.Nodes(0).Tag, True)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ReloadFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadFolderToolStripMenuItem.Click
        Try
            LoadProjFiles(TreeView2.SelectedNode.Tag, TreeView2.SelectedNode)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub


    Private Sub ctxTab_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxTab.Opening
        If IO.File.Exists(tabMain.ActiveControl.Filepath) Then
            If IO.Path.GetExtension(tabMain.ActiveControl.Filepath) = ".pfdf" Then
                CompilePFDToolStripMenuItem.Enabled = True
            Else
                CompilePFDToolStripMenuItem.Enabled = False
            End If
        Else
            CompilePFDToolStripMenuItem.Enabled = False

        End If
    End Sub
    Private WithEvents compdef As New VijaySridhara.Libraries.PForms.Initiator
    Private Sub CompilePFDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompilePFDToolStripMenuItem.Click
        Try
            With compdef
                If CType(tabMain.ActiveControl, Buntilla).IsDirty Or CType(tabMain.ActiveControl, Buntilla).FilePath Is Nothing Then
                    SaveCurrentFile()
                    If IO.Path.GetExtension(CType(tabMain.ActiveControl, Buntilla).FilePath) <> ".pfdf" Then
                        MsgBox("The file has to be saved as Pournami form Definition file (*.pfdf)", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                End If
                If .ParseContent(CType(tabMain.ActiveControl, Buntilla).FilePath) Then
                    Dim ds As New DataShow(.FormPath)
                    ds.LoadContents()
                    If ds.DataForm1.UserDefined = False Then
                        ds.Close()

                    End If

                End If
            End With

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub compdef_ClearMessagearea() Handles compdef.ClearMessagearea
        txtMessages.Clear()
    End Sub

    Private Sub compdef_MessageSent(ByVal msg As String) Handles compdef.MessageSent
        WriteSTatus("PFDF Compile >" + msg)
    End Sub



    Private Sub ctxForms_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ctxForms.Opening
        If TreeView1.SelectedNode Is Nothing Then Exit Sub
        Try
            If TreeView1.SelectedNode.ImageIndex = 0 Then
                CreateNewDefinitionToolStripMenuItem.Enabled = True
                FinalizeFormToolStripMenuItem.Enabled = False
                DeleteFormToolStripMenuItem.Enabled = False
                SetFormsDirectoryToolStripMenuItem.Enabled = True
                CompileFormToolStripMenuItem.Enabled = False
                RunTheFormToolStripMenuItem.Enabled = False
                RefreshDirectoryToolStripMenuItem.Enabled = True
            ElseIf TreeView1.SelectedNode.ImageIndex = 1 Or TreeView1.SelectedNode.ImageIndex = 2 Then
                CreateNewDefinitionToolStripMenuItem.Enabled = True
                FinalizeFormToolStripMenuItem.Enabled = False
                DeleteFormToolStripMenuItem.Enabled = False
                SetFormsDirectoryToolStripMenuItem.Enabled = False
                CompileFormToolStripMenuItem.Enabled = False
                RunTheFormToolStripMenuItem.Enabled = False
                RefreshDirectoryToolStripMenuItem.Enabled = True

            Else
                If TreeView1.SelectedNode.Parent Is Nothing Then
                    CreateNewDefinitionToolStripMenuItem.Enabled = False
                    DeleteFormToolStripMenuItem.Enabled = True
                    SetFormsDirectoryToolStripMenuItem.Enabled = False
                    FinalizeFormToolStripMenuItem.Enabled = False
                    CompileFormToolStripMenuItem.Enabled = False
                    RunTheFormToolStripMenuItem.Enabled = True
                    RefreshDirectoryToolStripMenuItem.Enabled = False
                    Exit Sub
                Else
                    CreateNewDefinitionToolStripMenuItem.Enabled = False
                    DeleteFormToolStripMenuItem.Enabled = True
                    SetFormsDirectoryToolStripMenuItem.Enabled = False
                    RefreshDirectoryToolStripMenuItem.Enabled = False
                End If
                If TreeView1.SelectedNode.Parent.ImageIndex = 1 Or TreeView1.SelectedNode.Parent.ImageIndex = 2 Then
                    FinalizeFormToolStripMenuItem.Enabled = True
                    CompileFormToolStripMenuItem.Enabled = True
                    RunTheFormToolStripMenuItem.Enabled = False
                Else
                    FinalizeFormToolStripMenuItem.Enabled = False
                    CompileFormToolStripMenuItem.Enabled = False
                    RunTheFormToolStripMenuItem.Enabled = True
                End If

            End If
            If TreeView1.SelectedNode.Tag.ToString.Contains(My.Settings.FormsDir & "\Finalized") Then
                CopyTopersonalToolStripMenuItem.Enabled = True
            Else
                CopyTopersonalToolStripMenuItem.Enabled = False
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub LoadForms()
        TreeView1.Nodes.Clear()
        WriteStatusLable("Loading forms...")
        Dim dirname As String = My.Settings.FormsDir
        Try
            If IO.Directory.Exists(dirname) = False Then
                MkDir(dirname)
            End If
            Dim tn As New TreeNode(dirname.Substring(InStrRev(dirname, "\")))
            tn.Tag = dirname
            tn.ImageIndex = 0
            tn.SelectedImageIndex = 0
            TreeView1.Nodes.Add(tn)
            If IO.Directory.Exists(dirname & "\Debug") = False Then
                MkDir(dirname & "\Debug")
            End If
            If IO.Directory.Exists(dirname & "\Personalized") = False Then
                MkDir(dirname & "\Personalized")
            End If
            If IO.Directory.Exists(dirname & "\Finalized") = False Then
                MkDir(dirname & "\Finalized")
            End If

            Dim tn2 As New TreeNode("Debug")
            tn2.Tag = dirname & "\Debug"
            tn2.SelectedImageIndex = 1
            tn2.ImageIndex = 1
            tn2.Nodes.Add("dummy", "")
            tn.Nodes.Add(tn2)
            RefreshDebugDir(tn2)
            tn2 = New TreeNode("Finalized")
            tn2.Tag = dirname & "\Finalized"
            tn2.SelectedImageIndex = 1
            tn2.ImageIndex = 1
            tn2.Nodes.Add("dummy", "")
            tn.Nodes.Add(tn2)
            RefreshFormsDir(tn2)
            tn2 = New TreeNode("Personalized")
            tn2.Tag = dirname & "\Personalized"
            tn2.SelectedImageIndex = 1
            tn2.ImageIndex = 1
            tn2.Nodes.Add("dummy", "")
            tn.Nodes.Add(tn2)
            RefreshFormsDir(tn2)
            Dim fls() As String = IO.Directory.GetFiles(dirname, "*.pf1")
            For Each fl As String In fls
                Dim tn3 As New TreeNode(IO.Path.GetFileNameWithoutExtension(fl))
                tn3.Tag = fl
                tn3.ImageIndex = 4
                tn3.SelectedImageIndex = 4
                TreeView1.Nodes.Add(tn3)
            Next
            TreeView1.Nodes(0).Expand()
            WriteStatusLable()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub RefreshDebugDir(ByVal nd As TreeNode)
        Try
            nd.Nodes.Clear()
            Dim fls() As String = IO.Directory.GetFiles(nd.Tag, "*.pfdf")
            For Each fl As String In fls
                Dim tn3 As New TreeNode(IO.Path.GetFileNameWithoutExtension(fl))
                tn3.Tag = fl
                tn3.ImageIndex = 3
                tn3.SelectedImageIndex = 3
                nd.Nodes.Add(tn3)
            Next

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub RefreshFormsDir(ByVal nd As TreeNode)
        Try
            nd.Nodes.Clear()
            Dim fls() As String = IO.Directory.GetFiles(nd.Tag, "*.pf1")
            For Each fl As String In fls
                Dim tn3 As New TreeNode(IO.Path.GetFileNameWithoutExtension(fl))
                tn3.Tag = fl
                tn3.ImageIndex = 4
                tn3.SelectedImageIndex = 4
                nd.Nodes.Add(tn3)
            Next

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub FinalizeFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinalizeFormToolStripMenuItem.Click
        Try
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            If TreeView1.SelectedNode.Tag.ToString.Contains(My.Settings.FormsDir) Then

                Dim cf As New PForms.Initiator
                AddHandler cf.MessageSent, AddressOf compdef_MessageSent
                If cf.ParseContent(TreeView1.SelectedNode.Tag) Then
                    If IO.File.Exists(My.Settings.FormsDir & "\Finalized\" & IO.Path.GetFileName(cf.FormPath)) Then
                        If MsgBox("The form already exists at the target location, do you want to overwrite?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
                    End If
                    IO.File.Copy(cf.FormPath, My.Settings.FormsDir & "\Finalized\" & IO.Path.GetFileName(cf.FormPath), True)
                End If
                LoadForms()
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub CreateNewDefinitionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNewDefinitionToolStripMenuItem.Click
        Try
            Dim sfd As New SaveFileDialog
            With sfd
                .Filter = "Pournami Data Form Definition|*.pfdf"
                If IO.Directory.Exists(My.Settings.FormsDir & "\Debug") = False Then
                    MkDir(My.Settings.FormsDir & "\Debug")
                End If
                .InitialDirectory = My.Settings.FormsDir & "\Debug"
                If .ShowDialog = DialogResult.OK Then
                    Dim sr As New IO.StreamWriter(.FileName)
                    sr.WriteLine("#Created on " & Format(Date.Now, "dd-MMM-yyyy") & " at " & Format(Date.Now, "HH:mm"))
                    sr.WriteLine("[META:Employee Data]")
                    sr.WriteLine("[FORMDEF:Departments:DEPARTMENTS]")
                    sr.WriteLine("[FIELD:DEPID:TEXT]")
                    sr.WriteLine("[FIELD:DEPNAME:TEXT]")
                    sr.WriteLine("[FIELD:MANAGER:LIST:VIJAY,AJAY,JHANSI,KALYANI,NAGABHUSHAN,PRASAD]")
                    sr.WriteLine("#PROJECT DATA")
                    sr.WriteLine("[FORMDEF:Projects:PROJECTS]")
                    sr.WriteLine("[FIELD:PROJECTID:TEXT]")
                    sr.WriteLine("[FIELD:NAME:TEXT]")
                    sr.WriteLine("[FIELD:MANAGERID:ROCOMBO:SELECT EMPNAME FROM EMPLOYEES ORDER BY EMPID]")
                    sr.WriteLine("#EMPLOYEE DATA")
                    sr.WriteLine("[FORMDEF:Employees:EMPLOYEES]")
                    sr.WriteLine("[FIELD:EMPID:TEXT]")
                    sr.WriteLine("[FIELD:EMPNAME:TEXT]")
                    sr.WriteLine("[FIELD:SALARY:NUMERIC]")
                    sr.WriteLine("[FIELD:DOB:DATE]")
                    sr.WriteLine("[FIELD:DEPTID:ROCOMBO:SELECT DEPID FROM DEPARTMENTS ORDER BY DEPID]")
                    sr.WriteLine("[FIELD:PROJECT:ROCOMBO:SELECT PROJECTID FROM PROJECTS ORDER BY PROJECTID]")
                    sr.WriteLine("[REPORT:PROJECTIMP:PROJECTS:SELECT PROJECTID,NAME,MANAGERID FROM PROJECTS ORDER BY PROJECTID]")
                    sr.Close()
                    sr.Dispose()
                    OpenFile(.FileName)
                    If TreeView1.Nodes(0).Nodes(0).Text = "Debug" Then
                        RefreshDebugDir(TreeView1.Nodes(0).Nodes(0))
                        TreeView1.Nodes(0).Nodes(0).Expand()
                    End If
                End If
            End With
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub DeleteFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteFormToolStripMenuItem.Click
        Try
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            If MsgBox("Do you really want to delete the files?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            If TreeView1.SelectedNode.ImageIndex = 3 Then
                Dim sourcefile1, sourcefile2 As String
                sourcefile1 = TreeView1.SelectedNode.Tag
                sourcefile2 = IO.Path.GetDirectoryName(sourcefile1) & "\" & IO.Path.GetFileNameWithoutExtension(sourcefile1) & ".pf1"
                IO.File.Delete(sourcefile1)
                IO.File.Delete(sourcefile2)
                TreeView1.SelectedNode.Remove()
            ElseIf TreeView1.SelectedNode.ImageIndex = 4 Then
                Dim sourcefile1 = TreeView1.SelectedNode.Tag
                IO.File.Delete(sourcefile1)
                TreeView1.SelectedNode.Remove()
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub SetFormsDirectoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetFormsDirectoryToolStripMenuItem.Click
        Try
            Dim fb As New FolderBrowserDialog
            fb.SelectedPath = My.Settings.FormsDir
            If fb.ShowDialog = DialogResult.OK Then
                My.Settings.FormsDir = fb.SelectedPath
                LoadForms()
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub RefreshDirectoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshDirectoryToolStripMenuItem.Click
        Try
            LoadForms()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub TreeView1_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCollapse
        If e.Node.ImageIndex = 1 Or e.Node.ImageIndex = 2 Then
            e.Node.ImageIndex = 1
            e.Node.SelectedImageIndex = 1
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub TreeView1_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        If e.Node.Tag = My.Settings.FormsDir & "\Debug" Then
            RefreshDebugDir(e.Node)
            e.Node.ImageIndex = 2
            e.Node.SelectedImageIndex = 2
        ElseIf e.Node.Tag = My.Settings.FormsDir & "\Finalized" Or e.Node.Tag = My.Settings.FormsDir & "\Pesonalized" Then
            RefreshFormsDir(e.Node)
            e.Node.ImageIndex = 2
            e.Node.SelectedImageIndex = 2

        End If
    End Sub

    Private Sub CompileFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompileFormToolStripMenuItem.Click
        Try
            Dim cf As New PForms.Initiator
            AddHandler cf.MessageSent, AddressOf compdef_MessageSent
            If cf.ParseContent(TreeView1.SelectedNode.Tag) Then
                Dim ds As New DataShow(cf.FormPath)
                ds.LoadContents()
                If ds.DataForm1.UserDefined = False Then
                    ds.Close()

                End If
            End If

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub RunTheFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunTheFormToolStripMenuItem.Click
        Try
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            For Each fm As Form In Application.OpenForms
                If TypeOf fm Is DataShow Then
                    If CType(fm, DataShow).FileUsed = TreeView1.SelectedNode.Tag Then
                        fm.Activate()
                        Exit Sub
                    End If
                End If
            Next
            Dim ds As New DataShow(TreeView1.SelectedNode.Tag)
            ds.LoadContents()
            If ds.DataForm1.UserDefined = False Then
                ds.Close()

            End If

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub TreeView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeView1.MouseClick
        Try
            Dim ht As TreeViewHitTestInfo = TreeView1.HitTest(e.Location)
            If Not ht.Node Is Nothing Then
                TreeView1.SelectedNode = ht.Node
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        Try
            If e.Node.ImageIndex = 3 Or e.Node.ImageIndex = 4 Then
                OpenFile(e.Node.Tag)
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub SetLanguageinStatusBar()
        currentFile = tabMain.ActiveControl

        If currentFile Is Nothing Then tlstpLAnglabel.Text = "No file" : Exit Sub
        tlstpColNo.Text = currentFile.CurrentLocation.X
        tlstpLineNo.Text = currentFile.CurrentLocation.Y
        tlstpLAnglabel.Text = currentFile.Tag & " file"
    End Sub

    Private Sub tabMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabMain.SelectedIndexChanged
        SetLanguageinStatusBar()
    End Sub

    Private Sub BrowserWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowserWindowToolStripMenuItem.Click

    End Sub

    Private Sub FileBrowserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileBrowserToolStripMenuItem.Click

    End Sub

    Private Sub FormsHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormsHelpToolStripMenuItem.Click
        Try
            Process.Start("PournamiForms.pdf")
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub CopyTopersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyTopersonalToolStripMenuItem.Click
        Try
            If TreeView1.SelectedNode Is Nothing Then Exit Sub
            If TreeView1.SelectedNode.Tag.ToString.Contains(My.Settings.FormsDir) Then

                Dim cf As New PForms.Initiator
                AddHandler cf.MessageSent, AddressOf compdef_MessageSent

                If IO.File.Exists(My.Settings.FormsDir & "\Personalized\" & IO.Path.GetFileName(TreeView1.SelectedNode.Tag.ToString)) Then
                    If MsgBox("The form already exists at the target location, do you want to overwrite?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
                End If
                IO.File.Copy(TreeView1.SelectedNode.Tag.ToString, My.Settings.FormsDir & "\Personalized\" & IO.Path.GetFileName(TreeView1.SelectedNode.Tag.ToString), True)
            End If
            LoadForms()

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub CreateInsertsFromCSVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateInsertsFromCSVToolStripMenuItem.Click
        Dim CSVINS As New CSVtoInsert
        CSVINS.ShowDialog()
    End Sub

    Private Sub OrganizeDataByPositionAndLengthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrganizeDataByPositionAndLengthToolStripMenuItem.Click
        Dim lende As New LenDelimitedtoTab
        lende.ShowDialog()
    End Sub

    Private Sub CompareTwoListsOfValuesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompareTwoListsOfValuesToolStripMenuItem.Click
        Dim fc As New Comparator
        fc.ShowDialog()
    End Sub

    Private Sub CompareTwoFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompareTwoFolderToolStripMenuItem.Click
        Dim flc As New FolderCompare
        flc.ShowDialog()
    End Sub

    Private Sub FindDuplicatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RemovemultipleSpacesInTheFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemovemultipleSpacesInTheFileToolStripMenuItem.Click
        currentFile = tabMain.ActiveControl
        If currentFile Is Nothing Then Exit Sub
        Dim cf As New ClosingMsg
        Try
            cf.Text = "Removing spaces"
            cf.Label1.Text = "Removing spaces and empty lines, please wait..."

            cf.Show(Me)
            cf.Label1.Refresh()
            Dim lns As New List(Of String)

            For Each ln As String In currentFile.Lines
                If String.IsNullOrEmpty(ln) Then Continue For
                lns.Add(ln.Trim)
            Next
            currentFile.Clear()
            Dim FinalSTring As String = ""
            For Each ln As String In lns
                FinalSTring += vbLf & ln
            Next
            FinalSTring = FinalSTring.Substring(1)
            currentFile.Text = FinalSTring

        Catch ex As Exception
            DE(ex)
        Finally
            cf.Close()
        End Try
    End Sub

    Private Sub EncloseSpaceDelimitedValuesInSingleQuotesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub WorkableParallelFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkableParallelFormToolStripMenuItem.Click
        Dim sf As New StandbyForm(Me)
        sf.Show()
    End Sub


    Private Sub SetdefaultToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetdefaultToolStripMenuItem.Click
        Try
            If TreeView2.Nodes.Count = 0 Then Exit Sub
            My.Settings.DefaultProjectFile = TreeView2.Nodes(0).Tag
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditorToolStripMenuItem.Click
        WI.Hide()
        ToolStripContainer1.Show()

        FileToolStripMenuItem.Enabled = True
        EditToolStripMenuItem.Enabled = True
        ViewToolStripMenuItem.Enabled = True
        ProjectToolStripMenuItem.Enabled = False
        LanguageToolStripMenuItem.Enabled = True
        TextFunctionsToolStripMenuItem.Enabled = True
    End Sub

    Private Sub WorkItemsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkItemsToolStripMenuItem1.Click
        ToolStripContainer1.Hide()
        WI.Show()
        WI.BringToFront()
        FileToolStripMenuItem.Enabled = False
        EditToolStripMenuItem.Enabled = False
        ViewToolStripMenuItem.Enabled = False
        ProjectToolStripMenuItem.Enabled = False
        LanguageToolStripMenuItem.Enabled = False
        TextFunctionsToolStripMenuItem.Enabled = False
    End Sub
End Class
