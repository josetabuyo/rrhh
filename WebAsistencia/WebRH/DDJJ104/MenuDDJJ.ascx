<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuDDJJ.ascx.cs" Inherits="DDJJ104_MenuDDJJ" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head id="Head1" runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../") %>

    <%--<link rel="stylesheet" type="text/css" href="Style.css" />
</head>--%>
<body>
    
    <br />

    <div id="menu_areas_a_administrar" style="text-shadow: 2px 2px 5px rgba(150, 150, 150, 1);">             
        <a id="btn_generar_ddjj" class="btn btn-primary" href="FAreasConDDJJ.aspx">Generar DDJJ</a>
        <a id="btn_reimprimir_djjj" class="btn btn-primary" href="ReImprimirDDJJ.aspx">Reimprimir DDJJ</a>
        <a id="btn_consultar_ddjj" class="btn btn-primary" href="ConsultarDDJJ.aspx">Consultar DDJJ</a>
    </div>

</body>
</html>