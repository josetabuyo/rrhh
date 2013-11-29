var AdministradorDePersonas = function () {
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
    columnas.push(new Columna("Area", { generar: function (una_persona) {
        return una_persona.area();
    }
    }));
    columnas.push(new Columna("Asistencia", { generar: function (una_persona) {
        var contenedorBtnAcciones = $('<div>');
        var botonPresente = $('<a>');
        botonPresente.addClass('assitencia-btn');
        //botonPresente.attr('href', '../ConceptosLicencia.aspx');
        botonPresente.text('Presente');
        botonPresente.click(function () {
            $("#DNIPersona").val(una_persona.documento());
            $("#btnAsistenciaAlumno").click();
        });
        // botonEditar.attr('style', 'padding-right:5px;');
        //botonEditar.attr('width', '35px');
        // botonEditar.attr('height', '35px');
        contenedorBtnAcciones.append(botonPresente);

        return contenedorBtnAcciones;

    }
    }));
    columnas.push(new Columna("Pase", { generar: function (una_persona) {
        var contenedorBtnAcciones = $('<div>');
        var botonPase = $('<img>');
        botonPase.addClass('pase-btn');
        if (una_persona.idPase() == 0) {
            botonPase.attr('src', '../Imagenes/paseMin.png');

            botonPase.click(function () {
                $("#DNIPersona").val(una_persona.documento());
                $("#btnPasePersona").click();
            });

        } else {
            botonPase.attr('src', '../Imagenes/eliminar.PNG');

            botonPase.click(function () {
                $("#DNIPersona").val(una_persona.documento());
                $("#btnEliminarPasePersona").click();
            });

        };
        



        // botonEditar.attr('style', 'padding-right:5px;');
        //botonEditar.attr('width', '35px');
        // botonEditar.attr('height', '35px');
        contenedorBtnAcciones.append(botonPase);

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
        valueNames: ['Documento', 'Nombre', 'Area']
    };

    var featureList = new List('ContenedorPrincipal', options);
}

$(".pase-btn").click(function () {
    location.href = "../FormulariosOtros/Pases.aspx";
});