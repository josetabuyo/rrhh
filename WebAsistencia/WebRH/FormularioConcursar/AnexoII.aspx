<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnexoII.aspx.cs" Inherits="FormularioConcursar_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
     <%= Referencias.Css("../")%>    

     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
</head>
<body>

    <form id="form1" runat="server">
    
    <div style="width:80%; font-size:1.1em; margin-left:10%;" class="">
        <div style=" text-align:left;" class="">
            <p style="float:left;" class="">Postulación Nº: <span id="num_postulacion" ></span> </p>
            <p style="float:right;">ANEXO II</p>
            <div style="clear:both;"></div>
            <p class="encabezado" style="font-size:20px; margin-bottom:1%">DECLARACIÓN JURADA Y CONSTANCIA DE RECEPCIÓN Y ACEPTACIÓN DEL REGLAMENTO Y BASES DEL CONCURSO</p>

            <p class="">Declaro bajo juramento que:</p>
        </div>
    
        <p>a) los datos consignados en la presente Solicitud y Ficha de Inscripción son completos, verdaderos y atinentes al perfil
        del puesto de trabajo o función a concursar;</p>
        <p>b) que los certificados, fotocopias y demás documentación entregada es autentica o copia fiel de sus
        respectivos originales;</p>
        <p>c) reúno los requisitos previstos en los Artículos 4º y 5º del Anexo de la Ley Nº 25.164, y su Decreto reglamentado
        Nº 1.421/2002, y artículos concordantes del Convenio Colectivo de Trabajo General de la Administración Pública Nacional 
        (Decreto Nº 214/06), a los que acepto conocer y aceptar;</p>
        <p>d) reúno los requisitos para acceder al Agrupamiento y Nivel Escalafonario del cargo a concursar, previstos por el
        Sistema Nacional de Empleo Público (2.098/08);</p>
        <p>e) conozco y acepto los términos de la presente Resolución de la SECRETARIA DE LA GESTIÓN PÚBLICA de la JEFATURA DE
        GABINETE DE MINISTROS que aprueba este Formulario de Solicitud y Ficha de Inscripción;</p>
        <p>f) conozco y acepto las Bases del Concurso en el que solicito inscribirme, cuya copia he recibido en este acto de 
        inscripción; tomando conocimiento del cronograma y metodología de las etapas del proceso, de las materias o temáticas a
        abordar en la(s) prueba(s) y entrevista(s) fijadas o de las asignaturas del Curso de Selección si fuera aplicable, de los puntajes
        a asignar a las diversas características a considerar, con los cambios que pudiera resolver el Comité de Selección a los efectos
        de mejor preveer, y que serán comunicados con la antelación suficiente;        </p>
        <p>g) he sido notificado de la ubicación de la cartelera y de la dirección de la página WEB en la que se notificarán las diversas
        incidencias y resultados del presente proceso de selección;</p>
        <p>h) acepto que las notificaciones a que dé lugar el desarrollo del proceso en el que solicito ser inscripto puedan
        ser efectuadas en las direcciones domiciliarias y electrónicas así como del teléfono y/o fax que he comunicado en la presente
        solicitud.</p>
        <br />
        <p>Dirección electrónica: concursos@desarrollosocial.gob.ar</p>
        <p>Ubicación de la cartelera: www.desarrollosocial.gob.ar/concursos</p>


        <div class="div-pie-tabla">
            <table border="border-collapse: collapse" style="border-collapse: collapse" class="pie-tabla">
            <tr>
            <td class="td-pie-tabla"><span class="letra-bold">Fecha de Inscripción</span></td>
            <td class="td-pie-tabla"><span class="letra-bold">Firma y Aclaración del Inscripto o Apoderado</span></td>
            </tr>
            </table>
           
           <%-- <p class="p-imprimir"><button class="btn btn-primary" onclick="ImprimirCVPostulado()">Imprimir</button></p>--%>
        </div>	

        <asp:HiddenField ID="postulacion" runat="server" />

    </div>

        
    </form>
</body>
<%= Referencias.Javascript("../") %>
<script type="text/javascript" src="FichaDeclaracionJurada.js" ></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>

<script type="text/javascript">
    Backend.start();

    function ImprimirCVPostulado() {
        //var html = $('#form1').context.body.innerHTML;
        //$('#pagina').val(html);
        //window.print();
    }

    $(document).ready(function () {
        $("#num_postulacion")[0].innerHTML = $("#postulacion")[0].value;
        window.print();
    });

</script>

</html>
