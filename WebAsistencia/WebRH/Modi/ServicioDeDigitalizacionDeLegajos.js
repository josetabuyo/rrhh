var ServicioDeDigitalizacionDeLegajos = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

ServicioDeDigitalizacionDeLegajos.prototype.buscarLegajosParaDigitalizacion = function (criterio, on_legajo_encontrado, on_legajo_no_encontrado, on_error_de_comunicaciones) {
    var diccionario = {};
    diccionario['OK'] = on_legajo_encontrado;
    diccionario['LEGAJO_NO_ENCONTRADO'] = on_legajo_no_encontrado;

    this.proveedor_ajax.postearAUrl({ url: "BuscarLegajosParaDigitalizacion",
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
    this.proveedor_ajax.postearAUrl({ url: "AsignarCategoriaADocumento",
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
    this.proveedor_ajax.postearAUrl({ url: "GetThumbnailPorId",
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
    this.proveedor_ajax.postearAUrl({ url: "GetImagenPorId",
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

ServicioDeDigitalizacionDeLegajos.prototype.asignarImagenAFolioDeLegajo = function (id_imagen, nro_folio, onSuccess) {
    this.proveedor_ajax.postearAUrl({ url: "AsignarImagenAFolioDeLegajo",
        data: {
            id_imagen: id_imagen,
            nro_folio: nro_folio
        },
        success: function () {
            onSuccess();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.desAsignarImagen = function (id_imagen, onSuccess) {
    this.proveedor_ajax.postearAUrl({ url: "DesAsignarImagen",
        data: {
            id_imagen: id_imagen
        },
        success: function (imagen) {
            onSuccess();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};

ServicioDeDigitalizacionDeLegajos.prototype.agregarImagenSinAsignarAUnLegajo = function (id_interna, nombre_imagen, bytes_imagen, onSuccess) {
    this.proveedor_ajax.postearAUrl({ url: "AgregarImagenSinAsignarAUnLegajo",
        data: {
            id_interna: id_interna,
            nombre_imagen: nombre_imagen,
            bytes_imagen: bytes_imagen
        },
        success: function () {
            onSuccess();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};