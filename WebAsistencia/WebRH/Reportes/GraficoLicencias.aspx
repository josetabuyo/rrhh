<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GraficoLicencias.aspx.cs"
    Inherits="Reportes_GraficoLicencias" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="Reportes.css" />
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="GraficoLicencias.js"></script>
</head>
<body>
    <form id="Reportes" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <br />
    <div style="display: flex;">
        <div id="div_datos" style="width: 40%; min-width: 10%; float: left;">
            <div id="div_filtros">
                <p>
                    Filtros</p>
                <label>
                    Tipo de Gráfico</label>
                <select>
                    <option id="0">Pendientes de Aprobación</option>
                </select>
                <button id="btn_armarGrafico" class"btn btn-primary">Graficar</button>
            </div>
            <br />
            <div id="div_tabla_resultado">
                <table id="datatable" style="display:none;">
                    <thead>
                        <tr>
                            <th>
                            </th>
                            <th>
                                Pendientes de Aprobación
                            </th>
                            <th>
                                Aprobadas por RRHH
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th>
                                Dirección General de Recursos Humanos y Organización
                            </th>
                            <td>
                                3
                            </td>
                            <td>
                                4
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Subsecretaría de Recursos Deportivos
                            </th>
                            <td>
                                2
                            </td>
                            <td>
                                0
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Coordinación de Desarrollo de Capacidades
                            </th>
                            <td>
                                5
                            </td>
                            <td>
                                9
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Unidad Ministro
                            </th>
                            <td>
                                1
                            </td>
                            <td>
                                1
                            </td>
                        </tr>
                        <tr>
                            <th>
                                Subsecretaría de Recursos Deportivos
                            </th>
                            <td>
                                2
                            </td>
                            <td>
                                4
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div id="div_grafico" style="width: 55%;">
            <div id="container" style="min-width: 210px; height: 400px; margin: 0 auto">
            </div>
        </div>
    </div>
    </form>
</body>
<script src="../Scripts/Graficos/highcharts.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/data.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/exporting.js" type="text/javascript"></script>
<script type="text/javascript">
    Backend.start();
    $(document).ready(function () {
        GraficoLicencias.Inicializar();
    });
</script>
</html>
