require.config({
    baseUrl: '../node_modules/',
    shim: {
        'bootstrap': {
            deps: ['jquery']
        },
        'opentip': {
            deps: ['jquery']
        },
        'jquery-ui': {
            deps: ['jquery']
        },
        'jquery-timepicker': {
            deps: ['jquery']
        },
        'select2': {
            deps: ['jquery']
        },
        'jquery.validate.min': {
            deps: ['jquery']
        },
        'additional-methods': {
            deps: ['jquery.validate']
        }
    },
    paths: {
        'jquery': 'jquery/jquery',
        'jquery-timepicker': 'jquery-timepicker/jquery.timepicker',

        'jquery.validate': 'jquery-validation/dist/jquery.validate',
        'additional-methods': 'jquery-validation/dist/additional-methods',

        'bootstrap': 'bootstrap/dist/js/bootstrap.bundle',

        'eval': '../EvaluacionDesempenio',

        'menuDesplegable': '../BarraMenu/MenuDesplegable2',
        'vistaTipoTicket': '../BarraMenu/VistaTipoTicket2',
        'vistaItemMenu': '../BarraMenu/VistaItemMenu2',
        'barramenu2': '../BarraMenu/BarraMenu2',

        'vistaThumbnail': '../Scripts/ControlesImagenes/VistaThumbnail2',
        'backend': '../Scripts/Backend2',
        'proveedorAjax': '../Scripts/ProveedorAjax2',
        'opentip': '../Scripts/opentip/opentip-jquery-excanvas.min',
        'promesa': '../Scripts/promesa2',
        'underscore': '../Scripts/underscore-min',
        'jquery-ui': '../Scripts/jquery-ui-1.10.2.custom/js/jquery-ui-1.10.2.custom.min',
        'creadorDeGrillas': '../Scripts/CreadorDeGrillas',
        'spa-tabs': '../Scripts/SPATabs',
        'wsviaticos': '../Scripts/WSViaticosAPI',
        'selector-personas': '../Scripts/SelectorDePersonas2',
        'select2': '../Scripts/select2-3.4.4/select2.min'
    }
});