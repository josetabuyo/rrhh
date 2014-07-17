var PanelListaDeOtrasCapacidades = {
    armarGrilla: function (experiencias) {
        var _this = this;

        _this.divGrilla = $('#tabla_otras_capacidades');
        _this.btn_agregar_otra_capacidad = $("#btn_agregar_otra_capacidad");

        _this.btn_agregar_otra_capacidad.click(function () {
            PanelDetalleDeExperienciaLaboral.mostrar({
                alModificar: function (nueva_experiencia) {
                    _this.GrillaExperiencias.BorrarContenido();
                    capacidades.push(nueva_experiencia);
                    _this.GrillaCapacidades.CargarObjetos(experiencias);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Id", { generar: function (una_experiencia) { return una_capacidad.Id } }));
        columnas.push(new Columna("Tipo", { generar: function (una_experiencia) { return una_capacidad.Tipo } }));
        columnas.push(new Columna("Detalle", { generar: function (una_experiencia) { return una_capacidad.Detalle } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_capacidad) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeExperienciaLaboral.mostrar({
                        capacidad: una_capacidad,
                        alModificar: function (experiencia_modificada) {
                            _this.GrillaCapacidades.BorrarContenido();
                            _this.GrillaCapacidades.CargarObjetos(experiencias);
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

        this.GrillaCapacidades = new Grilla(columnas);
        this.GrillaCapacidades.AgregarEstilo("table table-striped");
        this.GrillaCapacidades.SetOnRowClickEventHandler(function (una_capacidad) {
        });

        this.GrillaCapacidades.CargarObjetos(experiencias);
        this.GrillaCapacidades.DibujarEn(_this.divGrilla);

    },
    eliminar: function (una_capacidad) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la experiencia informada?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVExperiencias",
                    data: {
                        una_capacidad: una_capacidad
                    },
                    success: function (respuesta) {
                        alertify.success("Experiencia eliminada correctamente");
                        _this.GrillaCapacidades.QuitarObjeto(_this.divGrilla, una_capacidad);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar la experiencia");
                    }
                });
            } else {
                // user clicked "cancel"
                alertify.error("No se pudo eliminar la experiencia");
            }
        });



    }
}
