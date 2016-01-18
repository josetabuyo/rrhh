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
            <p class="subtitulo">1) Datos Personales:</p>
            <div class="bloque">  
                  
                <label class="etiqueta_campo" for="cmb_tipoDocumento" style="width:50px;" >
                    Tipo y Número de Documento:</label>
                <select id="cmb_tipoDocumento" campo="tipo_documento" style="width: 100px;" rh-control-type="combo" rh-data-provider="TiposDeDocumento"
                    rh-model-property="tipo_documento" data-validar="haySeleccionEnCombo" disabled="disabled">
                </select>
                <input id="txt_documento" campo="documento" type="text" style="width: 500px;" rh-control-type="textbox"
                     data-validar="esNumeroNatural" disabled="disabled" />
            </div>
            <div class="bloque">
                <label for="nombre">Nombre: </label>
                <input id="nombre" type="text" campo="nombre" rh-control-type="textbox" disabled="disabled"
                    style="width: 295px;" data-validar="esNoBlanco" maxlength="100" />

                <label for="apellido" style="margin-left:15px;">Apellido: </label>
                <input id="apellido" type="text" campo="apellido" style="width: 300px;" rh-control-type="textbox" disabled="disabled"
                     data-validar="esNoBlanco" />
            </div>

            <div class="bloque">
                <label for="nivel">Nivel:</label>
                <input id="nivel" type="text" campo="nivel" rh-control-type="textbox" rh-model-property="Nivel" disabled="disabled"
                    style="width: 50px;" data-validar="esNoBlanco" maxlength="2" />

                <label for="grado" style="margin-left:15px;">Grado:</label>
                <input id="grado" type="text" campo="grado" style="width: 50px;" rh-control-type="textbox" disabled="disabled"/>              

                <label for="funcion"> Caracter del Servicio:</label>
                <input id="funcion" type="text" campo="funcion" style="width: 300px;" rh-control-type="textbox" disabled="disabled"/>
            </div>

            <div class="bloque">
                <label class="etiqueta_campo" for="cmb_modalidadContratacion">Modalidad de Contratación: </label>
                <input id="modalidad" style="width: 345px" campo="modalidad" rh-control-type="textbox" disabled="disabled" />            
            </div>

            <div class="bloque">
                <p>Domicilio Particular</p>
                    <div class="bloque">
                        <label for="calle" style="display:inline-block; width:50px;">Calle:</label>
                        <input id="text_domicilio_calle_personal" campo="domicilio_calle" type="text" disabled="disabled" placeholder="Calle" style="width:680px;" class="validar" />
                    </div>
                    <div class="bloque">
                        <label for="nro" style="display:inline-block; width:50px;">Nro:</label>
                        <input id="text_domicilio_nro_personal" campo="domicilio_numero" type="number" disabled="disabled" placeholder="Nro" style="width: 100px;" class="validarNumero" />
                        <label for="piso" style="display:inline-block; width:40px; margin-left:50px;">Piso: </label>
                        <input id="text_domicilio_piso_personal" campo="domicilio_piso" type="number" disabled="disabled" placeholder="Piso" style="width: 80px;" class="validarNumero" />
                        <label for="dto" style="display:inline-block; width:40px; margin-left:50px;">Dto: </label>
                        <input id="text_domicilio_depto_personal" campo="domicilio_depto" type="text" disabled="disabled" placeholder="Depto" style="width: 80px;" class="validar" />
                        <label for="cp" style="display:inline-block; width:40px; margin-left:50px;">C.P: </label>
                        <input id="text_domicilio_cp_personal" campo="domicilio_cp" type="text" disabled="disabled" placeholder="C.P." style="width: 100px;" class="validar" />
                    </div>
                    <div class="bloque">
                      
                        <label for="provincia">Provincia: </label>
                        <input id="cmb_provincia_personal" campo="domicilio_provincia" rh-control-type="textbox" disabled="disabled" style="width:130px;" />
                        <label for="Localidad" style="margin-left:40px;">Localidad: </label>
                        <input id="cmb_localidad_personal" campo="domicilio_localidad" rh-control-type="textbox" disabled="disabled"  style="width:180px;" />
                        <label for="domicilio_telefono" style="display:inline-block; margin-left:20px;">T.E:</label>
                        <input id="domicilio_telefono" campo="domicilio_telefono" type="text" placeholder="Telefono" disabled="disabled" style="width: 192px;" class="validar" />
                    </div>

                <p>Consignar nuevo domicilio particular solo en el caso que fuera pertinente:</p>
                    <br />
                   <div class="bloque">
                        <label for="calle" style="display:inline-block; width:50px;">Calle: </label>
                        <input id="calle_nueva" campo="domicilio_calle_nuevo" type="text" placeholder="Calle" style="width:680px;" class="validar" />
                    </div>
                    <div class="bloque">
                        <label for="nro_nuevo" style="display:inline-block; width:50px;">Nro:</label>
                        <input id="nro_nuevo" campo="domicilio_numero_nuevo" type="number" placeholder="Nro" style="width: 100px;" class="validarNumero" />
                        <label for="piso" style="display:inline-block; width:40px; margin-left:50px;">Piso: </label>
                        <input id="piso_nuevo" campo="domicilio_piso_nuevo" type="number" placeholder="Piso" style="width: 80px;" class="validarNumero" />
                        <label for="dto" style="display:inline-block; width:40px; margin-left:50px;">Dto: </label>
                        <input id="dto_nuevo" campo="domicilio_depto_nuevo" type="text" placeholder="Depto" style="width: 80px;" class="validar" />
                        <label for="cp" style="display:inline-block; width:40px; margin-left:50px;">C.P: </label>
                        <input id="cp_nuevo" campo="domicilio_cp_nuevo" type="text" placeholder="C.P." style="width: 100px;" class="validar" />
                    </div>
                    <div class="bloque">
                        <label for="provincia">Provincia: </label>
                        <select id="provincia_nuevo" campo="domicilio_provincia_nuevo" rh-control-type="combo" rh-data-provider="Provincias" rh-propiedad-label= "Nombre" class="cmb_provincia" style="width:130px;" ></select>
                        <label for="Localidad" style="margin-left:40px;">Localidad:</label>
                        <select id="localidad_nuevo" campo="domicilio_localidad_nuevo" rh-control-type="combo"  rh-data-provider="Localidades" rh-filter-key="IdProvincia" rh-propiedad-label= "Nombre" 
                                    rh-id-filter-combo="provincia_nuevo" class="cmb_localidad" style="width:150px;" > </select>
                        <label for="domicilio_telefono_nuevo" style="display:inline-block; width:40px; margin-left:50px;">T.E:</label>
                        <input id="domicilio_telefono_nuevo" campo="domicilio_telefono_nuevo" type="text" placeholder="Telefono" style="width: 192px;" class="validar" />
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
                     <div class="bloque">
                        <label for="nivel_estudio_1" style="display:inline-block; width:150px;">Nivel de estudio:</label>
                        <input id="nivel_estudio_1" campo="nivel_estudio_1" type="text" placeholder="Nivel" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="titulo_obtenido_1" style="display:inline-block; width:150px;">Titulo obtenido:</label>
                        <input id="titulo_obtenido_1" class="input_estudio_extra" campo="titulo_obtenido_1" type="text" placeholder="Título" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="institucion_1" style="display:inline-block; width:150px;">Institución otorgante:</label>
                        <input id="institucion_1" campo="institucion_1" type="text" placeholder="Institución" style="width:480px;" />
                    </div>
                    <div class="bloque">
                        <label for="fecha_egreso_1" style="display:inline-block; width:150px;">Fecha Egreso:</label>
                        <input id="fecha_egreso_1" campo="fecha_egreso_1" type="text" placeholder="dd/mm/aaaa" style="width:480px;" />
                    </div>
                </div>

             
                   <div id="caja_estudio_2" class="caja_estudios caja_extra">
                         <div class="bloque">
                            <label for="nivel_estudio_2" style="display:inline-block; width:150px;">Nivel de estudio:</label>
                            <input id="nivel_estudio_2"  campo="nivel_estudio_2" type="text" placeholder="Nivel" style="width:480px;" />
                        </div>
                         <div class="bloque">
                            <label for="titulo_obtenido_2" style="display:inline-block; width:150px;">Titulo obtenido:</label>
                        <input id="titulo_obtenido_2" class="input_estudio_extra" campo="titulo_obtenido_2" type="text" placeholder="Título" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="institucion_2" style="display:inline-block; width:150px;">Institución otorgante:</label>
                        <input id="institucion_2" campo="institucion_2" type="text" placeholder="Institución" style="width:480px;" />
                    </div>
                    <div class="bloque">
                        <label for="fecha_egreso_2" style="display:inline-block; width:150px;">Fecha Egreso:</label>
                        <input id="fecha_egreso_2" campo="fecha_egreso_2" type="text" placeholder="dd/mm/aaaa" style="width:480px;" />
                    </div>
                    </div>
                    <div id="caja_estudio_3" class="caja_estudios caja_extra">
                     <div class="bloque">
                        <label for="nivel_estudio_3" style="display:inline-block; width:150px;">Nivel de estudio:</label>
                        <input id="nivel_estudio_3" campo="nivel_estudio_3" type="text" placeholder="Nivel" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="titulo_obtenido_3" style="display:inline-block; width:150px;">Titulo obtenido:</label>
                        <input id="titulo_obtenido_3" class="input_estudio_extra" campo="titulo_obtenido_3" type="text" placeholder="Título" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="institucion_3" style="display:inline-block; width:150px;">Institución otorgante:</label>
                        <input id="institucion_3" campo="institucion_3" type="text" placeholder="Institución" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="fecha_egreso_3" style="display:inline-block; width:150px;">Fecha Egreso:</label>
                        <input id="fecha_egreso_3" campo="fecha_egreso_3" type="text" placeholder="dd/mm/aaaa" style="width:480px;" />
                    </div>
                    </div>
                    <div id="caja_estudio_4" class="caja_estudios caja_extra">
                     <div class="bloque">
                        <label for="nivel_estudio_4" style="display:inline-block; width:150px;">Nivel de estudio:</label>
                        <input id="nivel_estudio_4" campo="nivel_estudio_4" type="text" placeholder="Nivel" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="titulo_obtenido_4" style="display:inline-block; width:150px;">Titulo obtenido:</label>
                        <input id="titulo_obtenido_4" class="input_estudio_extra" campo="titulo_obtenido_4" type="text" placeholder="Título" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="institucion_4" style="display:inline-block; width:150px;">Institución otorgante:</label>
                        <input id="institucion_4" campo="institucion_4" type="text" placeholder="Institución" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="fecha_egreso_4" style="display:inline-block; width:150px;">Fecha Egreso:</label>
                        <input id="fecha_egreso_4" campo="fecha_egreso_4" type="text" placeholder="dd/mm/aaaa" style="width:480px;" />
                    </div>
                    </div>
                    <div id="caja_estudio_5" class="caja_estudios caja_extra">
                     <div class="bloque">
                        <label for="nivel_estudio_5" style="display:inline-block; width:150px;">Nivel de estudio:</label>
                        <input id="nivel_estudio_5" campo="nivel_estudio_5" type="text" placeholder="Nivel" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="titulo_obtenido_5" style="display:inline-block; width:150px;">Titulo obtenido:</label>
                        <input id="titulo_obtenido_5" class="input_estudio_extra" campo="titulo_obtenido_5" type="text" placeholder="Título" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="institucion_5" style="display:inline-block; width:150px;">Institución otorgante:</label>
                        <input id="institucion_5" campo="institucion_5" type="text" placeholder="Institución" style="width:480px;" />
                    </div>
                     <div class="bloque">
                        <label for="fecha_egreso_5" style="display:inline-block; width:150px;">Fecha Egreso:</label>
                        <input id="fecha_egreso_5" campo="fecha_egreso_5" type="text" placeholder="dd/mm/aaaa" style="width:480px;" />
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
        <div style="margin-left: 50px;">
            <p style="font-weight: bold;">
                I. Tareas Generales: (D-E-F) (Asistente en oficios - Auxiliar - Ayudante)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        1</label>
                    <input id="Tarea_Gral_Mant_Edificio" campo="Tarea_Gral_Mant_Edificio" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Mantenimiento edificio (plomería, limpieza, electricidad)</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        2</label>
                    <input id="Tarea_Gral_Ascensorista" campo="Tarea_Gral_Ascensorista" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Ascensorista</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        3</label>
                    <input id="Tarea_Gral_Chofer" campo="Tarea_Gral_Chofer" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Chofer</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        4</label>
                    <input id="Tarea_Gral_Mozo" campo="Tarea_Gral_Mozo" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Mozo / Conserje</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        5</label>
                    <input id="Tarea_Gral_Seguridad" campo="Tarea_Gral_Seguridad" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Seguridad / Control de Acceso</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        6</label>
                    <input id="Tarea_Gral_Deposito" campo="Tarea_Gral_Deposito" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Depósito / Logística de Mercaderías</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        7</label>
                    <input id="Tarea_Gral_Otros" campo="Tarea_Gral_Otros" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 60px;">
                        Otros</label>
                    <label style="display: inline-block; width: 60px;">
                        Detalle</label>
                    <input id="Tarea_Gral_Detalle" campo="Tarea_Gral_Detalle" type="text" style="width: 350px;"
                        placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Tareas Administrativas--%>
        <div style="margin-left: 50px;">
            <p style="font-weight: bold;">
                II. Tareas Administrativas: (C-D-E-F) (Asistente técnico o experimentado - Auxiliar
                - Ayudante)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        1</label>
                    <input id="Tarea_Adm_Cadete" campo="Tarea_Adm_Cadete" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Cadete</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        2</label>
                    <input id="Tarea_Adm_Recepcionista" campo="Tarea_Adm_Recepcionista" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Recepcionista</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        3</label>
                    <input id="Tarea_Adm_Telefonista" campo="Tarea_Adm_Telefonista" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Telefonista</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        4</label>
                    <input id="Tarea_Adm_Logistica" campo="Tarea_Adm_Logistica" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Logística de documentación (mesa de entradas, archivo, notas)</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        5</label>
                    <input id="Tarea_Adm_Atencion_Publico" campo="Tarea_Adm_Atencion_Publico" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Atención al público (recepción, orientación y eventual derivación)</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        6</label>
                    <input id="Tarea_Adm_Reg_info" campo="Tarea_Adm_Reg_info" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Registro de información (data entry, carga de registros)</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        7</label>
                    <input id="Tarea_Adm_Elaboracion" campo="Tarea_Adm_Elaboracion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de notas, memos, informes</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        8</label>
                    <input id="Tarea_Adm_Secretaria_Adm" campo="Tarea_Adm_Secretaria_Adm" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Secretaria administrativa</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        9</label>
                    <input id="Tarea_Adm_Secretaria_Priv" campo="Tarea_Adm_Secretaria_Priv" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Secretaria privada (asistencia directa a funcionario)</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        10</label>
                    <input id="Tarea_Adm_Rendiciones" campo="Tarea_Adm_Rendiciones" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Rendiciones y Pagos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        11</label>
                    <input id="Tarea_Adm_Compras" campo="Tarea_Adm_Compras" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Compras</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        12</label>
                    <input id="Tarea_Adm_Contrataciones" campo="Tarea_Adm_Contrataciones" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Contrataciones</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        13</label>
                    <input id="Tarea_Adm_Elaboracion" campo="Tarea_Adm_Elaboracion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de Presupuestos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        14</label>
                    <input id="Tarea_Adm_Recepcion" campo="Tarea_Adm_Recepcion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Recepción y seguimiento de tramites
                    </label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        15</label>
                    <input id="Tarea_Adm_Otros" campo="Tarea_Adm_Otros" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 60px;">
                        Otros</label>
                    <label style="display: inline-block; width: 60px;">
                        Detalle</label>
                    <input id="Tarea_Adm_Detalle" campo="Tarea_Adm_Detalle" type="text" style="width: 350px;"
                        placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Tareas Tecnicas--%>
        <div style="margin-left: 50px;">
            <p style="font-weight: bold;">
                III. Tareas Técnicas: ( C-D ) (Asistente técnico o experimentado)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        1</label>
                    <input id="Tarea_Tec_Soporte_Tec" campo="Tarea_Tec_Soporte_Tec" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Soporte técnico / Reparación de equipos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        2</label>
                    <input id="Tarea_Tec_Programacion" campo="Tarea_Tec_Programacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Programación informática</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        3</label>
                    <input id="Tarea_Tec_Procesamiento" campo="Tarea_Tec_Procesamiento" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Procesamiento de información</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        4</label>
                    <input id="Tarea_Tec_Manejo_BD" campo="Tarea_Tec_Manejo_BD" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Manejo de bases de datos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        5</label>
                    <input id="Tarea_Tec_Elab_Materiales" campo="Tarea_Tec_Elab_Materiales" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de Materiales para difusión
                    </label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        6</label>
                    <input id="Tarea_Tec_Comunicacion" campo="Tarea_Tec_Comunicacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Comunicación y Prensa</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        7</label>
                    <input id="Tarea_Tec_Promocion" campo="Tarea_Tec_Promocion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Promoción de políticas públicas</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        8</label>
                    <input id="Tarea_Tec_Apoyo" campo="Tarea_Tec_Apoyo" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Apoyo a emprendedores de la Economía Social
                    </label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        9</label>
                    <input id="Tarea_Tec_Fortalecimiento" campo="Tarea_Tec_Fortalecimiento" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Fortalecimiento de Cooperativas</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        10</label>
                    <input id="Tarea_Tec_Tareas_Territoriales" campo="Tarea_Tec_Tareas_Territoriales"
                        type="text" style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Tareas territoriales</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        11</label>
                    <input id="Tarea_Tec_Diseño" campo="Tarea_Tec_Diseño" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Diseño y dictado de talleres</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        12</label>
                    <input id="Tarea_Tec_Org_Eventos" campo="Tarea_Tec_Org_Eventos" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Organización de ferias y eventos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        13</label>
                    <input id="Tarea_Tec_Act_Capacitacion" campo="Tarea_Tec_Act_Capacitacion" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Actividades de capacitación</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        14</label>
                    <input id="Tarea_Tec_Asis_Emerg" campo="Tarea_Tec_Asis_Emerg" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Asistencia en emergencias</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        15</label>
                    <input id="Tarea_Tec_Seg_Alim" campo="Tarea_Tec_Seg_Alim" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Tareas inherentes a la Seguridad Alimentaria
                    </label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        16</label>
                    <input id="Tarea_Tec_Otros" campo="Tarea_Tec_Otros" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 60px;">
                        Otros</label>
                    <label style="display: inline-block; width: 60px;">
                        Detalle</label>
                    <input id="Tarea_Tec_Detalle" campo="Tarea_Tec_Detalle" type="text" style="width: 350px;"
                        placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Asistencia Tecnicas--%>
        <div style="margin-left: 50px;">
            <p style="font-weight: bold;">
                IV. Asistencia Técnica: ( B-C-D de nivel terciario) (Técnico - Analista - Asistente
                técnico - Asistente experimentado - Profesional Inicial)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        1</label>
                    <input id="Asist_Tec_Form_Terc" campo="Asist_Tec_Form_Terc" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Tareas específicas de su formación terciaria</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        2</label>
                    <input id="Asist_Tec_Relevamiento" campo="Asist_Tec_Relevamiento" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Relevamiento</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        3</label>
                    <input id="Asist_Tec_Analisis_Info" campo="Asist_Tec_Analisis_Info" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 450px;">
                        Análisis de información (análisis, elaboración de informes y propuestas)</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        4</label>
                    <input id="Asist_Tec_Planificacion" campo="Asist_Tec_Planificacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Planificación de tareas</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        5</label>
                    <input id="Asist_Tec_Ejecucion" campo="Asist_Tec_Ejecucion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Ejecución</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        6</label>
                    <input id="Asist_Tec_Elaboracion_Notas" campo="Asist_Tec_Elaboracion_Notas" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de notas, memos, informes</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        7</label>
                    <input id="Asist_Tec_Soporte_Tec" campo="Asist_Tec_Soporte_Tec" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Soporte técnico / Reparación de equipos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        8</label>
                    <input id="Asist_Tec_Infraestructura" campo="Asist_Tec_Infraestructura" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Infraestructura edilicia</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        9</label>
                    <input id="Asist_Tec_Programacion" campo="Asist_Tec_Programacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Programación informática</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        10</label>
                    <input id="Asist_Tec_Procesamiento" campo="Asist_Tec_Procesamiento" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Procesamiento de información</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        11</label>
                    <input id="Asist_Tec_Manejo_DB" campo="Asist_Tec_Manejo_DB" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Manejo de bases de datos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        12</label>
                    <input id="Asist_Tec_Diseño_Grafico" campo="Asist_Tec_Diseño_Grafico" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Diseño gráfico</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        13</label>
                    <input id="Asist_Tec_Diseño_Imag_Son" campo="Asist_Tec_Diseño_Imag_Son" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Diseño de imagen y sonido</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        14</label>
                    <input id="Asist_Tec_Elab_Mat" campo="Asist_Tec_Elab_Mat" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de materiales para difusión
                    </label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        15</label>
                    <input id="Asist_Tec_Comunicacion" campo="Asist_Tec_Comunicacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Comunicación y prensa</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        16</label>
                    <input id="Asist_Tec_Ceremonial" campo="Asist_Tec_Ceremonial" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Ceremonial y protocolo</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        17</label>
                    <input id="Asist_Tec_Prom_Pol_Pub" campo="Asist_Tec_Prom_Pol_Pub" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Promoción de políticas públicas</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        18</label>
                    <input id="Asist_Tec_Apoyo_Econom_Soc" campo="Asist_Tec_Apoyo_Econom_Soc" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Apoyo a emprendedores de la Economía Social
                    </label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        19</label>
                    <input id="Asist_Tec_Fortalecimiento_Coop" campo="Asist_Tec_Fortalecimiento_Coop"
                        type="text" style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Fortalecimiento de cooperativas</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        20</label>
                    <input id="Asist_Tec_Tareas_Territoriales" campo="Asist_Tec_Tareas_Territoriales"
                        type="text" style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Tareas territoriales</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        21</label>
                    <input id="Asist_Tec_Diseño_Taller" campo="Asist_Tec_Diseño_Taller" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Diseño y dictado de talleres</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        22</label>
                    <input id="Asist_Tec_Org_Eventos" campo="Asist_Tec_Org_Eventos" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Organización de ferias y eventos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        23</label>
                    <input id="Asist_Tec_Act_Capa" campo="Asist_Tec_Act_Capa" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Actividades de capacitación</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        24</label>
                    <input id="Asist_Tec_Asist_Emerg" campo="Asist_Tec_Asist_Emerg" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Asistencia en emergencias</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        25</label>
                    <input id="Asist_Tec_Seg_Alim" campo="Asist_Tec_Seg_Alim" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Tareas inherentes a la Seguridad Alimentaria</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        26</label>
                    <input id="Asist_Tec_Articulacion" campo="Asist_Tec_Articulacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Articulación con otras intituciones y/o organismos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        27</label>
                    <input id="Asist_Tec_Elaboracion_Mat_Dif" campo="Asist_Tec_Elaboracion_Mat_Dif" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración, seguimiento y/o control de convenios con intituciones</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        28</label>
                    <input id="Asist_Tec_Rendiciones" campo="Asist_Tec_Rendiciones" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Rendiciones y pagos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        29</label>
                    <input id="Asist_Tec_Compras" campo="Asist_Tec_Compras" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Compras</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        30</label>
                    <input id="Asist_Tec_Contrataciones" campo="Asist_Tec_Contrataciones" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Contrataciones</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        31</label>
                    <input id="Asist_Tec_Elab_Presup" campo="Asist_Tec_Elab_Presup" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de presupuestos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        32</label>
                    <input id="Asist_Tec_Reg_Contables" campo="Asist_Tec_Reg_Contables" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Registros contables</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        33</label>
                    <input id="Asist_Tec_Recep_Seg_Tram" campo="Asist_Tec_Recep_Seg_Tram" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Recepción y seguimiento de trámites
                    </label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        34</label>
                    <input id="Asist_Tec_Otros" campo="Asist_Tec_Otros" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 60px;">
                        Otros</label>
                    <label style="display: inline-block; width: 60px;">
                        Detalle</label>
                    <input id="Asist_Tec_Detalle" campo="Asist_Tec_Detalle" type="text" style="width: 350px;"
                        placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Servicios Profesionales--%>
        <div style="margin-left: 50px;">
            <p style="font-weight: bold;">
                V. Servicios Profesionales: (preferentemente Niveles B-C-D nivel Universitario)
                (Analista - Dictaminante - Responsable - Matriculados)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        1</label>
                    <input id="Serv_Prof_Form_Univ" campo="Serv_Prof_Form_Univ" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Tareas específicas de su formación universitaria</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        2</label>
                    <input id="Serv_Prof_Relevamiento" campo="Serv_Prof_Relevamiento" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Relevamiento</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        3</label>
                    <input id="Serv_Prof_Planificacion" campo="Serv_Prof_Planificacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 450px;">
                        Planificación (Análisis, diseño, elaboración de propuestas)</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        4</label>
                    <input id="Serv_Prof_Ejecucion" campo="Serv_Prof_Ejecucion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Ejecución</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        5</label>
                    <input id="Serv_Prof_Eval_Monit" campo="Serv_Prof_Eval_Monit" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Evaluación y Monitoreo (Controles, seguimiento y detección de problemas)</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        6</label>
                    <input id="Serv_Prof_Elab_Dict" campo="Serv_Prof_Elab_Dict" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de informes y/o dictámines</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        7</label>
                    <input id="Serv_Prof_Soporte_Tec" campo="Serv_Prof_Soporte_Tec" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Soporte técnico / Reparación de equipos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        8</label>
                    <input id="Serv_Prof_Infraestructura" campo="Serv_Prof_Infraestructura" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Infraestructura edilicia</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        9</label>
                    <input id="Serv_Prof_Programacion" campo="Serv_Prof_Programacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Programación informática</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        10</label>
                    <input id="Serv_Prof_Procesamiento" campo="Serv_Prof_Procesamiento" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Procesamiento de información</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        11</label>
                    <input id="Serv_Prof_Manejo_DB" campo="Serv_Prof_Manejo_DB" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Manejo de bases de datos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        12</label>
                    <input id="Serv_Prof_Diseño_Grafico" campo="Serv_Prof_Diseño_Grafico" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Diseño gráfico</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        13</label>
                    <input id="Serv_Prof_Diseño_Imag_Son" campo="Serv_Prof_Diseño_Imag_Son" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Diseño de imagen y sonido</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        14</label>
                    <input id="Serv_Prof_Elab_Mat" campo="Serv_Prof_Elab_Mat" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de materiales para difusión
                    </label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        15</label>
                    <input id="Serv_Prof_Comunicacion" campo="Serv_Prof_Comunicacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Comunicación y prensa</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        16</label>
                    <input id="Serv_Prof_Ceremonial" campo="Serv_Prof_Ceremonial" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Ceremonial y protocolo</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        17</label>
                    <input id="Serv_Prof_Prom_Pol_Pub" campo="Serv_Prof_Prom_Pol_Pub" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Promoción de políticas públicas</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        18</label>
                    <input id="Serv_Prof_Apoyo_Econom_Soc" campo="Serv_Prof_Apoyo_Econom_Soc" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Apoyo a emprendedores de la Economía Social
                    </label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        19</label>
                    <input id="Serv_Prof_Fortalecimiento_Coop" campo="Serv_Prof_Fortalecimiento_Coop"
                        type="text" style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Fortalecimiento de cooperativas</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        20</label>
                    <input id="Serv_Prof_Tareas_Territoriales" campo="Serv_Prof_Tareas_Territoriales"
                        type="text" style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Tareas territoriales</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        21</label>
                    <input id="Serv_Prof_Diseño_Taller" campo="Serv_Prof_Diseño_Taller" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Diseño y dictado de talleres</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        22</label>
                    <input id="Serv_Prof_Org_Eventos" campo="Serv_Prof_Org_Eventos" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Organización de ferias y eventos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        23</label>
                    <input id="Serv_Prof_Elab_Inf_Soc" campo="Serv_Prof_Elab_Inf_Soc" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de Informes Sociales</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        24</label>
                    <input id="Serv_Prof_Act_Capa" campo="Serv_Prof_Act_Capa" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Actividades de capacitación</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        25</label>
                    <input id="Serv_Prof_Asist_Emerg" campo="Serv_Prof_Asist_Emerg" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Asistencia en emergencias</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        26</label>
                    <input id="Serv_Prof_Seg_Alim" campo="Serv_Prof_Seg_Alim" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Tareas inherentes a la Seguridad Alimentaria</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        27</label>
                    <input id="Serv_Prof_Articulacion" campo="Serv_Prof_Articulacion" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Articulación con otras intituciones y/o organismos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        28</label>
                    <input id="Serv_Prof_Elaboracion_Mat_Dif" campo="Serv_Prof_Elaboracion_Mat_Dif" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración, seguimiento y/o control de convenios con intituciones</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        29</label>
                    <input id="Serv_Prof_Rendiciones" campo="Serv_Prof_Rendiciones" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Rendiciones y pagos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        30</label>
                    <input id="Serv_Prof_Compras" campo="Serv_Prof_Compras" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Compras</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        31</label>
                    <input id="Serv_Prof_Contrataciones" campo="Serv_Prof_Contrataciones" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Contrataciones</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        32</label>
                    <input id="Serv_Prof_Elab_Presup" campo="Serv_Prof_Elab_Presup" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Elaboración de presupuestos</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        33</label>
                    <input id="Serv_Prof_Reg_Contables" campo="Serv_Prof_Reg_Contables" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Registros contables</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        34</label>
                    <input id="Text34" campo="Serv_Prof_Otros" type="text" style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 60px;">
                        Otros</label>
                    <label style="display: inline-block; width: 60px;">
                        Detalle</label>
                    <input id="Text35" campo="Serv_Prof_Detalle" type="text" style="width: 350px;" placeholder="Tarea que desempeña" />
                </div>
            </div>
        </div>
        <%--Tareas Adicionales--%>
        <div style="margin-left: 50px;">
            <p style="font-weight: bold;">
                VI. Tareas adicionales sólo Profesionales Avanzados: (preferentemente Niveles A-B-C
                nivel universit/posgr)</p>
            <p style="font-weight: bold;">
                (Responsable - Experto - Asesor o Especializado)</p>
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        1</label>
                    <input id="Tarea_Adic_Asesoramiento" campo="Tarea_Adic_Asesoramiento" type="text"
                        style="width: 30px;" placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Asesoramiento</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        2</label>
                    <input id="Tarea_Adic_Resol_Prob" campo="Tarea_Adic_Resol_Prob" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 400px;">
                        Resolución de problemas (Toma de decisiones y solución de situaciones críticas)</label>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        3</label>
                    <input id="Tarea_Adic_Coord_Equipo" campo="Tarea_Adic_Coord_Equipo" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 250px;">
                        Coordinación de equipos de trabajo</label>
                    <label style="display: inline-block; width: 170px;">
                        Cantidad de personas a cargo</label>
                    <input id="Tarea_Adic_Cant_Per_Cargo" campo="Tarea_Adic_Cant_Per_Cargo" type="text" style="width: 50px;"
                        placeholder="" />
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 20px;">
                        4</label>
                    <input id="Tarea_Adic_Otros" campo="Tarea_Adic_Otros" type="text" style="width: 30px;"
                        placeholder="" />
                    <label style="display: inline-block; width: 60px;">
                        Otros</label>
                    <label style="display: inline-block; width: 60px;">
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
                <textarea id="Funcion_Actual" rows="7" cols="1" style="width:700px"></textarea>
            </div>
            <br />
            <div style="margin-left: 50px;">
                <div class="bloque">
                    <label style="display: inline-block; width: 150px;">Herramienta</label>
<%--                    <select id="cboHerramientas" style="width: 200px" campo="cboHerramientas" rh-control-type="combo"
                        rh-data-provider="xxxxxxx" rh-model-property="cboHerramientas" data-validar="haySeleccionEnCombo">
                    </select>--%>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 150px;">Conocimiento</label>
<%--                     <select id="cboConocimiento" style="width: 200px" campo="cboConocimiento" rh-control-type="combo"
                        rh-data-provider="xxxxxxx" rh-model-property="cboConocimiento" data-validar="haySeleccionEnCombo">
                    </select>--%>
                </div>
                <div class="bloque">
                    <label style="display: inline-block; width: 150px;">Utiliza en sus funciones</label>
                    <label style="display: inline-block; width: 10px;">Si</label>
                    <input id="chkUtilizaFuncion_SI" style="width: 50px" />
                </div>
                <input type="button" id="btn_Agregar_Conocimientos" value="Agregar conocimiento" style="width:200px" />
            </div> 
    </div>
    <div style="margin-left: 50px;">
        
            <div style="margin-left: 50px;">
            <p>Otros Conocimientos:</p>
                <textarea id="Otros_Conocimientos" rows="4" cols="1" style="width:700px"></textarea>
            </div>
    </div>
    <hr />
    <div style="margin-left: 50px;">
        <p style="font-weight: bold;">
            6) Observaciones:</p>
        <div style="margin-left: 50px;">
            <p>Indique una observación relevante por renglón</p>
            <textarea id="Observaciones" rows="4" cols="1" style="width:700px"></textarea>
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
    <div style="margin-left: 80px;">
        <div class="bloque">
            <label style="display: inline-block; width: 300px; text-align:center"">_______________________</label>
            <label style="display: inline-block; width: 300px; text-align:center">__________________________________________</label> 
            <label style="display: inline-block; width: 300px; text-align:center">________________________</label> 
        </div>
        <label style="display: inline-block; width: 300px; text-align:center">Firma</label>   
        <label style="display: inline-block; width: 300px; text-align:center">Aclaración</label>   
        <label style="display: inline-block; width: 300px; text-align:center">Fecha</label>   
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
    <div style="margin-left: 80px;">
        <div class="bloque">
            <label style="display: inline-block; width: 300px; text-align:center"">_______________________</label>
            <label style="display: inline-block; width: 300px; text-align:center">__________________________________________</label> 
            <label style="display: inline-block; width: 300px; text-align:center">________________________</label> 
        </div>
        <label style="display: inline-block; width: 300px; text-align:center">Firma</label>   
        <label style="display: inline-block; width: 300px; text-align:center">Aclaración</label>   
        <label style="display: inline-block; width: 300px; text-align:center">Fecha</label>   
    </div>


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