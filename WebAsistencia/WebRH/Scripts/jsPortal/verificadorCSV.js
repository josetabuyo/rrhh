/********funciones de la pagina***/

var CSV = (function (window, undefined) {

    function verificarCSV(codigoCSV) {

        //asumo que el proceso es rapido por eso no pongo un cargando ...
        //siempre iniciar el Backend para asi poder disponer de los metodos del webservice......!
        //en este caso como es asincrono , luego de ejecutarse llamo a la funcion VerificarCSV..
        Backend.start(function () {
            Backend.VerificarCSV(codigoCSV)
                .onSuccess(function (res) {
                    var resp = JSON.parse(res);
                    if (resp.tipoDeRespuesta == "ok") { //todo salio bien
                        ocultarAlert() //limpio avisos de error                        
                        divCuil.innerHTML = resp.cuil;
                        divPeriodo.innerHTML = resp.periodo;
                        divNeto.innerHTML = resp.neto;
                        mostrarPanelRecibo();
                    } else {
                        document.getElementById("alertFiltro").innerHTML = "Recibo inexistente";
                        mostrarAlert();
                    }
                    //en el caso de los archivos estos ya vienen en b64 porque aun no encontre una funcion de conversion a b64 que codifique correctamente desde javascript
                    //saveSuccessFunction(res);
                })
            .onError(function (e) {
                //deberia indicar que hubo un error en pantalla???
            });
        });

    }

    function obtenerValorParametro(sParametroNombre) {
        var sPaginaURL = window.location.search.substring(1);
        var sURLVariables = sPaginaURL.split('&');
        for (var i = 0; i < sURLVariables.length; i++) {
            var sParametro = sURLVariables[i].split('=');
            if (sParametro[0] == sParametroNombre) {
                return sParametro[1];
            }
        }
        return null;
    }





    

    /* Metodos que publicamos del objeto RECIBOS */
    return {
        verificarCSV: verificarCSV,
        obtenerValorParametro: obtenerValorParametro
    };

})(window, undefined);

	
