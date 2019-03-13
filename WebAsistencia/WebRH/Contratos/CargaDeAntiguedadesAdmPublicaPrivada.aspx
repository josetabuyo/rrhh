<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CargaDeAntiguedadesAdmPublicaPrivada.aspx.cs"
    Inherits="Contratos_CargaDeAntiguedadesAdmPublicaPrivada" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Servicio Administracion Publica/Privada</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css" />
    <%= Referencias.Javascript("../")%>
</head>


<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu1" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div>
        <div style="margin-top: 40px" align="center" >
            <div style="display: block; width: 50%; padding: 0; margin-bottom: 27px; font-size: 19.5px;
                line-height: 36px; color: #333333; border: 0; border-bottom: 1px solid #e5e5e5;
                text-shadow: 2px 2px 5px rgba(150, 150, 150, 1); text-align: left;">
                <asp:Label ID="lblTitulo" runat="server" Text="" />
            </div>
        </div>
                
            <div>
                <asp:Label ID="lblAmbito" runat="server" Text="Ambito " />
                <select runat="server" id="cmbAmbitos" name="Ambitos" enableviewstate="false" style="text-transform: capitalize;"></select>
            </div>
        
            <div>
                <asp:Label ID="lblFolio" runat="server" Text="Folio " />
                <input type="text" id="NroFolio" value="00" style="width: 36px" />
                -
                <input type="text" id="NroFolioDesde" value="000" style="width: 40px" />
                -
                <input type="text" id="NroFolioHasta" value="000" style="width: 40px" />
            </div>

            <div>
                <asp:Label ID="lblJurisdiccion" runat="server" Text="Jurisdicción " />
                <input type="text" id="txtJurisdiccion" value="" style="width: 400px" />
            </div>

            <div>
                <asp:Label ID="lblCaja" runat="server" Text="Caja de Previsión " />
                <input type="text" id="txtCaja" value="" style="width: 400px" />
            </div>

            <div>
                <asp:Label ID="lblNroAfiliacion" runat="server" Text="Nro de Afiliación " />
                <input type="text" id="txtNroAfiliacion" value="" style="width: 400px" />
            </div>

            <div id='Remunerado'>
                <asp:Label ID="lblRemunerado" runat="server" Text="Remunerado " />
                <br/>
                <input type="radio" id="rdRemuneradoSI" value="1" name="Remunerado" /> SI
                <br/>
                <input type="radio" id="rdRemuneradoNO" value="0" name="Remunerado" /> NO (Ad Honorem)  
            </div>
            <br/>
            <div id='TipoDocumento'>
                <asp:Label ID="lblTipoDocumento" runat="server" Text="Tipo Documento" />
                <br/>
                <input type="radio" id="rdTipoDocumentoCTR" value="1" name="TipoDocumento" /> Contrato        
                <br/>
                <input type="radio" id="rdTipoDocumentoCER" value="0" name="TipoDocumento" /> Cert. de Serv.  
                <br/>
                <input type="radio" id="rdTipoDocumentoOTR" value="2" name="TipoDocumento" /> Otros
            </div>
        

        <br /><br />

        <div style="border: thin solid #3366FF; width:95%" >
            <%--Organismo--%>
            <asp:Label ID="lblOrganismo" runat="server" Text="Organismo " />
            <input type="text" id="txtOrganismo" value="" style="width: 400px; margin-right: 10px" />
            <%--Cargo--%>
            <asp:Label ID="lblCargo" runat="server" Text="Cargo " />
            <select runat="server" id="cmbCargo" name="Cargo" enableviewstate="false" style="text-transform: capitalize;margin-right: 10px"></select>
            <%--Desde--%>
            <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha Desde " />
            <input type="text" id="txtFechaDesde" style="width: 110px; ; margin-right: 10px" placeholder="dd/mm/aaaa" />
            <%--Hasta--%>
            <asp:Label ID="lblFechaHasta" runat="server" Text="Fecha Hasta " />
            <input type="text" id="txtFechaHasta" style="width: 110px; margin-right: 20px" placeholder="dd/mm/aaaa" />
            <%--Domicilio--%>
            <br/>
            <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio " />
            <input type="text" id="txtDomicilio" value="" style="width: 400px" />
            <br/>
            <input type="button" value="Agregar" class="btn btn-primary" id="btn_Agregar" />
            

            <br />
            <div id="ContenedorGrilla" runat="server" style="width: 95%" align="center">
                <div id="ContenedorServicios" runat="server" style="width: 95%"></div>
            </div>
        </div>


            <br/>
            <div>
                <asp:Label ID="lblCausaEgreso" runat="server" Text="Causa de Egreso " />
                <input type="text" id="txtCausaEgreso" value="" style="width: 400px" />
            </div>

            <input type="checkbox" id="DarDeBaja" name="DarDeBaja"  /> Dar de Baja

            <br /><br />
            <input type="button" value="Guardar" class="btn btn-primary" id="btn_Guardar" />

        

    </div>
    </form>
</body>
<script type="text/javascript" src="CargaDeAntiguedadesAdmPublicaPrivada.js"></script>
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
            inputFechaDesde: $('#txtFechaDesde'),
            inputFechaHasta: $('#txtFechaHasta'),
        }
        var panel_alta = new PanelFechas(cfg_panel_alta);


    });
</script>


</html>
