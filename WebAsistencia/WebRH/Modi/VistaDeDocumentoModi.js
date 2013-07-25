var VistaDeDocumentoModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeDocumentoModi.prototype.start = function () {
    this.lbl_descripcion_en_RRHH = this.o.ui.find('#lbl_descripcion_en_RRHH');
    this.lbl_folio = this.o.ui.find('#lbl_folio');
    this.div_imagenes = this.o.ui.find('#panel_imagenes');
    this.lbl_descripcion_en_RRHH.text(this.o.documento.descripcionEnRRHH);
    this.lbl_folio.text(this.o.documento.folio)

    var _this = this;
    this.panel_imagenes = new PanelDeImagenes({
        servicioDeImagenes: this.o.servicioDeImagenes,
        servicioDeDragAndDrop: this.o.servicioDeDragAndDrop,
        mensajeParaCuandoEstaVacio: 'Este documento no tiene imágenes asignadas',
        onImagenDropeada: function (imagen) {
            _this.o.servicioDeImagenes.asignarImagenADocumento(imagen.id,
                                                                _this.o.documento.tabla,
                                                                _this.o.documento.id);
        }
    });
    this.panel_imagenes.cargarImagenes(this.o.documento.idImagenesAsignadas);
    this.panel_imagenes.dibujarEn(this.div_imagenes);
};

VistaDeDocumentoModi.prototype.dibujarEn = function (panel) {
    panel.append(this.o.ui);
}; 
