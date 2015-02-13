<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><%@ Page Language="vb" AutoEventWireup="false" Inherits="SIGESWeb.frmContactenos" CodeFile="frmContactenos.aspx.vb" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"  Namespace="System.Web.UI" TagPrefix="asp" %>
<!--modificado - se quito el header con un script -->
        
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>SIGESWeb - Contáctenos</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body style="overflow:visible;width:95%" onload="findElement('TxtNombre').focus()">
	
		<form id="Form1" method="post" runat="server">
			<table class="TableContainer">
				<tr>
					<td class="Encabezado">
						<P>Contáctenos</P>
						<P>(Ingrese sus datos para que podamos responderle)</P>
					</td>
				</tr>
				<tr valign="middle">
					<td>
						<table class="FormTable">
							<tr>
								<td class="ColTitulo"><span class="AsteriscoAmarillo">*</span>Ingrese su Nombre</td>
								<td class="ColDatos">
									<asp:TextBox id="TxtNombre" runat="server" Width="355px"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Debe especificar su nombre"
										ControlToValidate="TxtNombre">*</asp:RequiredFieldValidator><FONT size="3"></FONT>
								</td>
							</tr>
							<tr>
								<td class="ColTitulo"><font color="#ffcc00" size="3">*</font>Ingrese su&nbsp; 
									E-mail</td>
								<td class="ColDatos">
									<asp:TextBox id="TxtEmail" runat="server" Width="355px"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Debe especificar su e-mail"
										ControlToValidate="TxtEmail">*</asp:RequiredFieldValidator>
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Formato inválido"
										ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
								</td>
							</tr>
							<tr>
								<td class="ColTitulo"><font color="#ffcc00" size="3">*</font>Asunto</td>
								<td class="ColDatos">
									<asp:TextBox id="TxtAsunto" runat="server" Width="355px"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Debe especificar el Asunto"
										ControlToValidate="TxtAsunto">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td class="ColTitulo" style="HEIGHT: 13px">Prioridad</td>
								<td class="ColDatos" style="HEIGHT: 13px">
									<asp:DropDownList id="DDLPrioridad" runat="server" Width="171px"></asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td class="ColTitulo"><font color="#ffcc00" size="3">*</font>Su Mensaje</td>
								<td class="ColDatos">
									<asp:TextBox id="TxtMensaje" runat="server" TextMode="MultiLine" Width="446px" Height="137px"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Debe especificar el mensaje"
										ControlToValidate="TxtMensaje">*</asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td align="center" colspan="2">
									<br>
									<asp:Button id="BtnEnviar" runat="server" Text="Enviar"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<asp:ValidationSummary id="ValidationSummary1" style="Z-INDEX: 101; LEFT: 278px; POSITION: absolute; TOP: 451px"
				runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
		</form>
	</body>
</HTML>
