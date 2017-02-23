<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormularioEvaluacion.aspx.cs" Inherits="EvaluacionDesempenio_FormularioEvaluacion" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evaluación de Desempeño</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <style>
.input_form 
{
    margin: 5px !important;
}
        
.plantilla_form 
{
    margin: 20px;
}

.pregunta 
{
    font-size: large;
    font-weight: bolder;
}
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />

    <div class="container-fluid">
    <div id="encabezado">
        <div id="izq" style="width:60%; float:left;">
            <h1 style="margin: 10px;">Formulario de Evaluación de Desempeño. Nivel:<span id="nivel">1. GERENCIAL</span> </h1>
            <h3 style="margin: 10px;">Nombre Evaluado: <span id="nombre_evaluado">Fernando</span></h3>
        </div>
        <div id="der" style="width:30%; float:right; border:1px solid; text-align:center; margin: 30px;">
            <h1>Puntaje</h1>
            <h1 id="puntaje">Muy Alto</h1>
        </div>
    </div>
        
        <div style="margin: 0 auto;" class="row">
            <div class="">
                <legend style="margin-top: 20px; text-align: center;">FORMULARIO EVALUACIÓN</legend>
                <div id="contenedor">
                
                </div>
                    <input id="btnGuardarFormulario" type="button" value="Guardar" class="btn btn-primary" />
                    
                    <div id="plantilla" class="plantilla_form" style="display:none; " >
                        <p class="pregunta"></p>
                        <div>
                            <p><input type="radio" name="rta1" data-opcion="1" class="input_form" /><span class="rta1"></span></p>
                            <p><input type="radio" name="rta1" data-opcion="2" class="input_form" /><span class="rta2"></span></p>
                            <p><input type="radio" name="rta1" data-opcion="3" class="input_form" /><span class="rta3"></span></p>
                            <p><input type="radio" name="rta1" data-opcion="4" class="input_form" /><span class="rta4"></span></p>
                            <p><input type="radio" name="rta1" data-opcion="5" class="input_form" /><span class="rta5"></span></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script type="text/javascript" src="ListadoAgentes.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {

        // Retrieve
        var nivel = 1;// localStorage.getItem("idNivel");
        var periodo = 1;// localStorage.getItem("idPeriodo");
        var evaluado = 1; //localStorage.getItem("idEvaluado");
        var evaluacion = 1; //localStorage.getItem("idEvaluacion");


        Backend.start(function () {
            ListadoAgentes.getFormularioDeEvaluacion(nivel, evaluacion, evaluado);
        });
    });
</script> 
</html>
