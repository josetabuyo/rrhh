<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EtapasPostulacion.aspx.cs" Inherits="FormularioConcursar_Inscripcion" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar" TagPrefix="uc3" %>
<%@ Register Src="~/FormularioConcursar/Pasos.ascx" TagName="Pasos" TagPrefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />

</head>
<body>
    <form id="form1" runat="server" class="cmxform">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar" >
        <div id="div_cambio_etapas" class="fondo_form" style="padding: 10px;">
            <h2>Cambio de Etapa</h2>
            <div>
                <div style="display:inline-block; margin-left:30px; width: 60%">
                    <label for="txt_codigo_postulacion">Postulación:&nbsp;</label>
                    <input type="text" id="txt_codigo_postulacion" />
                    <input type="button" id="btn_buscar_etapas" value="Buscar" />
                </div>
                <div style="display:inline-block; margin-left:30px;">
                    <div>Empleado:&nbsp;<span id="span_empleado"></span></div>
                    <div>Código:&nbsp;<span id="span_codigo"></span></div>
                    <div>Fecha de Postulación:&nbsp;<span id="span_fecha"></span></div>
                    <div>Perfil:&nbsp;<span id="span_perfil"></span></div>
                </div>
            </div>
            <div id="seccion_historial" style="display:none">
                <h3>Historial</h3>
                <div style="display:block; margin-left:30px; min-width: 60%; vertical-align: middle;">
                    <div id="div_tabla_historial"></div>
                </div>
                <div style="display:block; margin-left:30px; vertical-align: middle;">
                    <select id="cmb_etapas_concurso" dataProvider="EtapasConcurso" modelo="Etapa">
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
          PanelEtapasPostulacion();
      });
  </script>
</html>
