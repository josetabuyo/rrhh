<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EtapaInscripcionDocumental.aspx.cs" Inherits="FormularioConcursar_EtapaInscripcionDocumental" %>
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
        <p>Documentación necesaria para <span style="font-weight:bold;" id="nombre_perfil"></span></p>
        <fieldset>
            <legend>Documentacion Obligatoria del perfil</legend>
            <div id="detalle_foliables"></div>
        </fieldset>
    </div>
    <asp:HiddenField ID="postulacion" runat="server" />
    </form>
</body>
<script type="text/javascript" src="EtapaInscripcionDocumental.js" />
<%= Referencias.Javascript("../") %>

<script type="text/javascript">
    //Backend.start();

    $(document).ready(function () {
        var postulacion = JSON.parse($('#postulacion').val());

        EtapaInscripcionDocumental.mostrarPostulacion(postulacion);
    });

</script>

</html>
