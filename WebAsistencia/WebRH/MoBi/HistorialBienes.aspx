<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistorialBienes.aspx.cs"
    Inherits="MoBi_HistorialBienes" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Historia del Vehiculo</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" type="text/css" href="../estilos/estilos.css" />
    <link rel="stylesheet" type="text/css" href="css/BienesDetalle.css" />

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
    </style>

    <link rel="stylesheet" type="text/css" href="../Scripts/ArbolOrganigrama/ArbolOrganigrama.css" />
    <link rel="stylesheet" type="text/css" href="../Estilos/component.css" />
    <link rel="stylesheet" type="text/css" href="../Estilos/SelectorDeAreas.css" />
    <link rel="stylesheet" type="text/css" href="../Scripts/select2-3.4.4/select2.css" />
    <link rel="stylesheet" type="text/css" href="../Protocolo/ConsultaProtocolo.css" />
    <link rel="stylesheet" type="text/css" href="../Protocolo/VistaDeArea.css" />
    <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div style="" align="center">
        <div style="display: block; width: 50%; padding: 0; margin-bottom: 27px; font-size: 19.5px;
            line-height: 36px; color: #333333; border: 0; border-bottom: 1px solid #e5e5e5;
            text-shadow: 2px 2px 5px rgba(150, 150, 150, 1); text-align: center;">
            Movimientos del Bien
        </div>
    </div>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
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
                            <asp:GridView ID="GridViewMovimientos" runat="server" Width="100%" AutoGenerateColumns="False"
                                DataKeyNames="id" CssClass="table table-striped table-bordered table-condensed table-hover">
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
                        </div>
                    </fieldset>
                </div>

            </div>
        </div>
        <!--/span-->
    </div>
    </form>
</body>
<script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
<script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
<script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
<script src="../scripts/Spin.js" type="text/javascript"></script>
<script type="text/javascript">


    $(document).onload(function () {
        var id_bien = localStorage.getItem("idBien");
        alert(id_bien);
        $("#hiddenField_IdBien").value(id_bien);

    });



</script>
</html>
