<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatosPersonales.aspx.cs" Inherits="Portal_DatosPersonales" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
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
            <legend style="margin-top: 20px;">MIS DATOS</legend>
                <div class="cajitas">
                   <p class=""><label class="item_cajita">Legajo: </label><span id="legajo"></span></p>
                    <p class=""><label class="item_cajita">Documento: </label><span id="dni"></span></p>
                </div>
                 <div class="cajitas">
                    <p><label  class="item_cajita">Edad: </label><span id="edad">31</span></p>
                    <p class=""><label class="item_cajita">F. Nacimiento: </label><span id="fechaNac"></span></p>
                </div>
                <div class="cajitas">
                    <p class=""><label class="item_cajita">Sexo: </label><span id="sexo"></span></p>
                    <p class=""><label class="item_cajita">Estado Civil: </label><span id="estadoCivil"></span></p>
                 </div>
                 <div class="cajitas">
                    <p class=""><label class="item_cajita">CUIL: </label><span id="cuil"></span></p>
                    <p class=""><label class="item_cajita">Domicilio: </label><span id="domicilio"></span></p>
                 </div>
                <legend style="margin-top: 20px;">DATOS FAMILIARES</legend>
                  <div id="tabla_familiar">
    
                </div>
                    <%--<table class="table table-striped table-bordered table-condensed">
                        <thead class="estilo_tabla_portal">
                            <tr>
                                <th>Parentezco</th>
                                <th>Apellido</th>
                                <th>Nombre</th>
                                <th>F. Nac</th>
                                <th>N doc</th>
                                <th>Tipo DNI</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Hermano</td>
                                <td>Caino</td>
                                <td>German Daniel</td>
                                <td>19/05/1981</td>
                                <td>28888888</td>
                                <td>DNI</td>
                            </tr>
                            <tr>
                                <td>Madre</td>
                                <td>Bruschi</td>
                                <td>Maria Irente</td>
                                <td>19/05/1981</td>
                                <td>28888888</td>
                                <td>DNI</td>
                            </tr>
                            <tr>
                                <td>Padre</td>
                                <td>Caino</td>
                                <td>Daniel Alberto</td>
                                <td>19/05/1981</td>
                                <td>28888888</td>
                                <td>DNI</td>
                            </tr>
                        </tbody>
                    </table>--%>

                    <legend style="margin-top: 50px;">EXÁMENES PSICOFÍSICOS</legend>
                    <table class="table table-striped table-bordered table-condensed">
                        <thead class="estilo_tabla_portal">
                            <tr>
                                <th>Fecha</th>
                                <th>Motivo</th>
                                <th>Resultado</th>
                                <th>Organismo</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>19/05/1981</td>
                                <td>Ingreso</td>
                                <td>Provisorio</td>
                                <td>Depto Medicina</td>
                            </tr>
                            <tr>
                                <td>19/05/1981</td>
                                <td>Ingreso Planta</td>
                                <td>Apto</td>
                                <td>Depto Medicina</td>
                            </tr>

                        </tbody>
                    </table>

                </div>
               
            </div>
        </div>

    </form>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {
        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm");

        Backend.start(function () {
            Legajo.getDatosPersonales();
            Legajo.getDatosFamiliares();
        });

    });

</script> 
</html>
