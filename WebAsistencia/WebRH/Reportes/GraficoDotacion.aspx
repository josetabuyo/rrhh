<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GraficoDotacion.aspx.cs"
    Inherits="Reportes_GraficoDotacion" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="Reportes.css" />
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="GraficoDotacion.js"></script>
</head>
<body>
    <form id="GraficoDotacion" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <br />
    <div style="display: flex;">
        <div id="div_datos" style="width: 40%; min-width: 10%; float: left;">
            <div id="div_filtros">
                <p>
                    Filtros</p>
                <div>
                    <label>
                        Tipo de Gráfico</label>
                    <select>
                        <option id="0">Torta</option>
                    </select>
                </div>
                <div style="display: flex;">
                    <div>
                        <label>
                            Fecha Desde</label>
                        <input id="txt_fecha_desde" type="text" style="width: 50px; margin: 5px 10px 5px 10px;" />
                    </div>
                    <div>
                        <label>
                            Fecha Hasta</label>
                        <input id="txt_fecha_hasta" type="text" style="width: 50px; margin: 5px 10px 5px 10px;" />
                    </div>
                </div>
                <input id="btn_armarGrafico" type="button" class="btn btn-primary" style="float: right;
                    margin-right: 50px;" value="Graficar" />
            </div>
            <div id="div_tabla_detalle">
             <table id="tabla_detalle" style="width: 400px;">
            </table>
            </div>
            <br />
        </div>
        <div id="div_grafico" style="width: 55%;">
            <div id="container_grafico_torta_totales" style="min-width: 210px; height: 400px;
                margin: 0 auto">
            </div>
            <div id="div_tabla_resultado_totales" style="min-width: 210px; height: 400px; margin: 0 auto">
               <%-- <label>
                    Datos del Gráfico</label>--%>
                <input type="text" id="search" class="search" class="buscador" placeholder="Buscar" style="display:none;" />
                <a href="#" id="exportar_datos" class="btn btn-info" style="float: right; display: none">
                    Exportar Datos</a>
                    <table id="tabla_resultado_totales" style="width: 400px;">
            </table>
            </div>
            
        </div>
    </div>
    </form>
</body>
<script src="../Scripts/Graficos/highcharts.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/highcharts-3d.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/data.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/exporting.js" type="text/javascript"></script>
<script type="text/javascript">
    Backend.start();
    $(document).ready(function () {
        var personas = [];
        GraficoDotacion.Inicializar();
    });
</script>
</html>
