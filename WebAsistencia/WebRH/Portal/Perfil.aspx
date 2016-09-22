<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Portal_Perfil" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Perfil Profesional</title>
     <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>
        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortalSecciones.css" />

    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:30px; "></h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq"></div>

            <div class="caja_der papel">
            <p class="mensaje_cambio_datos" >Si alguno de los datos que está viendo no es correcto o hubiera que actualizar, por favor envíe un mail a <a href="mailto:xxx@example.com" target="_blank">xxx@example.com</a> </p>
            <legend style="margin-top: 20px;">PERFIL PROFESIONAL</legend>
                <div class="cajitas">
                   <p class=""><label class="item_cajita">Sector: </label><span id="txt_sector"></span></p>
                    <p class=""><label class="item_cajita">Nivel y Grado: </label><span id="txt_nivel_grado"></span></p>
                </div>
                 <div class="cajitas">
                    <p><label  class="item_cajita">Planta: </label><span id="txt_planta"></span></p>
                    <p class=""><label class="item_cajita">Agrupamiento: </label><span id="txt_agrupamiento"></span></p>
                </div>
                <div class="cajitas">
                    <p class=""><label class="item_cajita">Ingreso: </label><span id="txt_ingreso"></span></p>
                 </div>

                <legend style="margin-top: 20px;">DESIGNACIONES</legend>
                    <div id="tablaDesignaciones" class="table table-striped table-bordered table-condensed"> 
                    </div>
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
            Legajo.GetDatosDesignaciones();
        });
        
    });

</script> 
</html>
