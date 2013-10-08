<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintPlanillaAsistenciaAlumnos.aspx.cs" Inherits="SACC_PrintPlanillaAsistenciaAlumnos" %>
<%@ Register Src="~/SACC/ControlPlanillaAsistenciasAlumnos.ascx" TagName="planilla" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            width:98%;
            height:98%;
        }
        #DivContenedor
        {
            margin:100px 20px 100px 200px;
        
        }
    
    </style>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <link id="link3" rel="stylesheet" href="../Estilos/Estilos.css"
        type="text/css" runat="server" />
    <link id="link4" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../Scripts/linq.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>  
    <script type="text/javascript" src="Scripts/BotonAsistencia.js"></script>
    <script type="text/javascript" src="Scripts/AdministradorPlanillaAsistencias.js"></script>
    <style type="text/css">
    .acumuladas
    {
        font-weight:bold;
    }
    </style>

</head>
<body onload="/*javascript:window.print();window.close();*/">
    <form id="form1" runat="server">
        <div id="DivContenedor" runat="server" style="margin:10px;">
            <label>Curso:&nbsp;</label>
            <label id="Curso" runat="server">&nbsp;</label>
            <input type="hidden" id="CmbCurso" runat="server" />
            <br />
            <label>Mes:&nbsp;&nbsp;&nbsp;</label>
            <label id="Mes" runat="server">&nbsp;</label>
            <br />
            <label>Docente:</label>
            <label id="Docente" runat="server">&nbsp;</label>
            <label id="lblHorasCurso">Horas C&aacute;tedra:</label>
            <label id="HorasCatedraCurso" runat="server">&nbsp;</label>
            <br />
            <br />
            <div id="ContenedorPlanilla" runat="server" style="display:inline-block;">
        
            </div>
            <br />
            <label>Observaciones:</label>
            <label id="Observaciones" runat="server">&nbsp;</label>
        </div>
    </form>
</body>
<script type="text/javascript">
    $(document).ready(function () {
        //
        PlanillaAsistencias = new AdministradorPlanilla();
        CargarPlanilla();

        $("input").css("border", "none");
        $("input").css("background", "none");
    });
</script>
</html>
