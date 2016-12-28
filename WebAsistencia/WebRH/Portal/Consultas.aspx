<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consultas.aspx.cs" Inherits="Portal_Consultas" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Portal RRHH</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width">
    <!-- CSS media query on a link element -->
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
    <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortalSecciones.css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 30px;">
        </h1>
        <div style="text-align: center;" class="caja_izq no-print">
        </div>
        <div class="caja_der papel">
            <div id="div_explicacion_consultas">
                <br />
                <h4 style="color: #003e67; text-align: center">
                    Bienvenido al espacio brindado por la Oficina de <b style="color: #0074cc">RECURSOS
                        HUMANOS</b> para que usted pueda realizar consultas, comentarios, sugerencias
                    y solicitar asistencia Web sobre toda la gestión y procesos de los Colaboradores
                    del<br />
                    <b style="color: #0074cc">Ministerio de Desarrollo Social de la Nación</b></h4>
                <h5 id="link_nuevos_mensajes" style="cursor: pointer; display: none; text-align: center;
                    float: right; margin-top: -5px;">
                    <p style="text-align: center; font-size: 13px; color: #1a8662;">
                        Nuevos mensajes!</p>
                    <br />
                    <img style="margin-top: -30px; width: 90px;" alt="icono" src="../Imagenes/portal/respuestas.gif" />
                </h5>
                <br />
                <br />
                <input id="btn_nueva_consulta" type="button" class="btn btn-primary boton_destellante"
                    value="Realizar nueva consulta" />
            </div>
            <br />
            <br />
            <br />
            <div style="margin-top: 20px;" class="accordion" id="accordion">
                <div class="accordion-group">
                    <div id="ancla1" class="accordion-heading ">
                        <a class="accordion-toggle titulo_acordion" style="text-align: center;" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">NUEVAS RESPUESTAS</a>
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
                        <a class="accordion-toggle titulo_acordion" style="text-align: center;" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">CONSULTAS PENDIENTES DE UNA RESPUESTA</a>
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
                        <a class="accordion-toggle titulo_acordion" style="text-align: center;" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">TODAS LAS CONSULTAS</a>
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
                
                <%--<h5>
                    Nuevas respuestas:</h5>
                <div id="tablaConsultas_noleidas" class="table table-striped table-bordered table-condensed">
                </div>
                <h5>--%>
                  <%--  Consultas pendientes de una respuesta:</h5>
                <div id="tablaConsultas_pendientes" class="table table-striped table-bordered table-condensed">
                </div>
                <h5>
                    Todas las Consultas:</h5>
                <div id="tablaConsultas_historicas" class="table table-striped table-bordered table-condensed">
                </div>--%>
                <%-- <input id="btn_volver_explicacion" type="button" class="btn btn-primary" value="Volver" />--%>
            </div>
            <div id="div_detalle_consulta" style="display: none; margin-bottom: 10px;">
                <label style="font-size: initial;">
                    <strong>Motivo:</strong></label>
                <p id="ta_motivo" style="display: inline; font-style: italic;">
                </p>
                <%--<textarea id="ta_motivo" style="width: 100%; height: 150px;" readonly></textarea>--%>
                <br />
                <br />
                <label style="font-size: initial;">
                    <strong>Respuesta:</strong></label>
                <p id="ta_respuesta" style="display: inline; font-style: italic;">
                </p>
                <%--<textarea id="ta_respuesta" style="width: 100%; height: 150px;" readonly></textarea>--%>
            </div>
        </div>
    </form>
    <div id="pantalla_alta_ticket" style="display: none">
        <p style="font-size: xx-large; text-align: center; margin-top: 10px;">Realizar consulta</p>
        <br />
        <p>Seleccione el tipo de consulta que quiere realizar desde el menu izquierdo de la pantalla. Luego complete el campo de texto con su duda en cuestión</p>
        <br />
        <select id="cmb_tipo_consulta" size="7">
        </select>
        <textarea id="txt_motivo_consulta" placeholder="Ingrese su consulta aquí" maxlength="1000"></textarea>
        <input id="btn_enviar_consulta" type="button" class="btn btn-primary" style="margin: auto;
            display: block; width: 100px; height: 30px;" value="ENVIAR" />
    </div>
    <div id="pantalla_consulta_ticket" style="display: none">
        <h3 style="text-align: center;">
            CONSULTA NÚMERO.</h3>
        <br />
        <ol class="chat">
            <li class="other">
                <div class="avatar">
                    <img src="http://i.imgur.com/DY6gND0.png" draggable="false" /></div>
                <div class="msg">
                    <p>
                        Hola!</p>
                    <p>
                        Te vienes a cenar al centro?v jkdfj kldj kldfsñj fklñsdm jklñsdg mjgsdmklñgj sldk jksdljg klsdjsfklj klsfdjgk lsjgklsdj klsdfj klgsdfj klj klsdg sdfjsdfhdjkl  jkldjfk ljgkldklgjd kfjdklfjkl klj fkdlj fdklj kldf
                        <emoji class="pizza" />
                    </p>
                    <time>20:17</time>
                </div>
            </li>
            <li class="self">
                <div class="avatar">
                    <img src="http://i.imgur.com/HYcn9xO.png" draggable="false" /></div>
                <div class="msg">
                    <p>
                        Puff...</p>
                    <p>
                        Aún estoy haciendo el contexto de Góngora...
                        <emoji class="books" />
                    </p>
                    <p>
                        Mejor otro día</p>
                    <time>20:18</time>
                </div>
            </li>
        </ol>
        <input class="textarea" type="text" placeholder="Type here!" /><div class="emojis">
        </div>
        <br />
        <input id="btn_cerrar" type="button" class="btn btn-primary" style="margin: auto;
            display: block; width: 100px; height: 30px;" value="Cerrar Consulta" />
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
                Legajo.GetComboTipoConsulta();//aca dentro bindeo el evento del boton realizar consulta

                
            });
        });
    });


</script>
</html>
