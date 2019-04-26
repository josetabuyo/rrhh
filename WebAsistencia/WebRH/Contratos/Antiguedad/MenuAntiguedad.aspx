<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuAntiguedad.aspx.cs" Inherits="Contratos_Antiguedad_MenuAntiguedad" %>

<%--<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <!-- CSS media query on a link element -->
        <%= Referencias.Css("../../")%>
        <%= Referencias.Javascript("../../")%>

        <%--<script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script> estilosPortalSecciones.css--%>
        <link rel="stylesheet" href="../../Portal/estilosPortalSecciones.css" type="text/css"  />
        <link rel="stylesheet" href="../../Formularios/EstilosFormularios.css" type="text/css"  />
        <link rel="stylesheet" href="../../estilos/estilos.css" type="text/css" />
       
        <style>
            #btn_realizar_solicitud
            {
                position: absolute;
                right: 10px;
                bottom: 10px;
            }
            
            #panel_derecho_credencial
            {
                position: absolute;
                right: 10px;
                width: 70%;
                bottom: 10px;
                top: 100px;
            }
            
            #titulo_vista_previa
            {
                position: absolute;
                left: 70px;
                top: 39px;
            }
            
            #vista_previa_credencial
            {
                position: absolute;
                left: 40px;
                top: 73px;
            }
        
            #vista_previa_credencial #imagen_credencial
            {
                width: 250px;
            }        
        
            #vista_previa_credencial #foto_usuario
            {
                position: absolute;
                top: 64px;
                left: 21px;
                height: 112px;
                width: 112px;
            }    
        
            #vista_previa_credencial #apellido
            {
                position: absolute;
                top: 196px;
                left: 19px;
                font-size: 20px;
                color: white;
            }    
        
            #vista_previa_credencial #nombres
            {
                position: absolute;
                top: 224px;
                left: 18px;
                font-size: 20px;
                color: white;
            }    
        
            #vista_previa_credencial #documento
            {
                position: absolute;
                top: 252px;
                left: 66px;
                font-size: 20px;
                color: white;
            }    
            
            #vista_previa_credencial #titulo_documento
            {
                position: absolute;
                top: 252px;
                left: 18px;
                font-size: 20px;
                color: white;
            }             
               
            .label_combo
            {
                width: 250px;
                text-align: right;
                margin-right: 10px;
            }
            
            .combo
            {
                width: 470px;;
            }
            
            .etiqueta_campo
            {
                color: Red;
                text-align: right;
                float: right;
                margin-right: 34px;
            }
            
            #btn_cambiar_foto
            {
                position: absolute;
                bottom: 10px;
                left: 48px;
            }
        </style>
    </head>
<body>
    <form id="form1" runat="server">
    <%--<uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />--%>
    <div class="container-fluid">
        <h1 style="text-align:center; margin:17px; "></h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq"></div>
            
            <div class="caja_der papel">
                <legend style="margin-top: 20px;"></legend>
            

              <div style = "width:100%; text-align: center"; id="botonera_credenciales">
                <%--<div  style="display: inline-block;" > <button type="button" id="Button1" class="btn btn-primary">Ver credencial vigente</button></div>
                <div  style="display: inline-block;" > <button type="button" id="btn_credencial_vigente" class="btn btn-primary">Ver última credencial vigente</button></div>
                <div  style="display: inline-block;" > <button type="button" id="btn_aviso_solicitud" class="btn btn-danger">Tiene una solicitud pendiente de aprobación</button></div>
                <div  style="display: inline-block;" > <button type="button" id="btn_renovar_credencial" class="btn btn-primary">Solicitar nueva credencial</button></div>
                <div  style="display: inline-block;" > <button type="button" id="btn_historial_credenciales" class="btn btn-primary">Historial de credenciales</button></div>--%>
                
                <div  style="display: inline-block;" > <button type="button" id="btn_Estado" class="btn btn-primary">Agregar servicio administración pública</button></div>
                <div  style="display: inline-block;" > <button type="button" id="btn_Privado" class="btn btn-primary">Agregar servicio administración privada</button></div>

                </div>
                <br />

                <div id="TablaHistoriaCredencial" class="table table-striped table-bordered table-condensed" >
                </div>


              

            <div id="cajaSolicitudCredencial" style="display:none;" class="">
                <h3 style="text-align: center;">Solicitud de Credencial</h3>
                <br />
                <h4 id="titulo_vista_previa">Vista Previa Credencial</h4>
                <div id="vista_previa_credencial">
                    <%--<img id="imagen_credencial" src="../BarraMenu/credencialMds.png"/>--%>
                    <div id="foto_usuario"></div>
                    <div id="apellido"></div>    
                    <div id="nombres"></div>    
                    <div id="titulo_documento">DNI:</div>    
                    <div id="documento"></div>    
                </div>
                <a id="btn_cambiar_foto" > Cambiar foto de perfil y credencial </a>
                <div id="panel_derecho_credencial">
                    <div class="">
                        <label class="label_combo" for="select_motivo">Indique el Motivo del pedido:</label>
                        <select class="combo" id="select_motivo">
                            <option value="0">--</option>
                            <option value="1">Deterioro</option>
                            <option value="2">Pérdida</option>
                            <option value="3">Robo</option>
                            <option value="4">Nunca tuve</option>
                        </select>                       
                    </div>
                    <br />
                    <div class="">
                        <label class="label_combo" for="select_organismo">Indique a que Organismo pertenece:</label>
                        <select class="combo" id="select_organismo">
                                
                        <option value="1">Ministerio de Desarrollo Social</option>
                        <%--   <option value="2">Ministerio de Salud</option>
                        <option value="3">Externo</option>     --%>
                        </select>                    

                    </div>
                    <br />
                    <div class="">
                        <label class="label_combo" for="cmb_lugar_de_entrega">Seleccione lugar de entrega:</label>
                        <select class="combo" id="cmb_lugar_de_entrega">                                
                        </select>                    

                    </div>
                    <br />

                    <label class="etiqueta_campo">Al hacer la solicitud, su credencial vigente será dada de baja.</label>
                  
                    <br/>
                    <label id = "texto_robo" class="etiqueta_campo" " for="cmb_provincia">*Para el caso de pérdida/robo debe presentar la denuncia policial, o Declaración Jurada firmada por el superior directo (Rango de Director o Superior), al momento de retirar la nueva credencial 
                        <a target="_blank" href="Files/DDJJCredencialPerdidaoRobo.pdf">Descargar modelo de DDJJ</a>
                    </label>
                    <label id = "texto_deterioro" class="etiqueta_campo" for="cmb_provincia">*Para el caso de credencial deteriorada, la misma debe devolverse al momento de retirar la nueva. </label>
                    <label id = "texto_seleccione_motivo" class="etiqueta_campo" for="cmb_provincia">*Seleccione un motivo </label>
                    <br />
                    <input  id="btn_realizar_solicitud" value="Solicitar nueva credencial" class="btn btn-primary" type="button" />
                </div>          
            </div>


                 <div id="cajaCambiarDomicilio" style="display:none;" class="">
                 <h3 style="text-align: center;">Solicitud de actualización de domicilio</h3>
                    <br />
                        <div class="">
                            <p><em style="color:Red;">*</em> Campos Obligatorios</p>
                            <label class="etiqueta_campo" style="margin-right: 28px;" for="txt_calle">Calle: <em style="color:Red;">*</em></label>
                            <input type="text" value="" id="txt_calle" name="txt_calle" style="width: 250px; height: 30px;" />
                            <label class="etiqueta_campo" style="margin: 0 10px;" for="txt_numero">N°: <em style="color:Red;">*</em></label>
                            <input type="number" value="" id="txt_numero" name="txt_numero" style="width: 50px; height: 30px;" />

                                <label class="etiqueta_campo" style="margin: 0 10px;" for="txt_piso">Piso: </label>
                                <input type="text" value="" id="txt_piso" name="txt_piso" style="width: 30px; height: 30px;" />

                                <label class="etiqueta_campo" style="margin: 0 10px;" for="txt_dto">Dpto: </label>
                                <input type="text" value="" id="txt_dto" name="txt_dto" style="width: 30px; height: 30px;" />

                                 <label class="etiqueta_campo_small" style="margin: 0 10px;" for="txt_cp">C.P.: <em style="color:Red;">*</em></label>
                                <input type="text" value="" id="txt_cp" name="txt_cp" style="width: 50px; height: 30px;" />
                            </div>

                            <div class="">
                                <label class="etiqueta_campo" style="margin-right: 13px;" for="txt_calle">Manzana:</label>
                                <input type="text" value="" id="txt_manzana" name="txt_calle" style="width: 30px; height: 30px;" />
                                <label class="etiqueta_campo" style="margin: 0 10px;" for="txt_numero">Barrio:</label>
                                <input type="text" value="" id="txt_barrio" name="txt_numero" style="width: 30px; height: 30px;" />

                                <label class="etiqueta_campo" style="margin: 0 10px;" for="txt_piso">Torre:</label>
                                <input type="text" value="" id="txt_torre" name="txt_piso" style="width: 30px; height: 30px;" />

                                <label class="etiqueta_campo" style="margin: 0 10px;" for="txt_dto">Uf:</label>
                                <input type="text" value="" id="txt_uf" name="txt_dto" style="width: 30px; height: 30px;" />

                                 <label class="etiqueta_campo_small" style="margin: 0 10px;" for="txt_cp">Casa:</label>
                                <input type="text" value="" id="txt_casa" name="txt_cp" style="width: 30px; height: 30px;" />
                            </div>

                            <div class="">
                                <label class="etiqueta_campo" for="cmb_provincia">Provincia: <em style="color:Red;">*</em></label>
                                <select id="cmb_provincia" style="width: 200px;"></select>

                                <label class="etiqueta_campo_small" for="cmb_localidad">Localidad: <em style="color:Red;">*</em></label>
                                <select id="cmb_localidad" style="width: 250px;"></select>
                            </div>
                            <br />
                            <div style="text-align:center;">
                                <input  id="btnCambiarDomicilio" value="Solicitar Cambio" class="btn btn-primary" type="button" />
                            </div>
                            
                        </div>

                <legend style="margin-top: 20px;">Servicio Administración Pública</legend>
                    <div id="tabla_Serv_Adm_Publico">
    
                    </div>
                   
                    <legend style="margin-top: 50px;">Servicio Administración Privada</legend>
                    <div id="tabla_Serv_Adm_Privada">
    
                    </div>
                    <%--<table id="tabla_Serv_Adm_Privada" class="table table-striped table-bordered table-condensed"></table>--%>

                    <%--<legend style="margin-top: 20px;">ESTUDIOS</legend>
                    <div id="tabla_estudios"></div>--%>

                </div>
               
            </div>
        

         <%--<div class="cajaEstudioOculta">
            <img src="../Imagenes/diploma.png" class="img_caja_estudio" alt="diploma" />
            <div class="div_dentro_de_caja_estudio" >
                <p><span class="titulo"></span> (<span class="nivel"></span>)</p>
                <p>Fecha Egreso: <span class="fecha"></span> </p>
            </div>
        </div>--%>

        <div class="plantillas" style="display: none">
           
        </div>
    </form>
</body>

<%--<script type="text/javascript" src="Legajo.js"></script>--%>
<script type="text/javascript" src="../../Scripts/Spin.js"></script>
<script type="text/javascript" src="../../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript" src="MenuAntiguedad.js"></script>

<%--<script type="text/javascript" >
    $("#btn_credencial_vigente").hide();
    $(document).ready(function ($) {


        $("#texto_deterioro").hide();
        $("#texto_robo").hide();
        $("#texto_seleccione_motivo").hide();
        $("#btn_aviso_solicitud").hide();
        $("#btn_renovar_credencial").hide();
        $("#btn_historial_credenciales").hide();
        $("#botonera_credenciales").hide();
        Backend.start(function () {
            //para cargar el menu izquierdo 
            $(".caja_izq").load("SeccionIzquierda.htm", function () {

                Legajo.getNombre();
                Legajo.getDatosPersonales();
                Legajo.getDatosFamiliares();
                Legajo.getPsicofisicos();
                Legajo.getEstudios();
                Legajo.getCredencialesUsuario();
            });

            Backend.GetUsuarioLogueado().onSuccess(function (usuario) {

                if (usuario.Owner.IdImagen == -1) {


                    $("#cajaAgregarFotoPerfil").show();
                    $("#botonera_credenciales").hide();
                    $("#btn_cargar_foto").click(function () { $("#contenedor_foto_usuario").click(); });

                }
                else {

                    Backend.GetSolicitudesDeCredencialPorPersona().onSuccess(function (solicitudes) {

                        $("#botonera_credenciales").show();
                        if (_.some(solicitudes, function (sol) {
                            if (sol.Id == 0) return false;
                            if (sol.Estado == "ENTREGADO") return false;
                            if (sol.Estado == "RECHAZADO") return false;
                            return true;
                        })) {
                            $("#btn_aviso_solicitud").show();
                            $("#btn_renovar_credencial").hide();
                        }
                        else {
                            $("#btn_aviso_solicitud").hide();
                            $("#btn_renovar_credencial").show();
                        }
                        $("#btn_historial_credenciales").show();
                    });

                }

            });

            
            
            Backend.GetCredencialesTodasDePortal().onSuccess(function (credenciales) {
                var credencial_vigente = _.find(credenciales, function (c) { return c.Estado == "VIGENTE" });
                if (credencial_vigente) {
                    $("#btn_credencial_vigente").show();
                    $("#btn_credencial_vigente").click(function () {
                        var div = $("<div>");
                        div.load(window.location.origin + '/Componentes/CredencialVigente.htm', function () {
                            Componente.start(false, div);
                        });
                    });
                    //

                }

                $('#btn_renovar_credencial').click(function () {

                    //var ui = $("#cajaCambiarDomicilio");

                    vex.defaultOptions.className = 'vex-theme-os';
                    vex.open({
                        afterOpen: function ($vexContent) {
                            var ui = $("#cajaSolicitudCredencial").clone();
                            $vexContent.append(ui);
                            Backend.GetUsuarioLogueado().onSuccess(function (usuario) {
                                ui.find("#apellido").text(usuario.Owner.Apellido);
                                ui.find("#nombres").text(usuario.Owner.Nombre);
                                ui.find("#documento").text(usuario.Owner.Documento);

                                var img = new VistaThumbnail({
                                    id: usuario.Owner.IdImagen,
                                    contenedor: ui.find("#foto_usuario")
                                });                               
                            });

                            ui.find("#btn_cambiar_foto").click(function () { $("#contenedor_foto_usuario").click(); });

                            Backend.GetLugaresEntregaCredencial()
                                    .onSuccess(function (lugares) {
                                        _.forEach(lugares, function (lugar) {
                                            var opt = $("<option>");
                                            opt.text(lugar.Descripcion);
                                            opt.attr("value", lugar.IdLugar);
                                            ui.find("#cmb_lugar_de_entrega").append(opt);
                                        });
                                    });
                            ui.find("#select_motivo").change(function () {
                                var val = ui.find("#select_motivo").val();

                                if (val == 0) {
                                    ui.find("#texto_seleccione_motivo").show();
                                    ui.find("#texto_deterioro").hide();
                                    ui.find("#texto_robo").hide();
                                }

                                if (val == 1) {
                                    ui.find("#texto_deterioro").show();
                                    ui.find("#texto_robo").hide();
                                    ui.find("#texto_seleccione_motivo").hide();
                                }

                                if (val == 2) {
                                    ui.find("#texto_deterioro").hide();
                                    ui.find("#texto_robo").show();
                                    ui.find("#texto_seleccione_motivo").hide();
                                }

                                if (val == 3) {
                                    ui.find("#texto_deterioro").hide();
                                    ui.find("#texto_robo").show();
                                    ui.find("#texto_seleccione_motivo").hide();
                                }

                                if (val == 4) {
                                    ui.find("#texto_deterioro").hide();
                                    ui.find("#texto_robo").hide();
                                    ui.find("#texto_seleccione_motivo").hide();
                                }

                            });

                            ui.find("#btn_realizar_solicitud").click(function () {
                                if (ui.find("#select_motivo").val() == 0) {
                                    return;
                                }

                                Backend.SolicitarRenovacionCredencial(ui.find("#select_motivo").val(), ui.find("#select_organismo").val(), ui.find("#cmb_lugar_de_entrega").val()).onSuccess(function () {
                                    alertify.success("Solicitud creada con éxito");

                                    vex.close();
                                    setTimeout(function () { location.reload(); }, 1000);
                                });
                            });


                            ui.show();
                        },
                        css: {
                            'padding-top': "4%",
                            'padding-bottom': "0%"
                        },
                        contentCSS: {
                            width: "80%",
                            height: "90%"
                        }
                    });
                    //$('#cajaCambiarDomicilio').show();
                });
            });
        });
    });

</script> --%>
</html>

