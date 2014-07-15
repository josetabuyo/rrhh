var PanelDetalleDeOtraExperiencia = {
    mostrar: function (opciones) {
        //valores default
        var experiencia = opciones.experiencia || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeExperiencialaboral.htm", function () {

            _this.txt_experiencia_laboral_puesto = _this.ui.find("#experiencia-laboral_puesto");
            _this.txt_experiencia_laboral_puesto.val(experiencia.PuestoOcupado);
          
            _this.txt_experiencia_personal_a_cargo = _this.ui.find("#experiencia-laboral_personal_a_cargo");
            _this.txt_experiencia_laboral_puesto.val(experiencia.PersonasACargo);



            _this.txt_experiencia_laboral_fecha_inicio.datepicker();
            _this.txt_experiencia_laboral_fecha_inicio.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_experiencia_laboral_fecha_inicio.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(experiencia.FechaInicio));

            
            /*
            fechas
            */

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
            
            _this.cmb_experiencia_laboral_pais = _this.ui.find("#cmb_experiencia_laboral_pais");
            _this.cmb_experiencia_laboral_pais.val(experiencia.Pais);

            _this.txt_experiencia_laboral_actividad = _this.ui.find("#txt_experiencia_laboral_actividad");
            _this.txt_experiencia_laboral_actividad.val(experiencia.Actividad);
            
                      
            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.experiencia) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                experiencia.Tipo = _this.cmb_tipo.val();
                experiencia.Detalle = _this.txt_detalle.val();

                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "GuardarCvExperiencias",
                    data: {
                        otra_experiencia_original: experiencia,
                        otra_experiencia_nueva: experiencia
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
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();
        });
    }
}