<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaDeEvaluaciones.aspx.cs" Inherits="SACC_FormPlanillaDeEvaluaciones" %>
<%@ Register Src="~/SACC/ControlPlanillaEvaluaciones.ascx" TagName="planilla" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Planilla De Evaluaciones</title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <link rel="stylesheet" href="../Estilos/jquery-ui.css" />
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../Scripts/linq.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="DivContenedor" runat="server" style="margin:10px;">
        <label>Curso:&nbsp;</label>
        <select id="CmbCurso" onchange="javascript:CargarPlanilla();" runat="server">
            <option value="0">Seleccione</option>
        </select>
    <div>
    <uc1:planilla ID="PlanillaEvaluaciones" runat="server" />
    </div>
    </div>
    <asp:Button style="display:none;" ID="btn_CargarEvaluaciones" OnClick="CargarEvaluaciones" runat="server" />
    </form>
</body>
<script type="text/javascript">

    var AdministradorPlanillaEvaluaciones = function () {
        if ($('#PlanillaAsistencia_planillaJSON').val() != "{}" && $('#PlanillaAsistencia_planillaJSON').val() != "") {

            var Planilla = JSON.parse($('#PlanillaAsistencia_planillaJSON').val());

            var DiasCursados = Planilla['diascursados'];
            var AlumnosInasistencias = Planilla['asistenciasalumnos'];
            var contenedorPlanilla = $('#PlanillaAsistencia_ContenedorPlanilla');
            var columnas = [];

            columnas.push(new Columna("Apellido y Nombre", { generar: function (inasistenciaalumno) { return inasistenciaalumno.nombrealumno } }));
            if (DiasCursados) {
                for (var i = 0; i < DiasCursados.length; i++) {
                    columnas.push(new Columna(DiasCursados[i].nombre_dia + "/" + DiasCursados[i].dia + "<br/>" + DiasCursados[i].horas + " hs",
                                        new GeneradorCeldaDiaCursado(DiasCursados[i])));
                }
            }
            columnas.push(new Columna("Asistencias", { generar: function (inasistenciaalumno) { return inasistenciaalumno.asistencias } }));
            columnas.push(new Columna("Inasistencias", { generar: function (inasistenciaalumno) { return inasistenciaalumno.inasistencias } }));

            var PlanillaMensual = new Grilla(columnas);

            PlanillaMensual.CargarObjetos(AlumnosInasistencias);
            PlanillaMensual.DibujarEn(contenedorPlanilla);
            PlanillaMensual.SetOnRowClickEventHandler(function () {
                return true;
            });
            var Docente = JSON.parse($("#PlanillaAsistencia_Curso").val()).Docente;

            $("#Docente").text(Docente.Nombre + " " + Docente.Apellido);
        }
        else {
            $("#lblDocente").css("visibility", "hidden");
            $("#BtnGuardar").css("visibility", "hidden");
            $("#BtnImprimir").css("visibility", "hidden");
        }
    };

    function CargarPlanilla() {
        if ($("#CmbCurso").val() != 0 && $("#CmbMes").val() != 0) {
            $("#PlanillaAsistencia_CursoId").val($("#CmbCurso").val());
            $("#PlanillaAsistencia_Mes").val($("#CmbMes").val());
            $("#btn_CargarAsistencias").click();
        }
    }

    $(document).ready(function () {
        AdministradorPlanillaEvaluaciones();
    });

</script>
</html>
