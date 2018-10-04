requirejs(['../common'], function (common) {
    requirejs(['jquery', 'backend', 'creadorDeGrillas', 'eval/comitesPorPeriodo', 'barramenu2', 'jquery-ui'], function ($, Backend, CreadorDeGrillas, ComitesPorPeriodo) {

        Backend.start(function () {
            Backend.GetAllComites().onSuccess(function (comites) {
                Backend.GetEstadosEvaluacionesPeriodosActivos().onSuccess(function (ues) {
                    Backend.GetAgentesEvaluablesParaComites().onSuccess(function (evals) {
                        Backend.GetPeriodosEvaluacion().onSuccess(function (periodos) {

                            //localStorage.setItem("estadosEvaluaciones", JSON.stringify(ues));
                            var agrupados = ComitesPorPeriodo(ues, periodos, evals, comites)
                            CreadorDeGrillas('#tabla_periodos', agrupados)

                            //activo los tooltips
                            $('[data-toggle="tooltip"]').tooltip()

                            //agrego el handler de los componentes que cambian de pantalla
                            $('[target_scr]').click(function () {
                                var pantalla = this.attributes.target_scr.value
                                mostrarPantalla(pantalla);
                            })

                            var mostrarPantalla = function (pantalla) {
                                $('[role="tabpanel"]').hide()
                                $(pantalla).show()
                            }
                        })
                    })
                })
            })
        })
    })
})
