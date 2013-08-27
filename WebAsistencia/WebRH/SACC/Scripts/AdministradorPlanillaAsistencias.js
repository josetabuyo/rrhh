var AdministradorPlanillaMensual = function () {
    if ($('#PlanillaAsistencia_planillaJSON').val() != "{}" && $('#PlanillaAsistencia_planillaJSON').val() != "") {

        var Planilla = JSON.parse($('#PlanillaAsistencia_planillaJSON').val());

        var DiasCursados = Planilla['diascursados'];
        var AlumnosInasistencias = Planilla['asistenciasalumnos'];
        var contenedorPlanilla = $('#PlanillaAsistencia_ContenedorPlanilla');
        var HorasCatedraCurso = Planilla['horas_catedra'];
        var columnas = [];
        var columnas_acumuladas = [];

        columnas.push(new Columna("Apellido y Nombre", { generar: function (inasistenciaalumno) { return inasistenciaalumno.nombrealumno } }));
        if (DiasCursados) {
            for (var i = 0; i < DiasCursados.length; i++) {
                columnas.push(new Columna(DiasCursados[i].nombre_dia + "/" + DiasCursados[i].dia + "<br/>" + DiasCursados[i].horas + " hs",
                                        new GeneradorCeldaDiaCursado(DiasCursados[i])));
            }
        }
        columnas.push(new Columna("Asistencias <br>del mes", { generar: function (inasistenciaalumno) { return inasistenciaalumno.asistencias } }));
        columnas.push(new Columna("Inasistencias <br>del mes", { generar: function (inasistenciaalumno) { return inasistenciaalumno.inasistencias } }));

        columnas.push(new Columna("Asistencias <br>acumuladas", { generar: function (inasistenciaalumno) { return '<label class="acumuladas">' + inasistenciaalumno.asistencias_acumuladas + " (" + inasistenciaalumno.por_asistencias_acumuladas + ")</label>" } }));
        columnas.push(new Columna("Inasistencias <br>acumuladas", { generar: function (inasistenciaalumno) { return '<label class="acumuladas">' + inasistenciaalumno.inasistencias_acumuladas + " (" + inasistenciaalumno.por_inasistencias_acumuladas + ")</label>" } }));

        var PlanillaMensual = new Grilla(columnas);

        PlanillaMensual.AgregarEstilo("tabla_macc");
        PlanillaMensual.CargarObjetos(AlumnosInasistencias);
        PlanillaMensual.DibujarEn(contenedorPlanilla);
        PlanillaMensual.SetOnRowClickEventHandler(function () {
            return true;
        });
        var Docente = JSON.parse($("#PlanillaAsistencia_Curso").val()).Docente;

        $("#Docente").text(Docente.Nombre + " " + Docente.Apellido);
        $("#HorasCatedraCurso").text(HorasCatedraCurso);

        var Observaciones = JSON.parse($("#PlanillaAsistencia_Curso").val()).Observaciones;

        $("#TxtObservaciones").val(Observaciones);

    }
    else {
        $("#lblDocente").css("visibility", "hidden");
        $("#lblHorasCurso").css("visibility", "hidden");
        $("#BtnGuardar").css("visibility", "hidden");
        $("#BtnImprimir").css("visibility", "hidden");
        $("#TxtObservaciones").css("visibility", "hidden");
    }
};

var GeneradorCeldaDiaCursado = function (diaCursado) {
    var self = this;
    self.diaCursado = diaCursado;
    self.generar = function (inasistenciaalumno) {
        var contenedorAcciones = $('<div>');

        var queryResult = Enumerable.From(inasistenciaalumno.detalle_asistencia)
                .Where(function (x) { return x.fecha == diaCursado.fecha });

        var botonAsistencia;
        if (queryResult.Count() > 0) {
            var valor = queryResult.First().valor;
//            if (valor == 5)
//                valor = "AUSENTE";
//            if (valor == 6)
//                valor = "NO_CURSADO";
            botonAsistencia = new BotonAsistencia(inasistenciaalumno.id, diaCursado.fecha, valor, diaCursado.horas);
        }
        else {
            botonAsistencia = new BotonAsistencia(inasistenciaalumno.id, diaCursado.fecha, 0, diaCursado.horas);
        }
        contenedorAcciones.append(botonAsistencia.html);

        return contenedorAcciones;
    };
}