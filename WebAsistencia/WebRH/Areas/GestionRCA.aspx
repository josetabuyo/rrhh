<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionRCA.aspx.cs" Inherits="Areas_GestionRCA" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>           
    <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
    <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
    <script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
    <script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
    <script type="text/javascript" src="../Scripts/Persona.js"></script>
    <script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>
    <script type="text/javascript" src="../Scripts/ComboConBusquedaYAgregado.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"></script>
</head>


<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu1" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />

    <fieldset style="text-align: center; margin-top: 40px" >
        <legend>Gestion de Responsables de Control de Asistencia</legend>
    </fieldset>

    <%--<div style="text-align: right">
        <a style="font-size: 1.6em;display: block;margin-bottom: 10px;" href="ConsultaIndividualDDJJ.aspx">Consulta Individual de DDJJ104</a>
    </div>
    
    <div>    
        <select runat="server" title="Seleccione un mes" id="cmbMeses" name="Meses" enableviewstate="false" style="text-transform: capitalize;">
        </select>
    </div>


    <div id="grilla" runat="server" style="width: 100%" align="center">
        <label>Ingrese el Area o Estado que desea buscar: </label>
        <input type="text" id="search" class="search" class="buscador" placeholder="Buscar Area/Estado" style="width:250px"; />
        <div id="ContenedorGrillaAreas" style="width: 90%"></div>
        <div id="DivBotonExcel" runat="server" style="width: 90%"></div>
    </div>--%>
    
    <div id="grillaPersonas" runat="server" style="width: 100%" align="center">
        <div id="ContenedorPersona" runat="server" style="width: 90%"></div>
    </div>

    <div class="contenedorArea" style="display:none;">
     
         <div id="buscador_de_personas" >
            <p class="buscarPersona">Agregar Persona a RCA:
                <div id="selector_usuario" class="selector_personas" style="margin-bottom: 0px;">
                    <input id="buscador" type=hidden/>
                </div>
            </p>
        </div>
       
        <p class="nombreArea"></p>
        <table class="table table-striped table-bordered table-condensed table-hover tablaPersonas" style="cursor: pointer;">
            <thead class="detalle_viatico_titulo_tabla_detalle">
                <tr>
                    <th>Nombre</th>
                    <th>Documento</th>
                    <th>Permiso</th>
                </tr>
            </thead>
            <tbody class="list">
                <tr class="filaAgente" style="display:none;">
                    <td class="nombreAgente"></td>
                    <td class="documento"></td>
                    <td class="permiso"><input type="button" value="Eliminar" class="btn miBoton" /></td>
                </tr>
            </tbody>
          </table>

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
    </div>
      
    </form>

    
</body>

    <script src="../scripts/underscore-min.js" type="text/javascript"></script>
    <script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
    <script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
    <script src="../scripts/Spin.js" type="text/javascript"></script>
    <script src="GestionDeAreas.js" type="text/javascript"></script>
     <script type="text/javascript">
         $(document).ready(function () {

             Backend.start(function () {
                 GestionDeAreas.getAreasDelUsuario();
             });
         });

        
    </script>

</html>