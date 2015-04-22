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
            font-size:1.1em;
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
            <p class="encabezado" style="font-size:20px; margin-bottom:1%">SISTEMA NACIONAL DE EMPLEO PUBLICO (Decreto N° 2098/08)</p>
            <p class="encabezado"style="font-size:20px; margin-bottom:1%">FORMULARIO DE SOLICITUD Y FICHA DE INSCRIPCION N°</p>
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
                <td id="nivel_escalafonario" class="celda"></td>
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
                <td id="correo_electronico" colspan="4" class="celda">CORREO ELECTRONICO:</td>
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
            <tr>
                <td colspan="3" class="celda">CURRICULUM VITAE OPCIONAL</td>
                <td colspan="1" class="celda"></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">DOCUMENTACIÓN DE RESPALDO</td>
                <td colspan="1" class="celda"></td>
            </tr>
        </table>
    </div>

    <div class="info-gral posicion fondo_form">
	<p class="titulos"><span class="letra-bold">I.</span> Información Personal</p>
	<p class="nombre-h"><span id="cv_apellido" class="atributo-apelido"></span><span id="cv_nombre"></span></p>
    <br>
	<p class="general_info_personal"><span class="atributos">DNI: </span><span id="cv_dni"></span></p>
	<p class="general_info_personal"><span class="atributos">Estado Civil: </span><span id="cv_estadoCivil"></span></p>
	<p class="general_info_personal"><span class="atributos">Fecha de Nacimiento: </span><span id="cv_fechNac"></span></p>
	<p class="general_info_personal"><span class="atributos">Lugar de Nacimiento: </span><span id="cv_lugarNac"></span></p>
	<p class="general_info_personal"><span class="atributos">Nacionalidad: </span><span id="cv_nac"></span></p>
	<p class="general_info_personal"><span class="atributos">Domicilio Personal: </span><span id="cv_domPersonal"></span></p>
	
	
</div>

<div class="info-notif-avisos posicion fondo_form">
	<p class="titulos "><span class="letra-bold">II.</span> Información Requerida para Recibir Notificaciones y Avisos</p>
	<p class="general_info_personal"><span class="atributos">Domicilio: </span><span id="cv_domLegal"></span></p>
	<p class="general_info_personal"><span class="atributos">Teléfonos: </span><span id="cv_telefono"></span></p>
	<p class="general_info_personal"><span class="atributos">Corro Electrónico: </span><span id="cv_mail"></span></p>
	</div>

    <div id="caja_antecedentes_academicos"  style="page-break-before:always" ></div>
    <div id="caja_actividades_decentes"  style="page-break-before:always"></div>
    <div id="caja_eventos_academicos"  style="page-break-before:always"></div>
    <div id="caja_publicaciones"  style="page-break-before:always"></div>
    <div id="caja_matriculas"  style="page-break-before:always"></div>
    <div id="caja_instituciones"  style="page-break-before:always" ></div>
    <div id="caja_experiencias_laborales"  style="page-break-before:always"></div>
    <div id="caja_otras_aptitudes" style="page-break-before:always" ></div>

<asp:HiddenField ID="postulacion" runat="server" />
<asp:HiddenField ID="curriculum" runat="server" />
        
    </form>
</body>
<%= Referencias.Javascript("../") %>
<script type="text/javascript" src="Anexo.js" ></script>
<script type="text/javascript" src="curriculum.js" ></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>

<script type="text/javascript">
    //Backend.start();

    function ImprimirCVPostulado() {
        window.print();
    }
    Backend.start(function () {
        $(document).ready(function () {
            Anexo.armarAnexo();
            window.print();
        });
    });

</script>

</html>
