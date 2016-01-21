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
        <script type="text/javascript" src="../Scripts/ComboConBusquedaYAgregado.js"></script>
        <script type="text/javascript" src="Formularios.js"></script>
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
     <h1 style="text-align: center; margin-top: 30px;font-size: 2.9em;">Formulario <br />Relevamiento de Contratos</h1>
    
    <div id="buscador_de_personas">
        <p class="buscarPersona">Buscar persona:
            <div id="selector_usuario" class="selector_personas" style="margin-bottom: 0px;">
                <input id="buscador" type=hidden />
            </div>
        </p>
    </div>
   
        <hr />
        <div class="contenedor_formulario" style="display: none"> 
            <input id="btn_imprimir" type="button" class="btn btn-primary"  value="Imprimir" onclick="Imprimir()" />
            <p id="codigo_barra"></p>
            <p class="subtitulo">1) Datos Personales:</p>

            <div class="bloque">                    
                <label class="etiqueta_campo" for="cmb_tipoDocumento" style="margin-right: 10px" >  Tipo y Número de Documento:</label>
                <select id="cmb_tipoDocumento" campo="tipo_documento" style="margin-right: 10px;  margin-bottom: 10px;" rh-control-type="combo" rh-data-provider="TiposDeDocumento" rh-model-property="tipo_documento" disabled="disabled"> </select>
                <input id="txt_documento" campo="documento" type="text" style="flex-grow:100" disabled="disabled" />
            </div>

            <div class="bloque">
                <label for="nombre" style="margin-right: 10px">Nombre: </label>
                <input id="nombre" type="text" campo="nombre" rh-control-type="textbox" disabled="disabled" style="margin-right: 10px" maxlength="100" />
                <label for="apellido" style="margin-right: 10px">Apellido: </label>
                <input id="apellido" type="text" campo="apellido" style="flex-grow:100" rh-control-type="textbox" disabled="disabled" />
            </div>

            <div class="bloque">
                <label for="nivel">Nivel:</label>
                <input id="nivel" type="text" campo="nivel" rh-control-type="textbox" rh-model-property="Nivel" disabled="disabled" style="margin-right: 10px; width: 30px;" maxlength="2" />
                <label for="grado" style="margin-right: 10px;">Grado:</label>
                <input id="grado" type="text" campo="grado" style="margin-right: 10px; width: 30px;" rh-control-type="textbox" disabled="disabled"/>            
                <label for="funcion" style="margin-right: 10px"> Caracter del Servicio:</label>
                <input id="funcion" type="text" campo="funcion" style="flex-grow:100" rh-control-type="textbox" disabled="disabled"/>
            </div>

            <div class="bloque">
                <label class="etiqueta_campo" for="cmb_modalidadContratacion" style="margin-right: 10px;">Modalidad de Contratación: </label>
                <input id="modalidad" type="text" style="flex-grow:100" campo="modalidad" rh-control-type="textbox" disabled="disabled" />            
            </div>

            <div style="width:800px">
                <p>Domicilio Particular</p>
                <div class="bloque">
                    <label for="calle" style="margin-right: 10px">Calle:</label>
                    <input id="text_domicilio_calle_personal" campo="domicilio_calle" type="text" disabled="disabled" placeholder="Calle" style="flex-grow:100;" class="validar" />
                </div>
                <div class="bloque">
                    <label for="nro" style="display:inline-block; margin-right: 10px">Nro:</label>
                    <input id="text_domicilio_nro_personal" campo="domicilio_numero" type="number" disabled="disabled" placeholder="Nro" style="margin-right: 10px; width: 100px;" class="validarNumero" />
                    <label for="piso" style="display:inline-block; margin-right: 10px">Piso: </label>
                    <input id="text_domicilio_piso_personal" campo="domicilio_piso" type="number" disabled="disabled" placeholder="Piso" style="margin-right: 10px; width: 80px;" class="validarNumero" />
                    <label for="dto" style="display:inline-block; margin-right: 10px">Dto: </label>
                    <input id="text_domicilio_depto_personal" campo="domicilio_depto" type="text" disabled="disabled" placeholder="Depto" style="margin-right: 10px; width: 80px;" class="validar" />
                    <label for="cp" style="display:inline-block; margin-right: 10px">C.P: </label>
                    <input id="text_domicilio_cp_personal" campo="domicilio_cp" type="text" disabled="disabled" placeholder="C.P." style="flex-grow:100;" class="validar" />
                </div>
                <div class="bloque">                      
                    <label for="provincia" style="margin-right: 10px">Provincia: </label>
                    <input id="cmb_provincia_personal" type="text" campo="domicilio_provincia" rh-control-type="textbox" disabled="disabled" style="margin-right: 10px; width:130px;" />
                    <label for="Localidad" style="margin-right: 10px">Localidad: </label>
                    <input id="cmb_localidad_personal" type="text" campo="domicilio_localidad" rh-control-type="textbox" disabled="disabled"  style="margin-right: 10px; width:180px;" />
                    <label for="domicilio_telefono" style="display:inline-block; margin-right: 10px">T.E:</label>
                    <input id="domicilio_telefono" campo="domicilio_telefono" type="text" placeholder="Telefono" disabled="disabled" style="flex-grow:100;" class="validar" />
                </div>

                <p>Consignar nuevo domicilio particular solo en el caso que fuera pertinente:</p>
                <br />
                <div class="bloque">
                    <label for="calle" style="display:inline-block; margin-right: 10px">Calle: </label>
                    <input id="calle_nueva" campo="domicilio_calle_nuevo" type="text" placeholder="Calle" style="flex-grow:100;" class="validar" />
                </div>
                <div class="bloque">
                    <label for="nro_nuevo" style="display:inline-block; margin-right: 10px">Nro:</label>
                    <input id="nro_nuevo" campo="domicilio_numero_nuevo" type="number" placeholder="Nro" style="width: 100px; margin-right: 10px;" class="validarNumero" />
                    <label for="piso" style="display:inline-block; width:40px; margin-right: 10px">Piso: </label>
                    <input id="piso_nuevo" campo="domicilio_piso_nuevo" type="number" placeholder="Piso" style="width: 80px; margin-right: 10px;" class="validarNumero" />
                    <label for="dto" style="display:inline-block; width:40px; margin-right: 10px">Dto: </label>
                    <input id="dto_nuevo" campo="domicilio_depto_nuevo" type="text" placeholder="Depto" style="margin-right: 10px;width: 80px;" class="validar" />
                    <label for="cp" style="display:inline-block; width:40px; margin-right: 10px;">C.P: </label>
                    <input id="cp_nuevo" campo="domicilio_cp_nuevo" type="text" placeholder="C.P." style="flex-grow:100;" class="validar" />
                </div>
                <div class="bloque">
                    <label for="provincia" style="display:inline-block; margin-right: 10px">Provincia: </label>
                    <select id="provincia_nuevo" campo="domicilio_provincia_nuevo" rh-control-type="combo" rh-data-provider="Provincias" rh-propiedad-label= "Nombre" class="cmb_provincia" style="width:130px;margin-right: 10px;" ></select>
                    <label for="Localidad" style="margin-right: 10px">Localidad:</label>
                    <select id="localidad_nuevo" campo="domicilio_localidad_nuevo" rh-control-type="combo"  rh-data-provider="Localidades" rh-filter-key="IdProvincia" rh-propiedad-label= "Nombre" rh-id-filter-combo="provincia_nuevo" class="cmb_localidad" style="width:150px;margin-right: 10px" > </select>
                    <label for="domicilio_telefono_nuevo" style="display:inline-block; width:40px; margin-right: 10px">T.E:</label>
                    <input id="domicilio_telefono_nuevo" campo="domicilio_telefono_nuevo" type="text" placeholder="Telefono" style="flex-grow:100;" class="validar" />
                </div>
            </div>
            <hr />
            <p class="subtitulo">2) Estudios Formales:</p>
            <p>Estudio Completo:</p>
            <div style="margin-left:50px;">
                <p style="font-weight:bold;">a. Titulo declarado en su legajo:</p>
                <a style="cursor:pointer; font-size:1.2em;" class="toggle-text" data-toggle="collapse" id="cargar_mas_estudios">
                    <span>Cargar</span><span class="hidden">Ocultar</span> otros estudios (max 5)</a>
                <div class="caja_estudios caja_extra">
                     <div class="bloque_estudios">
                        <label for="nivel_estudio_1" style="display:inline-block; width:150px;margin-right: 10px">Nivel de estudio:</label>
                        <input id="nivel_estudio_1" campo="nivel_estudio_1" type="text" placeholder="Nivel" style="flex-grow:100;" />
                     </div>
                     <div class="bloque_estudios">
                        <label for="titulo_obtenido_1" style="display:inline-block; width:150px;margin-right: 10px">Titulo obtenido:</label>
                        <input id="titulo_obtenido_1" class="input_estudio_extra" campo="titulo_obtenido_1" type="text" placeholder="Título" style="flex-grow:100;" />
                    </div>
                     <div class="bloque_estudios">
                        <label for="institucion_1" style="display:inline-block; width:150px;margin-right: 10px">Institución otorgante:</label>
                        <input id="institucion_1" campo="institucion_1" type="text" placeholder="Institución" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="fecha_egreso_1" style="display:inline-block; width:150px;margin-right: 10px">Fecha Egreso:</label>
                        <input id="fecha_egreso_1" campo="fecha_egreso_1" type="text" placeholder="dd/mm/aaaa" style="flex-grow:100;" />
                    </div>
                </div>

             
                <div id="caja_estudio_2" class="caja_estudios caja_extra">
                    <div class="bloque_estudios">
                        <label for="nivel_estudio_2" style="display:inline-block; width:150px;margin-right: 10px">Nivel de estudio:</label>
                        <input id="nivel_estudio_2" campo="nivel_estudio_2" type="text" placeholder="Nivel" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="titulo_obtenido_2" style="display:inline-block; width:150px;margin-right: 10px">Titulo obtenido:</label>
                        <input id="titulo_obtenido_2" class="input_estudio_extra" campo="titulo_obtenido_2" type="text" placeholder="Título" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="institucion_2" style="display:inline-block; width:150px;margin-right: 10px">Institución otorgante:</label>
                        <input id="institucion_2" campo="institucion_2" type="text" placeholder="Institución" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="fecha_egreso_2" style="display:inline-block; width:150px;margin-right: 10px">Fecha Egreso:</label>
                        <input id="fecha_egreso_2" campo="fecha_egreso_2" type="text" placeholder="dd/mm/aaaa" style="flex-grow:100;" />
                    </div>
                </div>

                <div id="caja_estudio_3" class="caja_estudios caja_extra">
                    <div class="bloque_estudios">
                        <label for="nivel_estudio_3" style="display:inline-block; width:150px;margin-right: 10px">Nivel de estudio:</label>
                        <input id="nivel_estudio_3" campo="nivel_estudio_3" type="text" placeholder="Nivel" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="titulo_obtenido_3" style="display:inline-block; width:150px;margin-right: 10px">Titulo obtenido:</label>
                        <input id="titulo_obtenido_3" class="input_estudio_extra" campo="titulo_obtenido_3" type="text" placeholder="Título" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="institucion_3" style="display:inline-block; width:150px;margin-right: 10px">Institución otorgante:</label>
                        <input id="institucion_3" campo="institucion_3" type="text" placeholder="Institución" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="fecha_egreso_3" style="display:inline-block; width:150px;margin-right: 10px">Fecha Egreso:</label>
                        <input id="fecha_egreso_3" campo="fecha_egreso_3" type="text" placeholder="dd/mm/aaaa" style="flex-grow:100;" />
                    </div>
                </div>

                <div id="caja_estudio_4" class="caja_estudios caja_extra">
                    <div class="bloque_estudios">
                        <label for="nivel_estudio_4" style="display:inline-block; width:150px;margin-right: 10px">Nivel de estudio:</label>
                        <input id="nivel_estudio_4" campo="nivel_estudio_4" type="text" placeholder="Nivel" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="titulo_obtenido_4" style="display:inline-block; width:150px;margin-right: 10px">Titulo obtenido:</label>
                        <input id="titulo_obtenido_4" class="input_estudio_extra" campo="titulo_obtenido_4" type="text" placeholder="Título" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="institucion_4" style="display:inline-block; width:150px;margin-right: 10px">Institución otorgante:</label>
                        <input id="institucion_4" campo="institucion_4" type="text" placeholder="Institución" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="fecha_egreso_4" style="display:inline-block; width:150px;margin-right: 10px">Fecha Egreso:</label>
                        <input id="fecha_egreso_4" campo="fecha_egreso_4" type="text" placeholder="dd/mm/aaaa" style="flex-grow:100;" />
                    </div>
                </div>

                <div id="caja_estudio_5" class="caja_estudios caja_extra">
                    <div class="bloque_estudios">
                        <label for="nivel_estudio_5" style="display:inline-block; width:150px;margin-right: 10px">Nivel de estudio:</label>
                        <input id="nivel_estudio_5" campo="nivel_estudio_5" type="text" placeholder="Nivel" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="titulo_obtenido_5" style="display:inline-block; width:150px;margin-right: 10px">Titulo obtenido:</label>
                        <input id="titulo_obtenido_5" class="input_estudio_extra" campo="titulo_obtenido_5" type="text" placeholder="Título" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="institucion_5" style="display:inline-block; width:150px;margin-right: 10px">Institución otorgante:</label>
                        <input id="institucion_5" campo="institucion_5" type="text" placeholder="Institución" style="flex-grow:100;" />
                    </div>
                    <div class="bloque_estudios">
                        <label for="fecha_egreso_5" style="display:inline-block; width:150px;margin-right: 10px">Fecha Egreso:</label>
                        <input id="fecha_egreso_5" campo="fecha_egreso_5" type="text" placeholder="dd/mm/aaaa" style="flex-grow:100;" />
                    </div>
                </div>
                
          
            <!--<p style="font-weight:bold;">b. Registre nuevo título: (solo completar en el caso de haber obtenido un título de igual o mayor nivel que el registrado)</p>
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
                -->
            </div>
              <hr />
               <p class="subtitulo">3) Registre la experiencia laboral en este Ministerio:</p>
                <div style="margin-left:50px;" >
                    <div class="bloque">
                        <label for="fecha_ingreso_apn" style="display:inline-block; width:150px;">Ingreso a la Administración Pública:</label>
                        <input id="fecha_ingreso_apn" campo="fecha_ingreso_apn" type="text" placeholder="dd/mm/aaaa"  />
                    </div>
                   <div class="bloque">
                        <label for="fecha_ingreso_minis" style="display:inline-block; width:150px;">Ingreso al Ministerio:</label>
                        <input id="fecha_ingreso_minis" campo="fecha_ingreso_minis" type="text" placeholder="dd/mm/aaaa"  />
                    </div>
                  <div class="bloque">
                    <label for="fecha_ingreso_oficina" style="display:inline-block; width:150px;">Ingreso a su lugar de trabajo actual:</label>
                     <input id="fecha_ingreso_oficina" campo="fecha_ingreso_oficina" type="text" placeholder="dd/mm/aaaa"  />
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

                <hr />
        <div class="bloque">
            <p class="subtitulo">
                5) Tareas que desempeña: Numere por orden de importancia SOLAMENTE las 5 tareas
                fundamentales
            </p>
        </div>
        <div class="bloque">
            <label style="display: inline-block; width: 200px;">
                Máximo 1 número por renglón</label>
            <label style="display: inline-block; width: 200px;">
                1 -> Tarea mas importante</label>
            <label style="display: inline-block; width: 200px;">
                2 -> Tarea menos importante</label>
        </div>
        <%--Tareas Generales--%>
        <div style="margin-left: 50px;" id="contenedor_tarea_generales">
            <p style="font-weight: bold;">
                I. Tareas Generales: (D-E-F) (Asistente en oficios - Auxiliar - Ayudante)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label class="tareas_nro">
                        1</label>
                    <input id="Tarea_Gral_Mant_Edificio" campo="Tarea_Gral_Mant_Edificio" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Mantenimiento edificio (plomería, limpieza, electricidad)</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        2</label>
                    <input id="Tarea_Gral_Ascensorista" campo="Tarea_Gral_Ascensorista" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Ascensorista</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        3</label>
                    <input id="Tarea_Gral_Chofer" campo="Tarea_Gral_Chofer" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Chofer</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        4</label>
                    <input id="Tarea_Gral_Mozo" campo="Tarea_Gral_Mozo"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Mozo / Conserje</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        5</label>
                    <input id="Tarea_Gral_Seguridad" campo="Tarea_Gral_Seguridad" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Seguridad / Control de Acceso</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        6</label>
                    <input id="Tarea_Gral_Deposito" campo="Tarea_Gral_Deposito"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Depósito / Logística de Mercaderías</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        7</label>
                    <input id="Tarea_Gral_Otros" campo="Tarea_Gral_Otros" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas_otras">
                        Otros</label>
                    <label class="tareas_otras">
                        Detalle</label>
                    <input id="Tarea_Gral_Detalle" campo="Tarea_Gral_Detalle" type="text" style="width: 350px;" 
                        placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Tareas Administrativas--%>
        <div style="margin-left: 50px;" id="contenedor_tarea_administrativa">
            <p style="font-weight: bold;">
                II. Tareas Administrativas: (C-D-E-F) (Asistente técnico o experimentado - Auxiliar
                - Ayudante)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label class="tareas_nro">
                        1</label>
                    <input id="Tarea_Adm_Cadete" campo="Tarea_Adm_Cadete"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Cadete</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        2</label>
                    <input id="Tarea_Adm_Recepcionista" campo="Tarea_Adm_Recepcionista"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Recepcionista</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        3</label>
                    <input id="Tarea_Adm_Telefonista" campo="Tarea_Adm_Telefonista" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Telefonista</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        4</label>
                    <input id="Tarea_Adm_Logistica" campo="Tarea_Adm_Logistica"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Logística de documentación (mesa de entradas, archivo, notas)</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        5</label>
                    <input id="Tarea_Adm_Atencion_Publico" campo="Tarea_Adm_Atencion_Publico"  type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Atención al público (recepción, orientación y eventual derivación)</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        6</label>
                    <input id="Tarea_Adm_Reg_info" campo="Tarea_Adm_Reg_info" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Registro de información (data entry, carga de registros)</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        7</label>
                    <input id="Tarea_Adm_Elaboracion" campo="Tarea_Adm_Elaboracion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Elaboración de notas, memos, informes</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        8</label>
                    <input id="Tarea_Adm_Secretaria_Adm" campo="Tarea_Adm_Secretaria_Adm" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Secretaria administrativa</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        9</label>
                    <input id="Tarea_Adm_Secretaria_Priv" campo="Tarea_Adm_Secretaria_Priv" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Secretaria privada (asistencia directa a funcionario)</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        10</label>
                    <input id="Tarea_Adm_Rendiciones" campo="Tarea_Adm_Rendiciones" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Rendiciones y Pagos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        11</label>
                    <input id="Tarea_Adm_Compras" campo="Tarea_Adm_Compras" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Compras</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        12</label>
                    <input id="Tarea_Adm_Contrataciones" campo="Tarea_Adm_Contrataciones" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Contrataciones</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        13</label>
                    <input id="Tarea_Adm_Elaboracion" campo="Tarea_Adm_Elaboracion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Elaboración de Presupuestos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        14</label>
                    <input id="Tarea_Adm_Recepcion" campo="Tarea_Adm_Recepcion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Recepción y seguimiento de tramites
                    </label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        15</label>
                    <input id="Tarea_Adm_Otros" campo="Tarea_Adm_Otros" type="text" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas_otras">
                        Otros</label>
                    <label class="tareas_otras">
                        Detalle</label>
                    <input id="Tarea_Adm_Detalle" campo="Tarea_Adm_Detalle" type="text" style="width: 350px;"
                        placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Tareas Tecnicas--%>
        <div style="margin-left: 50px;" id="contendor_tarea_tecnica">
            <p style="font-weight: bold;">
                III. Tareas Técnicas: ( C-D ) (Asistente técnico o experimentado)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label class="tareas_nro">
                        1</label>
                    <input id="Tarea_Tec_Soporte_Tec" campo="Tarea_Tec_Soporte_Tec" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Soporte técnico / Reparación de equipos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        2</label>
                    <input id="Tarea_Tec_Programacion" campo="Tarea_Tec_Programacion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Programación informática</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        3</label>
                    <input id="Tarea_Tec_Procesamiento" campo="Tarea_Tec_Procesamiento"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Procesamiento de información</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        4</label>
                    <input id="Tarea_Tec_Manejo_BD" campo="Tarea_Tec_Manejo_BD" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Manejo de bases de datos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        5</label>
                    <input id="Tarea_Tec_Elab_Materiales" campo="Tarea_Tec_Elab_Materiales" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Elaboración de Materiales para difusión
                    </label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        6</label>
                    <input id="Tarea_Tec_Comunicacion" campo="Tarea_Tec_Comunicacion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Comunicación y Prensa</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        7</label>
                    <input id="Tarea_Tec_Promocion" campo="Tarea_Tec_Promocion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Promoción de políticas públicas</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        8</label>
                    <input id="Tarea_Tec_Apoyo" campo="Tarea_Tec_Apoyo" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Apoyo a emprendedores de la Economía Social
                    </label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        9</label>
                    <input id="Tarea_Tec_Fortalecimiento" campo="Tarea_Tec_Fortalecimiento" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Fortalecimiento de Cooperativas</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        10</label>
                    <input id="Tarea_Tec_Tareas_Territoriales" campo="Tarea_Tec_Tareas_Territoriales" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Tareas territoriales</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        11</label>
                    <input id="Tarea_Tec_Diseño" campo="Tarea_Tec_Diseño" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Diseño y dictado de talleres</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        12</label>
                    <input id="Tarea_Tec_Org_Eventos" campo="Tarea_Tec_Org_Eventos" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Organización de ferias y eventos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        13</label>
                    <input id="Tarea_Tec_Act_Capacitacion" campo="Tarea_Tec_Act_Capacitacion" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Actividades de capacitación</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        14</label>
                    <input id="Tarea_Tec_Asis_Emerg" campo="Tarea_Tec_Asis_Emerg" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Asistencia en emergencias</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        15</label>
                    <input id="Tarea_Tec_Seg_Alim" campo="Tarea_Tec_Seg_Alim" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Tareas inherentes a la Seguridad Alimentaria
                    </label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        16</label>
                    <input id="Tarea_Tec_Otros" campo="Tarea_Tec_Otros" style="width: 30px;"  type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas_otras">
                        Otros</label>
                    <label class="tareas_otras">
                        Detalle</label>
                    <input id="Tarea_Tec_Detalle" campo="Tarea_Tec_Detalle" type="text" style="width: 350px;"
                        placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Asistencia Tecnicas--%>
        <div style="margin-left: 50px;" id="contenedor_asistencia_tecnica">
            <p style="font-weight: bold;">
                IV. Asistencia Técnica: ( B-C-D de nivel terciario) (Técnico - Analista - Asistente
                técnico - Asistente experimentado - Profesional Inicial)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label class="tareas_nro">
                        1</label>
                    <input id="Asist_Tec_Form_Terc" campo="Asist_Tec_Form_Terc" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Tareas específicas de su formación terciaria</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        2</label>
                    <input id="Asist_Tec_Relevamiento" campo="Asist_Tec_Relevamiento"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Relevamiento</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        3</label>
                    <input id="Asist_Tec_Analisis_Info" campo="Asist_Tec_Analisis_Info" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Análisis de información (análisis, elaboración de informes y propuestas)</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        4</label>
                    <input id="Asist_Tec_Planificacion" campo="Asist_Tec_Planificacion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Planificación de tareas</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        5</label>
                    <input id="Asist_Tec_Ejecucion" campo="Asist_Tec_Ejecucion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Ejecución</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        6</label>
                    <input id="Asist_Tec_Elaboracion_Notas" campo="Asist_Tec_Elaboracion_Notas" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Elaboración de notas, memos, informes</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        7</label>
                    <input id="Asist_Tec_Soporte_Tec" campo="Asist_Tec_Soporte_Tec" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Soporte técnico / Reparación de equipos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        8</label>
                    <input id="Asist_Tec_Infraestructura" campo="Asist_Tec_Infraestructura" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Infraestructura edilicia</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        9</label>
                    <input id="Asist_Tec_Programacion" campo="Asist_Tec_Programacion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Programación informática</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        10</label>
                    <input id="Asist_Tec_Procesamiento" campo="Asist_Tec_Procesamiento" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Procesamiento de información</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        11</label>
                    <input id="Asist_Tec_Manejo_DB" campo="Asist_Tec_Manejo_DB" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Manejo de bases de datos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        12</label>
                    <input id="Asist_Tec_Diseño_Grafico" campo="Asist_Tec_Diseño_Grafico" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Diseño gráfico</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        13</label>
                    <input id="Asist_Tec_Diseño_Imag_Son" campo="Asist_Tec_Diseño_Imag_Son" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Diseño de imagen y sonido</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        14</label>
                    <input id="Asist_Tec_Elab_Mat" campo="Asist_Tec_Elab_Mat" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Elaboración de materiales para difusión
                    </label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        15</label>
                    <input id="Asist_Tec_Comunicacion" campo="Asist_Tec_Comunicacion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Comunicación y prensa</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        16</label>
                    <input id="Asist_Tec_Ceremonial" campo="Asist_Tec_Ceremonial" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Ceremonial y protocolo</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        17</label>
                    <input id="Asist_Tec_Prom_Pol_Pub" campo="Asist_Tec_Prom_Pol_Pub" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Promoción de políticas públicas</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        18</label>
                    <input id="Asist_Tec_Apoyo_Econom_Soc" campo="Asist_Tec_Apoyo_Econom_Soc" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Apoyo a emprendedores de la Economía Social
                    </label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        19</label>
                    <input id="Asist_Tec_Fortalecimiento_Coop" campo="Asist_Tec_Fortalecimiento_Coop" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Fortalecimiento de cooperativas</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        20</label>
                    <input id="Asist_Tec_Tareas_Territoriales" campo="Asist_Tec_Tareas_Territoriales" type="number" min="1" max="5" 
                         style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Tareas territoriales</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        21</label>
                    <input id="Asist_Tec_Diseño_Taller" campo="Asist_Tec_Diseño_Taller" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Diseño y dictado de talleres</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        22</label>
                    <input id="Asist_Tec_Org_Eventos" campo="Asist_Tec_Org_Eventos" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Organización de ferias y eventos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        23</label>
                    <input id="Asist_Tec_Act_Capa" campo="Asist_Tec_Act_Capa" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Actividades de capacitación</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        24</label>
                    <input id="Asist_Tec_Asist_Emerg" campo="Asist_Tec_Asist_Emerg" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Asistencia en emergencias</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        25</label>
                    <input id="Asist_Tec_Seg_Alim" campo="Asist_Tec_Seg_Alim" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Tareas inherentes a la Seguridad Alimentaria</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        26</label>
                    <input id="Asist_Tec_Articulacion" campo="Asist_Tec_Articulacion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Articulación con otras intituciones y/o organismos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        27</label>
                    <input id="Asist_Tec_Elaboracion_Mat_Dif" campo="Asist_Tec_Elaboracion_Mat_Dif" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Elaboración, seguimiento y/o control de convenios con intituciones</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        28</label>
                    <input id="Asist_Tec_Rendiciones" campo="Asist_Tec_Rendiciones" type="text" style="width: 30px;"
                        placeholder="" />
                    <label class="tareas">
                        Rendiciones y pagos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        29</label>
                    <input id="Asist_Tec_Compras" campo="Asist_Tec_Compras" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Compras</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        30</label>
                    <input id="Asist_Tec_Contrataciones" campo="Asist_Tec_Contrataciones" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Contrataciones</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        31</label>
                    <input id="Asist_Tec_Elab_Presup" campo="Asist_Tec_Elab_Presup" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Elaboración de presupuestos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        32</label>
                    <input id="Asist_Tec_Reg_Contables" campo="Asist_Tec_Reg_Contables" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Registros contables</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        33</label>
                    <input id="Asist_Tec_Recep_Seg_Tram" campo="Asist_Tec_Recep_Seg_Tram" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Recepción y seguimiento de trámites
                    </label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        34</label>
                    <input id="Asist_Tec_Otros" campo="Asist_Tec_Otros" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas_otras">
                        Otros</label>
                    <label class="tareas_otras">
                        Detalle</label>
                    <input id="Asist_Tec_Detalle" campo="Asist_Tec_Detalle" type="text" style="width: 350px;"
                        placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Servicios Profesionales--%>
        <div style="margin-left: 50px;" id="contenedor_servicios_profesionales">
            <p style="font-weight: bold;">
                V. Servicios Profesionales: (preferentemente Niveles B-C-D nivel Universitario)
                (Analista - Dictaminante - Responsable - Matriculados)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label class="tareas_nro">
                        1</label>
                    <input id="Serv_Prof_Form_Univ" campo="Serv_Prof_Form_Univ" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Tareas específicas de su formación universitaria</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        2</label>
                    <input id="Serv_Prof_Relevamiento" campo="Serv_Prof_Relevamiento" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Relevamiento</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        3</label>
                    <input id="Serv_Prof_Planificacion" campo="Serv_Prof_Planificacion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Planificación (Análisis, diseño, elaboración de propuestas)</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        4</label>
                    <input id="Serv_Prof_Ejecucion" campo="Serv_Prof_Ejecucion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Ejecución</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        5</label>
                    <input id="Serv_Prof_Eval_Monit" campo="Serv_Prof_Eval_Monit" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Evaluación y Monitoreo (Controles, seguimiento y detección de problemas)</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        6</label>
                    <input id="Serv_Prof_Elab_Dict" campo="Serv_Prof_Elab_Dict" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Elaboración de informes y/o dictámines</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        7</label>
                    <input id="Serv_Prof_Soporte_Tec" campo="Serv_Prof_Soporte_Tec" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Soporte técnico / Reparación de equipos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        8</label>
                    <input id="Serv_Prof_Infraestructura" campo="Serv_Prof_Infraestructura" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Infraestructura edilicia</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        9</label>
                    <input id="Serv_Prof_Programacion" campo="Serv_Prof_Programacion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Programación informática</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        10</label>
                    <input id="Serv_Prof_Procesamiento" campo="Serv_Prof_Procesamiento" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Procesamiento de información</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        11</label>
                    <input id="Serv_Prof_Manejo_DB" campo="Serv_Prof_Manejo_DB" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Manejo de bases de datos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        12</label>
                    <input id="Serv_Prof_Diseño_Grafico" campo="Serv_Prof_Diseño_Grafico" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Diseño gráfico</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        13</label>
                    <input id="Serv_Prof_Diseño_Imag_Son" campo="Serv_Prof_Diseño_Imag_Son" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Diseño de imagen y sonido</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        14</label>
                    <input id="Serv_Prof_Elab_Mat" campo="Serv_Prof_Elab_Mat" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Elaboración de materiales para difusión
                    </label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        15</label>
                    <input id="Serv_Prof_Comunicacion" campo="Serv_Prof_Comunicacion" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Comunicación y prensa</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        16</label>
                    <input id="Serv_Prof_Ceremonial" campo="Serv_Prof_Ceremonial" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Ceremonial y protocolo</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        17</label>
                    <input id="Serv_Prof_Prom_Pol_Pub" campo="Serv_Prof_Prom_Pol_Pub" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Promoción de políticas públicas</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        18</label>
                    <input id="Serv_Prof_Apoyo_Econom_Soc" campo="Serv_Prof_Apoyo_Econom_Soc" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Apoyo a emprendedores de la Economía Social
                    </label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        19</label>
                    <input id="Serv_Prof_Fortalecimiento_Coop" campo="Serv_Prof_Fortalecimiento_Coop" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Fortalecimiento de cooperativas</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        20</label>
                    <input id="Serv_Prof_Tareas_Territoriales" campo="Serv_Prof_Tareas_Territoriales" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Tareas territoriales</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        21</label>
                    <input id="Serv_Prof_Diseño_Taller" campo="Serv_Prof_Diseño_Taller" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Diseño y dictado de talleres</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        22</label>
                    <input id="Serv_Prof_Org_Eventos" campo="Serv_Prof_Org_Eventos" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Organización de ferias y eventos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        23</label>
                    <input id="Serv_Prof_Elab_Inf_Soc" campo="Serv_Prof_Elab_Inf_Soc"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Elaboración de Informes Sociales</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        24</label>
                    <input id="Serv_Prof_Act_Capa" campo="Serv_Prof_Act_Capa"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Actividades de capacitación</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        25</label>
                    <input id="Serv_Prof_Asist_Emerg" campo="Serv_Prof_Asist_Emerg" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Asistencia en emergencias</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        26</label>
                    <input id="Serv_Prof_Seg_Alim" campo="Serv_Prof_Seg_Alim"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Tareas inherentes a la Seguridad Alimentaria</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        27</label>
                    <input id="Serv_Prof_Articulacion" campo="Serv_Prof_Articulacion"  style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Articulación con otras intituciones y/o organismos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        28</label>
                    <input id="Serv_Prof_Elaboracion_Mat_Dif" campo="Serv_Prof_Elaboracion_Mat_Dif"type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Elaboración, seguimiento y/o control de convenios con intituciones</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        29</label>
                    <input id="Serv_Prof_Rendiciones" campo="Serv_Prof_Rendiciones" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Rendiciones y pagos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        30</label>
                    <input id="Serv_Prof_Compras" campo="Serv_Prof_Compras" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Compras</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        31</label>
                    <input id="Serv_Prof_Contrataciones" campo="Serv_Prof_Contrataciones" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Contrataciones</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        32</label>
                    <input id="Serv_Prof_Elab_Presup" campo="Serv_Prof_Elab_Presup" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Elaboración de presupuestos</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        33</label>
                    <input id="Serv_Prof_Reg_Contables" campo="Serv_Prof_Reg_Contables" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Registros contables</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        34</label>
                    <input id="Text34" campo="Serv_Prof_Otros" type="number" min="1" max="5"  style="width: 30px;" placeholder="" /> 
                    <label class="tareas_otras">
                        Otros</label>
                    <label class="tareas_otras">
                        Detalle</label>
                    <input id="Text35" campo="Serv_Prof_Detalle" type="text" style="width: 350px;" placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Tareas Adicionales--%>
        <div style="margin-left: 50px;" id="contenedor_tareas_adicionales">
            <p style="font-weight: bold;">
                VI. Tareas adicionales sólo Profesionales Avanzados: (preferentemente Niveles A-B-C
                nivel universit/posgr)</p>
            <p style="font-weight: bold;">
                (Responsable - Experto - Asesor o Especializado)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label class="tareas_nro">
                        1</label>
                    <input id="Tarea_Adic_Asesoramiento" campo="Tarea_Adic_Asesoramiento" type="number" min="1" max="5" 
                        style="width: 30px;" placeholder="" />
                    <label class="tareas">
                        Asesoramiento</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        2</label>
                    <input id="Tarea_Adic_Resol_Prob" campo="Tarea_Adic_Resol_Prob" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas">
                        Resolución de problemas (Toma de decisiones y solución de situaciones críticas)</label>
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        3</label>
                    <input id="Tarea_Adic_Coord_Equipo" campo="Tarea_Adic_Coord_Equipo" type="number" min="1" max="5"  style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 250px; margin-left:10px; margin-top:5px;">
                        Coordinación de equipos de trabajo</label>
                    <label style="display: inline-block; width: 170px; margin-left:10px; margin-top:5px;">
                        Cantidad de personas a cargo</label>
                    <input id="Tarea_Adic_Cant_Per_Cargo" campo="Tarea_Adic_Cant_Per_Cargo" type="text" style="width: 50px;"
                        placeholder="" />
                </div>
                <div class="bloque">
                    <label class="tareas_nro">
                        4</label>
                    <input id="Tarea_Adic_Otros" campo="Tarea_Adic_Otros" style="width: 30px;" type="number" min="1" max="5" 
                        placeholder="" />
                    <label class="tareas_otras">
                        Otros</label>
                    <label class="tareas_otras">
                        Detalle</label>
                    <input id="Tarea_Adic_Detalle" campo="Tarea_Adic_Detalle" type="text" style="width: 350px;"
                        placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
    

    <div style="margin-left: 50px;">
            <p style="font-weight: bold;">
                Función actual: (Describa las tres tareas principales que desarrolla)</p>
            <div style="margin-left: 50px;">
                <textarea id="Funcion_Actual" rows="7" cols="1" style="width:100%"></textarea>
            </div>
            <br />
            <div style="margin-left: 50px;">
                <div class="bloque" style="margin-bottom: 15px;">
                    <label style="display: inline-block; width: 100px;">Herramienta</label>

                    <select id="cboHerramientas" style="width: 200px" rh-control-type="combo" rh-data-provider="TiposCompetenciaInformatica" > </select>
            
                    <label style="display: inline-block; width: 100px; margin-left: 30px;">Conocimiento</label>
                    <select id="cboConocimiento" style="width: 200px" rh-control-type="combo" rh-data-provider="ConocimientoCompetenciaInformatica" rh-permite-agregar=true rh-id-filter-combo="cboHerramientas" rh-filter-key="Tipo" ></select>
                </div>
 <%--               <div class="bloque">
                    <label style="display: inline-block; width: 150px;">Utiliza en sus funciones</label>
                    <label style="display: inline-block; width: 10px;">Si</label>
                    <input id="chkUtilizaFuncion_SI" type="checkbox" style="width: 50px" />
                </div>--%>
                <div id="listadoConocimientos" style="margin: 10px; width: 660px;">
                    
                </div>
                <input type="button" id="btn_Agregar_Conocimientos" class="btn btn-primary" value="Agregar conocimiento" style="width:200px" />
            </div> 
    </div>
    <div style="margin-left: 50px;">
        
            <div style="margin-left: 50px;">
            <p>Otros Conocimientos:</p>
                <textarea id="Otros_Conocimientos" rows="4" cols="1" style="width:100%"></textarea>
            </div>
    </div>
    <hr />
    <div style="margin-left: 50px;">
        <p style="font-weight: bold;">
            6) Observaciones:</p>
        <div style="margin-left: 50px;">
            <p>Indique una observación relevante por renglón</p>
            <textarea id="Observaciones" rows="4" cols="1" style="width:100%"></textarea>
        </div>
    </div>
    <hr />                
    <div style="margin-left: 50px;">
        <p style="font-weight: bold;">
            Declaro conocer que la información volcada por mí en los ítems de este formulario tienen carácter de Declaración Jurada.
            Asimismo, se me ha informado que los datos de este formulario no serán publicados, serán debidamente protegidos y utilizados únicamente para lograr
            una mejor administración de los recursos humanos del Ministerio; y cuidando el tratamiento ético y bajo las normas legales vigentes.</p>
    </div>
    <br />
    <br />
    <br />
    <br />
    <div>
        <div style="text-align:center";>
            <label style="display: inline-block; width: 200px; text-align:center; "">_______________________</label>
            <label style="display: inline-block; width: 300px; text-align:center">_____________________________________</label> 
            <label style="display: inline-block; width: 200px; text-align:center">________________________</label> 
        </div>
        <div style="text-align:center";>
            <label style="display: inline-block; width: 200px; text-align:center; ">Firma</label>   
            <label style="display: inline-block; width: 300px; text-align:center">Aclaración</label>   
            <label style="display: inline-block; width: 200px; text-align:center">Fecha</label>   
        </div>
    </div>
    <hr />                
    <div style="margin-left: 50px;">
        <p style="font-weight: bold;">
            Firma, sello/aclaración y fecha del Responsable Directo:</p>
    </div>
    <br />
    <br />
    <br />
    <br />
    <div>
        <div style="text-align:center";>
            <label style="display: inline-block; width: 200px; text-align:center; "">_______________________</label>
            <label style="display: inline-block; width: 300px; text-align:center">_____________________________________</label> 
            <label style="display: inline-block; width: 200px; text-align:center">________________________</label> 
        </div>
        <div style="text-align:center";>
            <label style="display: inline-block; width: 200px; text-align:center; ">Firma</label>   
            <label style="display: inline-block; width: 300px; text-align:center">Aclaración</label>   
            <label style="display: inline-block; width: 200px; text-align:center">Fecha</label>   
        </div>
    </div>
    <br />
    <br />
    <input type="button" id="btn_guardar_cambios" class="btn btn-primary" value="Guardar Cambios" />
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

            <div class="caja_estilo_conocimiento"> 
                <input type=text class="conocimiento" disabled=disabled/> 
                <label style="margin-right: 10px;">Utiliza</label> 
                <input class="utiliza_conocimiento" type="checkbox" />
                <img src="../Imagenes/iconos/icono-eliminar.png" class="icono_eliminar"/>
            </div>
        </div>
    </form>
   
</body>
 <script type="text/javascript">
     function Imprimir() {

         window.print();
//         var data = $('.contenedor_formulario');
//         var mywindow = window.open('', 'my div', 'height=600,width=800');
//         mywindow.document.write('<html><head><title>Formulario</title>');
//         /*optional stylesheet*/ //mywindow.document.write('<link rel="stylesheet" href="main.css" type="text/css" />');
//         mywindow.document.write('</head><body >');
//         mywindow.document.write(data.html());
//         mywindow.document.write('</body></html>');

//         mywindow.document.close(); // necessary for IE >= 10
//         mywindow.focus(); // necessary for IE >= 10

//         mywindow.print();
//         mywindow.close();

//         return true;
     }
    
    </script>

</html>