<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PresentacionDeFacturas.aspx.cs"
    Inherits="FacturasContratos_PresentacionDeFacturas" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/Scripts/BuscadorDeAreas.ascx" TagName="BuscadorDeAreas" TagPrefix="uc3" %>
<%@ Register Src="~/Scripts/BuscadorDePersonas.ascx" TagName="BuscadorDePersonas"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Presentación de Facturas</title>
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
            Presentación de Facturas
            <%--<div id="DivBotonConsultaPorPersona" runat="server" style="display: block; float: right; margin-top: 4px; margin-left: 4px; border: #0055cc;"></div>
        <div id="DivBotonConsultaPorArea" runat="server" style="display: block; float: right; margin-top: 4px; margin-left: 4px; border: #0055cc;"></div>--%>
        </div>
    </div>
    <div id="contenedor_consulta_rapida" style="margin: 30px;">
        <%--<div id="divComboDesde">
            <p  style="display: inline-block; margin:auto" >
                Desde:
                <select runat="server" title="Seleccione un mes" id="cmbMesesDesde" 
                    enableviewstate="false" style="text-transform: capitalize;" >
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
            <p  style="display: inline-block; margin:auto">
                Estado:
                <select runat="server" title="Estado" id="cmbEstado"
                    enableviewstate="false" style="text-transform: capitalize;">
                </select>
            </p>
        </div>
        --%>
        

        <div id="divBuscadorPersona">
            <uc3:BuscadorDePersonas ID="buscadorPersonas1" runat="server" style="display: inline-block; margin: auto;" />
            <input type="button" value="Buscar" class="btn btn-primary" id="btn_BuscarFacturas" />
        </div>
                    <div>
                        <%--<label id="lblcuil">CUIL</label>--%>
                        <%--<input type="text" id="txtCuil" style="width: 270px;" />--%>
                        <label id="lblCuil">
                            CUIL                
                        </label>    
                            <label id="txtCuil">
                        </label>
                    </div>
                    <div>
                        <label id="lblPaseContabilidad">
                            Pase a Contabilidad</label>
                        <input type="text" id="txtPaseContabilidad" style="width: 110px;" placeholder="dd/mm/aaaa"/>
                    </div>
                    <div>
                        <label id="lblFechaFactura">
                            Fecha de Factura</label>
                        <input type="text" id="txtFechaFactura" style="width: 110px;" placeholder="dd/mm/aaaa"/>
                    </div>
                    <div>
                        <label id="lblNroFactura">
                            Nro de Factura</label>
                        <input type="text" id="txtNroFactura" style="width: 110px;" placeholder="ej: 1111-11111111" />
                    </div>
                    <div>
                        <label id="lblMontoFactura">
                            Monto de Factura</label>
                        <input type="text" id="txtMontoFactura" style="width: 110px;" />
                        <label id="lblMontoPendiente"></label>
                    </div>
                    <div>
                        <label id="lblFechaRecibida">
                            Fecha Recibida</label>
                        <input type="text" id="txtFechaRecibida" style="width: 110px;" placeholder="dd/mm/aaaa" />
                    </div>
                    <div id="divBuscadorArea">
                        <uc3:BuscadorDeAreas ID="buscadorArea1" runat="server"  style="display: inline-block; margin:auto;" />
                    </div>
                    <div>
                        <label id="lblFirmante">Firmante</label>
                        <select runat="server" title="Seleccione un mes" id="cboFirmante" 
                            enableviewstate="false" style="text-transform: capitalize;" >
                        </select>
                    </div>
        </div>

        <div id="ContenedorGrilla" runat="server" style="width: 50%" align="center">
            <div id="ContenedorPersona" runat="server" style="width: 50%">
            </div>
        </div>


        <input type="button" value="Guardar" class="btn btn-primary" id="btn_Guardar" />

        <%--<div style="width: 100%">
        <div id="DivBotonConsultar" runat="server" style="display: block; float: left;margin-left: 5px;" ></div>  
        <div id="DivBotonExcel" runat="server" style="display: block; float: right; margin-right: 5px;"></div>  
            </div>--%>
        <%--<div id="ContenedorGrilla" runat="server" style="width: 100%" align="center">
        <div id="ContenedorPersona" runat="server" style="width: 90%"></div>
            </div>--%>
        <%--<asp:HiddenField ID="hfIdPersona" runat="server" />--%>
    </form>
</body>

<%--<script src="ConsultasDDJJ.js" type="text/javascript"></script>--%>
<script type="text/javascript" src="PresentacionFacturas.js"></script>
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
            inputPaseContabilidad: $('#txtPaseContabilidad'),
            inputFechaFactura: $('#txtFechaFactura'),
            inputFechaRecibida: $('#txtFechaRecibida')

        }
        var panel_alta = new PanelAltaDeDocumento(cfg_panel_alta);


    });
    </script>   

</html>
