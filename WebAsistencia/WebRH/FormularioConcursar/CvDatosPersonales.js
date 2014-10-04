
var CvDatosPersonales = {
    completarDatos: function (datos_personales) {
        var _this = this;
        this.ui = $("#contenedor_datosPersonales");
        $("#cuil").mask("99-99999999-9");

        //RH_FORMS.bindear(this.ui, Repositorio, datos_personales);
        var rh_form = new FormularioBindeado({
            formulario: this.ui,
            modelo: datos_personales
        });

        _this.txt_nombre = _this.ui.find("#nombre");
        _this.txt_apellido = _this.ui.find("#apellido");
        _this.txt_cuil = _this.ui.find("#cuil");
        _this.cmb_lugar_nac = _this.ui.find("#cmb_lugar_nacimiento");
        _this.txt_fechaNac = _this.ui.find("#txt_fechaNac");
        _this.txt_dni = _this.ui.find("#txt_documento");
        _this.cmb_tipoDocumento = _this.ui.find("#cmb_tipoDocumento");

        _this.txt_cuil.val(parseInt(datos_personales.Cuil));

        if (datos_personales.TieneLegajo == "Tiene legajo") {
            _this.txt_nombre[0].disabled = true;
            _this.txt_apellido[0].disabled = true;
            _this.txt_cuil[0].disabled = true;
            _this.cmb_lugar_nac[0].disabled = true;
            _this.txt_fechaNac[0].disabled = true;
            _this.txt_dni[0].disabled = true;
            $("#contenedor_datos_legajos").find('select').prop('disabled', true);
        }

        //Bt guardar
        _this.add_datosPersonales = _this.ui.find("#btn_guardar_datosPersonales");
        _this.add_datosPersonales.click(function () {

        if ($("#contenedor_datosPersonales").esValido()) {
            datos_personales.Cuil = _this.txt_cuil.val().replace(/\-/g, '');

            Backend.GuardarCvDatosPersonales(datos_personales)
                .onSuccess(function (respuesta) {
                    alertify.success("Datos Personales guardados correctamente");
                    $(".modal_close_concursar").click();
                })
                .onError(function (error, as, asd) {
                    alertify.error(error.statusText);
                });
        } 
    });

}

}
