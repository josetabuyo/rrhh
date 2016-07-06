<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatosPersonales.aspx.cs" Inherits="Portal_DatosPersonales" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>

        <style type="text/css">
        
        .caja_izq 
        {
            color:#f4efe9; 
            background:#413f40; 
            width:20%; 
            display:inline-block; 
            min-height:600px;
            float:left;
        }
        
        .caja_der 
        {
            color:#4d4b4c; 
            background:#fffdfe; 
            width:60%; 
            display:inline-block; 
            min-height:600px;
            border: 1px solid #d0d0d0;
            padding: 0px 20px 0px 20px;
        }
        
        .imagen 
        {
                width: 40%;
                height: 100px;
                background: #fff;
                display: inline-block;
                border-radius: 45px;
                margin: 20px;
        }
        
        #apellido
        {
            color: #cdc8c4;
            font-size: 1.8em;
        }
        
        #nombre 
        {
            color: #f9f4ee;
            font-size: 1.8em;
        }
        
        #cargo 
        {
            font-size: 1.1em;
        }
        
        hr 
        {
            width:80%; margin:0 auto;
        }
        
        .div_texto_caja_izq 
        {
            text-align:left; 
            margin-left:40px;
        }
        
        .h3_caja_izq 
        {
            text-align:left; 
            margin-left:30px;
            margin-bottom:15px;
        }
        
        
        
        </style>

    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:10px;">Datos Personales</h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq">
                <div class="imagen">
                
                </div>
                <div style="text-align:center;">
                    <p class=""><span id="apellido">Caíno</span> <span id="nombre">Fernando</span></p>
                    <p class=""><span id="cargo">Analista en Gestión de la información</span></p>
                </div>
                <hr  />
                <h3 class="h3_caja_izq">Mis Datos</h3>
                <div class="div_texto_caja_izq">
                   <p class=""><label>Legajo: </label><span id="legajo_consulta">123456879</span></p>
                    <p class=""><label>Documento: </label><span id="documento_consulta">31000000</span></p>
                    <p class=""><label>Edad: </label><span id="edad">31</span></p>
                    <p class=""><label>F. Nacimiento: </label><span id="fechaNacimiento">18/07/1984</span></p>
                    <p class=""><label>Sexo: </label><span id="sexo"></span>Masculino</p>
                    <p class=""><label>Estado Civil: </label><span id="estadoCivil">Soltero</span></p>
                    <p class=""><label>CUIL: </label><span id="cuil">20-20202020-5</span></p>
                </div>
                <h3 class="h3_caja_izq">Domicilio</h3>
                <div class="div_texto_caja_izq">
                    <p class=""><span id="domicilio">Avalos 1301 - Villa Pueyrredon - C.A.B.A. </span></p>
                </div>

                <h3 class="h3_caja_izq">Nivel de Estudio</h3>
                <div class="div_texto_caja_izq">
                   <p class=""><span id="estudio">Universitario</span></p>
                </div>
            </div>
            <div class="caja_der">
            <legend style="margin-top: 20px;">Cargo y Actividad</legend>
                <div>
                    <p class=""><label>Sector: </label><span id="sector"></span></p> 
                </div>
                <div>
                    <p class=""><label>Nivel y Grado: </label><span id="nivel_grado"></span></p>
                    <p class=""><label>Planta: </label><span id="planta"></span></p>
                </div>
                <div>
                    
                    <p class=""><label>Agrupamiento: </label><span id="agrupamiento"></span></p>
                </div>
                <div>
                    <p class=""><label>Ing. Min.: </label><span id="ing_min"></span></p>
                </div>  
            </div>
        </div>
    </div>
    </form>
</body>
</html>
