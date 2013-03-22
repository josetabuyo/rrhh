<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormABMEspaciosFisicos.aspx.cs" Inherits="SACC_FormABMMaterias" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ABM Espacios Físicos</title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
     <script type="text/javascript" src="../bootstrap/js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="panelMateria" class="div_izquierdo">
    <fieldset>
        <legend>Panel De Espacios Físicos</legend>
            <div>
                <asp:Label ID="lblAula" CssClass="labels_sacc" runat="server" Text="Aula:"></asp:Label>
                <asp:TextBox ID="txtAula" placeholder="Aula" name="Aula" runat="server" EnableViewState="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblEdificio" CssClass="labels_sacc" runat="server" Text="Edificio:"></asp:Label>
                <asp:DropDownList ID="cmbEdificio" runat="server" enableviewstate="true">
                    <asp:ListItem Value="-1" class="placeholder" Selected="true">Seleccione un Edificio</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div>
                <asp:Label ID="lblDireccion" CssClass="labels_sacc" runat="server" Text="Dirección:"></asp:Label>
                <asp:TextBox ID="txtDireccion" placeholder="Direccion" name="Direccion" runat="server" EnableViewState="false"></asp:TextBox>
            </div>

            <div>
                <asp:Label ID="lblCapacidad" CssClass="labels_sacc" runat="server" Text="Capacidad:"></asp:Label>
                <asp:TextBox ID="txtCapacidad" placeholder="Capacidad" name="Capacidad" runat="server" EnableViewState="false"></asp:TextBox>
            </div>

            <div style=" margin-left:17%; margin-top:3%;">
                   
                <asp:Button ID="btnAgregarMateria" runat="server" Text="Agregar" class=" btn btn-primary boton_main_documentos" onclick="btnAgregarEspacioFisico_Click"  />
                <asp:Button ID="btnModificarMateria" runat="server" Text="Modificar" class=" btn btn-primary boton_main_documentos" onclick="btnModificarEspacioFisico_Click"  />
                <asp:Button ID="btnQuitarMateria" runat="server" Text="Eliminar" class=" btn btn-primary boton_main_documentos" onclick="btnQuitarEspacioFisico_Click"  />
                 <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class=" btn btn-primary boton_main_documentos" onClientClick="javascript:LimpiarCampos();" />
            <br />
            <br />
            <div class="alert alert-error" id="div_mensaje" style="width:42%;">
              <button type="button" class="close" data-dismiss="alert">&times;</button>
              <strong id="texto_mensaje">Por favor complete todos los campos.</strong> 
            </div>
            <%--<asp:Label ID="lblMensaje" CssClass="error-message" runat="server"></asp:Label>--%>
            </div>
    </fieldset>
    </div>

    <div class="div_derecho">
        <fieldset>
        <legend>Listado de Espacios Físicos</legend>
        <div id="ContenedorPlanilla" runat="server"></div>
        </fieldset>
    </div>

    <asp:HiddenField ID="materiasJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="txtIdMateria" runat="server" />
    <asp:HiddenField ID="idMateria" runat="server" />
    <asp:HiddenField ID="alerta_mensaje" runat="server" />

    </form>
</body>
<script type="text/javascript">

    if ($("#alerta_mensaje").val() == "1") {
        $(".alert").alert();
    } else if ($("#alerta_mensaje").val() == "2") {
        this.div_mensaje.setAttribute("class", "alert alert-success");
        this.texto_mensaje.innerHTML = "Operación exitosa.";
    } else if ($("#alerta_mensaje").val() == "3") {
        this.div_mensaje.setAttribute("class", "alert alert-error");
        this.texto_mensaje.innerHTML = "No se puede eliminar la materia porque se encuentra asignado a un curso";
    }else {
        $(".alert").alert('close');
    }

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
        };


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

    });
</script>
</html>
