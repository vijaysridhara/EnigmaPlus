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
Public Class Language
    Private _name As String
    Private _filepath As String
    Private _extensions As String
    Private _isInbuilt As Boolean
    Private _autocomplete As String
    Public Property IsInbuilt As Boolean
        Get
            Return _isInbuilt
        End Get
        Set(ByVal value As Boolean)
            _isInbuilt = value
        End Set
    End Property
    Public Property AutoCompleteWords() As String
        Get
            Return _autocomplete
        End Get
        Set(ByVal value As String)
            _autocomplete = value
        End Set
    End Property
    Public Sub New(ByVal name As String)
        _name = name

    End Sub
    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property
    Public Property FilePAth As String
        Get
            Return _filepath
        End Get
        Set(ByVal value As String)
            _filepath = value
        End Set
    End Property

    Public Property Extensions As String
        Get
            Return _extensions
        End Get
        Set(ByVal value As String)
            _extensions = value
        End Set
    End Property

    Public Function ContainsExtension(ByVal ext As String) As Boolean
        Dim ext1() As String = _extensions.Split("|")
        Dim i As Integer = 0
        For Each et As String In ext1
            i += 1
            If Int(i / 2) * 2 = i Then
                If "*" & ext.ToLower = et.ToLower Then Return True
            End If
        Next
        Return False
    End Function
End Class
