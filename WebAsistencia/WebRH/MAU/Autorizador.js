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

Autorizador.prototype.concederFuncionalidadPorAreaA = function (id_usuario, id_funcionalidad, id_area, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "ConcederFuncionalidadPorAreaA",
        data: {
            id_usuario: id_usuario,
            id_funcionalidad: id_funcionalidad,
            id_area: id_area
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

Autorizador.prototype.denegarFuncionalidadPorAreaA = function (id_usuario, id_funcionalidad, id_area, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "DenegarFuncionalidadPorAreaA",
        data: {
            id_usuario: id_usuario,
            id_funcionalidad: id_funcionalidad,
            id_area: id_area
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
        success: function (areas_json) {
            var lista_areas = [];
            for (var i = 0; i < areas_json.length; i++) {
                lista_areas.push({
                    id: areas_json[i].Id,
                    nombre: areas_json[i].Nombre,
                    alias: areas_json[i].Alias
                });
            }
            onSuccess(lista_areas);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};

Autorizador.prototype.asignarAreaAUnUsuario = function (id_usuario, id_area, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "AsignarAreaAUnUsuario",
        data: {
            id_usuario: id_usuario,
            id_area: id_area
        },
        success: function (areas) {
            onSuccess(areas);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};

Autorizador.prototype.desAsignarAreaAUnUsuario = function (id_usuario, id_area, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "DesAsignarAreaAUnUsuario",
        data: {
            id_usuario: id_usuario,
            id_area: id_area
        },
        success: function (areas) {
            onSuccess(areas);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};