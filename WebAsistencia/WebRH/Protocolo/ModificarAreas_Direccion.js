var ModificarAreas_Direccion = {

    Iniciar: function () {
        var _this = this;
        _this.DefinirEventos();
        _this.CargarCombos();
        _this.SettearValores(area.DireccionCompleta)

    },

    DefinirEventos: function () {
        var _this = this;
        $('#btn_nuevo_edificio').click(function () {
            $("#div_agregar_edificio").show();
            $("#div_agregar_oficina").hide();
            _this.CargarDatosEdificio();

        });

        $('#btn_nueva_oficina_edificio').click(function () {
            $("#div_agregar_oficina").show();
            $("#div_agregar_edificio").hide();
            $("#div_contenido_direccion").hide();
            _this.CargarDatosOficina();
        });

        $('#btn_volver_edificio').click(function () {
            $("#div_agregar_oficina").show();
            $("#div_agregar_edificio").hide();
            $("#div_contenido_direccion").hide();
            // _this.ReescribirDatos();

        });

        $('#btn_guardar_oficina').click(function () {
            _this.GuardarCambiosEnOficina();
        });
        $('#btn_guardar_edificio').click(function () {
            _this.GuardarCambiosEnEdificio();
        });

        $('#btn_volver_oficina').click(function () {
            $("#div_agregar_oficina").hide();
            $("#div_agregar_edificio").hide();
            $("#div_contenido_direccion").show();
            //_this.ReescribirDatos();
        });


        $('#cmb_edificio_provincia').change(function () {
            $('#cmb_edificio_localidad').empty();
            // area.DireccionCompleta.Localidad.IdProvincia = $('#cmb_edificio_provincia').find('option:selected').val();
            _this.CargarComboLocalidad($('#cmb_edificio_provincia').find('option:selected').val());
        });

        $('#cmb_edificio_localidad').change(function () {
            //            area.DireccionCompleta.CodigoPostal = "";
            $('#txt_oficina_codigopostal').val(area.DireccionCompleta.CodigoPostal);
        });

        $('#cmb_direccion_edificio').change(function () {
            area.DireccionCompleta.IdEdificio = $('#cmb_direccion_edificio').val();
            _this.CargarComboOficina();
            _this.CargarDatosDeEdificio();
        });

    },
    CargarCombos: function () {
        this.CargarComboProvincia();
        this.CargarComboLocalidad(area.DireccionCompleta.Localidad.IdProvincia);
        this.CargarComboEdificio();
        this.CargarComboOficina();
    },

    CargarDatosEdificio: function () {
        $('#cmb_edificio_localidad').val(area.DireccionCompleta.Localidad.Id).change();
        $('#cmb_edificio_provincia').val(area.DireccionCompleta.Localidad.IdProvincia).change();
        $('#txt_edificio_calle').val(area.DireccionCompleta.Calle);
        $('#txt_oficina_codigopostal').val(area.DireccionCompleta.Localidad.CodigoPostal);
        $('#txt_edificio_numero').val(area.DireccionCompleta.Numero);
    },

    CargarDatosOficina: function () {
        $('#txt_oficina_piso').val(area.DireccionCompleta.Piso);
        $('#txt_oficina_oficina').val(area.DireccionCompleta.Dto);
        $('#txt_oficina_uf').val(area.DireccionCompleta.UF);
    },

    CargarDatosDeEdificio: function () {
        var _this = this;
        var edificio = Backend.ejecutarSincronico("ObtenerEdificioPorId", [{ IdEdificio: parseInt(area.DireccionCompleta.IdEdificio)}]);


        area.DireccionCompleta.Calle = edificio.Calle
        area.DireccionCompleta.Numero = edificio.Numero
        area.DireccionCompleta.Nombre = edificio.Nombre
        area.DireccionCompleta.Localidad.CodigoPostal = edificio.Localidad.CodigoPostal;
        area.DireccionCompleta.Localidad.Id = edificio.Localidad.Id;
        area.DireccionCompleta.Localidad.IdPartido = edificio.Localidad.IdPartido;
        area.DireccionCompleta.Localidad.IdProvincia = edificio.Localidad.IdProvincia;
        area.DireccionCompleta.Localidad.Nombre = edificio.Localidad.Nombre;
        area.DireccionCompleta.Localidad.NombrePartido = edificio.Localidad.NombrePartido;
        area.DireccionCompleta.Localidad.NombreProvincia = edificio.Localidad.NombreProvincia;

        //        } else {
        //            area.DireccionCompleta.Calle = "";
        //            area.DireccionCompleta.Numero = "";
        //            area.DireccionCompleta.Nombre = "";
        //            area.DireccionCompleta.Localidad.CodigoPostal = "";
        //            area.DireccionCompleta.Localidad.Id = "";
        //            area.DireccionCompleta.Localidad.IdPartido = "";
        //            area.DireccionCompleta.Localidad.IdProvincia = "";
        //            area.DireccionCompleta.Localidad.Nombre = "";
        //            area.DireccionCompleta.Localidad.NombrePartido = "";
        //            area.DireccionCompleta.Localidad.NombreProvincia = "";
        //        }
        var direccion = area.DireccionCompleta;
        $("#txt_direccion_CodigoPostal").val(direccion.Localidad.CodigoPostal);
        $("#txt_direccion_Partido").val(direccion.Localidad.NombrePartido);
        $("#txt_direccion_Provincia").val(direccion.Localidad.NombreProvincia);

        $("#txt_direccion_Calle").val(direccion.Calle);
        $("#txt_direccion_Nro").val(direccion.Numero);


        $("#txt_edificio_calle").val(direccion.Calle);
        $("#txt_oficina_codigopostal").val(direccion.Localidad.CodigoPostal);
        $("#txt_edificio_numero").val(direccion.Numero);
    },

    CargarComboProvincia: function () {
        var combo = $('#cmb_edificio_provincia');

        var provincias = Backend.ejecutarSincronico("BuscarProvincias", [{ IdPais: 0}]);

        if (provincias.length > 0) {
            for (var i = 0; i < provincias.length; i++) {
                combo.append('<option value="' + provincias[i].Id + '">' + provincias[i].Nombre + '</option>');
            }
        }
    },

    CargarComboLocalidad: function (provincia) {
        var combo = $('#cmb_direccion_localidad');
        var combo2 = $('#cmb_edificio_localidad');

        var localidades = Backend.ejecutarSincronico("BuscarLocalidades", [{ IdProvincia: parseInt(provincia)}]);

        if (localidades.length > 0) {
            for (var i = 0; i < localidades.length; i++) {
                combo.append('<option value="' + localidades[i].Id + '">' + localidades[i].Nombre + '</option>');
                combo2.append('<option value="' + localidades[i].Id + '">' + localidades[i].Nombre + '</option>');
            }
            if (provincia.toString() != "") {
                if (provincia == 0) {
                    $('#cmb_direccion_localidad').val(localidades[0].Id).change();
                    $('#cmb_edificio_localidad').val(localidades[0].Id).change();
                } else {
                    $('#cmb_direccion_localidad').val(area.DireccionCompleta.Localidad.IdLocalidad).change();
                    $('#cmb_edificio_localidad').val(area.DireccionCompleta.Localidad.IdLocalidad).change();
                }
            }
        }
    },

    CargarComboEdificio: function () {
        var combo = $('#cmb_direccion_edificio');
        var combo2 = $('#cmb_oficina_edificio');

        var id_localidad = area.DireccionCompleta.Localidad.Id;
        var edificios = Backend.ejecutarSincronico("ObtenerEdificiosPorLocalidad", [{ IdLocalidad: parseInt(id_localidad)}]);

        if (edificios.length > 0) {
            for (var i = 0; i < edificios.length; i++) {
                combo.append('<option value="' + edificios[i].Id + '">' + edificios[i].Descripcion + '</option>');
                combo2.append('<option value="' + edificios[i].Id + '">' + edificios[i].Descripcion + '</option>');
            }
        }
    },

    CargarComboOficina: function () {
        var combo = $('#cmb_direccion_oficina');
        combo.empty();
        var id_edificio = area.DireccionCompleta.IdEdificio;
        var id_area = area.Id;
        var oficinas = Backend.ejecutarSincronico("ObtenerOficinaPorEdificio", [{ IdEdificio: parseInt(id_edificio), IdArea: parseInt(id_area)}]);

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

        $('#cmb_direccion_edificio').val(direccion.IdEdificio).change();
        $('#cmb_direccion_oficina').val(direccion.IdOficina).change();

        $("#txt_oficina_piso").val(direccion.Piso);
        $("#txt_oficina_oficina").val(direccion.Dto);
        $("#txt_oficina_uf").val(direccion.UF);

        $('#cmb_oficina_edificio').val(direccion.IdEdificio).change();

        $("#cmb_edificio_provincia").val(direccion.Localidad.NombreProvincia);
        $("#cmb_edificio_localidad").val(direccion.Localidad.CodigoPostal);
        $("#txt_edificio_calle").val(direccion.Calle);
        $("#txt_oficina_codigopostal").val(direccion.Localidad.CodigoPostal);
        $("#txt_edificio_numero").val(direccion.Numero);

    },

    GuardarCambiosEnOficina: function () {
        area.DireccionCompleta.Piso = $('#txt_oficina_piso').val();
        area.DireccionCompleta.Dto = $('#txt_oficina_oficina').val();
        area.DireccionCompleta.UF = $('#txt_oficina_uf').val();
        alertify.alert("Se han modificado los datos de la Oficina");
    },

    GuardarCambiosEnEdificio: function () {
        if ($("#txt_oficina_codigopostal").esValido()) {
            area.DireccionCompleta.CodigoPostal = $('#txt_oficina_codigopostal').val();
            area.DireccionCompleta.Calle = $('#txt_edificio_calle').val();
            area.DireccionCompleta.Numero = $('#txt_edificio_numero').val();
            area.DireccionCompleta.Localidad.Id = $('#cmb_edificio_localidad').find('option:selected').val();
            area.DireccionCompleta.Localidad.IdProvincia = $('#cmb_edificio_provincia').find('option:selected').val();
            area.DireccionCompleta.Localidad.NombreProvincia = $('#cmb_edificio_provincia').find('option:selected').text();

            if ($("#cmb_oficina_edificio option[value='99']").length > 0) {
                $("#cmb_oficina_edificio option[value='99']").remove();
            }
            $('#cmb_oficina_edificio').append('<option value="' + 99 + '">' + area.DireccionCompleta.Calle + ' ' + area.DireccionCompleta.Numero + '</option>');
            $('#cmb_oficina_edificio').val(99).change();

            alertify.alert("Se han modificado los datos del Edificio");

        }
    }
}



        