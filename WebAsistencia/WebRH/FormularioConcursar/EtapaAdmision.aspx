<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EtapaAdmision.aspx.cs" Inherits="FormularioConcursar_EtapaAdmision" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../") %>
    <link rel="stylesheet" href="EstilosPostular.css" />
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar">
        <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />
        <div id="div_admision" class="fondo_form" style="padding: 10px;">
                <h2>Selección de Admitidos y No Admitidos</h2>
            <br />
            <div>
                <div class="grupo_campos nueva_linea">
                    <div class="grupo_campos">
                        <label for="txt_comite">Comité:&nbsp;</label>
                        <input type="text" id="id_comite" style="width: 50px;" data-validar="esNumeroNatural" />
                    </div>
                    <div class="grupo_campos">
                        <label for="txt_perfil">Perfil:&nbsp;</label>
                        <select id="id_perfil" style="margin-bottom: 0px;"  disabled="disabled"> </select>
                    </div>
                </div>
                <div id="detalle_de_comite" style="display:inline-block; margin-left:10px; max-width: 35%; vertical-align:middle;">
                    <h4>Detalle del Comité Seleccionado</h4>
                    <div class="grupo_campos nueva_linea">Comité Titular:&nbsp;</div><span id="comite_titular"></span>
                    <div class="grupo_campos nueva_linea">Comité Suplente:&nbsp;</div><span id="comite_suplente"></span>
                </div>
            </div>
            <div id="contenedorTabla">
             <input type="text" id="search" class="search" class="buscador" placeholder="Buscar"/>
             <button class="btn btn-primary" id="btnExport" style="float:right;"> Exportar a Excel </button>
             <br />
             <table id="tabla_postulaciones" style="width:100%;"></table>
             <input type="button" style="display:none;" class="btn btn-primary" id="btn_generar_anexo" value="Generar Anexo" />
            </div>
       
        <%--<div id="requisitos_perfil"></div>
        <fieldset id="cuadro_perfil">
           
            <div id="detalle_perfil"></div>
        </fieldset>
        <fieldset id="cuadro_documentos">
           
            <div id="detalle_documentos"></div>
        </fieldset>
        <input type="button" style="display:none;" class="btn btn-primary" id="btn_guardar" value="Guardar" />--%>
       </div>
    </div>
    <%--<asp:HiddenField ID="postulacion" runat="server" />
    <asp:HiddenField ID="idPostulacion" runat="server" />--%>
    </form>
</body>
 <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
  <script type="text/javascript" src="../Scripts/ExportarAExcel.js" ></script>
 <script type="text/javascript" src="EtapaAdmision.js" />
<%= Referencias.Javascript("../") %>

<script type="text/javascript">
    Backend.start(function () {
        $(document).ready(function () {
            $('#search').hide();
            $('#btnExport').hide();
            var busqueda = $("#id_comite");

            //HACIENDO EL KEYDOWN EN VEZ DEL KEY UP Y CON EL PREVENT DEFAULT EL ENTER NO ACTUALIZA TODA LA PAGINA
            busqueda.keydown(function (event) {
                if (event.which == 13) {
                    PantallaEtapaDeAdmision.HabilitarBuscarComite();
                    event.preventDefault();
                }
            });

            $('#id_comite').change(function () {
                PantallaEtapaDeAdmision.HabilitarBuscarComite();
            });

            $('#id_perfil').change(function () {
                PantallaEtapaDeAdmision.FiltrarPorPerfil();
            });
            $('#btnExport').click(function () {
                ExportarAExcel.fnExcelReport(document.getElementById('tabla_postulaciones'));
            });

        });
    });

    

</script>

</html>
