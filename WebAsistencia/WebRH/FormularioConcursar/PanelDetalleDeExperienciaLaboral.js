var PanelDetalleDeExperienciaLaboral = {
    mostrar: function (opciones) {
        //valores default
        var experiencia = opciones.experiencia || {
            Pais: 9
        };
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeExperiencialaboral.htm", function () {

            _this.txt_experiencia_laboral_puesto = _this.ui.find("#experiencia-laboral_puesto");
            _this.txt_experiencia_laboral_puesto.val(experiencia.PuestoOcupado);

            _this.txt_experiencia_personal_a_cargo = _this.ui.find("#experiencia-laboral_personal_a_cargo");
            _this.txt_experiencia_personal_a_cargo.val(experiencia.PersonasACargo);

            _this.txt_experiencia_laboral_fecha_inicio = _this.ui.find("#txt_experiencia_laboral_fecha_inicio");

            _this.txt_experiencia_laboral_fecha_fin = _this.ui.find("#txt_experiencia_laboral_fecha_fin");

            _this.txt_experiencia_laboral_fecha_inicio.datepicker();
            _this.txt_experiencia_laboral_fecha_inicio.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_experiencia_laboral_fecha_inicio.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(experiencia.FechaInicio));

            _this.txt_experiencia_laboral_fecha_fin.datepicker();
            _this.txt_experiencia_laboral_fecha_fin.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_experiencia_laboral_fecha_fin.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(experiencia.FechaFin));

            _this.txt_motivo_desvinculacion = _this.ui.find("#experiencia-laboral_motivo_desvinculacion");
            _this.txt_motivo_desvinculacion.val(experiencia.MotivoDesvinculacion);

            _this.txt_nombre_empleador = _this.ui.find("#experiencia-laboral_empleador");
            _this.txt_nombre_empleador.val(experiencia.NombreEmpleador);

            _this.txt_tipo_empresa_institucion = _this.ui.find("#experiencia-laboral_tipo_empresa");
            _this.txt_tipo_empresa_institucion.val(experiencia.TipoEmpresa);

            _this.txt_experiencia_laboral_sector = _this.ui.find("#experiencia-laboral_sector");
            _this.txt_experiencia_laboral_sector.val(experiencia.Sector);

            _this.txt_experiencia_laboral_localidad = _this.ui.find("#experiencia-laboral_localidad");
            _this.txt_experiencia_laboral_localidad.val(experiencia.Localidad);

            _this.cmb_experiencia_laboral_pais = new SuperCombo({
                ui: _this.ui.find("#cmb_experiencia_laboral_pais"),
                nombre_repositorio: "Paises",
                id_item_seleccionado: experiencia.Pais
            });

            _this.txt_experiencia_laboral_actividad = _this.ui.find("#txt_experiencia_laboral_actividad");
            _this.txt_experiencia_laboral_actividad.val(experiencia.Actividad);


            //Bt agregar
            _this.btn_guardar = _this.ui.find("#add_experiencia_laboral");
            if (opciones.experiencia) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {

                experiencia.PuestoOcupado = _this.txt_experiencia_laboral_puesto.val();
                experiencia.PersonasACargo = _this.txt_experiencia_personal_a_cargo.val();

                experiencia.FechaInicio = _this.txt_experiencia_laboral_fecha_inicio.datepicker('getDate').toISOString();

                experiencia.FechaFin = _this.txt_experiencia_laboral_fecha_fin.datepicker('getDate').toISOString();

                experiencia.MotivoDesvinculacion = _this.txt_motivo_desvinculacion.val();
                experiencia.NombreEmpleador = _this.txt_nombre_empleador.val();
                experiencia.TipoEmpresa = _this.txt_tipo_empresa_institucion.val();
                experiencia.Sector = _this.txt_experiencia_laboral_sector.val();
             
                experiencia.Localidad = _this.txt_experiencia_laboral_localidad.val();
                experiencia.Pais = _this.cmb_experiencia_laboral_pais.idItemSeleccionado();
                experiencia.Actividad = _this.txt_experiencia_laboral_actividad.val();

                var proveedor_ajax = new ProveedorAjax();


                if (opciones.experiencia) {


                    proveedor_ajax.postearAUrl({ url: "ActualizarCvExperienciaLaboral",
                        data: {
                            experiencia_laboral: experiencia

                        },
                        success: function (respuesta) {
                            alertify.alert("Los datos fueron guardados correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alertify.alert("Error al guardar la experiencia laboral.");
                        }
                    });

                    return;
                }
                //               proveedor_ajax.postearAUrl({ url: "GuardarCvExperienciaLaboral",
                proveedor_ajax.postearAUrl({ url: "GuardarCvExperienciaLaboral",
                    data: {
                        experiencia_laboral: experiencia
                    },
                    success: function (respuesta) {
                        alertify.alert("La experiencia fue guardada correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar la experiencia.");
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();




        });
    }
}