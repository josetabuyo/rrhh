
$(document).ready(function () {
    var meses = $("#cmbMeses");
    completarComboMeses(meses);
    DibujarGrillaDDJJ();
});


var completarComboMeses = function (meses) {
    meses.html("");
    $.ajax({
        url: "../AjaxWS.asmx/GetMeses",
        type: "POST",
        async: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var item = new Option('Seleccione', '');
            meses.append(item);
            var respuesta = JSON.parse(respuestaJson.d);
            for (var i = 0; i < respuesta.length; i++) {
                item = new Option(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio, respuesta[i].Mes);
                $(item).html(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio);
                meses.append(item);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
}



var getAreasDDJJ = function () {
    var areas;

    $.ajax({
        url: "../AjaxWS.asmx/GetAreasParaDDJJDelMes",
        type: "POST",
        async: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            areas = JSON.parse(respuestaJson.d);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });

    return areas;
}


var DibujarGrillaDDJJ = function () {
    var grilla;
    var ContenedorGrilla = $("#ContenedorGrilla");
    var lista_DDJJ = getAreasDDJJ();

    grilla = new Grilla(
        [
            new Columna("Area", { generar: function (una_fila) { return una_fila.Area.Nombre; } }),
			new Columna("Cant. Personas", { generar: function (una_fila) { return una_fila.CantidadPersonas; } }),
			new Columna("Estado", { generar: function (una_fila) { return una_fila.Estado; } }),
		]);

    grilla.CargarObjetos(lista_DDJJ);
    grilla.DibujarEn(ContenedorGrilla);
}
