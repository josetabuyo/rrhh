<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BienesDetalle.aspx.cs" Inherits="MoBi_BienesDetalle" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Detalle de Vehiculo</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css"/>   

    <%= Referencias.Javascript("../")%>
</head>

<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    

    <div style="" align="center">
    

    <div style="display:block;
        width: 50%;
        padding: 0;
        margin-bottom: 27px;
        font-size: 19.5px;
        line-height: 36px;
        color: #333333;
        border: 0;
        border-bottom: 1px solid #e5e5e5; 
        text-shadow: 2px 2px 5px rgba(150, 150, 150, 1); text-align: left;" >
        Detalle de Vehiculo

        <a id="A1" class="btn btn-primary" href="MovimentosBien.aspx">Historial</a>
    </div>

    </div>


    <%--<div class="contenedor_principal contenedor_principal_seleccion_areas">
        <div id="titulo_areas_a_administrar" style="text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);">
            Vehiculo                 
            <a id="btn_consultar_historia" class="btn btn-primary" href="MovimentosBien.aspx">Historial</a>
        </div>
    </div>--%>

</form>

</body>


<script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
<script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
<script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
<script src="../scripts/Spin.js" type="text/javascript"></script>

<script type="text/javascript">
</script>


</html>