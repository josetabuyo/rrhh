<%@ Page Title="" Language="C#" MasterPageFile="~/MoBi/master/mobi.master" AutoEventWireup="true"
    CodeFile="BienesDisponibles.aspx.cs" Inherits="MoBi_BienesDisponibles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .radio {
            padding: 0px;
         }
         
         .radio {
             padding-top: 4px;
         }
         
    
    </style>
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
                            <asp:DropDownList ID="DropDownListTipoDeBien" runat="server" Width="90%" 
                                data-rel="chosen" AutoPostBack="True" 
                                onselectedindexchanged="DropDownListTipoDeBien_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="control-group">
						<label class="control-label">Áreas</label>
						<div class="controls">
							<label class="radio" style="padding-left: 0;">
							    <div class="radio" style="padding-left: 0;">
                                    <asp:RadioButton ID="rbTodasLasAreas2" runat="server" GroupName="gnMostrarAreas" 
                                        Checked="true" AutoPostBack="True" 
                                        oncheckedchanged="rbTodasLasAreas_CheckedChanged" />
                                </div>
							    Mostrar solo las áreas con bienes.
							</label>
							<div style="clear:both"></div>
							<label class="radio" style="padding-left: 0;">
							    <div class="radio" style="padding-left: 0;">
                                    <asp:RadioButton ID="rbAreasConBienes" runat="server" GroupName="gnMostrarAreas" 
                                    AutoPostBack="True" oncheckedchanged="rbAreasConBienes_CheckedChanged" />
                                </div>
							    Mostrar todas las áreas.
							</label>
							<div style="clear:both"></div>
						</div>
					</div>

                    <div class="control-group">
                        <label class="control-label" for="selectError3">
                            </label>
                        <div class="controls">
                            <asp:DropDownList ID="DropDownAreasUsuario" runat="server" Width="90%" 
                                data-rel="chosen" AutoPostBack="True" 
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
                            DataKeyNames="id" OnRowCommand="GridViewBienes_RowCommand" CssClass="table table-striped table-bordered bootstrap-datatable">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id"></asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Item"></asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado / Ult. Evento" />
                                <asp:BoundField DataField="UltMov" HeaderText="Fecha" />
                                <asp:BoundField DataField="Remitente" HeaderText="Área / Agente" />
                                <asp:BoundField DataField="Asignacion" HeaderText="Resp. Asignación" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbMovimiento" runat="server" CssClass="btn btn-success" ToolTip="Ver movimientos del bien"
                                            CommandName="MOV" CommandArgument='<%# Container.DataItemIndex %>'><i style="font-size: large;" class='icon-calendar'></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbAsignar" runat="server" CssClass="btn btn-info" ToolTip="Asignar bien"
                                            CommandName="ASIG" CommandArgument='<%# Container.DataItemIndex %>'><i style="font-size: large;" class='icon-share'></i></asp:LinkButton>
                                        <a class="btn btn-info btnVerBien" style="width: 16px;"><i style="font-size: large;" class='icon-edit'></i></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="alert alert-info">
							        <button type="button" class="close" data-dismiss="alert">×</button>
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

    <div id="pantalla_edicion_bien">
        <label class="lbl_nombre_atributo"> Descripcion:</label>
        <div id="ed_descripcion_bien"></div>
        <div id="ed_contenedor_imagenes"></div>
        <div id="btn_add_imagen"> + </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="Server">
</asp:Content>
