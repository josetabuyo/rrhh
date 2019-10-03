<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="ciot_Principal" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
 
    <link rel="stylesheet" href="css/bootstrap.css" type="text/css" />
    <link rel="stylesheet" href="css/estilos.css" type="text/css" />

    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>CIOT</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css"/>   
    <%= Referencias.Javascript("../")%>

</head>



<body>

    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu1" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    </form>

    <%--<div><img src="imagenes/header1200.png" width="100%" height="250px" /></div>--%>
    <div style="text-align:center;"><h1>Comisión de igualdad de oportunidades y trato (CIOT) </h1></div>

    <div class="divContenedorIconos">

        <div class="grupo_icono">
            <a href="Que_es_Ciot.aspx">
                <p><img src="imagenes/icono1.1.png" width="50" /></p><a>
                    <a href="Que_es_Ciot.aspx">Qué es CIOT<a>
        </div>

        <div class="grupo_icono">
            <a href="Que_es_Violencia.aspx"><p><img src="imagenes/icono1.2.png" width="50" /></p></a>
            <a href="Que_es_Violencia.aspx">Qué es la violencia laboral</a>
        </div>

        <div class="grupo_icono">
            <a href="Que_es_Igualdad.aspx"><p><img src="imagenes/icono1.3.png" width="50" /></p></a>
            <a href="Que_es_Igualdad.aspx">Qué es la igualdad de oportunidades y trato</a>
        </div>

    </div>

        <div class="divContenedorDestacados" style="background-color:#cccccc4a; padding: 60px; text-align:center">

        <h2 style="margin: 0; margin-bottom: 10px;">Servicios</h2>

        <div style="vertical-align: top;">

            <a href="Denuncia_Violencia_Laboral.aspx" class="grupo_servicio">
                <img src="imagenes/icono2.1.png" width="200" />
                <div>
                    <p style="font-size:small"><strong>Denunciá violencia Laboral</strong></p>
                    <p style="font-size:small" class="textoCuadros">Podés tramitar tu denuncia de forma rápida y simple</p>
                </div>
            </a>

            <a href="Nuestra_Delegacion.aspx" class="grupo_servicio">
                <img src="imagenes/icono2.2.png" width="200" />
                <div>
                    <p style="font-size:small"><strong>Nuestra delegación</strong></p>
                    <p style="font-size:small" class="textoCuadros">Conocé a los integrantes de la Ciot.</p>
                </div>
            </a>

            <a href="Manual_de_Procedimiento.aspx" class="grupo_servicio">
                <img src="imagenes/icono2.3.png" width="200" />
                <div>
                    <p style="font-size:medium"><strong>Manual de Procedimiento</strong></p>
                    <p class="textoCuadros">Enterate más sobre la conformación y funcionamiento</p>
                </div>
            </a>

            <a href="Ejes_de_Trabajo.aspx" class="grupo_servicio">
                <img src="imagenes/icono2.4.png" width="200" />
                <div>
                    <p style="font-size:small"><strong>Ejes de trabajo</strong></p>
                    <p style="font-size:small" class="textoCuadros">Conocé cómo trabajamos sobre igualdad de género.</p>
                </div>
            </a>
        </div>


        <h2 style="margin: 50px 0 10px 0;">Destacados</h2>

        <div style="vertical-align: top;">

            <a href="Que_Pensamos.aspx" class="grupo_servicio">
                <img src="imagenes/icono3.1.png" width="200" />
                <div class="divDestacados">
                    <p style="font-size:small"><strong>¿Qué es y cómo detectar la violencia laboral?</strong></p>
                    <p style="font-size:small" class="textoCuadros">Enterate más para prevenir y denunciar el maltrato ante la Comisión de Igualdad de Oportunidades y de Trato (CIOT).</p>
                </div>
            </a>

            <a href="Capacitaciones.aspx" class="grupo_servicio">
                <img src="imagenes/icono3.2.png" width="200" />
                <div class="divDestacados">
                    <p style="font-size:small"><strong>Nueva Diplomatura en Asistencia a Mujeres en Situación de Violencia </strong></p>
                    <p style="font-size:small" class="textoCuadros">Es virtual y brinda herramientas para incorporar la perspectiva de género tanto en el quehacer laboral como para interpelar prácticas interpersonales.</p>
                </div>
            </a>

            <a href="Maltrato_Laboral.aspx" class="grupo_servicio">
                <img src="imagenes/icono3.3.png" width="200" />
                <div class="divDestacados">
                    <p style="font-size:small"><strong>El Ciber-acoso como nueva forma de violencia laboral</strong></p>
                    <p style="font-size:small" class="textoCuadros">Conocé cómo se presenta el maltrato en las redes sociales, websites y en algunos dispositivos.</p>
                </div>
            </a>

            <a href="Comunicacion.aspx" class="grupo_servicio">
                <img src="imagenes/icono3.4.png" width="200" />
                <div class="divDestacados">
                    <p style="font-size:small"><strong>Comunicación y empatía</strong></p>
                    <p style="font-size:small" class="textoCuadros">La clave está en saber lo que sienten los demás y poder vivir sus emociones.</p>
                </div>
            </a>

        </div>

    </div>


     <footer>

        <a href="#">
            <img src="imagenes/logo.png" />
        </a>

        <hr />

        <h3>CONTACTO</h3>
        <p><strong>Dirección:</strong> Av. 9 de Julio 1925 - Ciudad Autónoma de Buenos Aires</p>
        <p><strong>Código Postal:</strong> C1073ABA</p>
        <p><strong>Teléfono:</strong> 0800-222-3294</p>
        <p><strong>Correo Electrónoco:</strong> ciot_delegacion@desarrollosocial.gob.ar</p>


    </footer>


</body>
</html>
