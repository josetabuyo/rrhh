<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FAreasConDDJJ.aspx.cs" Inherits="DDJJ104_FAreasConDDJJ" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>


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
    </fieldset>

    <%--<div style="text-align: right">
        <a style="font-size: 1.6em;display: block;margin-bottom: 10px;" href="ConsultaIndividualDDJJ.aspx">Consulta Individual de DDJJ104</a>
    </div>--%>
    
    <div>    
        <select runat="server" title="Seleccione un mes" id="cmbMeses" name="Meses" enableviewstate="false"
            style="text-transform: capitalize;">
        </select>
    </div>

    <div id="grilla" runat="server" style="width: 100%" align="center">
        <label>Ingrese el Area o Estado que desea buscar: </label>
        <input type="text" id="search" class="search" class="buscador" placeholder="Buscar Area/Estado" style="width:250px"; />
        <div id="ContenedorGrilla" runat="server" style="width: 90%"></div>
        <div id="DivBotonExcel" runat="server" style="width: 90%"></div>
    </div>
    
    <div id="grillaPersonas" runat="server" style="width: 100%" align="center">
        <div id="ContenedorPersona" runat="server" style="width: 90%"></div>
    </div>


    <asp:HiddenField ID="AreasJSON" runat="server" EnableViewState="true" />
      
    </form>
</body>

<script src="../scripts/underscore-min.js" type="text/javascript"></script>
<script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
<script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
<script src="../scripts/Spin.js" type="text/javascript"></script>
<script src="DDJJ.js" type="text/javascript"></script>


</html>
