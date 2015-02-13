/********************************************************************************************
** Módulo: AJAX_Engine.js
** Descripción: Funciones específicas para un motor básico de AJAX.
** Autor: Sergio J. Rodríguez (srodriguez@siafsag.gob.gt) (/$¡rm) (@sjrm).
** 
** Creación:            $03:55 PM 2006-09-08$
** Última modificación: $04:32 PM 2007-02-07$
********************************************************************************************/

// Definición de la estructura AJAX para el manejador.
// arrResponse: {manejador respuesta: string}, {estado: éxito | fallo}, {descripción: string}

// ¡¡¡!!!URL para pasar a PRODUCCION - Verificar sicoindes/sicoin
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
// FUNCIÓN: AJAX_GetXmlHttpObject(handler)
// DESCRIPCIÓN: Obtiene el objeto XMLHTTP.  Verifica la versión o uso del mismo.
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
// FUNCIÓN: AJAX_stateChanged().
// DESCRIPCIÓN: Manejador del evento cuando cambia el estado de la conexión HTTP.
/////////////////////////////////////////////////////////////////////////////////////////////
function AJAX_stateChanged()
{
    
    if (AJAX.xmlHttp.readyState==4 || AJAX.xmlHttp.readyState=="complete")
    {
        AJAX.arrResponse[1] = true;
        AJAX.arrResponse[2] = AJAX.xmlHttp.responseText; // Respuesta recibida del servidor.
        
        if (AJAX.Rsp_Desplegar) window.alert(AJAX.arrResponse[2]); // Mostrar el texto recibido como respuesta.
        
        // Se invoca a la función nombrada como el manejador de la respuesta: "AJAX.ResponseHandler".
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
                AJAX.arrResponse[2] = "AJAX: Ocurrió un problema.  [readyState = " + AJAX.xmlHttp.readyState + "]";
                window.alert(AJAX.arrResponse[2]);
            break;
        }
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////
// FUNCIÓN: AJAX_GetResponse(AJAX.arrResponse).
// DESCRIPCIÓN: Manejador del evento cuando se recibe una respuesta exitosa del servidor.
/////////////////////////////////////////////////////////////////////////////////////////////
// function { ... }

/////////////////////////////////////////////////////////////////////////////////////////////
// FUNCIÓN: AJAX_SetConnection(strURL).
// DESCRIPCIÓN: Establece la configuración de conexión hacia el servidor.
// "strURL" >> Indica la dirección destino para la conexión al servidor.
/////////////////////////////////////////////////////////////////////////////////////////////
function AJAX_SetConnection(strURL)
{
    // Interacción AJAX.
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
// FUNCIÓN: AJAX_InvokeEndPoint(intEndPoint, strMensaje, strParametros).
// DESCRIPCIÓN: Establece la invocación al punto de entrada AJAX, indicando el mensaje.
// "strEndPoint" >> Indica el punto de entrada (número de biblioteca: "01", "02", "03"...).
// "strMensaje"  >> Indica el nombre del método a invocar.
// "strParametros" >> Paso de parámetros al método a invocar (formato QueryString: prm1=XX&prm2=YY&prm3=ZZ).
//
// OBSERVACIÓN:
// El manejador AJAX de la respuesta recibida por el servidor, deberá declararse de acuerdo al siguiente prototipo:
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