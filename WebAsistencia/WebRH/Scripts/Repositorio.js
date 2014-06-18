var Repositorio = {
    get: function (nombre_repositorio, onSuccess, onError) {
        new ProveedorAjax().postearAUrl({ url: "GetTodoDeRepositorio",
            data: {
                nombre_repositorio: nombre_repositorio
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