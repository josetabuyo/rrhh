<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMComites.aspx.cs" Inherits="EvaluacionDesempenio_ABMComites" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Reuniones de Comite</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
    <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
</head>
<body>
    <form id="form2" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
    <div id="contenedor_comites">
        <asp:HiddenField ID="ComitesHiddenField" runat="server" />
        <table>
            <tr style="height: 50px;">
                <td>
                    Proceso Evaluatorio
                </td>
                <td>
                    <div class="grupo_campos">
                        <label class="etiqueta_campo" for="cmb_periodo">
                            Proceso Evaluatorio <em>*</em></label>
                        <select id="cmb_periodo" style="width: 280px;" rh-control-type="combo" rh-data-provider="PeriodosEvaluacion"
                            rh-model-property="PeriodoEvaluacion" data-validar="haySeleccionEnCombo">
                        </select>
                    </div>

<!--

                    <select>
                        <option value="1">2016 - Planta Permamente</option>
                    </select>-->
                </td>
            </tr>
            <tr>
                <td>
                    <div class="grupo_campos nueva_linea">
                        <label class="etiqueta_campo" for="txt_fecha">
                            Fecha <em>*</em></label>
                        <input type="text" id="txt_fecha" style="width: 110px;" rh-control-type="datepicker"
                            rh-model-property="Fecha" data-validar="esNoBlanco" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="grupo_campos nueva_linea">
                        <label for="hora">
                            Hora <em>*</em></label>
                        <input id="hora" type="text" rh-control-type="textbox" rh-model-property="Hora" style="width: 160px;"
                            data-validar="esNoBlanco" maxlength="100" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="grupo_campos nueva_linea">
                        <label for="lugar">
                            Lugar <em>*</em></label>
                        <input id="Text1" type="text" rh-control-type="textbox" rh-model-property="Lugar"
                            style="width: 160px;" data-validar="esNoBlanco" maxlength="100" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
<script type="text/javascript" src="../Scripts/jquery.maskedinput.min.js"> </script>
<script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
<script type="text/javascript" src="../Scripts/ObjectObserver.js"></script>
<script type="text/javascript" src="../Scripts/FormularioBindeado.js"></script>
<script type="text/javascript" src="./ABMComites.js"></script>
<script type="text/javascript">
    Backend.start();

    $(document).ready(function () {
        var comites = JSON.parse($('#ComitesHiddenField').val());
        ABMComites.completarDatos(comites[0]);
    });
</script>
</html>
