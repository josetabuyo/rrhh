var PanelListaDeInstitucionesAcademicas = {
    armarGrilla: function (instituciones_academicas) {
        var _this = this;

        _this.divGrilla = $('#tabla_instituciones_academicas');
        _this.btn_agregar_institucion_academica = $("#btn_agregar_institucion_academica");

        _this.btn_agregar_institucion_academica.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: {
                    Pais: 9, 
                    FechaDeAfiliacion: ConversorDeFechas.ConvertirDateNowDeJS(Date.now()),
                    Fecha: ConversorDeFechas.ConvertirDateNowDeJS(Date.now()),
                    FechaInicio: ConversorDeFechas.ConvertirDateNowDeJS(Date.now()),
                    FechaFin: ConversorDeFechas.ConvertirDateNowDeJS(Date.now())
                },
                path_html: "PanelDetalleDeInstitucionAcademica.htm",
                metodoDeGuardado: "GuardarCvInstitucionAcademica",
                mensajeDeGuardadoExitoso: "La institución fue guardada correctamente",
                mensajeDeGuardadoErroneo: "Error al guardar la institución",
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
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: una_institucion_academica,
                        path_html: "PanelDetalleDeInstitucionAcademica.htm",
                        metodoDeGuardado: "ActualizarCvInstitucionAcademica",
                        mensajeDeGuardadoExitoso: "La institución fue actualizada correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar la institución",
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
        this.GrillaInstitucionesAcademicas.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaInstitucionesAcademicas.CambiarEstiloCabecera("cabecera_tabla_postular");
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
                Backend.EliminarCvInstitucionAcademica(una_institucion_academica.Id)
                    .onSuccess(function (respuesta) {
                        alertify.success("Institución eliminada correctamente");
                        _this.GrillaInstitucionesAcademicas.QuitarObjeto(_this.divGrilla, una_institucion_academica);
                        var indice = _this.instituciones.indexOf(una_institucion_academica);
                        _this.instituciones.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar la institución");
                    });   
            }
        });
    }
}
