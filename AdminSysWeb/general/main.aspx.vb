Imports System.Web.UI.HtmlControls
Imports System.Collections
Imports System.Linq
Imports System.Xml
Imports Telerik.Web.UI

Namespace SIGESWeb
    Partial Class general_main
        Inherits PaginasBase.clsPaginaBase
        Private Const XML_TAB As String = "li"
        Private Const XML_MENU As String = "ul"
        Private Const XML_LABEL As String = "a"
        Private Const UCDefault As String = "VWUC"
        Private Const ENTDefault As String = "VWEnt"
        Private Const CookieEnt As String = "ckSIGESEnt"
        Private strEnt, strUE, strUD, strComportamiento As String 'Variables de identificación de institucion
        Private configNomina As String

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                CargarMenu()
                If Not IsPostBack() Then                    
                    Dim obj As Object = Session("OBJINI")

                    If (Not obj Is Nothing) Then
                        If Not IsPostBack Then Session("FORMA_ACTUAL") = Nothing
                        Last_url.Value = "../general/blank.htm"
                        Dim str As String = "$(document).ready(function(){browserManager.open('" & Last_url.Value & "')});"
                        Dim js As HtmlGenericControl = New HtmlGenericControl("script")
                        js.InnerHtml = str
                        js.Attributes.Add("type", "text/javascript")
                        Form.Controls.Add(js)
                    End If

                    Dim wsSIGES As New clsSIGESProxyWrapper
                    Dim dsSistema As DataSet = wsSIGES.getDatabySQL("Select * from AD_SISTEMA ", True, Nothing, "AD_SISTEMA")
                    cmbSistema.DataValueField = "POOL"
                    cmbSistema.DataTextField = "NOMBRE"
                    cmbSistema.DataSource = dsSistema
                    cmbSistema.DataBind()
                    Session("POOLSISTEMA") = cmbSistema.SelectedValue
                End If
            Catch ex As Exception
                showError("Error al cargar página", ex.ToString, String.Empty, False, True, False)
            End Try
        End Sub


        Private Function ObjetoInicial() As String
            Dim wsSIGES As New clsSIGESProxyWrapper
            Return wsSIGES.ObjetoInicial(Session("Usuario"))
        End Function

        Private Function esPagina(ByVal Objeto As wsSIGES.clsObjeto) As Boolean
            Return Objeto.Nivel = 7 AndAlso (Objeto.NombreFisico.Contains("aspx") OrElse Objeto.NombreFisico.Contains("pdf"))
        End Function

        Private Sub CargarMenu()
            Try
                Dim objEncrypt As New clsEncrypt.Encryption(Session("key"))
                Dim modulo As String = ""
                If Request.QueryString("pobj") Is Nothing Then
                    'If Not (IsNothing(Request.Cookies("Cookie"))) Then
                    '    If (Request.Cookies("Cookie")("CModulo") IsNot Nothing) Then
                    '        modulo = Request.Cookies("Cookie").Item("CModulo")
                    '    Else
                    '        modulo = ObjetoInicial()
                    '    End If
                    'Else
                    '    modulo = ObjetoInicial()
                    'End If
                    modulo = "00800760"
                Else
                    modulo = objEncrypt.DesEncriptarSTR(Request.Params("pobj"))
                End If
                Session("OBJINI") = modulo
                Dim wsSIGES As New clsSIGESProxyWrapper
                Dim ObjetosMenu = wsSIGES.MenuUsuario(Session("Usuario"), modulo)

                If Not ObjetosMenu Is Nothing Then
                    Dim XML_TAB As String = "li"
                    Dim XML_MENU As String = "ul"
                    Dim XML_ITEM As String = "li"
                    Dim XML_LABEL As String = "a"
                    Dim parents As Hashtable = New Hashtable()
                    Dim menues As Hashtable = New Hashtable()
                    Dim format As Hashtable = New Hashtable()

                    Dim mainMenu As HtmlGenericControl = New HtmlGenericControl(XML_MENU)
                    Dim parentMenu As HtmlGenericControl = Nothing
                    Dim parentItem As HtmlGenericControl = Nothing
                    Dim item As HtmlGenericControl = Nothing
                    Dim link As HtmlGenericControl

                    Dim url As String = Nothing

                    superMenu.Controls.Add(mainMenu)
                    mainMenu.Attributes("id") = "mega-menu-5"
                    mainMenu.Attributes("class") = "mega-menu"
                    MenuInicial(mainMenu)
                    For Each Objeto In ObjetosMenu
                        If Objeto.Nivel >= 6 AndAlso Objeto.Nivel <= 8 Then
                            If Objeto.NombreFisico.Contains("aspx") Then
                                If Objeto.NombreFisico.Contains("?") Then
                                    url = "../" + Objeto.NombreFisico + "&ST=Y&ID=" + objEncrypt.EncriptarSTR(Trim(Objeto.Objeto))
                                Else
                                    url = "../" + Objeto.NombreFisico + "?ST=Y&ID=" + objEncrypt.EncriptarSTR(Trim(Objeto.Objeto))
                                End If
                            ElseIf Objeto.NombreFisico.Contains("pdf") Then
                                url = "../" + Objeto.NombreFisico
                            Else
                                url = Nothing
                            End If
                            'Obtener el menu padre
                            parentMenu = menues.Item(Objeto.ObjetoPadre & IIf(esPagina(Objeto), "1", ""))
                            'Si no Tengo
                            If parentMenu Is Nothing Then
                                ''Obtener el item Padre
                                parentItem = parents.Item(Objeto.ObjetoPadre)
                                If Not parentItem Is Nothing Then
                                    ''Se crea un Menu al Item Parent
                                    parentMenu = New HtmlGenericControl(XML_MENU)
                                    parentItem.Controls.Add(parentMenu)
                                    If menues.Item(Objeto.ObjetoPadre) Is Nothing Then menues.Add(Objeto.ObjetoPadre, parentMenu)
                                    If esPagina(Objeto) Then
                                        item = New HtmlGenericControl(XML_ITEM)
                                        parents.Add(Objeto.ObjetoPadre & "1", item)
                                        parentMenu.Controls.Add(item)
                                        link = New HtmlGenericControl(XML_LABEL)
                                        link.InnerHtml = "Opciones"
                                        link.Attributes.Add("href", "#")
                                        item.Controls.Add(link)
                                        parentMenu = New HtmlGenericControl(XML_MENU)
                                        parentItem = item
                                        parentItem.Controls.Add(parentMenu)
                                        menues.Add(Objeto.ObjetoPadre & "1", parentMenu)
                                    End If
                                Else
                                    ''El Item parent es el Nodo Raíz
                                    parentMenu = mainMenu
                                End If
                            End If

                            If parentMenu Is mainMenu Then
                                item = New HtmlGenericControl(XML_TAB) '' creo tab
                            Else
                                item = New HtmlGenericControl(XML_ITEM) '' creo item
                            End If
                            parents.Add(Objeto.Objeto, item)
                            parentMenu.Controls.Add(item)

                            link = New HtmlGenericControl(XML_LABEL)
                            link.InnerHtml = IIf(Objeto.Nivel = 8 OrElse (esPagina(Objeto)), "► ", "") & Objeto.Etiqueta
                            If Not url Is Nothing Then
                                item.Attributes.Add("onclick", "browserManager.open('" + url + "')")
                                item.Attributes.Add("target", "myIframe")
                            End If
                            item.Controls.Add(link)
                        End If
                    Next
                    MenuFinal(mainMenu, objEncrypt)
                End If
            Catch ex As Exception
                Throw New Exception("Error al cargar Menu: " & ex.ToString)
            End Try
        End Sub

        Private Sub MenuInicial(ByRef mainMenu As HtmlGenericControl)
            Dim item As HtmlGenericControl = Nothing
            Dim item2 As HtmlGenericControl = Nothing
            Dim ul As HtmlGenericControl = Nothing
            Dim ulPrincipal As HtmlGenericControl = Nothing
            Dim link As HtmlGenericControl

            'Tab Regresar
            item = New HtmlGenericControl(XML_TAB)
            link = New HtmlGenericControl(XML_LABEL)
            link.InnerHtml = "Módulos"
            link.Attributes.Add("href", "#")
            link.Attributes.Add("style", "font-weight: bold;color:#2E2E2E;")
            item.Controls.Add(link)
            mainMenu.Controls.Add(item)
            'Titulo
            ulPrincipal = New HtmlGenericControl(XML_MENU)
            item.Controls.Add(ulPrincipal)
            'Hijos
            Dim wsSIGES As New clsSIGESProxyWrapper
            Dim objTabs = wsSIGES.TabGroup(Session("usuario").ToString)
            'Almacena el último módulo utilizado por el usuario
            Response.Cookies("Cookie")("CModulo") = Session("OBJINI")
            Response.Cookies("Cookie").Expires = DateTime.Now.AddDays(7)
            Dim objMenuInicio = (From Tab In objTabs
                                 Where Tab.Objeto = Session("OBJINI").ToString)
            If objMenuInicio.Any Then
                NombreModulo.Text = objMenuInicio.First.NombreLogico
            Else
                NombreModulo.Text = "Seleccione un Módulo"
            End If
            Dim actual As String = ""
            Dim objEncrypt As New clsEncrypt.Encryption(Session("key"))
            objTabs.ToList.ForEach(Sub(objMenu)
                                       Try
                                           If Not IsNothing(objMenu) AndAlso Not IsNothing(objMenu.Objeto) Then
                                               If actual <> objMenu.ImagenBotonSobre Then
                                                   actual = objMenu.ImagenBotonSobre
                                                   item = New HtmlGenericControl(XML_TAB)
                                                   link = New HtmlGenericControl(XML_LABEL)
                                                   link.InnerHtml = objMenu.ImagenBotonSobre
                                                   link.Attributes.Add("href", "#")
                                                   item.Controls.Add(link)
                                                   ulPrincipal.Controls.Add(item)
                                                   ul = New HtmlGenericControl(XML_MENU)
                                                   item.Controls.Add(ul)
                                               End If
                                               item = New HtmlGenericControl(XML_TAB)
                                               link = New HtmlGenericControl(XML_LABEL)
                                               link.InnerHtml = "<table title=""" + objMenu.NombreLogico + """> <tr><td><img src=""" & objMenu.ImagenBotonArriba & """ height=""45"" width=""50""></td><td> " & objMenu.Etiqueta & "</td></tr></table>"
                                               item.Controls.Add(link)
                                               item.Attributes.Add("onclick", "document.location.href='../general/main.aspx?pobj=" + Server.UrlEncode(objEncrypt.EncriptarSTR(objMenu.Objeto)) + "'")
                                               ul.Controls.Add(item)
                                           End If
                                       Catch ex As Exception
                                           Dim strResult As String = String.Empty
                                           Dim objLOG As New clsLOG
                                           If Not IsNothing(objEncrypt) Then
                                               strResult += " objEnc tiene algo"
                                               If Not IsNothing(objEncrypt.key) Then strResult += " objEncrypt.key tiene: " & objEncrypt.key
                                           End If
                                           If Not IsNothing(objMenu) Then
                                               strResult += " objMenu tiene algo"
                                               If Not IsNothing(objMenu.Objeto) Then strResult += " objMenu.Objeto tiene: " & objMenu.Objeto
                                           End If
                                           objLOG.AgregarLog("Error al generar menú, resultado del análisis: " & strResult & " Error: " & ex.ToString, Diagnostics.EventLogEntryType.Error)
                                           Throw ex
                                       End Try
                                   End Sub)
        End Sub

        Private Sub MenuFinal(ByRef mainMenu As HtmlGenericControl, objenc As clsEncrypt.Encryption)
            Dim item As HtmlGenericControl = Nothing
            Dim item2 As HtmlGenericControl = Nothing
            Dim ul As HtmlGenericControl = Nothing
            Dim ulPrincipal As HtmlGenericControl = Nothing
            Dim link As HtmlGenericControl

            'Tab Regresar
            item = New HtmlGenericControl(XML_TAB)
            link = New HtmlGenericControl(XML_LABEL)
            link.InnerHtml = Session("USUARIO")
            link.Attributes.Add("href", "#")
            link.Attributes.Add("style", "font-weight: bold;color:#2E2E2E;")
            item.Controls.Add(link)
            mainMenu.Controls.Add(item)

            'Titulo
            ulPrincipal = New HtmlGenericControl(XML_MENU)
            item.Controls.Add(ulPrincipal)

            'Subtitulo
            item = New HtmlGenericControl(XML_TAB)
            link = New HtmlGenericControl(XML_LABEL)
            link.InnerHtml = "Opciones"
            link.Attributes.Add("href", "#")
            item.Controls.Add(link)
            ulPrincipal.Controls.Add(item)
            ul = New HtmlGenericControl(XML_MENU)
            item.Controls.Add(ul)

            'Opciones
            item = New HtmlGenericControl(XML_TAB)
            link = New HtmlGenericControl(XML_LABEL)
            link.InnerHtml = "Mí Perfil"
            item.Attributes.Add("onclick", "showPass('../Include/frmMiPerfil.aspx?asp=1','Mi Perfil')")
            link.Attributes.Add("style", "font-weight: bold;color:#2E2E2E;")
            item.Controls.Add(link)
            ul.Controls.Add(item)

            item = New HtmlGenericControl(XML_TAB)
            link = New HtmlGenericControl(XML_LABEL)
            link.InnerHtml = "Cambiar Clave"
            item.Attributes.Add("onclick", "showPass('../General/frmCambioPWD.aspx?asp=2','Cambiar Clave')")
            link.Attributes.Add("style", "font-weight: bold;color:#2E2E2E;")
            item.Controls.Add(link)
            ul.Controls.Add(item)

            item = New HtmlGenericControl(XML_TAB)
            link = New HtmlGenericControl(XML_LABEL)
            link.InnerHtml = "Cerrar Sesión"
            link.Attributes.Add("onclick", "javascript:Salir()")
            link.Attributes.Add("style", "font-weight: bold;color:#2E2E2E;")
            item.Controls.Add(link)
            ul.Controls.Add(item)
        End Sub


        Private Function Modulo() As wsSIGES.ModuloSIGES
            '    <EnumMember> PagosAMunicipios = 11 00812053
            '<EnumMember> Administracion = 12 00810920
            '<EnumMember> Fideicomisos = 13 00817776
            '<EnumMember> CatalogoInsumos = 14 00816068
            '<EnumMember> CatalogoSistema = 15 00800755
            '<EnumMember> CDP = 16 00814601
            Select Case Session("OBJINI")
                Case "00800775" : Return wsSIGES.ModuloSIGES.PreOrden
                Case "00800760" : Return wsSIGES.ModuloSIGES.OrdenCompra
                Case "00817611" : Return wsSIGES.ModuloSIGES.ExpGasto
                Case "00811712" : Return wsSIGES.ModuloSIGES.ProcesoCompra
                Case "00812222" : Return wsSIGES.ModuloSIGES.Contratos
                Case "00812619" : Return wsSIGES.ModuloSIGES.Nomina
                Case "00814164" : Return wsSIGES.ModuloSIGES.ProgramacionSNIP
                Case "00814664" : Return wsSIGES.ModuloSIGES.EjecucionSNIP
                Case "00815947" : Return wsSIGES.ModuloSIGES.ProgramacionPpR
                Case "00817072" : Return wsSIGES.ModuloSIGES.EjecucionPpR
                Case "00812619" : Return wsSIGES.ModuloSIGES.ProgramacionNomina
                Case "00814601" : Return wsSIGES.ModuloSIGES.CDP
                Case "00800755" : Return wsSIGES.ModuloSIGES.CatalogoSistema
                Case "00816068" : Return wsSIGES.ModuloSIGES.CatalogoInsumos
                Case "00812053" : Return wsSIGES.ModuloSIGES.PagosAMunicipios
                Case "00810920" : Return wsSIGES.ModuloSIGES.Administracion
                Case "00817776" : Return wsSIGES.ModuloSIGES.Fideicomisos
                Case "00818400" : Return wsSIGES.ModuloSIGES.NominaPpR
                Case Else : Return wsSIGES.ModuloSIGES.Otro
            End Select
        End Function

        Protected Sub cmbSistema_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cmbSistema.SelectedIndexChanged
            Session("POOLSISTEMA") = cmbSistema.SelectedValue
        End Sub
    End Class
End Namespace