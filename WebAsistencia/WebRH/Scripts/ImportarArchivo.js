var ImportarArchivoABaseDeDatos = {

    Importar: function (nombreArchivo, detalleExcel) {

        alertify.confirm("Importación de Archivo", "¿Desea importar el archivo?", function () {
            Backend.ImportarArchivoExcel(nombreArchivo, detalleExcel).onSuccess(function () {
                alertify.success("Se importó correctamente");
            })
                    .onError(function () {
                        alertify.error("Se produjo un error");
                    });

        }, function () {
            alertify.success("Importación cancelada");
        }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });


    }


}