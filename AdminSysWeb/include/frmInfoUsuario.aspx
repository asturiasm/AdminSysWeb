<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><%@ Page Language="vb" AutoEventWireup="false" Inherits="SIGESWeb.frmInfoUsuario" CodeFile="frmInfoUsuario.aspx.vb" %>
<!--modificado - se quito el header con un script -->
<HTML>
	<HEAD>
		<title>Información de Usuario</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Styles.css">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101;  WIDTH: 100%;  POSITION: absolute" cellSpacing="1"
				cellPadding="1" width="100%" border="1">
				<TR width="40%">
					<TD class="ColTitulo">Nombre del usuario</TD>
					<TD class="ColTitulo">Puesto</TD>
				</TR>
				<TR width="60%">
					<TD class="ColDatos">
						<asp:Label id="LBLRegistro" runat="server">Label</asp:Label></TD>
					<TD class="ColDatos">
						<asp:Label id="LBLAnotacion" runat="server">Label</asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
