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
    <link href="../Estilos/default.css" rel="stylesheet" type="text/css" />
</head>
<body class="cbp-spmenu-push">
    <form id="GraficoDotacion" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <br />
    <div style="display: flex;">
        <div id="div_opciones_y_organigrama" style="width: 25%;">
            <div id="div_menu_grafico">
                <nav class="cbp-spmenu cbp-spmenu-horizontal cbp-spmenu-top" id="cbp-spmenu-s3">
			    <h3 id="btn_salir_menu" style="cursor: pointer;">Gráficos <p style="font-size: initial; margin-left: 34px;">(salir)</p></h3>
			    <a href="#">Dotación</a>
			    <a href="#">Recibo de Sueldo</a>
			    <a href="#">Licencias</a>
			    <a href="#">Otros</a>
			    <a href="#">Rango Etáreo</a>
			    <a href="#">Horas Extras</a>
		    </nav>
                <div class="container">
                    <div class="main">
                        <section style="float: left; margin-left: -61px;">					
					<input id="showTop" type="button" class="btn btn-primary" style="margin-bottom:10px;" value="Consultar otros Gráficos"/>
                     <input id="btn_consulta_individual" type="button" class="btn btn-primary" value="consulta Individual" />
				</section>
                    </div>
                </div>
            </div>
            <div id="div_organigrama" style="margin-left: 25px; margin-top: 15px;">
                <h2>
                    Organigrama</h2>
            </div>
        </div>
        <div id="div_filtros_graficos_y_tablas" style="float: right; width: 70%">
            <div id="div_filtros" style="margin-left: 10px; display: flex;">
                <h3>
                    Filtros</h3>
                <div style="margin-left: 20px;">
                    <div class="grupo_campos" style="margin-bottom: 9px;">
                        <label>
                            Fecha</label>
                        <input id="txt_fecha_desde" type="text" style="width: 100px; margin: 5px 10px 5px 46px;" />
                        <input id="btn_armarGrafico" type="button" class="btn btn-primary" style="float: right;
                            margin: 7px 314px 0px 0px;" value="Graficar" />
                    </div>
                    <div class="grupo_campos nueva_linea">
                        <label>
                            Información</label>
                        <div class="ac-custom ac-checkbox ac-cross" autocomplete="off" style="margin-left: 20px;">
                            <section>
					<ul style="display:flex; margin:-21px 0px 0px 11px">
						<li><input id="cb1" name="cb1" type="checkbox"/><label for="cb1">Género</label></li>
						<li><input id="cb2" name="cb2" type="checkbox"/><label for="cb2">Nivel</label></li>
						<li><input id="cb3" name="cb3" type="checkbox"/><label for="cb3">Estudios</label></li>
						<li><input id="cb4" name="cb4" type="checkbox"/><label for="cb4">Plantas</label></li>
						<li><input id="cb5" name="cb5" type="checkbox"/><label for="cb5">Afiliación Gremial</label></li>
					</ul>
		
			</section>
                        </div>
                    </div>
                </div>
            </div>
            <div id="div_grafico_y_tabla_resumen" style="display: flex; width: 100%;">
                <div id="container_grafico_torta_totales" style="width: 60%; height: 400px;">
                </div>
                <div id="div_tabla_resultado_totales" style="min-width: 210px; height: 400px; margin: 0 auto">
                    <input type="text" id="search" class="search" class="buscador" placeholder="Buscar"
                        style="display: none;" />
                    <%-- <a href="#" id="exportar_datos" class="btn btn-info" style="float: right; display: none">
                    Exportar Datos</a>--%>
                    <table id="tabla_resultado_totales" style="width: 420px;">
                    </table>
                </div>
            </div>
            <div id="div_tabla_detalle" style="margin-top: 39px;">
                <table id="tabla_detalle" style="width: 400px;">
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
<script src="../Scripts/Graficos/svgcheckbx.js" type="text/javascript"></script>
<script src="../Scripts/Graficos/classie.js" type="text/javascript"></script>
<script type="text/javascript">
    var 
				menuTop = document.getElementById('cbp-spmenu-s3'),
				showTop = document.getElementById('showTop'),
				body = document.body;

    showTop.onclick = function () {
        classie.toggle(this, 'active');
        classie.toggle(menuTop, 'cbp-spmenu-open');
        disableOther('showTop');
    };

    function disableOther(button) {
        if (button !== 'showTop') {
            classie.toggle(showTop, 'disabled');
        }
    }
</script>
<script type="text/javascript">

    Backend.start();
    $(document).ready(function () {

        GraficoDotacion.Inicializar();
    });
</script>
</html>
