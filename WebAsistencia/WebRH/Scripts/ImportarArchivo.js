//var spinner;


var ImportarArchivoABaseDeDatos = {

    Importar: function (nombreArchivo, detalleExcel) {

        alertify.confirm("Importación de Archivo", "¿Desea importar el archivo?", function () {

            //var spinner = new Spinner({ scale: 3 });
            //spinner.spin($("html")[0]);

            Backend.ImportarArchivoExcel(nombreArchivo, detalleExcel).onSuccess(function (mensaje) {
                alertify.success(mensaje);
                EscribirMensaje(mensaje);

              //  spinner.stop()
            })
            .onError(function (error) {
                alertify.error(error);
                EscribirMensaje(error);

               // spinner.stop()
            });

        }, function () {
            alertify.success("Importación cancelada");
        }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });


    }

}


function EscribirMensaje(mensaje) {
    var valData = mensaje;
    var valNew = valData.split('|');

    $('li').remove();

    for(var i=0;i<valNew.length;i++){

        $("ol").append("<li>" + valNew[i] +"</li>");

   }
}
