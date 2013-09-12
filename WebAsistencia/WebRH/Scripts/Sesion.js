var Sesion= function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

Sesion.prototype.setAreaActual = function (id_area) {
    var _this = this;
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/SetAreaActualEnSesion",
        data: {
            id_area: id_area
        },
        success: function () {
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
};