<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Documentos.aspx.cs" Inherits="Portal_Estudios" %>
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

        <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortalSecciones.css" />
        
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'><br/> Estudios</span> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div>
     <div class="container-fluid">
        <h1 style="text-align:center; margin:30px; "></h1>
        <div style="margin: 0 auto;" class="row">
         <div style="text-align:right; margin-right:20%"><a href="Consultas.aspx">Realizar/Visualizar Consultas</a></div>
            <div style="text-align:center;" class="caja_izq"></div>
            <div class="caja_der papel">   
                <legend style="margin-top: 20px;">Documentos del Legajo</legend>
                 <div id="tabla_documentos">
                </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {

        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm", function () {
            Backend.start(function () {
                Legajo.getNombre();
                Legajo.getDocumentos();
            });
        });

    });

</script> 
</html>
