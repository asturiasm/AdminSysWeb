// Elaborado por Obed
// implementa listas de valores dependientes llenadas mediante Ajax
// JScript File
var debug_osLov= false; // variable para debugear toda la libreria
var debugCambioValores=false;


function GeneraLov(texto,pMetodo)
{

    if(debug_osLov) alert('en GeneraLov');
	AJAX.urlEndPoint = "../include/endPointAJAX01.aspx?msg=",
	AJAX.Rsp_Desplegar = debug_osLov;
	AJAX_InvokeEndPoint("01", pMetodo, texto );
	if(debug_osLov) alert('saliendo GeneraLov');
}
//manejador de respuesta para las listas de valores
function AJAX_ResponseHandler_osLov(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaLista(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para las listas de valores para TRL entre cuentas monetarias
//1) [cazurdia] - 16/07/09 - Created
function AJAX_ResponseHandler_osLovTRL(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLovTRL');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaLista(obj);
			LlenaListabancodestino(obj);
			var txtTemp = document.getElementById('DESTINO')
			var Lista = document.getElementById('COD_BANCO_DESTINO_L')
			if (txtTemp.value != "")
			{
			    for (i=0;i<Lista.options.length;i++)
		        {
			        if (Lista.options[i].value == txtTemp.value)
			        {
				        Lista.selectedIndex = i;
				        break;
			        }
		        }
			}		
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
	
}

//manejador de respuesta para las listas de valores del reporte
function AJAX_ResponseHandler_getLovReporte(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaLista(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para las listas de valores para el Acreedor e intermediaro de el prestamo
//Como se tienen dos hijas el segundo obj hijo se asume el nombre fijo
//Cesar Azurdia 22/01/2008
function AJAX_ResponseHandler_osAcreInt(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaLista(obj);
			LlenaListaAcreInt(obj);	
			var txtTemp = document.getElementById('ID_INTERMEDIARIO')
			var Lista = document.getElementById('ID_INTERMEDIARIO_L')
			if (txtTemp.value != "")
			{
			    for (i=0;i<Lista.options.length;i++)
		        {
			        if (Lista.options[i].value == txtTemp.value)
			        {
				        Lista.selectedIndex = i;
				        break;
			        }
		        }
			}		
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}




//manejador de respuesta para el disponible
function AJAX_ResponseHandler_osDisp(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osDisp');
    
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			
			cl=document.getElementById(obj._cnom+"_L");
		    objID=document.getElementById("ID_PRESUPUESTO_GASTO");
			t=vec[0];
			cl.value=obj._descripcion;
			cl.value=agregarComas(cl);
			objID.value=obj._id_presupuesto;
			CalculaMontoTransaccion();
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para el disponible
function AJAX_ResponseHandler_getIDEgresos(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_getIDEgresos');
    
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			
			//cl=document.getElementById(obj._cnom+"_L");
		    objID=document.getElementById("ID_EGRESOS");
			//t=vec[0];
			//cl.value=obj._descripcion;
			//cl.value=agregarComas(cl);
			objID.value=obj._ID_EGRESOS;	
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para el disponible
function AJAX_ResponseHandler_osRubro(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osDisp');
    
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			
			//cl=document.getElementById(obj._cnom+"_L");
		    objID=document.getElementById("ID_RUBRO_INGRESO");
			t=vec[0];
			//cl.value=obj._descripcion;
			//cl.value=agregarComas(cl);
			objID.value=obj._id_rubro;
			//CalculaMontoTransaccion();
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el saldo de la cuenta monetaria
function AJAX_ResponseHandler_osSaldoCta(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osSaldoCta');
    
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			
			cl=document.getElementById(obj._cnom);
			//t=vec[0];
			var Saldo =new Number(obj._descripcion);
			cl.value=Saldo.toFixed(2);
			//cl.value=agregarComas(cl);
			//CalculaMontoTransaccion();
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria
function AJAX_ResponseHandler_osAtr(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaListaAtr(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria
function AJAX_ResponseHandler_osAux1(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaListaAtr(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para las listas de valores del reporte
function AJAX_ResponseHandler_osMayor(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaLista(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria
function AJAX_ResponseHandler_osAux2(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaListaAtr(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria
function AJAX_ResponseHandler_osAux2Mod(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaListaAtr(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria
function AJAX_ResponseHandler_osAtrIn(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaListaAtr(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria
function AJAX_ResponseHandler_osMunicipios(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaLista(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria
function AJAX_ResponseHandler_osCiudades(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			//LlenaLista(obj);
			window.parent.frames('DetalleUbicacionGeografica').window.location ='../General/frmMantenimiento.aspx?ST=Y&ID=' + obj._descripcion;
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria en el reporte
function AJAX_ResponseHandler_osRpt(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaListaAtr(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria
function AJAX_ResponseHandler_osGetAuxiliares(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
    
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
		    
			LlenaListaAuxiliaresConta(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}

//manejador de respuesta para traer el atributo de la partida presupuestaria
function AJAX_ResponseHandler_osBaseCalculo(obj)
{
    if(debug_osLov) alert('en AJAX_ResponseHandler_osLov');
	switch (obj._codigo)
	{
		case AJAX.Rsp_OK_COMPLETO: // OK
			LlenaLista(obj);
		break;
		case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			textoNombre.value = '***';
			window.alert(obj._descripcion);
		break;
	}
}



//llena la lista de valores hija acreedor/intermediario
function LlenaListaAcreInt(obj)
{if(debug_osLov) alert('en Llena lista'+ 'ID_INTERMEDIARIO_L');
	eval('vec=obj.'+obj._cnom );
	cl=document.getElementById('ID_INTERMEDIARIO_L')
	cl.length=0; 
	st = new Option("Seleccione la opcion...","");
	cl.add(st);
	if (vec.length > 0)
	{				
	    for (i = 0; i <vec.length; i++) {
		    t=vec[i];
		    st = new Option(t.descripcion,t.llave);
		    cl.add(st); 
	    }
	    var n_cmp=obj._cnom.substr(0,obj._cnom.length-2)
	    cl=document.getElementById(n_cmp)
	    if (debug_osLov || debugCambioValores) alert('Llena lista ' + n_cmp + '-' + cl );
	    if (cl != null) 
	        if (cl.value!="")
	            if(eval("Lov"+n_cmp+"_L"))
	                 eval("Lov"+n_cmp+"_L._TextChanged(true)");
	//&NOM1=EJER_EJECUCION&VAL1='"+document.getElementById("EJERCICIO").value+"
	}
	else
	{alert('No se encontraron valores para la lista INTERMEDIARIO');
	txtTemp = document.getElementById('ID_INTERMEDIARIO');
	txtTemp.value = '';
	}
}


//llena la lista de valores hija
function LlenaListabancodestino(obj)
{if(debug_osLov) alert('en Llena lista'+ 'COD_BANCO_DESTINO_L');
	eval('vec=obj.'+obj._cnom );
	cl=document.getElementById('COD_BANCO_DESTINO_L')
	cl.length=0; 
	st = new Option("Seleccione la opcion...","");
	cl.add(st);				
	if (vec.length > 0)
	{
	    for (i = 0; i <vec.length; i++) {
	    	t=vec[i];
	    	st = new Option(t.descripcion,t.llave);
	    	cl.add(st); 
	    }
	    var n_cmp=obj._cnom.substr(0,obj._cnom.length-2)
	    cl=document.getElementById(n_cmp)
	    if (debug_osLov || debugCambioValores) alert('Llena lista ' + n_cmp + '-' + cl );
	    if (cl != null) 
	        if (cl.value!="")
	          if(eval("Lov"+n_cmp+"_L"))
    	        eval("Lov"+n_cmp+"_L._TextChanged(true)");
	    //&NOM1=EJER_EJECUCION&VAL1='"+document.getElementById("EJERCICIO").value+"
	}
	else
	{alert('No se encontraron valores para la lista bancos');}
}


//llena la lista de valores hija
function LlenaLista(obj)
{if(debug_osLov) alert('en Llena lista'+ obj._cnom);
	eval('vec=obj.'+obj._cnom );
	cl=document.getElementById(obj._cnom)
	cl.length=0; 
	st = new Option("Seleccione la opcion...","");
	cl.add(st);				
	if (vec.length > 0)
	{
	    for (i = 0; i <vec.length; i++) {
	    	t=vec[i];
	    	st = new Option(t.descripcion,t.llave);
	    	cl.add(st); 
	    }
	    var n_cmp=obj._cnom.substr(0,obj._cnom.length-2)
	    cl=document.getElementById(n_cmp)
	    if (debug_osLov || debugCambioValores) alert('Llena lista ' + n_cmp + '-' + cl );
	    if (cl != null) 
	        if (cl.value!="")
	          if(eval("Lov"+n_cmp+"_L"))
    	        eval("Lov"+n_cmp+"_L._TextChanged(true)");
	    //&NOM1=EJER_EJECUCION&VAL1='"+document.getElementById("EJERCICIO").value+"
	}
	else
	{alert('No se encontraron valores para la lista '+ obj._nomobj);}
}

function LlenaListaAuxiliaresConta(obj)
{if(debug_osLov) alert('en Llena lista'+ obj._cnom1);

//******** LLENANDO LA LISA DEL AUXILIAR1
    
	eval('vec=obj.'+obj._cnom1 );
	cl=document.getElementById(obj._cnom1)
	cl.length=0; 
	st = new Option("Seleccione la opcion...","");
	cl.add(st);				
	if (vec.length > 0)
	{
	    for (i = 0; i <vec.length; i++) {
	    	t=vec[i];
	    	st = new Option(t.descripcion,t.llave);
	    	cl.add(st); 
	    }
	    var n_cmp="AUXILIAR1"//obj._cnom1
	    cl=document.getElementById(n_cmp)
	    if (debug_osLov || debugCambioValores) alert('Llena lista ' + n_cmp + '-' + cl );
	    if (cl != null) 
	        if (cl.value!="")
	          if(eval("Lov"+n_cmp+"_L"))
    	        eval("Lov"+n_cmp+"_L._TextChanged(true)");
	    //&NOM1=EJER_EJECUCION&VAL1='"+document.getElementById("EJERCICIO").value+"
	}
	else
	{alert('No se encontraron valores para la lista '+ obj._nomobj);}
	
	//******** LLENANDO LA LISA DEL AUXILIAR2
	
	eval('vec=obj.'+obj._cnom2 );
	cl=document.getElementById(obj._cnom2)
	cl.length=0; 
	st = new Option("Seleccione la opcion...","");
	cl.add(st);				
	if (vec.length > 0)
	{
	    for (i = 0; i <vec.length; i++) {
	    	t=vec[i];
	    	st = new Option(t.descripcion,t.llave);
	    	cl.add(st); 
	    }
	    var n_cmp="AUXILIAR2"
	    cl=document.getElementById(n_cmp)
	    if (debug_osLov || debugCambioValores) alert('Llena lista ' + n_cmp + '-' + cl );
	    if (cl != null) 
	        if (cl.value!="")
	          if(eval("Lov"+n_cmp+"_L"))
    	        eval("Lov"+n_cmp+"_L._TextChanged(true)");
	    //&NOM1=EJER_EJECUCION&VAL1='"+document.getElementById("EJERCICIO").value+"
	}
	else
	{alert('No se encontraron valores para la lista para el auxiliar 2');}

    
	//******** LLENANDO LA LISA DEL AUXILIAR3
	
	eval('vec=obj.'+obj._cnom3 );
	cl=document.getElementById(obj._cnom3)
	cl.length=0; 
	st = new Option("Seleccione la opcion...","");
	cl.add(st);				
	if (vec.length > 0)
	{
	    for (i = 0; i <vec.length; i++) {
	    	t=vec[i];
	    	st = new Option(t.descripcion,t.llave);
	    	cl.add(st); 
	    }
	    var n_cmp="AUXILIAR3"
	    cl=document.getElementById(n_cmp)
	    if (debug_osLov || debugCambioValores) alert('Llena lista ' + n_cmp + '-' + cl );
	    if (cl != null) 
	        if (cl.value!="")
	          if(eval("Lov"+n_cmp+"_L"))
    	        eval("Lov"+n_cmp+"_L._TextChanged(true)");
	    //&NOM1=EJER_EJECUCION&VAL1='"+document.getElementById("EJERCICIO").value+"
	}
	else
	{alert('No se encontraron valores para la lista para el auxiliar 3');}

}



function LlenaListaAtr(obj)
{
    var arr;
if(debug_osLov) alert('en Llena lista'+ obj._cnom);    
	eval('vec=obj.'+obj._cnom );
	cl=document.getElementById(obj._cnom)
	cl.length=0; 
	st = new Option("Seleccione la opcion...","");
	cl.add(st);	
	if (vec.length > 0)	
	{
	    for (i = 0; i <vec.length; i++) {
		t=vec[i];
		st = new Option(t.descripcion,t.llave);
		cl.add(st); 
	    }
	    var n_cmp=obj._cnom.substr(0,obj._cnom.length-2)
	    cl=document.getElementById(n_cmp)
	    if (cl.value!="")
	     if(eval("Lov"+n_cmp+"_L"))
	     eval("Lov"+n_cmp+"_L._TextChanged(true)");

	    t=vec[0];	
	    arr=t.llave.split("|");
	    if (arr[2]=='N') //Se revisa si el atributo es requerido. Si no es requerido entonces se valida si es visible o no
	    {
            cl.value=arr[1];
        	objLista=document.getElementById(obj._cnom)
            objLista.selectedIndex=1;
            eval("Lov"+n_cmp+"_L._TextChanged(true)");
	    }
	    
	    //&NOM1=EJER_EJECUCION&VAL1='"+document.getElementById("EJERCICIO").value+"
	}
	else
	{
	    alert('No se encontraron valores para la lista del'+  obj._nomobj);
	    }	
 }

/*
  NOTA: LOS DDL DEBEN SER DEFINIDOS DEL NIVEL SUPERIOR AL INVERIOR O DEL MAS DEPENDIENTE AL DEPENDIENTE LOS QUE
        TIENEN ASTERISCO AL PRINCIPIO SON OBLIGATORIOS QUE TENGAN VALOR
    
  *pTitulo=      El Titulo del Drop Down List (DDL), parametro entre comillado ej: 'Nombre'
  *pNomLista=    El nombre del campo de tipo Drop Down List en la forma, parametro entrecomillado
                 Es IMPORTANTE que el nombre de este campo termine con _L
  *pNomTexto=    El nombre del campo de tipo textBox en la forma, parametro entre comillado,
                 Si no tienen un textBox utilice el mismo nombre del DDL
  pDefault=
  pPadre=       El objeto padre del presente DDL, por lo general se utiliza posteriormente
                La funcion SetPadre(objetoPadre)
  pHijo=        El objeto Hijo del presente DDL, este al igua que el anterior es un objeto previamente creado
  pPNombre=     El nombre del campo o parametro que se va a utilizar en el DDL dependiente para filtrar, campo entre
                comillado, ej: 'cod_banco', 'id_entidad' esto implica que el valor seleccionado en el DDL actual se va
                a asignar a un parametro llamado cod_banco que se utiliza en el SQL hijo para hacer el filtro
  ppos=         Indice o nivel hasta el cual se realizara la busqueda, limpieza o utilizacion de los DDL, este es
                un Numero sin entre comillado, 1, 2, 3, etc
  pIDLov=       Este es el nombre de la Lista de valores, el valor es el nombre del LOV en la Base de Datos, 
                Es un Valor entrecomillado
  pPars=        Parametros para el DDL hijo deben seguir la estructrura siguiente 'NOM1=[NombreParametro]&VAL1=[Valor]&'
                NOM1 y VAL1 son parte de la sintaxis, si no tiene parametros para el DDL hijo usar null, si se
                usa valor debe ir entrecomillado
  pParPadres=
  pMetodo=      este parametro se utiliza en el caso de querere ejecutar un metodo en especial el valor debe ir
                entrecomillado y el parametro definido en endpointAJAX01.aspx.vb ej 'osSaldoCta'
*/
function Lov(pTitulo,pNomLista,pNomTexto,pDefault,
			pPadre,pHijo,pPNombre,ppos,pIdLov,pPars,pParPadres,pMetodo, pBorrarTexto, pLlaveCompuesta)
{
	this.Titulo = pTitulo;
	this.NomLista = pNomLista;
	this.NomTexto = pNomTexto;
	this.Lista = document.getElementById(pNomLista);
	if (pNomTexto != null) this.Texto = document.getElementById(pNomTexto);
	
	this.sDefault = pDefault;
	this.Padre = pPadre;
	this.Hijo = pHijo;
	this.PNombre = pPNombre;
	this.pos = ppos;
	this.IdLov = pIdLov;
	this.Pars="";
	this.Modificacion=false;
	this.LlaveCompuesta=false;
	if (pLlaveCompuesta!=null) this.LlaveCompuesta=pLlaveCompuesta;
	if(pPars!=null) this.Pars=pPars;
    this.ParPadres=1000;
    if(pParPadres!=null)
    this.ParPadres=pParPadres ;
    this.BorrarTexto=true;
    if (pBorrarTexto!=null) this.pBorrarTexto=pBorrarTexto;
    
    this.Metodo='osLov';
    if (pMetodo!=null) this.Metodo=pMetodo
    	
	this.SetPadre = SetPadre;
	this.SetBorrarTexto=SetBorrarTexto;
	this.BuscaEnLista = BuscaEnLista;
	this.setModificacion=setModificacion;
	
	this.validarNo = validarNo;
	this.evalActiva = evalActiva;
	this.Activa	= Activa;
	this.DesActiva = DesActiva;
	this.Limpia = Limpia;
	this.Filtro	= Filtro;
	this._TextChanged = _TextChanged;
	this._SelectedIndexChanged = _SelectedIndexChanged;
	this._BuscaListaModificacion=_BuscaListaModificacion;
	this.Fill = Fill;
	this.cntPars = cntPars;
	this.Lista.onchange=function(){ eval("Lov"+this.id+"._SelectedIndexChanged(true)") };
	this.Texto.onchange=function(){ eval("Lov"+this.id+"_L._TextChanged(true)") };		
	//alert(this.Lista.onchange);
}

function setModificacion(pModificacion)
{
    this.Modificacion=pModificacion;
}

function SetBorrarTexto(pBorrarTexto)
{
	this.BorrarTexto = pBorrarTexto	
}

function SetPadre(pPadre)
{
	this.Padre = pPadre	
}
function BuscaEnLista(pAlert)
{
	var i
	var found =false;
	var arr, _item;
	if(this.Lista.options!=null)
	    {
	        for (i=0;i<this.Lista.options.length;i++)
	        {
	            if (this.LlaveCompuesta== true)
	            {
	                arr=this.Lista.options[i].value.split("|");
	                _item=arr[1];
	                
	            }
	            else
	            {
	                _item=this.Lista.options[i].value;
	            }  
		        if (_item == this.Texto.value)
		            {
			            this.Lista.selectedIndex = i;
			            found=true;
			            break;
		            }	            
	        }
	    }
	    else
	    {
	        found=true;
	    }
	if (!found)
	{
		if (pAlert)
			alert("No existe el valor en la lista de : "+this.Titulo);
		if (this.Texto.disabled==false)
		{
		    if(this.BorrarTexto) this.Texto.value="";
		    //this.Texto.focus();
		}
	}
	return found;
}
function validarNo(strNo,strCampo)
{
	return true; //temporal
}
function evalActiva()
{
    if(debug_osLov) alert('estado disabled : '+this.Texto.disabled);
    if (this.Texto.disabled==false)
	    this.Hijo.Activa();
	return true;
}
function Activa()
{
	//this.Lista.disabled = false
	//this.Texto.disabled = false				
}
function DesActiva()
{
	this.Lista.disabled = true
	this.Texto.disabled = true
}
function Limpia()
{
	if(this.BorrarTexto) this.Texto.value = this.sDefault
	this.Lista.selectedIndex=0;
	this.BuscaEnLista(false);
	if (this.Hijo!=null)
	{
		this.evalActiva();
		this.Hijo.Limpia();
	}
}
function Filtro(p,cntp)
{
    var arr;
    if(debug_osLov) alert('en Filtro...' + cntp);
    if (this.LlaveCompuesta)
    {
        arr=this.Lista.options[ this.Lista.selectedIndex ].value.split("|");
        st="NOM"+p+"="+this.PNombre+"&VAL"+p+"="+arr[0];
    }
    else
    {
	    st="NOM"+p+"="+this.PNombre+"&VAL"+p+"="+this.Texto.value;
	}
	if (this.Padre!=null && cntp<this.ParPadres)
		st=st+"&"+this.Padre.Filtro(p+1,cntp+1);
	return st;
}
function cntPars()
{
    if(debug_osLov) alert('en cntPars');
	var noelem=0;
    var t=this.Pars;
    if(debug_osLov) alert(t);
    if (t.length>0)
	{
		//alert(t);
		while (t.indexOf("&VAL")!=-1)
		{
			noelem+=1;
			t=t.substr(t.indexOf("&VAL")+4);
		}
	}
	return noelem;
}
function Fill(pPars,pLimpia)
{
    if(debug_osLov) alert('en Fill');
	st='CALLBACK=osLov&CNOM='+this.NomLista+'&IDLOV='+this.IdLov+'&USE_DICCIONARIO=FALSE'+'&TITULO='+this.Titulo;
	if (pPars.length>0)
	{
		t=pPars;
		noelem=0;		
		while (t.indexOf("&VAL")!=-1)
		{
			noelem+=1;
			t=t.substr(t.indexOf("&VAL")+4);
		}
		//alert('elementos : '+noelem );
		st=st+"&NUMELEMEN="+noelem+'&'+pPars;
	}
	
	GeneraLov(st,this.Metodo);
	if (pLimpia)
	    this.Limpia();
}

function LimpiaHijo(objLOV)
{
    if (debug_osLov || debugCambioValores) alert(objLOV.Lista);
    objLOV.Lista.length=0;
    objLOV.Texto.value="";
    if(objLOV.Hijo!=null)  LimpiaHijo(objLOV.Hijo);
}

function ModificaFalsoPadre(objLOV)
{
    objLOV.Modificacion=false;
    if(objLOV.Padre!=null)  ModificaFalsoPadre(objLOV.Padre);
}


function _TextChanged(pLimpia)
{
    if (debug_osLov || debugCambioValores) alert('_TextChanged: ' + this.Hijo);
    if(this.Modificacion==true)
    {
        if (this.Hijo!=null)
            {
                if(this.Hijo.Hijo==null)
                {
                    ModificaFalsoPadre(this);       
                }
            }
    }
    else
    {
        if (this.Hijo) LimpiaHijo(this.Hijo); // verificando que tenga hijos
    }
    
	if (this.validarNo(this.Texto.value, this.Titulo)){
		if (this.BuscaEnLista(true)){
			if (this.Hijo!=null){			    			    
				if (this.evalActiva()){			    
					this.Hijo.Fill(this.Pars+this.Filtro(eval(this.cntPars()+'+1'),0),pLimpia)
				}
			}
		}
	}
}
function _SelectedIndexChanged(pLimpia)
{
    var arr, _item;
    //alert('en el select');
    if(debug_osLov) alert('en _SelectedIndexChanged');
    if (debug_osLov || debugCambioValores) alert('_SelectedIndexChanged:' + this.Hijo);
    if (this.LlaveCompuesta==true)
    {//alert('en el select LL-C');
        arr=this.Lista.options[ this.Lista.selectedIndex ].value.split('|');
        this.Texto.value='';
        if (arr[1] != null) this.Texto.value=arr[1];
    }
    else
    {
	    this.Texto.value = this.Lista.options[ this.Lista.selectedIndex ].value;
	}
	if (this.Hijo!=null){			
		if (this.evalActiva())
			this.Hijo.Fill(this.Pars+this.Filtro(eval(this.cntPars()+'+1'),0),pLimpia);
		else
			this.Hijo.Limpia();
	}
	
	if (this.Hijo) LimpiaHijo(this.Hijo);
}

function _BuscaListaModificacion(pLimpia)
{
    var arr, _item;
    if(debug_osLov) alert('en _SelectedIndexChanged');
    if (this.LlaveCompuesta==true)
    {
        arr=this.Lista.options[ this.Lista.selectedIndex ].value.split('|');
        this.Texto.value=arr[1];
    }
    else
    {
	    this.Texto.value = this.Lista.options[ this.Lista.selectedIndex ].value;
	}
	if (this.Hijo!=null){			
		if (this.evalActiva())
			this.Hijo.Fill(this.Pars+this.Filtro(eval(this.cntPars()+'+1'),0),pLimpia);
		else
			this.Hijo.Limpia();
	}
}


function txt(pTitulo,pNomLista,pNomTexto,pMetodo,pPars)
//,pDefault,pPadre,pHijo,pPNombre,ppos,pIdLov,pPars,pParPadres,pMetodo, pBorrarTexto, pLlaveCompuesta)
{
    
	this.Titulo = pTitulo;
	this.NomLista = pNomLista;
	this.NomTexto = pNomTexto;
	this.Lista = document.getElementById(pNomLista);
	if (pNomTexto != null) this.Texto = document.getElementById(pNomTexto);
   
    this.Metodo=pMetodo;
    this.Pars=pPars;
  	
	this._TxtChanged = _TxtChanged;
	this.txtFill = txtFill;
	this.Texto.onchange=function(){eval( "txt"+this.id+"._TxtChanged()" ) };		
}

function _TxtChanged() 
{
     txtFill(this.Pars,false);
     //GeneraLov('PRUEBA',this.Metodo);
}

function txtFill(pPars,pLimpia)
{
    st='CALLBACK=darAux&CNOM='+this.NomLista+'&DESC='+this.NomTexto;
    alert(st);
	if (pPars.length>0)
	{
		t=pPars;
		noelem=0;
		//alert(t);
		while (t.indexOf("&VAL")!=-1)
		{
			noelem+=1;
			t=t.substr(t.indexOf("&VAL")+4);
		}
		//alert('elementos : '+noelem );
	    
		st=st+"&NUMELEMEN="+noelem+'&'+pPars;
	}
	alert(pPars);
	GeneraLov(st,this.Metodo);
//	if (pLimpia)
//	    this.Limpia();

}

   function AJAX_ResponseHandler_darAux(obj)
            {
                //if(debug_osLov) 
                alert('en AJAX_ResponseHandler_darAux');
	            switch (obj._codigo)
	            {
		            case AJAX.Rsp_OK_COMPLETO: // OK
			           txtDesc = document.getElementById('DESCRIPCION_AUX01')
			           txtDesc.value  = obj.NOMBRE_AUX;
                       //document.Form1.DESCRIPCION_AUX01.isable = true;
                       document.Form1.AUXILIAR_01.focus();
		            break;
		            case AJAX.Rsp_OK_INCOMPLETO: case AJAX.Rsp_ERROR: // Error.
			             window.alert(obj._descripcion);
			             document.Form1.DESCRIPCION_AUX01.value = '';
		            break;
	            }
            }
