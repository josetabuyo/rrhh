<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionDeTareas.aspx.cs" Inherits="Portal_GestionDeTareas" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 30px;">
        </h1>
        <div style="text-align: center;" class="caja_izq no-print">
            <p style="margin: 25px; font-size: 2.1em; color: #fff;">
                Menú</p>
            <input id="btn_consultas_pendientes" type="button" class="btn_gestion_consulta" style="margin: 10px;
                width: 170px; font-size: smaller;color:#000" value="TAREAS PENDIENTES" />

        </div>
        <div class="caja_der papel">
            <%--DIV 1--%>
            <div id="consultas">
                <legend id="legend_gestion" style="margin-top: 10px;">TAREAS PENDIENTES</legend>
                <input type="text" id="search" class="search buscador" placeholder="Buscar"
                    style="display: none; height:35px;" />
                <div id="tablaTareas" class="table table-striped table-bordered table-condensed">
                </div>
                
            
        </div>
    </div>
    </form>
    
    <div id="pantalla_detalle_alerta" style="display: none;">
       
           
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
        Backend.start(function () {
            Legajo.getTareasParaGestion();
        });

        

    });


</script>
</html>
