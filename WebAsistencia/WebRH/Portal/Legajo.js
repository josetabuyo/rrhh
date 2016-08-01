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

                var _this = this;
                $("#tabla").empty();
                var divGrilla = $("#tabla");
                //var tabla = resultado;
                var columnas = [];

                columnas.push(new Columna("Titulo", { generar: function (un_estudio) { return un_estudio.titulo } }));
                columnas.push(new Columna("Nivel", { generar: function (un_estudio) { return un_estudio.nombreDeNivel } }));
                columnas.push(new Columna("Institución", { generar: function (un_estudio) { return ("XXX") } }));
                columnas.push(new Columna("F. Egreso", { generar: function (un_estudio) {
                    var fecha_sin_hora = un_estudio.fechaEgreso.split("T");
                    var fecha = fecha_sin_hora[0].split("-");
                    return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
                } 
                }));

                _this.Grilla = new Grilla(columnas);
                _this.Grilla.SetOnRowClickEventHandler(function (un_estudio) { });
                _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                _this.Grilla.CargarObjetos(estudios);
                _this.Grilla.DibujarEn(divGrilla);
                $('.table-hover').removeClass("table-hover");
                //_this.BuscadorDeTablaDetalle();

                /* $.each(estudios, function (key, value) {
                var estudio = $(".cajaEstudioOculta").clone();
                estudio.find(".nivel").html(value.nombreDeNivel);
                estudio.find(".titulo").html(value.titulo);
                var fecha_sin_hora = value.fechaEgreso.split("T");
                var fecha = fecha_sin_hora[0].split("-");
                estudio.find(".fecha").html(fecha[2] + "/" + fecha[1] + "/" + fecha[0]);
                estudio.addClass("caja_estudio_posta"); // attr('style', 'margin:10px; border-bottom:1px solid;');
                estudio.removeClass("cajaEstudioOculta");

                $('#listadoEstudios').append(estudio);
                });*/

            })
            .onError(function (e) {

            });
    }
}
