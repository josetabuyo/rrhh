<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComprobacionGDEListadoAgentes.aspx.cs"
    Inherits="EvaluacionDesempenio_ComprobacionGDEListadoAgentes" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Comprobacion de Códigos GDE</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
</head>
<body>
    <form id="form2" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    <div>
        <div class="container-fluid">
            <div style="margin: 0 auto;" class="row">
                <div class="caja_der papel">
                    <legend style="margin-top: 20px;">Comprobacion de Códigos GDE</legend>
                    <div id="contenedorTabla">
                        <label for="Text1">
                            Filtrar planilla por:
                        </label>
                        <input type="text" id="srch_agente" class="search buscador" style="height: 35px;"
                            placeholder="Apellido" />
                        <label style="margin-left: 20px;">
                            ó por ESTADO</label>
                        <select id="id_estado" style="margin-left: 10px; width: 170px;" disabled>
                            <option value="0">Todos</option>
                            <option value="1">Evaluacion Incompleta</option>
                            <option value="2">A Evaluar</option>
                            <!--<option value="3">Muy Destacado</option>-->
                            <option value="4">Destacado</option>
                            <option value="5">Bueno</option>
                            <option value="6">Regular</option>
                            <option value="7">Deficiente</option>
                        </select>
                        <div id="tablaAgentes" class="table table-striped table-bordered table-condensed">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!--popup para verificar el codigo gde de la evaluacion de desempenio cargada-->
    <div style="display:none" id="div_verificar_codigo_gde">
        Se marcará el código <div id="div_codigo_gde_a_verificar"></div>
        como verificado por usted, para la evaluacion de:
        <div id="div_agente_a_verificar"></div>
        
        ¿Confirma que desea realizar esta acción?<br /><br />
        <a href="#" id="lnk_cancelar_verificacion">Cancelar</a>
        <input type="button" id="btn_verificar_codigo_gde" value="Aceptar">
    </div>
    <input type="hidden" id="hid_id_eval" />

    <!--popup para cargar el codigo gde de la evaluacion de desempenio cargada-->
    <div style="display:none" id="div_codigo_gde">
        Ingrese el Codigo GDE<br />
        <input type="text" id="codigo_gde"></input><br />
        <a href="#" id="lnk_cancelar">Cancelar</a>
        <input type="button" id="btn_codigo_gde" value="Aceptar">
    </div>
    </form>
</body>
<script type="text/javascript" src="ListadoAgentes.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript">
    $(document).ready(function ($) {
        Backend.start(function () {
            ListadoAgentes.getEvaluaciones('Verificador');
        });
    });
</script>
</html>
