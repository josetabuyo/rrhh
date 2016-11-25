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
                <br />
                <br />
                <h5 id="link_nuevos_mensajes" style="float: right;cursor:pointer;">
                    <p style="text-align: center; font-size: initial; color: #1a8662;">
                        Nuevos mensajes!</p>
                    <br />
                    <img style="margin-top: -28px; width: 140px;" alt="icono" src="../Imagenes/portal/respuestas.gif" /></h5>
                <h5>
                    Desde aquí podrá:</h5>
                <ul style="margin-left: 10px;">
                    <li type="disc">Realizar Consultas Administrativas</li>
                    <li type="disc">Solicitar Cambios y Correcciones de Datos</li>
                    <li type="disc">Aclarar sus dudas e inquietudes sobre las herramientas del Sitio y de
                        Gestión</li>
                    <li type="disc">Enviar Sugerencias y Comentarios</li>
                </ul>
                <br />
                <br />
                <br />
                <h5 style="float: left;">
                    Si quiere generar una consulta, seleccione aquí:</h5>
                <input id="btn_nueva_consulta" type="button" class="btn btn-primary" style="margin: 10px;
                    margin-top: -5px;" value="Realizar nueva consulta" />
                <br />
                <br />
                <br />
                <h5 style="float: left;">
                    Si quiere ver las consultas enviadas, seleccione aquí:</h5>
                <input id="btn_consultas_historicas_del_empleado" type="button" class="btn btn-primary" style="margin: 10px;
                    margin-top: -5px;" value="Consultas enviadas" />
            </div>
            <div id="div_consultas_enviadas" style="display: none;">
                <div id="tablaConsultas" class="table table-striped table-bordered table-condensed">
                </div>
                <input id="btn_volver_explicacion" type="button" class="btn btn-primary" value="Volver" />
            </div>
            <div id="div_detalle_consulta" style="display: none;">
                <label style="margin-right: 24px;">
                    Motivo:</label>
                <textarea id="ta_motivo" style="width: 100%; height: 150px;" readonly></textarea>
                <br />
                <br />
                <label>
                    Respuesta:</label>
                <textarea id="ta_respuesta" style="width: 100%; height: 150px;" readonly></textarea>
            </div>
        </div>
    </form>
    <div id="pantalla_alta_ticket" style="display: none">
        <select id="cmb_tipo_consulta">
        </select>
        <textarea id="txt_motivo_consulta" placeholder="ingrese su consulta aquí" maxlength="1000"></textarea>
        <input id="btn_enviar_consulta" type="button" class="btn btn-primary" style="margin: 10px"
            value="Enviar" />
    </div>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
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
                Legajo.GetComboTipoConsulta();
                $("#btn_nueva_consulta").click(function () {
                    vex.defaultOptions.className = 'vex-theme-os';
                    vex.open({
                        afterOpen: function ($vexContent) {
                            var ui = $("#pantalla_alta_ticket").clone();
                            $vexContent.append(ui);
                            ui.show();
                            ui.find("#btn_enviar_consulta").click(function () {
                                Backend.NuevaConsultaDePortal({
                                    id_tipo_consulta: ui.find("#cmb_tipo_consulta").val(),
                                    tipo_consulta: ui.find("#cmb_tipo_consulta option:selected").text(),
                                    motivo: ui.find("#txt_motivo_consulta").val()
                                }).onSuccess(function (id_consulta) {
                                    alertify.success("Consulta enviada con éxito");
                                    vex.close();
                                }).onError(function (id_consulta) {
                                    alertify.error("Error al enviar consulta");
                                });
                            });
                            return ui;
                        },
                        css: {
                            'padding-top': "4%",
                            'padding-bottom': "0%"
                        },
                        contentCSS: {
                            width: "80%",
                            height: "80%"
                        }
                    });

                });
            });
        });
    });


</script>
</html>
