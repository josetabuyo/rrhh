<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Caratula.aspx.cs" Inherits="FormularioConcursar_Caratula" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>  
    <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
     <div style="width:80%; margin-left:10%;" class="">
        <div style=" text-align:left;" class="">
           <%-- <p style="float:left;" class="">Postulación Nº: <span id="num_postulacion"></span></p>--%>
           <%-- <p style="float:right;">Carátula</p>--%>
            <div style="clear:both;"></div>
            <p class="encabezado">CARÁTULA PARA SOBRE</p>

        
        </div>
    
    <div>
        <label class="label_caratula" >LLAMADO: <span id ="span_llamado"></span> </label>
        <br /><br />
        <label class="label_caratula">PERFIL: <span id ="span_perfil"></span></label>
         <br /><br />
        <label class="label_caratula">COMITÉ: <span id ="span_comite"></span></label>
         <br /><br />
        <label class="label_caratula">POSTULANTE: <span id ="span_postulante"></span></label>
         <br /><br />
        <label class="label_caratula">RECEPCIONÓ: <span id ="span_recepcion"></span></label>
    </div>

      <br /><br />
        <br /><br />
         
    <div>
            <table border="border-collapse: collapse" style="border-collapse: collapse" class="pie-caratula">
            <tr>
              <th class="td-caratula">TAREA</th>
              <th class="td-caratula">RESPONSABLE</th> 
              <th class="td-caratula">&nbsp;&nbsp;FECHA&nbsp;&nbsp;</th>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
              <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr> 
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
             <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
             <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
             <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>
            <tr>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
                <td class="td-caratula"></td>
            </tr>

           
           <%-- <td class="td-pie-tabla"><span class="letra-bold">Fecha de Inscripción</span></td>
            <td class="td-pie-tabla"><span class="letra-bold">Firma y Aclaración del Inscripto o Apoderado</span></td>--%>
           
            </table>
           
           <%-- <p class="p-imprimir"><button class="btn btn-primary" onclick="ImprimirCVPostulado()">Imprimir</button></p>--%>
    </div>	



    </div>

        

    </div>
    </form>
</body>

<%= Referencias.Javascript("../") %>
<script type="text/javascript" src="FichaDeclaracionJurada.js" ></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>

<script type="text/javascript">
    Backend.start();

//    function ImprimirCVPostulado() {
//        //var html = $('#form1').context.body.innerHTML;
//        //$('#pagina').val(html);
//        //window.print();
//    }

    $(document).ready(function () {

        var usuario = "";
        $.ajax({
            url: "../AjaxWS.asmx/GetUsuario",
            type: "POST",
            //data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
                document.getElementById("span_recepcion").innerHTML = respuestaJson.d;

                usuario = respuestaJson.d;



            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });




        document.getElementById("span_recepcion").innerHTML = usuario;
        document.getElementById("span_postulante").innerHTML = localStorage.getItem("empleado");
        document.getElementById("span_perfil").innerHTML = localStorage.getItem("perfil");
        document.getElementById("span_comite").innerHTML = localStorage.getItem("comite");


        setTimeout(
  function () {
      window.print();
  }, 100);
       
    });


</script>

</html>
