<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="FormABMCursos.aspx.cs" Inherits="SACC_FormABMCursos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ABM Cursos</title>
    <%= Referencias.Css("../")%>
    <link id="link5" rel="stylesheet" href="Estilos/EstilosSACC.css" type="text/css" runat="server" /> 
    <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="../Estilos/alertify.default.css"  />
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
</head>
<body class="marca_de_agua">
    <form id="form1" runat="server" onsubmit="return submit_value;">
        <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="panelCurso" class="div_izquierdo">
        <div class="estilo_formulario" style="width:90%; margin-left: 5%;">
        <fieldset>
           <legend class="subtitulos">Panel De Cursos</legend>
        <p>
            <asp:Label ID="lblMateria" CssClass="labels_sacc" runat="server" Text="Materia:"></asp:Label>
            <asp:DropDownList ID="cmbMateria" name="Materia" runat="server" EnableViewState="false" data-name="Materia"></asp:DropDownList >
        </p>
        <p> 
            <asp:Label ID="lblDocente" CssClass="labels_sacc" runat="server" Text="Docente:"></asp:Label>
            <asp:DropdownList ID="cmbDocente" name="Docente" runat="server" EnableViewState="false" data-name="Docente"></asp:DropdownList >
        </p>
        <p> 
            <asp:Label ID="lblEspacioFisico" CssClass="labels_sacc" runat="server" Text="Espacio Físico:"></asp:Label>
            <asp:DropdownList ID="cmbEspacioFisico" name="Docente" runat="server" EnableViewState="false" data-name="Espacio F&iacute;sico"></asp:DropdownList >
        </p>
        <p>
            <asp:Label ID="lblFechaInicio" CssClass="labels_sacc" runat="server" Text="Fecha Inicio"></asp:Label>
            <asp:TextBox ID="txtFechaInicio" CssClass="input-small" placeholder="Fecha Inicio" runat="server" MaxLength="8" data-name="Fecha de Inicio del Curso" title="Fecha de Inicio del Curso"></asp:TextBox>
            <br />
            <asp:Label ID="lblFechaFin" CssClass="labels_sacc" runat="server" Text="Fecha Fin"></asp:Label>
            <asp:TextBox ID="txtFechaFin" CssClass="input-small" placeholder="Fecha Fin" runat="server" MaxLength="8" data-name="Fecha de Fin del Curso" title="Fecha de Fin del Curso"></asp:TextBox></p>
        <p>   
            <asp:Label ID="lblHorario" CssClass="labels_sacc" runat="server" Text="Horario:"></asp:Label>
            <%--<asp:DropdownList ID="cmbDia" CssClass="input-small"  runat="server" data-name="Dia" ></asp:DropdownList>--%>
            <select id="cmbDia" class="input-small"  runat="server" data-name="Dia" style="text-transform:capitalize" ></select>
            <asp:TextBox ID="txtHoraInicio" title="Hora de inicio" CssClass="input-mini" placeholder="Hora Inicio" runat="server" MaxLength="5"  data-name="Hora de Inicio"></asp:TextBox>
            <asp:TextBox ID="txtHoraFin" title="Hora de fin" CssClass="input-mini" placeholder="Hora Fin" runat="server" MaxLength="5" data-name="Hora de Fin"></asp:TextBox>
            <select runat="server" title="Horas C&aacute;tedra" id="cmbHorasCatedra" name="HorasCatedra" enableviewstate="false" class="input-small" data-name="Cantidad de Horas C&aacute;tedra"></select>
           
            <input id="agregarHorario" type="button" value="Agregar" 
                onclick="javascript:AgregarHorario();" 
                class=" btn btn-primary boton_main_documentos" />
            <input id="cambiarHorario" type="button" value="Cambiar" onclick="javascript:CambiarHorario();" style="display:none; visibility:hidden" class=" btn btn-primary boton_main_documentos" />
        </p>
        <div id="contenedor_grilla_horario">&nbsp;</div>
        <asp:HiddenField ID="txtIdCurso" runat="server" />
        <asp:HiddenField ID="txtIdMateria" runat="server" />
        <asp:HiddenField ID="txtIdDocente" runat="server" />
        <asp:HiddenField ID="txtIdEspacioFisico" runat="server" />
        <asp:HiddenField ID="txtHorarios" runat="server" />

        <div style=" margin-left:17%; margin-top:3%;">
            <asp:Button ID="btnAgregarCurso" runat="server" Text="Agregar Curso" 
                 OnClick="btnAgregarCurso_Click" 
                class=" btn btn-primary boton_main_documentos" 
                OnClientClick="ValidarCurso();" UseSubmitBehavior="False"  />
            <asp:Button ID="btnModificarCurso" runat="server" Text="Modificar Curso" 
                class=" btn btn-primary boton_main_documentos"
                 OnClick="btnModificarCurso_Click" OnClientClick="ValidarCurso();" />
            <asp:Button  ID="btnQuitarCurso" runat="server" Text="Eliminar Curso" 
                class=" btn btn-primary boton_main_documentos" OnClick="btnQuitarCurso_Click" OnClientClick="ValidarCurso();" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" 
            class=" btn btn-primary boton_main_documentos"
            onClientClick="javascript:LimpiarCampos();" />
    </div>
     </fieldset>
        </div>
        </div>

    <div class="div_derecho">
        <div class="estilo_formulario" style="width:100%; overflow:auto;  margin-left:1%;">
        <fieldset>
        <legend class="subtitulos">Listado de Cursos</legend>
        <div id="ContenedorPlanilla" runat="server">
            <div class="input-append" style="clear:both;">   
                <div style="float:left;"><label>Cursos Vigentes: </label><input type="checkbox" id="filtrar_cursos_vigentes" /></div>
                <input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Filtrar Cursos" />    
            </div>
        </div>
        <%-- <asp:HiddenField ID="planillaJSON" runat="server" EnableViewState="true"/>--%>
        </fieldset>
        </div>
    </div>
    <asp:HiddenField ID="cursosJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="materiasJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="espacios_fisicosJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="idCursoAVer" runat="server" />
    <asp:HiddenField ID="horaCatedra" runat="server" />
     <asp:Button ID="btnVerFichaCurso" Text="" runat="server" OnClick="btnVerCurso_Click" style="display:none"/>
    </form>
    
       <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"></script>
    
    <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>


</body>

<script src="FormABMCursos.js" type="text/javascript"></script>
<script src="../Scripts/placeholder_ie.js" type="text/javascript"></script>
</html>