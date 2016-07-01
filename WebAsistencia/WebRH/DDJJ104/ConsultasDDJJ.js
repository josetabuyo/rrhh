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
    Backend.GetConsultaIndividualPorPersona(4, 2016, 4, 2016, 0, 0, 0)
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
            new Columna("Mes", { generar: function (consulta) { return consulta.mes; } }),
            new Columna("Año", { generar: function (consulta) { return consulta.anio; } }),
            new Columna("Area", { generar: function (consulta) { return consulta.area_generacion.Nombre; } }),
            new Columna("Apellido", { generar: function (consulta) { return consulta.persona.Apellido; } }),
            new Columna("Nombre", { generar: function (consulta) { return consulta.persona.Nombre; } }),
            new Columna("fecha_generacion", { generar: function (consulta) { return consulta.fecha_generacion; } }),
            new Columna("usuario_generacion", { generar: function (consulta) { return consulta.usuario_generacion; } }),
            new Columna("fecha_recibido", { generar: function (consulta) { return consulta.fecha_recibido; } }),
            new Columna("usuario_recibido", { generar: function (consulta) { return consulta.usuario_recibido; } }),
            new Columna("firmante", { generar: function (consulta) { return consulta.firmante; } }),
            new Columna("Categoria", { generar: function (consulta) { return consulta.persona.Categoria; } }),
            new Columna("mod_contratacion", { generar: function (consulta) { return consulta.mod_contratacion; } }),
            new Columna("estado_descrip", { generar: function (consulta) { return consulta.estado_descrip; } }),

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
