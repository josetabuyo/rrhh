<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InscripcionAlumnosACursos.aspx.cs" Inherits="SACC_InscripcionAlumnosACursos" %>
Inherits="FormularioDetalleDeViaticos_FDetalleDeViaticos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asignaciones</title>
   <%= Referencias.Css("../")%>
    <link id="link3" rel="stylesheet" href="Estilos/EstilosSACC.css" type="text/css" runat="server" /> 

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

         <asp:HiddenField ID="ListaAreas" runat="server" />
          <asp:HiddenField ID="AreaSeleccionada" runat="server" />
    
    </div>
    </form>
</body>

    <%= Referencias.Javascript("../") %>

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
