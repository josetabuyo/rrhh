<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistorialBienes.aspx.cs" Inherits="MoBi_HistorialBienes" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Detalle de Vehiculo</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/BienesDetalle.css" />
      <link  href="css/style.css" rel="stylesheet">
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
            Historial de Movimientos del Bien
          <%--  <div id="DivBotonMovimientos" runat="server" style="display: block; float: right;
                margin-top: 4px; margin-left: 4px; border: #0055cc;">
                <asp:Button runat="server" ID="btnMovimientos" CssClass="btn btn-primary" Text="Consultar movimientos" /> 
            </div>--%>
            
        </div>
    </div>
    <%--<div class="contenedor_principal contenedor_principal_seleccion_areas">
        <div id="titulo_areas_a_administrar" style="text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);">
            Vehiculo                 
            <a id="btn_consultar_historia" class="btn btn-primary" href="MovimentosBien.aspx">Historial</a>
        </div>
    </div>--%>



<%--    <label class="lbl_nombre_atributo">Descripcion:</label>
    <div id="ed_descripcion_bien"></div>
    <div id="ed_contenedor_imagenes"></div>
    <div id="btn_add_imagen">+</div>
    <div id="Contenido">


       
    </div>--%>
    
    
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
    
    
    
    </form>
</body>




<script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
<script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
<script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
<script src="../scripts/Spin.js" type="text/javascript"></script>
<%--<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>--%>
<%--<script type="text/javascript" src="../Scripts/ControlesImagenes/SubidorDeImagenes.js"></script>--%>
<%--<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>--%>
<%--<script type="text/javascript" src="js/BienesDetalle.js"></script>--%>
<script type="text/javascript">


    $(document).onload(function () {


        var id_bien = localStorage.getItem("idBien");

        alert(id_bien);
      

        $("#hiddenField_IdBien").value(id_bien);

    });



</script>
</html>
