<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Vehiculos_Default" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">


<head>
  <title>Control Vehicular</title>
      <link rel="stylesheet" href="css/Default-vehiculos.css" type="text/css"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="link1" rel="stylesheet" href="css/DetalleVehiculo.css" type="text/css" />
    <link rel="stylesheet" href="css/animate.css">
<%--    <link rel="stylesheet" href="css/bootstrap-responsive.css">
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css">--%>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
</head>
<body>
<form id="form1" runat="server" style="height:auto;">
    
            <div id="contenedor_imagen">
                <div id="contenedor_encabezado_sin_logo">
                <img src="../Imagenes/BarraMenu/encabezado_sin_logos.png" id="encabezado_sin_logo" />
                </div>
        
                <div id="contenedor_logo_sistema">
                <img src="../Imagenes/logo_sistema.png" id="img_logo_sistema" alt="logosistema" />
                <img src="../Imagenes/logo_direccion.png" id="img_logo_direccion" alt="logosistema" />
                 <img src="../Imagenes/logo_ministerio.png" id="img_logo_minis" alt="logosistema" />
                </div>                

                    <div id="barra_menu_nombre_sistema2">
                        <p id="titulo-del-menu">Consulta<br>de<br>Vigencia</p>
                    </div>
            
                    <div id="barra-azul">
                    </div>
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