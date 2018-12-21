/*
var cargoIdSeleccionado;
var cargoDescripSeleccionado;
var ContenedorGrilla;
var lista_de_serv_publico;


Backend.start(function () {
    $(document).ready(function () {

        //var valores = getParametrosURL();
        //pLegajo = valores['legajo'];
        //pDocumento = valores['documento'];
        //pFolio = valores['folio'];
        
        completarComboCargo();
        GetUsuario();

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorServicios").empty();

        ConsultarServicioAdmPrivada();
    });
});

var GetUsuario = function () {
    Backend.GetUsuarioLogueado()
    .onSuccess(function (respuesta) {
        pUsuarioLogueado = respuesta.Id;
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
    });
}

var PanelFechas = function (cfg) {
    var self = this;
    this.cfg = cfg;

    cfg.inputFechaDesde.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaDesde.change();
            self.cfg.inputFechaDesde.blur();
            FechaDesde = date;
        }
    });

    cfg.inputFechaHasta.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaHasta.change();
            self.cfg.inputFechaHasta.blur();
            FechaHasta = date;
        }
    });
}



var completarComboCargo = function () {
    var cargo = $('#cmbCargo');
    cargo.html("");
    Backend.GetCargos()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            //item = new Option(respuesta[i].id + ' - ' + respuesta[i].descripcion, respuesta[i].id + '-' + respuesta[i].descripcion);
            item = new Option(respuesta[i].descripcion, respuesta[i].id);
            $(item).html(respuesta[i].descripcion);
            cargo.append(item);
        }
        cargo.change(function () {
            cargoIdSeleccionado = parseInt($("#cmbCargo").val().split("-")[0]);
            cargoDescripSeleccionado = parseInt($("#cmbCargo").val().split("-")[1]);

            //alert(cargoIdSeleccionado);
            //alert(cargoDescripSeleccionado);

        });

        cargo.change();
        cargo.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
    });
}



//---------------------- CARGAR GRILLA -------------------------------------

var ConsultarServicioAdmPrivada = function (documento) {
    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.GET_Servicios_Adm_Publica_Detalles(pLegajo, pFolio)
    .onSuccess(function (respuesta) {
        lista_de_serv_publico = respuesta;
        CargarPantalla(lista_de_serv_publico);
        DibujarGrillaServPublico();
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
        LimpiarPantalla();
    });
};

//var CargarPantalla = function (ListaDeDatos) {

//    if (ListaDeDatos.length > 0) {

//        $("#cmbAmbitos").val(lista_de_serv_publico[0].Ambito.Id).change();
//        $('#NroFolio').val(GetFolio(lista_de_serv_publico[0].Folio, 1));
//        $('#NroFolioDesde').val(GetFolio(lista_de_serv_publico[0].Folio, 2));
//        $('#NroFolioHasta').val(GetFolio(lista_de_serv_publico[0].Folio, 3));
//        $('#txtJurisdiccion').val(lista_de_serv_publico[0].Jurisdiccion);
//        $('#txtCaja').val(lista_de_serv_publico[0].Caja);
//        $('#txtNroAfiliacion').val(lista_de_serv_publico[0].Afiliado);

//        if (lista_de_serv_publico[0].Remunerativo) {
//            $("#rdRemuneradoSI").prop("checked", true);
//        }
//        else {
//            $("#rdRemuneradoNO").prop("checked", true);
//        }

//        if (lista_de_serv_publico[0].Ctr_Cert == true) {
//            $("#rdTipoDocumentoCTR").prop("checked", true);
//        }
//        else {
//            if (lista_de_serv_publico[0].Ctr_Cert == false) {
//                $("#rdTipoDocumentoCER").prop("checked", true);
//            }
//            else {
//                $("#rdTipoDocumentoOTR").prop("checked", true);
//            }
//        }

//        $('#txtCausaEgreso').val(lista_de_serv_publico[0].Causa_Egreso);

//        if (lista_de_serv_publico[0].datonoimprime == true) {
//            $("#chkNoImprime").prop("checked", true);
//        }

//        if (lista_de_serv_publico[0].DatoDeBaja == true) {
//            $("#DarDeBaja").prop("checked", true);
//        }
//    }


//    if (pFolio == "0") {

//        $("#cmbAmbitos").val(ambitoIdSeleccionado);
//        $('#NroFolio').val(00);
//        $('#NroFolioDesde').val(000);
//        $('#NroFolioHasta').val(000);
//        $('#txtJurisdiccion').val(null);
//        $('#txtCaja').val(null);
//        $('#txtNroAfiliacion').val(null);

//        $("#rdRemuneradoSI").prop("checked", false);
//        $("#rdRemuneradoNO").prop("checked", false);

//        $("#rdTipoDocumentoCTR").prop("checked", false);
//        $("#rdTipoDocumentoCER").prop("checked", false);
//        $("#rdTipoDocumentoOTR").prop("checked", false);

//        $('#txtCausaEgreso').val(null);
//        $("#chkNoImprime").prop("checked", false);
//        $("#DarDeBaja").prop("checked", false);

//        $("#txtOrganismo").val(null);
//        $("#cmbCargo").val(cargoIdSeleccionado);
//        $("#txtFechaDesde").val(null);
//        $("#txtFechaHasta").val(null);

//        $("#chkNoImprime").prop("checked", false);
//        $("#DarDeBaja").prop("checked", false);
//        $("#txtCausaEgreso").val(null);

//        lista_de_serv_publico.length == 0;

//    }

//};


var DibujarGrillaServPublico = function () {
    var grilla;
    ContenedorGrilla.html("");
    $("#ContenedorServicios").empty();

    grilla = new Grilla(
        [
    //            new Columna("", { generar: function (consulta) {
    //                var check = $("<input type='checkbox' />");
    //                if (consulta.estaSeleccionado) check.attr("checked", true);
    //                check.click(function () {
    //                    if (consulta.estaSeleccionado) {
    //                        check.attr("checked", false);
    //                        consulta.estaSeleccionado = false;
    //                        CalcularFacturasAPagar(consulta);
    //                    }
    //                    else {
    //                        check.attr("checked", true);
    //                        consulta.estaSeleccionado = true;
    //                        CalcularFacturasAPagar(consulta);
    //                        if (MontoMaximoExcedido == 1) {
    //                            check.attr("checked", false);
    //                            consulta.estaSeleccionado = false;
    //                        }
    //                    }
    //                });
    //                return check
    //            }
    //            }),
            new Columna("Organismo", { generar: function (consulta) { return consulta.Organismo; } }),
            new Columna("Cargo", { generar: function (consulta) { return consulta.Cargo.Descripcion; } }),
            new Columna("Desde", { generar: function (consulta) { return FormatearFecha(consulta.Fecha_Desde); } }),
            new Columna("Hasta", { generar: function (consulta) { return FormatearFecha(consulta.Fecha_Hasta); } }),



            new Columna("Ver", { generar: function (consulta) {
                //return consulta.Afiliado; 
                var cont = $('<div>');

                //if (consulta.Id == 0) return cont;

                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/eliminar.png');
                img.attr('width', '15px');
                img.attr('height', '15px');
                btn_accion.attr('style', 'display:inline-block');
                btn_accion.append(img);
                btn_accion.click(function () {
                    var spinner = new Spinner({ scale: 3 });
                    spinner.spin($("html")[0]);

                    setTimeout(function () {
                        //window.open("CargaDeAntiguedadesAdmPublica.aspx?legajo=" + $('#legajo').text().trim() + "&" + "folio=" + consulta.Folio);
                        alertify.confirm("Eliminar Cargo", "¿Desea eliminar el cargo " + consulta.Cargo.Descripcion + " entre las fechas " + FormatearFecha(consulta.Fecha_Desde) + " y " + FormatearFecha(consulta.Fecha_Hasta) + " ?", function () {
                            //ACEPTO
                            alertify.success("OK - Borrar");
                            //lista_de_serv_publico.splice(lista_de_serv_publico.index(), 1)
                        }, function () {
                            //CANCELA
                            alertify.success("Eliminación cancelada");
                        }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });

                        spinner.stop();
                    }, 10);

                });
                cont.append(btn_accion);
                return cont;
            }
            }),



        ]);

    grilla.CargarObjetos(lista_de_serv_publico);
    grilla.DibujarEn(ContenedorGrilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
};

//----------------------------------------------------------------------------------

*/