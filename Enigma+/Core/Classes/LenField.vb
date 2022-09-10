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
Public Class LenField
    Private _colName As String
    Private _startPos As Integer
    Private _len As Integer
    Public Property Name As String
        Get
            Return _colName
        End Get
        Set(ByVal value As String)
            _colName = value
        End Set
    End Property
    Public Property StartPos As Integer
        Get
            Return _startPos
        End Get
        Set(ByVal value As Integer)
            _startPos = value
        End Set
    End Property
    Public Property Length As Integer
        Get
            Return _len
        End Get
        Set(ByVal value As Integer)
            _len = value
        End Set
    End Property
End Class
