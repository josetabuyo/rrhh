<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormABMMaterias.aspx.cs" Inherits="SACC_FormABMMaterias" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ABM Materias</title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="panelMateria" class="div_izquierdo">
    <fieldset>
        <legend>Panel De Materias</legend>
            <div>
                <asp:Label ID="lblNombre" CssClass="labels_sacc" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNombre" placeholder="Nombre" name="Nombre" runat="server" EnableViewState="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblModalidad" CssClass="labels_sacc" runat="server" Text="Modalidad:"></asp:Label>
                <asp:DropDownList ID="cmbPlanDeEstudio" runat="server" enableviewstate="true">
                    <asp:ListItem Value="-1" class="placeholder" Selected="true">Todos</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style=" margin-left:17%; margin-top:3%;">
                <asp:Button ID="btnAgregarMateria" runat="server" Text="Agregar" class=" btn btn-primary boton_main_documentos" onclick="btnAgregarMateria_Click"  />
                <asp:Button ID="btnModificarMateria" runat="server" Text="Modificar" class=" btn btn-primary boton_main_documentos" onclick="btnModificarMateria_Click"  />
                <asp:Button ID="btnQuitarMateria" runat="server" Text="Eliminar" class=" btn btn-primary boton_main_documentos" onclick="btnQuitarMateria_Click"  />
            <br />
            <asp:Label ID="lblMensaje" CssClass="error-message" runat="server"></asp:Label>
            </div>
    </fieldset>
    </div>

    <div class="div_derecho">
        <fieldset>
        <legend>Listado de Materias</legend>
        <div id="ContenedorPlanilla" runat="server"></div>
        </fieldset>
    </div>

    <asp:HiddenField ID="materiasJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="txtIdMateria" runat="server" />
    <asp:HiddenField ID="idMateria" runat="server" />

    </form>
</body>
<script type="text/javascript">
    var PlanillaMaterias;
    var contenedorPlanilla;

    var AdministradorMaterias = function () {
        var materias = JSON.parse($('#materiasJSON').val());
        contenedorPlanilla = $('#ContenedorPlanilla');
        var columnas = [];

        columnas.push(new Columna("Nombre", { generar: function (una_materia) { return una_materia.nombre } }));
        columnas.push(new Columna("Modalidad", { generar: function (una_materia) { return una_materia.modalidad.descripcion } }));

        PlanillaMaterias = new Grilla(columnas);

        PlanillaMaterias.SetOnRowClickEventHandler(function (una_materia) {
            panelMateria.CompletarDatosMateria(una_materia);
        });

        PlanillaMaterias.CargarObjetos(materias);
        PlanillaMaterias.DibujarEn(contenedorPlanilla);


        panelMateria.CompletarDatosMateria = function (una_materia) {

            $("#idMateria").val(una_materia.id);
            $("#txtNombre").val(una_materia.nombre);
            $("#cmbPlanDeEstudio").val(una_materia.modalidad.id);
        };


    }

    $(document).ready(function () {
        AdministradorMaterias();
    });
</script>
</html>
