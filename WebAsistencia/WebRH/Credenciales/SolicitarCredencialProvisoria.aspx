<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SolicitarCredencialProvisoria.aspx.cs" Inherits="Credenciales_SolicitarCredencialProvisoria" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pedido de Credencial</title>
    <link rel="stylesheet" type="text/css" href="SolicitarCredencialProvisoria.css" />
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
</head>
    <body>    
        <form id="form1" runat="server">
            <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>Datos Abiertos</span> <br/> <span style='font-size:12px;'> Administración de Usuarios </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
        <div id="formulario_solicitud">
            <h2>Pedido de Credencial</h1>
            <label for="txt_dni">DNI</label> <input id="Text1" type="text" />
            <label for="txt_apellido">Apellido</label> <input id="txt_apellido" type="text" />
            <label for="txt_nombres">Nombres</label> <input id="txt_nombres" type="text" />
            <label for="txt_email">Email</label> <input id="txt_email" type="text" />
            <label for="dtp_fechanacimiento">F. Nacimiento</label> <input id="dtp_fechanacimiento" type="text" />
            <label for="txt_telefono">Teléfono</label> <input id="txt_telefono" type="text" />
            <input id="btn_subirfoto" type="button" value = "Subir foto"/>
            <label for="cmb_tipocredencal">Tipo de Credencial</label> <select id="cmb_tipocredencal"></select>
            <label for="cmb_autorizante">Autorizante</label> <select id="cmb_autorizante"></select>
            <label for="cmb_vinculo">Vínculo</label> <select id="cmb_vinculo"></select>
            <label for="cmb_lugarentrega">Lugar de entrega</label> <select id="cmb_lugarentrega"></select>
            <input id="btn_guardar" value="Guardar" type="button"/>
        </div>
        </form>
    </body>
</html>
<script type="text/javascript" src="SolicitarCredencialProvisoria.js"></script>
