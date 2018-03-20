<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Licencias.aspx.cs" Inherits="Portal_Licencias" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Portal RRHH</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width">
    <!-- CSS media query on a link element -->
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
    <link rel="stylesheet"  href="estilosPortalSecciones.css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 17px;">
        </h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align: center;" class="caja_izq">
            </div>
            <div class="caja_der papel">
                <legend style="margin-top: 20px;">LICENCIAS EN TRÁMITE</legend><a href="#" id="btn_excel_tramite"
                    class="btn_exportar">Exportar Datos</a>
                <div id="tablaLicenciasEnTramite" class="table table-striped table-bordered table-condensed">
                </div>
                <legend style="margin-top: 50px; margin-bottom: 50px;">LICENCIAS ORDINARIAS DISPONIBLES</legend>
                <a href="#" id="btn_excel_pendientes" class="btn_exportar">Exportar Datos</a>
                <div id="tablaLicenciasOrdinariasDisponibles" class="table table-striped table-bordered table-condensed">
                </div>

                <legend style="margin-top: 50px; margin-bottom: 50px;">HISTORICO DE LICENCIAS ORDINARIAS</legend>
                <a href="#" id="A1" class="btn_exportar">Exportar Datos</a>
                <div id="tablaHistoricoLicenciasOrdinarias" class="table table-striped table-bordered table-condensed">
                </div>

                <legend style="margin-top: 50px; margin-bottom: 50px;">AUSENCIAS JUSTIFICACION</legend>
                <a href="#" id="A2" class="btn_exportar">Exportar Datos</a>
                <div id="tablaAusencias" class="table table-striped table-bordered table-condensed">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>s
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript">

    $(document).ready(function ($) {

        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm", function () {
            Backend.start(function () {
                Legajo.getNombre();
                Legajo.getDatosLicencias();
            });
        });

    });

</script>
</html>
