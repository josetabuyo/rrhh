<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Principal.aspx.vb" Inherits="covid_Principal" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>COVID</title>
    <style>

        .divCaja {
                width: 180px;
                height: 495px;
                display: inline-block;
                text-align: center;
                float: left;
                margin: 10px;
        }

        .cajaFondo {
            background: url(imagenes/fondo_cuadro.jpg) no-repeat;
            height: 70px;
            color: #fff;
            display: inline-block;
            padding: 10px;
            font-weight: bold;
            font-size: 18px;
        }

        .divImagen {
            display: inline-block;
            margin: 10px 0;
        }

    </style>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
</head>
<body style="background-color:#dedede;">
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Portal<br/> del Empleado</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <div >
            <div>
                <img src="imagenes/barra_superior.jpg" style="width: 100%;" />
            </div>
            <div style="margin:10px;">
                <div class="divCaja">
                    <a target="_blank" href="acta.pdf">
                        <div style="padding-bottom: 50px;  background-color: #fff; border: 1px solid;">
                            <p class="cajaFondo">ACTA CYMAT N° 02/2020</p>
                            <p style="color: #000; padding-top: 20px;">Aprobación Manual de Recomendaciones y Protocolo COVID-19</p>
                        </div>
                    </a>
                    <br />
                    <a target="_blank" href="protocolo.pdf">
                        <div style="padding-bottom: 55px; background-color: #fff; border: 1px solid;">
                            <p class="cajaFondo">PROTOCOLO COVID-19</p>
                            <p style="color: #000; padding-top: 20px;">Guía Informática con Recomendaciones Preventivas y Protocolos COVID-19</p>
                        </div>
                    </a>
                </div>
                <div class="divImagen">
                        <img src="imagenes/prevencion.jpg" width="350"  />
                </div>
                <div class="divImagen">
                    <img src="imagenes/tapaboca.jpg" width="350"  />
                </div>
                <div class="divImagen">
                    <img src="imagenes/consejos.jpg"  width="350"  />
                </div>
                <div class="divImagen">
                    <img src="imagenes/higiene.jpg" width="350"  />
                </div>
                <div class="divImagen">
                    <img src="imagenes/protocolo.jpg" width="350"  />
                </div>
            </div>
            
        </div>
    </form>
</body>
</html>
