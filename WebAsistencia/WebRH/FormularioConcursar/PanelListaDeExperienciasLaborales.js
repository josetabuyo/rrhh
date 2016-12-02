var PanelListaDeExperienciasLaborales = {
    armarGrilla: function (experiencias) {
        var _this = this;

        _this.divGrilla = $('#tabla_experiencias_laborales');
        _this.btn_agregar_experiencia_laboral = $("#btn_agregar_experiencia_laboral");

        _this.btn_agregar_experiencia_laboral.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: {
                    Pais: 9,
                    AmbitoLaboral: 1
                },
                path_html: "PanelDetalleDeExperiencialaboral.htm",
                metodoDeGuardado: "GuardarCvExperienciaLaboral",
                mensajeDeGuardadoExitoso: "La experiencia laboral fue guardada correctamente",
                mensajeDeGuardadoErroneo: "Error al guardar la experiencia laboral",
                alModificar: function (nueva_experiencia) {
                    _this.GrillaExperiencias.BorrarContenido();
                    experiencias.push(nueva_experiencia);
                    _this.GrillaExperiencias.CargarObjetos(experiencias);
                },
                alCargar: function (ui,modelo) {
                    _this.completarComboSinep(ui,modelo);
                  
                }
            });
        });


        var columnas = [];


        columnas.push(new Columna("Puesto", { generar: function (una_experiencia) { return una_experiencia.PuestoOcupado } }));
        columnas.push(new Columna("Fecha Inicio", { generar: function (una_experiencia) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_experiencia.FechaInicio) } }));
        columnas.push(new Columna("Fecha Fin", { generar: function (una_experiencia) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_experiencia.FechaFin) } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_experiencia) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: una_experiencia,
                        path_html: "PanelDetalleDeExperiencialaboral.htm",
                        metodoDeGuardado: "ActualizarCvExperienciaLaboral",
                        mensajeDeGuardadoExitoso: "La experiencia laboral fue actualizada correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar la experiencia laboral",
                        alModificar: function (experiencia_modificada) {
                            _this.GrillaExperiencias.BorrarContenido();
                            _this.GrillaExperiencias.CargarObjetos(experiencias);
                        },
                        alCargar: function (ui, modelo) {
                            _this.completarComboSinep(ui,modelo);
                           
                   
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_experiencia);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaExperiencias = new Grilla(columnas);
        this.GrillaExperiencias.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaExperiencias.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaExperiencias.SetOnRowClickEventHandler(function (una_experiencia) {
        });

        this.GrillaExperiencias.CargarObjetos(experiencias);
        this.GrillaExperiencias.DibujarEn(_this.divGrilla);

        this.experiencias = experiencias;

    },
    eliminar: function (una_experiencia) {
        var _this = this;
        // confirm dialog
        alertify.confirm("", "¿Está seguro que desea eliminar la experiencia laboral?", 
            function () {
                Backend.EliminarCvExperienciaLaboral(una_experiencia)
                    .onSuccess(function (respuesta) {
                        alertify.success("Experiencia eliminada correctamente");
                        _this.GrillaExperiencias.QuitarObjeto(_this.divGrilla, una_experiencia);
                        var indice = _this.experiencias.indexOf(una_experiencia);
                        _this.experiencias.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar la experiencia");
                    });
            },
            function(){}
        );
    },
        completarComboSinep: function (ui,una_experiencia) {
            if (una_experiencia.AmbitoLaboral == 2) {
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
