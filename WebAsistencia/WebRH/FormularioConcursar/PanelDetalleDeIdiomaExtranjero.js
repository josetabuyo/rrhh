var PanelDetalleDeIdiomaExtranjero = {
    mostrar: function (opciones) {
        //valores default
        var idioma_extranjero = opciones.idioma_extranjero || {
            Pais: 9,
            Escritura: 1,
            Lectura: 1,
            Oral: 1
        };
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeIdiomaExtranjero.htm", function () {

            RH_FORMS.bindear(_this.ui, Repositorio, idioma_extranjero);

            _this.txt_idioma_extranjero_diploma_certificacion = _this.ui.find("#txt_idioma_extranjero_diploma_certificacion");
            _this.txt_idioma_extranjero_diploma_certificacion.val(idioma_extranjero.Diploma);

            _this.txt_idioma_extranjero_fecha_obtencion = _this.ui.find("#txt_idioma_extranjero_fecha_obtencion");
            _this.txt_idioma_extranjero_fecha_obtencion.datepicker();
            _this.txt_idioma_extranjero_fecha_obtencion.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_idioma_extranjero_fecha_obtencion.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(idioma_extranjero.FechaObtencion));

            _this.txt_idioma_extranjero_establecimiento = _this.ui.find("#txt_idioma_extranjero_establecimiento");
            _this.txt_idioma_extranjero_establecimiento.val(idioma_extranjero.Establecimiento);
            _this.cmb_idioma_extranjero_localidad = _this.ui.find("#cmb_idioma_extranjero_localidad");
            _this.cmb_idioma_extranjero_localidad.val(idioma_extranjero.Localidad);

            _this.txt_idioma_extranjero_idioma = _this.ui.find("#txt_idioma_extranjero_idioma");
            _this.txt_idioma_extranjero_idioma.val(idioma_extranjero.Idioma);

            //Bt cerrar
            _this.btn_cerrar = _this.ui.find(".modal_close_concursar");
            _this.btn_cerrar.click(function () {
                _this.ui.limpiarValidaciones();
            });

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.idioma_extranjero) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {

                if (_this.ui.esValido()) {

                    idioma_extranjero.Diploma = _this.txt_idioma_extranjero_diploma_certificacion.val();
                    idioma_extranjero.FechaObtencion = _this.txt_idioma_extranjero_fecha_obtencion.datepicker('getDate').toISOString();
                    idioma_extranjero.Establecimiento = _this.txt_idioma_extranjero_establecimiento.val();
                    idioma_extranjero.Localidad = _this.cmb_idioma_extranjero_localidad.val();
                    idioma_extranjero.Idioma = _this.txt_idioma_extranjero_idioma.val();
                    idioma_extranjero.Oral = _this.cmb_idioma_extranjero_oral.idItemSeleccionado();

                    if (opciones.idioma_extranjero) {
                        Backend.ActualizarCvIdiomaExtranjero(idioma_extranjero).then(function (respuesta) {
                            alertify.alert("El idioma fue actualizado correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        }, function (error) {
                            alertify.alert("Error al actualizar el idioma.");
                        });
                        return;
                    }
                    Backend.GuardarCvIdiomaExtranjero(idioma_extranjero).then(function (respuesta) {
                        alertify.alert("El idioma fue guardado correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },function (error) {
                        alertify.alert("Error al guardar el idioma.");
                    });
                }
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

        });
    }
}