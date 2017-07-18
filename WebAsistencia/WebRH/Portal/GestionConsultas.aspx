<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionConsultas.aspx.cs"
    Inherits="Portal_GestionConsultas" ValidateRequest="false" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/ConsultaIndividual.ascx" TagName="Consulta" TagPrefix="uc3" %>
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
    <script type="text/javascript" src="editor.js"></script>
    <script type="text/javascript" src="ckeditor/ckeditor.js"></script>
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="../Reportes/Reportes.css" />
    <link rel="stylesheet" type="text/css" href="estilosPortalSecciones.css" />
    <link rel="stylesheet" href="estrellas.css">
    <link rel="stylesheet" href="chat.css" />
    <link rel="stylesheet" href="font-awesome.min.css" />
    <link rel="stylesheet" href="lato.css" />
    <script type="text/javascript" src="../Scripts/select2.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Scripts/select2.min.css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 17px;">
        </h1>
        <div style="text-align: center;" class="caja_izq no-print">
            <p style="margin: 25px; font-size: 2.1em; color: #fff;">
                Menú</p>
            <input id="btn_consultas_pendientes" type="button" class="btn_gestion_consulta" style="margin: 10px;
                width: 170px; font-size: smaller; color: #000" value="CONSULTAS PENDIENTES" />
            <input id="btn_consultas_historicas" type="button" class="btn_gestion_consulta" style="margin: 10px;
                width: 170px; font-size: smaller; color: #000" value="CONSULTAS HISTORICAS" />
            <input id="btn_notificaciones_creacion" type="button" class="btn_gestion_consulta"
                style="margin: 10px; width: 170px; font-size: smaller; color: #000" value="CREAR NOTIFICACIONES" />
            <input id="btn_notificaciones_historicas" type="button" class="btn_gestion_consulta"
                style="margin: 10px; width: 170px; font-size: smaller; color: #000" value="NOTIFICACIONES ENVIADAS" />
            <%-- <input id="Button3" type="button" class="btn_gestion_consulta" style="margin: 10px; width: 150px; font-size: smaller;"
                value="PARAMETRIA" />
            <input id="Button4" type="button" class="btn_gestion_consulta" style="margin: 10px; width: 150px; font-size: smaller;"
                value="REPORTES" />--%>
            <input id="Button1" type="button" onclick="javascript:location.href='Consultas.aspx'"
                class="btn_gestion_consulta" style="margin: 10px; width: 170px; font-size: smaller;
                color: #000" value="PORTAL" />
        </div>
        <div class="caja_der papel">
            <%--DIV 1--%>
            <div id="consultas">
                <legend id="legend_gestion" style="margin-top: 10px;">CONSULTAS PENDIENTES</legend>
                <input type="text" id="search" class="search buscador" placeholder="Buscar" style="display: none;
                    height: 35px;" />
                <div id="tablaConsultas" class="table table-striped table-bordered table-condensed">
                </div>
                <div id="div_detalle_consulta" style="display: none;">
                    <label style="margin-right: 20px;">
                        ID:</label><input type="text" id="txt_nro_consulta" readonly style="width: 50px;" />
                    <label style="margin-right: 20px;">
                        Creador:</label><input type="text" id="txt_creador" readonly style="width: 250px;" /><input
                            type="hidden" id="nroDocumentoCreador" />
                    <a id="btnConsultaIndividual" href="#" style="display: inline;">
                        <img src="../Imagenes/detalle.png" width="25px" height="25px" style="vertical-align: top;" /></a>
                    <label style="margin-right: 20px; margin-left: 20px;">
                        Tipo de Consulta:</label><input type="text" id="txt_tipo" readonly style="width: 150px;" />
                    <br />
                    <label style="margin-right: 24px;">
                        Motivo:</label>
                    <textarea id="ta_motivo" style="width: 100%; height: 150px;" readonly></textarea>
                    <br />
                    <br />
                    <label>
                        Respuesta:</label>
                    <textarea id="ta_respuesta" style="width: 100%; height: 150px;"></textarea>
                    <div style="text-align: center;">
                        <input id="btn_responder_consulta" type="button" class="btn btn-primary" style="margin: 10px;
                            width: 100px;" value="Responder" />
                        <input id="btn_volver_consulta" type="button" class="btn btn-primary" style="margin: 10px;
                            width: 100px;" value="Volver" />
                    </div>
                </div>
            </div>
            <div id="notificaciones">
                <div id="div_crear_nofificacion">
                    <label>
                        Documentos separados por ";"</label>
                    <input id="input_documentos" style="width: 100%;" />
                    <label>
                        Título</label>
                    <input id="input_titulo" style="width: 100%;" />
                    <br />
                    <textarea name="editor1" id="editor1" rows="10" cols="80"> </textarea>
                    <br />
                    <button id="boton_grabar_notificacion" class="btn ">
                        Grabar</button>
                    <input id="boton_vista_previa" type="button" class="btn btn-primary" style="margin: 10px;
                        width: 100px;" value="Vista Previa" />
                </div>
                <div id="div_notificaciones_enviadas">
                    <div id="tableNotificaciones" class="table table-striped table-bordered table-condensed">
                    </div>
                    <div id="tableNotificacionesUsuarios" class="table table-striped table-bordered table-condensed">
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
    <div id="pantalla_consulta_ticket" style="display: none;">
        <div>
            Clasificar:
            <select id="selector_clasificar">
            </select>
            Asignar:
            <select class="js-example-basic-single" style="width: 500px;">
                <option value="AL"></option>
                <option value="AL">Belén Cevey</option>
                <option value="WY">Lautaro Villar</option>
            </select>
            <div style="display: flex; margin-left: 35%;">
                <h3 id="titulo_consulta" style="text-align: center;">
                    CONSULTA NÚMERO.</h3>
                <img id="btn_info_usuario" src="../Imagenes/detalle.png" style="width: 20px; height: 20px;
                    margin-left: 15px; cursor: pointer;" draggable="false"></div>
            <div id="div_chat" style="height: 310px; margin-top: -10px; overflow: scroll; overflow-x: hidden;">
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
            <div style="text-align: center;">
                <input id="btn_pepreguntar" type="button" class="btn btn-primary" value="Responder" />
            </div>
        </div>
        <div id="pantalla_consulta_individual" style="display: none">
            <p style="font-size: xx-large; text-align: center; margin-top: 10px;">
                Consulta Individual</p>
            <br />
            <uc3:Consulta ID="Consulta1" runat="server" />
        </div>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript">
    $(document).ready(function ($) {
        $(".js-example-basic-single").select2();
        Backend.start(function () {
            Legajo.getConsultasParaGestion();
        });

        $("#btnConsultaIndividual").click(function () {

            vex.defaultOptions.className = 'vex-theme-os';
            vex.open({
                afterOpen: function ($vexContent) {
                    var ui = $("#pantalla_consulta_individual").clone();
                    $vexContent.append(ui);
                    ui.show();
                    Legajo.getConsultaIndividual($('#nroDocumentoCreador').val(), ui);
                    return ui;
                },
                css: {
                    'padding-top': "4%",
                    'padding-bottom': "0%"
                },
                contentCSS: {
                    width: "80%",
                    height: "830px"
                }
            });

        });

    });


</script>
</html>
