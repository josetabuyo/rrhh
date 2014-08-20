var VistaDeFolioModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeFolioModi.prototype.start = function () {
    var _this = this;
    this.id = this.o.idImagen;
    this.ui = $("#plantilla_ui_folio").clone();
    this.ui.attr("id", "folio_" + this.o.folio.numero_folio.toString())
    this.lbl_folio = this.ui.find("#lbl_folio");
    this.lbl_folio.text("Folio " + this.o.folio.numero_folio.toString());
    for (var i = 0; i < this.o.folio.imagenes.length; i++) {
        var vista_imagen = new VistaDeImagen({
            idImagen: _this.o.folio.imagenes[i].id,
            servicioDeDragAndDrop: _this.o.servicioDeDragAndDrop,
            servicioDeLegajos: _this.o.servicioDeLegajos,
            numeroDeFolio: _this.o.folio.numero_folio
        });
        vista_imagen.dibujarEn(_this.ui);
    }

    this.ui.droppable({
        accept: ".imagen_miniatura",
        hoverClass: "folio_drop_hover",
        drop: function (event, ui) {
//            if (_this.ui.find(".imagen_miniatura").length != 0) {
//                new Alerta("Ya hay una imagen asignada al folio elegido");
//                return;
//            }
            _this.o.servicioDeLegajos.asignarImagenAFolioDeLegajo(
                _this.o.servicioDeDragAndDrop.imagenOnDrag.id,
                _this.o.folio.numero_folio,
                function () {
                    _this.o.servicioDeDragAndDrop.imagenOnDrag.nro_folio = _this.o.folio.numero_folio;
                    _this.o.servicioDeDragAndDrop.imagenOnDrag.dibujarEn(_this.ui);
                });
            return true;
        }
    });

    this.ui.click(function () {
        if (_this.ui.find(".imagen_miniatura").length != 0) return;
        var subidor = new SubidorDeImagenes();
        subidor.subirImagen(function (bytes_imagen) {
            _this.o.servicioDeLegajos.agregarImagenAUnFolioDeUnLegajo(_this.o.numero_legajo,
                    _this.o.folio.numero_folio,
                    "un_nombre",
                    bytes_imagen,
                    function (id_imagen) {
                        //_this.o.folio.imagen.id = id_imagen;
                        var vista_imagen = new VistaDeImagen({
                            idImagen: id_imagen,
                            servicioDeDragAndDrop: _this.o.servicioDeDragAndDrop,
                            servicioDeLegajos: _this.o.servicioDeLegajos,
                            numeroDeFolio: _this.o.folio.numero_folio
                        });
                        vista_imagen.dibujarEn(_this.ui);
                    });
        });
    });
};

VistaDeFolioModi.prototype.dibujarEn = function (panel) {
    panel.append(this.ui);
};