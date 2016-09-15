<%@ Page Title="" Language="C#" MasterPageFile="~/MoBi/master/mpMobi.master" AutoEventWireup="true"
    CodeFile="Bienes.aspx.cs" Inherits="MoBi_Bienes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link href="../Protocolo/ConsultaProtocolo.css" rel="stylesheet" type="text/css" />
    <link href="../Protocolo/VistaDeArea.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        table, th, tr, td
        {
            border: 0px none;
        }
        
        .tabla-bienes-emphasis
        {
            font-size: 12px;
            margin: 45px;
            width: 480px;
            text-align: left;
            border-collapse: collapse;
        }
        
        .tabla-bienes-emphasis th
        {
            font-size: 14px;
            font-weight: bold;
            padding: 12px 15px;
        }
        
        .tabla-bienes-emphasis td
        {
            padding: 10px 15px;
            border-top: 1px solid #e8edff;
            cursor: pointer;
            cursor: hand;
        }
        
        .tabla-bienes-emphasis tr:hover td
        {
            background: #eff2ff;
        }
        
        
        .td_leyenda
        {
            text-align: right;
            padding-right: 10px;
            font-size: larger;
        }
        
        .td_item
        {
            text-align: left;
            padding-right: 20px;
        }
        
        .contenedor
        {
            text-align: center;
            margin-top: 5px;
            margin-left: -140px;
            margin-bottom: 25px;
        }
        
        .contenedor table
        {
            margin: auto;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#searchInput").keyup(function () {
                //split the current value of searchInput
                var data = this.value.split(" ");
                //create a jquery object of the rows
                var jo = $(".tabla-bienes-emphasis tbody").find("tr");
                if (this.value == "") {
                    jo.show();
                    return;
                }
                //hide all the rows
                jo.hide();
                //Recusively filter the jquery object to get results.
                jo.filter(function (i, v) {
                    var rowText = this.innerHTML.toLowerCase();
                    if (rowText.indexOf("<th scope=\"col\">") >= 0) return true;
                    for (var d = 0; d < data.length; ++d) {
                        if (rowText.indexOf(data[d].toLowerCase()) >= 0) {
                            return true;
                        }
                    }
                    return false;
                })
                //show the rows that match.
                            .show();
            }).focus(function () {
                this.value = "";
                $(this).css({
                    "color": "black"
                });
                $(this).unbind('focus');
            }).css({
                "color": "#C0C0C0"
            });
        });

        function Show_Bien_Detalle( id_bien ) {
            $('#modal_activar').modal('show');
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <legend class="contenedor">Bienes:
        <input type="text" id="searchInput" class="search" placeholder="Buscar">
    </legend>
    <div class="contenedor">
        <table>
            <tbody>
                <tr>
                    <td class="td_leyenda">
                        Tipo de Bien:
                    </td>
                    <td class="td_item">
                        <asp:DropDownList ID="DropDownListTipoDeBien" runat="server" data-rel="chosen" AutoPostBack="True"
                            OnSelectedIndexChanged="DropDownListTipoDeBien_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="td_leyenda">
                        Incluir dependencias:
                    </td>
                    <td class="td_item">
                        <asp:CheckBox ID="chkIncluirDependencias" runat="server" AutoPostBack="True" Checked="True"
                            OnCheckedChanged="chkIncluirDependencias_CheckedChanged" />
                    </td>
                    <td class="td_leyenda">
                        Areas:
                    </td>
                    <td class="td_item">
                        <asp:DropDownList ID="DropDownAreasUsuario" runat="server" Width="70%" data-rel="chosen"
                            AutoPostBack="True" OnSelectedIndexChanged="DropDownAreasUsuario_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="contenedor">
        <asp:GridView ID="GridViewBienes" runat="server" AutoGenerateColumns="False" Width="80%"
            DataKeyNames="id" CssClass="tabla-bienes-emphasis" 
            onrowdatabound="GridViewBienes_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Bien"></asp:BoundField>
                <asp:BoundField DataField="Estado" HeaderText="Ubicación" />
            </Columns>
            <HeaderStyle />
        </asp:GridView>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="Server">
    <div class="modal hide fade" id="modal_activar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h3>Confirmar Asignación:</h3>
        </div>
        <div class="modal-body">
            <p>¿Confirma asignar el bien seleccionado?</p>
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal"><i class="icon-chevron-left"></i> Cancelar</button>
            <button class="btn btn-success" onclick="recepcionar();" ><i class="icon-ok-circle"></i> Asignar</button>
        </div>
    </div>
</asp:Content>
