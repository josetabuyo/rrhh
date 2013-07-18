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
            //console.log(imagenOnDrag);
            $(ui).remove();
            var vista_imagen = new VistaDeImagenModi({
                ui: _this.o.plantilla_vista_imagen.clone(),
                imagen: imagenOnDrag.imagen
            });
            vista_imagen.dibujarEn(_this.panel_imagenes);
            imagenOnDrag.borrar();
            _this.o.servicioDeImagenes.asignarImagenADocumento(_this.o.numero_legajo,
                                                                imagenOnDrag.imagen.nombre,
                                                                _this.o.documento.tabla,
                                                                _this.o.documento.id);
        }
    });
    _this.mostrarRelojitoDeEspera();
    _this.o.servicioDeImagenes.getThumbnailsDeImagenesAsignadasAlDocumento(
        _this.o.documento.tabla,
        _this.o.documento.id,
        function (imagenes) {
            _this.ocultarRelojitoDeEspera();
            for (var i = 0; i < imagenes.length; i++) {
                var vista_imagen = new VistaDeImagenModi({
                    ui: _this.o.plantilla_vista_imagen.clone(),
                    imagen: imagenes[i]
                });
                vista_imagen.dibujarEn(_this.panel_imagenes);
            }
        });
};

VistaDeDocumentoModi.prototype.dibujarEn = function (panel) {
    panel.append(this.o.ui);
};

VistaDeDocumentoModi.prototype.mostrarRelojitoDeEspera = function () {
    this.progress_bar = $('<div style="min-height: 100%;">');
    var progress_label = $("<div>");
    progress_label.css("float", "left");
    progress_label.css("margin-left", "40%");
    progress_label.css("margin-top", "37px");
    progress_label.css("font-weight", "bold");

    progress_label.text("Buscando imagenes...");

    this.progress_bar.append(progress_label);

    this.progress_bar.progressbar({
        value: false
    });
    this.progress_bar.progressbar("option", "value", false);
    this.progress_bar.show();
    this.panel_imagenes.append(this.progress_bar);
};

VistaDeDocumentoModi.prototype.ocultarRelojitoDeEspera = function () {
    this.progress_bar.remove();
};  
