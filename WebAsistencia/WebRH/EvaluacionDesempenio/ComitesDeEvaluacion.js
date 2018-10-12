requirejs(['../common'], function (common) {
    requirejs(['jquery', 'underscore', 'eval/EvaluacionDesempenioAppState', 'spa-tabs', 'creadorDeGrillas', 'eval/comitesPorPeriodo', 'barramenu2', 'jquery-ui', 'jquery-timepicker'], function ($, _, app_sate, spa_tabs, CreadorDeGrillas, ComitesPorPeriodo) {

        window.localStorage.clear()

        //cuando se hace click en "siguiente (datos generales)
        var on_datos_generales_next = function (show_next_tab, params) {
            //params['IdPeriodo']<--todo

            app_sate.AddComite($("#descripcion").val(),
                $("#fecha").val(),
                $("#hora").val(),
                $("#lugar").val(),
                params,
                eval => {
                    show_next_tab()
                    load_grid_periodos()
                })
        }

        //config para la Single Page App con Tabs
        var tabs_events = [{
                tab_name: '#scr_datos_generales',
                on_next: on_datos_generales_next
            }]

        var load_grid_periodos = function() {
            app_sate.GetDataGridPeriodos(data => {
                var comites = data.GetAllComites
                var ues = data.GetEstadosEvaluacionesPeriodosActivos
                var evals = data.GetAgentesEvaluablesParaComites
                var periodos = data.GetPeriodosEvaluacion

                var agrupados = ComitesPorPeriodo(ues, periodos, evals, comites)
                CreadorDeGrillas('#tabla_periodos', agrupados)

                //activo los tooltips
                spa_tabs.createTabs(tabs_events)
                $('#tabla_periodos [data-toggle="tooltip"]').tooltip()
            })
        }

        var load_screen = function () {

            $('#fecha').datepicker({
                dateFormat: "dd/mm/yy"
            })

            $('.timepicker').timepicker({
                timeFormat: 'HH:mm',
                interval: 60,
                minTime: '10',
                maxTime: '6:00pm',
                defaultTime: '11',
                startTime: '10:00',
                dynamic: false,
                dropdown: true,
                scrollbar: true
            })
            load_grid_periodos()
        }
        load_screen()
    })
})