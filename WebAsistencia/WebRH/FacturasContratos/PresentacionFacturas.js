﻿var ContenedorGrilla;
var NombreFirmanteSeleccionado;
var DocumentoFirmanteSeleccionado;
var FechaPaseContabilidad;
var FechaFactura;
var FechaRecibida;
var NroFactura;
var MontoFactura;
var lista_de_facturas;
var SaldoAcumPendienteAFacturar;
var MontoAcumAFacturar;
var MontoAnterior;
var MontoMaximoExcedido;

Backend.start(function () {
    $(document).ready(function () {
        //$('#cmbMeses').hide();
        // spinner = new Spinner({ scale: 2 }).spin($("body")[0]);
        //ContenedorGrilla = $("#ContenedorGrilla");
        completarComboFirmante();

        ContenedorGrilla = $("#ContenedorGrilla");

        NroFactura = $("#txtNroFactura");
        MontoFactura = $("#txtMontoFactura");
        FechaPaseContabilidad = "";
        FechaFactura = "";
        NroFactura = "";
        MontoFactura = "";
        FechaRecibida = "";
        DocumentoFirmanteSeleccionado = "";
        SaldoAcumPendienteAFacturar = 0;
        MontoAcumAFacturar = 0;
        MontoAnterior = 0;

        $("#txtMontoFactura").blur(function () {
            if (parseFloat(MontoAcumAFacturar) > 0) {
                alert("No puede cambiar el importe. Existen facturas seleccionadas en la grilla");
                $("#txtMontoFactura").val(MontoAnterior);
                return;
            }
            SaldoAcumPendienteAFacturar = parseFloat($("#txtMontoFactura").val());
            MontoAnterior = parseFloat(SaldoAcumPendienteAFacturar);
            $('#lblMontoPendiente').text("Monto pendiente a facturar: $ " + parseFloat(SaldoAcumPendienteAFacturar));
        });
    });
});


var LimpiarPantalla = function () {
    $("#txtPaseContabilidad").val("");
    $("#txtFechaFactura").val("");
    $("#txtNroFactura").val("");
    $("#txtMontoFactura").val("");
    $("#lblMontoPendiente").text("");
    $("#txtFechaRecibida").val("");

    ContenedorGrilla.html("");
    $("#ContenedorPersona").empty();

    lista_de_facturas = null;
    SaldoAcumPendienteAFacturar = 0;
    MontoAcumAFacturar = 0;
    MontoAnterior = 0;
    MontoMaximoExcedido = 0;
}

var completarComboFirmante = function () {
    var firmante = $('#cboFirmante');
    firmante.html("");
    Backend.GetFirmantes()
    .onSuccess(function (respuestaFirmantes) {

        respuesta = $.grep(respuestaFirmantes, function (elemento) { return elemento.Categoria = 'Si' }); //Filtro los que firman facturas

        for (var i = 0; i < respuesta.length; i++) {
            item = new Option(respuesta[i].Nombre + ' - ' + respuesta[i].Documento, respuesta[i].Nombre + '-' + respuesta[i].Documento);
            $(item).html(respuesta[i].Nombre); //+ ' - ' + respuesta[i].Id);
            firmante.append(item);
        }
        firmante.change(function () {

            NombreFirmanteSeleccionado = parseInt($("#cboFirmante").val().split("-")[0]);
            DocumentoFirmanteSeleccionado = parseInt($("#cboFirmante").val().split("-")[1]);

//            getAreasDDJJ(function () {
//                ContenedorGrilla.html("");
//                DibujarGrillaDDJJ();
//                spinner.stop();
//            });
        });

        firmante.change();
        firmante.show();

    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
    });
}



$("#btn_BuscarFacturas").click(function () {

    LimpiarPantalla();

    var documento = $('#documento').text().trim();
    if (documento == "") {
        documento = 0;
        alert("Ingrese una persona");
        return;
    }


    ConsultarFacturasPersona(documento); //10477929
    //    vex.defaultOptions.className = 'vex-theme-os';
    //    vex.open({
    //        afterOpen: function ($vexContent) {
    //            var ui = $("#ed_contenedor_imagenes").clone();
    //            $vexContent.append(ui);
    //            ui.show();
    //            return ui;
    //        }
    //    })
});



var ConsultarFacturasPersona = function (documento) {

    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.GetFacturasConSaldo(documento)
    .onSuccess(function (respuesta) {
        //DibujarGrillaPersonas(respuesta);
        lista_de_facturas = respuesta;
        DibujarGrillaDDJJ();
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
    });

};


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
                        CalcularFacturasAPagar(consulta);
                    }
                    else {
                        check.attr("checked", true);
                        consulta.estaSeleccionado = true;
                        CalcularFacturasAPagar(consulta);
                        if (MontoMaximoExcedido == 1) {
                            check.attr("checked", false);
                            consulta.estaSeleccionado = false;
                        }
                    }
                });
                return check
            }
            }),
            new Columna("Año", { generar: function (consulta) { return consulta.Año; } }),
            new Columna("Mes", { generar: function (consulta) { return consulta.Mes; } }),
            new Columna("Monto Contrato", { generar: function (consulta) { return consulta.Monto_Contrato; } }),
            new Columna("Monto a Facturar", { generar: function (consulta) { return consulta.Monto_A_Factura; } }),
            new Columna("Monto otras facturas", { generar: function (consulta) { return consulta.Monto_Otras_Factura; } }),
            new Columna("Saldo", { generar: function (consulta) { return consulta.Saldo; } }) //, //IIf(Int(Rs!saldo_mes), Rs!saldo_mes, IIf(Rs!saldo_mes = 0, 0, Format(Rs!saldo_mes, "#,###,###.##"))) 
		]);

    lista_de_facturas = $.grep(lista_de_facturas, function (elemento) { return elemento.Monto_Contrato != elemento.Monto_Otras_Factura });
    grilla.CargarObjetos(lista_de_facturas);
    grilla.DibujarEn(ContenedorGrilla);

    $("#ContenedorGrilla table tbody").append('<tr><td class="Chk"><td class="Mes"></td><td class="Año"></td><td class="Monto_Contrato"></td><td class="Monto_A_Factura"></td><td class="Monto_Otras_Factura"></td><td class="Saldo">' + this.SumarTotalSaldo(lista_de_facturas) + '</td></tr>')

    //    $("#DivBotonExcel").empty();
    //    var divBtnExportarExcel = $("#DivBotonExcel")
    //    botonExcel = $("<input type='button'>");
    //    botonExcel.val("Exportar a Excel");
    //    botonExcel.click(function () {
    //        BuscarExcel();
    //    });
    //    botonExcel.addClass("btn btn-primary");
    //    divBtnExportarExcel.append(botonExcel);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
};

var SumarTotalSaldo = function (lista) {
    saldototal = 0;
    for (var i = 0; i < lista.length; i++) {
        saldototal = saldototal + lista[i].Saldo;
    }
    return saldototal;
}


var CalcularFacturasAPagar = function (elemento) {
    //consulta.Monto_Contrato
    //consulta.Monto_A_Factura
    //consulta.Monto_Otras_Factura
    //consulta.Saldo
    //SaldoAcumPendienteAFacturar
    //MontoAcumAFacturar
    MontoMaximoExcedido = 0;

    MontoFactura = $("#txtMontoFactura");
    if (MontoFactura.val() == 0) {
        alert("Debe seleccionar el monto a pagar");
        MontoMaximoExcedido = 1;
        return;
    }

    if (elemento.estaSeleccionado) {
        if (parseFloat(SaldoAcumPendienteAFacturar) == 0) {
            alert("Ha alcanzado el monto maximo a facturar");
            MontoMaximoExcedido = 1;
            return;
        }

        if (parseFloat(SaldoAcumPendienteAFacturar) >= parseFloat(elemento.Saldo)) {
            elemento.Monto_A_Factura = parseFloat(elemento.Saldo);
            SaldoAcumPendienteAFacturar = parseFloat(SaldoAcumPendienteAFacturar) - parseFloat(elemento.Saldo);
            elemento.Saldo = parseFloat(elemento.Saldo) - parseFloat(elemento.Monto_A_Factura);
            MontoAcumAFacturar = parseFloat(elemento.Saldo);
        }
        else {
            elemento.Monto_A_Factura = parseFloat(SaldoAcumPendienteAFacturar);
            elemento.Saldo = parseFloat(elemento.Saldo) - parseFloat(SaldoAcumPendienteAFacturar);
            MontoAcumAFacturar = parseFloat(SaldoAcumPendienteAFacturar);
            SaldoAcumPendienteAFacturar = 0;
        }
    }
    else {

        SaldoAcumPendienteAFacturar = parseFloat(SaldoAcumPendienteAFacturar) + parseFloat(elemento.Monto_A_Factura);
        MontoAcumAFacturar = parseFloat(MontoAcumAFacturar) - parseFloat(elemento.Monto_A_Factura);
        elemento.Saldo = parseFloat(elemento.Monto_Contrato) - parseFloat(elemento.Monto_Otras_Factura);
        elemento.Monto_A_Factura = 0;
    }

    $('#lblMontoPendiente').text("Monto pendiente a facturar: $ " + parseFloat(SaldoAcumPendienteAFacturar));
    ContenedorGrilla.html("");
    DibujarGrillaDDJJ();

    //      if (lista_de_facturas == null || lista_de_facturas.length == 0) {
    //          alert("No hay facturas cargadas");
    //          $("#txtMontoFactura").val("");
    //          return;
    //      }
    //      alert(MontoFactura.val());
    //        for (var i = 0; i < lista_de_facturas.length; i++) {
    //            lista_de_facturas[i].Monto_A_Factura = MontoFactura.val();
    //        }
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

    cfg.inputFechaFactura.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaFactura.change();
            self.cfg.inputFechaFactura.blur();

            FechaFactura = date;
        }
    });

    cfg.inputFechaRecibida.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaRecibida.change();
            self.cfg.inputFechaRecibida.blur();

            FechaRecibida = date;
        }
    });

   

}


$("#btn_Guardar").click(function () {
    //    alert(FechaPaseContabilidad);
    //    alert(FechaFactura);
    //    alert(NroFactura.val());
    //    alert(MontoFactura.val());
    //    alert(DocumentoFirmanteSeleccionado);
    //    alert(FechaRecibida);

    var documento = $('#documento').text().trim();
    if (documento == "") {
        documento = 0;
        alert("Ingrese una persona");
        return;
    }

    NroFactura = $("#txtNroFactura");
    MontoFactura = $("#txtMontoFactura");


    if (lista_de_facturas.length == 0) {
        alert("Debe seleccionar una factura a pagar");
        return;
    }


    aFacturar = 0;
    for (var i = 0; i < lista_de_facturas.length; i++) {
        aFacturar = parseFloat(aFacturar) + parseFloat(lista_de_facturas[i].Monto_A_Factura);
    }
    if (MontoFactura.val() != aFacturar) {
        alert("El monto de la factura (" + MontoFactura.val() + ") no es igual al monto a facturar (" + aFacturar + ")");
        return;
    }


    if (FechaPaseContabilidad == "") {
        alert("Ingrese la fecha de pase a contabilidad");
        return;
    }

    if (FechaFactura == "") {
        alert("Ingrese la fecha de la factura");
        return;
    }

    //1111-11111111
    if (NroFactura.val() == "") {
        alert("Ingrese el nro de la factura");
        return;
    }

    if (MontoFactura.val() == "") {
        alert("Ingrese el importe de la factura");
        return;
    }


    if (FechaRecibida == "") {
        alert("Ingrese la fecha recibida");
        return;
    }

    var idarea = $('#hfIdArea').val();

    if (alert == "") {
        alert("Ingrese el area");
        return;
    }

    if (DocumentoFirmanteSeleccionado == "") {
        alert("Ingrese el firmante");
        return;
    }


    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);
    Backend.GuardarFactura({ doc: documento,
        facha_pase: FechaPaseContabilidad,
        fecha_factura: FechaFactura,
        nro_factura: NroFactura.val(),
        monto_a_facturar: MontoFactura.val(),
        fecha_recibida: FechaRecibida,
        id_area: idarea,
        doc_firm_selecc: DocumentoFirmanteSeleccionado
    }, lista_de_facturas)
    .onSuccess(function (respuesta) {
        alertify.alert("", respuesta);
        spinner.stop();
        LimpiarPantalla();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
    });


});