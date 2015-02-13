Imports System.Xml
Imports Telerik.Web.UI
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Linq

Imports System

Imports System.Collections.Generic


Namespace SIGESWeb
    Partial Class frmObjetosJerarquia
        Inherits clsPaginaBase
        Dim wsAdminSys As New clsAdminSysProxyWrapper




#Region " Web Form Designer Generated Code "
        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            ' ws = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
        End Sub

#End Region

#Region "Load"
        Private Overloads Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
            'Validando si la sesion ha expirado, de ser verdadero se procede a notificar al usuario.
            '1.0 Valida Expira Session
            If clsUtil.ExpiroSesion(Session("usuario")) Then MensajeExpiraSesion()

            If Not IsPostBack Then
                LoadToolbar()
                BindToDataSet(ArbolObjetos)
            End If
        End Sub

#End Region

#Region "Métodos Generales"



        ''' <summary>
        ''' Sen encarga del Bind del Arbol
        ''' </summary>
        ''' <remarks></remarks>
        ''' <author>Cesar Melgar</author>
        Private Sub BindToDataSet(ByVal treeView As RadTreeView)
            Dim arrParametros(1) As clsParametro
            arrParametros(0) = New clsParametro("USUARIO", "")

            Dim dsDetalle As DataSet = wsAdminSys.ObjetosJerarquiaDS("00801935", Session("POOLSISTEMA"))

            If (dsDetalle.Tables.Count > 0) Then
                If (dsDetalle.Tables(0).Rows.Count > 0) Then
                    dsDetalle.Relations.Add("NodeRelation", dsDetalle.Tables(0).Columns("OBJETO"), dsDetalle.Tables(0).Columns("OBJETO_PADRE"))

                    'Se crea el arbol de unidades administrativas en base al xml
                    CreaArbol(dsDetalle.Tables(0).Rows(0).Item("OBJETO").ToString(), dsDetalle)
                Else
                    Response.Write("<script>window.alert('No se cuenta con ninguna funcion.');</script>")
                    Response.Write("<script>window.close();</script>")
                End If
            Else
                Response.Write("<script>window.alert('No se cuenta con ninguna funcion.');</script>")
                Response.Write("<script>window.close();</script>")
            End If

        End Sub

        ''' <summary>
        ''' Crea y recorre los nodos del arbol
        ''' </summary>
        ''' <remarks></remarks>
        ''' <author>Cesar Melgar</author>
        Private Sub CreaArbol(ByVal indicePadre As String, ByVal ds As DataSet)
            Dim rows As DataRow() = ds.Tables(0).Select(("OBJETO_PADRE is null"))
            Dim row As DataRow

            For Each row In rows
                Dim node2 As New RadTreeNode
                node2.Text = row.Item("OBJETO") & " - " & row.Item("NOMBRE_LOGICO")
                node2.Value = row.Item("OBJETO")
                node2.Selected = True
                node2.Expanded = True

                node2.ImageUrl = "../img/arbol_img/Image" & row.Item("TIPO_OBJETO") & ".ico"

                'If row.Item("RESTRINGIDO") = 1 Then
                '    node2.Checked = True
                'Else
                '    node2.Checked = False
                'End If

                ArbolObjetos.Nodes.Add(node2)
                CrearNodosDelPadre(row("OBJETO"), node2, ds)
            Next row
        End Sub

        ''' <summary>
        ''' Crea los nodos parde del arbol
        ''' </summary>
        ''' <remarks></remarks>
        ''' <author>Cesar Melgar</author>
        Private Sub CrearNodosDelPadre(ByVal indicePadre As String, ByVal nodoPadre As RadTreeNode, ByVal ds As DataSet)
            'Private Sub CrearNodosDelPadre(ByVal indicePadre As String, ByVal nodoPadre As Microsoft.Web.UI.WebControls.TreeNode, ByVal ds As DataSet)
            Dim rows As DataRow() = ds.Tables(0).Select(("OBJETO_PADRE = " + indicePadre + " AND OBJETO_PADRE <> OBJETO"))
            Dim row As DataRow

            For Each row In rows
                Dim node As New RadTreeNode
                'Dim node As New Microsoft.Web.UI.WebControls.TreeNode 'RadTreeNode
                node.Text = row.Item("OBJETO") & " - " & row.Item("NOMBRE_LOGICO")
                node.Value = row.Item("OBJETO")
                If row.Item("NIVEL") < 4 Then
                    node.Expanded = True
                Else
                    node.Expanded = False
                End If


                node.ImageUrl = "../img/arbol_img/Image" & row.Item("TIPO_OBJETO") & ".ico"

                'If row.Item("RESTRINGIDO") = 1 Then
                '    node.Checked = True
                'Else
                '    node.Checked = False
                'End If

                ' se añade el nuevo nodo al nodo padre.
                nodoPadre.Nodes.Add(node)
                CrearNodosDelPadre(row("OBJETO"), node, ds)
            Next row
        End Sub
#End Region

#Region "Eventos"
        Private Sub SALIR_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles SALIR.Click
            'Validando si la sesion ha expirado, de ser verdadero se procede a notificar al usuario.
            If clsUtil.ExpiroSesion(Session("usuario")) Then MensajeExpiraSesion()

            Dim mywebutil As New clsWebUtil(Me.Context.ApplicationInstance, Cache)
            'mywebutil.generic_exit()
            Server.Transfer("../general/blank.htm")
        End Sub

 
        ' ''' <summary>
        ' ''' Opciones del Context Menu 
        ' ''' </summary>
        ' ''' <remarks></remarks>
        ' ''' <author>Cesar Melgar</author>
        'Protected Sub TreeViewFuncion_ContextMenuItemClick(ByVal sender As Object, ByVal e As RadTreeViewContextMenuEventArgs)
        '    Dim clickedNode As RadTreeNode = e.Node

        '    If e.MenuItem.Value = "PERFIL" Then
        '        RWAConsultar.Title = " Detalle Perfiles - " & clickedNode.Text
        '    Else
        '        RWAConsultar.Title = " Detalle Funciones - " & clickedNode.Text
        '    End If

        '    Perfil_Funcion.Funciones("00" & clickedNode.Value, e.MenuItem.Value)

        '    'Dim script As String = "<script language='javascript' type='text/javascript'>Sys.Application.add_load(openWin);</script>"
        '    'ClientScript.RegisterStartupScript(Me.GetType(), "openWin", script)
        '    'RadAjaxPanel1.ResponseScripts.Add("openWin();")
        'End Sub
#End Region

        Private Sub LoadToolbar()
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
            Dim objToolBar = ws.CargarToolBar("00817805", Session("USUARIO"))
            Dim BotonesRoot As List(Of wsSIGES.clsBoton) = (From obj In objToolBar.Botones _
                                                            Where obj.ObjetoPadre = objToolBar.Objeto _
                                                            Select obj).ToList
            For Each Boton As wsSIGES.clsBoton In BotonesRoot
                Select Case Boton.TipoObjeto
                    Case 9 : RadToolBar1.Items.Add(New Telerik.Web.UI.RadToolBarButton _
                                                   With {.ImageUrl = "../img/" & Boton.Etiqueta.ToUpper & ".gif",
                                                         .ToolTip = Boton.NombreLogico,
                                                         .Value = Boton.NombreFisico.ToUpper})
                    Case 29 : RadToolBar1.Items.Add(New Telerik.Web.UI.RadToolBarButton _
                                                    With {.ImageUrl = "../img/" & Boton.Etiqueta.ToUpper & ".gif",
                                                          .ToolTip = Boton.NombreLogico,
                                                          .Value = Boton.NombreFisico.ToUpper,
                                                          .Text = Boton.NombreLogico})
                    Case 28
                        Dim dropDown As New RadToolBarDropDown _
                                        With {.Text = Boton.NombreFisico,
                                              .ToolTip = Boton.NombreLogico,
                                              .DataItem = Boton.Objeto,
                                              .ImageUrl = If(Boton.Etiqueta.Length > 0, "../img/" & Boton.Etiqueta.ToUpper & ".gif", String.Empty)}
                        RadToolBar1.Items.Add(dropDown)
                        Dim BotonesHijos As List(Of wsSIGES.clsBoton) = (From obj In objToolBar.Botones _
                                                                         Where obj.ObjetoPadre = Boton.Objeto _
                                                                         Select obj).ToList
                        BotonesHijos.ForEach(Sub(BotonHijo) _
                                                 dropDown.Buttons.Add(New RadToolBarButton _
                                                                      With {.Text = BotonHijo.NombreLogico,
                                                                            .ImageUrl = If(BotonHijo.Etiqueta.Length > 0, "../img/" & BotonHijo.Etiqueta.ToUpper & ".gif", String.Empty),
                                                                            .ToolTip = BotonHijo.NombreLogico,
                                                                            .Value = BotonHijo.NombreFisico,
                                                                            .CssClass = "rtbImageOnly"}))
                End Select
            Next
            RadToolBar1.Items.Add(New Telerik.Web.UI.RadToolBarButton _
                                  With {.ImageUrl = "../img/consultar.gif",
                                        .ToolTip = "Consultar todos los Registros",
                                        .Value = "CONSULTAR"})
        End Sub

        Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
            Dim x As Telerik.Web.UI.RadToolBarButton = CType(e.Item, Telerik.Web.UI.RadToolBarButton)
            ' Dim itemSeleccionado As Boolean = GetSelItem(grdMantenimiento, x)
            Dim oxml As New XmlDocument
            Dim dsTemp As DataSet = CType(Session("DATAROW"), DataSet)


            Select Case x.Value.ToUpper

                Case "MODIFICAR"

                    showInfo("Modificar", "Presiono Modificar . Objeto Selecionado " & ArbolObjetos.SelectedNode.Value & "", False, True)
                    
                Case Else

            End Select
        End Sub
    End Class
End Namespace
