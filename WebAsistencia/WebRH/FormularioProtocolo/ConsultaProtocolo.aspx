<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaProtocolo.aspx.cs" Inherits="FormularioProtocolo_ConsultaProtocolo" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioProtocolo/GrillaProtocolo.ascx" TagName="GrillaProtocolo" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Formulario Protocolo</title>
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" />
    <link id="link3" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link5" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" /> 
    
</head>

<body onload="MM_preloadImages('Imagenes/Botones/gestiontramites_s2.png','Imagenes/Botones/administrar_s2.png','Imagenes/Botones/solicitar_modificacion_s2.png','Imagenes/Botones/Botones Nuevos/ayuda_s2.png','Imagenes/Botones/Botones Nuevos/inicio_s2.png','Imagenes/Botones/cerrarsesion_s2.png','Imagenes/Botones/consprotocolo_s2.png')">

<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlEstilos="../Estilos/" UrlImagenes="../Imagenes/" />
<div class= "contenedor_principal">
    		<div class= "contenedor_separador"> 
        	  <div class= "imagen_separador"> 
                <img src="../Imagenes/separador_protocolo.png" width="340" height="54" alt="separador_protocolo" />
		      </div>
            </div>

<%--NO BORRAR--%>
<%--    Se comenta el Filtro y la Búsqueda porque la misma se encuentra incompleto 
    y por el momento se decidió mostrar toda la tabla completa sin posibilidad de filtrado--%>


     <div class= "contenedor_buscador">
               
<%--                <div class= "combo_buscador">

              <%-- <asp:DropDownList ID="DDLIdBusqueda" runat="server">
                    <asp:ListItem Value="1">Área/s</asp:ListItem>
                    <asp:ListItem Value="2">Responsable/s</asp:ListItem>
                    <asp:ListItem Value="3">Asistente/s</asp:ListItem>
                    <asp:ListItem Value="4">Teléfono</asp:ListItem>
                    <asp:ListItem Value="5">Fax</asp:ListItem>
                    <asp:ListItem Value="6">E-Mail</asp:ListItem>
                    <asp:ListItem Value="7">Dirección</asp:ListItem>
                </asp:DropDownList>--%>
<%--               </div>
               --%>
              <%-- <div class= "filtro_buscador">
               <input name="" type="text" />
               </div>--%>
               
<%--               <div class= "contenedor_imagen_buscar">--%>

<%--    Se comenta el Filtro y la Búsqueda porque la misma se encuentra incompleto 
    y por el momento se decidió mostrar toda la tabla completa sin posibilidad de filtrado--%>

                           <%--<asp:LinkButton ID="BotonBuscar" name="buscar" runat="server"
                            onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('buscar','','../Imagenes/Botones/buscar_s2.png',1)"
                            OnClick="Buscar_Click" 
                            EnableViewState="False">
                <asp:Image id="ImagenBotonBuscar" runat="server" ImageUrl="../Imagenes/Botones/buscar.png" name="buscar" width="56" height="22" border="0" />
            </asp:LinkButton>--%>



<%--<a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('buscar','','../Imagenes/Botones/buscar_s2.png',1)"><img src="../Imagenes/Botones/buscar.png" name="buscar" width="56" height="22" border="0" id="buscar" /></a>--%>
<%--	  </div>--%>
               
            </div>

            <div class="tabla_protocolo">
            <uc1:GrillaProtocolo ID="GrillaProtocolo" runat="server" />
            </div>

    </div>
    </form>
</body>
</html>
