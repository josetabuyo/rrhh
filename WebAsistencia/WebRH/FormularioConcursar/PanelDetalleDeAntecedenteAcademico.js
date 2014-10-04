var PanelDetalleDeAntecedenteAcademico = {
    mostrar: function (opciones) {
        //valores default
        var estudio = opciones.estudio || {
            Pais: 9,
            Nivel: 1
        };
        var alModificar = opciones.alModificar || function () { };

        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("PanelDetalleDeAntecedenteAcademico.htm", function () {
            var rh_form = new FormularioBindeado({
                formulario: _this.ui,
                modelo: estudio
            });

            //Bt cerrar
            _this.btn_cerrar = _this.ui.find(".modal_close_concursar");
            _this.btn_cerrar.click(function () {
                _this.ui.limpiarValidaciones();
            });

            //Bt agregar
            _this.btn_guardar = _this.ui.find("#add_antecedentesAcademicos");
            if (opciones.estudio) _this.btn_guardar.val("Guardar Cambios");

            _this.btn_guardar.click(function () {
                if (_this.ui.esValido()) {                       
                    if (opciones.estudio) {
                        Backend.ActualizarCvAntecedenteAcademico(estudio)
                            .onSuccess(function (respuesta) {
                                alertify.alert("El Antecedente fue actualizado correctamente");
                                alModificar(respuesta);
                                $(".modal_close_concursar").click();
                            })
                            .onError(function (error, as, asd) {
                                alertify.error("Error al crear la capacidad");
                            });   
//                        proveedor_ajax.postearAUrl({ url: "ActualizarCvAntecedenteAcademico",
//                            data: {
//                                un_estudio: estudio
//                            },
//                            success: function (respuesta) {
//                                alertify.alert("El Antecedente fue actualizado correctamente");
//                                alModificar(respuesta);
//                                $(".modal_close_concursar").click();
//                            },
//                            error: function (XMLHttpRequest, textStatus, errorThrown) {
//                                alertify.alert("Error al crear la capacidad.");
//                            }
//                        });

                        return;
                    }
                    Backend.GuardarCVAntecedenteAcademico(estudio)
                            .onSuccess(function (respuesta) {
                                alertify.alert("Los datos fueron guardados correctamente");
                                alModificar(respuesta);
                                $(".modal_close_concursar").click();
                            })
                            .onError(function (error, as, asd) {
                                alertify.error("Error al guardar el antecedente");
                            });   

//                    proveedor_ajax.postearAUrl({ url: "GuardarCVAntecedenteAcademico",
//                        data: {
//                            antecedentesAcademicos_nuevos: estudio

//                        },
//                        success: function (respuesta) {
//                            alertify.alert("Los datos fueron guardados correctamente");
//                            alModificar(respuesta);
//                            $(".modal_close_concursar").click();
//                        },
//                        error: function (XMLHttpRequest, textStatus, errorThrown) {
//                            alertify.alert("Error al guardar el antecedente.");
//                        }
//                    });
                }

            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();
        });
    }
}