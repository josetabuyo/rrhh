<%@ Page Title="" Language="C#" MasterPageFile="~/MoBi/master/mpMobi.master" AutoEventWireup="true"
    CodeFile="Bienes.aspx.cs" Inherits="MoBi_Bienes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="Reportes.css" />
    <link rel="stylesheet" type="text/css" href="../Scripts/ArbolOrganigrama/ArbolOrganigrama.css" />
    <link rel="stylesheet" type="text/css" href="../Estilos/component.css" />
    <link rel="stylesheet" type="text/css" href="../estilos/SelectorDeAreas.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/select2-3.4.4/select2.css" />
    <%= Referencias.Javascript("../")%>
    <link href="../Protocolo/ConsultaProtocolo.css" rel="stylesheet" type="text/css" />
    <link href="../Protocolo/VistaDeArea.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        table, th, tr, td
        {
            border: 0px none;
        }
        
        .table-hover td
        {
            cursor: pointer;
        }
        
        .table-hover th
        {
            font-family: "Humnst777 BT" !important;
            font-size: 11px !important;
            background-color: #003 !important;
            color: #FFF !important;
            text-align: center !important;
            border-left: 1px solid black;
            border-right: 1px solid black;
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
            font-family: Calibri,Verdana,Arial;
        }
        
        .contenedor table
        {
            margin: auto;
        }
        
        .Detalle
        {
            width: 25px;
            height: 25px;
            padding: 2px;
        }
        
        .Detalle:hover
        {
            background-color: #58ACFA;
        }
        
        .active-result
        {
            font-size: x-small;
        }
        
        legend input 
        {
            margin-left: 10px;
        }
        
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#searchInput").keyup(function () {
                //split the current value of searchInput
                var data = this.value.split(" ");
                //create a jquery object of the rows
                var jo = $(".table-hover tbody").find("tr");
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

        function Deseleccionar_Todo() {
            var celdas = $(".table-hover tbody").find("tr").find("td");
            celdas.removeClass('celda_seleccionada');
            celdas.removeClass('celda_on_hover');
        }

        function Seleccionar_Row(row_sel) {
            Deseleccionar_Todo();
            $(row_sel).find("td").addClass('celda_seleccionada');
        }


        function Show_Detalle_Bien(id_bien, verificacion) {
            localStorage.setItem("idBien", id_bien);
            localStorage.setItem("verificacion", verificacion);            
            window.location.href = 'BienesDetalle.aspx';
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <legend class="contenedor" style="margin-left: -30px; text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);" >
            Bienes:
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
                        <asp:DropDownList ID="DropDownAreasUsuario" runat="server" Width="550px" data-rel="chosen"
                            AutoPostBack="True" OnSelectedIndexChanged="DropDownAreasUsuario_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="contenedor">
        <asp:GridView ID="GridViewBienes" runat="server" AutoGenerateColumns="False" Width="80%"
            DataKeyNames="id,verificacion" CssClass="table table-striped table-bordered table-condensed table-hover"
            OnRowDataBound="GridViewBienes_RowDataBound">
            <Columns>
                <asp:BoundField DataField="descripcion" HeaderText="Bien"></asp:BoundField>
                <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" />
                <asp:TemplateField HeaderText="" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="Server">
    <div class="modal hide fade" id="modal_activar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Confirmar Asignación:</h3>
        </div>
        <div class="modal-body">
            <p>
                ¿Confirma asignar el bien seleccionado?</p>
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal">
                <i class="icon-chevron-left"></i>Cancelar</button>
            <button class="btn btn-success" onclick="recepcionar();">
                <i class="icon-ok-circle"></i>Asignar</button>
        </div>
    </div>
</asp:Content>
