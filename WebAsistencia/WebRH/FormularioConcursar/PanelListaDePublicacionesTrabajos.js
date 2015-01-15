var PanelListaDePublicacionesTrabajos = {
    armarGrilla: function (publicaciones) {
        var _this = this;
        _this.divGrilla = $('#tabla_publicaciones_trabajos');
        _this.btn_agregar_publicacion_trabajo = $("#btn_agregar_publicacion_trabajo");

        _this.btn_agregar_publicacion_trabajo.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: {
                    FechaPublicacion: ConversorDeFechas.ConvertirDateNowDeJS(Date.now())
                },
                path_html: "PanelDetalleDePublicacionTrabajo.htm",
                metodoDeGuardado: "GuardarCvPublicacionesTrabajos",
                mensajeDeGuardadoExitoso: "La publicacion fue creada correctamente",
                mensajeDeGuardadoErroneo: "Error al crear la publicacion",
                alModificar: function (nueva_publicacion) {
                    _this.GrillaPublicaciones.BorrarContenido();
                    publicaciones.push(nueva_publicacion);
                    _this.GrillaPublicaciones.CargarObjetos(publicaciones);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Título", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.Titulo } }));
        columnas.push(new Columna("Datos de Editorial/Revista", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.DatosEditorial } }));
        columnas.push(new Columna("Fecha", { generar: function (una_publicacion_trabajo) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_publicacion_trabajo.FechaPublicacion) } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_publicacion_trabajo) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: una_publicacion_trabajo,
                        path_html: "PanelDetalleDePublicacionTrabajo.htm",
                        metodoDeGuardado: "ActualizarCvPublicaciones",
                        mensajeDeGuardadoExitoso: "La publicación fue actualizada correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar la publicación",
                        alModificar: function (publicacion_modificada) {
                            _this.GrillaPublicaciones.BorrarContenido();
                            _this.GrillaPublicaciones.CargarObjetos(publicaciones);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_publicacion_trabajo);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaPublicaciones = new Grilla(columnas);
        this.GrillaPublicaciones.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaPublicaciones.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaPublicaciones.SetOnRowClickEventHandler(function (una_publicacion_trabajo) {
        });

        this.GrillaPublicaciones.CargarObjetos(publicaciones);
        this.GrillaPublicaciones.DibujarEn(_this.divGrilla);

    },
    eliminar: function (una_publicacion_trabajo) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la publicación?", function (e) {
            if (e) {
                Backend.EliminarCvPublicacionesTrabajos(una_publicacion_trabajo.Id)
                    .onSuccess(function (respuesta) {
                        alertify.success("Publicación eliminada correctamente");
                        _this.GrillaPublicaciones.QuitarObjeto(_this.divGrilla, una_publicacion_trabajo);
                        var indice = _this.publicaciones.indexOf(una_publicacion_trabajo);
                        _this.publicaciones.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar la publicación");
                    });   
            }
        });
    }
}
