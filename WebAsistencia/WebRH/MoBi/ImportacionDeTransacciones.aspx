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
    <script src="../Scripts/ImportarArchivo.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    

    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>Contratos</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div style="margin-top: 1%">
            
            <h2 style="text-align: center">Importación de Transacciones de YPF</h2>
            <br/>
            <input type="button" id="btnImportarArchivo" value="Importar" />
            <br />
            <%--Escribo el mensaje que devuelve al importar el archivo.--%>
           <ol></ol>

    </div>
    </form>


    <script type="text/javascript">
        Backend.start(function () {
            $(document).ready(function () {

                $("#btnImportarArchivo").click(function () {
                    var fileInput = $('<input type="file" />')[0];
                    fileInput.addEventListener("change", function () {
                        var file = fileInput.files[0];
                        var reader = new FileReader();
                        reader.readAsDataURL(file);

                        reader.onload = function () {
                            //console.log(reader.result);
                            var bytes = reader.result.replace(/^data:application\/vnd.ms-excel;base64/, "");
                            bytes = bytes.substring(1);
                            //console.log("---------------------------------------------------------------------------------------");
                            //console.log(bytes);
                            ImportarArchivoABaseDeDatos.Importar(file.name, bytes);
                        };

                        reader.onerror = function (error) {
                            console.log('Error: ', error);
                        };
                    });
                    $(fileInput).click();
                });

                
            });
        });

        
    </script>

    
</body>
</html>
