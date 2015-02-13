
//listener 

var initListeners = new Array();

function addInitListener(callback){
    initListeners.push(callback);
}
function initPage(){
    try{
         /*startPage es un metodo que puede definirse en la pagina, y en este momento va ser llamado*/
        if(startPage != null)
            startPage();
    }catch(ex){
        throw ex;
    }
    var i=0;
    for (i=0;i<initListeners.length;i++){
        initListeners[i]();/*call to init listeners*/
    }
    try{
        //DoClock();
        /*al cargar muestra popup a partir los campos*/
        //mostrarPopup();
    }catch(ex){
        throw ex;
    }
}
//init page
/*jQuery(document).ready(function() {
    initPage();
});*/
