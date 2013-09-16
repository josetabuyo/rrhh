var AdministradorPlanilla = function () {
    var _this = this;
    var contenedor_grilla = $('#ContenedorPlanilla');
    _this.contenedorPlanilla = {};
    var planilla = {};
    var alumnos = {};
    var diasCursados = {};
    var detalle_asistencias = {};
    var horasCatedra = {};
    var filas = [];
    var generar_filas = function () {
        var rows = [];
        for (var i = 0; i < alumnos.length; i++) {
            var row = { Alumno: {}, DetalleAsistencias: [], AsistenciasPeriodo: '', InasistenciasPeriodo: '' }
            var cols = [];
            row.Alumno = { html: alumnos[i].Nombre + ' ' + alumnos[i].Apellido };
            for (var j = 0; j < diasCursados.length; j++) {
                //AcumuladorDto
                var asistencia = Enumerable.From(detalle_asistencias.Asistencias)
                .Where(function (x) { return x.Fecha == diasCursados[j].Fecha && x.IdAlumno == alumnos[i].id });
                if (asistencia.length > 0)
                    row.DetalleAsistencias.push(new BotonAsistencia(alumnos[i].Id, diasCursados[j].Fecha, asistencia.First().Valor, diasCursados[j].HorasCatedra));
                else
                    row.DetalleAsistencias.push(new BotonAsistencia(alumnos[i].Id, diasCursados[j].Fecha, '', diasCursados[j].HorasCatedra));
            }
            var detalle_asistencias_acumuladas = Enumerable.From(detalle_asistencias.Asistencias)
                .Where(function (x) { return x.IdAlumno == alumnos[i].id });
            if (detalle_asistencias_acumuladas.length > 0) {
                row.AsistenciasPeriodo = detalle_asistencias_acumuladas.First().AsistenciasPeriodo;
                row.InasistenciasPeriodo = detalle_asistencias_acumuladas.First().InAsistenciasPeriodo;
            } else {

                row.AsistenciasPeriodo = '';
                row.InasistenciasPeriodo = '';
            }
            rows.push(row);
        }
        filas = rows;
    }
    _this.cargar_asistencias = function (id_curso, fecha_desde, fecha_hasta) {
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
                alumnos = respuesta.Alumnos;
                diasCursados = respuesta.FechasDeCursada;
                detalle_asistencias = respuesta.DetalleAsistenciasPorAlumno;
                horasCatedra = respuesta.HorasCatedra;

                generar_filas(respuesta);
                _this.dibujar_planilla();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
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
        /*
        columnas.push(new Columna("Asistencias <br>acumuladas", { generar: function (asistenciaalumno) { return '<label class="acumuladas">' + asistenciaalumno.asistencias_acumuladas + " (" + asistenciaalumno.por_asistencias_acumuladas + ")</label>" } }));
        columnas.push(new Columna("Inasistencias <br>acumuladas", { generar: function (asistenciaalumno) { return '<label class="acumuladas">' + asistenciaalumno.inasistencias_acumuladas + " (" + asistenciaalumno.por_inasistencias_acumuladas + ")</label>" } }));
        */

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