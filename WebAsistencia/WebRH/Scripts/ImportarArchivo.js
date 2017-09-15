var ImportarArchivoABaseDeDatos = {

    Importar: function (nombreArchivo, detalleExcel) {

        alertify.confirm("Importación de Archivo", "¿Desea importar el archivo?", function () {
            Backend.ImportarArchivoExcel(nombreArchivo, detalleExcel).onSuccess(function (mensaje) {
                //alertify.success(mensaje);
                EscribirMensaje(mensaje);
            })
                    .onError(function (error) {
                        //alertify.error(error);
                        EscribirMensaje(error);
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
