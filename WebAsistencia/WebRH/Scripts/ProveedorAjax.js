var ProveedorAjax = function (raiz) {
    var raiz_detectada = "";
    for (var i = 0; i < window.location.pathname.split('/').length - 3; i++) {
        raiz_detectada += "../";
    };
    this.raiz = raiz || raiz_detectada;
};

ProveedorAjax.prototype.upCase = function (J) {
    return J;
};

ProveedorAjax.prototype.lowCase = function (J) {
    var transformados = [];
    var originales = JSON.parse(J);
    for (var i = 0; i < originales.length; i++) {
        var ret = {};
        $.map(originales[i], function (value, key) {
            ret[key.toLowerCase()] = value;
        });
        transformados.push(ret);
    }
    return transformados;
};

ProveedorAjax.prototype.postearAUrl = function (datos_del_post) {
    var _this = this;

    $.ajax({ 
        url: this.raiz + "AjaxWS.asmx/" + datos_del_post.url,
        type: "POST",
        data: this.upCase(datos_del_post.data),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = _this.lowCase(respuestaJson.d);
            datos_del_post.success(respuesta);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            datos_del_post.error(errorThrown);
        }
    });
};