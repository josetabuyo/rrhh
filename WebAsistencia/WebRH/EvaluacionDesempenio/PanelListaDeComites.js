var PanelListaDeComites = {
    armarGrilla: function (comites) {
        var _this = this;
        _this.divGrilla = $('#tabla_comites');
        _this.btn_agregar_comite = $("#btn_agregar_comite");

        _this.btn_agregar_comite.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: {
                    Periodo: 1
                },
                path_html: "PanelDetalleComite.htm",
                metodoDeGuardado: "GuardarComite",
                mensajeDeGuardadoExitoso: "El comité fue creado correctamente",
                mensajeDeGuardadoErroneo: "Error al crear comité",
                alModificar: function (nuevo_comite) {
                    _this.GrillaComites.BorrarContenido();
                    comites.push(nuevo_comite);
                    _this.GrillaComites.CargarObjetos(comites);
                }
            });
        });

        var columnas = [];
        columnas.push(new Columna("Id", { generar: function (comite) { return comite.Id; } }));
        columnas.push(new Columna("Lugar", { generar: function (comite) { return comite.Lugar; } }));
        columnas.push(new Columna("Fecha", { generar: function (comite) { return comite.Fecha.substring(0, 10); } }));
        columnas.push(new Columna("Periodo", { generar: function (comite) { return comite.Periodo.descripcion_periodo; } }));
        columnas.push(new Columna("UE", { generar: function (comite) {
            var ues = comite.UnidadesEvaluacion;
            if (ues.length == 0) {
                return "No especificado";
            }
            if (ues.length == 1) {
                return ues[0].NombreArea;
            }
            return ues[0].NombreArea & " y " & (ues.length - 1).toString() & " ue mas";
        }
        }));

        columnas.push(new Columna('Acciones', {
            generar: function (un_comite) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: un_comite,
                        path_html: "PanelDetalleComite.htm",
                        metodoDeGuardado: "xx",
                        mensajeDeGuardadoExitoso: "El comité fue actualizado correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar el comité",
                        alModificar: function (comite_modificado) {
                            _this.GrillaComites.BorrarContenido();
                            _this.GrillaComites.CargarObjetos(comites);
                        }
                    });
                });

                btn_eliminar.click(function () {
                    _this.eliminar(un_comite);
                });

                return contenedorBtnAcciones;
            } 
        }));

        this.GrillaComites = new Grilla(columnas);
        this.GrillaComites.CargarObjetos(comites);
        this.GrillaComites.DibujarEn(_this.divGrilla);
    }
}