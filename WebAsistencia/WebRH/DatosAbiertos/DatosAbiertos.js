$(document).ready(function () {
    Backend.start(function () {
        Backend.GetConsultasOPD()
            .onSuccess(function (consultas) {
                $("#pagina").empty();
                _.forEach(consultas, function (c) {
                    var ui_consulta = $("#plantillas .consulta").clone();
                    ui_consulta.find(".titulo").text(c.Nombre);
                    ui_consulta.find(".descripcion").text(c.Descripcion);
                    ui_consulta.find(".descripcion_boton").text(c.Nombre);

                    ui_consulta.find(".btn_xls").click(function () {
                        var spinner = new Spinner({ scale: 3 });
                        spinner.spin($("html")[0]);

                        Backend.EjecutarConsultaOPD()
                            .onSuccess(function (resultado) {
                                if (resultado.length > 0) {
                                    var a = window.document.createElement('a');
                                    a.href = "data:application/vnd.ms-excel;base64," + resultado;
                                    a.download = c.Nombre + "_" + ConversorDeFechas.deIsoAFechaEnCriollo(new Date()).replace('/', '_').replace('/', '_').replace('/', '_') + "_.xlsx";
                                    document.body.appendChild(a);
                                    a.click();
                                    document.body.removeChild(a);
                                } else {
                                    alertify.error("No se han encontrado datos para Exportar");
                                }
                                spinner.stop();
                            })
                            .onError(function (e) {
                                spinner.stop();
                                alertify.error("error al Exportar datos. Detalle: " + e);
                            });
                    });
                    $("#pagina").append(ui_consulta);
                });
            })
            .onError(function (e) {
                alertify.error("error al Exportar datos. Detalle: " + e);
            });


        $("#btn_mapa_del_estado_xls").click(function () {
            var spinner = new Spinner({ scale: 3 });
            spinner.spin($("html")[0]);

            Backend.ExcelMapaDelEstado()
                .onSuccess(function (resultado) {
                    if (resultado.length > 0) {
                        var a = window.document.createElement('a');
                        a.href = "data:application/vnd.ms-excel;base64," + resultado;
                        a.download = "Mapa_del_estado_MDS_" + ConversorDeFechas.deIsoAFechaEnCriollo(new Date()).replace('/', '_').replace('/', '_').replace('/', '_') + "_.xlsx";
                        document.body.appendChild(a);
                        a.click();
                        document.body.removeChild(a);
                    } else {
                        alertify.error("No se han encontrado datos para Exportar");
                    }
                    spinner.stop();
                })
                .onError(function (e) {
                    spinner.stop();
                    alertify.error("error al Exportar datos. Detalle: " + e);
                });
        });

        $("#btn_planif_dotaciones_xls").click(function () {
            var spinner = new Spinner({ scale: 3 });
            spinner.spin($("html")[0]);

            Backend.ExcelPlanificacionDotaciones()
                .onSuccess(function (resultado) {
                    if (resultado.length > 0) {
                        var a = window.document.createElement('a');
                        a.href = "data:application/vnd.ms-excel;base64," + resultado;
                        a.download = "Planificacion_Dotaciones_MDS_" + ConversorDeFechas.deIsoAFechaEnCriollo(new Date()).replace('/', '_').replace('/', '_').replace('/', '_') + "_.xlsx";
                        document.body.appendChild(a);
                        a.click();
                        document.body.removeChild(a);
                    } else {
                        alertify.error("No se han encontrado datos para Exportar");
                    }
                    spinner.stop();
                })
                .onError(function (e) {
                    spinner.stop();
                    alertify.error("error al Exportar datos. Detalle: " + e);
                });
        });

    });
});
