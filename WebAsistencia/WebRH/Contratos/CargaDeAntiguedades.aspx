<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CargaDeAntiguedades.aspx.cs"
    Inherits="Contratos_CargaDeAntiguedades" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="~/Scripts/ControlBuscarPersonas.ascx" TagName="BuscadorDePersonas"
    TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
        <title>Carga de Antiguedades</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Formularios/EstilosFormularios.css" />
    <link rel="stylesheet" href="../estilos/estilos.css" type="text/css" />
    <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu1" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>"
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />

    <div>
        
        <div style="margin-top: 40px" align="center">
            <div style="display: block; width: 50%; padding: 0; margin-bottom: 27px; font-size: 19.5px;
                line-height: 36px; color: #333333; border: 0; border-bottom: 1px solid #e5e5e5;
                text-shadow: 2px 2px 5px rgba(150, 150, 150, 1); text-align: left;">
                Carga de Antiguedades
            </div>
        </div>

        <div id="divBuscadorPersona">
            <table>
                <tr>
                    <td>
                        <uc3:buscadordepersonas id="buscadorPersonas1" runat="server" style="display: inline-block;
                            margin: auto;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="button" value="Estado" class="btn btn-primary" id="btn_Estado" />
                    </td>
                    <td>
                        <input type="button" value="Privado" class="btn btn-primary" id="btn_Privado" />
                    </td>
                </tr>
            </table>
        </div>

        <div id="ContenedorGrilla" runat="server" style="width: 50%" align="center">
            <div id="ContenedorPersona" runat="server" style="width: 50%"></div>
        </div>
        <input type="button" value="Agregar Servicio" class="btn btn-primary" id="btn_AgregarServicio" />


    </div>
    </form>
</body>


<script type="text/javascript" src="CargaDeAntiguedades.js"></script>
<script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>
<script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
<script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
<script src="../scripts/Spin.js" type="text/javascript"></script>
<script type="text/javascript" src="../Scripts/alertify.js"></script>

</html>
