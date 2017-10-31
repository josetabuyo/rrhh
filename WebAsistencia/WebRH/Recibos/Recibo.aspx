<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recibo.aspx.cs" Inherits="Portal_Recibo" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!Doctype html>
<html lang="es">
    <head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width"/>
        <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>

        <link rel="stylesheet" href="estilosPortalSecciones.css" />




        <link rel="stylesheet" href="recibo.css" />





    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:17px; "></h1>
        
        <div style="text-align:center;" class="caja_izq no-print"></div>

        <!--contenido derecho -->
         <div  class="caja_der papel" >
         <fieldset>
         <legend style="margin-top: 20px;">FIRMA DE RECIBOS</legend>
         </fieldset>
         <div id="div_recibo">            
         <div  style="margin:10px;">
            <p>Seleccione la lista de recibos a firmar:</p>
         <!--   <select style="width:130px;" id="cmb_filtro">
                <option value="0">Sin Firmar</option>
                <option value="1">Firmado Conforme</option>
                <option value="2">Firmado No Conforme</option>
             </select>-->
             <!--nota: 0: indica que se firmen todos los tipos de liquidacion-->
             <select style="width:230px;" id="cmb_tipo_liquidacion" size="1">
                <option value="0" selected>TODOS</option>
             </select>
            <!--TODO: cargar dinamicamente los select si no se quieren mostrar meses no vigentes para el año actual-->
             <select style="width:65px;" id="cmb_anio">
                <option value="2017" selected>2017</option>
             </select>
             <select style="width:105px;" id="cmb_meses">
                <option value="1" selected>Enero</option>
                <option value="2">Febrero</option>
                <option value="3">Marzo</option>
                <option value="4">Abril</option>
                <option value="5">Mayo</option>
                <option value="6">Junio</option>
                <option value="7">Julio</option>
                <option value="8">Agosto</option>
                <option value="9">Septiembre</option>
                <option value="10">Octubre</option>
                <option value="11">Noviembre</option>
                <option value="12">Diciembre</option>
             </select>
              &nbsp;&nbsp;&nbsp;<input id="Buscar" class="botonFirmaM" type="button" value="Buscar" onclick="javascript:buscarRecibos();return false;" />
              <!--<div id="caja_controles"> </div>-->
         
         <!-- 	estatus de la operacion realizada --> 
         <div id ="Div1"> 
         <div id ="Div2"></div><div id ="Div3"></div>
         <div id ="Div4"></div><div id ="Div6"></div>
         </div>

        <!--  <div class="Table"> 
            <div class="Title"><p> Esta es la tabla</p> </div>  
            <div class="Heading"> <div class="Cell">
              <p> Primer Nombre</p>  
            </div>  
            <div class="Cell"><p> Segundo Nombre</p></div>  
            <div class="Cell"> <p>  Edad</p> </div>  
         </div>--> 
         <div class="Row"> 
            <div class="Cell"> <p>  Operación</p> </div>  
            <div class="Cell"> <p>  xxx </p>  </div> 
         </div>  
         <div class="Row"> 
            <div class="Cell"> <p>  Estatus</p> </div>  
            <div class="Cell" id="divmensaje"> <p>  ...</p>  </div> 
         </div> 
  
    </div>  

              
         <!-- 	lista de recibos a firmar -->    
	     <div id ="resumenRecibos" class="resultadoValidar">        
	     </div>

       <!--   </div>
          <div><table class="tablex table-stripedx table-bordered table-condensed" style="cursor: pointer;width:100%">
				 <tbody class="list">
				    <tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:10pt" >Operación</td>
                        <td style="text-align: right"><input id="botonFirmas" class="botonFirmaM" type="button" value="Firmar Seleccionados" onclick="javascript:iniciarOperaciones();return false;" /></td>
                    </tr>
				    <tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Estatus</td><td><div id="divmensaje">&nbsp;</div></td></tr>
				 </tbody>
               </table>
           </div><br/>

         <table id="tabla_recibo_encabezado">
            <thead>
                <tr class="fila_header">
                    <th style="width:67px;" class="">Legajo No.</th>
                    <th style="width:311px;" class="">Apellido y Nombre</th>
                    <th style="width:100px;">CUIL</th>
                    <th style="width:40px;">Of.</th>
                    <th style="width:85px;">N. Orden</th>
                </tr>
           
                <tr style="height: 30px;">
                    <td id="celdaLegajo"></td>
                    <td id="celdaNombre"></td>
                    <td id="celdaCUIL"></td>
                    <td id="celdaOficina"></td>
                    <td id="celdaOrden"></td>
                </tr>
            <tr class="fila_header">
                    <th colspan="1" rowspan="2" class="ancho_primera_columna">Código</th>
                    <th colspan="1" rowspan="2" class="ancho_segunda_columna">Descripción</th>
                    <th colspan="3" class="">Importe</th>
                </tr>
                <tr class="fila_header">
                    <th colspan="1" style="width:110px;">Haberes</th>
                    <th colspan="2" style="width:110px;">Descuentos</th>
                </tr>
           </thead>
           <tbody>
               
            </tbody>
         </table>
         
        <p style="font-weight: bold; text-align: center; margin-top: 20px;">SOLO PARA INFORMACIÓN - NO VÁLIDO COMO COMPROBANTE</p>
       <div id="bloque_final" style="display:none; margin-top:20px;">
            <p><strong>Área:</strong> <span id="area"></span></p>
            <p><strong>Categ:</strong> <span id="categoria"></span></p>
            <p><strong>Fecha Liq:</strong> <span id="fechaLiquidacion"></span></p>
            <p><strong>Domicilio:</strong> <span id="domicilio"></span></p>
        </div>
-->

<%--///////////////////////////////////////
         <p>Recibí el importe neto y Copia del recibo de la presente liquidación.</p>
         <p>Certifico que el Nro. de Documento <span>xxxx</span> corresponde a mi Documento Civico (Decreto N°: 1221/80).</p>
         
         

         <br />
         <p>Firma del empleado: <span class="subrayado"></span></p>

         <p>Firma Autorizante: <span class="subrayado"></span></p>

         <p>Articulo 12 de la Ley N° 17250, Depositado: <span></span></p>

         </div>--%>
         
         </div>
         </div>
        <!--FIN contenido derecho -->
    </div>
    </form>
</body>


<script type="text/javascript" src="miniapplet.js"></script>
<script type="text/javascript" src="constantes.js"></script>
<script type="text/javascript" src="recibo.js"></script>


<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {
        //NOTA: por el momento lo deshabilito porque da error
        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm", function () {
            Backend.start(function () {
                // las funciones de inicio se deben ejecutar aqui dentro
                //cargo las listas seleccionables
                RECIBOS.getTiposLiquidacion();



                /*          Legajo.getNombre();

                Legajo.bindearBotonLiquidacion();

                $("#tabla_recibo_encabezado").hide();
                var day = new Date();
                var mes = day.getMonth() + 1;
                var anio = day.getFullYear();

                $("#cmb_meses").val(mes)
                $("#cmb_anio").trigger('change');*/
                //$("#cmb_meses").val(mes).trigger('change');
            });
        });

        
        
    });

    
</script> 

<!-- js de los servicios de validacion de firma -->
<script type="text/javascript" defer="defer">
    var btn_validarSign = document.getElementById('botonValidarSign');
    var divMensajeSign = document.getElementById('divMensajeSign');
    var divMensajesRequisitos = document.getElementById('validarFirmaForm.errors');
    //guardo el contenido del archivo de disco en una var pero tambien puede
    //ubicarse en un input hidden
    //<input id="fff" name="fff" type="hidden" value="">
    var contenidoSignExterno = "";

    function mostrarPanelInicialValidacionSign() {
        //oculto el panel del resultado
        document.getElementById('resultFirmaForm').style.display = 'none';
        //muestro el panel de seleccion de documento firmado 
        document.getElementById('validarFirmaForm').style.display = 'block';

    }

    function cleanMensajesValidadorFirmaError() {
        //limpio los mensajes de requisitos antes de validar,pj debe seleccionar un archivo
        divMensajesRequisitos.style.display = 'none';
        //limpio los mensajes de invalidez de las firmas del documento
        divMensajeSign.innerHTML = '&nbsp;';

    }

    function validarFirma() {
        var doc = null;
        var validezSign = false; //validez de la firma

        /**NOTA: por default no reseteo el valor del documento seleccionado
        despues de una solicitud de validacion**/

        if (document.getElementById('ficheroDOC').value == '') {
            //entonces no se selecciono ningun archivo  
            divMensajesRequisitos.innerHTML = 'Debe seleccionar un archivo firmado.';
            divMensajesRequisitos.style.display = 'block';
        } else {
            //verifico el tamaño del archivo
            if (sizeDoc > MAX_BYTES) {
                divMensajesRequisitos.innerHTML = 'El archivo supera los 8 Megas.';
                divMensajesRequisitos.style.display = 'block';
            } else {
                //se selecciono un archivo desde disco
                //NOTA: la carga del contenido del fichero es asincrona asi
                //que puede darse que no termine antes de realizar el evento
                //validarFirma
                //alert(contenidoCertExterno);

                doc = Base64.encodeArrayBuffer(contenidoSignExterno, false);


                //deshabilito el boton 
                btn_validarSign.disabled = true;
                btn_validarSign.classList.remove('botonP');
                btn_validarSign.classList.add('botonGrisadoP');

                //Muestro un mensaje de procesando
                divMensajeSign.innerHTML = '<BR><div class="iconProcesando">Procesando Solicitud ...</div>';

                //realizo la operacion de validacion 
                var httpRequest = Generales.getHttpRequest();
                //url del servicio
                var urlServiceValidationSign = Constants.SERVICE_VALIDESIGN;
                //indico llamado de forma asincrona, true
                httpRequest.open("POST", urlServiceValidationSign, true);
                //le indico al server que los datos que envio son json
                httpRequest.setRequestHeader("Content-type", "application/json");
                //seteo los parametros en json	  
                //var params = "{'certB64':'" + cert+ "'}";
                //Pruebo directamente con el b64 del certificado del gde porque no puedo 
                //seleccionar otro validador
                //		   var params =  "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";
                //var params ="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";
                var params = doc;

                //cuando obtengo respuesta realizo la siguiente funcion
                httpRequest.onreadystatechange = function () {
                    if (httpRequest.readyState == 4 && httpRequest.status == 200) {

                        //recupero la respuesta en forma de objeto json
                        //este contine result,reason,etc
                        var resp = JSON.parse(httpRequest.responseText);

                        //verifico si el resultado es OK			   
                        //en caso de exito muestro datos de los certificados de los firmantes
                        //en caso de error muestro el error
                        if (resp.result == "OK") {
                            //remuevo el cargando
                            divMensajeSign.innerHTML = '&nbsp;';
                            //oculto el panel de seleccion de documento
                            document.getElementById('validarFirmaForm').style.display = 'none';

                            //genero la lista de certificados
                            var listaResu = "";
                            var listaCert = "";
                            var itemResu, itemCert;
                            var i, j, p1, p2, p3, p4;
                            var certs;
                            var longitud; //tamaño de la lista de certificados
                            var d = []; //lista de elementos de cada certificado
                            var itemsLabels = ["Nombre/Apellid. Firmante: ", "CUIT/CUIL Firmante: ", "Emisor: ", "Firmante: ", "Correo: ", "V&aacute;lido Desde: ", "V&aacute;lido Hasta: ", "N&uacutemero de Serie: ", "Pol&iacute;tica de certificaci&oacute;n: ", "Usos del certificado: "]; //lista de labels de los items de los certificados 
                            var horaDeConsulta; //la hora de consulta se tomara del primer detalle de la lista de certificados
                            var separacion; //html de separacion entr detalles de los firmantes
                            var subtitResu; //subtitulo de los resumenes de los firmantes

                            certs = resp.certsFirmantes;
                            p1 = '<h5>';
                            p2 = '</h5><br>';
                            p3 = '<p><span class="destacadoFieldset">';
                            p4 = '</span>';
                            p5 = '</p>';
                            separacion = '<div class="barraSeparadora"></div>';
                            longitud = Object.keys(certs).length;
                            subtitResu = '<p class="fontSize11 destacadoFieldset">Firmantes:</p><br>';
                            listaResu = listaResu + subtitResu;

                            //genero la lista de resumen de los firmantes y la de los detalles de los certificados de los firmantes
                            for (i = 0; i < longitud; i++) {

                                //obtengo los campos del certificado
                                d[0] = certs[i].asunto_CN;
                                d[1] = certs[i].asunto_SerialNumber;
                                d[2] = certs[i].emisor;
                                d[3] = certs[i].firmante;
                                d[4] = certs[i].correo;
                                d[5] = certs[i].valido_desde;
                                d[6] = certs[i].valido_hasta;
                                d[7] = certs[i].num_serie;
                                d[8] = certs[i].politica_cert;
                                d[9] = certs[i].uso_certificado;
                                //d[10]= certs[i].fecha_consulta;
                                //agrego el cn del certificado a la lista resumen de certificados de los firmantes
                                itemResu = p1 + d[0] + p2; //p1.concat(d1,p2);
                                listaResu = listaResu + itemResu; //listaResu.concat(itemResu);

                                //genero un detalle sin la informacion de hora de consulta
                                for (j = 0; j < d.length - 1; j++) {
                                    itemCert = p3 + itemsLabels[j] + p4 + d[j] + p5;
                                    listaCert = listaCert + itemCert;
                                }
                                //agrego la separacion si no es el ultimo firmante
                                if (i < longitud - 1) {
                                    listaCert = listaCert + separacion;
                                }

                            };
                            //seteo la hora de consulta
                            document.getElementById('respSignFechaConsulta').innerHTML = certs[0].fecha_consulta;

                            //cargo los datos de la lista resumen
                            document.getElementById('resumenFirmantes').innerHTML = listaResu;

                            //cargo la lista de los detalles de los certificados de los firmantes
                            document.getElementById('detallesFirmantes').innerHTML = listaCert;

                            //muestro el panel del resultado
                            document.getElementById('resultFirmaForm').style.display = 'block';


                        } else {

                            //muestro un mensaje de error
                            divMensajeSign.innerHTML = '<div class="iconErrorCertificado">El documento firmado NO es v&aacute;lido. <BR><BR>Motivo: ' + resp.reason + '</div>';
                            //oculto el panel del resultado
                            document.getElementById('resultFirmaForm').style.display = 'none';

                        }

                        //habilito el boton 
                        btn_validarSign.disabled = false;
                        btn_validarSign.classList.remove('botonGrisadoP');
                        btn_validarSign.classList.add('botonP');

                        //reseteo el valor del documento

                    }

                }
                //envio la peticion
                httpRequest.send(params);


            }


        }

    }

</script>

<!-- js configuracion del miniapplet-->
<script type="text/javascript" >
    var HOST = Constants.URL_BASE_APP;
    var storage = "http://www.milocal.com:8080" + "/AlmacenarFirma"; //document.getElementById('storageService').value;
    var retrieve = HOST + "/RecuperarFirma"; //document.getElementById('retrieveService').value;
    var jnlp = Constants.URL_BASE_JNLP; //document.getElementById('jnlpService').value;
    MiniApplet.setServlets(storage, retrieve);
    MiniApplet.setJnlpService(jnlp); // URL donde esta el generador de JNLP
    if (navigator.platform.indexOf("Linux") != -1 || navigator.platform.indexOf("Mac") != -1) {
        //En Mac y Linux se fuerza la utilización de servidores intermedios
        MiniApplet.setForceWSMode(true);
    }
    //dominio desde el que se realiza la llamada al servicio
    //MiniApplet.cargarAppAfirma('miniapplet.js');
    //MiniApplet.setForceWSMode(true);
    MiniApplet.cargarAppAfirma(HOST + 'valide/js/miniapplet.js', MiniApplet.KEYSTORE_WINDOWS);

    //////////////////////////////////////////////////////
    //MiniApplet.cargarMiniApplet("https://valide.redsara.es/valide/applet");

    //MiniApplet.setServlets("https://valide.redsara.es/firmaMovil/afirma-signature-storage/StorageService","https://valide.redsara.es/firmaMovil/afirma-signature-retriever/RetrieveService");

    /*	if (navigator.userAgent.toUpperCase().indexOf("FIREFOX") != -1) {
    if (navigator.javaEnabled() == false) {
    autofirma = true;
    mostrarPantalla();// mostrar despues de la carga
    } else {
    waiting("mostrarPantalla()", 10);
    }
    } 
    if ((navigator.javaEnabled() == false) || (isLoad() == false)) {
    autofirma = true;
    }		
    mostrarPantalla();*/
	
</script>
</html>
