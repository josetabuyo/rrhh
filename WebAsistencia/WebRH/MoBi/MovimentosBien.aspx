<%@ Page Title="" Language="C#" MasterPageFile="~/MoBi/master/mobi.master" AutoEventWireup="true"
    CodeFile="MovimentosBien.aspx.cs" Inherits="MoBi_MovimentosBien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="Default.aspx">Módulo Bienes</a><i class="icon-angle-right">
        </i></li>
        <li><i class="icon-check"></i><a href="BienesDisponibles.aspx">Bienes Asignados</a><i
            class="icon-angle-right"> </i></li>
        <li><i class="icon-calendar"></i><a href="#">Movimientos</a></li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header" data-original-title="">
                <h2>
                    <i class="icon-calendar"></i><span class="break"></span>Movimientos del Bien</h2>
                <div class="box-icon">
                    <a href="#" class="btn-minimize"><i class="icon-chevron-down"></i></a><a href="#"
                        class="btn-close"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <div id="div1" class="form-horizontal" runat="server">
                <fieldset>
                    <asp:HiddenField ID="HiddenField_IdBien" runat="server" />
                    <div class="control-group">
                        <label class="control-label" for="disabledInput">
                            Tipo de Bien:
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtTipoBien" runat="server" CssClass="input-xlarge disabled" type="text"
                                placeholder="" disabled="" Width="90%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="disabledInput">
                            Item:
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtItem" runat="server" CssClass="input-xlarge disabled" type="text"
                                placeholder="" disabled="" Width="90%"></asp:TextBox>
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
                        <asp:GridView ID="GridViewMovimientos" runat="server" Width="100%" AutoGenerateColumns="False"
                            DataKeyNames="id" CssClass="table table-striped table-bordered bootstrap-datatable">
                            <Columns>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha"></asp:BoundField>
                                <asp:BoundField DataField="TipoEvento" HeaderText="Evento" />
                                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                                <asp:BoundField DataField="Area" HeaderText="Área" />
                                <asp:BoundField DataField="Responsable" HeaderText="Responsable" />
                                <asp:BoundField DataField="Operador" HeaderText="Operador" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="alert alert-info">
                                    <button type="button" class="close" data-dismiss="alert">
                                        ×</button>
                                    <h4 class="alert-heading">
                                        Atención!</h4>
                                    <p>
                                        El itém seleccionado no presenta movimientos.</p>
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
                <div class="box-content" style="text-align: center">
                        <asp:LinkButton ID="lkBtn" runat="server" class='btn btn-small' 
                        onclick="lkBtn_Click" ><i class='icon-arrow-left'></i> Atrás</asp:LinkButton>

                </div>
            </div>
    </div>
    <!--/span-->
    </div>
</asp:Content>
