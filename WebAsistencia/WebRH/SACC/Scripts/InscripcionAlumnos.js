var PaginaInscripcionAlumnos = function (options) {
    this.o = options;
    var _this = this;
    this.btnAsignar = options.botonAsignarAlumno;
    this.btnDesAsignar = options.botonDesAsignarAlumno;
    this.btnInscribir = options.botonGuardarInscriptos;
    this.chkCursos = options.checkCurso;

    this.btnAsignar.click(function () {
        _this.AsignarAlumno();
    });

    this.btnDesAsignar.click(function () {
        _this.DesasignarAlumno();
    });

    this.btnInscribir.click(function () {
        _this.InscribirAlumnos();
    });

    this.chkCursos.change(function () {
        _this.FiltrarCursos();
    });

    this.o.planillaAlumnosDisponibles = new Grilla(
        [
            new Columna("Documento", { generar: function (un_alumno) { return un_alumno.Documento; } }),
			new Columna("Nombre", { generar: function (un_alumno) { return un_alumno.Nombre; } }),
			new Columna("Apellido", { generar: function (un_alumno) { return un_alumno.Apellido; } }),
			new Columna("Modalidad", { generar: function (un_alumno) { return un_alumno.Modalidad.Descripcion; } })
		]);

    this.o.planillaAlumnosDisponibles.SetOnRowClickEventHandler(function (un_alumno) {
        _this.o.alumnoGlobal = un_alumno;
    });

    this.o.planillaAlumnosAsignados = new Grilla(
        [
            new Columna("Documento", { generar: function (un_alumno) { return un_alumno.Documento; } }),
			new Columna("Nombre", { generar: function (un_alumno) { return un_alumno.Nombre; } }),
			new Columna("Apellido", { generar: function (un_alumno) { return un_alumno.Apellido; } }),
			new Columna("Modalidad", { generar: function (un_alumno) { return un_alumno.Modalidad.Descripcion; } })
		]);

    this.o.planillaAlumnosAsignados.SetOnRowClickEventHandler(function (un_alumno) {
        _this.o.alumnoGlobal = un_alumno;
    });


    this.o.planillaAlumnosAsignados.AgregarEstilo("tabla_macc");
    this.o.planillaAlumnosDisponibles.AgregarEstilo("tabla_macc");
    this.o.planillaAlumnosDisponibles.CargarObjetos(this.o.alumnos);
    this.o.planillaAlumnosDisponibles.DibujarEn(this.o.contenedorAlumnosDisponibles);

    this.completarcombosDeCursos();
    this.completarCombosDeCiclo();
}

PaginaInscripcionAlumnos.prototype.completarCombosDeCiclo = function () {

    _this = this;
    this.o.cmbCiclo.change(function (e) {
        var cicloSeleccionado = _this.o.cmbCiclo.find('option:selected').val();
        if (cicloSeleccionado == -1) {
            _this.o.cmbCursos.empty();
            _this.ArmarComboCurso(_this.o.cursosJSON);

            return;
        }

        var queryResult = Enumerable.From(_this.o.cursosJSON)
                    .Where(function (x) { return x.Materia.Ciclo.Id == cicloSeleccionado }).ToArray();

        _this.o.cmbCursos.empty();

        _this.ArmarComboCurso(queryResult);

        _this.o.cmbCursos.change();
    });
};

PaginaInscripcionAlumnos.prototype.ArmarComboCurso = function (cursos) {
        this.o.cmbCursos.empty();
        for (var i = 0; i < cursos.length; i++) {
            var curso = cursos[i];
            var listItem = $('<option>');
            // alert(JSON.stringify(curso));
            listItem.val(curso.Id);
            listItem.text(curso.Nombre);
            this.o.cmbCursos.append(listItem);
        }
    }

PaginaInscripcionAlumnos.prototype.ParsearFecha = function (fecha) {
    var day = parseInt(fecha.split("/")[0]);
    var month = parseInt(fecha.split("/")[1]);
    var year = parseInt(fecha.split("/")[2]);

    return new Date(year, month, day);

}

PaginaInscripcionAlumnos.prototype.FiltrarCursos = function () {
        _this = this;
            if (_this.o.checkCurso[0].checked == true) {
                var cursos_vigentes = Enumerable.From(_this.o.cursosJSON)
                .Select(function (x) { return x })
                .Where(function (x) { return _this.ParsearFecha(x.FechaFin) > new Date() })
                .ToArray();

                _this.ArmarComboCurso(cursos_vigentes);

            } else {
                _this.ArmarComboCurso(_this.o.cursosJSON);
            }
   }

    PaginaInscripcionAlumnos.prototype.completarcombosDeCursos = function () {
        this.o.idCursoSeleccionado.val("");

        this.ArmarComboCurso(this.o.cursosJSON);

		_this = this;
        this.o.cmbCursos.change(function (e) {
            var idSeleccionado = _this.o.cmbCursos.find('option:selected').val();
            _this.o.idCursoSeleccionado.val(idSeleccionado);

            var cursoSeleccionado;
            for (var i = 0; i < _this.o.cursosJSON.length; i++) {
                var curso = _this.o.cursosJSON[i];
                if (curso.Id == idSeleccionado) cursoSeleccionado = curso;
            }
            if (cursoSeleccionado !== undefined) {

                var queryResult = Enumerable.From(_this.o.alumnos)
                                          .Where(function (x) { return x.Modalidad.Id == cursoSeleccionado.Materia.Modalidad.Id }).ToArray();

                _this.o.planillaAlumnosAsignados.BorrarContenido();
                _this.o.planillaAlumnosAsignados.CargarObjetos(cursoSeleccionado.Alumnos);
                _this.o.planillaAlumnosAsignados.DibujarEn(_this.o.contenedorAlumnosAsignados);
                _this.o.alumnosEnGrillaParaInscribir.val(JSON.stringify(_this.o.planillaAlumnosAsignados.Objetos));
                //$("#descripcionCursoSeleccionado").text(cursoSeleccionado.nombre);
                _this.o.mensaje.text("");
                $("#nombreDeCurso").text(cursoSeleccionado.Nombre);
                _this.MostrarAlumnosQueNoEstanEnElCursoSeleccionado(cursoSeleccionado, queryResult);

            }
            else {

            }

            //Estilos para ver coloreada la grilla en Internet Explorer
            $("tbody tr:even").css('background-color', '#E6E6FA');
            $("tbody tr:odd").css('background-color', '#9CB3D6 ');
        });

    };

    PaginaInscripcionAlumnos.prototype.AsignarAlumno = function () {
        if (!this.o.planillaAlumnosAsignados.ContieneElemento(this.o.alumnoGlobal)) {
            this.o.planillaAlumnosDisponibles.QuitarObjeto(this.o.contenedorAlumnosDisponibles, this.o.alumnoGlobal);
            this.o.planillaAlumnosAsignados.CargarObjeto(this.o.alumnoGlobal);
            this.o.planillaAlumnosAsignados.DibujarEn(this.o.contenedorAlumnosAsignados);
            this.o.alumnoGlobal = null;
            this.o.alumnosEnGrillaParaInscribir.val(JSON.stringify(this.o.planillaAlumnosAsignados.Objetos));
            this.o.mensaje.text("Agregado al Curso");
        }
        else {
            this.o.mensaje.text("Existe en el Curso");
        }
    };

    PaginaInscripcionAlumnos.prototype.DesasignarAlumno = function () {
        if (!this.o.planillaAlumnosDisponibles.ContieneElemento(this.o.alumnoGlobal)) {
            this.o.planillaAlumnosAsignados.QuitarObjeto(this.o.contenedorAlumnosAsignados, this.o.alumnoGlobal);
            this.o.planillaAlumnosDisponibles.CargarObjeto(this.o.alumnoGlobal);
            this.o.planillaAlumnosDisponibles.DibujarEn(this.o.contenedorAlumnosDisponibles);
            this.o.alumnoGlobal = null;
            this.o.alumnosEnGrillaParaInscribir.val(JSON.stringify(this.o.planillaAlumnosAsignados.Objetos));
            this.o.mensaje.text("Quitado del Curso");
        }
        else {
            this.o.mensaje.text("Existe en el Curso");
        }
    };

    PaginaInscripcionAlumnos.prototype.MostrarAlumnosQueNoEstanEnElCursoSeleccionado = function(cursoSeleccionado, query_alumnos_modalidad) {
        this.o.planillaAlumnosDisponibles.BorrarContenido();
        this.o.planillaAlumnosDisponibles.CargarObjetos(query_alumnos_modalidad);
        var alumnos_filtrados_curso = this.o.planillaAlumnosDisponibles.QuitarObjetosExistentes(cursoSeleccionado.Alumnos);
        this.o.planillaAlumnosDisponibles.BorrarContenido();
        this.o.planillaAlumnosDisponibles.CargarObjetos(alumnos_filtrados_curso);
    };

    PaginaInscripcionAlumnos.prototype.InscribirAlumnos = function () {
        var data_post = JSON.stringify({
            alumnos: JSON.stringify(this.o.planillaAlumnosAsignados.Objetos),
            id_curso: $("#idCursoSeleccionado").val()
        });
        _this = this;
        $.ajax({
            url: "../AjaxWS.asmx/InscribirAlumnos",
            type: "POST",
            data: data_post,
            //data: "{'alumnos' : '" + JSON.stringify(planillaAlumnosAsignados.Objetos) + "', 'id_curso': '" +      + " }",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                if (respuesta.tipoDeRespuesta == "inscripcionAlumno.ok") {
                    _this.GetCursosDTO();
                    alertify.alert("Se inscribieron los alumnos correctamente");
                }
                if (respuesta.tipoDeRespuesta == "inscripcionAlumno.parcial") {
                    var mensaje = "No se pudo desinscribir a los siguientes alumnos por tener asistencias cargadas en el curso:";
                    for (var i = 0; i < respuesta.alumnos.length; i++) {
                        mensaje += "<br>" + respuesta.alumnos[i].Nombre + " " + respuesta.alumnos[i].Apellido;
                    }
                    _this.GetCursosDTO();
                    alertify.alert(mensaje);
                }
                if (respuesta.tipoDeRespuesta == "inscripcionAlumno.error") {
                    alertify.alert("Error al inscribir alumnos: " + respuesta.error);
                }


            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    };

    PaginaInscripcionAlumnos.prototype.GetCursosDTO = function () {
	_this = this;
        $.ajax({
            url: "../AjaxWS.asmx/GetCursosDTO",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);

                $('#cursosJSON').val(respuestaJson.d);
                _this.o.cursosJSON = respuesta;

                _this.completarCombosDeCiclo();

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
     };

    
