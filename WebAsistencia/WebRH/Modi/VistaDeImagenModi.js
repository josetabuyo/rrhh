var VistaDeImagenModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeImagenModi.prototype.start = function () {
    this.lbl_nombre = this.o.ui.find('#lbl_nombre');
    this.img_thumbnail = this.o.ui.find('#img_thumbnail');

    this.lbl_nombre.text(this.o.imagen.nombre)
    this.img_thumbnail.attr("src", "data:image/png;base64," + this.o.imagen.bytesImagen);

    this.onclick = function () { };

    var _this = this;
    this.o.ui.click(function () {
        _this.onClick(_this.o.imagen);
    });
};

VistaDeImagenModi.prototype.dibujarEn = function (panel) {
    panel.append(this.o.ui);
};
                                   

