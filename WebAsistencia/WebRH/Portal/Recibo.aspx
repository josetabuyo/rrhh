<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recibo.aspx.cs" Inherits="Portal_Recibo" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width"/>
        <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>

        <link rel="stylesheet" href="estilosPortalSecciones.css" />
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
         
        <div style="text-align:center;margin-top:20px; padding-bottom:7px;" class="caja_izq no-print"></div>
         <div  class="caja_derxxxx papelxxx" style="float:left;margin-top:20px;width:80%;padding: 0px 20px 0px 20px; ">
             <div style="background-image: linear-gradient(to bottom, rgb(1,70,99), rgb(1,70,99));border-radius: 10px;color: #fff;font-weight: bold;padding:10pt 0pt 10pt 0pt;font-size: 13pt;text-align: center;">
                       
                          RECIBO DE SUELDO      
                       
              </div>
         <div id="div_recibo">
            <%--<p class="">Dirección de Diseño y Desarrollo Organizacional para la Gestión de Personas, Dirección de Recursos Humanos y 
         Organización, Secretaría de Coordinación y Monitoreo Institucional, Unidad Ministro, Ministerio de Desarrollo Social </p>--%>
         <div  style="margin:10px;font-size:12pt">
         <p>Seleccioná un mes para ver los recibos correspondientes al sueldo cobrado a principios del mes de:</p>
             <select style="width:115px;" id="cmb_meses">
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
              <select style="width:70px;" id="cmb_anio">
             </select>
             <div id="caja_controles" style="margin-top:5pt;">
                
             </div>
             <div id="caja_info_recibos">
                
             </div>

             

             <hr style="border-top: 1px solid #d0cdd6;border-radius: 5px;width: 100%;margin: 0 auto;margin-top:5px;">
             </div>
                          

             <div style="max-width:650px;-webkit-border-radius: 7px 7px 0px 0px;
-moz-border-radius: 7px 7px 0px 0px;border-radius: 7px 7px 0px 0px;border-collapse: collapse;border: 0px solid #1C6EA4;text-align: center;margin: 0 auto;">
         <table id="tabla_recibo_encabezado">
            <thead>
                <tr class="fila_header">
                    <th style="width:67px;" class="">Legajo No.</th>
                    <th style="width:311px;" class="">Apellido y Nombre</th>
                    <th style="width:100px;">CUIL</th>
                    <th style="width:40px;">Of.</th>
                    <th style="width:85px;">N. Orden</th>
                </tr>
           
                <tr style="height: 30px;">
                    <td id="celdaLegajo"></td>
                    <td id="celdaNombre"></td>
                    <td id="celdaCUIL"></td>
                    <td id="celdaOficina"></td>
                    <td id="celdaOrden"></td>
                </tr>
            <tr class="fila_header">
                    <th colspan="1" rowspan="2" class="ancho_primera_columna">Código</th>
                    <th colspan="1" rowspan="2" class="ancho_segunda_columna">Descripción</th>
                    <th colspan="3" style="text-align:center;">Importe</th>
                </tr>
                <tr class="fila_header">
                    <th colspan="1" style="width:110px;">Haberes</th>
                    <th colspan="2" style="width:110px;">Descuentos</th>
                </tr>
           </thead>
           <tbody>
               
            </tbody>
         </table>
                 <div id="bloque_final" style="display:none; margin-top:20px;text-align:left;;width:100%">
            <p style="font-weight: bold; text-align: center; margin-top: 20px;">SOLO PARA INFORMACIÓN - NO VÁLIDO COMO COMPROBANTE</p>
       
            <p><strong>Área:</strong> <span id="area"></span></p>
            <p><strong>Categ:</strong> <span id="categoria"></span></p>
            <p><strong>Fecha Liq:</strong> <span id="fechaLiquidacion"></span></p>
            <p><strong>Domicilio:</strong> <span id="domicilio"></span></p>
        </div>
         </div>

<%--
         <p>Recibí el importe neto y Copia del recibo de la presente liquidación.</p>
         <p>Certifico que el Nro. de Documento <span>xxxx</span> corresponde a mi Documento Civico (Decreto N°: 1221/80).</p>
         
         

         <br />
         <p>Firma del empleado: <span class="subrayado"></span></p>

         <p>Firma Autorizante: <span class="subrayado"></span></p>

         <p>Articulo 12 de la Ley N° 17250, Depositado: <span></span></p>

         </div>--%>
         
         </div>
    </div>
    </form>
</body>
<script type="text/javascript" src="Legajo.js?"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../Scripts/jsPortal/RepoFirmaDigital.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {
        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm", function () {
            Backend.start(function () {
                Legajo.getNombre();

                Legajo.bindearBotonLiquidacion();

                $("#tabla_recibo_encabezado").hide();
                var day = new Date();
                var mes = day.getMonth() + 1;
                var anio = day.getFullYear();

                /*NOTA: por default la web solo permite ver los recibos de los ultimos 3 años, incluido el año actual, por lo
                 * que se coincide con las tablas de recibos actuales; por eso no se se envia el parametro historico para
                 * buscar en recibos historicos*/
                $("#cmb_anio").empty();

                for (var i = 0; i <= 2; i++) {
                    $("#cmb_anio").append('<option value=' + (anio - i).toString() + '>' + (anio - i).toString() + '</option>');
                }


                $("#cmb_meses").val(mes);
                $("#cmb_anio").trigger('change');
                //$("#cmb_meses").val(mes).trigger('change');



            });
        });

    });


</script> 


<script type="text/javascript" >
    /*funcionalidadaes de la pagina web*/
    function mostrarObservacion(opcion) {

        if (opcion == 0) {
            //hizo click en conformar, entonces oculto el panel de observacion
            document.getElementById('capaObservacion').style.display = 'none';
            //document.getElementById('observacion2').value = '';
        } else {
            document.getElementById('capaObservacion').style.display = 'block';
        
       }
    }

    function conformarRecibo(idRecibo) {

        var obs = document.getElementById('observacion2').innerHTML;//value;
        var resultado = 0;

        var porNombre = document.getElementsByName("modoFirma");
        // Recorremos todos los valores del radio button para encontrar el
        // seleccionado
        for (var i = 0; i < porNombre.length; i++) {
            if (porNombre[i].checked)
                resultado = porNombre[i].value;
        }
        //resultado 1 = conforme
        //resultado 0 = disconforme
        
        GeneralPortal.conformar(idRecibo,resultado,obs);

    }


</script> 

</html>
