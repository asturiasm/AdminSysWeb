<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><%@ Page Language="vb" AutoEventWireup="false" Inherits="SIGESWeb.errLogin" CodeFile="errLogin.aspx.vb" %>
<!--modificado - se quito el header con un script -->
<HTML>
	<HEAD>
		<title>Sistema de Gestión [SIAF-SAG]</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link type="text/css" rel="stylesheet" href="../Styles.css">
		<SCRIPT TYPE="text/javascript">
		<!--
		if(self != top) top.location = self.location;
		//-->
				
		</SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" width=100%>
				<tr>
					<td align="left" bgcolor="#3B71A6"><IMG alt="" src="../img/logosiaf.gif" style="WIDTH: 85px; HEIGHT: 89px" height="89" width="85"></td>
					<td align="left" bgcolor="#3B71A6"></td>
				</tr>
			</table>
			<br>
			<br>
			<br>
			<br>
			<br>
			<br>
			<br>
			<table align="center">
				<tr>
					<td class="Encabezado">Error en la sesión
						<br>
						<br>
						<asp:Label CssClass="MensajeError" id="Lbl_Error" runat="server" Width="381px" Height="51px">Error en la autenticacion</asp:Label>
						<br>
						<asp:LinkButton id="LinkButton1" CssClass="LinkBlanco" runat="server" Width="104px" Height="21px">Iniciar Sesi&oacute;n</asp:LinkButton>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
