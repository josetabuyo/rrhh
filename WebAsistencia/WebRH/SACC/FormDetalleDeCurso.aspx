<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormDetalleDeCurso.aspx.cs" Inherits="SACC_FormDetalleDeCurso" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <link id="link1" rel="stylesheet" href="../Estilos/EstilosSeleccionDeArea.css" type="text/css" runat="server" />    
    <link id="link5" rel="stylesheet" href="Estilos/EstilosSACC.css" type="text/css" runat="server" /> 
</head>
<body>
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    
    <div class="botones_main_sicoi">
            <asp:Button ID="btnABMCursos" Text="Asignar Alumnos" runat="server" 
                onclick="btnAsignarAlumnos_Click" class=" btn btn-primary boton_main_documentos" 
                Visible="True"/>
    
    </div>
    </form>
</body>
</html>
