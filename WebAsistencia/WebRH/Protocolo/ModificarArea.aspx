<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModificarArea.aspx.cs" Inherits="FormularioProtocolo_ConsultaListadoLicencias" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Áreas</title>
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link id="link1" rel="stylesheet" href="ConsultaProtocolo.css" type="text/css" runat="server" />
    <link id="link5" rel="stylesheet" href="VistaDeArea.css" type="text/css" runat="server" />
    <link href="../FormularioConcursar/EstilosPostular.css" rel="stylesheet" type="text/css" />
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
                     <label for="institucion_academica_nombre" style="color: green;font-size: small;">
                               * Recuerde realizar las modificaciones pertinentes y luego enviarlas para que el cambio sea aprobado </label>
                    <h2>
                        Modificación de Datos del Área</h2>
                    <p>
                     <div class="btn-fld" style="float:right;">
                        <input type="button" class="btn btn-primary" id="btn_guardar" value="Enviar Cambios para su Aprobación" />
                    </div>
                    </p>
                </div>
                <div id="contenido_form_ModificarArea" class="fondo_form">
               
                    <fieldset style="width: 95%; padding-left: 3%;">
                        <legend style="margin-bottom: 20px;">Responsable</legend>
                        
                        <div class="grupo_campos">
                            <label for="institucion_academica_nombre">
                               Nombre y Apellido: </label>
                            <input id="txt_institucion_academica_nombre" type="text" style="width: 285px;" rh-control-type="textbox"
                                rh-model-property="Institucion" data-validar="esNoBlanco" disabled/>
                        </div>
                        <div class="grupo_campos nueva_linea">
                            <label for="institucion_academica_caracter" style="margin-right: 15px;">
                                Nro Documento: </label>
                            <input id="txt_institucion_academica_caracter" type="text" style="width: 100px;"
                                rh-control-type="textbox" rh-model-property="CaracterEntidad" data-validar="esNoBlanco" disabled/>
                        </div>
                        <div class="grupo_campos">
                            <label for="institucion_academica_caracter">
                                Id Interna: </label>
                            <input id="Text1" type="text" style="width: 96px;"
                                rh-control-type="textbox" rh-model-property="CaracterEntidad" data-validar="esNoBlanco" disabled/>
                        </div>
                        <div class="btn-fld">
                        <input type="button" class="btn btn-primary" style="margin-top: 4px;" id="Button1" value="Modificar" />
                    </div>
                          <legend style="margin-bottom: 20px;">Dirección</legend>
                        <div class="grupo_campos nueva_linea">
                            <label for="institucion_academica_cargo" style="margin-left: 38px;">
                                Calle: </label>
                            <input id="txt_institucion_academica_cargo" type="text" style="width: 285px;" rh-control-type="textbox"
                                rh-model-property="CargosDesempeniados" data-validar="esNoBlanco" disabled/>
                        </div>
                        <div class="grupo_campos">
                            <label for="institucion_academica_fecha_inicio">
                                Nro: </label>
                            <input id="txt_institucion_academica_fechaInicio" type="text" style="width: 50px;"
                                rh-control-type="datepicker" data-validar="esNoBlanco" disabled/>
                        </div>
                        <div class="grupo_campos">
                            <label for="institucion_academica_fecha_fin">
                                Piso: </label>
                            <input id="txt_institucion_academica_fechaFin" type="text" style="width: 25px;"
                                 disabled />
                        </div>
                        <div class="grupo_campos nueva_linea">
                            <label for="institucion_academica_fecha_fin" style="margin-left: 27px;">
                                Oficina: </label>
                            <input id="Text2" type="text" style="width: 285px;"
                                rh-control-type="datepicker" rh-model-property="FechaFin" disabled />
                        </div>
                        <div class="grupo_campos">
                            <label for="institucion_academica_fecha_fin" style="margin-left: 5px;">
                                UF: </label>
                            <input id="Text3" type="text" style="width: 132px;"
                                rh-control-type="datepicker" rh-model-property="FechaFin" disabled />
                        </div>
                        <div class="grupo_campos nueva_linea">
                            <label for="institucion_academica_fecha_fin" style="margin-left: 14px;">
                                Localidad: </label>
                            <input id="Text4" type="text" style="width: 285px;"
                                rh-control-type="datepicker" rh-model-property="FechaFin" disabled/>
                        </div>
                        <div class="grupo_campos">
                            <label for="institucion_academica_fecha_fin">
                                Código Postal:</label>
                            <input id="Text5" type="text" style="width: 75px;"
                                rh-control-type="datepicker" rh-model-property="FechaFin" disabled/>
                        </div>
                        <div class="grupo_campos nueva_linea">
                            <label for="institucion_academica_fecha_fin" style="margin-left: 2px;">
                               Partido/Dto: </label>
                            <input id="Text6" type="text" style="width: 192px;"
                                rh-control-type="datepicker" rh-model-property="FechaFin" disabled/>
                        </div>
                        <div class="grupo_campos">
                            <label for="institucion_academica_fecha_fin">
                                Provincia:</label>
                            <input id="Text7" type="text" style="width: 192px;"
                                rh-control-type="datepicker" rh-model-property="FechaFin" disabled/>
                        </div>
                         <div class="btn-fld">
                        <input type="button" class="btn btn-primary"  style="margin-top: 4px;" id="Button2" value="Modificar" />
                    </div>
                         <legend style="margin-bottom: 20px;">Información de Contacto</legend>
                        <div class="accordion-inner fondo_form">
                        <fieldset style="width: 100%;">
                            <legend><a id="btn_agregar_antecedente_academico" class="btn btn-primary">Agregar Contacto</a></legend>
                            <h4>
                                Contactos Agregados</h4>
                            <div id="ContenedorPlanillaAntecendentesAcademicos" runat="server">
                                <table id="tabla_antecedentes_academicos" class="table table-striped">
                                </table>
                            </div>
                        </fieldset>

                         <fieldset style="width: 100%;">
                            <legend><a id="A1" class="btn btn-primary">Agregar Asistente</a></legend>
                            <h4>
                                Asistentes Agregados</h4>
                            <div id="Div1" runat="server">
                                <table id="Table1" class="table table-striped">
                                </table>
                            </div>
                        </fieldset>
                    </div>
              
   
                    </fieldset>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="texto_mensaje_exito" runat="server" />
        <asp:HiddenField ID="texto_mensaje_error" runat="server" />
        <asp:HiddenField ID="personasJSON" runat="server" EnableViewState="true" />
        <asp:HiddenField ID="pasesJSON" runat="server" EnableViewState="true" />
        <asp:HiddenField ID="txtIdArea" runat="server" />
        <asp:HiddenField ID="idArea" runat="server" />
    </div>
    </form>
</body>
<script type="text/javascript" src="AdministradorDeLicencias.js"></script>
<script type="text/javascript" src="AdministradorDePases.js"></script>
<script type="text/javascript" src="Persona.js"></script>
<script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>
<script src="../Scripts/ConversorDeFechas.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        var admin_lic = new AdministradorDeLicencias();
        var admin_pases = new AdministradorDePases();
        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');
    });
</script>
</html>
