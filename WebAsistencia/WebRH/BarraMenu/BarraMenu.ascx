<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarraMenu.ascx.cs" Inherits="FormularioDeViaticos_BarraMenu" %>
<%@ Register Src="FormPassword.ascx" TagName="FormPassword" TagPrefix="uc5" %>
<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="link1" rel="stylesheet" href="<%= UrlEstilos %>EstilosBarraMenu.css" type="text/css" />
    <link id="link2" rel="stylesheet" href="<%= UrlEstilos %>BarraMenuUsuarios.css" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script type="text/javascript" src="../BarraMenu/BarraMenu.js"></script>
    <script type="text/javascript" src="../BarraMenu/BotonDesplegable.js"></script>
    <script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
    <script type="text/javascript" src="../Scripts/ControlesImagenes/SubidorDeImagenes.js"></script>
    <%= Referencias.Javascript("../")%>
</head>
<div id="barra_menu_contenedor" class="no-print">
    <div id="contenedor_imagen">
        <div id="barra_menu_contenedor_imagen">
            <img src="<%= UrlImagenes %>logo_sistema.png" id="img_logo_sistema" alt="logosistema" />
            <img src="<%= UrlImagenes %>logo_ministerio.png" id="img_logo_minis" alt="logosistema" />
            <img src="<%= UrlImagenes %>logo_direccion.png" id="img_logo_direccion" alt="logosistema" />
            <div id="barra_menu_nombre_sistema">
            </div>
        </div>
    </div>
    <div id="barra_navegacion">
        <div id="barra_azul">
        </div>
        <div id="boton_home">
            <img src="<%= UrlImagenes %>Home-icono.png" id="home_imagen" alt="homeicono" />
        </div>
        <div id="contenedor_imagen_usuario">
            <img src="<%= UrlImagenes %>portal/portal_empleado.png" id="foto_usuario_icono" alt="fotouser" />
        </div>
        <div id="contenedor_menu_usuarios" class="menu_usuario sombrita" style="display: none;">
            <div class="flechita">
            </div>
            <div id="contenedor_foto_usuario">
                <div id="foto_usuario_menu" class="foto_menu_estilo">
                
                </div>
                <div id="barrita_cambio_imagen">
                    <div>Cambiar</div>
                    <div>Imágen</div>                  
                </div>
            </div>
            
            <img id="foto_usuario_generica" src="<%= UrlImagenes %>portal/portal_empleado.png"
                alt="fotousuariogenerica" class="foto_menu_estilo" />
            <div id="nombre_user" class="cabecera_menu_usuario">
            </div>
            <div id="apellido_user" class="cabecera_menu_usuario">
            </div>
            <div id="dni_user" class="cabecera_menu_usuario">
            </div>
            <div id="email_user" class="cabecera_menu_usuario">
            </div>
            <div id="info_usuario">
                <button id="cambiar-email_usuario" type="button" class="btn barra_menu_botones sombrita-iconos">
                    Modificar correo</button>
                <%--<button id="cambiar-constrasena_usuario" type="button" class="btn btn-info datos_usuario">
                        Modificar contraseña </button>--%>
                <a id="go" rel="leanModal" class="btn barra_menu_botones sombrita-iconos" name="signup"
                    href="#signup">Cambiar Contraseña</a>
                <uc5:FormPassword ID="FormPassword" runat="server" />
                <div id="cerrar-sesion_usuario">
                    <asp:Button ID="CerrarSessionLinkButton" CssClass="barra_menu_botones sombrita-iconos"
                        runat="server" OnClick="CerrarSessionLinkButton_Click" Text="Cerrar Sesión">
                    </asp:Button>
                </div>
            </div>
        </div>
        <div id="contenedor_imagen_cuadrados" class="sombrita-iconos">
            <img src="<%= UrlImagenes %>cuadraditos.png" id="menu_cuadrados" alt="fotousuariomenu" />
        </div>
        <div id="contenedor_menu_cuadrados" class="menu_usuario sombrita" style="display: none;">
            <div class="flechita">
            </div>
        </div>
        <!--mensajes-->
        <div id="contenedor_imagen_mensajes">
          <div id="notificacion_punto_verde">
          <img id="check" src="../Imagenes/BarraMenu/check.png"></img>
                </div>
            <div id="notificacion_punto_rojo">
                </div>
            <img src="<%= UrlImagenes %>mensajes-icono.png" id="menu_mensajes" alt="fotousuariomenu" />
        </div>
        <div id="contenedor_menu_mensajes" class="menu_usuario sombrita-iconos" style="display: none;">
            <div class="flechita">
            </div>
            <div class="contenedor_de_alertas_y_mensajes">
            </div>
        </div>
        <%--<div id="contenedor_barraInferior">
        <div id="barra_menu_inferior">
            <div id="barra_menu_inferior_usuario">
                <div id="barra_menu_label_usuario">
                    USUARIO
                </div>
                <asp:Label ID="LabelUsuario" runat="server"></asp:Label>
            </div>

             <div id="barra_menu_inferior_botones">
                <asp:Button ID="VolverAInicio" CssClass="barra_menu_botones" runat="server" OnClick="VolverAInicioLinkButton_Click"
                    Text="Inicio"></asp:Button>
                <a id="go" rel="leanModal" class="btn barra_menu_botones" name="signup" href="#signup">
                    Cambiar Contraseña</a>
                <asp:Button ID="CerrarSessionLinkButton" CssClass="barra_menu_botones" runat="server"
                    OnClick="CerrarSessionLinkButton_Click" Text="Cerrar Sesión"></asp:Button>
                </div>
            <uc5:FormPassword ID="FormPassword" runat="server" />
        </div>
    </div>--%>
        <div id="plantillas" style="display: none">
            <div class="ui_mensaje_alerta mensaje_alerta sombra-mensaje">
                <p class="titulo_mensaje_alerta">
                    Mensaje 1</p>
                <p class="contenido_mensaje_alerta">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam mi nunc, euismod
                    eget est nec, consequat porttitor est. Maecenas ante elit, bibendum in volutpat
                    sit amet, imperdiet ac neque. Quisque dapibus eros sit amet mauris venenatis molestie.
                    Integer feugiat felis dolor, pellentesque tincidunt nulla efficitur quis. Pellentesque
                    pretium velit id neque accumsan, vitae aliquam augue mollis. Fusce ut diam malesuada,
                    placerat tortor et, efficitur massa. Praesent sagittis tortor et enim accumsan laoreet.
                    Praesent ut sapien ac leo porta finibus eget vitae lacus. Aliquam at arcu felis.
                    Morbi sit amet consectetur ex. Maecenas in nisi turpis.</p>
            </div>
        </div>
    </div>
