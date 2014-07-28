var PanelListaDeExperienciasLaborales = {
    armarGrilla: function (experiencias) {
        var _this = this;

        _this.divGrilla = $('#tabla_experiencias_laborales');
        _this.btn_agregar_experiencia_laboral = $("#btn_agregar_experiencia_laboral");

        _this.btn_agregar_experiencia_laboral.click(function () {

            PanelDetalleDeExperienciaLaboral.mostrar({
                alModificar: function (nueva_experiencia) {
                    _this.GrillaExperiencias.BorrarContenido();
                    experiencias.push(nueva_experiencia);
                    _this.GrillaExperiencias.CargarObjetos(experiencias);
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
                    PanelDetalleDeExperienciaLaboral.mostrar({
                        experiencia: una_experiencia,
                        alModificar: function (experiencia_modificada) {
                            _this.GrillaExperiencias.BorrarContenido();
                            _this.GrillaExperiencias.CargarObjetos(experiencias);
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
        this.GrillaExperiencias.AgregarEstilo("table table-striped");
        this.GrillaExperiencias.SetOnRowClickEventHandler(function (una_experiencia) {
        });

        this.GrillaExperiencias.CargarObjetos(experiencias);
        this.GrillaExperiencias.DibujarEn(_this.divGrilla);

    },
    eliminar: function (una_experiencia) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la experiencia laboral?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCvExperienciaLaboral",
                    data: {
                        id_experiencia_laboral: una_experiencia.id
                    },
                    success: function (respuesta) {
                        alertify.success("Experiencia eliminada correctamente");
                        _this.GrillaExperiencias.QuitarObjeto(_this.divGrilla, una_experiencia);
                        var indice = _this.idiomas.indexOf(una_experiencia);
                        _this.experiencias.splice(indice, 1);
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
