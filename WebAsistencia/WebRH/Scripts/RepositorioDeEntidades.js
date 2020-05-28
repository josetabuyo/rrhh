var RepositorioDeEntidades = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

RepositorioDeEntidades.prototype.buscarEntidades = function (criterio, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({
        url: "BuscarEntidades",
        data: {
            criterio: criterio
        },
        success: function (areas_json) {
            var lista_areas = [];
            for (var i = 0; i < areas_json.length; i++) {
                lista_areas.push({
                    id: areas_json[i].Id, 
                    nombre: areas_json[i].Nombre 
                });
            }
            onSuccess(lista_areas);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};
