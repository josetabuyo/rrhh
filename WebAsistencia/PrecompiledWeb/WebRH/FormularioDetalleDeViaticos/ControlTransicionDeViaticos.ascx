<%@ control language="C#" autoeventwireup="true" inherits="FormularioDetalleDeViaticos_WebUserControl, App_Web_jo0z5gbo" %>

    <div class="tituloControlTransiciones">
    <asp:Label runat="server" ID="label_titulo" Text= "Gestión de la Comisión de Servicio" />
    </div>
    <div class="accesoDirecto">
        <asp:Button ID="Btn_AccesoDirectoAprobar" runat="server" Text="Button" 
            class="btn btn-primary" onclick="Btn_AccesoDirectoAprobar_Click"/>
    </div>
    <div id="PanelAccesoDirectoModificar" class="panelControlTransiciones">
        <asp:Button ID="Btn_AccesoDirectoSolicitarModificacion" runat="server" Text="Button" 
            class="btn btn-primary" onclick="Btn_AccesoDirectoSolicitarModificacion_Click"/>
            <asp:DropDownList ID="cmbAreasTransicionesAnteriores" class="dropdown" runat="server">
            </asp:DropDownList>
    </div>
    <div id="PanelAccion" class="panelControlTransiciones">
        <div class="tituloPanelControlTransiciones">
            <asp:Label ID="Label1" class="label" runat="server" Text="Acción">
            </asp:Label>
        </div>
        <div class="contenidoPanelControlTransiciones">
            <asp:DropDownList ID="cmbAccion" class="dropdown" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <div id="PanelAreas" class="panelControlTransiciones">
        <div class="tituloPanelControlTransiciones">
            <asp:Label ID="Label2" class="label" runat="server" Text="Área Destino">
            </asp:Label>
        </div>
        <div class="contenidoPanelControlTransiciones">
                <input id="SelectorDeAreas" type="text" class="span3" 
                    data-provide="typeahead" 
                    data-items="9" />
        </div>
    </div>   
    <div id="PanelComentarios" class="panelControlTransiciones">
        <div class="tituloPanelControlTransiciones">
            <asp:Label ID="Label3" class="label" runat="server" Text="Comentarios">
            </asp:Label>
        </div>
        <div class="contenidoPanelControlTransiciones">
            <asp:TextBox ID="txtComentarios" class="span3" runat="server" TextMode="MultiLine" />
        </div>
    </div>          
    
    <div id="AlertaTransicionInvalida" class="alert  alert-error" style="clear:both;" runat="server">
        <a class="close" data-dismiss="alert">×</a> <strong>Error</strong>
    </div>

    <asp:Button ID="btnEnviar" class="btn btn-primary" runat="server" Text="Enviar"
        OnClick="btnEnviar_Click" 
        EnableViewState="False" />       

    <asp:HiddenField ID="AreaSeleccionada" runat="server" />
    <asp:HiddenField ID="ListaAreas" runat="server" />
    
    <script type="text/javascript" src="../bootstrap/js/jquery.js">    
    </script>
    <script type="text/javascript">
        $('#SelectorDeAreas').attr('data-source', $('#<%= ListaAreas.ClientID %>').val());
        $('#SelectorDeAreas').attr("autocomplete", "off");
        //$('#SelectorDeAreas').blur(function () { alert($('#SelectorDeAreas').data().typeahead.$menu.find('.active').data().item.value); });
        $('#SelectorDeAreas').blur(function () {
            $('#<%= AreaSeleccionada.ClientID %>').val($('#SelectorDeAreas').data().typeahead.$menu.find('.active').data().item.value);
        });
        function txtComentarios_onclick() {

        }

    </script>