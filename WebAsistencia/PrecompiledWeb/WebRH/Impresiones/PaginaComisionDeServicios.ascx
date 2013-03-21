<%@ control language="C#" autoeventwireup="true" inherits="Impresiones_PaginaComisionDeServicios, App_Web_bmi1lyey" %>


<%@ Register Src="~/FormularioDetalleDeViaticos/ControlDetalleDeViaticos.ascx" TagName="ControlDetalleDeViaticos" TagPrefix="uc1" %>


<div style="width: 100%" align="center">
    <asp:Image ID="ImgBarcode" runat="server" Height="16px" />
    <br />    
    <div class="container" ID="PanelPaginaComision" runat="server" align="left" style="width: 100%"></div>
</div>
