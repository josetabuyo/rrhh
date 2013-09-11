<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaAsistenciaAlumnos.aspx.cs" Inherits="SACC_FormPlanillaAsistenciaAlumnos" %>
<%@ Register Src="~/SACC/ControlPlanillaAsistenciasAlumnos.ascx" TagName="planilla" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link rel="stylesheet" href="../Estilos/jquery-ui.css" />
 
     <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
     <link rel="stylesheet" href="../Estilos/alertify.default.css"  />


    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../Scripts/linq.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="Scripts/BotonAsistencia.js"></script>
    <script type="text/javascript" src="Scripts/AdministradorPlanillaAsistencias.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <style type="text/css">
    .acumuladas
    {
        font-weight:bold;
    }
    </style>

</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="DivContenedor" runat="server" style="margin:10px;">   
    <fieldset>
        <legend>Asistencias</legend>
        <label>Curso:&nbsp;</label>
        <select id="CmbCurso" style="width:400px;" runat="server" onchange="javascript:CargarPlanilla();>
            <option value="0">Seleccione</option>
        </select>
        <br />
        <label>Mes:&nbsp;&nbsp;&nbsp;</label>
        <select id="CmbMes" style="width:400px; text-transform:capitalize" 
            onchange="javascript:CargarPlanilla();" runat="server" enableviewstate="true"></select>
        <input type="hidden" runat="server" id="MesesCurso" />
        <br />
        <label id="lblDocente">Docente:</label>
        <label id="Docente" runat="server">&nbsp;</label>
        <br />
        <br />
        <label id="lblHorasCurso">Horas C&aacute;tedra:</label>
        <label id="HorasCatedraCurso" runat="server">&nbsp;</label>
        <br />
        <br />

        </div>
        <div id="ContenedorPlanillaAcumulados" runat="server" style="width:40%;">

        </div>
        <div style="height:20px; width: 100%">
        <input id="BtnGuardar" style="margin-left: 10px;" class="btn btn-primary " type="submit" onclick="javascript:GuardarDetalleAsistencias();" value="Guardar" runat="server" />
        <input id="BtnImprimir" style="margin-left: 5px;" class="btn btn-primary " type="button" onclick="javascript:ImprimirPlanilla();" value="Imprimir" />
        <br />
        <br />
        <textarea id="TxtObservaciones" style="margin-left: 5px;" class="label_observaciones" rows="6" placeholder="Observaciones" ></textarea>
        </div>

        <asp:HiddenField ID="curso_con_observaciones" runat="server" />
    </fieldset>
    </form>
</body>
<script type="text/javascript">
    var PlanillaAsistencias;
    var CargarComboMeses = function () {
        $('#CmbMes')[0].options.length = 0;
        var meses = JSON.parse($("#MesesCurso").val());
        var mes_seleccionado = $("#PlanillaAsistencia_Mes").val();
        var o = new Option("Seleccione", "0");
        $(o).html("Seleccione");
        $("#CmbMes").append(o);

        for (var i = 0; i < meses.length; i++) {
            if ($("#CmbCurso").find('option:selected').val() == meses[i].IdCurso) {
                o = new Option(meses[i].Mes, meses[i].NroMes);
                if (meses[i].NroMes == mes_seleccionado)
                    $(o).attr("selected", "selected");
                $(o).html(meses[i].Mes);
                $("#CmbMes").append(o);

            }
        }
    }

    var CargarPlanilla = function () {
        var id_curso = $("#CmbCurso option:selected").val(); ;
        var fecha_desde = "10/01/2013";
        var fecha_hasta = "15/08/2013";
        PlanillaAsistencias.cargar_asistencias(id_curso, fecha_desde, fecha_hasta);
    }

    $("#CmbCurso").change(function () {
            CargarComboMeses();
            $('#CmbMes').change();
        });

        $(document).ready(function () {
            PlanillaAsistencias = new AdministradorPlanilla();
            CargarComboMeses();
            //Estilos para ver coloreada la grilla en Internet Explorer
            $("tbody tr:even").css('background-color', '#E6E6FA');
            $("tbody tr:odd").css('background-color', '#9CB3D6 ');
        });
</script>
</html>
