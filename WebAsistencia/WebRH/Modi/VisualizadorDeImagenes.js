var VisualizadorDeImagenes = function (opt) {
    this.o = opt;
    this.start();
};

VisualizadorDeImagenes.prototype.start = function () {
    this.ui = $("#plantilla_ui_visualizador_imagen").clone();
    this.panelImagen = this.ui.find('#imagen');
    var _this = this;
    
    this.ui.dialog({
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
    this.o.servicioDeLegajos.getThumbnailPorId(
        this.o.idImagen,
        0,
        980,
        function (imagen) {
            _this.ocultarRelojitoDeEspera();
            _this.ui.dialog("option", "title", imagen.nombre);
            _this.panelImagen.attr("src", "data:image/png;base64," + imagen.bytesImagen);
        });
};

 VisualizadorDeImagenes.prototype.mostrarRelojitoDeEspera = function () {
    this.ui.children().hide();
    this.progress_bar = $('<div style="min-height: 500px;">');
    this.progress_bar.progressbar({
        value: false
    });
    this.progress_bar.show();
    this.ui.append(this.progress_bar);
};

VisualizadorDeImagenes.prototype.ocultarRelojitoDeEspera = function () {
    this.progress_bar.remove();
    this.ui.children().show();
}; 
