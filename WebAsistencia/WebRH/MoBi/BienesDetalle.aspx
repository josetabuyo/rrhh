<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BienesDetalle.aspx.cs" Inherits="MoBi_BienesDetalle" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/Scripts/BuscadorDeAreas.ascx" TagName="BuscadorDeAreas" TagPrefix="uc3" %>
<%@ Register Src="~/Scripts/BuscadorDePersonas.ascx" TagName="BuscadorDePersonas" TagPrefix="uc3" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Detalle de Vehiculo</title>
    <%= Referencias.Css("../")%>
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet" />
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/BienesDetalle.css" />
    <%= Referencias.Javascript("../")%>
</head>
<body>

    <form id="form1" runat="server">
    <input type ="hidden" id = "hid" runat="server" />
    <input type ="hidden" id = "hidEstado" runat="server" />
    <input type ="hidden" id = "hidAreaSeleccionada" runat="server" />
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    
    <%--<div style="" align="center">
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
    </div>--%>

    <%--<div class="contenedor_principal contenedor_principal_seleccion_areas">
        <div id="titulo_areas_a_administrar" style="text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);">
            Vehiculo                 
            <a id="btn_consultar_historia" class="btn btn-primary" href="MovimentosBien.aspx">Historial</a>
        </div>
    </div>--%>
    
   <%-- <label class="lbl_nombre_atributo">Descripcion:</label>
    <div id="ed_descripcion_bien" runat="server" contenteditable="true">
    </div>--%>

    <div id="Contenido">
        <table id="datos-vehiculo" class="tabla-principal" style="border-width: thin; border-style: solid; border-color: #808080">
            <tr>
                <td colspan="2" class="celda_atributo">
                    Marca:
                </td>
                <td id="marca" colspan="2" class="celda_descripcion">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda_atributo">
                    Modelo:
                </td>
                <td id="Modelo" colspan="2" class="celda_descripcion">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda_atributo">
                    Segmento:
                </td>
                <td id="segmento" colspan="2" class="celda_descripcion">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda_atributo">
                    Dominio:
                </td>
                <td id="dominio" colspan="1" width="20%">
                </td>
                <td id="foto" colspan="1">
                    <div id="btn_ver_imagen" runat="server" style="display:none">
                        <a style="display:inline-block">
                            <img src="../Imagenes/camara.png" alt="" width="20px" height="20px" />
                        </a>
                    </div>
                    <div id="descrip_hay_imagen_cargadas" runat="server" 
                            style="display:inline-block; padding-left: 2%; font-family: Arial, Helvetica, sans-serif; font-size: small; color: #FF0000;" 
                            width="100%">
                    </div>
                </td>
                
            </tr>
            <tr>
                <td colspan="2" class="celda_atributo">
                    Año:
                </td>
                <td id="año" colspan="2" class="celda_descripcion">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda_atributo">
                    Motor:
                </td>
                <td id="Motor" colspan="2" class="celda_descripcion">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda_atributo">
                    Chasis:
                </td>
                <td id="chasis" colspan="2" class="celda_descripcion">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda_atributo">
                    Asignado al sector:
                </td>
                <td id="area" colspan="2" class="celda_descripcion">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="celda_atributo">
                    Conductor:
                </td>
                <td id="responsable" colspan="2" class="celda_descripcion">
                </td>
            </tr>
        </table>
    </div>

    <div id="DivBotones" runat="server" style="width: 100%; text-align: center;">
    </div>
        
    <div id="ed_contenedor_imagenes" style="display:none"></div>

    
    <%-- --------------- BUSCADOR DE PERSONA Y AREA SACADO DE DDJJ 104 ---------------- --%>
        <div runat="server" id="Controles_Persona_Area" style="margin-top:20px; display:none">
            <div id="divBuscadorArea">
                <uc3:BuscadorDeAreas ID="buscador1" runat="server"  style="display: inline-block; margin:auto;" />
            </div>

            <div id="divBuscadorPersona">
                <uc3:BuscadorDePersonas ID="buscadorPersonas1" runat="server"  style="display: inline-block; margin:auto;" />
            </div>

            <div id="btn_guardar" runat="server" style="width:85px">
                <a style="display:inline-block" >
                    <img src="../Imagenes/guardar.jpg" alt="" width="80px" height="36px" />
                </a>
            </div>
        </div>
    <%-- ------------------------------------------------------------------------------ --%>


    <%-- ---------------GRILLA DE MOVIMIENTOS------------------------------------------ --%>
     <div id="ContenedorGrilla" runat="server" style="margin-top:20px; width: 100%" align="center">
        <div id="ContenedorMovimientos" runat="server" style=" width: 90%"></div>
    </div>
    <%-- ------------------------------------------------------------------------------ --%>




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

        var id_estado = localStorage.getItem("idEstado");
        $("#hidEstado").val(id_estado);

        var id_Area_Seleccionada = localStorage.getItem("idAreaSeleccionada");
        $("#hidAreaSeleccionada").val(id_Area_Seleccionada);

    });   

</script>
</html>
