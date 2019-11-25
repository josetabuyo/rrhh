<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imprimir2.aspx.cs" Inherits="Portal_Recibo" %>
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

        <link rel="stylesheet"  href="../Permisos/estilosPermisos.css" type="text/css"/>
        <link rel="stylesheet" href="../Permisos/Permisos.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDeAreas.css" type="text/css"/>
        <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
        <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        

    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    
    <!--caja de contenido por debajo del menu-->
    <div style="width:99%; margin-left:11px; margin-right:11px">
    

        <div style="/*text-align:center;margin-top:5px; margin-left: 5px;margin-right:5px;background-color:rgb(1,70,99);*/" class="caja_izq no-print">
       <!-- Perfil empleador:<br />Firma Iterativa<br />Perfil empleado:<br />Confirmacion Recibo<br />Perfil auditor:<br />
        Verificacion de una firma<br />Obtener un recibo firmado<br />...-->
        </div>

        <!--contenido derecho -->
         <div  class="caja_derxxxx papelxxx" style="margin-top:5px;float:left;width:80% ">
           <!--modulo de firma iterativa -->
           <div id="subcontenidoFirmaIterativa" class="panelDerOcultable" style="display: inline;">               

            <div id="div_recibo" style="margin:20pt;">            
                <br />
                <div class="cajaPermisos">
                    <div id="buscador_de_personas">
                        <p class="buscarPersona" style="display: inline-block;">Buscar persona:
                            <div id="selector_usuario" class="selector_personas" style="display: inline-block;">
                                <input id="buscador" type="hidden" />
                            </div>
                        </p>
                    </div>
                </div>
                <div id="panel_datos_usuario" style="display:none">
                <div id="panel_superior_izquierdo" class="estilo_formulario">
                    <div id="contenedor_foto">
                        <div id="foto_usuario"> </div>
                        <img id="foto_usuario_generica" src="usuario.png"/>
                        <div id="barrita_cambio_foto">
                            <div>Cambiar</div>
                        </div>
                    </div>
                    <div id="cambio_imagen_pendiente" >
                        <img src="camera.png"/>
                    </div>
                    <div id="panel_datos_personales">
                        <div class="linea dato_personal">
                            <div id="nombre2"></div>
                            <div id="apellido2"></div>
                        </div>
                        <div class="linea dato_personal">
                            <div>Documento:</div>
                            <div id="documento2" ></div>
                        </div>
                        <div class="linea dato_personal">
                            <div>Legajo:</div>
                            <div id="legajo2"></div>    
                        </div>     
                        <div class="linea dato_personal">
                            <div>Email:</div>
                            <div id="email"></div>   
                            <input id="btn_modificar_mail" type="button" class="btn-primary botonesPermisos" value="Modificar"  /> 
                        </div>      
                        <input id="btn_credencial_usuario" type="button" class="btn-primary botonesPermisos" value="Credencial" />           
                    </div>
                    <div id="panel_password">
                        <div class="linea linea_nombre_usuario">
                            <div class="titulo">Nombre de Usuario</div>
                            <div id="txt_nombre_usuario"> </div>  
                        </div>
                        <div class="linea linea_passwrd">
                            <div class="titulo">Contraseña:</div>
                            <input id="btn_reset_password" type="button" class="btn-primary botonesPermisos" value="Resetear" />
                        </div>
                        <div class="seccion_verificacion_usuario">
                            <div id="usuario_verificado">DNI Verificado</div>    
                            <div id="usuario_no_verificado">DNI No Verificado</div>    
                            <input id="btn_verificar_usuario" type="button" class="btn-primary botonesPermisos" value="Verificar"  />
                        </div>
                    </div>
                </div> 
            </div> 

                <div id="caja_permisos_actuales" style="display:none;">
                    <legend style="margin-top: 20px;">PERMISOS ACTUALES</legend>
                    <div id="tabla_permisos">
    
                    </div>

                    <div id="caja_funcionalidades">
                         <input type="text" id="search" class="search buscador" style="height: 30px;" placeholder="Buscar Funcionalidad"  />
                         <div id="tabla_funcionalidades">
    
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>

         
        <div id="plantillas">
            <div class="vista_persona_en_selector">
                <div id="contenedor_legajo" class="label label-warning">
                    <div id="titulo_legajo">Leg:</div>
                    <div id="legajo"></div>
                </div> 
                <div id="nombre"></div>
                <div id="apellido"></div>
                <div id="contenedor_doc" class="label label-default">
                    <div id="titulo_doc">Doc:</div>
                    <div id="documento"></div>         
                </div>   
            </div>

            	
        </div


            </div> 

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
<script type="text/javascript">
    var divMensajeStatus = document.getElementById('divMensajeStatus');
//    var btn_firmar = document.getElementById("btn_firmar");  //BORRAR ya no la uso
    var lista_recibos_resumen; /*variable que mantiene la lista de recibos */
    var anio;
    var mes;
    var tipoLiquidacion;
    var tiposLiquidaciones;
    var liquidaciones; //lista de liquidaciones
    var rsfLiquidaciones = new Array(); //diccionario de recibos sin firmar
    var rfLiquidaciones = new Array();  //diccionario de recibos firmados

    function armarListaLiquidaciones() {
        /*obtengo la lista de liquidaciones*/

       RECIBOS.getLiquidacionesAFirmar();
    }


    /********BORRAR: MODELO VIEJO ahora se requiere historico de liquidaciones*/
    /************BORRAR:YA no usada**************/
    function buscarRecibos() {
        //NOTA: si tipo liquidacion es 0 entonces por ahora no se traer TODOS los recibos de un dado año y mes
        //se limita aqui, pero se puede hacer un bucle aqui e iterar por todos los tipos de liquidacion y obtener todos los recibos y luego firmar, hacer eso por cada tipo de liquidacion

        if (document.getElementById('cmb_tipo_liquidacion').value == "0") {
            divMensajeStatus.innerHTML = '<div class="iconAlerta">Debe seleccionar un Tipo de Liquidacion</div>';
        } else { 
            //Muestro un mensaje de procesando
            divMensajeStatus.innerHTML = '<div class="iconProcesando">Procesando Solicitud ...</div>';

            //realizo la operacion
            anio = document.getElementById('cmb_anio').value;
            mes = document.getElementById('cmb_meses').value;
            tipoLiquidacion = document.getElementById('cmb_tipo_liquidacion').value;


            /*nota1: las horas extra siempre se migran un mes despues del mes de liquidacion.Aun asi en la tabla de PLA_RECIBO el año y el mes de la liquidacion es el correcto.
            Por ejemplo: cuando el tipo de liquidacion es "hora extra" :

            PLA_RECIBOS_MIGRADOS, año=2019, mes=2  .año=2019, mes=1
            PLA_RECIBOS,     año=2019, mes 1       .año=2018, mes=12*/

            /*verifico si el tipo de liquidacion pertenece a los extras*/
            if (tiposLiquidaciones[tipoLiquidacion].Meses_Retraso > 0) {
            /*if (tipoLiquidacion.toLowerCase().indexOf("extras") >= 0) {*/
                /*actualizo la fecha a la liquidacion de un mes atras*/
                if (mes == "1") { /*es enero*/
                    mes = 12;
                    anio = anio - 1;
                } else {
                    mes = mes - 1;
                }
            
            }
                     
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

<script type="text/javascript" src="../Permisos/Permisos.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>

<script type="text/javascript" >

    $(document).ready(function ($) {
        //NOTA: por el momento lo deshabilito porque da error
        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm", function () {
            Backend.start(function () {
                Permisos.init();
                Permisos.iniciarConsultaRapida();

                // las funciones de inicio se deben ejecutar aqui dentro

                //cargo las listas seleccionables
//                RECIBOS.getTiposLiquidacion();
                
                /*cargo la lista de años, los ultimos 3 años*/
//                var day = new Date();
//                var mes = day.getMonth() + 1;
//                var anio = day.getFullYear();


//                $("#cmb_anio").empty();

//                for (var i = 0; i <= 2; i++) {
//                    $("#cmb_anio").append('<option value=' + (anio - i).toString() + '>' + (anio - i).toString() + '</option>');
//                }
                /*seteo el mes al mes actual*/
//                $("#cmb_meses").val(mes)

                /*verifico si el mes del año seleccionado esta permitido para seleccionar*/
//                var btn = $('#cmb_meses').change(function () {
                                    
//                    var mes = $("#cmb_meses option:selected").val() - 1;
                   
//                    var anio_combo = $("#cmb_anio option:selected").val();
//                    var day = new Date();
//                    var mes_no_permitido = day.getMonth() + 2;
//                    var anio = day.getFullYear();

                    //si el año seleccionado es el actual seteo el mes al mes actual y el mes seleccionado es mayor al mes actual
//                    if ((anio_combo == anio) && (mes > mes_no_permitido - 1)) {
//                        $("#cmb_meses").val(mes_no_permitido - 1);
//                   }
//                });

                /*seteo el evento cambio en la seleccion del año*/
//                var btn_combo_anio = $('#cmb_anio').change(function () {
//                    $('#cmb_meses').change();
//                    var anio_combo = $("#cmb_anio option:selected").val();
//                    var day = new Date();
//                    mes_para_inhabilitar = day.getMonth() + 2;
//                    var anio = day.getFullYear();

                    //inhabilito lo meses que no estan vigentes para este año
//                    if (anio_combo == anio) {
//                        $("#cmb_meses option").each(function () {
//                            if (mes_para_inhabilitar <= $(this).val()) {
//                                $(this).attr('disabled', 'disabled');
//                            }
//                        });
//                    } else {
//                        $("#cmb_meses option").each(function () {
//                            $(this).removeAttr('disabled');
//                        });
//                    }
//                });
                /*llamo al metodo change en la carga de la pagina*/
//                $("#cmb_anio").trigger('change');

            });
        });



    });

    
</script> 


</html>
