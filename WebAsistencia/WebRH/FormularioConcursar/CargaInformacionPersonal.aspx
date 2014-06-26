<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CargaInformacionPersonal.aspx.cs" Inherits="FormularioConcursar_Pantalla1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%= Referencias.Css("../")%>    
    
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>

    <link rel="stylesheet" href="EstilosPostular.css" />
</head>
<body class="">

 <form   runat="server" class="cmxform">
 <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
   <div class="contenedor_concursar" >
   
   <div class="accordion" id="accordion">

       <div class="navbar" style="font-size: 15px;">
            <div class="navbar-inner">
                <div class="container">
                    <a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    </a>
                    <a class="brand" href="#"></a>
                    <div class="nav-collapse navbar-responsive-collapse">
                    <ul id="Ul1" class="nav"  runat="server">
                    <li><a href="PanelDeControl.aspx" >Panel de Control</a></li>
                    <li><a href="Postulaciones.aspx" >Postulaciones</a></li>
                    <li><a href="CargaInformacionPersonal.aspx" >MI CV</a></li>
                    </ul>
       
                    <ul id="Ul2" class="nav pull-right"  runat="server">
                    </ul>
                    </div><!-- /.nav-collapse -->
                </div>
            </div><!-- /navbar-inner -->
        </div><!-- /navbar -->

        <nav style="min-width: 900px;">
            <ul class="ul_cv" style="width:100%; margin-left:1%; margin-top:15px; margin-bottom:3px;">    
                <li class="menu_lista_formularios"><a href="#ancla1">Información Personal</a></li>
                <li class="menu_lista_formularios"><a href="#ancla2">Antecedentes Academicos</a></li>
                <li class="menu_lista_formularios"><a href="#ancla3">Actividades de Capacitación</a></li>
                <li class="menu_lista_formularios"><a href="#ancla4">Actividades Docentes</a></li>
                <li class="menu_lista_formularios no_borde"><a href="#ancla5">Eventos Académicos</a></li>
             </ul>
             <ul class="ul_cv" style="width:90%; margin-left:6%; margin-bottom:3px;">
                <li class="menu_lista_formularios"><a href="#ancla6">Publicaciones o trabajos</a></li>
                <li class="menu_lista_formularios"><a href="#ancla7">Matr&iacute;culas</a></li>
                <li class="menu_lista_formularios"><a href="#ancla8">Instituciones Académicas</a></li>
                <li class="menu_lista_formularios"><a href="#ancla9">Experiencia Laboral</a></li>
                <li class="menu_lista_formularios no_borde"><a href="#ancla10">Idiomas Extranjeros</a></li>
            </ul>
            <ul class="ul_cv" style="width:60%; margin-left:20%;">
                <li class="menu_lista_formularios"><a href="#ancla11">Competencias Informáticas</a></li>
                <li class="menu_lista_formularios"><a href="#ancla12">Otras Capacidades</a></li>
                <li class="menu_lista_formularios no_borde"><a href="#ancla13">Vista Preliminar</a></li>
            </ul>
        </nav>

        <hr style="clear:both; background-color:#0088cc;" />
            <div class="accordion-group">
              <div id="ancla1" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">INFORMACION PERSONAL</a>
              </div>
              <div id="collapseOne" class="accordion-body collapse" style="height: 0px; ">
                <div id="contenedor_datosPersonales" class="accordion-inner fondo_form">
                    <fieldset style=" width:100%; min-width:500px;" >
                      <p><em>*</em> Campos Obligatorios</p>
                      <p style="text-transform:uppercase; font-weight:bold;">I.- Editar información personal</p>
                        <div style="float:left; margin:8px" >
                          <label for="nombre">Nombre <em>*</em></label>
                          <input id="nombre" type="text" style="width:150px;"  />
                        </div>
                        <div style="float:left; margin:8px">
                          <label for="apellido">Apellido <em>*</em></label>
                          <input id="apellido" type="text" style="width:150px;" />
                        </div>
                        <div style="float:left; margin:8px">
                            <label for="cmb_sexo">Sexo <em>*</em></label>
                            <select id="cmb_sexo" style="width:100px;" name="cmb_sexo" >
                            </select>
                        </div>
                        <div style="float:left; margin:8px">
                         <label for="cmb_estadoCivil">Estado Civil <em>*</em></label>
                         <select id="cmb_estadoCivil" style="width:100px;" name="cmb_estadoCivil" >
                         </select>
                         </div>
                        <div style="float:left; margin:8px; width:130px;">
                          <label for="cuil">Cuil / Cuit <em>*</em></label>
                          <input id="cuil" type="text" style="width:120px;" />
                          <span style="float:left;">Ej.:20-22114543-5</span>
                        </div>
                        <div style="float:left; clear:left; margin:8px">
                             <label class="etiqueta_campo" for="cmb_lugar_nacimiento">Lugar nacimiento <em>*</em></label>
                             <input type="text" id="cmb_lugar_nacimiento" style="width:120px;" />
                        </div>
                        <div style="float:left; margin:8px">
                            <label class="etiqueta_campo" for="txt_fechaNac">Fecha Nac <em>*</em></label>
                            <input type="text" id="txt_fechaNac" style="width:120px;" name="txt_fechaNac" size="10"/>
                        </div>
                      <div style="float:left; margin:8px">
                        <label class="etiqueta_campo" for="cmb_nacionalidad">Nacionalidad <em>*</em></label>
                         <select id="cmb_nacionalidad" style="width:250px;" name="cmb_nacionalidad">
                         </select>
                      </div>
                      <div style="float:left; margin:8px">
                       <label class="etiqueta_campo" for="cmb_tipoDocumento">Tipo documento <em>*</em></label>
                        <select id="cmb_tipoDocumento" style="width:100px;" name="cmb_tipoDocumento">
                        </select>
                      </div>
                      <div style="float:left; margin:8px">
                          <label class="etiqueta_campo" for="txt_documento">Nro documento <em>*</em></label>
                          <input id="txt_documento" type="text" style="width:150px;" />
                      </div>
                       <div style="float:left; margin:8px">
                        <label class="etiqueta_campo" for="txt_calle1">Calle <em>*</em></label>
                        <input type="text" id="txt_calle1" name="txt_calle1" size="20"/>
                      </div>

                       <div style="float:left; margin:8px; width:60px;">
                        <label class="etiqueta_campo" for="txt_numero1">Número <em>*</em></label>
                        <input type="text" id="txt_numero1" name="txt_numero1" style="width:50px"/>
                       </div>      
                       <div style="float:left; margin:8px; width:60px;">
                        <label class="etiqueta_campo" for="txt_piso1">Piso</label>
                        <input type="text" id="txt_piso1" name="txt_piso1" style="width:50px"/>
                       </div>
                      <div style="float:left; margin:8px; width:80px;">     
                          <label class="etiqueta_campo" for="txt_dto1">Dto</label>
                          <input type="text" id="txt_dto1" name="txt_dto1" style="width:50px"/>
                      </div> 
                      <div style="float:left; margin:8px">
                          <label class="etiqueta_campo_small" for="txt_cp1">Código postal <em>*</em></label>
                          <input type="text" id="txt_cp1" name="txt_cp1" style="width:80px"/><br/>
                      </div>
                      <div style="float:left; margin:8px">     
                        <label class="etiqueta_campo" for="cmb_provincia1">Provincia <em>*</em></label>
                        <select id="cmb_provincia1" name="cmb_provincia1" style="width:200px;" >
                        </select>
                      </div> 
                      <div style="float:left; margin:8px">
                          <label class="etiqueta_campo_small" for="cmb_localidad1">Localidad <em>*</em></label>
                           <select id="cmb_localidad1" name="cmb_localidad1" style="width:300px;" >
                            </select>
                      </div>
                    </fieldset>
                    <fieldset style="width:100%;" >
		                <p style="font-weight:bold; text-transform:uppercase;">II.- Información Requerida Para Recibir Notificaciones y Avisos</p>
	                    <div style="float:left; margin:8px">
                            <label class="etiqueta_campo" for="text_calle2">Calle <em>*</em></label>
                            <input type="text" id="text_calle2" name="text_calle2" size="20"/>
                        </div>

                       <div style="float:left; margin:8px; width:60px;">
                            <label class="etiqueta_campo" for="txt_numero2">Número <em>*</em></label>
                            <input type="text" id="txt_numero2" name="txt_numero2" style="width:50px"/>
                       </div>
       
                       <div style="float:left; margin:8px; width:60px;">
                            <label class="etiqueta_campo" for="txt_piso2">Piso</label>
                            <input type="text" id="txt_piso2" name="txt_piso2" style="width:50px"/>
                       </div>

                      <div style="float:left; margin:8px; width:80px;">     
                          <label class="etiqueta_campo" for="txt_dto2">Dto</label>
                          <input type="text" id="txt_dto2" name="txt_dto2" style="width:50px"/>
                      </div>

                      <div style="float:left; margin:8px">
                            <label class="etiqueta_campo_small" for="txt_cp2">Código postal <em>*</em></label>
                          <input type="text" id="txt_cp2" name="txt_cp2" style="width:50px"/><br/>
                      </div>

                      <div style="float:left; margin:8px">     
                        <label class="etiqueta_campo" for="cmb_provincia2">Provincia <em>*</em></label>
                        <select id="cmb_provincia2" name="cmb_provincia2" style="width:200px;" >
                        </select>
                      </div>
                      <div style="float:left; margin:8px">
                          <label class="etiqueta_campo_small" for="cmb_localidad2">Localidad <em>*</em></label>
                           <select id="cmb_localidad2" name="cmb_localidad2" style="width:300px;" >
                            </select>
                      </div>

                        <div style="float:left; margin:8px">
                            <label class="etiqueta_campo" for="txt_telefonoFijo">Tel&eacute;fono fijo <em>*</em></label>
                            <input type="text" id="txt_telefonoFijo" name="txt_telefonoFijo" style="width:100px;"/>
                        </div>

                        <div style="float:left; margin:8px">
                            <label class="etiqueta_campo" for="txt_telefonoCelular">Tel&eacute;fono celular</label>
                            <input type="text" id="txt_telefonoCelular" name="txt_telefonoCelular" style="width:100px;"/>
                        </div>

                       <div style="float:left; margin:8px; ">
                            <label class="etiqueta_campo" for="txt_email">Email alternativo</label>
                            <input type="text" id="txt_email" name="txt_email" style="width:100px"/>
                       </div>
                      </fieldset>
                      <div style="text-align: center;">
                        <input type="button"  class="btn" id="btn_guardar_datosPersonales"  value="Guardar"/>
                      </div>
                </div>
                
              </div>
            </div>
            
            <div class="accordion-group">
              <div id="ancla2" class="accordion-heading ">
                <a class="accordion-toggle titulo_acordion" style="" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                 ANTECEDENTES ACADÉMICOS
                </a>   
              </div>
              <div id="collapseTwo" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="antecedentes_link"  onclick="javascript:AgregarAntecedentesAcademico();"  class="link" >Cargar antecedentes academicos</a></legend>
                           
                        <h4>Antecedentes Agregados</h4>
                        <div id="ContenedorPlanillaAntecendentesAcademicos" runat="server">
                            <table id="tabla_antecedentes_academicos" class="table table-striped">
                          
                            </table>
                        </div>
                    </fieldset>
                </div>
              </div>
            </div>
            
            <div class="accordion-group">
              <div id="ancla3" class="accordion-heading">
                <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                 ACTIVIDADES DE CAPACITACI&Oacute;N
                </a>    
              </div>
              <div id="collapseThree" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                <fieldset style="width:100%;">
                <legend><a id="actividades_capacitacion_link" onclick="javascript:AgregarActividadesCapacitacion();"  class="link"> Cargar actividades de capacitación</a></legend>
                        <h4>Actividades de Capacitación Agregadas</h4>
                        <div id="ContenedorPlanillaActividadesCapacitacion" runat="server">
                            <table id="tabla_actividades_capacitacion" class="table table-striped">
                          
                            </table>
                        </div>  
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla4" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">
                  ACTIVIDADES DOCENTES
                </a>   
              </div>
              <div id="collapseFour" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="actividades_docentes_link"  onclick="javascript:AgregarActividadesDocentes();"  class="link" >Cargar actividades docentes</a></legend>
                        <h4>Actividades Docentes Agregadas</h4>
                        <div id="ContenedorPlanillaActividadesDocentes" runat="server">
                            <table id="tabla_actividades_docentes" class="table table-striped">
                          
                            </table>
                        </div>
                    </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla5" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                  EVENTOS ACAD&Eacute;MICOS
                </a>
              </div>
              <div id="collapseFive" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="eventos_academicos_link"  onclick="javascript:AgregarEventosAcademicos();"  class="link" >Cargar eventos académicos</a></legend>
                        <h4>Eventos Acadmémicos Agregados</h4>
                        <div id="ContenedorPlanillEventosAcademicos" runat="server">
                            <table id="tabla_eventos_academicos" class="table table-striped">
                          
                            </table>
                        </div>                       
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla6" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                  PUBLICACIONES O TRABAJOS
                </a>
              </div>
              <div id="collapseSix" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="publicaciones_trabajos_link"  onclick="javascript:AgregarPublicacionesTrabajos();"  class="link" >Cargar publicaciones y trabajos</a></legend>
                        <h4>Publicaciones y Trabajos Agregados</h4>
                        <div id="ContenedorPlanillaPublicacionesTrabajos" runat="server">
                            <table id="tabla_publicaciones_trabajos" class="table table-striped">
                          
                            </table>
                        </div>                           
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla7" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                  MATR&Iacute;CULAS
                </a>
              </div>
              <div id="collapseSeven" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="matriculas_link"  onclick="javascript:AgregarMatriculas();"  class="link" >Cargar matrículas</a></legend>
                        <h4>Matrículas Agregadas</h4>
                        <div id="ContenedorPlanillaMatriculas" runat="server">
                            <table id="tabla_matriculas" class="table table-striped">
                          
                            </table>
                        </div>
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla8" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseEight">
                  INSTITUCIONES ACAD&Eacute;MICAS
                </a>
              </div>
              <div id="collapseEight" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="instituciones_academicas_link"  onclick="javascript:AgregarInstitucionesAcademicas();"  class="link" >Cargar instituciones académicas</a></legend>
                        <h4>Instituciones Académicas Agregadas</h4>
                        <div id="ContenedorPlanillaInstitucionesAcademicas" runat="server">
                            <table id="tabla_instituciones_academicas" class="table table-striped">
                          
                            </table>
                        </div>     
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla9" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseNine">
                  EXPERIENCIA LABORAL
                </a>
              </div>
              <div id="collapseNine" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="experiencia_laboral_link"  onclick="javascript:AgregarExperienciaLaboral();"  class="link" >Cargar experiencia laboral</a></legend>
                        <h4>Experiencia Laboral Agregada</h4>
                        <div id="ContenedorPlanillaExperienciaLaboral" runat="server">
                            <table id="tabla_experiencia_laboral" class="table table-striped">
                          
                            </table>
                        </div>
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla9" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTen">
                  IDIOMAS EXTRANJEROS
                </a>
              </div>
              <div id="collapseTen" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="idiomas_extranjeros_link"  onclick="javascript:AgregarIdiomasExtranjeros();"  class="link" >Cargar idiomas extranjeros</a></legend>
                        <h4>Idiomas Extranjeros Agregados</h4>
                        <div id="ContenedorPlanillaIdiomasExtranjeros" runat="server">
                            <table id="tabla_idiomas_extranjeros" class="table table-striped">
                          
                            </table>
                        </div> 
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla10" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseEleven">
                  COMPETENCIAS INFORM&Aacute;TICAS
                </a>
              </div>
              <div id="collapseEleven" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="competencias_informaticas_link"  onclick="javascript:AgregarCompetenciasInformaticas();"  class="link" >Cargar competencias informáticas</a></legend>
                        <h4>Competencias Informáticas Agregadas</h4>
                        <div id="ContenedorPlanillaCompetenciasInformaticas" runat="server">
                            <table id="tabla_competencias_informaticas" class="table table-striped">
                          
                            </table>
                        </div> 
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla11" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseTwelve">
                  OTRAS CAPACIDADES
                </a>
              </div>
              <div id="collapseTwelve" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="btn_agregar_otra_capacidad"  class="link" >Cargar otras capacidades</a></legend>
                        <h4>Otras Capacidades Agregadas</h4>
                        <div id="ContenedorPlanillaOtrasCapacidades" runat="server">
                            <table id="tabla_otras_capacidades" class="table table-striped">
                          
                            </table>
                        </div>
                    
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla12" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseThirteen">
                  VISTA PRELIMINIAR
                </a>
              </div>
              <div id="collapseThirteen" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend>Vista Preliminar</legend>
                  </fieldset>
                </div>
              </div>
            </div>
          </div>
    </div>

<%-----------------    MODAL DE VISTA PRELIMINAR ---------------------%>

 <input type="text" id="urlAjax" value=""  style="display:none;" />

 <div id="plantillas">
    <div class="botonera_grilla">
        <img id="btn_editar" src="../Imagenes/edit.png"/>
        <img id="btn_eliminar" src="../Imagenes/iconos_eliminar.jpg"/>
    </div>
 </div>

<div id="un_div_modal" style="width:65%;" class="form_concursar">
    <div class="modal_close_concursar"></div>
    <div id="contenido_modal"></div>
</div>
<asp:HiddenField ID="curriculum" runat="server" />
<asp:HiddenField ID="cvEstudios" runat="server" />
<asp:HiddenField ID="cvActividadesDocentes" runat="server" />
<asp:HiddenField ID="cvActividadesCapacitacion" runat="server" />
<asp:HiddenField ID="CvEventosAcademicos" runat="server" />
<asp:HiddenField ID="CvExperienciaLaboral" runat="server" />
<asp:HiddenField ID="CvIdiomas" runat="server" />
<asp:HiddenField ID="CvInstitucionesAcademicas" runat="server" />
<asp:HiddenField ID="CvMatricula" runat="server" />
<asp:HiddenField ID="CvPublicaciones" runat="server" />
<asp:HiddenField ID="CvCompetenciasInformaticas" runat="server" />


  </form>

<div id='IrArriba'><a href='#Arriba'><span></span></a></div>

</body>

<script type="text/javascript" src="CvDatosPersonales.js" ></script>
<script type="text/javascript" src="AntecedentesAcademicos.js" ></script>
<script type="text/javascript" src="ActividadesCapacitacion.js" ></script>
<script type="text/javascript" src="ActividadesDocentes.js" ></script>
<script type="text/javascript" src="EventosAcademicos.js" ></script>
<script type="text/javascript" src="PublicacionesTrabajos.js" ></script>
<script type="text/javascript" src="Matriculas.js" ></script>
<script type="text/javascript" src="InstitucionesAcademicas.js" ></script>
<script type="text/javascript" src="ExperienciaLaboral.js" ></script>
<script type="text/javascript" src="IdiomasExtranjeros.js" ></script>
<script type="text/javascript" src="CompetenciasInformaticas.js" ></script>
<script type="text/javascript" src="PanelDetalleDeOtraCapacidad.js" ></script>
<script type="text/javascript" src="PanelListaDeOtrasCapacidades.js" ></script>



    <%= Referencias.Javascript("../") %>
<script type="text/javascript" src="Postular.js" ></script>
<script type="text/javascript" src="../Scripts/Repositorio.js" ></script>
<script type="text/javascript" src="../Scripts/SuperCombo.js" ></script>

<script type="text/javascript">

    $(document).ready(function () {

        $(".collapse").collapse('show');


        var curriculum = JSON.parse($('#curriculum').val());

        CvDatosPersonales.completarDatos(curriculum.DatosPersonales);
        //        AntecedentesAcademicos.armarGrilla(curriculum.CvEstudios);
        //        ActividadesDocentes.armarGrilla(curriculum.CvDocencias);
        //        ActividadesCapacitacion.armarGrilla(curriculum.CvCertificadosDeCapacitacion);
        //        EventosAcademicos.armarGrilla(curriculum.CvEventosAcademicos);
        //        PublicacionesTrabajos.armarGrilla(curriculum.CvPublicaciones);
        //        Matriculas.armarGrilla(curriculum.CvMatricula);
        //        InstitucionesAcademicas.armarGrilla(curriculum.CvInstitucionesAcademicas);
        //        ExperienciaLaboral.armarGrilla(curriculum.CvExperienciaLaboral);
        //        IdiomasExtranjeros.armarGrilla(curriculum.CvIdiomas);
        //        CompetenciasInformaticas.armarGrilla(curriculum.CvCompetenciasInformaticas);

        //mockeado!!!
        curriculum.CvCapacidadesPersonales = [
            { Id: 1, Tipo: 1, Detalle: "una capacidad diferente" },
            { Id: 2, Tipo: 2, Detalle: "una capacidad especial" },
            { Id: 3, Tipo: 2, Detalle: "una capacidad distinta" }
        ];

        PanelListaDeOtrasCapacidades.armarGrilla(curriculum.CvCapacidadesPersonales);


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


        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#fff');
        $("tbody tr:odd").css('background-color', 'transparent ');
    });
    
    

</script>
</html>