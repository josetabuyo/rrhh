<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepXPersona.aspx.cs" Inherits="CtrlAcc_RepXPersona" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RRHH - Control Acceso</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link href="css/select2.min.css" rel="stylesheet" type="text/css" />
    <script src="js/select2.min.js" type="text/javascript"></script>

    <style type="text/css">
        input[type="search"]
        {
            height: 30px;
        }    
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>M.A.U.</span> <br/> <span style='font-size:12px;'> Administración de Usuarios </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    <div style="padding: 1%;">
        <select id="sel2" style="width: 50%">
        </select>
        <button id="btn" type="button" class="btn btn-info">Mostrar Accesos</button>
    </div>
    </form>
</body>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#sel2').select2({
                placeholder: 'Seleccione una persona (Apellido - Nombre - DNI - Credencial)',
                ajax: {
                    url: 'Data.ashx',
                    dataType: 'json'
                }
            });            
        });
    </script>
</html>