var ModificarAreas_Direccion = {

    Iniciar: function () {
        _this = this;
        _this.DefinirEventos();
        _this.CargarCombos();
        _this.SettearValores(area.DireccionCompleta)

    },

    DefinirEventos: function () {
        $('#btn_nuevo_edificio').click(function () {
            $("#div_agregar_edificio").show();
            $("#div_agregar_oficina").hide();

        });

        $('#btn_nueva_oficina_edificio').click(function () {
            $("#div_agregar_oficina").show();
            $("#div_agregar_edificio").hide();
            $("#div_contenido_direccion").hide();
        });

        $('#volver_edificio').click(function () {
            $("#div_agregar_oficina").show();
            $("#div_agregar_edificio").hide();
            $("#div_contenido_direccion").hide();

        });

        $('#volver_oficina').click(function () {
            $("#div_agregar_oficina").hide();
            $("#div_agregar_edificio").hide();
            $("#div_contenido_direccion").show();
        });
    },
    CargarCombos: function () {

        var combo = $('#cmb_direccion_localidad');
        var provincia = area.DireccionCompleta.Localidad.IdProvincia;
        var localidades = Backend.ejecutarSincronico("BuscarLocalidades", [{ IdProvincia: provincia}]);

        if (localidades.length > 0) {
            for (var i = 0; i < localidades.length; i++) {
                combo.append('<option value="' + localidades[i].Id + '">' + localidades[i].Nombre + '</option>');
            }
            if (provincia.toString() != "") {
                if (provincia == 0) {
                    $('#cmb_direccion_localidad').val(localidades[0].Id).change();
                } else {
                    $('#cmb_direccion_localidad').val(area.DireccionCompleta.Localidad.IdLocalidad).change();
                }
            }
        }

        var id_localidad = area.DireccionCompleta.Localidad.Id;
        var edificios = Backend.ejecutarSincronico("ObtenerEdificiosPorLocalidad", [{ IdLocalidad: id_localidad}]);

        if (edificios.length > 0) {
            for (var i = 0; i < localidades.length; i++) {
                combo.append('<option value="' + localidades[i].Id + '">' + localidades[i].Nombre + '</option>');
            }
            if (provincia.toString() != "") {
                if (provincia == 0) {
                    $('#cmb_direccion_localidad').val(localidades[0].Id).change();
                } else {
                    $('#cmb_direccion_localidad').val(area.DireccionCompleta.Localidad.IdLocalidad).change();
                }
            }
        }

    },
    SettearValores: function (direccion) {
        $("#txt_direccion_CodigoPostal").val(direccion.Localidad.CodigoPostal);
        $("#txt_direccion_Partido").val(direccion.Localidad.NombrePartido);
        $("#txt_direccion_Provincia").val(direccion.Localidad.NombreProvincia);

    }

}



        