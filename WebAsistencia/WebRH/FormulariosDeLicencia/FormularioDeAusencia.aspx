<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormularioDeAusencia.aspx.cs" Inherits="FormulariosDeLicencia_FormularioDeAusencia" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

        <%= Referencias.Css("../")%>           

        <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
        
        <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Ausencias </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
        <div style="margin: 20px;">
        <h2 style="text-align:center;">Formulario de Notificación de Ausencia</h2>
        <div class="margin-top:30px;" >
            <p>Por medio de la presente se deja constancia que el agente <asp:Label ID="nombrePersona" runat="server"></asp:Label> 
            con D.N.I. N° <asp:Label ID="documento" runat="server"></asp:Label> no asiste/asistirá a su lugar de trabajo. </p>
            
            <p>A continuación debe especificar el periodo y motivo de ausencia.</p>

           
            <p>Desde: <input id="desde" type="date" style="height: 30px; width: 140px;" /></p>
            <p>Hasta: <input id="hasta" type="date" style="height: 30px; width: 140px;" /></p>
            <p>Motivo: <select id="comboMotivos" style="width: 150px" > </select>  </p>
        </div>

        <div style="margin:30px 0;">
            Hasta tanto esta notificación no sea justificada por los mecanismos correspondientes (licencias, justificaciones, presentismo), las ausencias serán considerados como SIN JUSTIFICAR
        </div>

            <div style="text-align:center;">
                <input class="btn-primary" type="button" id="btnEnviar" value="Enviar" />
                <input class="btn-primary" onclick="Imprimir()" type="button" value="Imprimir" />
            </div>
            <asp:HiddenField runat="server" ID="idPersona" />
        </div>
    </form>
</body>
<script type="text/javascript">
    $(document).ready(function () {
        // alert($("#nombrePersona").html());
        Backend.start(function () {

            Backend.TraerMotivosAusencias()
                    .onSuccess(function (rto) {
                        var motivos = rto;

                        var select = $("#comboMotivos");
                        $.each(motivos, function () {
                            select.append($("<option />").val(this.Id).text(this.Descripcion));
                        });

                    })
                    .onError(function (e) {

                    });


            $("#btnEnviar").click(function () {
                var desde = new Date($("#desde").val());
                desde.setDate(desde.getDate() + 1);

                var hasta = new Date($("#hasta").val());
                hasta.setDate(hasta.getDate() + 1);

                var motivo = $("#comboMotivos").val();
                var documento = $("#documento").html();

                /*var inasistencia = {

                Motivo: $("#comboMotivos").val(),
                Documento: $("#documento").html(),
                Desde: desde,
                Hasta: hasta
                }*/

                Backend.CargarInasistencia($("#desde").val(), $("#hasta").val(), documento, motivo)
                    .onSuccess(function (rto) {

                        if (rto == true) {
                            alert("Se ha cargado la ausencia correctamente");
                            window.location.href = "../../Principal.aspx";
                        } else {
                            alertify.error("No se ha cargado la ausencia. Verificar que no se pise con otra Ausencia o con Licencias Solicitadas y/o aprobadas");
                        }

                    })
                    .onError(function (e) {

                    });

            });

        });


    });

    function Imprimir() {

        window.print();

    }
    

 </script>
</html>
