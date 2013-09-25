<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarraMenu.ascx.cs" Inherits="FormularioDeViaticos_BarraMenu" %>
<%@ Register Src="FormPassword.ascx" TagName="FormPassword" TagPrefix="uc5" %>

<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link id="link1" rel="stylesheet" href="<%= UrlEstilos %>EstilosBarraMenu.css" type="text/css" />
<%--    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link3" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
<%--    <link id="link4" rel="stylesheet" href="../Estilos/jquery-ui.css" />--%>
<%--    <link id="link5" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> --%>

<%--    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>

    <script type="text/javascript">
        $(function () {
            $('a[rel*=leanModal]').leanModal({ top: 200, closeButton: ".modal_close" });
        });		
    </script>--%>

</head>

<div id= "barra_menu_contenedor">
        <div id="contenedor_imagen">
            <div id="barra_menu_contenedor_imagen">
                <img src="<%= UrlImagenes %>BarraMenu/encabezado_sin_logos.png" height="69px;" width="1024px;" alt="logosistema"  />
                <img src="<%= UrlImagenes %>logo_sistema.png" id="img_logo_sistema" width="130px" height="39px"  alt="logosistema"  />              
                <img src="<%= UrlImagenes %>logo_ministerio.png" id="img_logo_minis" style="float:left;" width="150px" height="27px"  alt="logosistema"  />
                <img src="<%= UrlImagenes %>logo_direccion.png" id="img_logo_direccion" width="130px" height="26px"  alt="logosistema"  />
                

                <div id="barra_menu_nombre_sistema"><%= Feature %></div>
            </div>
        </div>
        <div id="contenedor_barraInferior">
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
                    <a id="go" rel="leanModal" class="btn barra_menu_botones" name="signup" href="#signup">Cambiar Password</a>
                    <asp:Button ID="CerrarSessionLinkButton" 
                                    CssClass="barra_menu_botones"
                                    runat="server"
                                    OnClick="CerrarSessionLinkButton_Click" 
                                    Text="Cerrar Sesión" >     
                    </asp:Button>
                    
                </div>
                <uc5:FormPassword ID="FormPassword" runat="server" />
                </div>
                </div>

</div>
