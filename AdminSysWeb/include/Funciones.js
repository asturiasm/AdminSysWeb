
//Agrega la funcion trim como un metodo del objeto prototipo del constructor String
String.prototype.trim = function()
{				
	// Usa la expresion regular para reemplazar espacios por un String vacio
	return this.replace(/(^\s*)|(\s*$)/g, "");
}


//Busca un valor digitado en un TextBox (Texto) dentro de las opciones
//de un DropDownList (Lista) y coloca este elemento de la lista como seleccionado
function BuscarValorEnLista(Lista,Texto)
{
	var i
	var found =false;
	if (Texto.value != "" )
	{
		for (i=0;i<Lista.options.length;i++)
		{
			if (Lista.options[i].value == Texto.value)
			{
				Lista.selectedIndex = i;
				found=true;
				break;
			}
		}
		if (!found)
		{
			alert("No existe el valor");
			Texto.value="";
			Texto.focus();
		}
	}
}

//Coloca el value de un DropDownList (Lista) en un TextBox (texto)
function ColocarValorEnTexto(Lista,Texto)
{
	Texto.value = Lista.value;
}

/*
//valida un email
function emailvalidation(entered, alertbox)
{
// Explained at www.echoecho.com/jsforms.htm
	with (entered)
	{
		apos=value.indexOf("@"); 
		dotpos=value.lastIndexOf(".");
		lastpos=value.length-1;
		if (apos<1 || dotpos-apos<2 || lastpos-dotpos>3 || lastpos-dotpos<2) 
		{
			if (alertbox) {alert(alertbox);} 
			return false;
		}
		else {return true;}
	}
}

//validacion de un campo numerico en un rango determinado
function valuevalidation(entered, min, max, alertbox, datatype)
{
with (entered)
{
checkvalue=parseFloat(value);
if (datatype)
{smalldatatype=datatype.toLowerCase();
if (smalldatatype.charAt(0)=="i") {checkvalue=parseInt(value)};
}
if ((parseFloat(min)==min && checkvalue<min) || (parseFloat(max)==max && checkvalue>max) || value!=checkvalue)
{if (alertbox!="") {alert(alertbox);} return false;}
else {return true;}
}
}

//validacion de digitos en un numero
function digitvalidation(entered, min, max, alertbox, datatype)
{
with (entered)
{
checkvalue=parseFloat(value);
if (datatype)
{smalldatatype=datatype.toLowerCase();
if (smalldatatype.charAt(0)=="i") 
{checkvalue=parseInt(value); if (value.indexOf(".")!=-1) {checkvalue=checkvalue+1}};
}
if ((parseFloat(min)==min && value.length<min) || (parseFloat(max)==max && value.length>max) || value!=checkvalue)
{if (alertbox!="") {alert(alertbox);} return false;}
else {return true;}
}
} 


//validacion de campo vacio
function emptyvalidation(entered, alertbox)
{
with (entered)
{
if (value==null || value=="")
{if (alertbox!="") {alert(alertbox);} return false;}
else {return true;}
}
}
*/
/*Funcion para las paginas de Mantenimiento Multiple.
  Muestra una pagina determinada por el parametro uri
  en el frame denominado detalle*/
/*  
function CambioDetalle(uri)
{
	parent.detalle.location.href=uri;
}  

*/


// Verifica que el valor sea un tipo de dato string
function esString(oThis)
{		
	var vValue = parseInt(oThis.value);

	if ( isNaN(vValue) )
		return true;
	else
	{
		if ( vValue != oThis.value )
			return true;
		else
			return false;
	}
}


// Verifica que el valor sea un tipo de dato float
function esFloat(oThis)
{
	var vValue = parseFloat(oThis.value);

	if ( isNaN(vValue) )
		return false;
	else
	{
		if ( vValue == oThis.value )
		{
			var vAux = oThis.value.replace('.','-');

			if (vAux.search('-') == -1)
				return false;
			else
				return true;
		}
		else
			return false;
	}
}


// Verifica que el valor sea un tipo de dato int
function esInt(oThis)
{
	var vValue = parseInt(oThis.value);
				
	if ( isNaN(vValue) )
		return false;
	else
	{
		if ( vValue == oThis.value )
		{
			var vAux = oThis.value.replace('.','-');

			if (vAux.search('-') == -1)
				return true;
			else
				return false;
		}
		else
			return false;
	}
}


// Devuelve el valor del parametro monto sin las comas que utiliza como separadores
function MontoSinComas(oThis)
{
	var vAux = '';
	if (oThis.value != '')
	{
		for (i=0;i<oThis.value.length;i++)
		{
			if (oThis.value.substr(i,1) != ',')
			{
				vAux += oThis.value.charAt(i);
			}
		}
	}
	return vAux;
}


// Trunca los decimales.
function Truncar(oThis)
{
	var vAux = '';
	for( i = 0; i < oThis.value.length && oThis.value.charAt(i) != '.'; i++ )
	{
		vAux += oThis.value.charAt(i);
	}
	return vAux*1.0 
}


// Redondea el valor utilizando el metodo toFixed()
function redondearValor(oThis, nDec)
{
	var vValor = oThis.value;
	
	return parseFloat(vValor).toFixed(nDec);
}


// Redondea el valor utilizando los metodos Math.round y Math.pow
function redondearValor2(oThis, nDec)
{
	var vValor = oThis.value;
	
	return Math.round(parseFloat(vValor) * Math.pow(10,nDec)) / Math.pow(10,nDec);
}


// Inserta comas en una cadena numerica.  
// Funciona con enteros o numeros con 2 o menos decimales.
function agregarComas( oThis )
{
	var vValor = oThis.value;
	var objRegExp = new RegExp('(-?[0-9]+)([0-9]{3})');

	while(objRegExp.test(vValor)) {
		vValor = vValor.replace(objRegExp, '$1,$2');
	}
	return vValor;
}


// Remueve comas de un string.
function removerComas( oThis )
{
	var vValor = oThis.value;
	var objRegExp = /,/g;

	return vValor.replace(objRegExp,'');
}


// Verifica que el valor sea de tipo monetario
function esMonto(oThis)
{ 
	var vRegExp = new RegExp(/^-?(0|[1-9]\d{0,2}|[1-9]\d{0,2}(,?\d{3}){1,})(\.\d\d)?$/);

	return vRegExp.test(oThis.value);
}


// Verifica que la cadena solamente incluya letras mayusculas
function esLetrasMayusculas(oThis)
{			
	var vASCII;
	var vError = false;

	for (j=0; j<oThis.value.length; j++)	
	{					
		vASCII = oThis.value.charCodeAt(j);

		if ( !((vASCII >= 65) && (vASCII <= 90)) )
		{
			vError = true;
			break;
		}
	}

	if ( vError )
		return false;
	else
		return true;
}


// Convierte la cadena de entrada a mayusculas
function aLetrasMayusculas(oThis)
{
	oThis.value  = oThis.value.toUpperCase();
}


//Funcion para validar un nit dado. Si el nit es correcto retorna un string vacio, en
//caso contrario retorna el mensaje de error
function ValidaNit(nit)
{
	var largo;
	var indice;
	var digito;
	var digitov;
	var suma;
	var diferencia;
	var valor1;
	var valor2;

	//se verifica que el nit no traiga guion
	if (nit.search('-')!= -1)
		return 'El nit no debe incluir gui&oacute;n.';
	
	//se separa el nit y el digito verificador
	digitov=nit.substr(nit.length-1,1);
	nit =nit.substr(0,nit.length-1);
	largo=nit.length;
	indice=largo;
	suma=0;
	
	//se verifica que el nit sea numerico
	var tmp=parseInt(nit);
	if (isNaN(tmp))
		return 'El nit debe ser num&eacute;rico';
	else
	{	if(tmp.toString().length != largo)
			return 'El nit debe ser numérico';
	}
	
	//se verifica que el verificador sea numerico o 'K'
	if (isNaN(parseInt(digitov)))
	{	digitov = digitov.toUpperCase();
		if (digitov!='K')
			return 'Nit inv&aacute;lido';
	}
				
	while (indice<=largo && indice>=1)
	{
		valor1=largo-indice+2;
		valor2=parseInt(nit.substr(indice-1,1));
		suma=suma+valor2*valor1;
		indice=indice-1;
	}
	residuo=suma % 11;
	diferencia=11-residuo;
	if (diferencia==10 )
		digito='K';
	else
	{
		if (diferencia==11)
			digito='0';
		else
			digito=diferencia.toString();
	}
	if (digito==digitov)
		return '';
	else 
		return 'Nit inv&aacute;lido';
	
}			


/*
Funcion para validacion de fechas. Recibe un input como parametro y valida
la fecha contenida en el. Si no es válida muestra un mensaje de error y retorna el 
foco al campo en cuestion
*/
function checkDate(dateField)
{
	var strDate = dateField.value;
	if(strDate.length>0)
	{
		//var dateregex=/^[ ]*[0]?(\d{1,2})\/(\d{1,2})\/(\d{4,})[ ]*$/;
		var dateregex=/^[ ]*[0]?(\d{2})\/(\d{2})\/(\d{4,})[ ]*$/;
		var match=strDate.match(dateregex);
		if (match)
		{
			var tmpdate=new Date(match[3],parseInt(match[2],10)-1,match[1]);
			if (tmpdate.getDate()==parseInt(match[1],10) && tmpdate.getFullYear()==parseInt(match[3],10) && (tmpdate.getMonth()+1)==parseInt(match[2],10))
				return true; 
		}
	}
	alert('Fecha invalida');
	dateField.focus();
	return false;

}		


// Funcion que valida el NOG (sin guiones y el digito verificador)
function ValidarNOG(strNOG) {
	var largo;
    var indice;
    var digito;
    var digitov;
    var suma;
    var diferencia;
    var valor1;
    var valor2;
 
    // se separa el nog y el digito verificador
    digitov = strNOG.substr(strNOG.length-1,1);
    strNOG = strNOG.substr(0,strNOG.length-1);
    largo = strNOG.length;
    indice = largo;
    suma = 0;
 
    // se verifica que el nog sea numerico
    var tmp = parseInt(strNOG+digitov);
    if (isNaN(tmp))
		return ('El formato del NOG debe ser numerico'); // -2;
 
    while (indice<=largo && indice>=1) {
		valor1=largo-indice+2;
        valor2=parseInt(strNOG.substr(indice-1,1));
        suma=suma+valor2*valor1;
        indice=indice-1;
    }
 
    residuo = suma % 11;
    diferencia=11-residuo;
	if (diferencia==11)
		digito='0';
    else
        digito=diferencia.toString();
 
    if (digito==digitov)
		return ('OK'); // 0; 
    else
		return ('El NOG no es valido (digito verificador incorrecto)'); // -3;
} 
//  fin de la funcion ValidarNOG

function CargarCalendario(campo)
{
	w=window.open("../include/calendario.aspx?CAMPO=" + campo.id,"LOV","width=244,height=210,'toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1");
	
}

function InicializarCargandoAsincrono() {
    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);
}

function beginRequest(sender, args) {       
    
    //Recuperamos el identificador del updatePanel que ha lanzado la petición asincrona
    var id = null;
    if (sender._postBackSettings.panelID == null)
        id = sender._postBackSettings.panelsToUpdate[0].split('|')[0];
    else
        id = sender._postBackSettings.panelID.split('|')[0];

    while ( id.indexOf('$') != -1)
        id = id.replace('$', '_');    
    if (!sender.get_isInAsyncPostBack()){  
       
        if ( $("#"+id).length & $("#progress").length ){        
          $("#"+id).fadeTo("slow", 0.7);          
          //Calculamos la posición para centrar el progress
          var x = $("#"+id).position().left + ($("#"+id).children(0).width()
            / 2)  - ($("#progress").children(0).width()  / 2);
          var y = $("#"+id).position().top +( $("#"+id).children(0).height() 
            / 2) - ($("#progress").children(0).height() / 2);        
    
          Sys.UI.DomElement.setLocation($("#progress")[0], Math.round(x), Math.round(y));    
          //Mostramos el progress
          $("#progress").show("slow");   
        }         
        //DesHabilita los botones
        //Prueba
        //$('input[type=submit]').attr('disabled', true);
    }     
}

function endRequest(sender, args) {
    if (!sender.get_isInAsyncPostBack()) {
        var id = null;
        if (sender._postBackSettings.panelID == null)
            id = sender._postBackSettings.panelsToUpdate[0].split('|')[0];
        else
            id = sender._postBackSettings.panelID.split('|')[0];
            
        while ( id.indexOf('$') != -1)
            id = id.replace('$', '_');
        
        if (!sender.get_isInAsyncPostBack()){              
            $("#"+id).fadeTo("fast",100);
            $("#progress").hide("fast");
        }
    //$('input[type=submit]').attr('disabled', false);
    }
}