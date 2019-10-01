var spinner;
var mes;
var idUsuario;
var FechaDesde;
var FechaHasta;


Backend.start(function () {
    $(document).ready(function () {

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#Contenedor").empty();

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


var Consultar = function () {

    ContenedorGrilla.html("");
    $("#Contenedor").empty();
    
    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    getConsulta(function () {
        DibujarGrilla();
    });

   
    spinner.stop();
    //$('#DivBotonExcel').show();
}



var getConsulta = function (callback) {

    var documento = sessionStorage.getItem("documento");
    var fechadesde = $("#fecha_desde").val();
    var fechahasta = $("#fecha_hasta").val();


    if (documento == "") {
        documento = 0;
    }

    
    Backend.GET_Reporte_Presentismo_Individual(documento, fechadesde, fechahasta)
        .onSuccess(function (respuesta) {
            lista_presentismo = respuesta;
            DibujarGrilla();
        })
        .onError(function (error, as, asd) {
            alertify.alert("", error);
        });
    
}



var DibujarGrilla = function () {
    var grilla;

    $("#Contenedor").empty();
    
    grilla = new Grilla(
        [
            new Columna("Fecha", { generar: function (consulta) { return consulta.Fecha; } }),
            new Columna("Hora Desde", { generar: function (consulta) { return consulta.Hora_Desde; } }),
            new Columna("Hora Hasta", { generar: function (consulta) { return consulta.Hora_Hasta; } }),
            new Columna("Estado", { generar: function (consulta) { return consulta.Estado; } }),
            new Columna("Licencia", { generar: function (consulta) { return consulta.Licencia; } })
        ]);
    

    grilla.CargarObjetos(lista_presentismo);
    grilla.DibujarEn(ContenedorGrilla);


    //$("#DivBotonExcel").empty();
    //var divBtnExportarExcel = $("#DivBotonExcel")
    //botonExcel = $("<input type='button'>");
    //botonExcel.val("Exportar a Excel");
    //botonExcel.click(function () {
    //    BuscarExcel();
    //});
    //botonExcel.addClass("btn btn-primary");
    //divBtnExportarExcel.append(botonExcel);


    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
}
