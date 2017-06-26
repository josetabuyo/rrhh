<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Certificado.aspx.cs" Inherits="Portal_Certificado" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Perfil Profesional</title>
    <!-- CSS media query on a link element -->
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
    <link rel="stylesheet" href="estilosPortalSecciones.css" />
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
                <legend style="margin-top: 20px;">Certificación de Antigüedad</legend>
                <h4 style="color: #003e67; text-align: center">
                    La información mostrada a continuación corresponde a los lugares de trabajo dentro del Ministerio 
                    donde usted desempeño tareas según los registros obrantes de la <b style="color: #0074cc">Dirección
                        General de Recursos Humanos y Organización</b>:
                    <br />
                </h4>
                <div id="tablaCarreraAdministrativa" class="table table-striped table-bordered table-condensed">
                </div>
                <h4 style="color: #003e67; text-align: center">
                    Ante cualquier duda sobre la información mostrada deberá acercarse a
                    Dirección de Administración de Personal.<br />
                    Si está de acuerdo con la información haga click sobre el botón <b style="color: #0074cc">
                        Confirmar Solicitud</b>
                    <br />
                </h4>
                <input id="btn_solic_cert" type="button" class="btn btn-primary" style="margin: auto;
                    display: block; height: 30px; margin-top: 10px; padding-bottom: 25px;"
                    value="Confirmar Solicitud" />
            </div>
        </div>
    </div>
    </form>
</body>
<script type="text/javascript" src="Certificado.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript">

    $(document).ready(function ($) {

        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm", function () {
            Backend.start(function () {
                //Legajo.getNombre();
                //Legajo.GetDatosDesignaciones();
                Certificado.GetCarreraAdministrativa();
            });
        });

    });

</script>
</html>
