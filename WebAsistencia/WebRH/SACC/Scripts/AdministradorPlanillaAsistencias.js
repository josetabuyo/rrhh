var cursos = {};

var CargarComboAnios = function () {
    var anio_inicio = Enumerable.From(cursos)
    .Select(function (x) { return x.FechaInicio })
    .Min().substr(6, 4);

    var anio_fin = Enumerable.From(cursos)
    .Select(function (x) { return x.FechaInicio })
    .Max().substr(6, 4);

    var id_curso = $("#CmbCurso option:selected").val();
    var cmb_anio = $("#CmbAnio");
    cmb_anio.html("");
    var o = new Option('Seleccione', '0');
    $(o).html('Seleccione');
    cmb_anio.append(o);
    for (var a = anio_inicio; a <= anio_fin; a++) {
        var o = new Option(a, a);
        $(o).html(a);
        cmb_anio.append(o);
    }

    cmb_anio.val(0);
}

var CargarComboMeses = function () {
    var id_curso = $("#CmbCurso option:selected").val();
    var cmb_mes = $("#CmbMes");
    cmb_mes.html("");
    var o = new Option("Seleccione", "0");
    $(o).html("Seleccione");
    cmb_mes.append(o);

    if (id_curso > 0) {
        data_post = { id_curso: id_curso };
        $.ajax({
            url: "../AjaxWS.asmx/GetMesesCursoDto",
            type: "POST",
            async: false,
            data: JSON.stringify(data_post),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                for (var i = 0; i < respuesta.length; i++) {
                    var o = new Option(respuesta[i].NombreMes, respuesta[i].Mes);
                    $(o).html(respuesta[i].NombreMes);
                    cmb_mes.append(o);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });
    }
    cmb_mes.val(0);
    CargarPlanilla();

}

var CargarComboCursos = function () {
    var cmb_cursos = $("#CmbCurso");
    var anio = $("#CmbAnio option:selected").val();

    var cursos_por_anio = Enumerable.From(cursos)
                        .Select(function (x) { return x })
                        .Where(function (x) { return x.FechaInicio.substr(6, 4) == anio })
                        .ToArray();

    cmb_cursos.html("");
    var o = new Option("Seleccione", "0");
    $(o).html("Seleccione");
    cmb_cursos.append(o);

    for (var i = 0; i < cursos_por_anio.length; i++) {
        var c = cursos_por_anio[i].Nombre + " " + cursos_por_anio[i].Materia.Ciclo.Nombre;
        var o = new Option(c, cursos_por_anio[i].Id);
        $(o).html(c);
        cmb_cursos.append(o);
    }
    cmb_cursos.val(0);
    CargarComboMeses();
}

var GuardarDetalleAsistencias = function () {
    PlanillaAsistencias.guardar_asistencias();
    CargarPlanilla();
}
var CargarPlanilla = function () {
    $("#ContenedorPlanilla").html("");
    var id_curso = $("#CmbCurso option:selected").val();
    var mes = $("#CmbMes option:selected").val();
    var anio = $("#CmbAnio option:selected").val();
    if (mes != 0 && anio && id_curso) {
        var fecha_desde = anio + "/" + mes + "/01";
        var fecha_hasta = "";
        PlanillaAsistencias.cargar_asistencias(id_curso, fecha_desde, fecha_hasta);
        PlanillaAsistencias.mostrar_botones();
        PlanillaAsistencias.mostrar_panel_detalle_curso();
    } else {
        PlanillaAsistencias.ocultar_botones();
        PlanillaAsistencias.ocultar_panel_detalle_curso();
    }
}

var GetCursos = function () {
    $.ajax({
        url: "../AjaxWS.asmx/GetCursosDto",
        type: "POST",
        async: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            cursos = JSON.parse(respuestaJson.d);
            CargarComboAnios();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
}