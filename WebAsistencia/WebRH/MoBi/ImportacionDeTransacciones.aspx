<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportacionDeTransacciones.aspx.cs" Inherits="MoBi_ImportacionDeTransacciones" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="../Reportes/Reportes.css" />
    <link rel="stylesheet" type="text/css" href="../Scripts/ArbolOrganigrama/ArbolOrganigrama.css" />
    <link rel="stylesheet" type="text/css" href="../Estilos/component.css" />
    <link rel="stylesheet" type="text/css" href="../estilos/SelectorDeAreas.css" />
    <link rel="stylesheet" type="text/css" href="../scripts/select2-3.4.4/select2.css" />
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>

    <script type="text/javascript" src="../Scripts/ArbolOrganigrama/ArbolOrganigrama.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    

    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>Contratos</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div style="margin-top: 1%">
            
            <asp:FileUpload ID="FileUpload1" runat="server" Width="800px" />
            <asp:Button ID="btnLeerArchivo" runat="server" onclick="btnLeerArchivo_Click" Text="Leer archivo excel" />

            <input type="button" id="btnImportarArchivo" value="Importar"  onclick="return btnImportarArchivo_onclick()" />
            
    </div>
    
    <div>
        <asp:ListBox ID="ListBox1" runat="server" Width="6000px" Height="400px" 
            Font-Size="Smaller"></asp:ListBox>
    </div>

    </form>

    <script src="../Scripts/ImportarArchivo.js" type="text/javascript"></script>

    <script type="text/javascript">
        Backend.start(function () {
            $(document).ready(function () {
                btnImportarArchivo = document.getElementById('btnImportarArchivo'),

                btnImportarArchivo.onclick = function () {
                    ImportarArchivoABaseDeDatos.Importar(hNombreArchivo.value, hDetalleExcel.value);
                };
                

            });
        });


    </script>


    <input type ="hidden" id = "hNombreArchivo" runat="server" />
    <input type ="hidden" id = "hDetalleExcel" runat="server" />
    

</body>
</html>
