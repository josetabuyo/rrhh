<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreInscripcion.aspx.cs" Inherits="FormularioConcursar_PreInscripcion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar"
    TagPrefix="uc3" %>
<%@ Register Src="~/FormularioConcursar/Pasos.ascx" TagName="Pasos" TagPrefix="uc4" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    <link rel="stylesheet" href="../scripts/select2-3.4.4/select2.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
</head>
<body>
    <form id="form1" runat="server" class="cmxform">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar">
        <uc3:BarraMenuConcursar runat="server" />
        <uc4:Pasos runat="server" />
        <p>
            Usted está por confirmar su postulación. Si desea modificar los datos personales
            y de contacto de su curriculum puede hacerlo antes de postularse.<br />
            <%--Una vez que haya modificado su curriculum presione el botón de "Guardar Cambios".<br />
            PARA SEGUIR EN EL PROCESO DE POSTULACION PRESIONE EL SIGUIENTE--%></p>
        <div id="contenedor_datosPersonales" class="fondo_form">
            <%--<a style="margin-right: 10px; color: #3A9ABF; font-size: 14px; text-decoration: none;"
                id="btn_guardar_datosPersonales" href="#">Guardar Cambios </a>--%>
            <%--<a class="btn btn-primary" onclick="javascript:PasarAInscripcion()" href="#">Confirmar Postulación</a>--%>
            <fieldset style="width: 100%; min-width: 800px;">
                <h5>
                    <em>*</em> Campos Obligatorios</h5>
                <p style="text-transform: uppercase; font-weight: bold;">
                    I.- Editar información personal</p>
                <div id="contenedor_datos_legajos">
                    <div class="grupo_campos nueva_linea">
                        <label for="nombre">
                            Nombre <em>*</em></label>
                        <input id="nombre" type="text" rh-control-type="textbox" rh-model-property="Nombre" disabled="true"
                            style="width: 160px;" data-validar="esNoBlanco" maxlength="100" />
                    </div>
                    <div class="grupo_campos">
                        <label for="apellido">
                            Apellido <em>*</em></label>
                        <input id="apellido" type="text" style="width: 160px;" rh-control-type="textbox" disabled="true"
                            rh-model-property="Apellido" data-validar="esNoBlanco" />
                    </div>
                    <div id="contenedor_cmb_sexo" class="grupo_campos">
                        <label for="cmb_sexo">
                            Sexo <em>*</em></label>
                        <select id="cmb_sexo" style="width: 100px;" rh-control-type="combo" rh-data-provider="Sexos" disabled="true"
                            rh-model-property="Sexo" data-validar="haySeleccionEnCombo">
                        </select>
                    </div>
                    <div id="contenedor_cmb_estado_civil" class="grupo_campos">
                        <label for="cmb_estadoCivil">
                            Estado Civil <em>*</em></label>
                        <select id="cmb_estadoCivil" style="width: 160px;" rh-control-type="combo" rh-data-provider="EstadosCiviles" disabled="true"
                            rh-model-property="EstadoCivil" data-validar="haySeleccionEnCombo">
                        </select>
                    </div>
                    <div class="grupo_campos nueva_linea">
                        <label class="etiqueta_campo" for="cmb_tipoDocumento">
                            Tipo Documento <em>*</em></label>
                        <select id="cmb_tipoDocumento" style="width: 170px;" rh-control-type="combo" rh-data-provider="TiposDeDocumento" disabled="true"
                            rh-model-property="TipoDocumento" data-validar="haySeleccionEnCombo">
                        </select>
                    </div>
                    <div class="grupo_campos">
                        <label class="etiqueta_campo" for="txt_documento">
                            Nro Documento <em>*</em></label>
                        <input id="txt_documento" type="text" style="width: 160px;" rh-control-type="textbox" disabled="true"
                            rh-model-property="Dni" data-validar="esNumeroNatural" />
                    </div>
                    <div class="grupo_campos">
                        <label for="cuil">
                            CUIL <em>*</em>
                            <h5 style="display: inline-block;">
                                (Ej.:99-99999999-9)</h5>
                        </label>
                        <input id="cuil" type="text" style="width: 270px;" data-validar="esNoBlanco" disabled="true" /> 
                    </div>
                    <div class="grupo_campos nueva_linea">
                        <label class="etiqueta_campo" for="txt_fechaNac">
                            Fecha Nacimiento <em>*</em></label>
                        <input type="text" id="txt_fechaNac" style="width: 110px;" rh-control-type="datepicker" disabled="true"
                            rh-model-property="FechaNacimiento" data-validar="esNoBlanco" />
                    </div>
                    <div class="grupo_campos">
                        <label class="etiqueta_campo" for="cmb_lugar_nacimiento">
                            Lugar Nacimiento <em>*</em></label>
                        <input type="text" id="cmb_lugar_nacimiento" style="width: 210px;" rh-control-type="textbox" disabled="true"
                            rh-model-property="LugarDeNacimiento" data-validar="esNoBlanco" /></div>
                    <div class="grupo_campos">
                        <label class="etiqueta_campo" for="cmb_nacionalidad">
                            Nacionalidad <em>*</em></label>
                        <select id="cmb_nacionalidad" style="width: 280px;" rh-control-type="combo" rh-data-provider="Nacionalidades" disabled="true"
                            rh-model-property="Nacionalidad" data-validar="haySeleccionEnCombo">
                        </select>
                    </div>
                </div>
            </fieldset>
            <fieldset style="width: 100%;">
                <p style="font-weight: bold; text-transform: uppercase;">
                    Información Requerida Para Recibir Notificaciones y Avisos</p>
                <div class="grupo_campos nueva_linea">
                    <label class="etiqueta_campo" for="text_calle2">
                        Calle <em>*</em></label>
                    <input type="text" id="text_calle2" name="text_calle2" style="width: 350px;" data-validar="esNoBlanco"
                        rh-control-type="textbox" rh-model-property="DomicilioLegal.Calle" maxlength="100" />
                </div>
                <div class="grupo_campos">
                    <label class="etiqueta_campo" for="txt_numero2">
                        Número <em>*</em></label>
                    <input type="text" id="txt_numero2" name="txt_numero2" style="width: 50px" data-validar="esNumeroNatural"
                        rh-control-type="textbox" rh-model-property="DomicilioLegal.Numero" maxlength="10" />
                </div>
                <div class="grupo_campos">
                    <label class="etiqueta_campo" for="txt_piso2">
                        Piso</label>
                    <input type="text" id="txt_piso2" name="txt_piso2" style="width: 30px" maxlength="10"
                        rh-control-type="textbox" rh-model-property="DomicilioLegal.Piso" />
                </div>
                <div class="grupo_campos">
                    <label class="etiqueta_campo" for="txt_dto2">
                        Dto</label>
                    <input type="text" id="txt_dto2" name="txt_dto2" style="width: 30px" maxlength="10"
                        rh-control-type="textbox" rh-model-property="DomicilioLegal.Depto" />
                </div>
                <div class="grupo_campos">
                    <label class="etiqueta_campo_small" for="txt_cp2">
                        Código Postal <em>*</em></label>
                    <input type="text" id="txt_cp2" name="txt_cp2" style="width: 80px" data-validar="esNumeroNatural"
                        rh-control-type="textbox" rh-model-property="DomicilioLegal.Cp" maxlength="20" /><br />
                </div>
                <div class="grupo_campos nueva_linea">
                    <label class="etiqueta_campo" for="cmb_provincia2">
                        Provincia <em>*</em></label>
                    <select id="cmb_provincia2" style="width: 320px;" rh-control-type="combo" rh-propiedad-label="Nombre"
                        rh-data-provider="Provincias" rh-model-property="DomicilioLegal.Provincia" data-validar="haySeleccionEnCombo">
                    </select>
                </div>
                <div class="grupo_campos">
                    <label class="etiqueta_campo_small" for="cmb_localidad2">
                        Localidad <em>*</em></label>
                    <select id="cmb_localidad2" style="width: 320px;" rh-control-type="combo" rh-propiedad-label="Nombre"
                        rh-data-provider="Localidades" rh-model-property="DomicilioLegal.Localidad" rh-filter-key="IdProvincia"
                        rh-filter-value="DomicilioLegal.Provincia" data-validar="haySeleccionEnCombo">
                    </select>
                </div>
                <div class="grupo_campos nueva_linea">
                    <label class="etiqueta_campo" for="txt_telefono">
                        Tel&eacute;fono Fijo <em>*</em></label>
                    <input type="text" id="txt_telefono" name="txt_telefonoFijo" style="width: 140px;"
                        rh-control-type="textbox" rh-model-property="DatosDeContacto.Telefono" data-validar="haySeleccionEnCombo" />
                </div>
                <div class="grupo_campos">
                    <label class="etiqueta_campo" for="txt_telefono2">
                        Tel&eacute;fono Celular<em>*</em></label>
                    <input type="text" id="txt_telefono2" name="txt_telefonoCelular" style="width: 140px;"
                        rh-control-type="textbox" rh-model-property="DatosDeContacto.Telefono2" data-validar="haySeleccionEnCombo" />
                </div>
                <div id="contenedor_mails" class="grupo_campos">
                    <label class="etiqueta_campo" for="txt_email">
                        Correo Electrónico<em>*</em></label>
                    <input type="text" id="txt_email" name="txt_email" style="width: 320px" data-validar="esEmailValido, esNoBlanco"
                        rh-control-type="textbox" rh-model-property="DatosDeContacto.Email" />
                </div>
            </fieldset>
            <div class="actions clearfix " style="margin: 20px 5px 20px -25px; position: relative;
                width: 100%; height: 60px; text-align: center;">
                <ul>
                    <li><a id="pasosanterior" href="javascript:Anterior();">Volver</a></li>
                    <li><a id="pasossiguiente" onclick="javascript:Siguiente();">Continuar</a></li>
                    <input type="button" class="btn" id="btn_guardar_datosPersonales" value="" style="visibility: hidden;" />
                </ul>
            </div>
        </div>
    </div>
    <div id="modal_mensaje" class="form_concursar">
        <div id="modal_mensaje-ct">
            <div id="modal_mensaje-header" class="form_concursar_header">
                <h2>
                    Mensaje</h2>
                <p>
                </p>
                <a class="modal_close_concursar" href="#"></a>
            </div>
            <div id="Div6" class="fondo_form">
                <fieldset style="width: 95%; padding-left: 3%;">
                    <p>
                        Usted está por confirmar su postulación.</p>
                    <p>
                        Si desea revisar y modificar su curriculum puede hacerlo antes de postularse.</p>
                    <p>
                        Una vez que haya modificado su curriculum presione el botón de "Guardar Cambios".</p>
                    <p>
                        PARA POSTULARSE PRESIONE EL BOTON "Confirmar Postulación"</p>
                </fieldset>
            </div>
        </div>
    </div>
    <%-- <a id="modal_preinscripcion" rel="leanModal" style="display:none;" name="modal_mensaje" href="#modal_mensaje"></a>--%>
    <asp:HiddenField ID="curriculum" runat="server" />
    <asp:HiddenField ID="perfil" runat="server" />
    </form>
</body>
<%= Referencias.Javascript("../") %>
<%--<script type="text/javascript" src="../Scripts/jquery.min.js"></script>--%>
<script type="text/javascript" src="CvDatosPersonales.js"></script>
<script type="text/javascript" src="Postulacion.js"></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
<script type="text/javascript" src="../Scripts/FormularioBindeado.js"></script>
<script type="text/javascript" src="../Scripts/ComboConBusquedaYAgregado.js"></script>
<script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"> </script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="../Scripts/ObjectObserver.js"> </script>
<script type="text/javascript" src="../Scripts/rhforms-combos.js"> </script>
<script type="text/javascript" src="../Scripts/String.js"> </script>
<script type="text/javascript">
    // var puesto;
    var perfil;
    var curriculum;
    Backend.start();

    $(document).ready(function () {
        //puesto = getVarsUrl();
        curriculum = JSON.parse($('#curriculum').val());
        CvDatosPersonales.completarDatos(curriculum.DatosPersonales);

        //this.ui = $("#modal_mensaje");
        //this.ui.find("#div").load("PanelDetalleDePublicacionTrabajo.htm", function ()

        $('a[rel*=leanModal]').leanModal({ top: 300, closeButton: ".modal_close_concursar" });

        // $("#siguiente").click();

        $("#paso_2").attr('class', 'link_activado');

    });

    function Siguiente() {
        alertify.confirm("¿Está seguro que desea pasar al siguiente paso?", function (e) {
            if (e) {
                // user clicked "ok"
                if ($("#contenedor_datosPersonales").esValido()) {
                    $("#btn_guardar_datosPersonales").click();
                    window.location.href = 'Inscripcion.aspx';
                } else { 
                
                }
            } else {
                // user clicked "cancel"
                //alertify.error("");
            }
        });

    }

    function Anterior() {
        window.location.href = 'Postulaciones.aspx';
    }

    /* function getVarsUrl() {
    var url = location.search.replace("?", "");
    var arrUrl = url.split("&");
    var urlObj = {};
    for (var i = 0; i < arrUrl.length; i++) {
    var x = arrUrl[i].split("=");
    urlObj[x[0]] = x[1]
    }
    return urlObj;
    }*/

    function PasarAInscripcion() {

        //window.location.href = 'Inscripcion.aspx?id=' + puesto.id;

    }
       
</script>
</html>
