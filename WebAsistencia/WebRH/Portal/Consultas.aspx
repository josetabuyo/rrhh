
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<head id="Head1">
    <title>  Portal RRHH </title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width" />
    <!-- CSS media query on a link element -->
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
    <link rel="stylesheet" href="estrellas.css" />
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet" />
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet" />
    <link rel="stylesheet" href="estilosPortalSecciones.css" />
    <link rel="stylesheet" href="chat.css" />
    <link rel="stylesheet"  href="estilosPortalSecciones.css" />
</head>
<body>
    <form id="form1" runat=server >
    <%--<uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />--%>
      
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 30px;">
        </h1>
        <div style="text-align: center;" class="caja_izq no-print">
        </div>
        <div class="caja_der papel">
            <div id="div_explicacion_consultas">
                <br />
                <h4 style="color: #003e67; text-align: center">
                    Este espacio es para que lo aprovechemos juntos como herramienta de comunicación
                    y conocimiento mutuo.
                    <br />
                    Desde aquí podés realizar tus consultas, comentarios, sugerencias y solicitar las
                    asistencia de los integrantes de la
                    <br />
                    <b style="color: #0074cc">Dirección General de Recursos Humanos y Organización</b>
                    <br />
                    para lo que consideres necesario.<br />
                    También recibirás notificaciones, avisos y noticias que consideremos que pueden
                    resultar de tu interés.
                </h4>
                <h5 id="link_nuevos_mensajes" style="cursor: pointer; display: none; text-align: center;
                    float: left; margin-top: 8px; margin-left: 195px;">
                    <p style="text-align: center; font-size: 13px; color: #1a8662; margin-top: 10px;">
                        Nuevos mensajes!</p>
                    <br />
                    <img style="margin-top: -14px; width: 40px;" alt="icono" src="../Imagenes/portal/respuestas.gif" />
                </h5>
                <div style="margin-top: 20px;">
                    <input id="btn_nueva_consulta" type="button" style="position: absolute; left: 25px;"
                        class="btn btn-primary boton_destellante" value="Realizar nueva consulta" />
                    <a id="boton_notificaciones" class="btn btn-primary" style="margin-left: 20px;
                        float: right;">Notificaciones</a> <a id="Button1" href="GestionConsultas.aspx" requierefuncionalidad="49"
                            class="btn btn-primary" style="float: right;">Gestión de consultas </a>
                </div>
            </div>
            <br />
            <br />
            <br />
            <div style="margin-top: 20px;" class="accordion" id="accordion">
                <div class="accordion-group">
                    <div id="ancla1" class="accordion-heading ">
                        <a class="accordion-toggle titulo_acordion" style="text-align: center;" data-toggle="collapse"
                            data-parent="#accordion" href="#collapseOne" id="acordeon_1">RESPUESTAS NO LEIDAS</a>
                    </div>
                    <div id="collapseOne" class="accordion-body collapse">
                        <div class="accordion-inner fondo_form">
                            <fieldset style="width: 100%;">
                                <div id="tablaConsultas_noleidas" class="table table-striped table-bordered table-condensed">
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <br />
                <hr style="clear: both; background-color: #0088cc;" />
                <div class="accordion-group">
                    <div id="ancla2" class="accordion-heading ">
                        <a class="accordion-toggle titulo_acordion" style="text-align: center;" data-toggle="collapse"
                            data-parent="#accordion" href="#collapseTwo" id="acordeon_2">CONSULTAS ESPERANDO
                            UNA RESPUESTA</a>
                    </div>
                    <div id="collapseTwo" class="accordion-body collapse">
                        <div class="accordion-inner fondo_form">
                            <fieldset style="width: 100%;">
                                <div id="tablaConsultas_pendientes" class="table table-striped table-bordered table-condensed">
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <br />
                <hr style="clear: both; background-color: #0088cc;" />
                <div class="accordion-group">
                    <div id="ancla3" class="accordion-heading ">
                        <a class="accordion-toggle titulo_acordion" style="text-align: center;" data-toggle="collapse"
                            data-parent="#accordion" href="#collapseThree" id="acordeon_3">TODAS LAS CONSULTAS</a>
                    </div>
                    <div id="collapseThree" class="accordion-body collapse">
                        <div class="accordion-inner fondo_form">
                            <fieldset style="width: 100%;">
                                <div id="tablaConsultas_historicas" class="table table-striped table-bordered table-condensed">
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
                
                
                
            </div>
            <div id="div_detalle_consulta" style="display: none; margin-bottom: 10px;">
                <label style="font-size: initial;">
                    <strong>Motivo:</strong></label>
                <p id="ta_motivo" style="display: inline; font-style: italic;">
                </p>
                
                <br />
                <br />
                <label style="font-size: initial;">
                    <strong>Respuesta:</strong></label>
                <p id="ta_respuesta" style="display: inline; font-style: italic;">
                </p>
                
            </div>
        </div>
    </form>
    <div id="pantalla_alta_ticket" style="display: none">
        <p style="font-size: xx-large; text-align: center; margin-top: 10px;">
            Realizar consulta</p>
        <br />
        <p>
            Seleccione el tipo de consulta que quiere realizar desde el menu izquierdo de la
            pantalla. Luego complete el campo de texto con su duda en cuestión</p>
        <br />
        <select id="cmb_tipo_consulta" size="7">
        </select>
        <textarea id="txt_motivo_consulta" placeholder="Ingrese su consulta aquí" maxlength="1000"></textarea>
        <input id="btn_enviar_consulta" type="button" class="btn btn-primary" style="margin: auto;
            display: block; width: 100px; height: 30px; margin-top: 10px; padding-bottom: 25px;"
            value="ENVIAR" />
    </div>
    <div id="pantalla_notificaciones" style="display: none">
        <p style="font-size: xx-large; text-align: center; margin-top: 10px;">
            Notificaciones</p>
        <br />
        <div id="table_notificaciones" class="table table-striped table-bordered table-condensed">
        </div>
    </div>
    <div id="pantalla_consulta_ticket" style="display: none;">
        <h3 id="titulo_consulta" style="text-align: center;">
            CONSULTA NÚMERO.</h3>
        <div id="div_chat" style="height: 320px; margin-top: -10px; overflow: scroll; overflow-x: hidden;">
            <div id="div_repreguntar" style="text-align: center; display: none;">
                <textarea id="ta_repreguntar" placeholder="Ingrese su consulta aquí" maxlength="1000"
                    style="width: 100%; margin-top: 30px;" rows="5"></textarea>
                <input id="btn_enviar_pepregunta" type="button" class="btn btn-primary" style="margin-top: 5px;
                    margin-bottom: -30px;" value="Enviar" />
            </div>
            <ol class="chat" id="listado_chat">
                <li id="other" class="other" style="display: none;">
                    <div class="avatar">
                        <img src="../Imagenes/Portal/icono_rrhh.png" draggable="false">
                    </div>
                    <div class="msg">
                        <time class="time">20:17</time>
                    </div>
                </li>
                <br />
                <li id="self" class="self" style="display: none;">
                    <div class="avatar">
                        <div class="imagen" style="width: 40px; height: 40px; margin-left: 0px; margin-top: 0px;">
                        </div>
                    </div>
                    <div class="msg">
                        <time class="time">20:18</time>
                    </div>
                </li>
            </ol>
        </div>
        <div id="contenedor_estrellas">
        </div>
        <br />
        <div style="text-align: center; margin-top: -15px;">
            <input id="btn_pepreguntar" type="button" class="btn btn-primary" value="Repreguntar" />
            <input id="btn_cerrar" type="button" class="btn btn-primary" value="Dar por finalizada la consula" />
            <span id="txt_mensaje_calificacion"></span>
            <input id="btn_calificar" type="button" class="btn btn-primary" value="Calificar"
                style="display: none;" />
        </div>
    </div>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript">

    $(document).ready(function ($) {
        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm", function () {
            $("#btn_consultas_historicas_del_empleado").click(function () {
                $("#div_consultas_enviadas").show();
                $("#div_explicacion_consultas").hide();
            });
            $("#btn_volver_explicacion").click(function () {
                $("#div_consultas_enviadas").hide();
                $("#div_detalle_consulta").hide();
                $("#div_explicacion_consultas").show();

            });
            $("#link_nuevos_mensajes").click(function () {
                $("#btn_consultas_historicas_del_empleado").click();
            });

            Backend.start(function () {
                Legajo.getNombre();
                Legajo.getConsultas();
                Legajo.GetNotificaciones();
                Legajo.GetComboTipoConsulta(); //aca dentro bindeo el evento del boton realizar consulta
            });
        });
    });


</script>
</html>
