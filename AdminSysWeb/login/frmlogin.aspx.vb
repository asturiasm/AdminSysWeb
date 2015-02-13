Imports System.Xml
Imports System.Web.Security

Namespace SIGESWeb
    Partial Class frmlogin
        Inherits System.Web.UI.Page

        Private Sub validarLogonGenerico(ByVal usuario As String)
            If Not usuario Is Nothing Then
                LogON(usuario, usuario)
            End If
        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not IsPostBack Then

                If Request.Url.LocalPath <> Request.Url.PathAndQuery Then
                    Response.Redirect("frmlogin.aspx")
                End If
            End If
#If Debug Then
                                                 TxtUsuario.Text = "sias"
                                                 TxtPassword.Text = "secreto"
                                                 Button1_Click(Nothing, Nothing)
                                                'TxtUsuario.Focus()

#End If
        End Sub

        Private Sub LogON(ByVal strUser As String, ByVal strPass As String)
            Dim wsServicio As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
            Try
                Dim intError As Integer

                intError = wsServicio.LogIN(strUser, strPass, Session.SessionID)

                If intError = 0 Then
                    FormsAuthentication.SetAuthCookie(strUser, False)
                    Dim dsuser As New DataSet
                    Dim param As New System.Xml.XmlDocument

                    dsuser = wsServicio.getDatabySQL("SELECT NOMBRE, APELLIDOS, NOMBRES FROM AD_USUARIOS WHERE UPPER(USUARIO) = '" & strUser.ToUpper & "'", True, "<p></p>", "AD_USUARIOS")
                    If Not IsNothing(dsuser) AndAlso _
                        dsuser.Tables.Count > 0 AndAlso _
                        dsuser.Tables(0).Rows.Count > 0 Then
                        Session("NombreUsuario") = dsuser.Tables(0).Rows(0).Item("NOMBRE")
                        Session("Usuario") = strUser.ToUpper
                        Session("CambiaClave") = wsServicio.puedeCambiarClave(strUser.ToUpper)

                        If (wsServicio.expiraTiempoClave(strUser.ToUpper, System.Configuration.ConfigurationManager.AppSettings("duracion_password")) AndAlso (Session("CambiaClave"))) Then
                            Response.Redirect("../general/frmCambioPWD.aspx")
                        End If

                        Session("CondicionAcceso") = ""
                        Session("FechaHoraIngreso") = Now
                        param.LoadXml(CType(Application("GLOBAL_PARAMETROS"), XmlDocument).InnerXml)
                        Session("PARAMETROS") = param
                        Session("OBJETO_RAIZ") = "00810922"
                        Session("OBJINI") = "00800760"
                        Session("MANTV2") = "S"
                        wsServicio.ActualizarSesionUsuario(strUser.ToUpper, Now)
                        clsUtil.agregarParametroVAL(param, strUser.ToUpper, "USUARIO", "C")
                        clsUtil.agregarParametroVAL(param, "7", "ENTIDAD", "N")
                        clsUtil.agregarParametroVAL(param, "0", "UNIDAD_EJECUTORA", "N")
                        clsUtil.agregarParametroVAL(param, "0", "UNIDAD_DESCONCENTRADA", "N")

                        If IsDBNull(dsuser.Tables(0).Rows(0).Item("APELLIDOS")) OrElse _
                           IsDBNull(dsuser.Tables(0).Rows(0).Item("NOMBRES")) Then
                            Response.Redirect("../include/frmMiPerfil.aspx", False)
                        Else
                            Response.Redirect("../general/main.aspx", False)
                        End If
                    Else
                        dsuser.Tables(0).Rows(0).IsNull(0)
                        Response.Redirect("errLogin.aspx?ec=-1", False)
                    End If
                    dsuser = Nothing
                Else
                    Response.Redirect("errLogin.aspx?ec=" & intError, False)
                End If
            Catch ex As Exception
                lblError.Text = "Ocurrio un error al intentar acceder a la aplicación, por favor notifique al equipo de Soporte si el inconveniente perdura más de 5 minutos"
                SIGESWeb.clsUtil.MensajeLog("AppNet", ex.ToString, SIGESWeb.clsConstantesCategoria.Login, SIGESWeb.clsConstantesSubCategoria.ErroresNoControlados)
            End Try
        End Sub

        Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
            LogON(TxtUsuario.Text, TxtPassword.Text)
        End Sub
    End Class
End Namespace
