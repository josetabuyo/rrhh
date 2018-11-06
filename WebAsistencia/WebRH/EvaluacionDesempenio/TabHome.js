define(['jquery', 'eval/EvaluacionDesempenioAppState', 'spa-tabs', 'creadorDeGrillas', 'eval/comitesPorPeriodo', 'jquery-ui'],
    function ($, app_state, spa_tabs, CreadorDeGrillas, ComitesPorPeriodo) {

        var set_id_periodo_seleccionado = function (e) {
            $("#id_periodo_seleccionado").val(e.currentTarget.attributes.btn_id_periodo.value)
        }

        var load_grid_periodos = function () {
            app_state.GetDataGridPeriodos(data => {
                var comites = data.GetAllComites
                var ues = data.GetEstadosEvaluacionesPeriodosActivos
                var evals = data.GetAgentesEvaluablesParaComites
                var periodos = data.GetPeriodosEvaluacion

                var agrupados = ComitesPorPeriodo(ues, periodos, evals, comites)
                CreadorDeGrillas('#tabla_periodos', agrupados)

                $('[btn_id_periodo]').click(set_id_periodo_seleccionado)

                spa_tabs.createTabs()

                //activo los tooltips
                $('#tabla_periodos [data-toggle="tooltip"]').tooltip()
            })
        }

        var init = function () {
            app_state.OnStateChange(load_grid_periodos)
        }

        return {
            tab_name: '#scr_home',
            load_grid_periodos: load_grid_periodos,
            init: init
        }

    })