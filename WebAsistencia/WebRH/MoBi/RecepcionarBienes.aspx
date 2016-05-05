<%@ Page Title="" Language="C#" MasterPageFile="~/MoBi/master/mobi.master" AutoEventWireup="true"
    CodeFile="RecepcionarBienes.aspx.cs" Inherits="MoBi_RecepcionarBienes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/jscript">
        function load() {
            $('#liMenu1').removeClass("active");
            $('#liMenu2').addClass("active");
        }
        window.onload = load;

        function show_recepcion(indexGrid, aceptar) {
            $("#hfIndexGrid").val(indexGrid);
            if (aceptar == 1)
                $('#modal_desactivar').modal('show');
            else
                $('#modal_activar').modal('show');
        }

        function recepcionar() {
            $("#hfObservaciones").val($("#txt_obs_recep").val());
            $("#btnRecepcionar").click();
        }

        function rechazar() {
            $("#hfObservaciones").val($("#txt_obs_rech").val());
            $("#btnRechazar").click();
        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="Default.aspx">Módulo Bienes</a> <i class="icon-angle-right">
        </i></li>
        <li><i class="icon-inbox"></i><a href="#">Recepcionar Bienes</a></li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header" data-original-title="">
                <h2>
                    <i class="icon-inbox"></i><span class="break"></span>Recepcionar Bienes</h2>
                <div class="box-icon">
                    <a href="#" class="btn-minimize"><i class="icon-chevron-down"></i></a><a href="#"
                        class="btn-close"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <form id="Form1" class="form-horizontal" runat="server">
                <fieldset>
                    <div class="control-group">
                        <label class="control-label" for="selectError3">
                            Tipo de bien</label>
                        <div class="controls">
                            <asp:DropDownList ID="DropDownListTipoDeBien" runat="server" Width="90%" 
                                data-rel="chosen"
                                AutoPostBack="True" 
                                onselectedindexchanged="DropDownListTipoDeBien_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="selectError3">
                            Área</label>
                        <div class="controls">
                            <asp:DropDownList ID="DropDownAreasUsuario" runat="server" Width="90%" 
                                data-rel="chosen"
                                AutoPostBack="True" 
                                onselectedindexchanged="DropDownAreasUsuario_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- style="display: none;" -->
                    <div class="row-fluid hideInIE8 circleStats" style="display: none;">
                        <div class="span2" ontablet="span4" ondesktop="span2">
                            <div class="circleStatsItemBox blue">
                                <div class="header">
                                    Memory</div>
                                <span class="percent">percent</span>
                                <div class="circleStat">
                                    <input type="text" value="35" class="whiteCircle" />
                                </div>
                                <div class="footer">
                                    <span class="count"><span class="number">64</span> <span class="unit">GB</span>
                                    </span><span class="sep">/ </span><span class="value"><span class="number">64</span>
                                        <span class="unit">GB</span> </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-content" style="margin-top: -5px;" id="first-container">
                        Filtrar resultados
                        <div class="input-prepend" style="padding-left: 10px; padding-right: 20px;">
                            <span class="add-on"><i class="icon-filter"></i></span>
                            <input id="texto" size="16" type="text" />
                        </div>
                        Mostrar
                        <div class="input-prepend" style="padding-left: 10px; padding-right: 10px;">
                            <span class="add-on"><i class="icon-eye-open"></i></span>
                            <select class="simple-pagination-items-per-page">
                            </select>
                        </div>
                        items por página.
                        <asp:GridView ID="GridViewBienes" runat="server" Width="100%" AutoGenerateColumns="False"
                            DataKeyNames="id"
                            CssClass="table table-striped table-bordered bootstrap-datatable">
                            <Columns>
                                <asp:BoundField DataField="Descripcion" HeaderText="Item"></asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado Asignación / Observaciones" />
                                <asp:BoundField DataField="UltMov" HeaderText="Fecha de Envío" />
                                <asp:BoundField DataField="Remitente" HeaderText="Área / Agente Destino" />
                                <asp:BoundField DataField="Asignacion" HeaderText="Operador" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <a class="btn btn-success" title="Recepcionar bien." onclick="show_recepcion(<%# Container.DataItemIndex %>, 0);"><i class="icon-ok-circle"></i></a>
                                        <a class="btn btn-danger" title="Rechazar bien." onclick="show_recepcion(<%# Container.DataItemIndex %>, 1);"><i class="icon-ban-circle"></i></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="alert alert-info">
							        <button type="button" class="close" data-dismiss="alert">×</button>
							        <strong>¡Sin registros!</strong> No existen bienes para recibir en el área.
						        </div>
                            </EmptyDataTemplate>
                            <RowStyle BorderColor="Silver" />
                        </asp:GridView>
                        <div class="my-navigation">
                            <a class="simple-pagination-first"></a><a class="simple-pagination-previous"></a>
                            <a class="simple-pagination-page-numbers"></a><a class="simple-pagination-next">
                            </a><a class="simple-pagination-last"></a>
                        </div>
                            <asp:HiddenField ID="hfIndexGrid" runat="server" ClientIDMode="Static"/>
                            <asp:HiddenField ID="hfObservaciones" runat="server" ClientIDMode="Static"/>
                            <asp:Button ID="btnRecepcionar" runat="server" onclick="btnRecepcionar_Click" ClientIDMode="Static" style="display:none;" />
                            <asp:Button ID="btnRechazar" runat="server" onclick="btnRechazar_Click" ClientIDMode="Static" style="display:none;" />
                    </div>
                </fieldset>
                </form>
            </div>
        </div>
        <!--/span-->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="Server">
    <div class="modal hide fade" id="modal_activar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h3>Recepcionar Bien:</h3>
        </div>
        <div class="modal-body">
            <p>¿Confirma recepcionar el bien en tránsito?</p>
            Observaciones: <input id="txt_obs_recep" type="text" maxlength="32" style="width: 98%" />
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal"><i class="icon-chevron-left"></i> Cancelar</button>
            <button class="btn btn-success" onclick="recepcionar();" ><i class="icon-ok-circle"></i> Recepcionar</button>
        </div>
    </div>

    <div class="modal hide fade" id="modal_desactivar">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">×</button>
            <h3>Rechazar Bien:</h3>
        </div>
        <div class="modal-body">
            <p>¿Confirma rechazar el bien en tránsito?</p>
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal"><i class="icon-chevron-left"></i> Cancelar</button>
            <button class="btn btn-danger" onclick="rechazar();"><i class="icon-ban-circle"></i> Rechazar</button>
        </div>
    </div>

</asp:Content>
