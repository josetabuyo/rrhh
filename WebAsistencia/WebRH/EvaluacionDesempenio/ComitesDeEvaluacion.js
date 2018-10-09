requirejs(['../common'], function (common) {
    requirejs(['jquery', 'underscore', 'backend',  'creadorDeGrillas', 'eval/comitesPorPeriodo', 'barramenu2', 'jquery-ui', 'jquery-timepicker'], function ($, _, Backend, CreadorDeGrillas, ComitesPorPeriodo) {

        var on_scr_home_next = function (show_next) {
            show_next()
        }
        var on_datos_generales_next = function (show_next) {
            Backend.start(function () {
                Backend.AgregarComiteEvaluacionDesempenio(descripcion, fecha, hora, lugar, periodo).onSuccess(function (comite) {
                    show_next()
                });
            });
        }

        var tabs_config = [
            {
                tab_name: '#scr_home',
                on_next: on_scr_home_next
            },
            {
                tab_name: '',
                on_next: on_scr_home_next
            },
            {
                tab_name: '#scr_datos_generales',
                on_next: on_datos_generales_next
            }
        ]

        var load_screen = function () {
            var data = JSON.parse(window.localStorage.getItem('ComitesDeEvaluacionData'))
            var comites = data.GetAllComites
            var ues = data.GetEstadosEvaluacionesPeriodosActivos
            var evals = data.GetAgentesEvaluablesParaComites
            var periodos = data.GetPeriodosEvaluacion

            //localStorage.setItem("estadosEvaluaciones", JSON.stringify(ues));
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

            var mostrarTab = function (tab_name, parameter) {
                $('[role="tabpanel"]').hide()
                $(tab_name).show()
            }

            var tab_definition_from_url = function (url) {
                if (!url) {
                    return {
                        name: '',
                        parameter: ''
                    }
                }
                var tab_definition = url.split('/')
                var tab_name = tab_definition[0]
                var tab_parameter = tab_definition[1]
                return {
                    name: tab_name,
                    parameter: tab_parameter
                }
            }

            $('[target_scr]').click(function (e) {
                e.preventDefault();
                var url = this.attributes.target_scr.value
                var next_tab = tab_definition_from_url(this.attributes.target_scr.value)
                var current_tab = tab_definition_from_url(location.hash)
                var tab_config = _.find(tabs_config, function (each) { return each.tab_name == current_tab.name })
                tab_config.on_next(function () { mostrarTab(next_tab.name, next_tab.parameter) })
                history.pushState(null, null, url);
                
            })

            window.addEventListener("popstate", function (e) {
                var tab = tab_definition_from_url(location.hash)
                var activeTab = $(tab.name);
                if (activeTab.length) {
                    mostrarTab(tab.name, tab.parameter)
                } else {
                    mostrarTab('#scr_home')
                }
            });
        }


        if (!window.localStorage.getItem('ComitesDeEvaluacionData')) {
            Backend.start(function () {
                Backend.GetAllComites().onSuccess(function (comites_response) {
                    Backend.GetEstadosEvaluacionesPeriodosActivos().onSuccess(function (ues_response) {
                        Backend.GetAgentesEvaluablesParaComites().onSuccess(function (evals_response) {
                            Backend.GetPeriodosEvaluacion().onSuccess(function (periodos_response) {
                                var ComitesDeEvaluacionData = {
                                    GetAllComites: comites_response,
                                    GetEstadosEvaluacionesPeriodosActivos: ues_response,
                                    GetAgentesEvaluablesParaComites: evals_response,
                                    GetPeriodosEvaluacion: periodos_response
                                }
                                window.localStorage.setItem('ComitesDeEvaluacionData', JSON.stringify(ComitesDeEvaluacionData))
                                load_screen()
                            })
                        })
                    })
                })
            })
        } else {
            load_screen()
        }
    })
})
