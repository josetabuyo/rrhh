var PanelDetalleDeIdiomaExtranjero = {
    mostrar: function (opciones) {
        //valores default
        var idioma_extranjero = opciones.idioma_extranjero || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeIdiomaExtranjero.htm", function () {
            _this.cmb_tipo = _this.ui.find("#cmb_tipo");
            _this.cmb_tipo.val(idioma_extranjero.Tipo);
            _this.txt_detalle = _this.ui.find("#txt_detalle");
            _this.txt_detalle.val(idioma_extranjero.Detalle);

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.idioma_extranjero) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                idioma_extranjero.Tipo = _this.cmb_tipo.val();
                idioma_extranjero.Detalle = _this.txt_detalle.val();

                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "GuardarCvIdiomasExtranjeros",
                    data: {
                        idioma_extranjero_original: idioma_extranjero,
                        idioma_extranjero_nueva: idioma_extranjero
                    },
                    success: function (respuesta) {
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar la idioma extranjero.");
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();
        });
    }
}