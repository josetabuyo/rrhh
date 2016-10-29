<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionConsultas.aspx.cs"
    Inherits="Portal_GestionConsultas" %>

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
            <input id="Button1" type="button" class="btn btn-primary" style="margin: 10px; width: 150px;"
                value="Consultas pendientes" />
            <input id="Button2" type="button" class="btn btn-primary" style="margin: 10px; width: 150px;"
                value="Consultas históricas" />
            <input id="Button3" type="button" class="btn btn-primary" style="margin: 10px; width: 150px;"
                value="Parametría" />
            <input id="Button4" type="button" class="btn btn-primary" style="margin: 10px; width: 150px;"
                value="Reportes" />
        </div>
        <div class="caja_der papel">
            <%--DIV 1--%>
            <div id="consultas">
                <h2 id="consultas_titulo">
                    Consultas Pendientes</h2>
                <div id="tablaConsultas" class="table table-striped table-bordered table-condensed">
                </div>
                <div id="div_detalle_consulta" style="display: none;">
                    <label style="margin-right: 20px;">Creador:</label><input type="text" id="txt_creador"readonly />
                    <label style="margin-right: 20px;margin-left: 20px;">Tipo de Consulta:</label><input type="text" id="txt_tipo" readonly />
                    <br />
                    <label style="margin-right: 24px;">
                        Motivo:</label>
                    <textarea id="ta_motivo" style="width: 100%; height: 150px;" readonly></textarea>
                    <br />
                    <br />
                    <label>
                        Respuesta:</label>
                    <textarea id="ta_respuesta" style="width: 100%; height: 150px;"></textarea>
                     <div style="text-align:center;">
                     <input id="Button5" type="button" class="btn btn-primary" style="margin: 10px; width: 100px;"
                value="Responder" />
                <input id="btn_volver_consulta" type="button" class="btn btn-primary" style="margin: 10px; width: 100px;"
                value="Volver" />
                </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript">

    $(document).ready(function ($) {
        Backend.start(function () {
            Legajo.getConsultasTodas();
        });
    });


</script>
</html>
