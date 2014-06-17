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
                                <option value="-1">Sexo</option>
                                <option value="1">Masculino</option>
                                <option value="2">Femenino</option>
                             </select>
                        </div>
                        <div style="float:left; margin:8px">
                         <label for="cmb_estadoCivil">Estado Civil <em>*</em></label>
                         <select id="cmb_estadoCivil" name="cmb_estado_civil" style="width:150px;" >
                            <option value="-1">Estado Civil</option>
                            <option value="1">Soltero</option>
                            <option value="2">Casado</option>
                         </select>
                         </div>
                        <div style="float:left; margin:8px; width:130px;">
                          <label for="cuil">Cuil / Cuit <em>*</em></label>
                          <input id="cuil" type="text" style="width:120px;" />
                          <span style="float:left;">Ej.:20-22114543-5</span>
                        </div>
                        <div style="float:left; clear:left; margin:8px">
                             <label class="etiqueta_campo" for="cmb_lugar_nacimiento">Lugar nacimiento <em>*</em></label>
                             <select id="cmb_lugar_nacimiento" style="width:120px;" name="cmb_lugar_nacimiento" >
                                <option value="-1">Seleccione</option>
                              </select>
                        </div>
                        <div style="float:left; margin:8px">
                            <label class="etiqueta_campo" for="txt_fechaNac">Fecha Nac <em>*</em></label>
                            <input type="text" id="txt_fechaNac" style="width:120px;" name="txt_fechaNac" size="10"/>
                        </div>
                      <div style="float:left; margin:8px">
                        <label class="etiqueta_campo" for="cmb_nacionalidad">Nacionalidad <em>*</em></label>
                         <select id="cmb_nacionalidad" style="width:120px;" name="cmb_nacionalidad" >
                            <option value="-1">Seleccione</option>
                         </select>
                      </div>
                      <div style="float:left; margin:8px">
                       <label class="etiqueta_campo" for="cmb_tipoDocumento">Tipo documento <em>*</em></label>
                        <select id="cmb_tipoDocumento" style="width:100px;" name="cmb_tipoDocumento" >
                            <option value="0">DNI</option>
                            <option value="1">LC</option>
                            <option value="2">LE</option>
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
                          <label class="etiqueta_campo_small" for="txt_localidad1">Localidad <em>*</em></label>
                          <input type="text" id="txt_localidad1" name="txt_localidad1" style="width:100px"/> 
                      </div>
                      <div style="float:left; margin:8px">
                          <label class="etiqueta_campo_small" for="txt_cp1">Código postal <em>*</em></label>
                          <input type="text" id="txt_cp1" name="txt_cp1" style="width:80px"/><br/>
                      </div>
                      <div style="float:left; margin:8px">     
                        <label class="etiqueta_campo" for="cmb_provincia1">Provincia <em>*</em></label>
                        <select id="cmb_provincia1" name="cmb_provincia1" style="width:130px;" >
                            <option value="-1">Seleccione</option>
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
                          <label class="etiqueta_campo_small" for="txt_localidad2">Localidad <em>*</em></label>
                          <input type="text" id="txt_localidad2" name="txt_localidad2" style="width:100px"/> 
                      </div>

                      <div style="float:left; margin:8px">
                            <label class="etiqueta_campo_small" for="txt_cp2">Código postal <em>*</em></label>
                          <input type="text" id="txt_cp2" name="txt_cp2" style="width:50px"/><br/>
                      </div>

                      <div style="float:left; margin:8px">     
                        <label class="etiqueta_campo" for="cmb_provincia2">Provincia <em>*</em></label>
                        <select id="cmb_provincia2" name="cmb_provincia2" style="width:150px;" >
                            <option value="-1">Seleccione</option>
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
                        <div id="ContenedorPlanilla" runat="server">
                            <table id="tabla_antecedentes" class="table table-striped">
                          
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
                <legend><a id="a3" rel="leanModalConcursar" data-url="ActividadesCapacitacion.htm" class="link" name="form_actividadesCapacitacion"  href="#un_div_modal">Cargar actividades de capacitacion</a></legend>
                    <p>No tiene actividades cargadas</p> 
                     <table id="tabla_capacitacion" class="table table-striped">
                          <thead>
                            <tr>
                              <th>Diploma</th>
                              <th>F. Inicio</th>
                              <th>F. Finalización</th>
                              <th>Duración</th>
                              <th>Especialidad</th>
                              <th>Establecimiento</th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr>
                              <td>Tecnico en Computadoras</td>
                              <td>12/12/2012</td>
                              <td>12/12/2012</td>
                              <td>5 dias</td>
                              <td>Computacion</td>
                              <td>UBA</td>
                            </tr>
                          </tbody>
                            </table>                   
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
                        <div id="ContenedorPlanillaActividadesAcademicas" runat="server">
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
                    <legend><a id="go5" rel="leanModalConcursar" data-url="EventosAcademicos.htm" class="link" name="form_eventosAcademicos"  href="#un_div_modal">Cargar eventos académicos</a></legend>
                    <p>No tiene eventos cargados</p>  
                    <table id="tabla_eventoAcademico" class="table table-striped">
                          <thead>
                            <tr>
                              <th>Denominaci&oacute;n</th>
                              <th>Tipo Evento</th>
                              <th>Car&aacute;cter de Participaci&oacute;n</th>
                              <th>F. Inicio</th>
                              <th>F. Fin</th>
                              <th>Instituci&oacute;n</th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr>
                              <td>T&eacute;cnico en Computadoras</td>
                              <td>12/12/2012</td>
                              <td>12/12/2012</td>
                              <td>5 dias</td>
                              <td>Computaci&oacute;n</td>
                              <td>UBA</td>
                            </tr>
                          </tbody>
                            </table>                             
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
                    <legend><a id="go6" rel="leanModalConcursar" data-url="Publicaciones.htm" class="link" name="form_publicaciones"  href="#un_div_modal">Cargar publicaciones o trabajos</a></legend>
                    <p>No tiene publicaciones cargadas</p>   
                    <table id="tabla_publicaciones" class="table table-striped">
                          <thead>
                            <tr>
                              <th>T&iacute;tulo</th>
                              <th>Datos de Editorial</th>
                              <th>Fecha</th>
                              <th>Cant. de Hojas</th>
                              <th>Dispone copia</th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr>
                              <td>El estado de bienestar</td>
                              <td>Atl&aacute;ntida</td>
                              <td>12/12/2012</td>
                              <td>5</td>
                              <td>Si</td>
                            </tr>
                          </tbody>
                            </table>                             
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
                    <legend><a id="go7" rel="leanModalConcursar" data-url="Matriculas.htm" class="link" name="form_matriculas"  href="#un_div_modal">Cargar matriculas</a></legend>
                    <p>No tiene matr&iacute;culas cargadas</p>  
                    
                      <table id="tabla_matriculas" class="table table-striped">
                          <thead>
                            <tr>
                              <th>N&uacute;mero</th>
                              <th>Expedida por</th>
                              <th>Fecha Inscr.</th>
                              <th>Situaci&oacute;n Actual</th>
                           </tr>
                          </thead>
                          <tbody>
                            <tr>
                              <td>M.N. 20586</td>
                              <td>Ministerio de Salud</td>
                              <td>01/08/2005</td>
                              <td>Vigente</td>
                            </tr>
                          </tbody>
                     </table>                   

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
                    <legend><a id="go8" rel="leanModalConcursar" data-url="InstitucionesAcademicas.htm" class="link" name="form_institucionesAcademicas"  href="#un_div_modal">Cargar instituciones</a></legend>
                    <p>No tiene instituciones cargadas</p> 

                       <table id="tabla_instituciones_academicas" class="table table-striped">
                          <thead>
                            <tr>
                              <th>Nombre Inst.</th>
                              <th>Car&aacute;cter Entidad</th>
                              <th>Cargos Desempeñados</th>
                              <th>N&uacute;mero de Afiliado</th>
                                <th>Categor&iacute;a actual</th>
                              <th>Fecha de afiliaci&oacute;n</th>
                            
                              <th>Fecha</th>
                             
                              <th>Fecha inicio</th>
                              <th>Fecha Fin</th>
                               <th>Localidad</th>
                              <th>Pa&iacute;s</th>
                           </tr>
                          </thead>
                          <tbody>
                            <tr>
                              <td>Universidad Kennedy</td>
                              <td>Privada</td>
                              <td>Preceptor</td>
                             
                              <td>457345</td>
                              <td>Vigente</td>
                               <td>01/02/03</td>
                              
                              <td>01/08/2014</td>
                             
                              <td>01/04/08</td>
                              <td>01/08/12</td>
                               <td>CABA</td>
                              <td>Argentina</td>
                            </tr>
                          </tbody>
                     </table>               
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
                    <legend><a id="go9" rel="leanModalConcursar" data-url="ExperienciasLaborales.htm" class="link" name="form_experienciasLaborales"  href="#un_div_modal">Cargar experiencia laboral</a></legend>
                    <p>No tiene experiencia laboral cargada</p>  
                                        
                        <table id="tabla_experiencia_laboral" class="table table-striped">
                          <thead>
                            <tr>
                              <th>Puesto</th>
                              <th>Personal a cargo</th>
                              <th>Fecha Inicio</th>
                              <th>Fecha Fin</th>
                              <th>Motivo de Desvinculaci&oacute;n </th>
                              <th>Empleador</th>
                              <th>Tipo Empresa</th>
                              <th>Sector</th>
                              <th>Localidad</th>
                              <th>Pa&iacute;s</th>
                          </tr>
                          </thead>
                          <tbody>
                            <tr>
                              <td>Analista Programador</td>
                              <td>3</td>
                              <td>01/05/2008</td>
                              <td>01/09/2009</td>
                              <td>Cambio laboral</td>
                              <td>SAP Argentina S.A.</td>
                              <td>Privada</td>
                              <td>Inform&aacute;tica</td>
                              <td>CABA</td>
                              <td>Argentina</td>
                            </tr>
                          </tbody>
                     </table>            
                    
                        
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
                    <legend><a id="go10" rel="leanModalConcursar" data-url="IdiomasExtranjeros.htm" class="link" name="form_idiomasExtranjeros"  href="#un_div_modal">Cargar idiomas</a></legend>
                    <p>No tiene idiomas cargados</p>      
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
                    <legend><a id="go11" rel="leanModalConcursar" data-url="CompetenciasInformaticas.htm" class="link" name="form_competenciasInformaticas"  href="#un_div_modal">Cargar competencias informáticas</a></legend>
                     <p>No tiene competencias inform&aacute;ticas cargadas</p>  
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
                    <legend><a id="go12" rel="leanModalConcursar" data-url="OtrasCapacidades.htm" class="link" name="form_otrasCapacidades"  href="#un_div_modal">Cargar otras capacidades</a></legend>
                    <p>No tiene capacidades cargadas</p>  
                    
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

<%-----------------    MODAL DE VISTA PREELIMINAR ---------------------%>

 <input type="text" id="urlAjax" value=""  style="display:none;" />
 
<div id="un_div_modal" style="width:65%;" class="form_concursar">
    <div class="modal_close_concursar"></div>
    <div id="contenido_modal"></div>
</div>
<asp:HiddenField ID="curriculum" runat="server" />
<asp:HiddenField ID="cvEstudios" runat="server" />
<asp:HiddenField ID="cvActividadesDocentes" runat="server" />
  </form>

<div id='IrArriba'><a href='#Arriba'><span></span></a></div>

</body>

<script type="text/javascript" src="AntecedentesAcademicos.js" ></script>
<script type="text/javascript" src="CvDatosPersonales.js" ></script>
<script type="text/javascript" src="ActividadesDocentes.js" ></script>
    <%= Referencias.Javascript("../") %>
<script type="text/javascript" src="Postular.js" ></script>
<script type="text/javascript" src="../Scripts/RepositorioDeProvincias.js" ></script>

<script type="text/javascript">

    $(document).ready(function () {

        $(".collapse").collapse('show');


        var curriculum = JSON.parse($('#curriculum').val());
        
        CvDatosPersonales.completarDatos(curriculum.DatosPersonales);
        AntecedentesAcademicos.armarGrilla(curriculum.CvEstudios);
        ActividadesDocentes.armarGrilla(curriculum.CvDocencias);


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