<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recibo.aspx.cs" Inherits="Portal_Recibo" %>
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

        <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortalSecciones.css" />
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:30px; "></h1>
        <div style="text-align:center;" class="caja_izq no-print"></div>
         <div  class="caja_der papel" style="width:35%;">
         <div id="div_recibo">
            <%--<p class="">Dirección de Diseño y Desarrollo Organizacional para la Gestión de Personas, Dirección de Recursos Humanos y 
         Organización, Secretaría de Coordinación y Monitoreo Institucional, Unidad Ministro, Ministerio de Desarrollo Social </p>--%>
         <table id="tabla_recibo_encabezado">
            <thead>
                <tr>
                    <th style="width:67px;" class="">Legajo No.</th>
                    <th style="width:311px;" class="">Apellido y Nombre</th>
                    <th style="width:100px;">CUIL</th>
                    <th style="width:40px;">Of.</th>
                    <th style="width:85px;">N. Orden</th>
                </tr>
           
                <tr>
                    <td id="celdaLegajo"></td>
                    <td id="celdaNombre"></td>
                    <td id="celdaCUIL"></td>
                    <td id="celdaOficina"></td>
                    <td id="celdaOrden"></td>
                </tr>
            <tr>
                    <th colspan="1" rowspan="2" class="ancho_primera_columna">Código</th>
                    <th colspan="1" rowspan="2" class="ancho_segunda_columna">Descripción</th>
                    <th colspan="3" class="">Importe</th>
                </tr>
                <tr>
                    <th colspan="1" style="width:110px;">Haberes</th>
                    <th colspan="2" style="width:110px;">Descuentos</th>
                </tr>
           </thead>
           <tbody>
                 <tr>
                    <td>123</td>
                    <td class="columna_concepto">Sueldo basico</td>
                    <td>$ 5000.00</td>
                    <td colspan="2" ></td>
                </tr>
                <tr>
                    <td>123</td>
                    <td class="columna_concepto">Sueldo basico</td>
                    <td>$ 5000.00</td>
                    <td colspan="2" ></td>
                </tr>
                <tr>
                    <td>123</td>
                    <td class="columna_concepto">Sueldo basico</td>
                    <td>$ 5000.00</td>
                    <td colspan="2" ></td>
                </tr>
                <tr>
                    <td>123</td>
                    <td class="columna_concepto">Sueldo basico</td>
                    <td>$ 5000.00</td>
                    <td colspan="2" ></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan="2" ></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan="2" ></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan="2" ></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan="2" ></td>
                </tr>
                <tr class="ultima_fila">
                    <td></td>
                    <td></td>
                    <td class="celda_neto">Neto:</td>
                    <td class="celda_importe_neto" colspan="2" ></td>
                </tr>
            </tbody>
         </table>
         
        <%-- <div class="bloque_final">
            <p>Categ: <span></span></p>
            <p>Opción: <span></span></p>
            <p>AFJP: <span></span></p>
        </div>

        <div class="bloque_final">
            <p>Fecha Liq:</p>
            <p>Tipo Liq:</p>
        </div>

         <p>Recibí el importe neto y Copia del recibo de la presente liquidación.</p>
         <p>Certifico que el Nro. de Documento <span>xxxx</span> corresponde a mi Documento Civico (Decreto N°: 1221/80).</p>
         
         <p>Domicilio:<span class="subrayado"></span></p>

         <br />
         <p>Firma del empleado: <span class="subrayado"></span></p>

         <p>Firma Autorizante: <span class="subrayado"></span></p>

         <p>Articulo 12 de la Ley N° 17250, Depositado: <span></span></p>--%>

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
            Legajo.getReciboDeSueldo();

        });

    });


</script> 
</html>
