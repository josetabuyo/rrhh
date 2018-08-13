<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaseFacturaContabilidad.aspx.cs"
    Inherits="FacturasContratos_PaseFacturaContabilidad" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Remisión de Facturas a Contabilidad</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css" />
    <%= Referencias.Javascript("../")%>
</head>
<body style="padding: 0px !important;">
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu1" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <%-- <fieldset style="text-align: center">
        <legend>Consultas DDJJ 104/2001</legend>
    </fieldset>--%>
    <div style="margin-top: 40px" align="center">
        <div style="display: block; width: 50%; padding: 0; margin-bottom: 27px; font-size: 19.5px;
            line-height: 36px; color: #333333; border: 0; border-bottom: 1px solid #e5e5e5;
            text-shadow: 2px 2px 5px rgba(150, 150, 150, 1); text-align: left;">
            Remisión de Facturas a Contabilidad
            <%--<div id="DivBotonConsultaPorPersona" runat="server" style="display: block; float: right; margin-top: 4px; margin-left: 4px; border: #0055cc;"></div>
        <div id="DivBotonConsultaPorArea" runat="server" style="display: block; float: right; margin-top: 4px; margin-left: 4px; border: #0055cc;"></div>--%>
        </div>
    </div>
    <div id="ContenedorGrilla" runat="server" style="width: 90%" align="center">
        <div id="ContenedorPersona" runat="server" style="width: 90%">
        </div>
    </div>
    <div>
        <label id="lblPaseContabilidad">Pase a Contabilidad</label>
        <input type="text" id="txtPaseContabilidad" style="width: 110px;" placeholder="dd/mm/aaaa"/>
    </div>
    <input type="button" value="Enviar" class="btn btn-primary" id="btn_Enviar" />
    </form>
</body>
<script type="text/javascript" src="PaseFacturaContabilidad.js"></script>
<script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
<script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
<script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
<script src="../scripts/Spin.js" type="text/javascript"></script>
<script type="text/javascript" src="../Scripts/alertify.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $(window).keydown(function (event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                return false;
            }
        });

        var cfg_panel_alta = {
            inputPaseContabilidad: $('#txtPaseContabilidad')
        }
        var panel_alta = new PanelAltaDeDocumento(cfg_panel_alta);

    });
</script>

</html>
