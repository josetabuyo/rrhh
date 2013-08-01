var VistaDeImagen = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeImagen.prototype.start = function () {
    this.id = this.o.idImagen;
    this.ui = $("#plantilla_ui_imagen").clone();
    this.img_thumbnail = this.ui.find('#img_thumbnail');
    this.relojito = this.ui.find('#relojito_de_espera');

    this.relojito.progressbar({
        value: false
    });

    this.relojito.show();

    var _this = this;
    this.ui.click(function () {
        if (!_this.onDrag) {
            new VisualizadorDeImagenes({
                idImagen: _this.id ,
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

    this.o.servicioDeLegajos.getThumbnailPorId(
        this.id,
        90,
        90,
        function (imagen) {
            _this.relojito.hide();
            _this.img_thumbnail.attr("src", "data:image/png;base64," + imagen.bytesImagen)
        });
};

VistaDeImagen.prototype.dibujarEn = function (panel) {
    panel.append(this.ui);
};

VistaDeImagen.prototype.borrar = function () {
    this.ui.remove();
};