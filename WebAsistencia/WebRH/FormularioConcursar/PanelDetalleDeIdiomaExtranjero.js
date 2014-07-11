var PanelDetalleDeIdiomaExtranjero = {
    mostrar: function (opciones) {
        //valores default
        var idioma_extranjero = opciones.idioma_extranjero || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeIdiomaExtranjero.htm", function () {
            _this.txt_idioma_extranjero_diploma_certificacion = _this.ui.find("#txt_idioma_extranjero_diploma_certificacion");
            _this.txt_idioma_extranjero_diploma_certificacion.val(idioma_extranjero.Diploma);
            _this.txt_idioma_extranjero_fecha_obtencion = _this.ui.find("#txt_idioma_extranjero_fecha_obtencion");
            _this.txt_idioma_extranjero_fecha_obtencion.val(idioma_extranjero.FechaObtencion);
            _this.txt_idioma_extranjero_establecimiento = _this.ui.find("#txt_idioma_extranjero_establecimiento");
            _this.txt_idioma_extranjero_establecimiento.val(idioma_extranjero.Establecimiento);
            _this.cmb_idioma_extranjero_localidad = _this.ui.find("#cmb_idioma_extranjero_localidad");
            _this.cmb_idioma_extranjero_localidad.val(idioma_extranjero.Localidad);
            _this.cmb_idioma_extranjero_pais = _this.ui.find("#cmb_idioma_extranjero_pais");
            _this.cmb_idioma_extranjero_pais.val(idioma_extranjero.Pais);
            _this.txt_idioma_extranjero_idioma = _this.ui.find("#txt_idioma_extranjero_idioma");
            _this.txt_idioma_extranjero_idioma.val(idioma_extranjero.Idioma);
            _this.cmb_idioma_extranjero_lectura = _this.ui.find("#cmb_idioma_extranjero_lectura");
            _this.cmb_idioma_extranjero_lectura.val(idioma_extranjero.Lectura);
            _this.cmb_idioma_extranjero_escritura = _this.ui.find("#cmb_idioma_extranjero_escritura");
            _this.cmb_idioma_extranjero_escritura.val(idioma_extranjero.Escritura);
            _this.cmb_idioma_extranjero_oral = _this.ui.find("#cmb_idioma_extranjero_oral");
            _this.cmb_idioma_extranjero_oral.val(idioma_extranjero.Oral);

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.idioma_extranjero) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {


                idioma_extranjero.Diploma = _this.txt_idioma_extranjero_diploma_certificacion.val();
                idioma_extranjero.FechaObtencion = _this.txt_idioma_extranjero_fecha_obtencion.val();
                idioma_extranjero.Establecimiento = _this.txt_idioma_extranjero_establecimiento.val();
                idioma_extranjero.Localidad = _this.cmb_idioma_extranjero_localidad.val();
                idioma_extranjero.Pais = _this.cmb_idioma_extranjero_pais.val();
                idioma_extranjero.Idioma = _this.txt_idioma_extranjero_idioma.val();
                idioma_extranjero.Lectura = _this.cmb_idioma_extranjero_lectura.val();
                idioma_extranjero.Escritura = _this.cmb_idioma_extranjero_escritura.val();
                idioma_extranjero.Oral = _this.cmb_idioma_extranjero_oral.val();

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
                            alertify.alert("Error al crear la capacidad.");
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
                        alertify.alert("Error al guardar la idioma extranjero.");
                    }
                });
            });

            $('#txt_idioma_extranjero_fecha_obtencion').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

        });
    }
}