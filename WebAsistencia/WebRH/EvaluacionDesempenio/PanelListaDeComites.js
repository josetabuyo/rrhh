var PanelListaDeComites = {
    armarGrilla: function (estudios) {
        var _this = this;
        _this.divGrilla = $('#tabla_comites');
        _this.btn_agregar_comite = $("#btn_agregar_comite");

        _this.btn_agregar_comite.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                defaults: {
                    Pais: 9,
                    Nivel: 1
                },
                path_html: "PanelDetalleComite.htm",
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
    }
}