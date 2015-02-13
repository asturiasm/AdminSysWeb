<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ Page Language="vb" AutoEventWireup="false" Inherits="SIGESWeb.frmMensajeGenerico" CodeFile="frmMensajeGenerico.aspx.vb" %>
<!--modificado - se quito el header con un script -->
<html>
	<head>
		<title>frmMensajeGenerico</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link href="../Styles.css" type="text/css" rel="stylesheet" />
		
		<script language="javascript" type="text/javascript">
		    function aceptar(){
		        eval($('#LinkButton1').attr('href'));
		        startPage();
		        return true;
		    }
		    function startPage(){
		        var dialog  = null;
		        
		        if (parent.parent != null && parent.parent.SiafDialog != null){
		            dialog = new parent.parent.SiafDialog();
		        }
		        else if (parent != null && parent.SiafDialog != null)
		            dialog = new parent.SiafDialog();
		        else
		            dialog = new SiafDialog();
		           
		        var params = new Object();
		        
		        try{
		             $('#LinkButton1').click(function(){alert('hello!');alert('hello2!')});
		            dialog.showCustomInfo('Mensaje Genérico',$('#lblTitulo').text(),$('#LblMensaje').text(),$('#LinkButton1').text(),aceptar);
		        }catch(ex){
		            alert(ex.message);
		        }
		        
		    }
		</script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
            <div title="Mensaje Genérico" id="dialog" style="display:none"> 
			    <table width="100%">
				    <tr>
					    <td>
						    <table align="center" >
							    <tr>
								    <td class="Encabezado" valign="middle">
									    <asp:Label id="lblTitulo" runat="server">Label</asp:Label>
									    <asp:Label CssClass="MensajeError" id="LblMensaje" runat="server" Width="381px" Height="51px">Mensaje</asp:Label>
									    <asp:LinkButton id="LinkButton1" runat="server" >LinkButton</asp:LinkButton>
								    </td>
							    </tr>
						    </table>
					    </td>
				    </tr>
			    </table>
			</div>
		</form>
	</body>
</html>
