
var valores;
var pLegajo;
var pDocumento;
var pFolio;
var ambitoIdSeleccionado;
var ambitoDescripSeleccionado;
var cargoIdSeleccionado;
var cargoDescripSeleccionado;

var ContenedorGrilla;
var lista_de_serv_publico;


Backend.start(function () {
    $(document).ready(function () {

        var valores = getParametrosURL();
        pLegajo = valores['legajo'];
        pDocumento = valores['documento'];
        pFolio  = valores['folio'];

        completarComboAmbitos();
        completarComboCargo();

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorServicios").empty();

        ConsultarServicioAdmPublica();
    });
});

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

$("#btn_Agregar").click(function () {

    var ServPublico = {};
    ServPublico.Ambito = [];
    ServPublico.Ambito.Id = parseInt($("#cmbAmbitos").val());
    ServPublico.Ambito.Descripcion = $("#cmbAmbitos option:selected").text();
    ServPublico.Jurisdiccion = $('#txtJurisdiccion').val();
    ServPublico.Organismo = $('#txtOrganismo').val();
    ServPublico.Cargo = [];
    ServPublico.Cargo.Id = parseInt($("#cmbCargo").val());
    ServPublico.Cargo.Descripcion = $("#cmbCargo option:selected").text();

    if ($("#rdRemuneradoSI").checked) {
        ServPublico.Remunerativo = true;
    }
    else {
        ServPublico.Remunerativo = false;
    }

    ServPublico.Fecha_Desde = $("#txtFechaDesde").val();
    ServPublico.Fecha_Hasta = $("#txtFechaHasta").val();
    ServPublico.Causa_Egreso = $('#txtCausaEgreso').val();
    ServPublico.Folio = $('#NroFolio').val() + "-" + $('#NroFolioDesde').val() + "/" + $('#NroFolioHasta').val();
    ServPublico.Id_Interna = parseInt(pLegajo);
    ServPublico.Doc_Titular = parseInt(pDocumento);
    ServPublico.Caja = $('#txtCaja').val();
    ServPublico.Afiliado = $('#txtNroAfiliacion').val();

    if ($("#chkNoImprime").checked) {
        ServPublico.datonoimprime = true;
    }
    else {
        ServPublico.datonoimprime = false;
    }

    if ($("#DarDeBaja").checked) {
        ServPublico.DatoDeBaja = true;
    }
    else {
        ServPublico.DatoDeBaja = false;
    }


    if ($("#rdTipoDocumentoCTR").checked) {
        ServPublico.Ctr_Cert = true;
    }
    if ($("#rdTipoDocumentoCER").checked) {
        ServPublico.Ctr_Cert = false;
    }
    if ($("#rdTipoDocumentoOTR").checked) {
        ServPublico.Ctr_Cert = null;
    }

    ServPublico.Domicilio = null;
    ServPublico.Institucion = null;

    //lista_de_serv_publico.append(ServPublico);
    lista_de_serv_publico.push(ServPublico);
    DibujarGrillaServPublico();
});


$("#btn_Guardar").click(function () {
    //var aa = ServPublico;

    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.Alta_Servicios_Adm_Publica(lista_de_serv_publico)
    .onSuccess(function (respuesta) {
        alert("Datos guardados correctamente");
        //lista_de_serv_publico = respuesta;
        //CargarPantalla(lista_de_serv_publico);
        //DibujarGrillaServPublico();
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("Error al guardar los servicios", error);
        spinner.stop();
        //LimpiarPantalla();
    });

}); 


function getParametrosURL() {
    // url
    var loc = document.location.href;
    // si existe el signo ?
    if (loc.indexOf('?') > 0) {
        var getString = loc.split('?')[1];
        var GET = getString.split('&');
        var get = {};
        for (var i = 0, l = GET.length; i < l; i++) {
            var tmp = GET[i].split('=');
            get[tmp[0]] = unescape(decodeURI(tmp[1]));
        }
        return get;
    }
}


var FormatearFecha = function (p_fecha) {

    if (p_fecha.split("T").length == 1) {
        return p_fecha;
    }
    else {
        var fecha_sin_hora = p_fecha.split("T");
        var fecha = fecha_sin_hora[0].split("-");
        return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
    }
    
};


var GetFolio = function (folio, dato) {

    if (dato == 1) {
        var nro = folio.split("-");
        return nro[0];
    }

    if (dato == 2) {
        var nro = folio.split("-");
        var dh = nro[1].split("/");
        return dh[0];
    }

    if (dato == 3) {
        var nro = folio.split("-");
        var dh = nro[1].split("/");
        return dh[1];
    }
};


//function getRadioButtonSelectedValue(ctrl) {
//    for (i = 0; i < ctrl.length; i++)
//        if (ctrl[i].checked) return ctrl[i].value;
//}
//OR
//function getCheckedRadio() {
//    var radioButtons = document.getElementsByName("RadioButtonList1");
//    for (var x = 0; x < radioButtons.length; x++) {
//        if (radioButtons[x].checked) {
//            alert("You checked " + radioButtons[x].id + " which has the value " + radioButtons[x].value);
//        }
//    }
//}



var completarComboAmbitos = function () {
    var ambitos = $('#cmbAmbitos');
    ambitos.html("");
    Backend.GetAmbitos()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            //item = new Option(respuesta[i].id + ' - ' + respuesta[i].descripcion, respuesta[i].id + '-' + respuesta[i].descripcion);
            item = new Option(respuesta[i].descripcion, respuesta[i].id);
            $(item).html(respuesta[i].descripcion);
            ambitos.append(item);
        }
        ambitos.change(function () {
            ambitoIdSeleccionado = parseInt($("#cmbAmbitos").val().split("-")[0]);
            ambitoDescripSeleccionado = parseInt($("#cmbAmbitos").val().split("-")[1]);

            //alert(ambitoIdSeleccionado);
            //alert(ambitoDescripSeleccionado);

        });

        ambitos.change();
        ambitos.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
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

var ConsultarServicioAdmPublica = function (documento) {
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

var CargarPantalla = function (ListaDeDatos) {

    if (ListaDeDatos.length > 0) {

        $("#cmbAmbitos").val(lista_de_serv_publico[0].Ambito.Id).change();
        $('#NroFolio').val(GetFolio(lista_de_serv_publico[0].Folio, 1));
        $('#NroFolioDesde').val(GetFolio(lista_de_serv_publico[0].Folio, 2));
        $('#NroFolioHasta').val(GetFolio(lista_de_serv_publico[0].Folio, 3));
        $('#txtJurisdiccion').val(lista_de_serv_publico[0].Jurisdiccion);
        $('#txtCaja').val(lista_de_serv_publico[0].Caja);
        $('#txtNroAfiliacion').val(lista_de_serv_publico[0].Afiliado);

        if (lista_de_serv_publico[0].Remunerativo) {
            $("#rdRemuneradoSI").prop("checked", true);
        }
        else {
            $("#rdRemuneradoNO").prop("checked", true);
        }

        if (lista_de_serv_publico[0].Ctr_Cert == true) {
            $("#rdTipoDocumentoCTR").prop("checked", true);
        }
        else {
            if (lista_de_serv_publico[0].Ctr_Cert == false) {
                $("#rdTipoDocumentoCER").prop("checked", true);
            }
            else {
                $("#rdTipoDocumentoOTR").prop("checked", true);
            }
        }

        $('#txtCausaEgreso').val(lista_de_serv_publico[0].Causa_Egreso);

        if (lista_de_serv_publico[0].datonoimprime == true) {
            $("#chkNoImprime").prop("checked", true);
        }

        if (lista_de_serv_publico[0].DatoDeBaja == true) {
            $("#DarDeBaja").prop("checked", true);
        }

    }
};


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
        ]);

    grilla.CargarObjetos(lista_de_serv_publico);
    grilla.DibujarEn(ContenedorGrilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
};

//----------------------------------------------------------------------------------