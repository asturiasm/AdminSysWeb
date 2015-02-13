Imports System
Imports Microsoft.VisualBasic
Imports System.Web.UI
Imports SIGESWeb
Imports System.Collections
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Web.UI.WebControls
Imports System.Data

Namespace SIGESWeb
    Public Class PaginaBase
        Inherits System.Web.UI.Page
        Protected ws As clsSIGESProxyWrapper
        Protected Shared queries As Specialized.StringDictionary = Nothing


        Public Const QUERY_MANAGER As String = "PAGINA_BASE.QUERY_MANAGER"
        Public Const QUERIES_MANAGER As String = "PAGINA_BASE.QUERIES_MANAGER"


        Public Const INPUT_CONSULTA As String = "INPUT_CONSULTA"


        Public Const LABEL_MENSAJE_ESPERA As String = "LBL_MENSAJE_ESPERA"
        Public Const INPUT_MENSAJE_ESPERA As String = "INPUT_MENSAJE_ESPERA"
        Public Const INPUT_MODAL_TIPO As String = "INPUT_MODAL_TIPO"
        Public Const INPUT_MODAL_NIVEL As String = "INPUT_MODAL_NIVEL"
        Public Const INPUT_MODAL_CONFIRMAR As String = "INPUT_MODAL_CONFIRMAR"
        Public Const INPUT_MODAL_PROGRESSBAR_KEY As String = "INPUT_MODAL_PROGRESSBAR_KEY"
        Public Const INPUT_MODAL_CONFIRMACION_ID As String = "INPUT_MODAL_CONFIRMACION_ID"
        Public Const BUTTON_MODAL_CONFIRMAR As String = "BUTTON_MODAL_CONFIRMAR"
        Public Const MODAL_GOTO_PAGE As String = "MODAL_GOTO_PAGE"
        Public Const MODAL_ERROR_DIV As String = "MODAL_ERROR_DIV"
        Public Const MODAL_ERROR_LINK_DIV As String = "MODAL_ERROR_LINK_DIV"

        Public Const INPUT_MODAL_NIVEL_INFO As String = "INPUT_MODAL_NIVEL.INFO"
        Public Const INPUT_MODAL_NIVEL_WARNING As String = "INPUT_MODAL_NIVEL.WARNING"
        Public Const INPUT_MODAL_NIVEL_ERROR As String = "INPUT_MODAL_NIVEL.ERROR"

        Public Const INPUT_MODAL_BOTON_ACEPTAR As Integer = 1
        Public Const INPUT_MODAL_BOTON_CANCELAR As Integer = 2
        Public Const INPUT_MODAL_BOTON_CONFIRMAR As Integer = 4
        Public Const INPUT_MODAL_BOTON_PROGRESS_BAR As Integer = 8
        Public Const INPUT_MODAL_BOTON_CERRAR As Integer = 16
        Public Const INPUT_MODAL_BOTON_VOLVER As Integer = 32
        Public Const INPUT_MODAL_BOTON_DETALLES_ERROR As Integer = 64

        Public Const MODAL_INPUT_MENSAJE As String = "MODAL_INPUT_MENSAJE"
        Public Const MODAL_INPUT_MENSAJE_DETALLES As String = "MODAL_INPUT_MENSAJE_DETALLES"
        Public Const MODAL_LABEL_MENSAJE As String = "MODAL_LABEL_MENSAJE"
        Public Const MODAL_LABEL_MENSAJE_DETALLES As String = "MODAL_LABEL_MENSAJE_DETALLES"
        Public Const DIV_ID_AJAX_WAITING As String = "div_ajax_waiting"
        Public Const DIV_ID_AJAX_TAPA1 As String = "div_ajax_tapa1"
        Public Const DIV_ID_AJAX_TAPA2 As String = "div_ajax_tapa2"
        Public Const TIMER_ID_AJAX_WAITING As String = "nmf_ajax_my_timer"
        Public Const TIMER_ID_AJAX_WAITING2 As String = "nmf_ajax_my_timer"


        Public Const BUTTON_SALIR_ID As String = "BTN_SALIR_ID"

        Protected Sub setQueryManager(ByRef pagina As String)
            Dim queryManager As QueryManager = getQueryManager(pagina)
            ViewState(QUERY_MANAGER) = queryManager
        End Sub
        Protected Function getQueryManager() As QueryManager
            Dim queryManager As QueryManager = ViewState(QUERY_MANAGER)
            Return queryManager
        End Function

        Protected Function getQueryManager(ByVal name As String) As QueryManager
            Dim queriesManager As Hashtable = MyBase.ViewState(QUERIES_MANAGER)
            ''CARGAR EL HASH MAP
            If (queriesManager Is Nothing) Then
                queriesManager = New Hashtable()
                MyBase.ViewState.Add(QUERIES_MANAGER, queriesManager)
            End If

            If queriesManager.ContainsKey(name) Then
                Return queriesManager(name)
            End If
            Try
                Dim queryManager As QueryManager = New QueryManager(Server, name)
                queriesManager.Add(name, queryManager)
                Return queryManager
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Private Sub PageLoadBase(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ''comentarios
            ''handle salir


            If ViewState(QUERY_MANAGER) Is Nothing Then
                Dim queryManager As QueryManager = New QueryManager(Server, Request.ServerVariables("PATH_TRANSLATED").Replace(Server.MapPath("~/"), ""))
                ViewState.Add(QUERY_MANAGER, queryManager)
            End If
        End Sub


        Private Sub PageInitBase(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            ws = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
            Dim tokenInput As HiddenField = New HiddenField
            tokenInput.Value = GetNextToken()
            ''tokenInput.Visible = False


            ''Si tengo boton salir
            Dim btnSalir As ImageButton = FindControlByID(BUTTON_SALIR_ID)

            If Not btnSalir Is Nothing Then
                ''Aplicar Handler
                AddHandler btnSalir.Click, AddressOf Salir_Click_Handler
            End If




            If Not Form Is Nothing Then
                If ScriptManager.GetCurrent(Page) Is Nothing Then
                    Dim sMgr As ScriptManager = New ScriptManager()
                    Form.Controls.Add(sMgr)
                End If

                tokenInput.ID = "TXT_TOKEN_VALUE"
                Form.Controls.Add(tokenInput)
                obtenerXML()
                AgregarComponentesDeEsperar()

                ''Registrar el Salir en el Link Volver desde el BOTOn con ID salir
                Me.llamarScript("addSalirEnVolver();")
                Dim val As String = ""
            End If

        End Sub



        Protected Function EjecutarQueryByParams(ByVal dsDatos As DataSet, ByVal Assembly As String, ByVal Instancia As String, ByVal Metodo As String, ByVal name As String, ByVal ejercicio As Decimal, ByVal entidad As Decimal, ByVal unidadEjecutora As Decimal) As DataSet
            Try
                Dim dt As DataTable = New DataTable()
                dt.TableName = "QUERY_PARAMS"
                dsDatos.Tables.Add(dt)
                dt.Columns.Add("QUERY_NAME", name.GetType)
                dt.Columns.Add("EJERCICIO", ejercicio.GetType)
                dt.Columns.Add("ENTIDAD", entidad.GetType)
                dt.Columns.Add("UNIDAD_EJECUTORA", unidadEjecutora.GetType)

                Dim dr As DataRow = dt.NewRow
                dt.Rows.Add(dr)
                dr.Item(0) = name
                dr.Item(1) = ejercicio
                dr.Item(2) = entidad
                dr.Item(3) = unidadEjecutora

                Dim value As String = ws.DynamicTransaction(dsDatos, Assembly, Instancia, Metodo, True, "DS", Session("usuario"), "NMF_POLITICA", False, True)
                Dim ds As DataSet = New DataSet()
                Dim reader As System.IO.StringReader = New System.IO.StringReader(value)

                ds.ReadXml(reader)
                Return ds

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function ejecutarQueryByName(ByVal nombre As String, ByVal ejercicio As Decimal, ByVal entidad As Decimal, ByVal unidadEjecutora As Decimal, Optional ByVal unidadDesconcentrada As Decimal = 0D) As DataSet
            Dim sql As String = getQueryManager().getQuery(nombre)
            sql = sql.Replace(":pejercicio", ejercicio)
            sql = sql.Replace(":pentidad", entidad)
            sql = sql.Replace(":p_unidad_ejecutora", unidadEjecutora)
            sql = sql.Replace(":p_unidad_desconcentrada", unidadDesconcentrada)
            Dim ds As DataSet = ws.getDatabySQL(sql, False, "<p></p>", "OC_UNIDAD_COMPRADORA")
            Return ds
        End Function
        Public Function ejecutarQueryByNameWithParams(ByVal nombre As String, ByVal ejercicio As Decimal, ByVal entidad As Decimal, ByVal unidadEjecutora As Decimal, ByRef params As Hashtable) As DataSet
            Dim sql As String = ObtenerSqlString(nombre, ejercicio, entidad, unidadEjecutora, params)
            Dim ds As DataSet = ws.getDatabySQL(sql, False, "<p></p>", "OC_UNIDAD_COMPRADORA")
            Return ds
        End Function

        Public Function ObtenerSqlString(ByVal nombre As String, ByVal ejercicio As Decimal, ByVal entidad As Decimal, ByVal unidadEjecutora As Decimal, ByRef params As Hashtable) As String
            Dim sql As String = getQueryManager().getQuery(nombre)
            sql = sql.Replace(":pejercicio", ejercicio)
            sql = sql.Replace(":pentidad", entidad)
            sql = sql.Replace(":p_unidad_ejecutora", unidadEjecutora)
            ''Comentarios...
            If (Not params Is Nothing) Then
                For Each param As String In params.Keys
                    sql = sql.Replace(param, params(param))
                Next
            End If
            Return sql
        End Function
        Public Overloads Function getQueriesBase(ByVal xml As String, ByVal AssemblyName As String, ByVal Metodo As String) As Specialized.StringDictionary
            ''If queries Is Nothing Then
            Try
                Dim queries As Specialized.StringDictionary = New Specialized.StringDictionary

                Dim xmlString As String = ws.DynamicTransaction(Nothing, AssemblyName, Metodo, xml, True, "C", Session("usuario"), "Datos", False, True)

                Dim xmlDoc As XmlDataSource

                xmlDoc = New XmlDataSource()

                ''xmlDoc.Data = Nothing
                ''xmlDoc.Data = xmlString

                Dim rs As System.Xml.XmlDocument = New System.Xml.XmlDocument
                ''xmlDoc.EnableCaching = False

                rs.LoadXml(xmlString)

                Dim i As Integer = 0
                Dim name As String
                Dim value As String


                While i < rs.ChildNodes.Item(1).ChildNodes.Count
                    name = rs.ChildNodes.Item(1).ChildNodes(i).ChildNodes(0).FirstChild.Value
                    value = rs.ChildNodes.Item(1).ChildNodes(i).ChildNodes(1).FirstChild.Value
                    queries.Add(name, value)
                    i = i + 1
                End While

                Return queries

            Catch ex As Exception
                Return Nothing
            End Try
            '' End If

            Return Nothing
        End Function

        Protected Sub showInfo(ByVal titulo As String, ByVal detalle As String, ByVal volver As Boolean, ByVal aceptar As Boolean)
            SetModalMensaje(titulo)
            SetModalMensajeDetalle(detalle)
            SetModalTipo((PaginaBase.INPUT_MODAL_BOTON_ACEPTAR And aceptar) Or (PaginaBase.INPUT_MODAL_BOTON_VOLVER And volver), PaginaBase.INPUT_MODAL_NIVEL_INFO)
        End Sub


        Protected Sub showWarning(ByVal titulo As String, ByVal detalle As String, ByVal volver As Boolean, ByVal aceptar As Boolean, ByVal cancelar As Boolean)
            SetModalMensaje(titulo)
            SetModalMensajeDetalle(detalle)
            SetModalTipo((PaginaBase.INPUT_MODAL_BOTON_CANCELAR And cancelar) Or (PaginaBase.INPUT_MODAL_BOTON_ACEPTAR And aceptar) Or (PaginaBase.INPUT_MODAL_BOTON_VOLVER And volver), PaginaBase.INPUT_MODAL_NIVEL_WARNING)
        End Sub
        Protected Sub showError(ByVal titulo As String, ByVal detalle As String, ByVal exception As String, ByVal volver As Boolean, ByVal aceptar As Boolean, ByVal cancelar As Boolean, Optional ByVal link As String = "")
            SetModalMensaje(titulo)
            SetModalMensajeDetalle(detalle)

            AgregarError(exception, link)

            SetModalTipo(PaginaBase.INPUT_MODAL_BOTON_DETALLES_ERROR Or (PaginaBase.INPUT_MODAL_BOTON_CANCELAR And cancelar) Or (PaginaBase.INPUT_MODAL_BOTON_ACEPTAR And aceptar) Or (PaginaBase.INPUT_MODAL_BOTON_VOLVER And volver), PaginaBase.INPUT_MODAL_NIVEL_ERROR)
        End Sub
        Protected Sub showCustomError(ByVal titulo As String, ByVal detalle As String, ByVal exception As String, ByVal volver As Boolean, ByVal aceptar As Boolean, ByVal cancelar As Boolean)

        End Sub
        Protected Sub showConfirmacion(ByVal titulo As String, ByVal detalle As String, ByVal confirmarCampo As Control, ByVal confirmarButton As Control)
            SetModalMensaje(titulo)
            SetModalMensajeDetalle(detalle)
            ''"
            ''Public Const BUTTON_MODAL_CONFIRMAR As String = ""
            Dim confirmarId As HiddenField = Page.FindControl(INPUT_MODAL_CONFIRMACION_ID)
            Dim button As HiddenField = Page.FindControl(BUTTON_MODAL_CONFIRMAR)

            confirmarId.Value = confirmarCampo.ClientID
            button.Value = confirmarButton.ClientID

            SetModalTipo((PaginaBase.INPUT_MODAL_BOTON_CONFIRMAR) Or (PaginaBase.INPUT_MODAL_BOTON_CANCELAR), PaginaBase.INPUT_MODAL_NIVEL_INFO)
        End Sub
        Protected Sub showProgressBar(ByVal titulo As String, ByVal detalle As String)
            SetModalMensaje(titulo)
            SetModalMensajeDetalle(detalle)
        End Sub

        Protected Function IniciarProgressBar(ByVal titulo As String, ByVal detalle As String, ByVal key As String) As SigesAsincSate
            Dim asinc As SigesAsincSate = New SigesAsincSate()
            showProgressBar(titulo, detalle)
            Dim messageValue As HiddenField = Page.FindControl(PaginaBase.INPUT_MODAL_PROGRESSBAR_KEY)
            Session(key) = asinc
            messageValue.Value = key
            SetModalTipo(INPUT_MODAL_BOTON_PROGRESS_BAR, INPUT_MODAL_NIVEL_INFO)
            Return asinc
        End Function

        Protected Sub SetMensajeEspera(ByVal value As String)
            Dim messageValue As HiddenField = Page.FindControl(INPUT_MENSAJE_ESPERA)
            messageValue.Value = value
            SetModalTipo(INPUT_MODAL_BOTON_CERRAR, INPUT_MODAL_NIVEL_INFO)
            SetModalMensaje(value)
        End Sub

        Protected Sub SetModalMensaje(ByVal value As String)
            Dim messageValue As HiddenField = Page.FindControl(MODAL_INPUT_MENSAJE)
            messageValue.Value = value
        End Sub

        Protected Sub SetModalMensajeDetalle(ByVal value As String)
            Dim messageValue As HiddenField = Page.FindControl(MODAL_INPUT_MENSAJE_DETALLES)
            messageValue.Value = value

        End Sub

        Protected Sub SetModalTipo(ByVal value As Integer, ByVal tipo As String)
            Dim messageValue As HiddenField = Page.FindControl(INPUT_MODAL_TIPO.ToString)
            Dim nivelValue As HiddenField = Page.FindControl(INPUT_MODAL_NIVEL)
            messageValue.Value = value
            nivelValue.Value = tipo
        End Sub

        Protected Function getModalConfirmar() As Boolean
            Dim messageValue As HiddenField = Page.FindControl(INPUT_MODAL_CONFIRMAR.ToString)
            Dim nivelValue As HiddenField = Page.FindControl(INPUT_MODAL_NIVEL)
            If messageValue.Value.ToLower = "true" Then
                messageValue.Value = "false"
                Return True
            End If
            messageValue.Value = "false"
            Return False
        End Function


        ''Agregar Componentes para Envio Asincronico
        Protected Sub enableModalTimer()
            Dim timer As Timer = Page.FindControl("MODAL_TIMER_ID")
            ''Modo progress bar cuando se habilita Timer
            SetModalTipo(INPUT_MODAL_BOTON_PROGRESS_BAR, INPUT_MODAL_NIVEL_INFO)
            timer.Enabled = True
        End Sub
        Protected Sub disableModalTimer()
            Dim timer As Timer = Page.FindControl("MODAL_TIMER_ID")
            ''quitar Modo progress bar cuando se habilita Timer
            SetModalTipo(INPUT_MODAL_BOTON_CERRAR, INPUT_MODAL_NIVEL_INFO)
            timer.Enabled = False
        End Sub

        Protected Sub setModalTimerInverval(ByVal value As Integer)
            Dim timer As Timer = Page.FindControl("MODAL_TIMER_ID")
            timer.Interval = value
        End Sub

        Protected Sub setConsultaAsp(ByVal value As String)
            Dim inputConsulta As HiddenField = Page.FindControl(INPUT_CONSULTA)
            inputConsulta.Value = value
        End Sub







        ''Agrega a la pagina los componentes de mensajes en forma MODAL
        Public Sub AsociarCombo(ByVal comboId As String, ByVal TextId As String)
            Dim js As HtmlGenericControl = New HtmlGenericControl("script")
            js.Attributes.Add("type", "text/javascript")
            Dim cstext2 As New StringBuilder()
            cstext2.AppendLine("try{ addBodyOnLoad(new asociarCombo('" + comboId + "','" + TextId + "').callback); } catch(ex){}")
            js.InnerHtml = cstext2.ToString()
            Form.Controls.Add(js)
        End Sub

        Public Sub ActualizarTareas()
            Dim js As HtmlGenericControl = New HtmlGenericControl("script")
            js.Attributes.Add("type", "text/javascript")
            Dim cstext2 As New StringBuilder()
            cstext2.AppendLine("$(document).ready(function() {ActualizarTareas()});")
            js.InnerHtml = cstext2.ToString()
            Form.Controls.Add(js)
        End Sub

        Public Sub llamarScript(ByVal script As String)
            Dim js As HtmlGenericControl = New HtmlGenericControl("script")
            js.Attributes.Add("type", "text/javascript")
            Dim cstext2 As New StringBuilder()
            cstext2.AppendLine("var abc = function(){try{ " + script + "; } catch(ex){logError(ex)}};abc();")
            js.InnerHtml = cstext2.ToString()
            Form.Controls.Add(js)
        End Sub

        Public Sub registrarBotonConConfirmacion(ByRef input As WebControl, ByVal titulo As String, ByVal descripcion As String)
            ''input.Attributes.Add("onclick", "return confirmarPopup('" + titulo + "','" + descripcion + "',this)")
            Dim script As String = "registrarConfirmacion(':id',':titulo',':descripcion')"

            script = script.Replace(":id", input.ClientID)
            script = script.Replace(":titulo", titulo)
            script = script.Replace(":descripcion", descripcion)
            llamarScript(script)
        End Sub

        Protected Sub AgregarComponentesTitulo()
            ''controles de titulos
            '   <div class="SiafTitulo">
            '    <div class="col1">
            '    </div>
            '    <div class="col3">
            '    </div>
            '    <div class="col2">
            '        <cc2:ctrltitulo id="CtrlTitulo1"  runat="server" ></cc2:ctrltitulo>
            '    </div>
            '</div>
            Dim SiafTitulo As HtmlGenericControl = New HtmlGenericControl("div")
            Dim col1 As HtmlGenericControl = New HtmlGenericControl("div")
            Dim col2 As HtmlGenericControl = New HtmlGenericControl("div")
            Dim col3 As HtmlGenericControl = New HtmlGenericControl("div")



            Dim w As New ctrlTitulos.ctrlTitulos.ctrlTitulo
            w.ID = "ctrlTituloEncabezado"
            ''w.Attributes.Add("style", "Z-INDEX: 101; LEFT: 320px; POSITION: absolute; TOP: 0px")
            clsUtil.TituloPantalla(w, Session("TITULO2"))
            SiafTitulo.Controls.Add(col1)
            SiafTitulo.Controls.Add(col3)
            SiafTitulo.Controls.Add(col2)
            col2.Controls.Add(w)
            col1.Attributes.Add("class", "col1")
            col2.Attributes.Add("class", "col2")
            col3.Attributes.Add("class", "col3")
            SiafTitulo.Attributes.Add("class", "SiafTitulo")

            Page.Form.Controls.AddAt(0, SiafTitulo)
        End Sub

        Protected Sub AgregarError(ByVal errorMsg As String)
            AgregarError(errorMsg, Nothing)
        End Sub
        Protected Sub AgregarError(ByVal errorMsg As String, ByVal errorLink As String)
            Dim errorDiv As HtmlGenericControl = New HtmlGenericControl("div")
            errorDiv.Style.Add("display", "none")
            errorDiv.ID = MODAL_ERROR_DIV
            errorDiv.InnerHtml = errorMsg

            Dim errorLinkDiv As HtmlGenericControl = New HtmlGenericControl("div")
            errorLinkDiv.Style.Add("display", "none")
            errorLinkDiv.ID = MODAL_ERROR_LINK_DIV
            errorLinkDiv.InnerHtml = errorLink

            Form.Controls.Add(errorDiv)
            Form.Controls.Add(errorLinkDiv)

            Me.SetModalTipo(PaginaBase.INPUT_MODAL_BOTON_ACEPTAR Or PaginaBase.INPUT_MODAL_BOTON_DETALLES_ERROR, PaginaBase.INPUT_MODAL_NIVEL_ERROR)

        End Sub
        Protected Sub AgregarException(ByRef ex As Exception)
            Dim exception As Exception = ex
            Dim htmlError As StringBuilder = New StringBuilder()
            htmlError.Append("<table><tr><th>Error</th></tr>")
            While Not exception Is Nothing
                Dim st As System.Diagnostics.StackTrace = New System.Diagnostics.StackTrace(exception, True)
                htmlError.Append("<td>")
                htmlError.Append(exception.Message)
                htmlError.Append("</td>")
                If st.FrameCount > 0 Then
                    htmlError.Append("<td>")
                    htmlError.Append(st.GetFrame(0).GetFileName)
                    htmlError.Append("</td>")
                    htmlError.Append("<td>")
                    htmlError.Append(st.GetFrame(0).GetMethod().Name)
                    htmlError.Append("</td>")
                    htmlError.Append("<td>")
                    htmlError.Append(st.GetFrame(0).GetFileLineNumber)
                    htmlError.Append("</td>")
                End If
                exception = exception.InnerException
                htmlError.Append("</tr><table>")
            End While

            AgregarError(htmlError.ToString)
        End Sub
        Protected Sub AgregarComponentesDeEsperar()
            Dim myTimer As Timer = New Timer()
            myTimer.ID = "MODAL_TIMER_ID"
            myTimer.Enabled = False
            myTimer.Interval = 5000
            AddHandler myTimer.Tick, AddressOf ModalTimer_Tick1
            ''Page.Form.Controls.Add(myTimer)

            Dim parent As Control = Page.Header
            If parent Is Nothing Then
                parent = Page.Form
            End If

            Dim jquery As HtmlGenericControl = New HtmlGenericControl("script")
            jquery.Attributes.Add("type", "text/javascript")
            jquery.Attributes.Add("src", clsConstantes.includejQuery)
            parent.Controls.Add(jquery)

            'jquery  xml 2 json
            Dim xml2json As HtmlGenericControl = New HtmlGenericControl("script")
            xml2json.Attributes.Add("type", "text/javascript")
            xml2json.Attributes.Add("src", "../Scripts/xml2json.js")
            parent.Controls.Add(xml2json)

            Dim link As HtmlGenericControl = New HtmlGenericControl("link")
            link.Attributes.Add("rel", "stylesheet")
            link.Attributes.Add("type", "text/css")
            link.Attributes.Add("href", "../Content/themes/base/jquery-ui.css")
            parent.Controls.Add(link)

            Dim uiAll As HtmlGenericControl = New HtmlGenericControl("script")
            uiAll.Attributes.Add("type", "text/javascript")
            uiAll.Attributes.Add("src", clsConstantes.includejQueryUI)
            parent.Controls.Add(uiAll)

            Dim layout As HtmlGenericControl = New HtmlGenericControl("script")
            layout.Attributes.Add("type", "text/javascript")
            layout.Attributes.Add("src", "../Scripts/jquery.layout.js")
            parent.Controls.Add(layout)

            Dim js As HtmlGenericControl = New HtmlGenericControl("script")
            js.Attributes.Add("type", "text/javascript")
            js.Attributes.Add("src", "../include/global2.js")
            parent.Controls.Add(js)

            Dim messageValue As HiddenField = New HiddenField
            messageValue.ID = INPUT_MENSAJE_ESPERA
            messageValue.Value = ""

            Dim inputConsulta As HiddenField = New HiddenField
            inputConsulta.ID = INPUT_CONSULTA
            inputConsulta.Value = ""

            Dim modalTipo As HiddenField = New HiddenField
            modalTipo.ID = INPUT_MODAL_TIPO
            modalTipo.Value = ""

            Dim modalConfirmar As HiddenField = New HiddenField
            modalConfirmar.ID = INPUT_MODAL_CONFIRMAR

            Dim modalConfirmacionId As HiddenField = New HiddenField()
            modalConfirmacionId.ID = INPUT_MODAL_CONFIRMACION_ID

            Dim modalBtnConfirmar As HiddenField = New HiddenField()
            modalBtnConfirmar.ID = BUTTON_MODAL_CONFIRMAR

            Dim messageBoxValue As HiddenField = New HiddenField
            messageBoxValue.ID = MODAL_INPUT_MENSAJE
            messageBoxValue.Value = ""

            Dim messageBoxDetailsValue As HiddenField = New HiddenField
            messageBoxDetailsValue.ID = MODAL_INPUT_MENSAJE_DETALLES
            messageBoxDetailsValue.Value = ""


            Dim modalProgressBarKey As HiddenField = New HiddenField
            modalProgressBarKey.ID = INPUT_MODAL_PROGRESSBAR_KEY
            modalProgressBarKey.Value = ""

            Dim modalNivel As HiddenField = New HiddenField
            modalNivel.ID = INPUT_MODAL_NIVEL

            Dim gotoPage As HiddenField = New HiddenField
            gotoPage.ID = MODAL_GOTO_PAGE

            Form.Controls.Add(modalTipo)
            Form.Controls.Add(modalNivel)
            Form.Controls.Add(modalConfirmar)
            Form.Controls.Add(modalConfirmacionId)
            Form.Controls.Add(modalBtnConfirmar)
            Form.Controls.Add(messageValue)
            Form.Controls.Add(messageBoxValue)
            Form.Controls.Add(messageBoxDetailsValue)
            Form.Controls.Add(gotoPage)
            Form.Controls.Add(modalProgressBarKey)

            Form.Controls.Add(inputConsulta)

            modalTipo.Value = "0"
            modalNivel.Value = "0"
            modalConfirmar.Value = "false"

        End Sub
        Protected Sub AgregarComponentesDeEsperarOld()
            ''agregarJSWainting2()
            ''Agregar Timer

            Dim myTimer As Timer = New Timer()
            myTimer.ID = "MODAL_TIMER_ID"
            myTimer.Enabled = False
            myTimer.Interval = 5000
            AddHandler myTimer.Tick, AddressOf ModalTimer_Tick1
            Page.Form.Controls.Add(myTimer)

            Dim js As HtmlGenericControl = New HtmlGenericControl("script")
            js.Attributes.Add("type", "text/javascript")
            js.Attributes.Add("src", "../include/global.js")
            Form.Controls.Add(js)

            Dim NewControl As HtmlGenericControl = New HtmlGenericControl("div")
            Dim NewControlTapa1 As HtmlGenericControl = New HtmlGenericControl("iframe")
            Dim NewControlTapa2 As HtmlGenericControl = New HtmlGenericControl("div")
            Dim DivModalDetalles As HtmlGenericControl = New HtmlGenericControl("div")

            Dim NewTable As HtmlGenericControl = New HtmlGenericControl("table")
            Dim NewRow1 As HtmlGenericControl = New HtmlGenericControl("tr")
            Dim NewCell1 As HtmlGenericControl = New HtmlGenericControl("td")
            Dim NewRow2 As HtmlGenericControl = New HtmlGenericControl("tr")
            Dim NewCell2 As HtmlGenericControl = New HtmlGenericControl("td")
            Dim NewRow3 As HtmlGenericControl = New HtmlGenericControl("tr")
            Dim NewCell3 As HtmlGenericControl = New HtmlGenericControl("td")
            Dim NewRow4 As HtmlGenericControl = New HtmlGenericControl("tr")
            Dim NewCell4 As HtmlGenericControl = New HtmlGenericControl("td")


            Dim messageValue As HiddenField = New HiddenField
            messageValue.ID = INPUT_MENSAJE_ESPERA
            messageValue.Value = ""

            Dim messageBoxValue As HiddenField = New HiddenField
            messageBoxValue.ID = MODAL_INPUT_MENSAJE
            messageBoxValue.Value = ""

            Dim messageBoxDetailsValue As HiddenField = New HiddenField
            messageBoxDetailsValue.ID = MODAL_INPUT_MENSAJE_DETALLES
            messageBoxDetailsValue.Value = ""

            Dim gotoPage As HiddenField = New HiddenField
            gotoPage.ID = "MODAL_GOTO_PAGE"

            Dim aspLabel As Label = New Label()
            aspLabel.ID = LABEL_MENSAJE_ESPERA
            aspLabel.Text = ""

            Dim image As HtmlGenericControl = New HtmlGenericControl("img")
            image.Attributes.Add("id", "modal_progress_bar")
            image.Attributes.Add("src", "../img/progressbar.gif")

            Dim ModalMessage As HtmlGenericControl = New HtmlGenericControl("label")
            ModalMessage.Attributes.Add("id", "modal_message_id")


            NewControl.ID = DIV_ID_AJAX_WAITING

            NewControl.Style.Add("margin", "0 auto 0 auto")
            NewControl.Style.Add("width", "250px")
            NewControl.Style.Add("height", "100px")
            NewControl.Style.Add("text-align", "center")
            NewControl.Style.Add("position", "absolute")
            NewControl.Style.Add("top", "100")
            NewControl.Style.Add("border", "1px solid #016FB3")
            NewControl.Style.Add("display", "none")
            NewControl.Style.Add("z-index", "9999")

            NewControlTapa1.ID = DIV_ID_AJAX_TAPA1
            NewControlTapa1.Style.Add("filter", "alpha(opacity=0)")
            NewControlTapa1.Style.Add("position", "absolute ")
            NewControlTapa1.Style.Add("left", "0")
            NewControlTapa1.Style.Add("height", "100%")
            NewControlTapa1.Style.Add("width", "100%")
            NewControlTapa1.Style.Add("top", "0")
            NewControlTapa1.Style.Add("z-index", "9000")
            NewControlTapa1.Style.Add("border", "0")
            NewControlTapa1.Style.Add("display", "none")
            NewControlTapa1.Attributes.Add("frameborder", "0")
            NewControlTapa1.Attributes.Add("scrolling", "no")

            NewControlTapa2.ID = DIV_ID_AJAX_TAPA2
            NewControlTapa2.Style.Add("filter", "alpha(opacity=30)")
            NewControlTapa2.Style.Add("visibility", "block")
            NewControlTapa2.Style.Add("position", "absolute")
            NewControlTapa2.Style.Add("top", "0")
            NewControlTapa2.Style.Add("left", "0")
            NewControlTapa2.Style.Add("height", "100%")
            NewControlTapa2.Style.Add("width", "100%")
            NewControlTapa2.Style.Add("z-index", "9500")
            NewControlTapa2.Style.Add("display", "none")
            NewControlTapa2.Style.Add("background-color", "#000033")



            DivModalDetalles.Attributes.Add("ID", "modal_detalles_id")
            DivModalDetalles.Style.Add("height", "100%")
            DivModalDetalles.Style.Add("width", "100%")

            ''button accept


            NewCell4.Attributes.Add("ID", "modal_buttonera_id")

            ''td styles
            NewCell1.Style.Add("text-align", "center")
            NewCell1.Style.Add("color", "red")

            NewCell3.Style.Add("text-align", "center")
            NewCell4.Style.Add("text-align", "center")

            NewTable.Controls.Add(NewRow1)
            NewRow1.Controls.Add(NewCell1)
            NewCell1.Controls.Add(aspLabel)
            NewCell1.Controls.Add(messageValue)
            NewCell1.Controls.Add(messageBoxValue)
            NewCell1.Controls.Add(messageBoxDetailsValue)
            NewCell1.Controls.Add(gotoPage)

            NewTable.Controls.Add(NewRow2)
            NewRow2.Controls.Add(NewCell2)

            NewCell2.Controls.Add(ModalMessage)
            NewCell2.Controls.Add(DivModalDetalles)
            NewCell2.Controls.Add(image)

            NewTable.Controls.Add(NewRow3)
            NewRow3.Controls.Add(NewCell3)

            NewTable.Controls.Add(NewRow4)
            NewRow4.Controls.Add(NewCell4)

            NewControl.Controls.Add(NewTable)

            Form.Controls.Add(NewControlTapa1)
            Form.Controls.Add(NewControlTapa2)
            Form.Controls.Add(NewControl)

        End Sub

        Protected Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not IsPostBack() Then
                If Session("NMF_FORMA_ANTERIOR") <> Nothing Then
                    Session("FORMA_ACTUAL") = Session("NMF_FORMA_ANTERIOR")
                    Session("NMF_FORMA_ANTERIOR") = Nothing
                    ''ocultarPanel();
                End If
            End If

            validarSession()
        End Sub

        Protected Sub inhabilitarControles()
            Dim txt As New TextBox
            Dim ddl As New DropDownList
            Dim chk As New CheckBox
            'Inhabilitar textbos y listas
            For Each icontrol As System.Web.UI.Control In Me.Page.Controls
                Select Case icontrol.GetType.ToString
                    Case txt.GetType.ToString
                        CType(icontrol, TextBox).Enabled = False
                    Case ddl.GetType.ToString
                        CType(icontrol, DropDownList).Enabled = False
                    Case chk.GetType.ToString
                        CType(icontrol, CheckBox).Enabled = False
                End Select
            Next
        End Sub


        Protected Sub agregarJSWainting()
            Dim csname2 As String = "ButtonClickScript"
            Dim cstype As Type = Me.GetType()
            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript
            ' Check to see if the startup script is already r
            ' Check to see if the client script is already registered.
            If (Not cs.IsClientScriptBlockRegistered(cstype, csname2)) Then

                Dim cstext2 As New StringBuilder()
                cstext2.Append(" function DoClock() {")
                cstext2.AppendLine()
                cstext2.Append(" DoClockAccept(true);")
                cstext2.AppendLine()
                cstext2.Append(" }")
                cstext2.AppendLine()
                cstext2.Append(" function DoClockAccept(accept) {")
                'cstext2.Append("alert(document.getElementById('ESTADO_PROCESO').value == '' ) return;")
                cstext2.AppendLine()
                cstext2.Append("var divid = '" + DIV_ID_AJAX_WAITING + "';")
                cstext2.AppendLine()
                cstext2.Append("var tapa1 = '" + DIV_ID_AJAX_TAPA1 + "';")
                cstext2.AppendLine()
                cstext2.Append("var tapa2 = '" + DIV_ID_AJAX_TAPA2 + "';")
                cstext2.AppendLine()
                cstext2.Append("if(document.getElementById('" + INPUT_MENSAJE_ESPERA + "').value == '') return;")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById('" + LABEL_MENSAJE_ESPERA + "').innerHTML" + "= document.getElementById('" + INPUT_MENSAJE_ESPERA + "').value")
                cstext2.AppendLine()
                cstext2.Append("var IpopTop = (document.body.offsetHeight - document.getElementById(divid).offsetHeight)/3;")
                cstext2.AppendLine()
                cstext2.Append("var IpopLeft = (document.body.offsetWidth - document.getElementById(divid).offsetWidth)/2;")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById(divid).style.left=IpopLeft + document.body.scrollLeft;")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById(divid).style.top=IpopTop + document.body.scrollTop;")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById(tapa1).style.height = document.body.offsetHeight+document.body.scrollTop;")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById(tapa1).style.width = document.body.offsetWidth + document.body.scrollLeft;")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById(tapa2).style.height = document.body.offsetHeight+document.body.scrollTop;")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById(tapa2).style.width = document.body.offsetWidth + document.body.scrollLeft;")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById(tapa1).style.display = 'block';")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById(tapa2).style.display = 'block';")
                cstext2.AppendLine()
                cstext2.Append("document.getElementById(divid).style.display = 'block';}")
                cstext2.AppendLine()
                cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), True)
            End If
        End Sub

        Protected Sub mostrarPanel()

        End Sub
        Protected Sub ocultarPanel()
            ocultarPanel(Form)
        End Sub
        Protected Sub ocultarPanel(ByRef control As Control)
            For Each child As Control In control.Controls()
                If TypeOf child Is Button Then
                    CType(child, Button).Visible = False
                ElseIf TypeOf child Is ImageButton Then
                    If child.ID.ToUpper <> "SALIR" Then
                        CType(child, ImageButton).Visible = False
                    End If
                Else
                    If child.HasControls Then
                        ocultarPanel(child)
                    End If
                End If
            Next
        End Sub
        Protected Sub desabilitarBotones()

        End Sub

        Protected Sub validarSession()
            If clsUtil.ExpiroSesion(Session("usuario")) Then
                MensajeExpiraSesion()
            End If
        End Sub
        ''Overridear para no controlar si expira sesión
        Protected Overridable Sub MensajeExpiraSesion()
            Session("ParametrosMensaje") = clsUtil.BuildXMLMensaje("SESIÓN EXPIRADA", clsConstantes.errorSesionExpirada, True, "../login/frmLogin.aspx", , "Volver a Ingresar")
            Response.Redirect("../general/frmMensajeGenerico.aspx")
        End Sub

        Shared Sub obtenerXML()
            If queries Is Nothing Then
                Return
            End If
        End Sub

        ''Asignar el Valor del Token
        Protected Sub AsignarToken()
            GetTokenInput().Value = GetNextToken()
        End Sub

        Protected Sub CancelarToken()
            Dim tokenValue As String = Session("NMF_CURR_TOKEN")
            Dim tokens As ArrayList = Session("NMF_TOKEN_LIST")
            tokens.Remove(tokenValue)
            GetTokenInput().Value = tokenValue
        End Sub

        Public Function FindControlByID(ByVal id As String) As Control

            If (Page.Form Is Nothing) Then
                Return Nothing
            End If

            Return FindControlByID(Page.Form, id)
        End Function
        Public Function FindControlByID(ByRef parent As Control, ByVal id As String) As Control

            Dim result As Control = Nothing

            If (parent.HasControls) Then
                For Each Ctrl As Control In parent.Controls
                    'result = FindControlByID(Ctrl, id)
                    'If (Not result Is Nothing) Then
                    '    Return result
                    'End If
                    If Ctrl.ID = id Then
                        Return Ctrl
                    Else
                        result = FindControlByID(Ctrl, id)
                        If Not result Is Nothing Then
                            Return result
                        End If
                    End If
                Next
            End If


            Return result
        End Function
        Private Function GetTokenInput() As HiddenField
            Dim tokenInput As HiddenField = Page.FindControl("TXT_TOKEN_VALUE")
            Return tokenInput
        End Function
        ''Retorna Falso si el token no es valido, doble Submit. y dice que ese token ya no es valido
        Protected Function ValidarToken() As Boolean
            Dim tokens As ArrayList = Session("NMF_TOKEN_LIST")
            If tokens Is Nothing Then
                tokens = New ArrayList()
                Session("NMF_TOKEN_LIST") = tokens
                Return True
            End If
            Dim tokenValue As String = GetTokenInput().Value

            If tokens.Contains(tokenValue) Then
                Return False
            End If
            tokens.Add(tokenValue)
            Session("NMF_CURR_TOKEN") = tokenValue

            Return True
        End Function

        Protected Function GetNextToken() As String
            Return Now.Ticks
        End Function

        Protected Overridable Sub CargarDatosToDS(ByVal pejercicio As Decimal, ByVal pentidad As Decimal, ByVal punidadEjecutora As Decimal, ByVal pUnidaddesconcentrada As Decimal, ByVal ppolitica As Decimal, ByRef dsDatos As DataSet)
            Dim dr As DataRow
            If dsDatos.Tables.Contains(clsConstantesNomina.clsTablas.Politicas) Then dsDatos.Tables.Remove(clsConstantesNomina.clsTablas.Politicas)
            dsDatos.Tables.Add(clsConstantesNomina.clsTablas.Politicas)

            With dsDatos.Tables(clsConstantesNomina.clsTablas.Politicas)
                .Columns.Add("EJERCICIO", System.Type.GetType("System.Decimal"))
                .Columns.Add("ENTIDAD", System.Type.GetType("System.Decimal"))
                .Columns.Add("UNIDAD_EJECUTORA", System.Type.GetType("System.Decimal"))
                .Columns.Add("UNIDAD_DESCONCENTRADA", System.Type.GetType("System.Decimal"))
                .Columns.Add("POLITICA", System.Type.GetType("System.Decimal"))
                dr = dsDatos.Tables(clsConstantesNomina.clsTablas.Politicas).NewRow

                dr.Item("EJERCICIO") = pejercicio
                dr.Item("ENTIDAD") = pentidad
                dr.Item("UNIDAD_EJECUTORA") = punidadEjecutora
                dr.Item("UNIDAD_DESCONCENTRADA") = pUnidaddesconcentrada
                dr.Item("POLITICA") = ppolitica
                .Rows.Add(dr)
            End With
        End Sub

        Protected Overridable Sub CargarDatosToDS(ByVal pejercicio As Decimal, ByVal pentidad As Decimal, ByVal punidadEjecutora As Decimal, ByVal pUnidaddesconcentrada As Decimal, ByVal pUnidadCompradora As Decimal, ByVal ppolitica As Decimal, ByRef dsDatos As DataSet)
            Dim dr As DataRow
            If dsDatos.Tables.Contains(clsConstantesNomina.clsTablas.Politicas) Then dsDatos.Tables.Remove(clsConstantesNomina.clsTablas.Politicas)
            dsDatos.Tables.Add(clsConstantesNomina.clsTablas.Politicas)

            With dsDatos.Tables(clsConstantesNomina.clsTablas.Politicas)
                .Columns.Add("EJERCICIO", System.Type.GetType("System.Decimal"))
                .Columns.Add("ENTIDAD", System.Type.GetType("System.Decimal"))
                .Columns.Add("UNIDAD_EJECUTORA", System.Type.GetType("System.Decimal"))
                .Columns.Add("UNIDAD_DESCONCENTRADA", System.Type.GetType("System.Decimal"))
                .Columns.Add("UNIDAD_COMPRADORA", System.Type.GetType("System.Decimal"))
                .Columns.Add("POLITICA", System.Type.GetType("System.Decimal"))
                dr = dsDatos.Tables(clsConstantesNomina.clsTablas.Politicas).NewRow

                dr.Item("EJERCICIO") = pejercicio
                dr.Item("ENTIDAD") = pentidad
                dr.Item("UNIDAD_EJECUTORA") = punidadEjecutora
                dr.Item("UNIDAD_DESCONCENTRADA") = pUnidaddesconcentrada
                dr.Item("UNIDAD_COMPRADORA") = pUnidadCompradora
                dr.Item("POLITICA") = ppolitica
                .Rows.Add(dr)
            End With
        End Sub

        ''' <summary>
        ''' Carga información contenida de un detalle de datos al dataset que viajara a la lógica
        ''' </summary>
        ''' <param name="VariableSesion"></param>
        ''' <param name="NombreTabla"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub CargarDetalleToDS(ByVal VariableSesion As String, ByVal NombreTabla As String)
            Dim dsTemp As DataSet = CType(Session("DATAROW"), DataSet)
            Dim dtDatos As DataTable = Nothing

            '1.0 Recuperando información
            If Not IsNothing(Session(VariableSesion)) Then dtDatos = CType(Session(VariableSesion), DataTable)

            If Not IsNothing(dtDatos) Then
                dtDatos.TableName = NombreTabla
                '1.1 Si ya existe la tabla se remueve
                If Not IsNothing(dsTemp.Tables) AndAlso _
                   dsTemp.Tables.Contains(NombreTabla) Then
                    dsTemp.Tables.Remove(NombreTabla)
                End If
                '2.0 Trasladando al DataSet de Arquitectura la información de tramos
                dtDatos.AcceptChanges()
                dsTemp.Tables.Add(dtDatos.Copy())
            End If
        End Sub

        Public Function ejecutarQuery(ByVal sql As String) As DataSet
            Return ejecutarQuery(sql, "tabla_sin_nombre")
        End Function
        Public Function ejecutarQuery(ByVal sql As String, ByVal name As String) As DataSet
            Return ws.getDatabySQL(sql, False, "<p></p>", name)
        End Function

        Public Overridable Sub ModalTimer_Tick1(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim a As Integer = 0
        End Sub


        Public Shared Function CrearDataSet(ByVal tableName As String, ByVal columns As ArrayList, ByVal values As Hashtable) As DataSet
            Dim ds As DataSet = New DataSet()
            Dim dt As DataTable = New DataTable()
            dt.TableName = tableName
            ds.Tables.Add(dt)
            For i As Integer = 0 To columns.Count - 1
                dt.Columns.Add(columns(i), values(columns(i)).GetType)
            Next
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
            For i As Integer = 0 To columns.Count - 1
                dr.Item(columns(i)) = values(columns(i))
            Next
            Return ds
        End Function

 
        ''' <summary>
        ''' Realiza un bind a un gridview desde una datatable de session
        ''' </summary>
        ''' <param name="pGrid"></param>
        ''' <param name="pSession"></param>
        ''' <remarks></remarks>
        Public Sub BindGridView(ByRef pGrid As GridView, ByVal pSession As String)
            pGrid.DataSource = CType(Session(pSession), DataTable)
            pGrid.DataBind()
        End Sub

        ''' <summary>
        ''' Realiza un bind a un gridview filtrando datos de un datatable de session
        ''' </summary>
        ''' <param name="pGrid"></param>
        ''' <param name="pSession"></param>
        ''' <param name="pFiltro"></param>
        ''' <remarks></remarks>
        Public Sub BindGridViewFiltro(ByRef pGrid As GridView, ByVal pSession As String, ByVal pFiltro As String)
            Dim dView As New DataView(CType(Session(pSession), DataTable))
            dView.RowFilter = pFiltro

            pGrid.DataSource = dView
            pGrid.DataBind()
        End Sub

        ''' <summary>
        ''' Agrega un encabezado customizado al gridview
        ''' </summary>
        ''' <param name="Texto"></param>
        ''' <param name="RowSpan"></param>
        ''' <param name="ColSpan"></param>
        ''' <returns>Nueva Fila</returns>
        ''' <remarks></remarks>
        Public Function AgregarEncabezado(ByVal Texto As String, ByVal RowSpan As Integer, ByVal ColSpan As Integer, ByVal Link As LinkButton) As TableCell
            Dim Celda As New TableCell()
            'Agregando montos
            Celda.Text = Texto
            Celda.ColumnSpan = ColSpan
            Celda.RowSpan = RowSpan
            If IsNothing(Link) = False Then
                Celda.Controls.Add(Link)
            End If
            Return Celda
        End Function


        Protected Overridable Sub Salir_Click_Handler(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
            If (SalirDeForma()) Then
                Dim mywebutil As clsWebUtil = New clsWebUtil(Me.Context.ApplicationInstance, Cache)
                mywebutil.generic_exit()
            End If
        End Sub

        ''Aplicar
        Protected Overridable Function SalirDeForma() As Boolean
            Return True
        End Function

        Protected Function getWebUtil() As clsWebUtil
            Dim mywebutil As clsWebUtil = New clsWebUtil(Me.Context.ApplicationInstance, Cache)
            Return mywebutil
        End Function

        Protected Overridable Sub ObtenerParametros(ByRef EJERCICIO As TextBox, ByRef ENTIDAD As TextBox, ByRef UNIDAD_DESCONCENTRADA As TextBox, ByRef UNIDAD_COMPRADORA As TextBox, ByRef POLITICA As TextBox, ByRef UNIDAD_EJECUTORA As TextBox)
            If Not EJERCICIO Is Nothing Then
                EJERCICIO.Text = CType(Session("PARAMETROS"), System.Xml.XmlDocument).SelectSingleNode("PARAMETROS/PEJER_EJECUCION").InnerText
            End If
            If Not ENTIDAD Is Nothing Then
                ENTIDAD.Text = CType(Session("PARAMETROS"), System.Xml.XmlDocument).SelectSingleNode("PARAMETROS/PENTIDAD").InnerText
            End If
            If Not UNIDAD_DESCONCENTRADA Is Nothing Then
                UNIDAD_DESCONCENTRADA.Text = CType(Session("PARAMETROS"), System.Xml.XmlDocument).SelectSingleNode("PARAMETROS/PUNIDAD_DESCONCENTRADA").InnerText
            End If
            If Not UNIDAD_COMPRADORA Is Nothing Then
                UNIDAD_COMPRADORA.Text = CType(Session("PARAMETROS"), System.Xml.XmlDocument).SelectSingleNode("PARAMETROS/PUNIDAD_COMPRADORA").InnerText
            End If
            If Not UNIDAD_EJECUTORA Is Nothing Then
                UNIDAD_EJECUTORA.Text = CType(Session("PARAMETROS"), System.Xml.XmlDocument).SelectSingleNode("PARAMETROS/PUNIDAD_EJECUTORA").InnerText
            End If
            'Recuperar código de unidad ejecutora de contratos asociada a la unidad compradora
        End Sub

        Protected Sub AgregarTabla(ByRef ds As DataSet, ByVal Nombre As String, ByVal Cols As String)

            If Not Cols Is Nothing Then
                Dim dt As DataTable = New DataTable(Nombre)
                Dim filtrosItems As String() = Cols.Split(";")
                Dim i As Decimal = 0

                For i = 0 To filtrosItems.Length - 2
                    Dim filtroItem As String() = filtrosItems(i).Split(",")

                    If filtroItem(1).ToUpper.Equals("C") Then
                        dt.Columns.Add(filtroItem(0), System.Type.GetType("System.String"))
                    ElseIf filtroItem(1).ToUpper.Equals("N") Then
                        dt.Columns.Add(filtroItem(0), System.Type.GetType("System.Decimal"))
                    ElseIf filtroItem(1).ToUpper.Equals("D") Then
                        dt.Columns.Add(filtroItem(0), System.Type.GetType("System.DateTime"))
                    End If
                Next

                ds.Tables.Add(dt)

            End If
        End Sub


    End Class
End Namespace

