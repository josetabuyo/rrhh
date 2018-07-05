<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SolicitarCredencialProvisoria.aspx.cs" Inherits="Credenciales_SolicitarCredencialProvisoria" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pedido de Credencial</title>
    <link rel="stylesheet" type="text/css" href="SolicitarCredencialProvisoria.css" />
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>


    <style type="text/css">
      
      .componenteCambioDomicilio 
      {
          padding-left: 15px;
      }
      
      .textCambioDomicilio 
      {
          height: 21px !important;
      }
      
      .fieldsetCambioDomicilio 
      {
            background-color: rgba(218, 218, 218, 0.31);
            border-radius: 15px;
            padding: 10px;
            text-align:center;
           float: left; 
          
           margin-right: 1em; 
           text-align: right; 
           width: 400px;
  margin:auto;
  
      margin-left: 40%;
           
      }
        
    </style>

</head>
    <body>    
        <form id="form1" runat="server">
            <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>Datos Abiertos</span> <br/> <span style='font-size:12px;'> Administración de Usuarios </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
        <div id="formulario_solicitud" >
            <h2  style="text-align:center">Pedido de Credencial - Personal Externo</h2>

            <fieldset class="fieldsetCambioDomicilio">

         <%--   <label for="txt_dni" class="componenteCambioDomicilio">DNI</label> <input id="Text1" type="text" />--%>
              <p class="componenteCambioDomicilio">DNI: <input id="Text2" maxlength="12" type="text" class="textCambioDomicilio" /></p>
          <%--  <label for="txt_apellido">Apellido</label> <input id="txt_apellido" type="text" />--%>
            <p class="componenteCambioDomicilio">Apellido:  <input id="txt_apellido" type="text" maxlength="30" class="textCambioDomicilio" /></p>
            <p class="componenteCambioDomicilio">Nombres: <input id="txt_nombres" type="text"  maxlength="30" class="textCambioDomicilio" /></p>
            <p class="componenteCambioDomicilio">Email: <input id="txt_email" type="text" maxlength="60" class="textCambioDomicilio"/></p>
            <p class="componenteCambioDomicilio">Fecha de Nacimiento: <input id="dtp_fechanacimiento" type="text" maxlength="10" class="textCambioDomicilio" /></p>
            <p class="componenteCambioDomicilio">Teléfono: <input id="txt_telefono" type="text" maxlength="20" class="textCambioDomicilio" /></p>
            <p class="componenteCambioDomicilio">Autorizante: <input id="txt_autorizante" type="text" maxlength="30" class="textCambioDomicilio" /></p>
            <input id="btn_subirfoto" type="button" style="display:block;margin:auto;" value = "Subir foto"/>
            <br>
            <p class="componenteCambioDomicilio">Tipo de Credencial: <select id="cmb_tipocredencal"></select>
          
            <p class="componenteCambioDomicilio">Vínculo: <select id="cmb_vinculo" ></select>
            <p class="componenteCambioDomicilio">Lugar de entrega: <select id="cmb_lugarentrega"></select> </p>
            <input id="btn_guardar" value="Guardar" type="button" style="display:block;margin:auto;"/>

            </fieldset>

        </div>
        </form>
    </body>
</html>
<script type="text/javascript" src="SolicitarCredencialProvisoria.js"></script>
