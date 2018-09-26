var GeneralPortal = {
    conformar: function (idRecibo) {

        var spinner = new Spinner({ scale: 2 });
        //spinner.spin($("html")[0]);

        Backend.ConformarRecibo(idRecibo)
            .onSuccess(function (respuestaJSON) {
                //spinner.stop();
                var respuesta = JSON.parse(respuestaJSON);
                var texto1;
                var div_caja_info_recibos = $("#caja_info_recibos");

                //reseteo el cuadro de conformacion
                div_caja_info_recibos.empty();

                if (respuesta.tipoDeRespuesta = "conformarRecibo.ok") {
                    // agrego un enlace de descarga
                    texto1 = "<BR/>";
                    boton1 = "<button type='button' onclick=\"GeneralPortal.descargarRecibo(\'" + idRecibo + "\')\">Descargar</button>";
                    div_caja_info_recibos.append(texto1 + boton1);

                } else { 
                    // muestro un mensaje de error 
                    texto1 = "<BR/><B>No se a podido conformar el recibo.</B>";
                    div_caja_info_recibos.append(texto1);
                }

                /*<div id="caja_info_recibos">
                
             </div>*/
                //cosas por hacer   [dbo].[PLA_UPD_ConformarRecibo]
                //$("#tabla_recibo_encabezado > tbody ").append(detalle);


            })
            .onError(function (e) {
                //por aca nunca se entra si desde el webserver no se levanta una excepcion   
                //spinner.stop();
            });

    },
    descargarRecibo: function (idRecibo) {
        //hacer

        Backend.GetReciboPDFEmpleado(idRecibo)
            .onSuccess(function (respuestaJSON) {


            /********************************HACER************/
                //obtengo el pdf en b64

                var b64=respuestaJSON;

                window.open("data:application/pdf;base64," + b64); 
                //var url = 'data:application/pdf;base64,' + Base64.encode(out); document.location.href = url;
                var url = 'data:application/pdf;base64,' + b64; 
        //        document.location.href = url;


                //spinner.stop();
        //        var respuesta = JSON.parse(respuestaJSON);
        //        var texto1;
        //        var div_caja_info_recibos = $("#caja_info_recibos");

                //reseteo el cuadro de conformacion
        //        div_caja_info_recibos.empty();
        
        //        if (respuesta.tipoDeRespuesta = "conformarRecibo.ok") {
                    // agrego un enlace de descarga
                    //  texto1 = "<BR/>No se a podido conformar el recibo.";
                    //   div_caja_info_recibos.append(texto1);

        //        } else {
                    // muestro un mensaje de error 
         //           texto1 = "<BR/><B>No se a podido conformar el recibo.</B>";
         //           div_caja_info_recibos.append(texto1);
         //       }

                /*<div id="caja_info_recibos">
                
                </div>*/
                //cosas por hacer   [dbo].[PLA_UPD_ConformarRecibo]
                //$("#tabla_recibo_encabezado > tbody ").append(detalle);


            })
            .onError(function (e) {
                //por aca nunca se entra si desde el webserver no se levanta una excepcion   
                //spinner.stop();
            });


    }
};