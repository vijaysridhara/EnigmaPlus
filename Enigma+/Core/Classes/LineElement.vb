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
Public Class LineElement
    Private _Value As String
    Private _no As UInteger
    Private _isChecked As Boolean
    Private _linestatus As LST
    Enum LST
        Found
        Inserted
        Deleted
    End Enum
    Public Property Value As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
        End Set
    End Property
    Public Property LineNo As UInteger
        Get
            Return _no
        End Get
        Set(ByVal value As UInteger)
            _no = value
        End Set
    End Property
    Public Property IsChecked As Boolean
        Get
            Return _isChecked
        End Get
        Set(ByVal value As Boolean)
            _isChecked = value
        End Set
    End Property
    Public Property LineSTatus As LST
        Get
            Return _linestatus
        End Get
        Set(ByVal value As LST)
            _linestatus = value
        End Set
    End Property
End Class
