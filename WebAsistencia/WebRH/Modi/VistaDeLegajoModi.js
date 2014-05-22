var VistaDeLegajoModi = function (opt) {
    this.o = opt;
    this.start();
};

VistaDeLegajoModi.prototype.start = function () {
    this.o.ui.css('opacity', '0');
    this.lbl_resumen_datos_personales = this.o.ui.find('#lbl_resumen_datos_personales');
    this.panel_documentos = this.o.ui.find('#panel_documentos');
    this.div_imagenes_no_asignadas = this.o.ui.find('#panel_imagenes_no_asignadas');
    this.subidorDeImagenes = document.getElementById("subir_imagenes");
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

    this.subidorDeImagenes.addEventListener("change", function () {
        _this.colaDeSubida = _this.subidorDeImagenes.files;
        _this.indiceFileSubiendo = 0;

        _this.subirProximaImagen();
    }, false);

    this.btn_subir_imagenes.click(function () {
        $(_this.subidorDeImagenes).click();
    });
};

VistaDeLegajoModi.prototype.subirProximaImagen = function () {
    var _this = this;

    var file = _this.colaDeSubida[_this.indiceFileSubiendo];
    url = window.URL || window.webkitURL;
    src = url.createObjectURL(file);
    var canvas = document.createElement('CANVAS');
    var ctx = canvas.getContext('2d');
    var img = new Image;
    img.crossOrigin = 'Anonymous';
    img.src = src;
    img.onload = function () {
        canvas.height = img.height;
        canvas.width = img.width;
        ctx.drawImage(img, 0, 0);
        var bytes_imagen = canvas.toDataURL('image/jpg');
        bytes_imagen = bytes_imagen.replace(/^data:image\/(png|jpg);base64,/, "")
        _this.o.servicioDeLegajos.agregarImagenSinAsignarAUnLegajo(_this.legajo.idInterna,
                "un_nombre",
                bytes_imagen,
                function () {
                    console.log("imagen subida ok");
                    _this.indiceFileSubiendo += 1;
                    if (_this.indiceFileSubiendo >= _this.colaDeSubida.length) return;
                    _this.subirProximaImagen();
                });
    };
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
