var PanelListaDeIdiomasExtranjeros = {
    armarGrilla: function (idiomas_extranjeros) {
        var _this = this;

        _this.divGrilla = $('#tabla_idiomas_extranjeros');
        _this.btn_agregar_idioma_extranjero = $("#btn_agregar_idioma_extranjero");

        _this.btn_agregar_idioma_extranjero.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: { Pais: 9,
                    Escritura: 1,
                    Lectura: 1,
                    Oral: 1
                },
                path_html: "PanelDetalleDeIdiomaExtranjero.htm",
                metodoDeGuardado: "GuardarCvIdiomaExtranjero",
                mensajeDeGuardadoExitoso: "El idioma extranjero fue guardado correctamente",
                mensajeDeGuardadoErroneo: "Error al guardar el idioma extranjero",
                alModificar: function (nuevo_idioma_extranjero) {
                    _this.GrillaIdiomasExtranjeros.BorrarContenido();
                    idiomas_extranjeros.push(nuevo_idioma_extranjero);
                    _this.GrillaIdiomasExtranjeros.CargarObjetos(idiomas_extranjeros);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Idioma", { generar: function (un_idioma_extranjero) { return un_idioma_extranjero.Idioma } }));
        columnas.push(new Columna("Lectura", {
            generar: function (un_idioma_extranjero, callback) {
                Repositorio.buscar("NivelesDeIdioma", { Id: un_idioma_extranjero.Lectura }, function (niveles) { callback(niveles[0].Descripcion) });
            }, asincronico: true 
        }));
        columnas.push(new Columna("Escritura", {
            generar: function (un_idioma_extranjero, callback) {
                Repositorio.buscar("NivelesDeIdioma", { Id: un_idioma_extranjero.Escritura }, function (niveles) { callback(niveles[0].Descripcion) });
            }, asincronico: true 
        }));
        columnas.push(new Columna("Oral", {
            generar: function (un_idioma_extranjero, callback) {
                Repositorio.buscar("NivelesDeIdioma", { Id: un_idioma_extranjero.Oral }, function(niveles){callback(niveles[0].Descripcion)});
            }, asincronico: true 
        }));
        columnas.push(new Columna('Acciones', {
            generar: function (un_idioma_extranjero) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: un_idioma_extranjero,
                        path_html: "PanelDetalleDeIdiomaExtranjero.htm",
                        metodoDeGuardado: "ActualizarCvIdiomaExtranjero",
                        mensajeDeGuardadoExitoso: "El idioma extranjero fue actualizado correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar el idioma extranjero",
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
        this.GrillaIdiomasExtranjeros.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaIdiomasExtranjeros.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaIdiomasExtranjeros.SetOnRowClickEventHandler(function (un_idioma_extranjero) {
        });

        this.GrillaIdiomasExtranjeros.CargarObjetos(idiomas_extranjeros);
        this.GrillaIdiomasExtranjeros.DibujarEn(_this.divGrilla);

        this.idiomas = idiomas_extranjeros;
    },
    eliminar: function (un_idioma_extranjero) {
        var _this = this;
        // confirm dialog
        alertify.confirm("¿Está seguro que desea eliminar el idioma?", function (e) {
            if (e) {
                Backend.EliminarCvIdiomaExtranjero(un_idioma_extranjero.Id)
                    .onSuccess(function (respuesta) {
                        alertify.success("Idioma eliminado correctamente");
                        _this.GrillaIdiomasExtranjeros.QuitarObjeto(_this.divGrilla, un_idioma_extranjero);
                        var indice = _this.idiomas.indexOf(un_idioma_extranjero);
                        _this.idiomas.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar el idioma");
                    });   
            }
        });
    }
}
