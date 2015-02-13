Imports Microsoft.VisualBasic
Imports System.Web.UI.HtmlControls

Namespace SIGESWeb.PaginasBase
    ''' <summary>
    ''' Esta clase sustituiría a la actual estructura de páginas base, la principal diferencia es eliminar el overhead que los objetos de pagina base anterior
    ''' contienen por su vinculación con los componentes de arquitectura 
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class clsPaginaBase
        Inherits clsPaginaCore

        Public Const INPUT_MODAL_TIPO As String = "INPUT_MODAL_TIPO"
        Public Const INPUT_MODAL_NIVEL As String = "INPUT_MODAL_NIVEL"
        Public Const cINPUT_MODAL_CONFIRMACION_ID As String = "INPUT_MODAL_CONFIRMACION_ID"
        Public Const cBUTTON_MODAL_CONFIRMAR As String = "BUTTON_MODAL_CONFIRMAR"
        Public Const MODAL_ERROR_DIV As String = "MODAL_ERROR_DIV"
        Public Const MODAL_ERROR_LINK_DIV As String = "MODAL_ERROR_LINK_DIV"
        Public Const MODAL_INPUT_MENSAJE As String = "MODAL_INPUT_MENSAJE"
        Public Const MODAL_INPUT_MENSAJE_DETALLES As String = "MODAL_INPUT_MENSAJE_DETALLES"


        Protected Sub showInfo(ByVal titulo As String, ByVal detalle As String, ByVal volver As Boolean, ByVal aceptar As Boolean)
            SetModalMensaje(titulo)
            SetModalMensajeDetalle(detalle)
            SetModalTipo((PaginaBase.INPUT_MODAL_BOTON_ACEPTAR And aceptar) Or (PaginaBase.INPUT_MODAL_BOTON_VOLVER And volver), PaginaBase.INPUT_MODAL_NIVEL_INFO)
        End Sub

        Protected Sub showError(ByVal titulo As String, ByVal detalle As String, ByVal exception As String, ByVal volver As Boolean, ByVal aceptar As Boolean, ByVal cancelar As Boolean, Optional ByVal link As String = "")
            SetModalMensaje(titulo)
            SetModalMensajeDetalle(detalle)
            AgregarError(exception, link)
            SetModalTipo(PaginaBase.INPUT_MODAL_BOTON_DETALLES_ERROR Or (PaginaBase.INPUT_MODAL_BOTON_CANCELAR And cancelar) Or (PaginaBase.INPUT_MODAL_BOTON_ACEPTAR And aceptar) Or (PaginaBase.INPUT_MODAL_BOTON_VOLVER And volver), PaginaBase.INPUT_MODAL_NIVEL_ERROR)
        End Sub

        Protected Sub showConfirmacion(ByVal titulo As String, ByVal detalle As String, ByVal volver As Boolean, ByVal aceptar As Boolean, ByVal cancelar As Boolean, _
                                       ByVal confirmarCampo As Control, ByVal confirmarButton As Control)
            SetModalMensaje(titulo)
            SetModalMensajeDetalle(detalle)
            Dim confirmarId As HiddenField = Page.FindControl(cINPUT_MODAL_CONFIRMACION_ID)
            Dim button As HiddenField = Page.FindControl(cBUTTON_MODAL_CONFIRMAR)
            confirmarId.Value = confirmarCampo.ClientID
            button.Value = confirmarButton.ClientID
            SetModalTipo((PaginaBase.INPUT_MODAL_BOTON_CONFIRMAR) Or (PaginaBase.INPUT_MODAL_BOTON_CANCELAR), PaginaBase.INPUT_MODAL_NIVEL_INFO)
        End Sub
        Protected Sub AgregarError(ByVal errorMsg As String, ByVal errorLink As String)
            Dim errorDiv As HtmlGenericControl = Form.FindControl(MODAL_ERROR_DIV)
            if IsNothing(errorDiv) then
                errorDiv = New HtmlGenericControl("div")
                errorDiv.Style.Add("display", "none")
                errorDiv.ID = MODAL_ERROR_DIV
                errorDiv.InnerHtml = errorMsg
                Form.Controls.Add(errorDiv)
            Else
                errorDiv.InnerHtml = errorMsg
            End If
            Dim errorLinkDiv As HtmlGenericControl = Form.FindControl(MODAL_ERROR_LINK_DIV)
            if IsNothing(errorLinkDiv) then
                errorLinkDiv = New HtmlGenericControl("div")
                errorLinkDiv.Style.Add("display", "none")
                errorLinkDiv.ID = MODAL_ERROR_LINK_DIV
                errorLinkDiv.InnerHtml = errorLink
                Form.Controls.Add(errorLinkDiv)
            Else
                errorLinkDiv.InnerHtml = errorLink
            End If
            Me.SetModalTipo(PaginaBase.INPUT_MODAL_BOTON_ACEPTAR Or PaginaBase.INPUT_MODAL_BOTON_DETALLES_ERROR,
                            PaginaBase.INPUT_MODAL_NIVEL_ERROR)
        End Sub

        Private Sub SetModalMensaje(ByVal value As String)
            Dim messageValue As HiddenField = Page.FindControl(MODAL_INPUT_MENSAJE)
            messageValue.Value = value
        End Sub

        Private Sub SetModalMensajeDetalle(ByVal value As String)
            Dim messageValue As HiddenField = Page.FindControl(MODAL_INPUT_MENSAJE_DETALLES)
            messageValue.Value = value
        End Sub

        Private Sub SetModalTipo(ByVal value As Integer, ByVal tipo As String)
            Dim messageValue As HiddenField = Page.FindControl(INPUT_MODAL_TIPO.ToString)
            Dim nivelValue As HiddenField = Page.FindControl(INPUT_MODAL_NIVEL)
            messageValue.Value = value
            nivelValue.Value = tipo
        End Sub

        Public Overrides Function FindControl(ByVal id As String) As System.Web.UI.Control
            Dim Control As System.Web.UI.Control

            Control = MyBase.FindControl(id)
            If IsNothing(Control) Then 'Buscando control dentro de la página master
                Control = Master.FindControl(id)
            End If
            Return Control
        End Function

        Protected Function ShouldApplySortFilterOrGroup(ByRef Grid As Telerik.Web.UI.RadGrid) As Boolean
            Return Grid.MasterTableView.FilterExpression <> "" OrElse _
                   Grid.MasterTableView.GroupByExpressions.Count > 0 OrElse _
                   Grid.MasterTableView.SortExpressions.Count > 0
        End Function

        Protected Function startIndex(ByRef Grid As Telerik.Web.UI.RadGrid) As Integer
            Return If(ShouldApplySortFilterOrGroup(Grid), 0, Grid.CurrentPageIndex * Grid.PageSize)
        End Function

        Protected Function maxRows(ByRef Grid As Telerik.Web.UI.RadGrid) As Integer
            Return If(ShouldApplySortFilterOrGroup(Grid), Integer.MaxValue, Grid.PageSize)
        End Function

        Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
            If clsUtil.ExpiroSesion(Session("usuario")) Then
                MensajeExpiraSesion2()
            End If
        End Sub
        Protected Overridable Sub MensajeExpiraSesion2()
            Session("ParametrosMensaje") = clsUtil.BuildXMLMensaje("SESIÓN EXPIRADA", clsConstantes.errorSesionExpirada, True, "../login/frmLogin.aspx", , "Volver a Ingresar")
            Response.Redirect("~/general/frmMensajeGenerico.aspx")
        End Sub
    End Class
End Namespace