<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionAusencias.aspx.cs" Inherits="FormulariosDeLicencia_GestionAusencias" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gestion Ausencias</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <uc1:BarraMenu ID="BarraMenu1" runat="server" UrlEstilos="../Estilos/" UrlImagenes ="../Imagenes/" />
      <h1 style="text-align: center; margin: 30px;">
        </h1>
        <div class="">
            <div id="ausencias" style="width: 95%; margin: 0 auto;">
                <legend id="legend_gestion" style="margin-top: 10px;">Ausencias Sin Justificar</legend>
                <input type="text" id="search" class="search buscador" placeholder="Buscar" style="height:35px;" />
                <div id="tablaAusencias" class="table table-striped table-bordered table-condensed">
                </div>
                
            
            </div>
        </div>
    </form>
</body>
<script type="text/javascript" src="../Componentes/justificarAusencia.htm"></script>
<script type="text/javascript" src="GestionDeAusencias.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript">
    $(document).ready(function ($) {
        Backend.start(function () {
            GestionDeAusencias.getAusencias();
        });
    });
</script>
</html>
