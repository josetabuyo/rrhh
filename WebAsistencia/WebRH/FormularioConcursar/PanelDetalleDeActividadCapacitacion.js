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

            var generador_combos = new ComboPopuladoConRepoBuilder(Repositorio);
            generador_combos.construirCombosEn(_this.ui, actividad_capacitacion);

            _this.txt_actividad_capacitacion_nombreDiploma = _this.ui.find("#txt_actividad_capacitacion_nombreDiploma");
            _this.txt_actividad_capacitacion_nombreDiploma.val(actividad_capacitacion.DiplomaDeCertificacion);

            _this.txt_actividad_capacitacion_fechaInicio = _this.ui.find("#txt_actividad_capacitacion_fechaInicio");
            _this.txt_actividad_capacitacion_fechaInicio.datepicker();
            _this.txt_actividad_capacitacion_fechaInicio.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_actividad_capacitacion_fechaInicio.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(actividad_capacitacion.FechaInicio));
            _this.txt_actividad_capacitacion_fechaFin = _this.ui.find("#txt_actividad_capacitacion_fechaFin");
            _this.txt_actividad_capacitacion_fechaFin.datepicker();
            _this.txt_actividad_capacitacion_fechaFin.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_actividad_capacitacion_fechaFin.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(actividad_capacitacion.FechaFinalizacion));

            _this.txt_actividad_capacitacion_duracion = _this.ui.find("#txt_actividad_capacitacion_duracion");
            _this.txt_actividad_capacitacion_duracion.val(actividad_capacitacion.Duracion);
            _this.txt_actividad_capacitacion_especialidad = _this.ui.find("#txt_actividad_capacitacion_especialidad");
            _this.txt_actividad_capacitacion_especialidad.val(actividad_capacitacion.Especialidad);
            _this.txt_actividad_capacitacion_establecimiento = _this.ui.find("#txt_actividad_capacitacion_establecimiento");
            _this.txt_actividad_capacitacion_establecimiento.val(actividad_capacitacion.Establecimiento);
            _this.cmb_actividad_capacitacion_localidad = _this.ui.find("#cmb_actividad_capacitacion_localidad");
            _this.cmb_actividad_capacitacion_localidad.val(actividad_capacitacion.Localidad);

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

                    actividad_capacitacion.DiplomaDeCertificacion = _this.txt_actividad_capacitacion_nombreDiploma.val();
                    actividad_capacitacion.FechaInicio = _this.txt_actividad_capacitacion_fechaInicio.datepicker('getDate').toISOString();
                    actividad_capacitacion.FechaFinalizacion = _this.txt_actividad_capacitacion_fechaFin.datepicker('getDate').toISOString();
                    actividad_capacitacion.Duracion = _this.txt_actividad_capacitacion_duracion.val();
                    actividad_capacitacion.Especialidad = _this.txt_actividad_capacitacion_especialidad.val();
                    actividad_capacitacion.Establecimiento = _this.txt_actividad_capacitacion_establecimiento.val();
                    actividad_capacitacion.Localidad = _this.cmb_actividad_capacitacion_localidad.val();

                    var proveedor_ajax = new ProveedorAjax();

                    if (opciones.actividad_capacitacion) {

                        proveedor_ajax.postearAUrl({ url: "ActualizarCvActividadCapacitacion",
                            data: {
                                actividad_capacitacion: actividad_capacitacion
                            },
                            success: function (respuesta) {
                                alertify.alert("La actividad fue actualizada correctamente");
                                alModificar(respuesta);
                                $(".modal_close_concursar").click();
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert("Error al actualziar la actividad.");
                            }
                        });

                        return;  
                }

                proveedor_ajax.postearAUrl({ url: "GuardarCvActividadCapacitacion",
                    data: {
                        actividad_capacitacion: actividad_capacitacion
                    },
                    success: function (respuesta) {
                        alertify.alert("La actividad fue guardada correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar la actividad de capacitación.");
                    }
                });
            }
            });


            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

        });
    }
}