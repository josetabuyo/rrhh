<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Vehiculos_Default" %>
<html>
<head>
    <title>Control de Vigencia</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%= Referencias.Javascript("../")%>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" href="css/Default-vehiculos.css" type="text/css" />
    <link id="link2" rel="stylesheet" href="css/DetalleVehiculo.css" type="text/css"/>
    <link rel="icon" href="../Imagenes/iconos/logoweb-favicon.png">
</head>
<body>
                <div id="fondo-Arriba">
                            </div>
                <div id="fondo-Abajo">
                            </div>


    <form id="form1" runat="server" style="height: auto;">
        <div id="contenedor_imagen">
            <div id="contenedor_encabezado_sin_logo">
                <img src="../Imagenes/BarraMenu/encabezado_sin_logos.png" id="encabezado_sin_logo" />
            </div>
            <div id="contenedor_logo_sistema">
                <img src="../Imagenes/logo_sistema.png" id="img_logo_sistema" alt="logosistema" />
                <img src="../Imagenes/logo_direccion.png" id="img_logo_direccion" alt="logosistema" />
                <img src="../Imagenes/logo_ministerio.png" id="img_logo_minis" alt="logosistema" />
            </div>
            <div id="barra_menu_nombre_sistema">
                <p id="titulo-del-menu">
                    Consulta<br>
                    de<br>
                    Vigencia</p>
            </div>
            <div id="barra-azul">
            </div>
        </div>
        <div id="Contenido">
            
                <div id="contenedor_controles">
                    <input type="text" id="txt_codigo_verificacion" />
                    <input type="button" id="btn_verificar" value="Verificar" onclick="return btn_verificar_onclick()" />
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            
        
            
        
        </div>
    </form>
</body>
<script type="text/javascript">
    $(document).ready(function () {
        Backend.start(function () {
            $("#contenedor_controles").addClass("animated slideInLeft");
            $("#btn_verificar").click(function () {
                window.location = "DetalleVehiculo.aspx?" + $("#txt_codigo_verificacion").val();
            });
        });
    });
    function btn_verificar_onclick() {

    }

</script>
</html>
