<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consultas.aspx.cs" Inherits="Portal_Consultas" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>

        <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortalSecciones.css" />
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:30px; "></h1>
        <div style="text-align:center;" class="caja_izq no-print"></div>
         <div  class="caja_der papel" style="width:35%;">
         <input id="btn_nueva_consulta" type="button" class="btn btn-primary" style="margin:10px" value="Realizar nueva consulta" />  
               <div id="tablaConsultas" class="table table-striped table-bordered table-condensed">  
         </div>
    </div>
    </form>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {
        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm");

        Backend.start(function () {
            Legajo.getConsultas();

        });

    });


</script> 
</html>
