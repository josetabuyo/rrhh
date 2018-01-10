
var lista_personas_no_certificadas;
var ContenedorGrilla;
var mesSeleccionado;
var anioSeleccionado;
var spinner;


Backend.start(function () {
    $(document).ready(function () {
        $('#cmbMeses').hide();
        ContenedorGrilla = $("#ContenedorGrilla");
        completarComboMeses();
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
            new Columna("NroDocumento", { generar: function (una_persona) { return una_persona.persona.Documento; } }),
            new Columna("Apellido", { generar: function (una_persona) { return una_persona.persona.Apellido; } }),
            new Columna("Nombre", { generar: function (una_persona) { return una_persona.persona.Nombre; } }),
            new Columna("Area", { generar: function (una_persona) { return una_persona.area_generacion.Nombre; } }),
            
            new Columna("Motivo", { generar: function (una_persona) {
                var motivo = $("<input type='text'/>");
                motivo.val(una_persona.persona.MotivoNoCertificar);
                motivo.change(function () {
                    una_persona.persona.MotivoNoCertificar = motivo.val();
                });
                return motivo;
            }
            }),

            new Columna("CCO", { generar: function (una_persona) {
                var cco = $("<input type='text'/>");
                cco.val(una_persona.persona.CCONoCertificar);
                cco.change(function () {
                    una_persona.persona.CCONoCertificar = cco.val();
                });
                return cco;
            }
            }),
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

        spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

        Backend.GenerarMotivoEnPersonasNoCertificadas(mesSeleccionado, anioSeleccionado, lista_personas_no_certificadas)
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