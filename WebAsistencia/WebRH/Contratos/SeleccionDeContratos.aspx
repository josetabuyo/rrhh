<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeleccionDeContratos.aspx.cs" Inherits="Contratos_SeleccionDeContratos" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contratos</title>
     <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Reportes/Reportes.css" />
    <link rel="stylesheet" type="text/css" href="../Scripts/ArbolOrganigrama/ArbolOrganigrama.css" />
    <link rel="stylesheet" type="text/css" href="../Estilos/component.css" />
    <link rel="stylesheet" type="text/css" href="../estilos/SelectorDeAreas.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/select2-3.4.4/select2.css" />
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>

    <script type="text/javascript" src="../Scripts/ArbolOrganigrama/ArbolOrganigrama.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>Contratos</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div>
     <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-left" style="position: relative;
            top: 0; width: 100%;" id="cbp-spmenu-s1">
            <div id="contenedor_arbol_organigrama"> 

            </div>
           
            <input type="button" class="btn_organigrama" id="showLeftPush" value="Organigrama" />
            

            <div id="div_filtros_graficos_y_tablas" style="position: absolute; left: 650px; width: 100%;">
                <div style=" position: absolute;left: 150px; margin-top: 10px;">
                    <h2 style="font-size: 1.1em;">Área Seleccionada: 
                        <span id="titulo_area">Seleccionar Área</span>
                        <input id="chk_incluir_dependencias" style="display:none; margin: 0px 5px 0px 5px;" class="regular-checkbox" type="checkbox"/><label id="lbl_incluir_dependencias" style="display:none" for="chk_incluir_dependencias">Incluir dependencias</label>
                    </h2>
                   
                </div>
 <%--GRAFICO DE DOTACIÓN--%>
                <div id="div_grafico_de_dotacion" style="display:none">
                   <%-- <div id="div_filtros" style="display: flex;position: absolute; display:none; top: 80px;left: 135px;">
                        <div style="margin-left:20px;">
                           
                            <div class="grupo_campos nueva_linea">
                                <label>Filtros:</label>
                                <div class="" autocomplete="off" style="margin-left: 50px;">
                                    <section>
					                    <ul class="lista_filtros">
						                    <li><input id="cb1" class="regular-checkbox filtros" name="cb1"  data-grafico="GraficoPorGenero" type="checkbox"/><label for="cb1">Género</label></li>
						                    <li><input id="cb2" class="regular-checkbox filtros" name="cb2"  data-grafico="GraficoPorNivel" type="checkbox"/><label for="cb2">Nivel</label></li>
						                    <li><input id="cb3" class="regular-checkbox filtros" name="cb3"  data-grafico="GraficoPorEstudio" type="checkbox"/><label for="cb3">Estudios</label></li>
						                    <li><input id="cb4" class="regular-checkbox filtros" name="cb4"  data-grafico="GraficoPorPlanta" type="checkbox"/><label for="cb4">Plantas</label></li>
                                            <li><input id="cb5" class="regular-checkbox filtros" name="cb5"  data-grafico="GraficoPorArea" type="checkbox"/><label for="cb4">Áreas</label></li>
                                            <li><input id="cb6" class="regular-checkbox filtros" name="cb6"  data-grafico="GraficoPorSecretarias" type="checkbox"/><label for="cb4">Secretarías</label></li>
                                            <li><input id="cb7" class="regular-checkbox filtros" name="cb7"  data-grafico="GraficoPorSubSecretarias" type="checkbox"/><label for="cb4">SubSecretarías</label></li>
					                    </ul>
			                        </section>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <div id="div_graficos_y_tablas" style="display:flex; width: 85%; left: 125px; position: absolute; top: 90px;">
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
                       
                    </div>

                    <div id="div_detalle_informe" style="width: 85%; left: 125px; position: absolute; top: 560px;">
                     <div id="div_tabla_informes" style="margin: 0 30px; width: 100%; ">
                            <span id="lb_titulo_tabla_informes"></span>
                            <br />
                           <%-- <input type="text" id="Text1" class="search" class="buscador" placeholder="Buscar" style="display: none;" />--%>
                           <%-- <a href="#" id="A1" class="btn btn-info" style="display: none; float: right; padding: 5px; margin-left:10px; margin-right: 70px;s"> Exportar Datos</a>--%>
                            <%--<a href="#" id="btn_generarInforme" class="btn btn-info" style="display: none; float: right; padding: 5px; margin-left:10px; "> Generar Informe</a>--%>
                          
                            <table id="tabla_informe" style="width: 95%;"> </table>
                        </div>

                        <div id="div_tabla_detalle" style="margin: 0 30px; width: 100%;">
                            <span id="lb_titulo_tabla_detalle"></span>
                            <br />
                            <input type="text" id="search_detalle" class="search" class="buscador" placeholder="Buscar" style="display: none;" />
                            <a href="#" id="btn_exportarExcelDetalle" class="btn btn-info" style="display: none; float: right; padding: 5px; margin-left:10px; margin-right: 70px;"> Exportar Datos</a>
                            <%--<a href="#" id="btn_generarInforme" class="btn btn-info" style="display: none; float: right; padding: 5px; margin-left:10px; "> Generar Informe</a>--%>
                          
                            <table id="tabla_detalle" style="width: 95%;"> </table>
                        </div>
                    </div>
                </div>
           
            </div>   
        </nav>
    </div>
    </form>
    <div id="plantillas">
        <div class="arbol_organigrama">
            <div id="buscador_de_area" class="selector_areas">
                <input id="buscador" type="hidden" class="combo_buscar_area" />
            </div>
            <div id="areas_arbol">
            </div>
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
        <div class="vista_area_en_selector">
            <div id="nombre">
            </div>
        </div>
    </div>
  <script type="text/javascript" src="../Scripts/underscore-min.js"></script>

    <script src="../Scripts/Graficos/highcharts.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/highcharts-3d.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/data.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/exporting.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/svgcheckbx.js" type="text/javascript"></script>
    <script src="../Scripts/Graficos/classie.js" type="text/javascript"></script>
    <script src="../Scripts/ExportarAExcel.js" type="text/javascript"></script>
    <script src="../Scripts/Spin.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
    <script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>
    <script type="text/javascript" src="../Scripts/Area.js"></script>
    <script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
    <script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
    <script type="text/javascript" src="GraficoContratos.js"></script>
    <script type="text/javascript" src="../Reportes/GraficoHerramientas.js"></script>

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
                GraficoHerramientas.BlanquearParametrosDeBusqueda();
                GraficoContratos.Inicializar();

                $('#btn_exportarExcelDetalle').click(function () {
                    ExportarAExcel.fnExcelReport(document.getElementById('tabla_detalle'));
                });

                $('#exportar_datos').click(function () {
                    ExportarAExcel.fnExcelReport(document.getElementById('tabla_resultado_totales'));
                });

//                $('#btn_generarInforme').click(function () {
//                    alert("informe");
//                });
            });
        });

        
    </script>
</body>
</html>
