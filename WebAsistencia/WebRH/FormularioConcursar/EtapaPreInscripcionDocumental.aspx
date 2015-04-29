<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EtapaPreInscripcionDocumental.aspx.cs" Inherits="FormularioConcursar_EtapaInscripcionDocumental" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../") %>
    <link rel="stylesheet" href="EstilosPostular.css" />
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
</head>
<body>

    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar">
        <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />
            <div id="div_foliacion" class="fondo_form" style="padding: 10px;">
            <h2>Presentación de documentación</h2>
            <p>Ingrese la cantidad de documentos que el postulante entrega por cada item del CV cargado.</p>
            <p>Importante: al guardar los documentos presentados, la postulación pasará automáticamente como disponible para la etapa Inscripción Documental</p>
            <br />
            <div>
                <div style="display:inline-block; margin-left:30px; width: 50%; vertical-align:middle;">
                    <label for="txt_codigo_postulacion">Postulación:&nbsp;</label>
                    <input type="text" id="txt_codigo_postulacion" style="margin-bottom: 0px;" data-validar="esNoBlanco" />
                    <input type="button" id="btn_buscar_postulacion" value="Buscar" class="btn" />
                    <p style="font-size:smaller;">(respete may&uacute;sculas y min&uacute;sculas del c&oacute;digo)</p>
                </div>
                <div style="display:inline-block; margin-left:10px; max-width: 35%; vertical-align:middle;">
                    <div>Empleado:&nbsp;<span id="span_empleado"></span></div>
                    <div>Código:&nbsp;<span id="span_codigo"></span></div>
                    <div>Fecha de Postulación:&nbsp;<span id="span_fecha"></span></div>
                    <div>Perfil:&nbsp;<span id="span_perfil"></span></div>
                    <div>Estado:&nbsp;<span id="span_etapa"></span></div>
                </div>
            </div>
       
        <div id="requisitos_perfil"></div>

        <fieldset id="cuadro_documentos">
           
            <div id="detalle_documentos"></div>
        </fieldset>
        <input type="button" style="display:none;" class="btn btn-primary" id="btn_guardar" value="INSCRIBIR" />
        <input type="button" style="display:none;" class="btn btn-primary" id="btn_comprobantes" value="Imprimir comprobantes" />
        <input type="button" style="display:none;" class="btn btn-primary" id="btn_caratula" onclick = "ImprimirCaratula()" value="Imprimir carátula" />
       </div>
    </div>
    <asp:HiddenField ID="postulacion" runat="server" />
    <asp:HiddenField ID="idPostulacion" runat="server" />
    </form>
</body>
 <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
<script type="text/javascript" src="EtapaPreInscripcionDocumental.js" />
<%= Referencias.Javascript("../") %>

<script type="text/javascript">
    Backend.start(function () {
        $(document).ready(function () {
            var btn = $("#btn_buscar_postulacion");
            var busqueda = $("#txt_codigo_postulacion");

            //HACIENDO EL KEYDOWN EN VEZ DEL KEY UP Y CON EL PREVENT DEFAULT EL ENTER NO ACTUALIZA TODA LA PAGINA
            busqueda.keydown(function (event) {
                if (event.which == 13) {
                    btn.click();
                    event.preventDefault();
                }
            });

            EtapaPreInscripcionDocumental.mostrarPostulacion();
                               

        });

        
             


    });


    function ImprimirCaratula() {
        alertify.confirm("¿Está seguro que desea imprimir la carátula?", function (e) {
            if (e) {
                // user clicked "ok"

                // Store
                localStorage.setItem("empleado", $("#span_empleado").text());
                localStorage.setItem("perfil", $("#span_perfil").text());


                // Retrieve


//                Empleado: Fernando Raul CAINO
//                Código: AAA072
//                Fecha de Postulación: 13/1/2015
//                Perfil: Contador Público experto en Programación y Control Presupuestario
//                Estado: Preinscripción Documental



             

                window.location.href = 'Caratula.aspx';

            } else {
                // user clicked "cancel"
                //alertify.error("");
            }
        });

    }

</script>

</html>
