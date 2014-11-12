var PanelListaDeActividadesDocentes = {
    armarGrilla: function (actividades_docentes) {
        var _this = this;

        _this.actividades_docentes = actividades_docentes;
        _this.divGrilla = $('#tabla_actividades_docentes');
        _this.btn_agregar_otra_actividad_docente = $("#btn_agregar_actividad_docente");

        _this.btn_agregar_otra_actividad_docente.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: {
                    NivelEducativo: { Id: 0 },
                    Pais: 9
                },
                path_html: "PanelDetalleDeActividadDocente.htm",
                metodoDeGuardado: "GuardarCvActividadDocente",
                mensajeDeGuardadoExitoso: "La actividad docente fue creada correctamente",
                mensajeDeGuardadoErroneo: "Error al crear la actividad docente",
                alModificar: function (nueva_actividad) {
                    _this.GrillaActividadesDocentes.BorrarContenido();
                    _this.actividades_docentes.push(nueva_actividad);
                    _this.GrillaActividadesDocentes.CargarObjetos(_this.actividades_docentes);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Asignatura", { generar: function (una_actividad_docente) { return una_actividad_docente.Asignatura } }));
        columnas.push(new Columna("Fecha Inicio", { generar: function (una_actividad_docente) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_actividad_docente.FechaInicio); } }));
        columnas.push(new Columna("Fecha Fin", { generar: function (una_actividad_docente) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_actividad_docente.FechaFinalizacion); } }));
        columnas.push(new Columna("Establecimiento", { generar: function (una_actividad_docente) { return una_actividad_docente.Establecimiento } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_actividad_docente) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: una_actividad_docente,
                        path_html: "PanelDetalleDeActividadDocente.htm",
                        metodoDeGuardado: "ActualizarCvActividadDocente",
                        mensajeDeGuardadoExitoso: "La actividad docente fue actualizado correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar la actividad docente",
                        alModificar: function (docencia_modificada) {
                            _this.GrillaActividadesDocentes.BorrarContenido();
                            _this.GrillaActividadesDocentes.CargarObjetos(_this.actividades_docentes);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_actividad_docente);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaActividadesDocentes = new Grilla(columnas);
        this.GrillaActividadesDocentes.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaActividadesDocentes.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaActividadesDocentes.SetOnRowClickEventHandler(function (una_actividad_docente) {
        });

        this.GrillaActividadesDocentes.CargarObjetos(_this.actividades_docentes);
        this.GrillaActividadesDocentes.DibujarEn(_this.divGrilla);

    },
    eliminar: function (una_actividad_docente) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar este registro?", function (e) {
            if (e) {
                Backend.EliminarCvActividadDocente(una_actividad_docente.Id)
                    .onSuccess(function (respuesta) {
                        alertify.success("Docencia eliminada correctamente");
                        _this.GrillaActividadesDocentes.QuitarObjeto(_this.divGrilla, una_actividad_docente);
                        var indice = _this.actividades_docentes.indexOf(una_actividad_docente);
                        _this.actividades_docentes.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar la docencia");
                    });   
            } 
        });



    }
}
