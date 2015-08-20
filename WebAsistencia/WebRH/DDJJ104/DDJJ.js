
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

    if (meses.val() == "") {
        $("#progressbar").hide();
        return;
    }

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
            $("#progressbar").hide();
            meses.val("");
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
                boton.click(ImprimirDDJJ(row.Area.Id));
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

                $("#progressbar").show();
                ContenedorGrilla.html("");
                getAreasDDJJ();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
        });
    }
};


var ImprimirDDJJ = function (idArea) {
    return function (e) {
        var listaImprimir;

        var queryResult = Enumerable.From(lista_DDJJ)
                .Where(function (x) { return x.Area.Id == idArea });

        var data_post = { lista: queryResult.ToArray() };
        $.ajax({
            url: "../AjaxWS.asmx/ImprimirDDJJ104",
            type: "POST",
            async: false,
            dataType: "json",
            data: JSON.stringify(data_post),
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                listaImprimir = JSON.parse(respuestaJson.d);
                DibujarFormularioDDJJ104(listaImprimir);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    }
};


var DibujarFormularioDDJJ104 = function (p_listaImprimir_DDJJ) {
    var grilla;
    var ContenedorPlanilla = $("<div style='page-break-before: always;'>");

    var area;
    var mes;
    var anio;
    var direccion;
    var dependencia;
    var leyenda;
    var nroDDJJ104;

    area = p_listaImprimir_DDJJ[0].Area.Nombre;
    mes = p_listaImprimir_DDJJ[0].Mes;
    anio = p_listaImprimir_DDJJ[0].Anio;
    direccion = p_listaImprimir_DDJJ[0].Area.Direccion;
    dependencia = p_listaImprimir_DDJJ[0].Area.Dependencias[0].Nombre;
    leyenda = p_listaImprimir_DDJJ[0].LeyendaPorAnio;
    nroDDJJ = "NRO DDJJ: " + p_listaImprimir_DDJJ[0].IdDDJJ;
    

    grilla = new Grilla(
        [
            new Columna("APELLIDO Y NOMBRE", { generar: function (una_fila) { return una_fila.Agente.Apellido + " " + una_fila.Agente.Nombre; } }),
			new Columna("CUIL/CUIT", { generar: function (una_fila) { return una_fila.Agente.Cuit; } }),
            new Columna("ESCALAFON O MODALIDAD DE CONTRATACION", { generar: function (una_fila) { return una_fila.Agente.Categoria.split("#")[1]; } }),
            new Columna("NIVEL O CATEGORIA", { generar: function (una_fila) { return una_fila.Agente.Categoria.split("#")[0]; } }),
		]);

    grilla.CargarObjetos(p_listaImprimir_DDJJ);
    grilla.DibujarEn(ContenedorPlanilla);
    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });


    var w = window.open("../DDJJ104/Impresion/ImpresionDDJJ104.aspx");

    w.onload = function () {

        var t = w.document.getElementById("PanelImpresion");
        var mesddjj = w.document.getElementById("MesDDJJ104");
        var anioddjj = w.document.getElementById("AnioDDJJ104");
        var areaddjj = w.document.getElementById("AreaDDJJ104");
        var areadireccionddjj = w.document.getElementById("AreaDireccionDDJJ104");
        var areadependenciaddjj = w.document.getElementById("AreaDependenciaDDJJ104");
        var leyendaporanioddjj = w.document.getElementById("LeyendaPorAnioDDJJ104");
        var nroDDJJ104 = w.document.getElementById("NroDDJJ104");
        
        $(areaddjj).html(area);
        $(mesddjj).html(NombreMes(mes));
        $(anioddjj).html(anio);
        $(areadireccionddjj).html(direccion);
        $(areadependenciaddjj).html(dependencia);
        $(leyendaporanioddjj).html(leyenda);
        $(nroDDJJ104).html(nroDDJJ);

        $(t).html(ContenedorPlanilla.html());
    }



    // w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap.css' type='text/css' />");
    // w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap-responsive.css' type='text/css' />");
    // w.document.write("<link  rel='stylesheet' href='../Estilos/Estilos.css' type='text/css'  />");

    //    w.document.write("<div class='div_print'><br/>Area: " + area + "<br/><br/></div>");

    // w.document.write(ContenedorPlanilla.html());
    // w.print();
    // w.close();

}




$(function() {
    $( "#progressbar" ).progressbar({
      value: false
    })    
});


function NombreMes(num) {

    switch (num) {
        case 1: return "enero";
        case 2: return "febrero";
        case 3: return "marzo";
        case 4: return "abril";
        case 5: return "mayo";
        case 6: return "junio";
        case 7: return "julio";
        case 8: return "agosto";
        case 9: return "septiembre";
        case 10: return "octubre";
        case 11: return "noviembre";
        case 12: return "diciembre";
    }

    return "";
}