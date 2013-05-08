<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaAsistenciaAlumnos.aspx.cs" Inherits="SACC_FormPlanillaAsistenciaAlumnos" %>
<%@ Register Src="~/SACC/ControlPlanillaAsistenciasAlumnos.ascx" TagName="planilla" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
        <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link rel="stylesheet" href="../Estilos/jquery-ui.css" />
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../Scripts/linq.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../Scripts/BotonAsistencia.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="DivContenedor" runat="server" style="margin:10px;">
    

    <label>Curso:&nbsp;</label>
    <select id="CmbCurso" style="width:250px;" onchange="javascript:CargarPlanilla();" runat="server">
    <option value="0">Seleccione</option>
    </select>

    <br />
    <label>Mes:&nbsp;&nbsp;&nbsp;</label>
    <select id="CmbMes" style="width:250px;" onchange="javascript:CargarPlanilla();" runat="server">
    <option value="0">Seleccione</option>
    <option value="1">Enero</option>
    <option value="2">Febrero</option>
    <option value="3">Marzo</option>
    <option value="4">Abril</option>
    <option value="5">Mayo</option>
    <option value="6">Junio</option>
    <option value="7">Julio</option>
    <option value="8">Agosto</option>
    <option value="9">Septiembre</option>
    <option value="10">Octubre</option>
    <option value="11">Noviembre</option>
    <option value="12">Diciembre</option>
    </select>
    
    <br />
    <label id="lblDocente">Docente:</label>
    <label id="Docente" runat="server">&nbsp;</label>
    <br />
    <br />
    <uc1:planilla ID="PlanillaAsistencia" runat="server" />
    </div>
    <div style="height:20px; width: 100%">
    
    <input id="BtnGuardar" style="margin-left: 10px;" class="btn btn-primary " type="submit" onclick="javascript:GuardarDetalleAsistencias();" value="Guardar" runat="server" />
    <input id="BtnImprimir" style="margin-left: 5px;" class="btn btn-primary " type="button" onclick="javascript:ImprimirPlanilla();" value="Imprimir" />
    </div>
    <asp:Button style="display:none;" ID="btn_CargarAsistencias" OnClick="CargarAsistencias" runat="server" />
    <asp:Button style="display:none;" ID="BtnSave" runat="server" Onclick="BtnSave_Click" />
    </form>
</body>
<script type="text/javascript">

    var AdministradorPlanillaMensual = function () {
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

   /* var GeneradorAsistencia = function (asistencia, dias_cursados) {
        var self = this;
        self.asistencia = asistencia;
        self.generar = function (inasistenciaalumno) {
            var contenedorAcciones = $('<div>');
            if (asistencia == "Asistencias") {
                var queryResult = Enumerable.From(inasistenciaalumno.detalle_asistencia)
                .Where(function (x) { return x.valor == 1 });
            } else {
                var queryResult = Enumerable.From(inasistenciaalumno.detalle_asistencia)
                .Where(function (x) { return x.valor == 2 });
            }

            var etiqueta;
            if (queryResult.Count() > 0) {
                etiqueta = queryResult.Count();
            }
            else {
                etiqueta = "";
            }
            contenedorAcciones.append(etiqueta);

            return contenedorAcciones;
        };
    }*/

    $(document).ready(function () {
        AdministradorPlanillaMensual();
    });

    function GuardarDetalleAsistencias() {
        var botones_asistencias = $("table input");
        var detalle_asistencias = [];
        
        for (var i = 0; i < botones_asistencias.length; i++) {
            var asistencia_btn = $(botones_asistencias[i]);
            var asistencia = {
                id_alumno: asistencia_btn.attr("id_alumno"),
                fecha: asistencia_btn.attr("dia_cursado"),
                valor: asistencia_btn.attr("valor")
            };
            detalle_asistencias.push(asistencia);
        }
        $("#PlanillaAsistencia_DetalleAsistencias").val(JSON.stringify(detalle_asistencias));
        $("#BtnSave").click();
//        return true;
    }

    function ImprimirPlanilla() {
        if ($("#CmbCurso").val() != 0 && $("#CmbMes").val() != 0) {
            window.open('PrintPlanillaAsistenciaAlumnos.aspx?' + 'idCurso=' + $("#CmbCurso").val() + '&mes=' + $("#CmbMes").val() + '&nombre_mes=' + $("#CmbMes option:selected").text() + "&nombre_curso=" + $("#CmbCurso option:selected").text()); ;
        }
    }

    function CargarPlanilla() {
        if ($("#CmbCurso").val() != 0 && $("#CmbMes").val() != 0) {
            $("#PlanillaAsistencia_CursoId").val($("#CmbCurso").val());
            $("#PlanillaAsistencia_Mes").val($("#CmbMes").val());
            $("#btn_CargarAsistencias").click();
        }
    }
</script>
</html>
