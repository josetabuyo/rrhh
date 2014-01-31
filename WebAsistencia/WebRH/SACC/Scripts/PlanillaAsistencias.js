var PlanillaAsistencia = function (curso) {
    var _this = this;

    _this.contenedorPlanilla = {};
    var contenedor_grilla = $('#ContenedorPlanilla');
    var label_horas_catedra = $('#HorasCatedraCurso');
    var label_docente = $('#Docente');
    var txt_observaciones = $('#TxtObservaciones');

    var planilla = {};
    var alumnos = {};
    var diasCursados = {};
    var detalle_asistencias = {};
    var horasCatedra = {};
    var docente = {};
    var filas = [];

    _this.cargar_asistencias = function (id_curso, fecha_desde, fecha_hasta) {
        _this.id_curso = id_curso;
        var data_post = { id_curso: id_curso, fecha_desde: fecha_desde, fecha_hasta: fecha_hasta };
        $.ajax({
            url: "../AjaxWS.asmx/GetPlanillaAsistencias",
            type: "POST",
            async: false,
            data: JSON.stringify(data_post),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                planilla = respuesta;
                docente = respuesta.Docente;
                alumnos = respuesta.Alumnos;
                diasCursados = respuesta.FechasDeCursada;
                detalle_asistencias = respuesta.DetalleAsistenciasPorAlumno;
                horasCatedra = respuesta.HorasCatedra;
                observaciones = respuesta.Observaciones;
                generar_filas(respuesta);
                _this.dibujar_planilla();
                _this.completar_datos_curso_seleccionado();
                _this.mostrar_botones();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    }


    _this.mostrar_panel_detalle_curso = function () {
        $("#DatosCurso").css("visibility", "visible");
    }

    _this.ocultar_panel_detalle_curso = function () {
        $("#DatosCurso").css("visibility", "hidden");
    }

    _this.mostrar_botones = function () {
        $("#DivBotonesObservacion").css("visibility", "visible");
    }

    _this.ocultar_botones = function () {
        $("#DivBotonesObservacion").css("visibility", "hidden");
    }

    _this.guardar_asistencias = function () {
        var data_post = {};
        var asistencias_nuevas = [];
        var asistencias_originales = [];
        for (var i = 0; i < filas.length; i++) {
            var detalle_asistencia = filas[i].DetalleAsistencias;
            for (var j = 0; j < detalle_asistencia.length; j++) {
                asistencias_nuevas.push({
                    Id: detalle_asistencia[j].id,
                    IdAlumno: detalle_asistencia[j].id_alumno,
                    IdCurso: _this.id_curso,
                    Fecha: detalle_asistencia[j].dia_cursado,
                    Valor: detalle_asistencia[j].valor
                });
                asistencias_originales.push({
                    Id: detalle_asistencia[j].id,
                    IdAlumno: detalle_asistencia[j].id_alumno,
                    IdCurso: _this.id_curso,
                    Fecha: detalle_asistencia[j].dia_cursado,
                    Valor: detalle_asistencia[j].valor_original
                });
            }
        }
        data_post = {
            asistencias_nuevas: JSON.stringify(asistencias_nuevas),
            asistencias_originales: JSON.stringify(asistencias_originales)
        };

        $.ajax({
            url: "../AjaxWS.asmx/GuardarAsistencias",
            type: "POST",
            async: false,
            data: JSON.stringify(data_post),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                alertify.alert("Los cambios se guardaron satisfactoriamente");
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    }

    _this.completar_datos_curso_seleccionado = function () {
        label_docente.text(docente);
        label_horas_catedra.text(horasCatedra);
        txt_observaciones.text(observaciones);

    }
    _this.dibujar_planilla = function () {
        contenedor_grilla.html("");
        var columnas = [];
        columnas.push(new Columna("Apellido y Nombre", { generar: function (row) { return row.Alumno.html } }));
        for (var i = 0; i < diasCursados.length; i++) {
            columnas.push(new Columna(diasCursados[i].NombreDia + "/" + diasCursados[i].Dia + "<br/>" + diasCursados[i].HorasCatedra + " hs",
                                        new GeneradorCeldaDiaCursado(diasCursados[i])));
        }

        columnas.push(new Columna("Asistencias <br>del mes", { generar: function (row) { return row.AsistenciasPeriodo } }));
        columnas.push(new Columna("Inasistencias <br>del mes", { generar: function (row) { return row.InasistenciasPeriodo } }));

        columnas.push(new Columna("Asistencias <br>acumuladas", { generar: function (row) { return '<label class="acumuladas">' + row.AsistenciasTotal + "</label>" } }));
        columnas.push(new Columna("Inasistencias <br>acumuladas", { generar: function (row) { return '<label class="acumuladas">' + row.InasistenciasTotal + "</label>" } }));


        var grilla = new Grilla(columnas);

        grilla.AgregarEstilo("tabla_macc");

        grilla.SetOnRowClickEventHandler(function () {
            return true;
        });
        grilla.CargarObjetos(filas);
        grilla.DibujarEn(contenedor_grilla);
    }


    _this.imprimir_planilla = function (estilos) {
        var w = window.open();
        w.document.write(estilos);
        w.document.write("<div class='div_print'><br>Curso: " + $("#CmbCurso option:selected").text() + "<br></div>");
        w.document.write("<div class='div_print'><br>Per&iacute;odo: " + $("#CmbMes option:selected").text() + "/" + $("#CmbAnio option:selected").text() + "<br></div>");
        w.document.write("<div class='div_print'><br>Docente: " + $("#Docente").text() + "<br><br></div>");

        w.document.write(contenedor_grilla.html());
        w.print();
        w.close();
    }

    var generar_filas = function () {
        var rows = [];
        for (var i = 0; i < alumnos.length; i++) {
            var row = { Alumno: {}, DetalleAsistencias: [], AsistenciasPeriodo: '', InasistenciasPeriodo: '' }
            var cols = [];
            row.Alumno = { html: alumnos[i].Nombre + ' ' + alumnos[i].Apellido };
            var detalle_asistencia_alumno = Enumerable.From(detalle_asistencias)
                        .Where(function (x) {
                            return x.IdAlumno == alumnos[i].Id;
                        });
            for (var j = 0; j < diasCursados.length; j++) {
                var asistencia;
                if (detalle_asistencia_alumno.Count() > 0) {
                    asistencia = Enumerable.From(detalle_asistencia_alumno.First().Asistencias)
                        .Where(function (x) {
                            return x.Fecha == diasCursados[j].Fecha && x.IdAlumno == alumnos[i].Id
                        });
                } else {
                    asistencia = Enumerable.From({});
                }

                if (asistencia.Count() > 0)
                    row.DetalleAsistencias.push(new BotonAsistencia(asistencia.First().Id, alumnos[i].Id, _this.id_curso, diasCursados[j].Fecha, asistencia.First().Valor, diasCursados[j].HorasCatedra));
                else
                    row.DetalleAsistencias.push(new BotonAsistencia(0, alumnos[i].Id, _this.id_curso, diasCursados[j].Fecha, '', diasCursados[j].HorasCatedra));

            }

            if (detalle_asistencia_alumno.Count() > 0) {
                row.AsistenciasPeriodo = detalle_asistencia_alumno.First().AsistenciasPeriodo;
                row.InasistenciasPeriodo = detalle_asistencia_alumno.First().InasistenciasPeriodo;
                row.AsistenciasTotal = detalle_asistencia_alumno.First().AsistenciasTotal + " (" + ((detalle_asistencia_alumno.First().AsistenciasTotal / horasCatedra) * 100).toFixed(2) + "%)";
                row.InasistenciasTotal = detalle_asistencia_alumno.First().InasistenciasTotal + " (" + ((detalle_asistencia_alumno.First().InasistenciasTotal / horasCatedra) * 100).toFixed(2) + "%)";
            } else {
                row.AsistenciasPeriodo = '';
                row.InasistenciasPeriodo = '';
                row.AsistenciasTotal = '';
                row.InasistenciasTotal = '';

            }
            rows.push(row);
        }
        filas = rows;
    }

    var GeneradorCeldaDiaCursado = function (diaCursado) {
        var self = this;
        self.diaCursado = diaCursado;
        self.generar = function (row) {
            var contenedorAcciones = $('<div>');

            var queryResult = Enumerable.From(row.DetalleAsistencias)
                .Where(function (x) { return x.dia_cursado == diaCursado.Fecha });

            var botonAsistencia;
            if (queryResult.Count() > 0) {
                botonAsistencia = queryResult.First();
            }
            contenedorAcciones.append(botonAsistencia.html);
            return contenedorAcciones;
        };
    }

}