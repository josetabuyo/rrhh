var AdministradorDeAreas = function () {
    var areas = JSON.parse($('#areasJSON').val());
    contenedorPlanilla = $('#ContenedorPlanilla');
    var columnas = [];

    columnas.push(new Columna("Área", { generar: function (un_area) {
        return un_area.Nombre;
    }
    }));
    columnas.push(new Columna("Responsable", { generar: function (un_area) {
        return un_area.datos_del_responsable.Apellido + ", " + un_area.datos_del_responsable.Nombre;
    }
    }));
    columnas.push(new Columna("Teléfonos", { generar: function (un_area) {
        var telefonos = "";
        for (var i = 0; i < un_area.DatosDeContacto.length; i++) {
            if (un_area.DatosDeContacto[i].Id == 1) {
                telefonos += un_area.DatosDeContacto[i].Dato + ", ";
            }
        }
        if (telefonos.length > 0) telefonos = telefonos.substring(0, telefonos.length - 2);
        return telefonos;
    }
    }));
    columnas.push(new Columna("Fax", { generar: function (un_area) {
        var faxes = "";
        for (var i = 0; i < un_area.DatosDeContacto.length; i++) {
            if (un_area.DatosDeContacto[i].Id == 2) {
                faxes += un_area.DatosDeContacto[i].Dato + ", ";
            }
        }
        if (faxes.length > 0) faxes = faxes.substring(0, faxes.length - 2);
        return faxes;
    }
    }));
    columnas.push(new Columna("Correo Electrónico", { generar: function (un_area) {
        var mails = "";
        for (var i = 0; i < un_area.DatosDeContacto.length; i++) {
            if (un_area.DatosDeContacto[i].Id == 3) {
                mails += un_area.DatosDeContacto[i].Dato + ", ";
            }
        }
        if (mails.length > 0) mails = mails.substring(0, mails.length - 2);
        return mails;
    }
    }));
    columnas.push(new Columna("Dirección", { generar: function (un_area) {
        return un_area.Direccion;
    }
    }));

    PlanillaAreas = new Grilla(columnas);

    PlanillaAreas.AgregarEstilo("tabla_macc");
    PlanillaAreas.AgregarEstilo("tabla_protocolo");

    PlanillaAreas.SetOnRowClickEventHandler(function (un_area) {
        var vista = new VistaDeArea({area:un_area});
    });

    PlanillaAreas.CargarObjetos(areas);
    PlanillaAreas.DibujarEn(contenedorPlanilla);

    var options = {
        valueNames: ['Área', 'Responsable', 'Teléfonos', 'Fax', 'Correo Electrónico', 'Dirección']
    };

    var featureList = new List('ContenedorPlanilla', options);
}
