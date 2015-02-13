// JScript File

function leerMenu(pDiv,pMenu){
    try{
        var text = document.getElementById(pMenu).innerHTML; 
	    var mm = new MainMenu();	
	    mm.divId =  pDiv;
	    mm.element = loadXMLString(text);
	    mm.imprimir();
    }
    catch(ex){
        alert(ex);
        throw ex;
    }
	
}
var MENU = new Object();
MENU.MENU = "menu";
MENU.LABEL = "label";
MENU.ITEM = "item";
MENU.VALUE = "value";

MainMenu.prototype.divId = ''
MainMenu.prototype.div = ''
MainMenu.prototype.element = null;
MainMenu.prototype.items = null;
MainMenu.prototype.itemSelected = null;

{
	if (window.ActiveXObject){
		MENU.MENU = "MENU";
		MENU.LABEL = "LABEL";
		MENU.ITEM = "ITEM";
		MENU.VALUE = "VALUE";
	}
}
function MainMenu(me){
	
	this.imprimir = function(){
		me = this;
		var tabs = getChildNodes(this.element.getElementsByTagName(MENU.MENU)[0]);
		this.items = new Array();
		me.div = findElement(this.divId);
		for (var i=0;i<tabs.length ;i++ )
		{
			var node = loadNode(tabs[i]);
			var item = new MainMenuItem();
			item.mainMenu = this;
			this.items.push(item);
			item.div = createDiv();
			item.div.appendChild(createLabel(node[MENU.LABEL]));
			item.div.className ='main_menu_item';
			me.div.appendChild(item.div);
			item.title = node[MENU.LABEL];
			item.parentPopup = me;
			item.node = node;
			item.tipo = 1;
			item.configure();
			
		}
	};
	this.mantener = function(){
	   
	}
	this.esconder = function(){
	   
	}
	this.seleccionar = function(){
	   
	}
	this.deseleccionar = function(){
	   
	}
	this.preview = function(){
	   
	}
}
MainMenuItem.prototype.configure = null;
MainMenuItem.prototype.mainMenu = null;
MainMenuItem.prototype.div = null;
MainMenuItem.prototype.me = null;
MainMenuItem.prototype.popup = null;
MainMenuItem.prototype.parentPopup = null;
MainMenuItem.prototype.title = null;
MainMenuItem.prototype.tab = null;
MainMenuItem.prototype.node = null;
MainMenuItem.prototype.timer = null;
MainMenuItem.prototype.tipo = null;

function MainMenuItem(me){

	this.configure = function(){
		me = this;
		/*si tengo un sub menu agregar*/
		
		if (this.node[MENU.MENU] != null)
		{
			this.popup = new PopupMenu();
			this.popup.menuItem = this;
			this.popup.configure();
			
		}else{
			me.div.style.backgroundPosition = '-2000px -2000px';
		}
		addEvent(me.div,'onmouseover',this.mouseOver);
		addEvent(me.div,'onmouseout',this.mouseOut);
		addEvent(me.div,'onclick',this.click);
	};
	
	this.mouseOver = function(){
	    me.div.className = 'main_menu_item_selected';
	    me.parentPopup.mantener();
	    
	    if (me.popup != null){
	        me.popup.preview();
	    }else{
	        me.div.style.backgroundPosition = '-2000px -2000px';
	    }
        me.parentPopup.seleccionar(me);
        
	};
	this.click = function(){
	    /*si tengo popup mostrar sus hijos*/
	    if (me.popup != null)
		{
		    me.parentPopup.mantener();
	        if (me.popup != null){
	            me.popup.mantener();
	        }
            me.parentPopup.seleccionar(me);
            me.div.className = 'main_menu_item_selected';
		}else{
		    /*mostrar y esconder*/
		    browserManager.open(me.node[MENU.VALUE]);
			me.parentPopup.deseleccionar(me);
		}
	};
	this.mouseOut = function(){
	    me.parentPopup.deseleccionar(me,true);
	    if (me.popup != null){
	        me.popup.esconder();
	    }
	    me.div.className = 'main_menu_item';
	};
	
	
	
}
PopupMenu.prototype.x = null;
PopupMenu.prototype.y = null;
PopupMenu.prototype.menuItem = null;
PopupMenu.prototype.div = null;
PopupMenu.prototype.sub = null;
PopupMenu.prototype.items = null;
PopupMenu.prototype.timer = null;
PopupMenu.prototype.parentPopup = null;
PopupMenu.prototype.itemSelected = null;
PopupMenu.prototype.visible = null;

function PopupMenu(me){

	this.configure = function(){
		this.div = createDiv();
		this.div.className = 'main_menu_items_float';
		getBody().appendChild(this.div);
		me = this;

		this.parentPopup = this.menuItem.parentPopup;
		try{
			if (this.menuItem.node[MENU.MENU] != null)
			{
				var menuItems = getChildNodes(this.menuItem.node[MENU.MENU]);
				this.items = new Array();

				for (var i=0;i<menuItems.length ;i++ )
				{
					var node = loadNode(menuItems[i]);
					var item = new MainMenuItem();
					item.parentPopup = me;
					this.items.push(item);
					item.div = createDiv();
					item.div.className = 'main_menu_item';
					item.div.appendChild(createParagraph(node[MENU.LABEL]));
					this.div.appendChild(item.div);
					item.title = node[MENU.LABEL];
					item.node = node;
					item.tipo = 2;
					item.configure();
				}
			}	
		}catch(ex){
			alert(ex);
			throw ex;
		}
	};
	this.show = function(){
	        if (me.menuItem.tipo == 1)
		    {
			    me.div.style.left = getX(me.menuItem.div)+'px';
			    me.div.style.top = getY(me.menuItem.div)+getHeight(me.menuItem.div)+'px';
		    }else{
			    me.div.style.left = getX(me.menuItem.div)+getWidth(me.menuItem.div)+'px';
			    me.div.style.top = getY(me.menuItem.div)+'px';
		    }
		    me.div.style.display = 'block';
		    me.visible = true;
		    
	};
	this.hide = function(){
        me.div.style.display = 'none';
        me.visible = false;
	};
	
	this.mantener = function(itemSelected){
	    /*mostrar o mantener popup*/
	    
	    if (me.ocultarTimer != null){
            clearTimeout(me.ocultarTimer);
        }
	    if (me.mostrarTimer != null){
            clearTimeout(me.mostrarTimer);
        }
	    if (me.visible){
	        
	    }else{
	        me.mostrarTimer = setTimeout(me.show,200);
	    }
    }
    this.preview = function(){
	    me.mantener();
	    me.ocultarTimer = setTimeout(me.hide,2200);
    }
     
	/*seguir mostrando*/
	this.esconder = function(now){
	    /*esconder popup*/
	    if (me.mostrarTimer != null){
	        clearTimeout(me.mostrarTimer);
	    }
	    if (me.ocultarTimer != null){
	        clearTimeout(me.ocultarTimer);
	    }
	    if (now){
	        me.hide();
	    }else{
	        me.ocultarTimer = setTimeout(me.hide,500);
	    }
	    
	}
	this.seleccionar = function(itemSelected){
	    me.mantener();
        me.menuItem.parentPopup.seleccionar(me.menuItem);
	}
	this.deseleccionar = function(itemSelected){
	   me.esconder();
	   me.menuItem.parentPopup.deseleccionar(me.menuItem);
	}
	
	
}
 // -->


