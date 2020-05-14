$(document).ready(function () {
    console.warn('document ready');
    Backend.start(function () {
      console.warn('backend started');
        Backend.PTGetAsistenciasPorGrupoYMes()
            .onSuccess(function (asistencias) {
                console.warn('asistencias obtenidas:', asistencias);
                console.warn($("#pt_tabla_semanal"));
                $("#pt_tabla_semanal").find(".pt_fila_semanal").remove();
                _.forEach(asistencias, function (a) {
                    var fila = $("<tr>")

                    var celda = $("<td>")
                    celda.text(a.cuil);
                    fila.append(celda);

                    celda = $("<td>")
                    celda.text(a.nombre);
                    fila.append(celda);
                    
                    $("#pt_tabla_semanal").append(fila);
                });
            })
            .onError(function (e) {
                alertify.error("error al obtener asistencias: " + e);
            });
    });
});
