// Esconde los botones de grabar y salir para evitar que se haga doble click
function DeshabilitarBotones()
{
	var theForm = document.forms[0];
				
	EsconderElemento('Grabar');
	EsconderElemento('Salir');
	
	if (document.getElementById("spnMensaje")!= undefined)
	{
	    var spnMsUp = document.getElementById("spnMensaje");
	    spnMsUp.style.display = "inline";
	}
	return true;
}		

//Esconde un elemento
function EsconderElemento(elemento)
{
	if (document.getElementById(elemento) != undefined)
	{
		document.getElementById(elemento).style.visibility="hidden";
		document.getElementById(elemento).style.width=0;
	}
}
