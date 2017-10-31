/*configuracion de la aplicacion de firma*/
var HOST = Constants.URL_BASE_APP;
var storage = "http://www.milocal.com:8080" + "/AlmacenarFirma"; //document.getElementById('storageService').value;
var retrieve = HOST + "/RecuperarFirma";//document.getElementById('retrieveService').value;
var jnlp = Constants.URL_BASE_JNLP;//document.getElementById('jnlpService').value;
MiniApplet.setServlets(storage, retrieve);
MiniApplet.setJnlpService (jnlp); // URL donde esta el generador de JNLP
if (navigator.platform.indexOf("Linux")!=-1 || navigator.platform.indexOf("Mac")!=-1){
//En Mac y Linux se fuerza la utilización de servidores intermedios
MiniApplet.setForceWSMode(true);
}
//dominio desde el que se realiza la llamada al servicio
//MiniApplet.cargarAppAfirma('miniapplet.js');
MiniApplet.cargarAppAfirma(HOST+'valide/js/miniapplet.js',MiniApplet.KEYSTORE_WINDOWS);

/********funciones de la pagina***/
var RECIBOS = (function (window, undefined) {

    function getTiposLiquidacion() {
        Backend.GetTiposLiquidacion()
        .onSuccess(function (tiposLiquidacion) {
            /*tiposLiquidacion es la respuesta*/
            //var options = document.getElementById("cmb_tipo_liquidacion");
            var select = document.getElementById("cmb_tipo_liquidacion");
            var i;
            //**parsear el objeto json y loopear para cargar las opciones*/
            //recupero la respuesta en forma de objeto json
            //este contine Id,Descripcion

            var resp = JSON.parse(tiposLiquidacion);
            var longitud; //tamaño de la lista de tipos de liquidacion
            longitud = Object.keys(resp).length;

            //genero la lista de opciones
            for (i = 0; i < longitud; i++) {
                var option = document.createElement("option"); //creamos el elemento
                option.value = resp[i].Id; //asignamos valores a sus parametros
                option.text = resp[i].Descripcion;
                select.add(option); //insertamos el elemento
                
            }
            /*usando jquery no me funciona, fix despues*/
            /*$.each(tiposLiquidacion, function () {
            options.append($("<option />").val(this.Id).text(this.Descripcion));
            });*/
        })
        .onError(function (e) {

        });

    }

    /* Metodos que publicamos del objeto RECIBOS */
    return {
        getTiposLiquidacion: getTiposLiquidacion
    }

})(window, undefined);

	
