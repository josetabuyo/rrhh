<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Reportes_Reportes" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="Reportes.css" />
    <link rel="stylesheet" type="text/css" href="../Scripts/ArbolOrganigrama/ArbolOrganigrama.css" />
    <link rel="stylesheet" type="text/css" href="../Estilos/component.css" />
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="Reportes.js"></script>
    <script type="text/javascript" src="../Scripts/ArbolOrganigrama/ArbolOrganigrama.js"></script>
</head>
<body>
    <form id="Reportes" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>Reportes</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <!--<h1 style="text-align: center; font-weight:200;">Reportes</h1>-->
   
    <div>
        <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-left" style="position: relative;
            top: 0; width: 100%;" id="cbp-spmenu-s1">
            
            <div id="contenedor_arbol_organigrama">
                <h2 class="titulo_organigrama">Organigrama</h2>
            </div>
             <input id="btn_consulta_rapida" type="button" class="btn_consulta_individual" requierefuncionalidad="32" value="Consulta Individual" />
             <input type="button" class="btn_organigrama" id="showLeftPush" value="Organigrama" />
           
             <div id="menu_grafico">
                <h2 class="">Gráficos</h2>
                  <ul class="lista" >
                    <li><a href="#" id="btn_grafico_dotacion" class="link_listado">Dotación</a>
                        <ul><li class="Rango Etáreo">- <a href="#" class="link_listado">Rango Etáreo</a></li></ul>
                    </li>
                    <li class="Dotacion"><a href="#" class="link_listado">Sueldo</a></li>
                    <li id="btn_grafico_licencias" class="Licencias"><a href="#" class="link_listado">Licencias</a></li>
                     <li class="Horas Extras"><a href="#" class="link_listado">Horas Extras</a></li>
                    <li class="Otros"><a href="#" class="link_listado">Otros</a></li>
                </ul>
             </div>

             <div id="div_filtros_graficos_y_tablas" style="position: absolute; left: 650px; width: 100%;">
                <div style=" position: absolute;left: 150px; margin-top: 10px;">
                    <h2 style="font-size: 1.2em;">Área Seleccionada: <span id="titulo_area"></span></h2>
                    <h2 style="font-size: 1.2em; ">Gráfico Seleccionado: <span id="titulo_grafico"></span></h2>
                </div>
                <div id="div_filtros" style="display: flex;position: absolute; display:none; top: 80px;left: 135px;">
                    <div style="margin-left:20px;">
                    <div class="grupo_campos" style="margin-bottom: 9px;">
                        <label>
                            Fecha</label>
                        <input id="txt_fecha_desde" type="text" style="width: 100px; margin: 5px 10px 5px 46px;" />
                         <input id="btn_armarGrafico" type="button" class="btn btn-primary" style="float: right;
                    margin: 7px 314px 0px 0px;" value="Graficar" />
                    </div>
                    <div class="grupo_campos nueva_linea">
                        
                        <div class="ac-custom ac-checkbox ac-cross" autocomplete="off" style="margin-left: 20px;">
                        <section>
					    <ul style="display:flex; margin:-21px 0px 0px 11px;width: 463px;">
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

                <div id="div_graficos_y_tablas" style="display:flex; width: 100%; left: 125px; position: absolute; top: 160px;">
            <div id="div_grafico_y_tabla" style="display:flex; width: 100%; position: absolute; ">
            <div id="container_grafico_torta_totales" style="width: 40%; height: 450px; border: 1px solid;
                margin: 0 30px; display:none;">
            </div>
            <div id="div_tabla_resultado_totales" style="min-width: 210px; height: 400px; margin: 0 30px">
                    <input type="text" id="search" class="search" class="buscador" placeholder="Buscar"
                        style="display: none;" />
                     <a href="#" id="exportar_datos" class="btn btn-info" style="float: right; display: none; padding: 5px;">
                    Exportar Datos</a>
                    <table id="tabla_resultado_totales" style="width:420px;">
                    </table>
                </div>
                </div>

                
                <div id="div_tabla_detalle" style="margin: 0 30px; width: 100%; position: absolute; top: 465px;">
                    <table id="tabla_detalle" style="width: 70%;">
                    </table>
                </div>
   </div>

        </div>
             
         </nav>
    </div>
    </form>
    <div id="plantillas">
        <div class="arbol_organigrama">
        </div>
        <div class="area_en_arbol">
            <div id="area">
                <div id="btn_expandir" class="btn_apertura">
                </div>
                <div id="btn_contraer" class="btn_apertura">
                </div>
                <div id="nombre_area">
                </div>
            </div>
            <div id="areas_dependientes">
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="GraficoDotacion.js"></script>
    <script src="../Scripts/Graficos/highcharts.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/highcharts-3d.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/data.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/exporting.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/svgcheckbx.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/classie.js" type="text/javascript"></script>
    <script type="text/javascript">
        var menuLeft = document.getElementById('cbp-spmenu-s1'),
				showLeftPush = document.getElementById('showLeftPush'),
				body = document.body;

        showLeftPush.onclick = function () {
            classie.toggle(this, 'active');
            classie.toggle(body, 'cbp-spmenu-push-toright');
            classie.toggle(menuLeft, 'cbp-spmenu-open');
            //disableOther('showLeftPush');
        };

        Backend.start();
        $(document).ready(function () {

            GraficoDotacion.Inicializar();
        });
			
    </script>
</body>
</html>
