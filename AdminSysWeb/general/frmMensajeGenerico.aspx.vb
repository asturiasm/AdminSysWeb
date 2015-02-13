Namespace SIGESWeb

Partial Class frmMensajeGenerico
        Inherits PaginaBase

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
            Dim oxml As New System.Xml.XmlDocument()

            If Not Session("ParametrosMensaje") Is Nothing Then
                oxml = Session("ParametrosMensaje")
                LblMensaje.Text = oxml.SelectSingleNode("MENSAJE/TEXTO").InnerText
                LblTitulo.Text = oxml.SelectSingleNode("MENSAJE/TITULO").InnerText
                If oxml.SelectSingleNode("MENSAJE/REGRESAR").InnerText = "N" Then
                    LinkButton1.Visible = False
                Else
                    LinkButton1.Text = "Regresar"
                End If

                If Not oxml.SelectSingleNode("MENSAJE/TEXTOLINK") Is Nothing Then
                    LinkButton1.Text = oxml.SelectSingleNode("MENSAJE/TEXTOLINK").InnerText
                End If
            End If

            oxml = Nothing
        End If
        End Sub

        Protected Overrides Sub MensajeExpiraSesion()
            
        End Sub


    Private Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Dim strLink As String
        Dim oxml As New System.Xml.XmlDocument()

        If Not Session("ParametrosMensaje") Is Nothing Then
            oxml = Session("ParametrosMensaje")
            strLink = oxml.SelectSingleNode("MENSAJE/LINK").InnerText

            If Not oxml.SelectSingleNode("MENSAJE/PARAMETROS") Is Nothing Then
                strLink = strLink & "?" & oxml.SelectSingleNode("MENSAJE/PARAMETROS").InnerText
            End If

            'Response.Redirect(strLink)
            Response.Write("<script language=""javascript"">")
            Response.Write("parent.parent.location.href='" & strLink & "';")
            Response.Write("</script>")
        End If

    End Sub
End Class

End Namespace
