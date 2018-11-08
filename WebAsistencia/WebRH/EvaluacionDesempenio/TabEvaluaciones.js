define(['jquery', 'eval/EvaluacionDesempenioAppState', 'spa-tabs', 'creadorDeGrillas'],
    function ($, app_state, spa_tabs, CreadorDeGrillas) {

        var on_tab_enter = function (idComite) {
            var comite = app_state.GetComite(idComite)
            var ues = comite.UnidadesEvaluacion
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
