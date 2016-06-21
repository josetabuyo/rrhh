var contador_guardado = 0;
var ModificarAreas_Contacto = {

    Iniciar: function () {
        var _this = this;
        _this.DefinirEventos();
        _this.CargarCombos();
    },

    DefinirEventos: function () {
        var _this = this;
        $('#btn_guardar_contacto').click(function () {
            _this.GuardarCambiosEnContacto();
        });
    },
    CargarCombos: function () {
        this.CargarComboTipoContacto();
    },

    GuardarCambiosEnContacto: function () {
        var resultado = Backend.ejecutarSincronico("BuscarCambiosEnContacto", [{ IdArea: area.Id}]);

        if (resultado != "" && contador_guardado < 1) {
            alertify.alert(resultado);
            contador_guardado = contador_guardado + 1;
        } else {
            var resultado = Backend.ejecutarSincronico("GuardarCambiosEnContacto", [{
                IdArea: area.Id,
                Estado: 1,
                TipoDato: parseInt($('#cmb_TipoContacto').val()),
                Dato: $('#txt_Contacto').val(),
                Orden: parseInt($('#txt_Orden').val())
            }]);

            if (resultado == "") {
                $('#txt_resultado').text("La modificación de la contacto se envió correctamente. Los cambios en la misma se verá reflejados cuando sean aprobados por Recursos Humanos. Puede cerrar esta ventana.")
                $('#txt_resultado').css("color", "Green");
            } else {
                $('#txt_resultado').text(resultado);
                $('#txt_resultado').css("color", "Red");
            }
        }
    },

    CargarComboTipoContacto: function () {

        var combo = $('#cmb_TipoContacto');
        combo.empty();

        var tipos = Backend.ejecutarSincronico("ObtenerTiposDeContacto", []);

        if (tipos.length > 0) {
            for (var i = 0; i < tipos.length; i++) {
                combo.append('<option value="' + tipos[i].Id + '">' + tipos[i].Descripcion + '</option>');
            }
        }
    },

    ContactoValido: function () {
        return true;
        // return $('#div_agregar_edificio').esValido();
    }
}



        