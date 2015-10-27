<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanelDeControl.aspx.cs" Inherits="FormularioConcursar_PanelDeControl" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar" TagPrefix="uc3" %>
<%@ Register Src="~/FormularioConcursar/Pasos.ascx" TagName="Pasos" TagPrefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
     <link rel="stylesheet" href="../scripts/select2-3.5.4/select2.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar" >

    <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />
    
    <div class="panel panel-heading">
        <div class="panel_izquierdo" style="height:auto; width:50%" >
           
            <!--<div class="panel panel-default">
                <div class=" estilo_paneles  ">
                
                <a href="#" ><span><img alt="imprimir" width="22px" height="22px" src="../Imagenes/Botones/impresora.png" />&nbsp;Imprimir</span></a>    
                <a href="VistaPreliminar.aspx" ><span><img alt="descargar" width="22px" height="22px" src="../Imagenes/Botones/guardar.png" />&nbsp;Descargar</span></a>                 
                <hr class="lineas-subraya"/>
                <div  class="panel-body estilo_paneles fondo_form ">
                    <h3 class="panel-title" style="text-align:center; font-size:12pt; font-weight: bold;">Mi CV</h3>
                    <hr class="lineas-subraya"/>
                    <a class="cvFotoUsuario " href="#"><img src="../Imagenes/silueta.gif" alt="Avatar Usuario" width="125" /></a>
                    <div class="cvOverview"> 
                	    <p class=""><a class="cvNombrePostulante" href="#"><%=nombre +" "+ apellido  %></a></p>
                        <p class="cvEstadoCv">Tu CV está al  <span id="Span1">85</span>%</p>
                        <div class="cvProgress">
                            <div class="cvProgressBar cvProgressBarAlta" style="width: 85%"></div>
                        </div>
                    </div>
                </div>
                </div>
            </div>-->
            <div id="prueba">
                <input id="cmb_provincia" style="width: 320px;" rh-control-type="combo" rh-propiedad-label="Nombre"
                    rh-data-provider="Provincias" rh-model-property="Provincia" data-validar="haySeleccionEnCombo">
            </div>
            <legend><q>Bienvenid@</q></legend>
            <p>El Ministerio de Desarrollo Social de la Nación tiene el gran placer de darte la bienvenida a este sitio web donde esperamos poder brindarte una ágil y cómoda experiencia para la gestión de tu información personal en forma de un Currículum Vitae electrónico.</p>
            <p>En este sitio podrás ingresar tus datos personales, tu historial académico y laboral, así como toda otra información que pudiera resultar de interés para las búsquedas laborales que oportunamente ponga en vigencia el Ministerio.</p>
            <p>Una vez que hayas ingresado tu información, podrás volver y actualizarla cuanta veces lo desees, siempre teniendo en cuenta que los datos aquí consignados deberán ser factibles de verificación documental, es decir deberás contar con los comprobantes respectivos de toda la información volcada en tu Currículum Vitae.</p>
            <p>Asimismo, desde esta página, te será posible realizar tus postulaciones a las convocatorias que el Ministerio de Desarrollo Social habilite oportunamente, realizando la preinscripción electrónica que implica adjuntar este Currículum Vitae digital al perfil que selecciones.</p>
            <p>Para ello, encontrarás publicadas las bases y condiciones de cada Perfil de Puesto de Trabajo que integre las distintas convocatorias, las cuales deberás leer con atención a fin de encontrar aquellas que resulten más adecuadas a tu historial, potencialidades y aspiraciones personales y laborales.</p>
            <p>También podrás encontrar en esta página toda la información relativa al desarrollo y evolución de tus postulaciones en los distintos llamados en los que participes, pudiendo consultar las Actas de los Comités y toda otra información que pudiera resultar de interés.</p>
            <p>Esperamos transformar este lugar en un instrumento dinámico de comunicación, el cual irá creciendo y evolucionando de acuerdo a la experiencia mutua de quienes integramos el Ministerio y, principalmente de quienes, como vos, nos aporten nuevas ideas y nos acerquen sus necesidades informativas para mejorar cada día en este gran desafío de gestionar personas y crear nuevas capacidades para un Estado moderno, inteligente y comprometido con la realidad actual.</p>
        </div>

        <div style="float:right; " class="panel_derecho">
           <%-- <a href="#" ><span><img alt="imprimir" width="22px" height="22px" src="../Imagenes/Botones/impresora.png" />&nbsp;Imprimir CV</span></a>    --%>
            <a href="VistaPreliminar.aspx" target="_blank" ><span><img alt="descargar" width="22px" height="22px" src="../Imagenes/Botones/guardar.png" />&nbsp;Descargar CV</span></a>                 
           
          <!--  <div class="panel panel-default">-->
              <div style="height: 435px;"   ">
               <h3 class="panel-title" >Mis Postulaciones</h3>
               
                 <hr class="lineas-subraya"/>
                 <div id="tabla_postulaciones"> </div>
                  <!-- <table id="tabla_postulaciones" style="width:100%;"></table>
                 <div class="feedPostulacionesAplicadas sombra_y_redondeado"> 
                    <h3 class="subtitulo_postulaciones"><a href="#">Programador para RRHH/ CABA </a></h3>
                    <hr class="SubrayadoPostulaciones degrade"/>
                  <p>Se require programadores con conocimientos avanzados en c#</p>
                  </div>

                <div class="feedPostulacionesAplicadas sombra_y_redondeado">
                    <h3 class="subtitulo_postulaciones"><a href="#">Adminitrador de Redes RRHH/ CABA </a></h3>
                    <hr class="SubrayadoPostulaciones degrade"/>
                    <p>Se require expertos en Redes para administrar la infraestructura</p>-->
                    
                    
                </div>
              </div>
            </div>

        <!--</div>-->
    </div>
    <asp:HiddenField ID="postulaciones" runat="server" />
            </form>
</body>

 <%= Referencias.Javascript("../") %>
 <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
 <script type="text/javascript" src="PanelDeControl.js"></script>
 <script type="text/javascript" src="../Scripts/FormularioBindeado.js"></script>
<script type="text/javascript" src="../Scripts/NuevoComboConBusquedaYAgregado.js"></script>
<script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"> </script>
<script type="text/javascript" src="../Scripts/select2-3.5.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.5.4/select2_locale_es.js"></script>
<script type="text/javascript" src="../Scripts/ObjectObserver.js"> </script>
<script type="text/javascript" src="../Scripts/String.js"> </script>
 <script type="text/javascript">
     $('#tab_panel').addClass('active');
     var prueba = {
         Provincia: 1
     };
    Backend.start();
    $(document).ready(function () {
        var postulaciones = JSON.parse($('#postulaciones').val());

        if ($.browser.msie) {
            alert("PARA UNA MEJOR EXPERIENCIA LE RECOMENDAMOS QUE POR FAVOR UTILICE NAVEGADORES MODERNOS COMO CHROME O FIREFOX " + $.browser.version);
        }

        PanelDeControl.armarPostulaciones(postulaciones);


        //DEBUG
        var rh_form = new FormularioBindeado({
            formulario: $("#prueba"),
            modelo: prueba
        });


    });
 </script>
</html>
