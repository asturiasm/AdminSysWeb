Imports System.Web.UI.HtmlControls

Namespace SIGESWeb

    Partial Class frmMensajeError
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
            Dim mensaje As String = Session("MensajeError").ToString()
            Dim descripcion As String = "No hay Descripción"

            If InStr(Session("MensajeError"), "#") > 0 Then
                mensaje = Mid(Session("MensajeError"), 1, InStr(Session("MensajeError"), "#") - 1)
                descripcion = Mid(Session("MensajeError"), InStr(Session("MensajeError"), "#") + 1, Session("MensajeError").ToString().Length() - 1)
            Else
                mensaje = Session("MensajeError")
            End If


            Dim mensajeTag As HtmlGenericControl = New HtmlGenericControl("div")
            Dim descripcionTag As HtmlGenericControl = New HtmlGenericControl("div")

            mensajeTag.Attributes.Add("class", "mensajeDiv")
            mensajeTag.Attributes.Add("style", "display:none")
            descripcionTag.Attributes.Add("class", "descripcionDiv")
            descripcionTag.Attributes.Add("style", "display:none")

            Form.Controls.Add(mensajeTag)
            Form.Controls.Add(descripcionTag)

            mensajeTag.InnerHtml = mensaje
            descripcionTag.InnerHtml = descripcion

            'var listener = new Object();
            'var params = new Object();
            'var dialog = New SiafDialog())
            ''me.show(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
            'dialog.showError(msj.titulo,msj.mensaje,msj.descripcion,msj.detalle);

            MyBase.llamarScript("var botonera = CONSTANTES.INPUT_MODAL_BOTON_VOLVER|CONSTANTES.INPUT_MODAL_BOTON_DETALLES_ERROR;var nivel = CONSTANTES.INPUT_MODAL_NIVEL_ERROR;var listener = new Object();var params = new Object();params.detalleInfo = jQuery('.descripcionDiv').html();params.volver = function(){history.go(-1);};var factory = parent.SiafDialog;if (parent.parent.SiafDialog!=null){factory = parent.parent.SiafDialog};var dialog = new factory();dialog.show('Aviso','Mensaje de Error',jQuery('.mensajeDiv').html(),'detalle',botonera,nivel,params);")
        End Sub

    End Class

End Namespace
