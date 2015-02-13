Imports System.Reflection
Namespace SIGESWeb
    Public Class ObjectManager

        Public Overridable Sub Page_Load(ByRef page As SIGESWeb.PaginaBase, ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Public Overridable Sub After_Page_Load(ByRef page As SIGESWeb.PaginaBase, ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Public Shared Function getInstante(ByVal name As String) As ObjectManager
            Dim ThisAssembly As Assembly = Assembly.GetExecutingAssembly()
            Dim mytype As Type = Nothing
            mytype = ThisAssembly.GetType(name)

            Dim instancia As Object = Activator.CreateInstance(mytype)


            Return instancia

        End Function

    End Class
End Namespace

