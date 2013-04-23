<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarraMenu.ascx.cs" Inherits="FormularioDeViaticos_BarraMenu" %>

<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="link1" rel="stylesheet" href="<%= UrlEstilos %>Estilos.css" type="text/css" />
</head>

<div id= "barra_menu_contenedor">
    <div id= "barra_menu">
        <div id="barra_menu_contenedor_imagen">
            <img src="<%= UrlImagenes %>BarraMenu/encabezado_mesa_entradas.png" alt="logosistema" width="800" height="67"/>
            <div id="barra_menu_nombre_sistema">MESA DE ENTRADAS</div>
        </div>
        <div id="barra_menu_inferior">
            <div id="barra_menu_inferior_usuario">
                <div id="barra_menu_label_usuario"> USUARIO </div>
                <asp:Label ID="LabelUsuario" runat="server"></asp:Label>  
            </div>
            <div id="barra_menu_inferior_botones">
                <asp:Button ID="VolverAInicio" 
                                CssClass="barra_menu_botones"
                                runat="server" 
                                OnClick="VolverAInicioLinkButton_Click"
                                Text="Inicio" >
                </asp:Button>
                <asp:Button ID="CerrarSessionLinkButton" 
                                CssClass="barra_menu_botones"
                                runat="server"
                                OnClick="CerrarSessionLinkButton_Click" 
                                Text="Cerrar Sesión" >     
                </asp:Button>
            </div>
        </div>
    </div>
</div>