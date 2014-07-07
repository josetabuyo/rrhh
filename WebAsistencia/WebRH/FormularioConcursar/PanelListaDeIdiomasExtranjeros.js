var PanelListaDeIdiomasExtranjeros = {
    armarGrilla: function (idiomas_extranjeros) {
        var _this = this;

        _this.divGrilla = $('#tabla_idiomas_extranjeros');
        _this.btn_agregar_idioma_extranjero = $("#btn_agregar_idioma_extranjero");

        _this.btn_agregar_idioma_extranjero.click(function () {
            PanelDetalleDeIdiomaExtranjero.mostrar({
                alModificar: function (nuevo_idioma_extranjero) {
                    _this.GrillaIdiomasExtranjeros.BorrarContenido();
                    idiomas_extranjeros.push(nuevo_idioma_extranjero);
                    _this.GrillaIdiomasExtranjeros.CargarObjetos(idiomas_extranjeros);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Idioma", { generar: function (un_idioma_extranjero) { return un_idioma_extranjero.Idioma } }));
        columnas.push(new Columna("Lectura", { generar: function (un_idioma_extranjero) { return un_idioma_extranjero.Lectura } }));
        columnas.push(new Columna("Escritura", { generar: function (un_idioma_extranjero) { return un_idioma_extranjero.Escritura } }));
        columnas.push(new Columna("Oral", { generar: function (un_idioma_extranjero) { return un_idioma_extranjero.Oral } }));
        columnas.push(new Columna('Acciones', {
            generar: function (un_idioma_extranjero) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeIdiomaExtranjero.mostrar({
                        idioma_extranjero: un_idioma_extranjero,
                        alModificar: function (idioma_extranjero_modificado) {
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
        alertify.confirm("¿Está seguro que desea eliminar el idioma?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVIdiomasExtranjeros",
                    data: {
                        id_idioma_extranjero: un_idioma_extranjero.Id
                    },
                    success: function (respuesta) {
                        alertify.success("Idioma eliminado correctamente");
                        _this.GrillaIdiomasExtranjeros.QuitarObjeto(_this.divGrilla, un_idioma_extranjero);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar el idioma");
                    }
                });
            } else {
                // user clicked "cancel"
                alertify.error("No se pudo eliminar el idioma");
            }
        });



    }
}
