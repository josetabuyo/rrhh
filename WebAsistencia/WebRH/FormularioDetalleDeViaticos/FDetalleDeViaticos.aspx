<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FDetalleDeViaticos.aspx.cs"
    Inherits="FormularioDetalleDeViaticos_FDetalleDeViaticos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>


    <link id="link1" rel="stylesheet" href="../Scripts/bootstrap/css/bootstrap.css" type="text/css"
        runat="server" />
    <link id="link2" rel="stylesheet" href="../Scripts/bootstrap/css/bootstrap-responsive.css"
        type="text/css" runat="server" />
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" />
    <script type="text/javascript" src="../Scripts/FuncionesDreamWeaver.js"></script>


</head>

<body class="body-detalle" onload="MM_preloadImages('../Imagenes/Botones/Botones Nuevos/cerrar_s2.png','/WebRH/Imagenes/Botones/Botones Gestion/modificar_s2.png','/WebRH/Imagenes/Botones/Botones Gestion/imprimir_s2.png','/WebRH/Imagenes/Botones/Botones Gestion/enviar_s2.png','/WebRH/Imagenes/Botones/Botones Gestion/modificar_solicitud_s2.png')">
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu1" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:14px;font-weight: bold;'> Gestión de Viáticos </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />

    <div class="contenedor_principal">       
       <div class="detalle_viatico_label_usuario">
            <img src="/WebRH/Imagenes/separador_detalle.png" width="350" height="57" alt="separador" class="detalle_viatico_separador"/>
            <div class="detalle_viatico_contenedor_datos_viajante">        
                <div class="detalle_viatico_datos_viajante">
                    <div class="detalle_viatico_dato_viajante"> 
                        <asp:Label ID="LabelNombreApellidoViajante" runat="server">Texto Varible(User Name)</asp:Label> 
                    </div>
                    <div class="detalle_viatico_dato_viajante"> 
                        <asp:Label ID="LabelCuilViajante" runat="server">Texto Varible(User Name)</asp:Label> 
                    </div>
                    <div class="detalle_viatico_dato_viajante"> 
                        <asp:Label ID="LabelAreaViajante" runat="server">Texto Varible(User Name)</asp:Label> 
                    </div>
                    <div class="detalle_viatico_dato_viajante"> 
                        <asp:Label ID="LabelTelefonoViajante" runat="server">Texto Varible(User Name)</asp:Label> 
                    </div>
                    <div class="detalle_viatico_dato_viajante"> 
                        <asp:Label ID="LabelCategoriaViajante" runat="server">Texto Varible(User Name)</asp:Label> 
                    </div>
                    <div class="detalle_viatico_dato_viajante"> 
                        <asp:Label ID="LabelLegajoViajante" runat="server">Texto Varible(User Name)</asp:Label> 
                    </div>
                    <div class="detalle_viatico_dato_viajante"> 
                        <asp:Label ID="LabelResumenViatico" runat="server">Texto Varible(User Name)</asp:Label> 
                    </div>                          
                </div>
                <div class="detalle_viatico_foto_viajante" >
                    <img src="../Imagenes/fabi.jpg" alt="foto" width="105" height="105" />
                </div>
            </div>
        </div>
       <div class="detalle_viatico_contenedor_detalle">
            <div class="detalle_viatico_titulo_detalle">DETALLE DE ESTADIAS</div>       
            <img src="../Imagenes/subrayado_r2_c3_r2_c3.png" width="980" height="3" />
            <div class= "detalle_viatico_cuerpo_detalle">
                <asp:Table ID="TablaEstadias" runat="server"></asp:Table>
            </div>
         </div>
   <div class="detalle_viatico_contenedor_detalle">
        <div class="detalle_viatico_titulo_detalle">DETALLE DE PASAJES</div>           
        <img src="../Imagenes/subrayado_r2_c3_r2_c3.png" width="980" height="3" />
        <div class="detalle_viatico_cuerpo_detalle">
            <asp:Table ID="TablaPasajes" runat="server"></asp:Table>
        </div>
    </div>
    <div class="detalle_viatico_contenedor_detalle">
        <div class="detalle_viatico_titulo_detalle">DETALLE DE FIRMANTES</div>
        <img src="../Imagenes/subrayado_r2_c3_r2_c3.png" width="980" height="03" alt="subrayado" />
        <div class="detalle_viatico_cuerpo_detalle">
            <div class="detalle_viatico_tabla_firmantes">
                <asp:Table ID="TablaFirmantes" border="0" cellpadding="0" cellspacing="0" class="detalle_viatico_tabla_firmantes" runat="server"></asp:Table>
            </div>
        </div>
        <div class="detalle_viatico_boton_modificar_solicitud">
            <asp:LinkButton ID="BotonModificar" name="enviar" runat="server"
                            onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('modificar_solicitud','','../Imagenes/Botones/Botones Gestion/modificar_solicitud_s2.png',1)"
                            OnClick="Modificar_Click" 
                            EnableViewState="False">
                <asp:Image id="ImagenBotonModificar" runat="server" ImageUrl="~/Imagenes/Botones/Botones Gestion/modificar_solicitud_s1.png" name="modificar_solicitud" width="140" height="20" border="0"/>
            </asp:LinkButton>
        </div>
        <div class="detalle_viatico_boton_imprimir">
            <a href="javascript:window.print();" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('imprimir','','../Imagenes/Botones/Botones Gestion/imprimir_s2.png',1)">
                <img src="../Imagenes/Botones/Botones Gestion/imprimir.png" width="79" height="19" id="imprimir" />
            </a>
        </div>
        <div class="detalle_viatico_contenedor_referencias">
            <div class="detalle_viatico_referencia_rendiciones_pendientes"> 
                *Agente con Rendiciones Pendientes.
            </div>
            <div class="detalle_viatico_referencia_viatico_menos_72">
                * Viático solicitado con menos de 72 horas hábiles.
            </div>
        </div>
    </div> 

    <div id="controlDeTransiciones" class="detalle_viatico_contenedor_detalle" runat="server">
        <div class="detalle_viatico_titulo_detalle">ENVIAR VIÁTICO A OTRA DEPENDENCIA</div>
        <img src="../Imagenes/subrayado_r2_c3_r2_c3.png" width="980" height="3" alt="subrayado" />

        <div class="detalle_viatico_contenedor_transicion_combo_boton">
            <input id="selectorDeAreaAprobacion" class="detalle_viatico_transicion_combo" type="text" data-provide="typeahead" data-items="9" runat="server"/>
            <asp:Button ID="botonAprobar" runat="server" Text="Con mi aprobación" class="btn btn-primary detalle_viatico_transicion_boton" onclick="botonAprobar_Click"/>
                       
<%--                    <asp:Image id="Image1" runat="server" ImageUrl="/WebRH/Imagenes/Botones/Botones Gestion/enviar.png" name="enviar" width="59" height="19" border="0"/>--%>
        </div>

        <div class="detalle_viatico_contenedor_transicion_combo_boton">
            <input id="selectorDeAreaModificacion" type="text" class="detalle_viatico_transicion_combo" data-provide="typeahead" data-items="9" runat="server"/>
            <asp:Button ID="botonSolicitarModificacion" runat="server" Text="Para modificación" class="btn btn-primary detalle_viatico_transicion_boton" onclick="botonModificar_Click"/>
                        
<%--                    <asp:Image id="Image1" runat="server" ImageUrl="/WebRH/Imagenes/Botones/Botones Gestion/enviar.png" name="enviar" width="59" height="19" border="0"/>--%>
        </div>

        <div class="detalle_viatico_contenedor_transicion_combo_boton">
            <input id="selectorDeAreaRechazo" type="text" class="detalle_viatico_transicion_combo" data-provide="typeahead" data-items="9" runat="server"/>
            <asp:Button ID="botonRechazar" runat="server" Text="Informando RECHAZO" class="btn btn-primary detalle_viatico_transicion_boton" onclick="botonRechazar_Click"/>
            <%--                    <asp:Image id="Image1" runat="server" ImageUrl="/WebRH/Imagenes/Botones/Botones Gestion/enviar.png" name="enviar" width="59" height="19" border="0"/>--%>
        </div>

        <div class="detalle_viatico_contenedor_transicion_comentarios">
            <div class="detalle_viatico_transicion_leyenda_comentarios">De considerarlo necesario, escriba sus observaciones aquí:</div>
            <asp:TextBox ID="txtComentarios" class="detalle_viatico_transicion_comentarios" runat="server" TextMode="MultiLine" Rows="3"/>
        </div>    

        <div id="AlertaTransicionInvalida" class="alert  alert-error" style="clear:both;" runat="server">
            <a class="close" data-dismiss="alert">×</a> <strong>Error</strong>
        </div>

         <asp:HiddenField ID="AreaSeleccionadaAprobacion" runat="server" />
         <asp:HiddenField ID="AreaSeleccionadaModificacion" runat="server" />
         <asp:HiddenField ID="AreaSeleccionadaRechazo" runat="server" />
         <asp:HiddenField ID="AreaSeleccionada" runat="server" />
         <asp:HiddenField ID="ListaAreas" runat="server" />
    </div>    



<%--    <div class="detalle_viatico_contenedor_detalle">--%>
<%--        <div class="detalle_viatico_titulo_detalle">GESTIÓN DE LA COMISIÓN DE SERVICIO</div>
        <img src="/WebRH/Imagenes/subrayado_r2_c3_r2_c3.png" width="980" height="3" alt="subrayado" />

        <div class="detalle_viatico_titulo_solicitar_modificacion">
            <asp:Button ID="Btn_AccesoDirectoSolicitarModificacion" runat="server" Text="Solicitar modificación a" class="btn btn-primary" onclick="Btn_AccesoDirectoSolicitarModificacion_Click"/>
        </div>    
        <asp:DropDownList ID="cmbAreasTransicionesAnteriores" class="detalle_viatico_combo_solicitar_modificacion" runat="server"></asp:DropDownList>
        <div class="detalle_viatico_acceso_directo_area_superior">
            <asp:LinkButton ID="Btn_AccesoDirectoAprobar" runat="server" Text="Button" onclick="Btn_AccesoDirectoAprobar_Click"/>
        </div>--%>

<%--        <div class="detalle_viatico_contenedor_enviar_viatico_por_excepcion">
            <div class="detalle_viatico_viatico_por_excepcion_accion_area_destino">--%>
<%--                <div class="detalle_viatico_titulo_accion_excepcion">Acción: </div>
                <div class="detalle_viatico_combo_accion_excepcion"> 
                    <asp:DropDownList ID="cmbAccion" class="dropdown" runat="server"> </asp:DropDownList>
                </div>
                <div class="detalle_viatico_titulo_area_destino_excepcion">Área Destino: </div>--%>
<%--                <div class="detalle_viatico_combo_area_destino_excepcion"> 
                    <input id="SelectorDeAreas" type="text" class="detalle_viatico_combo_area_destino_excepcion" data-provide="typeahead" data-items="9" />
                </div>
            </div>            
        </div>--%>
<%--        <div class="detalle_viatico_titulo_comentarios">Comentarios:</div>
        <div class="detalle_viatico_enviar">
                <asp:LinkButton ID="btnEnviar" name="enviar" runat="server"
                                onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('enviar','','/WebRH/Imagenes/Botones/Botones Gestion/enviar_s2.png',1)"
                                OnClick="btnEnviar_Click" 
                                EnableViewState="False">
                    <asp:Image id="enviar" runat="server" ImageUrl="/WebRH/Imagenes/Botones/Botones Gestion/enviar.png" name="enviar" width="59" height="19" border="0"/>
                </asp:LinkButton>
        </div>--%>
    </div>    
 </div>    

</form>    
</body>

<%--<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu1" runat="server" />
    <div class="container" align="left">
        <uc1:ControlDetalleDeViaticos ID="ControlDetalleDeViaticos1" runat="server" />
    </div>
    <div class="container" align="left">
        <uc1:ControlTransicionDeViaticos ID="ControlTransicionDeViaticos" runat="server">
        </uc1:ControlTransicionDeViaticos>
    </div>
    <div class="container" align="right">
        <input id="Button1" class="btn btn-primary" type="button" value="Imprimir" onclick="javascript:window.print();" />
        
    </div>
    </form>
    
</body>--%>



<script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>

<script type="text/javascript" src="../bootstrap/js/bootstrap-transition.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-alert.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-modal.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-tab.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-tooltip.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-popover.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-button.js"></script>
<script type="text/javascript" src="../bootstrap/js/bootstrap-typeahead.js"></script>
<script type="text/javascript">




    $('#SelectorDeAreas').attr('data-source', $('#<%= ListaAreas.ClientID %>').val());
    $('#SelectorDeAreas').attr("autocomplete", "off");
    //$('#SelectorDeAreas').blur(function () { alert($('#SelectorDeAreas').data().typeahead.$menu.find('.active').data().item.value); });
    $('#SelectorDeAreas').blur(function () {
        $('#<%= AreaSeleccionada.ClientID %>').val($('#SelectorDeAreas').data().typeahead.$menu.find('.active').data().item.value);
    });

    $('#selectorDeAreaAprobacion').attr('data-source', $('#<%= ListaAreas.ClientID %>').val());
    $('#selectorDeAreaAprobacion').attr("autocomplete", "off");
    $('#selectorDeAreaAprobacion').blur(function () {
        $('#<%= AreaSeleccionadaAprobacion.ClientID %>').val($('#selectorDeAreaAprobacion').data().typeahead.$menu.find('.active').data().item.value);
    });

    $('#selectorDeAreaModificacion').attr('data-source', $('#<%= ListaAreas.ClientID %>').val());
    $('#selectorDeAreaModificacion').attr("autocomplete", "off");
    $('#selectorDeAreaModificacion').blur(function () {
        $('#<%= AreaSeleccionadaModificacion.ClientID %>').val($('#selectorDeAreaModificacion').data().typeahead.$menu.find('.active').data().item.value);
    });

    $('#selectorDeAreaRechazo').attr('data-source', $('#<%= ListaAreas.ClientID %>').val());
    $('#selectorDeAreaRechazo').attr("autocomplete", "off");
    $('#selectorDeAreaRechazo').blur(function () {
        $('#<%= AreaSeleccionadaRechazo.ClientID %>').val($('#selectorDeAreaRechazo').data().typeahead.$menu.find('.active').data().item.value);
    });
</script>



       <%= Referencias.Javascript("../")%>  

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.validate.js"></script>
     <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-tab.js"></script>
    <%= Referencias.Css("../")%>  

</html>
