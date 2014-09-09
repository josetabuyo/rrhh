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
        <div class="fondo_form" style="padding: 10px;">
            <h2>Cambio de Etapa</h2>
            <div>
                <div style="display:inline-block; margin-left:30px;">
                    <label for="txt_codigo_postulacion">Postulación:&nbsp;</label>
                    <input type="text" id="txt_codigo_postulacion" />
                    <input type="button" id="btn_buscar_etapas" value="Buscar" />
                </div>
                <div style="display:inline-block; margin-left:30px;">
                    <div>Empleado:</div>
                    <div>Código:</div>
                    <div>Fecha de Postulación:</div>
                </div>
                <div style="display:inline-block; margin-left:30px;">
                    Perfil:
                </div>
            </div>
            <div>
                <div style="display:inline-block; margin-left:30px;">
                    <h3>Historial</h3>
                </div>
                <div style="display:inline-block; margin-left:30px;">
                    <select id="cmb_etapas_concurso"></select>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="puesto" runat="server" />
    </form>
</body>
 <%= Referencias.Javascript("../") %>
 <script type="text/javascript" src="../Scripts/SuperCombo.js"></script>
  <script type="text/javascript">

      $(document).ready(function () {


          var btn_buscar_etapas = $("#btn_buscar_etapas");
          btn_buscar_etapas.click(function () {
              var codigo = $("#txt_codigo_postulacion").val();
              BuscarPostulacionesPorCodigo(codigo);

          });
          var cmb_tipo_documento = new SuperCombo({
              ui: $("#cmb_etapas_concurso"),
              nombre_repositorio: "EtapasConcurso"
          });

      });


      var BuscarPostulacionesPorCodigo = function (codigo) {
          var proveedor_ajax = new ProveedorAjax();
          proveedor_ajax.postearAUrl({
              url: "GetPostulacionesPorCodigo",
              data: { "codigo": codigo },
              success: function (respuesta) {
                  alertify.alert(JSON.stringify(respuesta));
              },
              error: function (XMLHttpRequest, textStatus, errorThrown) {
                  alertify.alert("Error.");
              }
          });
      }

      var BuscarEtapasConcurso = function () {
          var proveedor_ajax = new ProveedorAjax();
          proveedor_ajax.postearAUrl({
              url: "GetEtapasConcurso",
              success: function (respuesta) {
                  alertify.alert(JSON.stringify(respuesta));
              },
              error: function (XMLHttpRequest, textStatus, errorThrown) {
                  alertify.alert("Error.");
              }
          });
      }
  </script>
</html>
