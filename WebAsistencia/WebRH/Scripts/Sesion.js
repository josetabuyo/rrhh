var Sesion= function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

Sesion.prototype.setAreaActual = function (id_area, on_success) {
    var _this = this;
    this.proveedor_ajax.postearAUrl({ url: "SetAreaActualEnSesion",
        data: {
            id_area: id_area
        },
        success: function () {
            on_success();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};

Sesion.prototype.setAreaActualEnSesionNuevo = function (area, on_success) {
    var _this = this;
    this.proveedor_ajax.postearAUrl({
        url: "SetAreaActualEnSesionNuevo",
        data: {
            areaJSON: JSON.stringify(area)
        },
        success: function () {
            on_success();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};