<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InstructivoInformeGDE.aspx.cs" Inherits="Portal_InstructivoInformeGDE" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>
        <%= Referencias.Javascript("../")%>
    
    <style>
    
    body {
        font-family: "Helvetica Neue",Helvetica,Arial,sans-serif;
        font-size: 14px;
        line-height: 1.42857143;
        color: #333;
        background-color: #fff;
    }
    
    </style>
</head>
<body>
<form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <div class="container-fluid">
    <h1>Instructivo para Solicitar Cambio de Domicilio en el SIGIRH</h1>

    <p>Para la Solicitar el Cambio de Domicilio deberás tener, ademas del  usuario del SIGIRH, un usuario y contraseña en el Sistema de Gestión Documental Electrónica (GDE). Para consultar por la generación de usuarios, podés escribir a ayuda.gde@desarrollosocial.gob.ar o comunicarte al (011) 4379-3902 / 3903.</p>

    <p>En caso de que no hayas realizado la actividad de capacitación acerca del Sistema GDE podés solicitar una vacante completando el siguiente <a href="https://docs.google.com/forms/d/e/1FAIpQLSdOIfc7xEYJCCUmxhL-Vop0y3iOQp92WN7XSFZXDmiGlfT48w/viewform" target="_blank">Formulario de Pre – Inscripción</a></p>

    <p>Los pasos a seguir son los siguientes:</p>
    <ul>
        <li>Generar un pedido desde el portal del SIGIRH</li>
        <li>Generar el PDF del pedido del paso anterior.</li>
        <li>El archivo PDF es el que se carga en el sistema GDE confeccionando un “Informe Gráfico” dentro del Módulo GEDO del citado sistema GDE.</li>
        <li>Al firmar digitalmente con tu usuario el “Informe Gráfico” generado en el punto anterior, el GDE te otorgará un número de informe similar al siguiente “IF-2017-9999999-APN-xxx#MDS” este número deberás copiarlo y actualizarlo en la solicitud del SIGIRH.</li>
        <li>Una vez generado actualizado el informe GDE, debes esperar a que los responsables de RRHH lo acepten y/o rechazen, según corresponda</li>
        <li>Te llegara un mail y un alerta en el SIGIRH informandote del resultado del tramite</li>
    </ul>
    </div>
    </form>
</body>
</html>