<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cambioDomicilio.aspx.cs" Inherits="Portal_cambioDomicilio" %>

<div>
<h1>Cambio Domicilio</h1>

<p>Domicilio para Cambiar</p>

<p>Calle <% Response.Write(Request.Form[1].ToString()); %> </p>
<p>Numero <% Response.Write(Request.Form[2].ToString()); %> </p>
<p>Piso <% Response.Write(Request.Form[3].ToString()); %> </p>
<p>Depto <% Response.Write(Request.Form[4].ToString()); %> </p>
<p>Localidad <% Response.Write(Request.Form[5].ToString()); %> </p>
<p>Provincia <% Response.Write(Request.Form[6].ToString()); %> </p>



</div>
