console.log('Loading a web page');
var page = new WebPage();
//This was tricky, this is the way to open LOCAL files 
var url = "file://mds-rh-0003/rrhh/jasmine-standalone-1.3.1/teamcity_reporter.html";
phantom.viewportSize = {
    width: 800,
    height: 600
};
//This is required because PhantomJS sandboxes the website and it does not show up the console messages form that page by default 
page.onConsoleMessage = function (msg) {
    console.log(msg);
};
//Open the website 
page.open(url, function (status) { //Page is loaded! 
    if (status !== 'success') {
        console.log('Unable to load the address!');
    } else {
		console.log('Loaded');
        //Using a delay to make sure the JavaScript is executed in the browser 
        window.setTimeout(function () {
            page.render("output.png");
            phantom.exit();
        }, 2000);
    }
});
console.log('Done');