var ServicioDeDigitalizacionDeLegajos = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

ServicioDeDigitalizacionDeLegajos.prototype.buscarLegajosParaDigitalizacion = function (criterio, on_legajo_encontrado, on_legajo_no_encontrado, on_error_de_comunicaciones) {
    var diccionario = {};
    diccionario['OK'] = on_legajo_encontrado;
    diccionario['LEGAJO_NO_ENCONTRADO'] = on_legajo_no_encontrado;

    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/BuscarLegajosParaDigitalizacion",
        data: { criterio: criterio },
        success: function (respuestaAPedidoDeLegajo) {
            diccionario[respuestaAPedidoDeLegajo.codigoDeResultado](respuestaAPedidoDeLegajo);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            on_error_de_comunicaciones();
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.asignarCategoriaADocumento = function (id_categoria, tabla, id_documento) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/AsignarCategoriaADocumento",
        data: {
            id_categoria: id_categoria,
            tabla: tabla,
            id_documento: id_documento
        },
        success: function () {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.getThumbnailPorId = function (id_imagen, alto, ancho, on_imagen_encontrada) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/GetThumbnailPorId",
        data: {
            id_imagen: id_imagen,
            alto: alto,
            ancho: ancho
        },
        success: function (imagen) {
            on_imagen_encontrada(imagen);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.getImagenPorId = function (id_imagen, on_imagen_encontrada) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/GetImagenPorId",
        data: {
            id_imagen: id_imagen
        },
        success: function (imagen) {
            on_imagen_encontrada(imagen);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.asignarImagenADocumento = function (id_imagen, tabla, id_documento, orden) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/AsignarImagenADocumento",
        data: {
            id_imagen: id_imagen,
            tabla: tabla,
            id_documento: id_documento,
            orden: orden
        },
        success: function () {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.desAsignarImagen = function (id_imagen) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/DesAsignarImagen",
        data: {
            id_imagen: id_imagen
        },
        success: function (imagen) {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};