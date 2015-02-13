/********************************************************************************************
** M�dulo: AJAX_Engine.js
** Descripci�n: Funciones espec�ficas para un motor b�sico de AJAX.
** Autor: Sergio J. Rodr�guez (srodriguez@siafsag.gob.gt) (/$�rm) (@sjrm).
** 
** Creaci�n:            $03:55 PM 2006-09-08$
** �ltima modificaci�n: $04:32 PM 2007-02-07$
********************************************************************************************/

// Definici�n de la estructura AJAX para el manejador.
// arrResponse: {manejador respuesta: string}, {estado: �xito | fallo}, {descripci�n: string}

// ���!!!URL para pasar a PRODUCCION - Verificar sicoindes/sicoin
//  "urlEndPoint" : "https://sicoin.minfin.gob.gt/sicoinweb/include/endPointAJAX##.aspx?msg=",

var AJAX = {
	"xmlHttp" : null,
	"urlEndPoint" : "http://localhost/sicoinweb/include/endPointAJAX##.aspx?msg=",
	"prfResponse" : "AJAX_ResponseHandler_",
	"arrResponse" : [ "AJAX_ResponseHandler_", false, "***" ],
	"Rsp_OK_COMPLETO"  : 1,
	"Rsp_OK_INCOMPLETO" : 2,
	"Rsp_ERROR" : 3,
	"Rsp_Sin_Error" : 0,
	"Rsp_Desplegar" : false
};

/////////////////////////////////////////////////////////////////////////////////////////////
// FUNCI�N: AJAX_GetXmlHttpObject(handler)
// DESCRIPCI�N: Obtiene el objeto XMLHTTP.  Verifica la versi�n o uso del mismo.
/////////////////////////////////////////////////////////////////////////////////////////////
function AJAX_GetXmlHttpObject(handler)
{ 
    var objXMLHttp = null;
    if (window.XMLHttpRequest) // Agente de usuario: Mozila/Linux
    {
        objXMLHttp = new XMLHttpRequest();
    }
    else if (window.ActiveXObject) // Agente de usuario: MS IE/Windows
    {
        objXMLHttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    return objXMLHttp;
}

/////////////////////////////////////////////////////////////////////////////////////////////
// FUNCI�N: AJAX_stateChanged().
// DESCRIPCI�N: Manejador del evento cuando cambia el estado de la conexi�n HTTP.
/////////////////////////////////////////////////////////////////////////////////////////////
function AJAX_stateChanged()
{
    
    if (AJAX.xmlHttp.readyState==4 || AJAX.xmlHttp.readyState=="complete")
    {
        AJAX.arrResponse[1] = true;
        AJAX.arrResponse[2] = AJAX.xmlHttp.responseText; // Respuesta recibida del servidor.
        
        if (AJAX.Rsp_Desplegar) window.alert(AJAX.arrResponse[2]); // Mostrar el texto recibido como respuesta.
        
        // Se invoca a la funci�n nombrada como el manejador de la respuesta: "AJAX.ResponseHandler".
        var objRespuesta = eval("(" + AJAX.arrResponse[2] + ");");
        
        
        if (AJAX.Rsp_Desplegar) window.alert(objRespuesta);
        try
        {
          st= objRespuesta._callback;
        }catch(e)
        {
		  st=""
        }
        if (AJAX.Rsp_Desplegar) window.alert(AJAX.arrResponse[0]);
        eval(AJAX.arrResponse[0] + "(objRespuesta);");
    }
    else
    {
        AJAX.arrResponse[1] = false;
        switch (AJAX.xmlHttp.readyState)
        {
            case 1: case 2: case 3: // wait...
            break;
            default:
                AJAX.arrResponse[2] = "AJAX: Ocurri� un problema.  [readyState = " + AJAX.xmlHttp.readyState + "]";
                window.alert(AJAX.arrResponse[2]);
            break;
        }
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////
// FUNCI�N: AJAX_GetResponse(AJAX.arrResponse).
// DESCRIPCI�N: Manejador del evento cuando se recibe una respuesta exitosa del servidor.
/////////////////////////////////////////////////////////////////////////////////////////////
// function { ... }

/////////////////////////////////////////////////////////////////////////////////////////////
// FUNCI�N: AJAX_SetConnection(strURL).
// DESCRIPCI�N: Establece la configuraci�n de conexi�n hacia el servidor.
// "strURL" >> Indica la direcci�n destino para la conexi�n al servidor.
/////////////////////////////////////////////////////////////////////////////////////////////
function AJAX_SetConnection(strURL)
{
    // Interacci�n AJAX.
    AJAX.xmlHttp = AJAX_GetXmlHttpObject()
    if (AJAX.xmlHttp == null)
    {
        window.alert("AJAX: El navegador no soporta peticiones HTTP.");
        return;
    } 
    
    // var strURL = "host.asp?x=" + x + "&y=" + y;

    AJAX.xmlHttp.onreadystatechange = AJAX_stateChanged;
    AJAX.xmlHttp.open("GET", strURL, true);
    AJAX.xmlHttp.send(null);
}

/////////////////////////////////////////////////////////////////////////////////////////////
// FUNCI�N: AJAX_InvokeEndPoint(intEndPoint, strMensaje, strParametros).
// DESCRIPCI�N: Establece la invocaci�n al punto de entrada AJAX, indicando el mensaje.
// "strEndPoint" >> Indica el punto de entrada (n�mero de biblioteca: "01", "02", "03"...).
// "strMensaje"  >> Indica el nombre del m�todo a invocar.
// "strParametros" >> Paso de par�metros al m�todo a invocar (formato QueryString: prm1=XX&prm2=YY&prm3=ZZ).
//
// OBSERVACI�N:
// El manejador AJAX de la respuesta recibida por el servidor, deber� declararse de acuerdo al siguiente prototipo:
// [AJAX.prfResponse] + [strMensaje] + '(objRespuesta)'.
// Ejemplo: strMensaje="obtenerNIT" => AJAX_ResponseHandler_obtenerNIT(objRespuesta);
/////////////////////////////////////////////////////////////////////////////////////////////
function AJAX_InvokeEndPoint(strEndPoint, strMensaje, strParametros)
{
        
		strParametros = "&" + strParametros;
		var url = AJAX.urlEndPoint.replace(/##/g, strEndPoint) + strMensaje + ((strParametros == "&") ? "" : strParametros);
		if (AJAX.Rsp_Desplegar) window.alert(url);
		AJAX.arrResponse[0] = AJAX.prfResponse + strMensaje; // indica el manejador de la respuesta.
		AJAX_SetConnection(url);
}

/*******************************************************************************************/