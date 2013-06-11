var ServicioDeLegajos = {
    getLegajo: function (numero_documento, onSuccess, onError) {
        $.ajax({
            url: "../AjaxWS.asmx/GetLegajoParaDigitalizacion",
            type: "POST",
            data: JSON.stringify({
                numero_documento: numero_documento
            }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                onSuccess(respuesta);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                onError(errorThrown);
            }
        });
    }
};