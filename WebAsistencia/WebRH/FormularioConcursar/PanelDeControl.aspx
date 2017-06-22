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
                        <p class="cvEstadoCv">Tu CV est&aacute; al  <span id="Span1">85</span>%</p>
                        <div class="cvProgress">
                            <div class="cvProgressBar cvProgressBarAlta" style="width: 85%"></div>
                        </div>
                    </div>
                </div>
                </div>
            </div>-->
            <h3>Concursos Planta Permanente</h3>
            <h4>Convocatoria Interna 2017</h4>
            <div class = "panel-de-control-texto">
                <p>El Ministerio de Desarrollo Social de la Nación inicia el proceso de concursos para ingresar a la Planta Permanente de la Administración Pública Nacional (APN).</p> 
                <p>A través de la Resolución 5-E/2017 se identificaron y asignaron los cargos a concursar por esta jurisdicción; como consecuencia, se pondrá en marcha una Convocatoria Interna a Concursos que prevé la cobertura de 726 cargos.</p>
                <p>En esta página vas a encontrar toda la información relevante sobre la Convocatoria Interna: la normativa vigente sobre los concursos, las Bases del Concurso de cada perfil con sus respectivos requisitos, y las Actas que se publicarán a medida que avance el Proceso de Selección.</p>
                <p>Por dudas o consultas, podés comunicarte con la Secretaría Técnica de Concursos de  la Dirección General de Recursos Humanos y Organización al (011) 4380-2500 o acercarte a las MESAS DE AYUDA. Éstas últimas estarán disponibles de 10.00hs. a 16.00hs., en los pisos 15, 19 y 22 de la sede central del Ministerio de Desarrollo Social de la Nación ubicada en Avenida 9 de Julio 1925 de la Ciudad Autónoma de Buenos Aires.</p>
            </div>
            <br />
            <br />
        
            <%--<img src="../Imagenes/underConstruccion.jpg" alt="actualizacion" width="400" height="400" />
            <h1>El Sitio se encuentra en mantenimiento <br /> Estamos trabajando para usted <br />Disculpes las molestias ocasionadas </h1>--%>
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

        </div>
    </div>
    <asp:HiddenField ID="postulaciones" runat="server" />
            </form>
</body>

 <%= Referencias.Javascript("../") %>
 <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
 <script type="text/javascript" src="PanelDeControl.js"></script>

 <script type="text/javascript">
     $('#tab_panel').addClass('active');

    Backend.start();
    $(document).ready(function () {
        var postulaciones = JSON.parse($('#postulaciones').val());

        if ($.browser.msie) {
            alert("PARA UNA MEJOR EXPERIENCIA LE RECOMENDAMOS QUE POR FAVOR UTILICE NAVEGADORES MODERNOS COMO CHROME O FIREFOX " + $.browser.version);
        }

        PanelDeControl.armarPostulaciones(postulaciones);
    });
 </script>
</html>
