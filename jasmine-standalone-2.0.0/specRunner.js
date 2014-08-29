

(function() {
   'use strict';
    
require.config({
    urlArgs: "cb=" + Math.random(),
    paths: {
        'jquery': '../WebAsistencia/WebRH/Scripts/jquery.min',
        'jasmine': '../jasmine-standalone-2.0.0/lib/jasmine-2.0.0/jasmine',
		'domReady': '../jasmine-standalone-2.0.0/lib/domReady',
        'jasmine_html': '../jasmine-standalone-2.0.0/lib/jasmine-2.0.0/jasmine-html',
        'jasmine_boot': '../jasmine-standalone-2.0.0/lib/jasmine-2.0.0/boot',
        'teamcityreporter' : '../jasmine-standalone-2.0.0/lib/Jasmine2-teamcityreporter'
    },
    shim: {
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