var PanelDetalleDeActividadDeCapacitacion = {
    mostrar: function (opciones) {
        //valores default
        var actividadCapacitacion = opciones.actividad || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeActividadDeCapacitacion.htm", function () {
            _this.txt_diploma_certificacion = _this.ui.find("#txt_capacitacion_nombreDiploma");
            _this.txt_diploma_certificacion.val(actividadCapacitacion.DiplomaDeCertificacion);
            _this.txt_fecha_inicio = _this.ui.find("#txt_capacitacion_fechaInicio");
           // _this.txt_fecha_inicio.val(actividadCapacitacion.FechaInicio);
            _this.txt_fecha_inicio.datepicker();
            _this.txt_fecha_inicio.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_fecha_inicio.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(actividadCapacitacion.FechaInicio));
            _this.txt_fecha_fin = _this.ui.find("#txt_capacitacion_fechaFin");
            //_this.txt_fecha_fin.val(actividadCapacitacion.FechaFinalizacion);
            _this.txt_fecha_fin.datepicker();
            _this.txt_fecha_fin.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_fecha_fin.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(actividadCapacitacion.FechaFinalizacion));

            _this.txt_duracion = _this.ui.find("#txt_capacitacion_duracion");
            _this.txt_duracion.val(actividadCapacitacion.Duracion);
            _this.txt_especialidad = _this.ui.find("#txt_capacitacion_especialidad");
            _this.txt_especialidad.val(actividadCapacitacion.Especialidad);
            _this.txt_establecimiento = _this.ui.find("#txt_capacitacion_establecimiento");
            _this.txt_establecimiento.val(actividadCapacitacion.Establecimiento);
            _this.cmb_localidad = _this.ui.find("#cmb_capacitacion_localidad");
            _this.cmb_localidad.val(actividadCapacitacion.Localidad);
            _this.cmb_pais = _this.ui.find("#cmb_capacitacion_pais");
            _this.cmb_pais.val(actividadCapacitacion.Pais);


            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_agregar_actividades_capacitacion");
            if (opciones.actividad) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                actividadCapacitacion.DiplomaDeCertificacion = _this.txt_diploma_certificacion.val();
                actividadCapacitacion.Establecimiento = _this.txt_establecimiento.val();
                actividadCapacitacion.Especialidad = _this.txt_especialidad.val();
                actividadCapacitacion.Duracion = _this.txt_duracion.val();
                actividadCapacitacion.FechaInicio = _this.txt_fecha_inicio.datepicker('getDate').toISOString();
                actividadCapacitacion.FechaFinalizacion = _this.txt_fecha_fin.datepicker('getDate').toISOString();
                actividadCapacitacion.Localidad = _this.cmb_localidad.val();
                actividadCapacitacion.Pais = _this.cmb_pais.val();

                var proveedor_ajax = new ProveedorAjax();
                if (opciones.actividad) {
                    proveedor_ajax.postearAUrl({ url: "ActualizarCvActividadDeCapacitacion",
                        data: {
                            una_actividad: actividadCapacitacion
                        },
                        success: function (respuesta) {
                            alertify.alert("La actividad fue creada correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alertify.alert("Error al crear la actividad.");
                        }
                    });

                    return;
                }

                proveedor_ajax.postearAUrl({ url: "GuardarCvActividadDeCapacitacion",
                    data: {
                        actividadCapacitacion: actividadCapacitacion
                        
                    },
                    success: function (respuesta) {
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar la capacidad.");
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

            $('#txt_capacitacion_fechaInicio').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
            $('#txt_capacitacion_fechaFin').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
        });
    }
}