<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnexoI.aspx.cs" Inherits="FormularioConcursar_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript">
         function ImprimirCVPostulado() {
             window.print();
         }
     
     </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
     <style type="text/css">
        .celda {
            border: 3px double #000;
            padding:3px;
        }
        
        .tabla_anexo_1 
        {
            font-size:1.2em;
            width:80%;
            }
     
     </style>
</head>
<body>
<a class="general atributos" style="float: right; margin: 20px; font-size:25px;" href="PanelDeControl.aspx" >Volver</a>
    <form id="form1" runat="server">
    
    <div class="contenedor_concursar">
        <div style="width: 80%; text-align:left;" class="">
            <p style="float:left;" class="">Postulación Nº: <span id="num_postulacion"></span></p>
            <p style="float:right;">ANEXO I</p>
            <div style="clear:both;"></div>
            <p class="encabezado">SISTEMA NACIONAL DE EMPLEO PUBLICO (Decreto N° 2098/08)</p>
            <p class="encabezado">FORMULARIO DE SOLICITUD Y FICHA DE INSCRIPCION N°</p>
            <p class="">Quien suscribe la presente, solicita ser inscripto para concursar el cargo cuyos datos figuran en el presente Formulario</p>
        </div>
        <table class="tabla_anexo_1">
            <tr >
                <td colspan="2" class="celda">N° DEL REGISTRO CENTRAL DE OFERTAS DE EMPLEO</td>
                <td colspan="2" class="celda">213-13214-14343-12436545</td>
            </tr>
            <tr>
                <td colspan="2" class="celda">DENOMINACION DEL CARGO A CUBRIR</td>
                <td colspan="2" class="celda">PROFESIONAL RESPONSABLE EN PROYECTOS DE ORDENAMIENTO AMBIENTAL Y CONVERSACION DE LA BIODIVERSIDAD</td>
            </tr>
            <tr>
                <td class="celda">AGRUPAMIENTO</td>
                <td class="celda">PROFESIONAL</td>
                <td class="celda">TIPO DE CONVOCATORIA</td>
                <td class="celda">ABIERTO</td>
            </tr>
            <tr>
                <td class="celda">NIVEL ESCALAFONARIO</td>
                <td class="celda">C</td>
                <td class="celda">NIVEL DE JEFATURA</td>
                <td class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">JURISDICCION/ENTIDAD DESCENTRALIZADA</td>
                <td colspan="2" class="celda">Jefatura de Gabinete de Ministros</td>
            </tr>
            <tr >
                <td colspan="2" class="celda">SECRETARIA/SUBSECRETARIA</td>
                <td colspan="2" class="celda"> </td>
            </tr>
            <tr >
                <td colspan="2" class="celda">DIRECCION NACIONAL/GENERAL O EQUIVALENTE</td>
                <td colspan="2" class="celda"> </td>
            </tr>
            <tr >
                <td colspan="2" class="celda">DIRECCION</td>
                <td colspan="2" class="celda">San Martin 451. CABA</td>
            </tr>
            <tr >
                <td colspan="2" class="celda">APELLIDO Y NOMBRES DEL INSCRIPTO</td>
                <td colspan="2" class="celda">Lorena Lopez</td>
            </tr>
            <tr >
                <td colspan="2" class="celda">TIPO Y NUMERO DE DOCUMENTO</td>
                <td colspan="2" class="celda">DNI 24999983</td>
            </tr>    
            <tr >
                <td colspan="2" class="celda">DOMICILIO DE RESIDENCIA PERSONAL</td>
                <td colspan="2" class="celda">San Martin 451. CABA</td>
            </tr>
            <tr >
                <td style="text-align:center;" colspan="4" class="celda">INFORMACION REQUERIDA PARA RECIBIR NOTIFICACIONES Y AVISOS</td>
            </tr>
            <tr >
                <td colspan="4" class="celda">DOMICILIO: San Martin 451. C(1414) CIUDAD DE BUENOS AIRES CAPITAL FEDERAL</td>
            </tr>
            <tr >
                <td colspan="2" class="celda">TELEFONO/FAX</td>
                <td colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td colspan="4" class="celda">CORREO ELECTRONICO:</td>
            </tr>
            <tr><td colspan="4" class="celda"></td></tr>
            <tr>
                <td style="text-align:center;" colspan="3" class="celda">LISTADO DE LA DOCUMENTACION PRESENTADA</td>
                <td style="text-align:center;" colspan="1" class="celda">FOLIOS</td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FICHA DE INSCRIPCION</td>
                <td colspan="1" class="celda"></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FOTOGRAFIA TIPO CARNET</td>
                <td colspan="1" class="celda"></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FOTOCOPIA DEL DNI (con domicilio actualizado)</td>
                <td colspan="1" class="celda"></td>
            </tr>
                <tr>
                <td colspan="3" class="celda">FOTOCOPIA DEL TITULO ACADEMICO EXIGIDO</td>
                <td colspan="1" class="celda"></td>
            </tr>
        </table>
    </div>

<asp:HiddenField ID="curriculum" runat="server" />
        
    </form>
</body>
<%= Referencias.Javascript("../") %>
<script type="text/javascript" src="FichaDeclaracionJurada.js" ></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>

<script type="text/javascript">
    Backend.start();

    $(document).ready(function () {
        curriculum = JSON.parse($('#curriculum').val());
        FichaDeclaracionJurada.armarFicha();
    });

</script>

</html>
