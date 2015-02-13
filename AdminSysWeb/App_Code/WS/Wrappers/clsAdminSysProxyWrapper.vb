Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class clsAdminSysProxyWrapper
    Inherits SIGESWeb.WS.Clases_Abstractas.clsObjetoProxy
    Private wsAdminSys As wsSIGESAdminSysWCF.AdminSysWCFClient


    Private Sub AbrirConexion()
        wsAdminSys = New wsSIGESAdminSysWCF.AdminSysWCFClient(System.Web.HttpContext.Current.Application("EndPointAdminSysWCF"))
        wsAdminSys.Open()
    End Sub

    Private Sub CerrarConexion()
        Try
            wsAdminSys.Close() 'Intenta cerrar una conexion que estaría fallida
        Catch
            Try
                wsAdminSys.Abort() 'Abortando conexion fallida
            Catch 'Absorbiendo el error
            End Try
        End Try
    End Sub
     
    Public Function ObjetosJerarquia(ObjetoInicial As Decimal, PoolSistema As String) As wsSIGESAdminSysWCF.clsObjetoPoco()
        Try
            AbrirConexion()
            Return wsAdminSys.Arbol(ObjetoInicial, PoolSistema)
        Catch
            Return Nothing
        Finally
            CerrarConexion()
        End Try
    End Function

    Public Function ObjetosJerarquiaDS(ObjetoInicial As Decimal, PoolSistema As String) As DataSet
        Try
            AbrirConexion()
            Return wsAdminSys.ObjetosJerarquiaDS(ObjetoInicial, PoolSistema)
        Catch
            Return Nothing
        Finally
            CerrarConexion()
        End Try
    End Function

End Class
