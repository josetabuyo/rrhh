requirejs(['../common'], function (common) {
    requirejs(['jquery', 'underscore', 'eval/EvaluacionDesempenioAppState', 'spa-tabs', 'creadorDeGrillas', 'eval/comitesPorPeriodo', 'eval/TabIntegrantes', 'eval/TabDatosGenerales', 'eval/TabUnidadesEvaluacion', 'barramenu2', 'jquery-ui', 'jquery-timepicker', 'additional-methods'], function ($, _, app_state, spa_tabs, CreadorDeGrillas, ComitesPorPeriodo, tab_integrantes, tab_datos_generales, tab_unidades_evaluacion) {

         //config para la Single Page App con Tabs
        var tabs_events = [{
            tab_name: '#scr_datos_generales',
            on_next: tab_datos_generales.on_next,
            on_enter: tab_datos_generales.on_enter
        }, {
            tab_name: '#scr_integrantes',
            on_enter: tab_integrantes.on_tab_enter
        }, {
            tab_name: '#scr_unidades',
            on_enter: tab_unidades_evaluacion.on_tab_enter
        }]

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

                spa_tabs.createTabs(tabs_events)

                //activo los tooltips
                $('#tabla_periodos [data-toggle="tooltip"]').tooltip()

            })
        }


        var setup_componentes = function () {



            app_state.OnStateChange(load_grid_periodos)

            tab_unidades_evaluacion.init()
            tab_datos_generales.init()
            tab_integrantes.init()

            app_state.StateChanged()
        }

        setup_componentes()
    })
})