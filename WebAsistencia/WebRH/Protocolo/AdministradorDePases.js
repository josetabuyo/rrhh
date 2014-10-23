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
