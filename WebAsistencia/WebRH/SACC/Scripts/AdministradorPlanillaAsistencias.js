var AdministradorPlanilla = function () {
    var _this = this;

    _this.contenedorPlanilla = {};

    var diasCursados = {};
    var asistencias = {};
    var horasCatedra = {};
    var columnas = [];

    _this.cargar_asistencias = function (id_curso, fecha_desde, fecha_hasta) {
        var data_post = { id_curso: id_curso, fecha_desde: fecha_desde, fecha_hasta: fecha_hasta };
        $.ajax({
            url: "../AjaxWS.asmx/GetPlanillaAsistencias",
            type: "POST",
            async: false,
            data: JSON.stringify(data_post),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                alert(respuestaJson);
                var respuesta = JSON.parse(respuestaJson.d);
                diasCursados = respuesta.diasCursados;
                asistencias = respuesta.asistencias;
                hotasCatedra = respuesta.horasCatedra;
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    }

    _this.dibujar_planilla = function () {

    }

}