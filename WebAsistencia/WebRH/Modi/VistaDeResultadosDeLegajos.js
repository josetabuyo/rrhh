var VistaDeResultadosDeLegajos = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeResultadosDeLegajos.prototype.start = function () {
    this.o.ui.css('opacity', '0');
    this.lbl_resumen_datos_personales = this.o.ui.find('#lbl_resumen_datos_personales');
    this.panel_documentos = this.o.ui.find('#panel_documentos');
    this.panel_imagenes_no_asignadas = this.o.ui.find('#panel_imagenes_no_asignadas');
    this.vistasDeDocumentos = [];
    this.visualizadorDeImagenes = new VisualizadorDeImagenes({ui:this.o.ui.find('#visualizador_de_imagenes'),
        servicioDeImagenes: this.o.servicioDeImagenes
    });
    this.btn_nueva_busqueda = this.o.ui.find('#btn_nueva_busqueda');
    var _this = this;
    this.btn_nueva_busqueda.click(function () {
        _this.o.ui.css('opacity', '0');
        _this.buscadorDeLegajos.mostrarModal();
    });
};

VistaDeResultadosDeLegajos.prototype.mostrandoVisualizadorDeImagenes = function () {
    return this.visualizadorDeImagenes.visible;
}

VistaDeResultadosDeLegajos.prototype.mostrarLegajo = function (legajo) {
    this.lbl_resumen_datos_personales.text(legajo.apellido + ", " + legajo.nombre + " (" + legajo.numeroDeDocumento + ") Id Interna:" + legajo.idInterna);
    this.vistasDeDocumentos = [];
    this.panel_documentos.empty();
    this.panel_imagenes_no_asignadas.empty();

    var _this = this;
    this.panel_imagenes_no_asignadas.droppable({
        accept: ".imagen_miniatura",
        hoverClass: "ui-state-active",
        drop: function (event, ui) {
            $(ui).remove();
            imagenOnDrag.dibujarEn(_this.panel_imagenes_no_asignadas);
            _this.o.servicioDeImagenes.desAsignarImagen(imagenOnDrag.id);
            imagenOnDrag.yaDropeo = true;
        }
    });

    for (var i = 0; i < legajo.documentos.length; i++) {
        var vista_documento = new VistaDeDocumentoModi({
            ui: this.o.plantilla_vista_documento.clone(),
            documento: legajo.documentos[i],
            plantilla_vista_imagen: this.o.plantilla_vista_imagen,
            servicioDeImagenes: this.o.servicioDeImagenes,
            visualizadorDeImagenes: this.visualizadorDeImagenes,
            numero_legajo: legajo.idInterna
        });
        this.vistasDeDocumentos.push(vista_documento);
        vista_documento.dibujarEn(this.panel_documentos);
    }

    var _this = this;
    for (var i = 0; i < legajo.idImagenesSinAsignar.length; i++) {
        var vista_imagen = new VistaDeImagenModi({
            ui: this.o.plantilla_vista_imagen.clone(),
            id_imagen: legajo.idImagenesSinAsignar[i],
            servicioDeImagenes: this.o.servicioDeImagenes,
            visualizadorDeImagenes: this.visualizadorDeImagenes
        });
        vista_imagen.dibujarEn(this.panel_imagenes_no_asignadas);
    }

    this.o.ui.css('opacity', '1');
};

VistaDeResultadosDeLegajos.prototype.buscadorDeLegajos = {};
