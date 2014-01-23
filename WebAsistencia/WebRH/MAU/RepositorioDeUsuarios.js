var RepositorioDeUsuarios = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

RepositorioDeUsuarios.prototype.getUsuarioPorIdPersona = function (id_persona, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "GetUsuarioPorIdPersona",
        data: {
            id_persona: id_persona
        },
        success: function (usuario) {
            onSuccess(usuario);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};
