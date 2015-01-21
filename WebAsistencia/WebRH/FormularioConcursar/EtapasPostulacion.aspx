<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EtapasPostulacion.aspx.cs" Inherits="FormularioConcursar_Inscripcion" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar" TagPrefix="uc3" %>
<%@ Register Src="~/FormularioConcursar/Pasos.ascx" TagName="Pasos" TagPrefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cambio de Etapas de Postulaciones</title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />

</head>
<body>
    <form id="form1" runat="server" class="cmxform">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar" >
    
    <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />
        <div id="div_cambio_etapas" class="fondo_form" style="padding: 10px;">
            <h2>Cambio de Etapa de Postulaciones</h2>
            <div>
                <div style="display:inline-block; margin-left:30px; width: 50%; vertical-align:middle;">
                    <label for="txt_codigo_postulacion">Postulación:&nbsp;</label>
                    <input type="text" id="txt_codigo_postulacion" style="margin-bottom: 0px;" data-validar="esNoBlanco" />
                    <input type="button" id="btn_buscar_etapas" value="Buscar" class="btn" />
                    <p style="font-size:smaller;">(respete mayusculas y minisculas del c&oacute;digo)</p>
                </div>
                <div style="display:inline-block; margin-left:10px; max-width: 35%; vertical-align:middle;">
                    <div>Empleado:&nbsp;<span id="span_empleado"></span></div>
                    <div>Código:&nbsp;<span id="span_codigo"></span></div>
                    <div>Fecha de Postulación:&nbsp;<span id="span_fecha"></span></div>
                    <div>Perfil:&nbsp;<span id="span_perfil"></span></div>
                </div>
            </div>
            <div id="seccion_historial" style="display:none">
                <h3>Historial</h3>
                <div style="display:block; margin-left:30px; vertical-align: middle;">
                    <div id="div_tabla_historial"></div>
                </div>
                <div style="display:block; margin-left:30px; vertical-align: middle;">
                Cambiar a:&nbsp;
                    <select id="cmb_etapas_concurso">
                    </select>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="postulacion" runat="server" />
    </form>
</body>
 <%= Referencias.Javascript("../") %>
 <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
 <script type="text/javascript" src="../Scripts/rhforms-combos.js" ></script>
 
 <script type="text/javascript" src="EtapasPostulacion.js" ></script>
  <script type="text/javascript">
      $(document).ready(function () {

          var btn = $("#btn_buscar_etapas");
          var busqueda = $("#txt_codigo_postulacion");

          //HACIENDO EL KEYDOWN EN VEZ DEL KEY UP Y CON EL PREVENT DEFAULT EL ENTER NO ACTUALIZA TODA LA PAGINA
          busqueda.keydown(function (event) {
                if (event.which == 13) {
                    btn.click();
                    event.preventDefault();
                }
            });

          PanelEtapasPostulacion();

      });
  </script>
</html>
