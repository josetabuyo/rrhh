var ServicioDeSeguridad = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

ServicioDeSeguridad.prototype.getPermisosPara = function (usuario, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/GetPermisosPara",
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

ServicioDeSeguridad.prototype.concederPermisoA = function (usuario, funcionalidad, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/ConcederPermisoA",
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

ServicioDeSeguridad.prototype.denegarPermisoA = function (usuario, funcionalidad, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/DenegarPermisoA",
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
ServicioDeSeguridad.prototype.getFuncionalidades = function (onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/GetFuncionalidades",
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