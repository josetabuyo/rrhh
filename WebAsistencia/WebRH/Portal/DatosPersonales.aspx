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
        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        <link rel="stylesheet"  href="estilosPortalSecciones.css" />
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="container-fluid">
        <h1 style="text-align:center; margin:17px; "></h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq"></div>
            <div class="caja_der papel">
            <legend style="margin-top: 20px;">MIS DATOS</legend>
                <div class="cajitas">
                   <p class=""><label class="item_cajita">Legajo: </label> <span id="legajo"></span></p>
                    <p class=""><label class="item_cajita">Documento: </label> <span id="dni"></span></p>
                </div>
                 <div class="cajitas">
                    <p><label  class="item_cajita">Edad: </label> <span id="edad"></span></p>
                    <p class=""><label class="item_cajita">F. Nacimiento: </label> <span id="fechaNac"></span></p>
                </div>
                <div class="cajitas">
                    <p class=""><label class="item_cajita">Sexo: </label> <span id="sexo"></span></p>
                    <p class=""><label class="item_cajita">Estado Civil: </label> <span id="estadoCivil"></span></p>
                 </div>
                 <div class="cajitas">
                    <p class=""><label class="item_cajita">CUIL: </label> <span id="cuil"></span></p>
                    <p class=""><label class="item_cajita">Domicilio: </label> <span id="domicilio"></span>
                    <img id="btnMostrarDomicilio" style="cursor:pointer; " title="Cambiar Domicilio" src="../Imagenes/edit.png" width="30px" height="30px" />
                    <%--<input id="btnMostrarDomicilio" value="Cambiar Domicilio" class="btn btn-primary" type="button" />--%>
                    <div style="display:none; color:Red;" id="mensajeCambioDomicilioPendiente">
                        <span>Solicitud Pendiente de Aprobación</span>
                        Actualizar N° GDE del Form.<input id="numeroGDE" placeholder="IF-2017-xxxxx" style="width: 50px; height: 30px;"  type="text" />
                        <input id="btnGenerarPDF" value="Generar PDF" class="btn btn-primary" type="button" />
                    </div>
                    
                    </p>
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

                            <label class="etiqueta_campo" style="margin-right: 13px;" for="txt_tel">Tel.: </label> <input id="txt_tel" style="width: 100px; height: 30px;" name="txt_tel" type="text" value="" /><label class="etiqueta_campo" style="margin: 0 10px;" for="txt_email">Cel: </label> <input id="txt_cel" style="width: 100px; height: 30px;" name="txt_cel" type="text" value="" />

                            <br />
                            <div style="text-align:center;">
                                <input  id="btnCambiarDomicilio" value="Solicitar Cambio" class="btn btn-primary" type="button" />
                            </div>
                            
                        </div>

                <legend style="margin-top: 20px;">DATOS FAMILIARES</legend>
                    <div id="tabla_familiar">
    
                    </div>
                   
                    <legend style="margin-top: 50px;">EXÁMENES PSICOFÍSICOS</legend>
                    <table id="tabla_psicofisicos" class="table table-striped table-bordered table-condensed">
                        
                    </table>

                    <legend style="margin-top: 20px;">ESTUDIOS</legend>

                    <div id="tabla_estudios">
    
                    </div>

                </div>
               
            </div>
        </div>

         <div class="cajaEstudioOculta">
            <img src="../Imagenes/diploma.png" class="img_caja_estudio" alt="diploma" />
            <div class="div_dentro_de_caja_estudio" >
                <p><span class="titulo"></span> (<span class="nivel"></span>)</p>
                <p>Fecha Egreso: <span class="fecha"></span> </p>
            </div>
        </div>

    </form>
</body>
<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>
<script type="text/javascript" >

    $(document).ready(function ($) {
        //para cargar el menu izquierdo 
        $(".caja_izq").load("SeccionIzquierda.htm", function() {
            Backend.start(function () {
                Legajo.getNombre();
                Legajo.getDatosPersonales();
                Legajo.getDatosFamiliares();
                Legajo.getPsicofisicos();
                Legajo.getEstudios();
            });
        });

        

    });

</script> 
</html>
