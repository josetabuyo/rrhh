<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreInscripcion.aspx.cs" Inherits="FormularioConcursar_PreInscripcion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
     <link rel="stylesheet" type="text/css" href="EstilosPostular.css" />
</head>
<body>
    <form id="form1" runat="server" class="cmxform">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>PostulAR</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <div class="contenedor_concursar">

    <div class="navbar">
        <div class="navbar-inner">
        <div class="container">
            <a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-responsive-collapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            </a>
            <a class="brand" href="#"></a>
            <div class="nav-collapse navbar-responsive-collapse">
            <ul id="Ul1" class="nav"  runat="server">
                <li><a href="PanelDeControl.aspx" >Panel de Control</a></li>
                <li><a href="#" >Postulaciones</a></li>
                <li><a href="CargaInformacionPersonal.aspx" >MI CV</a></li>
            </ul>
       
            <ul id="Ul2" class="nav pull-right"  runat="server">
            </ul>
            </div><!-- /.nav-collapse -->
        </div>
        </div><!-- /navbar-inner -->
    </div><!-- /navbar -->
    
        <a style="margin-right: 10px;" class="btn btn-primary" href="#">Guardar Cambios </a>
        <a class="btn btn-primary" href="Inscripcion.aspx">Confirmar Postulación</a>
        <a id="go5" rel="leanModal" class="link" name="modal_mensaje"  href="#modal_mensaje">MODALLLLLL</a>
            <div class="fondo_form">
                <fieldset style="width:100%; min-width:800px;" >
                    <p><em>*</em> Campos Obligatorios</p>
                    <p style="text-transform:uppercase; font-weight:bold;">I.- Editar información personal</p>
                    <div style="float:left; margin:8px;" >
                        <label for="nombre" class="">Nombre <em>*</em></label>
                        <input id="nombre" type="text" style="width:150px;" value="Nestor"  />
                    </div>
                    <div style="float:left; margin:8px;">
                        <label for="apellido">Apellido <em>*</em></label>
                        <input id="apellido" type="text" style="width:150px;" value="Kirner" />
                    </div>
                    <div style="float:left; margin:8px;">
                        <label for="cmb_nivel_educativo">Sexo <em>*</em></label>
                        <select id="cmb_nivel_educativo" style="width:100px;" name="cmb_sexo" >
                            <option value="-1">Sexo</option>
                            <option value="1" selected="selected">Masculino</option>
                            <option value="1">Femenino</option>
                        </select>
                    </div>
                    <div style="float:left; margin:8px;">
                        <label for="cmb_estadoCivil">Estado Civil <em>*</em></label>
                        <select id="cmb_estadoCivil" name="cmb_estado_civil" style="width:150px;" >
                        <option value="-1">Estado Civil</option>
                        <option value="1" selected="selected">Masculino</option>
                        <option value="1">Femenino</option>
                        </select>
                        </div>
                    <div style="float:left; margin:8px; width:130px;">
                        <label for="cuil">Cuil / Cuit <em>*</em></label>
                        <input id="cuil" type="text" style="width:120px;" value="20-22114543-5" />
                        <span style="float:left;">Ej.:20-22114543-5</span>
                    </div>
                    <div style="float:left; clear:left; margin:8px">
                            <label class="" for="cmb_nivel_educativo">Lugar nacimiento <em>*</em></label>
                            <select id="Select1" style="width:120px;" name="cmb_nivel_educativo" >
                            <option value="-1">Seleccione</option>
                            <option value="1" selected="selected">Argentina</option>
                            <option value="1">Bolivia</option>
                            </select>
                    </div>
                    <div style="float:left; margin:8px">
                        <label class="" for="txt_categoria_docente">Fecha Nac <em>*</em></label>
                        <input type="text" id="txt_categoria_docente" value="18/05/2005" style="width:120px;" name="txt_categoria_docente" size="10"/>
                    </div>
                    <div style="float:left; margin:8px">
                    <label class="" for="cmb_nivel_educativo">Nacionalidad <em>*</em></label>
                        <select id="Select2" style="width:120px;" name="cmb_nivel_educativo" >
                        <option value="-1">Seleccione</option>
                        <option value="1" selected="selected">Argentina</option>
                        <option value="1">Boliviano</option>
                        </select>
                    </div>
                    <div style="float:left; margin:8px">
                    <label class="" for="cmb_nivel_educativo">Tipo documento <em>*</em></label>
                    <select id="Select3" style="width:100px;" name="cmb_nivel_educativo" >
                        <option value="-1" selected="selected">DNI</option>
                        <option value="1">LC</option>
                        <option value="1">LE</option>
                    </select>
                    </div>
                    <div style="float:left; margin:8px">
                        <label class="" for="documento">Nro documento <em>*</em></label>
                        <input id="documento" type="text" style="width:150px;" value="22114523" />
                    </div>
                    <div style="float:left; margin:8px">
                    <label class="" for="txt_categoria_docente">Calle <em>*</em></label>
                    <input type="text" id="Text1" name="txt_categoria_docente" size="20" value="Tinogasta"/>
                    </div>

                    <div style="float:left; margin:8px; width:60px;">
                    <label class="" for="txt_caracter_designacion">Número <em>*</em></label>
                    <input type="text" id="txt_caracter_designacion" name="txt_caracter_designacion" style="width:50px" value="3222"/>
                    </div>      
                    <div style="float:left; margin:8px; width:60px;">
                    <label class="" for="txt_dedicacion_docente">Piso</label>
                    <input type="text" id="txt_dedicacion_docente" name="txt_dedicacion_docente" style="width:50px" value="1"/>
                    </div>
                    <div style="float:left; margin:8px; width:80px;">     
                        <label class="" for="txt_carga_horaria">Dto</label>
                        <input type="text" id="txt_carga_horaria" name="txt_carga_horaria" style="width:50px" value="C"/>
                    </div>
                    <div style="float:left; margin:8px">
                        <label class="" for="txt_fecha_inicio">Localidad <em>*</em></label>
                        <input type="text" id="txt_fecha_inicio" name="txt_fecha_inicio" style="width:100px" value="CABA"/> 
                    </div>
                    <div style="float:left; margin:8px">
                        <label class="" for="txt_fecha_fin">Código postal <em>*</em></label>
                        <input type="text" id="txt_fecha_fin" name="txt_fecha_fin" style="width:80px" value="1427"/><br/>
                    </div>
                    <div style="float:left; margin:8px">     
                    <label class="" for="cmb_nivel_educativo">Provincia <em>*</em></label>
                    <select id="Select4" name="cmb_nivel_educativo" style="width:130px;" >
                        <option value="-1">Seleccione</option>
                        <option value="1" selected="selected">Buenos Aires</option>
                        <option value="1">Cordoba</option>
                    </select>
                    </div>
                </fieldset>
                <fieldset style="width:100%;" >
		            <p style="font-weight:bold; text-transform:uppercase;">II.- Información Requerida Para Recibir Notificaciones y Avisos</p>
	                <div style="float:left; margin:8px">
                        <label class="" for="txt_categoria_docente">Calle <em>*</em></label>
                        <input type="text" id="Text2" name="txt_categoria_docente" size="20" value="Tinogasta"/>
                    </div>

                    <div style="float:left; margin:8px; width:60px;">
                        <label class="" for="txt_caracter_designacion">Número <em>*</em></label>
                        <input type="text" id="Text3" name="txt_caracter_designacion" style="width:50px" value="1427"/>
                    </div>
       
                    <div style="float:left; margin:8px; width:60px;">
                        <label class="" for="txt_dedicacion_docente">Piso</label>
                        <input type="text" id="Text4" name="txt_dedicacion_docente" style="width:50px" value="1"/>
                    </div>

                    <div style="float:left; margin:8px; width:80px;">     
                        <label class="" for="txt_carga_horaria">Dto</label>
                        <input type="text" id="Text5" name="txt_carga_horaria" style="width:50px" value="C"/>
                    </div>

                    <div style="float:left; margin:8px">
                        <label class="" for="txt_fecha_inicio">Localidad <em>*</em></label>
                        <input type="text" id="Text6" name="txt_fecha_inicio" style="width:100px" value="CABA"/> 
                    </div>

                    <div style="float:left; margin:8px">
                        <label class="" for="txt_fecha_fin">Código postal <em>*</em></label>
                        <input type="text" id="Text7" name="txt_fecha_fin" style="width:50px" value="1427"/><br/>
                    </div>

                    <div style="float:left; margin:8px">     
                    <label class="" for="cmb_nivel_educativo">Provincia <em>*</em></label>
                    <select id="Select5" name="cmb_nivel_educativo" style="width:150px;" >
                        <option value="-1">Seleccione</option>
                        <option value="1" selected="selected">Buenos Aires</option>
                        <option value="1">Cordoba</option>
                    </select>
                    </div>
                    </fieldset>
            </div>


        </div>

        <div id="modal_mensaje" class="form_concursar" >
		    <div id="modal_mensaje-ct">
			    <div id="modal_mensaje-header" class="form_concursar_header">
				    <h2>Mensaje</h2>
				    <p></p>
				     <a class="modal_close_concursar" href="#"></a>
			    </div>
				<div id="Div6" class="fondo_form">
                    <fieldset style="width:95%; padding-left:3%;" >
                        <p>Usted está por confirmar su postulación.</p>
                        <p>Si desea revisar y modificar su curriculum puede hacerlo antes de postularse.</p>
                        <p>Una vez que haya modificado su curriculum presione el botón de "Guardar Cambios".</p>
                        <p>PARA POSTULARSE PRESIONE EL BOTON "Confirmar Postulación"</p>
                    </fieldset>
                </div>	         
		    </div>
        </div> 

        <asp:HiddenField ID="curriculum" runat="server" />
        <asp:HiddenField ID="puesto" runat="server" />
    </form>



</body>
 <%= Referencias.Javascript("../") %>
 <script type="text/javascript">

     $(document).ready(function () {

         
         $('a[rel*=leanModal]').leanModal({ top: 300, closeButton: ".modal_close_concursar" });
     
    });
       
</script>
</html>
