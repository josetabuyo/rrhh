var VistaDeLegajoModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeLegajoModi.prototype.start = function () {
    this.o.ui.css('opacity', '0');
    this.lbl_resumen_datos_personales = this.o.ui.find('#lbl_resumen_datos_personales');
    this.panel_documentos = this.o.ui.find('#panel_documentos');
    this.div_imagenes_no_asignadas = this.o.ui.find('#panel_imagenes_no_asignadas');
    this.btn_subir_imagenes = $("#btn_subir_imagenes");

    this.vistasDeDocumentos = [];
    this.servicioDeDragAndDrop = new ServicioDeDragAndDrop();
    var _this = this;
    this.panel_imagenes_no_asignadas = new PanelDeImagenes({
        servicioDeLegajos: this.o.servicioDeLegajos,
        servicioDeDragAndDrop: this.servicioDeDragAndDrop,
        mensajeParaCuandoEstaVacio: 'Este legajo no tiene imágenes sin asignar',
        onImagenDropeada: function (imagen) {
            _this.o.servicioDeLegajos.desAsignarImagen(imagen.id,
                                                        function () {
                                                            imagen.nro_folio = "";
                                                            _this.panel_imagenes_no_asignadas.agregarVistaImagen(imagen);
                                                        });
        }
    });
    this.panel_imagenes_no_asignadas.dibujarEn(this.div_imagenes_no_asignadas);

    this.btn_nueva_busqueda = this.o.ui.find('#btn_nueva_busqueda');
    this.btn_nueva_busqueda.click(function () {
        _this.o.ui.css('opacity', '0');
        _this.buscadorDeLegajos.mostrarModal();
    });

    this.btn_subir_imagenes.click(function () {
        var subidor = new SubidorDeImagenes();
        subidor.subirImagenes(function (bytes_imagen) {
            _this.o.servicioDeLegajos.agregarImagenSinAsignarAUnLegajo(_this.legajo.idInterna,
                "un_nombre",
                bytes_imagen,
                function (id_imagen) {
                    var vista_imagen = new VistaDeImagen({
                        idImagen: id_imagen,
                        servicioDeDragAndDrop: _this.servicioDeDragAndDrop,
                        servicioDeLegajos: _this.o.servicioDeLegajos
                    });
                    _this.panel_imagenes_no_asignadas.agregarVistaImagen(vista_imagen);
                });
        });
    });
};

VistaDeLegajoModi.prototype.mostrandoVisualizadorDeImagenes = function () {
    return this.visualizadorDeImagenes.visible;
};

VistaDeLegajoModi.prototype.mostrarLegajo = function (legajo) {
    this.lbl_resumen_datos_personales.text(legajo.apellido + ", " + legajo.nombre + " (" + legajo.numeroDeDocumento + ") Id Interna:" + legajo.idInterna);
    this.vistasDeDocumentos = [];
    this.panel_documentos.empty();
    this.legajo = legajo;
    var _this = this;
    for (var i = 0; i < legajo.documentos.length; i++) {
        var vista_documento = new VistaDeDocumentoModi({
            ui: this.o.plantilla_vista_documento.clone(),
            documento: legajo.documentos[i],
            plantilla_vista_imagen: this.o.plantilla_vista_imagen,
            servicioDeLegajos: this.o.servicioDeLegajos,
            servicioDeDragAndDrop: this.servicioDeDragAndDrop,
            visualizadorDeImagenes: this.visualizadorDeImagenes,
            numero_legajo: legajo.idInterna,
            servicioDeCategorias: this.o.servicioDeCategorias
        });
        this.vistasDeDocumentos.push(vista_documento);
        vista_documento.dibujarEn(this.panel_documentos);
    }

    this.panel_imagenes_no_asignadas.cargarImagenes(legajo.imagenesSinAsignar);
    this.o.ui.css('opacity', '1');
};
