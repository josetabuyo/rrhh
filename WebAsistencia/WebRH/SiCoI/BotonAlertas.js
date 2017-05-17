var BotonAlertas = function (cfg) {
    cfg.boton_alertas.hide();
    cfg.boton_alertas.click(function () {
        $.ajax({
            url: "../AjaxWS.asmx/GetDocumentosEnAlerta",
            type: "POST",
            data: JSON.stringify({}),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var documentos = JSON.parse(respuestaJson.d);
                cfg.panel_documentos.mostrarDocumentos(documentos);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert("", errorThrown);
            }
        });
    });
    setInterval(function () {
        $.ajax({
            url: "../AjaxWS.asmx/HayDocumentosEnAlerta",
            type: "POST",
            data: JSON.stringify({}),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                if (JSON.parse(respuestaJson.d)) cfg.boton_alertas.show();
                else cfg.boton_alertas.hide();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    }, 10000);  //cada 10 segundos pregunta si hay
}
