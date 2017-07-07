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
    border: 1px dotted; 
    padding: 10px;
}
.pregunta 
{
    font-size: large;
    font-weight: bolder;
    margin-bottom: 20px;
}
.pregunta-pendiente-leyenda
{
    margin-left: 20px;
    font-style: italic;     
}
.pregunta-pendiente-leyenda:before
{
   content: " (*) ";
   color: Red;
   font-weight: bold;    
}
.pregunta-pendiente::after 
{
    content: " (*) ";
    color: Red;
    font-weight: bold;
} 
#foto_usuario {
    display: inline-block;
    vertical-align: top;
    margin-top: 20px;
    display: block;
}

.bloque_foto 
{
    display: inline-block;  
    vertical-align: top;  
}

.foto_usuario {
    position: absolute;
    top: 0px;
    bottom: 0px;
    left: 0px;
    height: 128px;
    width: 128px;
    margin-left: 10px;
    border-radius: 10px;
    overflow: hidden;
}

.radioSeleccionado [class*='rta']
{
    color: #0036ff;
    font-weight: bold;
}

.div_fixed {
    background: rgba(245, 245, 245, 0.71);
    position: fixed;
    bottom: 0;
    width: 100%;
    height: 50px;
    text-align: center;
    margin: 0;
}

/*ESTILO PARA LA FLECHA DE SCROLL*/
#IrArriba {
    position: fixed;
    bottom: 30px;
    right: 30px;
}

#IrArriba span {
    width: 50px;
    height: 50px;
    display: block;
    background: url('../Imagenes/Botones/boton-subir1.png') no-repeat center center;
}

.puntaje_fixed {
    background: rgba(245, 245, 245, 0.71);
    position: fixed;
    top: 80px;
    right:50px;
}

    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />

    <div class="container-fluid">

    <div id="encabezado">
        <div id="izq" style="width:60%; float:left; position: absolute;">
            <div id="foto_usuario" class="foto_usuario" class="bloque_foto" > </div>
           <%-- <img id="img_estatica" class="foto_usuario" src="../Imagenes/silueta.gif" style="margin-top: 25px;"/>--%>
            <p style="margin: 10px; margin-left: 150px; margin-top:50px;"><label>Nivel: </label> <span id="nivel"></span> </p>
            <p style="margin: 10px; margin-left: 150px;"><label>Nombre: </label> <span id="nombre_evaluado"></span></p>
            <p style="margin: 10px; margin-left: 150px;"><label>Estado: </label> <span id="baja"></span></p>
            <p style="margin: 10px; margin-left: 150px; display:none;" ><label>Gremio: </label> <span id="cargo_gremial" ></span></p>
        </div>
        <div id="der" class="" style="width:30%; float:right; border:1px solid; text-align:center; margin: 30px;">
            <h1>Puntaje</h1>
            <h1 id="puntaje"></h1>
        </div>
    </div>
        
        <div style="margin: 0 auto;" class="row">
            <div class="">
                <legend style="margin-top: 20px; text-align: center;">FORMULARIO EVALUACIÓN</legend>
                <p class="pregunta-pendiente-leyenda">Preguntas aún sin responder<span class="total-preguntas-pendiente"></span></p>
                <p>Puntaje actual<span class="puntaje-actual"></span></p>
                <div id="contenedor">
                
                </div>
                    <div class="div_fixed">
                        <input data-estado="0" type="button" value="Guardar Borrador" class="btn btn-primary btnGuardar" />
                        <input id="btnGuardarDefinitivo" data-estado="1" type="button" value="Guardar Definitivo" class="btn btn-primary btnGuardar" />
                    </div>
                    <div id="plantilla" class="plantilla_form" style="display:none; " >
                       
                        <p class="pregunta"></p>
                        <div>
                            <p><input type="radio" data-opcion="1" class="input_form" /><label><span class="rta1"></span></label></p>
                            <p><input type="radio" data-opcion="2" class="input_form" /><label><span class="rta2"></span></label></p>
                            <p><input type="radio" data-opcion="3" class="input_form" /><label><span class="rta3"></span></label></p>
                            <p><input type="radio" data-opcion="4" class="input_form" /><label><span class="rta4"></span></label></p>
                            <p><input type="radio" data-opcion="5" class="input_form" /><label><span class="rta5"></span></label></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
     <div id='IrArriba'>
        <a href='#Arriba'><span></span></a>
    </div>
</body>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="ListadoAgentes.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {

        // Retrieve
        var nivel = localStorage.getItem("idNivel");
        var periodo = localStorage.getItem("idPeriodo");
        var evaluado = localStorage.getItem("idEvaluado");
        var evaluacion = localStorage.getItem("idEvaluacion");

        $("#IrArriba").hide();
        $(".div_fixed").hide();
        $(function () {
            $(window).scroll(function () {
                if ($(this).scrollTop() > 200) {
                    $('#IrArriba').fadeIn();
                    $(".div_fixed").fadeIn();
                } else {
                    $('#IrArriba').fadeOut();
                }
            });
            $('#IrArriba a').click(function () {
                $('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });
        });

        Backend.start(function () {
            ListadoAgentes.getFormularioDeEvaluacion(nivel, evaluacion, evaluado);
        });
    });
</script> 
</html>
