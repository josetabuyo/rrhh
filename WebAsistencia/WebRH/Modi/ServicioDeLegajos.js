var ServicioDeLegajos = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};



ServicioDeLegajos.prototype.buscarLegajosParaDigitalizacion = function (criterio, on_legajo_encontrado, on_legajo_no_encontrado, on_error_de_comunicaciones) {
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

ServicioDeLegajos.prototype.asignarCategoriaADocumento = function (id_categoria, tabla, id_documento) {
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