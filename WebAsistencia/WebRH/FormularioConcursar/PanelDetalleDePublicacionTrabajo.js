var PanelDetalleDePublicaciones = {
    mostrar: function (opciones) {
        //valores default
        var publicacion = opciones.publicacion || {};
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDePublicacionTrabajo.htm", function () {
            _this.publicaciones_titulo = _this.ui.find("#txt_publicaciones_titulo");
            _this.publicaciones_titulo.val(publicacion.Titulo);
            _this.publicaciones_editorial = _this.ui.find("#txt_publicaciones_editorial");
            _this.publicaciones_editorial.val(publicacion.DatosEditorial);
            _this.publicaciones_fecha = _this.ui.find("#txt_publicaciones_fecha");

            _this.publicaciones_fecha.datepicker();
            _this.publicaciones_fecha.datepicker('option', 'dateFormat', 'dd/mm/yy');
            _this.publicaciones_fecha.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(publicacion.FechaPublicacion));


            _this.publicaciones_paginas = _this.ui.find("#txt_publicaciones_paginas");
            _this.publicaciones_paginas.val(publicacion.CantidadHojas);
            _this.publicaciones_dispone_copia = _this.ui.find("#txt_publicaciones_dispone_copia");
            _this.publicaciones_dispone_copia.val(publicacion.DisponeCopia); 

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#btn_guardar");
            if (opciones.publicacion) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                publicacion.Titulo = _this.publicaciones_titulo.val();
                publicacion.DatosEditorial = _this.publicaciones_editorial.val();
                publicacion.FechaPublicacion = _this.publicaciones_fecha.datepicker('getDate').toISOString();
                publicacion.CantidadHojas = _this.publicaciones_paginas.val();
                publicacion.DisponeCopia = _this.publicaciones_dispone_copia.val();

                var proveedor_ajax = new ProveedorAjax();

                if (opciones.publicacion) {
                    proveedor_ajax.postearAUrl({ url: "ActualizarCVPublicacionesTrabajos",
                        data: {
                            publicacion: publicacion
                        },
                        success: function (respuesta) {
                            alertify.alert("La publicación fue actualizada correctamente");
                            alModificar(respuesta);
                            $(".modal_close_concursar").click();
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alertify.alert("Error al actualizar la publicación.");
                        }
                    });

                    return;
                }

                proveedor_ajax.postearAUrl({ url: "GuardarCvPublicacionesTrabajos",
                    data: {
                        publicacion: publicacion
                    },
                    success: function (respuesta) {
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("Error al guardar la publicación.");
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();
        });
    }
}