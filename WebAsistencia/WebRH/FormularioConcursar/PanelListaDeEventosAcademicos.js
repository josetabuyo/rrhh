var PanelListaDeEventosAcademicos = {
    armarGrilla: function (eventos_academicos) {
        var _this = this;
        _this.divGrilla = $('#tabla_eventos_academicos');
        _this.btn_agregar_evento_academico = $("#btn_agregar_evento_academico");

        _this.btn_agregar_evento_academico.click(function () {
            PanelDetalleDeEventoAcademico.mostrar({
                alModificar: function (nuevo_evento_academico) {
                    _this.GrillaEventosAcademicos.BorrarContenido();
                    eventos_academicos.push(nuevo_evento_academico);
                    _this.GrillaEventosAcademicos.CargarObjetos(eventos_academicos);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Id", { generar: function (un_evento_academico) { return un_evento_academico.Id } }));
        columnas.push(new Columna("Denominación", { generar: function (un_evento_academico) { return un_evento_academico.Denominacion } }));
        columnas.push(new Columna("Tipo", { generar: function (un_evento_academico) { return un_evento_academico.TipoDeEvento } }));
        columnas.push(new Columna("Carácter", { generar: function (un_evento_academico) { return un_evento_academico.CaracterDeParticipacion } }));
        columnas.push(new Columna("Desde", { generar: function (un_evento_academico) { return ConversorDeFechas.deIsoAFechaEnCriollo(un_evento_academico.FechaInicio) } }));
        columnas.push(new Columna("Hasta", { generar: function (un_evento_academico) { return ConversorDeFechas.deIsoAFechaEnCriollo(un_evento_academico.FechaFinalizacion) } }));
        columnas.push(new Columna("Institución", { generar: function (un_evento_academico) { return un_evento_academico.Institucion } }));
        columnas.push(new Columna('Acciones', {
            generar: function (un_evento_academico) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    PanelDetalleDeEventoAcademico.mostrar({
                        evento_academico: un_evento_academico,
                        alModificar: function (evento_academico_modificado) {
                            _this.GrillaCapacidades.BorrarContenido();
                            _this.GrillaCapacidades.CargarObjetos(eventos);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(un_evento_academico);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaEventosAcademicos = new Grilla(columnas);
        this.GrillaEventosAcademicos.AgregarEstilo("table table-striped");
        this.GrillaEventosAcademicos.SetOnRowClickEventHandler(function (un_evento_academico) {
        });

        this.GrillaEventosAcademicos.CargarObjetos(eventos_academicos);
        this.GrillaEventosAcademicos.DibujarEn(_this.divGrilla);

    },
    eliminar: function (un_evento_academico) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la el evento académico?", function (e) {
            if (e) {
                // user clicked "ok"
                var proveedor_ajax = new ProveedorAjax();

                proveedor_ajax.postearAUrl({ url: "EliminarCVEventosAcademicos",
                    data: {
                        eventosAcademicos_borrar: un_evento_academico
                    },
                    success: function (respuesta) {
                        alertify.success("Evento académico eliminado correctamente");
                        _this.GrillaEventosAcademicos.QuitarObjeto(_this.divGrilla, un_evento_academico);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.error("No se pudo eliminar el evento académico");
                    }
                });
            } else {
                // user clicked "cancel"
                alertify.error("No se pudo eliminar el evento académico");
            }
        });



    }
}
