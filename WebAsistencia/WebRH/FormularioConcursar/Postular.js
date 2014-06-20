// Botón para Ir Arriba

jQuery(document).ready(function () {
    jQuery("#IrArriba").hide();
    jQuery(function () {
        jQuery(window).scroll(function () {
            if (jQuery(this).scrollTop() > 200) {
                jQuery('#IrArriba').fadeIn();
            } else {
                jQuery('#IrArriba').fadeOut();
            }
        });
        jQuery('#IrArriba a').click(function () {
            jQuery('body,html').animate({
                scrollTop: 0
            }, 800);
            return false;
        });
    });

});


//DatePicker del formulario de DatosPersonales
$('#txt_fechaNac').datepicker({
    dateFormat: 'dd/mm/yy',
    onClose: function () {

    }
});


var ParsearFecha = function (fecha) {
    var day = parseInt(fecha.split("/")[0]);
    var month = parseInt(fecha.split("/")[1]);
    var year = parseInt(fecha.split("/")[2]);

    return new Date(year, month, day);
}

function AgregarAntecedentesAcademico() {

    var antecedentes = {};

    AntecedentesAcademicos.mostrar(antecedentes, function (estudios) {
        PlanillaCvEstudios.BorrarContenido();
        PlanillaCvEstudios.CargarObjetos(estudios);
    });

};

function AgregarActividadesDocentes() {

    var antecedentes = {};

    ActividadesDocentes.mostrar(antecedentes, function (actividades_docentes) {
        PlanillaCvActividadesDocentes.BorrarContenido();
        PlanillaCvActividadesDocentes.CargarObjetos(actividades_docentes);
    });

};

function AgregarActividadesCapacitacion() {

    var antecedentes = {};

    ActividadesCapacitacion.mostrar(antecedentes, function (actividades_capacitacion) {
        PlanillaCvActividadesCapacitacion.BorrarContenido();
        PlanillaCvActividadesCapacitacion.CargarObjetos(actividades_capacitacion);
    });

};

function AgregarEventosAcademicos() {

    var eventos = {};

    EventosAcademicos.mostrar(eventos, function (eventos_academicos) {
        PlanillaCvEventosAcademicos.BorrarContenido();
        PlanillaCvEventosAcademicos.CargarObjetos(eventos_academicos);
    });

};

function AgregarPublicacionesTrabajos() {

    var antecedentes = {};

    PublicacionesTrabajos.mostrar(antecedentes, function (publicaciones_trabajos) {
        PlanillaCvPublicacionesTrabajos.BorrarContenido();
        PlanillaCvPublicacionesTrabajos.CargarObjetos(publicaciones_trabajos);
    });

};

function AgregarMatriculas() {

    var antecedentes = {};

    Matriculas.mostrar(antecedentes, function (matriculas) {
        PlanillaCvMatriculas.BorrarContenido();
        PlanillaCvMatriculas.CargarObjetos(matriculas);
    });

};

function InstitucionesAcademicas() {

    var antecedentes = {};

    InstitucionesAcademicas.mostrar(antecedentes, function (instituciones_academicas) {
        PlanillaCvInstitucionesAcademicas.BorrarContenido();
        PlanillaCvInstitucionesAcademicas.CargarObjetos(instituciones_academicas);
    });

};

function AgregarExperienciaLaboral() {

    var antecedentes = {};

    ExperienciaLaboral.mostrar(antecedentes, function (experiencia_laboral) {
        PlanillaCvExperienciaLaboral.BorrarContenido();
        PlanillaCvExperienciaLaboral.CargarObjetos(experiencia_laboral);
    });

};

function AgregarIdiomasExtranjeros() {

    var antecedentes = {};

    IdiomasExtranjeros.mostrar(antecedentes, function (idiomas_extranjeros) {
        PlanillaCvIdiomasExtranjeros.BorrarContenido();
        PlanillaCvIdiomasExtranjeros.CargarObjetos(idiomas_extranjeros);
    });

};

function AgregarCompetenciasInformaticas() {

    var antecedentes = {};

    CompetenciasInformaticas.mostrar(antecedentes, function (competencias_informaticas) {
        PlanillaCvCompetenciasInformaticas.BorrarContenido();
        PlanillaCvCompetenciasInformaticas.CargarObjetos(competencias_informaticas);
    });

};

function AgregarOtrasCapacidades() {

    var antecedentes = {};

    OtrasCapacidades.mostrar(antecedentes, function (otras_capacidades) {
        PlanillaCvOtrasCapacidades.BorrarContenido();
        PlanillaCvOtrasCapacidades.CargarObjetos(otras_capacidades);
    });

};


//SOY BEL, lo Borré para reemplazarlo por como estaba Actividsdes academicas
//var AgregarCapacitacion = function () {

//    var capacitacion = {};
//    capacitacion.DiplomaDeCertificacion = $("#txt_capacitacion_nombreDiploma").val();
//    capacitacion.Establecimiento = $("#txt_capacitacion_establecimiento").val();
//    capacitacion.Especialidad = $("#txt_capacitacion_especialidad").val();
//    capacitacion.Duracion = $("#txt_capacitacion_duracion").val();
//    capacitacion.FechaInicio = ParsearFecha($("#txt_capacitacion_fechaInicio").val());
//    capacitacion.FechaFinalizacion = ParsearFecha($("#txt_capacitacion_fechaFin").val());
//    capacitacion.Localidad = $("#txt_capacitacion_localidad").val();
//    capacitacion.Pais = $("#txt_capacitacion_pais").val();

//    var data_post = JSON.stringify({
//        "capacitaciones_nuevas": capacitacion,
//        "capacitaciones_originales": capacitacion
//    });
//    $.ajax({
//        url: "../AjaxWS.asmx/GuardarCVCapacitaciones",
//        type: "POST",
//        data: data_post,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (respuestaJson) {
//            var respuesta = JSON.parse(respuestaJson.d);
//            if (respuesta.length == 0)
//                AgregarEnTabla($("#tabla_capacitacion"), capacitacion);
//            alertify.alert("Los datos fueron guardados correctamente");
//            $(".modal_close_concursar").click();
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alertify.alert(errorThrown);
//        }
//    });
//}

//var AgregarDocencia = function () {

//    var docencia = {};
//    docencia.Asignatura = $("#actividad_docente_asignatura").val();
//    docencia.NivelEducativo = $("#actividad_docente_nivel_educativo").val();
//    docencia.TipoActividad = $("#actividad_docente_tipo_actividad").val();
//    docencia.CategoriaDocente = $("#actividad_docente_categoria").val();
//    docencia.CaracterDesignacion = $("#actividad_docente_caracter_designacion").val();
//    docencia.DedicacionDocente = $("#actividad_docente_dedicacion").val();
//    docencia.CargaHoraria = $("#actividad_docente_carga_horaria").val();
//    docencia.FechaInicio = ParsearFecha($("#actividad_docente_fecha_inicio").val());
//    docencia.FechaFinalizacion = ParsearFecha($("#actividad_docente_fecha_fin").val());
//    docencia.Establecimiento = $("#actividad_docente_establecimiento").val();
//    docencia.Localidad = $("#actividad_docente_localidad").val();
//    docencia.Pais = $("#actividad_docente_pais").val();

//    var data_post = JSON.stringify({
//        "docencias_nuevas": docencia,
//        "docencias_originales": docencia
//    });
//    $.ajax({
//        url: "../AjaxWS.asmx/GuardarCvActividadesDocentes",
//        type: "POST",
//        data: data_post,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (respuestaJson) {
//            var respuesta = JSON.parse(respuestaJson.d);
//            if (respuesta.length == 0)
//                AgregarEnTabla($("#tabla_docentes"), docencia);
//            alertify.alert("Los datos fueron guardados correctamente");
//            $(".modal_close_concursar").click();
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alertify.alert(errorThrown);
//        }
//    });

//}

//var AgregarEventoAcademico = function () {

//    var eventoAcademico = {};
//    eventoAcademico.Denominacion = $("#txt_evento_denominacion").val();
//    eventoAcademico.TipoDeEvento = $("#evento_academico_tipo_evento").val();
//    eventoAcademico.CaracterDeParticipacion = $("#evento_academico_caracter_participacion").val();
//    eventoAcademico.Institucion = $("#evento_academico_institucion").val();
//    eventoAcademico.FechaInicio = ParsearFecha($("#evento_academico_fecha_inicio").val());
//    eventoAcademico.FechaFinalizacion = ParsearFecha($("#evento_academico_fecha_fin").val());
//    //eventoAcademico.Duracion =
//    eventoAcademico.Localidad = $("#evento_academico_localidad").val();
//    eventoAcademico.Pais = $("#cmb_evento_academico_pais").val();

//    var data_post = JSON.stringify({
//        "eventosAcademicos_nuevos": eventoAcademico,
//        "eventosAcademicos_originales": eventoAcademico
//    });
//    $.ajax({
//        url: "../AjaxWS.asmx/GuardarCVEventoAcademico",
//        type: "POST",
//        data: data_post,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (respuestaJson) {
//            var respuesta = JSON.parse(respuestaJson.d);
//            if (respuesta.length == 0)
//                AgregarEnTabla($("#tabla_eventoAcademico"), eventoAcademico);
//            alertify.alert("Los datos fueron guardados correctamente");
//            $(".modal_close_concursar").click();
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alertify.alert(errorThrown);
//        }
//    });
//}

//var AgregarPublicacion = function () {

//    var publicacion = {};
//    publicacion.Titulo = $("#publicaciones_titulo").val();
//    publicacion.DatosEditorial = $("#publicaciones_editorial").val();
//    publicacion.FechaPublicacion = ParsearFecha($("#publicaciones_fecha").val());
//    publicacion.CantidadHojas = $("#publicaciones_paginas").val();
//    publicacion.DisponeCopia = $("#publicaciones_dispone_copia").val();


//    var data_post = JSON.stringify({
//        "publicaciones_nuevas": publicacion,
//        "publicaciones_originales": publicacion
//    });
//    $.ajax({
//        url: "../AjaxWS.asmx/GuardarCVPublicaciones",
//        type: "POST",
//        data: data_post,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (respuestaJson) {
//            var respuesta = JSON.parse(respuestaJson.d);
//            if (respuesta.length == 0)
//                AgregarEnTabla($("#tabla_publicaciones"), publicacion);
//            alertify.alert("Los datos fueron guardados correctamente");
//            $(".modal_close_concursar").click();
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alertify.alert(errorThrown);
//        }
//    });
//}


//var AgregarMatricula = function () {

//    var matricula = {};
//    matricula.numero = $("#matricula_numero").val();
//    matricula.expedidapor = $("#matricula_expedida_por").val();
//    matricula.fechaInscripcion = ParsearFecha($("#matricula_fecha_inscripcion").val());
//    matricula.situacionActual = $("#matricula_situacion").val();

//    var data_post = JSON.stringify({
//        "matriculas_nuevas": matricula,
//        "matriculas_originales": matricula
//    });
//    $.ajax({
//        url: "../AjaxWS.asmx/GuardarCVMatriculas",
//        type: "POST",
//        data: data_post,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (respuestaJson) {
//            var respuesta = JSON.parse(respuestaJson.d);
//            if (respuesta.length == 0)
//                AgregarEnTabla($("#tabla_matriculas"), matricula);
//            alertify.alert("Los datos fueron guardados correctamente");
//            $(".modal_close_concursar").click();
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alertify.alert(errorThrown);
//        }
//    });
//}


//var AgregarInstitucionAcademica = function () {

//    var Institucion = {};
//    Institucion.institucion = $("#pertenencia-institucion_nombre").val();
//    Institucion.caracterEntidad = $("#pertenencia-institucion_caracter").val();
//    Institucion.cargosDesempeniados = $("#pertenencia-institucion_cargo").val();

//    Institucion.numeroAfiliado = $("#pertenencia-institucion_numero_afiliado").val();
//    Institucion.categoriaActual = $("#pertenencia-institucion_categoria_actual").val();
//    Institucion.fechaDeAfiliacion = ParsearFecha($("#pertenencia-institucion_fecha_afiliacion").val());
//    Institucion.fecha = ParsearFecha($("#pertenencia-institucion_fecha").val());
//    Institucion.fechaInicio = ParsearFecha($("#pertenencia-institucion_fecha_inicio").val());
//    Institucion.fechaFin = ParsearFecha($("#pertenencia-institucion_fecha_fin").val());
//    Institucion.localidad = $("#pertenencia-institucion_localidad").val();
//    Institucion.pais = $("#pertenencia-institucion_pais").val();

//    var data_post = JSON.stringify({
//        "instituciones_nuevas": Institucion,
//        "instituciones_originales": Institucion
//    });
//    $.ajax({
//        url: "../AjaxWS.asmx/GuardarCVInstituciones",
//        type: "POST",
//        data: data_post,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (respuestaJson) {
//            var respuesta = JSON.parse(respuestaJson.d);
//            if (respuesta.length == 0)
//                AgregarEnTabla($("#tabla_instituciones_academicas"), Institucion);
//            alertify.alert("Los datos fueron guardados correctamente");
//            $(".modal_close_concursar").click();
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alertify.alert(errorThrown);
//        }
//    });
//}





//var AgregarExperiencia = function () {

//    var experiencia = {};
//    experiencia.puestoOcupado = $("#experiencia-laboral_puesto").val();
//    experiencia.motivoDesvinculacion = $("#experiencia-laboral_motivo_desvinculacion").val();
//    experiencia.nombreEmpleador = $("#experiencia-laboral_empleador").val();
//    experiencia.fechaInicio = ParsearFecha($("#experiencia-laboral_fecha_inicio").val());
//    experiencia.fechaFin = ParsearFecha($("#experiencia-laboral_fecha_fin").val());
//    experiencia.localidad = $("#experiencia-laboral_localidad").val();

//    experiencia.pais = $("#experiencia-laboral_pais").val();
//    experiencia.personasACargo = $("#experiencia-laboral_personal_a_cargo").val();
//    experiencia.tipoEmpresa = $("#experiencia-laboral_tipo_empresa").val();
//    experiencia.actividad = $("#experiencia-laboral_sector").val();


//    var data_post = JSON.stringify({
//        "experiencias_nuevas": experiencia,
//        "experiencias_originales": experiencia
//    });
//    $.ajax({
//        url: "../AjaxWS.asmx/GuardarCVExperiencias",
//        type: "POST",
//        data: data_post,
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function (respuestaJson) {
//            var respuesta = JSON.parse(respuestaJson.d);
//            if (respuesta.length == 0)
//                AgregarEnTabla($("#tabla_experiencia_laboral"), experiencia);
//            alertify.alert("Los datos fueron guardados correctamente");
//            $(".modal_close_concursar").click();
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            alertify.alert(errorThrown);
//        }
//    });
//}



var AgregarEnTabla = function (tabla, datos) {

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

