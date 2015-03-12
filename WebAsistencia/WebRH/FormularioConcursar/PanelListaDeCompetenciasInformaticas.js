var PanelListaDeCompetenciasInformaticas = {
    armarGrilla: function (competencias_informaticas) {
        var _this = this;

        _this.divGrilla = $('#tabla_competencias_informaticas');
        _this.btn_agregar_competencia_informatica = $("#btn_agregar_competencia_informatica");

        _this.btn_agregar_competencia_informatica.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: { 
                    Pais: 9,
                    Nivel: 1,
                    TipoInformatica: 1,
                    Conocimiento: 1
                },
                path_html: "PanelDetalleDeCompetenciaInformatica.htm",
                metodoDeGuardado: "GuardarCvCompetenciaInformatica",
                mensajeDeGuardadoExitoso: "La competencia informática fue guardada correctamente",
                mensajeDeGuardadoErroneo: "Error al guardar la competencia informática",
                alModificar: function (nueva_competencia_informatica) {
                    _this.GrillaCompetenciasInformaticas.BorrarContenido();
                    competencias_informaticas.push(nueva_competencia_informatica);
                    _this.GrillaCompetenciasInformaticas.CargarObjetos(competencias_informaticas);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Diploma/Certificación", { generar: function (una_competencia_informatica) { return una_competencia_informatica.Diploma } }));
        columnas.push(new Columna("Fecha Obtención", { generar: function (una_competencia_informatica) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_competencia_informatica.FechaObtencion) } }));
        columnas.push(new Columna("Establecimiento", { generar: function (una_competencia_informatica) { return una_competencia_informatica.Establecimiento } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_competencia_informatica) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: una_competencia_informatica,
                        path_html: "PanelDetalleDeCompetenciaInformatica.htm",
                        metodoDeGuardado: "ActualizarCvCompetenciaInformatica",
                        mensajeDeGuardadoExitoso: "La competencia informática fue actualizada correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar la competencia informática",
                        alModificar: function (competencia_informatica_modificada) {
                            _this.GrillaCompetenciasInformaticas.BorrarContenido();
                            _this.GrillaCompetenciasInformaticas.CargarObjetos(competencias_informaticas);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_competencia_informatica);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaCompetenciasInformaticas = new Grilla(columnas);
        this.GrillaCompetenciasInformaticas.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaCompetenciasInformaticas.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaCompetenciasInformaticas.SetOnRowClickEventHandler(function (una_competencia_informatica) {
        });

        this.GrillaCompetenciasInformaticas.CargarObjetos(competencias_informaticas);
        this.GrillaCompetenciasInformaticas.DibujarEn(_this.divGrilla);
        this.competencias = competencias_informaticas;

    },
    eliminar: function (una_competencia_informatica) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la competencia informática?", function (e) {
            if (e) {
                Backend.EliminarCvCompetenciaInformatica(una_competencia_informatica)
                    .onSuccess(function (respuesta) {
                        alertify.success("Competencia informática eliminada correctamente");
                        _this.GrillaCompetenciasInformaticas.QuitarObjeto(_this.divGrilla, una_competencia_informatica);
                        var indice = _this.competencias.indexOf(una_competencia_informatica);
                        _this.competencias.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar la competencia informática");
                    }); 
            } 
        });
    }
}
