var Legajo = {
    init: function () {

    },
    getEstudios: function () {
        var data = JSON.stringify({
            doc: 123
        });

        Backend.GetEstudios(123)
            .onSuccess(function (estudiosJSON) {

                var estudios = JSON.parse(estudiosJSON);

                $.each(estudios, function (key, value) {
                    var estudio = $(".cajaEstudioOculta").clone();
                    estudio.find(".nivel").html(value.nombreDeNivel);
                    estudio.find(".titulo").html(value.titulo);
                    var fecha_sin_hora = value.fechaEgreso.split("T");
                    var fecha = fecha_sin_hora[0].split("-");
                    estudio.find(".fecha").html(fecha[2] + "/" + fecha[1] + "/" + fecha[0]);
                    estudio.addClass("caja_estudio_posta");// attr('style', 'margin:10px; border-bottom:1px solid;');
                    estudio.removeClass("cajaEstudioOculta");

                    $('#listadoEstudios').append(estudio);
                });

            })
            .onError(function (e) {

            });
    }
}
