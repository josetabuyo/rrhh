requirejs.config({
    paths: {
        jquery: 'Scripts/jquery.min',
        vex: 'Scripts/vex-2.1.1/js/vex.min',
        dialog: 'Scripts/vex-2.1.1/js/vex.dialog.min',
        PantallaRegistro: 'RegistroPostular/PantallaRegistro',
        ProveedorAjax: 'Scripts/ProveedorAjax',
        alertify: 'Scripts/alertify',
        validaciones: 'Scripts/Extensiones/Validaciones',
        Opentip: 'Scripts/opentip/opentip-jquery-excanvas.min'
    },
    shim: {
        vex: {
            deps: ['jquery'],
            exports: 'vex'
        },
        dialog: {
            deps: ['vex'],
            exports: 'vex'
        },
        ProveedorAjax: {
            deps: ['jquery'],
            exports: 'ProveedorAjax'
        },
        validaciones: {
            deps: ['Opentip']
        },
        Opentip: {
            deps: ['jquery']
        }
    }
});
