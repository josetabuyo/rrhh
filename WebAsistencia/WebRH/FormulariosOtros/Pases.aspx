<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pases.aspx.cs" Inherits="FormulariosOtros_Pases" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema RRHH - Buscador de áreas</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css"/>    
    <link rel="stylesheet" href="../estilos/SelectorDeAreas.css" type="text/css"/>    
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>

    <style type="text/css">
        .style1
        {
            width: 18px;
        }
        .style4
        {
            height: 16px;
        }
        .style5
        {
            width: 18px;
            height: 16px;
        }
    </style>
</head>
<body style="background-color:#8694A4;">
    <form id="form1" runat="server">
        <table style="width: 100%; text-align: center">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 80%; background-color: #ffffff;
                        text-align: left">
                        <tr>
                            <td style="background-image: url('../Imagenes/bordeTabla2SupIzq.PNG'); width: 18px">
                                &nbsp;
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2Sup.PNG')">
                                &nbsp;
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2SupDer.PNG'); width: 21px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url('../Imagenes/bordeTabla2Izq.PNG'); width: 17px; height: 19px">
                            </td>
                            <td align="center" style="height: 19px">
                                    

                                    <p class="persona_baja_con_funcionalidades">Escriba una parte del nombre del área.</p><br />
                                    <div id="selector_area_usuarios" class="selector_areas" style="position: inherit; display: inline;">
                                        <input id="buscador" type="hidden" class="buscarUsuarioPorArea" style="width:500px;" />
                                    </div>
                                    <div id="plantillas">
                                        <div class="vista_area_en_selector">
                                            <div id="nombre"></div>
                                        </div>
                                    </div>
                                <br />
                                <br />
                                <asp:Button ID="BtnGenerarPase" jsId="btn_generar_pase" runat="server" 
                                        Text="GenerarPase" onclick="BtnGenerarPase_Click" />

                                
                                    <asp:HiddenField ID="selected_area_name" runat="server" />
                                    <asp:HiddenField ID="selected_area_id" runat="server" />

                                
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2Der.PNG'); width: 18px; height: 19px">
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url('../Imagenes/bordeTabla2Izq.PNG'); width: 5px">
                                &nbsp;
                            </td>
                            <td align="center">
                                <strong>&nbsp;<br />
                                </strong>
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2Der.PNG'); width: 18px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url('../Imagenes/bordeTabla2InfIzq.PNG')" 
                                class="style4">
                                &nbsp;
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2Inf.PNG')" 
                                class="style4">
                                &nbsp;
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2InfDer.PNG'); " 
                                class="style5">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>

<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>


<script type="text/javascript">
    $(document).ready(function () {
        this.div_lista_areas = $("#lista_areas_para_consultar");
        $("#BtnGenerarPase").css('visibility', 'hidden');
        var proveedor_ajax = new ProveedorAjax("../");
        this.repositorioDeAreas = new RepositorioDeAreas(proveedor_ajax);

        this.selector_de_areas = new SelectorDeAreas({
            ui: $("#selector_area_usuarios"),
            repositorioDeAreas: this.repositorioDeAreas,
            placeholder: "ingrese el área que desea buscar",
            alSeleccionarUnArea: function (area) {
                if (area.id == "") {
                    $("#BtnGenerarPase").css('visibility', 'hidden');
                } else {
                    $("#BtnGenerarPase").css('visibility', 'visible');
                }
                $("#selected_area_id").val(area.id);
                $("#selected_area_name").val(area.nombre);
                //$("#tabla_usuarios_por_area").html("");
                //contexto.BackendBuscarUsuariosPorArea(contexto, area.nombre);
            }
        });
    });
</script>


</html>
