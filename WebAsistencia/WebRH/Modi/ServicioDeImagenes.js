var ServicioDeImagenes = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

ServicioDeImagenes.prototype.getThumbnailPorId = function (id_imagen, alto, ancho, on_imagen_encontrada) {
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

ServicioDeImagenes.prototype.getImagenPorId = function (id_imagen, on_imagen_encontrada) {
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

ServicioDeImagenes.prototype.asignarImagenADocumento = function (id_imagen, tabla, id_documento) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/AsignarImagenADocumento",
        data: {
            id_imagen: id_imagen,
            tabla: tabla,
            id_documento: id_documento
        },
        success: function (imagen) {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};