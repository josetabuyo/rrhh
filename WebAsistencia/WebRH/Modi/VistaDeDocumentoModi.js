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

    this.cmb_categorias = this.o.ui.find('#cmb_categoria select');
    this.o.servicioDeCategorias.categoriasDocumentosSICOI(function (categorias) {
        for (var i = 0; i < categorias.length; i++) {
            var o_categoria = $('<option id="' + categorias[i].Id + '">');
            o_categoria.text(categorias[i].descripcion);
            _this.cmb_categorias.append(o_categoria);
        }
        _this.cmb_categorias.find('#' + _this.o.documento.idCategoria).attr('selected', 'selected');
        console.log('categoria del documento:' + _this.o.documento.id + ' -> ' + _this.o.documento.idCategoria);
    });

    this.cmb_categorias.change(function () {
        _this.o.servicioDeLegajos.asignarCategoriaADocumento(_this.cmb_categorias.find(":selected").attr('id'),
                                                                _this.o.documento.tabla,
                                                                _this.o.documento.id);
    });

};

VistaDeDocumentoModi.prototype.dibujarEn = function (panel) {
    panel.append(this.o.ui);
}; 
