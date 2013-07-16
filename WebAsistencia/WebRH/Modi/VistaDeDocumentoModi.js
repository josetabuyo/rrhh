var VistaDeDocumentoModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeDocumentoModi.prototype.start = function () {
    this.lbl_descripcion_en_RRHH = this.o.ui.find('#lbl_descripcion_en_RRHH');
    this.lbl_folio = this.o.ui.find('#lbl_folio');
    this.panel_imagenes = this.o.ui.find('#panel_imagenes');
    this.lbl_descripcion_en_RRHH.text(this.o.documento.descripcionEnRRHH);
    this.lbl_folio.text(this.o.documento.folio)

    var _this = this;
    this.panel_imagenes.droppable({
        accept: ".imagen_miniatura",
        hoverClass: "ui-state-active",
        drop: function (event, ui) {
            console.log(imagenOnDrag);
            var vista_imagen = new VistaDeImagenModi({
                ui: _this.o.plantilla_vista_imagen.clone(),
                imagen: imagenOnDrag.imagen
            });
            vista_imagen.dibujarEn(_this.panel_imagenes);
            imagenOnDrag.borrar();
            _this.o.servicioDeImagenes.asignarImagenADocumento( _this.o.numero_legajo, 
                                                                imagenOnDrag.imagen.nombre, 
                                                                _this.o.documento.tabla,
                                                                _this.o.documento.id);
        }
    });

    for (var i = 0; i < this.o.documento.thumbnailsImagenesAsignadas.length; i++) {
        var vista_imagen = new VistaDeImagenModi({
            ui: this.o.plantilla_vista_imagen.clone(),
            imagen: this.o.documento.thumbnailsImagenesAsignadas[i]
        });
        vista_imagen.dibujarEn(this.panel_imagenes);
    }
};

VistaDeDocumentoModi.prototype.dibujarEn = function (panel) {
    panel.append(this.o.ui);
};
                                   

