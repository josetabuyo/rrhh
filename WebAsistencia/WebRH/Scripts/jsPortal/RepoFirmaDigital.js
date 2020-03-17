var GeneralPortal = {
    conformar: function (idRecibo, resultado, obs) {

        var spinner = new Spinner({ scale: 2 });
        //spinner.spin($("html")[0]);

        Backend.ConformarRecibo(idRecibo, resultado, obs)
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
                    boton1 = "<button type='button' onclick=\"GeneralPortal.descargarRecibo(\'" + respuesta.idArchivo + "\')\">Descargar</button>";
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
    descargarRecibo: function (idArchivo) {
        //hacer

        //Backend.GetReciboPDFEmpleado(idRecibo)
        /*forma de descarga de generacion de pdf al vuelo, sin el sello de la firma digital*/
//        Backend.GetReciboPDFDigital(idRecibo) 
        /*forma de descarga desde la tabla de archivos firmados*/
        Backend.GetReciboPDFDigitalArchivado(idArchivo)
            .onSuccess(function (res) {
                //en esta version siempre retorna exito a menos que sea un error antes del webservice
                if (!res.DioError) {
                    //en el caso de los archivos estos ya vienen en b64 porque aun no encontre una funcion de conversion a b64 que codifique correctamente desde javascript
//                    downloadSuccessFunction(res.Respuesta, idRecibo);

                    //obtengo el pdf en b64
                    var b64 = res.Respuesta;

                    //NOTA: para obligar a que si se tiene el plugin del navegador para ver pdf se debe cambiar octet-stream por "pdf" en ambas 
                    //NOTA2: esta solucion solo vale para un pdf descargado sin firma, porque el plugin por alguna razon
                    //si el archivo esta firmado, intenta utilizar como nombre del archivo todo el contenido mas un or binario
                    //en cambio en modo sin firma utiliza el nombre default del pdf "document.pdf", lo del nombre depende del plugin
                    //se podria modificar el plugin para que acepte como parametro el nombre del pdf
                    //otra mejor seria setear el encabezado del archivo descargado desde el server, obligandolo tipo:

                    /*
                    const result = json2csv({ data });

                    res.writeHead(200
                     'Content-Type': 'application/octet-stream',
                     'Content-Disposition': 'attachment;filename=issues.csv',
                     'Content-Length': result.length
                    });

                  res.end(result);
                    */
                    /******************************/
                    //var myWindow = window.open("data:application/pdf;base64," + b64);
                    var base64Data = b64;
                    var arrBuffer = base64ToArrayBuffer(base64Data);

                    // It is necessary to create a new blob object with mime-type explicitly set
                    // otherwise only Chrome works like it should
                    var newBlob = new Blob([arrBuffer], { type: "application/pdf" });

                    // IE doesn't allow using a blob object directly as link href
                    // instead it is necessary to use msSaveOrOpenBlob
                    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
                        window.navigator.msSaveOrOpenBlob(newBlob);
                        return;
                    }

                    // For other browsers: 
                    // Create a link pointing to the ObjectURL containing the blob.
                    var data = window.URL.createObjectURL(newBlob);

                    var link = document.createElement('a');
                    document.body.appendChild(link); //required in FF, optional for Chrome
                    link.href = data; link.target = "_blank";
                    link.download = agenteActual + " " +idArchivo+".pdf";//este elemento hace que se descargue automaticamente si lo saco se abrira otra pagina
                    link.click();
                    window.URL.revokeObjectURL(data);
                    link.remove(); 

                    /********************************/
//                    window.open("data:application/octet-stream;base64," + b64);
                    //var url = 'data:application/pdf;base64,' + Base64.encode(out); document.location.href = url;
  //                  var url = 'data:application/octet-stream;base64,' + b64; 


/*                    var msg = atob(b64);
                    var blob = new File([msg], "hello.pdf", { "type": "application/octet-stream" });

                    var a = document.createElement("a");
                    a.href = URL.createObjectURL(blob);
*/
   //                 window.location.href = a;

 /*                   var pdfWindow = window.open("",idRecibo,"_TARGET");
pdfWindow.document.write("<iframe width='100%' height='100%' src='data:application/pdf;base64, " + encodeURI(b64) + "'></iframe>");
*/
                }

            /********************************HACER************/
                




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

function base64ToArrayBuffer(data) {
    var binaryString = window.atob(data);
    var binaryLen = binaryString.length;
    var bytes = new Uint8Array(binaryLen);
    for (var i = 0; i < binaryLen; i++) {
        var ascii = binaryString.charCodeAt(i);
        bytes[i] = ascii;
    }
    return bytes;
};

