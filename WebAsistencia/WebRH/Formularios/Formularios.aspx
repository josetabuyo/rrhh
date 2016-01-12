<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formularios.aspx.cs" Inherits="Formularios_Formularios" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Formularios</title>
        <%= Referencias.Css("../")%>           
        <link rel="stylesheet" type="text/css" href="EstilosFormularios.css" />
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>           
        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
        <%= Referencias.Javascript("../")%>
        <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
        <script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
        <script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
        <script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
        <script type="text/javascript" src="../Scripts/Persona.js"></script>
        <script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
        <script type="text/javascript" src="Formularios.js"></script>
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
     <h1 style="text-align:center; margin-top:50px;">Relevamiento de Contratos</h1>
    
    <div>
        <p class="buscarPersona">Buscar persona:
            <div id="selector_usuario" class="selector_personas" style="margin-bottom: 0px;">
                <input id="buscador" type=hidden />
            </div>
        </p>
    </div>
   
        <hr />
        <div class="contenedor_formulario">
            <p class="subtitulo">1) Datos Personales:</p>
            <div class="bloque">  
                  
                <label class="etiqueta_campo" for="cmb_tipoDocumento" style="width:50px;" >
                    Tipo y Número de Documento <em>*</em></label>
                <select id="cmb_tipoDocumento" campo="tipo_documento" style="width: 50px;" rh-control-type="combo" rh-data-provider="TiposDeDocumento"
                    rh-model-property="TipoDocumento" data-validar="haySeleccionEnCombo">
                </select>
                <input id="txt_documento" campo="documento" type="text" style="width: 500px;" rh-control-type="textbox"
                     data-validar="esNumeroNatural" />
            </div>
            <div class="bloque">
                <label for="nombre">Nombre <em>*</em></label>
                <input id="nombre" type="text" campo="nombre" rh-control-type="textbox" 
                    style="width: 295px;" data-validar="esNoBlanco" maxlength="100" />

                <label for="apellido" style="margin-left:15px;">Apellido <em>*</em></label>
                <input id="apellido" type="text" campo="apellido" style="width: 295px;" rh-control-type="textbox"
                     data-validar="esNoBlanco" />
            </div>
            <div class="bloque">
                <label for="nivel">Nivel <em>*</em></label>
                <input id="nivel" type="text" campo="nivel" rh-control-type="textbox" rh-model-property="Nivel"
                    style="width: 50px;" data-validar="esNoBlanco" maxlength="2" />
                <label for="grado" style="margin-left:15px;">Grado <em>*</em></label>
                <input id="grado" type="text" campo="grado" style="width: 50px;" rh-control-type="textbox"
                    rh-model-property="Grado" data-validar="esNoBlanco" />
                <label class="etiqueta_campo" style="margin-left:15px;" for="cmb_modalidadContratacion">Modalidad de Contratación <em>*</em></label>
                <select id="modalidad" style="width: 332px" campo="modalidad" rh-control-type="combo" rh-data-provider="xxxxxxx"
                    rh-model-property="Modalidad" data-validar="haySeleccionEnCombo"></select>
            </div>
            <div class="bloque">
                <p>Domicilio Particular</p>
                    <div class="bloque">
                        <label for="calle" style="display:inline-block; width:50px;">Calle: <em>*</em></label>
                        <input id="text_domicilio_calle_personal" campo="domicilio_calle" type="text" placeholder="Calle" style="width:680px;" class="validar" />
                    </div>
                    <div class="bloque">
                        <label for="nro" style="display:inline-block; width:50px;">Nro: <em>*</em></label>
                        <input id="text_domicilio_nro_personal" campo="domicilio_numero" type="number" placeholder="Nro" style="width: 100px;" class="validarNumero" />
                        <label for="piso" style="display:inline-block; width:40px; margin-left:50px;">Piso: <em>*</em></label>
                        <input id="text_domicilio_piso_personal" campo="domicilio_piso" type="number" placeholder="Piso" style="width: 80px;" class="validarNumero" />
                        <label for="dto" style="display:inline-block; width:40px; margin-left:50px;">Dto: <em>*</em></label>
                        <input id="text_domicilio_depto_personal" campo="domicilio_depto" type="text" placeholder="Depto" style="width: 80px;" class="validar" />
                        <label for="cp" style="display:inline-block; width:40px; margin-left:50px;">C.P: <em>*</em></label>
                        <input id="text_domicilio_cp_personal" campo="domicilio_cp" type="text" placeholder="C.P." style="width: 100px;" class="validar" />
                    </div>
                    <div class="bloque">
                      
                        <label for="provincia">Provincia: <em>*</em></label>
                        <select id="cmb_provincia_personal" campo="domicilio_provincia" class="cmb_provincia" style="width:273px;" ></select>
                        <label for="Localidad" style="margin-left:40px;">Localidad: <em>*</em></label>
                        <select id="cmb_localidad_personal" campo="domicilio_localidad" class="cmb_localidad" style="width:285px;"> </select>
                    </div>

                <p>Consignar nuevo domicilio particular solo en el caso que fuera pertinente:</p>
                    <br />
                   <div class="bloque">
                        <label for="calle" style="display:inline-block; width:50px;">Calle: <em>*</em></label>
                        <input id="calle_nueva" campo="domicilio_calle_nuevo" type="text" placeholder="Calle" style="width:680px;" class="validar" />
                    </div>
                    <div class="bloque">
                        <label for="nro_nuevo" style="display:inline-block; width:50px;">Nro: <em>*</em></label>
                        <input id="nro_nuevo" campo="domicilio_numero_nuevo" type="number" placeholder="Nro" style="width: 100px;" class="validarNumero" />
                        <label for="piso" style="display:inline-block; width:40px; margin-left:50px;">Piso: <em>*</em></label>
                        <input id="piso_nuevo" campo="domicilio_piso_nuevo" type="number" placeholder="Piso" style="width: 80px;" class="validarNumero" />
                        <label for="dto" style="display:inline-block; width:40px; margin-left:50px;">Dto: <em>*</em></label>
                        <input id="dto_nuevo" campo="domicilio_depto_nuevo" type="text" placeholder="Depto" style="width: 80px;" class="validar" />
                        <label for="cp" style="display:inline-block; width:40px; margin-left:50px;">C.P: <em>*</em></label>
                        <input id="cp_nuevo" campo="domicilio_cp_nuevo" type="text" placeholder="C.P." style="width: 100px;" class="validar" />
                    </div>
                    <div class="bloque">
                        <label for="provincia">Provincia: <em>*</em></label>
                        <select id="provincia_nuevo" campo="domicilio_provincia_nuevo" class="cmb_provincia" style="width:273px;" ></select>
                        <label for="Localidad" style="margin-left:40px;">Localidad: <em>*</em></label>
                        <select id="localidad_nuevo" campo="domicilio_localidad_nuevo" class="cmb_localidad" style="width:285px;" > </select>
                    </div>
            </div>
            <hr />
            <p class="subtitulo">2) Estudios Formales:</p>
            <p>Estudio Completo:</p>
            <div style="margin-left:50px;">
                <p style="font-weight:bold;">a. Titulo declarado en su legajo:</p>
                <div style="margin-left:50px;">
                     <div class="bloque">
                        <label for="nivel_estudio" style="display:inline-block; width:150px;">Nivel de estudio:</label>
                        <input id="nivel_estudio" campo="nivel_estudio" type="text" placeholder="Nivel" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="titulo_obtenido" style="display:inline-block; width:150px;">Titulo obtenido:</label>
                        <input id="titulo_obtenido" campo="titulo_obtenido" type="text" placeholder="Título" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="institucion" style="display:inline-block; width:150px;">Institución otorgante:</label>
                        <input id="institucion" campo="institucion" type="text" placeholder="Institución" style="width:480px;" />
                    </div>
                </div>
          
            <p style="font-weight:bold;">b. Registre nuevo título: (solo completar en el caso de haber obtenido un título de igual o mayor nivel que el registrado)</p>
             <div style="margin-left:50px;">
                     <div class="bloque">
                        <label for="nivel_estudio_nuevo" style="display:inline-block; width:150px;">Nivel de estudio:</label>
                        <input id="nivel_estudio_nuevo" campo="nivel_estudio_nuevo" type="text" placeholder="Nivel" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="titulo_obtenido_nuevo" style="display:inline-block; width:150px;">Titulo obtenido:</label>
                        <input id="titulo_obtenido_nuevo" campo="titulo_obtenido_nuevo" type="text" placeholder="Título" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="institucion_nuevo" style="display:inline-block; width:150px;">Institución otorgante:</label>
                        <input id="institucion_nuevo" campo="institucion_nuevo" type="text" placeholder="Institución" style="width:480px;" />
                    </div>
                </div>
            </div>
              <hr />
               <p class="subtitulo">3) Registre la experiencia laboral en este Ministerio:</p>
                <div style="margin-left:50px;" >
                    <div class="bloque">
                        <label for="fecha_ingreso_apn" style="display:inline-block; width:150px;">Ingreso a la Administración Pública:</label>
                        <input id="fecha_ingreso_apn" campo="fecha_ingreso_apn" type="text" placeholder="Fecha Ingreso APN"  />
                    </div>
                   <div class="bloque">
                        <label for="fecha_ingreso_minis" style="display:inline-block; width:150px;">Ingreso al Ministerio:</label>
                        <input id="fecha_ingreso_minis" campo="fecha_ingreso_minis" type="text" placeholder="Fecha Ingreso Ministerio"  />
                    </div>
                  <div class="bloque">
                    <label for="fecha_ingreso_oficina" style="display:inline-block; width:150px;">Ingreso a su lugar de trabajo actual:</label>
                     <input id="fecha_ingreso_oficina" campo="fecha_ingreso_oficina" type="text" placeholder="Fecha Lugar actual"  />
                  </div>
                </div>
              <hr />
              <p class="subtitulo">4) Lugar actual de trabajo:</p>
               <div style="margin-left:50px;" >
                  <div class="bloque">
                    <label for="lugar_actual" style="display:inline-block; width:150px;">Área:</label>
                     <input id="lugar_actual" campo="lugar_actual" type="text" style="width:480px;" placeholder="Área"  />
                  </div>
                  <div class="bloque">
                    <label for="lugar_dependiente" style="display:inline-block; width:150px;">Unidad Organizativa de donde depende:</label>
                     <input id="lugar_dependiente" campo="lugar_dependiente" type="text" style="width:480px;" placeholder="Unidad dependiente"  />
                  </div>
                  <div class="bloque">
                    <label for="domicilio_area" style="display:inline-block; width:150px;">Domicilio:</label>
                     <input id="domicilio_area" campo="domicilio_area" type="text" style="width:480px;" placeholder="Domicilio del Area"  />
                  </div>
                  <div class="bloque">
                    <label for="telefono_area" style="display:inline-block; width:150px;">Teléfono:</label>
                     <input id="telefono_area" campo="telefono_area" type="text" style="width:480px;" placeholder="Telefono del area"  />
                  </div>
                </div>

                <input type=button id="btn_guardar_cambios" value="Guardar Cambios" />
        </div>

        <div id="plantillas">
            <div class="vista_persona_en_selector">
                <div id="contenedor_legajo" class="label label-warning">
                    <div id="titulo_legajo">Leg:</div>
                    <div id="legajo"></div>
                </div> 
                <div id="nombre"></div>
                <div id="apellido"></div>
                <div id="contenedor_doc" class="label label-default">
                    <div id="titulo_doc">Doc:</div>
                    <div id="documento"></div>         
                </div>   
            </div>
        </div>
    </form>
</body>

</html>