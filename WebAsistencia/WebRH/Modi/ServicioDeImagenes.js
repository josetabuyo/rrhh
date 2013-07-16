var ServicioDeImagenes = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

ServicioDeImagenes.prototype.getImagenSinAsignar = function (legajo, nombre_imagen, on_imagen_encontrada, on_imagen_no_encontrada, on_error_de_comunicaciones) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/GetImagenSinAsignar",
        data: {
            legajo: legajo,
            nombre_imagen: nombre_imagen
        },
        success: function (imagen) {
            on_imagen_encontrada(imagen);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            on_error_de_comunicaciones();
        }
    });
};

ServicioDeImagenes.prototype.asignarImagenADocumento = function (legajo, nombre_imagen, tabla, id_documento) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/AsignarImagenADocumento",
        data: {
            legajo: legajo,
            nombre_imagen: nombre_imagen,
            tabla: tabla,
            id_documento: id_documento
        },
        success: function (imagen) {
            console.log("imagen asignada con éxito");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("Error al asignar imagen");
        }
    });
};