
<!-- saved from url=(0094)https://raw.githubusercontent.com/EmberConsultingGroup/Testing-Automation/master/specRunner.js -->
<html><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8"></head><body><pre style="word-wrap: break-word; white-space: pre-wrap;">
(function() {
   'use strict';
    
require.config({
    urlArgs: "cb=" + Math.random(),
    paths: {
        'jquery': '../WebAsistencia/WebRH/Scripts/jquery.min',
        'jasmine': '../jasmine-standalone-2.0.0/lib/jasmine-2.0.0/jasmine',
		'domReady': '../jasmine-standalone-2.0.0/lib/domReady',
        'jasmine_html': '../jasmine-standalone-2.0.0/lib/jasmine-2.0.0/jasmine-html',
        'jasmine_boot': '../jasmine-standalone-2.0.0/lib/jasmine-2.0.0/jasmine-boot',
        'teamcityreporter' : '../jasmine-standalone-2.0.0/lib/jasmine2.teamcityreporter'
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
    
})();</pre></body></html>