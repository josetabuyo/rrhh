<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaObservaciones.aspx.cs" Inherits="SACC_FormPlanillaObservaciones" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Observaciones</title>

    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link3" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />

    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>  
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/list.js"></script>
    <script type="text/javascript" src="../Scripts/placeholder_ie.js"></script>
</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
        
            <div id="ContenedorPlanilla" style="width:80%; overflow:auto; margin:0 auto;" runat="server">
                <fieldset>
                    <legend>Observaciones</legend>
                     <div class="input-append" style="clear:both;">   
                        <input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Filtrar Observaciones" />    
                    </div>  
                 </fieldset>    
            </div>
       

        <div style="width:80%; overflow:auto; margin:0 auto;">
            <fieldset>
                <legend>Agregar Observacion</legend>
            <table class="table table-striped table-bordered table-condensed table-hover" >
            <tr>
                        <td class="FechaCarga">
                            <input type="hidden" id="id-field" />
                            <input type="text" id="FechaCarga-field" placeholder="FechaCarga" />
                        </td>
                        <td class="Relacion">
                            <input type="text" id="Relacion-field" placeholder="Relacion" />
                        </td>
                        <td class="PersonaCarga">
                            <input type="text" id="PersonaCarga-field" placeholder="PersonaCarga" />
                        </td>
                        <td class="Pertenece">
                            <input type="text" id="Pertenece-field" placeholder="Pertenece" />
                        </td>
                        <td class="Asunto">
                            <input type="text" id="Asunto-field" placeholder="Asunto" />
                        </td>
                        <td class="ReferenteMDS">
                            <input type="text" id="ReferenteMDS-field" placeholder="ReferenteMDS" />
                        </td>
                        <td class="Seguimiento">
                            <input type="text" id="Seguimiento-field" placeholder="Seguimiento" />
                        </td>
                        <td class="Resultado">
                            <input type="text" id="Resultado-field" placeholder="Resultado" />
                        </td>
                        <td class="FechaDelResultado">
                            <input type="text" id="FechaDelResultado-field" placeholder="FechaDelResultado" />
                        </td>
                        <td class="ReferenteDeLaRespuestaMDS">
                            <input type="text" id="ReferenteDeLaRespuestaMDS-field" placeholder="ReferenteDeLaRespuestaMDS" />
                        </td>
                        <td class="add">
                            <input type="button" value="Agregar" id="add-btn" />
                            <input type="button" value="Editar" id="edit-btn" />
                        </td>
                        </tr>
                    </table>
                    </div>
                    </fieldset>
                    <div style="height:20px; margin-top:10px; width: 100%">
                        <input id="BtnGuardar" style="margin-left: 10px;" class="btn btn-primary " type="submit" onclick="" value="Guardar" runat="server" />
                        <input id="BtnImprimir" style="margin-left: 5px;" class="btn btn-primary " type="button" onclick="" value="Imprimir" />
                    </dvi>
                <asp:HiddenField ID="observaciones" runat="server" />

    </form>

     <script type="text/javascript">
         $(document).ready(function () {
             AdministradorPlanillaMensual();

            //Estilos para ver coloreada la grilla en Internet Explorer
             $("tbody tr:even").css('background-color', '#E6E6FA');
             $("tbody tr:odd").css('background-color', '#9CB3D6 ');

         });

         var AdministradorPlanillaMensual = function () {

             var observaciones = JSON.parse($('#observaciones').val());
             contenedorPlanilla = $('#ContenedorPlanilla');
             var columnas = [];

             columnas.push(new Columna("id", { generar: function (una_observacion) { return una_observacion.id } }));
             columnas.push(new Columna("FechaCarga", { generar: function (una_observacion) { return una_observacion.FechaCarga } }));
             columnas.push(new Columna("Relacion", { generar: function (una_observacion) { return una_observacion.Relacion } }));
             columnas.push(new Columna("PersonaCarga", { generar: function (una_observacion) { return una_observacion.PersonaCarga } }));
             columnas.push(new Columna("Pertenece", { generar: function (una_observacion) { return una_observacion.Pertenece } }));
             columnas.push(new Columna("Asunto", { generar: function (una_observacion) { return una_observacion.Asunto } }));
             columnas.push(new Columna("ReferenteMDS", { generar: function (una_observacion) { return una_observacion.ReferenteMDS } }));
             columnas.push(new Columna("Seguimiento", { generar: function (una_observacion) { return una_observacion.Seguimiento } }));
             columnas.push(new Columna("Resultado", { generar: function (una_observacion) { return una_observacion.Resultado } }));
             columnas.push(new Columna("FechaDelResultado", { generar: function (una_observacion) { return una_observacion.FechaResultado } }));
             columnas.push(new Columna("ReferenteDeLaRespuestaMDS", { generar: function (una_observacion) { return una_observacion.ReferenteRespuestaMDS } }));
             columnas.push(new Columna('Editar', { generar: function (una_observacion) {
                 var botonEditar = $('<input>');
                 botonEditar.attr('type', 'button');
                 botonEditar.addClass('edit-item-btn');
                 botonEditar.val('Editar');

                 return botonEditar;
             }
             }));
             columnas.push(new Columna('Eliminar', { generar: function (una_observacion) {
                 var botonEliminar = $('<input>');
                 botonEliminar.attr('type', 'button');
                 botonEliminar.addClass('remove-item-btn');
                 botonEliminar.val('Eliminar');
                 return botonEliminar;
             }
             }));

             PlanillaObservaciones = new Grilla(columnas);

             PlanillaObservaciones.AgregarEstilo("tabla_macc");

             PlanillaObservaciones.SetOnRowClickEventHandler(function (una_observacion) {
                 //                 panelAlumno.CompletarDatosAlumno(un_alumno);
             });

             PlanillaObservaciones.CargarObjetos(observaciones);
             PlanillaObservaciones.DibujarEn(contenedorPlanilla);

             // Define value names
             var options = {
                 valueNames: ['id', 'FechaCarga', 'Relacion', 'PersonaCarga', 'Pertenece', 'Asunto', 'ReferenteMDS', 'Seguimiento', 'Resultado', 'FechaDelResultado', 'ReferenteDeLaRespuestaMDS']
             };

             // Init list
             var contactList = new List('ContenedorPlanilla', options);

             var idField = $('#id-field'),

                FechaCargaField = $('#FechaCarga-field'),
                RelacionField = $('#Relacion-field'),
                PersonaCargaField = $('#PersonaCarga-field'),
                PerteneceField = $('#Pertenece-field'),
                AsuntoField = $('#Asunto-field'),
                ReferenteMDSField = $('#ReferenteMDS-field'),
                SeguimientoField = $('#Seguimiento-field'),
                ResultadoField = $('#Resultado-field'),
                FechaDelResultadoField = $('#FechaDelResultado-field'),
                ReferenteDeLaRespuestaMDSField = $('#ReferenteDeLaRespuestaMDS-field'),

                addBtn = $('#add-btn'),
                editBtn = $('#edit-btn').hide(),
                removeBtns = $('.remove-item-btn'),
                editBtns = $('.edit-item-btn');

             // Sets callbacks to the buttons in the list
             refreshCallbacks();

             addBtn.click(function () {
                 contactList.add({
                     id: Math.floor(Math.random() * 110000),
                     FechaCarga: FechaCargaField.val(),
                     Relacion: RelacionField.val(),
                     PersonaCarga: PersonaCargaField.val(),
                     Pertenece: PerteneceField.val(),
                     Asunto: AsuntoField.val(),
                     ReferenteMDS: ReferenteMDSField.val(),
                     Seguimiento: SeguimientoField.val(),
                     Resultado: ResultadoField.val(),
                     FechaDelResultado: FechaDelResultadoField.val(),
                     ReferenteDeLaRespuestaMDS: ReferenteDeLaRespuestaMDSField.val()

                 });
                 clearFields();
                 refreshCallbacks();
             });

             editBtn.click(function () {
                 var item = contactList.get('id', idField.val());
                 item.values({
                     id: idField.val(),
                     FechaCarga: FechaCargaField.val(),
                     Relacion: RelacionField.val(),
                     PersonaCarga: PersonaCargaField.val(),
                     Pertenece: PerteneceField.val(),
                     Asunto: AsuntoField.val(),
                     ReferenteMDS: ReferenteMDSField.val(),
                     Seguimiento: SeguimientoField.val(),
                     Resultado: ResultadoField.val(),
                     FechaDelResultado: FechaDelResultadoField.val(),
                     ReferenteDeLaRespuestaMDS: ReferenteDeLaRespuestaMDSField.val()
                 });
                 clearFields();
                 editBtn.hide();
                 addBtn.show();
             });

             function refreshCallbacks() {
                 // Needed to add new buttons to jQuery-extended object
                 removeBtns = $(removeBtns.selector);
                 editBtns = $(editBtns.selector);

                 removeBtns.click(function () {
                     var itemId = $(this).closest('tr').find('.id').text();
                     contactList.remove('id', itemId);
                 });

                 editBtns.click(function () {
                     var itemId = $(this).closest('tr').find('.id').text();
                     var itemValues = contactList.get('id', itemId).values();
                     idField.val(itemValues.id);

                     FechaCargaField.val(itemValues.FechaCarga);
                     RelacionField.val(itemValues.Relacion);
                     PersonaCargaField.val(itemValues.PersonaCarga);
                     PerteneceField.val(itemValues.Pertenece);
                     AsuntoField.val(itemValues.Asunto);
                     ReferenteMDSField.val(itemValues.ReferenteMDS);
                     SeguimientoField.val(itemValues.Seguimiento);
                     ResultadoField.val(itemValues.Resultado);
                     FechaDelResultadoField.val(itemValues.FechaDelResultado);
                     ReferenteDeLaRespuestaMDSField.val(itemValues.ReferenteDeLaRespuestaMDS);

                     editBtn.show();
                     addBtn.hide();
                 });
             }

             function clearFields() {
                 FechaCargaField.val(""),
                RelacionField.val(""),
                PersonaCargaField.val(""),
                PerteneceField.val(""),
                AsuntoField.val(""),
                ReferenteMDSField.val(""),
                SeguimientoField.val(""),
                ResultadoField.val(""),
                FechaDelResultadoField.val(""),
                ReferenteDeLaRespuestaMDSField.val("")
             }
         }

    </script>
</body>


   
</html>
