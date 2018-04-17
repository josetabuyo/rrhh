<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LegajosDeBaja.aspx.cs" Inherits="Reportes_LegajosDeBaja" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta Legajos de Baja</title>
    <%= Referencias.Css("../")%>           
    <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
<script type="text/javascript" src="../Scripts/underscore-min.js"></script>
<script type="text/javascript" >
    $(document).ready(function ($) {
        Backend.start(function () {
            Reportes.iniciarConsultaRapida();
        });
    });
    
</script> 

</html>
