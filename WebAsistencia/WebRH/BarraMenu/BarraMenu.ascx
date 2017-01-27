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
</head>
<div id="barra_menu_contenedor" class="no-print">
    <div id="contenedor_imagen">
        <div id="barra_menu_contenedor_imagen">
            <% if (Feature != "")
               {%>
            <img src="<%= UrlImagenes %>BarraMenu/encabezado_sin_logos.png" height="69px;" width="1024px;"
                alt="logosistema" />
            <%}%>
            <img src="<%= UrlImagenes %>logo_sistema.png" id="img_logo_sistema" width="130px"
                height="39px" alt="logosistema" />
            <img src="<%= UrlImagenes %>logo_ministerio.png" id="img_logo_minis" style="float: left;"
                width="150px" height="27px" alt="logosistema" />
            <img src="<%= UrlImagenes %>logo_direccion.png" id="img_logo_direccion" width="130px"
                height="26px" alt="logosistema" />
            <div id="barra_menu_nombre_sistema">
                <%= Feature %></div>
        </div>
    </div>
    <div id="barra_navegacion">
        <div id="barra_azul">
        </div>
        <div id="boton_home">
            <img src="<%= UrlImagenes %>Home-icono.png" id="home_imagen" alt="homeicono" />
        </div>
        <div id="contenedor_imagen_usuario">
            <img src="<%= UrlImagenes %>portal/portal_empleado.png" id="foto_usuario" alt="fotouser" />
        </div>
        <div id="contenedor_menu_usuarios" class="menu_usuario">
            <div id="contenedor_foto_usuario_del_menu">
                <img src="<%= UrlImagenes %>portal/portal_empleado.png" id="foto_usuario_menu" alt="fotousuariomenu" />
            </div>

            <div id="nombre_user" class="cabecera_menu_usuario">
                         </div>

            <div id="apellido_user" class="cabecera_menu_usuario">
                         </div>

            <div id="dni_user" class="cabecera_menu_usuario">
                         </div>
            
            <div id="email_user" class="cabecera_menu_usuario">
                           </div>

            <div id="info_usuario">
                <button id="cambiar-email_usuario" type="button" class="btn btn-info datos_usuario">
                    Modificar correo</button>
                <button id="cambiar-constrasena_usuario" type="button" class="btn btn-info datos_usuario">
                    Modificar contraseña</button>
                    <div id="cerrar-sesion_usuario">
                <asp:Button ID="CerrarSessionLinkButton" CssClass="barra_menu_botones" runat="server"
                    OnClick="CerrarSessionLinkButton_Click" Text="Cerrar Sesión"></asp:Button>
                    </div>
            </div>
        </div>
        <div id="contenedor_imagen_cuadrados">
            <img src="<%= UrlImagenes %>cuadraditos.png" id="menu_cuadrados" alt="fotousuariomenu" />
        </div>
        <div id="contenedor_menu_cuadrados" class="menu_usuario">

            <a  href="../SACC/Inicio.aspx">
                <img class="borde-circular" src="../MenuPrincipal/macc.png"></a>
            <a href="../SACC/Inicio.aspx">
            <img class="borde-circular" src="../MenuPrincipal/mau.png">
            </a>
            <a href="../SACC/Inicio.aspx">
            <img class="borde-circular" src="../MenuPrincipal/mobi.png">
            </a>
              <a href="../MODI/Modi.aspx">
            <img class="borde-circular" src="../MenuPrincipal/modi.png">
                </a>
                <a href="../SACC/Inicio.aspx">
            <img class="borde-circular" src="../MenuPrincipal/Postular.png">
             </a>

              <a href="../SACC/Inicio.aspx">
            <img class="borde-circular"  src="../MenuPrincipal/Reportes.png">
            </a>
            <a href="../SACC/Inicio.aspx">
            <img class="borde-circular" src="../MenuPrincipal/Formularios.png">
            </a>
            <a  href="../SeleccionDeArea.aspx">
            <img class="borde-circular" src="../MenuPrincipal/Administración_de_Areas.png">
             </a>
        </div>
        <div id="contenedor_imagen_mensajes">
            <img src="<%= UrlImagenes %>mensajes-icono.png" id="menu_mensajes" alt="fotousuariomenu" />
        </div>
        <div id="contenedor_menu_mensajes" class="menu_usuario">
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
</div>
