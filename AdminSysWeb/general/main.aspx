<%@ Page Language="VB" AutoEventWireup="false" CodeFile="main.aspx.vb" Inherits="SIGESWeb.general_main" MasterPageFile="~/include/SIGESMasterPage.master" %>
<%@ MasterType VirtualPath="~/include/SIGESMasterPage.master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <link rel="stylesheet" type="text/css" href="../menu.css"/>
    <style type="text/css">       
        #container    
        {   width :100%;height: 100%;margin: 0 auto;background-image :url('../img/background_banner.jpg'); }
        #ui-layout-north
        {   height:80px;padding:0px; }
        #ui-layout-center
        {   width:100%;height:85%;background-color:white;overflow:hidden;}
        body
        {   position: relative;height: 100%;}

        html 
        {   position:relative; height: 100%;}

        #myIframe 
        {   width:100%; height:100%; overflow:auto;
        }
        .LabelT
        { font-size:10px; color:white; }
        .Label
        { font-size:8px; color:white; }
    </style>
    <script type="text/javascript" src="../Scripts/jquery.hoverIntent.minified.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.dcmegamenu.1.3.3.js"></script>
    <script type="text/javascript">
        function showPass(url, titulo) {
            var opt = {
                autoOpen: false,
                modal: true,
                width: 550,
                height: 450,
                title: titulo
            };
            $("#divId")
                .html('<iframe id="modalIframeId" width="100%" height="100%" marginWidth="0" marginHeight="0" frameBorder="0" />')
                .dialog(opt)
                .dialog("open");
            $("#modalIframeId").attr("src", url);
            return false;
        }

        $(document).ready(function ($) {
            $('#mega-menu-5').dcMegaMenu({
                rowItems: '5',
                speed: 'fast',
                effect: 'fade'
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPagina" runat="server">
    <div id="container" style="overflow:hidden;">
        <div id="ui-layout-north">
            <table class="TableDistr" style="width:100%">
                <colgroup>
                    <col style="width:5%" />
                    <col style="width:30%" />
                    <col style="width:65%" />
                </colgroup>
                <tr>
                    <td>                    
                        <img src="../img/logo_homepage.gif" alt="Siges Logo" style="height:55px;width:auto" id="SIAF_LOGO"/>
                    </td>
                    <td style="color:white;font-size:18px">Sistema de Administración de Seguridad</td>
                    <td>
                        <table class="TableDistr" style="width:100%">
                            <colgroup>
                                <col style="width:25%" />
                                <col style="width:10%" />
                                <col style="width:65%" />
                            </colgroup>
                            <tr>
                                <td rowspan="2">
                                    <div class="modulo-actual">
                                        <asp:Label ID="NombreModulo" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td class="LabelT" >Sistema/Ambiente:</td>
                                <td >                      
                                    <telerik:RadComboBox ID="cmbSistema" Width="95%" runat="server" AutoPostBack="True"></telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div class="demo-container">
                <div id="superMenu" class="blue" runat="server"></div>
            </div>
            <asp:HiddenField ID="Last_url" runat="server"/>
        </div>
        <div id="ui-layout-center">
            <iframe src="../general/blank.htm" name="myIframe" id="myIframe"></iframe>
        </div>
        <div id="divId" title="" style="width:70%;" />
    </div>
</asp:Content>

