var RepositorioDeUsuarios = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

RepositorioDeUsuarios.prototype.getUsuarioPorIdPersona = function (id_persona, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "GetUsuarioPorIdPersona",
        data: {
            id_persona: id_persona
        },
        success: function (usuario_json) {
            var usuario = new Usuario({
                id: usuario_json.Id,
                nombre: usuario_json.Nombre,
                apellido: usuario_json.Apellido,
                legajo: usuario_json.Legajo,
                documento: usuario_json.Documento,
                alias: usuario_json.Alias
            });
            onSuccess(usuario);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};
