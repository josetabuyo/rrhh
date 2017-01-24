<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarraMenu.ascx.cs" Inherits="FormularioDeViaticos_BarraMenu" %>
<%@ Register Src="FormPassword.ascx" TagName="FormPassword" TagPrefix="uc5" %>
<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="link1" rel="stylesheet" href="<%= UrlEstilos %>EstilosBarraMenu.css" type="text/css" />
    <link id="link2" rel="stylesheet" href="<%= UrlEstilos %>BarraMenuUsuarios.css" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
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
    <div id="barra_azul">
    </div>
    <img src="<%= UrlImagenes %>portal/portal_empleado.png" id="foto_usuario" alt="fotouser" />
    <div id="menu_usuario">
        <div id="contenedor_foto_usuario_del_menu">
            <img src="<%= UrlImagenes %>portal/portal_empleado.png" id="foto_usuario_menu" alt="fotousuariomenu" />
        </div>
          <div id="nombre_user" class="cabecera_menu_usuario">
                Matías Julián 
            </div>
              <div id="apellido_user" class="cabecera_menu_usuario">
                Sáenz Tejeira
            </div>
            <div id="dni_user" class="cabecera_menu_usuario" >
                31.937.582
            </div>
            <div id="email_user" class="cabecera_menu_usuario">
               msaenz@desarrollosocial.gob.ar
            </div>
            
        <div id="info_usuario">
          
            
            <button id="cambiar-email_usuario" type="button" class="btn btn-info datos_usuario">Modificar correo</button>
        
              <button  id="cambiar-constrasena_usuario" type="button" class="btn btn-info datos_usuario">Modificar contraseña</button>
            <button  id="cerrar-sesion_usuario" type="button" class="btn btn-primary datos_usuario">Cerrar Sesión</button>
          
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
