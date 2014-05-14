<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pantalla1.aspx.cs" Inherits="FormularioConcursar_Pantalla1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%= Referencias.Css("../")%>    
      <!--[if lte IE 8]>  
        <script type="text/javascript" src="js/mootools.js"></script>  
        <script type="text/javascript" src="js/selectivizr.js"></script>  
    <![endif]-->  
    
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>


    <link rel="stylesheet" href="Estilos.css" />
</head>
<body class="">

 <form   runat="server" class="cmxform">
 <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
   <div class="accordion" id="accordion">

        <nav style="min-width: 900px;">
            <ul style="width:100%; margin-left:1%; margin-top:35px; margin-bottom:3px;">    
                <li class=""><a href="#ancla1">Información Personal</a></li>
                <li class=""><a href="#ancla2">Antecedentes Academicos</a></li>
                <li class=""><a href="#ancla3">Actividades de Capacitación</a></li>
                <li class=""><a href="#ancla4">Actividades Docentes</a></li>
                <li class="no_borde"><a href="#ancla5">Eventos Académicos</a></li>
             </ul>
             <ul style="width:90%; margin-left:6%; margin-bottom:3px;">
                <li class=""><a href="#ancla6">Publicaciones o trabajos</a></li>
                <li class=""><a href="#ancla7">Matriculas</a></li>
                <li class=""><a href="#ancla8">Instituciones Académicas</a></li>
                <li class=""><a href="#ancla9">Experiencias Laborales</a></li>
                <li class="no_borde"><a href="#ancla10">Idiomas Extranjeros</a></li>
            </ul>
            <ul style="width:60%; margin-left:20%;">
                <li class=""><a href="#ancla11">Competencias Informáticas</a></li>
                <li class=""><a href="#ancla12">Otras Capacidades</a></li>
                <li class="no_borde"><a href="#ancla13">Vista Preliminar</a></li>
            </ul>
        </nav>
        <hr style="clear:both; background-color:#0088cc;" />
            <div class="accordion-group">
              <div id="ancla1" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">INFORMACION PERSONAL</a>
              </div>
              <div id="collapseOne" class="accordion-body collapse" style="height: 0px; ">
                <div class="accordion-inner fondo_form">
                    <fieldset style=" width:100%; min-width:800px;" >
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
                            <label for="cmb_nivel_educativo">Sexo <em>*</em></label>
                            <select id="cmb_nivel_educativo" style="width:100px;" name="cmb_sexo" >
                                <option value="-1">Sexo</option>
                                <option value="1">Masculino</option>
                                <option value="1">Femenino</option>
                             </select>
                        </div>
                        <div style="float:left; margin:8px">
                         <label for="cmb_estadoCivil">Estado Civil <em>*</em></label>
                         <select id="cmb_estadoCivil" name="cmb_estado_civil" style="width:150px;" >
                            <option value="-1">Estado Civil</option>
                            <option value="1">Masculino</option>
                            <option value="1">Femenino</option>
                         </select>
                         </div>
                        <div style="float:left; margin:8px; width:130px;">
                          <label for="cuil">Cuil / Cuit <em>*</em></label>
                          <input id="cuil" type="text" style="width:120px;" />
                          <span style="float:left;">Ej.:20-22114543-5</span>
                        </div>
                        <div style="float:left; clear:left; margin:8px">
                             <label class="etiqueta_campo" for="cmb_nivel_educativo">Lugar nacimiento <em>*</em></label>
                             <select id="Select1" style="width:120px;" name="cmb_nivel_educativo" >
                                <option value="-1">Seleccione</option>
                                <option value="1">Argentina</option>
                                <option value="1">Bolivia</option>
                              </select>
                        </div>
                        <div style="float:left; margin:8px">
                            <label class="etiqueta_campo" for="txt_categoria_docente">Fecha Nac <em>*</em></label>
                            <input type="text" id="txt_categoria_docente" style="width:120px;" name="txt_categoria_docente" size="10"/>
                        </div>
                      <div style="float:left; margin:8px">
                        <label class="etiqueta_campo" for="cmb_nivel_educativo">Nacionalidad <em>*</em></label>
                         <select id="Select2" style="width:120px;" name="cmb_nivel_educativo" >
                            <option value="-1">Seleccione</option>
                            <option value="1">Argentina</option>
                            <option value="1">Boliviano</option>
                         </select>
                      </div>
                      <div style="float:left; margin:8px">
                       <label class="etiqueta_campo" for="cmb_nivel_educativo">Tipo documento <em>*</em></label>
                        <select id="Select3" style="width:100px;" name="cmb_nivel_educativo" >
                            <option value="-1">DNI</option>
                            <option value="1">LC</option>
                            <option value="1">LE</option>
                        </select>
                      </div>
                      <div style="float:left; margin:8px">
                          <label class="etiqueta_campo" for="documento">Nro documento <em>*</em></label>
                          <input id="documento" type="text" style="width:150px;" />
                      </div>
                       <div style="float:left; margin:8px">
                        <label class="etiqueta_campo" for="txt_categoria_docente">Calle <em>*</em></label>
                        <input type="text" id="Text1" name="txt_categoria_docente" size="20"/>
                      </div>

                       <div style="float:left; margin:8px; width:60px;">
                        <label class="etiqueta_campo" for="txt_caracter_designacion">Número <em>*</em></label>
                        <input type="text" id="txt_caracter_designacion" name="txt_caracter_designacion" style="width:50px"/>
                       </div>      
                       <div style="float:left; margin:8px; width:60px;">
                        <label class="etiqueta_campo" for="txt_dedicacion_docente">Piso</label>
                        <input type="text" id="txt_dedicacion_docente" name="txt_dedicacion_docente" style="width:50px"/>
                       </div>
                      <div style="float:left; margin:8px; width:80px;">     
                          <label class="etiqueta_campo" for="txt_carga_horaria">Dto</label>
                          <input type="text" id="txt_carga_horaria" name="txt_carga_horaria" style="width:50px"/>
                      </div>
                      <div style="float:left; margin:8px">
                          <label class="etiqueta_campo_small" for="txt_fecha_inicio">Localidad <em>*</em></label>
                          <input type="text" id="txt_fecha_inicio" name="txt_fecha_inicio" style="width:100px"/> 
                      </div>
                      <div style="float:left; margin:8px">
                            <label class="etiqueta_campo_small" for="txt_fecha_fin">Código postal <em>*</em></label>
                          <input type="text" id="txt_fecha_fin" name="txt_fecha_fin" style="width:80px"/><br/>
                      </div>
                      <div style="float:left; margin:8px">     
                        <label class="etiqueta_campo" for="cmb_nivel_educativo">Provincia <em>*</em></label>
                        <select id="Select4" name="cmb_nivel_educativo" style="width:130px;" >
                            <option value="-1">Seleccione</option>
                            <option value="1">Buenos Aires</option>
                            <option value="1">Cordoba</option>
                        </select>
                      </div>
                    </fieldset>
                    <fieldset style="width:100%;" >
		                <p style="font-weight:bold; text-transform:uppercase;">II.- Información Requerida Para Recibir Notificaciones y Avisos</p>
	                    <div style="float:left; margin:8px">
                            <label class="etiqueta_campo" for="txt_categoria_docente">Calle <em>*</em></label>
                            <input type="text" id="Text2" name="txt_categoria_docente" size="20"/>
                        </div>

                       <div style="float:left; margin:8px; width:60px;">
                            <label class="etiqueta_campo" for="txt_caracter_designacion">Número <em>*</em></label>
                            <input type="text" id="Text3" name="txt_caracter_designacion" style="width:50px"/>
                       </div>
       
                       <div style="float:left; margin:8px; width:60px;">
                            <label class="etiqueta_campo" for="txt_dedicacion_docente">Piso</label>
                            <input type="text" id="Text4" name="txt_dedicacion_docente" style="width:50px"/>
                       </div>

                      <div style="float:left; margin:8px; width:80px;">     
                          <label class="etiqueta_campo" for="txt_carga_horaria">Dto</label>
                          <input type="text" id="Text5" name="txt_carga_horaria" style="width:50px"/>
                      </div>

                      <div style="float:left; margin:8px">
                          <label class="etiqueta_campo_small" for="txt_fecha_inicio">Localidad <em>*</em></label>
                          <input type="text" id="Text6" name="txt_fecha_inicio" style="width:100px"/> 
                      </div>

                      <div style="float:left; margin:8px">
                            <label class="etiqueta_campo_small" for="txt_fecha_fin">Código postal <em>*</em></label>
                          <input type="text" id="Text7" name="txt_fecha_fin" style="width:50px"/><br/>
                      </div>

                      <div style="float:left; margin:8px">     
                        <label class="etiqueta_campo" for="cmb_nivel_educativo">Provincia <em>*</em></label>
                        <select id="Select5" name="cmb_nivel_educativo" style="width:150px;" >
                            <option value="-1">Seleccione</option>
                            <option value="1">Buenos Aires</option>
                            <option value="1">Cordoba</option>
                        </select>
                      </div>

                        <div style="float:left; margin:8px">
                            <label class="etiqueta_campo" for="txt_categoria_docente">Telefono fijo <em>*</em></label>
                            <input type="text" id="Text8" name="txt_categoria_docente" style="width:100px;"/>
                        </div>

                        <div style="float:left; margin:8px">
                            <label class="etiqueta_campo" for="txt_categoria_docente">Telefono celular</label>
                            <input type="text" id="Text12" name="txt_categoria_docente" style="width:100px;"/>
                        </div>

                       <div style="float:left; margin:8px; ">
                            <label class="etiqueta_campo" for="txt_caracter_designacion">Email alternativo</label>
                            <input type="text" id="Text9" name="txt_caracter_designacion" style="width:100px"/>
                       </div>
                      </fieldset>
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
                    <legend><a id="a2" rel="leanModalConcursar" data-url="AntecedentesAcademicos.htm" class="link" style="" name="form_antecedentesAcademicos" href="#un_div_modal">Cargar antecedentes academicos</a></legend>
                           
                        <h4>Antecedentes Agregados</h4>
                        <div id="ContenedorPlanilla" runat="server">
                        <table id="tabla_antecedentes" class="table table-striped">
                          <thead>
                            <tr>
                              <th>Nivel</th>
                              <th>Universidad</th>
                              <th>Facultad</th>
                              <th>Institución</th>
                              <th>Título</th>
                              <th>Especialidad</th>
                              <th>Certificado</th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr>
                              <td>Universitario</td>
                              <td>UBA</td>
                              <td>Derecho</td>
                              <td></td>
                              <td>Abogado</td>
                              <td></td>
                              <td>Si</td>
                            </tr>
                            <tr>
                              <td>Terciario</td>
                              <td></td>
                              <td></td>
                              <td>Instituto Da Vinci</td>
                              <td>Diseñador Web</td>
                              <td></td>
                              <td>Si</td>
                            </tr>
                            <tr>
                              <td>Maestria</td>
                              <td>UBA</td>
                              <td>Ciencias Economicas</td>
                              <td></td>
                              <td>MBA</td>
                              <td></td>
                              <td>No</td>
                            </tr>
                          </tbody>
                    </table>
                        </div>
                    </fieldset>
                </div>
              </div>
            </div>
            
            <div class="accordion-group">
              <div id="ancla3" class="accordion-heading">
                <a class="accordion-toggle titulo_acordion" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                 ACTIVIDADES DE CAPACITACIÓN
                </a>    
              </div>
              <div id="collapseThree" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                <fieldset style="width:100%;">
                <legend><a id="a3" rel="leanModalConcursar" data-url="ActividadesCapacitacion.htm" class="link" name="form_actividadesCapacitacion"  href="#un_div_modal">Cargar actividades de capacitacion</a></legend>
                    <p>No tiene actividades cargadas</p>                    
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
                    <legend><a id="go4" rel="leanModalConcursar" data-url="ActividadesDocentes.htm" class="link" name="form_actividadesDocentes"  href="#un_div_modal">Cargar actividades docentes</a></legend>
                    <p>No tiene actividades cargadas</p>      
                  </fieldset>
                </div>
              </div>
            </div>

             <div class="accordion-group">
              <div id="ancla5" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">
                  EVENTOS ACADEMICOS
                </a>
              </div>
              <div id="collapseFive" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="go5" rel="leanModalConcursar" data-url="EventosAcademicos.htm" class="link" name="form_eventosAcademicos"  href="#un_div_modal">Cargar eventos académicos</a></legend>
                    <p>No tiene eventos cargados</p>      
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
                  </fieldset>
                </div>
              </div>
            </div>

             <div class="accordion-group">
              <div id="ancla7" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                  MATRICULAS
                </a>
              </div>
              <div id="collapseSeven" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="go7" rel="leanModalConcursar" data-url="Matriculas.htm" class="link" name="form_matriculas"  href="#un_div_modal">Cargar matriculas</a></legend>
                    <p>No tiene matriculas cargadas</p>   
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla8" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseEight">
                  INSTITUCIONES ACADEMICAS
                </a>
              </div>
              <div id="collapseEight" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="go8" rel="leanModalConcursar" data-url="InstitucionesAcademicas.htm" class="link" name="form_institucionesAcademicas"  href="#un_div_modal">Cargar instituciones</a></legend>
                    <p>No tiene instituciones cargadas</p>   
                  </fieldset>
                </div>
              </div>
            </div>

            <div class="accordion-group">
              <div id="ancla9" class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseNine">
                  EXPERIENCIAS LABORALES
                </a>
              </div>
              <div id="collapseNine" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="go9" rel="leanModalConcursar" data-url="ExperienciasLaborales.htm" class="link" name="form_experienciasLaborales"  href="#un_div_modal">Cargar experiencias laborales</a></legend>
                    <p>No tiene experiencias cargadas</p>      
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
                  COMPETENCIAS INFORMATICAS
                </a>
              </div>
              <div id="collapseEleven" class="accordion-body collapse">
                <div class="accordion-inner fondo_form">
                  <fieldset style="width:100%;">
                    <legend><a id="go11" rel="leanModalConcursar" data-url="CompetenciasInformaticas.htm" class="link" name="form_competenciasInformaticas"  href="#un_div_modal">Cargar competencias informáticas</a></legend>
                     <p>No tiene compentencias informaticas cargadas</p>  
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
    

<%-----------------    MODAL DE VISTA PREELIMINAR ---------------------%>

 <asp:TextBox ID="urlAjax" runat="server" Text=""  style="display:none;" />
 
<div id="un_div_modal" style="width:50%;" class="form_concursar">
    <a class="modal_close_concursar" href="#"></a>
    <div id="contenido_modal"></div>
</div>
  </form>

<div id='IrArriba'><a href='#Arriba'><span></span></a></div>
</body>
    <%= Referencias.Javascript("../") %>
       

<script type="text/javascript">
  //<![CDATA[
    // Botón para Ir Arriba
    
    jQuery(document).ready(function () {
        jQuery("#IrArriba").hide();
        jQuery(function () {
            jQuery(window).scroll(function () {
                if (jQuery(this).scrollTop() > 200) {
                    jQuery('#IrArriba').fadeIn();
                } else {
                    jQuery('#IrArriba').fadeOut();
                }
            });
            jQuery('#IrArriba a').click(function () {
                jQuery('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });
        });

    });
    //]]>
    $(document).ready(function () {
      

        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#fff');
        $("tbody tr:odd").css('background-color', 'transparent ');

        $(".collapse").collapse('show');


        //Al presionarse Enter luego de Ingresar el DNI, se fuerza a realizar la búsqueda de dicho DNI para no tener que hacer necesariamente un click en el botón Buscar

        //document.onkeypress = CapturarTeclaEnter;

        $("#add_antecedentesAcademicos").click(function () {

            var data_post = JSON.stringify({

            });
            _this = this;

            $.ajax({
                url: $('#urlAjax').val().concat("AjaxWS.asmx/CambiarPassword"),
                type: "POST",
                data: data_post,
                //data: "{pass_actual : '" + pass_actual + "', pass_nueva: " + pass_nueva + " }",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (respuestaJson) {
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alertify.alert(errorThrown);
                }
            });
        });


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
        
    });

    var AgregarAntecedentes = function () {

        var n = $('tr:last td', $("#tabla_antecedentes")).length;
        var valores = new Array();
        valores.push($("#txt_titulo").val());
        valores.push($("#txt_ingreso").val());
        valores.push($("#txt_egreso").val());
        valores.push($("#txt_establecimiento").val());
        valores.push($("#txt_localidad").val());
        valores.push($("#cmb_pais").val());
        valores.push($("#txt_especialidad").val());

        var tds = '<tr>';
        for (var i = 0; i < n; i++) {

            tds += '<td>'+ valores[i] + '</td>';
        }
        tds += '</tr>';

        $("#tabla_antecedentes").append(tds);

    };

</script>
</html>