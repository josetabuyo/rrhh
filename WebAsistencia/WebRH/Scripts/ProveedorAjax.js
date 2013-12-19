var ProveedorAjax = function (raiz) {
    this.raiz = raiz||"";
};

ProveedorAjax.prototype.postearAUrl = function (datos_del_post) {
    $.ajax({
        url: this.raiz + "AjaxWS.asmx/" + datos_del_post.url,
        type: "POST",
        data: JSON.stringify(datos_del_post.data),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
            datos_del_post.success(respuesta);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            datos_del_post.error(errorThrown);
        }
    });  
};