 
Imports System.Xml
Imports Telerik.Web.UI
Imports System.Linq
Imports System.Collections.Generic

Namespace SIGESWeb
    Partial Class ADM_Mantenimiento
        Inherits System.Web.UI.MasterPage
        Private _UD As Integer = 0 'Unidad desconcentrada, siempre es 0

        ''' <summary>
        ''' Ejercicio seleccionado
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Ejercicio As Integer
            Get
                Return CInt(CType(Session("PARAMETROS"), XmlDocument).SelectSingleNode("PARAMETROS/PEJER_EJECUCION").InnerText)
            End Get
        End Property

        ''' <summary>
        ''' Entidad seleccionada
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Entidad As Integer
            Get
                Return CInt(CType(Session("PARAMETROS"), XmlDocument).SelectSingleNode("PARAMETROS/PENTIDAD").InnerText)
            End Get
        End Property

        ''' <summary>
        ''' Unidad ejecutora seleccionada (Usualmente solo tendría un valor distinto a 0 en secretarías)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property UE As Integer
            Get
                Return CInt(CType(Session("PARAMETROS"), XmlDocument).SelectSingleNode("PARAMETROS/PUNIDAD_EJECUTORA").InnerText)
            End Get
        End Property

        ''' <summary>
        ''' Unidad Desconcentrada (0 por defecto)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property UD As Integer
            Get
                Return _UD
            End Get
        End Property

        ''' <summary>
        ''' Unidad de Negocios seleccionada representado por el código de unidad de compras
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property UC As Integer
            Get
                Return CInt(CType(Session("PARAMETROS"), XmlDocument).SelectSingleNode("PARAMETROS/PUNIDAD_COMPRADORA").InnerText)
            End Get
        End Property

        Public Property Objeto As String
            Get
                Return hidObjeto.Value
            End Get
            Set(value As String)
                hidObjeto.Value = value
            End Set
        End Property

        Public Property ToolBar As Telerik.Web.UI.RadToolBar
            Get
                Return RadToolBar1
            End Get
            Set(value As Telerik.Web.UI.RadToolBar)
                RadToolBar1 = value
            End Set
        End Property

        Private Sub LoadToolbar()
            Dim ws As clsSIGESProxyWrapper = SIGESWeb.clsInstanciaAplicacion.InstanciaWSGenerico(Me.Context)
            Dim objToolBar = ws.CargarToolBar(Objeto, Session("USUARIO"))
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


        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                Me.LoadToolbar()
            End If
        End Sub

  
    End Class
End Namespace
