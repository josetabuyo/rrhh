<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetalleVehiculo.aspx.cs" Inherits="Vehiculos_DetalleVehiculo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html id="mihtml" xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title>Control Vehicular</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="link1" rel="stylesheet" href="css/DetalleVehiculo.css" type="text/css" />
    <link type="text/css" rel="stylesheet" href="css/animate.css">
<%--<link type="text/css" rel="stylesheet" href="css/bootstrap-responsive.css">
    <link type="text/css" rel="stylesheet" href="css/bootstrap-responsive.min.css">--%>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="../Vehiculos/js/DetalleVehiculo.js"></script>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap-theme.min.css">
    <link type="text/css" rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
   <link href="//ajax.googleapis.com/ajax/libs/jqueryui/1.11.1/themes/ui-darkness/jquery-ui.min.css" rel="stylesheet">
	<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
	<script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.11.1/jquery-ui.min.js"></script>
</head>
<body>
    <div id="contenedor_imagen">
                <img src="../Imagenes/BarraMenu/encabezado_sin_logos.png" id="encabezado_sin_logo" alt="logosistema" />
                <img src="../Imagenes/logo_sistema.png" id="img_logo_sistema" alt="logosistema" />
                <img src="../Imagenes/logo_ministerio.png" id="img_logo_minis" alt="logosistema" />
                <img src="../Imagenes/logo_direccion.png" id="img_logo_direccion" alt="logosistema" />
                    <div id="barra_menu_nombre_sistema">
                        <p id="titulo-del-menu">Consulta<br>de<br> Vigencia </p>
                    </div>
                    <div id="barra-azul">
                    </div>

                    	<div id="mensaje_error" title="Error" style="display:none">
		<p id="prueba">Se ha ingresado un código incorrecto. Por favor, verifique e inténtelo nuevamente.  </p>

        <input type="button" id="button" value="Volver">
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

    <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Carousel indicators -->
    <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
    </ol>   
    <!-- Wrapper for carousel items -->
    <div class="carousel-inner">
        <div class="item active">
            <img src="../Imagenes/vehiculos-prueba/golf1999.jpg" alt="First Slide">
        </div>
        <div class="item">
            <img src="../Imagenes/vehiculos-prueba/golf1999-2.jpg" alt="Second Slide">
        </div>
        <div class="item">
            <img src="../Imagenes/vehiculos-prueba/golf1999-1.jpg" alt="Third Slide">
        </div>
    </div>
    <!-- Carousel controls -->
    <a class="carousel-control left" href="#myCarousel" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left"></span>
    </a>
    <a class="carousel-control right" href="#myCarousel" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right"></span>
    </a>
</div>

<%--        <a href="../Imagenes/vehiculos-prueba/golf1999.jpg" target="_blank">
            <img href="../Imagenes/vehiculos-prueba/golf1999.jpg" class="imagenes" src="../Imagenes/vehiculos-prueba/golf1999.jpg">
        </a><a href="../Imagenes/vehiculos-prueba/golf1999-1.jpg" target="_blank">
            <img class="imagenes" src="../Imagenes/vehiculos-prueba/golf1999-1.jpg">
        </a><a href="../Imagenes/vehiculos-prueba/golf1999-2.jpg" target="_blank">
            <img class="imagenes" src="../Imagenes/vehiculos-prueba/golf1999-2.jpg">
        </a><a href="../Imagenes/vehiculos-prueba/golf1999-2.jpg" target="_blank">
            <img class="imagenes" src="../Imagenes/vehiculos-prueba/golf1999-2.jpg">
        </a>--%>
    </div>
    </div>
</div>
<!-- DIALOG -->

	
<!-- DIALOG -->
</body>
     
</html>