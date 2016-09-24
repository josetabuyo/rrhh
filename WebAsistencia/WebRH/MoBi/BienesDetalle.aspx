<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BienesDetalle.aspx.cs" Inherits="MoBi_BienesDetalle" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Detalle de Vehiculo</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/BienesDetalle.css" />
    <%= Referencias.Javascript("../")%>
</head>
<body>



    <form id="form1" runat="server">
    <asp:HiddenField ID="hidden_idBien" runat="server" />
    <input type ="hidden" id = "hid" runat="server" />


    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div style="" align="center">
        <div style="display: block; width: 50%; padding: 0; margin-bottom: 27px; font-size: 19.5px;
            line-height: 36px; color: #333333; border: 0; border-bottom: 1px solid #e5e5e5;
            text-shadow: 2px 2px 5px rgba(150, 150, 150, 1); text-align: left;">
            Detalle de Vehiculo
            <div id="DivBotonMovimientos" runat="server" style="display: block; float: right;
                margin-top: 4px; margin-left: 4px; border: #0055cc;">
                <asp:Button runat="server" ID="btnMovimientos" CssClass="btn btn-primary" 
                    Text="Consultar movimientos" UseSubmitBehavior="True" 
                    onclick="btnMovimientos_Click1"  /> 
           
               
           
            </div>
            
        </div>
    </div>
    <%--<div class="contenedor_principal contenedor_principal_seleccion_areas">
        <div id="titulo_areas_a_administrar" style="text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);">
            Vehiculo                 
            <a id="btn_consultar_historia" class="btn btn-primary" href="MovimentosBien.aspx">Historial</a>
        </div>
    </div>--%>
    <label class="lbl_nombre_atributo">Descripcion:</label>
    <div id="ed_descripcion_bien" runat="server" contenteditable="true">
    
  
    
    </div>




    <div id="ed_contenedor_imagenes"></div>
    <div id="btn_add_imagen">+</div>
    <div id="Contenido">
        <table id="datos-vehiculo" class="tabla-principal">
            <tr>
                <td colspan="2" class="celda">
                    Marca:
                </td>
                <td id="marca" colspan="2" class="celda2">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda">
                    Modelo:
                </td>
                <td id="Modelo" colspan="2" class="celda2">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda">
                    Segmento:
                </td>
                <td id="segmento" colspan="2" class="celda2">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda">
                    Dominio:
                </td>
                <td id="dominio" colspan="2" class="celda2">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda">
                    Año:
                </td>
                <td id="año" colspan="2" class="celda2">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda">
                    Motor:
                </td>
                <td id="Motor" colspan="2" class="celda2">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda">
                    Chasis:
                </td>
                <td id="chasis" colspan="2" class="celda2">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda">
                    Asignado al sector:
                </td>
                <td id="area" colspan="2" class="celda2">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda">
                    Conductor:
                </td>
                <td id="responsable" colspan="2" class="celda2">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>

<script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
<script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
<script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
<script src="../scripts/Spin.js" type="text/javascript"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/SubidorDeImagenes.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript" src="js/BienesDetalle.js"></script>

<script type="text/javascript">

    $(document).ready(function () {    
        var id_bien = localStorage.getItem("idBien"); 
        $("#hid").val(id_bien);   

    });   

</script>
</html>
