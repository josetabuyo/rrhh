var VistaThumbnail = function (opt) {
    _.extend(this, opt);
    this.ui = $("<div>");
    this.ui.load("../Scripts/ControlesImagenes/VistaThumbnail.html");

    this.img_thumbnail = this.ui.find('#img_thumbnail');
    this.img_estatica = this.ui.find('#img_estatica');

    var _this = this;
    this.ui.click(function () {
        new VisualizadorDeImagenes({ imagen: _this });
    });

    this.img_thumbnail.hide();
    this.img_estatica.show();

    this.getImagen();
};

VistaThumbnail.prototype.getImagen = function () {
    var _this = this;
    Backend.GetThumbnail(this.id, this.alto, this.ancho).onSuccess(function (imagen) {
        if (imagen.reintentar) {
            setTimeout(function () { _this.getImagen(); }, 100);
            return;
        }
        _this.img_thumbnail.show();
        _this.img_estatica.hide();
        _this.img_thumbnail.attr("src", "data:image/png;base64," + imagen.bytes)
    });
};

VistaThumbnail.prototype.dibujarEn = function (panel) {
    panel.append(this.ui);
};

VistaThumbnail.prototype.borrar = function () {
    this.ui.remove();
};