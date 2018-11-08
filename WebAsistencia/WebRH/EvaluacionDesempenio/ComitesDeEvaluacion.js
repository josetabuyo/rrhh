requirejs(['../common'], function (common) {
    requirejs([
        'jquery',
        'underscore',
        'eval/EvaluacionDesempenioAppState',
        'spa-tabs', 
        'eval/TabHome',
        'eval/TabIntegrantes',
        'eval/TabDatosGenerales',
        'eval/TabUnidadesEvaluacion',
        'eval/TabEvaluaciones',
        'barramenu2',
        'jquery-ui',
        'jquery-timepicker',
        'additional-methods',
        'bootstrap'],
        function ($,
            _,
            app_state,
            spa_tabs,
            tab_home,
            tab_integrantes,
            tab_datos_generales,
            tab_unidades_evaluacion,
            tab_evaluaciones) {


            var setup_componentes = function () {
                spa_tabs.addTabs([tab_home, tab_unidades_evaluacion, tab_datos_generales, tab_integrantes, tab_evaluaciones])
                app_state.StateChanged()
            }

            setup_componentes()

        })
})