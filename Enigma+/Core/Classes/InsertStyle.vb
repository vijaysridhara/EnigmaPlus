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

Public Class InsertedSTyle
    Inherits Style

    Public ReadOnly Property ForeBrush As Brush
        Get
            Return Brushes.White
        End Get
    End Property

    Public ReadOnly Property BackgroundBrush As Brush
        Get
            Return Brushes.Green
        End Get

    End Property

    Public ReadOnly Property FontStyle As FontStyle
        Get
            Return FontStyle.Regular
        End Get

    End Property

    Public Overrides Sub Draw(ByVal gr As Graphics, ByVal position As Point, ByVal range As Range)
        'draw background
        If (Not (BackgroundBrush) Is Nothing) Then
            gr.FillRectangle(BackgroundBrush, position.X, position.Y, ((range.End.iChar - range.Start.iChar) _
                            * range.tb.CharWidth), range.tb.CharHeight)
        End If
        'draw chars
        Dim f As Font = New Font(range.tb.Font, FontStyle)
        Dim line As Line = range.tb(range.Start.iLine)
        Dim dx As Single = range.tb.CharWidth
        Dim y As Single = (position.Y - 2.0!)
        Dim x As Single = (position.X - 2.0!)
        Dim foreBrush As Brush = New SolidBrush(range.tb.ForeColor)
        Dim i As Integer = range.Start.iChar
        Do While (i < range.End.iChar)
            'draw char
            gr.DrawString(line(i).c.ToString, f, foreBrush, x, y)
            x = (x + dx)
            i = (i + 1)
        Loop
    End Sub
End Class