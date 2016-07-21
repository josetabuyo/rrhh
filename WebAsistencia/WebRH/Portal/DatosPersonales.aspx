﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatosPersonales.aspx.cs" Inherits="Portal_DatosPersonales" %>
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
        <h1 style="text-align:center; margin:30px; ">Datos Personales</h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq">
                <div class="imagen">
                
                </div>
                <div style="text-align:center;">
                    <p class=""><span id="apellido">Caíno</span> <span id="nombre">Fernando</span></p>
                    <p class=""><span id="cargo">Analista en Gestión de la información</span></p>
                </div>
                <hr  />
                <h3 class="h3_caja_izq">Accesos directos</h3>
                <div class="div_texto_caja_izq">
                    <ul>
                        <li class=""><a href="DatosPersonales.aspx" style="color: #fff;" >Datos Personales</a></li>
                        <li class=""><a href="Estudios.aspx" style="color: #fff;" >Estudios</a></li>
                        <li class=""><a href="Perfil.aspx" style="color: #fff;">Cerrera Administrativa</a></li>
                        <li class=""><a href="#" style="color: #fff;" >Licencias</a></li>
                        <li class=""><a href="#" style="color: #fff;" >Notificaciones</a></li>
                        <li class=""><a href="#" style="color: #fff;">Capacitaciones</a></li>
                        <li class=""><a href="#" style="color: #fff;" >Beneficios</a></li>
                        <li class=""><a href="#" style="color: #fff;">Viáticos</a></li>
                   </ul>
                </div>
            </div>
            <div class="caja_der papel">
            <legend style="margin-top: 20px;">Mis Datos</legend>
                <div class="cajitas">
                   <p class=""><label class="item_cajita">Legajo: </label><span id="Span1">123456879</span></p>
                    <p class=""><label class="item_cajita">Documento: </label><span id="Span2">31000000</span></p>
                </div>
                 <div class="cajitas">
                    <p><label  class="item_cajita">Edad: </label><span id="Span3">31</span></p>
                    <p class=""><label class="item_cajita">F. Nacimiento: </label><span id="Span4">18/07/1984</span></p>
                </div>
                <div class="cajitas">
                    <p class=""><label class="item_cajita">Sexo: </label><span id="Span5"></span>Masculino</p>
                    <p class=""><label class="item_cajita">Estado Civil: </label><span id="Span6">Soltero</span></p>
                 </div>
                 <div class="cajitas">
                    <p class=""><label class="item_cajita">CUIL: </label><span id="Span7">20-20202020-5</span></p>
                    <p class=""><label class="item_cajita">Domicilio: </label><span id="Span8">Avalos 1301 - Villa Pueyrredon - C.A.B.A. </span></p>
                 </div>
                <legend style="margin-top: 20px;">Datos Familiares</legend>
                    <table class="tabla_familiar">
                        <thead>
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
                    </table>

                    <legend style="margin-top: 50px;">Exámenes psicofísicos</legend>
                    <table class="tabla_familiar">
                        <thead>
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
</html>
