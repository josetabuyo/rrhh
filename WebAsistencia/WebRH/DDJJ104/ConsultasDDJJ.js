var ContenedorGrilla;
var mesSeleccionadoDesde;
var anioSeleccionadoDesde;
var mesSeleccionadoHasta;
var anioSeleccionadoHasta;


Backend.start(function () {
    $(document).ready(function () {
        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorPersona").empty();

        //$('#cmbMesesDesde').hide();
        //$('#cmbMesesHasta').hide();
        completarComboMeses($('#cmbMesesDesde'));
        completarComboMeses($('#cmbMesesHasta'));

        GenerarBoton();
    });
});

var GenerarBoton = function() {
    $("#DivBotonConsultar").empty();
    var divBtnConsultar = $("#DivBotonConsultar")
    botonConsultar = $("<input type='button'>");
    botonConsultar.val("Consultar");
    botonConsultar.click(function () {
        Consultar();
    });
    divBtnConsultar.append(botonConsultar);
}


var completarComboMeses = function (combo) {
    var meses = combo;
    meses.html("");
    Backend.GetMeses()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            item = new Option(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio, respuesta[i].Mes + '-' + respuesta[i].Anio);
            $(item).html(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio);
            meses.append(item);
        }
        meses.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert(error);
    });
}


var Consultar = function() { 

    ContenedorGrilla.html("");
    $("#ContenedorPersona").empty();

    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    mesSeleccionadoDesde  = parseInt($("#cmbMesesDesde").val().split("-")[0]);
    anioSeleccionadoDesde = parseInt($("#cmbMesesDesde").val().split("-")[1]);
    mesSeleccionadoHasta  = parseInt($("#cmbMesesHasta").val().split("-")[0]);
    anioSeleccionadoHasta = parseInt($("#cmbMesesHasta").val().split("-")[1]);
            
    getConsultaIndividual(function () {
        DibujarGrillaDDJJ();
        spinner.stop();                 
    });            

}


var getConsultaIndividual = function (callback) {
    Backend.GetAreasParaDDJJ104(4, 2016, 0)
    .onSuccess(function (respuesta) {
        lista_areas_del_usuario = respuesta;
        callback();
    })
    .onError(function (error, as, asd) {
        alertify.alert(error);
    });
}

var DibujarGrillaDDJJ = function () {
    var grilla;

    $("#ContenedorPersona").empty();
    grilla = new Grilla(
        [
            new Columna("Area", { generar: function (un_area) { return un_area.Nombre; } }),

		]);

    grilla.CargarObjetos(lista_areas_del_usuario);
    grilla.DibujarEn(ContenedorGrilla);
    

    $("#DivBotonExcel").empty();
    var divBtnExportarExcel = $("#DivBotonExcel")
    botonExcel = $("<input type='button'>");
    botonExcel.val("Exportar a Excel");
    botonExcel.click(function () {
        BuscarExcel(mesSeleccionado, anioSeleccionado, 0);
    });
    divBtnExportarExcel.append(botonExcel);


    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
}
