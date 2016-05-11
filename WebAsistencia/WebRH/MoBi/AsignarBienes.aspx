<%@ Page Title="" Language="C#" MasterPageFile="~/Mobi/master/mobi.master" AutoEventWireup="true"
    CodeFile="AsignarBienes.aspx.cs" Inherits="MoBi_AsignarBienes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/jscript">
        function load() {
            $('#liMenu2').removeClass("active");
            $('#liMenu1').addClass("active");
        }
        window.onload = load;

        function show_asignar() {
            $('#modal_activar').modal('show');
        }

        function recepcionar() {
            $("#btnAsignar").click();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="Default.aspx">Módulo Bienes</a><i class="icon-angle-right">
        </i></li>
        <li><i class="icon-check"></i><a href="BienesDisponibles.aspx">Bienes Asignados</a><i
            class="icon-angle-right"> </i></li>
        <li><i class="icon-share"></i><a>Asignar Bienes</a></li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header" data-original-title="">
                <h2>
                    <i class="icon-share"></i><span class="break"></span>Asignar Bien</h2>
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
                            Área / Agente Origen:
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtArea" runat="server" CssClass="input-xlarge disabled" type="text"
                                Width="90%" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="disabledInput">
                            Tipo de Bien:
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtTipoBien" runat="server" CssClass="input-xlarge disabled" type="text"
                                Width="90%" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="disabledInput">
                            Item:
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtItem" runat="server" CssClass="input-xlarge disabled" type="text"
                                Width="90%" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="selectError3">
                            Área Destino</label>
                        <div class="controls">
                            <asp:DropDownList ID="DropDownAreasDestino" runat="server" Width="90%" OnSelectedIndexChanged="DropDownAreasDestino_SelectedIndexChanged"
                                AutoPostBack="True" data-rel="chosen">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:CheckBox ID="checkAgenteDestino" runat="server" AutoPostBack="True" 
                                oncheckedchanged="checkAgenteDestino_CheckedChanged" />
                            Habilitar la asignacion a un agente
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:DropDownList ID="DropDownAgenteDestino" runat="server" Width="90%" 
                                Visible="False" data-rel="chosen">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="disabledInput">
                            Observaciones:
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="input-xlarge" type="text"
                                Width="90%" MaxLength="32" ></asp:TextBox>
                        </div>
                    </div>

                </fieldset>
                <div class="form-actions">
                    <a class="btn btn-primary" title="Recepcionar bien." onclick="show_asignar();">Asignar Bien</a>
                    <asp:Button ID="btnCancekar" runat="server" Text="Cancelar" type="reset" class="btn"
                        OnClick="btnCancekar_Click" />
                </div>
                <asp:Button ID="btnAsignar" runat="server" onclick="btnAsignar_Click" ClientIDMode="Static" style="display:none;" />
                </div>
                <br />
            </div>

        </div>
        <!--/span-->
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
