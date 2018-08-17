var ModificarAreas_Asistente = {

    Iniciar: function () {
        _this = this;
        _this.CargarEventos();
        // _this.DatosDelResponsable(area.Responsable);
        // _this.ComboTratamientoPersona();
        // _this.ComboTratamientoTitulo();
        // _this.ComboCargoFuncion();
    },

    CargarEventos: function () {
        $('#btn_buscar_asistente').click(function () {
            _this.BuscarPersonal();
        });
        $('#txt_asistente_documento').blur(function () {
            _this.BuscarPersonal();
        });
    },

    CambiarAreaCombo: function (combo, tipo) {
        if (tipo == 1) {
            area.Responsable.TratamientoPersona.Id = combo.find('option:selected').val();
            area.Responsable.TratamientoPersona.Descripcion = combo.find('option:selected').text();
        };
        if (tipo == 2) {
            area.Responsable.TratamientoTitulo.Id = combo.find('option:selected').val();
            area.Responsable.TratamientoTitulo.Descripcion = combo.find('option:selected').text();
        };
        if (tipo == 3) {
            area.Responsable.CargoFuncion.Id = combo.find('option:selected').val();
            area.Responsable.CargoFuncion.Descripcion = combo.find('option:selected').text();
        };
    },

    DatosDelResponsable: function (persona) {
        if (persona.Documento != 0) {
            _this = this;
            $("#div_mensaje").hide();
            $('#txt_responsable_documento').val(persona.Documento); 0
            $('#txt_responsable_id_interna').val(persona.IdInterna);
            $('#txt_responsable_nombre').val(persona.Nombre);
            $('#txt_responsable_apellido').val(persona.Apellido);

            _this.CheckearDatosResponsable(persona.ActoAdministrativo, $('#check_acto_administrativo'));
            _this.CheckearDatosResponsable(persona.Contratos, $('#check_contratos'));
            _this.CheckearDatosResponsable(persona.Facturas, $('#check_facturas'));
            _this.CheckearDatosResponsable(persona.DDJJRecibos, $('#check_ddjj_recibo'));

            $('#cmb_responsable_tratamiento_persona').val(persona.TratamientoPersona.Id);
            $('#cmb_responsable_tratamiento_titulo').val(persona.TratamientoTitulo.Id);
            $('#cmb_responsable_cargo_funcion').val(persona.CargoFuncion.Id);

            $("#txt_responsable_id_interna").prop('disabled', true);
            $("#txt_responsable_nombre").prop('disabled', true);
            $("#txt_responsable_apellido").prop('disabled', true);
        }
    },

    CheckearDatosResponsable: function (dato, check) {
        if (dato == "Si") {
            check.attr('checked', true);
        } else {
            check.attr('checked', false);
        }
    },

    BuscarPersonal: function () {
        _this = this;
        if ($("#txt_asistente_documento").esValido()) {
                var criterio = {}
                criterio.Documento = parseInt($("#txt_asistente_documento").val());
                var persona = Backend.ejecutarSincronico("BuscarPersonas", [JSON.stringify(criterio)]);
                if (persona.length > 0) {
                    _this.LimpiarDatos();
                    $("#div_mensaje").hide();
                    area.Responsable.IdInterna = persona[0].Legajo;
                    area.Responsable.Nombre = persona[0].Nombre;
                    area.Responsable.Apellido = persona[0].Apellido;
                    area.Responsable.Documento = persona[0].Documento;
                    area.Responsable.NombreApellido = persona[0].Apellido + ", " + persona[0].Nombre;
                    persona.ActoAdministrativo = "No";
                    //                    _this.CheckearDatosResponsable(persona.Contratos, $('#check_contratos'));
                    //                    _this.CheckearDatosResponsable(persona.Facturas, $('#check_facturas'));
                    //                    _this.CheckearDatosResponsable(persona.DDJJRecibos, $('#check_ddjj_recibo'));


                    $("#txt_responsable_id_interna").prop('disabled', true);
                    $("#txt_responsable_nombre").prop('disabled', true);
                    $("#txt_responsable_apellido").prop('disabled', true);
                } else {
                    _this.LimpiarDatos();
                }       
        }
    },

    LimpiarDatos: function () {

        $("#div_mensaje").show();
        $("#txt_responsable_id_interna").prop('disabled', false);
        $("#txt_responsable_nombre").prop('disabled', false);
        $("#txt_responsable_apellido").prop('disabled', false);
        $("#txt_responsable_id_interna").val("");
        $("#txt_responsable_nombre").val("");
        $("#txt_responsable_apellido").val("")

        $('#cmb_responsable_cargo_funcion').val(99).change();
        $('#cmb_responsable_tratamiento_titulo').val(99).change();
        $('#cmb_responsable_tratamiento_persona').val(99).change();

        $('#check_acto_administrativo').attr('checked', false);
        $('#check_contratos').attr('checked', false);
        $('#check_facturas').attr('checked', false);
        $('#check_ddjj_recibo').attr('checked', false);

    },

    //*****************************************************************//
    //*************************COMBOS**********************************//
    //*****************************************************************//
    ComboTratamientoPersona: function () {
        var respuesta;
        var combo = $('#cmb_responsable_tratamiento_persona');
        combo.append('<option value="' + 99 + '">' + "" + '</option>')
        Backend.ejecutar("ObtenerTratamientoPersonas",
            "",
            function (respuesta) {
                for (var i = 0; i < respuesta.length; i++) {
                    combo.append('<option value="' + respuesta[i].Id + '">' + respuesta[i].Descripcion + '</option>');
                }
                if (area.Responsable.TratamientoPersona.Id != "") {
                    $('#cmb_responsable_tratamiento_persona').val(area.Responsable.TratamientoPersona.Id).change();
                }

            },
            function (errorThrown) {
                alertify.alert(errorThrown);
            }
        );
    },

    ComboTratamientoTitulo: function () {
        var respuesta;
        var combo = $('#cmb_responsable_tratamiento_titulo');
        combo.append('<option value="' + 99 + '">' + "" + '</option>')
        Backend.ejecutar("ObtenerTratamientoTitulos",
            "",
            function (respuesta) {
                for (var i = 0; i < respuesta.length; i++) {
                    combo.append('<option value="' + respuesta[i].Id + '">' + respuesta[i].Descripcion + '</option>');
                }
                if (area.Responsable.TratamientoTitulo.Id != "") {
                    $('#cmb_responsable_tratamiento_titulo').val(area.Responsable.TratamientoTitulo.Id).change();
                }

            },
            function (errorThrown) {
                alertify.alert(errorThrown);
            }
        );
    },

    ComboCargoFuncion: function () {
        var respuesta;
        var combo = $('#cmb_responsable_cargo_funcion');
        combo.append('<option value="' + 99 + '">' + "" + '</option>')
        Backend.ejecutar("ObtenerCargosFunciones",
            "",
            function (respuesta) {
                for (var i = 0; i < respuesta.length; i++) {
                    combo.append('<option value="' + respuesta[i].Id + '">' + respuesta[i].Descripcion + '</option>');
                }
                if (area.Responsable.CargoFuncion.Id != "") {
                    $('#cmb_responsable_cargo_funcion').val(area.Responsable.CargoFuncion.Id).change();
                }

            },
            function (errorThrown) {
                alertify.alert(errorThrown);
            }
        );
    }
}



        