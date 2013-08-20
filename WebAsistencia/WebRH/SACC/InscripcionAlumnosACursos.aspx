<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InscripcionAlumnosACursos.aspx.cs" Inherits="SACC_InscripcionAlumnosACursos" %>
Inherits="FormularioDetalleDeViaticos_FDetalleDeViaticos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asignaciones</title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" />
    <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="../Estilos/alertify.default.css"  />

</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
         <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />

    <div id="DivContenedor" runat="server" style="margin:10px;">

                <asp:DropDownList ID="cmbSeleccion" runat="server" enableviewstate="true">
                    <asp:ListItem Value="0" class="placeholder" Selected="true">Buscar Por:</asp:ListItem>
                </asp:DropDownList>
                <input id="selectorAlumnosyCursos" class="detalle_viatico_transicion_combo" type="text" data-provide="typeahead" data-items="9" runat="server" onclick="return selectorAlumnosyCursos_onclick()" />
                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-primary detalle_viatico_transicion_boton" onclick="btnBuscar_Click"/>
                 <%--<div class="detalle_viatico_contenedor_transicion_combo_boton">
            
           
                     
        </div>--%>

         <asp:HiddenField ID="ListaAreas" runat="server" />
          <asp:HiddenField ID="AreaSeleccionada" runat="server" />
    
    </div>
    </form>
</body>

<script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
<script type="text/javascript" src="../Scripts/jquery.printElement.min.js"></script>
<script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
<%--<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>--%>
<script type="text/javascript" src="../bootstrap/js/bootstrap-transition.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-alert.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-modal.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-tab.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-tooltip.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-popover.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-button.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-typeahead.js"></script>
<script type="text/javascript" src="../Scripts/alertify.js"></script>

<script type="text/javascript">
    $('#selectorAlumnosyCursos').attr('data-source', $('#<%= ListaAreas.ClientID %>').val());
    $('#selectorAlumnosyCursos').attr("autocomplete", "off");
    $('#SelectorDeAreas').blur(function () {
        $('#<%= AreaSeleccionada.ClientID %>').val($('#selectorAlumnosyCursos').data().typeahead.$menu.find('.active').data().item.value);
    });


    function selectorAlumnosyCursos_onclick() {

    }

</script>

</html>
