var PanelListaDeInstitucionesAcademicas = {
    armarGrilla: function (instituciones_academicas) {
        var _this = this;

        _this.divGrilla = $('#tabla_instituciones_academicas');
        _this.btn_agregar_institucion_academica = $("#btn_agregar_institucion_academica");

        _this.btn_agregar_institucion_academica.click(function () {
            PanelDetalleDeInstitucionAcademica.mostrar({
                alModificar: function (nueva_institucion_academica) {
                    _this.GrillaInstitucionesAcademicas.BorrarContenido();
                    instituciones_academicas.push(nueva_institucion_academica);
                    _this.GrillaInstitucionesAcademicas.CargarObjetos(instituciones_academicas);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Institución", { generar: function (una_institucion_academica) { return una_institucion_academica.Institucion } }));
        columnas.push(new Columna("Cargo", { generar: function (una_institucion_academica) { return una_institucion_academica.CargosDesempeniados } }));
        columnas.push(new Columna("Fecha Inicio", { generar: function (una_institucion_academica) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_institucion_academica.FechaInicio) } }));
        columnas.push(new Columna("Fecha Fin", { generar: function (una_institucion_academica) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_institucion_academica.FechaFin) } }));
        columnas.push(new Columna('Acciones', {
            generar: function (una_institucion_academica) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeInstitucionAcademica.mostrar({
                        institucion_academica: una_institucion_academica,
                        alModificar: function (institucion_academica_modificada) {
                            _this.GrillaInstitucionesAcademicas.BorrarContenido();
                            _this.GrillaInstitucionesAcademicas.CargarObjetos(instituciones_academicas);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(una_institucion_academica);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaInstitucionesAcademicas = new Grilla(columnas);
        this.GrillaInstitucionesAcademicas.AgregarEstilo("table table-striped");
        this.GrillaInstitucionesAcademicas.SetOnRowClickEventHandler(function (una_institucion_academica) {
        });

        this.GrillaInstitucionesAcademicas.CargarObjetos(instituciones_academicas);
        this.GrillaInstitucionesAcademicas.DibujarEn(_this.divGrilla);

        this.instituciones = instituciones_academicas;
    },
    eliminar: function (una_institucion_academica) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la institución?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVInstitucionAcademica",
                    data: {
                        id_institucion_academica: una_institucion_academica.Id
                    },
                    success: function (respuesta) {
                        alertify.success("Institución eliminada correctamente");
                        _this.GrillaInstitucionesAcademicas.QuitarObjeto(_this.divGrilla, una_institucion_academica);
                        var indice = _this.instituciones.indexOf(una_institucion_academica);
                        _this.instituciones.splice(indice, 1);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar la institución");
                    }
                });
            } else {
                // user clicked "cancel"
                alertify.error("No se pudo eliminar la institución");
            }
        });



    }
}
