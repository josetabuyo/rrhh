<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PermisosActuales.aspx.cs" Inherits="Permisos_PermisosActuales" %>
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
        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        <link rel="stylesheet"  href="estilosPermisos.css" />

       
    </head>
<body>
    
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <div class="container-fluid">
            <h1 style="text-align:center; margin:17px; "></h1>
            <div style="margin: 0 auto;" class="row">
                <div style="text-align:center;" class="caja_izq"></div>
            
                <div class="caja_der papel">
            
                    <legend style="margin-top: 20px;">PERMISOS ACTUALES</legend>
                    <div id="tabla_permisos">
    
                    </div>

                     <div id="tabla_funcionalidades">
    
                    </div>

                </div>

                <a id="btn_seleccion_contratos" RequiereFuncionalidad="ingreso_seleccion_contrato" RequiereArea="2584" class="btn btn-primary">Selección de Contratos</a>
               
             </div>
        </div>
    </form>
</body>

<script type="text/javascript" src="Permisos.js"></script>
<script type="text/javascript" src="../MAU/HabilitadorDePermisos.js"></script>
<script type="text/javascript" src="../MAU/HabilitadorDeControles.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {


        Backend.start(function () {
            //para cargar el menu izquierdo 
            $(".caja_izq").load("SeccionIzquierda.htm", function () {

                Permisos.getPerfilesDelUsuario();
                Permisos.getFuncionalidadesDelUsuario();
                //HabilitadorDePermisos.comprobarPermisosEnPantalla();
            });

        });
    });

</script> 
</html>
