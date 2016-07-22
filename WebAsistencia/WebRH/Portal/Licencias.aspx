<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Licencias.aspx.cs" Inherits="Portal_Licencias" %>
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
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:30px; ">Licencias</h1>
        <div style="margin: 0 auto;" class="row">
        <div style="text-align:center;" class="caja_izq"></div>

            <div class="caja_der papel">
            <legend style="margin-top: 20px;">Licencias Tomadas</legend>
            <p>Elegir tipo de Licencia: 
                <select id="cmbLicTomadas" >
                    <option value="0">Seleccionar</option>
                    <option value="1">9 - Ordinaria Anual</option>
                    <option value="2">14f - Razones Particulares</option>
                </select>
            </p>
            
            <p id="textoLicenciaElegida" style="font-weight:bold;"></p>
            <a href="#" id="btn_excel_tomadas" class="btn_exportar">Exportar Datos</a>
            <table id="tablaLicenciasTomadas" class="tabla_familiar">
                <thead>
                    <tr>
                        <th>Año</th>
                        <th>Anual Autorizados</th>
                        <th>Anual Tomados</th>
                        <th>Anual Restan</th>
                        <th>Desde</th>
                        <th>Hasta</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>2016</td>
                        <td>6</td>
                        <td>1</td>
                        <td>5</td>
                        <td>18/01/01</td>
                        <td>19/01/01</td>
                    </tr>
                </tbody>
            </table>

                    <legend style="margin-top: 50px; margin-bottom:50px;">Licencias Pendientes</legend>
                    <a href="#" id="btn_excel_pendientes" class="btn_exportar">Exportar Datos</a>
                    <table class="tabla_familiar">
                        <thead>
                            <tr>
                                <th>Año</th>
                                <th>Días Pendientes</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>2016</td>
                                <td>25</td>
                            </tr>
                            <tr>
                                <td>2015</td>
                                <td>20</td>
                            </tr>
                            <tr>
                                <td>2014</td>
                                <td>20</td>
                            </tr>
                            <tr>
                                <td>2013</td>
                                <td>15</td>
                            </tr>
                        </tbody>
                    </table>

                </div>
               
            </div>
        </div>

    </form>
</body>
<script type="text/javascript" >

    $(document).ready(function ($) {

        $('#tablaLicenciasTomadas').hide();
        $('#btn_excel_tomadas').hide();

        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm");

        Backend.start(function () {

            $("#cmbLicTomadas").change(function () {
                $('#textoLicenciaElegida').html($("#cmbLicTomadas option:selected").text());
                $('#tablaLicenciasTomadas').show();
                $('#btn_excel_tomadas').show();
            });

        });

    });

</script> 
</html>
