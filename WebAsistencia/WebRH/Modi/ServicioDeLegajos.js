var ServicioDeLegajos = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};



ServicioDeLegajos.prototype.getLegajo = function (numero_documento, on_legajo_encontrado, on_legajo_no_encontrado, on_error_de_comunicaciones) {
    var diccionario = {};
    diccionario['OK'] = on_legajo_encontrado;
    diccionario['LEGAJO_NO_ENCONTRADO'] = on_legajo_no_encontrado;

    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/GetLegajoParaDigitalizacion",
        data: { numero_documento: numero_documento },
        success: function (respuestaAPedidoDeLegajo) {
            diccionario[respuestaAPedidoDeLegajo.codigoDeResultado](respuestaAPedidoDeLegajo);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            on_error_de_comunicaciones();
        }
    });
};