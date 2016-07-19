var FichaAlumno = function (options) {
    this.o = options;
    var _this = this;
    //this.btnAsignar = options.botonAsignarAlumno;	
    //this.btnDesAsignar = options.botonDesAsignarAlumno;
    //this.btnInscribir = options.botonGuardarInscriptos;

    this.o.ficha_nombre.html(this.o.alumno.Apellido + ", " + this.o.alumno.Nombre);
    this.o.ficha_oficina.html(this.o.alumno.Areas[0].Nombre);
    this.o.ficha_dni.html(this.o.alumno.Documento);
    this.o.ficha_telefono.html(this.o.alumno.Telefono);
    this.o.ficha_perfil.html('Alumno');
    this.o.ficha_modalidad.html(this.o.alumno.Modalidad.Descripcion);
    this.o.ficha_celular.html(this.o.alumno.Celular);
    this.o.ficha_estado.html(this.o.alumno.EstadoDeAlumno);
    this.o.ficha_mail.html(this.o.alumno.Mail);
    this.o.ficha_aniocursado.html(this.o.alumno.CicloCursado);
    this.o.ficha_direccion.html(this.o.alumno.Direccion);
    this.o.ficha_tutor.html(this.o.alumno.Tutor);
    this.o.ficha_fecha_nac.html(this.o.alumno.FechaDeNacimiento);
    this.o.ficha_ingreso.html(this.o.alumno.FechaDeIngreso);


    this.o.PlanillaCursos = new Grilla(
        [
            new Columna("Materia", { generar: function (un_curso) { return un_curso.Materia.Nombre } }),
            new Columna("Ciclo", { generar: function (un_curso) { return un_curso.Materia.Ciclo.Nombre } }),
            new Columna("Docente", { generar: function (un_curso) { return un_curso.Docente.Nombre } }),
            new Columna("Espacio Fisico", { generar: function (un_curso) { return un_curso.EspacioFisico.Edificio.Nombre } }),
            new Columna("Horario", { generar: function (un_curso) {
                var horario = $.map(un_curso.Horarios, function (val, index) {
                    return val.Dia.substring(0, 3) + " " + val.HoraDeInicio + " - " + val.HoraDeFin;
                }).join("<br>"); return horario;
            }
            }),
            new Columna("Estado", { generar: function (un_curso) { return un_curso.EstadoDelAlumno } }),
            new Columna("Fecha Inicio", { generar: function (un_curso) { return un_curso.FechaInicio } }),
            new Columna("Fecha Fin", { generar: function (un_curso) { return un_curso.FechaFin } })
		]);

    //		this.o.planillaAlumnosDisponibles.SetOnRowClickEventHandler(function (un_alumno) {
    //			_this.o.alumnoGlobal = un_alumno;
        //});

    this.o.PlanillaAsistencias = new Grilla(
    [
        new Columna("Materia", { generar: function (asistencia) { return asistencia.Materia } }),
        new Columna("Ciclo", { generar: function (asistencia) { return asistencia.Ciclo } }),
        new Columna("Asistencia", { generar: function (asistencia) { return asistencia.AsistenciasTotal + _this.ValorPorcentaje(asistencia.AsistenciasTotal, asistencia.TotalHorasCatedra)  } }),
        new Columna("Inasistencia", { generar: function (asistencia) { return asistencia.InasistenciasTotal +  _this.ValorPorcentaje(asistencia.InasistenciasTotal, asistencia.TotalHorasCatedra)  } }),
        new Columna("Sin Cursar", { generar: function (asistencia) { return asistencia.DiasSinCursarTotal +  _this.ValorPorcentaje(asistencia.DiasSinCursarTotal, asistencia.TotalHorasCatedra)  } }),
        new Columna("Fecha Inicio", { generar: function (asistencia) { return asistencia.FechaInicio } }),
        new Columna("Fecha Fin", { generar: function (asistencia) { return asistencia.FechaFin } })

	]);

    this.o.PlanillaAsistencias.SetOnRowClickEventHandler(function (asistencia) {
        //_this.o.alumnoGlobal = un_alumno;
        _this.CompletarDetalleAsistencias(asistencia);
    });

    this.o.PlanillaEvaluaciones = new Grilla(
        [
            new Columna("Materia", { generar: function (evaluacion) { return evaluacion.Materia } }),
            new Columna("Ciclo", { generar: function (evaluacion) { return evaluacion.Ciclo } }),
            new Columna("Docente", { generar: function (evaluacion) { return evaluacion.Docente } }),
            new Columna("Estado", { generar: function (evaluacion) { return evaluacion.Estado } }),
            new Columna("Calificaci&oacute;n General", { generar: function (evaluacion) { return evaluacion.CalificacionFinal } }),
            new Columna("Fecha Fin", { generar: function (evaluacion) { return evaluacion.FechaFin } })
		]);

    this.o.PlanillaEvaluaciones.SetOnRowClickEventHandler(function (evaluacion) {
        //_this.o.alumnoGlobal = un_alumno;
        _this.CompletarDetalleEvaluaciones(evaluacion);
    });


    this.o.PlanillaCursos.AgregarEstilo("tabla_macc");
    this.o.PlanillaEvaluaciones.AgregarEstilo("tabla_macc");
    this.o.PlanillaCursos.CargarObjetos(this.o.cursos_inscriptos);
    this.o.PlanillaCursos.DibujarEn(this.o.contenedorPlanillaCursos);
    this.o.PlanillaAsistencias.CargarObjetos(this.o.asistencias_por_curso);
    this.o.PlanillaAsistencias.DibujarEn(this.o.contenedorPlanillaAsistencias);
    this.o.PlanillaEvaluaciones.CargarObjetos(this.o.evaluaciones_por_curso);
    this.o.PlanillaEvaluaciones.DibujarEn(this.o.contenedorPlanillaEvaluaciones);

    //this.completarcombosDeCursos();
    //this.completarCombosDeCiclo();

}

FichaAlumno.prototype.ValorPorcentaje = function (asistencia, horasCatedra) {
    return " (" + ((asistencia / horasCatedra) * 100).toFixed(2) + "%)";
}


FichaAlumno.prototype.CompletarDetalleAsistencias = function (asistenciasDTO) {
//    _this = this;
//    //var contenedorPlanillaEvaluacionesDetalle = $('#ContenedorPlanillaEvaluacionesDetalle');
//    _this.o.contenedorPlanillaAsistenciasDetalle.html("");
//    //_this.o.sub_eval_2.html("Asistencias del Curso");
//    //_this.o.sub_eval_2.attr("class", "sub_eval");
//    //$("#sub_eval_2").html("Notas del Curso");

//    _this.o.PlanillaAsistenciasDetalle = new Grilla(
//        [
//            new Columna("Asistencia", { generar: function (asistenciasDTO) { return asistencias_por_curso.AsistenciasTotal } }),
//            new Columna("Cantidad de d&iacute;as", { generar: function (asistenciasDTO) { return asistenciasDTO.Fecha } }),
//            new Columna("Porcentaje", { generar: function (asistenciasDTO) { return asistenciasDTO.Calificacion } })
//		]);

//    // var columnas = [];
//    var asistenciasDTO = evaluacion.Evaluaciones;
//    // columnas.push(new Columna("Instancia", { generar: function (evaluacionDTO) { return evaluacionDTO.DescripcionInstancia } }));
//    // columnas.push(new Columna("Fecha De Rendici&oacute;n", { generar: function (evaluacionDTO) { return evaluacionDTO.Fecha } }));
//    // columnas.push(new Columna("Calificac&oacute;n", { generar: function (evaluacionDTO) { return evaluacionDTO.Calificacion } }));

//    //PlanillaEvaluacionesDetalle = new Grilla(columnas);

//    _this.o.PlanillaAsistenciasDetalle.AgregarEstilo("tabla_macc");
//    _this.o.PlanillaAsistenciasDetalle.CargarObjetos(evaluacionDTO);
//    _this.o.PlanillaAsistenciasDetalle.DibujarEn(_this.o.contenedorPlanillaAsistenciasDetalle);

//    //Estilos para ver coloreada la grilla en Internet Explorer
//    $("tbody tr:even").css('background-color', '#E6E6FA');
//    $("tbody tr:odd").css('background-color', '#9CB3D6 ');

    return;
}

FichaAlumno.prototype.CompletarDetalleEvaluaciones = function (evaluacion) {
    _this = this;
    //var contenedorPlanillaEvaluacionesDetalle = $('#ContenedorPlanillaEvaluacionesDetalle');
    _this.o.contenedorPlanillaEvaluacionesDetalle.html("");
    _this.o.sub_eval_2.html("Notas del Curso");
    _this.o.sub_eval_2.attr("class", "sub_eval");
    //$("#sub_eval_2").html("Notas del Curso");

    _this.o.PlanillaEvaluacionesDetalle = new Grilla(
        [
            new Columna("Instancia", { generar: function (evaluacionDTO) { return evaluacionDTO.DescripcionInstancia } }),
            new Columna("Fecha De Rendici&oacute;n", { generar: function (evaluacionDTO) { return evaluacionDTO.Fecha } }),
            new Columna("Calificac&oacute;n", { generar: function (evaluacionDTO) { return evaluacionDTO.Calificacion } })
		]);

    // var columnas = [];
    var evaluacionDTO = evaluacion.Evaluaciones;
    // columnas.push(new Columna("Instancia", { generar: function (evaluacionDTO) { return evaluacionDTO.DescripcionInstancia } }));
    // columnas.push(new Columna("Fecha De Rendici&oacute;n", { generar: function (evaluacionDTO) { return evaluacionDTO.Fecha } }));
    // columnas.push(new Columna("Calificac&oacute;n", { generar: function (evaluacionDTO) { return evaluacionDTO.Calificacion } }));

    //PlanillaEvaluacionesDetalle = new Grilla(columnas);

    _this.o.PlanillaEvaluacionesDetalle.AgregarEstilo("tabla_macc");
    _this.o.PlanillaEvaluacionesDetalle.CargarObjetos(evaluacionDTO);
    _this.o.PlanillaEvaluacionesDetalle.DibujarEn(_this.o.contenedorPlanillaEvaluacionesDetalle);

    //Estilos para ver coloreada la grilla en Internet Explorer
    $("tbody tr:even").css('background-color', '#E6E6FA');
    $("tbody tr:odd").css('background-color', '#9CB3D6 ');

    return;
}
    
