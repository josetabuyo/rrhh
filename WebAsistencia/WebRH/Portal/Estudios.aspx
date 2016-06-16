<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Estudios.aspx.cs" Inherits="Portal_Estudios" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Portal Estudios</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width" />
        <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>

    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div>
    <h1 style="text-align:center;">Estudios</h1>
    <p>Estudios cargados en su legajo:</p>

    <div id="listadoEstudios">
    
    </div>

    <div style="display:none;" class="cajaEstudio">
        <p>Nivel:<span class="nivel"></span> </p>
        <p>Titulo:<span class="titulo"></span> </p>
        <p>Fecha Egreso:<span class="fecha"></span> </p>
    </div>
    
    </div>
    </form>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {


        Backend.start(function () {
            Legajo.getEstudios();
        });


        
    });

    
</script> 
</html>
