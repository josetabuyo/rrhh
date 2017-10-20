<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InstructivoDatosPersonales.aspx.cs" Inherits="Instructivos_InstructivoDatosPersonales" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>
        <%= Referencias.Javascript("../")%>
        <style>
         ul li 
         {
             margin:10px;
         }
        
        </style>

    
</head>
<body>
<form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <div class="container-fluid">
    <h1 style="text-align:center">Actualización del Domicilio Personal</h1>
    <br />
    <p>Es FUNDAMENTAL que mantengas actualizados tus datos en tu Legajo Personal del Ministerio.</p>

    <br />
    <p><strong>1. Inicio:</strong></p>

    <ul>
        <li>Para actualizar tu Domicilio Personal, debés completar el formulario que aparece al hacer “click” en el botón “Actualizar Domicilio”.</li>
        <li>Una vez completados todos los datos, hacer “click” en el botón “Solicitar Cambio”.</li>
    </ul>

    <br />
     <p><strong>2. Generación del Formulario:</strong></p>

     <ul>
        <li>Verás que se activa la Opción “Próximo Paso: Generar PDF”. Al hacer “click” en ella se descarga en tu computadora un archivo de tipo PDF con el Formulario de Actualización de Domicilio ya completo con tus datos.</li>
    </ul>

    <br />
    <p><strong>3. Envío Electrónico del Formulario (a través de GDE): </strong></p>

    <ul>
        <li>Con el archivo PDF que se acaba de descargar en tu computadora, deberás generar un “Informe Gráfico” en el Módulo GEDO del Sistema de Gestión Documental (GDE).</li>
        <li>Al firmar digitalmente con tu usuario el “Informe Gráfico” generado, el GDE te otorgará un número de informe similar a “IF-2017-999999-APN-XXX#MDS”, que deberás reservar para el próximo paso.</li>
    </ul>

    <br />
    <p><strong>3b. Alternativa: Envío “en papel” del Formulario: </strong></p>

    <ul>
        <li>Si no poseés usuario del Sistema GDE (o éste no funciona) podés imprimir en papel el el archivo PDF que se acaba de descargar en tu computadora y firmar “a mano” el Formulario de Actualización de Domicilio.</li>
        <li>En caso de conformar el Formulario “en papel” deberás remitirlo o acercarlo al Sector Legajos de la Dirección de Administración de Personal, en el piso 21 de la Avenida Nueve de Julio 1925 (CABA) o entregarlo al Responsable de Control de Asistencia designado en tu oficina para que lo remita oportunamente.</li>
        <li>Es probable que la evaluación y aceptación del cambio por este medio pueda demorar un poco más que si lo enviás de manera electrónica a través del Sistema GDE.</li>
    </ul>

    <br />
    <p><strong>4. Informar a Recursos Humanos el número de envío: </strong></p>

    <ul>
        <li>Verás que se activa la Opción “Próximo Paso: Actualizar Nº de IF GDE”.</li>
        <li>Al hacer “click” en ella podrás copiar el Número de Informe que generaste (“IF-2017-999999-APN-XXX#MDS” sin las comillas).</li>
        <li>Al dar click en “OK” ya estará tu Solicitud disponible para su evaluación en la Dirección de Administración de Personal.</li>
        <li>Te informaremos en las alertas de la barra superior del Portal SiGIRH y a través de un mail cuando tu solicitud haya sido evaluada y aceptada.</li>
    </ul>

    </div>
    </form>
</body>

</html>
