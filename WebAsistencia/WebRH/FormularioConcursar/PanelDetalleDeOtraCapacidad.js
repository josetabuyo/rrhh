var PanelDetalleDeOtraCapacidad = {
    mostrar: function (opciones) {
        //valores default
        var capacidad = opciones.capacidad || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeOtraCapacidad.htm", function () {
            _this.cmb_tipo = _this.ui.find("#cmb_tipo");
            _this.cmb_tipo.val(capacidad.Tipo);
            _this.txt_detalle = _this.ui.find("#txt_detalle");
            _this.txt_detalle.val(capacidad.Detalle);

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.capacidad) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                capacidad.Tipo = _this.cmb_tipo.val();
                capacidad.Detalle = _this.txt_detalle.val();

                var proveedor_ajax = new ProveedorAjax();

                if (opciones.capacidad) {
                    proveedor_ajax.postearAUrl({ url: "ActualizarCvOtraCapacidad",
                        data: {
                            otra_capacidad: capacidad
                        },
                        success: function (respuesta) {
                            alertify.alert("Los capacidad fue creada correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alertify.alert("Error al crear la capacidad.");
                        }
                    });

                    return;
                }
                proveedor_ajax.postearAUrl({ url: "GuardarCvOtraCapacidad",
                    data: {
                        otra_capacidad: capacidad
                    },
                    success: function (respuesta) {
                        alertify.alert("La capacidad fué guardada correctamente");
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
        });
    }
}