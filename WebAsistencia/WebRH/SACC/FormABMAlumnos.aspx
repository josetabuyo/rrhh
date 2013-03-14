<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormABMAlumnos.aspx.cs" Inherits="SACC_FormABMAlumnos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />

</head>
<body>
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="panelAlumno" class="div_izquierdo">
        <fieldset>
        <legend>Panel De Alumnos</legend>
        <div class="input-append">   
            <asp:TextBox id="input_dni" CssClass="label_alumno" placeholder="D.N.I" runat="server"></asp:TextBox>
            <asp:Button ID="btn_buscar_personas" Text="Buscar" runat="server" OnClick="btnBuscarPersona_Click" class=" btn btn-primary" />
        </div>
         <p>   
            <asp:Label ID="lblDocumento" CssClass="labels_sacc" runat="server" Text="Documento:"></asp:Label>
            <asp:TextBox ID="lblDatoDocumento" ReadOnly="false" CssClass="label_alumno" runat="server" ></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblApellido" CssClass="labels_sacc" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox  ID="lblDatoApellido" ReadOnly="false"  CssClass="label_alumno" runat="server" ></asp:TextBox>        
        </p>
        <p> 
            <asp:Label ID="lblNombre" CssClass="labels_sacc" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="lblDatoNombre" ReadOnly="false" CssClass="label_alumno" runat="server" ></asp:TextBox>
        </p>

        <p>   
            <asp:Label ID="lblTelefono" CssClass="labels_sacc" runat="server" Text="Teléfono:"></asp:Label>
            <asp:TextBox ID="lblDatoTelefono" ReadOnly="false" CssClass="label_alumno" runat="server" ></asp:TextBox>
        </p>
        <%--<p>
        <asp:Label ID="texto" CssClass="popover-title" runat="server" Text="Otros datos de contacto"></asp:Label>
        <br/>
        </p>--%>

        <p>   
            <asp:Label ID="lblMail" CssClass="labels_sacc" runat="server" Text="Mail:"></asp:Label>
            <asp:TextBox ID="lblDatoMail" ReadOnly="false" CssClass="label_alumno" runat="server" ></asp:TextBox>
        </p>

        <p>   
            <asp:Label ID="lblDireccion" CssClass="labels_sacc" runat="server" Text="Dirección:"></asp:Label>
            <asp:TextBox ID="lblDatoDireccion" ReadOnly="false" CssClass="label_alumno" runat="server" ></asp:TextBox>
        </p>


        <p>
            <asp:DropDownList ID="cmbPlanDeEstudio" runat="server" enableviewstate="true">
                <asp:ListItem Value="-1" class="placeholder" Selected="true">Todos</asp:ListItem>
               
            </asp:DropDownList>
        </p>
        <div style=" margin-left:17%; margin-top:3%;">
            <asp:Button ID="btnAgregarAlumno" runat="server" Text="Inscribir"  OnClick="btnAgregarAlumno_Click" class=" btn btn-primary boton_main_documentos"  />
            <asp:Button ID="btnModificarAlumno" runat="server" Text="Cambiar Modalidad" class=" btn btn-primary boton_main_documentos" onclick="btnModificarAlumno_Click" />
            <asp:Button ID="btnQuitarAlumno" runat="server" Text="Desinscribir" class=" btn btn-primary boton_main_documentos" onclick="btnQuitarAlumno_Click" />
        <br/>
            <asp:Label ID="lblMensaje" CssClass="error-message" runat="server"></asp:Label>
        </div>
    </fieldset>
    </div>
    <div class="div_derecho">
        <fieldset>
        <legend>Listado de Alumnos</legend>
        <div id="ContenedorPlanilla" runat="server"></div>
       <%-- <asp:HiddenField ID="planillaJSON" runat="server" EnableViewState="true"/>--%>
       </fieldset>
    </div>
    <asp:HiddenField ID="personasJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="alumnosJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="idAlumnoAVer" runat="server" />
    <asp:HiddenField ID="datosPersona" runat="server" />
    <asp:HiddenField ID="personaSeleccionada" runat="server" />
     <asp:Button ID="btnVerFichaAlumno" Text="" runat="server" OnClick="btnVerAlumno_Click" style="display:none"/>
    </form>
</body>
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-transition.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-modal.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-tab.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-tooltip.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-popover.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-button.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-typeahead.js"></script>
<script type="text/javascript">
    var PlanillaAlumnos;
    var contenedorPlanilla;

    var AdministradorPlanillaMensual = function () {
        var Alumnos = JSON.parse($('#alumnosJSON').val());
        //var nombreAlumno = Alumnos['nombre'];
        var panelAlumno = $("#panelAlumno");

        var listaPersonas = $('#personasJSON');
        var selectorDePersonas = $('#input_dni');
        var personaSeleccionada = $('#personaSeleccionada');

        //crearInputAutocompletable(selectorDePersonas, listaPersonas, personaSeleccionada);

        var EncabezadoPlanilla;
        contenedorPlanilla = $('#ContenedorPlanilla');
        var columnas = [];

        columnas.push(new Columna("Documento", { generar: function (un_alumno) { return un_alumno.documento } }));
        columnas.push(new Columna("Nombre", { generar: function (un_alumno) { return un_alumno.nombre } }));
        columnas.push(new Columna("Apellido", { generar: function (un_alumno) { return un_alumno.apellido } }));
//        columnas.push(new Columna("Pertenece A", { generar: function (un_alumno) { return un_alumno.area.descripcion } }));
        columnas.push(new Columna("Teléfono", { generar: function (un_alumno) { return un_alumno.telefono } }));
        columnas.push(new Columna("Modalidad", { generar: function (un_alumno) { return un_alumno.modalidad.descripcion } }));
        columnas.push(new Columna('Detalle', { generar: function (un_alumno) {
            var contenedorBtnFichaAlumno = $('<div>');
            var botonVerAlumno = $('<input>');
            botonVerAlumno.attr('type', 'button');
            botonVerAlumno.addClass('btn');
            botonVerAlumno.addClass('btn-primary');
            botonVerAlumno.val('Ver Ficha');
            botonVerAlumno.click(function () {
                $("#idAlumnoAVer").val(un_alumno.id);
                $("#btnVerFichaAlumno").click();
            });
            contenedorBtnFichaAlumno.append(botonVerAlumno);

            return contenedorBtnFichaAlumno;
        } 
        }));

        PlanillaAlumnos = new Grilla(columnas);

        PlanillaAlumnos.SetOnRowClickEventHandler(function (un_alumno) {
            panelAlumno.CompletarDatosAlumno(un_alumno);
        });

        PlanillaAlumnos.CargarObjetos(Alumnos);
        PlanillaAlumnos.DibujarEn(contenedorPlanilla);


        panelAlumno.CompletarDatosAlumno = function (un_alumno) {

            $("#input_dni").val("");
            $("#idAlumnoAVer").val(un_alumno.id);
            $("#lblDatoApellido").val(un_alumno.apellido);
            $("#lblDatoNombre").val(un_alumno.nombre);
            $("#lblDatoDocumento").val(un_alumno.documento);
            $("#lblDatoTelefono").val(un_alumno.telefono);
            $("#lblDatoMail").val(un_alumno.mail);
            $("#lblDatoDireccion").val(un_alumno.direccion);
            $("#cmbPlanDeEstudio").val(un_alumno.modalidad.id);

        };


    }

    function crearInputAutocompletable(input, lista, elementoSeleccionado) {
        input.attr('data-source', lista.val());
        input.attr("autocomplete", "off");
        input.blur(function () {
            try {
                if (input.val() != '') {
                    var itemSeleccionado = input.data().typeahead.$menu.find('.active').data().item;
                    elementoSeleccionado.val(itemSeleccionado.value);
                    input.val(itemSeleccionado.label);
                }
                else {
                    elementoSeleccionado.val('');
                }
            }
            catch (e) {
                elementoSeleccionado.val('');
                input.val('');
            }
        });
    }

   
    $(document).ready(function () {
        AdministradorPlanillaMensual();
    });
</script>
</html>
