<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InscripcionManual.aspx.cs" Inherits="FormularioConcursar_Inscripcion" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar" TagPrefix="uc3" %>
<%@ Register Src="~/FormularioConcursar/Pasos.ascx" TagName="Pasos" TagPrefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
      <style type="text/css">
        .celda {
            border: 3px double #000;
            padding:3px;
        }
        
        .tabla_anexo_1 
        {
            font-size:1.1em;
            width:100%;
            }
            
      
     
     </style>
</head>
<body>
    <form id="form1" runat="server" class="cmxform">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    
    <div class="contenedor_concursar" >
       <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />     
        <div id = "cont_titulo">
            <h1>Inscripción Manual</h1>
        </div>
            <hr />
        <div style="width:80%; margin-left:10%;" class="">
            <div style="width: 100%; text-align:left;" class="">
                <p style="float:left;" class="">Postulación Nº: <span id="num_postulacion"></span></p>
                <p style="float:right;">ANEXO I</p>
                <div style="clear:both;"></div>
                <p class="encabezado" style="font-size:20px; margin-bottom:1%">SISTEMA NACIONAL DE EMPLEO PUBLICO (Decreto N° 2098/08)</p>
                <p class="encabezado"style="font-size:20px; margin-bottom:1%">FORMULARIO DE SOLICITUD Y FICHA DE INSCRIPCION N°</p>
                <p class="">Quien suscribe la presente, solicita ser inscripto para concursar el cargo cuyos datos figuran en el presente Formulario</p>
                <p>Seleccione el perfil a inscribirse: <select id="combo_perfiles" style="width:70%;">
                    
                </select></p>
                <p>Elija la Modalidad de Inscripción: <select id="combo_modalidad">
                    <option value="1">Correo</option>
                    <option value="2">Formulario</option>
                </select></p>
            </div>

        <table class="tabla_anexo_1">
            <tr >
                <td colspan="2" class="celda">N° DEL REGISTRO CENTRAL DE OFERTAS DE EMPLEO</td>
                <td id="numero_de_oferta" colspan="2" class="celda"></td>
            </tr>
            <tr>
                <td colspan="2" class="celda">DENOMINACION DEL CARGO A CUBRIR</td>
                <td id="puesto_denominacion" colspan="2" class="celda"></td>
            </tr>
            <tr>
                <td class="celda">AGRUPAMIENTO</td>
                <td id="puesto_agrupamiento" class="celda validarTexto"></td>
                <td class="celda">TIPO DE CONVOCATORIA</td>
                <td id="puesto_tipo" class="celda validarTexto"></td>
            </tr>
            <tr>
                <td class="celda">NIVEL ESCALAFONARIO</td>
                <td id="nivel_escalafonario" class="celda validarTexto"></td>
                <td class="celda">NIVEL DE JEFATURA</td>
                <td id="nivel_jefatura" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">JURISDICCION/ENTIDAD DESCENTRALIZADA</td>
                <td id="jurisdiccion" colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">SECRETARIA/SUBSECRETARIA</td>
                <td id="secretaria" colspan="2" class="celda"> </td>
            </tr>
            <tr >
                <td colspan="2" class="celda">DIRECCION NACIONAL/GENERAL O EQUIVALENTE</td>
                <td id="direccion" colspan="2" class="celda"> </td>
            </tr>
            <tr >
                <td colspan="2" class="celda">DIRECCION</td>
                <td id="domicilio_lugar_de_trabajo" colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">APELLIDO Y NOMBRES DEL INSCRIPTO</td>
                <td id="apellido_y_nombre" colspan="2" class="celda"><input id="text_nombre" class="validar" type="text" placeholder="Nombre" /><input class="validar" id="text_apellido" type="text" placeholder="Apellido" /></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">TIPO Y NUMERO DE DOCUMENTO</td>
                <td id="documento" colspan="2" class="celda"><input id="text_dni" type="text" placeholder="DNI" class="validar" /></td>
            </tr>    
            <tr >
                <td colspan="2" class="celda">DOMICILIO DE RESIDENCIA PERSONAL</td>
                <td id="domicilio_personal" colspan="2" class="celda"><input id="text_domicilio" type="text" placeholder="Domicilio" class="validar" /></td>
            </tr>
            <tr >
                <td style="text-align:center;" colspan="4" class="celda">INFORMACION REQUERIDA PARA RECIBIR NOTIFICACIONES Y AVISOS</td>
            </tr>
            <tr >
                <td id="domicilio_legal" colspan="2" class="celda">DOMICILIO: </td>
                <td colspan="2" class="celda"><input id="text_domicilio_notificacion" type="text" placeholder="Domicilio" class="validar" /></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">TELEFONO/FAX:</td>
                <td id="telefono" colspan="2" class="celda"><input id="text_telefono" type="text" placeholder="Teléfono" class="validar" /></td>
            </tr>
            <tr >
                <td id="correo_electronico" colspan="2" class="celda">CORREO ELECTRONICO:</td>
                <td colspan="2" class="celda"> <input id="text_mail" type="text" placeholder="Mail" class="validar" /></td>
            </tr>
            <tr>
                <td id="mail" colspan="4" class="celda"></td>
            </tr>
            <tr>
                <td style="text-align:center;" colspan="3" class="celda">LISTADO DE LA DOCUMENTACION PRESENTADA</td>
                <td style="text-align:center;" colspan="1" class="celda">FOLIOS</td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FICHA DE INSCRIPCION</td>
                <td colspan="1" class="celda"><input id="text_folio_ficha_inscripcion" type="text" placeholder="Folio Ficha" maxlength="3" class="validar validarNumero" /></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FOTOGRAFIA TIPO CARNET</td>
                <td colspan="1" class="celda"><input id="text_folio_foto_carnet" type="text" placeholder="Folio Foto" maxlength="1" class="validar validarNumero" /></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FOTOCOPIA DEL DNI (con domicilio actualizado)</td>
                <td colspan="1" class="celda"><input id="text_folio_dni" type="text" placeholder="Folio DNI" maxlength="1" class="validar validarNumero"/></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FOTOCOPIA DEL TITULO ACADEMICO EXIGIDO</td>
                <td colspan="1" class="celda"><input id="text_folio_titulo" type="text" placeholder="Folio Título" maxlength="2" class="validar validarNumero" /></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">CURRICULUM VITAE OPCIONAL</td>
                <td colspan="1" class="celda"><input id="text_folio_cv" type="text" placeholder="Folio CV" maxlength="3" class="validar validarNumero" /></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">DOCUMENTACIÓN DE RESPALDO</td>
                <td colspan="1" class="celda"><input id="text_folio_respaldo" type="text" placeholder="Folio Respaldo" maxlength="3" class="validar validarNumero" /></td>
            </tr>
        </table>

        <div class="div-pie-tabla">
            <table border="border-collapse: collapse" style="border-collapse: collapse; height:50px; margin-top:10px;" class="pie-tabla" >
                <tr>
                    <td class="td-pie-tabla" ><span class="letra-bold" "><input id="text_fecha_inscripcion" type="text" placeholder="Fecha Inscripción" class="validarPie" /><br />Fecha de Inscripción</span></td>
                    <td class="td-pie-tabla" ><span class="letra-bold" "><input id="text_dni_inscriptor" type="text" placeholder="DNI Inscriptor" class="validarPie" /><br />DNI del Inscriptor</span></td>
                </tr>
            </table>
        </div>	
        <div style="text-align:center; margin-top:10px;">
            <input type="button" value="Inscribir" id="btn_inscripcion_manual" class="btn btn-primary" />
        </div>
    </div>

    </div>
   
   
   
    </form>
</body>
 <script type="text/javascript" src="Perfil.js" ></script>
 
 <%= Referencias.Javascript("../") %>

  <script type="text/javascript">
      Backend.start();

      $(document).ready(function () {
          Perfil.traerPerfiles();

          $('#text_fecha_inscripcion').datepicker();
          $('#text_fecha_inscripcion').datepicker('option', 'dateFormat', 'dd/mm/yy');

          $('#btn_inscripcion_manual').click(function () {

             // if (validar()) {

                  //var anonimoPerfil = {};
                  //anonimoPerfil.Id = $('#combo_perfiles').val();

                  var postulacionManual = {};
                  postulacionManual.Perfil = $('#combo_perfiles').val();
                  postulacionManual.FechaInscripcion = $('#text_fecha_inscripcion').val();
                  postulacionManual.DNIInscriptor = $('#text_dni_inscriptor').val();
                  postulacionManual.Modalidad = $('#combo_modalidad').val();


                  var datosPersonales = {};
                  datosPersonales.Nombre = $('#text_nombre').val();
                  datosPersonales.Apellido = $('#text_nombre').val();
                  datosPersonales.DNI = $('#text_dni').val();
                  datosPersonales.DomicilioPersonal = $('#text_domicilio').val();
                  datosPersonales.DomicilioNotificacion = $('#text_domicilio_notificacion').val();
                  datosPersonales.Telefono = $('#text_telefono').val();
                  datosPersonales.Mail = $('#text_mail').val();

                  var folio = {};
                  folio.FichaInscripcion = $('#text_folio_ficha_inscripcion').val();
                  folio.FotografiaCarnet = $('#text_folio_foto_carnet').val();
                  folio.FotocopiaDNI = $('#text_folio_dni').val();
                  folio.Titulo = $('#text_folio_titulo').val();
                  folio.CV = $('#text_folio_cv').val();
                  folio.DocumentacionRespaldo = $('#text_folio_respaldo').val();

                  var postulacionJSON = JSON.stringify(postulacionManual);
                  var datosPersonalesJSON = JSON.stringify(datosPersonales);
                  var folioJSON = JSON.stringify(folio);

                  Backend.ejecutar("GuardarPostulacionManual", [{ postulacion: postulacionManual }, { datosPersonales: datosPersonales }, { folio: folio}]);
             // }
          });

          function validar() {
              $('.validarTexto').each(function () {
                  if (this.textContent == '') {
                      alertify.error('Complete ' + this.previousElementSibling.textContent);
                      return false;
                  }
              });

              $('.validar').each(function () {
                  if (this.value == '') {
                      alertify.error('Complete ' + this.parentNode.previousElementSibling.textContent);
                      return false;
                  }
              });

              $('.validarNumero').each(function () {
                  if (isNaN(this.value)) {
                      alertify.error('El folio de ' + this.parentNode.previousElementSibling.textContent + ' debe ser un número.');
                      return false;
                  }
              });

              $('.validarPie').each(function () {
                  if (this.value == '') {
                      alertify.error('Complete ' + this.parentNode.textContent);
                      return false;
                  }
              });

              return true;
          }


      });

    
  </script>


</html>
