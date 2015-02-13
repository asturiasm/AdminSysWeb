var global2_version = '2.0';

function Salir(){
    if (iframe==true)
        parent.location.href = '../login/frmlogout.aspx';
    else
        location.href = '../login/frmlogout.aspx';
}
//CLICK DERECHO, COPIADO DE POR AHI
function MTMcatchRight(thisEvent) {
  /*  try{
        if(thisEvent) {
            if (thisEvent.which == 3 || thisEvent.which == 2) {
              alert("Ping!");
              return false;
            }
          } else if(event && (event.button == 2 || event.button == 3)) {
            alert("Ping!");
            return false;
          }
      return true;  
    }catch(ex){
        throw ex;
    }*/
}
SiafContextMenu.prototype.div = null;
SiafContextMenu.prototype.x = null;
SiafContextMenu.prototype.y = null;

function SiafContextMenu(me){
    me = this;
    
    this.config = function(){
        var inputs = getBody().getElementsByTagName('INPUT');
        var i=0;
        me.div = createDiv();
		me.div.className = 'ContextMenu';
		getBody().appendChild(me.div);
		
        for (i=0;i<inputs.length;i++){
            if (inputs[i].type.toUpperCase()== 'IMAGE' || inputs[i].type.toUpperCase()== 'BUTTON'){
                var item = new SiafContextMenuItem(inputs[i]);
                item.config(me);
                me.div.appendChild(item.div);
            }
        }
        inputs = getBody().getElementsByTagName('TBNS:ToolbarButton');
        logMessage('inputs size = '+inputs.length);
        
        for (i=0;i<inputs.length;i++){
        
             var item = new SiafContextMenuItem(inputs[i]);
             logMessage('inputs size = '+inputs[i].src);
             item.config(me);
             me.div.appendChild(item.div);
        }
        var item = new SiafContextMenuItem(createButton('Cerrar'));
        item.config(me);
        me.div.appendChild(item.div);
        me.div.style.border = '1px solid blue'
        
    };    
    this.show = function(){
        me.div.style.display = 'block';
        me.div.style.left = me.x+'px';
        me.div.style.top = me.y+'px';
    };
     this.hide = function(){
        me.div.style.display = 'none';
    };
    this.preview = function(x,y){
        me.x = x;
        me.y = y;
        me.show();
        if (me.timer != null){
            clearTimeout(me.timer);
        }
        me.timer = setTimeout(me.hide,1000);
    };
    this.esconder = function(){
        if (me.timer != null){
            clearTimeout(me.timer);
        }
        me.timer = setTimeout(me.hide,500);
    };  
    this.mantener = function(){
        if (me.timer != null){
            clearTimeout(me.timer);
        }
    };    
}
SiafContextMenuItem.prototype.div = null;
SiafContextMenuItem.prototype.input = null;
SiafContextMenuItem.prototype.contextMenu = null;

function SiafContextMenuItem(input,me){
    me = this;
    me.input = input;
    
    this.config = function(contextMenu){
      /*  if (me.input != null){
            me.div = createDiv();
            me.contextMenu = contextMenu;
            
            me.div.appendChild(createLabel(SiafUtil.nvl('*','*'+me.input.title,'*'+me.input.value,'*'+me.input.alt)));
            
            addEvent(me.div,'onmouseover',me.mouseOver);
            addEvent(me.div,'onmouseout',me.mouseOut);
            addEvent(me.div,'onclick',me.click);
        }*/
        
    };
    this.mouseOver = function(){
        me.div.className = 'ContextMenuItemSelected';
        me.contextMenu.mantener();  
    };
    this.mouseOut = function(){
        me.div.className = '';
        me.contextMenu.esconder();
    };
    this.click = function(evnt){
        
    };
    
    this.show = function(){
    
    };
    this.select = function(){
    };    
}
var siafContextMenu = new SiafContextMenu();

function showContextControl(evt){
    var result = getMouseClickPosition(evt);
    siafContextMenu.preview(result.x,result.y);
    return false;
}

function enableContextControl(id){
    siafContextMenu.config();
    findElement(id).oncontextmenu = showContextControl;
}

function initializeMouseControl() {
  

  if(document.layers) {
//    window.captureEvents(Event.MOUSEDOWN);
  }else{
  //  document.onmousedown = MTMcatchRight;
  }
  //window.onmousedown = MTMcatchRight;
  
  
}

// JScript File
// JScript File
var iframe = true;
var siafAttributes = new Array();

function setIframe(value){
    iframe = value;
}
function changeDocType(){
    
    try{
        /*
        <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
        "http://www.w3.org/TR/html4/loose.dtd">
        */
        info('vamos con el doctype!'+document.body.parentNode.parentNode.firstChild.nodeValue);
        document.body.parentNode.parentNode.firstChild.nodeValue = "DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\""; 
        
        /*var newDoctype = document.implementation.createDocumentType('html','-//W3C//DTD HTML 4.01 Transitional//EN','http://www.w3.org/TR/html4/loose.dtd');
        
        if (document.doctype) {
            document.doctype.parentNode.replaceChild(newDoctype, document.doctype);
        }*/
        
    }catch(ex){
        throw ex;
    }
}
var initListeners = new Array();

function addInitListener(callback){
    initListeners.push(callback);
}
/*evento que es llamado al cargarse la página*/
function initPage(){
    try{
         /*startPage es un metodo que puede definirse en la pagina, y en este momento va ser llamado*/
        if(startPage != null)
            startPage();
    }catch(ex){
        //throw ex;
    }
    var i=0;
    
    for (i=0;i<initListeners.length;i++){
        initListeners[i]();/*call to init listeners*/
    }
    
    try{
        //DoClock();
        /*al cargar muestra popup a partir los campos*/
        
        mostrarPopup();
    }catch(ex){
        throw ex;
    }
}

var CONSTANTES = new Object();

CONSTANTES.LBL_MENSAJE_ESPERA = 'LBL_MENSAJE_ESPERA'
CONSTANTES.INPUT_MENSAJE_ESPERA = 'INPUT_MENSAJE_ESPERA'
CONSTANTES.MODAL_INPUT_MENSAJE = 'MODAL_INPUT_MENSAJE'
CONSTANTES.INPUT_MODAL_TIPO = 'INPUT_MODAL_TIPO'
CONSTANTES.INPUT_MODAL_NIVEL = 'INPUT_MODAL_NIVEL'
CONSTANTES.INPUT_MODAL_CONFIRMAR = 'INPUT_MODAL_CONFIRMAR'
CONSTANTES.INPUT_MODAL_CONFIRMACION_ID = 'INPUT_MODAL_CONFIRMACION_ID'
CONSTANTES.BUTTON_MODAL_CONFIRMAR = 'BUTTON_MODAL_CONFIRMAR'
CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES = 'MODAL_INPUT_MENSAJE_DETALLES'
CONSTANTES.MODAL_LABEL_MENSAJE = 'MODAL_LABEL_MENSAJE'
CONSTANTES.MODAL_ERROR_DIV = 'MODAL_ERROR_DIV'

CONSTANTES.div_ajax_waiting = 'div_ajax_waiting'
CONSTANTES.div_ajax_tapa1 = 'div_ajax_tapa1'
CONSTANTES.div_ajax_tapa2 = 'div_ajax_tapa2'
CONSTANTES.nmf_ajax_my_timer = 'nmf_ajax_my_timer'
CONSTANTES.modal_progress_bar = 'modal_progress_bar'
CONSTANTES.modal_message_id = 'modal_message_id'
CONSTANTES.modal_buttonera_id = 'modal_message_id'
CONSTANTES.METODO = 'METODO'
CONSTANTES.CLASE = 'CLASE'
CONSTANTES.DESCRIPCION = 'DESCRIPCION'
CONSTANTES.modal_detalles_id = 'modal_detalles_id'
CONSTANTES.salir = 'salir'

CONSTANTES.MENSAJES = new Object();
CONSTANTES.MENSAJES.ACEPTAR = 'Aceptar'
CONSTANTES.MENSAJES.CANCELAR = 'Cancelar'
CONSTANTES.MENSAJES.DETALLES = 'Detalles'
CONSTANTES.MENSAJES.CERRAR = 'Cerrar'
CONSTANTES.MENSAJES.CONFIRMAR = 'Confirmar'
CONSTANTES.MENSAJES.VOLVER = 'Regresar'
CONSTANTES.MENSAJES.BUSCAR = 'Buscar'
CONSTANTES.MENSAJES.FULL_SCREEN = 'Pantalla Completa';
CONSTANTES.MENSAJES.NO_FULL_SCREEN = 'Ver Menu';

CONSTANTES.ZERO = 0;

CONSTANTES.WINDOW_SHOW_HEADER = 1;
CONSTANTES.WINDOW_SHOW_BODY = 2;
CONSTANTES.WINDOW_SHOW_FOOTER = 4;


CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR = 1;
CONSTANTES.INPUT_MODAL_BOTON_CANCELAR = 2;
CONSTANTES.INPUT_MODAL_BOTON_CONFIRMAR = 4;
CONSTANTES.INPUT_MODAL_BOTON_PROGRESS_BAR = 8;
CONSTANTES.INPUT_MODAL_BOTON_CERRAR = 16;
CONSTANTES.INPUT_MODAL_BOTON_VOLVER = 32;
CONSTANTES.INPUT_MODAL_BOTON_DETALLES_ERROR = 64;
CONSTANTES.INPUT_MODAL_BOTON_CUSTOM_MSG = 128;
CONSTANTES.ALL_BITS = 1023;

COLORS = new Object();
COLORS.WHITE = 'white';

CONSTANTES.INPUT_MODAL_NIVEL_INFO = "INPUT_MODAL_NIVEL.INFO";
CONSTANTES.INPUT_MODAL_NIVEL_WARNING = "INPUT_MODAL_NIVEL.WARNING";
CONSTANTES.INPUT_MODAL_NIVEL_ERROR = "INPUT_MODAL_NIVEL.ERROR";

CONSTANTES.STYLES = new Object();
CONSTANTES.STYLES.MODAL_TAPA1 = 'modal_tapa_1'
CONSTANTES.STYLES.MODAL_TAPA2 = 'modal_tapa_2'
CONSTANTES.STYLES.COLOR_PAR = 'white'
CONSTANTES.STYLES.COLOR_IMPAR = 'rgb(230,230,255)'

var WINDOW_TIPO = new Object();
WINDOW_TIPO.MENSAJES = 1;
WINDOW_TIPO.VACIO = 2;


var modalTapa1 = null;
var modalTapa2 = null;


function getMouseClickPosition(evt){
    var object = new Object();
    if (window.ActiveXObject){ //ie
	    //element.attachEvent(eventName,handler);
	    object.x = window.event.clientX;
	    object.y = window.event.clientY;
    }else{
	    object.x = evt.pageX;
	    object.y = evt.pageY;
    }
    return object;
}
/*
Si el input Hidden del campo con ID 'NMF_INPUT_MENSAJE_ESPERA' tiene valor se muestra el mensaje,
Si Hay 
*/
 //registrar evento a elemento
function addEvent(element,eventName,handler,param,mousePointer){
	try{
	    if (window.ActiveXObject){ //ie
		    element.attachEvent(eventName,handler);
	    }
	    else{
		    try{
			    var name = eventName.substring(2,eventName.length);
			    element.addEventListener(name,handler,false)
		    }catch(ex){
                throw ex;
		    }
	    }
	    if (eventName == 'onclick' || eventName == 'ondblclick'  || mousePointer==true){
		    addEvent(element,'onmouseover', function(){document.body.style.cursor='pointer';});
		    addEvent(element,'onmouseout', function(){document.body.style.cursor='default';});
	    }
	}catch(ex){
	    throw ex;
	}
	
}
  //crea un elemento link
 function createLink(text){
	var label = document.createElement('a');
	label.href = '#';
	label.innerHTML = text;
	return label;
}
//crea un texto dentro de span
function createText(text){
	var span = document.createElement('<span>');
	span.innerHTML = text;
	return span;
}
//crea un elemento label
function createLabel(text){
	var label = document.createElement('label');
	label.innerHTML = text;
	return label;
}
function createParagraph(text){
	var label = document.createElement('p');
	label.innerHTML = text;
	return label;
}

//nuevo modal



SiafConfirmacion.prototype.button = null;
SiafConfirmacion.prototype.titulo = null;
SiafConfirmacion.prototype.observacion = null;
SiafConfirmacion.prototype.callback = null;
SiafConfirmacion.prototype.confirm = null;
SiafConfirmacion.prototype.image = null;

function SiafConfirmacion(me){
    me = this;
    me.image = false;
    me.submit = false;
    
    this.select = function(){
        var params = new Object();
        params.confirmacionListener = me.confirm;
        params.value = me.titulo;
		mostrarGenericPopup(me.titulo,me.titulo,me.observacion,me.observacion,CONSTANTES.INPUT_MODAL_BOTON_CANCELAR|CONSTANTES.INPUT_MODAL_BOTON_CONFIRMAR ,CONSTANTES.INPUT_MODAL_NIVEL_INFO,params)
        return false;
    };
    this.config = function(button,titulo,observacion){
        logMessage('configurar confirmacion '   );
        me.callback = button.onclick;
        me.button = button;
        button.onclick = me.select;
        me.titulo = titulo;
        me.observacion = observacion;
        //addEvent(button,'onclick',me.select);
        logMessage('onclick old =' + me.callback );
    };
    this.cancel = function(){
        
    };
    this.confirm = function(){
        try{
            me.button.onclick = me.callback;    
            me.button.click();
            setTimeout(me.clear,500);
        }catch(ex){
            throw ex;
        }
    };
    this.clear = function(){
        try{
            me.button.onclick = me.select;
        }catch(ex){
            throw ex;
        }
    };
}
/*function para registrar confirmacino a un boton*/
function registrarConfirmacion(id,pTitulo,observacion){
    logMessage(iframe+'registrar confirmacion para '+ id + ' & ' + pTitulo+ ' &'+ observacion );
    var confirmacion = new SiafConfirmacion();
    confirmacion.config(findElement(id),pTitulo,observacion);
}
function registrarSalir(id){
        
}
/** @deprecated */
function confirmarPopup(mensaje,descripcion,btn){
	try{
		var confirmar = findElement(CONSTANTES.INPUT_MODAL_CONFIRMAR);
 		if (confirmar.value == 'true'){
		    /*confirmar.value = 'false';
		    btn.onclick = btn.onclickOld;
		    if (btn.onclick != null)
		        btn.click();
		    btn.onclick = null;*/
		    /*var btnClone = createButton('clon');
		    addEvent(btnClone,'onclick',btn.onclickOld);
		    getBody().appendChild(btnClone);
		    return btnClone.click();*/
		    return true;
		}
		else{
			document.getElementById(CONSTANTES.MODAL_INPUT_MENSAJE).value = mensaje;
			document.getElementById(CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES).value = descripcion;
			document.getElementById(CONSTANTES.INPUT_MODAL_TIPO).value = CONSTANTES.INPUT_MODAL_BOTON_CONFIRMAR|CONSTANTES.INPUT_MODAL_BOTON_CANCELAR;
			document.getElementById(CONSTANTES.INPUT_MODAL_NIVEL).value = CONSTANTES.INPUT_MODAL_NIVEL_WARNING;

			var params = new Object();
			params.confirmar = btn;
			
			mostrarPopup(params);
		}
	    return false;
	}catch(ex){
		throw ex;
	}
}
var alertLoop = 0;
/*SOBREESCRIBE EL ALERT DEL BROWSER*/
alertOld = alert
function alert(msg,listener){
	try{
	    alertLoop++;
	    if (alertLoop > 100){
	        alertOld('posible loop infinito en el alert');
	    }else{
	        mostrarWindowPopup('* Alert',msg,'','',CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR,CONSTANTES.INPUT_MODAL_NIVEL_WARNING,null,listener);
	    }
		alertLoop--;
	}catch(ex){
        throw ex;
	}
}
function alertObject(root,listener){
	try{
	
	    alertLoop++;
	    var params = new Object();
	    params.root = root;
	    //params.width = '70%';
	    //params.height = '85%';
	    
	    if (listener.closeListener != null)
	        params.closeListener = listener.closeListener
	        
		mostrarWindowPopup('* Alert','','','',CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR,CONSTANTES.INPUT_MODAL_NIVEL_WARNING,params,listener,params);
	}catch(ex){
        throw ex;
	}
}
function info(msg){
	try{
	    alertLoop++;
		mostrarWindowPopup('Info',msg,'','',CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR,CONSTANTES.INPUT_MODAL_NIVEL_INFO);
	}catch(ex){
        throw ex;
	}
}
if (iframe == true){
    alert = window.parent.alert;
    alertObject = window.parent.alertObject;
    info = window.parent.info;
    
    if (alert == null){
        alert = window.parent.parent.alert;
        alertObject = window.parent.parent.alertObject;
        info = window.parent.parent.info;
    }
}
/*funcion para abril un iframe dentro de un div*/
function openIframe(url,modal){
    var siw = new SiafIframeWindow();
    siw.show(url,modal);
}
function cerrarIframe(pId,message){
    try{
        var iframeManager =  siafAttributes['iframe_'+pId];
        iframeManager.hide();
        
    }catch(ex){
        throw ex;
    }
    info(message);
    
}
SiafIframeWindow.prototype.iframe = null;
SiafIframeWindow.prototype.iframeWindow = null;



function SiafIframeWindow(me){
    me = this;
    
    this.show = function(url,modal){
        
        var time = new Date();
        siafAttributes['iframe_'+time.valueOf()]=me;
        
        me.url = url+'&CLIENT_ID='+time.valueOf();
        
        var params = new Object();
        params.title = me.url;
        params.width = '60%';
        params.height = '80%';
        params.closeIconEnabled = true;
        
        me.iframeWindow = createWindow(null,modal,CONSTANTES.WINDOW_SHOW_HEADER|CONSTANTES.WINDOW_SHOW_BODY|CONSTANTES.WINDOW_SHOW_FOOTER,params);
        me.iframe = createIframe();
        
        me.iframe.siafManager = me;
        me.iframe.frameborder='no';
        me.iframe.scrolling='yes';
        me.iframe.test='';
        
        me.iframeWindow.body.div.appendChild(me.iframe);
        me.iframeWindow.body.div.appendChild(createHR('HrFin'));
        me.iframeWindow.body.div.className = 'ModalInfoIframe'
        
        me.iframe.src = me.url;
        
        me.iframeWindow.centrar();
        
        
        var h = getHeight(me.iframeWindow.body.div)-30;
        var w = getWidth(me.iframeWindow.body.div);
        
        me.iframe.style.width = w+'px';
        me.iframe.style.height = h+'px';
        
		me.iframeWindow.setCloseListener(me.hide);
		
		setTimeout(this.reload,1000);
		
    };
    this.reload = function(){
        /*alert(me.iframe.width);*/
        /* me.iframe.location.href = me.url;*/
        //me.iframe.reload();
    };
    this.hide = function(){
        me.iframeWindow.hide();
    };
}
SiafProgressBar.prototype.timeout = null;    
SiafProgressBar.prototype.ctx = null;    

function SiafProgressBar(me){
    me = this;
    
    this.show = function(dialog){
        setTimeout(me.verify,500);
        me.dialog = dialog;
            
        me.ctx = findElement('myIframe').document;
        if (findElement('myIframe').contentWindow != null)
            me.ctx = findElement('myIframe').contentWindow;
    };
    this.hide = function(){
    
    };
    this.verify = function(){
        /*controlar si el hijo tiene que mostrar progressBar*/
        try{
            
            var value = me.ctx.mostrarProgressBar();
            
            if (value==false){
                me.dialog.hide();
                me.dialog = null;
                return false;
            }
        }catch(ex){
            throw(ex);
        }
        setTimeout(me.verify,500);        
        
        
    };
}
var siafProgressBar = new SiafProgressBar();
if (iframe == true)
    siafProgressBar = window.parent.siafProgressBar; 
    
    
SiafBrowserManager.prototype.links = null;
SiafBrowserManager.prototype.cursor = null;
SiafBrowserManager.prototype.loop = null;

function SalirAPrincipal(){
    parent.location.href = '../general/main.aspx';
}
function SiafBrowserManager(me){
    me = this;
    this.init = function(){
        me.links = new Array();
        me.cursor = 0;
        me.appendLink(SalirAPrincipal);
        me.loop = 0;
    }
    this.appendLink= function(punteroSalir){
        try{
            me.links[me.cursor] = punteroSalir;
            me.cursor++;
            logMessage('Se Agrego!' + punteroSalir + ' cursor =' + me.cursor);    
        }catch(ex){
        
        }
        
    }
    
    this.salir = function(){
        try{
            if (me.cursor > 0){
                me.cursor--;
                me.links[me.cursor]();
            }
        }catch(ex){
            /*salir si hay error*/
            if (me.loop < 10){
                me.loop++;
                me.reload();
                me.salir();
            }
        }
    }
    /*cera los valores de history del volver*/
    this.reload = function(){
        cursor = 1;
    }
    /*abre un url en el iframe principal*/
    this.open = function(url){
        me.reload();
        window.frames['myIframe'].location.href = url;
        findElement('Last_url').value = url;
    }
}
var browserManager = new SiafBrowserManager();
/*definir logger*/
if (iframe == true){
    browserManager = window.parent.browserManager;
    if (browserManager == null)
        browserManager = window.parent.parent.browserManager;
    
}else{
   
}
/*para que se apriete el boton con id salir del component*/
function hacerClickEnSalir(){
    try{
        findElement(CONSTANTES.salir).click();
    }catch(ex){
        throw ex;
    }
}
/*agrega el salir al link del Volver*/
function configurarSalirEnVolver(param){
    if (iframe == true){
        if (findElement(CONSTANTES.salir)!=null){
            if (parent.browserManager != null)
                parent.browserManager.appendLink(hacerClickEnSalir);
            else if (parent.parent.browserManager != null)
                parent.parent.browserManager.appendLink(hacerClickEnSalir);
        }else{
            logMessage('LA PAGINA NO TIENE UN BOTON CON ID salir');
        }
    }
        
}
function addSalirEnVolver(){
    try{
        logMessage('Add Salir En Volver');
        addInitListener(configurarSalirEnVolver);
    }catch(ex){
        throw ex;
    }
    
}
/*componente para usar logger en el cliente*/    
function Logger(me){

    me = this;
    this.table = createTable('SiafLogger');
    
    this.show = function(){
        
        if (me.window == null){
            me.window = createModalWindow();
            
            var div_buttons = me.window.footer.data;
		    
		    me.window.body.div.appendChild(me.table);

		    var div_buttons = me.window.footer.data;
		    var aceptar = createButton(CONSTANTES.MENSAJES.ACEPTAR);
		    var limpiar = createButton('Limpiar');
		    
		    div_buttons.appendChild(aceptar);
		    div_buttons.appendChild(limpiar);
		    
		    addEvent(aceptar,'onclick',me.cerrar);
		    addEvent(limpiar,'onclick',me.limpiar);
		    
            me.window.centrar();
        }
        me.window.setVisible(true);
        
    }
    this.cerrar = function(){
        me.window.setVisible(false);
    }
    
    this.limpiar = function(){
        var count = me.table.rows.length;
        var i=0;
        for (i=0;i<count;i++){
            me.table.deleteRow(0);
        }
    }
    
    this.log = function(msg){
		var tr =  createRow(this.table,0);
		var cell = createCell(tr,0);
		cell.appendChild(createLabel(msg));
    }
}
var logger = new Logger();
/*definir logger*/
if (iframe == true){
    logger = window.parent.logger;
    if (logger == null){
        logger = window.parent.parent.logger;
    }
}

function logError(ex){
    logMessage(ex.message);
}
function logMessage(msg){
   logger.log(msg);
}

function showLogger(){
    if (iframe == true){
        if (window.parent.showLogger == null)
            window.parent.showLogger();
        else 
            window.parent.parent.showLogger();
    }else{
        logger.show();
    }
}
function setValues(mensaje,descripcion,detalle,botonera,nivel,error){
    try{
        findElement(CONSTANTES.MODAL_INPUT_MENSAJE).value = mensaje;
	    findElement(CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES).value = descripcion;
	    findElement(CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES).value = detalle;
	    findElement(CONSTANTES.INPUT_MODAL_TIPO).value = botonera;
        findElement(CONSTANTES.INPUT_MODAL_NIVEL).value = nivel;
        
        var errorDiv = findElement(CONSTANTES.MODAL_ERROR_DIV);
        
        if (errorDiv!= null){
            findElement(CONSTANTES.MODAL_ERROR_DIV).innerHTML = error;
        }
    }catch(ex){
        throw ex;
    }
}
function mostrarProgressBar(){
    try{
        var botonera = parseInt(document.getElementById(CONSTANTES.INPUT_MODAL_TIPO).value);
        var mensaje = document.getElementById(CONSTANTES.MODAL_INPUT_MENSAJE).value;
		/*si mensaje esta vacio y botonera tiene modal*/
        if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_PROGRESS_BAR) != CONSTANTES.ZERO){
			   return true;
        }
    }catch(ex){
        
    }
    /*no mostrar*/
    return false;
    
}

function mostrarPopup(params){
        try{
            if (params == null)
                params = new Object();
                
            var titulo = 'Panel de Información SIGES';

		    if (document.getElementById(CONSTANTES.MODAL_INPUT_MENSAJE) == null)
		        return;
    		    
		    var mensaje = document.getElementById(CONSTANTES.MODAL_INPUT_MENSAJE).value;
		    /*si no existe mensaje, no se muestra nada*/
		    if (mensaje == null || mensaje == '')
		        return;
    		    
		    var descripcion = document.getElementById(CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES).value;
		    var detalle = document.getElementById(CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES).value;
		    var botonera = parseInt(document.getElementById(CONSTANTES.INPUT_MODAL_TIPO).value);
		    var nivel = document.getElementById(CONSTANTES.INPUT_MODAL_NIVEL).value;
		    var modalErrorDiv = findElement(CONSTANTES.MODAL_ERROR_DIV);
		    var detalleInfo = null;
		    
		    if (modalErrorDiv != null)
		        detalleInfo = modalErrorDiv.innerHTML;
		        
		    /*asignar confirmacion*/
		    
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CONFIRMAR) != CONSTANTES.ZERO){
		    
		        if (params.confirmacionListener == null){
		            /*
		            CONSTANTES.INPUT_MODAL_CONFIRMACION_ID = 'INPUT_MODAL_CONFIRMACION_ID'
                    CONSTANTES.BUTTON_MODAL_CONFIRMAR = 'BUTTON_MODAL_CONFIRMAR'
		            */
		            var hiddenInput = findElement(findElement(CONSTANTES.INPUT_MODAL_CONFIRMACION_ID).value);
		            var BtnInput = findElement(findElement(CONSTANTES.BUTTON_MODAL_CONFIRMAR).value);
		            var confirmacion = new ManejadorConfirmacion(hiddenInput,BtnInput);
		            hiddenInput.value = 'false';
		            params.confirmacionListener = confirmacion.confirmar;
		        }
		    }
		    
            document.getElementById(CONSTANTES.MODAL_INPUT_MENSAJE).value = '';
		    document.getElementById(CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES).value = '';
    		
		    params.detalleInfo = detalleInfo;
        
		    mostrarGenericPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params)
        }catch(ex){
            //alert('error al mostrar Popup'+ex.message+' - ' + ex.name + ' ('+ex.line+')');
            throw ex;
        }
}
function ManejadorConfirmacion(hiddenInput,BtnInput,me){
    me = this;
    me.hiddenInput = hiddenInput;
    me.BtnInput = BtnInput;
    this.confirmar = function(){
        me.hiddenInput.value = 'true';
        //presionar boton con confirmacion
        if( __doPostBack!=null){
            __doPostBack(me.BtnInput.id,'');
        }else{
           var value = SFDispatchEvent(me.BtnInput,'click');
        }
    }
    //asignar true
    
    //asignar bonton
}
function mostrarGenericPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params){
    if (params == null)
        params = new Object();
    /*
    si es volver se le hace click al boton con ID salir  */
    params.volver = SiafGenericVolver;
    
    if (iframe == true){
        if (window.parent.mostrarWindowPopup != null)
	        window.parent.mostrarWindowPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
	    else 
	        window.parent.parent.mostrarWindowPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
    }else{
        mostrarWindowPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
    }
}
function SiafGenericVolver(){
		findElement(CONSTANTES.salir).click();
}
SiafDialog.prototype.imagen = '../img/error32.jpg';
SiafDialog.prototype.titulo = null;
SiafDialog.prototype.mensaje = null;
SiafDialog.prototype.descripcion = null;
SiafDialog.prototype.detalle = null;
SiafDialog.prototype.botonera = null;
SiafDialog.prototype.nivel = null;
SiafDialog.prototype.params = null;
SiafDialog.prototype.hideFlag = null;
SiafDialog.prototype.window = null;
SiafDialog.prototype.botonera = null;
SiafDialog.prototype.responseListener = null;
SiafDialog.prototype.confirmacionListener = null;
SiafDialog.prototype.progressBar = null;

SiafDialog.RESPONSE = new Object();
SiafDialog.RESPONSE.ACEPTAR = 1;
SiafDialog.RESPONSE.CANCELAR = 2;
SiafDialog.RESPONSE.CONFIRMAR = 4;
SiafDialog.RESPONSE.CERRAR = 8;
SiafDialog.RESPONSE.VOLVER = 16;

function SiafDialog(listener,params,me){
    me = this;
    me.hideFlag = false;
    me.listener = listener;
    me.initParams = params;
    
    /*(titulo,mensaje,descripcion,detalle,botonera,nivel,params)*/
    this.show = function(titulo,mensaje,descripcion,detalle,botonera,nivel,params){
        try
	    {
	        me.titulo = titulo;
	        me.mensaje = mensaje;
	        me.descripcion = descripcion;
	        me.detalle = detalle;
	        me.botonera = botonera;
	        me.nivel = nivel;
	        me.params = params;
		    try{
			    if (nivel == CONSTANTES.INPUT_MODAL_NIVEL_ERROR){
				    imagen = '../img/error32.jpg';
			    }else if (nivel == CONSTANTES.INPUT_MODAL_NIVEL_WARNING){
				    imagen = '../img/warn32.png';
			    }else{
				    imagen = '../img/info32.png';
			    }
		    }catch(ex){
		        throw (ex);
		    }
		    //NO SE MUESTRA SI MENSAJE ESTA VACIO
            
            if (mensaje != '' || (me.initParams != null && me.initParams.root != null ) ){
                /*mostrar*/
            }else{
                return;
            }
            
		    var wind = createModalWindow(WINDOW_TIPO.MENSAJES,params);
		    
		    me.window = wind;
		    var div_buttons = wind.footer.data;
		    var div = wind.div;

		    wind.body.imagen.src = imagen;
		    
		    if (me.initParams != null && me.initParams.root != null ){
		        wind.body.detalles.appendChild(me.initParams.root);
		        
		        me.initParams.root.style.width = '100%';
		        me.initParams.root.style.height = '100%';
		        me.initParams.root.style.overflow = 'visible';
		        
		        wind.body.detalles.appendChild(createHR('HrFin'));
		        
		    }else{
                wind.body.mensajeLbl.innerHTML = mensaje;		    
                
		    }
		    wind.body.detallesLbl.innerHTML = descripcion;
		    
		    me.wind = wind;

		    var acceptBtn = createButton(CONSTANTES.MENSAJES.ACEPTAR);
		    var cancelBtn = createButton(CONSTANTES.MENSAJES.CANCELAR);
		    var volverBtn = createButton(CONSTANTES.MENSAJES.VOLVER);
		    var confirmBtn = createButton(CONSTANTES.MENSAJES.CONFIRMAR);
		    var cerrarBtn = createButton(CONSTANTES.MENSAJES.CERRAR);
		    var detallesBtn = createButton(CONSTANTES.MENSAJES.DETALLES);
		    
    		
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR) != CONSTANTES.ZERO){
			    div_buttons.appendChild(acceptBtn);
			    addEvent(acceptBtn,'onclick',me.aceptar);
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CANCELAR) != CONSTANTES.ZERO){
			    div_buttons.appendChild(cancelBtn);
			    //cancelBtn.innerHTML = 'Test!' + me.cancelar;
			    addEvent(cancelBtn,'onclick',me.cancelar);
			    //wind.habilitarCerrar = me.cancelar;
			    me.window.clickXCallback = me.cancelar;
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CONFIRMAR) != CONSTANTES.ZERO){
		        me.confirmacionListener = params.confirmacionListener;
			    div_buttons.appendChild(confirmBtn);
			    addEvent(confirmBtn,'onclick',me.confirmar);
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_PROGRESS_BAR) != CONSTANTES.ZERO){
			    var progressBar = createImage('../img/progressbar.gif');
			    progressBar.className = 'modal_progress_bar';
			    div_buttons.appendChild(progressBar);
			    //div_buttons.style.backgroundColor = COLORS.WHITE;
			    siafProgressBar.show(me.window);
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CERRAR) != CONSTANTES.ZERO){
			    div_buttons.appendChild(cerrarBtn);
			    addEvent(cerrarBtn,'onclick',me.cerrar);
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_VOLVER) != CONSTANTES.ZERO && parseInt(botonera^CONSTANTES.ALL_BITS) != CONSTANTES.ZERO){
			    div_buttons.appendChild(volverBtn);
			    addEvent(volverBtn,'onclick',me.volver);
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_DETALLES_ERROR) != 0){
			    div_buttons.appendChild(detallesBtn);
			    addEvent(detallesBtn,'onclick',me.showDetallesError);
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CUSTOM_MSG) != 0){
		        var customBtn = createButton(params.custom_message);
		        div_buttons.appendChild(customBtn);
		        addEvent(customBtn,'onclick',me.selectCustomButton);
		    }
		    me.window.centrar();
		    me.window.setCloseListener(me.hide);
	    }
	    catch (ex)
	    {
		    throw ex;
	    }
    };
    
    this.hide = function(){
        if (parseInt(me.botonera&CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR||me.botonera&CONSTANTES.INPUT_MODAL_BOTON_CANCELAR ) != CONSTANTES.ZERO){
            return true;/*si es aceptar esconder*/
        }
        return me.hideFlag;
    };
    this.Visible = function(){
        me.wind.div.style.display = 'block';
    }
    this.noVisible = function(){
        me.wind.div.style.display = 'none';
    }
    this.esconderDiv =  function(event){
    
//		esconderTapaModalDiv(param0);
	};
	this.selectCustomButton = function(event){
	    if(me.params.custom_select()==true){
	        me.window.hide();
	    }
	};
	this.aceptar =  function(event){
        me.window.hide();
        if (me.responseListener != null){
            me.responseListener(SiafDialog.RESPONSE.ACEPTAR);
        }
        if (me.listener != null){
            if (me.listener.aceptar != null)
                me.listener.aceptar();
            me.listener.closeDialog();
        }
        
	};
	this.confirmar =  function(event){
	    me.window.hide();
	    if (me.confirmacionListener != null){
	        me.confirmacionListener();
	    }
	};
	this.cancelar =  function(event){
		me.window.hide();
		if (me.responseListener != null){
		    me.responseListener(SiafDialog.RESPONSE.CANCELAR);
		}
		if (me.listener != null){
		    if (me.listener.cancelar != null)
                me.listener.cancelar();
            me.listener.closeDialog();
        }
	};
	this.volver =  function(event){
		me.window.hide();
		if (me.responseListener != null){
		    me.responseListener(SiafDialog.RESPONSE.VOLVER);
		}
		try{
		    me.params.volver();
		}catch(ex){
		}
		
	};
	this.cerrar =  function(event){
		/*esconderTapaModalDiv(param0);*/
		me.window.hide();
		if (me.responseListener != null){
		   me.responseListener(SiafDialog.RESPONSE.CERRAR);
		}
	};
	this.showDetallesError =  function(event){
	    me.noVisible();
	    var listener  = new Object();
	    //al aceptar que me notifique para volver a mostrar el popup
	    listener.closeDialog = me.aceptarDetalle;
	    listener.closeListener = me.aceptarDetalle;
	    
	    var detalleXML = loadXMLString(me.params.detalleInfo);
	    
	    var errores = getChildNodes(detalleXML.getElementsByTagName('ERRORES')[0]);
	    var log = '';
	    var div = createDiv('ModalDetalles');
	    var table = createTable();
	    
	    if (errores != null && errores.length>0){
	        var row = createRow(table,0,'DetallesHeader');
	        
	        var cell1 = createCell(row,0);
	        var cell2 = createCell(row,1);
	        var cell3 = createCell(row,2);
	        
	        cell1.appendChild(createLabel('Clase'));
            cell2.appendChild(createLabel('Metodo'));
            cell3.appendChild(createLabel('Descripcion'));
	            
	        for (var i=0;i<errores.length;i++){
	            row = createRow(table,i+1);
	            var node = loadNode(errores[i]);
	            cell1 = createCell(row,0);
	            cell2 = createCell(row,1);
	            cell3 = createCell(row,2);
	            cell1.appendChild(createLabel(node['CLASE']));
	            cell2.appendChild(createLabel(node['METODO']));
	            cell3.appendChild(createLabel(node['DESCRIPCION']));
	        }
	        div.appendChild(table);
	    }else{
	        div.innerHTML = me.params.detalleInfo;
	    }
/*	    
	    for (var i=0;i<3;i++){
	        
	        var cell1 = createCell(row,0);
	        var cell2 = createCell(row,1);
	        
	        cell1.appendChild(createLabel('label 1' + i));
	        cell2.appendChild(createLabel('label 2' + i));
	    }*/
	    alertObject(div,listener)
	};
	this.aceptarDetalle = function(event){
	    me.Visible();
	};
	this.openUrl = function(event){
	    document.location.href=param0;
	};
	this.test = function(event){
	    alert('y ahora es test! '+param0);
		return false;
	};
	this.mostrarConfirmacion = function(event){
		//return confirmarPopup(param0,param1,param2);
	};
	
}
function mostrarWindowPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params,listener,initParams){
	var dialog = new SiafDialog(listener,initParams);
	dialog.show(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
	return dialog;
}
function mostrarPopupDetallesError(parentDiv){
    
    try{
        var errorDiv = findElement(CONSTANTES.MODAL_ERROR_DIV);
        
        if (errorDiv!=null){
            parentDiv.style.display = 'none';
            var div = createAbsoluteDiv('100','100','400px','auto');
            try{
                getBody().appendChild(div);
                var xml = errorDiv.innerHTML;
                div.innerHTML = xml;
                
                /*var xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
                xmlDoc.async="false";
                var xml = errorDiv.innerHTML;
                xmlDoc.loadXML(xml);
                
                var table = createTable('modal_error_table');
                
                getBody().appendChild(div);
	            div.appendChild(table);
	            
	            for (var i=0 ;i< xmlDoc.getElementsByTagName(CONSTANTES.METODO).length;i++ )
	            {
		            var error1 =  xmlDoc.getElementsByTagName(CONSTANTES.CLASE)[i].childNodes[0].nodeValue;
                    var error2 = xmlDoc.getElementsByTagName(CONSTANTES.METODO)[i].childNodes[0].nodeValue;
		            var error3 = xmlDoc.getElementsByTagName(CONSTANTES.DESCRIPCION)[i].childNodes[0].nodeValue;
                    		
                    var fila =	createRow(table,i);
                    				
                    var cell1 = createCell(fila,0,'modal_error_table_clase');
                    var cell2 = createCell(fila,1,'modal_error_table_metodo');
                    var cell3 = createCell(fila,2,'modal_error_table_descripcion');
                    
                    cell1.appendChild(createTextNode(error1));
                    cell2.appendChild(createTextNode(error2));
                    cell3.appendChild(createTextNode(error3));
                    
              }
              */
            }catch(ex){
                throw ex;
            }
	        
	        div.className='modal_framecito';
	        var div_buttons = createDiv();
	        div.appendChild(div_buttons);
	        div_buttons.className = 'modal_botonera';
	        var acceptBtn = createButton(CONSTANTES.MENSAJES.ACEPTAR);
	        div_buttons.appendChild(acceptBtn);
	        addEvent(acceptBtn,'onclick',new elegirItem(div,parentDiv).aceptarDetalle);
	        centrarDiv(div);
	    }
   
   }catch(ex){
        throw ex;
   }
    
}
function mostrarPopupDetallesErrorOld(parentDiv){
    
    try{
        var errorDiv = findElement(CONSTANTES.MODAL_ERROR_DIV);
        
        if (errorDiv!=null){
            parentDiv.style.display = 'none';
            var div = createAbsoluteDiv('100','100','400px','auto');
            try{
                getBody().appendChild(div);
                var xml = errorDiv.innerHTML;
                div.innerHTML = xml;
            }catch(ex){
                throw ex;
            }
	        
	        div.className='modal_framecito';
	        var div_buttons = createDiv();
	        div.appendChild(div_buttons);
	        div_buttons.className = 'modal_botonera';
	        var acceptBtn = createButton(CONSTANTES.MENSAJES.ACEPTAR);
	        div_buttons.appendChild(acceptBtn);
	        addEvent(acceptBtn,'onclick',new elegirItem(div,parentDiv).aceptarDetalle);
	        centrarDiv(div);
	    }
   }catch(ex){
        throw ex;
   }
}
/*Asociar un elemento(onclick) para que muestre un Selector */
function asociarMySelector(eleId,comboId,asociarTextCombo){
    var ele = findElement(eleId);
    var combo = findElement(comboId);
    var selector = new MySelector(ele,combo,asociarTextCombo);
    selector.config();
}

/*
Buscador en Pantallita para Combo Box
*/
MySelector.prototype.element = null;
MySelector.prototype.combo = null;
MySelector.prototype.items = null;
MySelector.prototype.div = null;
MySelector.prototype.label = null;
MySelector.prototype.bodyOptions = null;
MySelector.prototype.selectedIndex = null;
MySelector.prototype.selectedItem = null;
MySelector.prototype.searchInput = null;
MySelector.prototype.searchText = null;
MySelector.prototype.timer = null;
MySelector.prototype.asociarCombo = null;
MySelector.prototype.tipoSeleccion = 1;
MySelector.prototype.window = null;

MySelectorTipos = new Object();
MySelectorTipos.DEFAULT = 1;
MySelectorTipos.LINK = 1;
MySelectorTipos.CHECKBOX = 2;
MySelectorTipos.RADIO = 3;
MySelectorTipos.BUTTON = 4;
/*
    asociarCombo es opcional,
    asociar
*/
function MySelector(ele,combo,asociarCombo,me){
    
    this.element = ele;
    this.combo = combo;
    this.asociarCombo = asociarCombo;
    this.tipoSeleccion = MySelectorTipos.DEFAULT;
    
    this.config = function(){
        me = this;
        this.label = ele.id;
        addEvent(this.element,'onclick',this.open);
    }
    this.close = function(){
        me.window.hide();
    }
    this.accept = function(){
        var oldIndex = me.combo.selectedIndex;
       
        if (me.selectedItem != null){
            me.combo.selectedIndex = me.selectedItem.index;
        }
        if (me.asociarCombo != null){
         //   me.asociarCombo.mostrarCombo();
            me.asociarCombo.cambiarCombo();
        }
        try{
            if (this.oldIndex != me.selectedItem.index)
                me.combo.onchange()
        }catch(ex){
            /*no tiene onchange el combo*/
        }
        me.close();
    }
    this.search = function(){
        clearTimeout(me.timer);
        me.timer = setTimeout(me.imprimirOpciones,200);
    }
    this.imprimirOpciones = function(){
        me.searchText = me.searchInput.value;

        if (me.items != null){
            for (var i=0;i<me.items.length ;i++ ){
                var item = me.items[i];
                if(item.optionDiv != null)
                    me.bodyOptions.removeChild(item.optionDiv);
            }
        }
        me.items = new Array();
        
        for (var i=0;i<me.combo.options.length ;i++ )
		{
		    if ((StringUtil.intoString(me.combo.options[i].text,me.searchText,true,true) == true) || i == me.selectedIndex){
		        var item = new Object();
		        
		        item.index = i;
		        item.option = me.combo.options[i];
		        item.label = createLabelHTML(insertarEstiloEnTexto(me.combo.options[i].text,me.searchText,'textoEncontrado'));
			    
			    me.items.push(item);
			    
    			if (me.tipoSeleccion == MySelectorTipos.LINK){

    			}else if (me.tipoSeleccion == MySelectorTipos.CHECKBOX){
    			    item.checkBox = createCheckBox();
    			}else if (me.tipoSeleccion == MySelectorTipos.RADIO){
    			
    			}else if (me.tipoSeleccion == MySelectorTipos.BUTTON){
    			
    			}else {
    			
    			}
    			var optionDiv = createDiv();
			    optionDiv.className = 'SelectorItem';
			    item.optionDiv = optionDiv;
			    me.bodyOptions.appendChild(optionDiv)
			    
			    if (me.tipoSeleccion == MySelectorTipos.LINK){
			        item.link = createLink(item.label.innerHTML);
    			    optionDiv.appendChild(item.link);
    			    addEvent(item.link,'onclick',new callback(me.selectItem,item).call);
    			    optionDiv.style.border = 'none';
    			    if (i%2 == 1){
    			        optionDiv.style.backgroundColor =  CONSTANTES.STYLES.COLOR_IMPAR;
    			    }
    			    if (i == me.selectedIndex){
    			        optionDiv.style.fontWeight =  'BOLD';
    			    }
    			    
    			}else if (me.tipoSeleccion == MySelectorTipos.CHECKBOX){
    			    item.checkBox = createCheckBox();
			        optionDiv.appendChild(item.checkBox);
			        optionDiv.appendChild(item.label);
			        addEvent(item.checkBox,'onclick',new callback(me.selectItem,item).call);
			        
			        if(me.combo.options[i].selected)
			         {
    			            me.selectedIndex = i;
			                me.selectedItem = item;
			                item.checkBox.checked = true;
			         }
			            
    			}else if (me.tipoSeleccion == MySelectorTipos.RADIO){
    			        if(me.combo.options[i].selected)
			            {
    			            me.selectedIndex = i;
			                me.selectedItem = item;
			                item.checkBox.checked = true;
			            }
			            optionDiv.appendChild(selectorComponent);
			            optionDiv.appendChild(item.label);
    			}else if (me.tipoSeleccion == MySelectorTipos.BUTTON){
    			
    			}else {
    			
    			}
		    }
		}
    }
    this.selectItem = function(param){
        if (me.tipoSeleccion == MySelectorTipos.LINK){
            me.selectedItem = param;
            me.accept();
    	}else if (me.tipoSeleccion == MySelectorTipos.CHECKBOX){
    	    if (me.selectedItem != null)
                me.selectedItem.checkBox.checked = false;
            param.checkBox.checked = true;
            me.selectedItem = param;
            
    	}else if (me.tipoSeleccion == MySelectorTipos.RADIO){
    	
    	}else if (me.tipoSeleccion == MySelectorTipos.BUTTON){
    	
    	}else {
    			
    	}
    }
    this.open = function(){
        try{
            var params = new Object();
            params.width = '50%';
            params.height = '80%';
            var wind = createModalWindow(null,params);
           
            wind.clickXCallback = me.close;
           
            me.window = wind;
		   
		    var div_buttons = wind.footer.data;
		    me.div = wind.div;
		    me.selectedIndex = me.combo.selectedIndex;
		   
		    var div = me.div;
		    me.items = new Array();
		   
		    var table = createTable();
		    var head =  createRow(table,0);
		    head.className = 'SelectorHeader';
		   
		    var body =  createRow(table,1);
		    var cell1 = createCell(head,0);
		    var cell2 = createCell(head,1);
		    var cell3 = createCell(body,0);
		   
		    cell3.colSpan = 2   ;
		    cell1.appendChild(createLabel('Buscar'));
		   
		    me.searchInput = createTextField();
		    cell2.appendChild(me.searchInput);
		    //cell2.appendChild(createImage('../img/search10x20.jpg'));
		   
		    me.bodyOptions = createDiv();
		    me.bodyOptions.className = 'SiafCustomSelectorOptions';
		    cell3.appendChild(me.bodyOptions);
		    wind.body.div.className = 'SiafCustomSelector';
		    wind.body.div.appendChild(table);
		   
		    var div_buttons = wind.footer.data;
		    var aceptar = null;
		    var cancelar = createButton(CONSTANTES.MENSAJES.CANCELAR);
    		
		    if (me.tipoSeleccion == MySelectorTipos.LINK){

    	    }else if (me.tipoSeleccion == MySelectorTipos.CHECKBOX){
    	        aceptar = createButton(CONSTANTES.MENSAJES.ACEPTAR);
    	    }else if (me.tipoSeleccion == MySelectorTipos.RADIO){
        		
    	    }else if (me.tipoSeleccion == MySelectorTipos.BUTTON){
        			
    	    }else {
        			
    	    }
    	    if (aceptar != null){
    	        div_buttons.appendChild(aceptar);
                addEvent(aceptar,'onclick',me.accept);
    	    }
		    div_buttons.appendChild(cancelar);
    		
    		
		    addEvent(cancelar,'onclick',me.close);
    		

		    addEvent(me.searchInput,'onkeydown',me.search);
    		
		    me.imprimirOpciones();
            centrarDiv(div);
            
            wind.setCloseListener(me.close);
            
            me.searchInput.focus();
         }catch(ex){
            throw ex;
         }
    }
}
function SiafSearch(name,target,targetLabel,params,consultaAsp,listener){
    //Si llamo desde el hijo
    try{
        if (iframe == true){
            var inputConsulta = findElement('INPUT_CONSULTA');
            consultaAsp = null;
            if (inputConsulta!=null){
                if (inputConsulta.value != null && inputConsulta.value != ''){
                     consultaAsp = inputConsulta.value;
                }   
            }
            if (parent.SiafSearch != null)
                parent.SiafSearch(name,target,targetLabel,params,consultaAsp,listener);
            else   
                parent.parent.SiafSearch(name,target,targetLabel,params,consultaAsp,listener);
        }
        else{
            var search = new SiafSearchComponent();
            search.name = name;
            search.target = target;
            search.targetLabel = targetLabel;
            search.tipoSeleccion = MySelectorTipos.LINK;
            search.params = params;
            search.listener = listener;
            
            if (consultaAsp != null){
                search.url = '../'+consultaAsp+'?TIPO='+name;
            }else{
                search.url = '../NNM/consulta.aspx?TIPO='+name;
            }
            search.open();
       }
   }
   catch(ex){
    throw ex;
   }
}
    
function SiafSearchComponent(me){
    me = this;
    me.url = '';
    me.items = new Array();
    me.results = new Array();
    me.urlParams ='';
    this.search = function(){
    
    }
    this.close = function(){
        me.window.hide();
    }
    this.selectItem = function(node,evt){
        
        
        me.close();
        
      
        
        me.target.value = node.value;
        
        if (node.label == null){
            node.label = node.value;
        }
        if (me.targetLabel.value != null){
            me.targetLabel.value = node.label;
        }
        
        if (me.listener != null){
            me.listener(node);
        }
        if (me.target.onchange != null){
            //me.target.onchange(evt);
            //setTimeout(me..onchange,100);
            SFDispatchEvent(me.target,'change');
            
/*            eval(me.target.getAttribute('onchange'));
            alert('evaluado!');*/
        }
    }
    this.accept = function(){
        
    }
    this.search2Server = function(){
        clearTimeout(me.timer);
        me.buscar.disabled = true;
        
        /*esperar que se reciban los valores*/
        if (me.ajax != null){
            me.timer = setTimeout(me.search2Server,500);
        }
        var query = '';
        for (var i=0;i<me.items.length;i++){
            var filtro = me.items[i];
            query = query + '&'+filtro.name +'='+filtro.input.value;
        }
        var url = me.url;
        url = url +'&OPTION=SEARCH&'+me.params;
        url = url + query;
        url = url + me.urlParams;
        
        me.ajax = new JRAjax(url);
        me.ajax.send(me.searchResults);
    }
    this.validarInput = function(){
        var valido = false;
        for (var i=0;i<me.items.length;i++){
            var filtro = me.items[i];
            if (filtro.input.selectedIndex != null)
            {
               valido = filtro.input.selectedIndex>0
            }
            else if (filtro.minchars <= filtro.input.value.length){
                valido = true;
                i = me.items.length;
            }
        }
        me.buscar.disabled = !valido;
    }
    this.searchResults = function(obj){
        me.ajax = null;
        
        try{
            var tabs = getChildNodes(obj.getElementsByTagName('resultados')[0]);
            var properties = loadNode(obj.getElementsByTagName('propiedades')[0]);
            
            var cols = null;
            
            if (properties.cols != null)
                cols = parseInt(properties.cols);
                
            if (properties.mensaje != null){
                me.mensaje.innerHTML = properties.mensaje;    
            }else{
                me.mensaje.innerHTML = '';
            }
            var rows = me.tableOptions.rows.length;
            
            for (var i=0;i<rows ;i++ ){
                me.tableOptions.deleteRow(0);
            }
            
            
            me.results = new Array();
            var j=0;
            var i=0;
            for (i=0;i<tabs.length ;i++ )
		    {
		        var node = loadNode(tabs[i]);
		        var row = createRow(me.tableOptions,i);
		        if (i%2 == 0){
		            row.className = 'DetalleAlterno';
		        }else{
		            row.className = 'DetallePrincipal';
		        }
		        var callItem = new callback(me.selectItem,node).call;
		        for (j=0;j<cols;j++){
		            var cell = createCell(row,j);
		            var link = createLink(node['campo'+j]);
                    cell.appendChild(link);
                    addEvent(link,'onclick',callItem);
		        }
		        me.results.push(node);
		        //var optionDiv = createDiv();
                //optionDiv.className = 'SelectorItem';
                //me.bodyOptions.appendChild(optionDiv)
		    }
		    if (i==0){
		        var row = createRow(me.tableOptions,0);
		        var cell = createCell(row,0);
		        cell.colSpan = cols;
		        cell.appendChild(createLabel('La Busqueda no tuvo resultados...'));
		    }
		    centrarDiv(me.div);
		    me.validarInput();
        }catch(ex){
            throw ex;
        }
        
    }
    this.keyUp = function(evt){
        if (me.buscar.disabled == false){
            if(evt!=null && evt.keyCode == '13'){
                me.search();
            }
            else if(event.keyCode=='13'){
                me.search();
            }
        }
        
    }
    this.search = function(){
        me.buscar.disabled = true;
        clearTimeout(me.timer);
        me.timer = setTimeout(me.search2Server,100);
    }
    this.receiveForm = function(obj){
        var tabs = getChildNodes(obj.getElementsByTagName('filtros')[0]);
		
		var row =  createRow(me.table,0);
		row.className = 'SelectorHeader';
		var cell = createCell(row,0);
		cell.colSpan = 2;
		
		me.mensaje = createLabel('Presione ENTER para BUSCAR','WarningLabel'); 
		
		cell.appendChild(me.mensaje);
		
		
		for (var i=0;i<tabs.length ;i++ )
		{
		    var node = loadNode(tabs[i]);
		    
		    var filtro = new Object();
		    filtro.minchars = 1;
		    
		    if (node.minchars != null){
		        filtro.minchars = parseInt(node.minchars);
		    }
		    
		    me.items.push(filtro);
		    
		    filtro.name = node.name;
		    
			
			var head =  createRow(me.table,i);
		    head.className = 'SelectorHeader';
		    
		    var cell1 = createCell(head,0);
		    var cell2 = createCell(head,1);
		
    		cell1.appendChild(createLabel(node.label));
    		
    		if (node.tipo == 'SELECT'){
    		    /*crear select y asignar los options*/
    		    var select = createSelect();
    		    cell2.appendChild(select);
    		    
    		    var options = getChildNodes(node.options);
    		    
    		    select.options[0] = new Option('Elegir','')
    		    for (var j=0;j<options.length;j++){
    		        var myOption = loadNode(options[j]);
    		        select.options[j+1] = new Option(myOption.label,myOption.value);
    		    }
    		    filtro.input = select;
    		    addEvent(select,'onchange',me.validarInput);
    		}else{
    		    var searchInput = createTextField();
		        cell2.appendChild(searchInput)
		        addEvent(searchInput,'onkeyup',me.validarInput);
		        filtro.input = searchInput;
    		}
		    
		    //me.searchInput = createTextField();
		    //cell2.appendChild(me.searchInput);
		}
		centrarDiv(me.div);
    }
    this.open = function(){
        
        
        me.urlParams = '';
        for (var param in me.params){
            me.urlParams = me.urlParams + '&'+param+'='+me.params[param];
        }
        
        var ajax = new JRAjax(me.url+me.urlParams);
        ajax.send(me.receiveForm);
        
        var wind = createModalWindow();
        me.window = wind;
		var div_buttons = wind.footer.data;
		me.div = wind.div;
		//me.selectedIndex = me.combo.selectedIndex;
		var div = me.div;
		me.items = new Array();
		var table = createTable();
		me.table = table;
		//addEvent(searchInput,'onkeyup',me.validarInput);
		
		addEvent(me.table,'onkeyup',me.keyUp);
		
		var body =  createRow(table,0);
		var cell3 = createCell(body,0);
		
		cell3.colSpan = 2   ;
		
		//cell2.appendChild(createImage('../img/search10x20.jpg'));
		me.bodyOptions = createDiv();
		me.bodyOptions.className = 'SiafCustomSelectorOptions';
		
		cell3.appendChild(me.bodyOptions);
		me.tableOptions = createTable('DataGridMant');
		me.bodyOptions.appendChild(me.tableOptions);
		
		wind.body.div.className = 'SiafCustomSelector';
		wind.body.div.appendChild(table);
		var div_buttons = wind.footer.data;
		me.buscar = createButton(CONSTANTES.MENSAJES.BUSCAR);
		var cancelar = createButton(CONSTANTES.MENSAJES.CANCELAR);
		
		if (me.tipoSeleccion == MySelectorTipos.LINK){

    	}else if (me.tipoSeleccion == MySelectorTipos.CHECKBOX){
    	    aceptar = createButton(CONSTANTES.MENSAJES.ACEPTAR)
    	    
    	}else if (me.tipoSeleccion == MySelectorTipos.RADIO){
    		
    	}else if (me.tipoSeleccion == MySelectorTipos.BUTTON){
    			
    	}else {
    			
    	}
    	if (me.buscar != null){
    	    div_buttons.appendChild(me.buscar);
    	    me.buscar.disabled = true;
    	    addEvent(me.buscar,'onclick',me.search);
    	}
		div_buttons.appendChild(cancelar);
		addEvent(cancelar,'onclick',me.close);

		//addEvent(me.searchInput,'onkeydown',me.search);
		
		//me.imprimirOpciones();
        centrarDiv(div);
        wind.setCloseListener(me.close);
        
        //me.searchInput.focus();
    }
};
function getBody(){
	return document.getElementsByTagName('BODY')[0];
}
function getIFrameCtx(){
    
    if (findElement('myIframe').contentWindow != null)
        return findElement('myIframe').contentWindow;
        
    return findElement('myIframe').document;
}

//crear elementos
function createText(text){
	var span = document.createElement('span');
	span.innerHTML = text;
	return span;
}
function createTextNode(text){
    return document.createTextNode(text);
}
function createImage(url){
	var img = document.createElement('img');
	img.src = url;
	return img;
}
function createLabel(text,className){
	var label = document.createElement('label');
	label.appendChild(createTextNode(text));
	
	if (className != null)
	    label.className = className;
	    
	return label;
}
function createLabelHTML(text){
	var label = document.createElement('label');
	label.innerHTML = text;
	return label;
}
function createLink(text){
	var label = document.createElement('a');
	label.href = '#';
	label.innerHTML = text;
	return label;
}
function createAbsoluteDiv(x,y,w,h){
	var div = document.createElement('div');
	div.style.position = 'absolute'
	div.style.left = x;
	div.style.top = y;
	div.style.width = w;
	div.style.height = h;
	return div;
	
}
function createSelect(){
    var input = document.createElement('select');
	return input;
}

function createCheckBox(){
	var input = document.createElement('input');
	input.type = 'checkbox';
	return input;
}
function createTextField(){
	var input = document.createElement('input');
	input.type = 'text';
	return input;
}
function createButton(label){
	var input = document.createElement('input');
	input.type = 'button';
	input.value = label;
	return input;
}
function createDiv(className){
	var div = document.createElement('div');
	div.className = className;
	return div;
}
function createHR(className){
    var table = document.createElement('HR');
    table.className = className;
    return table;
}
function createIframe(url){
	var iframe = document.createElement('IFRAME');
    return iframe;
}
function createTable(className){
    var table = document.createElement('TABLE');
    table.className = className;
    return table;
}
function createRow(table,cellNum,className){
    var row = table.insertRow(cellNum);
    row.className = className;
    return row;
}
function createCell(row,cellNum,className){
    var cell = row.insertCell(cellNum);
    cell.className = className;
    return cell;
}

SiafModal.prototype.div = null;
SiafModal.prototype.iframe = null;
SiafModal.prototype.modalTapa1 = null;
SiafModal.prototype.modalTapa2 = null;
SiafModal.prototype.div = null;
SiafModal.prototype.parentDiv = null;

function SiafModal(parentDiv,me){
    me = this;
    this.parentDiv = parentDiv;
        
    me.show = function(){
	    /*var tapa1 = document.getElementById(CONSTANTES.div_ajax_tapa1);
	    var tapa2 = document.getElementById(CONSTANTES.div_ajax_tapa2);*/
    	
        try{
            me.modalTapa1 = createDiv();
			me.modalTapa2 = createDiv();
        
			var wh = SiafWindowUtil.getPageSizeWithScroll();

			getBody().appendChild(me.modalTapa1);
			getBody().appendChild(me.modalTapa2);
    			
			me.modalTapa1.className = CONSTANTES.STYLES.MODAL_TAPA1;
            me.modalTapa2.className = CONSTANTES.STYLES.MODAL_TAPA2;
    			
            me.modalTapa1.style.top = '0px';
            me.modalTapa2.style.left = '0px';

            me.modalTapa1.style.height = wh.height+'px';
            me.modalTapa1.style.width = wh.width+'px';
    			
            me.modalTapa2.style.height = wh.height+'px';
            me.modalTapa2.style.width = wh.width+'px';
    	    
    	    if (me.parentDiv != null){
    	        me.modalTapa1.style.zIndex = parseInt(me.parentDiv.style.zIndex)+1;
                me.modalTapa2.style.zIndex = parseInt(me.parentDiv.style.zIndex)+2;
    	    }
            me.modalTapa1.style.display = 'block';
            me.modalTapa2.style.display = 'block';
            
        }catch(ex){
            throw ex;
        }
    };
    this.hide = function(){
        getBody().removeChild(me.modalTapa2);
        getBody().removeChild(me.modalTapa1);
    };
    this.setVisible = function(param){
        me.modalTapa1.style.display = 'block';
        me.modalTapa2.style.display = 'block';

        if (param == false){
            me.modalTapa1.style.display = 'none';
            me.modalTapa2.style.display = 'none';
        }
    }; 
}
SiafPopupWindow.prototype.div = null;
SiafPopupWindow.prototype.table = null;
SiafPopupWindow.prototype.tr = null;
SiafPopupWindow.prototype.header = null;
SiafPopupWindow.prototype.body = null;
SiafPopupWindow.prototype.footer = null;
SiafPopupWindow.prototype.footer = null;
SiafPopupWindow.prototype.closeIcon = null;
SiafPopupWindow.prototype.closeListener = null;
SiafPopupWindow.prototype.parent = null;
SiafPopupWindow.prototype.modal = null;

function SiafPopupWindow(me){
    me = this;
    this.setCloseListener = function(closeListener){
        me.closeListener = closeListener;
    };
    this.close = function(){
        if (me.closeListener != null){
            if(me.closeListener()==true){
                me.hide();     
            }
        }else{
        
        }
        
    };
    this.clickX = function(){
       if (me.clickXCallback != null){
            me.clickXCallback();
       }
    };
    this.hide = function(){
        if (me.modal != null){
            me.modal.hide();   
        }
        me.parent.removeChild(me.div);
    }
    this.setVisible = function(param){
        me.div.style.display = 'block';
        if (param == false){
            me.div.style.display = 'none';
        }
        if (me.modal != null){
                me.modal.setVisible(param)
        }
    }; 
    this.show = function(parent){
       if (parent == null)
          parent = getBody();
       me.parent = parent;
       parent.appendChild(me.div);
    };
    this.showModal = function(parent){
        me.modal = new SiafModal();
        me.modal.show();
        me.show(parent);
    };
    this.centrar = function(parent){
        centrarDiv(me.div);
    };
}
function createModalWindow(tipo,params){
    return createWindow(tipo,true,null,params);
}
/*
function para crear una ventanita

*/
/*
@deprecated
fnc createWindowOldOld(tipo,modal,restricciones,params){
	var wind = new SiafPopupWindow();
	
	wind.div = createAbsoluteDiv('100','100','350px','auto');
	
	if (restricciones == null)
	    restricciones  = CONSTANTES.WINDOW_SHOW_HEADER|CONSTANTES.WINDOW_SHOW_BODY|CONSTANTES.WINDOW_SHOW_FOOTER;
	    
    var restrictionsInt = restricciones;
    
    
    
    if (modal){
        wind.showModal();
    }else{
        //
        wind.show();
    }
	wind.div.className = 'ModalFramecito'
	wind.table = createTable();
	wind.tr = new Array();
	
	
	if (parseInt(restrictionsInt&CONSTANTES.WINDOW_SHOW_HEADER) !=  CONSTANTES.ZERO){
	    
	    wind.header = new Object();    
	    
	    wind.trHeader = createRow(wind.table,wind.table.rows.length);
	    wind.header.icon = createCell(wind.trHeader,0,'modal_title_icon');
	    wind.header.data = createCell(wind.trHeader,1,'modal_title');

	    wind.header.closeButton = createCell(wind.trHeader,2,'modal_title_close');
       	wind.header.icon.style.width = '5px'
	    wind.header.closeButton.style.width = '5px'
	    wind.header.data.style.width = '100%'
	    
	    wind.header.titulo = createLabel('Ventana Ayuda SIAF');

	    wind.header.data.appendChild(wind.header.titulo);

	    var iconImg = createImage('../img/icon.gif')
	    wind.header.iconImg = iconImg;
	    wind.header.icon.appendChild(wind.header.iconImg);
	    
	    var cerrarImg = createImage('../img/cerrar.gif');
	    wind.header.closeButton.appendChild(cerrarImg);
	    addEvent(cerrarImg,'onclick',wind.close);
	}
	if (parseInt(restrictionsInt&CONSTANTES.WINDOW_SHOW_BODY) !=  CONSTANTES.ZERO){
	    	    
	    
        wind.body = new Object();
        
	    wind.trBody = createRow(wind.table,wind.table.rows.length);
	    wind.body.data = createCell(wind.trBody,0,'ModalInfo');
	    wind.body.data.colSpan=3;
	    
	    if (WINDOW_TIPO.MENSAJES == tipo)
	    {
		    wind.body.div =  createDiv();
		    wind.body.div.className =  'ModalInfo';

		    wind.body.imagen = createImage('../img/warn32.png');
		    wind.body.mensaje =  createDiv();
		    wind.body.mensajeLbl = createLabel('Test');
		    wind.body.detalles =  createDiv();
		    wind.body.detalles.className = 'ModalInfoDetails';
    		
		    wind.body.detallesLbl =  createLabel('Observaciones saslkajskajskljalskjañsjaklñs asjaklñsjlñak sklñajsklñajsñklajsa sajslñkaj sasjklñajsklñajñ');
    		
		    wind.body.data.appendChild(wind.body.div);
		    wind.body.div.appendChild(wind.body.imagen);

		    wind.body.div.appendChild(wind.body.mensaje);
		    wind.body.div.appendChild(wind.body.detalles);

		    wind.body.mensaje.appendChild(wind.body.mensajeLbl);
		    wind.body.detalles.appendChild(wind.body.detallesLbl);
	    }else{
	        wind.body.div =  createDiv();
	        wind.body.data.appendChild(wind.body.div);
	    }
	}
	if (parseInt(restrictionsInt&CONSTANTES.WINDOW_SHOW_FOOTER) != CONSTANTES.ZERO){
	    wind.footer = new Object();
	    wind.trFooter = createRow(wind.table,wind.table.rows.length);
	    wind.footer.data = createCell(wind.trFooter,0,'ModalBotonera');
	    wind.footer.data.colSpan=3;
	}
	wind.div.appendChild(wind.table)
	
	if (params != null){
	    if (params.width != null){
	        wind.div.style.width =  params.width;
	    }
	    if (params.height != null){
	        wind.div.style.height =  params.height;
	    }
	    
	    if (restrictionsInt&CONSTANTES.WINDOW_SHOW_HEADER !=  CONSTANTES.ZERO){
	        if (params.title != null){
	            wind.header.titulo.innerHTML = params.title;
	        }
	    }
	    if (restrictionsInt&CONSTANTES.WINDOW_SHOW_BODY !=  CONSTANTES.ZERO){
	        if (params.bodyHeight != null){
	            wind.body.data.style.height =  params.bodyHeight;
	        }
	    }
	    if (restrictionsInt&CONSTANTES.WINDOW_SHOW_FOOTER !=  CONSTANTES.ZERO){
	        if (params.hideFooter == true){
	            wind.footer.data.style.display =  'none';
	        }
	    }
	}
	return wind;
}*/
function createWindow(tipo,modal,restricciones,params){
	var wind = new SiafPopupWindow();
	/*registrar listener de window*/
	if (params!=null){
	    if (params.closeListener != null)
	        wind.closeListener = params.closeListener;
	    
	}
	/*DESARROLLANDO*/
	wind.div = createTable('TableDistr');
	
	
	if (params != null){
	    if (params.width != null){
	        wind.div.style.width = params.width;
	    }
	}
	if (restricciones == null)
	    restricciones  = CONSTANTES.WINDOW_SHOW_HEADER|CONSTANTES.WINDOW_SHOW_BODY|CONSTANTES.WINDOW_SHOW_FOOTER;
	    
    var restrictionsInt = restricciones;
    
    if (modal){
        wind.showModal();
    }else{
        //
        wind.show();
    }
	wind.div.className = 'ModalFramecito'
	var rowIndex = 0;
	if (parseInt(restrictionsInt&CONSTANTES.WINDOW_SHOW_HEADER) !=  CONSTANTES.ZERO){
	    
	    wind.header = new Object();    
	    
	    wind.header.row = createRow(wind.div,rowIndex,'ModalHeader');
	    
	    
	    wind.header.row.style.height = '20px';
	    wind.header.cell = createCell(wind.header.row,0,'TableHeaderCell');
	    
	    wind.header.table = createTable('TableDistr');
	    wind.header.table.style.width = '100%';
	    var row1 = createRow(wind.header.table,rowIndex,'ModalHeader');
	    rowIndex++;
        
        wind.header.cell.appendChild(wind.header.table);
	    
	    wind.header.cellIcon = createCell(row1,0,'TableHeaderCell');
        wind.header.cellTitle = createCell(row1,1,'TableHeaderCell');
	    wind.header.cellCloseButton = createCell(row1,2,'TableHeaderCell');
	     
	    wind.header.cellIcon.style.width = '5%';
	    wind.header.cellIcon.style.height = '40px';
	    wind.header.cellIcon.style.backgroundImage = "url('../img/curva_izquierda_arriba_noticias.gif')";
	    wind.header.cellIcon.style.backgroundPosition = 'left top';
	    
	    wind.header.cellTitle.style.width = '90%';
	    wind.header.cellTitle.style.height = '40px';
	    wind.header.cellTitle.style.backgroundImage = "url('../img/fondo_final_tabla_noticias.gif')";
	    wind.header.cellTitle.style.backgroundPosition = 'top left';
	    
	    wind.header.cellCloseButton.style.width = '5%';
	    wind.header.cellCloseButton.style.height = '40px';
	    wind.header.cellCloseButton.style.backgroundImage = "url('../img/curva_derecha_arriba_noticias.gif')";
	    wind.header.cellCloseButton.style.backgroundPosition = 'right top';
	    
	     
	    var iconImg = createImage('../img/icon.gif')
	    iconImg.className = 'ModalIcon';
	    wind.header.titulo = createLabel('Ventana Ayuda SIAF');

        var cerrarImg = createImage('../img/cerrar.gif');
	    cerrarImg.className = 'ModalCloseIcon';
	    cerrarImg.style.styleFloat = 'right';
	    wind.cerrarImg = cerrarImg;
	    
	    wind.header.cellIcon.appendChild(iconImg);
	    wind.header.cellTitle.appendChild(wind.header.titulo);
	    wind.header.cellCloseButton.appendChild(cerrarImg);	    

        if (params != null && params.closeIconEnabled == true){
	        //cancelar con icono
	        addEvent(cerrarImg,'onclick',wind.close);
	    }else{
	        addEvent(cerrarImg,'onclick',wind.clickX);
	    }
	    /*
	    <tr style="height:40px;">
                <td style="width:25%;background-image:url('../img/curva_izquierda_arriba_noticias.gif');background-position:top left"></td>
                <td style="width:50%;background-image:url('../img/fondo_final_tabla_noticias.gif')"></td>
                <td style="width:25%;background-image:url('../img/curva_derecha_arriba_noticias.gif');background-position:right">
                    <img src="../img/cerrar.gif" alt="cerrar" onclick="maxiHorizontal('leftPanel','rightPanel')" onmouseover="document.body.style.cursor='pointer'" onmouseout="document.body.style.cursor='default'" style="float:right;margin-top:2px;margin-right:10px"/>
                 </td>
            </tr>
	    
	    */
	    /*wind.header.data = createDiv('ModalTitle');
	    wind.header.title = createDiv('ModalTextTitle');
	    
	    wind.header.closeButton = createDiv('ModalTitleClose');
	    
	    wind.header.title.appendChild(wind.header.titulo);

	   
	    
	    wind.header.iconImg = iconImg;
	    wind.header.data.appendChild(wind.header.iconImg);
	    wind.header.data.appendChild(wind.header.title);
	    
	    wind.div.appendChild(wind.header.data);*/
	    
	}
	if (parseInt(restrictionsInt&CONSTANTES.WINDOW_SHOW_BODY) !=  CONSTANTES.ZERO){
	    	    
	    
        wind.body = new Object();
        
	   /* wind.trBody = createRow(wind.table,wind.table.rows.length);
	    wind.body.data = createCell(wind.trBody,0,'ModalInfo');
	    wind.body.data.colSpan=3;*/
	    
	    if (WINDOW_TIPO.MENSAJES == tipo)
	    {
	        wind.body.row = createRow(wind.div,rowIndex,'ModalBody');
	        rowIndex++;
	        wind.body.div =  wind.body.row;
	        wind.body.cell = createCell(wind.body.row,0,'ModalBody');
	        
	        wind.body.data = wind.body.cell;
	        wind.body.table = createTable('ModalBody');
	        wind.body.table.style.width = '100%';
	        wind.body.table.style.border = 'none';
	        
	        
	        wind.body.cell.appendChild(wind.body.table);
	        
	        wind.body.tr1 = createRow(wind.body.table,0);
	        wind.body.tr2 = createRow(wind.body.table,1);
	        wind.body.tr3 = createRow(wind.body.table,2);
	        
	        wind.body.icon = createCell(wind.body.tr1,0,'MainModalIcon');
	        wind.body.icon.rowSpan = 3;
	        wind.body.icon.style.width = '150px';
	        
	        wind.body.titulo = createCell(wind.body.tr1,1,'MainModalTitle');
	        wind.body.titulo.style.width = 'auto';
	        
	        wind.body.descripcion = createCell(wind.body.tr2,0,'MainModalDescription');
	        wind.body.detalles = createCell(wind.body.tr3,0,'MainModalDetails');
	        
	        wind.body.imagen = createImage('../img/warn32.png');
	        
	        
	        wind.body.mensajeLbl = createLabel('');
	        wind.body.detallesLbl =  createLabel('');
	        
	        
	        wind.body.icon.appendChild(wind.body.imagen);
	        wind.body.descripcion.appendChild(wind.body.mensajeLbl);
	        wind.body.detalles.appendChild(wind.body.detallesLbl);
	        
	        
	        
	        
/*	        wind.body.data = wind.body.cell;
	        
	        wind.body.div.className =  'ModalInfo';
	        
	        wind.body.icon = createDiv('MainModalIcon');
	        wind.body.bodyInfo = createDiv('MainModalInfo');
	        
	        wind.body.titulo = createDiv('MainModalTitle');
	        wind.body.descripcion = createDiv('MainModalDescription');
	        wind.body.detalles = createDiv('MainModalDetails');
	        
	        wind.body.div.className =  'ModalInfo';
	        wind.body.imagen = createImage('../img/warn32.png');
	        
	       */
	        
	        //wind.body.data.appendChild(wind.body.imagen);
	        
	        //wind.body.mensajeLblDiv = createDiv();
	        //wind.body.detalles.className = 'ModalInfo';
	        //wind.body.mensajeLblDiv.appendChild(wind.body.mensajeLbl);
	        
	        
	    //    wind.body.detalles = createDiv();
	     //   wind.body.detalles.className = 'ModalInfoDetails';
	        
	        
	        /*wind.body.data.appendChild(wind.body.mensajeLblDiv);
	        wind.body.data.appendChild(wind.body.detallesLbl);
	        wind.body.data.appendChild(wind.body.detalles);*/
	         
	       /* wind.body.icon = createDiv('MainModalIcon');
	        wind.body.titulo = createDiv('MainModalTitle');
	        wind.body.descripcion = createDiv('MainModalDescription');
	        wind.body.detalles = createDiv('MainModalDetails');
	        
	        
	        wind.body.data.appendChild(wind.body.icon);
	        wind.body.data.appendChild(wind.body.bodyInfo);
	        
	        wind.body.bodyInfo.appendChild(wind.body.titulo);
	        wind.body.bodyInfo.appendChild(wind.body.descripcion);
	        wind.body.bodyInfo.appendChild(wind.body.detalles);
	        
	        wind.body.icon.appendChild(wind.body.imagen);
	        
	        wind.body.titulo.appendChild(wind.body.mensajeLbl);
	        wind.body.descripcion.appendChild(wind.body.mensajeLbl);
	        wind.body.detalles.appendChild(wind.body.detallesLbl);*/
	        
	        //wind.body.detalles.appendChild(createLabel('Vamos Vamos!'));
	        
	        
	        
		/*  wind.body.div =  createDiv();
		    wind.body.data = wind.body.div;
		    wind.body.div.className =  'ModalInfo';

		    wind.body.imagen = createImage('../img/warn32.png');
		    wind.body.mensaje =  createDiv();
		    
		    wind.body.detalles =  createDiv();
		    wind.body.detalles.className = 'ModalInfoDetails';
    		
		    
    		
		    //wind.body.data.appendChild(wind.body.div);
		    wind.body.div.appendChild(wind.body.imagen);

		    wind.body.div.appendChild(wind.body.mensaje);
		    wind.body.div.appendChild(wind.body.detalles);

		    wind.body.mensaje.appendChild(wind.body.mensajeLbl);
		    wind.body.detalles.appendChild(wind.body.detallesLbl);
		    
		    wind.div.appendChild(wind.body.data);*/
		    
	    }else{
	        wind.body.row = createRow(wind.div,rowIndex,'ModalBody');
	        rowIndex++;
            wind.body.cell = createCell(wind.body.row,0,'TableBodyCell');
	        wind.body.cell.style.height = '300px';
	        wind.body.data = wind.body.cell;
	        wind.body.div = wind.body.cell;
	        wind.body.div.className =  'ModalInfo';
	       
	        wind.body.detalles = createDiv();
	        wind.body.detalles.className = 'ModalInfoDetails';
	        
	        
	        wind.body.data.appendChild(wind.body.detalles);
	        
	        //wind.x.y = 0;
	        
	       /* wind.body.data =  createDiv('ModalBody');
	        wind.body.div = wind.body.data;
	        wind.div.appendChild(wind.body.data);*/
	    }
	}
	if (parseInt(restrictionsInt&CONSTANTES.WINDOW_SHOW_FOOTER) != CONSTANTES.ZERO){
	    
	    wind.footer = new Object();
	    wind.footer.row = createRow(wind.div,rowIndex,'ModalFooter');
	    rowIndex++;
	    wind.footer.cell = createCell(wind.footer.row,0,'TableCellHeader');
	    
	    wind.botonera = createDiv('ModalBotonera');
	    
	    wind.footer.cell.appendChild(wind.botonera);
	    wind.footer.data = wind.botonera;
	    
	    /*wind.footer.data = createDiv('ModalBotonera');
	    wind.div.appendChild(wind.footer.data);*/
	}
	if (params != null){
	    if (params.width != null){
	        wind.div.style.width =  params.width;
	    }
	    if (params.height != null){
	        wind.div.style.height =  params.height;
	    }
	    
	    if (restrictionsInt&CONSTANTES.WINDOW_SHOW_HEADER !=  CONSTANTES.ZERO){
	        if (params.title != null){
	            wind.header.titulo.innerHTML = params.title;
	        }
	    }
	    if (restrictionsInt&CONSTANTES.WINDOW_SHOW_BODY !=  CONSTANTES.ZERO){
	        if (params.bodyHeight != null){
	            wind.body.data.style.height =  params.bodyHeight;
	        }
	    }
	    if (restrictionsInt&CONSTANTES.WINDOW_SHOW_FOOTER !=  CONSTANTES.ZERO){
	        if (params.hideFooter == true){
	            wind.footer.data.style.display =  'none';
	        }
	    }
	}
	return wind;
}
    
function esconderTapaModalDiv(param0){
	getBody().removeChild(param0);
	esconderTapaModal()
}
//Iconos
function appendIcon(parent,title,image,purl){
	try{
	    var icon = new SiafIcon();
	    icon.append(parent,title,image,purl);
	}catch(ex){
		throw ex;
	}
}
SiafIcon.prototype.url = null;

function SiafIcon(me){
    me = this;
    this.append = function(parent,title,image,purl){
        try{
            var div = createDiv();	
		    parent.appendChild(div);
		    me.url = purl;

		    var div2 = createDiv();
		    var imageIcon = createImage(image);
		    var link = createLink(title);
		    div.className = 'thumbnail';
		    

		    div.appendChild(div2)
		    div2.appendChild(imageIcon)
		    div.appendChild(link)
		    
		    addEvent(link,'onclick',this.openUrl);
		    addEvent(imageIcon,'onclick',this.openUrl);
		    
		    
        }catch(ex){
            throw ex;
        }
    }
    this.openUrl = function(event){
	    document.location.href=me.url;
	};
}


function loadNode(node){
	var obj = new Object();
	if (node == null){
		return obj;
	}

	for (i=0; i<node.childNodes.length;i++){

		var child = node.childNodes[i];
		obj[child.nodeName] = child;

		if (child.firstChild != null)
		{
			if (child.firstChild.nodeType == 3)
				obj[child.nodeName] = child.firstChild.nodeValue;
		}
		
	}
	return obj;
}
function loadXMLString(txt) 
{
	var xmlDoc;
	if (window.DOMParser)
	  {
	  parser=new DOMParser();
	  xmlDoc=parser.parseFromString(txt,"text/xml");
	  }
	else // Internet Explorer
	  {

		try{
		  xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
		  xmlDoc.async="false";
  		  xmlDoc.loadXML(txt); 		
		}catch(ex){
 		 	  throw ex;
		}


	  }

	return xmlDoc;
}
function getChildNodes(element){
	/*function getNextSibling(startBrother){
	  endBrother=startBrother.nextSibling;
	  while(endBrother.nodeType!=1){
		endBrother = endBrother.nextSibling;
	  }
	  return endBrother;
	} */

	var array = new Array();
	if (element == null)
	{
		return array;
	}
	var list = element.childNodes;

	for (var i=0;i<list.length ;i++ ){
		if (list[i].nodeType == 1)//element type
		{
			array[array.length] = list[i];
		}
	}

	return array;
}
function getNextSibling(startBrother){

  var endBrother=startBrother.nextSibling;
  if (endBrother == null)
  {
	  return null;
  }
  while(endBrother.nodeType!=1){
    endBrother = endBrother.nextSibling;
  }
  return endBrother;
}
function firstChild(node){

  var child = node.firstChild;
  if (child == null)
  {
	  return null;
  }
  while(child.nodeType!=1){
    child = child.nextSibling;
  }
  return child;
}
function getY( oElement )
{
	var iReturnValue = 0;
	while( oElement != null ) {
		iReturnValue += oElement.offsetTop;
		oElement = oElement.offsetParent;
	}
	return iReturnValue;
}
function getX( oElement )
{
	var iReturnValue = 0;
	while( oElement != null ) {
		iReturnValue += oElement.offsetLeft;
		oElement = oElement.offsetParent;
	}
	return iReturnValue;
}
function getHeight(oElement){
    if (oElement == null)
        return 0;
        
	return oElement.offsetHeight;
}
function getWidth(oElement){
    if (oElement == null)
        return 0;
        
	return oElement.offsetWidth;
}
/*Asociacion de Combos*/
function asociarTextCombo(linkId,comboId){
    try{
    var lnk = findElement(linkId);
	var combo = findElement(comboId);
	
	
	var textCombo = new TextCombo(lnk,combo);
    
    addEvent(lnk,'onclick',textCombo.mostrarCombo);
    addEvent(combo,'onchange',textCombo.cambiarCombo);
    addEvent(combo,'onblur',textCombo.perderCombo);
	    
    if (combo.selectedIndex >= 0)
        lnk.innerHTML = '['+ combo.options[combo.selectedIndex].innerHTML +']';
        
    return textCombo;
    }catch(ex){
        throw ex;
    }
}
function TextCombo(param0,param1,param2){
	
	this.mostrarCombo =  function(event){
		param1.style.display = 'inline';
		param0.style.display = 'none';
		param1.focus();
	};
	this.cambiarCombo =  function(event){
		param0.style.display = 'inline';
		param0.innerHTML = '['+ param1.options[param1.selectedIndex].innerHTML +']'
		param1.style.display = 'none';
	};
	this.perderCombo =  function(event){
		param0.style.display = 'inline';
		param1.style.display = 'none';
	};
}
/*
function  modificarEjercicio(lnk){
	lnk.style.display = 'none';
	document.getElementById('select_ejercicio').style.display = 'inline'

}
*/

function asociarCombo(comboId,textId){
    
    this.callback = function(event){

	    var combo = document.getElementById(comboId);
	    var text = document.getElementById(textId);
	    var verror = false;
	    if (combo == null){
	        verror = true;
	    }
	    if (text == null){
	        verror = true;
	    }
	    if (verror == true){
	        logMessage('Asociar combo error Combo o Text no se encotraron');
	        return false;
	    }
	    try{
	        var encontrado = 0;
	        var valueNull = 0;
	        
	        for (var i=0;i<combo.options.length;i++){
                if (combo.options[i].value == text.value){
                    combo.selectedIndex = i;
                    encontrado = 1;
                }
                else if (combo.options[i].value == '0'){
                    valueNull = i;
                }
                
	        }
	        //primer elemento si no concuerda con nada
	        if (encontrado == 0){
	            
	            combo.selectedIndex = valueNull;
	        }
	            
	            
	        
	        addEvent(combo,'onchange',new asociarCombo(comboId,textId).changeValue);
	        addEvent(text,'onchange',new asociarCombo(comboId,textId).changeValue2);
	        
	        combo.disabled = text.disabled;
	    }catch(ex){
	        alert(ex);
	        /*if (combo == null)
	            //alert('No se encontro Combo con ID '+comboId)
	        if (text == null)
	            //alert('No se encontro TextBox con ID '+textId)
	           */
	    }
	};
	this.changeValue = function(event){
	    var combo = document.getElementById(comboId);
	    var text = document.getElementById(textId);
	    text.value = combo.options[combo.selectedIndex].value;
	};
	
	this.changeValue2 = function(event){
	    var combo = document.getElementById(comboId);
	    var text = document.getElementById(textId);
	     try{
	     
	        var encontrado = 0;
	        var valueNull = 0;
	        
	        for (var i=0;i<combo.options.length;i++){
                if (combo.options[i].value == text.value){
                    combo.selectedIndex = i;
                    encontrado = 1;
                }
                else if (combo.options[i].value == '0'){
                    valueNull = i;
                }
                
	        }
	        //primer elemento si no concuerda con nada
	        if (encontrado == 0){
	            combo.selectedIndex = valueNull;
	        }else{
	         
	        }
	            
	            
	            
	    }catch(ex){
	        throw ex;
	    }
	};
}
/*html util*/
function findElement(childId,parent){
	if (parent == null)
	{
		return document.getElementById(childId);
	}
}
/*funciones util*/
function callback(listener,param){
    this.call =  function(evt){
		listener(param,evt);
	};
}

/*string util*/
var StringUtil = new Object();

/*
valida si dentro de un string existe una palabra (uppercase = true para que no sea sensible a mayuscula)
*/
StringUtil.intoString = function(text,substr,upperCase,accent){
    var ct = substr;
    var text2 = text;
    if (upperCase == true){
        ct = substr.toUpperCase();
        text2 = text.toUpperCase();
    }
    if (accent == true){
        ct = StringUtil.quitarAcentos(ct);
        text2 = StringUtil.quitarAcentos(text2);
    }
    return text2.match('.*'+ct+'.*')!=null;
};
/*
devuelve la posicino donde empieza un substring dado
last(int) =  desde donde buscar
*/
StringUtil.quitarAcentos = function(text){
    try{
        var r=text;
        r = r.replace(new RegExp("[àáâãäå]", 'g'),"a");
        r = r.replace(new RegExp("æ", 'g'),"ae");
        r = r.replace(new RegExp("ç", 'g'),"c");
        r = r.replace(new RegExp("[èéêë]", 'g'),"e");
        r = r.replace(new RegExp("[ìíîï]", 'g'),"i");
        r = r.replace(new RegExp("ñ", 'g'),"n");                            
        r = r.replace(new RegExp("[òóôõö]", 'g'),"o");
        r = r.replace(new RegExp("œ", 'g'),"oe");
        r = r.replace(new RegExp("[ùúûü]", 'g'),"u");
        r = r.replace(new RegExp("[ýÿ]", 'g'),"y");
        //upper case
        r = r.replace(new RegExp("[àáâãäå]".toUpperCase(), 'g'),"a".toUpperCase());
        r = r.replace(new RegExp("æ".toUpperCase(), 'g'),"ae".toUpperCase());
        r = r.replace(new RegExp("ç".toUpperCase(), 'g'),"c".toUpperCase());
        r = r.replace(new RegExp("[èéêë]".toUpperCase(), 'g'),"e".toUpperCase());
        r = r.replace(new RegExp("[ìíîï]".toUpperCase(), 'g'),"i".toUpperCase());
        r = r.replace(new RegExp("ñ".toUpperCase(), 'g'),"n".toUpperCase());                            
        r = r.replace(new RegExp("[òóôõö]".toUpperCase(), 'g'),"o".toUpperCase());
        r = r.replace(new RegExp("œ".toUpperCase(), 'g'),"oe".toUpperCase());
        r = r.replace(new RegExp("[ùúûü]".toUpperCase(), 'g'),"u".toUpperCase());
        r = r.replace(new RegExp("[ýÿ]".toUpperCase(), 'g'),"y".toUpperCase());
        
        return r;
    }catch(ex){
        //no se pudo quitar los acentos
        return text;
    }
    
};
StringUtil.indexSubString = function(text,substr,upperCase,accent,last){
	if (text.length > substr.length)
	{
	    var from = 0;
		var size = substr.length;
		var to = text.length-size;
		var i = 0;
		var from = 0;
		if (last != null)
		{
			from = last;
		}
		for (i=from;i<=to;i++)
		{
			var match = text.substr(i,size);
			var substrTemp = substr;
			if (accent == true){
			    match = StringUtil.quitarAcentos(match);
			    substrTemp = StringUtil.quitarAcentos(substrTemp);
			}
			if (substrTemp.toUpperCase() == match.toUpperCase())
			{
				var result = new Object();
				result.index = i;
				result.to = i+size;
				result.size = size;
				return result;
			}
		}
	}
	return null;
};
/*
las palabras *param* se aplicaran un estilo dado
*/
function insertarEstiloEnTexto(value,param,cssClass){
    try{
        if (param == null || param == ''){
            return value;
        }
        var obj = value;
	    var indexInfo = StringUtil.indexSubString(obj,param,true,true,0);
    	
	    while (indexInfo != null)
	    {
	        
            var result = null;
            if (cssClass != null){
                result = insertCssClass(obj,cssClass,indexInfo.index,indexInfo.to);
            }else{
                result = insertTag(obj,'b',indexInfo.index,indexInfo.to);
            }
		    obj = result.text;
		    indexInfo = StringUtil.indexSubString(obj,param,true,true,result.length);
	    }
	    return obj;
    }catch(ex){
        logError(ex);
        return value;
    }
}
/*
las palabras *param* se aplicaran un tag dado ejem (B para que esten en negrita)
*/
function insertTag(str,tag,p,q){
	var result = new Object();
	var text1 = str.substr(0,p);
	var text2 = str.substr(p,q-p);
	var text3 = str.substr(q,100);

	result.text =text1 + '<'+tag+'>' + text2 + '</'+tag+'>'+text3; 
	result.text1 = text1 + '<'+tag+'>' + text2 + '</'+tag+'>';
	result.length = result.text1.length;
	
	return result;
}
/*
se inserta un css class en un string en la posicion p hasta la q
*/
function insertCssClass(str,css,p,q){
	var result = new Object();
	var text1 = str.substr(0,p);
	var text2 = str.substr(p,q-p);
	var text3 = str.substr(q,100);
	var textCss1 = '<span class=\"'+css+'\">'
	var textCss2 = '</span>';

	result.text = text1 + textCss1 + text2 + textCss2 +text3; 
	result.text1 = text1 + textCss1 + text2 + textCss2; 
	result.length = result.text1.length;

	return result;
}
var SiafUtil = new Object();
SiafUtil.nvl = function(def,str1,str2,str3){
    try{
        if (str1 != null)
            return str1;
        if (str2 != null)
            return str2;
        if (str3 != null)
            return str3;
    }catch(ex){
    
    }
    return def;
}

var SiafWindowUtil = new Object();
/*
centrar un div en la posicion dada
*/
SiafWindowUtil.centrarDiv = function(myDiv){
    try{
		    var W = document.body.clientWidth;
		    var H = document.body.clientHeight;

		    myDiv.style.display = 'block';    

		    var IpopTop = (H - myDiv.offsetHeight)/2;
		    var IpopLeft = (W - myDiv.offsetWidth)/2;

		    myDiv.style.left=parseInt(IpopLeft)+'';
   	        myDiv.style.top=parseInt(IpopTop)+'';
       	    
		    myDiv.style.left=parseInt(IpopLeft)+'px';
   	        myDiv.style.top=parseInt(IpopTop)+'px';
       	    
	    }catch(ex){
		    throw ex;
	    }
    };
SiafWindowUtil.getPageSizeWithScroll =function(){
	var result =  null;
	try{
	    result = new Object;
		result.width = getDocWidth();
		result.height = getDocHeight();
		return result;
	}
	catch(ex){
		throw ex;
	}
	return result;
}   
SiafMiniMaxi.prototype.link = null;
SiafMiniMaxi.prototype.menuRightId = null;
SiafMiniMaxi.prototype.menu = null;
SiafMiniMaxi.prototype.header = null;
SiafMiniMaxi.prototype.body = null;
SiafMiniMaxi.prototype.height = null;

function SiafMiniMaxi(me){
    me = this;
    
    this.select = function(link,menuRightId,menuId,headerId,bodyId){
        me.link = link;
        me.header = findElement(headerId);
        me.menu = findElement(menuId);
        me.body = findElement(bodyId);
        
        if (me.body == null){
            alert('BODY ES NULL'+bodyId);
            return;
        }
        if (me.link.innerHTML == CONSTANTES.MENSAJES.NO_FULL_SCREEN){
            /*mostrar*/
            me.body.style.height = me.height;
            me.link.innerHTML = CONSTANTES.MENSAJES.FULL_SCREEN;
            me.header.style.display = 'block';
            me.menu.style.display = 'block';
        }else{/*ocultar*/
            var wh = SiafWindowUtil.getPageSizeWithScroll();
            var oldHeight = getHeight(me.header);
            me.height =  me.body.style.height;
            
            me.link.innerHTML = CONSTANTES.MENSAJES.NO_FULL_SCREEN
            me.header.style.display = 'none';
            me.menu.style.display = 'none';
            me.body.style.height = (wh.height-oldHeight)+'px';
            
        }  
    };
}
var miniMaxi = new SiafMiniMaxi();

if (iframe == true){
    if (window.parent.miniMaxi != null)
        miniMaxi = window.parent.miniMaxi;
    else
        miniMaxi = window.parent.parent.miniMaxi;
}

function getMinimaxi(){
    return miniMaxi;
}
function maxiHorizontal(divId1,divId2){
    
    var div1 = findElement(divId1);
    var div2 = findElement(divId2);

    div1.style.display = 'none';
    div2.style.width = '100%';
    
}
function showPanel(divId1,divId2,size1,size2){
    var div1 = findElement(divId1);
    var div2 = findElement(divId2);
    if (div1.style.display != 'block'){
        div1.style.display = 'block';
        div2.style.display = 'block';
        
        div1.style.width = size1;
        div2.style.width = size2;
    }else{
        div1.style.display = 'none';
        div2.style.display = 'block';
        div2.style.width = '100%';
    }
}
    

/*
to deprecated
*/
/*centra div by id*/
function centrar(divid){
	centrarDiv(findElement(divid));
}
function centrarDiv(myDiv){
	try{
		var W = document.body.clientWidth;
		var H = document.body.clientHeight;

		myDiv.style.display = 'block';    

		var IpopTop = (H - myDiv.offsetHeight)/2;
		var IpopLeft = (W - myDiv.offsetWidth)/2;

		myDiv.style.left=parseInt(IpopLeft)+'';
   	    myDiv.style.top=parseInt(IpopTop)+'';
   	    
		myDiv.style.left=parseInt(IpopLeft)+'px';
   	    myDiv.style.top=parseInt(IpopTop)+'px';
   	    
	}catch(ex){
		alert('Error en Centrar -> '+ex);
	}
}
function mostrarTapaModal(){
	var WH = getPageSizeWithScroll();
    var W = WH[0];
	var H = WH[1];
	
	/*var tapa1 = document.getElementById(CONSTANTES.div_ajax_tapa1);
	var tapa2 = document.getElementById(CONSTANTES.div_ajax_tapa2);*/
	
    try{
		if (modalTapa1 == null){
			var WH = getPageSizeWithScroll();
			var W = WH[0];
			var H = WH[1];

			modalTapa1 = createDiv();
			modalTapa2 = createDiv();

			getBody().appendChild(modalTapa1);
			getBody().appendChild(modalTapa2);
			
			modalTapa1.className = CONSTANTES.STYLES.MODAL_TAPA1;
			modalTapa2.className = CONSTANTES.STYLES.MODAL_TAPA2;
			
			modalTapa1.style.top = '0px';
			modalTapa2.style.left = '0px';

			modalTapa1.style.height = H+'px';
			modalTapa1.style.width = W+'px';
			
			modalTapa2.style.height = H+'px';
			modalTapa2.style.width = W+'px';
			
			modalTapa1.style.display = 'block';
			modalTapa2.style.display = 'block';
		}
    }catch(ex){
        alert(ex);
    }
}
function esconderTapaModal(){
    try{
        if (modalTapa1 != null){
            getBody().removeChild(modalTapa1);
            getBody().removeChild(modalTapa2);
        }
        modalTapa1 = null;
    }catch(ex){
        alert(ex);
    }
	
}
function getDocHeight() {
    var D = document;
    return Math.max(
        Math.max(D.body.scrollHeight, D.documentElement.scrollHeight),
        Math.max(D.body.offsetHeight, D.documentElement.offsetHeight),
        Math.max(D.body.clientHeight, D.documentElement.clientHeight)
    );
}
function getDocWidth() {
    var D = document;
    return Math.max(
        Math.max(D.body.scrollWidth, D.documentElement.scrollWidth),
        Math.max(D.body.offsetWidth, D.documentElement.offsetWidth),
        Math.max(D.body.clientWidth, D.documentElement.clientWidth)
    );
}
function getPageSizeWithScroll(){
	var arrayPageSizeWithScroll = new Array(100,100);
	
	try{
		var xWithScroll = getDocWidth();
		var yWithScroll = getDocHeight();

		arrayPageSizeWithScroll = new Array(xWithScroll,yWithScroll);

		return arrayPageSizeWithScroll;
	}
	catch(ex){
		alert(ex.message);
	}

	
	return arrayPageSizeWithScroll;
}
/**END, TO DEPRECATED*/

/*registrar ONLOAD*/
//registrar onload
function configureOnLoad(){
    addBodyOnLoad(initPage)
}
function addBodyOnLoad(handler){
    addEvent(window,'onload',handler)
}
function alertSize() {
  var myWidth = 0, myHeight = 0;
  if( typeof( window.innerWidth ) == 'number' ) {
    //Non-IE
    myWidth = window.innerWidth;
    myHeight = window.innerHeight;
  } else if( document.documentElement && ( document.documentElement.clientWidth || document.documentElement.clientHeight ) ) {
    //IE 6+ in 'standards compliant mode'
    myWidth = document.documentElement.clientWidth;
    myHeight = document.documentElement.clientHeight;
  } else if( document.body && ( document.body.clientWidth || document.body.clientHeight ) ) {
    //IE 4 compatible
    myWidth = document.body.clientWidth;
    myHeight = document.body.clientHeight;
  }
  var obj = new Object();
  obj.height = myHeight;
  obj.width = myWidth;
  return obj;
}
function JRAjax(url,me){
    me = this;
    me.url = url;
    this.send = function(callback){
        me.callback = callback
	    me.xmlhttp = null;
	    var browser = '';
	    
	    if (window.XMLHttpRequest)
  	    {
		    me.xmlhttp=new XMLHttpRequest()
	    }
	    // code for IE
	    else if (window.ActiveXObject)
  	    {
	      me.xmlhttp=new ActiveXObject("Microsoft.XMLHTTP")
  	    }
        return me.loadXMLDoc();
    }
    this.stateChange = function(){
        if (me.xmlhttp.readyState==4)
		{
			  if (me.xmlhttp.status==200){
			        try{
			            var xmlDoc = me.xmlhttp.responseXML;
			            var values = xmlDoc.getElementsByTagName("documento")[0];
			            
			            me.callback(values);
			        }catch(ex){
			            alert('error->'+ex.message);
			        }
			        
				    //var value = xmlDoc.getElementsByTagName("documento")[0];
			        //me.callback(me.xmlhttp.responseXML);	    
			        
			  }
	    }
    }
    this.loadXMLDoc = function()
    {
	    if (me.xmlhttp!=null)
  	    {
  	        var xmlhttp = me.xmlhttp;
		    xmlhttp.onreadystatechange= me.stateChange
		    xmlhttp.open("POST",me.url,true)
		    xmlhttp.setRequestHeader('Content-Type','application/x-www-form-urlencoded; charset=ISO-8859-15');
 		    xmlhttp.send(null);
 		    return true;
	     }
	     else
  		 {
		      alert("Your browser does not support XMLHTTP.")
         }
        return false;
    }
}
function SFDispatchEvent(element,eventName){
    if (document.createEventObject){
        // dispatch for IE
        var evt = document.createEventObject();
        return element.fireEvent('on'+eventName)
    }
    else{
        // dispatch for firefox + others
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent(eventName, true, true ); // event type,bubbling,cancelable
        return !element.dispatchEvent(evt);
    }
}
configureOnLoad();
alert('javascript version: '+global2_version);