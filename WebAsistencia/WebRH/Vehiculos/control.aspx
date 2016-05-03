<%@ Page Language="C#" AutoEventWireup="true" CodeFile="control.aspx.cs" Inherits="Vehiculos_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">


<head>
    <title>Control Vehicular</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
       <link id="link1" rel="stylesheet" href="../vehiculos/control.css" type="text/css" />
</head>
<body>
        <div id="contenedor_imagen">
            <div id="barra_menu_contenedor_imagen">
          
               <img src="../Imagenes/BarraMenu/encabezado_sin_logos.png" id="encabezado_sin_logo" alt="logosistema"  />
          
                <img src="../Imagenes/logo_sistema.png" id="img_logo_sistema" alt="logosistema"  />              
                <img src="../Imagenes/logo_ministerio.png" id="img_logo_minis" alt="logosistema"  />
                <img src="../Imagenes/logo_direccion.png" id="img_logo_direccion" alt="logosistema"  />
                <div id="barra_menu_nombre_sistema">
                   <span style="font-size:18px; font-weight: bold;"></span>
<br>
<span style="font-size:18px;font-weight: bold;"> Control<br> Vehicular </span>
                </div>
            </div>
        </div>
    <p style="font-size:18px;font-weight: bold;">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ac nisi id urna blandit varius sit amet vel est. Quisque hendrerit orci mollis tortor condimentum commodo. Nunc sollicitudin mi odio, nec varius erat pulvinar ut. Integer placerat euismod ullamcorper. Etiam faucibus purus lectus, non consectetur nisl mattis vitae. Integer lacinia felis nibh. Mauris sed pretium leo, vel sollicitudin nunc. Integer aliquam diam nec tincidunt ullamcorper. Nullam id vestibulum augue. </p>
    <br>
    <br>
    <br>
    <div class="separador"></div>
        <p class="titulos">Vehículo:</p>
    <div class="separador"></div> 
            <table class="tabla-principal">
                <tr>
                    <td colspan="2" class="celda">Marca:</td>
                    <td id="marca" colspan="2" class="celda2">AAA000</td>
                </tr>    
                
                <tr>
                    <td colspan="2" class="celda">Modelo:</td>
                    <td id="Modelo" colspan="2" class="celda2">Meriva</td>
                </tr>   
                <tr>
                    <td colspan="2" class="celda">Segmento:</td>
                    <td id="segmento" colspan="2" class="celda2">2012</td>
                </tr>   
        
                <tr>
                    <td colspan="2" class="celda">Dominio:</td>
                    <td id="dominio" colspan="2" class="celda2">Sedan</td>
                </tr>
        
                <tr>
                    <td colspan="2" class="celda">Año:</td>
                    <td id="año" colspan="2" class="celda2">1999</td>
                </tr>
                
                <tr>
                    <td colspan="2" class="celda">Motor:</td>
                    <td id="Motor" colspan="2" class="celda2">ARG208444</td>
                </tr>   

                  <tr>
                    <td colspan="2" class="celda">Chasis:</td>
                    <td id="chasis" colspan="2" class="celda2">WVWZZZ1JZXW594362</td>
                </tr> 
        
                <tr>
                    <td colspan="2" class="celda">Asignado al sector:</td>
                    <td id="sector" colspan="2" class="celda2">Subsecretaría de Abordaje Territorial</td>
                </tr> 
                
                <tr>
                    <td colspan="2" class="celda">Teléfono:</td>
                    <td id="telefono" colspan="2" class="celda2">15-1234-5678</td>
                </tr> 
                <tr>
                    <td colspan="2" class="celda">Imágen:</td>
                    <td id="imagen1" colspan="2" class="celda-imagen"></td>
                </tr>
                <tr>
                    <td colspan="2" class="celda">Imágen:</td>
                    <td id="imagen2" colspan="2" class="celda-imagen"></td>
                </tr>
                <tr>
                    <td colspan="2" class="celda">Imágen:</td>
                    <td id="imagen3" colspan="2" class="celda-imagen"></td>
                </tr>
           </table>
    
    <div class="separador"></div>    
        <p class="titulos">Conductor:</p>
    <div class="separador"></div> 
            <table class="tabla-principal">
 
                <tr>
                     <td colspan="2" class="celda">Nombre Completo:</td>
                      <td id="nombre" colspan="2" class="celda2"></td>
               </tr>
      
                <tr>
                     <td colspan="2" class="celda">DNI:</td>
                    <td id="dni" colspan="2" class="celda2"></td>
                </tr>
        
                <tr>
                    <td colspan="2" class="celda">Licencia:</td>
                    <td id="licencia" colspan="2" class="celda2"></td>
                </tr>
                <tr>
                    <td colspan="2" class="celda">Imágen:</td>
                    <td id="Imagen-conductor" colspan="2" class="celda-imagen"></td>
                </tr>
            </table>
        </body>
                </html>
