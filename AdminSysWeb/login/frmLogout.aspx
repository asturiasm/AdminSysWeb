<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><%@ Page Language="vb" AutoEventWireup="false" Inherits="SIGESWeb.frmLogout" CodeFile="frmLogout.aspx.vb" %>
<!--modificado - se quito el header con un script -->
        

<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Sistema de Gestión [SIAF-SAG]</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0" />
		<meta name="vs_defaultClientScript" content="JavaScript" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<link href="../Styles.css" rel="stylesheet" type="text/css" />
	</head>
	<body style="margin-top:0;">
		<form id="Form1" method="post" runat="server">
		    <table id="Table3" class="LogOutInterno">
				<tr>
					<td style="HEIGHT: 110px" align="center" colspan="4">
						<img alt="" src="../img/logosiges.jpg" width="100%" />
						<br />
						<p style="font-family:Verdana; font-size:18; color:#ffffff">Final de la sesión</p>
					</td>
				</tr>
				<tr>
					<td align="center" colspan="4">
						<asp:LinkButton id="Linkbutton2" runat="server" CssClass="LinkBlanco" Font-Names="Verdana">Iniciar Sesi&oacute;n</asp:LinkButton>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
