<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaObservaciones.aspx.cs" Inherits="SACC_FormPlanillaObservaciones" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Observaciones</title>
     <%= Referencias.Css("../")%>
     <link id="link3" rel="stylesheet" href="Estilos/EstilosSACC.css" type="text/css" runat="server" /> 
    <link rel="stylesheet" href="../Estilos/alertify.core.css" id="Link6" />
    <link rel="stylesheet" href="../Estilos/alertify.default.css"  />
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>

   
</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
        
            <div id="ContenedorPlanilla" style="width:80%; height:550px; overflow:auto; margin:0 auto;" runat="server">
                <fieldset>
                    <legend>Observaciones</legend>
                     <div class="input-append" style="clear:both;">   
                        <a id="btnObservacion" rel="leanModal" class="btn btn-primary" name="observacion" href="#observacion">Agregar Observaci&oacute;n</a>
                        <a id="BtnImprimir" style="margin-left: 5px;" class="btn btn-primary " href=""  >Imprimir</a>
                        <input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Filtrar Observaciones" />    
                    </div>  
                 </fieldset>    
            </div>
       
                <div id="observacion" >
			        <div id="signup-ct">
				        <div id="signup-header">
					        <h2 style="color:#fff;">Observaci&oacute;n</h2>
					        <p></p>
					        <a class="modal_close" href="#"></a>
				        </div>
						<div id="contenido_form">
                            <input type="hidden" id="id-field" />
                            <div class="txt-fld">
				                <label for="">Fecha Carga:</label>
                                <input type="text"  id="FechaCarga-field" />
				            </div>
                            <div class="txt-fld">
				                <label for="">Relaci&oacute;n:</label>
                                <input type="text" id="Relacion-field" />
				            </div>
                            <div class="txt-fld">
				                <label for="">Persona Carga:</label>
                                <input type="text" id="PersonaCarga-field"  />
				            </div>
                            <div class="txt-fld">
				                <label for="">Pertenece:</label>
                                <input type="text" id="Pertenece-field"  />
				            </div>
                            <div class="txt-fld">
				                <label for="">Asunto:</label>
                                <input type="text" id="Asunto-field"  />
				            </div>
                            <div class="txt-fld">
				                <label for="">ReferenteMDS:</label>
                                <input type="text" id="ReferenteMDS-field" />
				            </div>
                            <div class="txt-fld">
				                <label for="">Seguimiento:</label>
                                <textarea rows="4" cols="50" id="Seguimiento-field"  ></textarea>
                               <%-- <input type="text" id="Seguimiento-field" placeholder="Seguimiento" />--%>
				            </div>
                            <div class="txt-fld">
				                <label for="">Resultado:</label>
                                <textarea rows="4" cols="50" id="Resultado-field"  ></textarea>
                               <%-- <input type="text" id="Resultado-field" placeholder="Resultado" />--%>
				            </div>
                            <div class="txt-fld">
				                <label for="">FechaDelResultado:</label>
                                <input type="text" id="FechaDelResultado-field"  />
				            </div>
                            <div class="txt-fld">
				                <label for="">ReferenteRtaMDS:</label>
                                <input type="text" id="ReferenteRtaMDS-field"  />
				            </div>

                                <p style="clear:left; margin:0 10px; text-align:center; padding:10px 10px" class="add">
                                    <input type="button" class="btn btn-primary " value="Agregar" id="add-btn" />
                                    <input type="button" class="btn btn-primary " value="Editar" id="edit-btn" />
                                </p>
                        </div>
                    </div>	             
                </div> 

<%--                    <div style="height:20px; margin-top:10px; text-align:center; width: 100%">
                        <%--<input id="BtnGuardar" style="margin-left: 10px;" class="btn btn-primary " type="button" onclick="" value="Guardar" runat="server" />--%>
                        <%--<input id="BtnImprimir" style="margin-left: 5px;" class="btn btn-primary " type="button" onclick="" value="Imprimir" />
                    </div>--%>
                <asp:HiddenField ID="observaciones" runat="server" />

    </form>

</body>

    <%= Referencias.Javascript("../") %> 
    <script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>

    <script type="text/javascript" src="../Scripts/list.js"></script>
  

         <script type="text/javascript">

             function CapturarTeclaEnter(evt) {
                 var evt = (evt) ? evt : ((event) ? event : null);
                 var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                 if ((evt.keyCode == 13) && (node.type == "text") ) { return false; }
             }

             $(document).ready(function () {
                 AdministradorPlanillaObservaciones();

                 $('#FechaCarga-field').datepicker({
                     dateFormat: 'dd/mm/yy',
                     onClose: function () {
                         
                     }
                 });

                 $('#FechaDelResultado-field').datepicker({
                     dateFormat: 'dd/mm/yy',
                     onClose: function () {

                     }
                 });

                

                 //Estilos para ver coloreada la grilla en Internet Explorer
                 $("tbody tr:even").css('background-color', '#E6E6FA');
                 $("tbody tr:odd").css('background-color', '#9CB3D6 ');

             });

             var AdministradorPlanillaObservaciones = function () {

                 var _this = this;
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
                 columnas.push(new Columna("ReferenteRtaMDS", { generar: function (una_observacion) { return una_observacion.ReferenteRespuestaMDS } }));
                 columnas.push(new Columna('&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Acciones&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;', { generar: function (una_observacion) {
                     var contenedorBtnAcciones = $('<div>');
                     var botonEditar = $('<img>');
                     botonEditar.addClass('edit-item-btn');
                     botonEditar.attr('src', '../Imagenes/edit.png');
                     botonEditar.attr('style', 'padding-right:5px;');
                     botonEditar.attr('width', '35px');
                     botonEditar.attr('height', '35px');
                     contenedorBtnAcciones.append(botonEditar);

                     var botonEliminar = $('<img>');
                     botonEliminar.addClass('remove-item-btn');
                     botonEliminar.attr('src', '../Imagenes/iconos_eliminar.png');
                     botonEliminar.attr('width', '35px');
                     botonEliminar.attr('height', '35px');
                     contenedorBtnAcciones.append(botonEliminar);

                     return contenedorBtnAcciones;
                 }
                 }));


                 PlanillaObservaciones = new Grilla(columnas);

                 PlanillaObservaciones.AgregarEstilo("tabla_macc");

                 PlanillaObservaciones.SetOnRowClickEventHandler(function (una_observacion) {
                     //                 panelAlumno.CompletarDatosAlumno(un_alumno);
                 });

                 PlanillaObservaciones.CargarObjetos(observaciones);
                 PlanillaObservaciones.DibujarEn(contenedorPlanilla);

                 $(".modal_close").click(function () {
                     clearFields();
                     editBtn.hide();
                     addBtn.show();
                 });

                 //Guardar o Actualizar Observaciones
                 //$("#BtnGuardar").click(function () {
                 function GuardarObservacion() {

                     var data_post = JSON.stringify({
                         "observaciones_nuevas": JSON.stringify(PlanillaObservaciones.Objetos),
                         "observaciones_originales": JSON.stringify(observaciones)
                     });
                     $.ajax({
                         url: "../AjaxWS.asmx/GuardarObservaciones",
                         type: "POST",
                         data: data_post,
                         dataType: "json",
                         contentType: "application/json; charset=utf-8",
                         success: function (respuestaJson) {
                             var respuesta = JSON.parse(respuestaJson.d);
                             if (respuesta.length == 0)
                             // _this.MostrarDetalleErrores(respuesta);

                                 location.href = "FormPlanillaObservaciones.aspx";
                             //alertify.alert("Las observaciones se guardaron correctamente");
                             //_this.CargarObservacionesDTO();

                         },
                         error: function (XMLHttpRequest, textStatus, errorThrown) {
                             alertify.alert(errorThrown);
                         }
                     });
                 };

                 //                function CargarObservacionesDTO() {
                 //                    //PaginaInscripcionAlumnos.prototype.GetCursosDTO = function () {
                 //                    PlanillaObservaciones.BorrarContenido();
                 //                    $.ajax({
                 //                        url: "../AjaxWS.asmx/GetObservaciones",
                 //                        type: "POST",
                 //                        contentType: "application/json; charset=utf-8",
                 //                        success: function (respuestaJson) {
                 //                            var respuesta = JSON.parse(respuestaJson.d);

                 //                            $('#observaciones').val(respuestaJson.d);

                 //                            PlanillaObservaciones.CargarObjetos(respuesta);
                 //                            PlanillaObservaciones.DibujarEn(contenedorPlanilla);
                 //                            //planilla_original = JSON.parse(respuestaJson.d);

                 //                        },
                 //                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                 //                            alertify.alert(errorThrown);
                 //                        }
                 //                    });
                 //                };


                 // Define value names
                 var options = {
                     valueNames: ['id', 'FechaCarga', 'Relacion', 'PersonaCarga', 'Pertenece', 'Asunto', 'ReferenteMDS', 'Seguimiento', 'Resultado', 'FechaDelResultado', 'ReferenteRtaMDS']
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
                ReferenteDeLaRespuestaMDSField = $('#ReferenteRtaMDS-field'),

                addBtn = $('#add-btn'),
                editBtn = $('#edit-btn').hide(),
                removeBtns = $('.remove-item-btn'),
                editBtns = $('.edit-item-btn');

                 // Sets callbacks to the buttons in the list
                 refreshCallbacks();
                 clearFields();

                 addBtn.click(function () {
                     //var observacion_nueva;
                     if (!(ValidarCamposVacios())) {
                         return false;
                     }

                     contactList.add({
                         id: 0,
                         FechaCarga: FechaCargaField.val(),
                         Relacion: RelacionField.val(),
                         PersonaCarga: PersonaCargaField.val(),
                         Pertenece: PerteneceField.val(),
                         Asunto: AsuntoField.val(),
                         ReferenteMDS: ReferenteMDSField.val(),
                         Seguimiento: SeguimientoField.val(),
                         Resultado: ResultadoField.val(),
                         FechaDelResultado: FechaDelResultadoField.val(),
                         ReferenteRtaMDS: ReferenteDeLaRespuestaMDSField.val()
                     });

                     idField.val(0);

                     AgregarObservacionAGrilla();

                     GuardarObservacion();

                     $(".modal_close").click();
                     clearFields();
                     refreshCallbacks();
                 });

                 ArmarObservacion = function () {
                     observacion_nueva =
                            {
                                id: idField.val(),
                                FechaCarga: FechaCargaField.val(),
                                Relacion: RelacionField.val(),
                                PersonaCarga: PersonaCargaField.val(),
                                Pertenece: PerteneceField.val(),
                                Asunto: AsuntoField.val(),
                                ReferenteMDS: ReferenteMDSField.val(),
                                Seguimiento: SeguimientoField.val(),
                                Resultado: ResultadoField.val(),
                                FechaResultado: FechaDelResultadoField.val(),
                                ReferenteRespuestaMDS: ReferenteDeLaRespuestaMDSField.val()
                            };
                     return observacion_nueva;
                 }

                 ValidarCamposVacios = function () {
                     if (FechaCargaField.val() == "" || FechaCargaField.val() == "FechaCarga") {
                         alertify.alert("Complete el campo fecha de carga");
                         return false;
                     }
                     return true;
                 };

                 AgregarObservacionAGrilla = function () {
                     PlanillaObservaciones.CargarObjetoSinDibujar(ArmarObservacion());
                     //PlanillaObservaciones.DibujarEn(contenedorPlanilla);
                 }

                 QuitarObservacionAGrilla = function () {
                     PlanillaObservaciones.QuitarObjeto(PlanillaObservaciones, ArmarObservacion());
                     //PlanillaObservaciones.DibujarEn(contenedorPlanilla);
                 }

                 editBtn.click(function () {
                     var item = contactList.get('id', idField.val());
                     var observacion_vieja = PlanillaObservaciones.buscarObjetoPorId(idField.val());
                     PlanillaObservaciones.QuitarObjetoSinDibujar(observacion_vieja);
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
                         ReferenteRtaMDS: ReferenteDeLaRespuestaMDSField.val()
                     });
                     PlanillaObservaciones.CargarObjetoSinDibujar(ArmarObservacion());

                     GuardarObservacion();

                     $(".modal_close").click();
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
                         var obj = PlanillaObservaciones.buscarObjetoPorId(itemId);
                         PlanillaObservaciones.QuitarObjetoSinDibujar(obj);
                         GuardarObservacion();
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
                         ReferenteDeLaRespuestaMDSField.val(itemValues.ReferenteRtaMDS);

                         editBtn.show();
                         addBtn.hide();

                         $("#btnObservacion").click();
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

                 $("#BtnImprimir").click(function () {
                     var w = window.open();

                     w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap.css' type='text/css' />");
                     w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap-responsive.css' type='text/css' />");
                     w.document.write("<link  rel='stylesheet' href='../Estilos/Estilos.css' type='text/css'  />");
                     w.document.write("<link  rel='stylesheet' href='EstilosSACC.css' type='text/css'  />");
                     w.document.write("<style>div_print{margin:20px;}.text_2caracteres{max-width: 20px;margin-left: 3px;}.text_10caracteres{max-width: 100px;margin-left: 17px;}</style>");
                     //w.document.write("<div class='div_print'><br>Curso: " + $("#CmbCurso option:selected").text() + "<br><br></div>");
                     w.document.write(contenedorPlanilla.html());
                     w.print();
                     //w.close();
                 });
             }

    </script>
   
</html>
