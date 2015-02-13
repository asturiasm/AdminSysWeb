<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ Page Language="vb" AutoEventWireup="false" Inherits="SIGESWeb.frmMensajeError" CodeFile="frmMensajeError.aspx.vb" %>
<!--modificado - se quito el header con un script -->
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>frmMensajeError</title>
		<link href="../Styles.css" type="text/css" rel="stylesheet" />
		<script src="../menu/mtmtrack.js" type="text/javascript"></script>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="100%" style="display:none">
			    <colgroup>
			        <col width="50%" />
			        <col width="50%" />
			    </colgroup>
			    <tr>
			        <td class="Encabezado" colspan="2" valign="middle">Error en la operación</td>
			    </tr>
				<tr>
                    <td colspan="2">
						<asp:label id="LblMensaje" runat="server" CssClass="MensajeError">Error en la autenticacion</asp:label>
				    </td>
				</tr>
				<tr>
				    <td>
						<a id="salir" class="LinkBlanco" href="javascript: history.go(-1)">Regresar</a>
					</td>
					<td>	
						<a class="LinkBlanco" href="javascript: goDetalle();">Ver Detalle</a>
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
