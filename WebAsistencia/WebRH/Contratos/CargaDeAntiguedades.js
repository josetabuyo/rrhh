var botonSeleccionado;
var ContenedorGrilla;
var lista_de_serv_publico;

Backend.start(function () {
    $(document).ready(function () {

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorPersona").empty();

    });
});


var LimpiarPantalla = function () {

    botonSeleccionado = null;

    //$('#ContenedorCampos').hide();
    //$("#txtPaseContabilidad").val("");
    //ContenedorGrilla.html("");
    //$("#ContenedorPersona").empty();
    //lista_de_facturas = null;
    //SaldoAcumPendienteAFacturar = 0;
};


$("#btn_Estado").click(function () {
    CargarGrilla("ESTADO");
});


$("#btn_Privado").click(function () {
    CargarGrilla("PRIVADO");
});


var CargarGrilla = function (boton) {
    LimpiarPantalla();

    botonSeleccionado = boton;

    var documento = $('#documento').text().trim();
    if (documento == "") {
        documento = 0;
        alert("Ingrese una persona");
        return;
    }

    //    if (!ValidarUsuario(documento)) {
    //        alert("NO PASA");
    //    };

    if (botonSeleccionado == "ESTADO") {
        ConsultarServicioAdmPublica(documento);
    }
    else {

    }

};

var ConsultarServicioAdmPublica = function (documento) {
    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.GetServicios_Adm_Publica_Principal(documento)
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
    $("#ContenedorPersona").empty();

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
            new Columna("Id", { generar: function (consulta) { return consulta.Id; } }),
            new Columna("Ambito", { generar: function (consulta) { return consulta.Ambito; } }),
            new Columna("Jurisdiccion", { generar: function (consulta) { return consulta.Jurisdiccion; } }),
            new Columna("Folio", { generar: function (consulta) { return consulta.Folio; } }),
            new Columna("Caja", { generar: function (consulta) { return consulta.Caja; } }),
            new Columna("Afiliado", { generar: function (consulta) { return consulta.Afiliado; } }) 
            ]);

    grilla.CargarObjetos(lista_de_serv_publico);
    grilla.DibujarEn(ContenedorGrilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
};