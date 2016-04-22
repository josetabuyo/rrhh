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
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>Reportes</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div>
        <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-left" style="position: relative; top: 0; width: 100%;" id="cbp-spmenu-s1">
            <div id="contenedor_arbol_organigrama"> </div>
            <input id="btn_consulta_rapida" type="button" class="btn_consulta_individual" requierefuncionalidad="32" value="Consulta Individual" />
            <input type="button" class="btn_organigrama" id="showLeftPush" value="Organigrama" />
            <div id="menu_grafico">
               <h2 class="">Gráficos</h2>
                 <ul class="lista" >
                   <li><a href="#" id="btn_grafico_dotacion" class="link_listado">Dotación</a>
                       <ul>
                           <li class="Rango Etáreo"><a href="#" id="btn_genero" class="link_listado">Género</a></li>
                           <li class="Rango Etáreo"><a href="#" id="btn_nivel" class="link_listado">Nivel</a></li>
                           <li class="Rango Etáreo"><a href="#" id="btn_estudios" class="link_listado">Estudios</a></li>
                           <li class="Rango Etáreo"><a href="#" id="btn_plantas" class="link_listado">Plantas</a></li>
                           <li class="Rango Etáreo"><a href="#" id="btn_areas" class="link_listado">Áreas</a></li>
                           <li class="Rango Etáreo"><a href="#" id="btn_secretarias" class="link_listado">Secretarías</a></li>
                           <li class="Rango Etáreo"><a href="#" id="btn_subsecretarias" class="link_listado">SubSecretarías</a></li>
                          <%-- <li class="Rango Etáreo"><a href="#" id="btn_rango_etareo" class="link_listado">Rango Etáreo</a></li>--%>
                       </ul>
                   </li>
                   <li class="Dotacion"><a href="#" id="btn_grafico_sueldo" class="link_listado">Sueldo</a></li>
                   <%--<li id="btn_grafico_licencias" class="Licencias"><a href="#" class="link_listado">Licencias</a></li>
                    <li class="Horas Extras"><a href="#" class="link_listado">Horas Extras</a></li>
                   <li class="Otros"><a href="#" class="link_listado">Otros</a></li>--%>
               </ul>
            </div>

            <div id="div_filtros_graficos_y_tablas" style="position: absolute; left: 650px; width: 100%;">
                <div style=" position: absolute;left: 150px; margin-top: 10px;">
                    <h2 style="font-size: 1.1em;">Área Seleccionada: 
                        <span id="titulo_area">Seleccionar Área</span>
                        <input id="chk_incluir_dependencias" style="display:none; margin: 0px 5px 0px 5px;" class="regular-checkbox" type="checkbox"/><label id="lbl_incluir_dependencias" style="display:none" for="chk_incluir_dependencias">Incluir dependencias</label>
                    </h2>
                    <h2 style="font-size: 1.1em; ">Gráfico Seleccionado: <span id="titulo_grafico">Seleccionar Informe</span></h2>
                </div>
 <%--GRAFICO DE DOTACIÓN--%>
                <div id="div_grafico_de_dotacion" style="display:none">
                    <div id="div_filtros" style="display: flex;position: absolute; display:none; top: 80px;left: 135px;">
                        <div style="margin-left:20px;">
                            <div class="grupo_campos" style="margin-bottom: 9px;">
                                <label>Fecha</label>
                                <input id="txt_fecha_desde" type="text" style="width: 100px; margin: 5px 10px 5px 46px;" />
                                <input id="btn_armarGrafico" type="button" class="btn btn-primary" value="Graficar" />
                            </div>
                            <div class="grupo_campos nueva_linea">
                                <label>Filtros:</label>
                                <!--Saque las clases para los checkbox porque eran un quilombo manipularlos 
                                ac-custom ac-checkbox ac-cross-->
                                <div class="" autocomplete="off" style="margin-left: 50px;">
                                    <section>
					                    <ul class="lista_filtros">
						                    <li><input id="cb1" class="regular-checkbox filtros" name="cb1" data-filtro="Genero" type="checkbox"/><label for="cb1">Género</label></li>
						                    <li><input id="cb2" class="regular-checkbox filtros" name="cb2" data-filtro="Nivel" type="checkbox"/><label for="cb2">Nivel</label></li>
						                    <li><input id="cb3" class="regular-checkbox filtros" name="cb3" data-filtro="Estudios" type="checkbox"/><label for="cb3">Estudios</label></li>
						                    <li><input id="cb4" class="regular-checkbox filtros" name="cb4" data-filtro="Plantas" type="checkbox"/><label for="cb4">Plantas</label></li>
                                            <li><input id="cb5" class="regular-checkbox filtros" name="cb5" data-filtro="Areas" type="checkbox"/><label for="cb4">Áreas</label></li>
                                            <li><input id="cb6" class="regular-checkbox filtros" name="cb6" data-filtro="Secretarias" type="checkbox"/><label for="cb4">Secretarías</label></li>
                                            <li><input id="cb7" class="regular-checkbox filtros" name="cb7" data-filtro="SubSecretarias" type="checkbox"/><label for="cb4">SubSecretarías</label></li>
						                    <%--<li><input id="cb5" class="regular-checkbox filtros" name="cb5" data-filtro="Afiliacion" type="checkbox"/><label for="cb5">Afiliación Gremial</label></li>--%>
					                    </ul>
			                        </section>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="div_graficos_y_tablas" style="display:flex; width: 85%; left: 125px; position: absolute; top: 160px;">
                        <div id="div_grafico_y_tabla" style="width: 100%; position: absolute; ">
                            <div id="container_grafico_torta_totales" style="width: 40%; height: 450px; border: 1px solid; margin: 0 30px; display:none;float:left;">
                            </div>
                            <div id="div_tabla_resultado_totales" style="min-width: 210px; height: 450px; margin: 0 30px;">
                                <input type="text" id="search" class="search" class="buscador" placeholder="Buscar" style="display: none;" />
                                <a href="#" id="btn_excel" class="btn btn-info" style="float: right; padding: 5px; margin-left:10px;"> Exportar Datos</a>
                                <div style="overflow-y: scroll;max-height: 420px;">
                                    <table id="tabla_resultado_totales" style="width:100%;"></table>
                                </div>
                    
                    
                            </div>
                        </div>
                        <div id="div_tabla_detalle" style="margin: 0 30px; width: 100%; position: absolute; top: 465px;">
                            <span id="lb_titulo_tabla_detalle"></span>
                            <br />
                            <input type="text" id="search_detalle" class="search" class="buscador" placeholder="Buscar" style="display: none;" />
                            <table id="tabla_detalle" style="width: 95%;"> </table>
                        </div>
                    </div>
                </div>
 <%--GRAFICO DE SUELDOS--%>
                <div id="div_resultados_sueldos" style="display:none">
                    <div id="div_filtros_sueldos" style="display:none; flex;position: absolute;top:80px;left: 135px;">
                        <div style="margin-left:20px;">
                            <div class="grupo_campos" style="margin-bottom: 9px;">
                                <label>Fecha</label>
                                <input id="txt_fecha_desde_sueldo" type="text" style="width: 100px; margin: 5px 10px 5px 46px;" />
                                <input id="btn_buscar_sueldo" type="button" class="btn btn-primary" value="Buscar" />
                            </div> 
                            <div class="grupo_campos nueva_linea">
                                <label>Agrupar por:</label>
                                <div class="" autocomplete="off" style="margin-left: 50px;">
                                    <section>
					                    <ul class="lista_filtros">
						                    <li><input id="cb_SinAgrupar" class="regular-checkbox filtros_sueldo" name="cb8" data-filtro="SinAgrupar_sueldo" type="checkbox"/><label for="cb_SinAgrupar">Sin Agrupar</label></li>
                                            <li><input id="cb_Secretarias_sueldo" class="regular-checkbox filtros_sueldo" name="cb9" data-filtro="Secretarias_sueldo" type="checkbox"/><label for="cb_Secretarias">Secretarías</label></li>
						                    <li><input id="cb_SubSecretarias_sueldo" class="regular-checkbox filtros_sueldo" name="cb0" data-filtro="Subsecretariasr_sueldo" type="checkbox"/><label for="cb_SubSecretarias">Subsecretarias</label></li>
					                    </ul>
			                        </section>
                                </div>
                            </div>                   
                        </div>
                    </div>

                    <div id="div_tabla_sueldo" style="margin: -310px 0px 0px 148px; width: 100%; position: absolute; top: 465px;">               
                        <span id="lb_titulo_tabla"></span>
                        
                        <div style="width:80%; margin: 20px 0px 10px 0px;">
                            <input type="text" id="search_sueldo" class="search" class="buscador" placeholder="Buscar" style="display: none;" />
                            <a href="#" id="exportar_datos_sueldo" class="btn btn-info" style="float: right; display: none; padding: 5px;"> Exportar Datos</a>
                        </div>
                        <table id="tabla_sueldo" style="width: 80%;"> </table>
                    </div> 
                    
                    <div id="div_tabla_sueldo_detalle" style="margin: -310px 0px 0px 148px; width: 100%; position: absolute; top: 465px; display:none;">               
                        <span id="lb_titulo_tabla_detalle"></span>
                        <br />  
                        <div style="width:80%;">
                            <input type="text" id="search_detalle_sueldo" class="search" class="buscador" placeholder="Buscar" style="display: none; margin: 0;" />
                            <input id="btn_mostrar_resumen" type="button" class="btn btn-primary" value="Volver al Resumen" style="display:none; float: right;"/>  
                        </div>
                        <table id="tabla_sueldo_detalle" style="width: 80%; margin-top: 38px;"> </table>
                    </div> 
               </div>
               <div id="div_grafico_de_rango_etareo">
                    <div id="div_filtros_rango_etareo" style="display: flex;position: absolute; display:none; top: 80px;left: 135px;">
                        <div style="margin-left:20px;">
                            <div class="grupo_campos" style="margin-bottom: 9px;">
                                <label>Fecha</label>
                                <input id="txt_fecha_desde_rango_etareo" type="text" style="width: 100px; margin: 5px 10px 5px 46px;" />
                                <input id="btn_armarGrafico_RangoEtaero" type="button" class="btn btn-primary" value="Graficar" />
                            </div>
                        </div>
                    </div>
                    <div id="container_grafico_rango_etareo" style="width: 40%; height: 450px; border: 1px solid; margin: 0 30px; display:none;">
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
    <script type="text/javascript" src="GraficoSueldos.js"></script>
    <script src="../Scripts/Graficos/highcharts.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/highcharts-3d.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/data.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/exporting.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/svgcheckbx.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/classie.js" type="text/javascript"></script>
    <script src="../Scripts/ExportarAExcel.js" type="text/javascript"></script>
    <script src="../Scripts/Spin.js" type="text/javascript"></script>
    <script type="text/javascript">

        //EFECTOS DEL MENU ORGANIGRAMA

        Backend.start(function () {
            $(document).ready(function () {
                var menuLeft = document.getElementById('cbp-spmenu-s1'),
				    showLeftPush = document.getElementById('showLeftPush'),
				    body = document.body;

                showLeftPush.onclick = function () {
                    classie.toggle(this, 'active');
                    classie.toggle(body, 'cbp-spmenu-push-toright');
                    classie.toggle(menuLeft, 'cbp-spmenu-open');
                    //disableOther('showLeftPush');
                };
                GraficoDotacion.Inicializar();
                GraficoSueldos.Inicializar();
                $('#exportar_datos_detalle').click(function () {
                    ExportarAExcel.fnExcelReport(document.getElementById('tabla_detalle'));
                });
                $('#exportar_datos_detalle_sueldo').click(function () {
                    ExportarAExcel.fnExcelReport(document.getElementById('tabla_detalle_sueldo'));
                });
                $('#exportar_datos').click(function () {
                    ExportarAExcel.fnExcelReport(document.getElementById('tabla_resultado_totales'));
                });
            });
        });

        
    </script>
</body>
</html>
