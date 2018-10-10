requirejs(['../common'], function (common) {
    requirejs(['jquery', 'underscore', 'wsviaticos', 'spa-tabs', 'creadorDeGrillas', 'eval/comitesPorPeriodo', 'barramenu2', 'jquery-ui', 'jquery-timepicker'], function ($, _, ws, spa_tabs, CreadorDeGrillas, ComitesPorPeriodo) {

        //window.localStorage.clear()

        //cuando se hace click en "siguiente" (solapa home)
        var on_scr_home_next = function (show_next) {
            show_next()
        }

        //cuando se hace click en "siguiente (datos generales)
        var on_datos_generales_next = function (show_next) {
            Backend.start(function () {
                Backend.AgregarComiteEvaluacionDesempenio(descripcion, fecha, hora, lugar, periodo).onSuccess(function (comite) {
                    show_next()
                });
            });
        }

        //config para la Single Page App con Tabs
        var tabs_config = [
            { tab_name: '#scr_home',
              on_next: on_scr_home_next
            }, { tab_name: '',
                on_next: on_scr_home_next
            }, { tab_name: '#scr_datos_generales',
                on_next: on_datos_generales_next
            }
        ]

        var load_screen = function () {
            var data = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData'))
            var comites = data.GetAllComites
            var ues = data.GetEstadosEvaluacionesPeriodosActivos
            var evals = data.GetAgentesEvaluablesParaComites
            var periodos = data.GetPeriodosEvaluacion

            
            var agrupados = ComitesPorPeriodo(ues, periodos, evals, comites)
            CreadorDeGrillas('#tabla_periodos', agrupados)

            //activo los tooltips
            $('[data-toggle="tooltip"]').tooltip()

            $('#fecha').datepicker()

            $('.timepicker').timepicker({
                timeFormat: 'h:mm p',
                interval: 60,
                minTime: '10',
                maxTime: '6:00pm',
                defaultTime: '11',
                startTime: '10:00',
                dynamic: false,
                dropdown: true,
                scrollbar: true
            })
            spa_tabs.createTabs(tabs_config)
        }

        //traigo todos los datos del backend en paralelo y los guardo en el local storage
        if (!window.localStorage.getItem('ComitesDeEvaluacionData')) {
            var requests = [
                { nombre_metodo: "GetAllComites", argumentos_json: [] },
                { nombre_metodo: "GetEstadosEvaluacionesPeriodosActivos", argumentos_json: [] },
                { nombre_metodo: "GetAgentesEvaluablesParaComites", argumentos_json: [] },
                { nombre_metodo: "GetPeriodosEvaluacion", argumentos_json: [] }
            ]
            ws.parallel(requests, function (err, respuestas) {
                if (err) {
                    console.log('Se produjo un error ' + err)
                    return 
                }
                var ComitesDeEvaluacionData = {
                    GetAllComites: respuestas[0],
                    GetEstadosEvaluacionesPeriodosActivos: respuestas[1],
                    GetAgentesEvaluablesParaComites: respuestas[2],
                    GetPeriodosEvaluacion: respuestas[3]
                }
                window.localStorage.setItem('ComitesDeEvaluacionData', JSON.stringify(ComitesDeEvaluacionData))
                load_screen()
            })
        } else {
            load_screen()
        }
    })
})
