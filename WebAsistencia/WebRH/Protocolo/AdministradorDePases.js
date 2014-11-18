var AdministradorDePases = function () {
    var json_personas = JSON.parse($('#pasesJSON').val());
    var personas = [];
    for (var i = 0; i < json_personas.length; i++) {
        personas.push(new Persona(json_personas[i]));
    }
    contenedorPlanilla = $('#ContenedorPlanilla2');
    var columnas = [];

    columnas.push(new Columna("Documento", { generar: function (una_persona) {
        return una_persona.documento();
    }
    }));
    columnas.push(new Columna("Nombre", { generar: function (una_persona) {
        return una_persona.nombre();
    }
    }));
    columnas.push(new Columna("Area Origen", { generar: function (una_persona) {
        return una_persona.areaOrigen();
    }
    }));
    columnas.push(new Columna("Area Solicitada", { generar: function (una_persona) {
        return una_persona.areaDestino();
    }
    }));
    columnas.push(new Columna("Fecha Solicitud", { generar: function (una_persona) {
        return una_persona.fechaPase();
    }
    }));

    columnas.push(new Columna("Estado", { generar: function (una_persona) {
        return una_persona.estadoPase();
    }
    }));



    columnas.push(new Columna("Eliminar", { generar: function (una_persona) {
        if (una_persona.estadoPase() == "Pendiente") {
            var contenedorBtnAcciones = $('<div>');
            var botonEliminar = $('<img>');
            botonEliminar.attr('src', '../Imagenes/btnEliminar.gif');
            botonEliminar.attr('width', '25px');
            botonEliminar.attr('height', '25px');
            contenedorBtnAcciones.append(botonEliminar);
            botonEliminar.click(function () {
                var mensaje = "¿Está seguro que desea eliminar el Pase de " + una_persona.nombre() + " desde el Área: " + una_persona.areaOrigen() + " hacía el Área: " + una_persona.areaDestino() + "?";
                alertify.confirm(mensaje, function (e) {
                    if (e) {
                        // user clicked "ok"
                        var data_post = JSON.stringify({
                            id_pase: JSON.stringify(una_persona.idPase()),
                           
                        });
                        $.ajax({
                            url: "../AjaxWS.asmx/EliminarPasePendienteAprobacion",
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
                    } else {
                        alertify.error("No se ha eliminado el Pase");
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

//    PlanillaPersonas.SetOnRowClickEventHandler(function (un_area) {
//        var vista = new VistaDeArea({ area: un_area });
//        vista.mostrarModal();
//    });

    PlanillaPersonas.CargarObjetos(personas);
    PlanillaPersonas.DibujarEn(contenedorPlanilla);

    var options = {
        valueNames: ['Documento', 'Nombre', 'Area Solicitada', 'Fecha Solicitud', 'Estado']
    };

    var featureList = new List('ContenedorPrincipal', options);
}
