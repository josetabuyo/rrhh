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
            <p>Busque la postulación por su número. Cuando la encuentre, podrá imprimir una caratula y pasar al estado Inscripto Documental.</p>
            <p>Importante: al presionar inscribir, saldra una ventana para completar la cantidad de folios presentados. Una vez completados, persione inscribir para pasar de etapa y generar el anexo para su impresión</p>
            <br />
            <div>
                <div style="display:inline-block; margin-left:30px; width: 50%; vertical-align:middle;">
                    <label for="txt_codigo_postulacion">Postulación:&nbsp;</label>
                    <input type="text" id="txt_codigo_postulacion" style="margin-bottom: 0px;" data-validar="esNoBlanco" />
                    <input type="button" id="btn_buscar_postulacion" value="Buscar" class="btn" />
                    <p style="font-size:smaller;">(respete may&uacute;sculas y min&uacute;sculas del c&oacute;digo)</p>
                </div>
                <div style="display:inline-block; margin-left:10px; max-width: 35%; vertical-align:middle;">
                    <div><b>Empleado:&nbsp;</b><span id="span_empleado"></span>. DNI: <span id="span_dni_postulante"></span></div>
                    <div><b>Código:&nbsp;</b><span id="span_codigo"></span></div>
                    <div><b>Números de Informes GDE:&nbsp;</b><span id="span_gde"></span></div>
                    <div><b>Fecha de Postulación:&nbsp;</b><span id="span_fecha"></span></div>
                    <div><b>Perfil:&nbsp;</b><span id="span_perfil"></span></div>
                    <div><b>Estado:&nbsp;</b><span id="span_etapa"></span></div>
                </div>
            </div>
       
        <div id="requisitos_perfil"></div>

        <fieldset id="cuadro_documentos">
           
            <div id="detalle_documentos"></div>
        </fieldset>

        <div id="contenedorInformesGDE" style="display:none;">
            <table style="text-align: center;">
                <thead>
                    <tr><th style="padding: 0 10px;">N° Informe</th><th style="padding: 0 10px;">Aceptar</th><th style="padding: 0 10px;">Rechazar</th></tr>
                </thead>
                <tbody id="cuerpoTablaInformes">
                </tbody>
            </table>
            <div style="margin-top: 50px;">
                <p class="subtitulo_incripcion">Agregar nuevos INFORMES GRÁFICOS</p>
                <div id="cajaDeInformesGraficos" style="display: inline;">
                    <input class="informesGraficos" placeholder="N° Informe" type="text" id="informeGrafico_00" />
                </div>
                <span style="cursor:pointer; color:#337ab7;" id="btnActualizarInformes" >Agregar</span>
                <%--<input type="button" class="btn" onclick="agregarInforme()" value="Agregar otro INFORME" />--%>
                <%--<input type="button" class="btn btn-primary" id="btnActualizarInformes" value="Actualizar Informes" />--%>
            </div>
            <input type="checkbox" id="checkValidacionInformes" /> He validado todo los informes
        </div>
        <input type="button" style="display:none;" class="btn btn-primary" id="btn_guardar" value="INSCRIBIR" />
       <input type="button" style="display:none;" class="btn btn-primary" id="btn_comprobantes" visible="false" value="IMPRIMIR ANEXO III" />
        <%--<input type="button" style="display:none;" class="btn btn-primary" id="btn_caratula" onclick = "ImprimirCaratula()" value="Imprimir carátula" />--%>
       </div>
    </div>
    <asp:HiddenField ID="postulacion" runat="server" />
    <asp:HiddenField ID="idPostulacion" runat="server" />
    <asp:HiddenField ID="idPostulante" runat="server" />
   

    <div id = "somediv"  style="width:400px; height:300px;"></div>

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


    $('#btn_guardar').click(function () {

        var codigo = $("#span_codigo").text();
        var fecha = $("#span_fecha").text();
       

        //alert(codigo);
          localStorage.setItem("codigo_postu", codigo);
          localStorage.setItem("fecha", fecha);
          localStorage.setItem("idPostulante", idPostulante);

             

      //  $("#somediv").load("PanelDetalleDeFoliosAnexo.htm").dialog({ modal: true,resizable: false,title: 'Documentación', width: 360 }); 

    });


    function ImprimirAnexo3Modificado() {

        alertify.confirm("","¿Está seguro que desea imprimir el anexo de documentación?", function () {
                /*localStorage.setItem("empleado", $("#span_empleado").text());
                localStorage.setItem("dni", $("#span_dni_postulante").text());
                localStorage.setItem("idPostulante", $("#idPostulante").val());

                window.showModalDialog("PanelDetalleDeFoliosAnexo.htm", "", "dialogHeight: " + 150 + "px;");*/
          //      window.location.href = 'AnexoIIICantHojas.aspx';

            }, function() {

            }
        );
    
    
    }


    function ImprimirCaratula() {
        alertify.confirm("", "¿Está seguro que desea imprimir la carátula?", function () {              
                localStorage.setItem("empleado", $("#span_empleado").text());
                localStorage.setItem("perfil", $("#span_perfil").text());
                localStorage.setItem("codigo_postu", $("#span_codigo").text());

                window.open('Caratula.aspx', '_blank');
                //window.location.href = 'Caratula.aspx';

            }, 
            function () { 
               
            }
        );

        }

//        var nextinput = 0;
//        function agregarInforme() {
//            nextinput++;
//            campo = '<input class="informesGraficos" placeholder="N° Informe" type="text" id="informeGrafico_0' + nextinput + '" />';
//            $("#cajaDeInformesGraficos").append(campo);
//        }

</script>

</html>
