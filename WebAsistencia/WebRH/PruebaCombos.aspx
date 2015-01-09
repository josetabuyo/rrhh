<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PruebaCombos.aspx.cs" Inherits="_Default" %>

<%@ Register src="SiCoI/Componentes/AutoCompleteTextBox.ascx" tagname="AutoCompleteTextBox" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Sistema RRHH</title>
    <%= Referencias.Css("")%>
    <link rel="stylesheet" href="Scripts/select2-3.4.4/select2.css" />

</head>
<body id="bodyLogin">
    <div id="contenedor">        
          <select id="cmb_provincia"></select>
    </div>
    <%= Referencias.Javascript("") %>
    <script type="text/javascript" src="Scripts/ComboConBusquedaYAgregado.js">  </script>
    <script type="text/javascript" src="Scripts/select2-3.4.4/select2.js">  </script>
    <script type="text/javascript" src="Scripts/select2-3.4.4/select2_locale_es.js">  </script>

</body>
<script>
    $(document).ready(function () {
        cmb_provincia = new ComboConBusquedaYAgregado({
            select: $("#cmb_provincia"),
            dataProvider: "Provincias",
            campoDescripcion: "Nombre",
            placeHolder: "Seleccione una provincia"
        });
    });
</script>
</html>
