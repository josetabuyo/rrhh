<%@ Page Title="" Language="C#" MasterPageFile="~/MoBi/master/mobi.master" AutoEventWireup="true"
    CodeFile="BienesDisponibles.aspx.cs" Inherits="MoBi_BienesDisponibles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .radio
        {
            padding: 0px;
            padding-top: 4px;
        }
        
        .tr_hover
        {
            background-color: #FFFF99;
        }
        
        .tr_transito
        {
            background-color: #EFF5FB;
        }
        
        .table-striped tbody > tr:nth-child(odd) > td
        {
            background-color: transparent;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            /*
            $('table tr').hover(function () {
            $(this).addClass('tr_hover');
            }, function () {
            $(this).removeClass('tr_hover');
            });
            */
            $(".bootstrap-datatable tr:has(td)").each(function () {
                var t = $(this).text().toLowerCase();
                if (t.indexOf("en tránsito") > -1) $(this).addClass('tr_transito');
            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="Default.aspx">Módulo Bienes</a> <i class="icon-angle-right">
        </i></li>
        <li><i class="icon-check"></i><a href="#">Bienes Asignados</a></li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header" data-original-title="">
                <h2>
                    <i class="icon-check"></i><span class="break"></span>Bienes Disponibles</h2>
                <div class="box-icon">
                    <a href="#" class="btn-minimize"><i class="icon-chevron-down"></i></a><a href="#"
                        class="btn-close"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <div id="div1" class="form-horizontal" runat="server">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="selectError3">
                                Tipo de bien</label>
                            <div class="controls">
                                <asp:DropDownList ID="DropDownListTipoDeBien" runat="server" Width="90%" data-rel="chosen"
                                    AutoPostBack="True" OnSelectedIndexChanged="DropDownListTipoDeBien_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                Áreas</label>
                            <div class="controls">
                                <label class="checkbox inline">
                                    <asp:CheckBox ID="chkIncluirDependencias" runat="server" AutoPostBack="True" Checked="True"
                                        OnCheckedChanged="chkIncluirDependencias_CheckedChanged" />
                                    Incluir dependencias
                                </label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="selectError3">
                            </label>
                            <div class="controls">
                                <asp:DropDownList ID="DropDownAreasUsuario" runat="server" Width="90%" data-rel="chosen"
                                    AutoPostBack="True" OnSelectedIndexChanged="DropDownAreasUsuario_SelectedIndexChanged">
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
                                DataKeyNames="id" OnRowCommand="GridViewBienes_RowCommand" CssClass="table table-striped table-bordered bootstrap-datatable">
                                <Columns>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Item"></asp:BoundField>
                                    <asp:BoundField DataField="Estado" HeaderText="Ubicación" />
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbMovimiento" runat="server" CssClass="btn btn-webrh" ToolTip="Ver movimientos del bien"
                                                CommandName="MOV" CommandArgument='<%# Container.DataItemIndex %>'><i class='icon-calendar icon-btn' style="color: #81BEF7"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lbAsignar" runat="server" CssClass="btn btn-webrh" ToolTip="Asignar bien"
                                                CommandName="ASIG" CommandArgument='<%# Container.DataItemIndex %>'><i class='icon-share icon-btn' style="color: #86B404"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="alert alert-info">
                                        <button type="button" class="close" data-dismiss="alert">
                                            ×</button>
                                        <strong>¡Sin registros!</strong> No existen bienes en el área.
                                    </div>
                                </EmptyDataTemplate>
                                <RowStyle BorderColor="Silver" />
                            </asp:GridView>
                            <div class="my-navigation">
                                <a class="simple-pagination-first"></a><a class="simple-pagination-previous"></a>
                                <a class="simple-pagination-page-numbers"></a><a class="simple-pagination-next">
                                </a><a class="simple-pagination-last"></a>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <!--/span-->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="Server">
</asp:Content>
