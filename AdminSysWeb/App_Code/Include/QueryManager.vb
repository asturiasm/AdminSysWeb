Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Web

Namespace SIGESWeb
    <Serializable()> Public Class QueryManager
        Protected queries As Specialized.StringDictionary
        Protected pageName As String
        Public Sub New(ByRef server As HttpServerUtility, ByVal pagina As String)
            Try
                pageName = server.MapPath("~/App_Data/queries/" + pagina + ".xml")
                queries = getQueries(pageName)
            Catch ex As Exception

            End Try
        End Sub

        Public Function getQuery(ByVal key As String) As String
            Return getProperty(key)
        End Function

        Public Function getProperty(ByVal key As String) As String
            If queries Is Nothing Then
                Return Nothing
            End If

            If (queries.ContainsKey(key)) Then
                Return queries(key)
            End If

            Return Nothing

        End Function

        Public Function getQueries(ByRef fileName As String) As Specialized.StringDictionary
            Try
                Dim queries As Specialized.StringDictionary = New Specialized.StringDictionary

                Dim rs As New System.Xml.XmlDocument

                rs.Load(fileName)

                Dim i As Integer = 0
                Dim name As String
                Dim value As String

                Dim array As ArrayList = New ArrayList()

                While i < rs.ChildNodes.Item(1).ChildNodes.Count
                    name = rs.ChildNodes.Item(1).ChildNodes(i).ChildNodes(0).FirstChild.Value
                    value = rs.ChildNodes.Item(1).ChildNodes(i).ChildNodes(1).FirstChild.Value

                    Dim array2 As ArrayList = New ArrayList(array)
                    array2.Reverse()

                    For Each key As String In array2
                        value = value.Replace((":query:" + key), queries(key))
                    Next
                    array.Add(name)
                    queries.Add(name, value)
                    i = i + 1
                End While
                Return queries
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class

End Namespace
