<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GraficoDotacion.aspx.cs"
    Inherits="Reportes_GraficoDotacion" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="GraficoDotacion.js"></script>
    <link rel="stylesheet" type="text/css" href="Reportes.css" />
    <link rel="stylesheet" type="text/css" href="../Estilos/component.css" />
</head>
<body>
    <form id="GraficoDotacion" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <br />
    <div style="display: flex;">
        <div id="div_datos" style="width: 40%; min-width: 10%; float: left;">
            <div id="div_filtros" style="margin-left: 10px;">
                <p>
                    Filtros</p>
                    <input id="btn_armarGrafico" type="button" class="btn btn-primary" style="float: right;
                    margin: 7px 189px 0px 0px;" value="Graficar" />
                <div class="grupo_campos nueva_linea">
                    <label>
                        Fecha</label>
                    <input id="txt_fecha_desde" type="text" style="width: 100px; margin: 5px 10px 5px 10px;" />
                </div>
                <label>
                    Gráfico</label>
                <div class="ac-custom ac-checkbox ac-cross" autocomplete="off" style="margin-left:20px;">
                    <section>
				
					<ul>
						<li><input id="cb1" name="cb1" type="checkbox"/><label for="cb1">Género</label></li>
						<li><input id="cb2" name="cb2" type="checkbox"/><label for="cb2">Nivel</label></li>
						<li><input id="cb3" name="cb3" type="checkbox"/><label for="cb3">Estudios</label></li>
						<li><input id="cb4" name="cb4" type="checkbox"/><label for="cb4">Plantas</label></li>
						<li><input id="cb5" name="cb5" type="checkbox"/><label for="cb5">Afiliación Gremial</label></li>
					</ul>
		
			</section>
                </div>
                <div class="grupo_campos nueva_linea">
                    <label>
                        Área</label>
                    <input id="id_airea" type="text" style="width: 100px; margin: 5px 10px 5px 18px;" />
                </div>
            </div>
            <br />
        </div>
        <div id="div_grafico" style="width: 55%;">
            <div id="container_grafico_torta_totales" style="min-width: 210px; height: 400px;
                margin: 0 auto">
            </div>
            <div id="div_tablas" style="display:flex;">
            <div id="div_tabla_resultado_totales" style="min-width: 210px; height: 400px; margin: 0 auto">
                <input type="text" id="search" class="search" class="buscador" placeholder="Buscar"
                    style="display: none;" />
               <%-- <a href="#" id="exportar_datos" class="btn btn-info" style="float: right; display: none">
                    Exportar Datos</a>--%>
                <table id="tabla_resultado_totales" style="width: 220px;">
                </table>
            </div>
            <div id="div_tabla_detalle" style="margin-top: 39px;">
                <table id="tabla_detalle" style="width: 400px;">
                </table>
            </div>
            </div>
        </div>
    </div>
    </form>
</body>
<script src="../Scripts/Graficos/highcharts.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/highcharts-3d.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/data.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/exporting.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/svgcheckbx.js" type="text/javascript"></script>
<script type="text/javascript">
   
    Backend.start();
    $(document).ready(function () {
       
        GraficoDotacion.Inicializar();
    });
</script>
</html>
