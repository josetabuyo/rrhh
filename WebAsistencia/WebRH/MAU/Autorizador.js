var Autorizador = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

Autorizador.prototype.getUsuarioPorIdPersona = function (id_persona, onSuccess, onError) {
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
                alias: usuario_json.NombreDeUsuario
            });
            onSuccess(usuario);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};

Autorizador.prototype.getPermisosPara = function (usuario, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "GetPermisosPara",
        data: {
            usuario: usuario.nombre
        },
        success: function (permisos) {
            onSuccess(permisos);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};

Autorizador.prototype.concederPermisoA = function (usuario, funcionalidad, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "ConcederPermisoA",
        data: {
            usuario: usuario.nombre,
            funcionalidad: funcionalidad
        },
        success: function () {
            onSuccess();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};

Autorizador.prototype.denegarPermisoA = function (usuario, funcionalidad, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "DenegarPermisoA",
        data: {
            usuario: usuario.nombre,
            funcionalidad: funcionalidad
        },
        success: function () {
            onSuccess();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });

};
Autorizador.prototype.getFuncionalidades = function (onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "GetFuncionalidades",
        data: {
        },
        success: function (funcionalidades) {
            onSuccess(funcionalidades);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};

Autorizador.prototype.getMenu = function (nombre_menu, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "GetMenu",
        data: {
            nombre_menu: nombre_menu
        },
        success: function (menu) {
            onSuccess(menu);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};