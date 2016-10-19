<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consultas.aspx.cs" Inherits="Portal_Consultas" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>
        <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
        <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
        <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortalSecciones.css" />
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Recibo</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:30px; "></h1>
        <div style="text-align:center;" class="caja_izq no-print"></div>
         <div  class="caja_der papel" style="width:35%;">
         <input id="btn_nueva_consulta" type="button" class="btn btn-primary" style="margin:10px" value="Realizar nueva consulta" />  
         <div id="tablaConsultas" class="table table-striped table-bordered table-condensed">  
         </div>
         
    </div>
    </form>
    <div id="pantalla_alta_ticket" style="display:none">
        <select id="cmb_tipo_consulta">
            <option value="1">Error en el sitio</option>
            <option value="2">Duda sobre el sitio</option>
            <option value="3">Consulta administrativa</option>
            <option value="4">Sugerencia</option>
        </select>
        <textarea id="txt_motivo_consulta" placeholder="ingrese su consulta aquí"></textarea>
        <input id="btn_enviar_consulta" type="button" class="btn btn-primary" style="margin:10px" value="Enviar" />
    </div>
</body>
<script type="text/javascript" src="Legajo.js"></script>
 <script src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {
        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm");

        Backend.start(function () {
            Legajo.getConsultas();

            $("#btn_nueva_consulta").click(function () {
                vex.defaultOptions.className = 'vex-theme-os';
                vex.open({
                    afterOpen: function ($vexContent) {
                        var ui = $("#pantalla_alta_ticket").clone();
                        $vexContent.append(ui);
                        ui.show();
                        ui.find("#btn_enviar_consulta").click(function () {
                            Backend.NuevaConsultaDePortal({
                                id_tipo_consulta: ui.find("#cmb_tipo_consulta").val(),
                                tipo_consulta: ui.find("#cmb_tipo_consulta option:selected").text(),
                                motivo: ui.find("#txt_motivo_consulta").val()
                            }).onSuccess(function(id_consulta){
                                alertify.success("Consulta enviada con éxito");
                                vex.close();
                            }).onError(function(id_consulta){
                                alertify.error("Error al enviar consulta");
                            });
                        });
                        return ui;
                    },
                    css: {
                        'padding-top': "4%",
                        'padding-bottom': "0%"
                    },
                    contentCSS: {
                        width: "80%",
                        height: "80%"
                    }
                });

            });
        });
    });


</script> 
</html>
