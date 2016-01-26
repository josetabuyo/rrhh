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

        this.CargarComboLocalidad();
        this.CargarComboEdificio();
        this.CargarComboOficina();
    },

    CargarComboLocalidad: function () {
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
    },

    CargarComboEdificio: function () {
        var combo = $('#cmb_direccion_edificio');
        var id_localidad = area.DireccionCompleta.Localidad.Id;
        var edificios = Backend.ejecutarSincronico("ObtenerEdificiosPorLocalidad", [{ IdLocalidad: id_localidad}]);

        if (edificios.length > 0) {
            for (var i = 0; i < edificios.length; i++) {
                combo.append('<option value="' + edificios[i].Id + '">' + edificios[i].Descripcion + '</option>');
            }
        }
    },

    CargarComboOficina: function () {
        var combo = $('#cmb_direccion_oficina');
        var id_edificio = area.DireccionCompleta.IdEdificio;
        var id_area = area.Id;
        var oficinas = Backend.ejecutarSincronico("ObtenerOficinaPorEdificio", [{ IdEdificio: id_edificio, IdArea: id_area}]);

        if (oficinas.length > 0) {
            for (var i = 0; i < oficinas.length; i++) {
                combo.append('<option value="' + oficinas[i].Id + '">' + oficinas[i].Descripcion + '</option>');
            }
        }
    },

    SettearValores: function (direccion) {
        $("#txt_direccion_CodigoPostal").val(direccion.Localidad.CodigoPostal);
        $("#txt_direccion_Partido").val(direccion.Localidad.NombrePartido);
        $("#txt_direccion_Provincia").val(direccion.Localidad.NombreProvincia);

        $("#txt_direccion_Calle").val(direccion.Calle);
        $("#txt_direccion_Nro").val(direccion.Numero);
        $("#txt_direccion_Piso").val(direccion.Piso);
        $("#txt_direccion_Oficina").val(direccion.Dto);
        $("#txt_direccion_UF").val(direccion.UF);
        
        
        
        
        

    }

}



        