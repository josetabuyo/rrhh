(function() {
   'use strict';
    
require.config({
    //urlArgs: "cb=" + Math.random(),
	baseUrl: 'lib/jasmine-2.0.0/',
    paths: {
		'app': '../../../WebAsistencia/WebRH/Scripts/',
		'domready': 'domready',
        'jasmine_html': 'jasmine-html',
		'jasmine_boot': 'boot',
		'teamcityreporter': 'jasmine2-teamcityreporter',
		'mockAjax': 'mock-ajax',
		'ComboPopuladoConRepoSpec': '../../spec/ComboPopuladoConRepoSpec',
		'ComboConBusquedaYAgregadoSpec': '../../spec/ComboConBusquedaYAgregadoSpec'
    },
    shim: {
    	'ComboConBusquedaYAgregadoSpec': {
			deps: ['mockAjax', 'app/bootstrap/js/jquery', 'app/ComboConBusquedaYAgregado'],
		},
		'ComboPopuladoConRepoSpec': {
			deps: ['mockAjax', 'app/bootstrap/js/jquery', 'app/rhforms-combos'],
		},
		'app/rhforms-combos': {
			deps: ['app/repositorio', 'app/bindings', 'app/string']
		},
        'app/ComboConBusquedaYAgregado': {
			deps: ['app/repositorio', 'app/Extensiones/Colecciones', 'app/select2-3.4.4/select2_locale_es']
		},
        'app/select2-3.4.4/select2_locale_es':{
            deps:['app/select2-3.4.4/Select2.min']
        },
        'app/select2-3.4.4/Select2.min':{
            deps:['app/bootstrap/js/jquery']
        },
		'app/repositorio': {
			deps: ['app/backend']
		},
		'app/backend': {
			deps: ['app/proveedorAjax']
		},
		'mockAjax': {
			deps: ['jasmine']
		},
        'jasmine': {           
            exports: 'jasmine'
        },
        'jasmine_html': {
            deps: ['jasmine'],
            exports: 'jasmine'
        },
        'jasmine_boot': {
            deps: ['jasmine', 'jasmine_html'],
            exports: 'jasmine'
        },
        'teamcityreporter': {
            deps: ['jasmine']
        }
    },
    waitSeconds: 60
});

   
require(['jasmine_boot', 'teamcityreporter'], function () {

    require(specList,  //From specList.js, todo:automate
        function () {

            var TeamcityReporter = jasmineRequire.TeamcityReporter();
            window.teamcityReporter = new TeamcityReporter();
            jasmine.getEnv().addReporter(window.teamcityReporter);
			
            window.onload();
        });
    });
})();