<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormABMEspaciosFisicos.aspx.cs" Inherits="SACC_FormABMMaterias" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ABM Espacios Físicos</title>
   <%= Referencias.Css("../")%>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>

</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="panelEspacioFisico" class="div_izquierdo">
   
        <div class="estilo_formulario" style="width:60%; margin-left: 30%;">
         <fieldset>
        <legend class="subtitulos">Panel De Espacios Físicos</legend>
            <div>
                <asp:Label ID="lblAula" CssClass="labels_sacc" runat="server" Text="Aula:"></asp:Label>
                <asp:TextBox ID="txtAula" placeholder="Aula" name="Aula" runat="server" EnableViewState="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblEdificio" CssClass="labels_sacc" runat="server" Text="Edificio:"></asp:Label>
                <asp:DropDownList ID="cmbEdificio" runat="server" enableviewstate="true" OnTextChanged="cbMostarDireccion_Click" AutoPostBack="True"> <%--OnSelectedIndexChanged="cbMostarDireccion_Click"--%>
                    <asp:ListItem Value="-1" class="placeholder" Selected="true">Seleccione un Edificio</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="cmbDireccion" runat="server" Visible="False" >
                <asp:ListItem Value="-1" class="placeholder" Selected="true">Seleccione un Edificio</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div>
                <asp:Label ID="lblDireccion" CssClass="labels_sacc" runat="server" Text="Dirección:"></asp:Label>
                <asp:TextBox ID="txtDireccion" placeholder="Direccion" name="Direccion" runat="server" EnableViewState="false" ReadOnly="true"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="lblCapacidad" CssClass="labels_sacc" runat="server" Text="Capacidad:"></asp:Label>
                <asp:TextBox ID="txtCapacidad" placeholder="Capacidad" name="Capacidad" runat="server" EnableViewState="false"></asp:TextBox>
            </div>

            <div style=" margin-left:17%; margin-top:3%;">
                   
                <asp:Button ID="btnAgregarEspacioFisico" runat="server" Text="Agregar" class=" btn btn-primary boton_main_documentos" onclick="btnAgregarEspacioFisico_Click"  />
                <asp:Button ID="btnModificarEspacioFisico" runat="server" Text="Modificar" class=" btn btn-primary boton_main_documentos" onclick="btnModificarEspacioFisico_Click"  />
                <asp:Button ID="btnQuitarEspacioFisico" runat="server" Text="Eliminar" class=" btn btn-primary boton_main_documentos" onclick="btnQuitarEspacioFisico_Click"  />
                <input type="button" id="btnLimpiar"  value="Limpiar" class=" btn btn-primary boton_main_documentos" onclick="javascript:LimpiarCampos();" />
            <br />
            <br />
          
             <div runat="server" id="DivMensajeExito" Visible="false" class="alert alert-success">

            </div>
            </div>
             </fieldset>
            </div>
   
    </div>

    <div class="div_derecho">
        <div class="estilo_formulario" style="width:95%; overflow:auto;  margin-left:1%;">
        <fieldset>
        <legend class="subtitulos">Listado de Espacios Físicos</legend>
        <div id="ContenedorPlanilla" runat="server">
            <div class="input-append" style="clear:both;">   
                <input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Filtrar Espacios" />    
            </div>
        </div>
        </fieldset>
        </div>
    </div>

    <asp:HiddenField ID="texto_mensaje_exito" runat="server" />
    <asp:HiddenField ID="texto_mensaje_error" runat="server" />
    <asp:HiddenField ID="espacios_fisicosJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="txtIdEspacioFisico" runat="server" />
    <asp:HiddenField ID="idEspacioFisico" runat="server" />


    </form>
</body>
    <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>


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
        $("#btnAgregarEspacioFisico").removeAttr('disabled', 'false');
    }

    var DeshabilitarNuevo = function () {
        $("#btnAgregarEspacioFisico").attr('disabled', 'disabled');
    }

    var PlanillaMaterias;
    var contenedorPlanilla;

    var AdministradorEspaciosFisicos = function () {
        var espacios_fisicos = JSON.parse($('#espacios_fisicosJSON').val());
        contenedorPlanilla = $('#ContenedorPlanilla');
        var columnas = [];

        columnas.push(new Columna("Aula", { generar: function (un_espacio_fisico) { return un_espacio_fisico.aula } }));
        columnas.push(new Columna("Edificio", { generar: function (un_espacio_fisico) { return un_espacio_fisico.edificio.nombre } }));
        columnas.push(new Columna("Capacidad", { generar: function (un_espacio_fisico) { return un_espacio_fisico.capacidad } }));

        PlanillaEspaciosFisicos = new Grilla(columnas);

        PlanillaEspaciosFisicos.AgregarEstilo("tabla_macc");

        PlanillaEspaciosFisicos.SetOnRowClickEventHandler(function (un_espacio_fisico) {
            panelEspacioFisico.CompletarDatosEspacioFisico(un_espacio_fisico);
        });

        PlanillaEspaciosFisicos.CargarObjetos(espacios_fisicos);
        PlanillaEspaciosFisicos.DibujarEn(contenedorPlanilla);


        panelEspacioFisico.CompletarDatosEspacioFisico = function (un_espacio_fisico) {

            DeshabilitarNuevo();
            $("#idEspacioFisico").val(un_espacio_fisico.id);
            $("#txtAula").val(un_espacio_fisico.aula);
            $("#cmbEdificio").val(un_espacio_fisico.edificio.id);
            $("#txtDireccion").val(un_espacio_fisico.edificio.direccion);
            $("#txtCapacidad").val(un_espacio_fisico.capacidad);

            $("#btnAgregarEspacioFisico").attr("disabled", true);
            $("#btnModificarEspacioFisico").attr("disabled", false);
            $("#btnQuitarEspacioFisico").attr("disabled", false);
        };

        var options = {
            valueNames: ['Aula', 'Edificio', 'Capacidad']
        };

        var featureList = new List('ContenedorPlanilla', options);
    }

    var LimpiarCampos = function () {

        Limpiar($("#txtAula"));
        Limpiar($("#idEspacioFisico"));
        Limpiar($("#txtIdEspacioFisico"));
        Limpiar($("#cmbEdificio"));
        Limpiar($('#txtDireccion'));
        Limpiar($('#txtCapacidad'));

        HabilitarNuevo();
    }

    var Limpiar = function (control) {
        control.val("");
    };

    $(document).ready(function () {
        AdministradorEspaciosFisicos();
        HabilitarNuevo();

        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');
    });
</script>
</html>