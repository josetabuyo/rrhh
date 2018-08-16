
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