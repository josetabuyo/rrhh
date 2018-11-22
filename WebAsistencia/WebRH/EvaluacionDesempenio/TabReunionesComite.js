define(['jquery', 'underscore', 'eval/EvaluacionDesempenioAppState', 'creadorDeGrillas', 'jquery-ui'],
    function ($, _, app_state, CreadorDeGrillas) {


        var init = function (idPeriodo) {
            //alert(idPeriodo)
        }

        var on_tab_enter = function (idPeriodo) {
            alert(idPeriodo)
        }


        return {
            tab_name: '#scr_reuniones_comites',
            init: init,
            on_tab_enter: on_tab_enter,
        }

    })