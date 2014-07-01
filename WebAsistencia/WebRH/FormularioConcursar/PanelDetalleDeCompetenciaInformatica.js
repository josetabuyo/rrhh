var PanelDetalleDeCompetenciaInformatica = {
    mostrar: function (opciones) {
        //valores default
        var competencia_informatica = opciones.competencia_informatica || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeCompetenciaInformatica.htm", function () {
            _this.cmb_tipo = _this.ui.find("#cmb_tipo");
            _this.cmb_tipo.val(competencia_informatica.Tipo);
            _this.txt_detalle = _this.ui.find("#txt_detalle");
            _this.txt_detalle.val(competencia_informatica.Detalle);

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.competencia_informatica) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                competencia_informatica.Tipo = _this.cmb_tipo.val();
                competencia_informatica.Detalle = _this.txt_detalle.val();

                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "GuardarCvCompetenciasInformaticas",
                    data: {
                        competencia_informatica_original: competencia_informatica,
                        competencia_informatica_nueva: competencia_informatica
                    },
                    success: function (respuesta) {
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar la competencia informática.");
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();
        });
    }
}