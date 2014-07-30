var PanelDetalleDeInstitucionAcademica = {
    mostrar: function (opciones) {
        //valores default
        var institucion_academica = opciones.institucion_academica || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeInstitucionAcademica.htm", function () {
            _this.txt_institucion_academica_nombre = _this.ui.find("#txt_institucion_academica_nombre");
            _this.txt_institucion_academica_nombre.val(institucion_academica.Institucion);
            _this.txt_institucion_academica_caracter = _this.ui.find("#txt_institucion_academica_caracter");
            _this.txt_institucion_academica_caracter.val(institucion_academica.CaracterEntidad);
            _this.txt_institucion_academica_cargo = _this.ui.find("#txt_institucion_academica_cargo");
            _this.txt_institucion_academica_cargo.val(institucion_academica.CargosDesempeniados);
            _this.txt_institucion_academica_numero_afiliado = _this.ui.find("#txt_institucion_academica_numero_afiliado");
            _this.txt_institucion_academica_numero_afiliado.val(institucion_academica.NumeroAfiliado);

            _this.txt_institucion_academica_fecha_afiliacion = _this.ui.find("#txt_institucion_academica_fecha_afiliacion");
            _this.txt_institucion_academica_fecha_afiliacion.datepicker();
            _this.txt_institucion_academica_fecha_afiliacion.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_institucion_academica_fecha_afiliacion.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(institucion_academica.FechaDeAfiliacion));

            _this.txt_institucion_academica_categoria_actual = _this.ui.find("#txt_institucion_academica_categoria_actual");
            _this.txt_institucion_academica_categoria_actual.val(institucion_academica.CategoriaActual);

            _this.txt_institucion_academica_fecha = _this.ui.find("#txt_institucion_academica_fecha");
            _this.txt_institucion_academica_fecha.datepicker();
            _this.txt_institucion_academica_fecha.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_institucion_academica_fecha.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(institucion_academica.Fecha));

            _this.cmb_institucion_academica_localidad = _this.ui.find("#cmb_institucion_academica_localidad");
            _this.cmb_institucion_academica_localidad.val(institucion_academica.Localidad);

            _this.cmb_institucion_academica_pais = new SuperCombo({
                ui: _this.ui.find("#cmb_institucion_academica_pais"),
                nombre_repositorio: "Paises",
                campo_id: "Id",
                campo_descripcion: "Descripcion",
                id_item_seleccionado: institucion_academica.Pais
            });

            _this.txt_institucion_academica_fechaInicio = _this.ui.find("#txt_institucion_academica_fechaInicio");
            _this.txt_institucion_academica_fechaInicio.datepicker();
            _this.txt_institucion_academica_fechaInicio.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_institucion_academica_fechaInicio.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(institucion_academica.FechaInicio));
            _this.txt_institucion_academica_fechaFin = _this.ui.find("#txt_institucion_academica_fechaFin");
            _this.txt_institucion_academica_fechaFin.datepicker();
            _this.txt_institucion_academica_fechaFin.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.txt_institucion_academica_fechaFin.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(institucion_academica.FechaFin));


            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.institucion_academica) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                institucion_academica.Institucion = _this.txt_institucion_academica_nombre.val();
                institucion_academica.CaracterEntidad = _this.txt_institucion_academica_caracter.val();
                institucion_academica.CargosDesempeniados = _this.txt_institucion_academica_cargo.val();
                institucion_academica.NumeroAfiliado = _this.txt_institucion_academica_numero_afiliado.val();
                institucion_academica.FechaDeAfiliacion = _this.txt_institucion_academica_fecha_afiliacion.datepicker('getDate').toISOString();
                institucion_academica.CategoriaActual = _this.txt_institucion_academica_categoria_actual.val();
                institucion_academica.Fecha = _this.txt_institucion_academica_fecha.datepicker('getDate').toISOString();
                institucion_academica.Localidad = _this.cmb_institucion_academica_localidad.val();
                institucion_academica.Pais = _this.cmb_institucion_academica_pais.idItemSeleccionado();
                institucion_academica.FechaInicio = _this.txt_institucion_academica_fechaInicio.datepicker('getDate').toISOString();
                institucion_academica.FechaFin = _this.txt_institucion_academica_fechaFin.datepicker('getDate').toISOString();

                var proveedor_ajax = new ProveedorAjax();

                if (opciones.institucion_academica) {

                    proveedor_ajax.postearAUrl({ url: "ActualizarCvInstitucionAcademica",
                        data: {
                            institucion_academica: institucion_academica
                        },
                        success: function (respuesta) {
                            alertify.alert("La institución fue actualizada correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alertify.alert("Error al actualziar la institución.");
                        }
                    });

                    return;
                }

                proveedor_ajax.postearAUrl({ url: "GuardarCvInstitucionAcademica",
                    data: {
                        institucion_academica: institucion_academica
                    },
                    success: function (respuesta) {
                        alertify.alert("La institución fue guardada correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar la instituación académica");
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

        });
    }
}