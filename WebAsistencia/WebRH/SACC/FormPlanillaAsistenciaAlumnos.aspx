<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaAsistenciaAlumnos.aspx.cs" Inherits="SACC_FormPlanillaAsistenciaAlumnos" %>
<%@ Register Src="~/SACC/ControlPlanillaAsistenciasAlumnos.ascx" TagName="planilla" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%= Referencias.Css("../")%>
    <link id="link3" rel="stylesheet" href="Estilos/EstilosSACC.css" type="text/css" runat="server" /> 
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>

    <script type="text/javascript" src="Scripts/BotonAsistencia.js"></script>
    <script type="text/javascript" src="Scripts/PlanillaAsistencias.js"></script>
    <script type="text/javascript" src="Scripts/AdministradorPlanillaAsistencias.js"></script>
    <style type="text/css">
    .acumuladas
    {
        font-weight:bold;
    }
    </style>

</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="DivContenedor" runat="server" style="margin:10px;">   
    <fieldset>
        <legend class="subtitulos">Asistencias</legend>
        <label>A&ntilde;o:&nbsp;&nbsp;&nbsp;&nbsp;</label>
        <select id="CmbAnio" style="width:100px; text-transform:capitalize" 
            onchange="javascript:CargarComboCursos();" runat="server" enableviewstate="true">
          <option value="0">Seleccione</option>    
        </select>
        <br />
        <label>Curso:&nbsp;</label>
        <select id="CmbCurso" style="width:400px;" runat="server" onchange="javascript:CargarComboMeses();">
            <option value="0">Seleccione</option>
        </select>
        <input type="checkbox" onchange="javascript:FiltrarCursos()" id="filtrar_cursos_vigentes" /><label> Vigentes</label>
        <br />
        <label>Mes:&nbsp;&nbsp;&nbsp;</label>
        <select id="CmbMes" style="width:400px; text-transform:capitalize" 
            onchange="javascript:CargarPlanilla();" runat="server" enableviewstate="true">
        <option value="0">Seleccione</option>
        </select>
        <br />
        <div id="DatosCurso" style="visibility:hidden">
        <label id="lblDocente">Docente:</label>
        <label id="Docente" runat="server">&nbsp;</label>
        <br />
        <br />
        <label id="lblHorasCurso">Horas C&aacute;tedra:</label>
        <label id="HorasCatedraCurso" runat="server">&nbsp;</label>
        </div>
        <br />
        <br />

        </div>
        <div id="ContenedorPlanilla" runat="server" style="display:inline-block;">
        
        </div>
        <div id="DivBotonesObservacion" style="visibility:hidden; width: 100%">
            <input id="BtnGuardar" style="margin-left: 10px;" class="btn btn-primary " type="button" onclick="javascript:GuardarDetalleAsistencias();" value="Guardar"/>
            <input id="BtnImprimir" style="margin-left: 5px;" class="btn btn-primary " type="button" onclick="javascript:ImprimirPlanilla();" value="Imprimir" />
            <br />
            <br />
            <textarea id="TxtObservaciones" style="margin-left: 5px;" class="label_observaciones" rows="6" placeholder="Observaciones" ></textarea>
        </div>

        <asp:HiddenField ID="curso_con_observaciones" runat="server" />
    </fieldset>
   <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="../Scripts/BotonAsistencia.js"></script>

    </form>
</body>
<script type="text/javascript">
    var PlanillaAsistencias;

    $(document).ready(function () {
        PlanillaAsistencias = new PlanillaAsistencia();
        GetCursos();
        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6');
    });

    function ImprimirPlanilla() {
        var ruta_estilos = '<%= Referencias.Css("../").Replace(Environment.NewLine, " ") %>';
        PlanillaAsistencias.imprimir_planilla(ruta_estilos);
    }
</script>
</html>
