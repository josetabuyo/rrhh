<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormularioEvaluacion.aspx.cs" Inherits="EvaluacionDesempenio_FormularioEvaluacion" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evaluación de Desempeño</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />

    <div class="container-fluid">
        <h1 style="text-align: center; margin: 30px;"></h1>
        <div style="margin: 0 auto;" class="row">
            <div class="caja_der papel">
                <legend style="margin-top: 20px;">FORMULARIO EVALUACIÓN</legend>
                <div id="contenedor">
                
                </div>
                    
                    
                    <div id="plantilla" style="display:none;" >
                        <p class="pregunta"></p>
                        <div>
                            <p><input type="checkbox" name="rta1" /><span class="rta1"></span></p>
                            <p><input type="checkbox" name="rta1" /><span class="rta2"></span></p>
                            <p><input type="checkbox" name="rta1" /><span class="rta3"></span></p>
                            <p><input type="checkbox" name="rta1" /><span class="rta4"></span></p>
                            <p><input type="checkbox" name="rta1" /><span class="rta5"></span></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
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
