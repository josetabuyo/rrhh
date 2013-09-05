var PanelDeImagenes = function (opt) {
    this.o = opt;
    this.start();
};

PanelDeImagenes.prototype.start = function () {
    this.ui = $("#plantilla_ui_panel_imagenes").clone();
    this.aviso_no_hay_imagenes = this.ui.find('#aviso_no_hay_imagenes');
    this.aviso_no_hay_imagenes.text(this.o.mensajeParaCuandoEstaVacio);
    var _this = this;

    this.ui.droppable({
        accept: ".imagen_miniatura",
        drop: function (event, ui) {
            _this.o.onImagenDropeada(_this.o.servicioDeDragAndDrop.imagenOnDrag);
        }
    });
    this.ui.disableSelection();
};

PanelDeImagenes.prototype.cargarImagenes = function (imagenes) {
    this.ui.find(".imagen_miniatura").remove();
    this.aviso_no_hay_imagenes.show();   
    for (var i = 0; i < imagenes.length; i++) {
        var vista_imagen = new VistaDeImagen({
            idImagen: imagenes[i].id,
            servicioDeDragAndDrop: this.o.servicioDeDragAndDrop,
            servicioDeLegajos: this.o.servicioDeLegajos
        });
        this.agregarVistaImagen(vista_imagen);
    }
};

PanelDeImagenes.prototype.cantidadDeImagenes = function () {
    return this.ui.find(".imagen_miniatura").length;
};

PanelDeImagenes.prototype.quitarVistaImagen = function (imagen) {
    if (this.cantidadDeImagenes() == 0) this.aviso_no_hay_imagenes.show();
};

PanelDeImagenes.prototype.agregarVistaImagen = function (imagen) {
    imagen.dibujarEn(this.ui);    
    imagen.ui.show();
    this.aviso_no_hay_imagenes.hide();
};

PanelDeImagenes.prototype.dibujarEn = function (panel) {
    panel.append(this.ui);
};