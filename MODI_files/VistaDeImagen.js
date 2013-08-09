var VistaDeImagen = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeImagen.prototype.start = function () {
    this.id = this.o.idImagen;
    this.ui = $("#plantilla_ui_imagen").clone();
    this.img_thumbnail = this.ui.find('#img_thumbnail');
    this.img_estatica = this.ui.find('#img_estatica');

    var _this = this;
    this.ui.click(function () {
        if (!_this.onDrag) {
            new VisualizadorDeImagenes({
                idImagen: _this.id,
                servicioDeLegajos: _this.o.servicioDeLegajos
            });
        }
    });

    this.ui.draggable({ revert: "invalid",
        distance: 20,
        start: function (ui) {
            _this.o.servicioDeDragAndDrop.imagenOnDrag = _this;
            _this.onDrag = true;
        },
        stop: function (ui) {
            setTimeout(function () { _this.onDrag = false; }, 300);
        },
        helper: "clone"
    });

    this.img_thumbnail.hide();
    this.img_estatica.show();
    this.o.servicioDeLegajos.getThumbnailPorId(
        this.id,
        90,
        90,
        function (imagen) {
            _this.img_thumbnail.show();
            _this.img_estatica.hide();
            _this.img_thumbnail.attr("src", "data:image/png;base64," + imagen.bytesImagen)
        });
};

VistaDeImagen.prototype.dibujarEn = function (panel) {
    panel.append(this.ui);
};

VistaDeImagen.prototype.borrar = function () {
    this.ui.remove();
};