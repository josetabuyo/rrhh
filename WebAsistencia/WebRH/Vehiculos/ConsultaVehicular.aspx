<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaVehicular.aspx.cs" Inherits="Vehiculos_Default" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title>Control Vehicular</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="link1" rel="stylesheet" href="../Vehiculos/css/ConsultaVehicular.css" type="text/css" />
    <link rel="stylesheet" href="../Vehiculos/css/animate.css">
    <link rel="stylesheet" href="../Vehiculos/css/bootstrap-responsive.css">
    <link rel="stylesheet" href="../Vehiculos/css/bootstrap-responsive.min.css">

</head>
<body>
<%--<div id="barra-azul"></div>--%>

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
    
    </div>

     

    <div id="Contenido">
    
   <div id="contenedor-imagenes">
    <div id="contenedor-vehiculos">
    <div class="div-titulos">
        <p id="titulo">
        Vehículo
        </p></div>  
    <div class="separador">
    </div>
    </div>

    <table class="tabla-principal">

        <tr>
            <td colspan="2" class="celda">
                Marca:
            </td>
            <td id="marca" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Modelo:
            </td>
            <td id="Modelo" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Segmento:
            </td>
            <td id="segmento" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Dominio:
            </td>
            <td id="dominio" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Año:
            </td>
            <td id="año" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Motor:
            </td>
            <td id="Motor" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Chasis:
            </td>
            <td id="chasis" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Asignado al sector:
            </td>
            <td id="area" colspan="2" class="celda2">
                
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Conductor:
            </td>
            <td id="responsable" colspan="2" class="celda2">
            </td>
        </tr>
    </table>
  </div>
 
    <div class="contenedor-imagen-vehiculo">
  <!--
    <div id="barra-separadora">
    
    </div>
     <hr>
   -->
        <a href="../Imagenes/vehiculos-prueba/golf1999.jpg" target="_blank">
            <img href="../Imagenes/vehiculos-prueba/golf1999.jpg" class="imagenes" src="../Imagenes/vehiculos-prueba/golf1999.jpg">
        </a><a href="../Imagenes/vehiculos-prueba/golf1999-1.jpg" target="_blank">
            <img class="imagenes" src="../Imagenes/vehiculos-prueba/golf1999-1.jpg">
        </a><a href="../Imagenes/vehiculos-prueba/golf1999-2.jpg" target="_blank">
            <img class="imagenes" src="../Imagenes/vehiculos-prueba/golf1999-2.jpg">
        </a><a href="../Imagenes/vehiculos-prueba/golf1999-2.jpg" target="_blank">
            <img class="imagenes" src="../Imagenes/vehiculos-prueba/golf1999-2.jpg">
        </a>
    </div>
    <!--
<div id="VehiculoAlertaInvalido" class="alert  alert-error">
                     <a class="close" data-dismiss="alert">X</a> <strong>Error</strong> No se encontraron vehiculos con esa referencia.
                </div>-->

<%--
    <div id="contenedor-conductor">
    <p class="titulos">
        Conductor:</p>
    <div class="separador">
    </div>
    </div>

    <table class="tabla-principal display-none">
        <tr>
            <td colspan="2" class="celda">
                Nombre Completo:
            </td>
            <td id="nombre" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                DNI:
            </td>
            <td id="dni" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Licencia:
            </td>
            <td id="licencia" colspan="2" class="celda2">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="celda">
                Imágen:
            </td>
            <td id="Imagen-conductor" colspan="2" class="celda-imagen">
            </td>
        </tr>
    </table>--%>
    </div>
</body>
     <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="../Vehiculos/js/ConsultaVehicular.js"></script>
</html>

