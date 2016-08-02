
$(function () {
    vex.defaultOptions.className = 'vex-theme-os';
    $(".btnVerBien").click(function (e) {
        var id_bien = $($(e.target).parent().parent().parent().children()[0]).text();
        vex.open({
            afterOpen: function($vexContent) {
                return $vexContent.append($("#pantalla_edicion_bien"));
            },
            css:{
                'padding-top': "4%",
                'padding-bottom': "0%"
            },
            contentCSS: {
                width: "80%",
                height: "80%"
            }
        });
    })
});