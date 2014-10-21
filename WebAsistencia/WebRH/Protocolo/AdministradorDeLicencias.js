var AdministradorDeLicencias = function () {
    var json_personas = JSON.parse($('#personasJSON').val());
    var personas = [];
    for (var i = 0; i < json_personas.length; i++) {
        personas.push(new Persona(json_personas[i]));
    }

    var contenedorPlanilla = $('#ContenedorPlanilla');
    var columnas = [];

    columnas.push(new Columna("Documento", { generar: function (una_persona) {
        return una_persona.documento();
    }
    }));
    columnas.push(new Columna("Nombre", { generar: function (una_persona) {
        return una_persona.nombre();
    }
    }));
    columnas.push(new Columna("Licencia", { generar: function (una_persona) {
        return una_persona.inasistencias();
    }
    }));
    columnas.push(new Columna("Desde", { generar: function (una_persona) {
        return una_persona.desde();
    }
    }));
    columnas.push(new Columna("Hasta", { generar: function (una_persona) {
        return una_persona.hasta();
    }
    }));
    columnas.push(new Columna("Estado", { generar: function (una_persona) {
        return una_persona.estado();
    }
    }));
    columnas.push(new Columna("Eliminar", { generar: function (una_persona) {

        if (una_persona.estado() == "En Trámite") {
            var contenedorBtnAcciones = $('<div>');
            var botonEliminar = $('<img>');
            botonEliminar.addClass('remove-item-btn');
            botonEliminar.attr('src', '../Imagenes/btnEliminar.gif');
            botonEliminar.attr('width', '25px');
            botonEliminar.attr('height', '25px');
            contenedorBtnAcciones.append(botonEliminar);
            botonEliminar.click(function () {

                var data_post = JSON.stringify({
                    id: JSON.stringify(una_persona.idInasistencias())
                });
                $.ajax({
                    url: "../AjaxWS.asmx/EliminarLicenciaPendienteAprobacion",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        PlanillaPersonas.EliminarObjeto(una_persona);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });

            });
            return contenedorBtnAcciones;
        }
    }
    }));



    var PlanillaPersonas = new Grilla(columnas);

    PlanillaPersonas.AgregarEstilo("tabla_macc");
    PlanillaPersonas.AgregarEstilo("tabla_protocolo");

    PlanillaPersonas.SetOnRowClickEventHandler(function (una_persona) {
        //        var vista = new VistaDeArea({ area: un_area });
        //        vista.mostrarModal();
    });

    PlanillaPersonas.CargarObjetos(personas);
    PlanillaPersonas.DibujarEn(contenedorPlanilla);

    var options = {
        valueNames: ['Documento', 'Nombre', 'Licencia', 'Desde', 'Hasta']
    };

    var featureList = new List('ContenedorPrincipal', options);

    var ParsearFecha = function (fecha) {
        var day = parseInt(fecha.split("/")[0]);
        var month = parseInt(fecha.split("/")[1]);
        var year = parseInt(fecha.split("/")[2]);

        return new Date(year, month, day);

    }
}
