<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuBienes.aspx.cs" Inherits="MoBi_MenuBienes"  %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Menu Bienes</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css"/> 
    
    <%= Referencias.Javascript("../")%>
</head>

<body>
<form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div style="" align="center">
        <div style="display: block; width: 50%; padding: 0; margin-bottom: 27px; font-size: 19.5px;
            line-height: 36px; color: #333333; border: 0; border-bottom: 1px solid #e5e5e5;
            text-shadow: 2px 2px 5px rgba(150, 150, 150, 1); text-align: left;">
            Menu de Bienes
            
            <div id="DivBotonAlta" runat="server" style="display: block; float: right;
                margin-top: 4px; margin-left: 4px; border: #0055cc;">
                <asp:Button runat="server" ID="btnAlta" RequiereFuncionalidad="37" CssClass="btn btn-primary" 
                    Text="Alta/Baja de Bienes" UseSubmitBehavior="True" 
                    onclick="btnAlta_Click" />
            </div>

            <div id="DivBotonConsulta" runat="server" style="display: block; float: right;
                margin-top: 4px; margin-left: 4px; border: #0055cc;">
                <asp:Button runat="server" ID="btnConsultar" RequiereFuncionalidad="41" CssClass="btn btn-primary" 
                    Text="Consultar Bienes" UseSubmitBehavior="True" 
                    onclick="btnConsultar_Click" /> 
            </div>

        </div>
    </div>



</form>
</body>
</html>