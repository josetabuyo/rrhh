requirejs.config({
    baseUrl: 'Scripts',
    paths: {
        jquery: 'jquery.min',
        vex: 'vex-2.1.1/js/vex.min',
        dialog: 'vex-2.1.1/js/vex.dialog.min',
        ProveedorAjax: 'ProveedorAjax',
        alertify: 'alertify',
        validaciones: 'Extensiones/Validaciones',
        Opentip: 'opentip/opentip-jquery-excanvas.min',
        PantallaRegistro: '../RegistroPostular/PantallaRegistro'
    },
    shim: {
        vex: {
            deps:['jquery'],
            exports: 'vex'
        },
        dialog: {
            deps: ['vex'],
            exports: 'vex.dialog'
        },
        ProveedorAjax: {
            deps: ['jquery'],
            exports: 'ProveedorAjax'
        },
        validaciones: {
            deps: ['Opentip']
        }
    }
});
