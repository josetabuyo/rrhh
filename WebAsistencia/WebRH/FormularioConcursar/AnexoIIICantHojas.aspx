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
            padding:3px;
        }
        
        .celda_vacia 
        {
            padding:15px 0px;
            border: 3px double #000;
            }
        
        .tabla_anexo_1 
        {
            font-size:0.9em;
            width:100%;
            }
     
     </style>
</head>
<body>

    <form id="form1" runat="server">

<input type="hidden" id = "codigo_postu" runat = "server"/>
    
    <div style="width: 80%; margin-left:10%;" class="">
        <div style=" text-align:left;" class="">
            <p style="float:left;" class="">Postulación Nº: <span id="num_postulacion"></span></p>
            <p style="float:right;">ANEXO III</p>
            <div style="clear:both;">
           <p style="float:left;" class=""> <label class="label_caratula">RECEPCIONÓ:</label> <span id ="span_recepcion"></span></p></div>
            <p class="encabezado"style="font-size:20px; margin-bottom:1%;margin-top:1%">CONSTANCIA DE RECEPCIÓN DE LA SOLICITUD.
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
                <td id="puesto_tipo" colspan="2" class="celda">ABIERTO</td>
            </tr>
            <tr>
                <td colspan="2" class="celda">DENOMINACION DEL CARGO A CUBRIR</td>
                <td id="puesto_denominacion" colspan="2" class="celda">Asistente de Dirección</td>
            </tr>
            <tr>
                <td colspan="2" class="celda">AGRUPAMIENTO</td>
                <td id="puesto_agrupamiento" colspan="2" class="celda">GENERAL</td>
            </tr>
            <tr>
                <td class="celda">NIVEL ESCALAFONARIO</td>
                <td id="nivel_escalafonario" class="celda">C</td>
                <td class="celda">NIVEL DE JEFATURA</td>
                <td id="nivel_jefatura" class="celda"></td>
            </tr>
            <tr >
                <td colspan="2" class="celda">JURISDICCION/ENTIDAD DESCENTRALIZADA</td>
                <td id="jurisdiccion" colspan="2" class="celda">Jefatura de Gabinete de Ministros</td>
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
                <td id="domicilio_lugar_de_trabajo" colspan="2" class="celda">San Martin 451. CABA</td>
            </tr>
            <tr >
                <td colspan="2" class="celda">APELLIDO Y NOMBRES DEL INSCRIPTO</td>
                <td id="apellido_y_nombre" colspan="2" class="celda">Lorena Lopez</td>
            </tr>
            <tr >
                <td colspan="2" class="celda">TIPO Y NUMERO DE DOCUMENTO</td>
                <td id="documento" colspan="2" class="celda">DNI 24999983</td>
            </tr>    
            <tr><td colspan="4" class="celda"></td></tr>
            <tr>
                <td style="text-align:center;" colspan="3" class="celda">LISTADO DOCUMENTACION PRESENTADA</td>
                <td style="text-align:center;" colspan="1" class="celda">FOLIOS</td>
            </tr>
            <tr>
                <td colspan="3" class="celda">Ficha de Inscripci&oacute;n</td>
                <td colspan="1" class="celda_vacia"></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">Foto tipo carnet</td>
                <td colspan="1" class="celda_vacia"></td>
            </tr>
            <tr>
                <td colspan="3" class="celda">Fotocopia de DNI</td>
                <td colspan="1" class="celda_vacia"></td>
            </tr>
                <tr>
                <td colspan="3"  class="celda">Fotocopia del t&iacute;tulo acad&eacute;mico</td>
                <td colspan="1"  class="celda_vacia"></td>
            </tr>
             <tr>
                <td colspan="3"  class="celda">Curr&iacute;culum Vitae</td>
                <td colspan="1"  class="celda_vacia"></td>
            </tr>
             <tr>
                <td colspan="3"  class="celda">Documentaci&oacute;n de respaldo</td>
                <td colspan="1"  class="celda_vacia"></td>
            </tr>


        </table>        

        <p style="border: 1px solid #000; padding:5px; padding-bottom:50px;">OBSERVACIONES (consignar si la inscripción fue efectuada por apoderado debidamente acreditado) Consignar
        entrega de las Bases del Concurso y cualquier otra documentación</p>

        <div class="div-pie-tabla" style="height:50px;">
            <table border="border-collapse: collapse" style="border-collapse: collapse; height:50px;" class="pie-tabla" >
            <tr>
                <td class="td-pie-tabla"><span class="letra-bold" style="height:50px;">Fecha de Inscripción</span></td>
                <td class="td-pie-tabla"><span class="letra-bold" style="height:50px;">Firma y Aclaración del Inscripto o Apoderado</span></td>
            </tr>
            </table>
           
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
                    document.getElementById("span_recepcion").innerHTML = nombre.toUpperCase() + " " + apellido; // localStorage.getItem("usuario"); // usuario;

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
