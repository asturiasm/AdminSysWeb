Imports System.Net.Mail
Imports SIGESWeb

Namespace SIGESWeb
    Partial Class frmContactenos
        Inherits SIGESWeb.PaginaBase

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No lo modifique con el editor de código.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página

            If Not IsPostBack Then
                DDLPrioridad.Items.Add(New System.Web.UI.WebControls.ListItem("Baja", "Baja"))
                DDLPrioridad.Items.Add(New System.Web.UI.WebControls.ListItem("Normal", "Normal"))
                DDLPrioridad.Items.Add(New System.Web.UI.WebControls.ListItem("Alta", "Alta"))
                ViewState("Client_id") = Request.Params("CLIENT_ID")
            End If
        End Sub

        Private Sub BtnEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnviar.Click
            Dim objMail As New MailMessage
            Dim objFrom As MailAddress
            Dim objSmptMail As New SmtpClient(clsConstantes.C_SERVIDOR_MAIL)
            
            objFrom = New MailAddress(TxtEmail.Text, TxtEmail.Text, System.Text.Encoding.UTF8)
            objMail.From = objFrom
            objMail.IsBodyHtml = True
            Select Case Request.QueryString("Contacto")
                Case "CENTRAL" : objMail.To.Add(clsConstantes.C_EMAIL_CONTACTENOS)
                Case "DESCENT" : objMail.To.Add(clsConstantes.C_EMAIL_CONTACTENOS_DESCENT)
                Case "INVENTA" : objMail.To.Add(clsConstantes.C_EMAIL_CONTACTENOS_INVENTA)
                Case "SIGES" : objMail.To.Add(clsConstantes.C_EMAIL_CONTACTENOS_SIGES)
            End Select
            objMail.Subject = TxtAsunto.Text

            Select Case DDLPrioridad.SelectedItem.Text
                Case "Normal" : objMail.Priority = MailPriority.Normal
                Case "Baja" : objMail.Priority = MailPriority.Low
                Case "Alta" : objMail.Priority = MailPriority.High
            End Select

            objMail.BodyEncoding = System.Text.Encoding.UTF8
            objMail.Body = TxtMensaje.Text & vbCrLf & vbCrLf & TxtNombre.Text

            objSmptMail.Send(objMail)
            'Session("ParametrosMensaje") = clsUtil.BuildXMLMensaje("Envío de Mensajes", "Mensaje enviado exitosamente", True, "frmContactenos.aspx")
            'Response.Redirect("frmMensajeGenerico.aspx")

            MyBase.llamarScript("parent.cerrarIframe('" + ViewState("Client_id") + "','Mensaje enviado exitosamente')")


        End Sub
    End Class

End Namespace
