var PanelListaDeIdiomasExtranjeros = {
    armarGrilla: function (idiomas_extranjeros) {
        var _this = this;

        _this.divGrilla = $('#tabla_idiomas_extranjeros');
        _this.btn_agregar_otra_capacidad = $("#btn_agregar_otra_capacidad");

        _this.btn_agregar_otra_capacidad.click(function () {
            PanelDetalleDeOtraCapacidad.mostrar({
                alModificar: function (nueva_capacidad) {
                    _this.GrillaIdiomasExtranjeros.BorrarContenido();
                    idiomas_extranjeros.push(nueva_capacidad);
                    _this.GrillaIdiomasExtranjeros.CargarObjetos(idiomas_extranjeros);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Id", { generar: function (un_idioma_extranjero) { return un_idioma_extranjero.Id } }));
        columnas.push(new Columna("Tipo", { generar: function (un_idioma_extranjero) { return un_idioma_extranjero.Tipo } }));
        columnas.push(new Columna("Detalle", { generar: function (un_idioma_extranjero) { return un_idioma_extranjero.Detalle } }));
        columnas.push(new Columna('Acciones', {
            generar: function (un_idioma_extranjero) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeOtraCapacidad.mostrar({
                        capacidad: un_idioma_extranjero,
                        alModificar: function (capacidad_modificada) {
                            _this.GrillaIdiomasExtranjeros.BorrarContenido();
                            _this.GrillaIdiomasExtranjeros.CargarObjetos(idiomas_extranjeros);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(un_idioma_extranjero);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaIdiomasExtranjeros = new Grilla(columnas);
        this.GrillaIdiomasExtranjeros.AgregarEstilo("table table-striped");
        this.GrillaIdiomasExtranjeros.SetOnRowClickEventHandler(function (un_idioma_extranjero) {
        });

        this.GrillaIdiomasExtranjeros.CargarObjetos(idiomas_extranjeros);
        this.GrillaIdiomasExtranjeros.DibujarEn(_this.divGrilla);

    },
    eliminar: function (un_idioma_extranjero) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la capacidad?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVIdiomasExtranjeros",
                    data: {
                        un_idioma_extranjero: un_idioma_extranjero
                    },
                    success: function (respuesta) {
                        alertify.success("Capacidad eliminada correctamente");
                        _this.GrillaIdiomasExtranjeros.QuitarObjeto(_this.divGrilla, un_idioma_extranjero);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar la capacidad");
                    }
                });
            } else {
                // user clicked "cancel"
                alertify.error("No se pudo eliminar la capacidad");
            }
        });



    }
}
