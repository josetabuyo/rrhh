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
        cursor.SinGDE += contGDE.SinGDE;
        cursor.SinComite += contGDE.SinComite;
        cursor.Finalizado = 0;
        cursor.ReunionesRealizadas = _.filter(comites, function (each) { return each.Periodo.Id == ue.IdPeriodo }).length
    }


    function getEvalsPeriodo(evals_por_periodo, evals, id_periodo) {
        if (!evals_por_periodo[id_periodo]) {
            evals_por_periodo[id_periodo] = _.filter(evals, function (each) { return each.periodo.id_periodo == id_periodo })
        }
        return evals_por_periodo[id_periodo]
    }

    /*function removerUesConPeriodosDeBaja(ues, periodos_alta) {
        return _.filter(ues, function (ue) {
            return _.some(periodos_alta, function (periodo) {
                return periodo.id_periodo == ue.IdPeriodo
            })
        })
    }*/

    ///devuelve la lista de comites agrupadas por período
    function agruparComitesPorPeriodo(ues, periodos, evals, comites) {

        //esto se utiliza porque el backend devuelve todas las ue,
        //incluso las de periodos de baja.
        //ues = removerUesConPeriodosDeBaja(ues, periodos)

        var periodo_anterior = -1
        var result = [];
        var cursor;
        var evals_por_periodo = {}
        for (var i = 1; i < ues.length; i++) {
            if (ues[i].IdPeriodo != periodo_anterior) {
                periodo_anterior = ues[i].IdPeriodo
                cursor = {
                    Periodo: nombrePeriodoFrom(ues[i].IdPeriodo, periodos),
                    EvaluacionesPendientes: 0,
                    EvaluacionesProvisorias: 0,
                    SinGDE: 0,
                    SinComite: 0,
                    Finalizado: 0,
                    Reuniones: 0
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
        return result;
    }

    return agruparComitesPorPeriodo;
})