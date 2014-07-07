var PanelListaDeOtrasCapacidades = {
    armarGrilla: function (capacidades) {
        var _this = this;

        _this.divGrilla = $('#tabla_otras_capacidades');
        _this.btn_agregar_otra_capacidad = $("#btn_agregar_otra_capacidad");

        _this.btn_agregar_otra_capacidad.click(function () {
            PanelDetalleDeOtraCapacidad.mostrar({
                alModificar: function (nueva_capacidad) {
                    _this.GrillaCapacidades.BorrarContenido();
                    capacidades.push(nueva_capacidad);
                    _this.GrillaCapacidades.CargarObjetos(capacidades);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Tipo", { generar: function (una_capacidad) { return RepositorioDeTiposDeCapacidadPersonal.buscar({ id: una_capacidad.Tipo }).descripcion;}}));
        columnas.push(new Columna("Detalle", { generar: function (una_capacidad) { return una_capacidad.Detalle } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_capacidad) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeOtraCapacidad.mostrar({
                        capacidad: una_capacidad,
                        alModificar: function (capacidad_modificada) {
                            _this.GrillaCapacidades.BorrarContenido();
                            _this.GrillaCapacidades.CargarObjetos(capacidades);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_capacidad);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaCapacidades = new Grilla(columnas);
        this.GrillaCapacidades.AgregarEstilo("table table-striped");
        this.GrillaCapacidades.SetOnRowClickEventHandler(function (una_capacidad) {
        });

        this.GrillaCapacidades.CargarObjetos(capacidades);
        this.GrillaCapacidades.DibujarEn(_this.divGrilla);

    },
    eliminar: function (una_capacidad) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la capacidad?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVOtraCapacidad",
                    data: {
                        id_capacidad: una_capacidad.Id
                    },
                    success: function (respuesta) {
                        alertify.success("Capacidad eliminada correctamente");
                        _this.GrillaCapacidades.QuitarObjeto(_this.divGrilla, una_capacidad);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar la capacidad");
                    }
                });
            } else {
                // user clicked "cancel"
            }
        });



    }
}
