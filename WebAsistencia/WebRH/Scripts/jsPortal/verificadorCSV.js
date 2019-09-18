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



    /************/
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
        /*VERRR:Esta funcionalidad cno la uso, revizar y revizar el sql , que quedo obsoleto debido a la modificacion de get 
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

        });
    }

    //descargo el recibo unico digital,este es tanto para el empleado como para el empleador
    function downloadRemoteDataB64POSTReciboDigital(url, idRecibo, params, successFunction, errorFunction) {

        downloadSuccessFunction = successFunction;
        downloadErrorFunction = errorFunction;

        Backend.GetReciboPDFDigital(params)
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
                    capaInicio = '<table class="tablex table-stripedx table-bordered table-condensed" style="width:100%"><tbody class="list"><tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:280px;text-align:center" >Descripción</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Pendientes</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Firmados</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Operación</td></tr>';

                    capaFin = '</tbody></table>';

                    capaAcumulada = capaInicio;
                    //genero la lista de liquidaciones
                    for (i = 0; i < longitud; i++) {
                        //como las llamadas son asincronas necesito un id para relacionar las llamadas que pueden ser retornadas en cualquier
                        //orden
                        var s, s2, s3;
                        s = 'rsf' + resp[i].anio + resp[i].mes + resp[i].tipo_liquidacion; //id recibo sin firmar local
                        s2 = 'rf' + resp[i].anio + resp[i].mes + resp[i].tipo_liquidacion; //id recibo firmado local
                        s3 = 'bf' + resp[i].anio + resp[i].mes + resp[i].tipo_liquidacion; //id boton de firma local
                        //capa2 = '<div class="iconInfo">Liquidación <B><span>' + resp[i].id + '   ' + resp[i].anio + '   ' + resp[i].mes + '   ' + resp[i].tipo_liquidacion + '   ' + resp[i].descripcion + '   ' + '</span><span id="' + s + '"></span><span id="' + s2 + '"></span><span id="span' + s3 + '"><input id="' + s3 + '" disabled  style="text-align: right;cursor: pointer;" class="botonGrisadoFirmaM" type="button" value="Firmar" onclick="iniciarOperaciones4(' + s + ');return false;" /></span></B>   </div></BR>';
                        //capa.innerHTML = capa.innerHTML + capa2;

                        /*capaLiq = '<tr><td><div style="margin-top:5px">' + resp[i].id + '</div></td> <td><div style="margin-top:5px">' + resp[i].anio + '</div></td> <td><div style="margin-top:5px">' + resp[i].mes + '</div></td> <td><div style="margin-top:5px">' + resp[i].tipo_liquidacion + '</div></td> <td><div style="margin-top:5px">' + resp[i].descripcion + '</div></td>  <td><div style="margin-top:5px"><span id="' + s + '"></span></div></td>  <td><div style="margin-top:5px"><span id="' + s2 + '"></span></div></td> <td style="text-align: right;"><input id="' + s3 + '" disabled  style="text-align: right;cursor: pointer;" class="botonGrisadoFirmaM" type="button" value="Firmar" onclick="iniciarOperaciones4(\'' + s + '\','+resp[i].anio+',' + resp[i].mes +','+ resp[i].tipo_liquidacion+');return false;" /></td></tr>';
                        */
                        capaLiq = '<tr>  <td><div style="margin-top:5px">' + resp[i].descripcion + '</div></td>  <td><div style="margin-top:5px;text-align:center"><span id="' + s + '"></span></div></td>  <td><div style="margin-top:5px;text-align:center"><span id="' + s2 + '"></span></div></td> <td style="text-align: center;"><input id="' + s3 + '" disabled  style="cursor: pointer;" class="botonGrisadoFirmaM" type="button" value="Firmar" onclick="iniciarOperaciones4(\'' + s + '\',' + resp[i].anio + ',' + resp[i].mes + ',' + resp[i].tipo_liquidacion + ');return false;" /></td></tr>';

                        capaAcumulada = capaAcumulada + capaLiq;

                        Backend.GetIdRecibosSinFirmar(resp[i].tipo_liquidacion, resp[i].anio, resp[i].mes)
                            .onSuccess(function (respuesta) {
                                /*respuesta es la respuesta*/

                                var respListSinFirmar = JSON.parse(respuesta);
                                var s = 'rsf' + respListSinFirmar.anio + respListSinFirmar.mes + respListSinFirmar.tipoLiquidacion;
                                var s3 = 'bf' + respListSinFirmar.anio + respListSinFirmar.mes + respListSinFirmar.tipoLiquidacion;
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
                        Backend.GetIdRecibosFirmados(resp[i].tipo_liquidacion, resp[i].anio, resp[i].mes)
                            .onSuccess(function (respuesta) {

                                var respListFirmados = JSON.parse(respuesta);
                                var s = 'rf' + respListFirmados.anio + respListFirmados.mes + respListFirmados.tipoLiquidacion;

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
        verificarCSV: verificarCSV
        /*getRecibos: getRecibos,
        getLiquidacionesAFirmar: getLiquidacionesAFirmar*/
    };

})(window, undefined);

	
