<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FCargaComisionDeServicio.aspx.cs"
    Inherits="FCargaComisionDeServicio" %>

<%@ Register Src="ControlPasaje.ascx" TagName="ControlPasaje" TagPrefix="uc1" %>
<%@ Register Src="../FormulariosDeLicencia/Partes/DatosDelAgente.ascx" TagName="DatosDelAgente"
    TagPrefix="uc2" %>
<%@ Register Src="../FormulariosDeLicencia/Partes/AceptarCancelar.ascx" TagName="AceptarCancelar"
    TagPrefix="uc3" %>
<%@ Register Src="ControlEstadia.ascx" TagName="ControlEstadia" TagPrefix="uc4" %>
<%@ Register Src="ControlNotficaciones.ascx" TagName="ControlNotficaciones" TagPrefix="uc5" %>
<%@ Register Src="GrillaEstadias.ascx" TagName="GrillaEstadias" TagPrefix="uc6" %>
<%@ Register Src="GrillaPasajes.ascx" TagName="GrillaPasajes" TagPrefix="uc7" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.0.30930.28736, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<%@ Register Src="../BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Formulario de Viáticos - Solicitud</title>
     
    <style type="text/css">
        #myTabContent .tab-content
        {
            background-color: #004066;
            color: #fff;
        }
        
        #myTabContent #estadia:hover, #myTabContent #estadia:focus, #estadia:active
        {
            background-color: #004066;
            color: #fff;
        }
        
        #myTabContent #pasaje:hover, #myTabContent #pasaje:focus, #pasaje:active
        {
            background-color: #004066;
            color: #fff;
        }
        
        #contenedor_tab
        {
            background-color: #004066;
            -moz-border-radius: 10px; /* Firefox */
            -webkit-border-radius: 10px; /* Safari, Chrome */
            border-radius: 10px; /* CSS3 */
            color: #fff;
        }
        
        #tabEstadia, #tabPasaje
        {
        }
        
        .agente, .documento, .area, .categoria
        {
            float: right;
            font-family: "Humnst777 BT";
            font-size: 13px;
        }
        
        .error-message, label.error
        {
            color: #ff0000;
            margin: 0;
            display: inline;
            font-size: 1em !important;
            font-weight: lighter;
        }
        
        .imagen
        {
            float: right;
            margin-left: 10px;
        }
        
        .area
        {
            text-align: right;
            width: 300px;
        }
        .cerrars
        {
            float: right;
            margin-right: 20px;
        }
        .mds
        {
            float: right;
            margin-top: 10px;
            margin-right: 20px;
        }
        .direccion
        {
            float: right;
            margin-top: 10px;
            margin-right: 20px;
        }
        .sistema
        {
            position: relative;
            top: 15px;
            left: 15px;
        }
        
        #texto_bienv
        {
            font-family: "Humnst777 BT";
            font-size: 26px;
            color: #FFF;
        }
    </style>
    <link id="link1" rel="stylesheet" href="../Scripts/bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../Scripts/bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <script src="../Scripts/bootstrap/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap/js/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery-ui-1.8.21.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>


       <%-- <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Estilos/alertify.core.css"" type=""text/css""/>
            <link rel=""stylesheet"" href=""__RUTA_ORIGEN__Estilos/alertify.default.css"" type=""text/css""/>";--%>

    <script type="text/javascript">


   
        function mostrarMensaje(mensaje) {
//            debugger;
            alertify.alert(mensaje);
            muestra('contenido_a_mostrar')
        }

        function muestra(id) {
            if (document.getElementById) {
                var div = document.getElementById(id);
                div.style.display = (div.style.display == 'display') ? 'block' : 'display';
            }
        }
        window.onload = function () {
            muestra('contenido_a_mostrar');
        }

        function oculta(id) {
            if (document.getElementById) {
                var div = document.getElementById(id);
                div.style.display = (div.style.display == 'none') ? 'block' : 'none';
            }
        }
        window.onload = function () {
            oculta('contenido_a_mostrar');
        }
    </script>
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
</head>
<body onload="MM_preloadImages('../Imagenes/Botones/volver_s2.png','../Imagenes/Botones/cerrarsesion_s2.png')">
<form id="form1" runat="server">
    <%--COMIENZO DE PLATILLA--%>
     
        <uc8:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:14px;font-weight: bold;'> Gestión de Viáticos </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />        
           

    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server" />
    <%--     Se cambió todo el código de la Barrá de Menú por el Control llamado Barra Menú--%>
    <%--<uc8:BarraMenu ID="BarraMenu" runat="server" />--%>   
    <div class="container">
        <br />
        <div class="row-fluid" style="text-align: center;">
            <asp:Image ID="img_perfil" runat="server" Width="95" Height="90" CssClass="imagen" />
            <%--<img src="../Imagenes/fabi.jpg" alt="cont+foto" width="95" height="90" class="imagen" />--%>
        <uc2:DatosDelAgente ID="DatosDelAgente1" runat="server" />
        </div>
        <%--<a data-toggle="modal" href="#myModal" class="btn-large">Instrucciones</a>--%>
        <br />
        <%--<asp:Button CssClass="btn" runat="server" Text="Ayuda" />--%>
        <div class="row-fluid">
        <%--<asp:Label ID="Label8" runat="server" Font-Names="Tahoma" Font-Underline="True" Text="Notificaciones:" EnableTheming="False" Font-Size="16px"></asp:Label>
             <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>--%>
            <div id="contenedor_tab" class="span4">
               
                <ul class="nav nav-tabs">
                    <li><a id="tabEstadia" href="#estadia" data-toggle="tab">Estadías</a></li>
                    <li><a id="tabPasaje" href="#pasaje" data-toggle="tab">Pasajes</a></li>
                    <%-- Se comenta el botón de Ayuda hasta no Obtener el Texto Final NO BORRAR!!!--%>
                    <%--<li><a href="#myModal"  data-toggle="modal" style="margin-left:150px; "><img width="25px" height="25px" alt="Ayuda" src="../Imagenes/ico_ayuda.png" /></a></li>--%>
                </ul>
                <div id="myTabContent" class="tab-content">
                    <div class="tab-pane fade in active" id="estadia">
                        <uc4:ControlEstadia ID="ControlEstadia" runat="server" />
                        <p style="text-align: center">
                            <asp:Button Text="Agregar Estadía" CssClass="btn" runat="server" ID="btn_agregar_estadia"
                                OnClick="btn_agregar_estadia_Click" /></p>
                    </div>
                    <div class="tab-pane fade" id="pasaje">
                        <uc1:ControlPasaje ID="ControlPasaje" runat="server" />
                        <p style="text-align: center">
                            <asp:Button Text="Agregar Pasaje" CssClass="btn" runat="server" ID="Button1" OnClick="btn_agregar_pasaje_Click" /></p>
                    </div>
                </div>
            </div>
            <div class="span8">
                <uc6:GrillaEstadias ID="ControlGrillaEstadias" runat="server" />
                <uc7:GrillaPasajes ID="ControlGrillaPasajes" runat="server" />
            </div>
        </div>
        <br />
        <div id="contenido_a_mostrar" class="alert alert-error" style="display: none;">
            <uc5:ControlNotficaciones ID="ControlNoficaciones" runat="server" EnableViewState="true" />
        </div>
        <%--        <div class="container-fluid" id="contenido_a_mostrar">
            <div class="row-fluid">
                <div class="span10">
                    >
                    <asp:Label ID="Notificacion" runat="server" Font-Names="Tahoma" Font-Underline="True"
                        Text="Notificaciones:" EnableTheming="False" Font-Size="16px"></asp:Label>
                    <asp:Label ID="DetalleNotificacion" runat="server" Text="Se está solicitando un Viático con un lapso menor a 72 horas hábiles"
                        Font-Names="Tahoma" EnableTheming="False" Font-Size="16px"></asp:Label>
                </div>
            </div>
        </div>--%>
        <%--<uc3:AceptarCancelar ID="AceptarCancelar1" runat="server" />--%>
        <div class="span12" style="text-align: center;">
            <%-- <asp:Button ID="btn_limpiar" runat="server" CssClass="btn" OnClick="btn_limpiar_Click" Text="Limpiar" />--%>
            <asp:Button ID="btn_guardar" runat="server" CssClass="btn" CausesValidation="false"
                OnClick="btn_guardar_Click" Text="Guardar" />
        </div>
        <br />
        <div class="span12" style="text-align: center;">
            <asp:Label ID="labelGuardado" runat="server" />
        </div>
    </div>
    <!-- Contenido del Modal -->
    <div id="myModal" class="modal hide fade">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                &times;</button>
            <h3>
                Instrucciones</h3>
        </div>
        <div class="modal-body">
            <h4>
                Text in a modal</h4>
            <p>
                Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio
                sem.</p>
            <h4>
                Popover in a modal</h4>
            <p>
                This <a href="#" class="btn popover-test" title="A Title" data-content="And here's some amazing content. It's very engaging. right?">
                    button</a> should trigger a popover on hover.</p>
            <h4>
                Tooltips in a modal</h4>
            <p>
                <a href="#" class="tooltip-test" title="Tooltip">This link</a> and <a href="#" class="tooltip-test"
                    title="Tooltip">that link</a> should have tooltips on hover.</p>
            <hr>
            <h4>
                Texto</h4>
            <p>
                Poner el texto que haga falta</p>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn" data-dismiss="modal">Salir</a>
            <%--<a href="#" class="btn btn-primary">Save changes</a>--%>
        </div>
    </div>
    </form>
    <%--        <script type="text/javascript">

            function onSuccess(result) {
                window.location = result;
            }

            function onFailure(error) {
                alert(error);
            }

            function QuitarEstadia(id_estadia) {
                PageMethods.VerDetalle(id, onSuccess, onFailure);
            }

        </script>--%>
                <script type="text/javascript">

                    function onSuccess(result) {
                        window.location = result;
                    }

                    function onFailure(error) {
                        alertify.alert(error);
                    }

                    function QuitarEstadia(id_estadia) {
                        PageMethods.QuitarEstadia(id_estadia, onSuccess, onFailure);
                    }

        </script>
     <%= Referencias.Javascript("../")%>  

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.validate.js"></script>
     <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-tab.js"></script>
    <%= Referencias.Css("../")%>  
  
     
</body>
</html>
