<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionRCA.aspx.cs" Inherits="Areas_GestionRCA" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../") %>
</head>


<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu1" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'></span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />

    <fieldset style="text-align: center; margin-top: 40px" >
        <legend>Gestion de RCA</legend>
    </fieldset>

    <%--<div style="text-align: right">
        <a style="font-size: 1.6em;display: block;margin-bottom: 10px;" href="ConsultaIndividualDDJJ.aspx">Consulta Individual de DDJJ104</a>
    </div>--%>
    
    <div>    
        <select runat="server" title="Seleccione un mes" id="cmbMeses" name="Meses" enableviewstate="false" style="text-transform: capitalize;">
        </select>
    </div>

    <div id="grilla" runat="server" style="width: 100%" align="center">
        <label>Ingrese el Area o Estado que desea buscar: </label>
        <input type="text" id="search" class="search" class="buscador" placeholder="Buscar Area/Estado" style="width:250px"; />
        <div id="ContenedorGrillaAreas" style="width: 90%"></div>
        <div id="DivBotonExcel" runat="server" style="width: 90%"></div>
    </div>
    
    <div id="grillaPersonas" runat="server" style="width: 100%" align="center">
        <div id="ContenedorPersona" runat="server" style="width: 90%"></div>
    </div>

    <div class="contenedorArea" style="display:none;">
        <p class="nombreArea"></p>
        <table class="table table-striped table-bordered table-condensed table-hover tablaPersonas" style="cursor: pointer;">
            <thead class="detalle_viatico_titulo_tabla_detalle">
                <tr>
                    <th>Nombre</th>
                    <th>Documento</th>
                    <th>Permiso</th>
                </tr>
            </thead>
            <tbody class="list">
                <tr class="filaAgente">
                    <td class="nombreAgente"></td>
                    <td class="documento"></td>
                    <td class="permiso"><input type="button" value="Eliminar" class="btn miBoton" /></td>
                </tr>
            </tbody>
          </table>
    </div>
      
    </form>
</body>

    <script src="../scripts/underscore-min.js" type="text/javascript"></script>
    <script src="../scripts/ConversorDeFechas.js" type="text/javascript"></script>
    <script src="../scripts/jquery-barcode.js" type="text/javascript"></script>
    <script src="../scripts/Spin.js" type="text/javascript"></script>
    <script src="GestionDeAreas.js" type="text/javascript"></script>
     <script type="text/javascript">
         $(document).ready(function () {

             Backend.start(function () {
                 GestionDeAreas.getAreasDelUsuario();
             });
         });

        
    </script>

</html>