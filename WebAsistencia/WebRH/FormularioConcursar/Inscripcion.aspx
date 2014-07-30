<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inscripcion.aspx.cs" Inherits="FormularioConcursar_Inscripcion" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/FormularioConcursar/MenuConcursar.ascx" TagName="BarraMenuConcursar" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />

</head>
<body>
    <form id="form1" runat="server" class="cmxform">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar" >

       <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />
    
        <div class="fondo_form" style="padding: 10px;">
            <div id = "cont_titulo">
                <p>Usted est&aacute; por inscribirse para concursar al cargo de:</p>
            </div>
            <hr />
            <div id="puesto_cuadro" class = "cont_detalles_cargo">
            <table>
                <tr>
                    <td>        
                        <label class ="titulo_cargo">N° Central de Oferta de empleo:</label>   
                        <td>
                            <label id="puesto_numero" class = "detalle_cargo">2013-001234-MDS-G-SI-0-A</label>
                        </td>  
                    </td>
                    <td>
                        <label class="titulo_cargo">Entidad Convocante:</label>        
                        <td>
                            <label id="puesto_convocante" class = "detalle_cargo"></label>
                        </td>
                    </td>
                </tr>
                <tr>
                  <td>
                        <label class = "titulo_cargo">Denominaci&oacute;n del puesto:</label>          
                        <td>
                            <label id="puesto_denominacion" class="detalle_cargo"></label>
                        </td>
                        <td>
                            <label class="titulo_cargo">Secretar&iacute;a/SubSecretar&iacute;a:</label>     
                            <label id="puesto_secretaria" class="detalle_cargo"> </label>
                         </td>
                  </td>
                </tr>
                <tr>
                    <td>
                        <label class ="titulo_cargo">Agrupamiento:</label> 
                        <td>
                            <label id="puesto_agrupamiento" class="detalle_cargo"></label>
                        </td>
                    </td>
                    <td>                      
                        <label class="titulo_cargo">Direcci&oacute;n Nacional/General o Equivalente:</label>  
                        <td>
                            <label id="puesto_cargo" class="detalle_cargo"></label>   
                        </td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="titulo_cargo">Tipo de convocatoria:</label> 
                        <td>
                            <label id="puesto_convocatoria" class="detalle_cargo"></label>
                        </td>
                    </td>
                    <td>
                        <label class = "titulo_cargo">Unidad Destino:</label>    
                        <td>  
                            <label id="puesto_destino" class="detalle_cargo"></label>       
                        </td>
                    </td>
                </tr>
                <tr>
                    <td>  
                        <label class = "titulo_cargo">Nivel escalafonario:</label>  
                        <td>
                            <label id="puesto_nivel" class="detalle_cargo"></label>
                        </td>
                  </td>
              </tr>
            </table>
            </div>
            <div id = "cont_titulo_completar_informacion">
                <p>Es deseable que complete la siguiente informaci&oacute;n:</p>
            </div>
            <hr />
            <div id = "cont_info_a_completar">
               <label>Motivo de la postulaci&oacute;n</label>
                <textarea id="txt_motivo" rows="2" cols="80"></textarea>
            </div>
            <div id="cont_info_a_completar_2">
                <label>Observaciones</label>
                <textarea id="txt_observaciones" rows="2" cols="80"></textarea>
            </div>
            <hr />

            <div>
                <p class="subtitulo_incripcion" >Documentaci&oacute;n a presentar: Verifique que la misma est&eacute; completa, podr&aacute; imprimirla una vez confirmada la postulaci&oacute;n:</p>
            </div>
            <hr />
            <div id="cont_aclaraciones">
                <p class="aclaraciones">
                        1) "Formulario de Solicitud y Ficha de Inscripci&oacute;n"-ANEXO I- debidamente completado, los datos all&iacute; volcados presentan car&aacute;cter de declaraci&oacute;n jurada. El formulario debe ser firmado en todas sus hojas. <span class="vista_preliminar">[vista preliminar]</span><br/>
                        2) Se deber&aacute; adjuntar un curr&iacute;culum vitae actualizado, firmado en todas sus hojas. <br/>
                        3) "Constancia de Recepción y Aceptación del Reglamento y Bases del Concurso". Declaración Jurada que obra como ANEXO II - <span class="vista_preliminar">[vista preliminar]</span><br/>
                        4) "Constancia de Recepción de la Solicitud, Ficha de Inscripción y de la Documentación presentada.", que obra como ANEXO III - <span class="vista_preliminar">[vista preliminar]</span> <br/>
                        5) Certificados de estudios formales y de la documentación que respalde toda otra información volcada en el Formulario "Solicitud y Ficha de Inscripción". Original y fotocopia. Los postulantes que no estén encuadrados en el Sistema Nacional de Empleo Público deberán adjuntar, además: <br/>
                        6) DOS (2) fotografías recientes tipo carné, tamaño 4x4 cm. <br/>
                        7) Fotocopia de las DOS (2) primeras hojas del DNI y de la hoja donde figure el domicilio actualizado. <br/>
                </p>
                <br />
                <p class="subtitulo_incripcion" >Declaro bajo juramento que:</p>
                <p class="aclaraciones">
                    a) los datos consignados en la presente Solicitud y Ficha de Inscripción son completos, verdaderos y atinentes al perfil del puesto de trabajo o función a concursar; <br />
                    b) que los certificados, fotocopias y demás documentación entregada es autentica o copia fiel de sus respectivos originales; <br />
                    c) que los certificados, fotocopias y demás documentación entregada es autentica o copia fiel de sus respectivos originales; <br />
                    d) que los certificados, fotocopias y demás documentación entregada es autentica o copia fiel de sus respectivos originales; <br />
                    e) que los certificados, fotocopias y demás documentación entregada es autentica o copia fiel de sus respectivos originales; <br />
                    f) que los certificados, fotocopias y demás documentación entregada es autentica o copia fiel de sus respectivos originales; <br />
                    g) que los certificados, fotocopias y demás documentación entregada es autentica o copia fiel de sus respectivos originales; <br />
                    h) que los certificados, fotocopias y demás documentación entregada es autentica o copia fiel de sus respectivos originales; <br />
                </p>
                <p class="aclaraciones"><input id="chk_bases" type="checkbox" />He leído y acepto las Bases y Condiciones del Concurso al que me postulo</p>
                <a style="margin-right: 10px;" class="btn btn-primary" href="#">Cancelar</a>
                <input type="button" class="btn btn-primary" id="btn_postularse" value="Confirmar Postulación" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="puesto" runat="server" />
    </form>
</body>
 <script type="text/javascript" src="Postulacion.js" ></script>
 <%= Referencias.Javascript("../") %>

  <script type="text/javascript">

      $(document).ready(function () {
          var puesto = JSON.parse($('#puesto').val());

          Postulacion.armarPostulacion(puesto);
          
      });


  </script>


</html>
