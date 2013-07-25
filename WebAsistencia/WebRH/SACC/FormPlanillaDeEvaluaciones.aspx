<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaDeEvaluaciones.aspx.cs" Inherits="SACC_FormPlanillaDeEvaluaciones" %>
<%@ Register Src="~/SACC/ControlPlanillaEvaluaciones.ascx" TagName="planilla" TagPrefix="uc1" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Planilla De Evaluaciones</title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link rel="stylesheet" href="../Estilos/jquery-ui.css" />
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../Scripts/linq.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="planilla_ingreso.js"></script>
    <style>
    .date_picker {
        width: 80px;
    }
    .cmb_calificacion
    {
        width: 50px;
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="DivContenedor" runat="server" class="div_izquierdo" style="margin:10px;">
        <label>Curso:&nbsp;</label>
        <select id="CmbCurso" onchange="javascript:cargar_instancias(this.value);" runat="server">
            <option value="0">Seleccione</option>
        </select><br />
        <label>Instancia:&nbsp;</label>
        <select id="CmbInstancia" onchange="javascript:admin_planilla.cargarPlanilla();" runat="server">
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
    var admin_planilla;
    function cargar_instancias(id_curso) {
        var data_post = JSON.stringify({
            'id_curso': id_curso
        });
        
        $.ajax({
            url: "../AjaxWS.asmx/GetInstanciasDeEvaluacion",
            type: "POST",
            data: data_post,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                var respuesta = JSON.parse(respuestaJson.d);
                var combo_instancias = $("#CmbInstancia");
                combo_instancias.html("");
                combo_instancias.append(new Option("Seleccione", 0));
                for (var i = 0; i < respuesta.length; i++) {
                    combo_instancias.append($(new Option(respuesta[i].Descripcion, respuesta[i].Id)).attr("id_curso", id_curso));
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    
    }

    var AdministradorDeEvaluaciones = function () {
        var _this = this;
        _this.cargarPlanilla = function (id_curso) {
            var data_post = JSON.stringify({
                'id_curso': $("#CmbCurso").val()
            });
            $.ajax({
                url: "../AjaxWS.asmx/GetPlanillaEvaluaciones",
                type: "POST",
                data: data_post,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (respuestaJson) {
                    var respuesta = JSON.parse(respuestaJson.d);
                    if (respuesta.MensajeError === "") {
                        _this.dibujarGrilla(respuesta);
                    }
                    else {
                        alert(respuesta.MensajeError);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        };
        _this.guardarPlanilla = function (planilla) {
            alert("Guardar Planilla");
        };
        _this.dibujarGrilla = function (planilla) {

            var pla = new Planilla(planilla);
            var columnas = []
            var contenedor_grilla = $("#PlanillaEvaluaciones_ContenedorPlanilla");
            columnas.push(new Columna("Nombre", { generar: function (fila) { return fila.alumno; } }));
            columnas.push(new Columna("Calificación", { generar: function (fila) { return fila.calificacion; } }));
            columnas.push(new Columna(pla.instancias.html(0), { generar: function (fila) { return fila.fecha; } }));

            var grilla = new Grilla(columnas);
            grilla.CargarObjetos(pla.grilla());
            contenedor_grilla.html("");
            grilla.DibujarEn(contenedor_grilla);

            $(".fecha_evaluacion").change(function (fecha) {
                if (!$(this).val())
                    this.val(fecha);
            });

            $("#btn").click(function () {
                $(".fecha_evaluacion").val($(".fecha_instancia").val());
            });


        }
    }
    $(document).ready(function () {
        admin_planilla = new AdministradorDeEvaluaciones();
    });
</script>
</html>
