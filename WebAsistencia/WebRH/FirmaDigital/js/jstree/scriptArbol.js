// Code goes here

/*$('#tree1').jstree({ 'core' : {
    'data' : [
       { "id" : "ajson2", "parent" : "#", "text" : "tree1" },
       { "id" : "ajson3", "parent" : "ajson2", "text" : "Child 1.1" },
       { "id" : "ajson4", "parent" : "ajson2", "text" : "Child 1.2" },
    ]
} });
*/


//$('#tree1')
  // listen for event
//  .on('changed.jstree', function (e, data) {
     
//   alert('hi');
//  })
  // create the instance
//  .jstree();

//$('#tree3').jstree()
//$('#tree4').jstree()



$(function () {


    $('#jstree').jstree({
        'core': {
            "themes" : {
             "dots" : true, // no connecting dots between dots
             "icons": false,
             "variant": "large"
                
            },
            'data': [{
                "id": "1.0",
                "text": "Fresh Products",
                "icon": "",
                "state": {
                    "opened": true,
                    "disabled": false,
                    "selected": false
                },
                "children": [],
                "liAttributes": null,
                "aAttributes": null
            }, {
                "id": "2.0",
                "text": "Frozen Products",
                "icon": "",
                "state": {
                    "opened": false,
                    "disabled": false,
                    "selected": false
                },
                "children": [],
                "liAttributes": null,
                "aAttributes": null
            }, {
                "id": "3.0",
                "text": "Store Equipment ",
                "icon": "",
                "state": {
                    "opened": false,
                    "disabled": false,
                    "selected": false
                },
                "children": [],
                "liAttributes": null,
                "aAttributes": null
            }, {
                "id": "4.0",
                "text": "Packaged Grocery",
                "icon": "",
                "state": {
                    "opened": false,
                    "disabled": false,
                    "selected": false
                },
                "children": [],
                "liAttributes": null,
                "aAttributes": null
            }, {
                "id": "5.0",
                "text": "Retail Technology",
                "icon": "",
                "state": {
                    "opened": false,
                    "disabled": false,
                    "selected": false
                },
                "children": [],
                "liAttributes": null,
                "aAttributes": null
            }, {
                "id": "6.0",
                "text": "HBC/Non-Foods",
                "icon": "",
                "state": {
                    "opened": false,
                    "disabled": false,
                    "selected": false
                },
                "children": [],
                "liAttributes": null,
                "aAttributes": null
            }]



        },
        "search": {

            "case_insensitive": true,
            "show_only_matches": true


        },

        "plugins": ["search"]


    });
});