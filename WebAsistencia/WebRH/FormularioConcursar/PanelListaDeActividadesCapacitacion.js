var PanelListaDeActividadesCapacitacion = {
    armarGrilla: function (actividades_capacitacion) {
        var _this = this;

        _this.divGrilla = $('#tabla_actividades_capacitacion');
        _this.btn_agregar_actividad_capacitacion = $("#btn_agregar_actividad_capacitacion");

        _this.btn_agregar_actividad_capacitacion.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: { 
                    Pais: 9,
                    //FechaInicio: ConversorDeFechas.ConvertirDateNowDeJS(Date.now()),
                    //FechaFinalizacion: ConversorDeFechas.ConvertirDateNowDeJS(Date.now())
                },
                path_html: "PanelDetalleDeActividadCapacitacion.htm",
                metodoDeGuardado: "GuardarCvActividadCapacitacion",
                mensajeDeGuardadoExitoso: "La actividad fue guardada correctamente",
                mensajeDeGuardadoErroneo: "Error al guardar la actividad de capacitación",
                alModificar: function (nueva_actividad_capacitacion) {
                    _this.GrillaActividadesCapacitacion.BorrarContenido();
                    actividades_capacitacion.push(nueva_actividad_capacitacion);
                    _this.GrillaActividadesCapacitacion.CargarObjetos(actividades_capacitacion);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Diploma/Certificación", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.DiplomaDeCertificacion } }));
        columnas.push(new Columna("Duración", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Duracion } }));
        columnas.push(new Columna("Fecha Inicio", { generar: function (una_actividad_capacitacion) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_actividad_capacitacion.FechaInicio) } }));
        columnas.push(new Columna("Fecha Fin", { generar: function (una_actividad_capacitacion) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_actividad_capacitacion.FechaFinalizacion) } }));
        columnas.push(new Columna("Especialidad", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Especialidad } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_actividad_capacitacion) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: una_actividad_capacitacion,
                        path_html: "PanelDetalleDeActividadCapacitacion.htm",
                        metodoDeGuardado: "ActualizarCvActividadCapacitacion",
                        mensajeDeGuardadoExitoso: "La actividad fue actualizada correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar la actividad de capacitación",
                        alModificar: function (actividad_capacitacion_modificada) {
                            _this.GrillaActividadesCapacitacion.BorrarContenido();
                            _this.GrillaActividadesCapacitacion.CargarObjetos(actividades_capacitacion);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_actividad_capacitacion);
                });

                return contenedorBtnAcciones;
            }}));

        this.GrillaActividadesCapacitacion = new Grilla(columnas);
        this.GrillaActividadesCapacitacion.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaActividadesCapacitacion.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaActividadesCapacitacion.SetOnRowClickEventHandler(function (una_actividad_capacitacion) {
        });

        this.GrillaActividadesCapacitacion.CargarObjetos(actividades_capacitacion);
        this.GrillaActividadesCapacitacion.DibujarEn(_this.divGrilla);

        this.actividades = actividades_capacitacion;
    },
    eliminar: function (una_actividad_capacitacion) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la actividad?", function (e) {
            if (e) {
                Backend.EliminarCvActividadCapacitacion(una_actividad_capacitacion)
                    .onSuccess(function (respuesta) {
                        alertify.success("Actividad eliminada correctamente");
                        _this.GrillaActividadesCapacitacion.QuitarObjeto(_this.divGrilla, una_actividad_capacitacion);
                        var indice = _this.actividades.indexOf(una_actividad_capacitacion);
                        _this.actividades.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar el antecedente");
                    });   
            } 
        });
    }
}
