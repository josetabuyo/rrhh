<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlArea.ascx.cs" Inherits="ControlArea" %>
<style type="text/css">
    .area01datos
    {
        font-family: "Humnst777 BT";
        font-size: 11px;
        clear: both;
        float: left;
        margin-top: -10px;
        width: 100%;
        font-weight: normal;
    }
    
    .area01datosresaltados
    {
        font-family: "Humnst777 BT";
        font-size: 13px;
        font-weight: normal;
    }
    
    .area01
    {
        clear: both;
        float: right;  /*margin-top: -400px;*/
        font-family: "Humnst777 BT";
        font-size: 13px;
        font-weight: bold;
        color: #000;
        text-transform: capitalize;
        margin-top: 50px; /*90px;*/
        background-color: #FFF;
        margin-right: 15px;
    }
    
    .botones
    {
        /*position: absolute;*/
        left: 50%;
        width: 840px;
        margin-left: -420px;
        margin-top: 0px;
        background-color: #FFF;
    }
    
    subrayado
    {
        clear: right;
        float: none;
        margin-top: -13px;
        margin-right: 0px;
        margin-left: -420px;
    }
    
        .boton
    {
        margin-top: 5px;
        float: right;
    }
    
</style>


<div>
    <div class="area01">
        
            <asp:Label ID="lblNombreArea" runat="server"></asp:Label>
        
        <p>
            <img src="Imagenes/linea.png" alt="linea" width="600px" height="4px"  /></p>
        <div class="area01datos">
            
            <%--<label>Responsable:</label>--%>
            <asp:Label runat="server" ID="lbResponsable"></asp:Label>
            <br />
            <%--<label>Dirección:</label>--%>
             <asp:Label runat="server" ID="lbDireccion"></asp:Label>
            <br />
            <%--<label>Teléfono:</label>--%>
             <asp:Label runat="server" ID="lbTelefonoArea"></asp:Label>
            <br />
            <%--<label>Mail:</label>--%>
             <asp:Label runat="server" ID="lbMailArea"></asp:Label>
            <asp:Label runat="server" ID="lbAsistentes"></asp:Label>
                    
            
            
            <%  %>
        <div class="boton">
        <asp:Table ID="tablaBoton" runat="server"></asp:Table>
        <%-- <asp:Panel runat="server" ID="Links"></asp:Panel>--%>
            <%--<asp:LinkButton ID="linkbAdministracion" runat="server"><asp:ImageButton Width="99px" Height="13px" ID="img1" ImageUrl="Imagenes/Botones/administrar_s2.png" runat="server"/> <%--<img width="99px" height="13px" src="Imagenes/Botones/administrar_s2.png"/></asp:LinkButton>--%>
        <%--    <asp:LinkButton ID="LinkbModificacion" runat="server"><img width="147px" height="12px" src="Imagenes/Botones/solicitar_modificacion_s2.png"/></asp:LinkButton>--%>
           <%-- <a href="Principal.aspx&IdArea=<%  %>"><img width="99px" height="13px" id="boton" onclick="IrAlArea" src="Imagenes/Botones/administrar_s2.png"/></a>
            <a href="#"><img width="147px" height="12px" id="Img1" onclick="IrAlArea" src="Imagenes/Botones/solicitar_modificacion_s2.png"/></a>--%>
            </div>
        </div>

    </div>
    
</div>


<%--<div >
    <div class="area01">
        <asp:Label ID="lblNombreArea" runat="server"></asp:Label>
        <p>
            <img src="Imagenes/linea.png" alt="linea" width="600px" height="4px"  /></p>
        <div class="area01datos">
            <asp:Table ID="TablaAreasDetalle" runat="server">
            </asp:Table>
        </div>
    </div>
</div>
--%>