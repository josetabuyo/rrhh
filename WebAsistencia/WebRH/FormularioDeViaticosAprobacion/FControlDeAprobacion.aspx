<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FControlDeAprobacion.aspx.cs"
    Inherits="FormularioDeViaticosJefe_FControlDeAprobacion" %>

<%@ Register Src="../BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc1" %>
<%--<%@ Register src="../FormulariosDeLicencia/Partes/DatosDelAgente.ascx" tagname="DatosDelAgente" tagprefix="uc2" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Formulario de Viáticos - Aprobación</title>
<%--    <link id="link3" rel="stylesheet" href="../../bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link4" rel="stylesheet" href="../../bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <script type="text/javascript" src="../../bootstrap/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../bootstrap/js/jquery-ui-1.8.21.custom.min.js"></script>
    <script type="text/javascript" src="../../Scripts/FuncionesDreamWeaver.js"></script>--%>

     <link id="link1" rel="stylesheet" href="../Scripts/bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../Scripts/bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <script src="../Scripts/bootstrap/js/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap/js/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery-ui-1.8.21.custom.min.js"></script>





</head>

<body class="body-detalle">
    <form id="form1" runat="server">
    <uc1:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:14px;font-weight: bold;'> Gestión de Viáticos </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>   

    <div class="contenedor_principal"> 
 		<div class= "listado_viaticos_contenedor_separador">
        	<div class= "listado_viaticos_imagen_separador">
        	    <img src="../Imagenes/separador_listado.png" width="350" height="57" alt="separador" />            
            </div>
        </div>        
        <div class = "listado_viaticos_contenedor_tablas" >
		    <div class="listado_viaticos_contenedor_viaticos_espera_gestion">
                <div class="listado_viaticos_viaticos_espera_gestion"> SOLICITUD DE VIÁTICOS A LA ESPERA DE GESTIÓN </div>
  			    <img src="../Imagenes/subrayado_r2_c3_r2_c3.png" alt="subrayado" width="990" height="3" align="right" />                            
                <div class= "listado_viaticos_tabla_viaticos_espera_gestion">

                    <asp:Table ID="TablaViaticosPendientesDeAprobacion" class= "listado_viaticos_tabla_viaticos_espera_gestion" runat="server">
                    </asp:Table>

                </div>    
                <div class= "listado_viaticos_imprimir_seleccion"> 
                    <asp:LinkButton ID="btn_imprimir" runat="server" Text="Imprimir Vi&aacute;ticos seleccionados" OnClick="btn_imprimir_Click"/>
  			    </div>
            </div>
        
            <div class= "listado_viaticos_contenedor_viaticos_seguimiento">
        	    <div class="listado_viaticos_viaticos_espera_gestion"> VIÁTICOS EN SEGUIMIENTO </div>
  			    <img src="../Imagenes/subrayado_r2_c3_r2_c3.png" alt="subrayado" width="990" height="3" align="right" />    
                <div class= "listado_viaticos_tabla_viaticos_seguimiento">                
                    <asp:Table ID="TablaViaticosEnSeguimiento" class= "listado_viaticos_tabla_viaticos_seguimiento" runat="server">
                    </asp:Table>
		        </div>
            </div>
            <div class="listado_viaticos_contenedor_asterisco">
        	    <div class="listado_viaticos_txt_asterisco">* Viáticos solicitados con menos de 72 horas hábiles.
           	    </div>
            </div>
        </div>      
    </div>

    
    </form>
    <script type="text/javascript">

        function onSuccess(result) {
            window.location = result;
        }

        function onFailure(error) {
            alert(error);
        }

        function VerDetalle(id) {
            PageMethods.VerDetalle(id, onSuccess, onFailure);
        }
    </script>


       <%= Referencias.Javascript("../")%>  

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.validate.js"></script>
     <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-tab.js"></script>
    <%= Referencias.Css("../")%>  

</body>
</html>
