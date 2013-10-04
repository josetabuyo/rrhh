<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeleccionDeArea.aspx.cs"
    Inherits="SeleccionDeArea" %>
<%@ Register Src="ControlArea.ascx" TagName="ControlArea" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Administrar áreas</title>
    <link id="link1" rel="stylesheet" href="Estilos/EstilosSeleccionDeArea.css" type="text/css" runat="server" />    
    <%= Referencias.Css("")%>
</head>

<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="Imagenes/" UrlEstilos="Estilos/" />
    <div class="contenedor_principal contenedor_principal_seleccion_areas">
        <legend style="text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);">
            Áreas a Administrar 
            <a id="btn_consultar_areas" class="btn btn-primary" href="FormularioProtocolo/ConsultaProtocolo.aspx"> 
                Consultar Todas las Areas 
            </a>
        </legend>
        <div>
            <asp:Panel ID="Panel" runat="server"></asp:Panel>
        </div> 
    </div>
</form>


<script type="text/javascript">
    function EditarElArea(id) {
        PageMethods.EditarElArea(id, onSuccess, onFailure);
    }

    function IrAlArea(id) {
        PageMethods.IrAlArea(id, onSuccess, onFailure);
    }

    function onSuccess(result) {
        window.location = result;
    }

    function onFailure(error) {
        alert(error);
    }


    </script>

     

</body>
</html>
