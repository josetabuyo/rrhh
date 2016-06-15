<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModificarArea.aspx.cs" Inherits="FormularioProtocolo_ModificarArea" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Áreas</title>
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
    <%= Referencias.Css("../")%>
    <link id="link1" rel="stylesheet" href="ConsultaProtocolo.css" type="text/css" runat="server" />
    <link id="link5" rel="stylesheet" href="VistaDeArea.css" type="text/css" runat="server" />
    <link href="../FormularioConcursar/EstilosPostular.css" rel="stylesheet" type="text/css" />
        <link rel="stylesheet" href="../scripts/select2-3.4.4/select2.css" type="text/css" />
        <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    <%--<script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlEstilos="../Estilos/" UrlImagenes="../Imagenes/"
        UrlPassword="../" />
    <div id="ContenedorPrincipal" class="contenedor_principal contenedor_principal_consulta_protocolo">
        <div id="ModificarArea">
            <div id="ModificarArea-ct">
                <div id="ModificarArea-header" class="form_concursar_header">
                    <label for="ModificarArea" style="color: green; font-size: small;">
                        * Recuerde realizar las modificaciones pertinentes y luego enviarlas para que el
                        cambio sea aprobado
                    </label>
                    <h2>
                        Modificación de Datos del Área</h2>
                    <p>
                        <div class="btn-fld" style="float: right;">
                            <input type="button" class="btn btn-primary" id="btn_buscarSinAprobacion" value="Visualizar Datos Enviados para Aprobación" />
                            <input type="button" class="btn btn-primary" id="btn_buscarDatosOriginales" value="Visualizar Datos Actuales" style="display:none" />
                        </div>
                    </p>
                </div>
                <div id="contenido_form_ModificarArea" class="fondo_form">
                    <fieldset style="width: 95%; padding-left: 3%;">
                        <legend style="margin-bottom: 20px;">Responsable</legend>
                        <div class="grupo_campos">
                            <label for="btn_enviar">
                                Nombre y Apellido:
                            </label>
                            <input id="txt_nombre_apellido" type="text" style="width: 285px;" rh-control-type="textbox"
                                data-validar="esNoBlanco" disabled />
                        </div>
                        <div class="grupo_campos nueva_linea">
                            <label for="NroDocumento" style="margin-left: 15px;">
                                Nro Documento:
                            </label>
                            <input id="txt_NroDocumento" type="text" style="width: 100px;" rh-control-type="textbox"
                                data-validar="esNoBlanco" disabled />
                        </div>
                        <div class="grupo_campos">
                            <label for="IdInterna">
                                Id Interna:
                            </label>
                            <input id="txt_IdInterna" type="text" style="width: 96px;" rh-control-type="textbox"
                                data-validar="esNoBlanco" disabled />
                        </div>
                        <div class="btn-fld">
                            <input type="button" class="btn btn-primary" style="margin: 4px 143px;" id="btn_modificar_responsable"
                                value="Visualizar" />
                        </div>
                        <legend style="margin-bottom: 20px;">Dirección</legend>
                        <div class="grupo_campos nueva_linea">
                            <label for="Calle" style="margin-left: 38px;">
                                Calle:
                            </label>
                            <input id="txt_Calle" type="text" style="width: 285px;" rh-control-type="textbox"
                                data-validar="esNoBlanco" disabled />
                        </div>
                        <div class="grupo_campos">
                            <label for="Nro">
                                Nro:
                            </label>
                            <input id="txt_Nro" type="text" style="width: 50px;" disabled />
                        </div>
                        <div class="grupo_campos">
                            <label for="Piso">
                                Piso:
                            </label>
                            <input id="txt_Piso" type="text" style="width: 25px;" disabled />
                        </div>
                        <div class="grupo_campos nueva_linea">
                            <label for="Oficina" style="margin-left: 27px;">
                                Oficina:
                            </label>
                            <input id="txt_Oficina" type="text" style="width: 285px;" disabled />
                        </div>
                        <div class="grupo_campos">
                            <label for="UF" style="margin-left: 5px;">
                                UF:
                            </label>
                            <input id="txt_UF" type="text" style="width: 132px;" disabled />
                        </div>
                        <div class="grupo_campos nueva_linea">
                            <label for="Localidad" style="margin-left: 14px;">
                                Localidad:
                            </label>
                            <input id="txt_Localidad" type="text" style="width: 285px;" disabled />
                        </div>
                        <div class="grupo_campos">
                            <label for="CodigoPostal">
                                Código Postal:</label>
                            <input id="txt_CodigoPostal" type="text" style="width: 75px;" disabled />
                        </div>
                        <div class="grupo_campos nueva_linea">
                            <label for="Partido" style="margin-left: 2px;">
                                Partido/Dto:
                            </label>
                            <input id="txt_Partido" type="text" style="width: 192px;" disabled />
                        </div>
                        <div class="grupo_campos">
                            <label for="Provincia">
                                Provincia:</label>
                            <input id="txt_Provincia" type="text" style="width: 192px;" disabled />
                        </div>
                        <div class="btn-fld">
                            <input type="button" class="btn btn-primary" style="margin-top: 4px;" id="btn_modificar_direccion"
                                value="Modificar" />
                        </div>
                        <legend style="margin-bottom: 20px;">Información de Contacto</legend>
                        <fieldset style="width: 100%;">
                            <legend><a id="btn_agregar_contacto" class="btn btn-primary">Agregar Contacto</a></legend>
                            <h4>
                                Contactos Agregados</h4>
                            <div id="ContenedorPlanillaContactos" runat="server">
                                <table id="tabla_contactos" class="table table-striped">
                                </table>
                            </div>
                        </fieldset>
                        <fieldset style="width: 100%;">
                            <legend><a id="btn_agregar_asistente" class="btn btn-primary">Agregar Asistente</a></legend>
                            <h4>
                                Asistentes Agregados</h4>
                            <div id="ContenedorPlanillaAsistentes" runat="server">
                                <table id="tabla_asistentes" class="table table-striped">
                                </table>
                            </div>
                        </fieldset>
                    </fieldset>
                </div>
            </div>
        </div>
        <%----------------- MODAL DE VISTA PRELIMINAR ---------------------%>
        <input type="text" id="urlAjax" value="" style="display: none;" />
        <div id="plantillas">
            <div class="botonera_grilla">
                <img id="btn_editar" src="../Imagenes/edit2.png" />
                <img id="btn_eliminar" src="../Imagenes/icono_eliminar2.png" />
            </div>
        </div>
        <div id="un_div_modal" style="width: 65%; height: 500px; overflow: scroll;" class="form_concursar">
            <div class="modal_close_concursar">
            </div>
            <div id="contenido_modal">
            </div>
        </div>
        <asp:HiddenField ID="AreaSeleccionada" runat="server" />
        
    </div>
    </form>
</body>
<%= Referencias.Javascript("../") %>
<script src="../FormularioConcursar/PanelDetalleGenerico.js" type="text/javascript"></script>
<script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>
<script src="ModificarAreas.js" type="text/javascript"></script>
<script src="ModificarAreas_Responsable.js" type="text/javascript"></script>
<script src="ModificarAreas_Direccion.js" type="text/javascript"></script>
<script src="ModificarAreas_Contacto.js" type="text/javascript"></script>
<script type="text/javascript" src="../Scripts/FormularioBindeado.js"></script>
<script type="text/javascript" src="../Scripts/ComboConBusquedaYAgregado.js"></script>
<script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"> </script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="../Scripts/ObjectObserver.js"> </script>
<script type="text/javascript" src="../Scripts/String.js"> </script>

<script type="text/javascript">
    $(document).ready(function () {
        area = JSON.parse($('#AreaSeleccionada').val());
        area_dinamica = JSON.parse($('#AreaSeleccionada').val());
        ModificarAreas.CompletarDatosArea(area);
        ModificarAreas.armarGrillaContacto(area.DatosDeContacto);
        asistentes = ""; //JSON.parse($('#curriculum').val());
        ModificarAreas.armarGrillaAsistente(area.Asistentes);

        //Activar leanModal
        $('a[rel*=leanModalConcursar]').click(function () {
            var _this = $(this);
            if (_this.attr("data-url") !== undefined) {
                var div = $("#contenido_modal");
                div.html("");
                $.ajax({
                    url: _this.attr("data-url"),
                    success: function (r) {
                        div.append(r);
                    }
                });
            }
        });

        $('a[rel*=leanModalConcursar]').leanModal({ top: 300, closeButton: ".modal_close_concursar" });

        ModificarAreas.Inicio();
        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');
    });
</script>
</html>
