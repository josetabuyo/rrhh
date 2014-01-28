var Autorizador = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

Autorizador.prototype.concederFuncionalidadA = function (id_usuario, id_funcionalidad, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "ConcederFuncionalidadA",
        data: {
            id_usuario: id_usuario,
            id_funcionalidad: id_funcionalidad
        },
        success: function () {
            onSuccess();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};

Autorizador.prototype.denegarFuncionalidadA = function (id_usuario, id_funcionalidad, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "DenegarFuncionalidadA",
        data: {
            id_usuario: id_usuario,
            id_funcionalidad: id_funcionalidad
        },
        success: function () {
            onSuccess();
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

Autorizador.prototype.areasAdministradasPor = function (id_usuario, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "AreasAdministradasPor",
        data: {
            id_usuario: id_usuario
        },
        success: function (areas) {
            onSuccess(areas);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};