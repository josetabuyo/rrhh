var AdministradorPlanilla = function () {
    var _this = this;

    _this.contenedorPlanilla = {};
    var planilla = {};
    var alumnos = {};
    var diasCursados = {};
    var asistencias = {};
    var horasCatedra = {};
    var columnas = [];

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
                diasCursados = respuesta.HorariosDeCursada;
                asistencias = respuesta.DetalleAsistenciasPorAlumno;
                horasCatedra = respuesta.HorasCatedra;
                _this.dibujar_planilla();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    }

    _this.dibujar_planilla = function () {

        columnas.push(new Columna("Apellido y Nombre", { generar: function (asistencia) { return asistencia.alumno.nombrealumno } }));
        for (var i = 0; i < diasCursados.length; i++) {
            columnas.push(new Columna(DiasCursados[i].nombre_dia + "/" + DiasCursados[i].dia + "<br/>" + DiasCursados[i].horas + " hs",
                                        new GeneradorCeldaDiaCursado(DiasCursados[i])));
        }

        columnas.push(new Columna("Asistencias <br>del mes", { generar: function (asistenciaalumno) { return asistenciaalumno.asistencias } }));
        columnas.push(new Columna("Inasistencias <br>del mes", { generar: function (asistenciaalumno) { return iasistenciaalumno.inasistencias } }));

        columnas.push(new Columna("Asistencias <br>acumuladas", { generar: function (asistenciaalumno) { return '<label class="acumuladas">' + asistenciaalumno.asistencias_acumuladas + " (" + asistenciaalumno.por_asistencias_acumuladas + ")</label>" } }));
        columnas.push(new Columna("Inasistencias <br>acumuladas", { generar: function (asistenciaalumno) { return '<label class="acumuladas">' + asistenciaalumno.inasistencias_acumuladas + " (" + asistenciaalumno.por_inasistencias_acumuladas + ")</label>" } }));


        var grilla = new Grilla(columnas);

        grilla.AgregarEstilo("tabla_macc");

        grilla.SetOnRowClickEventHandler(function () {
            return true;
        });
        grilla.CargarObjetos(planilla);
        grilla.DibujarEn(contenedor_grilla);
    }

    var GeneradorCeldaDiaCursado = function (diaCursado) {
        var self = this;
        self.diaCursado = diaCursado;
        self.generar = function (inasistenciaalumno) {
            var contenedorAcciones = $('<div>');

            var queryResult = Enumerable.From(asistenciaalumno.detalle_asistencia)
                .Where(function (x) { return x.fecha == diaCursado.fecha });

            var botonAsistencia;
            if (queryResult.Count() > 0) {
                botonAsistencia = new CrearBotonAsistencia(inasistenciaalumno.id, diaCursado.fecha, queryResult.First().valor, diaCursado.horas);
            }
            else {
                botonAsistencia = new CrearBotonAsistencia(inasistenciaalumno.id, diaCursado.fecha, 0, diaCursado.horas);
            }
            contenedorAcciones.append(botonAsistencia);

            return contenedorAcciones;
        };
    }

}