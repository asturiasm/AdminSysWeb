Imports System.Xml


Namespace SIGESWeb

    Partial Class frmMiPerfil
        Inherits System.Web.UI.Page
        Dim ws As clsSIGESProxyWrapper

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            ws = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            'Validando si la sesion ha expirado, de ser verdadero se procede a notificar al usuario.
            If clsUtil.ExpiroSesion(Session("usuario")) Then MensajeExpiraSesion()
            If Not IsPostBack() Then CargarDatos()
        End Sub

        Private Function CargarDataSet() As DataSet
            Dim strSQL As String
            Dim ds As New DataSet
            'Creando QUERY que obtendra datos de usuario
            strSQL = "SELECT * FROM AD_USUARIOS WHERE UPPER(USUARIO) ='" & Trim(Session("USUARIO")).ToUpper & "'"
            ds = ws.getDatabySQL(strSQL, True, "<p></p>", "AD_USUARIOS")
            Return ds
        End Function

        Private Sub CargarDatos()
            Dim dsdatos As DataSet
            dsdatos = CargarDataSet()
            'Cargando los datos del usuario en los textbox
            USUARIO.Text = Session("USUARIO")
            If Not IsNothing(dsdatos) AndAlso _
               dsdatos.Tables.Count > 0 AndAlso _
               dsdatos.Tables(0).Rows.Count = 1 Then
                With dsdatos.Tables(0).Rows(0)
                    If Not .IsNull("NIT") Then NIT.Text = .Item("NIT")
                    If Not .IsNull("TELEFONO") Then TELEFONO.Text = .Item("TELEFONO")
                    If Not .IsNull("DIRECCION") Then DIRECCION.Text = .Item("DIRECCION")
                    If Not .IsNull("EMAIL") Then EMAIL.Text = .Item("EMAIL")
                    If Not .IsNull("APELLIDOS") Then APELLIDOS.Text = .Item("APELLIDOS")
                    If Not .IsNull("NOMBRES") Then NOMBRES.Text = .Item("NOMBRES")
                End With
            End If
            dsdatos = Nothing
        End Sub

        Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click
            'Validando si la sesion ha expirado, de ser verdadero se procede a notificar al usuario.
            If clsUtil.ExpiroSesion(Session("usuario")) Then MensajeExpiraSesion()

            Dim dsactualizar As New DataSet
            Dim objenc As clsEncrypt.Encryption
            Dim respuesta, pass As String

            dsactualizar = CargarDataSet()

            If Not IsNothing(dsactualizar) AndAlso _
               dsactualizar.Tables.Count > 0 AndAlso _
               dsactualizar.Tables(0).Rows.Count > 0 Then
                objenc = New clsEncrypt.Encryption(CType(dsactualizar.Tables(0).Rows(0).Item("FECHA_CREACION"), Date).ToString("ssmmHHyyyyMMdd"))
                pass = objenc.DesEncriptarSTR(dsactualizar.Tables(0).Rows(0).Item("PASSWORD"))

                With dsactualizar.Tables(0).Rows(0)
                    .Item("NIT") = NIT.Text.Trim()
                    .Item("TELEFONO") = TELEFONO.Text.Trim()
                    .Item("DIRECCION") = DIRECCION.Text.Trim()
                    .Item("EMAIL") = EMAIL.Text.Trim()
                    .Item("PASSWORD") = pass
                    .Item("APELLIDOS") = APELLIDOS.Text.Trim()
                    .Item("NOMBRES") = NOMBRES.Text.Trim()
                End With

                respuesta = ws.DynamicTransaction(dsactualizar, "SIAFAdmin", "SIAFAdmin.clsCtrlAdmin", "ModificarUsuario", False, Nothing, Session("usuario"), "ad_usuarios", True, False)
                If respuesta = "OK" Then
                    Session("TieneMail") = "S"
                    Session("ParametrosMensaje") = clsUtil.BuildXMLMensaje("ACTUALIZACION DE DATOS", "Los datos han sido modificados satisfactoriamente. Por favor presione el boton Continuar.", True, "../general/Main.aspx", , "Continuar")
                    Response.Redirect("../general/frmMensajeGenerico.aspx")
                Else
                    Session("ParametrosMensaje") = clsUtil.BuildXMLMensaje("ERROR AL ACTUALIZAR DATOS", "No ha sido posible actualizar los datos el sistema. Error:" & respuesta, False)
                    Response.Redirect("../general/frmMensajeGenerico.aspx")
                End If
            End If

        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Metodo encargado de generar el mensaje de notificacion si la sesion expiro
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[cbarrera]	08/02/2007	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub MensajeExpiraSesion()
            Session("ParametrosMensaje") = clsUtil.BuildXMLMensaje("SESIÓN EXPIRADA", clsConstantes.errorSesionExpirada, True, "../login/frmLogin.htm", , "Volver a Ingresar")
            Response.Redirect("../general/frmMensajeGenerico.aspx")
        End Sub
    End Class
End Namespace
