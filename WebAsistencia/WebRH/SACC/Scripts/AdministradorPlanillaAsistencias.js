var AdministradorPlanilla = function () {
    var _this = this;

    _this.contenedorPlanilla = {};

    var contenedor_grilla = $('#ContenedorPlanilla');
    var label_horas_catedra = $('#HorasCatedraCurso');
    var label_docente = $('#Docente');
    var planilla = {};
    var alumnos = {};
    var diasCursados = {};
    var detalle_asistencias = {};
    var horasCatedra = {};
    var docente = {};
    var filas = [];
    var generar_filas = function () {
        var rows = [];
        for (var i = 0; i < alumnos.length; i++) {
            var row = { Alumno: {}, DetalleAsistencias: [], AsistenciasPeriodo: '', InasistenciasPeriodo: '' }
            var cols = [];
            row.Alumno = { html: alumnos[i].Nombre + ' ' + alumnos[i].Apellido };
            for (var j = 0; j < diasCursados.length; j++) {
                //AcumuladorDto
                for (var a = 0; a < detalle_asistencias.length; a++) {
                    var detalle_asistencia_alumno = detalle_asistencias[i];
                    var asistencia = Enumerable.From(detalle_asistencia_alumno.Asistencias)
                        .Where(function (x) {
                            return x.Fecha == diasCursados[j].Fecha && x.IdAlumno == alumnos[i].Id
                        });
                    if (asistencia.Count() > 0)
                        row.DetalleAsistencias.push(new BotonAsistencia(asistencia.First().Id, alumnos[i].Id, _this.id_curso, diasCursados[j].Fecha, asistencia.First().Valor, diasCursados[j].HorasCatedra));
                    else
                        row.DetalleAsistencias.push(new BotonAsistencia(0, alumnos[i].Id, _this.id_curso, diasCursados[j].Fecha, '', diasCursados[j].HorasCatedra));
                }
            }
            for (var a = 0; a < detalle_asistencias.length; a++) {
                var detalle_asistencia_alumno = detalle_asistencias[i];
                var detalle_asistencias_acumuladas = Enumerable.From(detalle_asistencia_alumno.Asistencias)
                .Where(function (x) { return x.IdAlumno == alumnos[i].id });
                if (detalle_asistencias_acumuladas.Count() > 0) {
                    var detalle_asistencia = detalle_asistencias_acumuladas.First();
                    row.AsistenciasPeriodo = detalle_asistencia.AsistenciasPeriodo;
                    row.InasistenciasPeriodo = detalle_asistencia.InAsistenciasPeriodo;
                    row.AsistenciasTotal = detalle_asistencia.AsistenciasTotal + " (" + ((detalle_asistencia.AsistenciasTotal / horasCatedra) * 100).toFixed(2) + "%)";
                    row.InasistenciasTotal = detalle_asistencia.InasistenciasTotal + " (" + ((detalle_asistencia.InasistenciasTotal / horasCatedra) * 100).toFixed(2) + "%)";
                } else {
                    row.AsistenciasPeriodo = '';
                    row.InasistenciasPeriodo = '';
                    row.AsistenciasTotal = '';
                    row.InasistenciasTotal = '';

                }
            }
            rows.push(row);
        }
        filas = rows;
    }

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

                generar_filas(respuesta);
                _this.dibujar_planilla();
                _this.completar_datos_curso_seleccionado();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
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
        alert(JSON.stringify(data_post));
        $.ajax({
            url: "../AjaxWS.asmx/GuardarAsistencias",
            type: "POST",
            async: false,
            data: JSON.stringify(data_post),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    }

    _this.completar_datos_curso_seleccionado = function () {
        label_docente.text(docente);
        label_horas_catedra.text(horasCatedra);
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
        columnas.push(new Columna("Inasistencias <br>del mes", { generar: function (row) { return row.InAsistenciasPeriodo } }));
        //toFixed
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