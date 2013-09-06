<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDetalleDeAlumno.aspx.cs" Inherits="SACC_FormDetalleDeAlumno" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link id="link1" rel="stylesheet" href="../Estilos/EstilosSeleccionDeArea.css" type="text/css" runat="server" />    
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link3" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <br />
     <br />
     <h1>Página en Construcción</h1>

    <ul id="myTab" class="nav nav-tabs">
              <li class=""><a href="#home" data-toggle="tab">Cursadas</a></li>
              <li class="active"><a href="#profile" data-toggle="tab">Asistencias</a></li>
              <li class=""><a href="#" class="dropdown-toggle" data-toggle="tab">Evaluaciones</a></li>
            </ul>

    <div class="botones_main_sicoi">
    
            <asp:Button ID="btnABMCursos" Text="Asignar Cursos" runat="server" 
                onclick="btnAsignarCursos_Click" class=" btn btn-primary boton_main_documentos" 
                Visible="false"/>
    
    </div>

    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>

    <script type="text/javascript" src="../bootstrap/js/bootstrap-tab.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-tooltip.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-popover.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-button.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-typeahead.js"></script>


    <script type="text/javascript">
        $(function () {
            $('#myTab a:last').tab('show');
            $('#myTab a[href="#profile"]').tab('show'); // Select tab by name
        })
    </script>
    </form>
</body>
</html>
