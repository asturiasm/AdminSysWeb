<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd"><%@ Page Language="vb" AutoEventWireup="false" Inherits="SIGESWeb.calendario" CodeFile="calendario.aspx.vb" %>
<!--modificado - se quito el header con un script -->
<html>
  <head>
    <title>calendario</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <script src="../include/calendariojs.js" type="text/javascript"></script>
<script language="javascript">
	function EnviarFecha()
	{
		var campo='<%=Request.QueryString("CAMPO").ToString()%>';
		//con este codigo se encontraba al principio es decir antes de que funcionara para visualizarce en MOZILLA
		//eval("window.opener.Form1."+campo+".value='"+ document.getElementById('fecha').value + "'");
		//Este codigo se dejo para que pudiera pasar la fecha utilizando cualquier navegador.
		eval("window.opener.document.Form1."+campo+".value=document.getElementById('fecha').value");
		window.opener.focus();
		window.close();	
	}	
</script>
</head>
<body onload="calendarioShow(document.getElementById('fecha'));">
    <form id="Form1" method="post" runat="server">
		<input type="hidden" id="fecha" name="fecha" />
    </form>
</body>
</html>
