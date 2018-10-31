
var ambitoIdSeleccionado;
var ambitoDescripSeleccionado;
var cargoIdSeleccionado;
var cargoDescripSeleccionado;

var ContenedorGrilla;
var lista_de_serv_publico;


Backend.start(function () {
    $(document).ready(function () {
        completarComboAmbitos();
        completarComboCargo();

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorServicios").empty();

        ConsultarServicioAdmPublica();
    });
});

var completarComboAmbitos = function () {
    var ambitos = $('#cmbAmbitos');
    ambitos.html("");
    Backend.GetAmbitos()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            item = new Option(respuesta[i].id + ' - ' + respuesta[i].descripcion, respuesta[i].id + '-' + respuesta[i].descripcion);
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
            item = new Option(respuesta[i].id + ' - ' + respuesta[i].descripcion, respuesta[i].id + '-' + respuesta[i].descripcion);
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

    Backend.GET_Servicios_Adm_Publica_Detalles(201609, '00-018/018')
    .onSuccess(function (respuesta) {
        lista_de_serv_publico = respuesta;
        DibujarGrillaServPublico();
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
        LimpiarPantalla();
    });
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
            new Columna("Desde", { generar: function (consulta) { return consulta.Fecha_Desde; } }),
            new Columna("Hasta", { generar: function (consulta) { return consulta.Fecha_Hasta; } })
            ]);

    grilla.CargarObjetos(lista_de_serv_publico);
    grilla.DibujarEn(ContenedorGrilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
};

//----------------------------------------------------------------------------------