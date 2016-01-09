<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Formularios.aspx.cs" Inherits="Formularios_Formularios" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title>Formularios</title>
        <%= Referencias.Css("../")%>   
         <link rel="stylesheet" type="text/css" href="EstilosFormularios.css" />
       
        
        <%= Referencias.Javascript("../")%>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:18px; font-weight: bold;'></span> <br/> <span style='font-size:18px;font-weight: bold;'> Menú Principal </span>" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" UrlPassword="../" />        
    <div>
        <p>Buscar persona:</p>
        <input type="text" />
        <input type="button" value="Buscar" />
    </div>
    <h1 style="text-align:center;">Relevamiento de Contratos</h1>
        <hr />
        <div class="contenedor_formulario">
            <p>1) Datos Personales:</p>
            <div class="bloque">  
                  
                <label class="etiqueta_campo" for="cmb_tipoDocumento" style="width:50px;" >
                    Tipo y Número de Documento <em>*</em></label>
                <select id="cmb_tipoDocumento" name="tipo_documento" style="width: 50px;" rh-control-type="combo" rh-data-provider="TiposDeDocumento"
                    rh-model-property="TipoDocumento" data-validar="haySeleccionEnCombo">
                </select>
                <input id="txt_documento" name="documento" type="text" style="width: 500px;" rh-control-type="textbox"
                    rh-model-property="Dni" data-validar="esNumeroNatural" />
            </div>
            <div class="bloque">
                <label for="nombre">Nombre <em>*</em></label>
                <input id="nombre" type="text" name="nombre" rh-control-type="textbox" rh-model-property="Nombre"
                    style="width: 295px;" data-validar="esNoBlanco" maxlength="100" />

                <label for="apellido" style="margin-left:15px;">Apellido <em>*</em></label>
                <input id="apellido" type="text" name="apellido" style="width: 295px;" rh-control-type="textbox"
                    rh-model-property="Apellido" data-validar="esNoBlanco" />
            </div>
            <div class="bloque">
                <label for="nivel">Nivel <em>*</em></label>
                <input id="nivel" type="text" name="nivel" rh-control-type="textbox" rh-model-property="Nivel"
                    style="width: 50px;" data-validar="esNoBlanco" maxlength="2" />
                <label for="grado" style="margin-left:15px;">Grado <em>*</em></label>
                <input id="grado" type="text" name="grado" style="width: 50px;" rh-control-type="textbox"
                    rh-model-property="Grado" data-validar="esNoBlanco" />
                <label class="etiqueta_campo" style="margin-left:15px;" for="cmb_modalidadContratacion">Modalidad de Contratación <em>*</em></label>
                <select id="modalidad" style="width: 330px" name="modalidad" rh-control-type="combo" rh-data-provider="xxxxxxx"
                    rh-model-property="Modalidad" data-validar="haySeleccionEnCombo"></select>
            </div>
            <div class="bloque">
                <p>Domicilio Particular</p>
                    <div class="bloque">
                        <label for="calle" style="display:inline-block; width:50px;">Calle: <em>*</em></label>
                        <input id="text_domicilio_calle_personal" name="domicilio_calle" type="text" placeholder="Calle" style="width:650px;" class="validar" />
                    </div>
                    <div class="bloque">
                        <label for="nro" style="display:inline-block; width:50px;">Nro: <em>*</em></label>
                        <input id="text_domicilio_nro_personal" name="domicilio_numero" type="number" placeholder="Nro" style="width: 10%;" class="validarNumero" />
                        <label for="piso" style="display:inline-block; width:40px; margin-left:2%;">Piso: <em>*</em></label>
                        <input id="text_domicilio_piso_personal" name="domicilio_piso" type="number" placeholder="Piso" style="width: 7%;" class="validarNumero" />
                        <label for="dto" style="display:inline-block; width:40px; margin-left:2%;">Dto: <em>*</em></label>
                        <input id="text_domicilio_depto_personal" name="domicilio_depto" type="text" placeholder="Depto" style="width: 7%;" class="validar" />
                        <label for="cp" style="display:inline-block; width:40px; margin-left:2%;">C.P: <em>*</em></label>
                        <input id="text_domicilio_cp_personal" name="domicilio_cp" type="text" placeholder="C.P." style="width: 11%;" class="validar" />
                    </div>
                    <div class="bloque">
                      
                        <label for="provincia">Provincia: <em>*</em></label>
                        <select id="cmb_provincia_personal" name="domicilio_provincia" class="cmb_provincia" ></select>
                        <label for="Localidad">Localidad: <em>*</em></label>
                        <select id="cmb_localidad_personal" name="domicilio_localidad" class="cmb_localidad" > </select>
                    </div>

                <p>Consignar nuevo domicilio particular solo en el caso que fuera pertinente:</p>
                    <br />
                   <div class="bloque">
                        <label for="calle">Calle: <em>*</em></label>
                        <input id="calle_nueva" name="domicilio_calle_nuevo" type="text" placeholder="Calle" style="width:100%;" class="validar" />
                    </div>
                    <div class="bloque">
                        <label for="nro_nuevo">Nro: <em>*</em></label>
                        <input id="nro_nuevo" name="domicilio_numero_nuevo" type="number" placeholder="Nro" style="width: 100px;" class="validarNumero" />
                        <label for="piso">Piso: <em>*</em></label>
                        <input id="piso_nuevo" name="domicilio_piso_nuevo" type="number" placeholder="Piso" style="width: 40px;" class="validarNumero" />
                        <label for="dto">Dto: <em>*</em></label>
                        <input id="dto_nuevo" name="domicilio_depto_nuevo" type="text" placeholder="Depto" style="width: 40px;" class="validar" />
                    </div>
                    <div class="bloque">
                        <label for="cp">C.P: <em>*</em></label>
                        <input id="cp_nuevo" name="domicilio_cp_nuevo" type="text" placeholder="C.P." style="width: 40px;" class="validar" />
                        <label for="provincia">Provincia: <em>*</em></label>
                        <select id="provincia_nuevo" name="domicilio_provincia_nuevo" class="cmb_provincia" ></select>
                        <label for="Localidad">Localidad: <em>*</em></label>
                        <select id="localidad_nuevo" name="domicilio_localidad_nuevo" class="cmb_localidad" > </select>
                    </div>
            </div>
            <hr />
            <p>2) Estudios Formales:</p>
            <p>Estudio Completo:</p>
        </div>
    </form>
</body>
</html>
