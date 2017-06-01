var contador_guardado = 0;
var ModificarAreas_Direccion = {

    Iniciar: function () {
        var _this = this;
        _this.DefinirEventos();
        _this.CargarCombos();
        _this.SettearValores(area.DireccionCompleta)

    },

    DefinirEventos: function () {
        var _this = this;
        $('#btn_guardar_direccion').click(function () {
            _this.GuardarCambiosEnDireccion();
        });
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
        });

        $('#btn_buscarEdificioPorCodigoPostal').click(function () {
            _this.CargarComboEdificioPorCodigoPostal(null, $('#txt_oficina_localidad').val());
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
        });

        $('#cmb_edificio_localidad').change(function () {
            $('#txt_oficina_codigopostal').val(area.DireccionCompleta.CodigoPostal);
        });

//        $('#cmb_direccion_oficina').change(function () {
//            area.DireccionCompleta.IdOficina = $('#cmb_direccion_oficina').val();
//            _this.CargarDatosDeOficina();
//        });

        $('#bnt_buscar_localidad').click(function () {
            _this.CargarDatosDeCodigoPostal($('#txt_oficina_codigopostal').val());
            $("#ui-accordion-accordion-header-1").click();
            $("#titulo_pasos").text("Modificación de la Dirección del Área - PASO 2 DE 4")
        });

//        $('#cmb_direccion_edificio').change(function () {
//            area.DireccionCompleta.IdEdificio = $('#cmb_direccion_edificio').val();
//            _this.CargarDatosDeEdificio(area.DireccionCompleta.IdEdificio);
//            _this.CargarComboOficina(area.DireccionCompleta.IdOficina, area.DireccionCompleta.IdEdificio);
//        });

    },
    CargarCombos: function () {

//        if (area.DireccionCompleta.Localidad != null) {
//            this.CargarComboEdificio(area.DireccionCompleta.IdEdificio, area.DireccionCompleta.Localidad.Id);
//        }

//        this.CargarComboOficina(area.DireccionCompleta.IdOficina, area.DireccionCompleta.IdEdificio);
    },

    GuardarCambiosEnDireccion: function () {
        var resultado = Backend.ejecutarSincronico("BuscarCambiosEnDireccion", [{ IdArea: area.Id}]);

        if (resultado != "" && contador_guardado < 1) {
            $('#txt_resultado').text(resultado)
            $('#txt_resultado').css("color", "Red");
            //alertify.alert(resultado); //@TODO: cambiar por un texto en la misma pantalla
            contador_guardado = contador_guardado + 1;
        } else {
            var resultado = Backend.ejecutarSincronico("GuardarCambiosEnDireccion", [{
                IdArea: area.Id,
                IdLocaldiad: area.DireccionCompleta.Localidad.Id,
                IdPartido: area.DireccionCompleta.Localidad.IdPartido,
                IdProvincia: area.DireccionCompleta.Localidad.IdProvincia,
                CodigoPostal: area.DireccionCompleta.Localidad.CodigoPostal,
                NombreLocalidad: area.DireccionCompleta.Localidad.Nombre,
                NombrePartido: area.DireccionCompleta.Localidad.NombrePartido,
                NombreProvincia: area.DireccionCompleta.Localidad.NombreProvincia,
                IdEdificio: parseInt(area.DireccionCompleta.IdEdificio),
                Calle: area.DireccionCompleta.Calle,
                Numero: area.DireccionCompleta.Numero,
                IdOficina: parseInt(area.DireccionCompleta.IdOficina),
                Dto: area.DireccionCompleta.Dto,
                Piso: area.DireccionCompleta.Piso,
                UF: area.DireccionCompleta.UF
            }]);

            if (resultado == "") {
                $('#txt_resultado').text("La modificación de la dirección se envió correctamente. Los cambios en la misma se verá reflejados cuando sean aprobados por Recursos Humanos. Puede cerrar esta ventana.")
                $('#txt_resultado').css("color", "Green");
            } else {
                $('#txt_resultado').text(resultado);
                $('#txt_resultado').css("color", "Red");
            }
        }
    },
    CargarDatosDeCodigoPostal: function (codigo_postal) {
        var localidad = Backend.ejecutarSincronico("CargarDatosDeCodigoPostal", [{
            CodigoPostal: parseInt(codigo_postal)
        }]);
        if (localidad.CodigoPostal != 0) {
            $("#input_provincia").val(localidad.NombreProvincia);
            $("#input_provincia").attr("numero", localidad.IdProvincia);
            $("#input_localidad").val(localidad.Nombre);
            $("#input_localidad").attr("numero", localidad.Id);
        } else {
            $('#txt_oficina_codigopostal').val("");
            $("#input_provincia").val("CP: " + codigo_postal + " Erróneo");
            $("#input_provincia").attr("numero", 0);
            $("#input_localidad").val("CP: " + codigo_postal + " Erróneo");
            $("#input_localidad").attr("numero", 0);
        }
    },


    CargarComboEdificio: function (id_seleccion, id_localildad) {

        $('#cmb_direccion_edificio').empty();
        $('#cmb_direccion_edificio').append('<option value="0"></option>');
        var edificios = Backend.ejecutarSincronico("ObtenerEdificiosPorLocalidad", [{ IdLocalidad: parseInt(id_localildad)}]);

        if (edificios.length > 0) {
            for (var i = 0; i < edificios.length; i++) {
                if (edificios[i].Descripcion != "No Especificado") {
                    $('#cmb_direccion_edificio').append('<option value="' + edificios[i].Id + '">' + edificios[i].Descripcion + '</option>');
                }
            }
        }
        $('#cmb_direccion_edificio').val("0");

    },
    CargarComboEdificioPorCodigoPostal: function (id_seleccion, id_codigo_postal) {

        var combo = $('#cmb_direccion_edificio');
        var combo2 = $('#cmb_oficina_edificio');
        combo.empty();
        combo2.empty();
        var edificios = Backend.ejecutarSincronico("ObtenerEdificiosPorCodigoPostal", [{ CodigoPostal: parseInt(id_codigo_postal)}]);

        if (edificios.length > 0) {
            for (var i = 0; i < edificios.length; i++) {
                combo.append('<option value="' + edificios[i].Id + '">' + edificios[i].Descripcion + '</option>');
                combo2.append('<option value="' + edificios[i].Id + '">' + edificios[i].Descripcion + '</option>');
            }
            if (id_seleccion != null) {
                combo.val(id_seleccion).change();
                combo2.val(id_seleccion).change();
            }

        }

    },

    //no se usa el id de seleccion
    CargarComboOficina: function (id_seleccion, id_edificio) {
        var _this = this;
        var combo = $('#cmb_direccion_oficina');
        combo.empty();
        var id_area = area.Id;
        var oficinas = Backend.ejecutarSincronico("ObtenerOficinaPorEdificio", [{ IdEdificio: parseInt(id_edificio), IdArea: parseInt(id_area)}]);

        if (oficinas.length > 0) {
            for (var i = 0; i < oficinas.length; i++) {
                combo.append('<option value="' + oficinas[i].Id + '">' + oficinas[i].Descripcion + '</option>');
            }
        }
        if (oficinas.length > 0) {
            area.DireccionCompleta.IdOficina = oficinas[0].Id;
        }
        _this.CargarDatosDeOficina();
    },

    //GUARDADOS
    GuardarCambiosEnOficina: function () {
        var _this = this;
        if (_this.OficinaValido()) {
            var id = _this.WS_GuardarOficinaPendienteDeAptobacion();
            if (id != 0) {
                _this.SettearValorOficina();
                alertify.alert("Se han modificado los datos de la Oficina");
                _this.CargarComboOficina(id, area.DireccionCompleta.IdEdificio);
                _this.MostarPantallaDireccion();
                _this.SettearValores(area.DireccionCompleta);
            } else {
                alertify.alert("Error al intentar agregar la Oficina");
            }
        }
    },

    GuardarCambiosEnEdificio: function () {
        var _this = this;
        $('#bnt_buscar_localidad').click();
        if (_this.EdificioValido()) {

            var id = _this.WS_GuardarEdificioPendienteDeAptobacion();
            if (id != 0) {
                _this.SettearValorEdificio();
                alertify.alert("Se han modificado los datos del Edificio");
                _this.CargarComboEdificio(id, area.DireccionCompleta.Localidad.Id);
                _this.MostarPantallaOficina();
            } else {
                alertify.alert("Error al intentar agregar el Edificio");
            }
        }
    },

    //*******************************************************
    //******************MÉTODOS AUXILIARES******************
    //*******************************************************
    //MÉTODOS AUXILIARES PARA EDIFICIO
    WS_GuardarEdificioPendienteDeAptobacion: function () {
        return Backend.ejecutarSincronico("GuardarEdificioPendienteDeAptobacion", [{
            IdProvincia: parseInt($('#cmb_edificio_provincia').find('option:selected').val()),
            NombreProvincia: $('#cmb_edificio_provincia').find('option:selected').text(),
            IdLocalidad: parseInt($('#cmb_edificio_localidad').find('option:selected').val()),
            NombreLocalidad: $('#cmb_edificio_localidad').find('option:selected').text(),
            CodigoPostal: parseInt($('#txt_oficina_codigopostal').val()),
            Calle: $('#txt_edificio_calle').val(),
            Numero: $('#txt_edificio_numero').val()
        }]);
    },

    EdificioValido: function () {
        return true;
        // return $('#div_agregar_edificio').esValido();
    },

    SettearValorEdificio: function () {
        area.DireccionCompleta.Localidad.IdProvincia = $('#cmb_edificio_provincia').find('option:selected').val();
        area.DireccionCompleta.Localidad.NombreProvincia = $('#cmb_edificio_provincia').find('option:selected').text();
        area.DireccionCompleta.Localidad.Id = $('#cmb_edificio_localidad').find('option:selected').val();
        area.DireccionCompleta.Localidad.Nombre = $('#cmb_edificio_localidad').find('option:selected').text();
        area.DireccionCompleta.CodigoPostal = $('#txt_oficina_codigopostal').val();
        area.DireccionCompleta.Calle = $('#txt_edificio_calle').val();
        area.DireccionCompleta.Numero = $('#txt_edificio_numero').val();
    },

    MostarPantallaOficina: function () {
        $("#div_agregar_oficina").show();
        $("#div_agregar_edificio").hide();
        $("#div_contenido_direccion").hide();
    },
    //MÉTODOS AUXILIARES PARA OFICINA

    WS_GuardarOficinaPendienteDeAptobacion: function () {
        return Backend.ejecutarSincronico("GuardarOficinaPendienteDeAptobacion", [{
            IdEdificio: parseInt($('#cmb_oficina_edificio').find('option:selected').val()),
            Piso: $('#txt_oficina_piso').val(),
            Oficina: $('#txt_oficina_oficina').val(),
            UF: $('#txt_oficina_uf').val()
        }]);
    },
    SettearValorOficina: function () {
        area.DireccionCompleta.Piso = $('#txt_oficina_piso').val();
        area.DireccionCompleta.Dto = $('#txt_oficina_oficina').val();
        area.DireccionCompleta.UF = $('#txt_oficina_uf').val();
        $('#cmb_direccion_edificio').val($('#cmb_oficina_edificio').val()).change();
    },
    OficinaValido: function () {
        return true;
    },
    MostarPantallaDireccion: function () {
        $("#div_agregar_oficina").hide();
        $("#div_agregar_edificio").hide();
        $("#div_contenido_direccion").show();
    },

    //SETTEAR DATOS
    SettearValores: function (direccion) {
        if (direccion.Localidad != null) {
            $("#txt_direccion_CodigoPostal").val(direccion.Localidad.CodigoPostal);
            $("#cmb_direccion_localidad").append('<option value=' + direccion.Localidad.CodigoPostal + '>' + direccion.Localidad.Nombre + '</option>');
            $("#txt_direccion_Partido").val(direccion.Localidad.NombrePartido);
            $("#txt_direccion_Provincia").val(direccion.Localidad.NombreProvincia);
        }


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

        if (direccion.Localidad != null) {
            $("#cmb_edificio_provincia").val(direccion.Localidad.NombreProvincia);
            $("#cmb_edificio_localidad").val(direccion.Localidad.CodigoPostal);
            $("#txt_oficina_codigopostal").val(direccion.Localidad.CodigoPostal);
        }
        $("#txt_edificio_calle").val(direccion.Calle);
        $("#txt_edificio_numero").val(direccion.Numero);

    },
    CargarDatosDeEdificio: function () {
        var _this = this;
        var edificio = Backend.ejecutarSincronico("ObtenerEdificioPorId", [{ IdEdificio: parseInt(area.DireccionCompleta.IdEdificio)}]);

        if (parseInt(edificio.Id) != 0) {
            area.DireccionCompleta.Calle = edificio.Calle;
            area.DireccionCompleta.Numero = edificio.Numero;
            area.DireccionCompleta.Nombre = edificio.Nombre;
            area.DireccionCompleta.Localidad.CodigoPostal = edificio.Localidad.CodigoPostal;
            area.DireccionCompleta.Localidad.Id = edificio.Localidad.Id;
            area.DireccionCompleta.Localidad.IdPartido = edificio.Localidad.IdPartido;
            area.DireccionCompleta.Localidad.IdProvincia = edificio.Localidad.IdProvincia;
            area.DireccionCompleta.Localidad.Nombre = edificio.Localidad.Nombre;
            area.DireccionCompleta.Localidad.NombrePartido = edificio.Localidad.NombrePartido;
            area.DireccionCompleta.Localidad.NombreProvincia = edificio.Localidad.NombreProvincia;


            var direccion = area.DireccionCompleta;
            $("#txt_direccion_CodigoPostal").val(direccion.Localidad.CodigoPostal);
            $("#cmb_direccion_localidad").append('<option value=' + direccion.Localidad.CodigoPostal + '>' + direccion.Localidad.Nombre + '</option>');

            $("#txt_direccion_Partido").val(direccion.Localidad.NombrePartido);
            $("#txt_direccion_Provincia").val(direccion.Localidad.NombreProvincia);

            $("#txt_direccion_Calle").val(direccion.Calle);
            $("#txt_direccion_Nro").val(direccion.Numero);


            $("#txt_edificio_calle").val(direccion.Calle);
            $("#txt_oficina_codigopostal").val(direccion.Localidad.CodigoPostal);
            $("#txt_edificio_numero").val(direccion.Numero);
        }

    },

    CargarDatosDeOficina: function () {
        var _this = this;
        var oficina = Backend.ejecutarSincronico("ObtenerOficinaPorId", [{ IdOficina: parseInt(area.DireccionCompleta.IdOficina)}]);


        area.DireccionCompleta.Piso = oficina.Piso;
        area.DireccionCompleta.Dto = oficina.Dto;
        area.DireccionCompleta.UF = oficina.UF;

        $('#txt_direccion_Piso').val(area.DireccionCompleta.Piso);
        $('#txt_direccion_Oficina').val(area.DireccionCompleta.Dto);
        $('#txt_direccion_UF').val(area.DireccionCompleta.UF);

    },
    CargarDatosEdificio: function () {
        var _this = this;
        _this.CargarDatosDeCodigoPostal($('#txt_oficina_codigopostal').val());
        $('#txt_edificio_calle').val(area.DireccionCompleta.Calle);
        if (area.DireccionCompleta.Localidad != null) {
            $('#txt_oficina_codigopostal').val(area.DireccionCompleta.Localidad.CodigoPostal);
        }
        $('#txt_edificio_numero').val(area.DireccionCompleta.Numero);
    },

    CargarDatosOficina: function () {
        $('#txt_oficina_piso').val(area.DireccionCompleta.Piso);
        $('#txt_oficina_oficina').val(area.DireccionCompleta.Dto);
        $('#txt_oficina_uf').val(area.DireccionCompleta.UF);
        if (area.DireccionCompleta.Localidad != null) {
            $('#txt_oficina_localidad').val(area.DireccionCompleta.Localidad.CodigoPostal);
        }


    }

}



        