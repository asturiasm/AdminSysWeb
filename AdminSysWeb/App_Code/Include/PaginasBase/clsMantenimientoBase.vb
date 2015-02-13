Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports Telerik.Web.UI

Namespace SIGESWeb.PaginasBase
    Public MustInherit Class clsMantenimientoBase
        Inherits clsPaginaCore

        Public MustOverride Property Grid As Telerik.Web.UI.RadGrid
        Public MustOverride Property ToolBar As Telerik.Web.UI.RadToolBar
        Public MustOverride Sub OperacionesCustomizadasClickConsultar()

        Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
            AddHandler ToolBar.ButtonClick, AddressOf ToolBarClick
        End Sub

        Protected Function ShouldApplySortFilterOrGroup() As Boolean
            Return Grid.MasterTableView.FilterExpression <> "" OrElse _
                   Grid.MasterTableView.GroupByExpressions.Count > 0 OrElse _
                   Grid.MasterTableView.SortExpressions.Count > 0
        End Function

        Protected Overridable Sub ToolBarClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs)
            Dim x As Telerik.Web.UI.RadToolBarButton = CType(e.Item, Telerik.Web.UI.RadToolBarButton)
            Select Case x.Value
                Case "CONSULTAR"
                    For Each column As Telerik.Web.UI.GridColumn In Grid.MasterTableView.OwnerGrid.Columns
                        column.CurrentFilterFunction = Telerik.Web.UI.GridKnownFunction.NoFilter
                        column.CurrentFilterValue = String.Empty
                    Next
                    OperacionesCustomizadasClickConsultar()
                    Grid.MasterTableView.FilterExpression = String.Empty
                    Grid.Rebind()
            End Select
        End Sub

        Protected Function startIndex() As Integer
            Return If(ShouldApplySortFilterOrGroup(), 0, Grid.CurrentPageIndex * Grid.PageSize)
        End Function

        Protected Function maxRows() As Integer
            Return If(ShouldApplySortFilterOrGroup(), Integer.MaxValue, Grid.PageSize)
        End Function
        Public Function GetSelItem(vGrid As RadGrid, Boton As Telerik.Web.UI.RadToolBarButton) As Boolean

            Dim b As GridItem = Nothing
            Dim KeyDictionary As New Dictionary(Of String, String)
            Dim KeyDictionaryBoton As New Dictionary(Of String, String)

            '1.0 Prepara Parametros
            KeyDictionaryBoton.Add("IMAGEN_BOTON", Boton.ImageUrl)
            KeyDictionaryBoton.Add("NOMBRE_OPCION", Boton.Text)
            KeyDictionaryBoton.Add("OP", Boton.Value)

            Session("BotonSel") = KeyDictionaryBoton

            If InStr(Boton.Value.ToUpper, "CREAR") = 0 Then
                If vGrid.Items.Count > 0 Then
                    Dim SelItem As Telerik.Web.UI.GridDataItem = vGrid.Items(0)
                    If vGrid.Items.Count > 1 Then
                        If vGrid.SelectedItems.Count > 0 Then SelItem = DirectCast(vGrid.SelectedItems(0), Telerik.Web.UI.GridDataItem)
                    End If
                    For i = 0 To vGrid.MasterTableView.DataKeyNames().Length - 1
                        KeyDictionary.Add(vGrid.MasterTableView.DataKeyNames()(i), SelItem.GetDataKeyValue(vGrid.MasterTableView.DataKeyNames()(i)))
                    Next
                    Session("SelItem") = KeyDictionary
                    Return True
                End If
            End If
            Return False
        End Function
    End Class
End Namespace