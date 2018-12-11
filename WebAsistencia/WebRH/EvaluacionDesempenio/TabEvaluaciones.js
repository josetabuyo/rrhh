define(['jquery', 'eval/EvaluacionDesempenioAppState',  'creadorDeGrillas', 'eval/ComitesPorPeriodo', 'eval/EvaluacionDesempenioPdfPrint'],
    function ($, app_state, CreadorDeGrillas, ComitesPorPeriodo, pdf_printer) {

        var on_tab_enter = function (idComite) {
            var comite = app_state.GetComite(idComite)
            var ues = comite.UnidadesEvaluacion

            var result = ComitesPorPeriodo.AgruparUnidadesEvaluacion(ues)
            CreadorDeGrillas('#tabla_resumen', result)

            var evals = app_state.GetEvaluacionesUes(ues)

            var grid_rows = _.map(evals, e => {
                return {
                    Dni: e.dni_agente_evaluado,
                    Apellido: e.apellido_agente_evaluado,
                    Nombre: e.nombre_agente_evaluado,
                    Area: e.area,
                    Evaluacion: e.evaluacion.calificacion,
                    GDE: e.evaluacion.codigo_gde,
                    IdEvaluacion: e.evaluacion.id_evaluacion,
                    Accion: 'Acc'
                }
            })
            grid_rows = _.chain(grid_rows).sortBy('Nombre').sortBy('Apellido').value()
            CreadorDeGrillas('#tabla_evaluaciones', grid_rows)

            pdf_printer.BindVerEvalButtons()
        }

        var setup_componentes = function () {
            //cargar combo de tipos de evaluacion
        }

        return {
            tab_name: '#scr_evaluaciones',
            on_tab_enter: on_tab_enter,
            init: setup_componentes
        }
    })