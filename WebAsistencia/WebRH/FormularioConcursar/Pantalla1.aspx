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

   <style type="text/css">
       
body {
	padding: 0 10px;
	font: normal 62.5% ;
	font-family: Calibri,Verdana,Arial;
}
	
p { margin: 10px 0; }
	
.sr {
	position: absolute;
	left: -9999em;
	top: 0;
	width: 1px;
	height: 1px;
	overflow: hidden;
	}
       
       
form.cmxform fieldset {
  margin-bottom: 10px;
}
form.cmxform legend {
  padding: 0 2px;
  font-weight: bold;
  font-size:14px;
}
form.cmxform label {
 
  line-height: 1.8;
  vertical-align: top;
}
/*form.cmxform fieldset ol {
  margin: 0;
  padding: 0;
}
form.cmxform fieldset li {
  list-style: none;
  padding: 5px;
  margin: 0;
}*/
form.cmxform fieldset fieldset {
  border: none;
  margin: 3px 0 0;
}
form.cmxform fieldset fieldset legend {
  padding: 0 0 5px;
  font-weight: normal;
}
form.cmxform fieldset fieldset label {
  display: block;
  width: auto;
}
form.cmxform em {
  font-weight: bold;
  font-style: normal;
  color: #f00;
}
form.cmxform label {
  /*width: auto; /* Width of labels */
  display: block;
  margin-bottom: 5px;
}
form.cmxform fieldset fieldset label {
  margin-left: 123px; /* Width plus 3 (html space) */
}
   

form.cmxform {
	width: 100%;
	font-size: 15px;
	color: #333;
	}
	
form.cmxform legend { padding-left: 0; }
	
form.cmxform legend,
form.cmxform label { color: #333; }

form.cmxform fieldset {
	border: none;
	/*border-top: 1px solid #d1edff;*/
	
	}
	
form.cmxform fieldset fieldset { background: none; }
	
form.cmxform fieldset li {
	padding: 5px 10px 7px;
	background: url(../images/cmxform-divider.gif) left bottom repeat-x;
	}   
/*del bootstrap*/
label {

}
label, input, button, select, textarea {
    font-size: 14px;
    font-weight: normal;
    line-height: 20px;
}

.table th, .table td {
    padding: 2px;
}

/*de estilos sacc*/
.table-striped tbody tr:nth-child(odd) td {
background-color: #fff;
border-top: 1px solid #929292;
border-bottom: 1px solid #929292;
}

.table tbody tr:hover td, .table tbody tr:hover th {
    background-color: transparent;/* #f5f5f5;*/
}

/*ESTILO ACORDION*/

#accordion 
{
    width: 60%;  
    margin-left:19%;
}

#accordion .accordion-heading a {  
    color: #fff;  
    line-height: 20px;  
    /*display: block;  */
    font-size: 12pt;  
    /*width: 100%;  */
    
    text-indent: 10px;  
    text-decoration:none;    
} 
    


#accordion .accordion-heading:first-of-type {  
    background-color: #389abe;  
    background-image: -moz-linear-gradient(top,  #dbdbdb 0%, #f9f9f9 100%); /* FF3.6+ */  
    background-image: -webkit-gradient(linear, left top, left bottombottom, color-stop(0%,#dbdbdb), color-stop(100%,#f9f9f9)); /* Chrome,Safari4+ */  
    background-image: -webkit-linear-gradient(top,  #dbdbdb 0%,#f9f9f9 100%); /* Chrome10+,Safari5.1+ */  
    background-image: -o-linear-gradient(top,  #dbdbdb 0%,#f9f9f9 100%); /* Opera 11.10+ */  
    background-image: -ms-linear-gradient(top,  #dbdbdb 0%,#f9f9f9 100%); /* IE10+ */  
    background-image: linear-gradient(to bottombottom,  #dbdbdb 0%,#f9f9f9 100%); /* W3C */  
    filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#dbdbdb', endColorstr='#f9f9f9',GradientType=0 ); /* IE6-9 */  
} 

#accordion .accordion-heading a   
{
    color: #00293d;
   /*text-shadow: 1px 1px 0px rgba(0,0,0,0.2);  
    text-shadow: 1px 1px 0px rgba(0,0,0,0.2);  
    border-right: 1px solid rgba(0, 0, 0, .2);  
    border-left: 1px solid rgba(0, 0, 0, .2);  
    border-bottom: 1px solid rgba(0, 0, 0, .2);  
    border-top: 1px solid rgba(250, 250, 250, .2);  */
}  
/*
#accordion .accordion-inner {  
    box-shadow: inset 0px -1px 0px 0px rgba(0, 0, 0, .4),  
                inset 0px 1px 1px 0px rgba(0, 0, 0, .2);  
}  
#accordion .accordion-inner:last-of-type {  
    box-shadow: inset 0px 1px 1px 0px rgba(0, 0, 0, .2),  
                inset 0px 0 0px 0px rgba(0, 0, 0, .5);  
}  

.menu 
{
    float:left; 
    width:15%;
    padding:0px 5px;
    border:solid 1px #0088cc;
    
    
}
.menu a:hover 
{
    text-decoration:none;
    }*/
    
    /* Botón para Ir Arriba CSS de Aizum Blog
----------------------------------------------- */
#IrArriba {
position: fixed;
bottom: 30px; /* Distancia desde abajo */
right: 30px; /* Distancia desde la derecha */
}

#IrArriba span {
width: 50px; /* Ancho del botón */
height: 50px; /* Alto del botón */
display: block;
background: url('../Imagenes/Botones/boton-subir1.png') no-repeat center center;
}

nav
    {
        height: auto; /*Junto a overflow: hidden; aplicará a nuestro elemento nav el mismo alto que el más alto de sus elementos hijos */ 
        margin: 0 auto; /* Centro el contenedor */
        overflow: hidden;
        text-align: left;
        width: 100%; /* Defino el ancho de mi página */
        vertical-align: middle;
       
        
    }
    
ul
    {
        margin: 0 auto; 
        float: left;
        list-style-type: none; /* Elimino los estilos de lista */
        padding: 0; 
        vertical-align: middle;
        font-size:medium; 
        cursor:pointer;
    }
    
li
    {
        /*width: 25%;*/
        float: left; /* Floto los li para que se dispongan horizontalmente */
        border-right: solid 1.5px #0088cc ;
    }
    
li a
    {
        padding: 10px; /* El padding añadirá separación entre los elementos */  
    }
    
li a:hover 
{
     text-decoration:none !important;
}

.no_borde 
{
    border-right:none;
    }
    
.fondo_form {
    background: -moz-linear-gradient(top,  #fff 0%,  #87a7ad 100%); /* FF3.6+ */  
    background: -webkit-gradient(linear, left top, left bottombottom, color-stop(0%,#fff), color-stop(100%, #87a7ad)); /* Chrome,Safari4+ */  
    background: -webkit-linear-gradient(top,  #fff 0%,#87a7ad 100%); /* Chrome10+,Safari5.1+ */  
    background: -o-linear-gradient(top,  #fff 0%, #87a7ad 100%); /* Opera 11.10+ */  
    background: -ms-linear-gradient(top,  #fff 0%,# 87a7ad 100%); /* IE10+ */  
    background: linear-gradient(to bottombottom,  #fff 0%,#87a7ad 100%); /* W3C */  
    /*filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#fff', endColorstr='#87a7ad',GradientType=0 ); /* IE6-9   */
   
    /*PARA QUE SE VEA EN IE VIEJOS*/
    -pie-background: linear-gradient(#fff 0%, #87a7ad 100%, #fff) 0 / 50px #0ae;
    behavior: url(../Estilos/css3_for_ie/PIE.htc);
    
    }
   
.link
{
    text-decoration:none !important;
}
   </style>

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
                    <legend><a id="a2" rel="leanModal" class="link" style="" name="form_antecedentesAcademicos" href="#form_antecedentesAcademicos">Cargar antecedentes academicos</a></legend>
                           
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
                <legend><a id="a3" rel="leanModal" class="" name="form_actividadesCapacitacion"  href="#form_actividadesCapacitacion">Cargar actividades de capacitacion</a></legend>
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
                    <legend><a id="go4" rel="leanModal" class="link" name="form_actividadesDocentes"  href="#form_actividadesDocentes">Cargar actividades docentes</a></legend>
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
                    <legend><a id="go5" rel="leanModal" class="link" name="form_eventosAcademicos"  href="#form_eventosAcademicos">Cargar eventos académicos</a></legend>
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
                    <legend><a id="go6" rel="leanModal" class="link" name="form_publicaciones"  href="#form_publicaciones">Cargar publicaciones o trabajos</a></legend>
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
                    <legend><a id="go7" rel="leanModal" class="link" name="form_matriculas"  href="#form_matriculas">Cargar matriculas</a></legend>
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
                    <legend><a id="go8" rel="leanModal" class="link" name="form_institucionesAcademicas"  href="#form_institucionesAcademicas">Cargar instituciones</a></legend>
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
                    <legend><a id="go9" rel="leanModal" class="link" name="form_experienciasLaborales"  href="#form_experienciasLaborales">Cargar experiencias laborales</a></legend>
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
                    <legend><a id="go10" rel="leanModal" class="link" name="form_idiomasExtranjeros"  href="#form_idiomasExtranjeros">Cargar idiomas</a></legend>
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
                    <legend><a id="go11" rel="leanModal" class="link" name="form_competenciasInformaticas"  href="#form_competenciasInformaticas">Cargar competencias informáticas</a></legend>
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
                    <legend><a id="go12" rel="leanModal" class="link" name="form_otrasCapacidades"  href="#form_otrasCapacidades">Cargar otras capacidades</a></legend>
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
    


<%-----------------    MODAL DE ANTECEDENTES ACADEMICOS---------------------%>

      <div id="form_antecedentesAcademicos" class="form_concursar" >
			        <div id="form_antecedentesAcademicos-ct">
				        <div id="form_antecedentesAcademicos-header" class="form_concursar_header">
					        <h2>Estudios Realizados</h2>
					        <p></p>
					        <a class="modal_close_concursar" href="#"></a>
				        </div>
					    <div id="contenido_form_antecedentes" class="fondo_form">
				           <fieldset style="width:95%; padding-left:3%;" >
                        <p><em>*</em> Campos Obligatorios</p>
                        <legend>III - Antecedentes Académicos</legend>
      
                        <div style="float:left; margin:4px 8px 4px 8px" >
                            <label for="nombre">Título <em>*</em></label>
                            <input id="txt_titulo" type="text" style="width:350px;"  />
                        </div>
                        <div style="float:left; margin:4px 8px 4px 8px">
                            <label for="txt_ingreso">Año/Mes Ingreso <em>*</em></label>
                            <input id="txt_ingreso" type="text" style="width:100px;" />
                        </div>
                        <div style="float:left;  margin:4px 8px 4px 8px">
                            <label for="txt_egreso">Año/Mes Egreso <em>*</em></label>
                            <input id="txt_egreso" type="text" style="width:100px;" />
                        </div>
                        <div style="float:left; clear:left; margin:4px 8px 4px 8px">
                            <label for="txt_establecimiento">Establecimiento <em>*</em></label>
                            <input id="txt_establecimiento" type="text" style="width:350px;" name="txt_establecimiento" />
                        </div>
                        <div style="float:left; margin:4px 8px 4px 8px">
                            <label for="txt_localidad">Localidad <em>*</em></label>
                            <input id="txt_localidad" type="text" style="width:100px;" />
                        </div>
                        <div style="float:left; margin:4px 8px 4px 8px">
                            <label for="cmb_pais">País <em>*</em></label>
                            <select id="cmb_pais" style="width:110px;">
                                <option>Seleccione</option>
                                <option value="1">Argentina</option>
                            </select>
                        </div>

                        <div style="float:left; clear:left; margin:4px 8px 4px 8px">
                            <label for="txt_especialidad">Nombre de Especialidad o Competencia <em>*</em></label>
                            <input id="txt_especialidad" type="text" style="width:350px;" name="txt_especialidad" />
                            <input id="btn_agregar_especialidad" type="button" value="+" />
                           
                
                            <table class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Especialidades</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr><td>Una Especialidad </td></tr>
                                <tr><td>Otra Especialidad </td></tr>
                            </tbody>
                            </table>
                        </div>
                    </fieldset>
				    <div class="btn-fld">
				        <input type="button" class="btn btn-primary" id="add_antecedentesAcademicos"  value="Agregar" onclick="javascript:AgregarAntecedentes();" />
                        <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
                    </div>
                    </div>	         
			        </div>
                </div> 

<%-----------------    MODAL DE ACTIVIDADES CAPACITACION---------------------%>

<div id="form_actividadesCapacitacion" class="form_concursar" >
		<div id="form_actividadesCapacitacion-ct">
			<div id="form_actividadesCapacitacion-header" class="form_concursar_header">
				<h2>Actividades de Capacitación</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="contenido_form_capacitacion" class="fondo_form">
    <fieldset style="width:95%; padding-left:3%;" >
            <p><em>*</em> Campos Obligatorios</p>
            <legend>Actividades de Capacitaci&oacute;n</legend>
            <br />
      <legend>Ingresar Certificaci&oacute;n/Actividad de Capacitaci&oacute;n</legend>
      
            <div style="float:left; margin:4px 8px 4px 8px" >
                <label for="nombre">Diploma o certificaci&oacute;n <em>*</em></label>
                <input id="Text21" type="text" style="width:350px;"  />
            </div>


            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_ingreso">Fecha de inicio <em>*</em></label>
                <input id="Text22" type="text"  style="width:100px;" />
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="txt_egreso">Fecha finalizaci&oacute;n <em>*</em></label>
                <input id="Text23" type="text"  style="width:100px;" />
            </div>
            <div style="float:left; clear:left; margin:4px 8px 4px 8px">
                <label for="txt_establecimiento">Duraci&oacute;n (Horas, d&iacute;as o meses) <em>*</em></label>
                <input id="Text24" type="text" style="width:150px;" name="txt_establecimiento" />
            </div>
           
            <div style="float:left; clear:left;margin:4px 8px 4px 8px">
                <label for="txt_especialidad">Nombre de Especialidad o Competencia <em>*</em></label>
                <input id="Text25" type="text" style="width:350px;" name="txt_especialidad" />
                <input id="Button18" type="button" value="+" />
                
                <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Especialidades</th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td>Una Especialidad </td></tr>
                    <tr><td>Otra Especialidad </td></tr>
                </tbody>
                </table>
            </div>

            <div style="float:left; clear:left; margin:4px 8px 4px 8px">
                <label for="txt_egreso">Establecimiento <em>*</em></label>
                <input id="Text26" type="text"  style="width:350px;" />
            </div>

            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="txt_egreso">Localidad <em>*</em></label>
                <input id="Text27" type="text"  style="width:100px;" />
            </div>

              <div style="float:left; margin:4px 8px 4px 8px">
                <label for="cmb_pais">Pa&iacute;s <em>*</em></label>
                <select id="Select13" style="width:110px;">
                    <option>Seleccione</option>
                    <option value="1">Argentina</option>
                </select>
            </div>
        </fieldset>
		<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button1"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 

<%-----------------    MODAL DE ACTIVIDADES DOCENTES---------------------%>

<div id="form_actividadesDocentes" class="form_concursar" >
		<div id="form_actividadesDocentes-ct">
			<div id="form_actividadesDocentes-header" class="form_concursar_header">
				<h2>Actividades Docentes</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="contenido_form_docentes" class="fondo_form">
                <fieldset style="width:95%; padding-left:3%;" >
<p><em>*</em> Campos Obligatorios</p>
<legend>Ingresar Actividad Docente</legend>
      
<div style="float:left; margin:4px 8px 4px 8px" >
    <label for="actividad-docente_asignatura">Asignatura <em>*</em></label>
    <input id="actividad-docente_asignatura" type="text" style="width:250px;"  />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="actividad-docente_nivel_educativo">Nivel Educativo <em>*</em></label>
    <select id="actividad-docente_nivel_educativo" style="width:100px;"></select>
</div>
<div style="float:left;  margin:4px 8px 4px 8px">
    <label for="actividad-docente_tipo_actividad">Tipo de Actividad <em>*</em></label>
    <input id="actividad-docente_tipo_actividad" type="text" style="width:150px;" />
</div>
<div style="float:left;  margin:4px 8px 4px 8px">
    <label for="actividad-docente_categoria">Categoría Docente <em>*</em></label>
    <input id="actividad-docente_categoria" type="text" style="width:150px;" />
</div>

<div style="float:left; clear:left; margin:4px 8px 4px 8px">
    <label for="actividad-docente_caracter_designacion">Carácter Designación <em>*</em></label>
    <input id="actividad-docente_caracter_designacion" type="text" style="width:170px;" name="" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="actividad-docente_dedicacion">Dedicación Docente <em>*</em></label>
    <input id="Text18" type="text" style="width:150px;" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="actividad-docente_carga_horaria">Carga Horaria <em>*</em></label>
    <input id="actividad-docente_carga_horaria" type="text" style="width:100px;" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="actividad-docente_fecha_inicio">Fecha de Inicio <em>*</em></label>
    <input id="actividad-docente_fecha_inicio" type="text" style="width:100px;" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="actividad-docente_fecha_fin">Fecha de Fin <em>*</em></label>
    <input id="actividad-docente_fecha_fin" type="text" style="width:100px;" />
</div><div style="float:left; clear:left; margin:4px 8px 4px 8px">
    <label for="actividad-docente_establecimiento">Establecimiento <em>*</em></label>
    <input id="actividad-docente_establecimiento" type="text" style="width:350px;" name="txt_establecimiento" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="actividad-docente_localidad">Localidad <em>*</em></label>
    <input id="actividad-docente_localidad" type="text" style="width:225px;" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="actividad-docente_pais">País <em>*</em></label>
    <select id="actividad-docente_pais" style="width:110px;">
        <option>Seleccione</option>
        <option value="1">Argentina</option>
    </select>
</div>
</fieldset>
		<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button2"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 

<%-----------------    MODAL DE EVENTOS ACADEMICOS---------------------%>

        <div id="form_eventosAcademicos" class="form_concursar" >
		<div id="form_eventosAcademicos-ct">
			<div id="form_eventosAcademicos-header" class="form_concursar_header">
				<h2>Eventos Academicos</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="Div4" class="fondo_form">
        <fieldset style="width:95%; padding-left:3%;" >
<p><em>*</em> Campos Obligatorios</p>
<legend>Ingresar Evento Académico</legend>
      
      
<div style="float:left; margin:4px 8px 4px 8px" >
    <label for="nombre">Denominación <em>*</em></label>
    <input id="Text10" type="text" style="width:250px;"  />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="evento-academico_tipo_evento">Tipo evento <em>*</em></label>
    <input id="Text11" type="text" style="width:100px;" />
</div>
<div style="float:left;  margin:4px 8px 4px 8px">
    <label for="evento-academico_caracter_participacion">Carácter de participación <em>*</em></label>
    <input id="Text13" type="text" style="width:200px;" />
</div>
<div style="float:left; clear:left; margin:4px 8px 4px 8px">
    <label for="evento-academico_fecha_inicio">Fecha de Inicio <em>*</em></label>
    <input id="Text14" type="text" style="width:350px;" name="txt_establecimiento" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="evento-academico_fecha_fin">Fecha de Fin <em>*</em></label>
    <input id="Text15" type="text" style="width:100px;" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="evento-academico_pais">Duración <em>*</em></label>
    <input id="Text16" type="text" style="width:100px;" />
</div>

<div style="float:left; clear:left; margin:4px 8px 4px 8px">
    <label for="evento-academico_institucion">Institución <em>*</em></label>
    <input id="Text17" type="text" style="width:350px;" name="txt_establecimiento" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="evento-academico_localidad">Localidad <em>*</em></label>
    <input id="Text19" type="text" style="width:100px;" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="evento-academico_pais">País <em>*</em></label>
    <select id="Select6" style="width:110px;">
        <option>Seleccione</option>
        <option value="1">Argentina</option>
    </select>
</div>
</fieldset>
<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button3"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 


<%-----------------    MODAL DE PUBLICACIONES O TRABAJOS---------------------%>

        <div id="form_publicaciones" class="form_concursar" >
		<div id="form_publicaciones-ct">
			<div id="form_publicaciones-header" class="form_concursar_header">
				<h2>Publicaciones o Trabajos</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="Div5" class="fondo_form">
    <fieldset style="width:95%; padding-left:3%;" >
<p><em>*</em> Campos Obligatorios</p>
<legend>Ingresar Publicación o Trabajo de Investigación</legend>
      
      
<div style="float:left; margin:4px 8px 4px 8px" >
    <label for="publicaciones_titulo">Título <em>*</em></label>
    <input id="publicaciones_titulo" type="text" style="width:250px;"  />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="publicaciones_editorial">Datos de Editorial/Revista <em>*</em></label>
    <input id="publicaciones_editorial" type="text" style="width:250px;" />
</div>
<div style="float:left;  margin:4px 8px 4px 8px">
    <label for="publicaciones_fecha">Fecha <em>*</em></label>
    <input id="publicaciones_fecha" type="text" style="width:100px;" />
</div>

<div style="float:left; clear:left; margin:4px 8px 4px 8px">
    <label for="publicaciones_paginas">Cantidad Páginas <em>*</em></label>
    <input id="publicaciones_paginas" type="text" style="width:120px;" name="" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="publicaciones_dispone_copia">Dispone copia <em>*</em></label>
    <input id="Text20" type="text" style="width:100px;" />
</div>
<div style="float:left; margin:4px 8px 4px 8px">
    <label for="publicaciones_copias">Adjunta copia <em>*</em></label>
    <select></select>
</div>
</fieldset>
<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button4"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 

<%-----------------    MODAL DE MATRICULAS---------------------%>

        <div id="form_matriculas" class="form_concursar" >
		<div id="form_matriculas-ct">
			<div id="form_matriculas-header" class="form_concursar_header">
				<h2>Matriculas</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="Div6" class="fondo_form">
        <fieldset style="width:95%; padding-left:3%;" >
            <p><em>*</em> Campos Obligatorios</p>
            <legend>Ingresar Matrícula Profesional</legend>
      
      
            <div style="float:left; margin:4px 8px 4px 8px" >
                <label for="matricula_numero">Número <em>*</em></label>
                <input id="matricula_numero" type="text" style="width:150px;"  />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="matricula_expedida_por">Expedida por <em>*</em></label>
                <input id="matricula_expedida_por" type="text" style="width:250px;" />
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="matricula_fecha_inscripcion">Fecha de Inscripción <em>*</em></label>
                <input id="matricula_fecha_inscripcion" type="text" style="width:125px;" />
            </div>

            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="matricula_situacion">Situación actual <em>*</em></label>
                <input id="matricula_situacion" type="text" style="width:120px;" name="" />
            </div>
        </fieldset>
<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button5"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 

<%-----------------    MODAL DE INSTITUCIONES ACADEMICAS---------------------%>

        <div id="form_institucionesAcademicas" class="form_concursar" >
		<div id="form_institucionesAcademicas-ct">
			<div id="form_institucionesAcademicas-header" class="form_concursar_header">
				<h2>Instituciones Academicas</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="Div7" class="fondo_form">
        <fieldset style="width:95%; padding-left:3%;" >
            <p><em>*</em> Campos Obligatorios</p>
            <legend>Ingresar Pertenencia a Institución Académica, o Profesional Relevante</legend>
      
      
            <div style="float:left; margin:4px 8px 4px 8px" >
                <label for="pertenencia-institucion_nombre">Nombre de la Institución <em>*</em></label>
                <input id="pertenencia-institucion_nombre" type="text" style="width:250px;"  />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="pertenencia-institucion_caracter">Carácter de la Entidad <em>*</em></label>
                <input id="pertenencia-institucion_caracter" type="text" style="width:225px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="pertenencia-institucion_cargo">Cargos Desempeñados <em>*</em></label>
                <input id="pertenencia-institucion_cargo" type="text" style="width:225px;" name="" />
            </div>

            <div style="float:left; clear:left; margin:4px 8px 4px 8px" >
                <label for="pertenencia-institucion_fecha_afiliacion">Fecha de Afiliación <em>*</em></label>
                <input id="pertenencia-institucion_fecha_afiliacion" type="text" style="width:100px;"  />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="pertenencia-institucion_numero_afiliado">Número Afiliado <em>*</em></label>
                <input id="pertenencia-institucion_numero_afiliado" type="text" style="width:225px;" />
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="pertenencia-institucion_categoria_actual">Categoría actual <em>*</em></label>
                <input id="pertenencia-institucion_categoria_actual" type="text" style="width:225px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="pertenencia-institucion_fecha">Fecha <em>*</em></label>
                <input id="pertenencia-institucion_fecha" type="text" style="width:100px;" name="" />
            </div>

            <div style="float:left; clear:left; margin:4px 8px 4px 8px" >
                <label for="pertenencia-institucion_localidad">Localidad <em>*</em></label>
                <input id="pertenencia-institucion_localidad" type="text" style="width:225px;"  />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="pertenencia-institucion_pais">País <em>*</em></label>
                <select id="pertenencia-institucion_pais" style="width:130px;"></select>
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="pertenencia-institucion_fecha_inicio">Fecha Inicio <em>*</em></label>
                <input id="pertenencia-institucion_fecha_inicio" type="text" style="width:125px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="pertenencia-institucion_fecha_fin">Fecha Fin <em>*</em></label>
                <input id="pertenencia-institucion_fecha_fin" type="text" style="width:120px;" name="" />
            </div>
        </fieldset>
<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button6"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 


<%-----------------    MODAL DE EXPERIENCIAS LABORALES---------------------%>

        <div id="form_experienciasLaborales" class="form_concursar" >
		<div id="form_experienciasLaborales-ct">
			<div id="form_experienciasLaborales-header" class="form_concursar_header">
				<h2>Experiencias Laborales</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="Div8" class="fondo_form">
        <fieldset style="width:95%; padding-left:3%;" >
            <p><em>*</em> Campos Obligatorios</p>
            <legend>Ingresar Experiencia Laboral Relevante</legend>
      
      
            <div style="float:left; margin:4px 8px 4px 8px" >
                <label for="experiencia-laboral_puesto">Puesto ocupado <em>*</em></label>
                <input id="experiencia-laboral_puesto" type="text" style="width:350px;"  />
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="experiencia-laboral_personal_a_cargo">Personal a cargo <em>*</em></label>
                <input id="experiencia-laboral_personal_a_cargo" type="text" style="width:100px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="experiencia-laboral_fecha_inicio">Fecha Inicio <em>*</em></label>
                <input id="experiencia-laboral_fecha_inicio" type="text" style="width:100px;" />
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="experiencia-laboral_fecha_fin">Fecha Fin <em>*</em></label>
                <input id="experiencia-laboral_fecha_fin" type="text" style="width:100px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="experiencia-laboral_motivo_desvinculacion">Motivo de Desvinculación <em>*</em></label>
                <input id="experiencia-laboral_motivo_desvinculacion" type="text" style="width:350px;" name="txt_establecimiento" />
            </div>
            <div style="float:left; clear:left; margin:4px 8px 4px 8px">
                <label for="experiencia-laboral_empleador">Nombre del Empleador <em>*</em></label>
                <input id="experiencia-laboral_empleador" type="text" style="width:325px;" name="txt_establecimiento" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_localidad">Tipo Empresa / Institución <em>*</em></label>
                <input id="Text47" type="text" style="width:175px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_localidad">Sector <em>*</em></label>
                <input id="Text48" type="text" style="width:175px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_localidad">Localidad <em>*</em></label>
                <input id="Text43" type="text" style="width:225px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="cmb_pais">País <em>*</em></label>
                <select id="Select7" style="width:130px;">
                    <option>Seleccione</option>
                    <option value="1">Argentina</option>
                </select>
            </div>

            <div style="float:left; clear:left; margin:4px 8px 4px 8px">
                <label for="txt_especialidad">Nombre de la Principal Actividad o Responsabilidad <em>*</em></label>
                <input id="Text44" type="text" style="width:350px;" name="txt_especialidad" />
                <input id="Button8" type="button" value="+" />
                
                <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Actividades o Responsabilidades</th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td>Una Actividad </td></tr>
                    <tr><td>Otra Actividad </td></tr>
                    <tr><td>Una Responsabilidad </td></tr>
                </tbody>
                </table>
            </div>
        </fieldset>
<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button7"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 


<%-----------------    MODAL DE IDIOMAS EXTANJEROS ---------------------%>

 <div id="form_idiomasExtranjeros" class="form_concursar" >
		<div id="form_idiomasExtranjeros-ct">
			<div id="form_idiomasExtranjeros-header" class="form_concursar_header">
				<h2>Idiomas Extranjeros</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="Div9" class="fondo_form">
       <fieldset style="width:95%; padding-left:3%;" >
            <p><em>*</em> Campos Obligatorios</p>
            <legend>Ingresar Idioma Extranjero</legend>
      
      
            <div style="float:left; margin:4px 8px 4px 8px" >
                <label for="nombre">Diploma/Certificación <em>*</em></label>
                <input id="Text49" type="text" style="width:250px;"  />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_ingreso">Fecha de Obtención <em>*</em></label>
                <input id="Text50" type="text" style="width:100px;" />
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="txt_egreso">Establecimiento <em>*</em></label>
                <input id="Text51" type="text" style="width:250px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_localidad">Localidad <em>*</em></label>
                <input id="Text58" type="text" style="width:250px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="cmb_pais">País <em>*</em></label>
                <select id="Select8" style="width:130px;">
                    <option>Seleccione</option>
                    <option value="1">Argentina</option>
                </select>
            </div>

            <div style="float:left; clear:left; margin:4px 8px 4px 8px" >
                <label for="nombre">Idioma <em>*</em></label>
                <input id="Text52" type="text" style="width:150px;"  />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_ingreso">Lectura <em>*</em></label>
                <select id="Select8" style="width:125px;"></select>
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="txt_egreso">Escritura <em>*</em></label>
                <select id="Select9" style="width:125px;"></select>
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="txt_egreso">Oral <em>*</em></label>
                <select id="Text55" style="width:125px;"></select>
                <input id="Button10" type="button" value="+" />
            </div>
            <div style="float:left; clear:left;  margin:4px 8px 4px 8px">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th colspan="4">Idiomas</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="width:150px">Inglés </td>
                            <td style="width:125px">Básico </td>
                            <td style="width:125px">Intermedio </td>
                            <td style="width:115px">Avanzado </td>
                            <td > <input id="Button11" type="button" value="-" /> </td>
                        </tr>
                        <tr>
                            <td>Chino </td>
                            <td>Básico </td>
                            <td>Intermedio </td>
                            <td>Bilingüe </td>
                            <td><input id="Button12" type="button" value="-" /> </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </fieldset>
<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button9"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 


<%-----------------    MODAL DE COMPETENCIAS INFORMACTICAS ---------------------%>

 <div id="form_competenciasInformaticas" class="form_concursar" >
		<div id="form_competenciasInformaticas-ct">
			<div id="form_competenciasInformaticas-header" class="form_concursar_header">
				<h2>Competencias Informaticas</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="Div13" class="fondo_form">
        <fieldset style="width:95%; padding-left:3%;" >
            <p><em>*</em> Campos Obligatorios</p>
            <legend>Ingresar Competencia Informática</legend>
      
      
            <div style="float:left; margin:4px 8px 4px 8px" >
                <label for="nombre">Diploma/Certificación <em>*</em></label>
                <input id="Text53" type="text" style="width:250px;"  />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_ingreso">Fecha de Obtención <em>*</em></label>
                <input id="Text54" type="text" style="width:100px;" />
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="txt_egreso">Establecimiento <em>*</em></label>
                <input id="Text56" type="text" style="width:250px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_localidad">Localidad <em>*</em></label>
                <input id="Text59" type="text" style="width:250px;" />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="cmb_pais">País <em>*</em></label>
                <select id="Select10" style="width:130px;">
                    <option>Seleccione</option>
                    <option value="1">Argentina</option>
                </select>
            </div>

            <div style="float:left; clear:left; margin:4px 8px 4px 8px" >
                <label for="nombre">Tipo Informática <em>*</em></label>
                <input id="Text57" type="text" style="width:250px;"  />
            </div>
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_ingreso">Conocimiento <em>*</em></label>
                <select id="Select11" style="width:275px;"></select>
            </div>
            <div style="float:left;  margin:4px 8px 4px 8px">
                <label for="txt_egreso">Nivel <em>*</em></label>
                <select id="Select12" style="width:125px;"></select>
                <input id="Button14" type="button" value="+" />
            </div>
            <div style="float:left; clear:left;  margin:4px 8px 4px 8px">
                <table class="table table-striped">
                    <thead>
                        <tr>
                            <th colspan="3">Competencias informáticas</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="width:250px">Bases de Datos </td>
                            <td style="width:275px">PL/SQL </td>
                            <td style="width:115px">Avanzado </td>
                            <td > <input id="Button15" type="button" value="-" /> </td>
                        </tr>
                        <tr>
                            <td>Bases de Datos </td>
                            <td>SQL Server 2012 </td>
                            <td>Intermedio </td>
                            <td><input id="Button16" type="button" value="-" /> </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </fieldset>
<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button13"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 


<%-----------------    MODAL DE OTRAS CAPACIDADES ---------------------%>

        <div id="form_otrasCapacidades" class="form_concursar" >
		<div id="form_otrasCapacidades-ct">
			<div id="form_otrasCapacidades-header" class="form_concursar_header">
				<h2>Otras Capacidades</h2>
				<p></p>
				 <a class="modal_close_concursar" href="#"></a>
			</div>
				<div id="Div10" class="fondo_form">
      <fieldset style="width:95%; padding-left:3%;" >
           
            <legend>Capacidades personales</legend>
            <br />
      <legend>Ingresar Capacidad Personal</legend>
      
            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_especialidad">Aptitudes Sociales</label>
                <input id="Button19" type="button" value= "Agregar aptitud social" style="width:300px;" name="txt_especialidad" />&nbsp;
                
                <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Describa el &aacute;mbito en el que las ha usado</th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td><textarea class="field span3" rows="2" cols="1"></textarea></td></tr>
                </tbody>
                             

                </table>
        
          </div>

            <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_especialidad">Aptitudes Organizativas</label>
                <input id="Button20" type="button" value= "Agregar aptitud organizativa" style="width:300px;" name="txt_especialidad" />&nbsp;
                
                <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Describa el &aacute;mbito en el que las ha usado</th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td><textarea rows="2" cols="1" class="field span3">
</textarea></td></tr>
                </tbody>

              

                </table>
            </div>


             <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_especialidad">Otras Aptitudes T&eacute;cnicas</label>
                <input id="Button21" type="button" value= "Agregar otra aptitud" style="width:300px;" name="txt_especialidad" />&nbsp;
                
                <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Describa el &aacute;mbito en el que las ha usado</th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td><textarea rows="2" cols="1" class="field span3">
</textarea></td></tr>
                </tbody>

              

                </table>
            </div>



              <div style="float:left; margin:4px 8px 4px 8px">
                <label for="txt_especialidad">Otras que considere relevantes</label>
                <input id="Button22" type="button" value= "Agregar otra aptitud relevante" style="width:300px;" name="txt_especialidad" />&nbsp;
                
                <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Describa el &aacute;mbito en el que las ha usado</th>
                    </tr>
                </thead>
                <tbody>
                    <tr><td><textarea rows="2" cols="1" class="field span3">
</textarea></td></tr>
                </tbody>

              

                </table>
            </div>


        </fieldset>

<div class="btn-fld">
			<input type="button" class="btn btn-primary" id="Button17"  value="Agregar"  />
            <%--<input type="button" class="btn btn-primary" id="del_antecedentesAcademicos"  value="Cancelar" />--%>
        </div>
        </div>	         
		</div>
    </div> 


<%-----------------    MODAL DE VISTA PREELIMINAR ---------------------%>


                <asp:TextBox ID="urlAjax" runat="server" Text=""  style="display:none;" />

      <%--  
        <ol>
			<li><label for="dob">Date of Birth <span class="sr">(Day)</span> <em>*</em></label> <select id="dob"><option value="1">1</option><option value="2">2</option></select> <label for="dob-m" class="sr">Date of Birth (Month) <em>*</em></label> <select id="dob-m"><option value="1">Jan</option><option value="2">Feb</option></select> <label for="dob-y" class="sr">Date of Birth (Year) <em>*</em></label> <select id="dob-y"><option value="1979">1979</option><option value="1980">1980</option></select></li>
			<li><label for="sex">Sex <em>*</em></label> <select id="sex"><option value="female">Female</option><option value="male">Male</option></select></li>
			<li>
				<fieldset>
					<legend>Which of the following sports do you enjoy?</legend>
					<label for="football"><input id="football" type="checkbox"> Football</label>
					<label for="golf"><input id="golf" type="checkbox"> Golf</label>
					<label for="rugby"><input id="rugby" type="checkbox"> Rugby</label>
					<label for="tennis"><input id="tennis" type="checkbox"> Tennis</label>
					<label for="basketball"><input id="basketball" type="checkbox"> Basketball</label>
					<label for="boxing"><input id="boxing" type="checkbox"> Boxing</label>
				</fieldset>
			</li>
			<li><label for="comments">Comments</label> <textarea id="comments" rows="7" cols="25"></textarea></li>
		</ol>--%>

  </form>

<%--  <asp:HiddenField ID="antecedentesAcademicosJSON" runat="server" EnableViewState="true"/>--%>
<div id='IrArriba'><a href='#Arriba'><span></span></a></div>

</body>
    <%= Referencias.Javascript("../") %>
       
       <%-- <script src="../Scripts/jquery.modal.js" type="text/javascript" charset="utf-8"></script>--%>

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
                //pass_actual: pass_actual,
                //pass_nueva: pass_nueva
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
                    //                    var respuesta = JSON.parse(respuestaJson.d);
                    //                    if (respuesta.tipoDeRespuesta == "cambioPassword.ok") {

                    //                        alertify.alert("Se cambio la contrase&ntilde;a correctamente");
                    //                        $(".modal_close").click();
                    //                        $('#pass_actual').val("");
                    //                        $('#pass_nueva').val("");
                    //                        $('#pass_nueva_repetida').val("");
                    //                        return;
                    //                    }

                    //                    if (respuesta.tipoDeRespuesta == "cambioPassword.error") {
                    //                        alertify.alert("La contrase&ntilde;a actual no es correcta");
                    //                        $(".modal_close").click();
                    //                        return;
                    //                    }

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alertify.alert(errorThrown);
                }
            });
        });
    });

//    var ValidarCamposVacios = function (pass_actual, pass_nueva, pass_nueva_repetida) {
//        if (pass_actual == "" || pass_nueva == "" || pass_nueva_repetida == "") {
//            alertify.alert("Complete todos los campos");
//            return false;
//        }
//        return true;
//    };
    //



    $(function () {
        $('a[rel*=leanModal]').leanModal({ top: 300, closeButton: ".modal_close" });
    });

    $(function () {
        $('a[rel*=leanModal]').leanModal({ top: 300, closeButton: ".modal_close_concursar" });
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
    

//    var PlanillaAlumnos;
//    var contenedorPlanilla_AntecedentesAcademicos;
//    
//    var AdministradorPlanillaMensual = function () {
//        var antecedentesAcademicos = JSON.parse($('#antecedentesAcademicosJSON').val());
//        //var nombreAlumno = Alumnos['nombre'];
//        //var panelAlumno = $("#panelAlumno");

//        //var listaPersonas = $('#personasJSON');
//        //var selectorDePersonas = $('#input_dni');
//        //var personaSeleccionada = $('#personaSeleccionada');

//        //crearInputAutocompletable(selectorDePersonas, listaPersonas, personaSeleccionada);

//        var EncabezadoPlanilla;
//        contenedorPlanilla = $('#ContenedorPlanilla');
//        var columnas = [];

//        columnas.push(new Columna("Univer", { generar: function (un_alumno) { return un_alumno.Documento } }));
//        columnas.push(new Columna("Nombre", { generar: function (un_alumno) { return un_alumno.Nombre } }));
//        columnas.push(new Columna("Apellido", { generar: function (un_alumno) { return un_alumno.Apellido } }));
//        //columnas.push(new Columna("Pertenece A", { generar: function (un_alumno) { return un_alumno.area.descripcion } }));
//        columnas.push(new Columna("Teléfono", { generar: function (un_alumno) { return un_alumno.Telefono } }));
//        columnas.push(new Columna("Modalidad", { generar: function (un_alumno) { return un_alumno.Modalidad.Descripcion } }));
//        columnas.push(new Columna('Detalle', { generar: function (un_alumno) {
//            var contenedorBtnFichaAlumno = $('<div>');
//            var botonVerAlumno = $('<input>');
//            botonVerAlumno.attr('type', 'button');
//            botonVerAlumno.addClass('btn');
//            botonVerAlumno.addClass('btn-primary');
//            botonVerAlumno.val('Ver Ficha');
//            botonVerAlumno.click(function () {
//                $("#DNIAlumnoFicha").val(un_alumno.Documento);
//                $("#btnVerFichaAlumno").click();
//            });
//            contenedorBtnFichaAlumno.append(botonVerAlumno);

//            return contenedorBtnFichaAlumno;
//        }
//        }));

//        PlanillaAlumnos = new Grilla(columnas);

//        PlanillaAlumnos.AgregarEstilo("tabla_macc");
//        //PlanillaAlumnos.agregarBuscador();

//        PlanillaAlumnos.SetOnRowClickEventHandler(function (un_alumno) {
//            panelAlumno.CompletarDatosAlumno(un_alumno);
//        });

//        PlanillaAlumnos.CargarObjetos(Alumnos);
//        PlanillaAlumnos.DibujarEn(contenedorPlanilla);


</script>
</html>