Imports Microsoft.VisualBasic
Imports System.ServiceModel

Namespace SIGESWeb.WS.Clases_Abstractas
    Public MustInherit Class clsObjetoProxy
        Protected ReadOnly Property Usuario As String
            Get
                Return CStr(System.Web.HttpContext.Current.Session("USUARIO"))
            End Get
        End Property

        Protected Sub RegistrarError(ex As Exception)
            Dim objLOG As New clsLOG
            objLOG.AgregarLog("Error: " & ex.ToString, System.Diagnostics.EventLogEntryType.Error)
        End Sub
    End Class
End Namespace