<%@ Page Title="" Language="VB" MasterPageFile="~/ADM/Mantenimiento.master" AutoEventWireup="false" CodeFile="frmObjetosMetadata.aspx.vb" Inherits="SIGESWeb.ADM_frmObjetosMetadata" %>
<%@ MasterType VirtualPath="~/ADM/Mantenimiento.master"  %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="TituloPagina" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Datos" Runat="Server">
 
    	

            <asp:textbox id="HISTORICO" runat="server" Visible="False" Enabled="False" Width="15px" MaxLength="20"></asp:textbox>
			<asp:textbox id="REGULARIZACION" runat="server" Visible="False" Enabled="False" Width="15px" MaxLength="20"></asp:textbox>
			<asp:textbox id="EJECUCION_FORMULACION" runat="server" Visible="False" Enabled="False" Width="15px" MaxLength="20"></asp:textbox>
			<asp:textbox id="RESTRICTIVA" runat="server" MaxLength="20" Width="15px" Enabled="False" Visible="False"></asp:textbox>
            
             
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
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" MinDisplayTime="2000"
                    Skin="Office2007">
                </telerik:RadAjaxLoadingPanel>   
 
            <telerik:RadTreeView ID="ArbolObjetos"  runat="server" EnableViewState="false" PersistLoadOnDemandNodes ="false" Width="500px" Height="550px" BorderColor="Black">
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


<%--      <telerik:RadGrid ID="grdMantenimiento" Visible="false" GridLines="None" runat="server" 
        AutoGenerateColumns="False" Skin="Vista" ShowFooter="true" 
        AllowPaging="true" PageSize="10" AllowMultiRowSelection="false" AllowFilteringByColumn="true" 
        ShowStatusBar="false" AllowCustomPaging="true">
        <ClientSettings>
            <Selecting AllowRowSelect="true"/>            
        </ClientSettings>
        <Mastertableview DataKeyNames="GESTION" CommandItemDisplay="Top" EditMode="InPlace" NoMasterRecordsText="No hay registros para mostrar." Caption="Politica" AllowFilteringByColumn="false">
            <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false"  />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
            </RowIndicatorColumn>
            <Columns> 
                <telerik:GridClientSelectColumn Display="true" Visible="true" UniqueName="Sel"></telerik:GridClientSelectColumn>
                <telerik:GridBoundColumn DataField="GESTION" HeaderText="Gestion" UniqueName="GESTION">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NOMBRE" HeaderText="Nombre" UniqueName="NOMBRE">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" UniqueName="Estado">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ETAPA_FORMULACION" HeaderText="Etapa" UniqueName="ETAPA_FORMULACION">
                </telerik:GridBoundColumn>
            </Columns>
        </Mastertableview>
    </telerik:RadGrid>--%>
 
</asp:Content>

