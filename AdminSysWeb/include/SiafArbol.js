// JScript File
function leerTree(pDiv,pMenu){
    try{
        var text = document.getElementById(pMenu).innerHTML; 
	    var tree = new SiafTree();	
	    tree.divId =  pDiv;
	    tree.element = loadXMLString(text);
	    tree.imprimir();
    }
    catch(ex){
        alert(ex);
        throw ex;
    }
}

SiafTree.prototype.divId = null;
SiafTree.prototype.childs = null;
SiafTree.prototype.element = null;

function SiafTree(me){
    me = this;
    me.items = new Array();
    this.imprimir = function (){
        me = this;
		var tabs = getChildNodes(this.element.getElementsByTagName(MENU.MENU)[0]);
		
		for (var i=0;i<tabs.length ;i++ )
		{
			var node = loadNode(tabs[i]);
			var item = new SiafTreeNode();
			me.items.push(item);
			item.configure(findElement(me.divId),node,0);
			
			/*item.mainMenu = this;
			this.items.push(item);
			item.div = createDiv();
			item.div.appendChild(createLabel(node[MENU.LABEL]));
			item.div.className ='main_menu_item';
			findElement(this.divId).appendChild(item.div);
			item.title = node[MENU.LABEL];
			item.node = node;
			item.tipo = 1;
			item.configure();*/
		}
    }
}
SiafTree.prototype.divId = null;
SiafTree.prototype.divId = null;
SiafTree.prototype.childs = null;
SiafTree.prototype.element = null;
SiafTree.prototype.parentDiv = null;
SiafTree.prototype.level = null;
SiafTree.prototype.open = false;
SiafTree.prototype.node = null;

function SiafTreeNode(me){
    me = this;
        //me.configure();
    this.configure = function(parentDiv,node,level){
        me.node = node;
        me.level = level;
        me.open = false;
        me.parentDiv = parentDiv;
        me.div = createDiv();
        me.image = createImage('../img/treelast.png');
        me.divImage = createDiv();
        me.divDescription = createDiv();
        me.treeChilds = createDiv();
        
        me.div.className = 'treeNode';
        me.divImage.className = 'treeImage';
        me.divDescription.className = 'treeDescription';
        me.treeChilds.className = 'treeChilds';
        
        me.divImage.appendChild(me.image);
        
        me.div.appendChild(me.divImage);
        me.div.appendChild(me.divDescription);
        me.div.appendChild(me.treeChilds);
        
        me.parentDiv.appendChild(me.div);
        
        
        
        if (node[MENU.MENU] != null){
            var menuItems = getChildNodes(node[MENU.MENU]);
            me.childs = new Array();
            
            if (menuItems.length>0){
                me.image.src = '../img/treeopen.png';
            }
            for (var i=0;i<menuItems.length ;i++ )
            {
                var node2 = loadNode(menuItems[i]);
			    var item = new SiafTreeNode();
			    item.configure(me.treeChilds,node2,me.level+1);
			    me.childs.push(item);
            }
        }
        if (me.childs==null){
            var link = createLink(node[MENU.LABEL]);
            me.divDescription.appendChild(link);
            addEvent(link,'onclick',this.show);
        }else{
            me.divDescription.appendChild(createLabel(node[MENU.LABEL]));
            addEvent(me.image,'onclick',this.select);
        }
        me.treeChilds.style.display = 'none';
        
    };
    this.show = function (){
        browserManager.open(me.node[MENU.VALUE]);
    };
    this.select = function (){
       if (me.open)
       {
          me.treeChilds.style.display = 'none';
          me.image.src = '../img/treeopen.png';
        }else{
          me.treeChilds.style.display = 'block';
          me.image.src = '../img/treeclose.png';
       }
       me.open = !me.open;
       
    }
}

