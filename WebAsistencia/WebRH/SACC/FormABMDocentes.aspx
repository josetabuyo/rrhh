<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormABMDocentes.aspx.cs" Inherits="SACC_FormABMDocentes" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ABM Docentes</title>
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
    <div id="panelDocente" class="div_izquierdo">
    <fieldset>
       <legend>Panel De Docentes</legend>
        <div class="input-append">   
            <asp:TextBox id="input_dni" CssClass="label_alumno" placeholder="D.N.I" runat="server"></asp:TextBox>
            <asp:Button ID="btn_buscar_personas" Text="Buscar" runat="server" OnClick="btnBuscarPersona_Click" class=" btn btn-primary" />
        </div>
                 <p>   
            <asp:Label ID="lblDNI" CssClass="labels_sacc" runat="server" Text="Documento:"></asp:Label>
            <asp:TextBox ID="lblDatoDocumento" name="D.N.I" runat="server" CssClass="label_alumno" EnableViewState="false"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label1" CssClass="labels_sacc" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox ID="lblDatoApellido" name="apellido" runat="server" CssClass="label_alumno" EnableViewState="false"></asp:TextBox>     
        </p>
        <p> 
            <asp:Label ID="Label2" CssClass="labels_sacc" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="lblDatoNombre" name="Nombre" runat="server" CssClass="label_alumno" EnableViewState="false"></asp:TextBox>
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

        <div style=" margin-left:17%; margin-top:3%;">
            <asp:Button ID="btnAgregarDocente" runat="server" Text="Agregar" class=" btn btn-primary boton_main_documentos" onclick="btnAgregarDocente_Click" />
            <%--<asp:Button ID="btnModificarDocente" runat="server" Text="Modificar" class=" btn btn-primary boton_main_documentos" onclick="btnModificarDocente_Click" />--%>
            <asp:Button ID="btnQuitarDocente" runat="server" Text="Eliminar" class=" btn btn-primary boton_main_documentos" onclick="btnQuitarDocente_Click" />
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
        <legend>Listado de Docentes</legend>
        <div id="ContenedorPlanilla" runat="server"></div>
        </fieldset>
    </div>

    <asp:HiddenField ID="docentesJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="txtIdDocente" runat="server" />
    <asp:HiddenField ID="idDocente" runat="server" />
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
        this.texto_mensaje.innerHTML = "No se puede eliminar el docente porque se encuentra asignado a un curso";
    } else if ($("#alerta_mensaje").val() == "4") {
        this.div_mensaje.setAttribute("class", "alert alert-error");
        this.texto_mensaje.innerHTML = "No se encontro una persona con ese documento";
    } else {
        $(".alert").alert('close');
    }

    var PlanillaDocentes;
    var contenedorPlanilla;

    var AdministradorDocentes = function () {
        var docentes = JSON.parse($('#docentesJSON').val());
        contenedorPlanilla = $('#ContenedorPlanilla');
        var columnas = [];

        columnas.push(new Columna("D.N.I", { generar: function (un_docente) { return un_docente.dni } }));
        columnas.push(new Columna("Nombre", { generar: function (un_docente) { return un_docente.nombre } }));
        columnas.push(new Columna("Apellido", { generar: function (un_docente) { return un_docente.apellido } }));

        PlanillaDocentes = new Grilla(columnas);

        PlanillaDocentes.SetOnRowClickEventHandler(function (un_docente) {
            panelDocente.CompletarDatosDocente(un_docente);
        });

        PlanillaDocentes.CargarObjetos(docentes);
        PlanillaDocentes.DibujarEn(contenedorPlanilla);


        panelDocente.CompletarDatosDocente = function (un_docente) {

            $("#idDocente").val(un_docente.id);
            $("#lblDatoDocumento").val(un_docente.dni);
            $("#lblDatoNombre").val(un_docente.nombre);
            $("#lblDatoApellido").val(un_docente.apellido);

            $("#lblDatoTelefono").val(un_docente.telefono);
            $("#lblDatoMail").val(un_docente.mail);
            $("#lblDatoDireccion").val(un_docente.domicilio);
        };


    }

    $(document).ready(function () {
        AdministradorDocentes();
    });
</script>
</html>
