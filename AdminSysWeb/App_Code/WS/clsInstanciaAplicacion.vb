Imports Microsoft.VisualBasic

Namespace SIGESWeb
    Public Class clsInstanciaAplicacion
        Public Shared Conn As clsSIGESProxyWrapper

        Public Shared Function InstanciaWSGenerico(ByVal Contexto As System.Web.HttpContext) As clsSIGESProxyWrapper
            If Contexto.Session(clsConstantes.EndPointSIGESGenerico) Is Nothing Then
                Conn = New clsSIGESProxyWrapper()
                Contexto.Session(clsConstantes.EndPointSIGESGenerico) = Conn
            Else
                Conn = Contexto.Session(clsConstantes.EndPointSIGESGenerico)
            End If
            Return Conn
        End Function
    End Class
End Namespace