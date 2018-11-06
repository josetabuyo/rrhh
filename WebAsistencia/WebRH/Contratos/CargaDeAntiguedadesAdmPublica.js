
var valores;
var pLegajo;
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
        pFolio  = valores['folio'];

        completarComboAmbitos();
        completarComboCargo();

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorServicios").empty();

        ConsultarServicioAdmPublica();
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
    var fecha_sin_hora = p_fecha.split("T");
    var fecha = fecha_sin_hora[0].split("-");
    return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
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
            item = new Option(respuesta[i].id, respuesta[i].descripcion);
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
            item = new Option(respuesta[i].id, respuesta[i].descripcion);
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
        //$('#cmbAmbitos')
        // $("#cmbAmbitos").puidropdown('selectValue', lista_de_serv_publico[0].Ambito.Id);
        //$("#tidservicio").val(datosViajes[1]);
        //$('#tidservicio').change();

        $('#NroFolio').val(GetFolio(lista_de_serv_publico[0].Folio, 1));
        $('#NroFolioDesde').val(GetFolio(lista_de_serv_publico[0].Folio, 2));
        $('#NroFolioHasta').val(GetFolio(lista_de_serv_publico[0].Folio, 3));
        $('#txtJurisdiccion').val(lista_de_serv_publico[0].Jurisdiccion);
        $('#txtCaja').val(lista_de_serv_publico[0].Caja);
        $('#txtNroAfiliacion').val(lista_de_serv_publico[0].Afiliado);

        if (lista_de_serv_publico[0].Remunerativo) {
            //document.getElementById('idofcorespondingradiobutton').checked = true;
        }

        //$('#rdRemunerado')
        //$('#rdTipoDocumento')
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
            new Columna("Cargo", { generar: function (consulta) { return consulta.Cargo; } }),
            new Columna("Desde", { generar: function (consulta) { return FormatearFecha(consulta.Fecha_Desde); } }),
            new Columna("Hasta", { generar: function (consulta) { return FormatearFecha(consulta.Fecha_Hasta); } })
            ]);

    grilla.CargarObjetos(lista_de_serv_publico);
    grilla.DibujarEn(ContenedorGrilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
};

//----------------------------------------------------------------------------------