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
Imports FastColoredTextBoxNS


Public Class Buntilla
    Inherits FastColoredTextBoxNS.FastColoredTextBox
    Private _filename As String = "Untitled"
    Private _filepath As String
    Event FileModified(ByVal sender As Object)
    Event FileSaved(ByVal sender As Object)

    Private _isDirty As Boolean
    Shadows Event FileNameChanged(ByVal sender As Object)
    'Private _curExtension As String = "Text files|*.txt"
    Private nonTextChars As New List(Of String)
    Event MessageSent(ByVal msg As String, ByVal iserror As Boolean)
    Event Travelling(ByVal line As Integer, ByVal col As Integer)

    Dim zoomlevel As Integer = 100
    Dim defaultZoomFomt As Integer = 10
    Dim zoomincrement As Integer = 15
    Private _cursorloc As New Point(0, 1)
    Event PlaceChanged(ByVal plc As Point)
    Public Property CurrentLocation As Point
        Get
            Return _cursorloc
        End Get
        Set(ByVal value As Point)
            _cursorloc = value
        End Set
    End Property
    Public ReadOnly Property IsDirty As Boolean
        Get
            Return _isDirty
        End Get

    End Property


    Public Property JustFileName As String
        Get
            Return _filename
        End Get
        Set(ByVal value As String)
            _filename = value
        End Set
    End Property

    Public ReadOnly Property FilePath As String
        Get
            Return _filepath

        End Get

    End Property
    Private ctxMenu As New ContextMenuStrip
    Public Sub New()
        MyBase.New()

        InitializeComponent()

        Me.Font = New Font("Courier new", defaultZoomFomt)
        Dim newdp As ToolStripItem
        For i As Integer = 0 To 9
            newdp = New ToolStripMenuItem
            Select Case i
                Case 0
                    newdp.Text = "Cu&t"

                Case 1
                    newdp.Text = "&Copy"
                Case 2
                    newdp.Text = "&Paste"
                Case 3
                    Dim x As New ToolStripSeparator
                    ctxMenu.Items.Add(x)
                    newdp.Text = "Select &all"
                Case 4
                    Dim x As New ToolStripSeparator
                    ctxMenu.Items.Add(x)
                    newdp.Text = "&Word wrap"
                Case 5
                    newdp.Text = "Split into &lines"
                Case 6
                    newdp.Text = "&Join selected lines"
                Case 7
                    newdp.Text = "Zoom &in"
                Case 8
                    newdp.Text = "Zoom &out"
                Case 9
                    newdp.Text = "Re&set zoom"
            End Select
            newdp.Tag = i
            ctxMenu.Items.Add(newdp)
            AddHandler newdp.Click, AddressOf ContextMenuClicked
        Next
        AddHandler ctxMenu.Opening, AddressOf ctxMenuOpening
        Me.ContextMenuStrip = ctxMenu
    End Sub
    Private Sub ctxMenuOpening(ByVal sender As Object, ByVal e As EventArgs)

        If Me.SelectedText = "" Then
            For Each ct As ToolStripItem In ctxMenu.Items
                Select Case ct.Tag
                    Case 0, 1
                        ct.Enabled = False
                End Select

            Next
        Else
            For Each ct As ToolStripItem In ctxMenu.Items
                Select Case ct.Tag
                    Case 0, 1
                        ct.Enabled = True
                End Select
            Next

        End If
        If Clipboard.GetText() = "" Then
            For Each ct As ToolStripItem In ctxMenu.Items
                Select Case ct.Tag
                    Case 2
                        ct.Enabled = False
                End Select

            Next
            For Each ct As ToolStripItem In ctxMenu.Items
                Select Case ct.Tag
                    Case 2
                        ct.Enabled = True
                End Select

            Next
        End If
    End Sub

    Private Sub ContextMenuClicked(ByVal sender As Object, ByVal e As EventArgs)
        Select Case sender.tag
            Case 0
                Me.Cut()
            Case 1
                Me.Copy()
            Case 2
                Me.Paste()
            Case 3
                Me.SelectAll()
            Case 4
                If Me.WordWrap = True Then
                    Me.WordWrap = False
                    sender.checked = False
                Else
                    Me.WordWrap = True
                    sender.checked = True
                End If
            Case 5
                Dim delim As String = InputBox("What is the delimiter", "Delimiter", ",")
                If String.IsNullOrEmpty(delim) Then Exit Select
                Me.SelectedText = Me.SelectedText.Replace(delim, vbLf)

            Case 6

                Me.SelectedText = Me.SelectedText.Replace(vbLf, " ")
            Case 7
                If zoomlevel >= 400 Then Exit Select
                zoomlevel += zoomincrement
                Me.Font = New Font(Me.Font.Name, Me.Font.Size + defaultZoomFomt * (zoomincrement / 100))

            Case 8
                If zoomlevel <= 25 Then Exit Select
                zoomlevel -= zoomincrement
                Me.Font = New Font(Me.Font.Name, Me.Font.Size - defaultZoomFomt * (zoomincrement / 100))

            Case 9
                zoomlevel = 100
                Me.Font = New Font(Me.Font.Name, defaultZoomFomt)
        End Select
    End Sub

  

    Private Sub Buntilla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.K Then
                If pmenu Is Nothing Then Exit Sub
                pmenu.Show(True)
                e.Handled = True
            End If


        End If

        If e.KeyCode = Keys.Left Then
            _cursorloc.X = Selection.Start.iChar
            _cursorloc.Y = Selection.Start.iLine + 1
            RaiseEvent PlaceChanged(_cursorloc)
        ElseIf e.KeyCode = Keys.Right Then
            _cursorloc.X = Selection.Start.iChar
            _cursorloc.Y = Selection.Start.iLine + 1
            RaiseEvent PlaceChanged(_cursorloc)
        ElseIf e.KeyCode = Keys.Up Then
            _cursorloc.X = Selection.Start.iChar
            _cursorloc.Y = Selection.Start.iLine + 1
            RaiseEvent PlaceChanged(_cursorloc)
        ElseIf e.KeyCode = Keys.Down Then
            _cursorloc.X = Selection.Start.iChar
            _cursorloc.Y = Selection.Start.iLine + 1
            RaiseEvent PlaceChanged(_cursorloc)
        End If



    End Sub

    Private Sub Buntilla_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Left Then
            _cursorloc.X = Selection.Start.iChar
            _cursorloc.Y = Selection.Start.iLine + 1
            RaiseEvent PlaceChanged(_cursorloc)
        ElseIf e.KeyCode = Keys.Right Then
            _cursorloc.X = Selection.Start.iChar
            _cursorloc.Y = Selection.Start.iLine + 1
            RaiseEvent PlaceChanged(_cursorloc)
        ElseIf e.KeyCode = Keys.Up Then
            _cursorloc.X = Selection.Start.iChar
            _cursorloc.Y = Selection.Start.iLine + 1
            RaiseEvent PlaceChanged(_cursorloc)
        ElseIf e.KeyCode = Keys.Down Then
            _cursorloc.X = Selection.Start.iChar
            _cursorloc.Y = Selection.Start.iLine + 1
            RaiseEvent PlaceChanged(_cursorloc)
        End If
    End Sub

 

    Private Sub Buntilla_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        _cursorloc.X = Selection.Start.iChar
        _cursorloc.Y = Selection.Start.iLine
        RaiseEvent PlaceChanged(_cursorloc)
    End Sub
 

    Private Sub Buntilla_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectionChanged

    End Sub





    Private Sub MyScite_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If isloadingfile Then Exit Sub
        _isDirty = True
        RaiseEvent FileModified(Me)
        _cursorloc.X = Selection.Start.iChar
        _cursorloc.Y = Selection.Start.iLine + 1
        RaiseEvent PlaceChanged(_cursorloc)
    End Sub
    Private isloadingfile As Boolean
    Public Overloads Sub LoadFile(ByVal fname As String)
        Try
            isloadingfile = True
            Dim sr As New IO.StreamReader(fname)
            Me.Text = sr.ReadToEnd
            sr.Close()
            sr.Dispose()
            'MyBase.OpenBindingFile(fname, New System.Text.ASCIIEncoding)

            _filepath = fname
            _isDirty = False
            JustFileName = IO.Path.GetFileName(_filepath)
            Dim langfound As Boolean
            For Each lang As Language In LanguagesSupported.Values
                If lang.ContainsExtension(IO.Path.GetExtension(_filepath).ToLower) Then
                    SetLanguage(lang)
                    langfound = True
                    Exit For

                End If
            Next
            If langfound = False Then
                Dim ext As String = IO.Path.GetExtension(_filepath)
                If ext.Length > 0 Then
                    ext = ext.Substring(1)
                    Me.Tag = ext.ToUpper
                Else
                    Me.Tag = "Unknown"
                End If

            End If
            RaiseEvent FileNameChanged(Me)

        Catch ex As Exception
            DE(ex)

        Finally
            isloadingfile = False
        End Try
    End Sub
    Dim pmenu As AutocompleteMenu = New FastColoredTextBoxNS.AutocompleteMenu(Me)
    Private Sub SetLanguage(ByVal Lang As Language)
        Try
            Select Case Lang.IsInbuilt
                Case True
                    Select Case Lang.Name
                        Case "VB"
                            Language = FastColoredTextBoxNS.Language.VB
                        Case "JS"
                            Language = FastColoredTextBoxNS.Language.JS
                        Case "SQL"
                            Language = FastColoredTextBoxNS.Language.SQL
                        Case "CSharp"
                            Language = FastColoredTextBoxNS.Language.CSharp
                        Case "PHP"
                            Language = FastColoredTextBoxNS.Language.PHP
                        Case "HTML", "XML"
                            Language = FastColoredTextBoxNS.Language.HTML
                    End Select
                Case False
                    Me.DescriptionFile = Lang.FilePAth
                    If Lang.AutoCompleteWords Is Nothing Then Exit Select
                    Dim wds() As String = Lang.AutoCompleteWords.Split(",")
                    pmenu = New FastColoredTextBoxNS.AutocompleteMenu(Me)
                    pmenu.MinFragmentLength = 2
                    pmenu.Items.SetAutocompleteItems(Lang.AutoCompleteWords.Split(","))
                    pmenu.Items.MaximumSize = New System.Drawing.Size(200, 300)
                    pmenu.Items.Width = 200
            End Select
            Me.Tag = Lang.Name
            Me.OnTextChanged()
        Catch ex As Exception
            DE(ex)
        End Try

    End Sub

    Public Overloads Sub SaveFile(ByVal fname As String)
        Try

            Dim sw As New IO.StreamWriter(fname)
            'MyBase.SaveToFile(fname, New System.Text.ASCIIEncoding)
            sw.Write(Me.Text)
            sw.Close()
            sw.Dispose()
            _isDirty = False
            _filepath = fname
            RaiseEvent FileSaved(Me)
            JustFileName = IO.Path.GetFileName(_filepath)
            RaiseEvent FileNameChanged(Me)

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'textAreaPanel
        '

        '
        'Buntilla
        '
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        Me.Name = "Buntilla"

        Me.Size = New System.Drawing.Size(378, 263)
        Me.ResumeLayout(False)

    End Sub



End Class



