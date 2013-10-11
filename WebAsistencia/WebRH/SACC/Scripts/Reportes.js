var PaginaReporteAlumnos = function (options) {
    this.o = options;
    var _this = this;

    this.o.botonModalidad.click(function () {
        _this.BuscarPorModalidad();
    });


    this.o.planillaAlumnosDisponibles = new Grilla(
        [
            new Columna("Documento", { generar: function (un_alumno) { return un_alumno.Documento; } }),
			new Columna("Nombre", { generar: function (un_alumno) { return un_alumno.Nombre; } }),
			new Columna("Apellido", { generar: function (un_alumno) { return un_alumno.Apellido; } }),
			new Columna("Modalidad", { generar: function (un_alumno) { return un_alumno.Modalidad.Descripcion; } })
		]);


    
    //this.o.planillaAlumnosDisponibles.DibujarEn(this.o.contenedorAlumnosDisponibles);

    //this.completarcombosDeCursos();
    //this.completarCombosDeModalidad();
};



PaginaReporteAlumnos.prototype.BuscarPorModalidad = function () {
    var data_post = JSON.stringify({
        fecha_desde: $("#idFechaDesde").val(),
        fecha_hasta: $("#idFechaHasta").val()
    });
    _this = this;
    $.ajax({
        url: "../AjaxWS.asmx/ReporteAlumnosDeCursosConFecha",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);

            // $("#alumnosJSON").val(respuesta);
            _this.o.planillaAlumnosDisponibles.AgregarEstilo("tabla_macc");
            _this.o.planillaAlumnosDisponibles.CargarObjetos(respuesta);
            _this.o.planillaAlumnosDisponibles.DibujarEn(_this.o.contenedorAlumnosDisponibles);

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
};



PaginaReporteAlumnos.prototype.BuscarPorOrganismo = function () {

    _this = this;
    $.ajax({
        url: "../AjaxWS.asmx/ReporteAlumnosPorOrganismo",
        type: "POST",
        data: "",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);

            _this.o.planillaAlumnosDisponibles.AgregarEstilo("tabla_macc");
            _this.o.planillaAlumnosDisponibles.CargarObjetos(respuesta);
            _this.o.planillaAlumnosDisponibles.DibujarEn(_this.o.contenedorAlumnosDisponibles);

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
};



//PaginaReporteAlumnos.prototype.completarCombosDeModalidad = function () {

//		_this = this;
//        this.o.cmbCiclo.change(function (e) {
//            var cicloSeleccionado = _this.o.cmbCiclo.find('option:selected').val();
//            if (cicloSeleccionado == -1) {
//                _this.o.cmbCursos.empty();
//                for (var i = 0; i < _this.o.cursosJSON.length; i++) {
//                    var curso = _this.o.cursosJSON[i];
//                    var listItem = $('<option>');
//                    // alert(JSON.stringify(curso));
//                    listItem.val(curso.Id);
//                    listItem.text(curso.Nombre);
//                    _this.o.cmbCursos.append(listItem);
//                }
//                return;
//            }

//            var queryResult = Enumerable.From(_this.o.cursosJSON)
//                    .Where(function (x) { return x.Materia.Ciclo.Id == cicloSeleccionado }).ToArray();

//            _this.o.cmbCursos.empty();

//            for (var i = 0; i < queryResult.length; i++) {
//                var curso = queryResult[i];
//                var listItem = $('<option>');
//                // alert(JSON.stringify(curso));
//                listItem.val(curso.Id);
//                listItem.text(curso.Nombre);
//                _this.o.cmbCursos.append(listItem);
//            }

//            _this.o.cmbCursos.change();
//        });
//    };

//    PaginaReporteAlumnos.prototype.completarcombosDeCursos = function () {
//        this.o.idCursoSeleccionado.val("");

//        for (var i = 0; i < this.o.cursosJSON.length; i++) {
//            var curso = this.o.cursosJSON[i];
//            var listItem = $('<option>');
//            // alert(JSON.stringify(curso));
//            listItem.val(curso.Id);
//            listItem.text(curso.Nombre);
//            this.o.cmbCursos.append(listItem);
//        }
//		_this = this;
//        this.o.cmbCursos.change(function (e) {
//            var idSeleccionado = _this.o.cmbCursos.find('option:selected').val();
//            _this.o.idCursoSeleccionado.val(idSeleccionado);

//            var cursoSeleccionado;
//            for (var i = 0; i < _this.o.cursosJSON.length; i++) {
//                var curso = _this.o.cursosJSON[i];
//                if (curso.Id == idSeleccionado) cursoSeleccionado = curso;
//            }
//            if (cursoSeleccionado !== undefined) {

//                var queryResult = Enumerable.From(_this.o.alumnos)
//                                          .Where(function (x) { return x.Modalidad.Id == cursoSeleccionado.Materia.Modalidad.Id }).ToArray();

//                _this.o.planillaAlumnosAsignados.BorrarContenido();
//                _this.o.planillaAlumnosAsignados.CargarObjetos(cursoSeleccionado.Alumnos);
//                _this.o.planillaAlumnosAsignados.DibujarEn(_this.o.contenedorAlumnosAsignados);
//                _this.o.alumnosEnGrillaParaInscribir.val(JSON.stringify(_this.o.planillaAlumnosAsignados.Objetos));
//                //$("#descripcionCursoSeleccionado").text(cursoSeleccionado.nombre);
//                _this.o.mensaje.text("");
//                $("#nombreDeCurso").text(cursoSeleccionado.Nombre);
//                _this.MostrarAlumnosQueNoEstanEnElCursoSeleccionado(cursoSeleccionado, queryResult);

//            }
//            else {

//            }

//            //Estilos para ver coloreada la grilla en Internet Explorer
//            $("tbody tr:even").css('background-color', '#E6E6FA');
//            $("tbody tr:odd").css('background-color', '#9CB3D6 ');
//        });

//    };

//    PaginaReporteAlumnos.prototype.AsignarAlumno = function () {
//        if (!this.o.planillaAlumnosAsignados.ContieneElemento(this.o.alumnoGlobal)) {
//            this.o.planillaAlumnosDisponibles.QuitarObjeto(this.o.contenedorAlumnosDisponibles, this.o.alumnoGlobal);
//            this.o.planillaAlumnosAsignados.CargarObjeto(this.o.alumnoGlobal);
//            this.o.planillaAlumnosAsignados.DibujarEn(this.o.contenedorAlumnosAsignados);
//            this.o.alumnoGlobal = null;
//            this.o.alumnosEnGrillaParaInscribir.val(JSON.stringify(this.o.planillaAlumnosAsignados.Objetos));
//            this.o.mensaje.text("Agregado al Curso");
//        }
//        else {
//            this.o.mensaje.text("Existe en el Curso");
//        }
//    };

//    PaginaReporteAlumnos.prototype.DesasignarAlumno = function () {
//        if (!this.o.planillaAlumnosDisponibles.ContieneElemento(this.o.alumnoGlobal)) {
//            this.o.planillaAlumnosAsignados.QuitarObjeto(this.o.contenedorAlumnosAsignados, this.o.alumnoGlobal);
//            this.o.planillaAlumnosDisponibles.CargarObjeto(this.o.alumnoGlobal);
//            this.o.planillaAlumnosDisponibles.DibujarEn(this.o.contenedorAlumnosDisponibles);
//            this.o.alumnoGlobal = null;
//            this.o.alumnosEnGrillaParaInscribir.val(JSON.stringify(this.o.planillaAlumnosAsignados.Objetos));
//            this.o.mensaje.text("Quitado del Curso");
//        }
//        else {
//            this.o.mensaje.text("Existe en el Curso");
//        }
//    };

//    PaginaReporteAlumnos.prototype.MostrarAlumnosQueNoEstanEnElCursoSeleccionado = function (cursoSeleccionado, query_alumnos_modalidad) {
//        this.o.planillaAlumnosDisponibles.BorrarContenido();
//        this.o.planillaAlumnosDisponibles.CargarObjetos(query_alumnos_modalidad);
//        var alumnos_filtrados_curso = this.o.planillaAlumnosDisponibles.QuitarObjetosExistentes(cursoSeleccionado.Alumnos);
//        this.o.planillaAlumnosDisponibles.BorrarContenido();
//        this.o.planillaAlumnosDisponibles.CargarObjetos(alumnos_filtrados_curso);
//    };

//    PaginaReporteAlumnos.prototype.InscribirAlumnos = function () {
//        var data_post = JSON.stringify({
//            alumnos: JSON.stringify(this.o.planillaAlumnosAsignados.Objetos),
//            id_curso: $("#idCursoSeleccionado").val()
//        });
//		_this = this;
//        $.ajax({
//            url: "../AjaxWS.asmx/InscribirAlumnos",
//            type: "POST",
//            data: data_post,
//            //data: "{'alumnos' : '" + JSON.stringify(planillaAlumnosAsignados.Objetos) + "', 'id_curso': '" +      + " }",
//            dataType: "json",
//            contentType: "application/json; charset=utf-8",
//            success: function (respuestaJson) {
//                var respuesta = JSON.parse(respuestaJson.d);
//                if (respuesta.tipoDeRespuesta == "inscripcionAlumno.ok") {

//                    _this.GetCursosDTO();

//                    alertify.alert("Se inscribieron los alumnos correctamente");
//                }
//                if (respuesta.tipoDeRespuesta == "inscripcionAlumno.error") {
//                    alertify.alert("Error al inscribir alumnos: " + respuesta.error);
//                }


//            },
//            error: function (XMLHttpRequest, textStatus, errorThrown) {
//                alertify.alert(errorThrown);
//            }
//        });
//    };

//    PaginaReporteAlumnos.prototype.GetCursosDTO = function () {
//	_this = this;
//        $.ajax({
//            url: "../AjaxWS.asmx/GetCursosDTO",
//            type: "POST",
//            contentType: "application/json; charset=utf-8",
//            success: function (respuestaJson) {
//                var respuesta = JSON.parse(respuestaJson.d);

//                $('#cursosJSON').val(respuestaJson.d);
//                _this.o.cursosJSON = respuesta;

//                _this.completarCombosDeCiclo();

//            },
//            error: function (XMLHttpRequest, textStatus, errorThrown) {
//                alertify.alert(errorThrown);
//            }
//        });
//     };

//    
