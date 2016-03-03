<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Reportes_Reportes" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="Reportes.css" />
    <link rel="stylesheet" type="text/css" href="../Scripts/ArbolOrganigrama/ArbolOrganigrama.css" />
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="Reportes.js"></script>
    <script type="text/javascript" src="../Scripts/ArbolOrganigrama/ArbolOrganigrama.js"></script>
</head>
<body>
    <form id="Reportes" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <br />
    
    <h1 style="text-align: center; font-weight:200;">Reportes</h1>
    <div>
    <input id="btn_consulta_rapida" style="display:block;" type="button" class="btn btn-primary" RequiereFuncionalidad="32" value="Consulta Individual" />
        <div id="contenedor_arbol_organigrama">
            <h2 style="text-align: center; font-weight: 200;">Organigrama</h2>
        </div>
        <div id="panel_derecho" style="text-align:center;">
            <h2 style="text-align: center; font-weight: 200;">Módulos</h2>
            <div >
                <input id="btn_grafico_dotacion" style="display:inline-block;" type="button" class="btn btn-primary" value="Gráfico Rotación" />
                <input id="btn_grafico_licencias" style="display:inline-block;" type="button" class="btn btn-primary" value="Gráfico Licencias" />
            </div>
        </div>
    </div>
    </form>
    <div id="plantillas">
        <div class="arbol_organigrama">
        </div>
        <div class="area_en_arbol">
            <div id="btn_expandir" class="btn_apertura">
            </div>
            <div id="btn_contraer" class="btn_apertura">
            </div>
            <div id="nombre_area">
            </div>
            <div id="areas_dependientes">
            </div>
        </div>
    </div>
</body>
</html>
