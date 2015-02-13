Namespace SIGESWeb
    Partial Class errLogin
        Inherits System.Web.UI.Page

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página
            Dim interror As Integer = CInt(Request.QueryString("ec"))

            Select Case interror
                Case clsConstantes.ErrNoExisteUsr : Lbl_Error.Text = "No existe el usuario."
                Case clsConstantes.ErrUsrEnSesion : Lbl_Error.Text = "El usuario se encuentra en otra sesi&oacute;n."
                Case clsConstantes.ErrClaveInvalida : Lbl_Error.Text = "Clave inv&aacute;lida."
                Case clsConstantes.ErrSesionExpirada : Lbl_Error.Text = "La sesi&oacute;n ha expirado, debe volver a ingresar al sistema."
                Case clsConstantes.ErrOrigenInvalido : Lbl_Error.Text = "El Origen de la sesi&oacute;n es inv&aacute;lido."
                Case clsConstantes.ErrUsuarioInactivo : Lbl_Error.Text = "El usuario se encuentra inactivo."
                Case clsConstantes.ErrUsuarioSinPermiso : Lbl_Error.Text = "El usuario no tiene permiso para ejecutora esta aplicaci&oacute;n."
                Case clsConstantes.ErrEntradasNoValidas : Lbl_Error.Text = "El sistema detecto entradas de datos no validas en esta aplicaci&oacute;n."

                Case Else : Lbl_Error.Text = "Error Desconocido"
            End Select
        End Sub

        Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
            Response.Redirect("frmLogin.htm")
        End Sub
    End Class

End Namespace
