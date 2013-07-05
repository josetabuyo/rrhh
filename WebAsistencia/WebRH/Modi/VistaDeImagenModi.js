var VistaDeImagenModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeImagenModi.prototype.start = function () {
    this.lbl_nombre = this.o.ui.find('#lbl_nombre');
    this.img_thumbnail = this.o.ui.find('#img_thumbnail');

    this.lbl_nombre.text(this.o.imagen.nombre)
    this.img_thumbnail.attr("src", "data:image/png;base64," + this.o.imagen.bytesImagen);
};

VistaDeImagenModi.prototype.dibujarEn = function (panel) {
    panel.append(this.o.ui);
};
                                   

