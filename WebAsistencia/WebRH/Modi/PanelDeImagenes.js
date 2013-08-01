var PanelDeImagenes = function (opt) {
    this.o = opt;
    this.start();
};

PanelDeImagenes.prototype.start = function () {
    this.ui = $("#plantilla_ui_panel_imagenes").clone();
    this.aviso_no_hay_imagenes = this.ui.find('#aviso_no_hay_imagenes');
    this.aviso_no_hay_imagenes.text(this.o.mensajeParaCuandoEstaVacio);    
    this.vistasImagenes = [];
    var _this = this;
    this.ui.droppable({
        accept: ".imagen_miniatura",
        hoverClass: "ui-state-active",
        drop: function (event, ui) {
            var imagen = _this.o.servicioDeDragAndDrop.imagenOnDrag;
            _this.agregarVistaImagen(imagen);
            _this.o.servicioDeDragAndDrop.panelOrigen.quitarVistaImagen(imagen);
            _this.o.servicioDeDragAndDrop.terminoElDragAndDrop();
            _this.o.onImagenDropeada(imagen);
        },
        out: function (event, ui) {
            _this.o.servicioDeDragAndDrop.panelOrigen = _this;
        }
    });
};

PanelDeImagenes.prototype.cargarImagenes = function (id_imagenes) {
    this.ui.empty();
    this.vistasImagenes = [];
    this.ui.append(this.aviso_no_hay_imagenes);
    for (var i = 0; i < id_imagenes.length; i++) {
        var vista_imagen = new VistaDeImagen({
            idImagen: id_imagenes[i],
            servicioDeDragAndDrop: this.o.servicioDeDragAndDrop,
            servicioDeLegajos: this.o.servicioDeLegajos
        });
        this.agregarVistaImagen(vista_imagen);
    }
};

PanelDeImagenes.prototype.quitarVistaImagen = function (imagen) {
    var index = this.vistasImagenes.indexOf(imagen);
    this.vistasImagenes.splice(index, 1);
    if (this.vistasImagenes.length == 0) this.aviso_no_hay_imagenes.show();
};

PanelDeImagenes.prototype.agregarVistaImagen = function (imagen) {
    imagen.dibujarEn(this.ui);
    this.vistasImagenes.push(imagen);
    this.aviso_no_hay_imagenes.hide();
};

PanelDeImagenes.prototype.dibujarEn = function (panel) {
    panel.append(this.ui);
};