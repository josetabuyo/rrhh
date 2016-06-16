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
                    var estudio = $(".cajaEstudio").clone();
                    estudio.find(".nivel").html(value.nombreDeNivel);
                    estudio.find(".titulo").html(value.titulo);
                    estudio.find(".fecha").html(value.fechaEgreso);
                    estudio.attr('style', 'margin:10px; border-bottom:1px solid;');
                    estudio.removeClass("cajaEstudio");

                    $('#listadoEstudios').append(estudio);
                });

            })
            .onError(function (e) {
                s
            });
    }
}
