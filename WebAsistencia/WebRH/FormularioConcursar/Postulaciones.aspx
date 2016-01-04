<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Postulaciones.aspx.cs" Inherits="FormularioConcursar_Postulaciones" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="MenuConcursar.ascx" TagName="MenuConcursar" TagPrefix="uc3" %>
<%@ Register Src="~/FormularioConcursar/Pasos.ascx" TagName="Pasos" TagPrefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
   
   <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
     <style>
     
      .contenedor_concursar 
    {
        width: 59%;
        margin-left:19%;
    }

      .buscador
      {
       width: 70%;
       margin-top:10px;    
      }
      
     
     </style>

</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    
    <div id="contenido_inscripcion" class="contenedor_concursar">
    
    <uc3:MenuConcursar runat="server" />
    
        <div>
            <h2 class="titulo_postulaciones">Proceso de Postulación => Perfiles, Cargos y Bases</h2>
            
        </div>

        <uc4:Pasos ID="Pasos" runat="server" /> 
        <div style="clear:both;"></div>
        <p>Ud. puede acotar la búsqueda por cualquier criterio, escriba al menos 3 caracteres en el campo para buscar el puesto que desee</p>           
        
        <div id="ContenedorPlanilla">
         <input type="text" id="search" class="search" class="buscador" placeholder="Buscar"/>
         <!--<a class="btn_concursar btn-small" href="#">Buscar</a>-->

        <table id="tabla_perfiles" style="width:100%;"></table>
        <p><div style="font-weight:bold; float:left">Convocatorias Generales: &nbsp</div> Sólo pueden postularse quienes al momento de hacerlo se encuentren trabajando en el marco del Convenio Colectivo de Trabajo Sectorial del Sistema Nacional de Empleo Público (SINEP)*, 
        sea en Planta Permanente, Planta Transitoria o designado de conformidad con el artículo 9° del Anexo de la Ley 25164. Se recomienda consultar en el área de Recursos Humanos de su organismo si usted está encuadrado en el SINEP</p>
        <p> <div style="font-weight:bold; float:left">Convocatorias Abiertas:&nbsp</div> Pueden postularse todas las personas que acrediten la idoneidad y los requisitos establecidos en las bases de cada concurso. </p>
        <p style="font-weight:bold; font-style:italic">En todos los casos se recomienda tener en cuenta los requisitos excluyentes de cada cargo.</p>
        </div>
          
    </div>


     <asp:HiddenField ID="perfiles" runat="server" />
      <asp:HiddenField ID="postulaciones" runat="server" />
      <asp:HiddenField ID="curriculum" runat="server" />
    </form>
</body>
    <%= Referencias.Javascript("../") %>
   
      <script type="text/javascript" src="Perfil.js" ></script>
<script type="text/javascript">
    $('#tab_cargos').addClass('active');

    $(document).ready(function () {
        $(".collapse").collapse("show");

        var perfiles = JSON.parse($('#perfiles').val());
        var postulaciones = JSON.parse($('#postulaciones').val());
        var curriculum = JSON.parse($('#curriculum').val());

        Perfil.armarLista(perfiles, postulaciones, curriculum);

        var options = {
            valueNames: ['Perfil', 'Nivel', 'Agrupamiento', 'Vacantes']
        };

        var featureList = new List('ContenedorPlanilla', options);

    });

    $('.actions').attr('style', 'display:none');
</script>
</html>
