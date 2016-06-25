var PanelListaDeCambiosObraSocial = {
    armarGrilla: function (cambios_obra_social) {
        var _this = this;

        _this.divGrilla = $('#tabla_cambios_obra_social');
        _this.btn_agregar_cambio_obra_social = $("#btn_agregar_cambio_obra_social");

        _this.btn_agregar_cambio_obra_social.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: {
                    Pais: 9,
                    AmbitoLaboral: 1
                },
                path_html: "PanelDetalleDeCambioObraSocial.htm",
                metodoDeGuardado: "GuardarCambioObraSocial",
                mensajeDeGuardadoExitoso: "Cambio de obra social realizado correctamente",
                mensajeDeGuardadoErroneo: "Error al cambiar la obra social",
                alModificar: function (nuevo_cambio_obra_social) {
                    _this.GrillaCambiosObraSocial.BorrarContenido();
                    cambios_obra_social.push(nuevo_cambio_obra_social);
                    _this.GrillaCambiosObraSocial.CargarObjetos(cambios_obra_social);
                },
                alCargar: function (ui, modelo) {
                    _this.completarComboObrasSociales(ui, modelo);

                }
            });
        });


        var columnas = [];


        columnas.push(new Columna("Fecha", { generar: function (un_cambio_obra_social) { return ConversorDeFechas.deIsoAFechaEnCriollo(un_cambio_obra_social.Fecha) } }));
        columnas.push(new Columna("ObraSocial", { generar: function (un_cambio_obra_social) { return un_cambio_obra_social.ObraSocial } }));
        columnas.push(new Columna('Acciones', {
            generar: function (un_cambio_obra_social) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: un_cambio_obra_social,
                        path_html: "PanelDetalleDeCambioObraSocial.htm",
                        metodoDeGuardado: "ActualizarCambioObraSocial",
                        mensajeDeGuardadoExitoso: "El cambio de obra social fue actualizado correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar el cambio de obra social",
                        alModificar: function (cambio_de_obra_social_modificado) {
                            _this.GrillaCambiosObraSocial.BorrarContenido();
                            _this.GrillaCambiosObraSocial.CargarObjetos(cambios_obra_social);
                        },
                        alCargar: function (ui, modelo) {
                            _this.completarComboSinep(ui, modelo);


                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(un_cambio_obra_social);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaCambiosObraSocial = new Grilla(columnas);
        this.GrillaCambiosObraSocial.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaCambiosObraSocial.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaCambiosObraSocial.SetOnRowClickEventHandler(function (un_cambio_obra_social) {
        });

        this.GrillaCambiosObraSocial.CargarObjetos(cambios_obra_social);
        this.GrillaCambiosObraSocial.DibujarEn(_this.divGrilla);

        this.cambios_obra_social = cambios_obra_social;

    },
    eliminar: function (un_cambio_obra_social) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea el cambio de obra social?", function (e) {
            if (e) {
                Backend.EliminarCambioObraSocial(una_cambio_obra_social)
                    .onSuccess(function (respuesta) {
                        alertify.success("Cambio de Obra social eliminado correctamente");
                        _this.GrillaCambiosObraSocial.QuitarObjeto(_this.divGrilla, una_cambio_obra_social);
                        var indice = _this.experiencias.indexOf(una_cambio_obra_social);
                        _this.cambios_obra_social.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar el cambio de obra social");
                    });
            }
        });
    },
    completarComboObrasSociales: function (ui, una_cambio_de_obra_social) {
        if (una_cambio_de_obra_social.AmbitoLaboral == 2) {
            $("#cmb_modalidad").prop('disabled', true);
            $("#div_vigencia").attr("style", "display:none");
        }

        ui.find('#cmb_ambitolaboral').on('change', function () {
            if (this.value == 1) {
                //alert(this.value);
                $("#cmb_modalidad").prop('disabled', false);
                $("#div_vigencia").attr("style", "display:inline");

            }
            else {
                //alert(this.value);
                //$("#cmb_modalidad").val("3");
                $("#cmb_modalidad").val('');
                $("#cmb_modalidad").prop('disabled', true);
                $("#div_vigencia").attr("style", "display:none");


            }

            //alert(this.value); // or $(this).val()
        });

    }
}
