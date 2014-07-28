var Repositorio = {
    buscar: function (nombre_repositorio, criterio, onSuccess, onError) {
        if (!criterio) criterio = {};
        new ProveedorAjax().postearAUrl({ url: "BuscarEnRepositorio",
            data: {
                nombre_repositorio: nombre_repositorio,
                criterio: JSON.stringify(criterio)
            },
            success: function (objetos) {
                onSuccess(objetos);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                onerror(errorThrown);
            }
        });
    }
};