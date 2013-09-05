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
            return true;
        }
    });

    this.ui.sortable({
        connectWith: '.panel_de_imagenes',
        placeholder: 'placeholder_sortable',
        scroll: true,
        tolerance: 'intersect',
        stop: function (event, ui) {
            var posicion_en_la_que_dropeo = _this.ui.find(".imagen_miniatura").index(ui.item);
            var vista_imagen = _this.o.servicioDeDragAndDrop.imagenOnDrag;
            var panel_origen = vista_imagen.panelContenedor;
            ui.item.remove();
            _this.agregarVistaImagen(vista_imagen, posicion_en_la_que_dropeo);
            panel_origen.quitarVistaImagen(vista_imagen);
            _this.o.onImagenDropeada(vista_imagen, posicion_en_la_que_dropeo);
            console.log('Dropearon en la posicion:' + posicion_en_la_que_dropeo);
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

PanelDeImagenes.prototype.agregarVistaImagen = function (imagen, posicion) {
    var cantidad_de_imagenes_original = this.cantidadDeImagenes();
    if (posicion === undefined || this.cantidad_de_imagenes_original == 0 || posicion >= cantidad_de_imagenes_original) {
        imagen.dibujarEn(this.ui);
    }
    if ((posicion !== undefined) && (posicion < cantidad_de_imagenes_original)) {
        $(this.ui.find(".imagen_miniatura")[posicion]).before(imagen.ui);
    }
    imagen.panelContenedor = this;
    imagen.ui.show();
    this.aviso_no_hay_imagenes.hide();
};

PanelDeImagenes.prototype.dibujarEn = function (panel) {
    panel.append(this.ui);
};