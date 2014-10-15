var PanelDetalleDeActividadCapacitacion = {
    mostrar: function (opciones) {
        //valores default
        var actividad_capacitacion = opciones.actividad_capacitacion || {
            Pais: 9
        };
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeActividadCapacitacion.htm", function () {
            var rh_form = new FormularioBindeado({
                formulario: _this.ui,
                modelo: actividad_capacitacion
            });

            //Bt cerrar
            _this.btn_cerrar = _this.ui.find(".modal_close_concursar");
            _this.btn_cerrar.click(function () {                
               _this.ui.limpiarValidaciones();
            });

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.actividad_capacitacion) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                if (_this.ui.esValido()) {
                    if (opciones.actividad_capacitacion) {
                        Backend.ActualizarCvActividadCapacitacion(actividad_capacitacion)
                            .onSuccess(function (respuesta) {
                                alertify.alert("La actividad fue actualizada correctamente");
                                alModificar(respuesta);
                                $(".modal_close_concursar").click();
                            })
                            .onError(function (error, as, asd) {
                                alertify.alert("Error al guardar la actividad.");
                            });   
                        return;  
                    }
                    Backend.GuardarCvActividadCapacitacion(actividad_capacitacion)
                        .onSuccess(function (respuesta) {
                            alertify.alert("La actividad fue guardada correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        })
                        .onError(function (error, as, asd) {
                            alertify.alert("Error al guardar la actividad de capacitación.");
                        });   
                }
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

        });
    }
}