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
        <div style="text-align:right; margin-right:20%"><a href="Consultas.aspx">Realizar/Visualizar Consultas</a></div>
        <div style="text-align:center;" class="caja_izq no-print"></div>
         <div  class="caja_der papel" style="width:35%;">
         <div id="div_recibo">
            <%--<p class="">Dirección de Diseño y Desarrollo Organizacional para la Gestión de Personas, Dirección de Recursos Humanos y 
         Organización, Secretaría de Coordinación y Monitoreo Institucional, Unidad Ministro, Ministerio de Desarrollo Social </p>--%>
         <div  style="margin:10px;">
         <p>Seleccione año y mes del recibo que quiera ver:  </p>
             <select style="width:60px;" id="cmb_anio">
                <option value="2016">2016</option>
                <option value="2015">2015</option>
                <option value="2014">2014</option>
                <option value="2013">2013</option>
                <option value="2012">2012</option>
                <option value="2011">2011</option>
                <option value="2010">2010</option>
             </select>
             <select style="width:100px;" id="cmb_meses">
                <option value="1">Enero</option>
                <option value="2">Febrero</option>
                <option value="3">Marzo</option>
                <option value="4">Abril</option>
                <option value="5">Mayo</option>
                <option value="6">Junio</option>
                <option value="7">Julio</option>
                <option value="8">Agosto</option>
                <option value="9">Septiembre</option>
                <option value="10">Octubre</option>
                <option value="11">Noviembre</option>
                <option value="12">Diciembre</option>
             </select>
             <div id="caja_controles">
                
             </div>
             </div>

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
            Legajo.bindearBotonLiquidacion();

            $("#tabla_recibo_encabezado").hide();
            var day = new Date();
            var mes = day.getMonth();
            $("#cmb_meses").val(mes).trigger('change'); ;

            
            //Legajo.getReciboDeSueldo();

        });

    });


</script> 
</html>
