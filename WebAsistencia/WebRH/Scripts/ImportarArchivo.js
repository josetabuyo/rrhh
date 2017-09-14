var ImportarArchivoABaseDeDatos = {

    Importar: function (nombreArchivo, detalleExcel) {

        alertify.confirm("Importación de Archivo", "¿Desea importar el archivo?", function () {
            Backend.ImportarArchivoExcel(nombreArchivo, detalleExcel).onSuccess(function (mensaje) {
                alertify.success(mensaje);
            })
                    .onError(function (error) {
                        //alertify.error("Se produjo un error");
                        alertify.error(error);
                    });

        }, function () {
            alertify.success("Importación cancelada");
        }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });


    }

}




//function myFunction() {
//    var path = document.getElementById("FileUpload").value;
//    //document.getElementById("pathArchivo").innerHTML = path;
//    $('#<%=pathArchivo.ClientID%>').text(path);
//    setfilename(path);
//}
//function setfilename(val) {
//    filename = val.split('\\').pop().split('/').pop();
//    //document.getElementById("nombreArchivo").innerHTML = filename;
//    $('#<%=nombreArchivo.ClientID%>').text(filename);
//}