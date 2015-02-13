Imports System.Xml
Imports Telerik.Web.UI
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Linq

Imports System

Imports System.Collections.Generic

 
Namespace SIGESWeb
    Partial Class C00818278
        Inherits clsPaginaBase
        Dim wsAdminSys As New clsAdminSysProxyWrapper



        Friend Class ArbolGenerico
            Private text1 As String
            Private id1 As Integer
            Private parentId1 As Integer

            Public Property NOMBRE_LOGICO() As String
                Get
                    Return text1
                End Get
                Set(ByVal value As String)
                    text1 = value
                End Set
            End Property


            Public Property OBJETO() As Integer
                Get
                    Return id1
                End Get
                Set(ByVal value As Integer)
                    id1 = value
                End Set
            End Property

            Public Property OBJETO_PADRE() As Integer
                Get
                    Return parentId1
                End Get
                Set(ByVal value As Integer)
                    parentId1 = value
                End Set
            End Property

            Public Sub New(ByVal id As Integer, ByVal parentId As Integer, ByVal text As String)
                Me.id1 = id
                Me.parentId1 = parentId
                Me.text1 = text
            End Sub
        End Class

        Private Shared Sub BindToIEnumerable(ByVal treeView As RadTreeView)
            Dim siteData As New List(Of ArbolGenerico)()


            siteData.Add(New ArbolGenerico(1, 0, "Products"))
            siteData.Add(New ArbolGenerico(2, 1, "Telerik UI for ASP.NET Ajax"))
            siteData.Add(New ArbolGenerico(3, 1, "Telerik UI for Silverlight"))
            siteData.Add(New ArbolGenerico(4, 2, "RadGrid"))
            siteData.Add(New ArbolGenerico(5, 2, "RadScheduler"))
            siteData.Add(New ArbolGenerico(6, 2, "RadEditor"))
            siteData.Add(New ArbolGenerico(7, 3, "RadGrid"))
            siteData.Add(New ArbolGenerico(8, 3, "RadMenu"))
            siteData.Add(New ArbolGenerico(9, 3, "RadEditor"))

            treeView.DataTextField = "NOMBRE_LOGICO"
            treeView.DataFieldID = "OBJETO"
            treeView.DataFieldParentID = "OBJETO_PADRE"
            treeView.DataValueField = "OBJETO"
            treeView.DataSource = siteData
            treeView.DataBind()
        End Sub


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

                'Dim mywebutil As New clsWebUtil(Me.Context.ApplicationInstance, Cache)
                'mywebutil.generic_page_load_event(IsPostBack, Me, ws)

                Dim objArbol = wsAdminSys.ObjetosJerarquia("00801935", "SIGESMD_DESA")



                'RadTreeView2.DataTextField = "NOMBRE_LOGICO"
                'RadTreeView2.DataFieldID = "OBJETO"
                'RadTreeView2.DataFieldParentID = "OBJETO_PADRE"
                'RadTreeView2.DataValueField = "OBJETO"
                'RadTreeView2.DataSource = objArbol



                ''For i = 0 To objArbol.Count - 1
                ''    Dim node2 As New RadTreeNode
                ''    node2.Text = objArbol.Item(i).NOMBRE_LOGICO
                ''    node2.Value = objArbol.Item(i).OBJETO
                ''    node2.ParentNode = objArbol.Item(i).OBJETO_PADRE
                ''    node2.Selected = True
                ''    node2.Expanded = False
                ''    TreeViewFuncion.Nodes.Add(node2)
                ''Next

                ''"../img/arbol_img/Image" & row.Item("TIPO_OBJETO") & ".ico"

                'Dim siteData As New List(Of ArbolGenerico)()
                'For i = 0 To objArbol.Count - 1
                '    siteData.Add(New ArbolGenerico(objArbol.Item(i).OBJETO, objArbol.Item(i).OBJETO_PADRE, objArbol.Item(i).NOMBRE_LOGICO))
                'Next
                ''objArbol.CopyTo(siteData)

                ''siteData.CopyTo(
                'RadTreeView2.DataTextField = "NOMBRE_LOGICO"
                'RadTreeView2.DataFieldID = "OBJETO"
                'RadTreeView2.DataFieldParentID = "OBJETO_PADRE"
                'RadTreeView2.DataValueField = "OBJETO"
                'RadTreeView2.DataSource = siteData
                'RadTreeView2.CollapseAllNodes()




                'RadTreeView2.DataBind()
                'RadTreeView2.Nodes(0).Nodes(0).Nodes(0).CollapseChildNodes()

                'RadTreeView2.CollapseAllNodes()

                'RadTreeView2.DataBind()
                '3.0 Limpia ARBOL
                'TreeViewFuncion.Nodes.Clear()
                'BindToIEnumerable(TreeViewFuncion)
                BindToDataSet(ArbolObjetos)



                ''''''''''''''


                ' CreaArbol2("801935", objArbol)
                'TreeViewFuncion.DataBind()
            End If
        End Sub

#End Region

#Region "Métodos Generales"


        ''' <summary>
        ''' Crea y recorre los nodos del arbol
        ''' </summary>
        ''' <remarks></remarks>
        ''' <author>Cesar Melgar</author>
        Private Sub CreaArbol2(ByVal indicePadre As Integer, arbol As wsSIGESAdminSysWCF.clsObjetoPoco())

            Dim objetoinicial = From cust In arbol
                                       Where cust.OBJETO_PADRE = indicePadre
                                       Select cust

            For i = 0 To objetoinicial.Count - 1
                Dim node2 As New RadTreeNode
                node2.Text = objetoinicial(i).OBJETO & " - " & objetoinicial(i).NOMBRE_LOGICO
                node2.Value = objetoinicial(i).OBJETO
                node2.Selected = True
                node2.Expanded = True

                ' node2.ImageUrl = "../img/arbol_img/Image" & row.Item("TIPO_OBJETO") & ".ico"

                'If row.Item("RESTRINGIDO") = 1 Then
                '    node2.Checked = True
                'Else
                '    node2.Checked = False
                'End If

                ArbolObjetos.Nodes.Add(node2)
                CrearNodosDelPadre2(objetoinicial(i).OBJETO, node2, arbol)
            Next

        End Sub


        Private Sub CrearNodosDelPadre2(ByVal indicePadre As Integer, ByVal nodoPadre As RadTreeNode, arbol As wsSIGESAdminSysWCF.clsObjetoPoco())

            Dim objetoinicial = From cust In arbol
                                    Where cust.OBJETO_PADRE = indicePadre
                                    Select cust

            For i = 0 To objetoinicial.Count - 1
                Dim node2 As New RadTreeNode
                node2.Text = objetoinicial(i).OBJETO & " - " & objetoinicial(i).NOMBRE_LOGICO
                node2.Value = objetoinicial(i).OBJETO
                node2.Selected = True


                node2.ImageUrl = "../img/arbol_img/Image" & objetoinicial(i).TIPO_OBJETO & ".ico"

                If objetoinicial(i).NIVEL < 4 Then
                    node2.Expanded = True
                Else
                    node2.Expanded = False
                End If


                nodoPadre.Nodes.Add(node2)

                CrearNodosDelPadre2(objetoinicial(i).OBJETO, node2, arbol)
            Next


        End Sub

        ''' <summary>
        ''' Sen encarga del Bind del Arbol
        ''' </summary>
        ''' <remarks></remarks>
        ''' <author>Cesar Melgar</author>
        Private Sub BindToDataSet(ByVal treeView As RadTreeView)
            Dim arrParametros(1) As clsParametro
            arrParametros(0) = New clsParametro("USUARIO", "")

            Dim dsDetalle As DataSet = wsAdminSys.ObjetosJerarquiaDS("00801935", "SIGESMD_DESA")

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
            Server.Transfer("../CLA/DummyCla.aspx")
        End Sub

        Protected Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
            BindToDataSet(ArbolObjetos)
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
    End Class
End Namespace
