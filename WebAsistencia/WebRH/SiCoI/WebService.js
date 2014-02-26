var WebService = {
    ultimoRequest: { abort: function () { } },
    getDocumentosFiltrados: function (filtros, onSuccess) {
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
    },
    transicionarDocumento: function (documento, onSuccess) {
        $.ajax({
            url: "../AjaxWS.asmx/TransicionarDocumento",
            type: "POST",
            data: JSON.stringify({
                id_documento: documento.id,
                id_area_origen: documento.areaActual.id,
                id_area_destino: documento.areaDestino.id
            }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                if (respuesta.tipoDeRespuesta == "envioDeDocumento.ok") {
                    onSuccess(respuesta.documento);
                }
                if (respuesta.tipoDeRespuesta == "envioDeDocumento.error") {
                    alertify.alert("Error al enviar el documento: " + respuesta.error);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    },
    transicionarDocumentoConAreaIntermedia: function (documento, idAreaIntermedia, onSuccess) {
        $.ajax({
            url: "../AjaxWS.asmx/TransicionarDocumentoConAreaIntermedia",
            type: "POST",
            data: JSON.stringify({
                id_documento: documento.id,
                id_area_origen: documento.areaActual.id,
                id_area_intermedia: idAreaIntermedia,
                id_area_destino: documento.areaDestino.id
            }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                if (respuesta.tipoDeRespuesta == "envioDeDocumento.ok") {
                    onSuccess(respuesta.documento);
                }
                if (respuesta.tipoDeRespuesta == "envioDeDocumento.error") {
                    alertify.alert("Error al enviar el documento: " + respuesta.error);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    },
    guardarCambiosEnDocumento: function(idDocumento, idAreaDestino, comentarios, onSuccess){
        $.ajax({
            url: "../AjaxWS.asmx/GuardarCambiosEnDocumento",
            type: "POST",
            data: JSON.stringify({
                id_documento: idDocumento,
                id_area_destino: idAreaDestino,
                comentario: comentarios
            }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                if (respuesta.tipoDeRespuesta == "guardarDocumento.ok") {
                    onSuccess(respuesta.documento);
                }
                if (respuesta.tipoDeRespuesta == "guardarDocumento.error") {
                    alertify.alert("Error al guardar cambios en documento: " + respuesta.error);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });    
    }

};