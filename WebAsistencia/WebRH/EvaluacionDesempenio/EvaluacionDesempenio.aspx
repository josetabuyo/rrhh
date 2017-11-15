<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EvaluacionDesempenio.aspx.cs" Inherits="EvaluacionDesempenio_EvaluacionDesempenio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evaluacion de Desempeño</title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a id="btn_listado_agentes" RequiereFuncionalidad="52" class="acomodar_botones_del_menu btn btn-primary" href="FormulariosDeLicencia/CalculoDeLicenciaOrdinaria.aspx">Listado Agentes Evaluables</a>
        <a id="btn_comprobacion_gde" RequiereFuncionalidad="58" class="acomodar_botones_del_menu btn btn-primary" href="FormulariosDeLicencia/CalculoDeLicenciaOrdinaria.aspx">Comprobacion GDE</a>
    </div>
    </form>
</body>
</html>
