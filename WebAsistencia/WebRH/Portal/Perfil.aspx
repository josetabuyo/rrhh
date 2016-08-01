<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Portal_Perfil" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Perfil Profesional</title>
     <!-- CSS media query on a link element -->
         <%= Referencias.Css("../")%>

        <%= Referencias.Javascript("../")%>

        <link rel="stylesheet" media="(max-width: 1600px)" href="estilosPortalSecciones.css" />

    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:30px; "></h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq"></div>

            <div class="caja_der papel">
            <p class="mensaje_cambio_datos" >Si alguno de los datos que está viendo no es correcto o hubiera que actualizar, por favor envíe un mail a <a href="mailto:xxx@example.com" target="_blank">xxx@example.com</a> </p>
            <legend style="margin-top: 20px;">PERFIL PROFESIONAL</legend>
                <div class="cajitas">
                   <p class=""><label class="item_cajita">Sector: </label><span id="Span1">Dirección de Diseño y Desarrollo Organizacional para la Gestión de las Personas</span></p>
                    <p class=""><label class="item_cajita">Nivel y Grado: </label><span id="Span2">C - 1</span></p>
                </div>
                 <div class="cajitas">
                    <p><label  class="item_cajita">Planta: </label><span id="Span3">Permanente</span></p>
                    <p class=""><label class="item_cajita">Agrupamiento: </label><span id="Span4">Profesional</span></p>
                </div>
                <div class="cajitas">
                    <p class=""><label class="item_cajita">Ingreso: </label><span id="Span5"></span>01/09/2010</p>
                 </div>

                <legend style="margin-top: 20px;">DESIGNACIONES</legend>
                    <table class="table table-striped table-bordered table-condensed">
                        <thead class="estilo_tabla_portal">
                            <tr>
                                <th>Nro Acto</th>
                                <th>Fecha Acto</th>
                                <th>Motivo</th>
                                <th>Situación de Revista</th>
                                <th>Folio</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>5182</td>
                                <td>21/09/2010</td>
                                <td>Aprobacion de...</td>
                                <td>Contratada | C 0 | Te...</td>
                                <td>00-001/003</td>
                            </tr>
                            <tr>
                                <td>1864</td>
                                <td>07/09/2015</td>
                                <td>Designación</td>
                                <td>Permanente | C 1 | A..</td>
                                <td>00-090/095</td>
                            </tr>
                        </tbody>
                    </table>

                    <legend style="margin-top: 50px;">CARRERA ADMINISTRATIVA</legend>
                    <table class="table table-striped table-bordered table-condensed">
                        <thead class="estilo_tabla_portal">
                            <tr>
                                <th>Jurisdicción</th>
                                <th>Organismo</th>
                                <th>Régimen</th>
                                <th>Agrupamiento</th>
                                <th>Categoria</th>
                                <th>Cargo</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>MDS</td>
                                <td>Secretaria de Coordinacion</td>
                                <td>Decreto 1421</td>
                                <td>General</td>
                                <td>C</td>
                                <td>Tecnico-Administrativo</td>
                            </tr>
                            <tr>
                                <td>MDS</td>
                                <td>MDS</td>
                                <td>Decreto 1421</td>
                                <td>General</td>
                                <td>C</td>
                                <td>Tecnico-Administrativo</td>
                            </tr>
                             <tr>
                                <td>MDS</td>
                                <td>MDS</td>
                                <td>Decreto 1421</td>
                                <td>General</td>
                                <td>C</td>
                                <td>Profesional</td>
                            </tr>
                            <tr>
                                <td>MDS</td>
                                <td>MDS</td>
                                <td>SINEP-Dto 209..</td>
                                <td>Profesional</td>
                                <td>C</td>
                                <td>Analista Profesional</td>
                            </tr>

                        </tbody>
                    </table>

                </div>
               
            </div>
        </div>

    </form>
</body>
<script type="text/javascript" >

    $(document).ready(function ($) {

        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm");

    });

</script> 
</html>
