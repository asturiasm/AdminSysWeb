/*
Plugin creado para mostrar el estado de la politica de Nomina Presupuesto por Resultado (PpR)
lgonzalez - 
*/
(function ($) {
    $.fn.estado = function () {
        this.append("<p></p>");
        //this.css("background-color", "blue");
        //return this;
    };
    $.fn.cambiarFormatoRadNumeric = function () {
        var monto = this.val();

        if (monto != undefined & monto != null & monto != "") {
            var convMonto = monto.toString();
            var reemplazo = /,/g
            var nuevoMonto = parseFloat(convMonto.replace(reemplazo, ""));
            return nuevoMonto;
        }
        else {
            return 0;
        }
    };
    //UTILIZAR ESTA FUNCION SI SE ESTA UTILIZANDO LABEL
    $.fn.agregarFormatoMoneda = function () {
        var monto = this.text();
        var formato = (parseFloat(monto, 10)
            .toFixed(2)
            .replace(/(\d)(?=(\d{3})+\.)/g, "$1,")
            .toString());
        return this.text(formato);
    }
    //UTILIZAR ESTA FUNCION SI SE ESTA USANDO RADTEXTBOX
    $.fn.agregarFormatoMonedaBox = function () {
        var monto = this.val();
        if (monto != undefined & monto != null & monto != "") {
            var formato = (parseFloat(monto, 10)
                .toFixed(2)
                .replace(/(\d)(?=(\d{3})+\.)/g, "$1,")
                .toString());
            return this.val(formato);
        } else {
            return 0;
        }
    }
    $.fn.desabilitarControlesTelerik = function () {
        this.find("input:text").each(function () {
            $(this).attr("disabled", "disabled");
        });

        this.find("a").each(function () {
            $(this).hide();
        });

        this.find("table").each(function () {
            $(this).addClass("rcbDisabled");
        });

        this.find("td.rcbArrowCell").each(function () {
            $(this).removeClass();
        });

        this.find("ul.rcbList").each(function () {
            $(this).remove();
        });

        this.find("textarea").each(function () {
            $(this).attr("disabled", "disabled");
        });

        this.find("#ContenidoPagina_grabar").hide();
    };
}(jQuery));