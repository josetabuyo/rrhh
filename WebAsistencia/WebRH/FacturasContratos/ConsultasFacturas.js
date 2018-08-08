var ContenedorGrilla;
var mesSeleccionadoDesde;
var anioSeleccionadoDesde;
var mesSeleccionadoHasta;
var anioSeleccionadoHasta;

Backend.start(function () {
    $(document).ready(function () {

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorPersona").empty();

        completarComboMeses($('#cmbMesesDesde'));
        completarComboMeses($('#cmbMesesHasta'));

        //GenerarBoton();
        $("#DivBotonConsultar").empty();
        var divBtnConsultar = $("#DivBotonConsultar")
        botonConsultar = $("<input type='button'>");
        botonConsultar.val("Consultar");
        botonConsultar.click(function () {
            Consultar();
        });
        botonConsultar.addClass("btn btn-primary");
        divBtnConsultar.append(botonConsultar);

    });
});


var completarComboMeses = function (combo) {
    var meses = combo;
    meses.html("");
    Backend.GetMesesDeFacturas()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            item = new Option(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio, respuesta[i].Mes + '-' + respuesta[i].Anio);
            $(item).html(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio);
            meses.append(item);
        }
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
    });
}


var Consultar = function () {

    ContenedorGrilla.html("");
    $("#ContenedorPersona").empty();

    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    mesSeleccionadoDesde = parseInt($("#cmbMesesDesde").val().split("-")[0]);
    anioSeleccionadoDesde = parseInt($("#cmbMesesDesde").val().split("-")[1]);
    mesSeleccionadoHasta = parseInt($("#cmbMesesHasta").val().split("-")[0]);
    anioSeleccionadoHasta = parseInt($("#cmbMesesHasta").val().split("-")[1]);
    estadoSeleccionado = parseInt($("#cmbEstado").val());

    getConsulta(function () {
        DibujarGrillaDDJJ();
        spinner.stop();
    });
    //$('#DivBotonExcel').show();
}


var getConsulta = function (callback) {

        var documento = $('#documento').text().trim();
        if (documento == "") {
            documento = 0;
        }
        Backend.GetConsultaFacturas(mesSeleccionadoDesde, anioSeleccionadoDesde, mesSeleccionadoHasta, anioSeleccionadoHasta, documento)
        .onSuccess(function (respuesta) {
            lista_areas_del_usuario = respuesta;
            callback();
        })
        .onError(function (error, as, asd) {
            alertify.alert("", error);
            spinner.stop();
        });

}


var DibujarGrillaDDJJ = function () {
    var grilla;
    $("#ContenedorPersona").empty();

        grilla = new Grilla(
        [
            new Columna("Apellido", { generar: function (consulta) { return consulta.Persona.Apellido; } }),
            new Columna("Nombre", { generar: function (consulta) { return consulta.Persona.Nombre; } }),
            new Columna("Documento", { generar: function (consulta) { return consulta.Persona.Documento; } }),
            new Columna("Monto de Contrato", { generar: function (consulta) { return consulta.Monto_Contrato; } }),
            new Columna("Fecha Factura", { generar: function (consulta) { return consulta.Fecha_Factura; } }),
            new Columna("Nro de Factura", { generar: function (consulta) { return consulta.Nro_Factura; } }),
            new Columna("Monto de Factura", { generar: function (consulta) { return consulta.Monto_Factura; } }),
            new Columna("Mes Imputado", { generar: function (consulta) { return consulta.Mes_Imputado; } }),
            new Columna("Año Imputado", { generar: function (consulta) { return consulta.Anio_Imputado; } }),
            new Columna("Area", { generar: function (consulta) { return consulta.Area; } }),
            new Columna("Firmante", { generar: function (consulta) { return consulta.Firmante; } })
		]);
    
    grilla.CargarObjetos(lista_areas_del_usuario);
    grilla.DibujarEn(ContenedorGrilla);


//    $("#DivBotonExcel").empty();
//    var divBtnExportarExcel = $("#DivBotonExcel")
//    botonExcel = $("<input type='button'>");
//    botonExcel.val("Exportar a Excel");
//    botonExcel.click(function () {
//        BuscarExcel();
//    });
//    botonExcel.addClass("btn btn-primary");
//    divBtnExportarExcel.append(botonExcel);


    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
}

