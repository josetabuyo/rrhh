define(['jquery', 'eval/EvaluacionDesempenioAppState', 'spa-tabs', 'creadorDeGrillas', 'eval/ComitesPorPeriodo', 'jquery-ui'],
    function ($, app_state, spa_tabs, CreadorDeGrillas, ComitesPorPeriodo) {

        var load_grid_periodos = function () {
            app_state.GetDataGridPeriodos(data => {
                var comites = data.GetAllComites
                var ues = data.GetEstadosEvaluacionesPeriodosActivos
                var evals = data.GetAgentesEvaluablesParaComites
                var periodos = data.GetPeriodosEvaluacion

                var agrupados = ComitesPorPeriodo.AgruparComitesPorPeriodo(ues, periodos, evals, comites)
                CreadorDeGrillas('#tabla_periodos', agrupados)

                spa_tabs.appendTabsTo('#tabla_periodos')

                //activo los tooltips
                $('#tabla_periodos [data-toggle="tooltip"]').tooltip()
            })
        }

        var init = function () {
            app_state.OnStateChange(load_grid_periodos)
        }

        return {
            tab_name: '#scr_periodos',
            load_grid_periodos: load_grid_periodos,
            init: init
        }
    })