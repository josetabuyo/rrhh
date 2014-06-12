
var lista_DDJJ;
var ContenedorGrilla = $("#ContenedorGrilla");

$(document).ready(function () {
    var meses = $("#cmbMeses");
    completarComboMeses(meses);
    $("#progressbar").hide();
    
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
                item = new Option(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio, respuesta[i].Mes + '-' + respuesta[i].Anio);
                $(item).html(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio);
                meses.append(item);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
}


$('#cmbMeses').change(function () {

    $("#progressbar").show();

    ContenedorGrilla.html("");
    
    getAreasDDJJ();

});


var DibujarGrillaDDJJ = function (p_lista_DDJJ) {
    var grilla;
    
    grilla = new Grilla(
        [
            new Columna("Area", { generar: function (una_fila) { return una_fila.Area.Nombre; } }),
			new Columna("Cant. Personas", { generar: function (una_fila) { return una_fila.CantidadPersonas; } }),
            //new Columna("Estado", { generar: function (una_fila) { return una_fila.Estado; } }),
            new Columna("Estado", { generar: function (una_fila) { return GetDescripcionEstado(una_fila.Estado); } }),

            new Columna("", new GeneradorBotones()),
		]);

    grilla.CargarObjetos(p_lista_DDJJ);
    grilla.DibujarEn(ContenedorGrilla);
    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
}


var getAreasDDJJ = function () {
    var meses = $("#cmbMeses");
    var data_post = { valorCombo: meses.val() };
    $.ajax({
        url: "../AjaxWS.asmx/GetAreasParaDDJJDelMes",
        type: "POST",
        async: true,
        dataType: "json",
        data: JSON.stringify(data_post),
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            lista_DDJJ = JSON.parse(respuestaJson.d);
            DibujarGrillaDDJJ(lista_DDJJ);            
            $("#progressbar").hide();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });

    //return areas;
}

var GeneradorBotones = function () {
    this.generar = function (row) {

        var boton;
        switch (row.Estado.toString()) {
            case '1':
                boton = $("<input type='button'>");
                boton.val("Generar");
                boton.click(GenerarDDJJ(row.Area.Id));
                break;
            case '2':
                boton = $("<input type='button'>");
                boton.val("Imprimir");
                boton.click();
                break;
            case '3':
                boton = $("<input type='button'>");
                boton.val("ReImprimir");
                boton.click();
                break;
        }

        return boton;
    };
}


var GetDescripcionEstado = function (estado) {
    switch (estado.toString()) {
        case '1':
            return 'Sin Generar'
            break;
        case '2':
            return 'Generada sin imprimir'
            break;
        case '3':
            return 'Impresa no recepcionada'
            break;
        case '4':
            return 'Recepcionada'
            break;
    }
};


var GenerarDDJJ = function (idArea) {
    return function (e) {
       // alert(idArea);

        var queryResult = Enumerable.From(lista_DDJJ)
                .Where(function (x) { return x.Area.Id == idArea });

        var data_post = { lista: queryResult.ToArray() };
        $.ajax({
        url: "../AjaxWS.asmx/GenerarDDJJ104",
        type: "POST",
        async: false,
        dataType: "json",
        data: JSON.stringify(data_post),
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            if (respuestaJson.d == "OK") {
                alertify.alert("Se genero correctamente");    
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
        });
    }

};


$(function() {
    $( "#progressbar" ).progressbar({
      value: false
    })    
});
