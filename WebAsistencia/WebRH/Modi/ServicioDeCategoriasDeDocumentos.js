var ServicioDeCategoriasDeDocumentos= function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

ServicioDeCategoriasDeDocumentos.prototype.categoriasDocumentosSICOI = function (on_categorias_encontradas) {
    var _this = this;
    this.proveedor_ajax.postearAUrl({ url: "CategoriasDocumentosSICOI",
        data: {
    },
    success: function (categorias) {
        _this.categorias_cacheadas = categorias;
        _this.categoriasDocumentosSICOI = _this.categoriasDocumentosSICOI_cacheadas;
        _this.categoriasDocumentosSICOI_cacheadas(on_categorias_encontradas);
    },
    error: function (XMLHttpRequest, textStatus, errorThrown) {
    }
});
};

ServicioDeCategoriasDeDocumentos.prototype.categoriasDocumentosSICOI_cacheadas = function (on_categorias_encontradas) {
    on_categorias_encontradas(this.categorias_cacheadas);
};