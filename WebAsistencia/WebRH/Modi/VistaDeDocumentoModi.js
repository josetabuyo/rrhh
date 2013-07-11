var VistaDeDocumentoModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeDocumentoModi.prototype.start = function () {
    this.lbl_descripcion_en_RRHH = this.o.ui.find('#lbl_descripcion_en_RRHH');
    //this.lbl_jurisdiccion = this.o.ui.find('#lbl_jurisdiccion');
    //this.lbl_organismo = this.o.ui.find('#lbl_organismo');
    this.lbl_folio = this.o.ui.find('#lbl_folio');
    //this.lbl_fechaDesde = this.o.ui.find('#lbl_fechaDesde');
    //this.lbl_tabla = this.o.ui.find('#lbl_tabla');
    //this.lbl_id = this.o.ui.find('#lbl_id');
    this.panel_imagenes = this.o.ui.find('#panel_imagenes');

    this.lbl_descripcion_en_RRHH.text(this.o.documento.descripcionEnRRHH)
    //this.lbl_jurisdiccion.text(this.o.documento.jurisdiccion)
    //this.lbl_organismo.text(this.o.documento.organismo)
    this.lbl_folio.text(this.o.documento.folio)
    //this.lbl_fechaDesde.text(this.o.documento.fechaDesde)
    //this.lbl_tabla.text(this.o.documento.tabla)
    //this.lbl_id.text(this.o.documento.id)
    var _this = this;
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
                                   

