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
    <style type="text/css">
    .acumuladas
    {
        font-weight:bold;
    }
    </style>

</head>
<body onload="javascript:window.print();window.close();">
    <form id="form1" runat="server">
        <div id="DivContenedor" runat="server" style="margin:10px;">
            <label>Curso:&nbsp;</label>
            <label id="Curso" runat="server">&nbsp;</label>
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
            <uc1:planilla ID="PlanillaAsistencia" runat="server" />
            <br />
            <label>Observaciones:</label>
            <label id="Observaciones" runat="server">&nbsp;</label>
        </div>
    </form>
</body>
<script type="text/javascript">

    var AdministradorPlanillaMensual = function () {

        var Planilla = JSON.parse($('#PlanillaAsistencia_planillaJSON').val());
        var DiasCursados = Planilla['diascursados'];
        var AlumnosInasistencias = Planilla['asistenciasalumnos'];
        var contenedorPlanilla = $('#PlanillaAsistencia_ContenedorPlanilla');
        var HorasCatedraCurso = Planilla['horas_catedra'];
        var columnas = [];

        columnas.push(new Columna("Apellido y Nombre", { generar: function (inasistenciaalumno) { return inasistenciaalumno.nombrealumno } }));
        //columnas.push(new Columna("Pertenece a", { generar: function (inasistenciaalumno) { return inasistenciaalumno.pertenece_a } }));

        for (var i = 0; i < DiasCursados.length; i++) {
            columnas.push(new Columna(DiasCursados[i].nombre_dia + "/" + DiasCursados[i].dia + "<br/>" + DiasCursados[i].horas + " hs",
                                        new GeneradorCeldaDiaCursado(DiasCursados[i])));
        }
        columnas.push(new Columna("Asistencias <br>del mes", { generar: function (inasistenciaalumno) { return inasistenciaalumno.asistencias } }));
        columnas.push(new Columna("Inasistencias <br>del mes", { generar: function (inasistenciaalumno) { return inasistenciaalumno.inasistencias } }));
        columnas.push(new Columna("Asistencias <br>acumuladas", { generar: function (inasistenciaalumno) { return '<label class="acumuladas">' + inasistenciaalumno.asistencias_acumuladas + " (" + inasistenciaalumno.por_asistencias_acumuladas + ")</label>" } }));
        columnas.push(new Columna("Inasistencias <br>acumuladas", { generar: function (inasistenciaalumno) { return '<label class="acumuladas">' + inasistenciaalumno.inasistencias_acumuladas + " (" + inasistenciaalumno.por_inasistencias_acumuladas + ")</label>" } }));
         


        var PlanillaMensual = new Grilla(columnas);


        PlanillaMensual.CargarObjetos(AlumnosInasistencias);
        PlanillaMensual.DibujarEn(contenedorPlanilla);
        PlanillaMensual.SetOnRowClickEventHandler(function () {
            return true;
        });

        var Docente = JSON.parse($("#PlanillaAsistencia_Curso").val()).Docente;
        $("#Docente").text(Docente.Nombre + " " + Docente.Apellido);
        $("#HorasCatedraCurso").text(HorasCatedraCurso);

        var Observaciones = JSON.parse($("#PlanillaAsistencia_Curso").val()).Observaciones;
        $("#Observaciones").text(Observaciones);
    };

    var GeneradorCeldaDiaCursado = function (diaCursado) {
        var self = this;
        self.diaCursado = diaCursado;
        self.generar = function (inasistenciaalumno) {
            var contenedorAcciones = $('<div>');
            var queryResult = Enumerable.From(inasistenciaalumno.detalle_asistencia)
                .Where(function (x) { return x.fecha == diaCursado.fecha });

            var botonAsistencia;
            if (queryResult.Count() > 0) {
                botonAsistencia = new CrearBotonAsistencia(inasistenciaalumno.id, diaCursado.fecha, queryResult.First().valor, diaCursado.horas);
            }
            else {
                botonAsistencia = new CrearBotonAsistencia(inasistenciaalumno.id, diaCursado.fecha, 0, diaCursado.horas);
            }
            contenedorAcciones.append(botonAsistencia);

            return contenedorAcciones;
        };
    }

    $(document).ready(function () {
        AdministradorPlanillaMensual();
        $("input").css("border", "none");
        $("input").css("background", "none");
    });
</script>
</html>
