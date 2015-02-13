Imports Microsoft.VisualBasic

Namespace SIGESWeb.PaginasBase
    Public MustInherit Class clsPaginaCore
        Inherits System.Web.UI.Page

        Private Sub PageLoadBase(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            validarSession()
        End Sub

        Protected Overridable Sub validarSession()
            If clsUtil.ExpiroSesion(Session("usuario")) Then
                MensajeExpiraSesion()
            End If
        End Sub

        Protected Overridable Sub MensajeExpiraSesion()
            If Page.IsCallback = False Then Response.Redirect("~/login/frmLogin.aspx")
        End Sub
    End Class
End Namespace