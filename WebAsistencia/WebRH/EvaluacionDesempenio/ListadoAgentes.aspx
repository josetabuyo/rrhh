<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoAgentes.aspx.cs" Inherits="EvaluacionDesempenio_ListadoAgentes" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evaluación de Desempeño</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    <div class="container-fluid">
        <h1 style="text-align: center; margin: 30px;"></h1>
        <div style="margin: 0 auto;" class="row">
            <div class="caja_der papel">
            <legend style="margin-top: 20px;">AGENTES EVALUABLES</legend>
                    <div id="tablaAgentes" class="table table-striped table-bordered table-condensed"> 
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
<script type="text/javascript" src="ListadoAgentes.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {
        Backend.start(function () {
            ListadoAgentes.getEstudios();
        });
    });
</script> </html>
