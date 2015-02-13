<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><%@ Page Language="vb" AutoEventWireup="false" codefile="frmCambioPWD.aspx.vb" Inherits="SIGESWeb.frmCambioPWD" %>
<!--modificado - se quito el header con un script -->
<HTML>
	<HEAD>
		<title>frmCambioPWD</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table width="80%" height="80%" border="0" align="center">
				<tr>
					<td class="Encabezado" height="8%">Cambio de clave</td>
				</tr>
				<tr valign="center">
					<td>
						<table class="grid" align="center">
							<tr>
								<td class="ColTitulo">Usuario</td>
								<td class="ColDatos">
									<asp:Label id="Label1" runat="server" class="ColDatos">Label</asp:Label></td>
							</tr>
							<tr>
								<td class="ColTitulo">Clave Anterior</td>
								<td class="ColDatos">
									<asp:TextBox id="TxtClaveAnterior" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Debe especificar la clave anterior" ControlToValidate="TxtClaveAnterior">*</asp:RequiredFieldValidator></td>
							</tr>
							<tr>
								<td class="ColTitulo">Clave Nueva</td>
								<td class="ColDatos">
									<asp:TextBox id="TxtClaveNueva" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Debe especificar la nueva clave" ControlToValidate="TxtClaveNueva">*</asp:RequiredFieldValidator>
									<asp:CompareValidator id="CompareValidator2" runat="server" Operator="NotEqual" ErrorMessage="La clave nueva es igual a la anterior" ControlToValidate="TxtClaveNueva" ControlToCompare="TxtClaveAnterior">*</asp:CompareValidator></td>
									<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="La clave nueva es distinta a la confirmación" ControlToValidate="TxtClaveNueva" ControlToCompare="TxtConfNueva">*</asp:CompareValidator></td>
							</tr>
							<tr>
								<td class="ColTitulo">Confirmar Clave Nueva</td>
								<td class="ColDatos">
									<asp:TextBox id="TxtConfNueva" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
									<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Debe confirmar la nueva clave" ControlToValidate="TxtConfNueva">*</asp:RequiredFieldValidator></td>
							</tr>
							<tr>
							   <td class="ColTitulo" colspan=2 style="TEXT-ALIGN: left"> El Password debe de cumplir con las siguientes caracteristicas:
							    <ul style="TEXT-ALIGN: left">
							      <li >Longitud Minima de 8 Carateres.</li>
							      <li >Al menos un numero.</li>
							      <li>Al menos un caracter en minúscula.</li>
							      <li>Al menos un caracter en Mayúscula.</li>
							      <li>Al menos un carácter especial de los siguiente @#$%^&amp;+=-_ </li>
							    </ul>
							   </td>
							</tr>
							<tr>
								<td align="middle" colspan="2">
									<br>
									<asp:Button id="Button1" runat="server" Text="Cambiar Clave"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
		</form>
	</body>
</HTML>
