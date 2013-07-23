var VisualizadorDeImagenes = function (opt) {
    this.o = opt;
    this.o.ui.hide();
    this.visible = false;
    this.panelImagen = this.o.ui.find('#imagen');
    this.tituloImagen = this.o.ui.find('#tituloImagen');
};

VisualizadorDeImagenes.prototype.mostrarImagen = function (id_imagen) {
    var _this = this;
    this.o.ui.children().hide();
    this.o.ui.dialog({
        title: "Cargando Imagen",
        height: 580,
        width: 1020,
        modal: true,
        show: {
            effect: "fade",
            duration: 500
        }
    });
    this.mostrarRelojitoDeEspera();
    this.o.servicioDeImagenes.getThumbnailPorId(
        id_imagen,
        0,
        980,
        function (imagen) {
            _this.ocultarRelojitoDeEspera();
            _this.visible = true;
            _this.o.ui.dialog("option", "title", imagen.nombre);
            _this.panelImagen.attr("src", "data:image/png;base64," + imagen.bytesImagen);
            _this.o.ui.children().show();
            /*
            _this.panelImagen.panZoom({
                zoomIn: _this.botonZoomIn,
                zoomOut: _this.botonZoomOut,
                min_width: 1000,
                min_height: 580,
                draggable: false
            });*/

            //_this.panelImagen.panZoom('fit');
            //});
        });
};

VisualizadorDeImagenes.prototype.mostrarRelojitoDeEspera = function () {
    this.progress_bar = $('<div style="min-height: 500px;">');
    this.progress_bar.progressbar({
        value: false
    });
    this.progress_bar.progressbar("option", "value", false);
    this.progress_bar.show();
    this.o.ui.append(this.progress_bar);
};

VisualizadorDeImagenes.prototype.ocultarRelojitoDeEspera = function () {
    this.progress_bar.remove();
}; 
