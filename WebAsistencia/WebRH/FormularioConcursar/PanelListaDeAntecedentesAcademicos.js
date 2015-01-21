var PanelListaDeAntecedentesAcademicos = {
    armarGrilla: function (estudios) {
        var _this = this;

        _this.divGrilla = $('#tabla_antecedentes_academicos');
        _this.btn_agregar_otro_antecedente = $("#btn_agregar_antecedente_academico");

        _this.btn_agregar_otro_antecedente.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: { 
                    Pais: 9,
                    Nivel: 1,
                    FechaIngreso: ConversorDeFechas.ConvertirDateNowDeJS(Date.now()),
                    FechaEgreso: ConversorDeFechas.ConvertirDateNowDeJS(Date.now())
                },
                path_html: "PanelDetalleDeAntecedenteAcademico.htm",
                metodoDeGuardado: "GuardarCvAntecedenteAcademico",
                mensajeDeGuardadoExitoso: "El Antecedente académico fue creado correctamente",
                mensajeDeGuardadoErroneo: "Error al crear el antecedente académico",
                alModificar: function (nuevo_antecedente) {
                    _this.GrillaAntecedentesAcademicos.BorrarContenido();
                    estudios.push(nuevo_antecedente);
                    _this.GrillaAntecedentesAcademicos.CargarObjetos(estudios);
                }
            });
        });

        var columnas = [];

        var columnas = [];
        columnas.push(new Columna("Título", { generar: function (un_estudio) { return un_estudio.Titulo } }));
        columnas.push(new Columna("Nivel", {
            generar: function (un_estudio, callback) {
                Repositorio.buscar("NivelesDeEstudio", { Id: un_estudio.Nivel }, function (niveles) { callback(niveles[0].Descripcion) });
            }, asincronico: true
        }));
        columnas.push(new Columna("Establecimiento", { generar: function (un_estudio) { return un_estudio.Establecimiento } }));
        columnas.push(new Columna('Acciones', {
            generar: function (un_estudio) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: un_estudio,
                        path_html: "PanelDetalleDeAntecedenteAcademico.htm",
                        metodoDeGuardado: "ActualizarCvAntecedenteAcademico",
                        mensajeDeGuardadoExitoso: "El antecedente fue actualizado correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar el antecedente académico",
                        alModificar: function (estudio_modificado) {
                            _this.GrillaAntecedentesAcademicos.BorrarContenido();
                            _this.GrillaAntecedentesAcademicos.CargarObjetos(estudios);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(un_estudio);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaAntecedentesAcademicos = new Grilla(columnas);
        this.GrillaAntecedentesAcademicos.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaAntecedentesAcademicos.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaAntecedentesAcademicos.SetOnRowClickEventHandler(function (un_estudio) {
        });

        this.GrillaAntecedentesAcademicos.CargarObjetos(estudios);
        this.GrillaAntecedentesAcademicos.DibujarEn(_this.divGrilla);

        this.estudios = estudios;
    },
    eliminar: function (un_estudio) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar la capacidad?", function (e) {
            if (e) {
                Backend.EliminarCvAntecedenteAcademico(un_estudio.Id)
                    .onSuccess(function (respuesta) {
                        alertify.success("Antecedente eliminado correctamente");
                        _this.GrillaAntecedentesAcademicos.QuitarObjeto(_this.divGrilla, un_estudio);
                        var indice = _this.estudios.indexOf(un_estudio);
                        _this.estudios.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar el antecedente");
                    });   
            }
        });
    }
}
