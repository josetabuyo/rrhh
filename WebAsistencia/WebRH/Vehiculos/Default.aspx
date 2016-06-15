<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Vehiculos_Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">


<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title> Consulta Vehicular</title>
    <link rel="stylesheet" href="css/ConsultaVehicular.css" type="text/css"/>
    <link rel="stylesheet" href="css/DetalleVehiculo.css" type="text/css"/>
    <%= Referencias.Css("../")%>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    <link rel="stylesheet" href="css/animate.css">
    <link rel="stylesheet" href="css/bootstrap-responsive.css">
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css">
</head>
<body class="body-detalle">
    <form id="form1" runat="server">
     
         <div id="contenedor_imagen">
                <div id="barra_menu_contenedor_imagen">
                    <img src="../Imagenes/BarraMenu/encabezado_sin_logos.png" id="encabezado_sin_logo"
                        alt="logosistema" />
                    <img src="../Imagenes/logo_sistema.png" id="img_logo_sistema" alt="logosistema" />
                    <img src="../Imagenes/logo_ministerio.png" id="img_logo_minis" alt="logosistema" />
                    <img src="../Imagenes/logo_direccion.png" id="img_logo_direccion" alt="logosistema" />
            
            
                    <div id="barra_menu_nombre_sistema">
                        <span id="titulo-del-menu"></span>
                        <br>
                        <span id="titulo-del-menu">Consulta<br>de<br> Vigencia </span>
                    </div>
                </div>
        <div id="barra-azul">
    
        </div>

         <div id="Contenido">
            <div id="contenedor_controles">
                <input type=text id=txt_codigo_verificacion />
                <input type=button id=btn_verificar value="Verificar"/>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
    </form>
</body>
    <%= Referencias.Javascript("../")%>    

    <script type="text/javascript">
        $(document).ready(function () {
            Backend.start(function () {
                $("#btn_verificar").click(function () {
                    window.location = "DetalleVehiculo.aspx?" + $("#txt_codigo_verificacion").val();
                });
            });
        });
    </script>   
</html>