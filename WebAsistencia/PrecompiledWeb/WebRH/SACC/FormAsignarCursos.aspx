<%@ page language="C#" autoeventwireup="true" inherits="SACC_FormAsignarCursos, App_Web_c0pv0oqu" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    

    
    <div class="div_derecho">
    <label>"hola"</label>
    <%--<div id="DivContenedorDerecho" runat="server" style="margin:10px;">
        <uc1:planilla ID="GrillaDeTodosLosCursos" runat="server" />
    </div>
        <input class="btn btn-primary boton_main_documentos" type="button" onclick="$('#DivContenedorDerecho').printElement();" value="Imprimir" />--%>
    </div>

    <div class="div_izquierdo">
    
    <label>"chau"</label>
    </div>

    
    </form>
</body>

<%--<script type="text/javascript">

    var AdministradorTotalCursos = function () {
        var Planilla = JSON.parse($('#PlanillaInasistencia_planillaJSON').val());
        var DiasCursados = Planilla['diascursados'];
        var AlumnosInasistencias = Planilla['asistenciasalumnos'];
        var EncabezadoPlanilla;
        var contenedorPlanilla = $('#PlanillaInasistencia_ContenedorPlanilla');
        var columnas = [];

        columnas.push(new Columna("Apellido y Nombre", { generar:function (inasistenciaalumno) { return inasistenciaalumno.nombrealumno }}));
        columnas.push(new Columna("Pertenece a", { generar:function (inasistenciaalumno) { return inasistenciaalumno.pertenece_a }}));

        for (var i = 0; i < DiasCursados.length; i++) {

            columnas.push(new Columna(DiasCursados[i], { generar:function () { return "" }}));
        }
        columnas.push(new Columna("Asistencias", { generar:function (inasistenciaalumno) { return inasistenciaalumno.asistencias }}));
        columnas.push(new Columna("Inasistencias", { generar:function (inasistenciaalumno) { return inasistenciaalumno.inasistencias }}));
        columnas.push(new Columna("Justificadas", { generar:function (inasistenciaalumno) { return inasistenciaalumno.justificadas }}));



        var PlanillaMensual = new Grilla(columnas);


        PlanillaMensual.CargarObjetos(AlumnosInasistencias);
        PlanillaMensual.DibujarEn(contenedorPlanilla);

    }

    $(document).ready(function () {
        AdministradorPlanillaMensual();
    });
</script>--%>
</html>
