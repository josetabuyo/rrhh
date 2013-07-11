var VistaDeResultadosDeLegajos = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeResultadosDeLegajos.prototype.start = function () {
    this.lbl_nombre = this.o.ui.find('#lbl_nombre');
    this.lbl_apellido = this.o.ui.find('#lbl_apellido');
    this.panel_documentos = this.o.ui.find('#panel_documentos');
    this.panel_imagenes_no_asignadas = this.o.ui.find('#panel_imagenes_no_asignadas');
    this.vistasDeDocumentos = [];
    this.visualizadorDeImagenes = new VisualizadorDeImagenes(this.o.ui.find('#visualizador_de_imagenes'));
};

VistaDeResultadosDeLegajos.prototype.mostrandoVisualizadorDeImagenes = function () {
    return this.visualizadorDeImagenes.visible;
}

VistaDeResultadosDeLegajos.prototype.mostrarLegajo = function (legajo) {
    this.lbl_nombre.text(legajo.nombre);
    this.lbl_apellido.text(legajo.apellido);
    this.vistasDeDocumentos = [];
    this.panel_documentos.empty();
    this.panel_imagenes_no_asignadas.empty();

    for (var i = 0; i < legajo.documentos.length; i++) {
        var vista_documento = new VistaDeDocumentoModi({
            ui: this.o.plantilla_vista_documento.clone(),
            documento: legajo.documentos[i],
            plantilla_vista_imagen: this.o.plantilla_vista_imagen
        });
        this.vistasDeDocumentos.push(vista_documento);
        vista_documento.dibujarEn(this.panel_documentos);
    }

    var _this = this;
    for (var i = 0; i < legajo.imagenesSinAsignar.length; i++) {
        var vista_imagen = new VistaDeImagenModi({
            ui: this.o.plantilla_vista_imagen.clone(),
            imagen: legajo.imagenesSinAsignar[i]
        });
        vista_imagen.onClick = function (imagen) {
            _this.o.servicioDeImagenes.getImagenSinAsignar(
                legajo.idInterna,
                imagen.nombre,
                function (imagen) {
                    _this.visualizadorDeImagenes.mostrarImagen(imagen);
                },
                function () {
                });
        };
        vista_imagen.dibujarEn(this.panel_imagenes_no_asignadas);
    }
};

