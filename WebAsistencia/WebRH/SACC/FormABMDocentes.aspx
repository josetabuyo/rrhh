<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormABMDocentes.aspx.cs" Inherits="SACC_FormABMDocentes" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ABM Docentes</title>
    <%= Referencias.Css("../")%>
     <link id="link3" rel="stylesheet" href="EstilosSACC.css" type="text/css" runat="server" /> 
     <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
     <link rel="stylesheet" href="../Estilos/alertify.default.css"  />
     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
    
</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    <div id="panelDocente" class="div_izquierdo">
    <div class="estilo_formulario" style="width:60%; margin-left: 30%;">
    <fieldset>
       <legend class="subtitulos">Panel De Docentes</legend>
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

            <asp:Button ID="btnQuitarDocente" runat="server" Text="Eliminar" class=" btn btn-primary boton_main_documentos" onclick="btnQuitarDocente_Click" />
            <br />
            <br />
            <div runat="server" id="DivMensaje" Visible="true">

            </div>
            <div runat="server" id="DivMensajeExito" Visible="false" class="alert alert-success">
        </div>
    </fieldset>
    </div>
    </div>

    <div class="div_derecho">
         <div class="estilo_formulario" style="width:95%; overflow:auto;  margin-left:1%;">
        <fieldset>
        <legend class="subtitulos">Listado de Docentes</legend>
        <div id="ContenedorPlanilla" runat="server">
            <div class="input-append" style="clear:both;">   
                <input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Filtrar Docentes" />    
            </div>
        </div>
        </fieldset>
        </div>
    </div>
    
    <asp:HiddenField ID="texto_mensaje_exito" runat="server" />
    <asp:HiddenField ID="texto_mensaje_error" runat="server" />
    <asp:HiddenField ID="docentesJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="idBaja" runat="server" />
    <asp:HiddenField ID="txtIdDocente" runat="server" />
    <asp:HiddenField ID="idDocente" runat="server" />
    <asp:HiddenField ID="alerta_mensaje" runat="server" />
    </form>
</body>
    <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
    


<script type="text/javascript">

    //Al presionarse Enter luego de Ingresar el DNI, se fuerza a realizar la búsqueda de dicho DNI para no tener que hacer necesariamente un click en el botón Buscar
    function CapturarTeclaEnter(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 13) && (node.type == "text")) { $("#btn_buscar_personas").click(); }
    }
    document.onkeypress = CapturarTeclaEnter;


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

        PlanillaDocentes.AgregarEstilo("tabla_macc");

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
            $("#idBaja").val(un_docente.baja);

            $("#btnAgregarDocente").attr("disabled", true);

            $("#btnQuitarDocente").attr("disabled", false);
        };

        var options = {
            valueNames: ['Documento', 'Nombre', 'Apellido', 'Modalidad', 'Detalle']
        };

        var featureList = new List('ContenedorPlanilla', options);


    }

    $(document).ready(function () {
        AdministradorDocentes();

        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');
    });
</script>
</html>
