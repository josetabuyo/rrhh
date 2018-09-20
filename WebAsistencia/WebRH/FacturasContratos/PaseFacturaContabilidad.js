
var ContenedorGrilla;
var FechaPaseContabilidad;
var lista_de_facturas;

Backend.start(function () {
    $(document).ready(function () {
        ContenedorGrilla = $("#ContenedorGrilla");
        FechaPaseContabilidad = "";
        Consultar();
    });
});


var Consultar = function () {
    ContenedorGrilla.html("");
    $("#ContenedorPersona").empty();

    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    getConsulta(function () {
        DibujarGrillaDDJJ();
        spinner.stop();
    });
}


var getConsulta = function (callback) {
    Backend.GetConsultaPaseFacturasContabilidad()
        .onSuccess(function (respuesta) {
            lista_de_facturas = respuesta;
            callback();
        })
        .onError(function (error, as, asd) {
            alertify.alert("", error);
            spinner.stop();
        });
}


var DibujarGrillaDDJJ = function () {
    var grilla;
    $("#ContenedorPersona").empty();

    grilla = new Grilla(
        [
            new Columna("", { generar: function (consulta) {
                var check = $("<input type='checkbox' />");
                if (consulta.estaSeleccionado) check.attr("checked", true);
                check.click(function () {
                    if (consulta.estaSeleccionado) {
                        check.attr("checked", false);
                        consulta.estaSeleccionado = false;
                    }
                    else {
                        check.attr("checked", true);
                        consulta.estaSeleccionado = true;
                    }
                });
                return check
            }
            }),
            new Columna("Apellido", { generar: function (consulta) { return consulta.Persona.Apellido; } }),
            new Columna("Nombre", { generar: function (consulta) { return consulta.Persona.Nombre; } }),
            new Columna("Cuil", { generar: function (consulta) { return consulta.Persona.Cuit; } }),
            new Columna("Nro de Factura", { generar: function (consulta) { return consulta.Nro_Factura; } }),
            new Columna("Monto de Factura", { generar: function (consulta) { return consulta.Monto_Factura; } }),
            new Columna("Fecha Recibida", { generar: function (consulta) { return consulta.Fecha_Recibida; } }),
            new Columna("Area", { generar: function (consulta) { return consulta.Area; } }),
            new Columna("Firmante", { generar: function (consulta) { return consulta.Firmante; } }),
            new Columna("Id Factura", { generar: function (consulta) { return consulta.Id_Factura; } })
		]);

    grilla.CargarObjetos(lista_de_facturas);
    grilla.DibujarEn(ContenedorGrilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
}



var PanelAltaDeDocumento = function (cfg) {
    var self = this;
    this.cfg = cfg;

    cfg.inputPaseContabilidad.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputPaseContabilidad.change();
            self.cfg.inputPaseContabilidad.blur();

            FechaPaseContabilidad = date;
        }
    });

}



$("#btn_Enviar").click(function () {

    var contador = 0;
    for (var i = 0; i < lista_de_facturas.length; i++) {
        if (lista_de_facturas[i].estaSeleccionado) {
            contador = contador + 1;
        }
    }
    if (contador == 0) {
        alert("Debe seleccionar una factura");
        return;
    }

    if (FechaPaseContabilidad == "") {
        alert("Ingrese la fecha de pase a contabilidad");
        return;
    }

    //alert("PASE!!");
    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.GenerarPaseFacturaContabilidad({facha_pase: FechaPaseContabilidad}, lista_de_facturas)
    .onSuccess(function (respuesta) {
        alertify.alert("", respuesta);
        spinner.stop();
        Consultar();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
    });
    

});



$("#btn_Imprimir_Nro_Pase").click(function () {

    var nropase = $("#txtPaseNro").val();
    if (nropase == "") {
        alert("Debe ingresar el Nro de Pase");
        return;
    }
    //alert("Imprimir Nro Pase " + nropase );
    Backend.GetConsultaImpresionPaseFacturasContabilidad(nropase)
        .onSuccess(function (respuesta) {
            DibujarFormularioImpresion(respuesta[0], nropase);
        })
        .onError(function (error, as, asd) {
            alertify.alert("", error);
        });
        
});


var DibujarFormularioImpresion = function (lista_de_impresion, nropase) {

    var vista_imprimir = $("<div>");

    ImprimirPase(lista_de_impresion, vista_imprimir);

    var w = window.open("/FacturasContratos/ImpresionPases.aspx"); //GER 19:38
    
    w.onload = function () {
        var pantalla_impresion = $(w.document);
        var t = w.document.getElementById("PanelImpresion");

        //var mesddjj = w.document.getElementById("MesDDJJ104");
        //var anioddjj = w.document.getElementById("AnioDDJJ104");
        //var areaddjj = w.document.getElementById("AreaDDJJ104");
        var leyendaporanio = w.document.getElementById("LeyendaPorAnio");
        var nroPase = w.document.getElementById("nroPase");
        var fecha = w.document.getElementById("fecha");

        Backend.GetLeyendaAnio(2018)
            .onSuccess(function (respuesta) {
                $(leyendaporanio).html(respuesta);
            })
            .onError(function (error, as, asd) {
                alertify.alert("", "error al obtener leyenda del año");
            });

        $(nroPase).html(nropase);
        $(fecha).html("13/04/1979");
        //$(anioddjj).html(anioSeleccionado);
        
        //var ddjj = un_area.DDJJ; 
        //pantalla_impresion.find("#nroddjj104").barcode("FRHDDJJ104," + ddjj.Id, "code128", {
        //    showHRI: true,
        //    height: 30,
        //    width: 100
        //});
        //$(nroidDDJJ).html(ddjj.Id);
        //pantalla_impresion.find("#fecha").html("Buenos Aires " + ConversorDeFechas.deIsoAFechaEnCriollo(ddjj.FechaGeneracion));
    

        $(t).html(vista_imprimir.html());
    }
    
}



var ImprimirPase = function (lista_de_impresion, contenedor_grilla) {
    var grilla;
    //$("#ContenedorPersona").empty();
    contenedor_grilla.empty();

    grilla = new Grilla(
        [
            new Columna("Cuil", { generar: function (consulta) { return consulta.Persona.Cuit; } }),
            new Columna("Nombre", { generar: function (consulta) { return consulta.Persona.Nombre; } }),
            //ACTO ADMINISTRATIVO
            new Columna("Monto de Factura", { generar: function (consulta) { return consulta.Monto_Factura; } }),
            //MES
            new Columna("Nro de Factura", { generar: function (consulta) { return consulta.Nro_Factura; } }),
            new Columna("Fecha Recibida", { generar: function (consulta) { return consulta.Fecha_Recibida; } }),
            new Columna("Area", { generar: function (consulta) { return consulta.Area; } }),
            new Columna("Firmante", { generar: function (consulta) { return consulta.Firmante; } }),
            //new Columna("Id Factura", { generar: function (consulta) { return consulta.Id_Factura; } })
        ]);

    grilla.CargarObjetos(lista_de_impresion);
    grilla.DibujarEn(contenedor_grilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
}