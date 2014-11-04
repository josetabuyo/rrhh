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
            Usted está por confirmar su postulación. Si desea revisar y modificar su curriculum
            puede hacerlo antes de postularse.<br />
            Una vez que haya modificado su curriculum presione el botón de "Guardar Cambios".<br />
            PARA SEGUIR EN EL PROCESO DE POSTULACION PRESIONE EL SIGUIENTE</p>
        <div id="contenedor_datosPersonales" class="fondo_form">
            <a style="margin-right: 10px; color: #3A9ABF; font-size: 14px; text-decoration: none;"
                id="btn_guardar_datosPersonales" href="#">Guardar Cambios </a>
            <%--<a class="btn btn-primary" onclick="javascript:PasarAInscripcion()" href="#">Confirmar Postulación</a>--%>
            <fieldset style="width: 100%; min-width: 800px;">
                <p>
                    <em>*</em> Campos Obligatorios</p>
                <p style="text-transform: uppercase; font-weight: bold;">
                    I.- Editar información personal</p>
                <div style="float: left; margin: 8px;">
                    <label for="nombre" class="">
                        Nombre <em>*</em></label>
                    <input id="nombre" type="text" style="width: 150px;" rh-control-type="textbox" rh-model-property="Nombre" />
                </div>
                <div style="float: left; margin: 8px;">
                    <label for="apellido">
                        Apellido <em>*</em></label>
                    <input id="apellido" type="text" style="width: 150px;" rh-control-type="textbox"
                                        rh-model-property="Apellido" />
                </div>
                <div style="float: left; margin: 8px;">
                    <label for="cmb_sexo">
                        Sexo <em>*</em></label>
                    <select id="cmb_sexo" style="width: 100px;" name="cmb_sexo" data-validar="esNumeroNaturalSinCero"
                        rh-control-type="combo" rh-data-provider="Sexos" rh-model-property="Sexo">
                    </select>
                </div>
                <div style="float: left; margin: 8px;">
                    <label for="cmb_estadoCivil">
                        Estado Civil <em>*</em></label>
               
                    <select id="cmb_estadoCivil" style="width: 160px;" rh-control-type="combo" rh-data-provider="EstadosCiviles"
                        name="cmb_estadoCivil" rh-model-property="EstadoCivil" data-validar="haySeleccionEnCombo">
                    </select>
                </div>
                <div style="float: left; margin: 8px; width: 130px;">
                    <label for="cuil">
                        Cuil / Cuit <em>*</em></label>
                    <input id="cuil" type="text" style="width: 120px;" />
                    <span style="float: left;">Ej.:20-22114543-5</span>
                </div>
                <div style="float: left; clear: left; margin: 8px">
                    <label class="" for="cmb_lugar_nacimiento">
                        Lugar nacimiento <em>*</em></label>
                    <select id="cmb_lugar_nacimiento" style="width: 120px;">
                        <option value="-1">Seleccione</option>
                        <option value="1" selected="selected">Argentina</option>
                        <option value="1">Bolivia</option>
                    </select>
                </div>
                <div style="float: left; margin: 8px">
                    <label class="" for="txt_fechaNac">
                        Fecha Nac <em>*</em></label>
                    <input type="text" id="txt_fechaNac" style="width: 120px;" rh-control-type="datepicker"
                                        rh-model-property="FechaNacimiento" />
                </div>
                <div style="float: left; margin: 8px">
                    <label class="" for="cmb_nacionalidad">
                        Nacionalidad <em>*</em></label>
                    <select id="cmb_nacionalidad" style="width: 280px;" name="cmb_nacionalidad" rh-control-type="combo" rh-data-provider="Nacionalidades"  rh-model-property="Nacionalidad">
                    </select>
                </div>
                <div style="float: left; clear:left;margin: 8px">
                    <label class="" for="cmb_tipoDocumento">
                        Tipo documento <em>*</em></label>
                    <select id="cmb_tipoDocumento" style="width: 170px;" name="cmb_tipoDocumento" rh-control-type="combo"  rh-data-provider="TiposDeDocumento"
                      rh-model-property="TipoDocumento"  data-validar="esUnComboSinCero">
                    </select>
                </div>
                <div style="float: left; margin: 8px">
                    <label class="" for="txt_documento">
                        Nro documento <em>*</em></label>
                    <input id="txt_documento" type="text" style="width: 150px;"   rh-control-type="textbox"
                                        rh-model-property="Dni" maxlength="20" />
                </div>
                <div style="float: left; clear:left; margin: 8px">
                    <label class="" for="txt_calle1">
                        Calle <em>*</em></label>
                    <input type="text" id="txt_calle1" size="20"   rh-control-type="textbox" rh-model-property="DomicilioPersonal.Calle"/>
                </div>
                <div style="float: left; margin: 8px; width: 60px;">
                    <label class="" for="txt_numero1">
                        Número <em>*</em></label>
                    <input type="text" id="txt_numero1" style="width: 50px"    rh-control-type="textbox" rh-model-property="DomicilioPersonal.Numero" />
                </div>
                <div style="float: left; margin: 8px; width: 60px;">
                    <label class="" for="txt_piso1">
                        Piso</label>
                    <input type="text" id="txt_piso1" style="width: 50px"  rh-control-type="textbox" rh-model-property="DomicilioPersonal.Piso" />
                </div>
                <div style="float: left; margin: 8px; width: 80px;">
                    <label class="" for="txt_dto1">
                        Dto</label>
                    <input type="text" id="txt_dto1" style="width: 50px"  rh-control-type="textbox" rh-model-property="DomicilioPersonal.Depto" />
                </div>
                <div style="float: left; margin: 8px">
                    <label class="" for="cmb_localidad1">
                        Localidad <em>*</em></label>
                 <select id="cmb_localidad1" style="width: 320px;" rh-control-type="combo" rh-propiedad-label="Nombre"
                                    rh-data-provider="Localidades" rh-model-property="DomicilioPersonal.Localidad"
                                    rh-filter-key="IdProvincia" rh-filter-value="DomicilioPersonal.Provincia" data-validar="haySeleccionEnCombo">
                                </select>
                </div>
                <div style="float: left; clear:left; margin: 8px">
                    <label class="" for="txt_cp1">
                        Código postal <em>*</em></label>
                    <input type="text" id="txt_cp1" style="width: 80px" rh-model-property="DomicilioPersonal.Cp" data-validar="esNumeroNatural" maxlength="10"rh-control-type="textbox" /><br />
                </div>
                <div style="float: left; margin: 8px">
                    <label class="" for="cmb_provincia1">
                        Provincia <em>*</em></label>
                      <select id="cmb_provincia1" style="width: 320px;" rh-control-type="combo" rh-propiedad-label="Nombre" rh-data-provider="Provincias" rh-model-property="DomicilioPersonal.Provincia" data-validar="haySeleccionEnCombo"> </select>
                </div>
            </fieldset>
            <fieldset style="width: 100%;">
                <p style="font-weight: bold; text-transform: uppercase;">
                    II.- Información Requerida Para Recibir Notificaciones y Avisos</p>
                <div style="float: left; margin: 8px">
                    <label class="" for="text_calle2">
                        Calle <em>*</em></label>
                    <input type="text" id="text_calle2" size="20"   rh-control-type="textbox" rh-model-property="DomicilioLegal.Calle" maxlength="100" />
                </div>
                <div style="float: left; margin: 8px; width: 60px;">
                    <label class="" for="txt_numero2">
                        Número <em>*</em></label>
                    <input type="text" id="txt_numero2" style="width: 50px"  rh-control-type="textbox" rh-model-property="DomicilioLegal.Numero" maxlength="10" />
                </div>
                <div style="float: left; margin: 8px; width: 60px;">
                    <label class="" for="txt_piso2">
                        Piso</label>
                    <input type="text" id="txt_piso2" style="width: 50px"  rh-control-type="textbox" rh-model-property="DomicilioLegal.Piso" />
                </div>
                <div style="float: left; margin: 8px; width: 80px;">
                    <label class="" for="txt_dto2">
                        Dto</label>
                    <input type="text" id="txt_dto2" style="width: 50px"  rh-control-type="textbox" rh-model-property="DomicilioLegal.Depto"  />
                </div>

                <div style="float: left; margin: 8px">
                    <label class="" for="cmb_localidad2">
                        Localidad <em>*</em></label>
                    <select id="cmb_localidad2" name="cmb_localidad2" style="width: 320px;"  rh-control-type="combo" rh-propiedad-label="Nombre"
                     rh-data-provider="Localidades" rh-model-property="DomicilioLegal.Localidad" rh-filter-key="IdProvincia"
                     rh-filter-value="DomicilioLegal.Provincia" data-validar="haySeleccionEnCombo">
                    </select>
                </div>

                <div style="float: left; margin: 8px; clear:left;" >
                    <label class="" for="txt_cp2">
                        Código postal <em>*</em></label>
                    <input type="text" id="txt_cp2" style="width: 50px" value="1427"      rh-control-type="textbox" rh-model-property="DomicilioLegal.Cp" maxlength="20" />
                </div>
              
                <div style="float: left; margin: 8px">
                    <label class="" for="cmb_provincia2">
                        Provincia <em>*</em></label>
                    <select id="cmb_provincia2" name="cmb_provincia2" style="width: 320px;" rh-control-type="combo" rh-propiedad-label="Nombre"
                        modelo="DomicilioLegal.Provincia" data-validar="esNoBlanco"rh-data-provider="Provincias" rh-model-property="DomicilioLegal.Provincia">
                    </select>
                </div>


            </fieldset>
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
   
   
              <div class="actions clearfix" style="margin:20px 5px; background-color: #FCFCFC; position: relative; width:100%; height: 60px; text-align:center; font-weight:bold;">
            <ul>
                <li class="" ><a href="javascript:Anterior();" id="anterior">Anterior</a></li>
                <li ><a id="siguiente" onclick="javascript:Siguiente();" >Siguiente</a></li>
                <li style="display: none;"><a href="#finish" >Finalizar</a></li>
            </ul>
        </div>
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
<script type="text/javascript" src="../Scripts/Bindings.js"> </script>
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
                window.location.href = 'Inscripcion.aspx';

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
