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
