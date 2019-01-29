define(['underscore'], function (_) {


    function nombrePeriodoFrom(idPeriodo, periodos) {
        var periodo = _.find(periodos, function (each) {
            return each.id_periodo == idPeriodo;
        })
        return periodo.descripcion_periodo
    }

    function getSinGde(evals_por_periodo) {
        var evals_sin_gde = _.countBy(evals_por_periodo, function (each) {
            if (each.evaluacion.verificacion_gde.PersonaVerificadora == "") {
                return "SinGDE"
            } else {
                return "SinComite"
            }
        })
        return evals_sin_gde;
    }

    function camposSumarizadosDe(cursor, ue, evals, comites) {
        cursor.EvaluacionesPendientes += ue.DetalleEvaluados.Pendiente;
        cursor.EvaluacionesProvisorias += ue.DetalleEvaluados.Provisoria;
        var contGDE = getSinGde(evals)
        cursor.SinGDE += contGDE.SinGDE || 0; 
        cursor.SinComite += contGDE.SinComite || 0;
        cursor.Finalizado = _.filter(evals, e => e.periodo == ue.IdPeriodo && e.evaluacion.aprobacion_comite.IdComiteAprobador != 0 ).length;
        cursor.ReunionesRealizadas = _.filter(comites, function (each) { return each.Periodo.Id == ue.IdPeriodo }).length
        
    }

    //evals_por_periodo es un diccionario (usado como cache) para agrupar las evaluaciones por cada key=id_periodo
    function getEvalsPeriodo(evals_por_periodo, evals, id_periodo) {
        if (!evals_por_periodo[id_periodo]) {
            evals_por_periodo[id_periodo] = _.filter(evals, function (each) { return each.periodo == id_periodo })
        }
        return evals_por_periodo[id_periodo]
    }

    ///devuelve la lista de comites agrupadas por período
    function AgruparComitesPorPeriodo(ues, periodos, evals, comites) {

        var periodo_anterior = -1
        var result = [];
        var cursor;
        var evals_por_periodo = {}

        //corte de control por id periodo
        for (var i = 1; i < ues.length; i++) {
            if (ues[i].IdPeriodo != periodo_anterior) {
                periodo_anterior = ues[i].IdPeriodo

                var cursor = {
                        EvaluacionesPendientes: 0,
                        EvaluacionesProvisorias: 0,
                        SinGDE: 0,
                        SinComite: 0,
                        Finalizado: 0,
                        Reuniones: 0,
                        Periodo: nombrePeriodoFrom(ues[i].IdPeriodo, periodos),
                        IdPeriodo: ues[i].IdPeriodo
                    }

                var evals_periodo = getEvalsPeriodo(evals_por_periodo, evals.asignaciones, ues[i].IdPeriodo)
                camposSumarizadosDe(cursor, ues[i], evals_periodo, comites)
                result.push(cursor)
            }
        }

        if (ues[ues.length - 1].IdPeriodo != periodo_anterior) {
            result.push({
                Periodo: periodoFrom(ues[ues.length - 1].IdPeriodo, periodos)
            })
        }

        result = _.sortBy(result, p => ordenPeriodo(p, periodos)).reverse()
        return result;
    }

    var ordenPeriodo = function (definicion, periodos) {
        var periodo = _.find(periodos, p => p.descripcion_periodo == definicion.Periodo)

        return periodo.desde
    }

    var AgruparUnidadesEvaluacion = function (ues) {

        var cursor = {
            Destacados: 0,
            Bueno: 0,
            Regular: 0,
            Deficiente: 0,
            Pendientes: 0,
            Provisorias: 0
        }

        for (var i = 0; i < ues.length; i++) {
            var detalle = ues[i].DetalleEvaluados
            cursor.Destacados += detalle.Destacados
            cursor.Bueno += detalle.Bueno
            cursor.Regular += detalle.Regular
            cursor.Deficiente += detalle.Deficiente
            cursor.Pendientes += detalle.Pendiente
            cursor.Provisorias += detalle.Provisoria
        }

        cursor.TotalEvaluados = cursor.Destacados + cursor.Bueno + cursor.Regular + cursor.Deficiente
        cursor.TotalGeneral = cursor.TotalEvaluados + cursor.Provisorias + cursor.Pendientes

        return [cursor]
    }

    return {
        AgruparComitesPorPeriodo: AgruparComitesPorPeriodo,
        AgruparUnidadesEvaluacion: AgruparUnidadesEvaluacion
    }
})