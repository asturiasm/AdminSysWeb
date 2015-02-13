Imports System.Xml


Namespace SIGESWeb
    Partial Class frmCambioPWD
        Inherits System.Web.UI.Page

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página
            If Not IsPostBack Then
                Label1.Text = Session("Usuario")
            End If
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
            Dim strRespuesta As String = ""
            Try
                Dim ds As New DataSet()
                ds = ws.getDatabySQL("Select * from ad_usuarios where UPPER(USUARIO) = '" & UCase(Trim(Session("Usuario"))) & "'", True, "<p></p>", "ad_usuarios")

                ds.Tables(0).Rows(0).Item("password") = TxtClaveNueva.Text

                strRespuesta = ws.DynamicTransaction(ds, "SIAFAdmin", "SIAFAdmin.clsCtrlAdmin", "ModificarPassword", False, Nothing, Session("usuario"), "ad_usuarios", True, True)
            Catch ex As Exception
                If ex.Message = "Thread was being aborted." Then
                    'Session("ParametrosMensaje") = clsUtil.BuildXMLMensaje("CAMBIO DE CONTRASEÑA", "La contraseña ha sido actualizada. Debe ingresar nuevamente al sistema", True, "../login/frmLogout.aspx", , "Volver a Ingresar")
                    If strRespuesta = "OK" Then
                        Response.Redirect("frmMensajeGenerico.aspx")
                    Else
                        Response.Redirect("../general/frmMensajeError.aspx")
                    End If

                    'clsUtil.Redirect(Server, Response,"frmMensajeGenerico.aspx")
                Else
                    ws = Nothing
                    Session("ParametrosMensaje") = clsUtil.BuildXMLMensaje("CAMBIO DE CONTRASEÑA", "ERROR EN EL CAMBIO DE CONTRASEÑA", True, "frmCambioPWD.aspx")
                    Response.Redirect("frmMensajeGenerico.aspx")

                End If
            End Try


            If strRespuesta = "OK" Then
                ws.LogOff(Session("Usuario"))
                Session("ParametrosMensaje") = clsUtil.BuildXMLMensaje("CAMBIO DE CONTRASEÑA", "La contraseña ha sido actualizada. Debe ingresar nuevamente al sistema", True, "../login/frmLogin.htm", , "Volver a Ingresar")
                If Session("ClaveSecreto") Then
                    Session("ClaveSecreto") = False
                End If
                Response.Redirect("frmMensajeGenerico.aspx")

            Else
                Session("MensajeError") = strRespuesta
                Response.Redirect("../general/frmMensajeError.aspx")

            End If


        End Sub

    End Class

End Namespace
