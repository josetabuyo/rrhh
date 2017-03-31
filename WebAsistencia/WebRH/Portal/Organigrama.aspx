<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Organigrama.aspx.cs" Inherits="Portal_Organigrama" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Organigrama</title>
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" href="estilosPortalSecciones.css" />
    <link id="link1" rel="stylesheet" href="../Protocolo/ConsultaProtocolo.css" type="text/css"
        runat="server" />
    <link id="link5" rel="stylesheet" href="../Protocolo/VistaDeArea.css" type="text/css"
        runat="server" />
    <script type="text/javascript" src="../Scripts/ConversorDeFechas.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Organigrama <br/> "
            UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <h1 style="text-align: center; margin: 30px;">
        </h1>
        <div style="margin: 0 auto;" class="row">
            <%--<div style="text-align:right; margin-right:20%"><a href="Docs/Organigrama_vigente.pdf" download>Descargar Organigrama PDF</a></div>--%>
            <div style="text-align: center;" class="caja_izq">
            </div>
            <div class="caja_der papel">
                <legend style="margin-top: 20px;">Listado de Lugares de Trabajo del Ministerio de Desarrollo
                    Social de Nación </legend>
                <div style="text-align: center; margin-bottom: 20px;">
                    <a class="btn btn-primary" style="margin: 2px;" href="Docs/Organigrama_vigente.pdf"
                        download>Descargar Organigrama PDF</a>
                    <input id="btnLugares" type="button" class="btn btn-primary" style="margin: 2px;"
                        value="Lugares de trabajo" />
                    <input id="btnAutoridades" type="button" class="btn btn-primary" style="margin: 2px;"
                        value="Autoridades" />
                </div>
                 <div id="ContenedorPrincipal" class="contenedor_principal contenedor_principal_consulta_protocolo">    
                <div style="margin-top: 20px;" id="search_box">
                    <input type="text" id="search" class="search" placeholder="Buscar" />
                    <a href="#" id="exportar">
                        <img id="descargar_a_excel_organigrama" src="../Protocolo/excel_icon.png" /></a>
                </div>
                <div id="ContenedorPlanilla" runat="server">
                </div>
                </div>
                <asp:HiddenField ID="texto_mensaje_exito" runat="server" />
                <asp:HiddenField ID="texto_mensaje_error" runat="server" />
                <asp:HiddenField ID="areasJSON" runat="server" EnableViewState="true" />
                <asp:HiddenField ID="txtIdArea" runat="server" />
                <asp:HiddenField ID="idArea" runat="server" />
                <div id="plantillas">
                    <div id="plantilla_vista_area" class="vista_area">
                        <div class="contenido">
                            <div>
                                <div class="titulo">
                                    Responsable:</div>
                                <div id="responsable" class="valor">
                                </div>
                            </div>
                            <div>
                                <div class="titulo">
                                    Dirección:</div>
                                <div id="direccion" class="valor">
                                </div>
                            </div>
                            <div>
                                <div class="titulo">
                                    Teléfono:</div>
                                <div id="telefono" class="valor">
                                </div>
                            </div>
                            <div>
                                <div class="titulo">
                                    Fax:</div>
                                <div id="fax" class="valor">
                                </div>
                            </div>
                            <div>
                                <div class="titulo">
                                    Mail:</div>
                                <div id="mail" class="valor">
                                </div>
                            </div>
                            <div id="asistentes">
                            </div>
                        </div>
                    </div>
                    <div id="plantilla_vista_asistente" class="vista_asistente">
                        <div>
                            <div id="cargo" class="titulo">
                            </div>
                            <div id="resumen" class="valor">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
<script type="text/javascript" src="../Protocolo/AdministradorDeLugaresDeTrabajo.js"></script>
<script type="text/javascript" src="../Protocolo/AdministradorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/Area.js"></script>
<script type="text/javascript" src="../Scripts/underscore-min.js"></script>
<script type="text/javascript" src="../Protocolo/VistaDeArea.js"></script>
<script type="text/javascript" src="../Protocolo/VistaDeAsistente.js"></script>
<script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>
<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<%= Referencias.Javascript("../")%>
<script type="text/javascript">
    $(document).ready(function () {

        $('#search_box').hide();
        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm", function () {
            Backend.start(function () {
                Legajo.getNombre();

                $('#btnPDF').click(function () {
                    window.location.href = "Docs/Organigrama_vigente.pdf";
                });

                $('#btnLugares').click(function () {
                    $('#ContenedorPlanilla').empty();
                    var admin = new AdministradorDeLugaresDeTrabajo();
                    $('#search_box').show();
                    $('#descargar_a_excel_organigrama').show();
                });

                $('#btnAutoridades').click(function () {
                    $('#ContenedorPlanilla').empty();
                    var admin = new AdministradorDeAreas();
                    $('#search_box').show();
                    $('#descargar_a_excel_organigrama').hide();
                });

            });
        });

        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');
    });
</script>
</html>
