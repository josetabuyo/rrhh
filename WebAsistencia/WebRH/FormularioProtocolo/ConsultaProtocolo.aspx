<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaProtocolo.aspx.cs" Inherits="FormularioProtocolo_ConsultaProtocolo" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioProtocolo/GrillaProtocolo.ascx" TagName="GrillaProtocolo" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Formulario Protocolo</title>
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
    <link id="link3" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link5" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" /> 
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" />
    <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="../Estilos/alertify.default.css"  /> 
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
            <%--Antigua grilla
            <uc1:GrillaProtocolo ID="GrillaProtocolo" runat="server" />--%>


        <fieldset>
          <legend>Listado de Áreas del Ministerio de Desarrollo Social de Nación</legend>
            <div id="ContenedorPlanilla" runat="server">
                <div class="input-append">   
                    <input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Filtrar Áreas" />    
                </div>
            </div>
        </fieldset>

    <asp:HiddenField ID="texto_mensaje_exito" runat="server" />
    <asp:HiddenField ID="texto_mensaje_error" runat="server" />
    <asp:HiddenField ID="areasJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="txtIdArea" runat="server" />
    <asp:HiddenField ID="idArea" runat="server" />
            </div>
    </div>
    </form>
</body>

    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/list.js"></script>
    <script type="text/javascript" src="../Scripts/placeholder_ie.js"></script>

    <script type="text/javascript">

    //Muestra los Mensajes de Error mediante PopUp y los de Éxito por mensaje
    var mostrador_de_mensajes = {
        mostrar: function (mensaje) {
            alertify.alert(mensaje);
        }
    };
    var administradorDeErrores = new AdministradorDeMensajes(
        {
            mostrar: function (mensaje) {
                alertify.alert(mensaje);
            }
        },
        $("#texto_mensaje_error").val());

    var administradorDeExitos = new AdministradorDeMensajes(
        {
            mostrar: function (mensaje) {
                $("#DivMensajeExito").show();
                $("#DivMensajeExito").Visible = "true";
            }
        },
        $("#texto_mensaje_exito").val());

        var HabilitarNuevo = function () {
            $("#btnAgregarArea").removeAttr('disabled', 'false');
        }

        var DeshabilitarNuevo = function () {
            $("#btnAgregarArea").attr('disabled', 'disabled');
        }

        var PlanillaMaterias;
        var contenedorPlanilla;

        var AdministradorAreas = function () {
            var areas = JSON.parse($('#areasJSON').val());
            contenedorPlanilla = $('#ContenedorPlanilla');
            var columnas = [];

            columnas.push(new Columna("Área", { generar: function (un_area) { return un_area.nombre } }));
            columnas.push(new Columna("Responsable", { generar: function (un_area) { return un_area.responsable } }));
            columnas.push(new Columna("Asistentes", { generar: function (un_area) { return un_area.asistentes } }));
            columnas.push(new Columna("Teléfonos", { generar: function (un_area) { return un_area.telefono } }));
            columnas.push(new Columna("Fax", { generar: function (un_area) { return un_area.fax } }));
            columnas.push(new Columna("Correo Electrónico", { generar: function (un_area) { return un_area.mail } }));
            columnas.push(new Columna("Dirección", { generar: function (un_area) { return un_area.direccion } }));


            PlanillaAreas = new Grilla(columnas);

            PlanillaAreas.AgregarEstilo("tabla_macc");

            PlanillaAreas.SetOnRowClickEventHandler(function (un_area) {
               // panelArea.CompletarDatosArea(un_area);
            });

            PlanillaAreas.CargarObjetos(areas);
            PlanillaAreas.DibujarEn(contenedorPlanilla);


//            panelArea.CompletarDatosArea = function (un_area) {

//                DeshabilitarNuevo();
//                $("#idArea").val(un_area.id);
//                //ANALIZAR LUEGO
////                $("#txtAula").val(un_area.aula);
////                $("#cmbEdificio").val(un_area.edificio.id);
////                $("#txtDireccion").val(un_area.edificio.direccion);
////                $("#txtCapacidad").val(un_area.capacidad);

//                $("#btnAgregarArea").attr("disabled", true);
//                $("#btnModificarArea").attr("disabled", false);
//                $("#btnQuitarArea").attr("disabled", false);
//            };

            var options = {
                valueNames: ['Área', 'Responsable', 'Asistentes', 'Teléfonos', 'Fax', 'Correo Electrónico', 'Dirección' ]
            };

            var featureList = new List('ContenedorPlanilla', options);
        }

        var LimpiarCampos = function () {


            Limpiar($("#idArea"));
            //ANALIZAR LUEGO
//            Limpiar($("#txtAula"));
//            Limpiar($("#txtIdArea"));
//            Limpiar($("#cmbEdificio"));
//            Limpiar($('#txtDireccion'));
//            Limpiar($('#txtCapacidad'));

            HabilitarNuevo();
        }

        var Limpiar = function (control) {
            control.val("");
        };

        $(document).ready(function () {
            AdministradorAreas();
            HabilitarNuevo();

        });
</script>

</html>
