var RepositorioDeNacionalidades = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

RepositorioDeNacionalidades.prototype.getNacionalidades = function (onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "GetNacionalidades",
        data: {
        },
        success: function (nacionalidades) {
            onSuccess(nacionalidades);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};