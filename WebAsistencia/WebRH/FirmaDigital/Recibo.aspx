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
        
        <div style="text-align:center;" class="caja_izq no-print">
        Perfil empleador:<br />Firma Iterativa<br />Perfil empleado:<br />Confirmacion Recibo<br />Perfil auditor:<br />
        Verificacion de una firma<br />Obtener un recibo firmado<br />...
        </div>

        <!--contenido derecho -->
         <div  class="caja_der papel" >
           <div id="subcontenidoFirmaMasiva"> 
         <fieldset>
         <legend style="margin-top: 20px;">FIRMA DE RECIBOS</legend>         
         </fieldset>
         <div id="div_recibo">            
         <div  style="margin:10px;">
            <p><B>Descripción:</B>  En esta sección se realiza la firma iterativa de todos los recibos<!-- que hayan sido confirmados por los empleados,--> para un determinado intervalo, y que ademas no hayan sido aun firmados digitalmente.</p>
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
             <select style="width:65px;" id="cmb_anio2">
                <option value="2016" selected>2016</option>
                <option value="2017" >2017</option>
                <option value="2018" >2018</option>
             </select>
             <select style="width:105px;" id="cmb_meses2">
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
              &nbsp;&nbsp;&nbsp;<input id="btn_Buscar" class="botonFirmaM" type="button" value="Buscar" onclick="javascript:buscarRecibos();return false;" />
              <!--<div id="caja_controles"> </div>-->
         
         <!-- 	estatus de la operacion realizada --> 
<!--          <div id ="Div1"> 
         <div id ="Div2"></div><div id ="Div3"></div>
         <div id ="Div4"></div><div id ="Div6"></div>
         </div>
-->
        <!--  <div class="Table"> 
            <div class="Title"><p> Esta es la tabla</p> </div>  
            <div class="Heading"> <div class="Cell">
              <p> Primer Nombre</p>  
            </div>  
            <div class="Cell"><p> Segundo Nombre</p></div>  
            <div class="Cell"> <p>  Edad</p> </div>  
         </div>--> 
   <BR>  <BR> 
   <div><table class="tablex table-stripedx table-bordered table-condensed" style="width:100%">
				 <tbody class="list">
				 <tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:10pt" >Operación</td>
				 <td style="text-align: right;"><input id="btn_firmar" disabled  style="text-align: right;cursor: pointer;" class="botonGrisadoFirmaM" type="button" value="Firmar Seleccionados" onclick="javascript:iniciarOperaciones3();return false;" />
				 </td></tr>
				 <tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Estatus</td><td><div id="divMensajeStatus" style="margin-top:5px">&nbsp;</div></td></tr>
				 </tbody></table></div><br/>

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
           <div id="subcontenidoReciboEmpleado">



           </div>
         </div>
        <!--FIN contenido derecho -->
    </div>
    </form>
</body>

<script type="text/javascript" src="js/protocolcheck.js"></script>
<script type="text/javascript" src="js/miniapplet.js"></script>
<script type="text/javascript" src="js/constantes.js"></script>
<script type="text/javascript" src="js/recibo.js"></script>
<script type="text/javascript" src="js/funcionesGenerales.js"></script>


<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>

<!-- js de los servicios propios de la pagina -->
<script type="text/javascript" >
    var divMensajeStatus = document.getElementById('divMensajeStatus');
    var btn_firmar = document.getElementById("btn_firmar");
    var lista_recibos_resumen; /*variable que mantiene la lista de recibos */
    var anio;
    var mes;
    var tipoLiquidacion;

    function buscarRecibos() {
        //NOTA: si tipo liquidacion es 0 entonces por ahora no se traer TODOS los recibos de un dado año y mes
        //se limita aqui, pero se puede hacer un bucle aqui e iterar por todos los tipos de liquidacion y obtener todos los recibos y luego firmar, hacer eso por cada tipo de liquidacion

        if (document.getElementById('cmb_tipo_liquidacion').value == "0") {
            divMensajeStatus.innerHTML = '<div class="iconAlerta">Debe seleccionar un Tipo de Liquidacion</div>';
        } else { 
            //Muestro un mensaje de procesando
            divMensajeStatus.innerHTML = '<div class="iconProcesando">Procesando Solicitud ...</div>';

            //realizo la operacion
            anio = document.getElementById('cmb_anio2').value;
            mes = document.getElementById('cmb_meses2').value;
            tipoLiquidacion = document.getElementById('cmb_tipo_liquidacion').value;
            RECIBOS.getIdRecibosSinFirmar(tipoLiquidacion, anio, mes);
                        
            //seteo el mensage con el resultado de la operacion


            //oculto el panel del resultado
//        document.getElementById('resultFirmaForm').style.display = 'none';
            //muestro el panel de seleccion de documento firmado 
//        document.getElementById('validarFirmaForm').style.display = 'block';
        }
    }

    function xxxfirmarRecibos() {

        var i;
        var longitud; //tamaño de la lista resumen de recibos
        //deshabilito el boton de buscar
        btn_Buscar.disabled = true;
        //Muestro un mensaje de procesando
        divMensajeStatus.innerHTML = '&nbsp;';
        divMensajeStatus.innerHTML = '<div class="iconProcesando">Procesando Solicitud ...</div>';
        //realizo la operacion
        longitud = Object.keys(lista_recibos_resumen).length;
        //firmo los recibos ciclicamente
        for (i = 0; i < longitud; i++) {
            //                var option = document.createElement("option"); //creamos el elemento
            //                option.value = resp[i].Id; //asignamos valores a sus parametros
            //                option.text = resp[i].Descripcion;
            //                select.add(option); //insertamos el elemento

        }
        var reciboB64 = RECIBOS.getRecibo(idRecibo);
        RECIBOS.getReciboANDfirmarRecibo(idRecibo);
        RECIBOS.firmarRecibo(lista_recibos_resumen);

    }


</script>

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

<!-- js de los servicios de firma -->
<script type="text/javascript" defer="defer">
//NOTA: por el momento la firma de documentos seleccionados por chechkbox no se va a hacer
    //var archivo; //variable que almacenara el documento a firmar.
    //NOTA: ver que tan grande puede ser? en memoria
    //NOTA2: solo usar estas variables globales si se realiza de a una vez la firma
    //variables que hacer referencia a objetos de una misma fila
    var idEstadoF = null;
    var idCheckBoxF = null;
    var idDocF = null;
    //cantidad TOTAL de operaciones de firma realizada
    var totalFirmas = 0;
    var totalFirmasRealizadas = 0; //guarda la cantidad de archivos descargados,firmados y guardados como una sola operacion exitosa
    var totalOperaciones = 0; //cantidad de operaciones de firmas realizadas ya sea si salieron bien o fallaron

    var indiceListaRecibos = 0; //item actual que se esta procesando de la lista de recibos resumen

    function downloadedErrorCallback(e) {
  //      showLog("Error en la descarga de los datos: " + e);
        totalOperaciones++;
    }
    //descargar archivo binario pdf o imagen y firmar
    /*function firmarFileB64ServerExterno(urlDocumento,idEstado,idBoton) {
    try {
    var data = urlDocumento;
    MiniApplet.downloadRemoteDataB64ServerExterno(
    data,
    downloadedFileSuccessCallback,
    downloadedErrorCallback,idEstado,idBoton);
			
    } catch(e) {
    showLog("Error en la descarga de los datos: " + e);
    }
    }*/
    function downloadedFileSuccessCallback(data,idRecibo) {
        //document.getElementById("data").value = data;
        //(data != undefined && data != null && data != "") ? data : document.location
        var archivoB64 = data;
        
        //ahora se debe comprobar la descarga del pdf rellenado,hay que firmar, y luego guardar el pdf firmado
        firmar(archivoB64, idRecibo);
    }

    function firmar(archivoB64, idRecibo) {
        var indice, idCheckBox, idEstado, idDoc;
//        var lista = document.getElementsByClassName("chk_listado");
        //indice checklist seleccionado
//        indice = siguienteSeleccion("chk_listado");
        //obtengo el id del checkbox que luego sera utilizado para obtener los otros objetos de la misma fila
//        idCheckBox = lista[indice].id;
//        idEstado = "estado_" + idCheckBox;
//        idDoc = "doc_" + idCheckBox;

        var dataB64 = archivoB64;
//        var estado = document.getElementById(idEstado);
//        var checkbox = document.getElementById(idCheckBox);

//        idEstadoF = idEstado; //usados de forma global
//        idCheckBoxF = idCheckBox;
//        idDocF = idDoc;


        //deshabilitar todos los demas botones para que no intenten 
        //descargar otros files paralelamente, puede ser motivo de bug 
        //en caso de firmas de varios megas de archivos

        //divMensaje.innerHTML='&nbsp;';

        var format = "AUTO";
        var algorithm = "SHA1withRSA";
        var params = "";
        params = params + "signaturePositionOnPageLowerLeftX = 60" + "\n";
        params = params + "signaturePositionOnPageLowerLeftY = 120" + "\n";
        params = params + "signaturePositionOnPageUpperRightX = 410" + "\n";
        params = params + "signaturePositionOnPageUpperRightY = 190" + "\n";
        params = params + "signaturePage = -1" + "\n";
        //nota: por el momento no se puede enviar texto enriquecido  /n /r /t
        params = params + "layer2Text = Firmado Digitalmente conforme Ley 25.506 por: $$SUBJECTCN$$ el día $$SIGNDATE=dd/MM/yyyy HH:mm:ss$$ certificado emitido por $$ISSUERCN$$ con serial $$CERTSERIAL$$" + "\n";
        params = params + "layer2FontFamily = 0" + "\n";
        params = params + "layer2FontSize = 10" + "\n";
        params = params + "layer2FontStyle = 0" + "\n";
        params = params + "layer2FontColor = black" + "\n";

        //para que la firma sea una imagen se debe ajustar los tamaños de la firma a la imagen
      /*  extraParams.setProperty("signaturePositionOnPageLowerLeftX", "60"); //$NON-NLS-1$ //$NON-NLS-2$
        extraParams.setProperty("signaturePositionOnPageLowerLeftY", "60"); //$NON-NLS-1$ //$NON-NLS-2$
        extraParams.setProperty("signaturePositionOnPageUpperRightX", "550"); //$NON-NLS-1$ //$NON-NLS-2$
        extraParams.setProperty("signaturePositionOnPageUpperRightY", "130"); //$NON-NLS-1$ //$NON-NLS-2$
        */

   /*     params = params + "signatureRubricImage =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" + "\n";
        */
        //atributos de la firma		
        params = params + "signReason = conforme" + "\n";
        params = params + "signatureProductionCity = Bs.As." + "\n";
        params = params + "signerContact = rrhh@desa.gov.ar" + "\n";
        //Se indica que el tipo de firma es CADES con modo explicito
        params = params + "signatureSubFilter = ETSI.CAdES.detached" + "\n";

        //FIX:Politica  .Agregar filtros y politica en produccion

        //filtro certificados a solo los del emisor no es case sensitive
        //filtro los certificados en base al subject (asunto). son mis datos de certificado

        //APLICAR los siguientes filtros en produccion
        //ejemplo de filtro para solo de onti y no expirados
        //filters=issuer.rfc2254:(O=Jefatura de Gabinete de Ministros);nonexpired:
        //indicacion de la politica de firma, cambiar por los valores finales del doc de a politica de firma 
        //policyIdentifier=2.16.724.1.3.1.1.2.1.8
        //policyIdentifierHash=V8lVVNGDCPen6VELRD1Ja8HARFk=
        //policyIdentifierHashAlgorithm=http://www.w3.org/2000/09/xmldsig#sha1
        //policyQualifier=http://rrhh.gob.ar/politicafirma/politica_firma_v1.0.pdf

        params = params + "filters=issuer.rfc2254:(O=Jefatura de Gabinete de Ministros);nonexpired:" + "\n";
//ambiente prueba        params = params + "filters=issuer.rfc2254:(CN = jcvelasquez);nonexpired:" + "\n";
        //cuando existe un solo certificado en la lista lo auto selecciono
        params = params + "headless=true"; //+ "\n";	

        try {
            //setear estados de la imagen y el checkbox
            //checkbox.disabled = true;
            //checkbox.checked = false;

            //NOTA: con disabled ya es suficiente no es necesario cambiar de estilo a gris, porque aun asi hay que deshabilitar el boton
            //NOTA2: pero si se actualiza la pagina por alguna razon si se dejo el boton deshabilitado va a quedar asi, es como que el navegador reusa el objeto boton del DOM, FIX: hay que hacer enter en la url asi recarga directamente la pagina
            //NOTA3: en caso de que se cancele el launch desde el inicio los botones no pueden detectar este evento y quedaran en proceso pero sin hacer nada, FIX:?????
            // btn_firmar.disabled = true; 

//            estado.classList.remove('estadoNoFirmado');
//            estado.classList.add('estadoProcesando');

            MiniApplet.sign(
            dataB64,
            algorithm,
            format,
            params,
            SignSuccessCallback,
            SignErrorCallback);

            //el nombre del pdf sera idRecibo
            //MiniApplet.signAndSaveToFile(
/*            MiniApplet.signAndSaveToFile(
					"SIGN",
					dataB64,
					algorithm,
					format,
					params,
					idRecibo+".pdf",
					SignSuccessCallback,
					SignErrorCallback);*/
        }
        catch (e) {
            //Se muestra el mensaje de error si NO es de cancelación de la operación
            //por ejemplo mal tipo de algoritmo enviado,etc
            //el canceled no es por parte del usuario sino por ejemplo por no hallarse
            //por lo menos un certificado en el almacen seleccionado, igualmente modifique 
            //este error para que por lo menos me permita seleccionar otro certificado sin
            //emitir esta excepcion
            if ((e.message.indexOf("PrivilegedActionException") == -1) &&
			    (e.message.indexOf("AOCancelledOperationException") == -1) &&
			    (e.message.indexOf("Error calling method on NPObject") == -1) &&
				(e.message.indexOf("Operacion cancelada por el usuario") == -1)) {
                /*divMensaje.innerHTML='<div class="iconErrorFirma">Error al firmar</div><br><div style="width:300pt">&nbsp;' + e.message + '</div>';*/
            }

//            checkbox.disabled = false;
//            estado.classList.remove('estadoProcesando');
//            estado.classList.add('estadoNoFirmado');

            totalOperaciones++;

        }

    }

    //verifico si aun hay firmas por realizar
    function verificarContinuacionProceso() {
        //divMensajeStatus.innerHTML = '<div class="iconInfo">procesando...' + totalOperaciones + '-' + totalFirmas + '</div>';
       
        //compruebo si se realizaron todas las operaciones
        if (totalOperaciones != totalFirmas) {

            divMensajeStatus.innerHTML = '<div class="iconProcesando">Total de archivos a firmar: <b>' + totalFirmas + '</b>. Archivos firmados correctamente: <b>' + totalFirmasRealizadas + '</b>. No se pudieron procesar: <b>' + (totalOperaciones - totalFirmasRealizadas) + '</b>.</div>';
            firmarFileB64ServerExternoMasivo3();
        } else {
            //ya se realizaron todas las operaciones
            //compruebo si se realizaron todas las operaciones de firma
            if (totalFirmasRealizadas == totalFirmas) {
                /*  divMensajeStatus.innerHTML = '<div class="iconOKFirmados">Archivos firmados correctamente.</div>';*/
                divMensajeStatus.innerHTML = '<div class="iconOKFirmados">Total de archivos a firmar: <b>' + totalFirmas + '</b>. Archivos firmados correctamente: <b>' + totalFirmasRealizadas + '</b>. No se pudieron procesar: <b>' + (totalOperaciones - totalFirmasRealizadas) + '</b>.</div>';
            } else {
                var archivosNoFirmados = totalOperaciones - totalFirmasRealizadas;
                /*divMensajeStatus.innerHTML = '<div class="iconAlerta">No se pudieron procesar ' + archivosNoFirmados + ' documentos.</div>';*/
                divMensajeStatus.innerHTML = '<div class="iconAlerta">Total de archivos a firmar: <b>' + totalFirmas + '</b>. Archivos firmados correctamente: <b>' + totalFirmasRealizadas + '</b>. No se pudieron procesar: <b>' + (totalOperaciones - totalFirmasRealizadas) + '</b>.</div>';
            }
            //reseteo las variables globales
            totalOperaciones = 0;
            totalFirmasRealizadas = 0;
            totalFirmas = 0;
            indiceListaRecibos = 0;
            //NO rehabilito de nuevo el boton de firmar porque el que lo habilita es las busqueda de recibos a firmar
            //ya no hay elementos a procesar
//            btn_firmar.disabled = false;
//            btn_firmar.classList.remove('botonGrisadoFirmaM');
//            btn_firmar.classList.add('botonFirmaM');


        }
    }

    function SignSuccessCallback(signatureB64, certificateB64) {
        
        //en realidad el algoritmo por default es utf-8 pero igualmente no se 
        //toma en cuenta el segundo parametro, abria que eliminarlo si el algoritmo
        //es por default utf-8
        var fichero = signatureB64; //MiniApplet.getTextFromBase64 (signatureB64, "utf-8");
 //       var estado = document.getElementById(idEstadoF);
 //       var checkbox = document.getElementById(idCheckBoxF);
//        var doc = document.getElementById(idDocF);

//        signature = signatureB64;

        /*divMensaje.innerHTML='<br><div class="iconOKFirma">Fichero firmado correctamente</div><br>&nbsp;';*/

//        checkbox.checked = false;
//        estado.classList.remove('estadoProcesando');
//        estado.classList.add('estadoFirmado');

//        doc.onclick = function () { crearClickDoc(checkbox.value, true); };

        //*****************VER: llamar al servicio para guardar el archivo firmado y que este ya sea en error o success verifique el total de operaciones?y totalfirmas?o seria este ultimo TOTAL final de la operacion de un recibo y este es el que verificacontinuacionproceso

    /*    guardar archivo 
             en success 
                  totalOperaciones++;
                  totalFirmasRealizadas++; 
                  verificarContinuacionProceso();
             en error
                  totalOperaciones++;
                  verificarContinuacionProceso();
 
        
        RECIBOS.guardarRecibo(fichero,saveSuccessCallback,saveErrorCallback);
    */
        RECIBOS.guardarReciboPDFFirmado(lista_recibos_resumen[indiceListaRecibos - 1].Id_Recibo, fichero, anio, mes, tipoLiquidacion,successCallback, errorCallback);    
     
        //seteo el enlace al nuevo documento firmado
        
                
        //SIMULACION BLOQUE GUARDADO OK
  /*      totalOperaciones++;
        totalFirmasRealizadas++;
        verificarContinuacionProceso();*/




    }

    function SignErrorCallback(errorType, errorMessage) {
        //        var estado = document.getElementById(idEstadoF);
        //        var checkbox = document.getElementById(idCheckBoxF);
        //VER: seria bueno ir enlistando los errores en una lista a mostrar de estatus de la operacion general

        if ((errorMessage) &&
(errorMessage.indexOf("AOCancelledOperationException") == -1) &&
(errorMessage.indexOf("Operacion cancelada por el usuario") == -1)) {
            if (errorMessage.indexOf("El almacen no contenia entradas") != -1) {
                /*divMensaje.innerHTML='<img class="iconStatus" src="../img/iconFALLO.png">No existen certificados en el almacén de su navegador<br><br>';*/
            }
            else {
                /*divMensaje.innerHTML='<div class="iconErrorFirma">Error al firmar</div><br><div style="width:300pt">' + errorMessage + '</div>';*/
            }
        }
        //        checkbox.disabled = false;
        /*NO se puede dejar checked en true porque al hacer las llamadas recursivamente
        lo va a volver a tomar al objeto y asi hasta que se termine de realizar
        la cantidad de operaciones seteada en el principio*/
        //        checkbox.checked = false;
        //        estado.classList.remove('estadoProcesando');
        //        estado.classList.add('estadoNoFirmado');

        totalOperaciones++;
        verificarContinuacionProceso();
    }

    function successCallback(idRecibo) {
        //alert("guardado ok "+idRecibo);
        totalOperaciones++;
        totalFirmasRealizadas++; 
        verificarContinuacionProceso();       

    }

    function errorCallback(e) {

//        if ((errorMessage) &&
//(errorMessage.indexOf("AOCancelledOperationException") == -1) &&
//(errorMessage.indexOf("Operacion cancelada por el usuario") == -1)) {
//            if (errorMessage.indexOf("El almacen no contenia entradas") != -1) {
                /*divMensaje.innerHTML='<img class="iconStatus" src="../img/iconFALLO.png">No existen certificados en el almacén de su navegador<br><br>';*/
//            }
//            else {
                /*divMensaje.innerHTML='<div class="iconErrorFirma">Error al firmar</div><br><div style="width:300pt">' + errorMessage + '</div>';*/
//            }
//        }*/
//        alert("error en el guardado");
        totalOperaciones++;
        verificarContinuacionProceso();
    }
        

    //la siguiente funcion se ejecuta desde protocolchec al agragar un iframe para cargar la app jnlp
    function xxxmostrarPantalla() {

        /*document.getElementById("cargandoApplet").style.display = "none";
        document.getElementById("pantalla").style.display = "block";
        if (mobile==true) {
        document.getElementById("firmaProceso1").style.display = "none";
        document.getElementById("botones").style.display = "none";
        document.getElementById("divmensaje").style.display = "none";
			
        if (MiniApplet.isAndroid()) {
        document.getElementById("firmaProcesoAND").style.display = "inline";
        }
        else if (MiniApplet.isIOS()) {
        document.getElementById("firmaProcesoIOS").style.display = "inline";
        }
        document.getElementById("firmaMovil").style.display = "inline";
        document.getElementById("saveFile").style.display = "none";
        document.getElementById("clienteEscritorio").style.display = "none";
        document.getElementById("nota").style.display = "none";
        document.getElementById("nota2").style.display = "inline";
        }*/
    }

    //seleccionar o deselecciona todos los checkbox
    function xxxseleccionarTodos(checkbox) {
        //obtengo la lista de checkbox con un nombre de clase determinado
        var lista = document.getElementsByClassName("chk_listado");
        var i;
        if (checkbox.checked) {

            for (i = 0; i < lista.length; i++) {
                if (lista[i].disabled == false) {
                    lista[i].checked = true;
                }
            }
        } else {
            for (i = 0; i < lista.length; i++) {
                if (lista[i].disabled == false) {
                    lista[i].checked = false;
                }
            }

        }
    }

    //crea el enlace para visualizar el doc
    //NOTA:doc siempre debe tener xxxxxx.b64 o xxx.html como nombre
    function xxxcrearClickDoc(doc, firmado) {
        var url, target, forma_de_la_ventana;
        var i, temp;
        //quitar extension del string
        i = doc.indexOf('.b64');
        if (i == -1) { i = doc.indexOf('.html'); }
        temp = doc.substring(0, i);

        if (firmado) {
            url = temp + '-firmado' + '.pdf';
        } else {
            url = temp + '.pdf';
        }

        target = '_blank';
        forma_de_la_ventana = 'width=620,height=400,fullscreen=yes,scrollbars=NO';

        window.open(url, target, forma_de_la_ventana);

    }


    //retorna el primer elemento seleccionado deuna lista de checkbox con clase id
    function xxxsiguienteSeleccion(clase) {
        //obtengo la lista de checkbox con un nombre de clase determinado
        var lista = document.getElementsByClassName("chk_listado");
        var pri; //guarda el primer indice seleccionado
        var ok = true; //para solo guardar un elemento

        //compruebo si minimamente hay un checkbox
        if (lista.length != 0) {

            //compruebo que haya algo para firmar
            for (i = 0; i < lista.length; i++) {
                //si hay algo seleccionado
                if (lista[i].checked) {
                    if (ok) { pri = i; ok = false; break; };
                }
            }
            return i;
        } else {
            return -1;
        }
    }

    ////////////NOTA: A modo de prueba solo se enviaran 3 archivos como maximo a firmar
    
    //retorna el elemento apuntado por indice y actualiza el indice
    function siguienteSeleccion3(indice) {

//limitacion        if (indice < (3)) {//lista_recibos_resumen.length
        if (indice < lista_recibos_resumen.length) {//lista_recibos_resumen.length   //para procesar completamente la lista
            //actualizo el indice
            indiceListaRecibos++;
            //retorno el valor
            return lista_recibos_resumen[indice].Id_Recibo;

        } else {return -1;}
        
    }

    //seteo las variables para poder realizar las operaciones recursivamente
    function xxxiniciarOperaciones() {
        //obtengo la lista de checkbox con un nombre de clase determinado
        var lista = document.getElementsByClassName("chk_listado");
        var btn_firmar = document.getElementById("botonFirmas");
        var i, checkbox; ;

        //compruebo si minimamente hay un checkbox
        if (lista.length != 0) {

            //compruebo que haya algo para firmar
            for (i = 0; i < lista.length; i++) {
                //si hay algo seleccionado
                if (lista[i].checked) {
                    totalFirmas++;
                    //deshabilito la seleccion asi no se permite que se saltee su firma en caso de una seleccion posterior cuando
                    //se esta ejecutando el proceso, si se requiere ese comportamiento ver
                    //que el totalFirmas se calcula al principio para un correcto display de
                    //mensajes agregar un evento cuando se click en un checkbox y este esta
                    //seleccionado asi se actualiza el totalFirmas
                    idCheckBox = lista[i].id;
                    //deshabilito el checkbox asi no lo modifican
                    checkbox = document.getElementById(idCheckBox);
                    checkbox.disabled = true;
                }
            }
            if (totalFirmas > 0) {
                //deshabilito el boton
                btn_firmar.disabled = true;
                btn_firmar.classList.remove('botonFirmaM');
                btn_firmar.classList.add('botonGrisadoFirmaM');

                //seteo el estatus de la operacion
                divMensaje.innerHTML = '<div class="iconProcesando">Procesando Documentos ...</div>';
                firmarFileB64ServerExternoMasivo();

            } else {
                divMensaje.innerHTML = '<div class="iconInfo">Debe seleccionar al menos un documento.</div>';
            }
        }

        /*a medida que se va firmando los archivos se setean las propiedades
        de los checkbox seteados asi la lista de seleccionados disminuye en 
        cada iteracion*/
    }

    //seteo las variables para poder realizar las operaciones recursivamente
    function iniciarOperaciones3() {
       // longitud = Object.keys(lista_recibos_resumen).length;
        //compruebo si minimamente hay elementos en la lista para firmar
        
        if (lista_recibos_resumen.length != 0) {
 //           totalFirmas = 3; //**********es la limitacion   
            totalFirmas = lista_recibos_resumen.length;     
            if (totalFirmas > 0) {
                //deshabilito el boton
                btn_firmar.disabled = true;
                btn_firmar.classList.remove('botonFirmaM');
                btn_firmar.classList.add('botonGrisadoFirmaM');

                //seteo el estatus de la operacion
                divMensajeStatus.innerHTML = '<div class="iconProcesando">Procesando Documentos ...</div>';
                firmarFileB64ServerExternoMasivo3();

            } else {
                divMensajeStatus.innerHTML = '<div class="iconInfo">Debe existir al menos un documento para firmar.</div>';
                
            }
        }

        /*a medida que se va firmando los archivos se setean las propiedades
        de los checkbox seteados asi la lista de seleccionados disminuye en 
        cada iteracion*/
    }


    //NOTA: los checkbox,idEstado de una misma fila deben llamarse
    /*para la fila numero x:
    objeto(checkBox_x).id= f1
    objeto(idEstado_x).id= estado_f1;
    objeto(idDoc_x).id= doc_f1;
    en resumen los demas ids de una misma fila deben derivarse del id del checkbox
    */
    //firma iterativamente los archivos seleccionados
    function firmarFileB64ServerExternoMasivo3() {

        //obtengo el item de la lista de recibos a procesar
        var idRecibo;
        var parametros = "";

        //obtengo el recibo a procesar
        idRecibo = siguienteSeleccion3(indiceListaRecibos);

        //       parametros = "id_recibo="+idRecibo;//para mi forma de llamar a los ws para agregar mas parametros poner & como separador
///////////VER eliminar data url al metodo de abajo, es redundante en la llamada modo backend
        //Para el uso del backend directamente mandar el idRecibo
        parametros = idRecibo;
        //si hay un elemento seleccionado
        if (idRecibo != -1) {

            //obtengo el primer elemento y empiezo el bucle en dos niveles,
            //de esta forma las ejecuciones iteradas son asincronas			
            //seteo la url del documento a firmar
            //VER: que no se esta utilizando el data porque para enviar la url porque se usa el backend asi se evita el cors desde diferentes puertos de llamada del web server y los servicios

            data = "http://localhost:43412/WSViaticos/WSViaticos.asmx/GetReciboPDF";  //ya no lo uso en la actualidad
/////////////////////VER
            try {
                RECIBOS.downloadRemoteDataB64POSTEmpleador(
									data,idRecibo,parametros,
									downloadedFileSuccessCallback,
									downloadedErrorCallback);
            } catch (e) {
                divMensajeStatus.innerHTML = '<div class="iconErrorFirma">Error en la descarga del archivo ' + data + ' con id Recibo: ' + idRecibo + '</div>';
                totalOperaciones++;
 //               //deschequeo el checkbox asi se puede continuar
 //               checkbox.checked = false;
                firmarFileB64ServerExternoMasivo3();

            }
        }
        else {//se entra por aqui se antes se produjo una excepcion en este mismo metodo
            //y ademas ya no hay checkbox seleccionados
            //ya no hay elementos a procesar
            btn_firmar.disabled = false;
            btn_firmar.classList.remove('botonGrisadoFirmaM');
            btn_firmar.classList.add('botonFirmaM');

            //ACtualizar el mensaje o ver continuacionproceso, en realidad no deberia entrar, sino por continuacionproceso
        }



    }



    //NOTA: los checkbox,idEstado de una misma fila deben llamarse
    /*para la fila numero x:
    objeto(checkBox_x).id= f1
    objeto(idEstado_x).id= estado_f1;
    objeto(idDoc_x).id= doc_f1;
    en resumen los demas ids de una misma fila deben derivarse del id del checkbox
    */
    //firma iterativamente los archivos seleccionados
    function xxxfirmarFileB64ServerExternoMasivo() {

        //obtengo la lista de checkbox con un nombre de clase determinado
        var lista = document.getElementsByClassName("chk_listado");
        var btn_firmar = document.getElementById("botonFirmas");
        var i, data, idCheckBox, idEstado, checkbox;
        var indice;
        //indice checklist seleccionado
        indice = siguienteSeleccion("chk_listado");

        //si hay un elemento seleccionado
        if (indice != -1) {


            //obtengo el primer elemento y empiezo el bucle en dos niveles,
            //de esta forma las ejecuciones iteradas son asincronas			
            //seteo la url del documento a firmar
            data = lista[indice].value;
            //obtengo el id del checkbox que luego sera utilizado para obtener los otros objetos de la misma fila
            idCheckBox = lista[indice].id;
            idEstado = "estado_" + idCheckBox;

            //deshabilito el checkbox asi no lo modifican
            checkbox = document.getElementById(idCheckBox);
            checkbox.disabled = true;

            try {
                MiniApplet.downloadRemoteDataB64(
									data,
									downloadedFileSuccessCallback,
									downloadedErrorCallback);
            } catch (e) {
                divMensaje.innerHTML = '<div class="iconErrorFirma">Error en la descarga del archivo ' + data + '</div>';
                totalOperaciones++;
                //deschequeo el checkbox asi se puede continuar
                checkbox.checked = false;
                firmarFileB64ServerExternoMasivo();

            }
        }
        else {//se entra por aqui se antes se produjo una excepcion en este mismo metodo
            //y ademas ya no hay checkbox seleccionados
            //ya no hay elementos a procesar
            btn_firmar.disabled = false;
            btn_firmar.classList.remove('botonGrisadoFirmaM');
            btn_firmar.classList.add('botonFirmaM');

        }



    }
    function xxxfirmarFileB64ServerExternoMasivo2() {

        //obtengo la lista de checkbox con un nombre de clase determinado
        var lista = document.getElementsByClassName("chk_listado");
        var i, data, idCheckBox, idEstado, idBoton, checkbox;

        //compruebo que haya algo para firmar
        for (i = 0; i < lista.length; i++) {
            //si hay algo seleccionado
            if (lista[i].checked) {
                //seteo el estatus de la operacion
                divMensaje.innerHTML = '<div class="iconProcesando">Procesando Documentos ...</div>';

            }
        }
        for (i = 0; i < lista.length; i++) {
            //si esta seleccionado
            if (lista[i].checked) {
                totalFirmas++;

                //seteo la url del documento a firmar
                data = lista[i].value;
                //obtengo el id del checkbox que luego sera utilizado para obtener los otros objetos de la misma fila
                idCheckBox = lista[i].id;
                idEstado = "estado_" + idCheckBox;

                //deshabilito el checkbox asi no lo modifican
                checkbox = document.getElementById(idCheckBox);
                checkbox.disabled = true;

                try {
                    MiniApplet.downloadRemoteDataB64ServerExterno(
								data,
								downloadedFileSuccessCallback,
								downloadedErrorCallback, idEstado, idCheckBox);
                } catch (e) {
                    showLog("Error en la descarga de los datos: " + e);
                }
            }
            //lista[i].style.backgroundColor = "red";
            //alert(lista[i].value);
            //alert(lista[i].id);
        }

    }

    function colorCeleste(o) {
        var obj = document.getElementById(o.id);
        obj.classList.remove('Documento');
        obj.classList.add('DocumentoCeleste');
    }

    function colorNegro(o) {
        var obj = document.getElementById(o.id);
        obj.classList.remove('DocumentoCeleste');
        obj.classList.add('Documento');
    }
	
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
    MiniApplet.cargarAppAfirma(HOST + 'FirmaDigital/js/miniapplet.js', MiniApplet.KEYSTORE_WINDOWS);

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
