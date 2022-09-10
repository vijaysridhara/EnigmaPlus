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
Imports System.IO
Friend Class Blobber
    Private _blob As Object
    Private _isclob As Boolean
    Private _blobsize As Long
    Event BlobChanged(ByVal sender As Object)
    Event MessageSent(ByVal msg As String)
    Public Property BlobSize() As Long
        Get
            Return _blobsize
        End Get
        Set(ByVal value As Long)
            _blobsize = value
        End Set
    End Property
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        butSave.BackgroundImage = My.Resources.save.ToBitmap
        _blobsize = 0
        butUpload.BackgroundImage = My.Resources.Upload.ToBitmap
        butView.BackgroundImage = My.Resources.eye.ToBitmap
    End Sub
    Public Property IsClob() As Boolean
        Get
            Return _isclob
        End Get
        Set(ByVal value As Boolean)
            _isclob = value
            If _isclob Then
                txtData.Text = "[CLOB]"
            Else

                txtData.Text = "[BLOB]"
            End If
        End Set
    End Property

    Public Property Blob() As Object
        Get
            Return _blob
        End Get
        Set(ByVal value As Object)
            _blob = value
            If _blob Is Nothing Then
                txtSize.Text = "0 bytes"
            Else
                If IsClob = False Then
                    If TypeOf (_blob) Is System.Byte() Then
                        txtSize.Text = CType(_blob, Byte()).Length & " bytes"
                        _blobsize = CType(_blob, Byte()).Length
                    ElseIf TypeOf (_blob) Is System.String Then
                        txtSize.Text = CType(_blob, String).Length & " bytes"
                        _blobsize = CType(_blob, String).Length
                    End If
                   
                Else
                    txtSize.Text = CType(_blob, String).Length & " bytes"
                    _blobsize = CType(_blob, String).Length
                End If

            End If
        End Set
    End Property

    Private Sub butUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butUpload.Click
        If IsClob = False Then
            Dim ofd As New OpenFileDialog
            With ofd
                .Filter = "All Files(*.*)|*.*"
                If .ShowDialog = DialogResult.OK Then
                    Try
                        txtData.Text = "Adding file...."
                        Dim fname As String = .FileName
                        Dim finfo As New IO.FileInfo(fname)
                        Dim arr(finfo.Length) As Byte
                        Dim fstr As New IO.FileStream(fname, IO.FileMode.Open, IO.FileAccess.Read)
                        fstr.Read(arr, 0, finfo.Length)
                        fstr.Close()
                        fstr.Dispose()
                        txtData.Text = "[BLOB]"
                        Blob = arr
                        RaiseEvent BlobChanged(Me)
                    Catch ex As Exception
                        DE(ex)
                        txtData.Text = "[BLOB]"
                    End Try
                End If
            End With
        Else
            Dim ofd As New OpenFileDialog
            With ofd
                .Filter = "All Files(*.*)|*.*"
                If .ShowDialog = DialogResult.OK Then
                    Try
                        txtData.Text = "Adding file...."
                        Dim fname As String = .FileName
                        Dim finfo As New IO.FileInfo(fname)
                        Dim arr(finfo.Length) As Byte
                        Dim fstr As New IO.StreamReader(fname)
                        txtData.Text = "[CLOB]"
                        Blob = fstr.ReadToEnd()
                        fstr.Close()
                        fstr.Dispose()
                        RaiseEvent BlobChanged(Me)
                    Catch ex As Exception
                        de(ex)
                        txtData.Text = "[CLOB]"
                    End Try
                End If
            End With
        End If
    End Sub

    Private Sub butSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click
        If BlobSize = 0 Then
            MsgBox("No data to save", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If IsClob = False Then
            Try
                Dim arr() As Byte = _blob
                Dim sfd As New SaveFileDialog
                With sfd

                    .Filter = "All files(*.*)|*.*"
                    .FileName = "Untitled"
                    If .ShowDialog = DialogResult.OK Then
                        RaiseEvent MessageSent("Saving file...")
                        Dim fstr As New IO.FileStream(.FileName, IO.FileMode.Create, IO.FileAccess.Write)
                        fstr.Write(arr, 0, arr.Length)
                        fstr.Close()
                        fstr.Dispose()
                        RaiseEvent MessageSent("Saved successfully")
                    End If
                End With
            Catch ex As Exception
                de(ex)
            End Try
        Else

            Dim sfd As New SaveFileDialog
            With sfd

                .Filter = "All files(*.*)|*.*"
                .FileName = "Untitled"
                If .ShowDialog = DialogResult.OK Then
                    RaiseEvent MessageSent("Saving file...")
                    Dim fstr As New IO.StreamWriter(.FileName)
                    fstr.Write(_blob)
                    fstr.Close()
                    fstr.Dispose()
                    RaiseEvent MessageSent("Saved successfully")
                End If
            End With
        End If

    End Sub

    Private Sub butView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butView.Click
        Try
            If (Me.BlobSize = 0) Then
                Interaction.MsgBox("No data to view", MsgBoxStyle.Exclamation, Nothing)
            Else
                Dim str2 As String = Interaction.InputBox("Specify filetype example: txt,jpg,png,doc,xls", "Filetype", "", -1, -1)
                If Not String.IsNullOrEmpty(str2) Then
                    If Not Directory.Exists((My.Settings.TempDir)) Then
                        Directory.CreateDirectory((My.Settings.TempDir))
                    End If
                    Dim path As String = (My.Settings.TempDir & "\Untitled." & str2)
                    RaiseEvent MessageSent("Downloading for view")
                    If Not Me.IsClob Then
                        If TypeOf (_blob) Is System.Byte() Then
                            Dim array As Byte() = DirectCast(Me._blob, Byte())
                            Dim stream As New FileStream(path, FileMode.Create, FileAccess.Write)
                            stream.Write(array, 0, array.Length)
                            stream.Close()
                            stream.Dispose()
                        Else
                            Dim writer As New StreamWriter(path)
                            writer.Write((Me._blob))
                            writer.Close()
                            writer.Dispose()
                        End If
                       
                    Else
                      
                    End If
                    RaiseEvent MessageSent("Asking OS to show the file")
                    Process.Start(path)
                    RaiseEvent MessageSent("BLOB/CLOB shown")
                End If
            End If
        Catch exception1 As Exception

            RaiseEvent MessageSent(exception1.Message)

        End Try

    End Sub
End Class
