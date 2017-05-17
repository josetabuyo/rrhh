<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatosAbiertos.aspx.cs" Inherits="DatosAbiertos_DatosAbiertos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Datos Abiertos</title>
    <link rel="stylesheet" type="text/css" href="DatosAbiertos.css" />
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
</head>
    <body>
        <form id="form1" runat="server">
            <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>Datos Abiertos</span> <br/> <span style='font-size:12px;'> Administración de Usuarios </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
            <div id="pagina">
                <%--<div requierefuncionalidad="46">
                    <div id="titulo_mapa_estado">Mapa del estado</div>
                    <div id="presentacion">Desde este acceso se puede descargar en formato xls  la Planilla de Mapa del Estado (correspondiente al Ministerio de Desarrollo Social) con datos actualizados a este momento, de acuerdo a la información registrada en el SIGIRH&reg; </div>
                    <a href="#" id="btn_mapa_del_estado_xls"> 
                        <img src="xls.png" height=50px width=50px />
                        <div>Mapa del MDS</div>
                    </a>
                    <br /><br />
                </div>

                <div requierefuncionalidad="47">
                    <div id="titulo_planificacion">Planificación de Dotaciones</div>
                    <div id="presentacion_planificacion" >Desde este acceso se puede descargar en formato xls  la Planilla Contenedora del Programa de Planificación de Dotaciones con datos actualizados a este momento, de acuerdo a la información registrada en el SIGIRH&reg; </div>
                    <a href="#" id="btn_planif_dotaciones_xls"> 
                        <img src="xls.png" height=50px width=50px />
                        <div>Planilla del Programa de Planificación de Dotaciones</div>
                    </a>
                </div>--%>
            </div>
        </form>
        <div id=plantillas>
            <div class="consulta">
                <div class="titulo"></div>
                <div class="descripcion"></div>
                <a href="#" class="btn_xls"> 
                    <img src="xls.png" height=50px width=50px />
                    <div class=descripcion_boton></div>
                </a>
                <br /><br />
            </div>
        </div>
    </body>
    <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
    <script type="text/javascript" src="../Scripts/ExportarAExcel.js" ></script>
    <script type="text/javascript" src="../Scripts/Spin.js" ></script>
    <script type="text/javascript" src="DatosAbiertos.js"></script>

</html>
