var VistaDeImagenModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeImagenModi.prototype.start = function () {
    this.mostrarRelojitoDeEspera();
    this.id = this.o.id_imagen;
    this.img_thumbnail = this.o.ui.find('#img_thumbnail');

    var _this = this;
    this.o.ui.click(function () {
        if (imagenOnDrag === undefined) {
            _this.o.servicioDeImagenes.getImagenPorId(
                _this.id,
                function (imagen) {
                    _this.o.visualizadorDeImagenes.mostrarImagen(imagen);
                },
                function () {
                });
        }
    });

    this.o.ui.draggable({ revert: "invalid",
        start: function (ui) {
            imagenOnDrag = _this;
        },
        stop: function (ui) {
            setTimeout(function () { imagenOnDrag = undefined; }, 300);
        },
        helper: "clone"
    });

    this.o.servicioDeImagenes.getThumbnailPorId(
        this.id,
        90,
        90,
        function (imagen) {
            _this.ocultarRelojitoDeEspera();
            _this.img_thumbnail.attr("src", "data:image/png;base64," + imagen.bytesImagen)
        });
};

VistaDeImagenModi.prototype.dibujarEn = function (panel) {
    panel.append(this.o.ui);
};

VistaDeImagenModi.prototype.borrar = function () {
    this.o.ui.remove();
};

VistaDeImagenModi.prototype.onClick = function () {
};

VistaDeImagenModi.prototype.id = {};

VistaDeImagenModi.prototype.mostrarRelojitoDeEspera = function () {
    this.progress_bar = $('<div style="min-height: 90px;">');
    this.progress_bar.progressbar({
        value: false
    });
    this.progress_bar.progressbar("option", "value", false);
    this.progress_bar.show();
    this.o.ui.append(this.progress_bar);
};

VistaDeImagenModi.prototype.ocultarRelojitoDeEspera = function () {
    this.progress_bar.remove();
}; 