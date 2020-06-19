<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModificacionBien.aspx.cs" Inherits="Portal_Recibo" %>
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

        <link rel="stylesheet" href="../FirmaDigital/estilosPortalSecciones.css" /> 
        <link rel="stylesheet" href="../FirmaDigital/recibo.css" />
        <link rel="stylesheet"  href="../FirmaDigital/estilosPermisos.css" /><!--css de la caja de busquedas -->
        <!--<link rel="stylesheet" href="../Permisos/Permisos.css" type="text/css"/> -->
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDeAreas.css" type="text/css"/>
        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/> <!-- css de la busqueda de personas -->

        <!-- plugin input file-->
        <!--JQuery-->

        <!--JCrop (Jquery plugin for cropping images)-->
        <script src="plugin_custom_input_file/js/jquery.Jcrop.min.js"></script> 
        <link rel="stylesheet" href="plugin_custom_input_file/css/jquery.Jcrop.min.css" type="text/css" /> 

        <!--Custom Input File-->
        <script src="plugin_custom_input_file/js/custominputfile.min-es.js"></script> 
        <link rel="stylesheet" href="plugin_custom_input_file/css/custominputfile.min.css"  type="text/css" />

    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    
    <!--caja de contenido por debajo del menu-->
    <div style="width:99%; margin-left:11px; margin-right:11px">
    

        <div style="/*text-align:center;margin-top:5px; margin-left: 5px;margin-right:5px;background-color:rgb(1,70,99);*/" class="caja_izq no-print">
        </div>

        <!--contenido derecho -->
         <div  class="caja_derxxxx papelxxx" style="margin-top:32px;float:left;width:80% ">
           <!--modulo de asignacion de tarjeton -->
           <div id="subcontenidoBusquedaPatentes" class="panelDerOcultable" style="display: inline;"> 

               <div style="width:80%;margin:20pt;-webkit-border-radius: 7px 7px 0px 0px;
-moz-border-radius: 7px 7px 0px 0px;border-radius: 7px 7px 0px 0px;border-collapse: collapse;border: 0px solid #1C6EA4;padding-left:40pt;text-align: center;margin: 0 auto;">
                   <div class="/*estilo_formulario3*//*cajaPermisos*/" style="text-align: left;padding: 20px 20px">                      
                       <div style="vertical-align: middle; padding:0px;;margin-bottom:0px">
                           <label for="tipoBien" style="padding-right:28pt">Tipo Bien:</label>
                           <select style="width:70pt;" id="cmb_tipobien"> </select>
                           <!--<input type="text" id="tipoBien" name="tipoBien" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 323pt;">-->
                       </div>                        
                    </div> 
                   <hr class="barraHorizontal">
                   <br />

                   <div class="cajaPermisos">
                       <!--la siguiente descripcion del vehiculo se puede quitar -->
                       <div class="/*estilo_formulario3*//*cajaPermisos*/" style="text-align: left;padding: 20px 20px">   
                           <div style="vertical-align: middle; padding:0px;;margin-bottom:0px">
                                <label for="buscadorPatentes" style="padding-right:48pt">Dominio:</label>
                                <input id="buscadorPatentes" name="buscadorPatentes" type="text" style="margin: 4px 0;padding:20px 10px;font-size:30pt;font-weight:bold;width: 280px;" maxlength="8"/>                                
                                <input id="btn_buscarPatente" class="botonAzul" type="button" value="Buscar" style="margin-left:5px;" onclick="BIENES.buscarVehiculo()" > 
                                <!-- donde se ubican los archivos precargados-->
                                <span style="float:right;color:black;"><span id="contenedorFiles" ></span></span>
                           </div>
                           <div style="vertical-align: middle; padding:0px;margin-bottom:0px">
                                <label for="segmento" style="padding-right:40pt">Segmento:</label>
                                <input type="text" id="segmento" name="segmento" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 210pt;">
                           </div>
                           <div style="vertical-align: middle; padding:0px;margin-bottom:0px">
                                <label for="marca" style="padding-right:59pt">Marca:</label>
                                <input type="text" id="marca" name="marca" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 210pt;">
                           </div>
                           <div style="vertical-align: middle; padding:0px;margin-bottom:0px">
                                <label for="modelo" style="padding-right:52pt">modelo:</label>
                                <input type="text" id="modelo" name="modelo" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 210pt;">
                           </div>
                           <div style="vertical-align: middle; padding:0px;margin-bottom:0px">
                                <label for="nummotor" style="padding-right:6pt">Número de Motor:</label>
                                <input type="text" id="nummotor" name="nummotor" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 210pt;">
                           </div>
                           <div style="vertical-align: middle; padding:0px;margin-bottom:0px">
                                <label for="numchasis" style="padding-right:2pt">Número de Chasis:</label>
                                <input type="text" id="numchasis" name="numchasis" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 210pt;">
                           </div>      
                           <div style="vertical-align: middle; padding:0px;margin-bottom:0px">
                                <label for="anio" style="padding-right:2pt">Año: (Según Tarjeta Verde)</label>
                                <select name="anio" id="cmb_anio" style="width:70px;color:black;border-radius: 3px;"> </select>
                           </div>
                           <div style="vertical-align: middle; padding:5px 0px;margin-bottom:0px">
                                <input name="input-file-1" id="input-file-1">
                           </div>
                           <div style="vertical-align: middle; padding:5px 0px;text-align:center;">
                                <input id="btn_guardarVehiculo" class="botonAzul" type="button" value="Guardar" style="margin-left:5px;" onclick="BIENES.guardarVehiculo()" >                       
                           </div>
                           
                           <br />
                           <hr class="barraHorizontal">
                           <br />
                           <div class="/*estilo_formulario3*//*cajaPermisos*/" style="text-align: left;padding: 20px 20px">
                       <!--<div id="buscador_de_personas" style="vertical-align: middle; margin-bottom:0px">
                          <label for="buscador" style="padding-right:2pt">Usuario Receptor:</label>
                          <div id="selector_usuario" class="selector_personas" style="display: inline-block;">
                                <input id="buscador" name="buscador" type="hidden" />
                          </div>                        
                       </div>-->
                       <div style="vertical-align: middle; padding:0px;;margin-bottom:0px">
                           <label for="observacionmobi" style="padding-right:28pt">Observación:</label>
                           <input type="text" id="observacionmobi" name="observacionmobi" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 323pt;">
                       </div>
                       <div style="vertical-align: middle; padding:0px;;margin-bottom:0px">
                           <label for="codhologramamobi" style="">Código Holograma:</label>
                           <input type="text" id="codhologramamobi" name="codhologramamobi" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 112pt;" maxlength="13">
                           <!--<label for="vencimiento" style="margin-left:5pt">Vencimiento:</label>
                           <input type="text" id="vencimiento" name="vencimiento" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 52pt;" maxlength="4">-->
                           <label for="vigencia" style="margin-left:5pt">Vigencia:</label>
                           <input type="text" id="vigencia" name="vigencia" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 100pt;" maxlength="9">
                          
                       </div>
                       <div style="margin-bottom:0px; text-align: right;padding: 10px 10px" >                    
                        <input class="botonAzul" type ="button" value="Imprimir Nuevo Tarjetón" onclick="BIENES.asociarTarjeton()">                 
	                   </div>
                           </div>
                           
                       </div>

                       <div id="buscador_general" style="vertical-align: middle; padding:10px;;margin-bottom:20px;display:none">
                        <p class="buscarPersona" style="display: inline-block;margin: 0 5px 10px;font-weight:bold;">Patente:
                            <!--<div id="selector_usuario" class="selector_personas" style="display: inline-block;">
                                <input id="buscador" type="hidden" />
                            </div>-->                            
                            <div class="" style="display: inline-block;">
                                <input id="buscadorPatentes2" type="text" style="margin: 4px 0;padding:20px;font-size:30pt;font-weight:bold;width: 280px;" maxlength="8"/>
                                <input id="btn_buscarPatente2" class="botonAzul" type="button" value="Buscar" style="margin-left:5px;" onclick="BIENES.buscarEventosTarjetonDePatente()" > 
                            </div>
                        </p>
                       </div>
                    </div>                   
                   <hr class="barraHorizontal">
                   <br />
                   <div class="/*estilo_formulario3*//*cajaPermisos*/" style="text-align: left;padding: 20px 20px;display:none">
                       <!--<div id="buscador_de_personas" style="vertical-align: middle; margin-bottom:0px">
                          <label for="buscador" style="padding-right:2pt">Usuario Receptor:</label>
                          <div id="selector_usuario" class="selector_personas" style="display: inline-block;">
                                <input id="buscador" name="buscador" type="hidden" />
                          </div>                        
                       </div>-->
                       <div style="vertical-align: middle; padding:0px;;margin-bottom:0px">
                           <label for="observacionmobi2" style="padding-right:28pt">Observación:</label>
                           <input type="text" id="observacionmobi2" name="observacionmobi2" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 323pt;">
                       </div>
                       <div style="vertical-align: middle; padding:0px;;margin-bottom:0px">
                           <label for="codhologramamobi2" style="">Código Holograma:</label>
                           <input type="text" id="codhologramamobi2" name="codhologramamobi2" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 112pt;" maxlength="13">
                           <!--<label for="vencimiento" style="margin-left:5pt">Vencimiento:</label>
                           <input type="text" id="vencimiento" name="vencimiento" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 52pt;" maxlength="4">-->
                           <label for="vigencia2" style="margin-left:5pt">Vigencia:</label>
                           <input type="text" id="vigencia2" name="vigencia2" style="margin: 4px 0;padding:15px;font-size:12pt;font-weight:bold;width: 100pt;" maxlength="9">
                          
                       </div>
                       <div style="margin-bottom:0px; text-align: right;padding: 5px 10px" >                    
                        <input class="botonAzul" type ="button" value="Asociar Tarjetón" onclick="BIENES.asociarTarjeton()">                 
	                   </div>
                    </div>                   
                   <hr class="barraHorizontal">
                   <br />

                   <!--lista de Eventos tarjetones asociados a la patente -->

                   <div id="listaEventosTarjetones"></div><br/>

                   
                    
                </div> 

                   
	            
                                
                       
            </div> 
                
            </div>               

               </div> 
             <!-- plantilla de carga de prebusquedas en el input de la busqueda-->
        <div id="plantillas">
            <div class="vista_persona_en_selector">
                <div id="contenedor_legajo" class="label label-warning">
                    <div id="titulo_legajo">Leg:</div>
                    <div id="legajo"></div>
                </div> 
                <div id="nombre" style="font-size:15px;color:black;" ></div>
                <div id="apellido" style="font-size:15px;color:black;"></div>
                <div id="contenedor_doc" class="label label-default">
                    <div id="titulo_doc">Doc:</div>
                    <div id="documento"></div>         
                </div>   
            </div>

            	
        </div>
           <!--FIN contenido derecho -->
    </div>
    </form>
</body>


<script type="text/javascript" src="../MAU/VistaDePermisosDeUnUsuario.js"></script>
<script type="text/javascript" src="../MAU/Autorizador.js"></script>
<script type="text/javascript" src="../MAU/RepositorioDeFuncionalidades.js"></script>
<script type="text/javascript" src="../MAU/RepositorioDeUsuarios.js"></script>
<script type="text/javascript" src="../MAU/NodoEnArbolDeFuncionalidades.js"></script>
<script type="text/javascript" src="../MAU/AdministradorDeUsuarios.js"></script>
<script type="text/javascript" src="../MAU/Usuario.js"></script>
<script type="text/javascript" src="../MAU/HabilitadorDeControles.js"></script>
<script type="text/javascript" src="../MAU/VistaDeAreasAdministradas.js"></script>
<script type="text/javascript" src="../MAU/VistaDeAreaAdministrada.js"></script>
<script type="text/javascript" src="../Scripts/Area.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>

<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>

<script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>

<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>

<!--<script type="text/javascript" src="../FirmaDigital/js/imprimirRecibo.js"></script>-->

<!--<script type="text/javascript" src="../FirmaDigital/Legajo.js"></script><!-- no va    dddd-->
    <!--legajo.js es lo mismo que imnprimirRecibo.js, en este ultimo cree la version que utilizaba-->
<script type="text/javascript" src="js/permisos.js"></script><!-- intento limpiar los js de arriba para que esten mas organizados-->
<script type="text/javascript" src="js/utiles.js"></script>

<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>

    <script type="text/javascript" >

        //    var listaRecibosConformados = new Array();
        //  var agenteActual = '';

        //ejemplo de funcion anonima y por parametro
        /*function ejemplo2(fn) {
            var nombre = "Pepe";
            fn(nombre);
        }
        //funcion enviada como anonima preo puede ser definida antes y enviada con fn(parametros)
        ejemplo2(function (nom) {
            console.log("hola " + nom);
        });*/  // "hola Pepe"

        $(document).ready(function ($) {

            //inicializo el manejador de la carga de archivos
            $('#input-file-1').customFile({
                maxFiles: 10,
                addContainerAfter: $('#contenedorFiles')
            });

            UTIL.enlazarEnter("buscadorPatentes", "btn_buscarPatente");
            UTIL.generarAnios("cmb_anio", 21); //generar una lista de los ultimos 21 años en el id select enviado

            Backend.start(function () {
                Permisos.init(BIENES.setearCamposDefault);/*esta variable estaba en imprimirRecibo.js*/

                BIENES.Mobi_GetTipoBien();
                //para cargar el menu izquierdo 
                $(".caja_izq").load("SeccionIzquierda.htm", function () {
                    /*inicia la operacion de carga del bucador de personas y setea la funcion a realizar en el onchange de la lista*/
                    /*como parametro va la funcion extra para la pagina actual que se quiere realizar cuando se selecciona un usuario*/
                    //No va solo es para la busqueda de personas                  Permisos.iniciarConsultaRapida(BIENES.setearCamposDefault);


                    //                  Permisos.iniciarConsultaRapida();
                    //FC: para importar el HabilitadorDeControles y afecte la seccion izquierda
                    //                  var imported = document.createElement('script');
                    //                  imported.src = '../MAU/HabilitadorDeControles.js';
                    //                   document.head.appendChild(imported);

                });
            });


        });


</script> 

 <script type="text/javascript" >
     var idBienVehiculo = ""; //mantiene el id del bien vehiculo en donde se asociara al tarjeton nuevo
     var spinner = new Spinner({ scale: 2 }); //el indicador de cargando o rocesando requerimiento

     var BIENES = (function (window, undefined) {
         function Mobi_GetTipoBien() {
             Backend.Mobi_GetTipoBien()
                 .onSuccess(function (tipos) {
                     /*tiposBien es la respuesta*/
                     var select = document.getElementById("cmb_tipobien");
                     var i;

                     var resp = tipos;
                     var longitud; //tamaño de la lista de tipos de liquidacion
                     longitud = Object.keys(resp).length;

                     //genero la lista de opciones
                     for (i = 0; i < longitud; i++) {
                         var option = document.createElement("option"); //creamos el elemento
                         option.value = resp[i].Id; //asignamos valores a sus parametros
                         option.text = resp[i].Nombre;
                         select.add(option); //insertamos el elemento
                         //option.setAttribute("disabled", true);
                         select.setAttribute("disabled", true);
                     }
                 })
                 .onError(function (e) {

                 });

         }
         function serialize(form) {
             var inputs = form.elements;
             var array = [];
             for (i = 0; i < inputs.length; i++) {
                 var inputNameValue = inputs[i].name + '=' + inputs[i].value;
                 array.push(inputNameValue);
             }
             return array.join('&');
         }
         function guardarVehiculo() {
             var comprobaciones = true;
             var idTipoBien = $("#cmb_tipobien option:selected").val(); 
             var dominio = document.getElementById("buscadorPatentes").value;
             var segmento = document.getElementById("segmento").value;
             var marca = document.getElementById("marca").value;
             var modelo = document.getElementById("modelo").value;
             var nummotor = document.getElementById("nummotor").value;
             var numchasis = document.getElementById("numchasis").value;
             var anio = $("#cmb_anio option:selected").val();
             var dataForm = $.customFile.serializeContenidoFilesB64('input-file-1');  //recibo un array de string

             if (dominio == '') {
                 alertify.alert("", "Debe indicar un dominio."); comprobaciones = false;
             } else {
                 if (segmento == '') {
                     alertify.alert("", "Debe ingresar un segmento."); comprobaciones = false;
                 } else {
                     if (marca == "") {
                         alertify.alert("", "Debe seleccionar una marca."); comprobaciones = false;
                     } else {
                         if (modelo == '') {
                             alertify.alert("", "Debe ingresar un modelo."); comprobaciones = false;
                         } else {
                             if (nummotor == '') {
                                 alertify.alert("", "Debe ingresar un número de motor."); comprobaciones = false;
                             } else {
                                 if (numchasis == '') {
                                     alertify.alert("Dbe indicar un número de chasis."); comprobaciones = false;
                                 }
                             }
                         }
                     }
                 }
             }
             /*var ajaxData = new FormData();
             ajaxData.append('action', 'uploadImages');
             $.each($("input[type=file]"), function (i, obj) {
                 $.each(obj.files, function (j, file) {
                     ajaxData.append('photo[' + j + ']', file);
                 })
             }); */
             /*var formDatax = new FormData();
             $.each($(".TheFiles"), function (i, obj) {
                 $.each(obj.files, function (j, file) {
                     formDatax.append('Attachment[' + i + ']', file); // is the var i against the var j, because the i is incremental the j is ever 0
                 });
             });
             var xx = formDatax.get('Attachment[0]');

             var formData = new FormData();
             $.each($(".TheFiles"), function (i, obj) {
                 $.each(obj.files, function (j, file) {
                     formData.append('Attachment[' + i + ']', file); // is the var i against the var j, because the i is incremental the j is ever 0
                 });
             });
             formData.append('Destination', 'vaca'); //add more variables that you need
             formData.append('ReplyTo', 'vacioata');//add more variables that you need
             formData.append('Body', 'este mensaje');//add more variables that you need
             var x = formData.getAll('Destination');
             var x2 = formData.get('Attachment[0]');
             var form = document.getElementById("form1");
             var formdata = new FormData(form[0]);
             var data = form.serialize();

             var form_data = serialize(form);
             var jsonString = JSON.stringify(x2);
             var phoneName = JSON.parse(x2);*/
             if (comprobaciones) {
                 spinner.spin($("html")[0]);
                 Backend.Mobi_AltaVehiculo(idTipoBien, dominio, segmento, marca, modelo, nummotor, numchasis, anio, dataForm)
                     .onSuccess(function (res) {
                         spinner.stop();
                         var resp = JSON.parse(res);
                         if (!resp.DioError) {
                             alertify.success(" Exito realizando la operación.");
                         } else {
                             alertify.error(resp.MensajeDeErrorAmigable);
                         }
                         /*tiposBien es la respuesta*/
                         /* var select = document.getElementById("cmb_tipobien");
                          var i;
     
                          var resp = tipos;
                          var longitud; //tamaño de la lista de tipos de liquidacion
                          longitud = Object.keys(resp).length;
     
                          //genero la lista de opciones
                          for (i = 0; i < longitud; i++) {
                              var option = document.createElement("option"); //creamos el elemento
                              option.value = resp[i].Id; //asignamos valores a sus parametros
                              option.text = resp[i].Nombre;
                              select.add(option); //insertamos el elemento
                              //option.setAttribute("disabled", true);
                              select.setAttribute("disabled", true);
                          }*/
                     })
                     .onError(function (e) {
                         spinner.stop();

                     });
             }

         }

         function setearCamposDefault() {

             var today = new Date();
             var dd = today.getDate();
             var mm = today.getMonth() + 1; //January is 0! 
             var yyyy = today.getFullYear(); if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } var today = dd + '/' + mm + '/' + yyyy;
             // document.getElementById("demo").innerHTML = today;

             //seteo el valor default de la observacion
             document.getElementById("observacionmobi").value = "Asociación con Tarjetón";//"Asoc Vehic a Tarj " + today;
             //seteo el valor default del año de vencimiento
             //document.getElementById("vencimiento").value = yyyy+"/"+(yyyy+1);
             //       document.getElementById("vencimiento").value = (yyyy + 1);
             document.getElementById("vigencia").value = yyyy + "/" + (yyyy + 1);
         }

         function buscarEventosTarjetonDePatente() {
             /* @Id_ClaveAtributoBien = 2,
 @valor = 'CVA155',
 @Id_TipoBien = 1,
 @tipoConsulta = 1*/
             var idClaveAtributoBien = 2; //atributo bien de tipo patente
             var valor = document.getElementById("buscadorPatentes").value; //valor de atributo bien de tipo patente buscado
             var idTipoBien = 1; //tipo bien vehiculo
             var tipoConsulta = 1; //es una consulta de tipo consulta eventos tarjeton, que requiere agrgar otras condiciones q permiten obtener otros atributos mas

             if (valor == '') {
                 /// no hago nada
             } else {                 
                 spinner.spin($("html")[0]);
                 //muestro la lista de eventos de tarjeton de sa patente
                 Backend.MOBI_GET_EventosxTipoBienxClaveAtributoBienxValor(idClaveAtributoBien, valor, idTipoBien, tipoConsulta)
                     .onSuccess(function (res) {
                         spinner.stop();
                         var capaLista = document.getElementById("listaEventosTarjetones");

                         var resp = JSON.parse(res);
                         var longitud; //tamaño de la lista
                         longitud = Object.keys(resp).length;
                         //capa.innerHTML = '';
                         //var capa2 = '';
                         var capaInicio = ''; //representa la capa que muestran a la lista
                         var capaFin = '';
                         var capaFil = '';
                         var capaAcumulada = '';
                         /*capaInicio = '<table class="tablex table-stripedx table-bordered table-condensed" style="width:100%"><tbody class="list"><tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Liquidación</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:65px;" >Año</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:105px;" >Mes</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Tipo Liquidación</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:230px;" >Descripción</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Pendientes</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Firmados</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;" >Operación</td></tr>';
                         */
                         capaInicio = '<table class="stripedGris tablex table-stripedx table-bordered table-condensed" style="width:99%"><tbody class="list"><tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:100pt;text-align:center" >CSV</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Tipo Evento </td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Observación</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Creación</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center" >Vigencia</td></tr>';

                         capaFin = '</tbody></table>';

                         capaAcumulada = capaInicio;
                         //codigo web tarjeton, descripcion tipo evento,observacion,fechacreacion,vigencia
                         /* idEvento = row.GetInt("idEvento"),
                     idVehiculoAsociado = row.GetInt("idVehiculoAsociado"),
                     idTipoEvento = row.GetInt("idTipoEvento"),
                     observacion = row.GetString("observacion", ""),
                     idTarjeton = row.GetInt("idTarjeton"),
                     fechaCreacion = row.GetString("fechaCreacion"),
                     descripcionTipoEvento = row.GetString("descripcionTipoEvento", ""),
                     vigencia = row.GetString("vigencia", ""),
                     codigoWeb = row.GetString("codigoWeb", "")*/

                         if (longitud > 0) {
                             //obtengo el id del bien vehiculo actual
                             idBienVehiculo = resp[0].idVehiculoAsociado;
                         }

                         //genero la lista de liquidaciones
                         for (i = 0; i < longitud; i++) {
                             var s = i;
                             var s2 = i + "otro";
                             capaFil = '<tr>  <td><div style="margin-top:5px">' + resp[i].codigoWeb + '</div></td>  <td><div style="margin-top:5px;text-align:center"><span id="' + s + '">' + resp[i].descripcionTipoEvento + '</span></div></td>  <td><div style="margin-top:5px;text-align:center"><span id="' + s2 + '">' + resp[i].observacion + '</span></div></td> <td><div style="margin-top:5px;text-align:center"><span id="' + s2 + '">' + resp[i].fechaCreacion + '</span></div></td><td><div style="margin-top:5px;text-align:center"><span id="' + s2 + '">' + resp[i].vigencia + '</span></div></td></tr>';

                             capaAcumulada = capaAcumulada + capaFil;
                         }

                         capaAcumulada = capaAcumulada + capaFin;
                         capaLista.innerHTML = capaAcumulada;

                     })
                     .onError(function (e) {
                         spinner.stop();
                     });

             }




         }

         function buscarVehiculo() {
             var patente = document.getElementById("buscadorPatentes").value;
         }

         function asociarTarjeton() {
             var patente = document.getElementById("buscadorPatentes").value;
             var observacion = document.getElementById("observacionmobi").value;
             var vigencia = document.getElementById("vigencia").value;
             var codHolograma = document.getElementById("codhologramamobi").value;

             if (patente == '') {
                 /// no hago nada
                 //alertify.error("Error al enviar consulta");
                 //window.scrollTo(0, 0);
                 alertify.alert("", "Debe ingresar un dominio.");
             } else {
                 window.scrollTo(0, 0);
                 spinner.spin($("html")[0]);

                 //no envio el idVehiculo porque vuelvo a encontrarlo segun la patente en el webservice asi se puede incluso asociar tarjeton sin realizar una prebusqueda de eventos de esa patente
                 Backend.AsociarTarjeton(patente, observacion, vigencia, codHolograma)
                     .onSuccess(function (res) {
                         spinner.stop();
                         var resp = JSON.parse(res);
                         if (!resp.DioError) {
                             UTIL.descargarPDF(resp.Respuesta, resp.nombrePDF);
                             alertify.success(" Exito realizando la operación.");
                         } else {
                             alertify.error(" Error realizando la operación.");
                         }

                     })
                     .onError(function (e) {
                         spinner.stop();
                     });

             }
         }

         function xxxbindearBotonBuscarEventosDePatente() {
             /*var _this = this;

             var btn = $('#cmb_tipobien').change(function () {
                 $("#tabla_recibo_encabezado tbody tr").remove();
                 $("#tabla_recibo_encabezado").hide();
                 $("#bloque_final").hide();

                 var anio = $("#cmb_anio option:selected").val();
                 mes = $("#cmb_meses option:selected").val() - 1;
                 if (mes == 0) {
                     mes = 12;
                     anio = anio - 1;
                 }
                 var div_controles = $("#caja_controles");
                 div_controles.empty();
                 //limpio la info respectiva a los recibos de sueldos
                 $("#caja_info_recibos").empty();
                                     

                 Backend.GetLiquidaciones(anio, mes)
                     .onSuccess(function (liquidacionesJSON) {
                         
                               //  var radio = "<input style='margin:0px' type='radio' name='liquidacion' value='" + liquidaciones[i].Id + "'/><span> " + liquidaciones[i].Descripcion + ' ' + texto_extra + "</span><br/>";
                               //  div_controles.append(radio);

                             
                     })
                     .onError(function (e) {
                         //spinner.stop();
                     });

             });*/

         }



         /* Metodos que publicamos del objeto Generales */
         return {
             buscarEventosTarjetonDePatente: buscarEventosTarjetonDePatente,
             xxxbindearBotonBuscarEventosDePatente: xxxbindearBotonBuscarEventosDePatente,
             setearCamposDefault: setearCamposDefault,
             Mobi_GetTipoBien: Mobi_GetTipoBien,
             asociarTarjeton: asociarTarjeton,
             guardarVehiculo: guardarVehiculo,
             buscarVehiculo: buscarVehiculo
         }

     })(window, undefined);

 </script>
</html>
