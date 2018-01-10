
var lista_personas_no_certificadas;
var lista_personas;
var ContenedorGrilla;
var mesSeleccionado;
var anioSeleccionado;
var spinner;


Backend.start(function () {
    $(document).ready(function () {
        $('#cmbMeses').hide();
        ContenedorGrilla = $("#ContenedorGrilla");
        completarComboMeses();
        lista_personas = [];
    });
});


var completarComboMeses = function () {
    var meses = $('#cmbMeses');
    meses.html("");
    Backend.GetMeses()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            item = new Option(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio, respuesta[i].Mes + '-' + respuesta[i].Anio);
            $(item).html(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio);
            meses.append(item);
        }
        meses.change(function () {
            ContenedorGrilla.html("");

            spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

            mesSeleccionado = parseInt($("#cmbMeses").val().split("-")[0]);
            anioSeleccionado = parseInt($("#cmbMeses").val().split("-")[1]);

            getPersonasSinCertificarDDJJ(function () {
                ContenedorGrilla.html("");
                DibujarGrillaDDJJ();
                spinner.stop();
            });
        });

        meses.change();
        meses.show();

    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
    });
}



var DibujarGrillaDDJJ = function () {
    var grilla;

    $("#ContenedorPersona").empty();
    grilla = new Grilla(
        [
                new Columna("Certifica", { generar: function (una_persona) {

                    var check = $("<input type='checkbox' />");
                    if (una_persona.EstaCertificadoEnLaDDJJ) check.attr("checked", true);
                    check.click(function () {
                        if (una_persona.EstaCertificadoEnLaDDJJ) {
                            check.attr("checked", false);
                            una_persona.EstaCertificadoEnLaDDJJ = false;
                            lista_personas = _.reject(lista_personas, function (p) { return p.Id == una_persona.Id; });
                        }
                        else {
                            check.attr("checked", true);
                            una_persona.EstaCertificadoEnLaDDJJ = true;
                            lista_personas.push(una_persona);
                        }
                    });
                    return check

                }
                }),

            new Columna("NroDocumento", { generar: function (una_persona) { return una_persona.persona.Documento; } }),
            new Columna("Apellido", { generar: function (una_persona) { return una_persona.persona.Apellido; } }),
            new Columna("Nombre", { generar: function (una_persona) { return una_persona.persona.Nombre; } }),
            new Columna("Area", { generar: function (una_persona) { return una_persona.area_generacion.Nombre; } }),

		]);

    grilla.CargarObjetos(lista_personas_no_certificadas);
    grilla.DibujarEn(ContenedorGrilla);
    BuscardoAreas();

    //$("#DivBotonExcel").empty();
    // var divBtnExportarExcel = $("#DivBotonExcel")
    //botonExcel = $("<input type='button'>");
    //botonExcel.val("Exportar a Excel");
    //botonExcel.click(function () {
    //    BuscarExcel(mesSeleccionado, anioSeleccionado, 0);
    //});
    //divBtnExportarExcel.append(botonExcel);

    boton = $("<input type='button'>");
    boton.val("Guardar");
    boton.click(function () {
        Guardar();
    });
    ContenedorGrilla.append(boton);


    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });

}
function BuscardoAreas() {

    var options = {
        valueNames: ['NroDocumento', 'Apellido', 'Nombre', 'Area']
    };
    var featureList = new List('grilla', options);
};


var getPersonasSinCertificarDDJJ = function (callback) {
    Backend.GetPersonasSinCertificar(mesSeleccionado, anioSeleccionado)
    .onSuccess(function (respuesta) {
        lista_personas_no_certificadas = respuesta;
        callback();

    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
    });
};


var Guardar = function () {

    if (lista_personas.count == 0) {
        alertify.alert("Debe seleccionar por lo menos una persona.");
        return;
    }


    var idarea = $('#hfIdArea').val();
    if (idarea == "") {
        alertify.alert("Debe ingresar el Area que certificar a las personas.");
        return;
    }


    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.AsignaAreaAPersonasNoCertificadas(mesSeleccionado, anioSeleccionado, lista_personas, idarea)
            .onSuccess(function () {

                //ContenedorGrilla.html("");

                alertify.success("Se guardaron los datos correctamente");
                spinner.stop();


            })
            .onError(function (error, as, asd) {
                alertify.alert("", error);
                spinner.stop();
            });

};