<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonasNoCertificadasAsigArea.aspx.cs" Inherits="DDJJ104_PersonasNoCertificadasAsigArea" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/Scripts/BuscadorDeAreas.ascx" TagName="BuscadorDeAreas" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../") %>
</head>

<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu1" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />

    <fieldset style="text-align: center; margin-top: 40px" >
        <legend>Certificación de Servicios según Decisión Administrativa N° 104/2001</legend>
        <legend>Certificar Personas no Certificadas</legend>
    </fieldset>

    <div>    
        <select runat="server" title="Seleccione un mes" id="cmbMeses" name="Meses" enableviewstate="false"
            style="text-transform: capitalize;">
        </select>
    </div>



    <%-- --------------- BUSCADOR DE AREA ---------------- --%>
        <div runat="server" id="Controles_Persona_Area" style="margin-top:20px;">
            <asp:label ID="Label1" runat="server" Text="Seleccione el Area que certica" ></asp:label>
            <div id="divBuscadorArea">
                <uc3:BuscadorDeAreas ID="buscador1" runat="server" style="display: inline-block; margin:auto;" />
            </div>
        </div>
    <%-- --------------------------------------------------- --%>


    <div id="grilla" runat="server" style="width: 100%" align="center">
        <label>Ingrese el texto que desea buscar: </label>
        <input type="text" id="search" class="search" class="buscador" placeholder="Buscar Area/Estado" style="width:250px"; />
        <div id="ContenedorGrilla" runat="server" style="width: 90%"></div>
        
        
        
        <div id="DivBotonGuardar" runat="server" style="width: 90%"></div>






    </div>


     

       


    </form>
</body>


    <script src="../scripts/underscore-min.js" type="text/javascript"></script>
    <script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
    <script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
    <script src="../scripts/Spin.js" type="text/javascript"></script>
    <script src="PersonasNoCertificadasAsigArea.js" type="text/javascript"></script>

</html>