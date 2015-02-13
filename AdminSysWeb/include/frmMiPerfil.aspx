<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><%@ Page Language="vb" AutoEventWireup="false" Inherits="SIGESWeb.frmMiPerfil" CodeFile="frmMiPerfil.aspx.vb" %>
<!--modificado - se quito el header con un script -->
<HTML>
	<HEAD>
		<title>Actualizacion de Datos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		
			function ValidarDatos()
			{
				var theForm = document.forms[0];
				if (theForm.NIT.value.length > 12 ) 
				{
					window.alert('El NIT no debe contener mas de 12 caracteres. \nActualmente se han ingresado: '+ theForm.NIT.value.length +' Caracteres');
					return false;
				}
				if (theForm.TELEFONO.value.length > 20)
				{
					window.alert('El TELEFONO no puede ser mayor a 20 caracteres. \nActualmente se han ingresado: '+ theForm.TELEFONO.value.length +' Caracteres');
					return false;
				}
				if (theForm.DIRECCION.value.length > 100)
				{
					window.alert('La DIRECCION no puede ser mayor a 100 caracteres. \nActualmente se ha ingresado: '+ theForm.DIRECCION.value.length +' Caracteres');
					return false;
				}
				if (theForm.EMAIL.value.length > 50)
				{
					window.alert('El EMAIL se ha considerado invalido debido a que ha sobrepasado los 50 caracteres, por favor verifique. \nActualmente se ha ingresado: '+ theForm.EMAIL.value.length +' Caracteres');
					return false;
				}
			}
		
		</script>
	</HEAD>
	<body onload="document.getElementById('NIT').focus();">
		<form id="Form1" method="post" runat="server" onsubmit="return ValidarDatos()" >
        <table id="Table1"  cellSpacing="1" cellPadding="1" width="100%" align="center" border="0"  title="Actualización de Datos" >
            <tr><td colspan="8"><br /></td></tr>
            <tr>
                <td colspan="8" class="ColTitulo" align="left">Por motivos de seguridad, es necesario que actualice sus datos, por lo que rogamos sirvase completar la información que se le solicita a continuación:</td>
            </tr>
            <tr>
				<td><br /></td>
		     </tr>
			<tr>
				<td class="ColTitulo" colspan="8">ACTUALIZACIÓN DE DATOS</td>
			</tr>
			<tr>
				<td colspan="8"><br /></td>
			</tr>
			<tr>
				<td class="ColTitulo" width="30%">Usuario</td>
				<td class="ColDatos" colspan="7" width="70%"><asp:TextBox id="USUARIO" runat="server" Enabled="False" Width="50%"></asp:TextBox></td>
			</tr>
				<TR>
					<TD class="ColTitulo" width="30%"><font color="#ffcc00" size="3">*</font>Nit</TD>
					<TD class="ColDatos" colspan="7" width="70%"><asp:TextBox id="NIT" runat="server" Width="50%"></asp:TextBox></TD>
                    <td><asp:RequiredFieldValidator id="RQValidatorNIT" runat="server" Width="0%" ErrorMessage="Debe Ingresar un numero de NIT."
							Height="8px" ControlToValidate="NIT">*</asp:RequiredFieldValidator></td>
                    
				</TR>
                <TR>
					<TD class="ColTitulo" width="30%"><font color="#ffcc00" size="3">*</font>Apellidos</TD>
					<TD class="ColDatos" colspan="7" width="70%"><asp:TextBox id="APELLIDOS" runat="server" Width="98%"></asp:TextBox></TD>
                    <td><asp:RequiredFieldValidator id="RQValidatorApellidos" runat="server" Width="0%" ErrorMessage="Debe Ingresar sus Apellidos."
							Height="8px" ControlToValidate="APELLIDOS">*</asp:RequiredFieldValidator></td>
                    
				</TR>
                 <TR>
					<TD class="ColTitulo" width="30%"><font color="#ffcc00" size="3">*</font>Nombres</TD>
					<TD class="ColDatos" colspan="7" width="70%"><asp:TextBox id="NOMBRES" runat="server" Width="98%"></asp:TextBox></TD>
                    <td><asp:RequiredFieldValidator id="RQValidatorNombres" runat="server" Width="0%" ErrorMessage="Debe Ingresar sus Nombres."
							Height="8px" ControlToValidate="NOMBRES">*</asp:RequiredFieldValidator></td>
				</TR>
                <TR>
					<TD class="ColTitulo">Teléfono</TD>
					<TD class="ColDatos" colspan="7"><asp:TextBox id="TELEFONO" runat="server" Width="98%"></asp:TextBox></TD>
				</TR>
				<tr>
					<TD class="ColTitulo">Dirección</TD>
					<TD class="ColDatos" colspan="7"><asp:TextBox id="DIRECCION" runat="server" Width="98%"></asp:TextBox></TD>
				</tr>
				<tr>
					<TD class="ColTitulo" width="30%"><font color="#ffcc00" size="3">*</font>E-mail</TD>
					<TD class="ColDatos" colspan="7" width="70%"><asp:TextBox id="EMAIL" runat="server" Width="98%"></asp:TextBox></TD>
                    <td><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="0%" ErrorMessage="Debe Ingresar una Dirección de Correo Electrónico."
							Height="8px" ControlToValidate="EMAIL">*</asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" Width="8px" ErrorMessage="Debe Ingresar una Dirección de Correo Electrónico Válida."
							Height="32px" ControlToValidate="EMAIL" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
				</tr>
				<tr>
					<td colspan="8"><br /></td>
				</tr>
				<tr>
					<td colspan="8" align="center">
						<br />
						<asp:Button id="Actualizar" runat="server" Text="Actualizar Datos"></asp:Button>
					</td>
				</tr>
                <tr>
					<td colspan="8"><br /></td>
				</tr>
                <tr>
                    <td colspan="8"><asp:ValidationSummary id="ValidationSummary1"  runat="server" Width="100%" ShowMessageBox="False" ShowSummary="True"></asp:ValidationSummary></td>
                </tr>
			</table>
			
		</form>
	</body>
</HTML>
