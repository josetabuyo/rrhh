var AdministradorDeAreas = function () {
    var json_areas = JSON.parse($('#areasJSON').val());
    var areas = [];
    for (var i = 0; i < json_areas.length; i++) {
        areas.push(new Area(json_areas[i]));
    }
    contenedorPlanilla = $('#ContenedorPlanilla');
    var columnas = [];

    columnas.push(new Columna("Área", { generar: function (un_area) {
        return un_area.nombre();
    }
    }));
    columnas.push(new Columna("Responsable", { generar: function (un_area) {
        return un_area.responsable();
    }
    }));
    columnas.push(new Columna("Teléfonos", { generar: function (un_area) {
        return un_area.telefonos();
    }
    }));
    columnas.push(new Columna("Fax", { generar: function (un_area) {
        return un_area.faxes();
    }
    }));
    columnas.push(new Columna("Correo Electrónico", { generar: function (un_area) {
        return un_area.mails();
    }
    }));
    columnas.push(new Columna("Dirección", { generar: function (un_area) {
        return un_area.direccion();
    }
    }));

    PlanillaAreas = new Grilla(columnas);

    PlanillaAreas.AgregarEstilo("tabla_macc");
    PlanillaAreas.AgregarEstilo("tabla_protocolo");

    PlanillaAreas.SetOnRowClickEventHandler(function (un_area) {
        var vista = new VistaDeArea({ area: un_area });
    });

    PlanillaAreas.CargarObjetos(areas);
    PlanillaAreas.DibujarEn(contenedorPlanilla);

    var options = {
        valueNames: ['Área', 'Responsable', 'Teléfonos', 'Fax', 'Correo Electrónico', 'Dirección']
    };

    var featureList = new List('ContenedorPlanilla', options);
}
