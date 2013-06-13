var VistaDeImagenModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeImagenModi.prototype.start = function () {
    this.lbl_nombre = this.o.ui.find('#lbl_nombre');

    this.lbl_nombre.text(this.o.imagen.nombre)
};

VistaDeImagenModi.prototype.dibujarEn = function (panel) {
    panel.append(this.o.ui);
};
                                   

