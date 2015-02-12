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
        <label class="label_caratula" >LLAMADO:</label> <span id ="span_llamado"></span> 
        <br /><br />
        <label class="label_caratula">PERFIL:</label> <span id ="span_perfil"></span>
         <br /><br />
        <label class="label_caratula">COMITÉ: </label><span " id ="span_comite"></span>
         <br /><br />
        <label class="label_caratula">POSTULANTE: </label><span id ="span_postulante"></span>
         <br /><br />
        <label class="label_caratula">RECEPCIONÓ:</label> <span id ="span_recepcion"></span>
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

        //var usuario = "";
        $.ajax({
            url: "../AjaxWS.asmx/GetUsuario",
            type: "POST",
            //data: data,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (respuestaJson) {
              
                usuario = respuestaJson.d;



                var fullName = usuario.split(' ');
                var nombre = fullName[0];
                var apellido = fullName[fullName.length - 1];

              //  document.getElementById("span_recepcion").innerHTML = respuestaJson.d;
                document.getElementById("span_recepcion").innerHTML = nombre.toUpperCase() +" " + apellido; // localStorage.getItem("usuario"); // usuario;

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert(errorThrown);
            }
        });


        //   setTimeout(


        //var usuario = localStorage.getItem("usuario");
     
//        var fullName = usuario.split(' ');
//        var nombre = fullName[0];
//        var apellido = fullName[fullName.length - 1];


        //        var fullName = "Paul Steve Panakkal".split(' '),
        //    firstName = fullName[0],
        //    lastName = fullName[fullName.length - 1];



        document.getElementById("span_postulante").innerHTML = localStorage.getItem("empleado");
        document.getElementById("span_perfil").innerHTML = localStorage.getItem("perfil");
        document.getElementById("span_comite").innerHTML = localStorage.getItem("comite");
       // document.getElementById("span_recepcion").innerHTML = nombre + " " + apellido; // localStorage.getItem("usuario"); // usuario;




        setTimeout(
  function () {
      window.print();
  }, 500);

    });


</script>

</html>
