var ContenedorGrilla;
var mesSeleccionadoDesde;
var anioSeleccionadoDesde;
var mesSeleccionadoHasta;
var anioSeleccionadoHasta;
var estadoSeleccionado;
var consultaSeleccionada;

Backend.start(function () {
    $(document).ready(function () {

        GenerarBoton();

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorPersona").empty();

        $('#divComboDesde').hide();
        $('#divComboHasta').hide();
        $('#divEstado').hide();
        $('#divBuscadorArea').hide();
        $('#divBuscadorPersona').hide();
        $('#DivBotonConsultar').hide();
        

        completarComboMeses($('#cmbMesesDesde'));
        completarComboMeses($('#cmbMesesHasta'));
        completarComboEstado(0, $('#cmbEstado'));

    });
});

var GenerarBoton = function () {

    $("#DivBotonConsultaPorPersona").empty();
    var divBtnConsultar = $("#DivBotonConsultaPorPersona")
    botonConsultar = $("<input type='button'>");
    botonConsultar.val("Consulta por Persona");
    botonConsultar.click(function () {
        ConsultarPorPersona();
    });
    divBtnConsultar.append(botonConsultar);


    $("#DivBotonConsultaPorArea").empty();
    var divBtnConsultar = $("#DivBotonConsultaPorArea")
    botonConsultar = $("<input type='button'>");
    botonConsultar.val("Consulta por Area");
    botonConsultar.click(function () {
        ConsultarPorArea();
    });
    divBtnConsultar.append(botonConsultar);


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
       // meses.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert(error);
    });
}

var completarComboEstado = function (mostrarSinGenerar, combo) {
    var estado = combo;
    estado.html("");
    Backend.GetEstadosDDJJ104(mostrarSinGenerar)
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            item = new Option(respuesta[i].Descripcion, respuesta[i].Id);
            $(item).html(respuesta[i].Descripcion);
            estado.append(item);
        }
       // estado.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert(error);
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

    getConsultaIndividual(function () {
        DibujarGrillaDDJJ();
        spinner.stop();
    });

}

var ConsultarPorPersona = function () {
    $('#divComboDesde').show();
    $('#divComboHasta').show();
    $('#divEstado').show();
    $('#divBuscadorArea').hide();
    $('#divBuscadorPersona').show();
    $('#DivBotonConsultar').show();

    consultaSeleccionada = "PERSONA";
}

var ConsultarPorArea = function () {
    $('#divComboDesde').show();
    $('#divComboHasta').show();
    $('#divEstado').show();
    $('#divBuscadorArea').show();
    $('#divBuscadorPersona').hide();
    $('#DivBotonConsultar').show();

    consultaSeleccionada = "AREA"
}


var getConsultaIndividual = function (callback) {

    if (consultaSeleccionada == "PERSONA") {
        var documento = $('#documento').text().trim();
        if (documento == "") {
            documento = 0;
        }
        Backend.GetConsultaIndividualPorPersona(mesSeleccionadoDesde, anioSeleccionadoDesde, mesSeleccionadoHasta, anioSeleccionadoHasta, documento, estadoSeleccionado, 0)
        .onSuccess(function (respuesta) {
            lista_areas_del_usuario = respuesta;
            callback();
        })
        .onError(function (error, as, asd) {
            alertify.alert(error);
        });
    }


    if (consultaSeleccionada == "AREA") {
        spinner.stop();
        alert("Falta Implementar");
    }

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
            new Columna("Fecha Generación", { generar: function (consulta) { return consulta.fecha_generacion; } }),
            new Columna("Usuario Generación", { generar: function (consulta) { return consulta.usuario_generacion; } }),
            new Columna("Fecha Recibido", { generar: function (consulta) { return consulta.fecha_recibido; } }),
            new Columna("Usuario Recibido", { generar: function (consulta) { return consulta.usuario_recibido; } }),
            new Columna("Firmante", { generar: function (consulta) { return consulta.firmante; } }),
            new Columna("Categoria", { generar: function (consulta) { return consulta.persona.Categoria; } }),
            new Columna("Mod Contratación", { generar: function (consulta) { return consulta.mod_contratacion; } }),
            new Columna("Estado", { generar: function (consulta) { return consulta.estado_descrip; } })
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
