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
        <h1 style="text-align:center; margin:30px; "></h1>
        <div style="margin: 0 auto;" class="row">
            <div style="text-align:center;" class="caja_izq"></div>
            <div class="caja_der papel">
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
                    <p class=""><label class="item_cajita">Domicilio: </label><span id="domicilio"></span>
                    <input id="btnMostrarDomicilio" value="Cambiar Domicilio" class="btn btn-primary" type="button" />
                    </p>
                 </div>

                 <div id="cajaCambiarDomicilio" style="display:none;" class="">
                 <div class="">
                                <label class="etiqueta_campo" for="txt_calle">
                                    Calle <em>*</em></label>
                                <input type="text" id="txt_calle" name="txt_calle" style="width: 350px;" />
                            </div>
                            <div class="">
                                <label class="etiqueta_campo" for="txt_numero">
                                    Número <em>*</em></label>
                                <input type="text" id="txt_numero" name="txt_numero" style="width: 50px" />
                            </div>
                            <div class="">
                                <label class="etiqueta_campo" for="txt_piso">
                                    Piso</label>
                                <input type="text" id="txt_piso" name="txt_piso" style="width: 30px" />
                            </div>
                            <div class="">
                                <label class="etiqueta_campo" for="txt_dto">
                                    Dpto</label>
                                <input type="text" id="txt_dto" name="txt_dto" style="width: 30px" />
                            </div>
                            <div class="">
                                <label class="etiqueta_campo_small" for="txt_cp">
                                    Código Postal <em>*</em></label>
                                <input type="text" id="txt_cp" name="txt_cp" style="width: 80px" />
                            </div>
                            <div class="">
                                <label class="etiqueta_campo" for="cmb_provincia">
                                    Provincia <em>*</em></label>
                                <select id="cmb_provincia" style="width: 320px;">
                                
                                </select>
                            </div>
                            <div class="">
                                <label class="etiqueta_campo_small" for="cmb_localidad">
                                    Localidad <em>*</em></label>
                                <select id="cmb_localidad" style="width: 320px;">
                                </select>
                            </div>
                            <input id="btnCambiarDomicilio" value="Cambiar" class="btn btn-primary" type="button" />
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
