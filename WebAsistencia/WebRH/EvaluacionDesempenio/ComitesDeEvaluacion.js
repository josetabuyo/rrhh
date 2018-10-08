requirejs(['../common'], function (common) {
    requirejs(['jquery', 'backend', 'Modernizr', 'creadorDeGrillas', 'eval/comitesPorPeriodo', 'barramenu2', 'jquery-ui'], function ($, Backend, Modernizr, CreadorDeGrillas, ComitesPorPeriodo) {
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

            var mostrarTab = function (tab_name) {
                $('[role="tabpanel"]').hide()
                $(tab_name).show()
            }

            $('[target_scr]').click(function (e) {
                var pageName = this.attributes.target_scr.value
                mostrarTab(pageName)
                history.pushState(null, null, pageName);
                e.preventDefault();
            });

            window.addEventListener("popstate", function (e) {
                var activeTab = $(location.hash);
                if (activeTab.length) {
                    mostrarTab(location.hash)
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
