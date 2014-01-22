var RepositorioDeFuncionalidades = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

RepositorioDeFuncionalidades.prototype.todasLasFuncionalidades = function (onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "TodasLasFuncionalidades",
        data: {},
        success: function (funcionalidades) {
            onSuccess(funcionalidades);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};

RepositorioDeFuncionalidades.prototype.funcionalidadesPara = function (usuario, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "FuncionalidadesPara",
        data: {
            id_usuario: usuario.id
        },
        success: function (permisos) {
            onSuccess(permisos);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};