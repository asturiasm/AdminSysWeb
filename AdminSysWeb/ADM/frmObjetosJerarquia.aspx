<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ Page Language="vb"    AutoEventWireup="false" Inherits="SIGESWeb.frmObjetosJerarquia" CodeFile="frmObjetosJerarquia.aspx.vb"  MaintainScrollPositionOnPostback="true" %>
 
<%@ Register TagPrefix="cc3" Namespace="CC_Titulos" Assembly="CC_Titulos" %>
<%@ Register TagPrefix="cc1" Namespace="ctrlTitulos.ctrlTitulos" Assembly="ctrlTitulos" %>


<!--modificado - se quito el header con un script -->
<HTML>
	<HEAD>
		<title>Ingreso De Usuarios</title>
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
		<LINK rel="stylesheet" type="text/css" href="../estilos/EstilosGenerales.css">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
         <style type="text/css" > 
             
            /** Columns */
                .rcbHeader ul,
                .rcbFooter ul,
                .rcbItem ul,
                .rcbHovered ul,
                .rcbDisabled ul {
                     margin: 0;
                     padding: 0;
                     width: 100%;
                     display: inline-block;
                     list-style-type: none;                     
                }

             .col1 {
                     margin: 0;
                     padding: 0 0px 0 0;
                     width: 60px;
                     line-height: 14px;
                     float: left;      
             }
                .col {
                     margin: 0;
                     padding: 0 0px 0 0;
                     width: 75px;
                     line-height: 14px;
                     float: left;                     
                }
  
                /** Multiple rows and columns */
                .multipleRowsColumns .rcbItem,
                .multipleRowsColumns .rcbHovered {
                     float: left;
                     margin: 0 1px;
                     min-height: 13px;
                     overflow: hidden;
                     padding: 2px 19px 2px 6px;
                     width: 125px;
                }
              
            img.rtImg{width: 17px; height: 18px;}
                    
        </style>
       
	</HEAD>
	<body class="FondoPantalla">
         <script type="text/javascript">
             function openWin() {
                 var oWnd = radopen(null, "RWAConsultar");
             }
        </script>
		<form id="Form1" method="post" runat="server">
            
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:textbox id="HISTORICO" runat="server" Visible="False" Enabled="False" Width="15px" MaxLength="20"></asp:textbox>
			<asp:textbox id="REGULARIZACION" runat="server" Visible="False" Enabled="False" Width="15px" MaxLength="20"></asp:textbox>
			<asp:textbox id="EJECUCION_FORMULACION" runat="server" Visible="False" Enabled="False" Width="15px" MaxLength="20"></asp:textbox>
			<asp:textbox id="RESTRICTIVA" runat="server" MaxLength="20" Width="15px" Enabled="False" Visible="False"></asp:textbox>
                 <div style="text-align:left;">
            <telerik:RadToolBar ID="RadToolBar1" runat="server" Skin="Office2007"></telerik:RadToolBar>
        </div>
            <cc3:CC_Titulos ID="CC_Titulos1" runat="server" EnableViewState="True"></cc3:CC_Titulos>
            <table width="100%">
			   <colgroup>
                            <col width="20%"/>
                            <col width="30%"/>
                            <col width="20%"/>
                            <col width="30%"/>
                </colgroup> 
                <tr>
			        <td colspan="4" class="ColTitulo">Administración de Objetos en Gerarquía</td>
		        </tr> 
            </table>   
               
              <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="btnMostrar">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="TreeViewFuncion" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                         <telerik:AjaxSetting AjaxControlID="TreeViewFuncion">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RWMostrar" LoadingPanelID="rlp" />
                                <telerik:AjaxUpdatedControl ControlID="TreeViewFuncion" LoadingPanelID="rlp" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>                
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" MinDisplayTime="2000"
                    Skin="Office2007">
                </telerik:RadAjaxLoadingPanel>   
 
            <telerik:RadTreeView ID="ArbolObjetos"  runat="server" Width="500px" Height="550px" BorderColor="Black">
                    <%-- <ContextMenus>
                        <telerik:RadTreeViewContextMenu ID="MainContextMenu" runat="server">
                            <Items>                                
                                <telerik:RadMenuItem Value="PERFIL" Text="Perfiles" ImageUrl="~/img/arbol_img/Functions.png">
                                </telerik:RadMenuItem>                            
                                <telerik:RadMenuItem Value="FUNCION" Text="funciones" ImageUrl="~/img/arbol_img/Profile.png">
                                </telerik:RadMenuItem>                            
                            </Items>
                            <CollapseAnimation Type="InBack"></CollapseAnimation>
                        </telerik:RadTreeViewContextMenu>
                     </ContextMenus> --%>
                            <DataBindings>
                                <telerik:RadTreeNodeBinding Expanded="true" />
                            </DataBindings>
                    </telerik:RadTreeView>

             <telerik:RadAjaxLoadingPanel id="rlp" Runat="server"  Skin="Default"></telerik:RadAjaxLoadingPanel>
 
            <table class="tabla1" id="Table3" cellspacing="1" cellpadding="1" border="1" width="100%">
			    <colgroup>
			        <col width="25%" />
			        <col width="25%" />
			        <col width="25%" />
			        <col width="25%" />
			    </colgroup>
                <tr>
					<td class="ColDatos" align="right" colspan="4">
                        <asp:ImageButton  id="GRABAR" runat="server" ToolTip="Modificar" ImageUrl="../img/modificar.gif" Visible="false"  ></asp:ImageButton>
					    &nbsp;
					    <asp:ImageButton id="SALIR" runat="server" ToolTip="Salir" ImageUrl="../img/salir.gif" CausesValidation="False"></asp:ImageButton>
					</td>
				</tr>	
			</table>
			
		</form>
	</body>
</HTML>
