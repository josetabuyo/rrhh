var VisualizadorDeImagenes = function (ui) {
    this.ui = ui;
    this.ui.hide();
    this.visible = false;
    this.panelImagen = this.ui.find('#imagen');
    this.tituloImagen = this.ui.find('#tituloImagen');
};

VisualizadorDeImagenes.prototype.mostrarImagen = function (imagen) {
    this.visible = true;
    this.panelImagen.attr("src", "data:image/png;base64," + imagen.bytesImagen);
    this.tituloImagen.text(imagen.nombre);
    this.ui.modal();
};

