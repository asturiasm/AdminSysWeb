<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><%@ Page Language="vb" AutoEventWireup="false" Inherits="SIGESWeb.frmMensajeExito" CodeFile="frmMensajeExito.aspx.vb" %>
<!--modificado - se quito el header con un script -->
<HTML>
	<HEAD>
		<title>frmMensajeError</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../Styles.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="100%" style="display:none">
				<tr>
					<td>
						<table align="center" style="WIDTH: 389px; HEIGHT: 35px">
							<tr>
								<td class="Encabezado" valign="top">
									Operación Exitosa JEJE&nbsp;
									<asp:Label CssClass="MensajeError" id="LblMensaje" runat="server" Width="381px" Height="20px">Error en la autenticacion</asp:Label>
									<asp:Button id="salir" runat="server" Text="Aceptar"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
