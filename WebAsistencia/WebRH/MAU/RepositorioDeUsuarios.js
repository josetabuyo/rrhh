var RepositorioDeUsuarios = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

RepositorioDeUsuarios.prototype.getUsuarioPorIdPersona = function (id_persona, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "GetUsuarioPorIdPersona",
        data: {
            id_persona: id_persona
        },
        success: function (usuario) {
            if (usuario.EsNulo) onError("LA_PERSONA_NO_TIENE_USUARIO");
            else onSuccess(usuario);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onError(errorThrown);
        }
    });
};

RepositorioDeUsuarios.prototype.crearUsuarioPara = function (id_persona, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "CrearUsuarioPara",
        data: {
            id_persona: id_persona
        },
        success: function (usuario) {
            if (usuario.EsNulo) onError("LA_PERSONA_NO_TIENE_USUARIO");
            else onSuccess(usuario);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onError(errorThrown);
        }
    });
};

RepositorioDeUsuarios.prototype.resetearPassword = function (id_usuario, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "ResetearPassword",
        data: {
            id_usuario: id_usuario
        },
        success: function (respuesta) {
            onSuccess(respuesta.nueva_clave);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onError(errorThrown);
        }
    });
};
