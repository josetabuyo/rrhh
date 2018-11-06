﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AsignacionDePerfiles.aspx.cs" Inherits="Permisos_AsignacionDePerfiles" %>
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
        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        <link rel="stylesheet"  href="estilosPermisos.css" />
        <link rel="stylesheet" href="../estilos/SelectorDeAreas.css" type="text/css"/> 
        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
       
    </head>
<body>
    
    <form id="form1" runat="server">
        <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
        <div class="container-fluid">
            <h1 style="text-align:center; margin:17px; "></h1>
            <div style="margin: 0 auto;" class="row">
                <div style="text-align:center;" class="caja_izq"></div>
            
                <div class="caja_der papel">
            
                    <legend style="margin-top: 20px;">ASIGNACION DE PERFILES</legend>
                    <label>Seleccione el Perfil a Asignar: </label>
                    <select id="comboPerfiles">
                        <option value="0">Seleccionar Perfil</option>
                        <option value="1">Responsable de Control de Asistencia</option>
                        <option value="2">Reportes de Dotacion Nivel 1</option>
                        <option value="3">Administracion de Medialunas</option>
                    </select>

                    <span id="mostrarDialogo">ver Listado de Func. de cada Perfil</span>

                    <div id="dialog" title="Listado de Funcionalidades por Perfil">
                      <div>
                        <p class="dialogNombrePerfil" >Responsable de RCA</p>
                        <hr />
                        <ul class="dialogListaFunc">
                            <li>Control Acceso</li>
                            <li>Control Asistencia</li>
                            <li>Carga Licencias</li>
                            <li>Control Planilla</li>
                        </ul>

                      </div>
                    </div>

                    <p style="margin-top: 20px;"><strong>Perfil Seleccionado:</strong></p>
                    <div id="perfilesSeleccionado"></div>

                    <hr />

                    <label>Seleccione el Area a Asignar al Perfil: </label>

                    <div id="panel_usuarios_por_area" >     
                        <div id="selector_area_usuarios" class="selector_areas" style="position: inherit; display: inline;">
                            <input id="buscador" type="hidden" class="buscarUsuarioPorArea" />
                        </div>
                            
                        <div style="margin-top: 20px;">
                            <p><strong>Areas Seleccionadas</strong></p>
                            <div id="listadoAreasElegidas"></div>
                        </div>
                     </div> 

                     <hr />
                     <div style="text-align:center;">
                        <input type="button" class="btn-primary" value="Agregar Perfil a las Areas seleccionadas" id="btnAsignarPerfilConAreas" />
                     </div>

                </div>
               
             </div>
        </div>
    </form>

    <div id="plantillas">
        <div class="vista_area_en_selector">
            <div id="nombre"></div> 
        </div>

    </div>

    <div id="plantillaArea" style="width:100%; display:none;" class="listadoAreas">
        <span style="width: 50%; display: inline-block;" id="areaSeleccionada"></span>
        <input  id="checkIncluyeDependencias" type="checkbox" /> Incluye Dependencias
        <hr />
    </div>

    <div id="plantillaPerfilSeleccionado" style="display:none;" class="listadoPerfiles">
        <span style="width: 50%; display: inline-block;" class="nombrePerfil"></span>
        <input  type="button" class="quitar" value="Quitar" /> 
    </div>

</body>

<script type="text/javascript" src="../MAU/VistaDeAreasAdministradas.js"></script>
<script type="text/javascript" src="../MAU/VistaDeAreaAdministrada.js"></script>
<script type="text/javascript" src="../Scripts/Area.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>
<script type="text/javascript" src="Permisos.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {

        $("#dialog").dialog({
            autoOpen: false,
            show: {
                effect: "blind",
                duration: 1000
            },
            hide: {
                effect: "explode",
                duration: 1000
            }
        });

        $("#mostrarDialogo").click(function () {
            $("#dialog").dialog("open");
        });


        Backend.start(function () {
            //para cargar el menu izquierdo 
            $(".caja_izq").load("SeccionIzquierda.htm", function () {

                //Permisos.init();
                Permisos.iniciarPantallaAsignacionPerfiles();


            });

        });
    });

</script> 
</html>
