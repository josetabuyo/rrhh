var Autorizador = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
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