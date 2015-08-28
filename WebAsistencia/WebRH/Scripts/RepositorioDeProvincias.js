var RepositorioDeProvincias = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

RepositorioDeProvincias.prototype.getProvincias = function (onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "GetProvincias",
        data: {
        },
        success: function (provincias) {
            onSuccess(provincias);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};