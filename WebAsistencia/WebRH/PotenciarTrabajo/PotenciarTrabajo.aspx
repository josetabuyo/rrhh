<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PotenciarTrabajo.aspx.cs" Inherits="PotenciarTrabajo_PotenciarTrabajo" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Potenciar Trabajo</title>
    <link href="../Scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
    <link href="../Scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="PotenciarTrabajo.css" />
    <%= Referencias.Css("../")%>
    <%= Referencias.Javascript("../")%>
</head>
    <body>
        <form id="form1" runat="server">
            <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'>Datos Abiertos</span> <br/> <span style='font-size:12px;'> Administración de Usuarios </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />
            <div id="pt_pagina">
                <div id="pt_barra_izquierda">
                    <div id="pt_titulo_barra">
                      <div>
                        Potenciar Trabajo
                      </div>
                    </div>
                    <img id="pt_logo_seccion"
                      src="../MenuPrincipal/Administración_de_Areas.png"/>
                    <div id="pt_controles_barra_izq">
                      PARTICIPACION
                      <div id="pt_boton_carga_participacion">
                        - Carga Participación
                      </div>
                      <div id="">
                        - Informes Mensuales
                      </div>
                      <div id="">
                        - Historial
                      </div>
                      <div id="">
                        - Consultas al Programa
                      </div>
                    </div>
                </div>
                <div id="pt_seccion_gestion_semanal" class="pt_seccion">
                  <div id='pt_estado_mensual'>
                    <div id="pt_titulo_seccion">
                      Estado Mensual de la Carga de Participación
                    </div>
                    <div id="pt_controles_superiores">
                        <div>
                            <label for="pt_cmb_periodo" class="pt_label_combo">Mes</label>
                            <select id="pt_cmb_periodo" class="pt_combo">
                            </select>
                        </div>
                    </div>
                    <div id="pt_contenedor_tabla_participacion_mensual"
                      class="pt_contenedor_tabla">
                      <table id="pt_tabla_participacion_mensual" class="pt_tabla">
                        <tr id="pt_titulos_tabla_participacion_mensual"
                          class="pt_fila_titulo_tabla" >
                          <th rowspan="2" style="text-align:center"> Grupo de Trabajo</th>
                          <th colspan="5" style="text-align:center"> Estados </th>
                          <th colspan="3" style="text-align:center"> Carga </th>
                        </tr>
                        <tr id="pt_titulos2_tabla_participacion_mensual"
                          class="pt_fila_subtitulo_tabla">
                          <th> Activos </th>
                          <th> Activos Parcial </th>
                          <th> Suspendidos </th>
                          <th> Inactivos </th>
                          <th> Total </th>
                          <th> Sin Carga </th>
                          <th> En Proceso </th>
                          <th> Con Informe </th>
                        </tr>
                      </table>
                    </div>
                  </div>
                  <div id="pt_estado_semanal">
                    <div id="pt_titulo_seccion">
                      Registro de Participacion en Actividades del Grupo de Trabajo
                    </div>
                    <div class="pt_nota">
                      Nota: Por defecto, todas las personas presentan un cumplimiento del 100%
                    </div>
                    <div id="pt_nota_de_abajo" class="pt_nota">
                      MODIFIQUE las que corresponda a MENORES porcentajes de cumplimiento (seleccionando el valor correcto de la lista desplegable)
                    </div>
                    <div id="pt_contenedor_tabla_participacion_semanal"
                      class="pt_contenedor_tabla">
                      <table id="pt_tabla_participacion_semanal"
                        class="pt_tabla">
                        <tr id="pt_titulos_tabla_participacion_semanal"
                          class="pt_fila_titulo_tabla">
                        </tr>
                      </table>
                    </div>
                    <div class="pt_nota_pie_table">
                      Atención: La carga de participación para Participantes
                      en Estado "incompatible" no generan ningún tipo de derecho
                      a cobro por el período y su consideración está
                      completamente supeditada a la evaluación del PROGRAMA
                      sobre la documentación que oportunamente se presente.
                    </div>
                  </div>
                  <div id="pt_controles_inferiores"></div>
                </div>
            </div>
            <div id="pt_plantillas">
              <div class="pt_justificacion">
                <div>
                  <label> Motivo: </label>
                  <select id="pt_justificacion_cmb_motivo">
                  </select>
                </div>
                <div class="pt_justificacion_semana_desde_hasta">
                  <div>
                    <label> Semana desde: </label>
                    <label id="pt_justificacion_semana_desde"> </label>
                  </div>
                  <div>
                  <label> Semana hasta: </label>
                    <select id="pt_justificacion_cmb_semana_hasta">
                    </select>
                  </div>
                </div>
                <div>
                  <label> Descripción: </label>
                  <textarea id="pt_descripcion_justificacion"> </textarea>
                </div>
              </div>
            </div>
        </form>
    </body>
    <script type="text/javascript" src="../Scripts/vex-2.1.1/js/vex.combined.min.js"></script>
    <script type="text/javascript" src="PotenciarTrabajo.js"></script>

</html>
