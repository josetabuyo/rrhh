var AdministradorDeLicencias = function () {
    var json_personas = JSON.parse($('#personasJSON').val());
    var personas = [];
    for (var i = 0; i < json_personas.length; i++) {
        personas.push(new Persona(json_personas[i]));
    }
    contenedorPlanilla = $('#ContenedorPlanilla');
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
        var contenedorBtnAcciones = $('<div>');
        var botonEliminar = $('<img>');
        botonEliminar.addClass('remove-item-btn');
        botonEliminar.attr('src', '../Imagenes/eliminar.png');
        botonEliminar.attr('width', '35px');
        botonEliminar.attr('height', '35px');
        contenedorBtnAcciones.append(botonEliminar);
        botonEliminar.click(function () {

            var data_post = JSON.stringify({
//                "observaciones_nuevas": JSON.stringify(PlanillaObservaciones.Objetos),
//                "observaciones_originales": JSON.stringify(observaciones)
            });
            $.ajax({
                url: "../AjaxWS.asmx/EliminarLicenciaPendienteAprobacion",
                type: "POST",
                data: data_post,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (respuestaJson) {
                    var respuesta = JSON.parse(respuestaJson.d);
                    if (respuesta.length == 0)
                    // _this.MostrarDetalleErrores(respuesta);

                        location.href = "FormPlanillaObservaciones.aspx";
                    //alertify.alert("Las observaciones se guardaron correctamente");
                    //_this.CargarObservacionesDTO();

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alertify.alert(errorThrown);
                }
            });





        });
        return contenedorBtnAcciones;
    }
    }));

    

    PlanillaPersonas = new Grilla(columnas);

    PlanillaPersonas.AgregarEstilo("tabla_macc");
    PlanillaPersonas.AgregarEstilo("tabla_protocolo");

//    PlanillaPersonas.SetOnRowClickEventHandler(function (un_area) {
//        var vista = new VistaDeArea({ area: un_area });
//        vista.mostrarModal();
//    });

    PlanillaPersonas.CargarObjetos(personas);
    PlanillaPersonas.DibujarEn(contenedorPlanilla);

    var options = {
        valueNames: ['Documento', 'Nombre', 'Licencia', 'Desde', 'Hasta']
    };

    var featureList = new List('ContenedorPrincipal', options);
}
