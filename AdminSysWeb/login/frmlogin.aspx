<!DOCTYPE html>
<%@ Page Language="vb"  AutoEventWireup="false" Inherits="SIGESWeb.frmlogin" CodeFile="frmlogin.aspx.vb" ValidateRequest="true"%>
<html> 
	<head>
		<title>Siaf Siges Login</title>
		<link rel="stylesheet" type="text/css" href="../Styles.css"/>
        <script type="text/javascript" src="../Scripts/jquery-1.10.2.min.js"></script>
        <script type="text/javascript" src="../Scripts/jquery-ui-1.10.3.min.js"></script>
	    <script type="text/javascript">
			// Variable para determinar si submit de la forma lo realizó la opción de PROVEEDORES			
		    function limpiar()
		    {
		      window.navigate('about:blank');
		      window.history.length=0;
		    }
		    
            function verCertificado()
            {
                var str = window.location.host.toUpperCase();
                var nom = 'SIGES.MINFIN.GOB.GT';
			    window.open("https://seal.verisign.com/splash?form_file=fdf/splash.fdf&dn="+nom+"&lang=es","VeriSign","width=600,height=465,toolbars=no;scrollbars=yes");
	         }            
		</script>
	</head>

<body onload="document.getElementById('TxtUsuario').focus();" style="font-family:Verdana;font-size:14px">
<div class="header" id="DivHeader" style="background-image :url('../img/background_banner.jpg')">
	<img src="../img/banner.jpg" alt="Siges Logo" style="height:100%;width:auto"/>
</div>
<div class="escritorio" id="escritorio" style="width:100%;" >
    <div class="leftPanel" id="leftPanel" style="width:70%;background-image:url('../img/background.jpg')" >
        <div class="IconsPanel" > 
            <table style="width:100%;border-collapse:collapse" class="TableDistr">
                <tr style="height:18px">
                    <td style="width:5%;background-image:url('../img/curva_izquierda_arriba.gif');" ></td>
                    <td style="width:50%;background-color:white;"></td>
                    <td style="width:20%;background-color:white;"></td>                    
                    <td style="width:15%;background-image:url('../img/curva_derecha_arriba.gif');background-position:right;background-repeat:no-repeat"></td>
                </tr>
                <tr style="height:40px">
                    <td colspan="4" style="background-color:white;background-image:url('../img/fondo_background.jpg');background-position:right;background-repeat:no-repeat">&nbsp;</td>
                </tr>                
                <tr style="height:30px">
                    <td style="background-color:#206094;"></td>
                    <td style="background-color:#206094;color:white;font-size:18px">Estimado Usuario: Bienvenido</td>
                    <td style="background-color:white;"></td>
                    <td style="background-color:white;background-image:url('../img/fondo_background.jpg');background-position:right;background-repeat:no-repeat">&nbsp;</td>
                </tr>
                <tr style="height:382px" >
                    <td style="background-color:#ffffff;"></td>
                    <td colspan="2" style="background-color:#ffffff;">
                        <table style="width:100%">
                            <tr>
                                <td style="background-color:#dff3fd;">Dirección de Soporte para el sistema SIGES soportesiafsag@minfin.gob.gt</td>
                            </tr>
                            <tr>
                                <td>Para comunicarse a la Mesa de Ayuda, teléfonos  2322-8888 ext. 10425, 10426, 10427, 10428, 10429, 10430 y 10431.</td>
                            </tr>   
                            <tr>
                                <td style="background-color:#dff3fd;">Para las consultas de ejecución del presupuesto deberán hacerse a Contabilidad del Estado al teléfono 2322888, Ext. 10434, 10435, 10437 y 10439.</td>
                            </tr>
                            <tr>
                                <td style="padding-top:5%"><a href="javascript:verCertificado();"><img src="../img/LogoVeriSign2.gif" alt="" /></a></td>
                            </tr>                                               
                        </table>
                    </td>
                    <td style="background-color:white;background-image:url('../img/fondo_background.jpg');background-position:right;background-repeat:no-repeat">&nbsp;</td>
                </tr>
               <tr style="height:40px">
                    <td colspan="4">
                        <table style="width:100%;border-collapse:collapse" class="TableDistr" >
                            <tr style="height:40px">
                                <td style="width:10%;background-image:url('../img/curva_izquierda_bottom.gif')"></td>
                                <td style="width:80%;background-image:url('../img/fondo_final_tabla.gif')"></td>
                                <td style="width:10%;background-image:url('../img/curva_derecha_bottom.gif');background-position:right"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="RightPanel" id="rightPanel" style="width:30%;background-image:url('../img/background.jpg')">
        <div class="IconsPanel" style="width:95%;" > 
            <table style="width:95%;" class="TableDistr">
                <tr style="height:40px;">
                    <td style="width:10%;background-image:url('../img/curva_izquierda_arriba_noticias.gif');" ></td>
                    <td style="width:80%;background-image:url('../img/fondo_final_tabla_noticias.gif')"></td>
                    <td style="width:10%;background-image:url('../img/curva_derecha_arriba_noticias.gif');background-position:right;background-repeat:no-repeat"></td>
                </tr>             
                <tr style="height:430px;" >
                    <td colspan="3" style="background-color:#ffffff;">
                        <form id="Form2" method="post" runat="server">
                            <table style="width:100%;border-spacing:0px;">
                                <tr style="background-color:#206094;color:White;height:30px;">
                                    <td style="width:10%;">&nbsp;</td>
                                    <td>Datos de usuario</td>
                                </tr>
                                <tr style="height:5px;">
                                    <td colspan="2" style="background-color:White;text-align:center;"></td>
                                </tr>                                                     
                                <tr style="background-color:#dff3fd;">
                                    <td colspan="2">&nbsp;</td>
                                </tr>                        
                                <tr style="background-color:#dff3fd;height:30px;">
                                    <td>&nbsp;</td>
                                    <td>Usuario</td>
                                </tr>
                                <tr style="background-color:#dff3fd;">
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox id="TxtUsuario"  tabindex="1" runat="server"  Width="80%"/>
                                        <asp:RequiredFieldValidator runat="server" ID="reqUsuario" ControlToValidate="TxtUsuario" Text="*" ErrorMessage="El campo USUARIO es obligatorio" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="regUser" ControlToValidate="TxtUsuario" Text="*" validationexpression="^([_a-zñA-ZÑ0-9@.\s]{1,25})$" Display="Dynamic" errormessage="El usuario no es válido, revise sus datos." />
                                    </td>
                                </tr>   
                                <tr style="background-color:#dff3fd;height:30px">
                                    <td>&nbsp;</td>
                                    <td>Contraseña</td>
                                </tr>
                                <tr style="background-color:#dff3fd;">
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:TextBox id="TxtPassword" tabindex="2" runat="server" TextMode="Password" Width="80%"/>
                                        <asp:RequiredFieldValidator runat="server" ID="reqPass" ControlToValidate="TxtPassword" Text="*" ErrorMessage="El campo CONTRASEÑA es obligatorio" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="background-color:#dff3fd;">
                                    <td colspan="2">&nbsp;</td>
                                </tr>                         
                                <tr style="height:5px">
                                    <td colspan="2" style="background-color:White;text-align:center;">&nbsp;</td>
                                </tr>
                                <tr style="height:30px">
                                    <td colspan="2" style="background-color:#206094;color:White;text-align:center;"><asp:Button Text="Ingresar" ID="Button1" runat="server"/></td>
                                </tr>
                            </table>
                            <asp:ValidationSummary CssClass="colDatos" id="valSummary" runat="server" DisplayMode="BulletList" HeaderText="Datos incorrectos, debe revisar lo siguiente:"></asp:ValidationSummary>
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </form>
                    </td>
                </tr>
               <tr style="height:40px">
                    <td colspan="3">
                        <table style="width:100%;border-collapse:collapse" class="TableDistr" >
                            <tr style="height:40px">
                                <td style="width:10%;background-image:url('../img/curva_izquierda_bottom.gif')"></td>
                                <td style="width:80%;background-image:url('../img/fondo_final_tabla.gif')"></td>
                                <td style="width:10%;background-image:url('../img/curva_derecha_bottom.gif');background-position:right"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>        
</body>
</html>
