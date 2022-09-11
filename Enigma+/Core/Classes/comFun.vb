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
Module comFun
    Public Unwantedfiles As New SortedList()
    Public LangColl As New Dictionary(Of String, String)
    Public UserDocuments As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Enigma+"
    Public UserTempData As String = UserDocuments & "\Data"
    Public UserWorkItems As String = UserDocuments & "\Data\IsTaBu.db3"
    Public Sub DE(ByVal ex As Exception)
        MsgBox(ex.Message, MsgBoxStyle.Critical)
    End Sub
    Public LanguagesSupported As New Dictionary(Of String, Language)
    Public FileQueue As New Collection
    Public AvailableExtensions As String = "Text files|*.txt|Data files|*.dat|Log files|*.log|Batch files|*.bat|CPP files|*.cpp|C files|*.c|Php files|*.php,*.php3|HTML files|*.htm,*.html|XML files|*.xml|ASPNET files|*.aspx|CSharp files|*.cs|VB files|*.vb|SQL Files|*.sql|Java files|*.java|Javascript files|*.js|Porunami Form Definition|*.pfdf|All files|*.*"
    Public Sub GetLangs()
        Try
            Dim fls() As String = IO.Directory.GetFiles(UserTempData & "\Addlang", "*.xml")
            Dim langle As Language
            With LanguagesSupported
                langle = New Language("VB")
                langle.IsInbuilt = True
                langle.Extensions = "VB Files(*.vb)|*.vb"
                .Add("VB", langle)
                langle = New Language("CSharp")
                langle.IsInbuilt = True
                langle.Extensions = "CS Files(*.cs)|*.cs"
                .Add("CSharp", langle)
                langle = New Language("HTML")
                langle.IsInbuilt = True
                langle.Extensions = "HTML Files(*.html)|*.html"
                .Add("HTML", langle)
                langle = New Language("XML")
                langle.IsInbuilt = True
                langle.Extensions = "XML Files(*.xml)|*.xml"
                .Add("XML", langle)
                langle = New Language("SQL")
                langle.IsInbuilt = True
                langle.Extensions = "SQL Files(*.sql)|*.sql"
                .Add("SQL", langle)
                langle = New Language("PHP")
                langle.Extensions = "PHP Files(*.php)|*.php"
                langle.IsInbuilt = True
                .Add("PHP", langle)
                langle = New Language("JS")
                langle.Extensions = "JS Files(*.js)|*.js"
                langle.IsInbuilt = True
                .Add("JS", langle)
                For Each fl As String In fls
                    Dim doc As New Xml.XmlDocument
                    doc.Load(fl)
                    Dim xmlN As Xml.XmlNode = doc.SelectSingleNode("doc")
                    If xmlN Is Nothing Then Continue For
                    Dim langName As String = xmlN.Attributes("name").Value
                    If langName Is Nothing Then Continue For
                    Dim extension As String = xmlN.Attributes("extensions").Value
                    If extension Is Nothing Then Continue For
                    Dim xmlN1 As Xml.XmlNode = doc.SelectSingleNode("doc/autocomplete")
                    Dim autocompletetext As String = ""
                    If Not xmlN1 Is Nothing Then
                        autocompletetext = xmlN1.InnerText.Trim
                    End If
                    langle = New Language(langName)
                    langle.FilePAth = fl
                    langle.Extensions = extension
                    langle.AutoCompleteWords = autocompletetext
                    LangColl.Add(langName, fl)
                    .Add(langle.Name, langle)
                Next
            End With
        Catch ex As Exception
            DE(ex)
        End Try


    End Sub
End Module
