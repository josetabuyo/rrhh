<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarraMenu.ascx.cs" Inherits="FormularioDeViaticos_BarraMenu" %>

<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="link1" rel="stylesheet" href="<%= UrlEstilos %>Estilos.css" type="text/css" />
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
</head>

    <div id="Barra_menu" onload="MM_preloadImages('<%= UrlImagenes %>Botones/Botones Nuevos/ayuda_s2.png','<%= UrlImagenes %>Botones/Botones Nuevos/inicio_s2.png','<%= UrlImagenes %>Botones/Botones Nuevos/cerrar_s2.png','<%= UrlImagenes %>Botones/Botones Gestion/modificar_s2.png','<%= UrlImagenes %>Botones/Botones Gestion/imprimir_s2.png','<%= UrlImagenes %>Botones/Botones Gestion/enviar_s2.png')">
        <div class="barra_menu_fondo">
            <div class= "barra_menu_contenedor">
                <div>
                    <img src="<%= UrlImagenes %>logo_sistema.png" alt="logosistema" width="120" height="36" class="barra_menu_logo_sistema" />
                    <div class="barra_menu_contenedor_logos_derecha">
                        <img src="<%= UrlImagenes %>logo_direccion.png" alt="logodireccion" width="120" height="24" />
                        <img src="<%= UrlImagenes %>logo_ministerio.png" alt="logoministerio" width="170" height="31" class="barra_menu_logo_ministerio" />
                    </div>
                </div>
                <div class="barra_menu_bloque_inferior">
                    <div class="barra_menu_label_bienvenido"> BIENVENIDO </div>
                    <asp:Label ID="LabelUsuario" class="barra_menu_label_usuario" runat="server">Texto Varible(User Name)</asp:Label>    
                    <div class="barra_menu_botones_menu_usuario">
                        <asp:LinkButton ID="CerrarSessionLinkButton" 
                                    runat="server" 
                                    OnClick="CerrarSessionLinkButton_Click" 
                                    onmouseout="MM_swapImgRestore()" 
                                    onmouseover="MM_swapImage('cerrar','','<%= UrlImagenes %>Botones/Botones Nuevos/cerrar_s2.png',1)">
                            <img src="<%= UrlImagenes %>Botones/Botones Nuevos/cerrar.png" width="75" height="16" class="barra_menu_boton_menu_usuario" id="Img1" />                
                        </asp:LinkButton>
                        <asp:LinkButton ID="VolverAInicio" 
                                    runat="server" 
                                    OnClick="VolverAInicioLinkButton_Click" 
                                    onmouseout="MM_swapImgRestore()" 
                                    onmouseover="MM_swapImage('inicio','','<%= UrlImagenes %>Botones/Botones Nuevos/inicio_s2.png',1)">
                            <img src="<%= UrlImagenes %>Botones/Botones Nuevos/inicio.png" width="36" height="17" class="barra_menu_boton_menu_usuario" id="Img2" />
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
