<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormABMMaterias.aspx.cs" Inherits="SACC_FormABMMaterias" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ABM Materias</title>
    <%= Referencias.Css("../")%>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
   
</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="panelMateria" class="div_izquierdo">
    <div class="estilo_formulario" style="width:60%; margin-left: 30%;">
    <fieldset>
        <legend class="subtitulos">Panel De Materias</legend>
            <div>
                <asp:Label ID="lblNombre" CssClass="labels_sacc" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNombre" placeholder="Nombre" name="Nombre" runat="server" EnableViewState="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblCiclo" CssClass="labels_sacc" runat="server" Text="Ciclo:"></asp:Label>
                <asp:DropDownList ID="cmbCiclo" runat="server" enableviewstate="true">
                    <asp:ListItem Value="-1" class="placeholder" Selected="true">Seleccione un ciclo</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblModalidad" CssClass="labels_sacc" runat="server" Text="Modalidad:"></asp:Label>
                <asp:DropDownList ID="cmbPlanDeEstudio" runat="server" enableviewstate="true">
                    <asp:ListItem Value="-1" class="placeholder" Selected="true">Seleccione una modalidad</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style=" margin-left:17%; margin-top:3%;">
                   
                <asp:Button ID="btnAgregarMateria" runat="server" Text="Agregar" class=" btn btn-primary boton_main_documentos" onclick="btnAgregarMateria_Click"  />
                <asp:Button ID="btnModificarMateria" runat="server" Text="Modificar" class=" btn btn-primary boton_main_documentos" onclick="btnModificarMateria_Click"  />
                <asp:Button ID="btnQuitarMateria" runat="server" Text="Eliminar" class=" btn btn-primary boton_main_documentos" onclick="btnQuitarMateria_Click"  />
                 <input type="button" id="btnLimpiar"  value="Limpiar" class=" btn btn-primary boton_main_documentos" onclick="javascript:LimpiarCampos();" />
            <br />
            <br />
          
            <div runat="server" id="DivMensajeExito" Visible="false" class="alert alert-success">
            
            </div>
    </fieldset>
    </div>
    </div>

    <div class="div_derecho">
        <div class="estilo_formulario" style="width:95%; overflow:auto;  margin-left:1%;">
        <fieldset>
        <legend class="subtitulos">Listado de Materias</legend>
        <div id="ContenedorPlanilla" runat="server">
            <div class="input-append" style="clear:both;">   
                <input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Filtrar Materias" />    
            </div>
        </div>
        </fieldset>
        </div>
    </div>

    <asp:HiddenField ID="texto_mensaje_exito" runat="server" />
    <asp:HiddenField ID="texto_mensaje_error" runat="server" />
    <asp:HiddenField ID="materiasJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="txtIdMateria" runat="server" />
    <asp:HiddenField ID="idMateria" runat="server" />


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

//    if ($("#alerta_mensaje").val() == "1") {
//        $(".alert").alert();
//    } else if ($("#alerta_mensaje").val() == "2") {
//        this.div_mensaje.setAttribute("class", "alert alert-success");
//        this.texto_mensaje.innerHTML = "Operación exitosa.";
//    } else if ($("#alerta_mensaje").val() == "3") {
//        this.div_mensaje.setAttribute("class", "alert alert-error");
//        this.texto_mensaje.innerHTML = "No se puede eliminar la materia porque se encuentra asignado a un curso";
//    }else {
//        $(".alert").alert('close');
//    }

    var HabilitarNuevo = function () {
        $("#btnAgregarCurso").removeAttr('disabled', 'false');
    }

    var DeshabilitarNuevo = function () {
        $("#btnAgregarMateria").attr('disabled', 'disabled');
    }

    var PlanillaMaterias;
    var contenedorPlanilla;

    var AdministradorMaterias = function () {
        var materias = JSON.parse($('#materiasJSON').val());
        contenedorPlanilla = $('#ContenedorPlanilla');
        var columnas = [];

        columnas.push(new Columna("Nombre", { generar: function (una_materia) { return una_materia.nombre } }));
        columnas.push(new Columna("Modalidad", { generar: function (una_materia) { return una_materia.modalidad.Descripcion } }));
        columnas.push(new Columna("Ciclo", { generar: function (una_materia) { return una_materia.ciclo.Nombre } }));

        PlanillaMaterias = new Grilla(columnas);

        PlanillaMaterias.AgregarEstilo("tabla_macc");

        PlanillaMaterias.SetOnRowClickEventHandler(function (una_materia) {
            panelMateria.CompletarDatosMateria(una_materia);
        });

        PlanillaMaterias.CargarObjetos(materias);
        PlanillaMaterias.DibujarEn(contenedorPlanilla);


        panelMateria.CompletarDatosMateria = function (una_materia) {

            DeshabilitarNuevo();
            $("#idMateria").val(una_materia.id);
            $("#txtNombre").val(una_materia.nombre);
            $("#cmbPlanDeEstudio").val(una_materia.modalidad.Id);
            $("#cmbCiclo").val(una_materia.ciclo.Id);

            $("#btnAgregarMateria").attr("disabled", true);
            $("#btnModificarMateria").attr("disabled", false);
            $("#btnQuitarMateria").attr("disabled", false);
        };

        var options = {
            valueNames: ['Nombre', 'Modalidad', 'Ciclo']
        };

        var featureList = new List('ContenedorPlanilla', options);

    }

    var LimpiarCampos = function () {

        Limpiar($("#txtNombre"));
        Limpiar($("#cmbCiclo"));
        Limpiar($('#cmbPlanDeEstudio'));

        HabilitarNuevo();
    }

    var Limpiar = function (control) {
        control.val("");
    };

    $(document).ready(function () {
        AdministradorMaterias();
        HabilitarNuevo();

        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');
    });
</script>
</html>
