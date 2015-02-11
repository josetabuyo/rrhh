var PanelListaDeEventosAcademicos = {
    armarGrilla: function (eventos_academicos) {
        var _this = this;
        _this.divGrilla = $('#tabla_eventos_academicos');
        _this.btn_agregar_evento_academico = $("#btn_agregar_evento_academico");
        _this.eventos_academicos = eventos_academicos;

        _this.btn_agregar_evento_academico.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: {
                    Pais: 9,
                    TipoDeEvento: 1,
                    CaracterDeParticipacion: 1,
                    Institucion: 1,
                    FechaInicio: ConversorDeFechas.ConvertirDateNowDeJS(Date.now()),
                    FechaFinalizacion: ConversorDeFechas.ConvertirDateNowDeJS(Date.now())
                },
                path_html: "PanelDetalleDeEventoAcademico.htm",
                metodoDeGuardado: "GuardarCvEventoAcademico",
                mensajeDeGuardadoExitoso: "El evento académico fue creado correctamente",
                mensajeDeGuardadoErroneo: "Error al crear la el evento académico",
                alModificar: function (nuevo_evento_academico) {
                    _this.GrillaEventosAcademicos.BorrarContenido();
                    eventos_academicos.push(nuevo_evento_academico);
                    _this.GrillaEventosAcademicos.CargarObjetos(eventos_academicos);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Denominación", { generar: function (un_evento_academico) { return un_evento_academico.Denominacion } }));
        columnas.push(new Columna("Tipo", {
            generar: function (un_evento_academico, callback) {
                Repositorio.buscar("TiposEventosAcademicos", { Id: un_evento_academico.TipoDeEvento }, function (niveles) { callback(niveles[0].Descripcion) });
            }, asincronico: true
        }));

        columnas.push(new Columna("Carácter", {
            generar: function (un_evento_academico, callback) {
                Repositorio.buscar("CaracterParticipacionEvento", { Id: un_evento_academico.CaracterDeParticipacion }, function (niveles) { callback(niveles[0].Descripcion) });
            }, asincronico: true
        }));

        columnas.push(new Columna("Institución", {
            generar: function (un_evento_academico, callback) {
                Repositorio.buscar("InstitucionesEvento", { Id: un_evento_academico.Institucion }, function (niveles) { callback(niveles[0].Descripcion) });
            }, asincronico: true
        }));



        columnas.push(new Columna('Acciones', {
            generar: function (un_evento_academico) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: un_evento_academico,
                        path_html: "PanelDetalleDeEventoAcademico.htm",
                        metodoDeGuardado: "ActualizarCvEventoAcademico",
                        mensajeDeGuardadoExitoso: "El evento académico fue actualizado correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar el evento académico",
                        alModificar: function (evento_academico_modificado) {
                            _this.GrillaEventosAcademicos.BorrarContenido();
                            _this.GrillaEventosAcademicos.CargarObjetos(eventos_academicos);
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
        this.GrillaEventosAcademicos.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaEventosAcademicos.CambiarEstiloCabecera("cabecera_tabla_postular");
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
                Backend.EliminarCvEventosAcademicos(un_evento_academico)
                    .onSuccess(function (respuesta) {
                        alertify.success("Evento académico eliminado correctamente");
                        _this.GrillaEventosAcademicos.QuitarObjeto(_this.divGrilla, un_evento_academico);
                        var indice = _this.eventos_academicos.indexOf(un_evento_academico);
                        _this.eventos_academicos.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar el evento académico");
                    });
            }
        });



    }
}
