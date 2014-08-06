var PanelDetalleDeIdiomaExtranjero = {
    mostrar: function (opciones) {
        //valores default
        var idioma_extranjero = opciones.idioma_extranjero || {
            Pais: 9
        };
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeIdiomaExtranjero.htm", function () {
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

            _this.cmb_idioma_extranjero_pais = new SuperCombo({
                ui: _this.ui.find("#cmb_idioma_extranjero_pais"),
                nombre_repositorio: "Paises",
                id_item_seleccionado: idioma_extranjero.Pais
            });

            _this.txt_idioma_extranjero_idioma = _this.ui.find("#txt_idioma_extranjero_idioma");
            _this.txt_idioma_extranjero_idioma.val(idioma_extranjero.Idioma);

            _this.cmb_idioma_extranjero_lectura = new SuperCombo({
                ui: _this.ui.find("#cmb_idioma_extranjero_lectura"),
                nombre_repositorio: "NivelesDeIdioma",
                id_item_seleccionado: idioma_extranjero.Lectura
            });

            _this.cmb_idioma_extranjero_escritura = new SuperCombo({
                ui: _this.ui.find("#cmb_idioma_extranjero_escritura"),
                nombre_repositorio: "NivelesDeIdioma",
                id_item_seleccionado: idioma_extranjero.Escritura
            });

            _this.cmb_idioma_extranjero_oral = new SuperCombo({
                ui: _this.ui.find("#cmb_idioma_extranjero_oral"),
                nombre_repositorio: "NivelesDeIdioma",
                id_item_seleccionado: idioma_extranjero.Oral
            });

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
                    idioma_extranjero.Pais = _this.cmb_idioma_extranjero_pais.idItemSeleccionado();
                    idioma_extranjero.Idioma = _this.txt_idioma_extranjero_idioma.val();
                    idioma_extranjero.Lectura = _this.cmb_idioma_extranjero_lectura.idItemSeleccionado();
                    idioma_extranjero.Escritura = _this.cmb_idioma_extranjero_escritura.idItemSeleccionado();
                    idioma_extranjero.Oral = _this.cmb_idioma_extranjero_oral.idItemSeleccionado();

                    var proveedor_ajax = new ProveedorAjax();

                    if (opciones.idioma_extranjero) {

                        proveedor_ajax.postearAUrl({ url: "ActualizarCvIdiomaExtranjero",
                            data: {
                                idioma_extranjero: idioma_extranjero
                            },
                            success: function (respuesta) {
                                alertify.alert("El idioma fue actualizado correctamente");
                                alModificar(respuesta);
                                $(".modal_close_concursar").click();
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alertify.alert("Error al actualziar el idioma.");
                            }
                        });

                        return;
                    }

                    proveedor_ajax.postearAUrl({ url: "GuardarCvIdiomaExtranjero",
                        data: {
                            idioma_extranjero: idioma_extranjero
                        },
                        success: function (respuesta) {
                            alertify.alert("El idioma fue guardado correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alertify.alert("Error al guardar el idioma extranjero.");
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