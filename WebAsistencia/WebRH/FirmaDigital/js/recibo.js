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
            tiposLiquidaciones = resp;
            /*usando jquery no me funciona, fix despues*/
            /*$.each(tiposLiquidacion, function () {
            options.append($("<option />").val(this.Id).text(this.Descripcion));
            });*/
        })
        .onError(function (e) {

        });

    }

    function getRecibos(tipoLiquidacion, anio, mes) {
        /*VERRR:Esta funcionalidad no la uso, revizar y revizar el sql , que quedo obsoleto debido a la modificacion de get 
        id recibo sin firmar*/
        Backend.GetRecibosResumen(tipoLiquidacion, anio, mes)
        .onSuccess(function (recibosResumen) {
            /*recibosResumen es la respuesta*/

            //            lista_recibos_resumen_div = document.getElementById("cmb_tipo_liquidacion");
            var i;
            //recupero la respuesta en forma de objeto json
            //este contine Id_Recibo, legajo,Cuil,Nyap,Nro_Orden

            var resp = JSON.parse(recibosResumen);
            var longitud; //tamaño de la lista resumen de recibos
            longitud = Object.keys(resp).length;

            //genero la lista de recibos a firmar
            for (i = 0; i < longitud; i++) {
                //                var option = document.createElement("option"); //creamos el elemento
                //                option.value = resp[i].Id; //asignamos valores a sus parametros
                //                option.text = resp[i].Descripcion;
                //                select.add(option); //insertamos el elemento

            }
            //guardo la lista de recibos a firmar:
            lista_recibos_resumen = resp;

            //actualizo el mensaje de respuesta
            divMensajeStatus.innerHTML = '&nbsp;';
            divMensajeStatus.innerHTML = '<div class="iconInfo">Se obtubieron <B>' + longitud + '</B> recibos para firmar. </div>';

            //habilito el boton para poder firmar
            btn_firmar.disabled = false;
            btn_firmar.classList.remove('botonGrisadoFirmaM');
            btn_firmar.classList.add('botonFirmaM');

            /*usando jquery no me funciona, fix despues*/
            /*$.each(tiposLiquidacion, function () {
            options.append($("<option />").val(this.Id).text(this.Descripcion));
            });*/
        })
        .onError(function (e) {

        });
    }

    function getIdRecibosSinFirmar(tipoLiquidacion, anio, mes) {
        Backend.GetIdRecibosSinFirmar(tipoLiquidacion, anio, mes)
        .onSuccess(function (recibosResumen) {
            /*recibosResumen es la respuesta*/

            //            lista_recibos_resumen_div = document.getElementById("cmb_tipo_liquidacion");
            var i;
            //recupero la respuesta en forma de objeto json
            //este contine Id_Recibo, legajo,Cuil,Nyap,Nro_Orden

            var resp = JSON.parse(recibosResumen);
            var longitud; //tamaño de la lista resumen de recibos
            longitud = Object.keys(resp).length;

            //genero la lista de recibos a firmar
            for (i = 0; i < longitud; i++) {
                //                var option = document.createElement("option"); //creamos el elemento
                //                option.value = resp[i].Id; //asignamos valores a sus parametros
                //                option.text = resp[i].Descripcion;
                //                select.add(option); //insertamos el elemento

            }
            //guardo la lista de recibos a firmar:
            lista_recibos_resumen = resp;

            //actualizo el mensaje de respuesta
            divMensajeStatus.innerHTML = '&nbsp;';
            divMensajeStatus.innerHTML = '<div class="iconInfo">Se obtubieron <B>' + longitud + '</B> recibos para firmar. </div>';


            //habilito el boton para poder firmar si hay mas de un recibo para firmar
            if (lista_recibos_resumen.length != 0) {
                // divMensajeStatus.innerHTML = '<div class="iconInfo">Debe existir al menos un documento para firmar.</div>';
                btn_firmar.disabled = false;
                btn_firmar.classList.remove('botonGrisadoFirmaM');
                btn_firmar.classList.add('botonFirmaM');
            }


            /*usando jquery no me funciona, fix despues*/
            /*$.each(tiposLiquidacion, function () {
            options.append($("<option />").val(this.Id).text(this.Descripcion));
            });*/
        })
            .onError(function (e) {
            //puede que por la rapides de las consultas y la falta de conexiones disponibles desde un mismo user den error de que se necsita una conexion abierta
            //pero se el estado actual es conectando, asi que vuelvo a realizar una segunda llamada para probar
                Backend.GetIdRecibosSinFirmar(tipoLiquidacion, anio, mes)
                    .onSuccess(function (recibosResumen) {
                        /*recibosResumen es la respuesta*/

                        //            lista_recibos_resumen_div = document.getElementById("cmb_tipo_liquidacion");
                        var i;
                        //recupero la respuesta en forma de objeto json
                        //este contine Id_Recibo, legajo,Cuil,Nyap,Nro_Orden

                        var resp = JSON.parse(recibosResumen);
                        var longitud; //tamaño de la lista resumen de recibos
                        longitud = Object.keys(resp).length;

                        //genero la lista de recibos a firmar
                        for (i = 0; i < longitud; i++) {
                            //                var option = document.createElement("option"); //creamos el elemento
                            //                option.value = resp[i].Id; //asignamos valores a sus parametros
                            //                option.text = resp[i].Descripcion;
                            //                select.add(option); //insertamos el elemento

                        }
                        //guardo la lista de recibos a firmar:
                        lista_recibos_resumen = resp;

                        //actualizo el mensaje de respuesta
                        divMensajeStatus.innerHTML = '&nbsp;';
                        divMensajeStatus.innerHTML = '<div class="iconInfo">Se obtubieron <B>' + longitud + '</B> recibos para firmar. </div>';


                        //habilito el boton para poder firmar si hay mas de un recibo para firmar
                        if (lista_recibos_resumen.length != 0) {
                            // divMensajeStatus.innerHTML = '<div class="iconInfo">Debe existir al menos un documento para firmar.</div>';
                            btn_firmar.disabled = false;
                            btn_firmar.classList.remove('botonGrisadoFirmaM');
                            btn_firmar.classList.add('botonFirmaM');
                        }


                        /*usando jquery no me funciona, fix despues*/
                        /*$.each(tiposLiquidacion, function () {
                        options.append($("<option />").val(this.Id).text(this.Descripcion));
                        });*/
                    })
                    .onError(function (e) {

                    });

        });
    }


    //nota: no la uso , descarga archivo ya codificado en base64
    function downloadRemoteDataB64POSTXXXXXXXYO(url, params, successFunction, errorFunction) {

        downloadSuccessFunction = successFunction;
        downloadErrorFunction = errorFunction;

        var httpRequest = Generales.getHttpRequest();
        httpRequest.open("POST", url, true);
        httpRequest.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

        httpRequest.onreadystatechange = function (evt) {
            //if (httpRequest.readyState == 4 && httpRequest.status == 200) {
            //	if (downloadSuccessFunction) {	document.getElementById('result').value =httpRequest.responseText; 				
            //en el caso de los archivos estos ya vienen en b64 porque aun no encontre una funcion de conversion a b64 que codifique correctamente desde javascript
            //downloadSuccessFunction(httpRequest.responseText);
            //	}
            if (httpRequest.readyState === httpRequest.DONE) {
                if (httpRequest.status === 200) {
                    if (downloadSuccessFunction) {
                        //en el caso de los archivos estos ya vienen en b64 porque aun no encontre una funcion de conversion a b64 que codifique correctamente desde javascript
                        downloadSuccessFunction(httpRequest.responseText);
                    }
                }
            }
            //}
        }
        httpRequest.onerror = function (e) {
            if (downloadErrorFunction) {
                downloadErrorFunction(e);
            }
            //				else {
            //					console.log("Error en la descarga de los datos. No se invoca a ninguna funcion.");
            //				}
        }
        httpRequest.send(params);
    }
    //nNOTA: no la uso, Modo anterior
    function downloadRemoteDataB64POSTEmpleador(url, idRecibo, params, successFunction, errorFunction) {

        downloadSuccessFunction = successFunction;
        downloadErrorFunction = errorFunction;

        Backend.GetReciboPDFEmpleador(params)
                .onSuccess(function (res) {
                    //en esta version siempre retorna exito a menos que sea un error antes del webservice
                    if (!res.DioError) {
                        //en el caso de los archivos estos ya vienen en b64 porque aun no encontre una funcion de conversion a b64 que codifique correctamente desde javascript
                        downloadSuccessFunction(res.Respuesta, idRecibo);
                    }

                })
            .onError(function (e) {
                downloadErrorFunction(e);
            });


    }


    function downloadRemoteDataB64POSTReciboPlano(url, idRecibo, params, successFunction, errorFunction) {

        downloadSuccessFunction = successFunction;
        downloadErrorFunction = errorFunction;

        Backend.GetReciboParseado(params)
                .onSuccess(function (res) {
                    //en esta version siempre retorna exito a menos que sea un error antes del webservice
                    if (!res.DioError) {
                        //en el caso de los archivos estos ya vienen en b64 porque aun no encontre una funcion de conversion a b64 que codifique correctamente desde javascript
                        downloadSuccessFunction(res.Respuesta, idRecibo);
                    }

                })
            .onError(function (e) {
                downloadErrorFunction(e);
            });


    }


    //nota: no la uso, como no necesito mandar mas que el idRecibo directamente llamo al ws desde el backend
    function downloadRemoteDataB64POSTEmpleado(url, idRecibo, params, successFunction, errorFunction) {

        downloadSuccessFunction = successFunction;
        downloadErrorFunction = errorFunction;

        Backend.GetReciboPDFEmpleado(params)
                .onSuccess(function (res) {

                    //en el caso de los archivos estos ya vienen en b64 porque aun no encontre una funcion de conversion a b64 que codifique correctamente desde javascript
                    downloadSuccessFunction(res, idRecibo);
                })
            .onError(function (e) {
                downloadErrorFunction(e);
            });


    }

    //descargo el recibo unico digital,este es tanto para el empleado como para el empleador
    function downloadRemoteDataB64POSTReciboDigital(url, idRecibo, params, successFunction, errorFunction) {

        downloadSuccessFunction = successFunction;
        downloadErrorFunction = errorFunction;

        Backend.GetReciboPDFDigital(params,0)/*se asume que el modo es 0 indicando que se deben obtener los datos de los recibos actuales y no los historicos*/
                .onSuccess(function (res) {
                    //en esta version siempre retorna exito a menos que sea un error antes del webservice
                    if (!res.DioError) {
                        //en el caso de los archivos estos ya vienen en b64 porque aun no encontre una funcion de conversion a b64 que codifique correctamente desde javascript
                        downloadSuccessFunction(res.Respuesta, idRecibo);
                    } else {
                        //en caso de error continuar el proceso
                        downloadErrorFunction("error obteniendo el pdf"); //se intento realizar una operacion mas
                        verificarContinuacionProceso(0);
                    }
                    

                })
            .onError(function (e) {
                downloadErrorFunction(e);
            });


    }

    function guardarReciboPDFFirmado(idLiquidacion,idRecibo, signatureB64, anio, mes, tipoLiquidacion, successFunction, errorFunction) {

        saveSuccessFunction = successFunction;
        saveErrorFunction = errorFunction;

        Backend.GuardarReciboPDFFirmado(signatureB64, idLiquidacion, idRecibo, anio, mes, tipoLiquidacion)
                .onSuccess(function (res) {

                    //en el caso de los archivos estos ya vienen en b64 porque aun no encontre una funcion de conversion a b64 que codifique correctamente desde javascript
                    saveSuccessFunction(res);
                })
            .onError(function (e) {
                saveErrorFunction(e);
            });


    }

    //NOTA: no la uso
    function firmarRecibosxxxx(lista_recibos_resumen) {
        Backend.firmarRecibos(tipoLiquidacion, anio, mes)
        .onSuccess(function (recibosResumen) {
            /*recibosResumen es la respuesta*/

            //            lista_recibos_resumen_div = document.getElementById("cmb_tipo_liquidacion");
            var i;
            //recupero la respuesta en forma de objeto json
            //este contine Id_Recibo, legajo,Cuil,Nyap,Nro_Orden

            var resp = JSON.parse(recibosResumen);
            var longitud; //tamaño de la lista resumen de recibos
            longitud = Object.keys(resp).length;

            //genero la lista de recibos a firmar
            for (i = 0; i < longitud; i++) {
                //                var option = document.createElement("option"); //creamos el elemento
                //                option.value = resp[i].Id; //asignamos valores a sus parametros
                //                option.text = resp[i].Descripcion;
                //                select.add(option); //insertamos el elemento

            }
            //guardo la lista de recibos a firmar:
            lista_recibos_resumen = resp;

            //actualizo el mensaje de respuesta
            divMensajeSign.innerHTML = '&nbsp;';
            divMensajeSign.innerHTML = '<div class="iconInfo">Se obtubieron <B>' + longitud + '</B> recibos para firmar. </div>';

            //habilito el boton para poder firmar
            btn_firmar.disabled = false;
            btn_firmar.classList.remove('botonGrisadoFirmaM');
            btn_firmar.classList.add('botonFirmaM');

            /*usando jquery no me funciona, fix despues*/
            /*$.each(tiposLiquidacion, function () {
            options.append($("<option />").val(this.Id).text(this.Descripcion));
            });*/
        })
        .onError(function (e) {

        });
    }

    /*NOTA: no la uso BORRAR*/
    function getIdRecibosFirmados2(tipoLiquidacion, anio, mes) {
        Backend.GetIdRecibosFirmados(tipoLiquidacion, anio, mes)
        .onSuccess(function (recibosResumen) {
            /*recibosResumen es la respuesta*/

            //este contine Id_Recibo, legajo,Cuil,Nyap,Nro_Orden

            //var resp = JSON.parse(recibosResumen);

            if (!recibosResumen.DioError) {
                respListFirmados = JSON.parse(recibosResumen.Respuesta);

            }
        })
        .onError(function (e) {
            console.log(e);
        });
    }

    //variables globales ya no usadas
    //var respListSinFirmar;
    //var respListFirmados;

    function getLiquidacionesAFirmar() {

        Backend.GetLiquidacionesAFirmar()
                .onSuccess(function (respLiquidaciones) {

                    /*respLiquidaciones es la respuesta*/
                    //var capa = document.getElementById("capaListaLiquidaciones"); //borrar
                    var capaListaLiq = document.getElementById("listaDeLiquidaciones");
                    var i;
                    //**parsear el objeto json y loopear para cargar las liquidaciones*/
                    //recupero la respuesta en forma de objeto json
                    //este contiene id,descripcion,anio,mes,tipo_liquidacion

                    var resp = JSON.parse(respLiquidaciones);
                    var longitud; //tamaño de la lista de liquidaciones
                    longitud = Object.keys(resp).length;
                    var lista_recibos_resumen;
                    //capa.innerHTML = '';
                    //var capa2 = '';
                    var capaInicio = ''; //representa la capa que muestran a las liquidaciones
                    var capaFin = '';
                    var capaLiq = '';
                    var capaAcumulada = '';
                    /*capaInicio = '<table class="tablex table-stripedx table-bordered table-condensed" style="width:100%"><tbody class="list"><tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Liquidación</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:65px;" >Año</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:105px;" >Mes</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Tipo Liquidación</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:230px;" >Descripción</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Pendientes</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Firmados</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Operación</td></tr>';
                    */
                    capaInicio = '<table class="stripedGris tablex table-stripedx table-bordered table-condensed" style="width:94%"><tbody class="list"><tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:280px;text-align:center" >Descripción</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Pendientes</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Firmados</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Operación</td></tr>';

                    capaFin = '</tbody></table>';

                    capaAcumulada = capaInicio;
                    //genero la lista de liquidaciones
                    for (i = 0; i < longitud; i++) {
                        //como las llamadas son asincronas necesito un id para relacionar las llamadas que pueden ser retornadas en cualquier
                        //orden
                        var s, s2, s3;
                        s = 'rsf' + resp[i].id + resp[i].anio + resp[i].mes + resp[i].tipo_liquidacion; //id recibo sin firmar local
                        s2 = 'rf' + resp[i].id + resp[i].anio + resp[i].mes + resp[i].tipo_liquidacion; //id recibo firmado local
                        s3 = 'bf' + resp[i].id + resp[i].anio + resp[i].mes + resp[i].tipo_liquidacion; //id boton de firma local
                        //capa2 = '<div class="iconInfo">Liquidación <B><span>' + resp[i].id + '   ' + resp[i].anio + '   ' + resp[i].mes + '   ' + resp[i].tipo_liquidacion + '   ' + resp[i].descripcion + '   ' + '</span><span id="' + s + '"></span><span id="' + s2 + '"></span><span id="span' + s3 + '"><input id="' + s3 + '" disabled  style="text-align: right;cursor: pointer;" class="botonGrisadoFirmaM" type="button" value="Firmar" onclick="iniciarOperaciones4(' + s + ');return false;" /></span></B>   </div></BR>';
                        //capa.innerHTML = capa.innerHTML + capa2;

                        /*capaLiq = '<tr><td><div style="margin-top:5px">' + resp[i].id + '</div></td> <td><div style="margin-top:5px">' + resp[i].anio + '</div></td> <td><div style="margin-top:5px">' + resp[i].mes + '</div></td> <td><div style="margin-top:5px">' + resp[i].tipo_liquidacion + '</div></td> <td><div style="margin-top:5px">' + resp[i].descripcion + '</div></td>  <td><div style="margin-top:5px"><span id="' + s + '"></span></div></td>  <td><div style="margin-top:5px"><span id="' + s2 + '"></span></div></td> <td style="text-align: right;"><input id="' + s3 + '" disabled  style="text-align: right;cursor: pointer;" class="botonGrisadoFirmaM" type="button" value="Firmar" onclick="iniciarOperaciones4(\'' + s + '\','+resp[i].anio+',' + resp[i].mes +','+ resp[i].tipo_liquidacion+');return false;" /></td></tr>';
                        */
                        capaLiq = '<tr>  <td><div style="margin-top:5px">' + resp[i].descripcion + '</div></td>  <td><div style="margin-top:5px;text-align:center"><span id="' + s + '"></span></div></td>  <td><div style="margin-top:5px;text-align:center"><span id="' + s2 + '"></span></div></td> <td style="text-align: center;"><input id="' + s3 + '" disabled  style="cursor: pointer;" class="botonGrisadoFirmaM" type="button" value="Firmar" onclick="iniciarOperaciones4(\'' + s + '\',' + '\'' + s3 + '\',' + resp[i].anio + ',' + resp[i].mes + ',' + resp[i].tipo_liquidacion + ',' + resp[i].id + ');return false;" /></td></tr>';

                        capaAcumulada = capaAcumulada + capaLiq;

                        Backend.GetIdRecibosSinFirmar(resp[i].id,resp[i].tipo_liquidacion, resp[i].anio, resp[i].mes)
                            .onSuccess(function (respuesta) {
                                /*respuesta es la respuesta*/

                                var respListSinFirmar = JSON.parse(respuesta);
                                var s = 'rsf' + respListSinFirmar.idLiquidacion + respListSinFirmar.anio + respListSinFirmar.mes + respListSinFirmar.tipoLiquidacion;
                                var s3 = 'bf' + respListSinFirmar.idLiquidacion + respListSinFirmar.anio + respListSinFirmar.mes + respListSinFirmar.tipoLiquidacion;
                                var lista = JSON.parse(respListSinFirmar.recibosSinFirmar);
                                var long = Object.keys(lista).length;

                                //guardo la lista de recibos sin firmar
                                rsfLiquidaciones[s] = lista;

                                document.getElementById(s).innerHTML = long;

                                if (long > 0) {//faltan firmar recibos
                                    //habilitar boton y cambiar estilo a rojo                                    
                                    var btn_firmar = document.getElementById(s3);
                                    btn_firmar.disabled = false;
                                    btn_firmar.classList.remove('botonGrisadoFirmaM');
                                    btn_firmar.classList.add('botonFirmaM');

                                    //agrego a la lista de botones habilitados el boton habilitado
                                    listaBotonesHabilitados.push(s3);

                                }

                            })
                            .onError(function (e) {

                            });
                        Backend.GetIdRecibosFirmados(resp[i].id, resp[i].tipo_liquidacion, resp[i].anio, resp[i].mes)
                            .onSuccess(function (respuesta) {

                                var respListFirmados = JSON.parse(respuesta);
                                var s = 'rf' + respListFirmados.idLiquidacion + respListFirmados.anio + respListFirmados.mes + respListFirmados.tipoLiquidacion;

                                var lista = JSON.parse(respListFirmados.recibosFirmados);
                                var long = Object.keys(lista).length;
                                //guardo la lista de recibos sin firmar
                                rfLiquidaciones[s] = lista;

                                document.getElementById(s).innerHTML = long;

                            })
                            .onError(function (e) {

                            });

                    }
                    liquidaciones = resp; //VEERRRRRR YA NO LO USO

                    capaAcumulada = capaAcumulada + capaFin;
                    capaListaLiq.innerHTML = capaAcumulada;
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
        getTiposLiquidacion: getTiposLiquidacion,
        getRecibos: getRecibos,
        downloadRemoteDataB64POSTEmpleador: downloadRemoteDataB64POSTEmpleador,
        downloadRemoteDataB64POSTReciboPlano: downloadRemoteDataB64POSTReciboPlano,
        downloadRemoteDataB64POSTEmpleado: downloadRemoteDataB64POSTEmpleado,
        guardarReciboPDFFirmado: guardarReciboPDFFirmado,
        getIdRecibosSinFirmar: getIdRecibosSinFirmar,
        getLiquidacionesAFirmar: getLiquidacionesAFirmar,
        downloadRemoteDataB64POSTReciboDigital: downloadRemoteDataB64POSTReciboDigital,
        getLiquidacionesAFirmar: getLiquidacionesAFirmar
    };

})(window, undefined);

	
