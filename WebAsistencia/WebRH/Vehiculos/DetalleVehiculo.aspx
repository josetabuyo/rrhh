<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetalleVehiculo.aspx.cs"
    Inherits="Vehiculos_DetalleVehiculo" %>

<html>
<head>
    <title>Control de Vigencia</title>
    <%= Referencias.Javascript("../")%>
    <%= Referencias.Css("../")%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="link1" rel="stylesheet" href="css/DetalleVehiculo.css" type="text/css" />
    <script type="text/javascript" src="js/DetalleVehiculo.js"></script>
    <script type="text/javascript" src="js/carousel.js"></script>
    <script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
    <link rel="icon" href="../Imagenes/iconos/logoweb-favicon.png">
</head>

<body>
    <div id="fondo-Arriba">
    </div>
    <div id="fondo-Abajo">
    </div>

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
        <a id="boton-volver" href="https://rrhh.desarrollosocial.gob.ar/vehiculos/" class="posicion-boton-imagenes btn btn-primary">Volver</a>
        <a id="boton-datos-vehiculo" href="#datos-vehiculo" class="posicion-boton-imagenes btn btn-primary">Datos</a>
        <a id="boton-imagenes" href="#myCarousel" class="posicion-boton-imagenes btn btn-primary">Imágenes</a>
        </div>
    </div>
    <div id="mensaje_error" title="Error" style="display: none">
        <p id="txt_mensaje_error">
            Se ha ingresado un código incorrecto.<br>
            Por favor, verifique e inténtelo nuevamente.
            <br>
        </p>
        <a href="javascript:history.back()">
            <p id="volver_mensaje_error">
                Volver</p>
        </a>
    </div>
    <div id="Contenido">
            <div id="prueba"> </div>
            <div id="contenedor-vehiculos">

                <div class="div-titulos animated slideInRight"">
                    <p id="titulo">
                        Vehículo
                    </p>
                </div>
               <%--<div class="separador">
                </div>--%>
            </div>
            <div id="mensaje_vehiculo"></div>
            <div id="mensaje_tarjeton"></div>
            <table id="datos-vehiculo" class="tabla-principal">
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
        


        <div class="contenedor-imagen-vehiculo">
            <div id="myCarousel" class="carousel slide" data-ride="carousel" style="width: 100%;
                height: 500px;">
                <!-- Wrapper for carousel items -->
                <div class="carousel-inner" style="width: 100%; height: 100%;">
                </div>
            

            <!-- Carousel controls -->
            <a class="carousel-control left" href="#myCarousel" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left">
            </span>
            </a>
            
            <a class="carousel-control right" href="#myCarousel" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right">
            </span>
            </a>
            </div>
        </div>
        </div>

    </div>
    
</body>
</html>
