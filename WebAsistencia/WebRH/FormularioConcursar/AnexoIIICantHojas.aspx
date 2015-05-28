<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnexoIIICantHojas.aspx.cs" Inherits="FormularioConcursar_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
     <%= Referencias.Css("../")%>    

     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
     <style type="text/css">
        .celda {
            border: 3px double #000;
            padding:1px;
        }
        
        .celda_vacia 
        {
            padding:10px 0px;
            border: 3px double #000;
             text-align: right;
         }
        
        .tabla_anexo_1 
        {
            font-size:0.9em;
            width:100%;
            }
     
         .style1
         {
             border: 3px double #000;
             padding: 1px;
             width: 389px;
         }
     
         .style2
         {
             border: 3px double #000;
             padding: 3px;
             height: 39px;
         }
         .style3
         {
             padding: 15px 0px;
             border: 3px double #000;
             text-align: right;
             height: 39px;
         }
         .style4
         {
             border: 3px double #000;
             padding: 3px;
             height: 29px;
         }
         .style5
         {
             padding: 15px 0px;
             border: 3px double #000;
             text-align: right;
             height: 29px;
         }
         .style6
         {
             border: 3px double #000;
             padding: 3px;
             height: 31px;
         }
         .style7
         {
             padding: 15px 0px;
             border: 3px double #000;
             text-align: right;
             height: 31px;
         }
         .style8
         {
             border: 3px double #000;
             padding: 3px;
             height: 24px;
         }
         .style9
         {
             padding: 15px 0px;
             border: 3px double #000;
             text-align: right;
             height: 24px;
         }
         .style10
         {
             border: 3px double #000;
             padding: 3px;
             width: 47px;
         }
     
     </style>
</head>
<body>

    <form id="form1" runat="server">

<input type="hidden" id = "codigo_postu" runat = "server"/>
    
    <div style="width: 80%; margin-left:10%; height: 949px;" class="">
        <div style=" text-align:left;" class="">
            <p style="float:left;" class="">Postulación Nº:     <span id="num_postulacion"></span> <label class="">    RECEPCIONÓ:</label> <span id ="span_recepcion"></span> </p>
            <p style="float:right;">ANEXO III</p>
            <div style="clear:both; height: 5px;">
           <p style="float:left;" class=""></p></div>
            <p class="encabezado"style="font-size:18px; margin-bottom:1%;margin-top:1%">CONSTANCIA DE RECEPCIÓN DE LA SOLICITUD.
             <br />
             FICHA DE INSCRIPCIÓN Y DE LA DOCUMENTACIÓN PRESENTADA</p>
            <%--<p class="encabezado"style="font-size:20px; margin-bottom:1%;margin-top:1%"></p>--%>
        </div>
        <table class="tabla_anexo_1">
            <tr >
                <td colspan="2" class="celda">FICHA DE INSCRIPCIÓN Nº</td>
                <td colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">N° DEL REGISTRO CENTRAL DE OFERTAS DE EMPLEO</td>
                <td id="numero_de_oferta" colspan="2" class="celda"></td>
            </tr>
            <tr>
                <td colspan="2" class="celda">TIPO DE CONVOCATORIA</td>
                <td id="puesto_tipo" colspan="2" class="celda"></td>
            </tr>
            <tr>
                <td colspan="2" class="celda">DENOMINACION DEL CARGO A CUBRIR</td>
                <td id="puesto_denominacion" colspan="2" class="celda"></td>
            </tr>
            <tr>
                <td colspan="2" class="celda">AGRUPAMIENTO</td>
                <td id="puesto_agrupamiento" colspan="2" class="celda"></td>
            </tr>
            <tr>
                <td class="celda">NIVEL ESCALAFONARIO</td>
                <td id="nivel_escalafonario" class="style10"></td>
                <td class="style1">NIVEL DE JEFATURA</td>
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
                <td id="apellido_y_nombre" colspan="2" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">TIPO Y NUMERO DE DOCUMENTO</td>
                <td id="documento" colspan="2" class="celda"></td>
            </tr>    
            <tr><td colspan="4" class="celda"></td></tr>
            <tr>
                <td style="text-align:center;font-size:17px;" colspan="3" class="celda">LISTADO DOCUMENTACION PRESENTADA</td>
                <td style="text-align:center;font-size:17px;" colspan="1" class="celda"style="font-size:17px;">FOLIOS</td>
            </tr>
            <tr>
                <td colspan="3" class="style2" style="font-size:16px;">Ficha de Inscripci&oacute;n</td>
                <td colspan="1" class="style3"> <input type = "text" /></td>
            </tr>
            <tr>
                <td colspan="3" class="style4"style="font-size:16px;">Foto tipo carnet</td>
                <td colspan="1" class="style5"> <input type = "text" /></td>
            </tr>
            <tr>
                <td colspan="3" class="style6"style="font-size:16px;">Fotocopia de DNI</td>
                <td colspan="1" class="style7"> <input type = "text" /></td>
            </tr>
                <tr>
                <td colspan="3"  class="style8"style="font-size:16px;">Fotocopia del t&iacute;tulo acad&eacute;mico</td>
                <td colspan="1"  class="style9"> <input type = "text" /></td>
            </tr>
             <tr>
                <td colspan="3"  class="celda"style="font-size:16px;">Curr&iacute;culum Vitae</td>
                <td colspan="1"  class="celda_vacia"> <input type = "text" /></td>
            </tr>
             <tr>
                <td colspan="3"  class="celda"style="font-size:16px;">Documentaci&oacute;n de respaldo</td>
                <td colspan="1"  class="celda_vacia"> <input type = "text" /></td>
            </tr>


        </table>        
<%--
        <p style="border: 1px solid #000; padding:5px; padding-bottom:50px;">OBSERVACIONES (consignar si la inscripción fue efectuada por apoderado debidamente acreditado) Consignar
        entrega de las Bases del Concurso y cualquier otra documentación</p>--%>

        <div class="div-pie-tabla" style="height:50px;">
            <table border="border-collapse: collapse" style="border-collapse: collapse; height:50px;" class="pie-tabla" >
          <%--  <tr>
                <td class="td-pie-tabla"><span class="letra-bold" style="height:50px;">Fecha de Inscripción</span></td>
                <td class="td-pie-tabla"><span class="letra-bold" style="height:50px;">Firma y Aclaración del Inscripto o Apoderado</span></td>
            </tr>--%>
            </table>
           <input type ="button" class="btn btn-primary" value="Imprimir" onclick="Imprimir();" />
           <%-- <p class="p-imprimir"><button class="btn btn-primary" onclick="ImprimirCVPostulado()">Imprimir</button></p>--%>
        </div>	
    </div>

<asp:HiddenField ID="postulacion" runat="server" />
<asp:HiddenField ID="curriculum" runat="server" />
        
    </form>
</body>
<%= Referencias.Javascript("../") %>
<script type="text/javascript" src="Anexo.js" ></script>
<script type="text/javascript" src="curriculum.js" ></script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>

<script type="text/javascript">
    //Backend.start();

    function ImprimirCVPostulado() {
        //window.print();
    }


    function Imprimir() {
        window.print();
    }

    Backend.start(function () {
        $(document).ready(function () {
        ///
            document.getElementById("codigo_postu").innerHTML = localStorage.getItem("codigo");
           // document.getElementById("span_perfil").innerHTML = localStorage.getItem("perfil");
           // document.getElementById("span_comite").innerHTML = localStorage.getItem("comite");

            ///
            Anexo.armarAnexo();





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
                    document.getElementById("span_recepcion").innerHTML = nombre + " " + apellido; // localStorage.getItem("usuario"); // usuario;

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alertify.alert(errorThrown);
                }
            });





         //   window.print();
        });
    });

</script>

</html>
