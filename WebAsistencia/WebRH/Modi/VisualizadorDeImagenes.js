var VisualizadorDeImagenes = function (opt) {
    this.o = opt;
    this.start();
};

VisualizadorDeImagenes.prototype.start = function () {
    this.ui = $("#plantilla_ui_visualizador_imagen").clone();
    this.panelImagen = this.ui.find('#imagen');
    this.panelContenedorImagen = this.ui.find('#contenedor_imagen');
    this.txtFolio = this.ui.find('#txt_folio');
    this.txtPagina = this.ui.find('#txt_pagina');
    var _this = this;

    this.txtFolio.val(this.o.imagen.nro_folio);
    this.txtFolio.keypress(function (event) {
        if (event.which == 13) {
            _this.ui.dialog("close");
            _this.o.onNumeroDeFolioIngresado(_this.txtFolio.val());
        }
    });

    this.txtPagina.val(this.o.imagen.orden);

    this.ui.dialog({
        title: "Cargando Imagen",
        height: 580,
        width: 1020,
        modal: true,
        show: {
            effect: "fade",
            duration: 500
        }
    });
    this.panelContenedorImagen.addClass('panel_con_estatica');
    this.o.servicioDeLegajos.getThumbnailPorId(
        this.o.imagen.id,
        0,
        980,
        function (imagen) {
            _this.panelContenedorImagen.removeClass('panel_con_estatica');
            _this.ui.dialog("option", "title", imagen.nombre);
            _this.panelImagen.attr("src", "data:image/png;base64," + imagen.bytesImagen);
        });
};