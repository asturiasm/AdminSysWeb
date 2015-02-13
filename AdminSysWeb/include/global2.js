

var global2_version = '2.22';



var CONSTANTES = new Object();


CONSTANTES.ICON_WARN = '../img/warning.png';
CONSTANTES.ICON_INFO = '../img/info32.png';
CONSTANTES.ICON_ERR = '../img/error32.jpg';
CONSTANTES.ICON_PROGRESS_BAR = '../img/progressbar.gif'


CONSTANTES.LBL_MENSAJE_ESPERA = '#LBL_MENSAJE_ESPERA'
CONSTANTES.INPUT_MENSAJE_ESPERA = '#INPUT_MENSAJE_ESPERA'
CONSTANTES.MODAL_INPUT_MENSAJE = '#MODAL_INPUT_MENSAJE'
CONSTANTES.INPUT_MODAL_TIPO = '#INPUT_MODAL_TIPO'
CONSTANTES.INPUT_MODAL_NIVEL = '#INPUT_MODAL_NIVEL'
CONSTANTES.INPUT_MODAL_CONFIRMAR = '#INPUT_MODAL_CONFIRMAR'
CONSTANTES.INPUT_MODAL_CONFIRMACION_ID = '#INPUT_MODAL_CONFIRMACION_ID'
CONSTANTES.BUTTON_MODAL_CONFIRMAR = '#BUTTON_MODAL_CONFIRMAR'
CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES = '#MODAL_INPUT_MENSAJE_DETALLES'
CONSTANTES.MODAL_LABEL_MENSAJE = '#MODAL_LABEL_MENSAJE'
CONSTANTES.INPUT_MODAL_PROGRESSBAR_KEY = '#INPUT_MODAL_PROGRESSBAR_KEY';
CONSTANTES.MODAL_ERROR_DIV = '#MODAL_ERROR_DIV';
CONSTANTES.MODAL_ERROR_LINK_DIV = '#MODAL_ERROR_LINK_DIV';


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
var siafAttributes = new Array();
function Salir(){
    if (iframe==true)
        parent.location.href = '../login/frmlogout.aspx';
    else
        location.href = '../login/frmlogout.aspx';
}
function gotoDummy(){
    location.href = '../CLA/dummycla.aspx';
}

// JScript File
// JScript File
var iframe = false;

if (parent.alert != null){
    iframe = true;
}

function addInitListener(callback){
    initListeners.push(callback);
}

function setShowVersion(){
     $('#SIAF_LOGO').click(function(){
        alert("Global2.js version: "+global2_version);
     });
}
var calendario = new Object();

	calendario.show = function(param){
    // document.Form1.FECHA_INICIO_CONTRATO
    
	if ($(param).prop('disabled') == false){
        $(param).datepicker({
                    changeMonth: true,
			        changeYear: true,
			        showOn: 'none'
		        });
		        
        $(param).datepicker('show');
    }else{
        // alert($(param).prop('disabled'));
    }
    
    		        
}
function applyPatch(parent){
	jQuery('table',parent).each(
            function(){
                if (jQuery(this).hasClass('DetallePrincipal') == true){
                    jQuery(this).removeClass('DetallePrincipal');
                    jQuery(this).addClass('DataGridMant');
                }else{
                    
                }
            }
        );
        
        jQuery('.NumberFormat',parent).each(
        		function(){
        			jQuery(this).SiafNumericFormat();
        		}
        );
        	
        jQuery('.DatePicker',parent).each(
                function(){
                    // var vimg = $('<img src="../img/calendario/calendar.gif"
    				// width="16" height="16"></img>');
                    var a = $(this).val();
                    
                    $(this).datepicker({
    			        showOn: "button",
    			        buttonImage: "../img/calendario/calendar.gif",
    			        buttonImageOnly: true,
                        changeMonth: true,
    			        changeYear: true,
    			        dateFormat: 'dd/mm/yy',
    			        beforeShow: function(input, inst) {
    			        	if ($(this).prop('disabled')){
    			        		$(this).datepicker('disable');
    			        		$(this).datepicker('close');
    			        	}
    			        }
                    
    		        });
                    /*disabled if disabled*/
                    if ($(this).prop('disabled')){
		        		$(this).datepicker('disable');
		        	}

                    //$(this).datepicker( "option", "dateFormat",  );
    		        
    		        $(this).val(a);
                    
                }
        );
        
        $('.MinfinBtn',parent).button();
}
function ObtenerEjercicio(){
	return Number(jQuery('#LISTA_EJERCICIOS').val());
}
function initPage(){
    try{
    	
    	/*
		 * PATCH
		 */
        applyPatch(null)
        
        
         /*
			 * startPage es un metodo que puede definirse en la pagina, y en
			 * este momento va ser llamado
			 */
        if (startPage != null) {
                startPage();
        }
        // global2 version
        setShowVersion();
        
            
    }catch(ex){

    }
    try{
        // DoClock();
        /* al cargar muestra popup a partir los campos */
        
        mostrarPopup();
    }catch(ex){
        throw ex;
    }

}
/* al iniciar la página se fija en algunos inputs para mostrar advertencias */
function mostrarPopup(params){
        try{
            if (params == null)
                params = new Object();
                
            var titulo = 'Panel de Información SIGES';
            
    		    
		    var mensaje = $(CONSTANTES.MODAL_INPUT_MENSAJE).val();
		    
		    /* si no existe mensaje, no se muestra nada */
		    if (mensaje == null || mensaje == '')
		        return;
            
            
		    var descripcion = $(CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES).val();
		    var detalle = $(CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES).val();
		    var botonera = parseInt($(CONSTANTES.INPUT_MODAL_TIPO).val());
		    var nivel = $(CONSTANTES.INPUT_MODAL_NIVEL).val();
		    // var modalErrorDiv = $(CONSTANTES.MODAL_ERROR_DIV).val();
		    var asincronoKey = $(CONSTANTES.INPUT_MODAL_PROGRESSBAR_KEY).val();
		    
		    var detalleInfo = $(CONSTANTES.MODAL_ERROR_DIV).html();
		    var detalleLink = $(CONSTANTES.MODAL_ERROR_LINK_DIV).html();
            
            // asincrono Key
            
            params.asincronoKey = asincronoKey;
                
		    /* asignar confirmacion */
		    
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CONFIRMAR) != CONSTANTES.ZERO){
		    
		        if (params.confirmacionListener == null){
		            /*
					 * CONSTANTES.INPUT_MODAL_CONFIRMACION_ID =
					 * 'INPUT_MODAL_CONFIRMACION_ID'
					 * CONSTANTES.BUTTON_MODAL_CONFIRMAR =
					 * 'BUTTON_MODAL_CONFIRMAR'
					 */
		            var hiddenInput = $(CONSTANTES.INPUT_MODAL_CONFIRMACION_ID).val();
		            var BtnInput = $(CONSTANTES.BUTTON_MODAL_CONFIRMAR).val();
                    
                    		            
		            var confirmacion = new ManejadorConfirmacion(hiddenInput,BtnInput);
		            
		            // hiddenInput.value = 'false';
		            $('#'+hiddenInput).val('false');
		            params.confirmacionListener = confirmacion.confirmar;
		        }
		    }
		    
            $(CONSTANTES.MODAL_INPUT_MENSAJE).val('')
		    $(CONSTANTES.MODAL_INPUT_MENSAJE_DETALLES).val('');
    		
		    params.detalleInfo = detalleInfo;
		    params.ejecutarScript = ejecutarScript;
		    params.link = detalleLink;
        
		    mostrarGenericPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params)
        }catch(ex){
            // alert('error al mostrar Popup'+ex.message+' - ' + ex.name + '
			// ('+ex.line+')');
            throw ex;
        }
}
function ejecutarScript(miScript){
    eval(miScript);
}


var modalTapa1 = null;
var modalTapa2 = null;


function getMouseClickPosition(evt){
    var object = new Object();
    if (window.ActiveXObject){ // ie
	    // element.attachEvent(eventName,handler);
	    object.x = window.event.clientX;
	    object.y = window.event.clientY;
    }else{
	    object.x = evt.pageX;
	    object.y = evt.pageY;
    }
    return object;
}
/*
 * Si el input Hidden del campo con ID 'NMF_INPUT_MENSAJE_ESPERA' tiene valor se
 * muestra el mensaje, Si Hay
 */
 // registrar evento a elemento
function addEvent(element,eventName,handler,param,mousePointer){
	try{
	    if (window.ActiveXObject){ // ie
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

// nuevo modal



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
        // addEvent(button,'onclick',me.select);
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
/* function para registrar confirmacino a un boton */
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
		    /*
			 * confirmar.value = 'false'; btn.onclick = btn.onclickOld; if
			 * (btn.onclick != null) btn.click(); btn.onclick = null;
			 */
		    /*
			 * var btnClone = createButton('clon');
			 * addEvent(btnClone,'onclick',btn.onclickOld);
			 * getBody().appendChild(btnClone); return btnClone.click();
			 */
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
/* SOBREESCRIBE EL ALERT DEL BROWSER */
alertOld = alert
var onAlert = false; 

var alertManager = new Object();

alertManager.queue = new Array();

alertManager.show = function(msg,listener,buttons){
    /* obj show */
    var obj = new Object();
    /* setting message */
    obj.message = msg;
    
    /* add listener */       
    if (listener == null)
        listener = new Object();
    
    /* dialog buttons */
    obj.buttons = buttons;
            
    obj.listener = listener;
    
    /* enquee obj */
    alertManager.queue.push(obj)
    
    /* call next */
    alertManager.next();
}
// se acepto el anterior y se muestra el actual

alertManager.accept = function(){
    alertManager.div.dialog('close');
}

alertManager.afterClose = function(){
    
    alertManager.queue.shift();
    alertManager.div.dialog('destroy');
    alertManager.div = null;
    alertManager.close = true;
    alertManager.next();
    
}
// mostrar siguiente alert
alertManager.div = null;
alertManager.close = true;
alertManager.count = 0;

alertManager.next = function(){
    
    if (alertManager.close == true && alertManager.queue.length>0){
        
        alertManager.close = false;
        
        var obj = alertManager.queue[0];
        
        // warning.png
        alertManager.div = $('<div title=\'SIAF'+'\'><div style="float:left;padding:7px;"><img src="'+CONSTANTES.ICON_WARN+'"></img></div><div style="text-align:center"><h3>Alerta</h3></div><div class="alert_content" style="margin-top:5px"></div></div>');
        
        $('.alert_content',alertManager.div).append('<p>'+obj.message + '</p>');
        
        var div = alertManager.div;
        
        var moreButtons = {};
        
        if (obj.buttons!=null){
            moreButtons = obj.buttons;
        }
        
        moreButtons.Aceptar = function(){
            /*
			 * 
			 */
            if (obj != null && obj.listener != null){
                try{
                    obj.listener();
                }catch(ex){
                }
            }
            alertManager.accept()
        };
        
        // moreButtons.div = div;
        
        
        alertManager.div.dialog(
            {
                modal: true,
                width:400,
                height:300,
                buttons:moreButtons,
                
                close:function(){
                    alertManager.afterClose()
                }
            }
        );
        
       // var listener = new Object();
       // listener.aceptar = alertManager.accept;
            
       // var dialog = new SiafDialog(listener);
        
            
        
            
        // dialog.showInfo("Alerta" + alertManager.cursor,"Alerta",obj.message);

    }
}
function alert(msg,listener,buttons){
    alertManager.show(msg,listener,buttons);
}

if (parent.alert != null) alert = parent.alert;



/*
 * function info(msg){ try{ alertLoop++;
 * mostrarWindowPopup('Info',msg,'','',CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR,CONSTANTES.INPUT_MODAL_NIVEL_INFO);
 * }catch(ex){ throw ex; } }
 */
if (iframe == true){
    // alert = window.parent.alert;
    // alertObject = window.parent.alertObject;
    // info = window.parent.info;
    
    /*
	 * if (alert == null){ alert = window.parent.parent.alert; alertObject =
	 * window.parent.parent.alertObject; info = window.parent.parent.info; }
	 */
}
/* funcion para abril un iframe dentro de un div */
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
        /* alert(me.iframe.width); */
        /* me.iframe.location.href = me.url; */
        // me.iframe.reload();
    };
    this.hide = function(){
        me.iframeWindow.hide();
    };
}

    
SiafBrowserManager.prototype.links = null;
SiafBrowserManager.prototype.cursor = null;
SiafBrowserManager.prototype.loop = null;

function SalirAPrincipal(){
    document.location.href = '../general/main.aspx';
}
function BackMainPage(){
    document.location.href = '../general/main.aspx';
}

function SiafBrowserManager(me){
    me = this;
    
    this.init = function(){
        me.links = new Array();
        me.cursor = 0;
        me.appendLink(BackMainPage);
        me.loop = 0;
    }
    this.appendLink= function(punteroSalir){
        try{
            me.links[me.cursor] = punteroSalir;
            me.cursor++;
        }catch(ex){
        
        }
    }
    this.back = function(){
        try{
            if (me.cursor > 0){
                me.cursor--;
                me.links[me.cursor]();
            }
        }catch(ex){
            // salir a principal
           BackMainPage();
        }
    }
    /* cera los valores de history del volver */
    this.reload = function(){
        cursor = 1;
    }
    /* abre un url en el iframe principal */
    this.open = function(uri){
        me.reload();
        window.frames['myIframe'].location.href = uri;
        $('#Last_url').val(uri);
        
        // $('Last_url').val(url);
    }
}
var browserManager = null;

if (parent.parent.browserManager!= null){
    browserManager = parent.parent.browserManager;
}
else if (parent.browserManager!= null){
    browserManager = parent.browserManager;
}
else {
    browserManager = new SiafBrowserManager();
    browserManager.init();
    
    
    
    // asignar valor
}

/* para que se apriete el boton con id salir del component */
function hacerClickEnSalir(){
    try{
        findElement(CONSTANTES.salir).click();
    }catch(ex){
        throw ex;
    }
}
/* agrega el salir al link del Volver */
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
/* componente para usar logger en el cliente */    
function Logger(me){

    /*
	 * me = this; this.table = createTable('SiafLogger');
	 * 
	 * this.show = function(){
	 * 
	 * if (me.window == null){ me.window = createModalWindow();
	 * 
	 * var div_buttons = me.window.footer.data;
	 * 
	 * me.window.body.div.appendChild(me.table);
	 * 
	 * var div_buttons = me.window.footer.data; var aceptar =
	 * createButton(CONSTANTES.MENSAJES.ACEPTAR); var limpiar =
	 * createButton('Limpiar');
	 * 
	 * div_buttons.appendChild(aceptar); div_buttons.appendChild(limpiar);
	 * 
	 * addEvent(aceptar,'onclick',me.cerrar);
	 * addEvent(limpiar,'onclick',me.limpiar);
	 * 
	 * me.window.centrar(); } me.window.setVisible(true); } this.cerrar =
	 * function(){ me.window.setVisible(false); }
	 * 
	 * this.limpiar = function(){ var count = me.table.rows.length; var i=0; for
	 * (i=0;i<count;i++){ me.table.deleteRow(0); } }
	 * 
	 * this.log = function(msg){ var tr = createRow(this.table,0); var cell =
	 * createCell(tr,0); cell.appendChild(createLabel(msg)); }
	 */
}
var logger = new Logger();
/* definir logger */
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
		/* si mensaje esta vacio y botonera tiene modal */
        if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_PROGRESS_BAR) != CONSTANTES.ZERO){
			   return true;
        }
    }catch(ex){
        
    }
    /* no mostrar */
    return false;
    
}


function ManejadorConfirmacion(hiddenInput,BtnInput,me){
    me = this;
    me.hiddenInput = hiddenInput;
    me.BtnInput = BtnInput;
    
    this.confirmar = function(){
        try{
            $('#'+me.hiddenInput).val('true');
            $('#'+me.BtnInput).trigger('click');
        }catch(ex){
            alert('Error JS al realizar Confirmación, Couníquese con Soporte');
        }
        // presionar boton con confirmacion
        // alert('Confirmar!!!');
        
        
        // jQuery('#'+CONSTANTES.salir).trigger('click');
        /*
		 * if( __doPostBack!=null){ __doPostBack(me.BtnInput.id,''); }else{ var
		 * value = SFDispatchEvent(me.BtnInput,'click'); }
		 */
    }
    // asignar true
    
    // asignar bonton
}
/**/
function SiafGenericVolver(){
    try{
        jQuery('#'+CONSTANTES.salir).trigger('click');
    }catch(ex){
        throw new Error('No existe el Botón '+CONSTANTES.salir);
    }
    
}
function mostrarGenericPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params){
    if (params == null)
        params = new Object();
    /*
	 * si es volver se le hace click al boton con ID salir
	 */
    params.volver = SiafGenericVolver;
    
    if (window.parent.parent.mostrarWindowPopup != null) 
	    window.parent.parent.mostrarWindowPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
    else if (window.parent.mostrarWindowPopup != null)
        window.parent.mostrarWindowPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
    else if(mostrarWindowPopup != null){
        mostrarWindowPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
    }	        
    
}
function mostrarWindowPopup(titulo,mensaje,descripcion,detalle,botonera,nivel,params,listener){
	var dialog = new SiafDialog(listener,params);
	dialog.show(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
	return dialog;
}

SiafDialog.prototype.imagen = CONSTANTES.ICON_ERR;
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

function SiafDialog(listener,initParams,me){
    me = this;
    me.hideFlag = false;
    me.listener = listener;
    me.initParams = initParams;
    me.doClose = false;
    /* (titulo,mensaje,descripcion,detalle,botonera,nivel,params) */
    
    this.showInfo = function(titulo,mensaje,descripcion){
        var botonera = CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR;
        var nivel = CONSTANTES.INPUT_MODAL_NIVEL_INFO;
        var params = new Object()
        me.show(titulo,mensaje,descripcion,null,botonera,nivel,params);  
    };
    this.showError = function(titulo,mensaje,descripcion,detalle){
        var botonera = CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR|CONSTANTES.INPUT_MODAL_BOTON_DETALLES_ERROR;
        var nivel = CONSTANTES.INPUT_MODAL_NIVEL_ERROR;
        var params = new Object()
        params.detalleInfo = detalle;
        me.show(titulo,mensaje,descripcion,detalle,botonera,nivel,params);
    };
     this.showCustomInfo = function(titulo,mensaje,descripcion,label,callback){
        var botonera = CONSTANTES.INPUT_MODAL_BOTON_CUSTOM_MSG;
        var nivel = CONSTANTES.INPUT_MODAL_NIVEL_WARNING;
        var params = new Object()
        params.customCallback = callback;
        params.customLabel = label;
        me.show(titulo,mensaje,descripcion,'',botonera,nivel,params);
    };
    
    this.show = function(titulo,mensaje,descripcion,detalle,botonera,nivel,params){
        try
	    {
	        var imagen = null;
	        
	        if (nivel == CONSTANTES.INPUT_MODAL_NIVEL_ERROR){
                imagen = CONSTANTES.ICON_ERR;
            }else if (nivel == CONSTANTES.INPUT_MODAL_NIVEL_WARNING){
			    imagen = CONSTANTES.ICON_WARN;
            }else{
			    imagen = CONSTANTES.ICON_INFO;
            }

			var buttonsList = {};
	        var $div = $("<div></div>");
	        
	        me.div = $div;
	        me.params = params;
	        
            $div.prop('title','SIGES');
            var id = createUniqueId();
            $div.prop('id',id);
            
            var $table = $('<div style="float:left;padding:7px;"><img id="icono" src="../img/warning.png"></img></div><div style="text-align:center"><h3 class="info_msg"></h3></div><div class="alert_content" style="margin-top:5px" class="info_msg"></div><div class="info_descr"></div><br/><div id="progreso" style="text-align:center"><img class="modal_progress_bar" src="../img/progressbar.gif" /></div>');
            // var $table = $("<table><tr><td
			// class=\'MainModalIcon\'><img></img></td><td
			// class=\'MainModalTitle\'><label></label></td></tr><tr><td
			// colspan='2'
			// class=\'MainModalDescription\'></td></tr></table>").appendTo($div);
	        /*
			 * var $cell1 = $(' tr:eq(0) td:eq(0)',$table); var $cell2 = $('
			 * tr:eq(0) td:eq(1)',$table); var $cell3 = $(' tr:eq(1)
			 * td:eq(0)',$table);
			 */
	        $table.appendTo($div);
	        
            $('#icono',$div).prop('src',imagen);
            $('.info_msg',$div).html(mensaje);
            $('.info_descr',$div).html(descripcion);
            
            
            
            
            /*
			 * $('label',$table).html(mensaje);
			 * $('td:eq(2)',$table).html(descripcion);
			 */
            
		    
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_ACEPTAR) != CONSTANTES.ZERO){
			    // div_buttons.appendChild(acceptBtn);
			    // addEvent(acceptBtn,'onclick',me.aceptar);
		        buttonsList[CONSTANTES.MENSAJES.ACEPTAR] = me.aceptar;
			    me.doClose = true;
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CANCELAR) != CONSTANTES.ZERO){
			    buttonsList[CONSTANTES.MENSAJES.CANCELAR] = me.cancelar;
			    me.doClose = true;
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CONFIRMAR) != CONSTANTES.ZERO){
		        me.confirmacionListener = params.confirmacionListener;
			    buttonsList[CONSTANTES.MENSAJES.CONFIRMAR] = me.confirmar;
		    }
		    if (parseInt(botonera & CONSTANTES.INPUT_MODAL_BOTON_PROGRESS_BAR) != CONSTANTES.ZERO) {
		        //$($table).append('<div><img class=\'modal_progress_bar\' src=\''+CONSTANTES.ICON_PROGRESS_BAR+'\'/ >');

		        if (params.asincronoKey != null) {
		            setTimeout(me.llamarAsincrono, 1000);
		        }
		    } else {
		        $('#progreso', $div).hide();
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CERRAR) != CONSTANTES.ZERO){
			    me.confirmacionListener = params.confirmacionListener;
			    buttonsList[CONSTANTES.MENSAJES.CERRAR] = me.confirmar;
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_VOLVER) != CONSTANTES.ZERO && parseInt(botonera^CONSTANTES.ALL_BITS) != CONSTANTES.ZERO){
			    me.confirmacionListener = params.confirmacionListener;
			    buttonsList[CONSTANTES.MENSAJES.VOLVER] = me.volver;
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_DETALLES_ERROR) != 0){
			    me.confirmacionListener = params.confirmacionListener;
			    buttonsList[CONSTANTES.MENSAJES.DETALLES] = me.showDetallesError;
			    
			    if (params.link != null && params.link.length > 0){
			    
		            buttonsList['Ir a'] = function(){
		                window.open(params.link,'mesa_ayuda',null);
		            };
		            
		        }
		    }
		    if (parseInt(botonera&CONSTANTES.INPUT_MODAL_BOTON_CUSTOM_MSG) != 0){
		        buttonsList[params.customLabel] = me.selectCustomButton;
		    }


		    // mostrar ventana modal
		    jQuery($div).dialog({
		        open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
		        modal: true, width: 400, height: 300, buttons: buttonsList,
		        show: {
		            effect: "blind",
		            duration: 500
		        },
		        closeOnEscape: false,
                close: me.afterClose
		    });
	    }
	    catch (ex)
	    {
		    throw ex;
	    }
	   
    }
    this.afterClose = function(){
        if (me.doClose == false)
            $(me.div).dialog("open");
    }
    this.llamarAsincrono =function(){
        // llamar asincrono!!
        sendJQueryAjax('../general/llamada_asincrona.aspx?KEY='+me.params.asincronoKey,me.resultAsincrono)
    }
    me.sleep = 1000;
    /* leer JSON */
    this.resultAsincrono = function(msj){
        var result = msj.respuesta;
        if (result == 'OK'){
            me.destroy();
            var listener = new Object();
            var params = new Object();
            var dialog = new SiafDialog()
            
            dialog.showInfo(msj.titulo,msj.mensaje,msj.descripcion);
            
            if (msj.script != null && initParams != null){
                me.initParams.ejecutarScript(msj.script)
            }
            
        }
        else if (result == 'ERROR'){
            me.destroy();
            var listener = new Object();
            var params = new Object();
            var dialog = new SiafDialog()
            
            dialog.showError(msj.titulo,msj.mensaje,msj.descripcion,msj.detalle);
            
            if (msj.script){
                me.initParams.ejecutarScript(msj.script)
            }
        }
        else if (result == 'WAITING'){
            // incrementar el tiempo de espera 1 segundo
            me.sleep = me.sleep + 1000;
            setTimeout(me.llamarAsincrono,me.sleep);
        }else{
            me.noVisible();
            alert(msj.respuesta);
        }
    }
    this.hide = function(){
      
    };
    this.Visible = function(){
        $(me.div).dialog("open");
    }
    this.noVisible = function(){
         me.doClose = true;
         $(me.div).dialog("close");
    }
    this.esconderDiv =  function(event){
	};
	this.selectCustomButton = function(event){
	   me.destroy();
	   me.params.customCallback();
	};
	this.aceptar =  function(event){
        // me.window.hide();
        me.destroy();	
        
        if (me.responseListener != null){
            me.responseListener(SiafDialog.RESPONSE.ACEPTAR);
        }
        if (me.listener != null){
            if (me.listener.aceptar != null)
                me.listener.aceptar();
            if (me.listener.closeDialog != null)
                me.listener.closeDialog();
        }
    };
	this.confirmar =  function(event){
	    me.destroy();
	    if (me.confirmacionListener != null){
	        me.confirmacionListener();
	    }
	};
	this.cancelar =  function(event){
	    me.destroy();
		if (me.responseListener != null){
		    me.responseListener(SiafDialog.RESPONSE.CANCELAR);
		}
		if (me.listener != null){
		    if (me.listener.cancelar != null)
                me.listener.cancelar();
            me.listener.closeDialog();
        }
	};
	this.destroy = function(event){
	    me.noVisible();
	    $(me.div).dialog( "destroy" )
	}
	this.volver =  function(event){
	    me.destroy();	
        
		if (me.responseListener != null){
		    me.responseListener(SiafDialog.RESPONSE.VOLVER);
		}
		try{
		    me.params.volver();
		}catch(ex){
		    throw ex;
		}
	};
	this.cerrar =  function(event){
	    me.destroy();	
        
		if (me.responseListener != null){
		   me.responseListener(SiafDialog.RESPONSE.CERRAR);
		}
	};
	this.showDetallesError =  function(event){
	     // esconder current window
	     me.noVisible();
	     me.doClose = false;
	     if (me.detalles != null){
	        // mostrar window con detalles
	        $(me.detalles).dialog("open");
	     }else{
            me.detalles = $('<div title=\'Detalles\'><div>');
            me.detalles.html(me.params.detalleInfo);
            
            // MensajeErrorHeader
            $('table',me.detalles).addClass('MensajeErrorHeader');
            
            
            try{
                // dialog JQuery
                $(me.detalles).dialog({ modal: true,width:600,height:300,close: me.aceptarDetalle});
            }catch(ex){
                    
            }
	     }
	}
	this.aceptarDetalle = function(event){
	    me.Visible();
	};
	this.closeDetalleError = function(event){
	}
	this.showDetallesError2 =  function(event){
	    // mostrar detalles
	    me.noVisible();
	    var listener  = new Object();
	    // al aceptar que me notifique para volver a mostrar el popup
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
 * for (var i=0;i<3;i++){
 * 
 * var cell1 = createCell(row,0); var cell2 = createCell(row,1);
 * 
 * cell1.appendChild(createLabel('label 1' + i));
 * cell2.appendChild(createLabel('label 2' + i)); }
 */
	    alertObject(div,listener)
	};
	
	this.openUrl = function(event){
	    document.location.href=param0;
	};
	this.test = function(event){
	    alert('y ahora es test! '+param0);
		return false;
	};
	this.mostrarConfirmacion = function(event){
		// return confirmarPopup(param0,param1,param2);
	};
	
}

/* Asociar un elemento(onclick) para que muestre un Selector */
function asociarMySelector(eleId,comboId,asociarTextCombo){
    var $ele = $(eleId);
    var $combo = $(comboId);
    
    var selector = new MyComboSelector($ele,$combo,asociarTextCombo);
    selector.config();
}
/*
 * Buscador en Pantallita para Combo Box
 */
MyComboSelector.prototype.element = null;
MyComboSelector.prototype.combo = null;
MyComboSelector.prototype.items = null;
MyComboSelector.prototype.div = null;
MyComboSelector.prototype.label = null;
MyComboSelector.prototype.bodyOptions = null;
MyComboSelector.prototype.selectedIndex = null;
MyComboSelector.prototype.selectedItem = null;
MyComboSelector.prototype.searchInput = null;
MyComboSelector.prototype.searchText = null;
MyComboSelector.prototype.timer = null;
MyComboSelector.prototype.asociarCombo = null;
MyComboSelector.prototype.tipoSeleccion = 1;
MyComboSelector.prototype.window = null;

MySelectorTipos = new Object();
MySelectorTipos.DEFAULT = 1;
MySelectorTipos.LINK = 1;
MySelectorTipos.CHECKBOX = 2;
MySelectorTipos.RADIO = 3;
MySelectorTipos.BUTTON = 4;
/*
 * asociarCombo es opcional, asociar
 */
function MyComboSelector(ele,combo,asociarCombo,me){
    
    this.element = ele;
    this.combo = combo;
    this.asociarCombo = asociarCombo;
    this.tipoSeleccion = MySelectorTipos.DEFAULT;
    me = this;
    
    /*
	 * this.configOld = function(){ this.label = ele.id;
	 * addEvent(this.element,'onclick',this.open); }
	 */
    this.config = function(){
        
        me.div = $("<div title='Elegir'><table ><tr><td><label>Buscar:</label></td><td><input type='text'></input></td></tr></table><div class='SiafCustomSelector' style='height:100%;width:100%;overflow:visible'><table></table></div></div>");
        
        $(me.div).dialog(
            {
                buttons:{'Aceptar':function(){me.close();}},
                autoOpen: false,
                modal: true,
                width:500,
                height:400}
        );
        
        // $(me.element).bind('click': function(){});
        
        $(me.element).bind({
              click: function() {
                me.open(); 
              },
              mouseover: function() {
                $(me.element).css('cursor','pointer');
              }
            }
        );
        
        // asociar boton a funcion search
        $('input:eq(0)',me.div).keydown(me.search);
        
    }
    this.open = function(){
        $(me.div).dialog('open');
        
        setTimeout(
            function(){
                me.imprimirOpciones();
                $('input:eq(0)',me.div).focus();
            },
            100
        );
    }
    this.close = function(){
        $(me.div).dialog('close');
    }
    this.search = function(){
        clearTimeout(me.timer);
        me.timer = setTimeout(me.imprimirOpciones,200);
    }
    this.imprimirOpciones = function(){

        // borrar elementos 'tr' de la tabla
        $('table:eq(1) tr',me.div).remove();
         
        me.items = new Array();
        
        // var matcher = new RegExp(
		// $('input:eq(0)',me.div).val().escapeRegex($('input:eq(0)',me.div).val()),
		// "i" );
        
        // var matcher = new RegExp(
		// $.ui.autocomplete.escapeRegex(request.term), "i" );
        
        var text = $('input:eq(0)',me.div).val();
        
        var matcher = new RegExp(regexWithoutAccent(text),'gi');
        var matcher2 = new RegExp(regexWithoutAccent(text), "gi");
        
        $('option',me.combo).each(function() {
            var label = $(this).text();
            var value = $(this).val();
            
            var selected = $(this).prop('selected');
            var matchResult = (text.length == 0);
            
            if (!matchResult)
                matchResult = label.match(matcher);
            
            if (selected == true || matchResult){
                
                    var newValue = label.replace(matcher2,'<span style=\"background:yellow\">'+text+'</span>');
                    var $tr = $("<tr>"+"<td class='SelectorItem' style='border:1px solid gray'><a>"+newValue.toUpperCase()+'</a></td>'+'</tr>')
                    $('table:eq(1)',me.div).append($tr);
                    
                    $('a',$tr).prop('href','#');
                    $('a',$tr).prop('value',value);
                }
        });
        // ASOCIAR E
        $('table:eq(1) tr td a',me.div).bind({
                click: function() {
                    me.close();
                    // $("option[selected='selected']",$('#'+me.combo.prop('id'))).prop('selected','');
                    
                    // $("option[value='"+$(this).prop('value')+"']",me.combo).prop('selected','selected');
                    $(me.combo).val($(this).prop('value'));
                    
                    me.asociarCombo.cambiarCombo();
                    
                    // alert(document.getElementById(me.combo.id).selectedIndex);
                    // alert($(me.combo).val());
                }
            }
        );
    }
    /*
	 * this.closeOld = function(){ me.window.hide(); }
	 */
    this.accept = function(){
        var oldIndex = me.combo.selectedIndex;
       
        if (me.selectedItem != null){
            me.combo.selectedIndex = me.selectedItem.index;
        }
        if (me.asociarCombo != null){
         // me.asociarCombo.mostrarCombo();
            me.asociarCombo.cambiarCombo();
        }
        try{
            if (this.oldIndex != me.selectedItem.index)
                me.combo.onchange()
        }catch(ex){
            /* no tiene onchange el combo */
        }
        me.close();
    }
    this.search2 = function(){
        clearTimeout(me.timer);
        me.timer = setTimeout(me.imprimirOpciones,50);
    }
    /*
	 * this.imprimirOpcionesOld = function(){ me.searchText =
	 * me.searchInput.value;
	 * 
	 * if (me.items != null){ for (var i=0;i<me.items.length ;i++ ){ var item =
	 * me.items[i]; if(item.optionDiv != null)
	 * me.bodyOptions.removeChild(item.optionDiv); } } me.items = new Array();
	 * 
	 * for (var i=0;i<me.combo.options.length ;i++ ) { if
	 * ((StringUtil.intoString(me.combo.options[i].text,me.searchText,true,true) ==
	 * true) || i == me.selectedIndex){ var item = new Object();
	 * 
	 * item.index = i; item.option = me.combo.options[i]; item.label =
	 * createLabelHTML(insertarEstiloEnTexto(me.combo.options[i].text,me.searchText,'textoEncontrado'));
	 * 
	 * me.items.push(item);
	 * 
	 * if (me.tipoSeleccion == MySelectorTipos.LINK){
	 * 
	 * }else if (me.tipoSeleccion == MySelectorTipos.CHECKBOX){ item.checkBox =
	 * createCheckBox(); }else if (me.tipoSeleccion == MySelectorTipos.RADIO){
	 * 
	 * }else if (me.tipoSeleccion == MySelectorTipos.BUTTON){
	 * 
	 * }else { } var optionDiv = createDiv(); optionDiv.className =
	 * 'SelectorItem'; item.optionDiv = optionDiv;
	 * me.bodyOptions.appendChild(optionDiv)
	 * 
	 * if (me.tipoSeleccion == MySelectorTipos.LINK){ item.link =
	 * createLink(item.label.innerHTML); optionDiv.appendChild(item.link);
	 * addEvent(item.link,'onclick',new callback(me.selectItem,item).call);
	 * optionDiv.style.border = 'none'; if (i%2 == 1){
	 * optionDiv.style.backgroundColor = CONSTANTES.STYLES.COLOR_IMPAR; } if (i ==
	 * me.selectedIndex){ optionDiv.style.fontWeight = 'BOLD'; }
	 * 
	 * }else if (me.tipoSeleccion == MySelectorTipos.CHECKBOX){ item.checkBox =
	 * createCheckBox(); optionDiv.appendChild(item.checkBox);
	 * optionDiv.appendChild(item.label); addEvent(item.checkBox,'onclick',new
	 * callback(me.selectItem,item).call);
	 * 
	 * if(me.combo.options[i].selected) { me.selectedIndex = i; me.selectedItem =
	 * item; item.checkBox.checked = true; }
	 * 
	 * }else if (me.tipoSeleccion == MySelectorTipos.RADIO){
	 * if(me.combo.options[i].selected) { me.selectedIndex = i; me.selectedItem =
	 * item; item.checkBox.checked = true; }
	 * optionDiv.appendChild(selectorComponent);
	 * optionDiv.appendChild(item.label); }else if (me.tipoSeleccion ==
	 * MySelectorTipos.BUTTON){
	 * 
	 * }else { } } } }
	 */
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
    /*
	 * this.openOld = function(){ try{ var params = new Object(); params.width =
	 * '50%'; params.height = '80%'; var wind = createModalWindow(null,params);
	 * 
	 * wind.clickXCallback = me.close;
	 * 
	 * me.window = wind;
	 * 
	 * var div_buttons = wind.footer.data; me.div = wind.div; me.selectedIndex =
	 * me.combo.selectedIndex;
	 * 
	 * var div = me.div; me.items = new Array();
	 * 
	 * var table = createTable(); var head = createRow(table,0); head.className =
	 * 'SelectorHeader';
	 * 
	 * var body = createRow(table,1); var cell1 = createCell(head,0); var cell2 =
	 * createCell(head,1); var cell3 = createCell(body,0);
	 * 
	 * cell3.colSpan = 2 ; cell1.appendChild(createLabel('Buscar'));
	 * 
	 * me.searchInput = createTextField(); cell2.appendChild(me.searchInput);
	 * //cell2.appendChild(createImage('../img/search10x20.jpg'));
	 * 
	 * me.bodyOptions = createDiv(); me.bodyOptions.className =
	 * 'SiafCustomSelectorOptions'; cell3.appendChild(me.bodyOptions);
	 * wind.body.div.className = 'SiafCustomSelector';
	 * wind.body.div.appendChild(table);
	 * 
	 * var div_buttons = wind.footer.data; var aceptar = null; var cancelar =
	 * createButton(CONSTANTES.MENSAJES.CANCELAR);
	 * 
	 * if (me.tipoSeleccion == MySelectorTipos.LINK){
	 * 
	 * }else if (me.tipoSeleccion == MySelectorTipos.CHECKBOX){ aceptar =
	 * createButton(CONSTANTES.MENSAJES.ACEPTAR); }else if (me.tipoSeleccion ==
	 * MySelectorTipos.RADIO){
	 * 
	 * }else if (me.tipoSeleccion == MySelectorTipos.BUTTON){
	 * 
	 * }else { } if (aceptar != null){ div_buttons.appendChild(aceptar);
	 * addEvent(aceptar,'onclick',me.accept); }
	 * div_buttons.appendChild(cancelar);
	 * 
	 * 
	 * addEvent(cancelar,'onclick',me.close);
	 * 
	 * 
	 * addEvent(me.searchInput,'onkeydown',me.search);
	 * 
	 * me.imprimirOpciones(); centrarDiv(div);
	 * 
	 * wind.setCloseListener(me.close);
	 * 
	 * me.searchInput.focus(); }catch(ex){ throw ex; } }
	 */
}

/* Diálogo de Busqueda */
if (parent.parent.SiafSearch != null){
    SiafSearch  = parent.parent.SiafSearch;
    
}
else if (parent.parent.SiafSearch != null){
    SiafSearch  = parent.SiafSearch;
    
}else{
    
    var seachCount = 0;
    
    /*
	 * params title = [texto] / titulo de la ventana searchOnOpen = [true,false] /
	 * ejecutar el buscar al abrir ventana urlParams = [Object]
	 */
    
    SiafSearch = function(name,target,targetLabel,params,contextPage,listener){
        seachCount++;
        var search = new SiafSearchComponent(seachCount);
        
        var validate = null;        
        if (params != null){
            search.title = params.title;
            search.searchOnOpen = params.searchOnOpen;
            search.params = params.urlParams;
            search.descObjetivo = params.descObjetivo;
            validate = params.validate;
            search.readOnly = params.readOnly;
        }
        search.name = name;
        search.target = target;
        search.targetLabel = targetLabel;
        search.tipoSeleccion = MySelectorTipos.LINK;
        search.listener = listener;
        
        

        pContext = contextPage;
        pName = name;
        search.url = '../general/consulta.ashx?Context='+pContext+'&TIPO='+pName+'&';
        
        if (validate != null){
            if (!validate()){
                /* Si no es valido, ignora mostrar diálogo */
                return;
            }
        }
        /* sino tiene o paso la validación */
        search.open();
        
        
    }
}

function SiafSearchComponent(seachCount,me){
    me = this;
    me.url = '';
    me.items = new Array();
    me.results = new Array();
    me.urlParams ='';
    me.descObjetivo = '';
    me.readOnly=false;
    
    this.open = function(){
        // llamar ajax los campos
       
        
        
        sendJQueryAjax(me.url+me.urlParams,me.receiveForm)
        
        if (me.title == null)
            me.title = 'Buscador';
            
        me.wind = $("<div title='"+me.title+":'><div class='BuscadorNotice'></div><table  class='tabla1'></table><table class='DataGridMant'></table></div>")
        
        me.wind.dialog({modal: true,width:600,height:400,close:me.afterClose,buttons:{Buscar:me.search,Cancelar:me.close}});
        me.desabilitarBuscar(me.wind.dialog);
        $('button:eq(0)',me.wind.dialog.buttons).button('disable');
        
        me.showMessage('Cargando Formulario');
        
        
        return;
    }
    this.showMessage = function(msg){
        if (msg == null){
            $('div:eq(0)',me.wind).css('display','none');
        }else{
            $('div:eq(0)',me.wind).css('display','');
            $('div:eq(0)',me.wind).html(msg);
        }
    }
    this.close = function(){
        $(me.wind).dialog('close');
    }
    this.afterClose = function(){
        // destruir el dialog
        $(me.wind).dialog('destroy');
    }
    this.desabilitarBuscar = function(dialog){
        $('button:eq(0)',$(me.wind).dialog.buttons).button('disable');
    }
    this.habilitarBuscar = function(){
        $('button:eq(0)',$(me.wind).dialog.buttons).button('enable');
    }
    this.receiveForm = function(pform){
        
        var result = pform.filtros;
        
        var filtros = GetJson2Array(result.filtro);
        var cabeceras = GetJson2Array(pform.cabeceras.cabecera);
        
        var $row =null;
        for (var index = 0;index < filtros.length;index++){
           var filtro = filtros[index];
           $row = $('<tr><td class="ColTitulo"><label></label></td><td class="ColDatos"></td></tr>')
                
            $('table:eq(0)',me.wind).append($row);
                
                var $cell = $('td:eq(1)',$row);
                
                $('label',$row).html(filtro.label);
                var tempParams = params;
                var params =  null;
                
                if (filtro.parametro != null && filtro.parametro != ''){
                	params = eval('(' + filtro.parametro + ')');
                	
                }
                
                if (filtro.tipo == 'NFILTRO' || filtro.tipo == 'SFILTRO'){
                	var $combo = $("<select class='InputComboFilter' name='"+filtro.name+":TIPO_FILTRO'></select>")
                	 
                	var $filter1 = $("<input type='text' name='"+filtro.name+":FILTRO0' disabled='disabled' style='display:none'/>")
                	
                	$cell.append($combo);
                	$cell.append($filter1);
                	
                	//$cell.append($('<label>'+filtro.name+'</label>'));
                	
                	
                	$filter1.keyup(me.validarInput);
                	
                	if (filtro.tipo == 'NFILTRO'){
                		$filter1.SiafNumericFormat();
                	}
                	
                	$combo.append($("<option value='Ninguno' selected='selected'>-- Sin Selección --</option>"));
                 	$combo.append($("<option value='Igual' >Igual</option>"));
                 	$combo.append($("<option value='MayorA'>Mayor a</option>"));
                 	$combo.append($("<option value='MayorIgualA'>Mayor o Igual a</option>"));
                 	$combo.append($("<option value='MenorA'>Menor a</option>"));
                 	$combo.append($("<option value='MenorIgualA'>Menor o Igual a</option>"));
                 	$combo.append($("<option value='Diferente'>Diferente</option>"));
                 	$combo.append($("<option value='BuscaCadena'>Busca Cadena</option>"));
                 	$combo.append($("<option value='NoNulo'>No Nulo</option>"));
                 	$combo.append($("<option value='Nulo'>Nulo</option>"));
                 	 
      		        //$combo.change();
      		        $combo.change(
      		        		function(){
      		        			var val = $(this).val();
      		        			//var str1 = "#Igual#MayorA#MayorIgualA#MenorA#MenorIgualA#Diferente#BuscaCadena#NoNulo#Nulo#"
      		        			var str1 = "#Igual#MayorA#MayorIgualA#MenorA#MenorIgualA#Diferente#BuscaCadena#"
      		        			var str2 = "#NoNulo#Nulo#"
      		        			
                                
      		        			if (str1.indexOf(val)>-1){
      		        				$('input:eq(0)',$(this).parent()).prop('disabled','');
      		        				$('input:eq(0)',$(this).parent()).css('display','')
      		        				$(this).addClass('InputComboFilter');
      		        				$('input:eq(0)',$(this).parent()).focus();
      		        			}
      		        			else if (str2.indexOf(val)>-1){
      		        				//change to InputComboFilter
      		        				$(this).removeClass('InputComboFilter');
      		        				$('input:eq(0)',$(this).parent()).val('')
      		        				$('input:eq(0)',$(this).parent()).css('display','none')
      		        				$('input:eq(0)',$(this).parent()).prop('disabled','disabled');
      		        			}else{
      		        				$('input:eq(0)',$(this).parent()).css('display','none')
      		        				$(this).addClass('InputComboFilter');
      		        			}
      		        			me.validarInput();
      		        		}
      		        );
                }
                else if (filtro.tipo == 'SELECT'){
    		        /* crear select y asignar los options */
    		        var $combo = $("<select name='"+filtro.name+"'><option value=''>Elegir</option></select>")
    		        $cell.append($combo);
    		        $combo.change(me.validarInput);
    		        
    		    }else{
    		        var $searchInput = $("<input type='text' name='"+filtro.name+":FILTRO0' size='70'/>")
    		        
    		        $cell.append($searchInput);
    		        
    		        $searchInput.keyup(me.validarInput);
   		        
    		        if (me.params != null && me.params[filtro.name] != null){
    		            if ($.trim(me.params[filtro.name].val())!= '')
    		                $searchInput.val(me.params[filtro.name].val());
    		            else
    		                $searchInput.val("-");
    		            $searchInput.prop('readonly',me.readOnly==true);
    		        }
    		    }
            }
           // add row to cabecera
        var $row = $('<tr class=\'Encabezado\'></tr>')
        
        $('table:eq(1)',me.wind).append($row);
        
        for (var index = 0;index < cabeceras.length;index++){
           var cabecera = cabeceras[index];
           $('table:eq(1) tr:eq(0)',me.wind).append('<th>'+cabecera.label+'</th>');
        }
        
        $('input').keyup(function(e) {
                // si se presiona enter
	            if(e.keyCode == 13) {
		            me.search(); 
	            }
        });
        
        $('input:eq(0)',me.wind).focus();
        
        me.showMessage(null);
        
        me.validarInput();
        
        /* si tengo que buscar al abrir formulario */
        if (me.searchOnOpen){
            me.search(); 
        }
        return;
    }
    this.validarInput = function(){
        me.desabilitarBuscar();
        
        // iterar sobre los inputs de la primera tabla
        $('table:eq(0) :input',me.wind).each(function(index){
            
        	var value = $(this).val();
            var disabled = $(this).prop('disabled');
            
            var hasClass = $(this).hasClass('InputComboFilter');
            
            if (value != null && value.length > 0 && !hasClass){
                me.habilitarBuscar();
                return true;
            }
            
        });
        
        return false;
    }
    this.searchByKey = function(){
        
    }
    this.search = function(){
    	$('table:eq(1) tr:gt(0)',me.wind).remove();
        clearTimeout(me.timer);
        me.timer = setTimeout(me.search2Server,100);
    }
    this.search2Server = function(){
        me.showMessage('Enviando Consulta...');
        me.desabilitarBuscar();
        var url = me.url;
        
        var query = '';
        
        var vdata = new Object();
        
        var queryObj = new Object();
        
        $('table:eq(0) :input',me.wind).each(function(index){
            var name = $(this).prop('name');
            var value = $(this).val();
            
            if (value.length >0){
                var sinTilde = value;
                sinTilde=sinTilde.toUpperCase()
                sinTilde=sinTilde.replace("Á","A"); 
                sinTilde=sinTilde.replace("É","E"); 
                sinTilde=sinTilde.replace("Í","I"); 
                sinTilde=sinTilde.replace("Ó","O"); 
                sinTilde=sinTilde.replace("Ú","U"); 
                sinTilde=sinTilde.replace("Ñ","N");      
                sinTilde=sinTilde.replace("Ü","U");             
                query = query + '&' + name + '=' + sinTilde;
                queryObj[name] = value;
                /* vdata[name] = value; */
                
            }
        });
        
        me.urlParams = '';
        
        for (var param in me.params){
            /* Si no tengo en el campo */
            if (queryObj[param] == null)
                me.urlParams = me.urlParams + '&'+param+'='+me.params[param];
        }
        /* add parameters */
        url = url +'&OPTION=SEARCH&'+me.urlParams;
        /* add textbox values */
        url = url + query;
        
        sendJQueryAjax(url,me.receiveResult);
        
        clearTimeout(me.timer);
       
    }
    this.receiveResult = function (json){
        me.showMessage('Recibiendo Consulta...');
        me.habilitarBuscar();
        var result = json.resultados;
        
        var $table = $('table:eq(1)',me.wind);
        $($table).css('background','white');
        
        var results = GetJson2Array(result.resultado);
        // recibir resultados
            
        for (var index=0;index < results.length;index++){
                var $row = '<tr>';
                var xml = '<xml><label>'+results[index].label+'</label><value>'+results[index].value+'</value>';
               var campos = GetJson2Array(results[index].campo);
                for (var col=0;col<campos.length;col++){
                    $row = $row + '<td>'+ campos[col].descripcion+'</td>'; 
                    xml = xml + '<campo'+col+'>'+  campos[col].descripcion +'</campo'+col+'>';
                    // node['campo'+col] =
					// result.resultado[index].campo[col].descripcion;
                }
                
                xml = xml + '</xml>';
                
                $row = $row + '</tr>';
                $row = $table.append($row);
                
                $('tr:last',$table).prop('nodeRel',xml);
        }
               
        me.showMessage('Cantidad de Resultados: '+results.length  + (json.propiedades.mensaje!=null?(' - ' + json.propiedades.mensaje):'') );
        $('tr',$table).addClass('DetalleAlterno');
        
        $('tr',$table).hover(function() {
            $(this).removeClass("DetalleAlterno");
            $(this).addClass("highlight");
        },
        function() {
            $(this).removeClass("highlight");
            $(this).addClass("DetalleAlterno");
        });        
  
        
        $('tr',$table).dblclick(
                    function(){
                        var nodeRel = $(this).prop('nodeRel');
                        var json = $.xml2json(nodeRel);
                       
                        if (me.target != null){
                            $(me.target).val(json.value);
                            $(me.target).focus();
                        }
                        
                        if (me.targetLabel != null){   
                            //$(me.targetLabel).val(json.label);
                            posicion = 1;
                            var desObj
                            for (desObj in me.descObjetivo){                                
                                me.descObjetivo[desObj].val($(this).find("td").eq(posicion++).text());
                            }
                        }
                        
                        if (me.listener != null){
                            me.listener(json);
                        }
                        
                        // llamar al onchange del target
                        if (me.target != null){
                           $(me.target).trigger('change');
                        }
                        me.close();                                                      
                    });
        
        // fin de llamada
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
		        // var optionDiv = createDiv();
                // optionDiv.className = 'SelectorItem';
                // me.bodyOptions.appendChild(optionDiv)
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
    
    this.accept = function(){
        
    }
  
    
};

// Iconos
function appendIcon(parentId,title,image,purl){
	try{
	    var icon = new SiafIcon();
	    icon.append(parentId,title,image,purl);
	    
	}catch(ex){
		throw ex;
	}
}
SiafIcon.prototype.url = null;

function SiafIcon(me){
    me = this;
    this.append = function(parentId,title,image,purl){
        try{
            var $div = $('<div><div><img></img></div><a></a></div>').appendTo($(parentId));
		    me.url = purl;
		    
		    $('img',$div).prop('src',image);
		    var $link = $('a',$div)
		    
		    $link.append(title);
		    $link.prop('href','#');
		    
		    $div.addClass('thumbnail');

            $('a',$div).click(me.openUrl);
            $('img',$div).click(me.openUrl);
            		    
        }catch(ex){
            throw ex;
        }
    }
    this.openUrl = function(event){
        // alert(me.url);
	    document.location.href=me.url;
	};
}

/* Asociacion de Combos */
function asociarTextCombo(linkId,comboId){
    try{
    var $lnk = $(linkId);
	var $combo = $(comboId);

	var $textCombo = new TextCombo($lnk,$combo);
	/*
	 * param1.style.display = 'inline'; param0.style.display = 'none';
	 * param1.focus();
	 */
	$lnk.text($('option:selected',$combo).text());
	
	$lnk.click(function(){$combo.css('display','inline');$lnk.css('display','none')});
	$combo.change(function(){$combo.css('display','none');$lnk.css('display','inline')});
	$combo.blur(function(){$combo.css('display','none');$lnk.css('display','inline')});
	
	return $textCombo;
    
    // $lnk.append('value')
    /*
	 * addEvent(lnk,'onclick',textCombo.mostrarCombo);
	 * addEvent(combo,'onchange',textCombo.cambiarCombo);
	 * addEvent(combo,'onblur',textCombo.perderCombo);
	 */
	    
   // if (combo.selectedIndex >= 0)
    // lnk.innerHTML = '['+ combo.options[combo.selectedIndex].innerHTML +']';
        
    // return textCombo;
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
	    param0.css('display','inline');
		// param1.options[param1.selectedIndex].innerHTML
		param0.html('['+ $('option:selected',param1).text() +']');
		param1.css('display','none');
		param1.trigger('change');
	};
	this.perderCombo =  function(event){
		param0.style.display = 'inline';
		param1.style.display = 'none';
	};
}
/*
 * function modificarEjercicio(lnk){ lnk.style.display = 'none';
 * document.getElementById('select_ejercicio').style.display = 'inline' }
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
	        // primer elemento si no concuerda con nada
	        if (encontrado == 0){
	            
	            combo.selectedIndex = valueNull;
	        }
	            
	            
	        
	        addEvent(combo,'onchange',new asociarCombo(comboId,textId).changeValue);
	        addEvent(text,'onchange',new asociarCombo(comboId,textId).changeValue2);
	        
	        combo.disabled = text.disabled;
	    }catch(ex){
	        alert(ex);
	        /*
			 * if (combo == null) //alert('No se encontro Combo con ID
			 * '+comboId) if (text == null) //alert('No se encontro TextBox con
			 * ID '+textId)
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
	        // primer elemento si no concuerda con nada
	        if (encontrado == 0){
	            combo.selectedIndex = valueNull;
	        }else{
	         
	        }
	            
	            
	            
	    }catch(ex){
	        throw ex;
	    }
	};
}

/* string util */
var StringUtil = new Object();

/*
 * valida si dentro de un string existe una palabra (uppercase = true para que
 * no sea sensible a mayuscula)
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
 * devuelve la posicino donde empieza un substring dado last(int) = desde donde
 * buscar
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
        // upper case
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
        // no se pudo quitar los acentos
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
 * las palabras *param* se aplicaran un estilo dado
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
 * las palabras *param* se aplicaran un tag dado ejem (B para que esten en
 * negrita)
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
 * se inserta un css class en un string en la posicion p hasta la q
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

   



// funcion para enviar ajax with JQuery
function sendJQueryAjax(purl,psuccess,pdata){
   var result = $.ajax({
        type: "GET",
        url: purl,
        contentType:'text/xml;utf-8',
        dataType: 'xml',
        scriptCharset:'utf-8',
        cache:false,
        success: function(xml){
                // var xml2 =
				// $(xml).find('resultado').contents().each(function(i){
				// alert(i) });
                 var json = $.xml2json(xml);
                 psuccess(json);
           }
        });
}
var i=0;
function createUniqueId(base){
    i++;
    return base+'_'+i;
}
function regexWithoutAccent(text){
    var r=text;
        r = r.replace(new RegExp("[àáâãäåa]", 'g'),"[àáâãäåa]");
        r = r.replace(new RegExp("æ", 'g'),"ae");
        r = r.replace(new RegExp("ç", 'g'),"c");
        r = r.replace(new RegExp("[èéêëe]", 'g'),"[èéêëe]");
        r = r.replace(new RegExp("[ìíîïi]", 'g'),"[ìíîïi]");
        r = r.replace(new RegExp("ñ", 'g'),"[ñn]");                            
        r = r.replace(new RegExp("[òóôõöóo]", 'g'),"[òóôõöo]");
        r = r.replace(new RegExp("œ", 'g'),"oe");
        r = r.replace(new RegExp("[ùúûüu]", 'g'),"[ùúûüu]");
        r = r.replace(new RegExp("[ýÿ]", 'g'),"[ýÿ]");
        // upper case
        r = r.replace(new RegExp("[àáâãäåa]".toUpperCase(), 'g'),"[àáâãäåa]".toUpperCase());
        r = r.replace(new RegExp("æ".toUpperCase(), 'g'),"ae".toUpperCase());
        r = r.replace(new RegExp("ç".toUpperCase(), 'g'),"c".toUpperCase());
        r = r.replace(new RegExp("[èéêëe]".toUpperCase(), 'g'),"[èéêëe]".toUpperCase());
        r = r.replace(new RegExp("[ìíîïi]".toUpperCase(), 'g'),"[ìíîïi]".toUpperCase());
        r = r.replace(new RegExp("ñ".toUpperCase(), 'g'),"[ñn]".toUpperCase());                            
        r = r.replace(new RegExp("[òóôõöo]".toUpperCase(), 'g'),"[òóôõöo]".toUpperCase());
        r = r.replace(new RegExp("œ".toUpperCase(), 'g'),"oe".toUpperCase());
        r = r.replace(new RegExp("[ùúûüu]".toUpperCase(), 'g'),"[ùúûüu]".toUpperCase());
        r = r.replace(new RegExp("[ýÿy]".toUpperCase(), 'g'),"[ýÿy]".toUpperCase());
        
        return r;
}
function findElement(pid){
    return document.getElementById(pid);
}

$(document).ready(function() {
    // init
    try {


        $("#grabar,#Grabar,#GRABAR").click(function () {
            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate('') == true) {
                    $(this).parent().append("<span class='AvisoImportanteLogin'>Este proceso tarda algunos minutos, por favor espere.</span>");
                    $("#grabar,#Grabar,#GRABAR,#salir,#Salir,#SALIR").each(function () {
                        $(this).hide();
                    });
                }
            } else {
                $(this).parent().append("<span class='AvisoImportanteLogin'>Este proceso tarda algunos minutos, por favor espere.</span>");
                $("#grabar,#Grabar,#GRABAR,#salir,#Salir,#SALIR").each(function () {
                    $(this).hide();
                });
            }
        });
        
        jQuery('.Fecha').keyup(function(event){
            
            if (event.which >= 48 && event.which <= 57 ){
                var d = jQuery(this).val();   
                
                var dia = '[0-3][0-9]';
                var mes = '[0-3][0-9].[0-1][0-9]'
                 var ano = '[0-3][0-9].[0-1][0-9]'
                if (d.match(dia) && d.length == 2){
                    jQuery(this).val(d+'/');
                }
                else if (d.match(mes) && d.length == 5){
                    jQuery(this).val(d+'/');
                }
            }else if (event.which >= 111){
                var d = jQuery(this).val();
                
                if (d.length == 2){
                    jQuery(this).val('0'+d);
                }
                else if (d.length==5){
                    var a = d.split('/')
                    jQuery(this).val(a[0]+'/0'+a[1]+'/');
                }
            }
        });
        jQuery('.Fecha').focusout(function(event){
            var date = jQuery(this).val();
            var split = date.split('/');
            var a = '?';
            var b = '?';
            var c = '?';
            // dia
            if (split.length == 3){
                
                if (split[0].match('\\d\\d')){
                    a = split[0];
                }else if (split[0].match('\\d')){
                    a = '0'+split[0];
                }
                                
                // mes
                if (split.length >= 2 && split[1].match('\\d\\d')){
                    b = split[1];
                }else if (split.length >= 2 && split[1].match('\\d')){
                    b = '0'+split[1];
                }
                
                
                // año
                if (split[2].match('\\d\\d\\d\\d')){
                     c = split[2];
                }else if(split[2].match('\\d\\d') && split[2].length == 2){
                    c = '20'+split[2];
                }
            }
            jQuery(this).val(a+'/'+b+'/'+c);
        });
    }catch(ex){
    
    }
    initPage();
});

function GetJson2Array(json){
    if (json == null){
        return new Array();
    }
    else if (json.length!=null){
        return json;
    }else{
        return new Array(json);
    }
    return array;
}
/* asigna como boton, a imagenes para que el cursor cambie al pasar encima */
function AsignarComoBoton(boton){
    $(boton).bind({
              mouseover: function() {
                $(boton).css('cursor','pointer');
              },
              mouseout: function() {
                $(boton).css('cursor','default');
              }
            }
        );
}
function ActualizarTareas(){
    try{
        if (parent != null && parent.MostrarTareas != null)
            parent.MostrarTareas();
        else
            MostrarTareas();
    }catch(ex)
    {

    }
}
function MostrarTareas(){
    // general/consulta.aspx?TIPO=TAREAS_USUARIO
    try{
        sendJQueryAjax('../general/consulta.aspx?TIPO=TAREAS_USUARIO',RecibirTareas)
    }catch(ex){
    
    }
}
function LimpiarTareas(){
    // general/consulta.aspx?TIPO=TAREAS_USUARIO
    sendJQueryAjax('../general/consulta.aspx?TIPO=LIMPIAR_TAREAS',ActualizarTareas)
}

function RecibirTareas(obj){
     
    // var xml =
	// '<xml><label>'+results[index].label+'</label><value>'+results[index].value+'</value>';
    try{
        
        
        $('#Tareas table:eq(0) tr').remove();
        var tareas = GetJson2Array(obj.tareas.tarea);
        var actualizar = false;
        
        
        
        for (var index=0;index < tareas.length;index++){
            var tarea = tareas[index];
            $div = ''
            
            if (tarea.estado == 'FAIL'){
                // $div = $("<tr><td><div><img
				// src='../img/error32.jpg'></img><label>"+tarea.titulo+"</label></div><div>"+tarea.titulo
				// + "</div></td></tr>");
                $div = $("<tr><td><table class='Tarea'><tr><td style='width:15px'><img src='../img/fail15.png'></img></td><td>"+tarea.fecha + ' | '+tarea.titulo+"</td></tr><tr><td colspan='2'>"+tarea.descripcion + "</td></tr></table></td></tr>");
                $('table:eq(0)','#Tareas').append($div);
                
            }else if (tarea.estado == 'OK'){
               $div = $("<tr><td><table class='Tarea'><tr><td ><img src='../img/ok15.png'></img></td><td>"+tarea.fecha + ' | '+tarea.titulo+"</td></tr><tr><td colspan='2'>"+tarea.descripcion + "</td></tr></table></td></tr>");
               $('table:eq(0)','#Tareas').append($div);
               
                // $('#Tareas').append($div);
            }else{
                try{
                    $div = $("<tr><td><table class='Tarea'><tr><td><img src='../img/wait.gif'/></td><td>"+ tarea.fecha + ' | '+tarea.titulo+"</td></tr><tr><td colspan='2' ><div style='height:15px'></div></td></tr></table></td></tr>");
                    $('table:eq(0)','#Tareas').append($div);
                    $('div',$div).progressbar({'value': parseInt(tarea.avance)});
                    // $('div',$('div',$div).progressbar("widget")).text(tarea.titulo)
                    $('div',$('div',$div).progressbar("widget")).css('overflow','hidden');
                    $('div',$('div',$div).progressbar("widget")).css('font-size','8pt');
                    $('div',$('div',$div).progressbar("widget")).css('font-weight','normal');
                    $('div',$('div',$div).progressbar("widget")).css('align','normal');
                    $('div',$div).progressbar("widget").css('width','100%')
                    // "widget"
                    // alert('vamos!');
                }
                catch(ex){
                   
                }
                
                actualizar = true;
            }
        }
        /* $('tr:odd',$table).addClass('DetalleAlterno'); */
         
        // $('#Tareas table:eq(0) tr:odd').addClass('DetalleAlterno');
        
        if (actualizar)
            setTimeout(MostrarTareas,5000);
    
    
    }catch (ex){
    
    }
}

function AbrirVentanaUbicacion()
{
	var w;
	var op = '<%=Request.QueryString("OP")%>';
	var ob = '<%=Session("OBJETOENCR")%>';
	var id = '<%=Request.QueryString("id")%>';
	if (op!='VER_REGISTRO' && op!='BORRAR'){
	    w=window.open("../NNM/frmSelUnidadAdminPuesto.aspx?id=" + ob,"Ubicacion","width=850,height=500,toolbars=yes,scrollbars=yes,resizable=yes");
	    // w=window.open("../NNM/frmSelUnidadAdminPuesto.aspx?id=" +
		// ob,"Ubicacion","width=850,height=650,toolbars=no,scrollbars=yes,resizable=yes");
		w.opener=self;
		w.focus();
	}
}
/* Arbol */

function SiafTreeCallback(listener,param){
    this.click = function(){
        listener(param);
    }
}
// calendario.show(document.Form1.FECHA_VIGENCIA);

// $('#AgregarDescuentoDiv').SiafCleanForm();
/* Siaf Clean Form */
(function($){  
    $.fn.SiafCleanForm = function(){
        var element = $(this);
        
        $(':input',element).each(
            function(){
                //
                $(this).val('');    
            }
        );
        
    }
})(jQuery);

/*Siaf Catálogo Plugin*/

(function($) {
	var methods = {

					
		/*
		 *  parametros
		 *  
		 *  nombre : nombre del arbol
		 *  contexto : contexto ejem NNM/NMF
		 *  campoObjetivo : campo donde se llena la clave
		 *  campoDescripcionObjetivo : campo donde se llena la descripcion
		 *  titulo : titulo del buscador
		 *  buscarAlAbrir : llamar al Buscar, sin llenar filtros
		 *  
		 *  alSeleccionar : Funcion Puntero, al momento de seleccionar opción de Arbol
		 *  
		 */
		init : function(options) {
			var element = $(this);
			var data = new Object();

			data.options = options;
			
			element.data('data',data);
			
			$(element).css('cursor','pointer');
			
			$(element).click(
					function(){$(element).SiafBuscador('open');}
			);
			if (data.options.getKey != null){
			    $(data.options.campoObjetivo).blur(
			            function(){$(element).SiafBuscador('open2');
			    });
			}
					
			return element;
		},
		open : function() {
			
			var element = $(this);
			data = element.data('data');
			
			var options = data.options;

			$(element).css('cursor','pointer');
			/*SiafSearch = function(name,target,targetLabel,params,contextPage,listener){*/
			
			var params = {title:options.titulo,searchOnOpen:options.buscarAlAbrir,readOnly:options.readOnly};
			
			/*
			 obtener parámetros personalizados
			*/
			if (options.getParametros != null){
				params.urlParams = options.getParametros();
			}
			if (options.campoDescripcionObjetivo != null){
			   params.descObjetivo = options.campoDescripcionObjetivo();
			}
			params.validate = options.validator;
			
			var dialog = SiafSearch(options.nombre,
					options.campoObjetivo,
					options.campoDescripcionObjetivo,
					params,
					options.contexto,
					options.alSeleccionar);

			
			return element;
		},
		open2 : function() {		
            var element = $(this);
			data = element.data('data');
			
			var options = data.options;

			$(element).css('cursor','pointer');
			
			var params = {title:options.titulo,searchOnOpen:options.buscarAlAbrir,readOnly:options.readOnly};
			
			/*
			 obtener parámetros personalizados
			*/
			if (options.getParametros != null){
				params.urlParams = options.getParametros();
			}
			if (options.getKey != null){
				params.urlKey = options.getKey();
			}			
			if (options.campoDescripcionObjetivo != null){
			   params.descObjetivo = options.campoDescripcionObjetivo();
			}
			params.validate = options.validator;
		    var info = SiafAAA(options.nombre,
				    options.campoObjetivo,
				    options.campoDescripcionObjetivo,
				    params,
				    options.contexto,
				    options.alSeleccionar);
			
			return element;
		}
	};
	$.fn.SiafBuscador = function(method) {
		// Method calling logic
		if (methods[method]) {
			return methods[method].apply(this, Array.prototype.slice.call(
					arguments, 1));
		} else if (typeof method === 'object' || !method) {
			return methods.init.apply(this, arguments);
		} else {
			$.error('Method ' + method + ' does not exist on jQuery.tooltip');
		}

	};

})(jQuery);

function SiafAAA(name,target,targetLabel,params,contextPage,listener){       
		if (target.val().length==0){
		    target.val("");
		    for (var desObj in params.descObjetivo){
			        params.descObjetivo[desObj].val('');
		    }			    
		}else{            
	        var urlParams="&WHERE=";
	        for (var param in params.urlKey){
                 urlParams = urlParams + '~AND~' + param+'-'+params.urlKey[param].val();
            }            
		    sendJQueryAjax('../general/consulta.ashx?Context='+contextPage+'&TIPO='+name+'&OPTION=BUSCAR2'+urlParams,function (json){
			    var result = json.resultados;                
			    var results = GetJson2Array(result.resultado);			
		        if (results.length>0){	
		            //Recorre cada fila encontrada
		            for (var index=0;index < results.length;index++){
				            var campos = GetJson2Array(results[index].campo);
				            //recorre cada campo de cada fila
				            var col = 1;
				            var desObj;
				            for (desObj in params.descObjetivo){
					            params.descObjetivo[desObj].val(campos[col].descripcion);
					            if (col==campos.length-1) break;
					            col++;
				            }
		            }
		            if (listener != null){
                        listener(json);
                    }		
		        }else{			    
		            for (var desObj in params.descObjetivo){
			            params.descObjetivo[desObj].val('No existe el código='+target.val());
		            }
		            target.val("");
		        }
    	    });
        }		        
}
    
(function($) {
	var methods = {

					
		/*
		 *  parametros
		 *  
		 *  nombre : nombre del arbol
		 *  contexto : contexto ejem NNM/NMF
		 *  campoObjetivo : campo donde se llena la clave
		 *  campoDescripcionObjetivo : campo donde se llena la descripcion
		 *  titulo : titulo del buscador
		 *  buscarAlAbrir : llamar al Buscar, sin llenar filtros
		 *  
		 *  alSeleccionar : Funcion Puntero, al momento de seleccionar opción de Arbol
		 *  
		 */
		init : function(options) {
			var element = $(this);
			var data = new Object();

			data.options = options;
			
			element.data('data',data);
			
			//$(element).css('cursor','pointer');
			
			$(element).blur(
					function(){$(element).SiafA('open');}
			);
					
			return element;
		},
		open : function() {		
            var element = $(this);
			data = element.data('data');
			
			var options = data.options;

			//$(element).css('cursor','pointer');
			
			var params = {title:options.titulo,searchOnOpen:options.buscarAlAbrir,readOnly:options.readOnly};
			
			/*
			 obtener parámetros personalizados
			*/
			if (options.getParametros != null){
				params.urlParams = options.getParametros();
			}
			if (options.campoDescripcionObjetivo != null){
			   params.descObjetivo = options.campoDescripcionObjetivo();
			}
			params.validate = options.validator;
			
			var dialog = SiafAAA(options.nombre,
					options.campoObjetivo,
					options.campoDescripcionObjetivo,
					params,
					options.contexto,
					options.alSeleccionar);

			
			return element;
		}
	};
	$.fn.SiafA = function(method) {
		// Method calling logic
		if (methods[method]) {
			return methods[method].apply(this, Array.prototype.slice.call(
					arguments, 1));
		} else if (typeof method === 'object' || !method) {
			return methods.init.apply(this, arguments);
		} else {
			$.error('Method ' + method + ' does not exist on jQuery.tooltip');
		}

	};

})(jQuery);

(function($) {
	var methods = {
		/*
		 *  parametros
		 *  
		 *  nombre : nombre del arbol
		 *  contexto : contexto ejem NNM/NMF
		 *  titulo : titulo del arbol
		 *  cerrarAlSeleccionar : ?
		 *  elegirCarpetas : ?
		 *  alSeleccionar : Funcion Puntero, al momento de seleccionar opción de Arbol
		 *  
		 */
		init : function(options) {
			var element = $(this);
			var data = new Object();

			data.options = options;
			
			element.data('data',data);
			
			$(element).css('cursor','pointer');
			
			
			
			$(element).click(
					function(){$(element).SiafTree('open');}
			);
			
			
			
			return element;
		},
		open : function() {
			
			var element = $(this);
			data = element.data('data');
			
			var options = data.options;

			$(element).css('cursor','pointer');
			
			
			var p_urlParams = new Object();
			
			if (options.getParametros != null){
				p_urlParams = options.getParametros();
			}
			
			p_urlParams.Context = options.contexto;
			
			var tree = new SiafTreeView({
                url:'../general/generic_tree.ashx?TIPO='+options.nombre,
                title:options.titulo,
                closeOnSelect:options.cerrarAlSeleccionar,
                selectFolder:options.elegirCarpetas,
                urlParams:p_urlParams,
                validator:options.validator,
                onSelect:options.alSeleccionar
            });

			tree.init();
			
			return element;
		}
	};
	$.fn.SiafTree = function(method) {
		// Method calling logic
		if (methods[method]) {
			return methods[method].apply(this, Array.prototype.slice.call(
					arguments, 1));
		} else if (typeof method === 'object' || !method) {
			return methods.init.apply(this, arguments);
		} else {
			$.error('Method ' + method + ' does not exist on jQuery.tooltip');
		}

	};

})(jQuery);

/*CAMPO NUMERICO*/
(function($) {

	var methods = {
		init : function(options) {
			var element = $(this);
			
			$(element).css('text-align','right');
			$(element).bind('keyup.numberFormat', function() {
				var ev = '48,49,50,51,52,53,54,55,56,57,188,110'.indexOf(event.keyCode + '');

				if (ev > -1) {
					var a = addCommas($(this).val());
					$(this).val(a);
				}
				
				// $('#MyT').append($('<tr><td>' + $('#myTest').val()+
				// '</td></tr>'));
			});
			
			var a = addCommas($(this).val());
			$(this).val(a);
		}
	};

	$.fn.SiafNumericFormat = function(method) {
		// Method calling logic
		if (methods[method]) {
			return methods[method].apply(this, Array.prototype.slice.call(
					arguments, 1));
		} else if (typeof method === 'object' || !method) {
			return methods.init.apply(this, arguments);
		} else {
			$.error('Method ' + method + ' does not exist on jQuery.tooltip');
		}

	};

})(jQuery);

/*SEPARAR PUNTOS*/
function addCommas(nStr) {
	/*
	 * /\./g
	 * */
	nStr = nStr.replace(',', '');
	nStr += '';
	x = nStr.split('.');
	x1 = x[0];
	x2 = x.length > 1 ? '.' + x[1] : '';
	var rgx = /(\d+)(\d{3})/;
	
	while (rgx.test(x1)) {
		x1 = x1.replace(rgx, '$1' + ',' + '$2');
	}
	/*
	 * 
	nStr = nStr.replace('.', '');
	nStr += '';
	x = nStr.split(',');
	x1 = x[0];
	x2 = x.length > 1 ? ',' + x[1] : '';
	var rgx = /(\d+)(\d{3})/;
	
	while (rgx.test(x1)) {
		x1 = x1.replace(rgx, '$1' + '.' + '$2');
	}
	return x1 + x2;
	*/
	//return nStr;
	return x1 + x2;
	
}

/*SIAF SUB FORM PLUGIN*/
(function($) {
		var methods = {
			init : function(options) {
				var element = $(this);
				var data = new Object();

				data.options = options;
				
				element.data('data',data);
				
				$(element).css('display','none');
				
				return element;
			},
			open : function(param0,param1) {
				
				
				var element = $(this);
				data = element.data('data');
				
				
					
				var options = data.options;
				
				if (options != null){
					
					if (options.reglas != null){
						var index = 0;
						
						for (index in options.reglas){
							
							var regla = options.reglas[index];
							
							var val = '';
							
							if (param1 != null){
								val = $(':input:eq('+index+')',param1).val();	
							}
							
							$(regla.campoDestino).val(val);
						}
					}
				}
				if (options.alAbrir != null){
					options.alAbrir();
				}
				if (parent != null)
					parent.showDialog(element,options.acciones[param0]);
				else
					showDialog(element,options.acciones[param0]);
				
				return element;
			}
		};
		$.fn.SiafSubForm = function(method) {
			// Method calling logic
			if (methods[method]) {
				return methods[method].apply(this, Array.prototype.slice.call(
						arguments, 1));
			} else if (typeof method === 'object' || !method) {
				return methods.init.apply(this, arguments);
			} else {
				$.error('Method ' + method + ' does not exist on jQuery.tooltip');
			}
		};
})(jQuery);




/* Arbol Class */
function SiafTreeView(params,me){
    me = this;
                
    this.init = function(){
                    
        if (params.validator != null){
            if (!params.validator()){
                // no paso validador
                return;
            }
        }
        
        me.$dialog = $('<div title="'+params.title+'" ></div>');
                
        me.$dialog.dialog(
        {
            modal:true,
            width:600,
            height:400,
            buttons:{Aceptar:me.aceptar,Cancelar:me.cancelar},
            close:function(){me.$dialog.dialog('destroy')}
        });
                    // call tree with ajax
                            
        me.sendJQueryAjax(params.url,me.show);
        me.img = $('<img src="../img/ajax-loader2.gif"></img>');
        $('.ui-dialog-title').append(me.img);
    }// end init

    this.cancelar = function(){
        me.$dialog.dialog('destroy');
    }
                
    this.aceptar = function(){
        if (me.selected != null){
            if (params.onSelect != null){
                
                            params.onSelect(me.selected);
                            
                            if (params.closeOnSelect){
                                me.$dialog.dialog('destroy');
                            }
                        }
                    }
                }
                
                this.show = function(obj){
                    
                   
                    
                    me.div = $('<div id="tree" style="width:100%;"></div>');
                    me.$dialog.append(me.div);
                    me.ul = $('<ul style="overflow:visible;border:1px solid red;"></ul>');
                    me.div.append(me.ul);
                    $("#tree",me.$dialog).dynatree({
                        checkbox: true,
                        autoFocus : true,
                        selectMode: 1,
                        fx : {height: "toggle", duration: 200},
                        onQuerySelect: function(select, node) {
                            try{
                                if( node.data.isFolder ){
                                    if (params.selectFolder != null)
                                        return params.selectFolder;
                                    return true;
                                }                            
                            }catch(ex){
                                log.error(ex.message);
                            }
                            return true;
			            },
                        onActivate: function(node) {
            			},
                        onSelect  : function(select, node) {
                            var selectedNodes = null;
                            try{
                                
                                selectedNodes = node.tree.getSelectedNodes();
                                
                                var selectedKeys = $.map(selectedNodes, function(node){
                                    return node.data.nodeData;
                                });
                                
                                var obj = eval('(' + selectedKeys + ')');
                                
                                me.selected = obj;
                                
                            }catch(ex){
                                throw ex;
                            }
                        },
                        onFocus: function(node,nodeSpan){
                                /* si es hoja, no aplica */
                                
                                if (!node.data.isFolder){
                                    return;
                                }
                                
                                if (node.data.load == true){
                                    return;
                                }
                                
                                var img = $('<img src="../img/ajax-loader2.gif"></img>');
                                $('.ui-dialog-title').append(img);
                                
                                node.data.load = true;
                                
                                setTimeout(
                                        function(){
                                            me.sendJQueryAjax(params.url+'&PARENT='+encodeURIComponent(node.data.value),
                                                function(param){
                                                    me.loadNode(node,param.node);
                                                    node.toggleExpand();
                                                    img.remove();
                                                }
                                            )
                                        },100);
                        }
                    });
                    
                    var rootNode = $("#tree",me.$dialog).dynatree("getRoot");
                    
                    var childNode = rootNode.addChild({
                        load:(obj.node.lazy=='false'),
                        nodeData : obj.node.nodeData,
                        value : obj.node.value,
                        title: obj.node.label,
                        tooltip: obj.node.label,
                        isFolder: true
                    });
                    
                    me.loadNode(childNode,obj.node);
                    
                    if (childNode.data.load == true){
                        childNode.toggleExpand();
                    }
                    if (me.img != null){
                        $(me.img).remove();
                        me.img = null;
                    }
                    
                   
                }
                
                this.sendJQueryAjax = function(url,callback){
                
                    var vurl = url;
                    var paramName = null;
                    var paramValue = null;
                    
                    if (params.urlParams != null){
                        for (paramName in params.urlParams){
                        
                            paramValue = params.urlParams[paramName];
                            
                            if (vurl.indexOf("?") != -1){
                                vurl = vurl + "&";
                            }else{
                                vurl = vurl + "?";
                            }
                            
                            vurl = vurl + paramName + "=" + paramValue;
                        }
                    }
                    sendJQueryAjax(vurl,callback)
                }
                
                this.loadNode = function(parentNode,obj){
                    if (obj.node == null)
                        return;
                        
                    if (obj.node.length == null){
                                /* no es un array, es hijo único */
                        var vload = !(obj.node.lazy=='true');
                        
                        var childNode = parentNode.addChild({
                            load:vload,
                            nodeData : obj.node.nodeData,
                            value: obj.node.value,
                            title: obj.node.label,
                            tooltip: obj.node.label,
                            isFolder: obj.node.nodeType == 'FOLDER'
                            
                        });
                        
                        if (obj.node.node != null)
                            me.loadNode(childNode,obj.node);
                        
                    }else{
                                /* array, lista de hijos */
                        var i = 0;
                                
                        for (i = 0;i<obj.node.length;i++){
                            
                            var vload = !(obj.node[i].lazy=='true');
                            
                            var childNode = parentNode.addChild({
                                load:vload,
                                nodeData : obj.node[i].nodeData,
                                value: obj.node[i].value,
                                title: obj.node[i].label,
                                tooltip: obj.node[i].label,
                                isFolder: obj.node[i].nodeType == 'FOLDER'
                            });
                            
                            me.loadNode(childNode,obj.node[i]);
                                
                                
                            // me.loadNode(childNode,obj.node[i].node);
                        }
                        
                    }
                }// end function
            }// end class def

function showDialog(obj,accion){
    var dialog = $(obj).clone();
    $(dialog).appendTo('body');
// $(dialog).css('display','inline');
    
 $(dialog).dialog({
	 width:600,
	 height:400,
	 modal:true,
	 close:function(){
	 /* destruir al salir */
		 $('.DatePicker',dialog).each(
		 function(){
	 // $(this).datepicker('destroy');
			 $(this).css('border','1px solid red');
		 }
	 );
		 
	 $(dialog).dialog('destroy');
	 	$(dialog).remove();
	 // $(dialog).dialog('open');
	 },
	 buttons:
	 {
		 'Aceptar':
			 	function(){
			 		/* iterate */
					 var index = 0;
					 
					 $(':input',obj).each(
					         function(){
					             $(':input:eq('+index+')',obj).val($(':input:eq('+index+')',dialog).val());
					             index++;
					         }
					     );
			 		$(dialog).dialog('close');
			 		accion();
		 		},
		 'Cancelar':function(){
			 $(dialog).dialog('close');
		 }
	 }
 });


 
 
 $('.DatePicker',dialog).each(
		 function(){
			 var input = $('<input type="text"></input>');
			 var id = $(this).prop('id');
			 
			 $(this).parent().append(input);
			 $(this).remove();
			 
			 $('.ui-datepicker-trigger',input.parent()).remove();
			 
			 $(input).datepicker({
				 showOn: "button",
				 buttonImage: "../img/calendario/calendar.gif",
				 buttonImageOnly: true,
                 changeMonth: true,
			     changeYear: true
			 });
			 //$(input).prop('id',id);
			 
// $(input).datepicker();
		 }
 );
 
 
 var index = 0;
 
 $(':input',obj).each(
         function(){
             $(':input:eq('+index+')',dialog).val($(':input:eq('+index+')',obj).val());
             index++;
         }
     );
 
 
 applyPatch(dialog);
 
 
}



/* InicializaciÃ³n en espaÃ±ol para la extensiÃ³n 'UI date picker' para jQuery. */
/* Traducido por Vester (xvester@gmail.com). */
jQuery(function($){
    if($.datepicker!=null){
	$.datepicker.regional['es'] = {
		closeText: 'Cerrar',
		prevText: '&#x3c;Ant',
		nextText: 'Sig&#x3e;',
		currentText: 'Hoy',
		monthNames: ['Enero','Febrero','Marzo','Abril','Mayo','Junio',
		'Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre'],
		monthNamesShort: ['Ene','Feb','Mar','Abr','May','Jun',
		'Jul','Ago','Sep','Oct','Nov','Dic'],
		dayNames: ['Domingo','Lunes','Martes','Mi&eacute;rcoles','Jueves','Viernes','S&aacute;bado'],
		dayNamesShort: ['Dom','Lun','Mar','Mi&eacute;','Juv','Vie','S&aacute;b'],
		dayNamesMin: ['Do','Lu','Ma','Mi','Ju','Vi','S&aacute;'],
		weekHeader: 'Sm',
		dateFormat: 'dd/mm/yy',
		firstDay: 1,
		isRTL: false,
		showMonthAfterYear: false,
		yearSuffix: ''};
	$.datepicker.setDefaults($.datepicker.regional['es']);
	}
});

function createWindow(tipo, modal, restricciones, params) {
    var wind = new SiafPopupWindow();

    wind.div = createAbsoluteDiv('100', '100', '400px', 'auto');

    if (restricciones == null)
        restricciones = CONSTANTES.WINDOW_SHOW_HEADER | CONSTANTES.WINDOW_SHOW_BODY | CONSTANTES.WINDOW_SHOW_FOOTER;

    var restrictionsInt = restricciones;

    if (modal) {
        wind.showModal();
    } else {
        //
        wind.show();
    }
    wind.div.className = 'ModalFramecito'

    if (parseInt(restrictionsInt & CONSTANTES.WINDOW_SHOW_HEADER) != CONSTANTES.ZERO) {

        wind.header = new Object();

        wind.header.data = createDiv('ModalTitle');
        wind.header.title = createDiv('ModalTextTitle');

        wind.header.closeButton = createDiv('ModalTitleClose');
        wind.header.titulo = createLabel('Ventana Modal Siges');
        wind.header.title.appendChild(wind.header.titulo);

        var iconImg = createImage('../img/icon.gif')
        iconImg.className = 'ModalIcon';
        wind.header.iconImg = iconImg;
        wind.header.data.appendChild(wind.header.iconImg);
        wind.header.data.appendChild(wind.header.title);

        var cerrarImg = createImage('../img/cerrar.gif');
        cerrarImg.className = 'ModalCloseIcon';
        wind.header.data.appendChild(cerrarImg);
        addEvent(cerrarImg, 'onclick', wind.close);

        wind.div.appendChild(wind.header.data);

    }
    if (parseInt(restrictionsInt & CONSTANTES.WINDOW_SHOW_BODY) != CONSTANTES.ZERO) {


        wind.body = new Object();

        /* wind.trBody = createRow(wind.table,wind.table.rows.length);
        wind.body.data = createCell(wind.trBody,0,'ModalInfo');
        wind.body.data.colSpan=3;*/

        if (WINDOW_TIPO.MENSAJES == tipo) {
            wind.body.div = createDiv();
            wind.body.data = wind.body.div;
            wind.body.div.className = 'ModalInfo';

            wind.body.imagen = createImage('../img/warn32.png');
            wind.body.mensaje = createDiv();
            wind.body.mensajeLbl = createLabel('');
            wind.body.detalles = createDiv();
            wind.body.detalles.className = 'ModalInfoDetails';

            wind.body.detallesLbl = createLabel('Observaciones saslkajskajskljalskjañsjaklñs asjaklñsjlñak sklñajsklñajsñklajsa sajslñkaj sasjklñajsklñajñ');

            //wind.body.data.appendChild(wind.body.div);
            wind.body.div.appendChild(wind.body.imagen);

            wind.body.div.appendChild(wind.body.mensaje);
            wind.body.div.appendChild(wind.body.detalles);

            wind.body.mensaje.appendChild(wind.body.mensajeLbl);
            wind.body.detalles.appendChild(wind.body.detallesLbl);

            wind.div.appendChild(wind.body.data);
        } else {
            wind.body.data = createDiv('ModalBody');
            wind.body.div = wind.body.data;
            wind.div.appendChild(wind.body.data);
        }
    }
    if (parseInt(restrictionsInt & CONSTANTES.WINDOW_SHOW_FOOTER) != CONSTANTES.ZERO) {
        wind.footer = new Object();
        wind.footer.data = createDiv('ModalBotonera');
        wind.div.appendChild(wind.footer.data);
    }



    if (params != null) {
        if (params.width != null) {
            wind.div.style.width = params.width;
        }
        if (params.height != null) {
            wind.div.style.height = params.height;
        }

        if (restrictionsInt & CONSTANTES.WINDOW_SHOW_HEADER != CONSTANTES.ZERO) {
            if (params.title != null) {
                wind.header.titulo.innerHTML = params.title;
            }
        }
        if (restrictionsInt & CONSTANTES.WINDOW_SHOW_BODY != CONSTANTES.ZERO) {
            if (params.bodyHeight != null) {
                wind.body.data.style.height = params.bodyHeight;
            }
        }
        if (restrictionsInt & CONSTANTES.WINDOW_SHOW_FOOTER != CONSTANTES.ZERO) {
            if (params.hideFooter == true) {
                wind.footer.data.style.display = 'none';
            }
        }
    }
    return wind;
}

function SiafPopupWindow(me) {
    me = this;
    this.setCloseListener = function (closeListener) {
        me.closeListener = closeListener;
    };
    this.close = function () {
        if (me.closeListener != null) {
            if (me.closeListener() == true) {
                me.hide();
            }
        } else {

        }

    };
    this.clickX = function () {
        if (me.clickXCallback != null) {
            me.clickXCallback();
        }
    };
    this.hide = function () {
        if (me.modal != null) {
            me.modal.hide();
        }
        me.parent.removeChild(me.div);
    }
    this.setVisible = function (param) {
        me.div.style.display = 'block';
        if (param == false) {
            me.div.style.display = 'none';
        }
        if (me.modal != null) {
            me.modal.setVisible(param)
        }
    };
    this.show = function (parent) {
        if (parent == null)
            parent = getBody();
        me.parent = parent;
        parent.appendChild(me.div);
    };
    this.showModal = function (parent) {
        me.modal = new SiafModal();
        me.modal.show();
        me.show(parent);
    };
    this.centrar = function (parent) {
        centrarDiv(me.div);
    };
}

function createAbsoluteDiv(x, y, w, h) {
    var div = document.createElement('div');
    div.style.position = 'absolute'
    div.style.left = x;
    div.style.top = y;
    div.style.width = w;
    div.style.height = h;
    return div;

}

SiafModal.prototype.div = null;
SiafModal.prototype.iframe = null;
SiafModal.prototype.modalTapa1 = null;
SiafModal.prototype.modalTapa2 = null;
SiafModal.prototype.div = null;
SiafModal.prototype.parentDiv = null;

function SiafModal(parentDiv, me) {
    me = this;
    this.parentDiv = parentDiv;

    me.show = function () {
        /*var tapa1 = document.getElementById(CONSTANTES.div_ajax_tapa1);
        var tapa2 = document.getElementById(CONSTANTES.div_ajax_tapa2);*/

        try {
            me.modalTapa1 = createDiv();
            me.modalTapa2 = createDiv();

            var wh = SiafWindowUtil.getPageSizeWithScroll();

            getBody().appendChild(me.modalTapa1);
            getBody().appendChild(me.modalTapa2);

            me.modalTapa1.className = CONSTANTES.STYLES.MODAL_TAPA1;
            me.modalTapa2.className = CONSTANTES.STYLES.MODAL_TAPA2;

            me.modalTapa1.style.top = '0px';
            me.modalTapa2.style.left = '0px';

            me.modalTapa1.style.height = wh.height + 'px';
            me.modalTapa1.style.width = wh.width + 'px';

            me.modalTapa2.style.height = wh.height + 'px';
            me.modalTapa2.style.width = wh.width + 'px';

            if (me.parentDiv != null) {
                me.modalTapa1.style.zIndex = parseInt(me.parentDiv.style.zIndex) + 1;
                me.modalTapa2.style.zIndex = parseInt(me.parentDiv.style.zIndex) + 2;
            }
            me.modalTapa1.style.display = 'block';
            me.modalTapa2.style.display = 'block';

        } catch (ex) {
            alert(ex);
        }
    };
    this.hide = function () {
        getBody().removeChild(me.modalTapa2);
        getBody().removeChild(me.modalTapa1);
    };
    this.setVisible = function (param) {
        me.modalTapa1.style.display = 'block';
        me.modalTapa2.style.display = 'block';

        if (param == false) {
            me.modalTapa1.style.display = 'none';
            me.modalTapa2.style.display = 'none';
        }
    };
}


//comienza el código del plugin ticker de noticias
(function ($) {
    //definición de las opciones por defecto
    var opciones = {
        retardo: 2000,
        tiempoAnimacion: 500,
        funcionAnimacion: '',
        animacion: true,
        elementoActual: 0,
        elementosLista: '',
        listaNovedades: ''
    }
    //el nombre del plugin se define aquí
    $.fn.dwdinanews = function (opt) {
        //se mezclan las opciones por defecto con las opciones recibidas al invocar el plugin
        jQuery.extend(opciones, opt);

        //para cada elemento donde se invoque el plugin
        this.each(function () {
            //accedemos a la lista LU que hay dentro del contenedor
            opciones.listaNovedades = $(this).children("ul");
            //accedemos a un array de los elementos LI que hay en la lista
            opciones.elementosLista = opciones.listaNovedades.children("li");
            //invocamos al plugin timer para realizar los retardos entre noticia y noticia
            $.timer(opciones.retardo, function (timer) {
                //modificamos la posición de la lista UL para producir la animación
                if (opciones.animacion && opciones.elementosLista.length>0) {
                    //incrementamos el elemento a mostrar, sin salirnos del rango de LIs
                    opciones.elementoActual = (opciones.elementoActual + 1) % opciones.elementosLista.length;

                    opciones.listaNovedades.animate({
                        top: "-" + $(opciones.elementosLista[opciones.elementoActual]).position().top + "px"
                    }, opciones.tiempoAnimacion, opciones.funcionAnimacion)
                }
            });
        });
        return this;
    };

    $.fn.pausar = function (){
        opciones.animacion = !opciones.animacion;
    };

    $.fn.right = function () {
        opciones.animacion = false;
        if (opciones.elementosLista.length > 0) {
            //incrementamos el elemento a mostrar, sin salirnos del rango de LIs
            opciones.elementoActual = (opciones.elementoActual + 1) % opciones.elementosLista.length;
            //modificamos la posición de la lista UL para producir la animación
            opciones.listaNovedades.animate({
                top: "-" + $(opciones.elementosLista[opciones.elementoActual]).position().top + "px"
            }, opciones.tiempoAnimacion, opciones.funcionAnimacion)
        }
    };

    $.fn.left = function () {
        opciones.animacion = false;
        if (opciones.elementosLista.length > 0) {
            //incrementamos el elemento a mostrar, sin salirnos del rango de LIs
            if (opciones.elementoActual == 0)
                opciones.elementoActual = opciones.elementosLista.length
            opciones.elementoActual = (opciones.elementoActual - 1) % opciones.elementosLista.length;
            //modificamos la posición de la lista UL para producir la animación
            opciones.listaNovedades.animate({
                top: "-" + $(opciones.elementosLista[opciones.elementoActual]).position().top + "px"
            }, opciones.tiempoAnimacion, opciones.funcionAnimacion)
        }
    };
})(jQuery);

// t: current time, b: begInnIng value, c: change In value, d: duration
jQuery.easing['jswing'] = jQuery.easing['swing'];

jQuery.extend(jQuery.easing,
{
    def: 'easeOutQuad',
    swing: function (x, t, b, c, d) {
        //alert(jQuery.easing.default);
        return jQuery.easing[jQuery.easing.def](x, t, b, c, d);
    },
    easeInQuad: function (x, t, b, c, d) {
        return c * (t /= d) * t + b;
    },
    easeOutQuad: function (x, t, b, c, d) {
        return -c * (t /= d) * (t - 2) + b;
    },
    easeInOutQuad: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return c / 2 * t * t + b;
        return -c / 2 * ((--t) * (t - 2) - 1) + b;
    },
    easeInCubic: function (x, t, b, c, d) {
        return c * (t /= d) * t * t + b;
    },
    easeOutCubic: function (x, t, b, c, d) {
        return c * ((t = t / d - 1) * t * t + 1) + b;
    },
    easeInOutCubic: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t + 2) + b;
    },
    easeInQuart: function (x, t, b, c, d) {
        return c * (t /= d) * t * t * t + b;
    },
    easeOutQuart: function (x, t, b, c, d) {
        return -c * ((t = t / d - 1) * t * t * t - 1) + b;
    },
    easeInOutQuart: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t * t + b;
        return -c / 2 * ((t -= 2) * t * t * t - 2) + b;
    },
    easeInQuint: function (x, t, b, c, d) {
        return c * (t /= d) * t * t * t * t + b;
    },
    easeOutQuint: function (x, t, b, c, d) {
        return c * ((t = t / d - 1) * t * t * t * t + 1) + b;
    },
    easeInOutQuint: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t * t * t + 2) + b;
    },
    easeInSine: function (x, t, b, c, d) {
        return -c * Math.cos(t / d * (Math.PI / 2)) + c + b;
    },
    easeOutSine: function (x, t, b, c, d) {
        return c * Math.sin(t / d * (Math.PI / 2)) + b;
    },
    easeInOutSine: function (x, t, b, c, d) {
        return -c / 2 * (Math.cos(Math.PI * t / d) - 1) + b;
    },
    easeInExpo: function (x, t, b, c, d) {
        return (t == 0) ? b : c * Math.pow(2, 10 * (t / d - 1)) + b;
    },
    easeOutExpo: function (x, t, b, c, d) {
        return (t == d) ? b + c : c * (-Math.pow(2, -10 * t / d) + 1) + b;
    },
    easeInOutExpo: function (x, t, b, c, d) {
        if (t == 0) return b;
        if (t == d) return b + c;
        if ((t /= d / 2) < 1) return c / 2 * Math.pow(2, 10 * (t - 1)) + b;
        return c / 2 * (-Math.pow(2, -10 * --t) + 2) + b;
    },
    easeInCirc: function (x, t, b, c, d) {
        return -c * (Math.sqrt(1 - (t /= d) * t) - 1) + b;
    },
    easeOutCirc: function (x, t, b, c, d) {
        return c * Math.sqrt(1 - (t = t / d - 1) * t) + b;
    },
    easeInOutCirc: function (x, t, b, c, d) {
        if ((t /= d / 2) < 1) return -c / 2 * (Math.sqrt(1 - t * t) - 1) + b;
        return c / 2 * (Math.sqrt(1 - (t -= 2) * t) + 1) + b;
    },
    easeInElastic: function (x, t, b, c, d) {
        var s = 1.70158; var p = 0; var a = c;
        if (t == 0) return b; if ((t /= d) == 1) return b + c; if (!p) p = d * .3;
        if (a < Math.abs(c)) { a = c; var s = p / 4; }
        else var s = p / (2 * Math.PI) * Math.asin(c / a);
        return -(a * Math.pow(2, 10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p)) + b;
    },
    easeOutElastic: function (x, t, b, c, d) {
        var s = 1.70158; var p = 0; var a = c;
        if (t == 0) return b; if ((t /= d) == 1) return b + c; if (!p) p = d * .3;
        if (a < Math.abs(c)) { a = c; var s = p / 4; }
        else var s = p / (2 * Math.PI) * Math.asin(c / a);
        return a * Math.pow(2, -10 * t) * Math.sin((t * d - s) * (2 * Math.PI) / p) + c + b;
    },
    easeInOutElastic: function (x, t, b, c, d) {
        var s = 1.70158; var p = 0; var a = c;
        if (t == 0) return b; if ((t /= d / 2) == 2) return b + c; if (!p) p = d * (.3 * 1.5);
        if (a < Math.abs(c)) { a = c; var s = p / 4; }
        else var s = p / (2 * Math.PI) * Math.asin(c / a);
        if (t < 1) return -.5 * (a * Math.pow(2, 10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p)) + b;
        return a * Math.pow(2, -10 * (t -= 1)) * Math.sin((t * d - s) * (2 * Math.PI) / p) * .5 + c + b;
    },
    easeInBack: function (x, t, b, c, d, s) {
        if (s == undefined) s = 1.70158;
        return c * (t /= d) * t * ((s + 1) * t - s) + b;
    },
    easeOutBack: function (x, t, b, c, d, s) {
        if (s == undefined) s = 1.70158;
        return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
    },
    easeInOutBack: function (x, t, b, c, d, s) {
        if (s == undefined) s = 1.70158;
        if ((t /= d / 2) < 1) return c / 2 * (t * t * (((s *= (1.525)) + 1) * t - s)) + b;
        return c / 2 * ((t -= 2) * t * (((s *= (1.525)) + 1) * t + s) + 2) + b;
    },
    easeInBounce: function (x, t, b, c, d) {
        return c - jQuery.easing.easeOutBounce(x, d - t, 0, c, d) + b;
    },
    easeOutBounce: function (x, t, b, c, d) {
        if ((t /= d) < (1 / 2.75)) {
            return c * (7.5625 * t * t) + b;
        } else if (t < (2 / 2.75)) {
            return c * (7.5625 * (t -= (1.5 / 2.75)) * t + .75) + b;
        } else if (t < (2.5 / 2.75)) {
            return c * (7.5625 * (t -= (2.25 / 2.75)) * t + .9375) + b;
        } else {
            return c * (7.5625 * (t -= (2.625 / 2.75)) * t + .984375) + b;
        }
    },
    easeInOutBounce: function (x, t, b, c, d) {
        if (t < d / 2) return jQuery.easing.easeInBounce(x, t * 2, 0, c, d) * .5 + b;
        return jQuery.easing.easeOutBounce(x, t * 2 - d, 0, c, d) * .5 + c * .5 + b;
    }
});

jQuery.timer = function (interval, callback) {
    var interval = interval || 100;

    if (!callback)
        return false;

    _timer = function (interval, callback) {
        this.stop = function () {
            clearInterval(self.id);
        };

        this.internalCallback = function () {
            callback(self);
        };

        this.reset = function (val) {
            if (self.id)
                clearInterval(self.id);

            var val = val || 100;
            this.id = setInterval(this.internalCallback, val);
        };

        this.interval = interval;
        this.id = setInterval(this.internalCallback, this.interval);

        var self = this;
    };

    return new _timer(interval, callback);
};