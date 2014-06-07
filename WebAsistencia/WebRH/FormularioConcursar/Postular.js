function ArmarGrillaEstudios () {
    var _this = this;
    var estudios = JSON.parse($('#cvEstudios').val());
    contenedorPlanilla = $('#tabla_antecedentes');

    var columnas = [];

    columnas.push(new Columna("Id", { generar: function (un_estudio) { return un_estudio.id } }));
    columnas.push(new Columna("Titulo", { generar: function (un_estudio) { return un_estudio.Titulo } }));
    columnas.push(new Columna("Establecimiento", { generar: function (un_estudio) { return un_estudio.Establecimiento } }));
    columnas.push(new Columna("Especialidad", { generar: function (un_estudio) { return un_estudio.Especialidad } }));
    columnas.push(new Columna("FechaIngreso", { generar: function (un_estudio) { return un_estudio.FechaIngreso } }));
    columnas.push(new Columna("FechaEgreso", { generar: function (un_estudio) { return un_estudio.FechaEgreso } }));
    columnas.push(new Columna("Localidad", { generar: function (un_estudio) { return un_estudio.Localidad } }));
    columnas.push(new Columna("Pais", { generar: function (un_estudio) { return un_estudio.Pais } }));
    columnas.push(new Columna('&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Acciones&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;', { generar: function (un_estudio) {
        var contenedorBtnAcciones = $('<div>');
        var botonEditar = $('<img>');
        botonEditar.addClass('edit-item-btn');
        botonEditar.attr('src', '../Imagenes/edit.png');
        botonEditar.attr('style', 'padding-right:5px;');
        botonEditar.attr('width', '35px');
        botonEditar.attr('height', '35px');
        contenedorBtnAcciones.append(botonEditar);

        var botonEliminar = $('<img>');
        botonEliminar.addClass('remove-item-btn');
        botonEliminar.attr('src', '../Imagenes/iconos_eliminar.png');
        botonEliminar.attr('width', '35px');
        botonEliminar.attr('height', '35px');
        contenedorBtnAcciones.append(botonEliminar);

        return contenedorBtnAcciones;
    }
    }));


    PlanillaCvEstudios = new Grilla(columnas);

    //PlanillaCvEstudios.AgregarEstilo("tabla_macc");

    PlanillaCvEstudios.SetOnRowClickEventHandler(function (un_estudio) {
        //                 panelAlumno.CompletarDatosAlumno(un_alumno);
    });

    PlanillaCvEstudios.CargarObjetos(estudios);
    PlanillaCvEstudios.DibujarEn(contenedorPlanilla);

    
    
}


function GuardarDatosPersonales() {
    
    var datosPersonales = {};
    var domicilio = {};
    datosPersonales.Nombre = $("#nombre").val();
    datosPersonales.Apellido = $("#apellido").val();
    datosPersonales.Sexo = $("#cmb_sexo").val();
    //datosPersonales.NivelEducativo = $("#cmb_nivel_educativo").val();
    datosPersonales.EstadoCivil = $("#cmb_estadoCivil").val();
    datosPersonales.Cuil = $("#cuil").val();
    datosPersonales.LugarDeNacimiento = $("#cmb_lugar_nacimiento").val();
    datosPersonales.FechaNacimiento = ParsearFecha($("#txt_fechaNac").val());
    datosPersonales.Nacionalidad = $("#cmb_nacionalidad").val();
    datosPersonales.TipoDocumento = $("#cmb_tipoDocumento").val();
    datosPersonales.Dni = parseInt($("#txt_documento").val());

    domicilio.Calle = $("#txt_calle1").val();
    domicilio.Numero = parseInt($("#txt_numero1").val());
    domicilio.Piso = parseInt($("#txt_piso1").val());
    domicilio.Depto = $("#txt_dto1").val();
    domicilio.Localidad = $("#txt_localidad1").val();
    domicilio.Cp = parseInt($("#txt_cp1").val());
    domicilio.Provincia = $("#cmb_provincia1").val();

    datosPersonales.Domicilio = domicilio;

    var data_post = JSON.stringify({
        "datosPersonales_nuevos": datosPersonales,
        "datosPersonales_originales": datosPersonales
    });
    $.ajax({
        url: "../AjaxWS.asmx/GuardarCVDatosPersonales",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
            if (respuesta.length == 0)
                
                alertify.alert("Los datos fueron guardados correctamente");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
};

var ParsearFecha = function (fecha) {
    var day = parseInt(fecha.split("/")[0]);
    var month = parseInt(fecha.split("/")[1]);
    var year = parseInt(fecha.split("/")[2]);

    return new Date(year, month, day);
}

function AgregarAntecedentes() {

    var antecedentes = {};
    antecedentes.Titulo = $("#txt_antecedentes_titulo").val();
    antecedentes.Establecimiento = $("#txt_antecedentes_establecimiento").val();
    antecedentes.Especialidad = $("#txt_establecimiento").val();
    antecedentes.FechaIngreso = ParsearFecha($("#txt_antecedentes_ingreso").val());
    antecedentes.FechaEgreso = ParsearFecha($("#txt_antecedentes_egreso").val());
    antecedentes.Localidad = $("#txt_antecedentes_localidad").val();
    antecedentes.Pais = $("#cmb_antecedentes_pais").val();

    var data_post = JSON.stringify({
        "antecedentesAcademicos_nuevos": antecedentes,
        "antecedentesAcademicos_originales": antecedentes
    });
    $.ajax({
    url: "../AjaxWS.asmx/GuardarCVAntecedentesAcademicos",
    type: "POST",
    data: data_post,
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (respuestaJson) {
        var respuesta = JSON.parse(respuestaJson.d);
        if (respuesta.length == 0)
            AgregarEnTabla($("#tabla_antecedentes"), antecedentes);
            alertify.alert("Los datos fueron guardados correctamente");
            $(".modal_close_concursar").click();
    },
    error: function (XMLHttpRequest, textStatus, errorThrown) {
        alertify.alert(errorThrown);
    }
    });
};


var AgregarCapacitacion = function () {

    var capacitacion = {};
    capacitacion.DiplomaDeCertificacion = $("#txt_capacitacion_nombreDiploma").val();
    capacitacion.Establecimiento = $("#txt_capacitacion_establecimiento").val();
    capacitacion.Especialidad = $("#txt_capacitacion_especialidad").val();
    capacitacion.Duracion = $("#txt_capacitacion_duracion").val();
    capacitacion.FechaInicio = ParsearFecha($("#txt_capacitacion_fechaInicio").val());
    capacitacion.FechaFinalizacion = ParsearFecha($("#txt_capacitacion_fechaFin").val());
    capacitacion.Localidad = $("#txt_capacitacion_localidad").val();
    capacitacion.Pais = $("#txt_capacitacion_pais").val();

    var data_post = JSON.stringify({
        "capacitaciones_nuevas": capacitacion,
        "capacitaciones_originales": capacitacion
    });
    $.ajax({
        url: "../AjaxWS.asmx/GuardarCVCapacitaciones",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
            if (respuesta.length == 0)
                AgregarEnTabla($("#tabla_capacitacion"), capacitacion);
                alertify.alert("Los datos fueron guardados correctamente");
                $(".modal_close_concursar").click();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
}


var AgregarDocencia = function () {

    var docencia = {};
    docencia.Asignatura = $("#actividad_docente_asignatura").val();
    docencia.NivelEducativo = $("#actividad_docente_nivel_educativo").val();
    docencia.TipoActividad = $("#actividad_docente_tipo_actividad").val();
    docencia.CategoriaDocente = $("#actividad_docente_categoria").val();
    docencia.CaracterDesignacion = $("#actividad_docente_caracter_designacion").val();
    docencia.DedicacionDocente = $("#actividad_docente_dedicacion").val();
    docencia.CargaHoraria = $("#actividad_docente_carga_horaria").val();
    docencia.FechaInicio = ParsearFecha($("#actividad_docente_fecha_inicio").val());
    docencia.FechaFinalizacion = ParsearFecha($("#actividad_docente_fecha_fin").val());
    docencia.Establecimiento = $("#actividad_docente_establecimiento").val();
    docencia.Localidad = $("#actividad_docente_localidad").val();
    docencia.Pais = $("#actividad_docente_pais").val();

    var data_post = JSON.stringify({
        "docencias_nuevas": docencia,
        "docencias_originales": docencia
    });
    $.ajax({
        url: "../AjaxWS.asmx/GuardarCVDocencia",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
            if (respuesta.length == 0)
                AgregarEnTabla($("#tabla_docentes"), docencia);
                alertify.alert("Los datos fueron guardados correctamente");
                $(".modal_close_concursar").click();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });

}

var AgregarEventoAcademico = function () {

    var eventoAcademico = {};
    eventoAcademico.Denominacion = $("#txt_evento_denominacion").val();
    eventoAcademico.TipoDeEvento = $("#evento_academico_tipo_evento").val();
    eventoAcademico.CaracterDeParticipacion = $("#evento_academico_caracter_participacion").val();
    eventoAcademico.Institucion = $("#evento_academico_institucion").val();
    eventoAcademico.FechaInicio = ParsearFecha($("#evento_academico_fecha_inicio").val());
    eventoAcademico.FechaFinalizacion = ParsearFecha($("#evento_academico_fecha_fin").val());
    //eventoAcademico.Duracion =
    eventoAcademico.Localidad = $("#evento_academico_localidad").val();
    eventoAcademico.Pais = $("#cmb_evento_academico_pais").val();

    var data_post = JSON.stringify({
        "eventosAcademicos_nuevos": eventoAcademico,
        "eventosAcademicos_originales": eventoAcademico
    });
    $.ajax({
        url: "../AjaxWS.asmx/GuardarCVEventoAcademico",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
            if (respuesta.length == 0)
                AgregarEnTabla($("#tabla_eventoAcademico"), eventoAcademico);
            alertify.alert("Los datos fueron guardados correctamente");
            $(".modal_close_concursar").click();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
}

var AgregarPublicacion = function () {

    var publicacion = {};
    publicacion.Titulo = $("#publicaciones_titulo").val();
    publicacion.DatosEditorial = $("#publicaciones_editorial").val();
    publicacion.FechaPublicacion = ParsearFecha($("#publicaciones_fecha").val());
    publicacion.CantidadHojas = $("#publicaciones_paginas").val();
    publicacion.DisponeCopia = $("#publicaciones_dispone_copia").val();
    

    var data_post = JSON.stringify({
        "publicaciones_nuevas": publicacion,
        "publicaciones_originales": publicacion
    });
    $.ajax({
        url: "../AjaxWS.asmx/GuardarCVPublicaciones",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
            if (respuesta.length == 0)
                AgregarEnTabla($("#tabla_publicaciones"), publicacion);
            alertify.alert("Los datos fueron guardados correctamente");
            $(".modal_close_concursar").click();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
}


var AgregarMatricula = function () {

    var matricula = {};
    matricula.numero = $("#matricula_numero").val();
    matricula.expedidapor = $("#matricula_expedida_por").val();
    matricula.fechaInscripcion = ParsearFecha($("#matricula_fecha_inscripcion").val());
    matricula.situacionActual = $("#matricula_situacion").val();

    var data_post = JSON.stringify({
        "matriculas_nuevas": matricula,
        "matriculas_originales": matricula
    });
    $.ajax({
        url: "../AjaxWS.asmx/GuardarCVMatriculas",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
            if (respuesta.length == 0)
                AgregarEnTabla($("#tabla_matriculas"), matricula);
            alertify.alert("Los datos fueron guardados correctamente");
            $(".modal_close_concursar").click();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
}


var AgregarInstitucionAcademica = function () {

    var Institucion = {};
    Institucion.institucion = $("#pertenencia-institucion_nombre").val();
    Institucion.caracterEntidad = $("#pertenencia-institucion_caracter").val();
    Institucion.cargosDesempeniados = $("#pertenencia-institucion_cargo").val();

    Institucion.numeroAfiliado = $("#pertenencia-institucion_numero_afiliado").val();
    Institucion.categoriaActual = $("#pertenencia-institucion_categoria_actual").val();
    Institucion.fechaDeAfiliacion = ParsearFecha($("#pertenencia-institucion_fecha_afiliacion").val());
    Institucion.fecha = ParsearFecha($("#pertenencia-institucion_fecha").val());
    Institucion.fechaInicio = ParsearFecha($("#pertenencia-institucion_fecha_inicio").val());
    Institucion.fechaFin = ParsearFecha($("#pertenencia-institucion_fecha_fin").val());
    Institucion.localidad = $("#pertenencia-institucion_localidad").val();
    Institucion.pais = $("#pertenencia-institucion_pais").val();
  



    var data_post = JSON.stringify({
        "instituciones_nuevas": Institucion,
        "instituciones_originales": Institucion
    });
    $.ajax({
        url: "../AjaxWS.asmx/GuardarCVInstituciones",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
            if (respuesta.length == 0)
                AgregarEnTabla($("#tabla_instituciones_academicas"), Institucion);
            alertify.alert("Los datos fueron guardados correctamente");
            $(".modal_close_concursar").click();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
}





















var AgregarEnTabla = function (tabla,datos) {

    var n = $('tr:last td', tabla).length;
    var valores = new Array();

    //FC: el map inspecciona cada key o cada valor del objeto o array que le pase
    jQuery.map(datos, function (value, key) {
        valores.push(value)
    });
    
    var tds = '<tr>';
    for (var i = 0; i < n; i++) {

        tds += '<td>' + valores[i] + '</td>';
    }
    tds += '</tr>';

    tabla.append(tds);
}




