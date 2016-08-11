
$(function () {
    Backend.start(function () {
        vex.defaultOptions.className = 'vex-theme-os';
        var ui = $("#pantalla_edicion_bien");

        $(".btnVerBien").click(function (e) {
            var id_bien = $($(e.target).parent().parent().parent().children()[0]).text();
            Backend.Mobi_GetBienPorId(id_bien).onSuccess(function (bien) {
                ui.find("#ed_descripcion_bien").text(bien.Descripcion);
                $("#ed_contenedor_imagenes").empty();
                _.forEach(bien.Imagenes, function (id_imagen) {
                    var cont_imagen = $('<div class="imagen_bien"></div>');
                    var img = new VistaThumbnail({ id: id_imagen, contenedor: cont_imagen });
                    $("#ed_contenedor_imagenes").append(cont_imagen);
                });
            });

            vex.open({
                afterOpen: function ($vexContent) {
                    return $vexContent.append(ui);
                },
                css: {
                    'padding-top': "4%",
                    'padding-bottom': "0%"
                },
                contentCSS: {
                    width: "80%",
                    height: "80%"
                }
            });
        });
    });
});