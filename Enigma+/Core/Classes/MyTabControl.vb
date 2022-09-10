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
Public Class MyTabControl
    Inherits TabControl

    Public ReadOnly Property ActiveControl
        Get
            If TabPages.Count = 0 Then Return Nothing
            If SelectedTab Is Nothing Then Return Nothing
            Return SelectedTab.Controls(0)

        End Get
    End Property
End Class
