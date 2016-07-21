<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaIndividualDDJJ.aspx.cs"
    Inherits="DDJJ104_ConsultasDDJJ" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/Scripts/BuscadorDeAreas.ascx" TagName="BuscadorDeAreas" TagPrefix="uc3" %>
<%@ Register Src="~/Scripts/BuscadorDePersonas.ascx" TagName="BuscadorDePersonas" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Consulta Rapida</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css"/>   

    <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
   <%-- <fieldset style="text-align: center">
        <legend>Consultas DDJJ 104/2001</legend>
    </fieldset>--%>

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
        Consultas DDJJ 104/2001

        <div id="DivBotonConsultaPorPersona" runat="server" style="display: block; float: right; margin-top: 4px; margin-left: 4px; border: #0055cc;"></div>
        <div id="DivBotonConsultaPorArea" runat="server" style="display: block; float: right; margin-top: 4px; margin-left: 4px; border: #0055cc;"></div>
    </div>

    </div>

    <div id="contenedor_consulta_rapida" style="margin: 30px;">
      
        <div id="divComboDesde">
            <p  style="display: inline-block; margin:auto; margin-right: 10px" >
                Desde:
                <select runat="server" title="Seleccione un mes" id="cmbMesesDesde" 
                    enableviewstate="false" style="text-transform: capitalize;">
                </select>
            </p>
        </div>
        <div id="divComboHasta">
            <p  style="display: inline-block; margin:auto">
                Hasta:
                <select runat="server" title="Seleccione un mes" id="cmbMesesHasta" 
                    enableviewstate="false" style="text-transform: capitalize;">
                </select>
            </p>
        </div>

        <div id="divEstado">
            <p  style="display: inline-block; margin:auto;">
                Estado:
                <select runat="server" title="Estado" id="cmbEstado"
                    enableviewstate="false" style="text-transform: capitalize;">
                </select>
            </p>
        </div>
      
       <div id="divBuscadorArea">
            <uc3:BuscadorDeAreas ID="buscador" runat="server"  style="display: inline-block; margin:auto;" />
       </div>

       <div id="divBuscadorPersona">
            <uc3:BuscadorDePersonas ID="buscadorPersonas" runat="server"  style="display: inline-block; margin:auto;" />
       </div>

    </div>
   
    <div id="DivBotonConsultar" runat="server" style="width: 90%"></div>
    
    <div id="ContenedorGrilla" runat="server" style="width: 100%" align="center">
        <div id="ContenedorPersona" runat="server" style="width: 90%"></div>
    </div>


    <%--<asp:HiddenField ID="hfIdPersona" runat="server" />--%>

    </form>

</body>

<script src="ConsultasDDJJ.js" type="text/javascript"></script>
<script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
<script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
<script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
<script src="../scripts/Spin.js" type="text/javascript"></script>


<script type="text/javascript">
</script>



</html>
