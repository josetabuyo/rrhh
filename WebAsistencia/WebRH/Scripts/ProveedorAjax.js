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

ProveedorAjax.prototype.minimizarKeys = function (objeto) {
        if ($.isArray(objeto)) { return objeto; }
        _this = this;
        $.map(objeto, function (value, key) {
            objeto[_this.aMinuscula(key)] = value;
            delete objeto[key];
        });
        return objeto
    };

    ProveedorAjax.prototype.aMinuscula = function (valor) {
        if (typeof (valor) !== 'string') { return valor; }
        return valor.toLowerCase();
    }

    ProveedorAjax.prototype.jsonToLowCase = function (json) {

        if (typeof (json) !== 'object') { return json };
        var original = this.minimizarKeys(json);
        _this = this;
        $.map(original, function (value, key) {
            original[key] = _this.jsonToLowCase(original[key])
        });

        //    for (var i = 0; i < originales.Items.length; i++) {
        //        $.map(originales.Items[i], function (value, key) {
        //            originales.Items[i][key.toLowerCase()] = value;
        //            delete originales.Items[i][key];
        //        });
        //    }
        return original;

    }

ProveedorAjax.prototype.lowCase = function (J) {
    var json = JSON.parse(J);
    return this.jsonToLowCase(json);
};

ProveedorAjax.prototype.postearAUrl = function (datos_del_post) {
    var _this = this;

    $.ajax({ 
        url: this.raiz + "AjaxWS.asmx/" + datos_del_post.url,
        type: "POST",
        data: JSON.stringify(this.upCase(datos_del_post.data)),
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