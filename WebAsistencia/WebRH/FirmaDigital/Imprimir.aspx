<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imprimir.aspx.cs" Inherits="Permisos_DefinicionDeUsuario" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <!-- CSS media query on a link element -->
        <%= Referencias.Css("../")%>
        <%= Referencias.Javascript("../")%>
        <link rel="stylesheet" href="estilosPortalSecciones.css" />
        <link rel="stylesheet" href="recibo.css" />

        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        <link rel="stylesheet"  href="estilosPermisos.css" />
        <link rel="stylesheet" href="../Permisos/Permisos.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDeAreas.css" type="text/css"/>   
         
        <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
        <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
 

        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
       
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    
        <!--caja de contenido por debajo del menu-->
    <div style="width:99%; margin-left:11px; margin-right:11px">
        <!-- el back-ground lo setee abajo porque justo hay unn estilo en permisos de caja_izq con otro color de azul-->
        <!--<div style="background-image: linear-gradient(to bottom, rgb(1,70,99), rgb(1,70,99))" class="caja_izq no-print"></div>-->
        <div class="caja_izq no-print"></div>
        <!--contenido derecho -->
         <div  class="caja_derxxxx papelxxx" style="margin-top:32px;float:left;width:80% ">
           <!--modulo de busqueda de recibos -->
           <div id="subcontenidoBusquedaRecibosConformados" class="panelDerOcultable" style="display: inline;"> 

               <div style="width:80%;margin:20pt;-webkit-border-radius: 7px 7px 0px 0px;
-moz-border-radius: 7px 7px 0px 0px;border-radius: 7px 7px 0px 0px;border-collapse: collapse;border: 0px solid #1C6EA4;padding-left:40pt;text-align: center;margin: 0 auto;">
                   <div class="cajaPermisos">
                       <div id="buscador_de_personas" style="vertical-align: middle; padding:5px;;margin-bottom:20px">
                         <p class="buscarPersona" style="display: inline-block;">Buscar persona:
                            <div id="selector_usuario" class="selector_personas" style="display: inline-block;">
                                <input id="buscador" type="hidden" />
                            </div>
                        </p>
                       </div>
                    </div>                   
                   <hr class="barraHorizontal">
                   <br />

                   <div id="panel_datos_usuario" style="display:none">
                   <div id="panel_superior_izquierdoxxx" class="estilo_formulario3">
                    <div id="contenedor_foto2">
                        <div id="foto_usuario"> </div>
                        <img id="foto_usuario_generica" src="../MAU/usuario.png"/>
                        <div id="barrita_cambio_foto">
                            <div></div>
                        </div>
                    </div>
                    <div id="cambio_imagen_pendiente" >
                        <img src="../MAU/camera.png"/>
                    </div>
                    <div id="panel_datos_personales3">
                        <div class="linea dato_personal2">
                            <div id="nombre2"></div>
                            <div id="apellido2"></div>
                        </div>
                        <div class="linea dato_personal2">
                            <div>Documento:</div>
                            <div id="documento2" ></div>
                        </div>
                        <div class="linea dato_personal2">
                            <div>Legajo:</div>
                            <div id="legajo2"></div>    
                        </div>     

                        <div class="linea dato_personal2">
                            <div>Email:</div>
                            <div id="email"></div>                               
                        </div>    
                        <div class="linea dato_personal2">
                            <div>Area:</div>
                            <div id="areaActual"></div>                               
                        </div> 
                    </div>
                    
                </div> 

                   
	            <div  style="margin:5px 0 5px 0;">
                    <div >   
                        <input type="radio" name="modoRecibo" value="0" checked id="recibosRecientes" style="margin-top: 0px;" onclick="getRecibosAEnlistar()" /> <label for="recibosRecientes">Recibos Recientes </label>   
                        <input type="radio" name="modoRecibo" value="1" id="recibosHistoricos" style="margin-top: 0px;" onclick="getRecibosAEnlistar()" /> <label for="recibosHistoricos">Recibos Historicos  </label>    
	                </div>
                    <!-- 	lista de recibos de la persona--> 
                    <div id ="listaRecibosConfomadosPersonal">  
	                </div>
	            </div>  

                <div style="margin-bottom:50px; float:right;" > 
                    <input class="botonAzul" type ="button" value="Ver por pantalla" onclick="mostrarRecibo()">
                    <input class="botonAzul" type="button" value="Descargar" onclick="descargarRecibo()">                     
	            </div>                 
                       
            </div> 
                
            </div>               

               </div> 

           <!--modulo de visualizacion del recibo seleccionado-->
           <div id="subcontenidoReciboConformado" class="panelDerOcultable" style="display: none;">
               <div style="width:80%;margin:20pt;-webkit-border-radius: 7px 7px 0px 0px;
-moz-border-radius: 7px 7px 0px 0px;border-radius: 7px 7px 0px 0px;border-collapse: collapse;border: 0px solid #1C6EA4;padding-left:40pt;text-align: center;margin: 0 auto;">

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
                    <th colspan="3" style="text-align:center;">Importe</th>
                </tr>
                <tr class="fila_header">
                    <th colspan="1" style="width:110px;">Haberes</th>
                    <th colspan="2" style="width:110px;">Descuentos</th>
                </tr>
           </thead>
           <tbody>
               
            </tbody>
         </table>
         
        <div id="bloque_final" style="display:none; margin-top:20px;text-align:left;;width:88%">
            <p style="font-weight: bold; text-align: center; margin-top: 20px;">SOLO PARA INFORMACIÓN - NO VÁLIDO COMO COMPROBANTE</p>
       
            <p><strong>Área:</strong> <span id="area"></span></p>
            <p><strong>Categ:</strong> <span id="categoria"></span></p>
            <p><strong>Fecha Liq:</strong> <span id="fechaLiquidacion"></span></p>
            <p><strong>Domicilio:</strong> <span id="domicilio"></span></p>

            <div style="margin-bottom:50px; float:right;" > 
                <input type="button"  class="botonAzul" value="Volver" onclick="mostrar('subcontenidoBusquedaRecibosConformados')">
                <input class="botonAzul" type="button" value="Descargar" onclick="descargarRecibo()">   
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

           </div> 

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

<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>

<script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>


<script type="text/javascript" src="../MAU/VistaDeAreasAdministradas.js"></script>
<script type="text/javascript" src="../MAU/VistaDeAreaAdministrada.js"></script>
<script type="text/javascript" src="../Scripts/Area.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>

<script type="text/javascript" src="../Scripts/alertify.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>

<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>

<script type="text/javascript" src="js/imprimirRecibo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>

<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/jsPortal/RepoFirmaDigital.js"></script>

<script type="text/javascript" >

    var listaRecibosConformados = new Array();
    var agenteActual = '';

    $(document).ready(function ($) {

             
        Backend.start(function () {
            Permisos.init();/*esta variable esta en imprimirRecibo.js*/
            //para cargar el menu izquierdo 
            $(".caja_izq").load("SeccionIzquierda.htm", function () {
                
                Permisos.iniciarConsultaRapida();
                //FC: para importar el HabilitadorDeControles y afecte la seccion izquierda
                var imported = document.createElement('script');
                    imported.src = '../MAU/HabilitadorDeControles.js';
                document.head.appendChild(imported);

               /* Backend.GetReciboPDFDigitalArchivado(418)
                    .onSuccess(function (res) { });*/
             /*   Backend.GetReciboPDFDigital(980679,0)
                    .onSuccess(function (res) {
                        //en esta version siempre retorna exito a menos que sea un error antes del webservice
                        if (!res.DioError) {
                            var b64 = res.Respuesta;

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
                            link.download = agenteActual + " prueba " + ".pdf";//este elemento hace que se descargue automaticamente si lo saco se abrira otra pagina
                            link.click();
                            window.URL.revokeObjectURL(data);
                            link.remove();
                        }

                    })
                    .onError(function (e) {
                        //por aca nunca se entra si desde el webserver no se levanta una excepcion   
                        spinner.stop();
                    });*/

                /*                                                                                                                                                                                                                                                                                                            $('#btnPantallaAsignarPerfil').click(function () {
                    $(".caja_der").load("AsignacionDePerfiles.htm", function () {
                        Permisos.iniciarPantallaAsignacionPerfiles();
                        Permisos.getPerfilesDelUsuario();
                        Permisos.getPerfilesConFuncionalidades();

                        $("#dialog").dialog({
                            autoOpen: false,
                            show: {
                                effect: "blind",
                                duration: 1000
                            },
                            hide: {
                                effect: "explode",
                                duration: 1000
                            }
                        });

                        $("#mostrarDialogo").click(function () {
                            $("#dialog").dialog("open");
                        });
                        
                    });
                });//FIN clickBtnPantalla
                
                $('#btnPantallaAsignarFuncionalidad').click(function () {
                    $(".caja_der").load("AsignacionDeFuncionalidades.htm", function () {
                        Permisos.iniciarPantallaAsignacionFuncionalidad();
                        Permisos.getFuncionalidadesDelUsuario();


                        
                    });
                });

                $("#btnBuscarPersonasDeBaja").click(function () {
                    $(".caja_der").load("ConsultaPermisosDeBaja.htm", function () {
                        Permisos.getPersonasDeBajaConPermisos();
                    });
                   
                });

                $("#btnBuscarUsuariosPorArea").click(function () {
                    $(".caja_der").load("ConsultarUsuariosPorArea.htm", function () {
                        Permisos.buscadorUsuariosPorArea();
                    });
                   
                });

*/
                

                

            });
 
        });
         

    });

    /*retorna si se esta en modo historico o no*/
    function getModoRecibo() {

        //obtengo la lista de radio button con un nombre de clase determinado
        var lista = document.getElementsByName("modoRecibo");
        var i;
        var valorModo = 0;

        for (i = 0; i < lista.length; i++) {
            //si hay algo seleccionado
            if (lista[i].checked) {
                valorModo = lista[i].value;
            }
        }
        return valorModo;
    }

    function getRecibosAEnlistar() {
        
        Permisos.getRecibos(idPersonaActual, getModoRecibo());
    }

    /*
     */
    function seleccionarRecibo() {

        //obtengo la lista de checkbox con un nombre de clase determinado
        var lista = document.getElementsByClassName("chk_listado");
        var i;
        var idRecibo = 0;

        for (i = 0; i < lista.length; i++) {
            //si hay algo seleccionado
            if (lista[i].checked) {
                idRecibo = lista[i].id;

            }
        }
        return idRecibo;
    }
    function seleccionarArchivo() {

        //obtengo la lista de checkbox con un nombre de clase determinado
        var lista = document.getElementsByClassName("chk_listado");
        var i;
        var idArchivo = -2;

        for (i = 0; i < lista.length; i++) {
            //si hay algo seleccionado
            if (lista[i].checked) {
                idArchivo = lista[i].value;

            }
        }        
        return idArchivo;
    }


          

    function mostrarRecibo() {

        var idRecibo = seleccionarRecibo();//obtengo al recibo seleccionado
        if (idRecibo != 0) {
            mostrar('subcontenidoReciboConformado');
            //limpio datos especificos del recibo  dejo los generales
            $("#tabla_recibo_encabezado tbody tr").remove();
            $('#celdaOficina').html("");
            $('#celdaOrden').html("");
            $('#area').html("");
            $('#domicilio').html("");
            $('#fechaLiquidacion').html("");
            $('#categoria').html("");

            var spinner = new Spinner({ scale: 2 });
            spinner.spin($("html")[0]);
            Backend.GetReciboPorId(idRecibo,getModoRecibo()).onSuccess(function (reciboJSON) {
                spinner.stop();

                $("#tabla_recibo_encabezado tbody tr").remove();
                $("#tabla_recibo_encabezado").show();
                $("#bloque_final").show();


                var recibo = JSON.parse(reciboJSON);
                var detalle = "";
                var _this = this;

                $('#celdaLegajo').html(recibo.cabecera.Legajo);
                $('#celdaNombre').html(recibo.cabecera.Agente);
                $('#celdaCUIL').html(recibo.cabecera.CUIL);
                $('#celdaOficina').html(recibo.cabecera.Oficina);
                $('#celdaOrden').html(recibo.cabecera.Orden);

                $('#bloque_final').show();
                $('#area').html(recibo.cabecera.Area);
                $('#domicilio').html(recibo.cabecera.Domicilio);
                $('#fechaLiquidacion').html(recibo.cabecera.FechaLiquidacion);
                $('#categoria').html(recibo.cabecera.NivelGrado);

                for (var i = 0; i < recibo.detalles.length; i++) {

                    if (recibo.detalles[i].Aporte != "0" || recibo.detalles[i].Descuento != "0") {
                        detalle = detalle + "<tr><td>" + recibo.detalles[i].Concepto + "</td><td class=\"columna_concepto\">"
                        + recibo.detalles[i].Descripcion + "</td><td>" + Legajo.ConvertirAMonedaOVacio(recibo.detalles[i].Aporte) + "</td><td colspan=\"2\">"
                        + Legajo.ConvertirAMonedaOVacio(recibo.detalles[i].Descuento) + "</td></tr>";
                    }

                }

                detalle += "<tr style='border-bottom:none;' class='ultima_fila'><td style='border: none;'></td><td style='border: none;'></td><td class='celda_bruto_nombre'><strong>Bruto:</strong></td><td class='celda_bruto'>" + Legajo.ConvertirAMonedaOVacio(parseInt(recibo.cabecera.Bruto)) + "</td><td class=''> " + Legajo.ConvertirAMonedaOVacio(parseInt(recibo.cabecera.Descuentos)) + "</td></tr>";
                detalle += "<tr style='border:none;' class='ultima_fila'><td style='border: none;'></td><td style='border: none;'></td><td class='celda_neto'><strong>Neto:</strong></td><td class='celda_importe_neto' colspan='2'><strong>" + Legajo.ConvertirAMonedaOVacio(parseInt(recibo.cabecera.Neto)) + "</strong></td></tr>";

                $("#tabla_recibo_encabezado > tbody ").append(detalle);


            })
            .onError(function (e) {
                spinner.stop();
            });
            
        }
    }

    //subcontenidoBusquedaRecibosConformados
    function mostrar(idPanel) {
        //oculto todos los paneles y solo muestro el enviado como parametro
        document.getElementById('subcontenidoBusquedaRecibosConformados').style.display = 'none';
        document.getElementById('subcontenidoReciboConformado').style.display = 'none';

        document.getElementById(idPanel).style.display = 'block';

    }

    /*SOLO: permito descargar recibos conformados por el agente, porque se le descarga recibos pdf firmados*/
    function descargarRecibo() {

        var idArchivo = seleccionarArchivo();//obtengo al recibo seleccionado

        if (idArchivo == -2) {
            alertify.alert("", "Debe seleccionar un recibo.");
        } else {
            if (idArchivo == -1) {
                alertify.alert("", "El recibo aun no ha sido firmado digitalmente.");
            } else {
                // ahora verifico si esta conformado o no
                var conformado = listaRecibosConformados['id' + seleccionarRecibo()];
                if (conformado == 1) {
                    GeneralPortal.descargarRecibo(idArchivo);
                } else {
                    alertify.alert("", "El recibo aun no esta conformado por el agente.");
                }

            }             
        }
       
    }


</script> 
</html>
