$(document).ready(function () {
    Backend.start(function () {
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

    });
});
