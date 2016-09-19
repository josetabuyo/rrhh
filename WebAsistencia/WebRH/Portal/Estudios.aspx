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

        <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortalSecciones.css" />
        <style>
        .cajaEstudioOculta 
        {
            display:none;
        }

        .caja_estudio_posta 
        {
            margin: 10px;
            border-bottom: 1px solid;
            background: rgba(25, 75, 180, 0.05);
            padding: 10px;
            /*display: inline-block;*/
            border-radius: 20px;
            max-width:500px;

        }
        
        .div_dentro_de_caja_estudio 
        {
            vertical-align:middle;
            display:inline-block;
            width: 90%;
        }
        
        .img_caja_estudio 
        {
            float: left;
            width:50px;
            height:50px;
        }
        
        </style>

    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'><br/> Estudios</span> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div>
     <div class="container-fluid">
        <h1 style="text-align:center; margin:30px; "></h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq"></div>

            <div class="caja_der papel">
            <p class="mensaje_cambio_datos" >Si alguno de los datos que está viendo no es correcto o hubiera que actualizar, por favor envíe un mail a <a href="mailto:xxx@example.com" target="_blank">xxx@example.com</a> </p>
            <%--<legend style="margin-top: 20px;">Estudios</legend>
            <p>Estudios cargados en el sistema (ordenados por más actual):</p>
            --%>
           
               
                <legend style="margin-top: 20px;">ESTUDIOS</legend>

                 <div id="tabla">
    
                </div>
                 
                </div>
               
            </div>
        </div>
   

    
    
    
    <div class="cajaEstudioOculta">
            <img src="../Imagenes/diploma.png" class="img_caja_estudio" alt="diploma" />
            <div class="div_dentro_de_caja_estudio" >
                <p><span class="titulo"></span> (<span class="nivel"></span>)</p>
                <p>Fecha Egreso: <span class="fecha"></span> </p>
            </div>
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
            Legajo.getEstudios();
        });

    });

</script> 
</html>
