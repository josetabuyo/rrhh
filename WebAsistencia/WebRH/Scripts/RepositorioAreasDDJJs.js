var RepositorioAreasDDJJs = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

RepositorioAreasDDJJs.prototype.buscarAreasDDJJ = function (usuario, mes, onSuccess, onError) {
	this.proveedor_ajax.postearAUrl({ url: "BuscarAreasConDDJJs",
        data: {
            usuario: usuario,
			mes: mes
        },
        success:onSuccess,
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onError(errorThrown);
        }
    });
}