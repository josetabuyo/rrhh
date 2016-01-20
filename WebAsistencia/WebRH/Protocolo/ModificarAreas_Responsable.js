var ModificarAreas_Responsable = {

    Iniciar: function () {
        _this = this;
        $('#btn_buscar_responsable').click(function () {
            _this.BuscarPersonal();
        });
        $('#txt_responsable_documento').blur(function () {
            _this.BuscarPersonal();
        });
        

        $('#txt_responsable_documento').val(area.Responsable.Documento);
        $('#txt_responsable_id_interna').val(area.Responsable.IdInterna);
        $('#txt_responsable_nombre').val(area.Responsable.Nombre);
        $('#txt_responsable_apellido').val(area.Responsable.Apellido);
        $('#txt_responsable_documento').val(area.Responsable.Documento);
        $('#txt_responsable_documento').val(area.Responsable.Documento);
        $('#txt_responsable_documento').val(area.Responsable.Documento);
        $('#txt_responsable_documento').val(area.Responsable.Documento);
        $('#txt_responsable_documento').val(area.Responsable.Documento);
        $('#txt_responsable_documento').val(area.Responsable.Documento);

        _this.ComboTratamientoPersona();
        _this.SeleccionarValores()
    },
    SeleccionarValores: function () {


        $('#cmb_responsable_tratamiento_persona').find('option[value="' + area.Responsable.TratamientoPersona.Id + '"]').attr("selected", "selected");
    },
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

    BuscarPersonal: function () {

        if ($("#div_documento").esValido()) {
            var criterio = {}
            criterio.Documento = parseInt($("#txt_responsable_documento").val());
            var persona = Backend.ejecutarSincronico("BuscarPersonas", [JSON.stringify(criterio)]);
            if (persona.length > 0) {
                $("#txt_responsable_id_interna").val(persona[0].Legajo);
                $("#txt_responsable_nombre").val(persona[0].Nombre);
                $("#txt_responsable_apellido").val(persona[0].Apellido)
                $("#div_mensaje").hide();
                $("#txt_responsable_id_interna").prop('disabled', true);
                $("#txt_responsable_nombre").prop('disabled', true);
                $("#txt_responsable_apellido").prop('disabled', true);
            } else {
                $("#div_mensaje").show();
                $("#txt_responsable_id_interna").prop('disabled', false);
                $("#txt_responsable_nombre").prop('disabled', false);
                $("#txt_responsable_apellido").prop('disabled', false);
                $("#txt_responsable_id_interna").val("");
                $("#txt_responsable_nombre").val("");
                $("#txt_responsable_apellido").val("")
                //Habilitar todo
            }
        }
    },

    CargarCombosResponsable: function () { }
}



        