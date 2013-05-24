var WebService = {
    ultimoRequest :{abort : function(){}},
    getDocumentosFiltrados : function(filtros, onSuccess){
        this.ultimoRequest.abort();
        this.ultimoRequest = $.ajax({
                url: "../AjaxWS.asmx/GetDocumentosFiltrados",
                type: "POST",
                data: "{'filtros' : '" + JSON.stringify(filtros) + "'}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (respuestaJson) {
                    onSuccess(JSON.parse(respuestaJson.d));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
    }
};