<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FormAsignarAlumnos.aspx.cs" Inherits="SACC_FormAsignarAlumnos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <%= Referencias.Css("../")%>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
</head>

<body class="marca_de_agua" >
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
        
        <div style="margin:20px;">
        
        <fieldset>
            <legend class="subtitulos">Elija ciclo y curso:</legend>
            <p>
            <asp:Label ID="lblCiclo"  runat="server" style="padding-right:5px;"  Text="Ciclo:"></asp:Label>
                <asp:DropDownList ID="cmbCiclo" runat="server"  EnableViewState="false" 
                    Width="400px">
                    <asp:ListItem Value="-1" class="placeholder" Selected="true">Ciclo</asp:ListItem>
                </asp:DropDownList>    
            </p>
            
            <p>
            <asp:Label ID="lblCursos"  runat="server"  Text="Curso:"></asp:Label>
                <asp:DropDownList ID="cmbCursos" runat="server" EnableViewState="false" 
                    Width="400px">
                    <asp:ListItem Value="0" class="placeholder" Selected="true">Cursos</asp:ListItem>
                </asp:DropDownList>  
                <input type="checkbox" id="filtrar_cursos_vigentes" />    <label>Vigentes </label>
            </p>
            
        </fieldset>
        
        </div>
        <div class="btn_inscripcion_SACC">
            <label id="descripcionCursoSeleccionado"></label> 
        </div>

    <div id="panelAlumnoDisponibles" style="margin-left:20px" class="div_izquierdo_inscripcion">
    <div class="estilo_formulario" style="width:75%; margin-left: 10%; overflow:auto;">
    <fieldset>
        <legend class="subtitulos">Listado de Alumnos Para Inscribir</legend>
        <div style="float:left; width:100%;" class="tablas_alumnos" id="grillaAlumnosDisponibles" runat="server">
            <div class="input-append">   
                <input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Buscar Alumnos" />    
            </div>
        </div>
    </fieldset>
    </div>
    </div>
    <div style="margin-top:200px;float: left; padding:0 30px; width: 2%;">

        <p><img alt="" src="../Imagenes/Botones/Botones SACC/flecha_der.png"   height="40"  id="Img1" /></p>
        <p><img alt="" src="../Imagenes/Botones/Botones SACC/flecha_izq.png"  height="40"  id="Img2" /></p>             
        <p><label id="mensaje" ></label></p>
        
        <input id="BtnGuardar" style="margin-left: -10px;" class="btn btn-primary " type="button" value="Inscribir" runat="server" />
        <%--<asp:Button ID="btnGrabar" Text="Guardar Inscriptos" runat="server" OnClick="btnGrabarAsignacion_Click" class=" btn btn-primary boton_main_documentos" Visible="true"/> --%>
    </div>


    <div id="panelAlumnosAsignados" class="div_derecho_inscripcion">
    <div class="estilo_formulario" style="width:95%; overflow:auto;  margin-left:1%;">
    <fieldset>
        <legend class="subtitulos">Listado de Alumnos Asignados al Curso de <span id="nombreDeCurso"></span></legend> 
        <div class="tablas_alumnos" style="width:85% !important; margin-left: 9% !important; overflow: auto;" id="grillaAlumnosAsignados" runat="server"></div>      
    </fieldset>

    </div>
    </div>

    <asp:HiddenField ID="cursosJSON" runat="server" />
    <asp:HiddenField ID="idCursoSeleccionado" runat="server" />
    <asp:HiddenField ID="alumnosJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="idAlumnoAVer" runat="server" />
    <asp:HiddenField ID="alumnosEnGrillaParaGuardar" runat="server" />
        <script type="text/javascript" src="Scripts/InscripcionAlumnos.js"></script>
    <%= Referencias.Javascript("../") %>

    </form>
</body>

<script type="text/javascript">

    var AdministradorPlanilla = function () {

        var items_pantalla = {
            alumnos: JSON.parse($('#alumnosJSON').val()),
            alumnoGlobal: $("<div>"),
            planillaAlumnosDisponibles: $("<div>"),
            planillaAlumnosAsignados: $("<div>"),
            panelAlumnoDisponibles: $("#panelAlumnoDisponibles"),
            panelAlumnoAsignados: $("#panelAlumnosAsignados"),
            contenedorAlumnosDisponibles: $('#grillaAlumnosDisponibles'),
            contenedorAlumnosAsignados: $('#grillaAlumnosAsignados'),
            cmbCursos: $("#cmbCursos"),
            cmbCiclo: $("#cmbCiclo"),
            cursosJSON: JSON.parse($('#cursosJSON').val()),
            idCursoSeleccionado: $("#idCursoSeleccionado"),
            alumnosEnGrillaParaInscribir: $("#alumnosEnGrillaParaGuardar"),
            mensaje: $("#mensaje"),
            botonAsignarAlumno: $("#Img1"),
            botonDesAsignarAlumno: $("#Img2"),
            botonGuardarInscriptos: $("#BtnGuardar"),
            checkCurso: $("#filtrar_cursos_vigentes")
        }

        var modulo_inscripcion = new PaginaInscripcionAlumnos(items_pantalla);

        var options = {
            valueNames: ['Documento', 'Nombre', 'Apellido', 'Modalidad']
        };

        var featureListAlumnosDisponibles = new List('grillaAlumnosDisponibles', options);
    };

    $(document).ready(function () {
        AdministradorPlanilla();

        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');
    });

</script>
</html>
