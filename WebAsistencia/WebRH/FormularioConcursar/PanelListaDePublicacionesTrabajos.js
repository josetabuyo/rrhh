var PanelListaDePublicacionesTrabajos = {
    armarGrilla: function (publicaciones) {
        var _this = this;
        _this.divGrilla = $('#tabla_publicaciones_trabajos');
        _this.btn_agregar_publicacion_trabajo = $("#btn_agregar_publicacion_trabajo");

        _this.btn_agregar_publicacion_trabajo.click(function () {
            PanelDetalleDePublicaciones.mostrar({
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
        //columnas.push(new Columna("Páginas", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.CantidadHojas } }));
        //columnas.push(new Columna("Dispone Copias", { generar: function (una_publicacion_trabajo) { return una_publicacion_trabajo.DisponeCopia} }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_publicacion_trabajo) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDePublicaciones.mostrar({
                        publicacion: una_publicacion_trabajo,
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
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCvPublicacionesTrabajos",
                    data: {
                        publicacionesTrabajos_borrar: una_publicacion_trabajo
                    },
                    success: function (respuesta) {
                        alertify.success("Publicación eliminada correctamente");
                        _this.GrillaPublicaciones.QuitarObjeto(_this.divGrilla, una_publicacion_trabajo);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar la publicación");
                    }
                });
            } else {
                // user clicked "cancel"
                //alertify.error("No se pudo eliminar la publicación");
            }
        });



    }
}
