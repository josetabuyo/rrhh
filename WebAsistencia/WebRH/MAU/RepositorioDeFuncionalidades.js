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

RepositorioDeFuncionalidades.prototype.FuncionalidadesOtorgadasA = function (usuario, onSuccess, onError) {
    Backend.FuncionalidadesOtorgadasA(usuario.Id)
        .onSuccess(function (permisos) {
            onSuccess(permisos);    
        })
        .onError(function () {
            onError();
        });
//    this.proveedor_ajax.postearAUrl({ url: "FuncionalidadesOtorgadasA",
//        data: {
//            id_usuario: usuario.Id
//        },
//        success: function (permisos) {
//            onSuccess(permisos);
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            onerror(errorThrown);
//        }
//    });
};