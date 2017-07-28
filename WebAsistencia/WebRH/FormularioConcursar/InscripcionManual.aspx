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
        <div id="contenedor_inscripcion_manual" style="width:80%; margin-left:10%;" class="">
            <div style="width: 100%; text-align:left;" class="">
                <p style="float:left;">Número Postulación: <span id="numero_postulacion"></span></p>
               
                <div style="clear:both;"></div>
                <%--<p class="encabezado" style="font-size:20px; margin-bottom:1%">SISTEMA NACIONAL DE EMPLEO PUBLICO (Decreto N° 2098/08)</p>--%>
                <%--<p class="encabezado"style="font-size:20px; margin-bottom:1%">FORMULARIO DE INSCRIPCION MANUAL</p>--%>
                <%--<p class="">Quien suscribe la presente, solicita ser inscripto para concursar el cargo cuyos datos figuran en el presente Formulario</p>--%>
                <p>Seleccione el perfil a inscribirse: <select id="combo_perfiles" style="width:100%; font-size:0.8em;"><option value="0">Seleccione un Perfil</option></select></p>
                <p>Elija la Modalidad de Inscripción: <br /> <select id="combo_modalidad"></select></p>
            </div>

        <table class="tabla_anexo_1">
           <%-- <tr >
                <td colspan="2" class="celda">N° DEL REGISTRO CENTRAL DE OFERTAS DE EMPLEO</td>
                <td id="numero_de_oferta" colspan="2" class="celda"></td>
            </tr>--%>
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
                <td id="domicilio_personal" colspan="2" class="celda">
                    <input id="text_domicilio_calle_personal" type="text" placeholder="Calle" class="validar" />
                    <input id="text_domicilio_nro_personal" type="number" placeholder="Nro" style="width: 40px;" class="validarNumero" />
                    <input id="text_domicilio_piso_personal" type="number" placeholder="Piso" style="width: 40px;" class="validarNumero" />
                    <input id="text_domicilio_depto_personal" type="text" placeholder="Depto" style="width: 40px;" class="validar" />
                    <input id="text_domicilio_cp_personal" type="text" placeholder="C.P." style="width: 40px;" class="validar" />
                    <select id="cmb_provincia_personal" class="cmb_provincia" ></select>
                    <select id="cmb_localidad_personal" class="cmb_localidad" > </select>
                
                </td>
            </tr>
            <tr >
                <td style="text-align:center;" colspan="4" class="celda">INFORMACION REQUERIDA PARA RECIBIR NOTIFICACIONES Y AVISOS</td>
            </tr>
            <tr >
                <td id="domicilio_legal" colspan="2" class="celda">DOMICILIO: </td>
                <td colspan="2" class="celda">
                    <input id="text_domicilio_calle_legal" type="text" placeholder="Calle" class="validar" />
                    <input id="text_domicilio_nro_legal" type="number" placeholder="Nro" style="width: 40px;" class="validarNumero" />
                    <input id="text_domicilio_piso_legal" type="number" placeholder="Piso" style="width: 40px;" class="validarNumero" />
                    <input id="text_domicilio_depto_legal" type="text" placeholder="Depto" style="width: 40px;" class="validar" />
                    <input id="text_domicilio_cp_legal" type="text" placeholder="C.P." style="width: 40px;" class="validar" />     
                    <select id="cmb_provincia_legal" class="cmb_provincia" ></select>
                    <select id="cmb_localidad_legal" class="cmb_localidad"> </select>
                </td>
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
                <td colspan="1" class="celda"><input id="text_folio_ficha_inscripcion" type="number" placeholder="Folio Ficha" maxlength="3" class="validarNumero" /></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FOTOGRAFIA TIPO CARNET</td>
                <td colspan="1" class="celda"><input id="text_folio_foto_carnet" type="number" placeholder="Folio Foto" maxlength="1" class="validarNumero" /></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FOTOCOPIA DEL DNI (con domicilio actualizado)</td>
                <td colspan="1" class="celda"><input id="text_folio_dni" type="number" placeholder="Folio DNI" maxlength="1" class="validarNumero"/></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">FOTOCOPIA DEL TITULO ACADEMICO EXIGIDO</td>
                <td colspan="1" class="celda"><input id="text_folio_titulo" type="number" placeholder="Folio Título" maxlength="2" class="validarNumero" /></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">CURRICULUM VITAE OPCIONAL</td>
                <td colspan="1" class="celda"><input id="text_folio_cv" type="number" placeholder="Folio CV" maxlength="3" class="validarNumero" /></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">DOCUMENTACIÓN DE RESPALDO</td>
                <td colspan="1" class="celda"><input id="text_folio_respaldo" type="number" placeholder="Folio Respaldo" maxlength="3" class="validarNumero" /></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">N° de INFORME GRÁFICO DEL SISTEMA GDE</td>
                <td colspan="1" class="celda">
                    <span id="cajaDeInformesGraficos">
                        <input class="informesGraficos" type="text" placeholder="N° Informe" id="informeGrafico_00" />
                    </span>
                    <input type=button class="btn btn-primary" onclick="agregarInforme()" value="Agregar otro INFORME" />
                </td>
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
            <input id="btn_imprimir" class="btn btn-primary" type="button" value="Imprimir" onclick="PrintElem()" style="display:none;" />
        </div>
    </div>
    </div>
   
   
   
    </form>
</body>
 <script type="text/javascript" src="Perfil.js" ></script>
  <script type="text/javascript" src="InscripcionManual.js" ></script>
 
 <%= Referencias.Javascript("../") %>

  <script type="text/javascript">

      function PrintElem() {
          var mywindow = window.open('', 'Formulario', 'height=600,width=800');
          mywindow.document.write('<html><head><title>Formulario Inscripción Manual</title><style type="text/css">.celda { border: 2px double #000; padding:3px; }.tabla_anexo_1 {font-size:0.6em;width:100%;}</style>');
          /*mywindow.document.write('<link rel="stylesheet" href="EstilosPostular.css" type="text/css" />');*/
          mywindow.document.write('</head><body >');
          mywindow.document.write($('#contenedor_inscripcion_manual').html());

          mywindow.document.getElementById('btn_imprimir').style.display = 'none';
          mywindow.document.getElementById('btn_inscripcion_manual').style.display = 'none';
          mywindow.document.getElementById('combo_perfiles').value = $('#combo_perfiles').val();
          mywindow.document.getElementById('text_fecha_inscripcion').value = $('#text_fecha_inscripcion').val();
          mywindow.document.getElementById('text_dni_inscriptor').value = $('#text_dni_inscriptor').val();
          mywindow.document.getElementById('combo_modalidad').value = $('#combo_modalidad').val();

          mywindow.document.getElementById('text_nombre').value = $('#text_nombre').val();
          mywindow.document.getElementById('text_apellido').value = $('#text_apellido').val();
          mywindow.document.getElementById('text_dni').value = $('#text_dni').val();
          mywindow.document.getElementById('text_domicilio_calle_personal').value = $('#text_domicilio_calle_personal').val();
          mywindow.document.getElementById('text_domicilio_nro_personal').value = $('#text_domicilio_nro_personal').val();
          mywindow.document.getElementById('text_domicilio_piso_personal').value = $('#text_domicilio_piso_personal').val();
          mywindow.document.getElementById('text_domicilio_depto_personal').value = $('#text_domicilio_depto_personal').val();
          mywindow.document.getElementById('text_domicilio_cp_personal').value = $('#text_domicilio_cp_personal').val();
          mywindow.document.getElementById('cmb_provincia_personal').value = $('#cmb_provincia_personal').val();
          mywindow.document.getElementById('cmb_localidad_personal').value = $('#cmb_localidad_personal').val();
          mywindow.document.getElementById('text_domicilio_calle_legal').value = $('#text_domicilio_calle_legal').val();
          mywindow.document.getElementById('text_domicilio_nro_legal').value = $('#text_domicilio_nro_legal').val();
          mywindow.document.getElementById('text_domicilio_piso_legal').value = $('#text_domicilio_piso_legal').val();
          mywindow.document.getElementById('text_domicilio_depto_legal').value = $('#text_domicilio_depto_legal').val();
          mywindow.document.getElementById('text_domicilio_cp_legal').value = $('#text_domicilio_cp_legal').val();
          mywindow.document.getElementById('cmb_localidad_personal').value = $('#cmb_localidad_personal').val();
          mywindow.document.getElementById('cmb_provincia_legal').value = $('#cmb_provincia_legal').val();

          mywindow.document.getElementById('text_telefono').value = $('#text_telefono').val();
          mywindow.document.getElementById('text_mail').value = $('#text_mail').val();
          mywindow.document.getElementById('text_folio_ficha_inscripcion').value = $('#text_folio_ficha_inscripcion').val();
          mywindow.document.getElementById('text_folio_foto_carnet').value = $('#text_folio_foto_carnet').val();
          mywindow.document.getElementById('text_folio_dni').value = $('#text_folio_dni').val();
          mywindow.document.getElementById('text_folio_titulo').value = $('#text_folio_titulo').val();
          mywindow.document.getElementById('text_folio_cv').value = $('#text_folio_cv').val();
          mywindow.document.getElementById('text_folio_respaldo').value = $('#text_folio_respaldo').val();
          mywindow.document.getElementById('informeGrafico_00').value = $('#informeGrafico_00').val();

          mywindow.document.write('</body></html>');

          mywindow.document.close(); // necessary for IE >= 10
          mywindow.focus(); // necessary for IE >= 10

          mywindow.print();
          mywindow.close();

          return true;
      }


      $(document).ready(function () {
         

          Backend.start(function () {

              InscripcionManual.iniciar();

          });
      });

      var nextinput = 0;
      function agregarInforme() {
          nextinput++;
          campo = '<input class="informesGraficos" type="text" id="informeGrafico_0' + nextinput + '" />';
          $("#cajaDeInformesGraficos").append(campo);
      }
    
  </script>


</html>
