<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoAgentes.aspx.cs" Inherits="EvaluacionDesempenio_ListadoAgentes" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evaluación de Desempeño</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 30px;">
        </h1>
        <div style="margin: 0 auto;" class="row">
            <div class="caja_der papel">
                <legend style="margin-top: 20px;">AGENTES EVALUABLES</legend>
                <div id="contenedorTabla">
                    <label for="Text1">Filtrar planilla por: </label>
                    <input type="text" id="Text1" class="search buscador" style="height: 35px;" disabled placeholder="DNI, Nombre o Apellido" />
                    <label style="margin-left:20px;">  ó por ESTADO</label>
                    <select id="id_estado" style="margin-left: 10px; width: 170px;" disabled>
                        <option value="0">Todos</option>
                        <option value="1">Evaluacion Incompleta</option>
                        <option value="2">A Evaluar</option>
                        <option value="3">Muy Destacado</option>
                        <option value="4">Destacado</option>
                        <option value="5">Bueno</option>
                        <option value="6">Regular</option>
                        <option value="7">Deficiente</option>
                    </select>
                    <div id="tablaAgentes" class="table table-striped table-bordered table-condensed">
                    </div>
                </div>
            </div>
    </div>
    </div>
    <div style="display: none" id="div_niveles">
        <select id="select_niveles">
            <option value="1">GERENCIAL</option>
            <option value="2">MEDIO PROFESIONAL O TECNICO CON PERSONAL A CARGO </option>
            <option value="3">MEDIO CON PERSONAL A CARGO</option>
            <option value="4">MEDIO SIN PERSONAL A CARGO</option>
            <option value="5">OPERATIVO CON PERSONAL A CARGO</option>
            <option value="6">OPERATIVO SIN PERSONAL A CARGO</option>
        </select>
        <input type="button" id="btn_nivel" value="Aceptar">
    </div>
    </form>
</body>
<script type="text/javascript" src="ListadoAgentes.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript">
    $(document).ready(function ($) {
        Backend.start(function () {    
            ListadoAgentes.getEvaluaciones();
        });
    });
</script>
</html>
