<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comites.aspx.cs" Inherits="FormularioConcursar_Comites" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    	<div class="contenedor_concursar" >
            <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />
            <h2>COMITE</h2>
            <span id="comite"></span>

        </div>
    </form>
    <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="../Scripts/Repositorio.js" ></script>
    <script type="text/javascript" src="Comite.js" ></script>
</body>
<script type="text/javascript">
    $(document).ready(function () {
        
        Comite.mostrarComite();

    });

</script>
</html>
