<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnexoI.aspx.cs" Inherits="FormularioConcursar_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
     <%= Referencias.Css("../")%>    

     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
     <style type="text/css">
        .celda {
            border: 3px double #000;
            padding:3px;
        }
        
        .tabla_anexo_1 
        {
            font-size:1.2em;
            width:100%;
            }
     
     </style>
</head>
<body>

    <form id="form1" runat="server">
    
    <div style="width:80%; margin-left:10%;" class="">
        <div style="width: 100%; text-align:left;" class="">
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
                <td id="numero_de_oferta" colspan="2" class="celda"></td>
            </tr>
            <tr>
                <td colspan="2" class="celda">DENOMINACION DEL CARGO A CUBRIR</td>
                <td id="puesto_denominacion" colspan="2" class="celda"></td>
            </tr>
            <tr>
                <td class="celda">AGRUPAMIENTO</td>
                <td id="puesto_agrupamiento" class="celda"></td>
                <td class="celda">TIPO DE CONVOCATORIA</td>
                <td id="puesto_tipo" class="celda"></td>
            </tr>
            <tr>
                <td class="celda">NIVEL ESCALAFONARIO</td>
                <td id="nivel_escalafonario" class="celda">C</td>
                <td class="celda">NIVEL DE JEFATURA</td>
                <td id="nivel_jefatura" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">JURISDICCION/ENTIDAD DESCENTRALIZADA</td>
                <td id="jurisdiccion" colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">SECRETARIA/SUBSECRETARIA</td>
                <td id="secretaria" colspan="2" class="celda"> </td>
            </tr>
            <tr >
                <td colspan="2" class="celda">DIRECCION NACIONAL/GENERAL O EQUIVALENTE</td>
                <td id="direccion" colspan="2" class="celda"> </td>
            </tr>
            <tr >
                <td colspan="2" class="celda">DIRECCION</td>
                <td id="domicilio_lugar_de_trabajo" colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">APELLIDO Y NOMBRES DEL INSCRIPTO</td>
                <td id="apellido_y_nombre" colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">TIPO Y NUMERO DE DOCUMENTO</td>
                <td id="documento" colspan="2" class="celda"></td>
            </tr>    
            <tr >
                <td colspan="2" class="celda">DOMICILIO DE RESIDENCIA PERSONAL</td>
                <td id="domicilio_personal" colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td style="text-align:center;" colspan="4" class="celda">INFORMACION REQUERIDA PARA RECIBIR NOTIFICACIONES Y AVISOS</td>
            </tr>
            <tr >
                <td id="domicilio_legal" colspan="4" class="celda">DOMICILIO: </td>
            </tr>
            <tr >
                <td colspan="2" class="celda">TELEFONO/FAX</td>
                <td id="telefono" colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td colspan="4" class="celda">CORREO ELECTRONICO:</td>
            </tr>
            <tr>
                <td id="mail" colspan="4" class="celda"></td>
            </tr>
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

<asp:HiddenField ID="postulacion" runat="server" />
<asp:HiddenField ID="curriculum" runat="server" />
        
    </form>
</body>
<%= Referencias.Javascript("../") %>
<script type="text/javascript" src="Anexo.js" ></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>

<script type="text/javascript">
    Backend.start();

    function ImprimirCVPostulado() {
        window.print();
    }

    $(document).ready(function () {
        Anexo.armarAnexo();
        window.print();
    });

</script>

</html>
