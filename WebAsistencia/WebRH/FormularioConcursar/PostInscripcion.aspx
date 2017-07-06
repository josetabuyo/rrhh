<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostInscripcion.aspx.cs" Inherits="FormularioConcursar_Inscripcion" %>
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

</head>
<body>
    <form id="form1" runat="server" class="cmxform">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar" >

       <uc3:BarraMenuConcursar ID="BarraMenuConcursar1" runat="server" />

        <div id="zonaImprimible" class="fondo_form" style="padding: 10px;">
            <%--<div id = "cont_titulo">
                <p>Para completar su pre-inscripción debe imprimir los Anexos I, II y III </p>
            </div>--%>
            <h2 style="text-align: center;">Postulación Finalizada Correctamente</h2>
            <br />
            <h4>Número de Postulación: <%=Request.QueryString["num"] %></h4>
            <h4>Informes de GDE: <%=Request.QueryString["gde"] %></h4>
            <hr />
            <div id="puesto_cuadro" class = "cont_detalles_cargo">
            <table>
                <tr>
                   <%-- <td>        
                        <label style="font-weight: 100;" class ="titulo_cargo">N° Central de Oferta de empleo:</label>   
                        <td>
                            <label id="puesto_numero" class = "detalle_cargo"></label>
                        </td>  
                    </td>--%>
                    <td>
                        <label style="font-weight: 100;" class="titulo_cargo">Entidad Convocante:</label>        
                        <td>
                            <label id="puesto_convocante" class = "detalle_cargo"></label>
                        </td>
                    </td>
                    <td>
                        <label style="font-weight: 100; padding-left: 10px;" class = "titulo_cargo">Denominaci&oacute;n del puesto:</label>          
                        <td>
                            <label style="padding-left: 5px;" id="puesto_denominacion" class="detalle_cargo"></label>
                        </td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="font-weight: 100; display: inline;" class="titulo_cargo">Secretar&iacute;a/SubSecretar&iacute;a:</label>
                        <td>     
                            <label style="display: inline;" id="puesto_secretaria" class="detalle_cargo"> </label>
                        </td>
                      </td>
                       <td>
                        <label style="font-weight: 100; padding-left: 10px;" class ="titulo_cargo">Agrupamiento:</label> 
                        <td>
                            <label style="padding-left: 5px;" id="puesto_agrupamiento" class="detalle_cargo"></label>
                        </td>
                    </td>
                </tr>
                <tr>
                    <td>                      
                        <label style="font-weight: 100; " class="titulo_cargo">Direcci&oacute;n Nacional/General o Equivalente:</label>  
                        <td>
                            <label style="padding-left: 5px;" id="puesto_cargo" class="detalle_cargo"></label>   
                        </td>
                    </td>
                     <td>
                        <label style="font-weight: 100; padding-left: 10px;" class="titulo_cargo">Tipo de convocatoria:</label> 
                        <td>
                            <label style="padding-left: 5px;" id="puesto_convocatoria" class="detalle_cargo"></label>
                        </td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label style="font-weight: 100; " class = "titulo_cargo">Unidad Destino:</label>    
                        <td>  
                            <label style="padding-left: 5px;" id="puesto_destino" class="detalle_cargo"></label>       
                        </td>
                    </td>
                     <td>  
                        <label style="font-weight: 100; padding-left: 10px;" class = "titulo_cargo">Nivel escalafonario:</label>  
                        <td>
                            <label style="padding-left: 5px;" id="puesto_nivel" class="detalle_cargo"></label>
                        </td>
                  </td>
                </tr>
            </table>
            </div>
           
            <hr />
             <div id = "cont_titulo_completar_informacion">
                <p><b>Documentación a presentar</b></p>
            </div>
            <div id="cont_aclaraciones">
            <p class="aclaraciones">Una vez completada la postulación, tenés que acercarte con TODA la documentación ORIGINAL de respaldo al edificio de la calle Alsina 1886 de esta Ciudad Autónoma de Buenos Aires de 10.00hs. a 16.00hs. en los días que se establezcan para la Inscripción Documental, oportunidad en la que los agentes de registro certificarán su validez con respecto a los originales presentados.</p>
             
             
              <%--  <p class="aclaraciones">
                        1) "Formulario de Solicitud y Ficha de Inscripci&oacute;n"-ANEXO I- debidamente completado, los datos all&iacute; 
                        volcados presentan car&aacute;cter de declaraci&oacute;n jurada. El formulario debe ser firmado en todas sus 
                        hojas. <input style="width: 60px; display:block; float:right;" id="anexo_1" class="btn btn-primary" value="Anexo I" /><br/><br/>
                        2) Se deber&aacute; adjuntar un curr&iacute;culum vitae actualizado, firmado en todas sus hojas. <br/><br/>
                        3) "Constancia de Recepción y Aceptación del Reglamento y Bases del Concurso". Declaración Jurada que obra como 
                        ANEXO II<input style="width: 60px; display:block; float:right;" id="anexo_2" class="btn btn-primary"  value="Anexo II" /><br/><br/>
                        4) "Constancia de Recepción de la Solicitud, Ficha de Inscripción y de la Documentación presentada.", que obra como 
                        ANEXO III<input style="width: 60px; display:block; float:right;" id="anexo_3" class="btn btn-primary" value="Anexo III" /> <br/>
                       
                </p>--%>
                 </div>

            </div>
                <br />
                <div style="text-align:center;">
                    <input type="button" class="btn btn-primary" id="imprimir" value="Imprimir" />
                    <input type="button" class="btn" id="home" value="Volver a Inicio" />
                    
                </div>
                
           
       
    </div>
    <asp:HiddenField ID="perfil" runat="server" />
    </form>
</body>
 <script type="text/javascript" src="Postulacion.js" ></script>
 <%= Referencias.Javascript("../") %>

  <script type="text/javascript">

      $(document).ready(function () {
          var perfil = JSON.parse($('#perfil').val());

          Postulacion.armarPostulacion(perfil);

          $('#anexo_1').click(function () {
              window.open('AnexoI.aspx?id=<%=Request.QueryString["id"] %>&fh=<%=Request.QueryString["fh"] %>');
              //window.location.href = 'AnexoI.aspx';

          });

          $('#anexo_2').click(function () {
              window.open('AnexoII.aspx?id=<%=Request.QueryString["id"] %>&fh=<%=Request.QueryString["fh"] %>');
              //window.location.href = 'AnexoII.aspx';
          });

          $('#anexo_3').click(function () {
              window.open('AnexoIII.aspx?id=<%=Request.QueryString["id"] %>&fh=<%=Request.QueryString["fh"] %>');
              //window.location.href = 'AnexoIII.aspx';
          });

          $('#todos_anexos').click(function () {
              window.open('AnexoI.aspx?id=<%=Request.QueryString["id"] %>&fh=<%=Request.QueryString["fh"] %>');
              window.open('AnexoII.aspx?id=<%=Request.QueryString["id"] %>&fh=<%=Request.QueryString["fh"] %>');
              window.open('AnexoIII.aspx?id=<%=Request.QueryString["id"] %>&fh=<%=Request.QueryString["fh"] %>');
              //window.location.href = 'AnexoIII.aspx';
          });

          $('#imprimir').click(function () {
              var printContents = $('#zonaImprimible').html();
              var originalContents = document.body.innerHTML;

              document.body.innerHTML = printContents;

              window.print();

              document.body.innerHTML = originalContents;

          });
         

          $('#home').click(function () {
              window.location.href = 'PanelDeControl.aspx';
          });

      });



  </script>


</html>
