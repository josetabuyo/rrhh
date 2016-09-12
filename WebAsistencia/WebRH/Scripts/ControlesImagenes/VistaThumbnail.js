var VistaThumbnail = function (opt) {
    var _this = this;
    _.extend(this, opt);
    this.contenedor.load("../Scripts/ControlesImagenes/VistaThumbnail.html", function () {
        _this.img_thumbnail = _this.contenedor.find('#img_thumbnail');
        _this.img_estatica = _this.contenedor.find('#img_estatica');

        _this.contenedor.click(function () {
            new VisualizadorDeImagenes({ imagen: _this });
        });

        _this.img_thumbnail.hide();
        _this.img_estatica.show();

        _this.getImagen();
    });    
};

VistaThumbnail.prototype.getImagen = function () {
    var _this = this;
    Backend.GetThumbnail(this.id, this.contenedor.height(), this.contenedor.width()).onSuccess(function (imagen) {
        if (imagen.reintentar) {
            setTimeout(function () { _this.getImagen(); }, 500);
            return;
        }
        _this.img_thumbnail.show();
        _this.img_estatica.hide();
        _this.img_thumbnail.attr("src", "data:image/png;base64," + imagen.bytes)
    });
};