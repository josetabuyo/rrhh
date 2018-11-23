requirejs(['../common'], function (common) {
    requirejs([
        'jquery',
        'underscore',
        'eval/EvaluacionDesempenioAppState',
        'spa-tabs', 
        'eval/TabPeriodos',
        'eval/TabIntegrantes',
        'eval/TabDatosGenerales',
        'eval/TabUnidadesEvaluacion',
        'eval/TabEvaluaciones',
        'eval/TabReunionesComite',
        'barramenu2',
        'jquery-ui',
        'jquery-timepicker',
        'additional-methods',
        'bootstrap'],
        function ($,
            _,
            app_state,
            spa_tabs,
            tab_periodos,
            tab_integrantes,
            tab_datos_generales,
            tab_unidades_evaluacion,
            tab_evaluaciones,
            tab_reuniones_comite) {


            var setup_componentes = function () {
                spa_tabs.addTabs([tab_periodos, tab_unidades_evaluacion, tab_datos_generales, tab_integrantes, tab_evaluaciones, tab_reuniones_comite])
                app_state.StateChanged()
            }

            setup_componentes()

        })
})