<%@ Page Language="C#" AutoEventWireup="true" CodeFile="coronavirusddjj.aspx.cs" Inherits="Permisos_DefinicionDeUsuario" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Portal RRHH</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width">
        <!-- CSS media query on a link element -->
        <%= Referencias.Css("../")%>
        <%= Referencias.Javascript("../")%>
        <link rel="stylesheet" href="estilosPortalSecciones.css" />
        

        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        <link rel="stylesheet" href="../Permisos/Permisos.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDePersonas.css" type="text/css"/>    
        <link rel="stylesheet" href="../estilos/SelectorDeAreas.css" type="text/css"/>   
         
        <link href="../scripts/vex-2.1.1/css/vex.css" rel="stylesheet">
        <link href="../scripts/vex-2.1.1/css/vex-theme-os.css" rel="stylesheet">
 

        <link href="../scripts/select2-3.4.4/select2.css" rel="stylesheet" type="text/css"/>
       
    </head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:18px; font-weight: bold; padding-top:25px;'>Datos<br/>Personales</span> <br/> " UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    
        <!--caja de contenido por debajo del menu-->
    <div style="width:99%; margin-left:11px; margin-right:11px">
        <!-- el back-ground lo setee abajo porque justo hay unn estilo en permisos de caja_izq con otro color de azul-->
        <!--<div style="background-image: linear-gradient(to bottom, rgb(1,70,99), rgb(1,70,99))" class="caja_izq no-print"></div>-->
        
        <!--contenido derecho -->
         <div  class="caja_derxxxx papelxxx" style="margin-top:32px;float:left;width:100% ">
           <!--modulo de importacion de recibos -->
           <div id="subcontenidoBusquedaRecibosConformados" class="panelDerOcultable" style="display: inline;"> 

               <div style="width:80%;margin:20pt;-webkit-border-radius: 7px 7px 0px 0px;
-moz-border-radius: 7px 7px 0px 0px;border-radius: 7px 7px 0px 0px;border-collapse: collapse;border: 0px solid #1C6EA4;padding-left:40pt;text-align: left;margin: 0 auto;">
                   <table class="" style="width:90%;margin:0 20pt 20pt 20pt;-webkit-border-radius: 7px 7px 0px 0px;
-moz-border-radius: 7px 7px 0px 0px;border-radius: 7px 7px 0px 0px;border-collapse: collapse;border: 0px solid rgb(1,70,99);">
             <tbody>
                 <tr><td style="background-image: linear-gradient(to bottom, rgb(1,70,99), rgb(1,70,99))/*linear-gradient(to bottom, #2574AD, #2574AD)*/; color: #fff;font-size: 13pt;font-weight: bold;text-align:center;padding:10px">Coronavirus - COVID-19 - Declaración Jurada</td></tr>
                 <tr><td>
                     <div style="padding:10px; border:1px; border-color:rgb(1,70,99);border-style:solid">
                         <div style="margin-top:0px;"><br />
                              <div style="margin-top:0px;float:right;margin-right:10px;"> <B>Fecha:</B> <script>
var f = new Date();
document.write(f.getDate() + "/" + (f.getMonth() +1) + "/" + f.getFullYear());
</script></div><br />
                         <span style="float:left;padding-top:3px;padding-right:5px;">Quien suscribe <B>MIRANDA, Fabián Adalberto (DNI 22.049.417)</B> manifiesto con carácter de Declaración Jurada que:</span><br /><br />
                         <span style="float:left;padding-top:3px;padding-right:5px;cursor: pointer">Con respecto al Artículo 7 <img src="../Imagenes/Ver-articulo-7.png"  alt="logosistema" onclick="window.open('../Imagenes/decreto-1.png')">del Decreto Nº 260/2020 (“Aislamiento Obligatorio. Acciones Preventivas”) y al Artículo 2 <img src="../Imagenes/Ver-articulo-2.png"  alt="logosistema" onclick="window.open('../Imagenes/decreto-2.png')">de la Resolución Nº 3/2020 de la Secretaría de Gestión y Empleo Público, que se transcriben debajo: </span><br />
                         </div>
                         <br />
                         <table class="table-condensed" style="width:94%">
                             <tbody class="list">
                                 <tr><td><input type="radio" name="comprendido" class="radio_listado" id="compno" style="cursor: pointer;margin: 2px;" value="compno" onclick="ocultar('capaSi')"><B>NO</B> me encuentro comprendido/a en los alcances de lo establecido por el Artículo 7 del Decreto Nº 260/2020</td></tr>
                                 <tr><td><input type="radio" name="comprendido" class="radio_listado" id="compsi" style="cursor: pointer;margin: 2px;" value="compsi" onclick="mostrar('capaSi')"><B>SI</B>, me encuentro comprendido/a en los alcances de lo establecido por el Artículo 7 del Decreto Nº 260/2020 y me comprometo a acreditar dicha situación, en el término de las próximas 48 hs., conforme lo dispuesto por el Artículo 2 de la Resolución Nº 3/2020 de la Secretaría de Gestión y Empleo Público.</td></tr>
                                 <tr><td><div id="capaSi" style="display:none">
                                     <table class="table-condensed" style="width:94%;margin-left:30px;border: 1px solid #ddd;">
                                        <tbody class="list">
                                            <tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:280px;text-align:center;width:10px"></td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:280px;text-align:center;width:45%; border:1px solid">Situación</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center;width:45%">Forma de Acreditación</td></tr>
                                            <tr><td style="width:10px;vertical-align:top;border: 1px solid #ddd"><input type="radio" class="radio_listado" id="comp1" style="cursor: pointer;margin: 2px;" value="comps1"><b>a)</b></td><td style="vertical-align:top;border: 1px solid #ddd">Caso sospechoso (Fiebre, uno o más síntomas respiratorios y, en los últimos días, historial de viaje a “zonas afectadas” o contacto con casos confirmados o probables de COVID-19.)</td><td style="vertical-align:top;border: 1px solid #ddd">Deberá acompañar la presente Declaración Jurada con Certificado Médico de Síntomas y completar el detalle de zonas visitadas</td></tr>
                                            <tr><td style="width:10px;vertical-align:top;border: 1px solid #ddd"><input type="radio" class="radio_listado" id="comp2" style="cursor: pointer;margin: 2px;" value="comps2"><b>b)</b></td><td style="vertical-align:top;border: 1px solid #ddd">Confirmación médica de haber contraído el COVID – 19</td><td style="vertical-align:top;border: 1px solid #ddd">Deberá acompañar la presente Declaración Jurada con Certificado Médico</td></tr>
                                            <tr><td style="width:10px;vertical-align:top;border: 1px solid #ddd"><input type="radio" class="radio_listado" id="comp3" style="cursor: pointer;margin: 2px;" value="comps3"><b>c)</b></td><td style="vertical-align:top;border: 1px solid #ddd">“Contactos estrechos” con personas comprendidas en los apartados a) y b)</td><td style="vertical-align:top;border: 1px solid #ddd">Esta Declaración Jurada oficia de acreditación suficiente.</td></tr>
                                            <tr><td style="width:10px;vertical-align:top;border: 1px solid #ddd"><input type="radio" class="radio_listado" id="comp4" style="cursor: pointer;margin: 2px;" value="comps4"><b>d)</b></td><td style="vertical-align:top;border: 1px solid #ddd">Arribo al país habiendo transitado por “zonas afectadas”</td><td style="vertical-align:top;border: 1px solid #ddd">Esta Declaración Jurada oficia de acreditación suficiente, con especial cuidado en la información vertida en el próximo ítem.</td></tr>
                                            
                                         </tbody>
                                    </table>

                                         </div></td>
                                 </tr>
                             </tbody>
                         </table>

                         <br />
                         Asimismo, cumplo en declarar, también con carácter de Declaración Jurada que:
                         <table class="table-condensed" style="width:94%">
                             <tbody class="list">
                                 <tr><td><input type="radio" class="radio_listado" name="ddjj" id="djj1" style="cursor: pointer;margin: 2px;" value="ddjjno" onclick="ocultar('capaVacaciones')"><B>NO</B> he usufructuado licencia anual ordinaria (Art 9 del Dcto N°3413/79) desde el 01/01/2020 a la fecha.</td></tr>
                                 <tr><td><input type="radio" class="radio_listado" name="ddjj" id="djj2" style="cursor: pointer;margin: 2px" value="ddjjsi" onclick="mostrar('capaVacaciones')"><B>SI</B>, he usufructuado licencia anual ordinaria (Art 9 del Dcto N°3413/79) en los siguientes términos:</td></tr>
                                 <tr><td><div id="capaVacaciones" style="display:none">
                                     <table class="table-condensed" style="width:94%;margin-left:30px;border: 1px solid #ddd">
                                        <tbody class="list">
                                            <tr><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:center;width:20px">Fecha Desde</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;width:20px;text-align:center;width:20px; border:1px solid">Fecha Hasta</td><td style="background-image: linear-gradient(to bottom, #2574AD, #2574AD); color: #fff;font-size: 9pt;font-weight: bold;text-align:left;width:80%">País o Países Visitados (indicar TODOS, incluidas las escalas, en caso de no haber salido de nuestro país, indicar “Argentina”)</td></tr>
                                            <tr><td style="width:20px;vertical-align:top;border: 1px solid #ddd;height:30px"><input type="date" id="opa1" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:20px;border: 1px solid #ddd;height:30px"><input type="date" id="opb1" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:80%;border: 1px solid #ddd;height:30px"><select name="pais1" id="pais1"><option value="" selected></option>
<option value="Afganistán" >Afganistán</option>
<option value="Albania" >Albania</option>
<option value="Alemania" >Alemania</option>
<option value="Andorra" >Andorra</option>
<option value="Angola" >Angola</option>
<option value="Anguila" >Anguila</option>
<option value="Antártida" >Antártida</option>
<option value="Antigua y Barbuda" >Antigua y Barbuda</option>
<option value="Antillas holandesas" >Antillas holandesas</option>
<option value="Arabia Saudí" ">Arabia Saudí</option>
<option value="Argelia" >Argelia</option>
<option value="Argentina" >Argentina</option>
<option value="Armenia" >Armenia</option>
<option value="Aruba" >Aruba</option>
<option value="Australia" >Australia</option>
<option value="Austria" >Austria</option>
<option value="Azerbaiyán" >Azerbaiyán</option>
<option value="Bahamas" >Bahamas</option>
<option value="Bahrein" >Bahrein</option>
<option value="Bangladesh" >Bangladesh</option>
<option value="Barbados" >Barbados</option>
<option value="Bélgica" >Bélgica</option>
<option value="Belice" >Belice</option>
<option value="Benín" >Benín</option>
<option value="Bermudas" >Bermudas</option>
<option value="Bhután" >Bhután</option>
<option value="Bielorrusia" >Bielorrusia</option>
<option value="Birmania" >Birmania</option>
<option value="Bolivia" >Bolivia</option>
<option value="Bosnia y Herzegovina" >Bosnia y Herzegovina</option>
<option value="Botsuana" >Botsuana</option>
<option value="Brasil" >Brasil</option>
<option value="Brunei" >Brunei</option>
<option value="Bulgaria" >Bulgaria</option>
<option value="Burkina Faso" >Burkina Faso</option>
<option value="Burundi" >Burundi</option>
<option value="Cabo Verde" >Cabo Verde</option>
<option value="Camboya" >Camboya</option>
<option value="Camerún" >Camerún</option>
<option value="Canadá" >Canadá</option>
<option value="Chad" >Chad</option>
<option value="Chile" >Chile</option>
<option value="China" >China</option>
<option value="Chipre" >Chipre</option>
<option value="Ciudad estado del Vaticano" >Ciudad estado del Vaticano</option>
<option value="Colombia" >Colombia</option>
<option value="Comores" >Comores</option>
<option value="Congo" >Congo</option>
<option value="Corea" >Corea</option>
<option value="Corea del Norte" >Corea del Norte</option>
<option value="Costa del Marfíl" >Costa del Marfíl</option>
<option value="Costa Rica" >Costa Rica</option>
<option value="Croacia" >Croacia</option>
<option value="Cuba" >Cuba</option>
<option value="Dinamarca" >Dinamarca</option>
<option value="Djibouri" >Djibouri</option>
<option value="Dominica" >Dominica</option>
<option value="Ecuador" >Ecuador</option>
<option value="Egipto" >Egipto</option>
<option value="El Salvador" >El Salvador</option>
<option value="Emiratos Arabes Unidos" >Emiratos Arabes Unidos</option>
<option value="Eritrea" >Eritrea</option>
<option value="Eslovaquia" >Eslovaquia</option>
<option value="Eslovenia" >Eslovenia</option>
<option value="España" >España</option>
<option value="Estados Unidos" >Estados Unidos</option>
<option value="Estonia" >Estonia</option>
<option value="c" >Etiopía</option>
<option value="Ex-República Yugoslava de Macedonia" >Ex-República Yugoslava de Macedonia</option>
<option value="Filipinas" >Filipinas</option>
<option value="Finlandia" >Finlandia</option>
<option value="Francia" >Francia</option>
<option value="Gabón" >Gabón</option>
<option value="Gambia" >Gambia</option>
<option value="Georgia" >Georgia</option>
<option value="Georgia del Sur y las islas Sandwich del Sur" >Georgia del Sur y las islas Sandwich del Sur</option>
<option value="Ghana" >Ghana</option>
<option value="Gibraltar" >Gibraltar</option>
<option value="Granada" >Granada</option>
<option value="Grecia" >Grecia</option>
<option value="Groenlandia" >Groenlandia</option>
<option value="Guadalupe" >Guadalupe</option>
<option value="Guam" >Guam</option>
<option value="Guatemala" >Guatemala</option>
<option value="Guayana" >Guayana</option>
<option value="Guayana francesa" >Guayana francesa</option>
<option value="Guinea" >Guinea</option>
<option value="Guinea Ecuatorial" >Guinea Ecuatorial</option>
<option value="Guinea-Bissau" >Guinea-Bissau</option>
<option value="Haití" >Haití</option>
<option value="Holanda" >Holanda</option>
<option value="Honduras" >Honduras</option>
<option value="Hong Kong R. A. E" >Hong Kong R. A. E</option>
<option value="Hungría" >Hungría</option>
<option value="India" >India</option>
<option value="Indonesia" >Indonesia</option>
<option value="Irak" >Irak</option>
<option value="Irán" >Irán</option>
<option value="Irlanda" >Irlanda</option>
<option value="Isla Bouvet" >Isla Bouvet</option>
<option value="Isla Christmas" >Isla Christmas</option>
<option value="Isla Heard e Islas McDonald" >Isla Heard e Islas McDonald</option>
<option value="Islandia" >Islandia</option>
<option value="Islas Caimán" >Islas Caimán</option>
<option value="Islas Cook" >Islas Cook</option>
<option value="Islas de Cocos o Keeling" >Islas de Cocos o Keeling</option>
<option value="Islas Faroe" >Islas Faroe</option>
<option value="Islas Fiyi" >Islas Fiyi</option>
<option value="Islas Malvinas Islas Falkland" >Islas Malvinas Islas Falkland</option>
<option value="Islas Marianas del norte" >Islas Marianas del norte</option>
<option value="Islas Marshall" >Islas Marshall</option>
<option value="Islas menores de Estados Unidos" >Islas menores de Estados Unidos</option>
<option value="Islas Palau" >Islas Palau</option>
<option value="Islas Salomón" >Islas Salomón</option>
<option value="Islas Tokelau" >Islas Tokelau</option>
<option value="Islas Turks y Caicos" >Islas Turks y Caicos</option>
<option value="Islas Vírgenes EE.UU." >Islas Vírgenes EE.UU.</option>
<option value="Islas Vírgenes Reino Unido" >Islas Vírgenes Reino Unido</option>
<option value="Israel" >Israel</option>
<option value="Italia" >Italia</option>
<option value="Jamaica" >Jamaica</option>
<option value="Japón" >Japón</option>
<option value="Jordania" >Jordania</option>
<option value="Kazajistán" >Kazajistán</option>
<option value="Kenia" >Kenia</option>
<option value="Kirguizistán" >Kirguizistán</option>
<option value="Kiribati" >Kiribati</option>
<option value="Kuwait" >Kuwait</option>
<option value="Laos" >Laos</option>
<option value="Lesoto" >Lesoto</option>
<option value="Letonia" >Letonia</option>
<option value="Líbano" >Líbano</option>
<option value="Liberia" >Liberia</option>
<option value="Libia" >Libia</option>
<option value="Liechtenstein" >Liechtenstein</option>
<option value="Lituania" >Lituania</option>
<option value="Luxemburgo" >Luxemburgo</option>
<option value="Macao R. A. E" >Macao R. A. E</option>
<option value="Madagascar" >Madagascar</option>
<option value="Malasia" >Malasia</option>
<option value="Malawi" >Malawi</option>
<option value="Maldivas" >Maldivas</option>
<option value="Malí" >Malí</option>
<option value="Malta" >Malta</option>
<option value="Marruecos" >Marruecos</option>
<option value="Martinica" >Martinica</option>
<option value="Mauricio" >Mauricio</option>
<option value="Mauritania" >Mauritania</option>
<option value="Mayotte" >Mayotte</option>
<option value="México" >México</option>
<option value="Micronesia" >Micronesia</option>
<option value="Moldavia" >Moldavia</option>
<option value="Mónaco" >Mónaco</option>
<option value="Mongolia" >Mongolia</option>
<option value="Montserrat" >Montserrat</option>
<option value="Mozambique" >Mozambique</option>
<option value="Namibia" >Namibia</option>
<option value="Nauru" >Nauru</option>
<option value="Nepal" >Nepal</option>
<option value="Nicaragua" >Nicaragua</option>
<option value="Níger" >Níger</option>
<option value="Nigeria" >Nigeria</option>
<option value="Niue" >Niue</option>
<option value="Norfolk" >Norfolk</option>
<option value="Noruega" >Noruega</option>
<option value="Nueva Caledonia" >Nueva Caledonia</option>
<option value="Nueva Zelanda" >Nueva Zelanda</option>
<option value="Omán" >Omán</option>
<option value="Panamá" >Panamá</option>
<option value="Papua Nueva Guinea" >Papua Nueva Guinea</option>
<option value="Paquistán" >Paquistán</option>
<option value="Paraguay" >Paraguay</option>
<option value="Perú" >Perú</option>
<option value="Pitcairn" >Pitcairn</option>
<option value="Polinesia francesa" >Polinesia francesa</option>
<option value="Polonia" >Polonia</option>
<option value="Portugal" >Portugal</option>
<option value="Puerto Rico" >Puerto Rico</option>
<option value="Qatar" >Qatar</option>
<option value="Reino Unido" >Reino Unido</option>
<option value="República Centroafricana" >República Centroafricana</option>
<option value="República Checa" >República Checa</option>
<option value="República de Sudáfrica" >República de Sudáfrica</option>
<option value="República Democrática del Congo Zaire" >República Democrática del Congo Zaire</option>
<option value="República Dominicana" >República Dominicana</option>
<option value="Reunión" >Reunión</option>
<option value="Ruanda" >Ruanda</option>
<option value="Rumania" >Rumania</option>
<option value="Rusia" >Rusia</option>
<option value="Samoa" >Samoa</option>
<option value="Samoa occidental" >Samoa occidental</option>
<option value="San Kitts y Nevis" >San Kitts y Nevis</option>
<option value="San Marino" >San Marino</option>
<option value="San Pierre y Miquelon" >San Pierre y Miquelon</option>
<option value="San Vicente e Islas Granadinas" >San Vicente e Islas Granadinas</option>
<option value="Santa Helena" >Santa Helena</option>
<option value="Santa Lucía" >Santa Lucía</option>
<option value="Santo Tomé y Príncipe" >Santo Tomé y Príncipe</option>
<option value="Senegal" >Senegal</option>
<option value="Serbia y Montenegro" >Serbia y Montenegro</option>
<option value="Sychelles" >Seychelles</option>
<option value="Sierra Leona" >Sierra Leona</option>
<option value="Singapur" >Singapur</option>
<option value="Siria" >Siria</option>
<option value="Somalia" >Somalia</option>
<option value="Sri Lanka" >Sri Lanka</option>
<option value="Suazilandia" >Suazilandia</option>
<option value="Sudán" >Sudán</option>
<option value="Suecia" >Suecia</option>
<option value="Suiza" >Suiza</option>
<option value="Surinam" >Surinam</option>
<option value="Svalbard" >Svalbard</option>
<option value="Tailandia" >Tailandia</option>
<option value="Taiwán" >Taiwán</option>
<option value="Tanzania" >Tanzania</option>
<option value="Tayikistán" >Tayikistán</option>
<option value="Territorios británicos del océano Indico" >Territorios británicos del océano Indico</option>
<option value="Territorios franceses del sur" >Territorios franceses del sur</option>
<option value="Timor Oriental" >Timor Oriental</option>
<option value="Togo" >Togo</option>
<option value="Tonga" >Tonga</option>
<option value="Trinidad y Tobago" >Trinidad y Tobago</option>
<option value="Túnez" >Túnez</option>
<option value="Turkmenistán" >Turkmenistán</option>
<option value="Turquía" >Turquía</option>
<option value="Tuvalu" >Tuvalu</option>
<option value="Ucrania" >Ucrania</option>
<option value="Uganda" >Uganda</option>
<option value="Uruguay" >Uruguay</option>
<option value="Uzbekistán" >Uzbekistán</option>
<option value="Vanuatu" >Vanuatu</option>
<option value="Venezuela" >Venezuela</option>
<option value="Vietnam" >Vietnam</option>
<option value="Wallis y Futuna" >Wallis y Futuna</option>
<option value="Yemen" >Yemen</option>
<option value="Zambia" >Zambia</option>
<option value="Zimbabue" >Zimbabue</option>
</select></td></tr>     
                                            <tr><td style="width:20px;vertical-align:top;border: 1px solid #ddd;height:30px"><input type="date" id="opa2" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:20px;border: 1px solid #ddd;height:30px"><input type="date" id="opb2" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:80%;border: 1px solid #ddd;height:30px"><select name="pais2" id="pais2"><option value="" selected></option>
<option value="Afganistán" >Afganistán</option>
<option value="Albania" >Albania</option>
<option value="Alemania" >Alemania</option>
<option value="Andorra" >Andorra</option>
<option value="Angola" >Angola</option>
<option value="Anguila" >Anguila</option>
<option value="Antártida" >Antártida</option>
<option value="Antigua y Barbuda" >Antigua y Barbuda</option>
<option value="Antillas holandesas" >Antillas holandesas</option>
<option value="Arabia Saudí" ">Arabia Saudí</option>
<option value="Argelia" >Argelia</option>
<option value="Argentina" >Argentina</option>
<option value="Armenia" >Armenia</option>
<option value="Aruba" >Aruba</option>
<option value="Australia" >Australia</option>
<option value="Austria" >Austria</option>
<option value="Azerbaiyán" >Azerbaiyán</option>
<option value="Bahamas" >Bahamas</option>
<option value="Bahrein" >Bahrein</option>
<option value="Bangladesh" >Bangladesh</option>
<option value="Barbados" >Barbados</option>
<option value="Bélgica" >Bélgica</option>
<option value="Belice" >Belice</option>
<option value="Benín" >Benín</option>
<option value="Bermudas" >Bermudas</option>
<option value="Bhután" >Bhután</option>
<option value="Bielorrusia" >Bielorrusia</option>
<option value="Birmania" >Birmania</option>
<option value="Bolivia" >Bolivia</option>
<option value="Bosnia y Herzegovina" >Bosnia y Herzegovina</option>
<option value="Botsuana" >Botsuana</option>
<option value="Brasil" >Brasil</option>
<option value="Brunei" >Brunei</option>
<option value="Bulgaria" >Bulgaria</option>
<option value="Burkina Faso" >Burkina Faso</option>
<option value="Burundi" >Burundi</option>
<option value="Cabo Verde" >Cabo Verde</option>
<option value="Camboya" >Camboya</option>
<option value="Camerún" >Camerún</option>
<option value="Canadá" >Canadá</option>
<option value="Chad" >Chad</option>
<option value="Chile" >Chile</option>
<option value="China" >China</option>
<option value="Chipre" >Chipre</option>
<option value="Ciudad estado del Vaticano" >Ciudad estado del Vaticano</option>
<option value="Colombia" >Colombia</option>
<option value="Comores" >Comores</option>
<option value="Congo" >Congo</option>
<option value="Corea" >Corea</option>
<option value="Corea del Norte" >Corea del Norte</option>
<option value="Costa del Marfíl" >Costa del Marfíl</option>
<option value="Costa Rica" >Costa Rica</option>
<option value="Croacia" >Croacia</option>
<option value="Cuba" >Cuba</option>
<option value="Dinamarca" >Dinamarca</option>
<option value="Djibouri" >Djibouri</option>
<option value="Dominica" >Dominica</option>
<option value="Ecuador" >Ecuador</option>
<option value="Egipto" >Egipto</option>
<option value="El Salvador" >El Salvador</option>
<option value="Emiratos Arabes Unidos" >Emiratos Arabes Unidos</option>
<option value="Eritrea" >Eritrea</option>
<option value="Eslovaquia" >Eslovaquia</option>
<option value="Eslovenia" >Eslovenia</option>
<option value="España" >España</option>
<option value="Estados Unidos" >Estados Unidos</option>
<option value="Estonia" >Estonia</option>
<option value="c" >Etiopía</option>
<option value="Ex-República Yugoslava de Macedonia" >Ex-República Yugoslava de Macedonia</option>
<option value="Filipinas" >Filipinas</option>
<option value="Finlandia" >Finlandia</option>
<option value="Francia" >Francia</option>
<option value="Gabón" >Gabón</option>
<option value="Gambia" >Gambia</option>
<option value="Georgia" >Georgia</option>
<option value="Georgia del Sur y las islas Sandwich del Sur" >Georgia del Sur y las islas Sandwich del Sur</option>
<option value="Ghana" >Ghana</option>
<option value="Gibraltar" >Gibraltar</option>
<option value="Granada" >Granada</option>
<option value="Grecia" >Grecia</option>
<option value="Groenlandia" >Groenlandia</option>
<option value="Guadalupe" >Guadalupe</option>
<option value="Guam" >Guam</option>
<option value="Guatemala" >Guatemala</option>
<option value="Guayana" >Guayana</option>
<option value="Guayana francesa" >Guayana francesa</option>
<option value="Guinea" >Guinea</option>
<option value="Guinea Ecuatorial" >Guinea Ecuatorial</option>
<option value="Guinea-Bissau" >Guinea-Bissau</option>
<option value="Haití" >Haití</option>
<option value="Holanda" >Holanda</option>
<option value="Honduras" >Honduras</option>
<option value="Hong Kong R. A. E" >Hong Kong R. A. E</option>
<option value="Hungría" >Hungría</option>
<option value="India" >India</option>
<option value="Indonesia" >Indonesia</option>
<option value="Irak" >Irak</option>
<option value="Irán" >Irán</option>
<option value="Irlanda" >Irlanda</option>
<option value="Isla Bouvet" >Isla Bouvet</option>
<option value="Isla Christmas" >Isla Christmas</option>
<option value="Isla Heard e Islas McDonald" >Isla Heard e Islas McDonald</option>
<option value="Islandia" >Islandia</option>
<option value="Islas Caimán" >Islas Caimán</option>
<option value="Islas Cook" >Islas Cook</option>
<option value="Islas de Cocos o Keeling" >Islas de Cocos o Keeling</option>
<option value="Islas Faroe" >Islas Faroe</option>
<option value="Islas Fiyi" >Islas Fiyi</option>
<option value="Islas Malvinas Islas Falkland" >Islas Malvinas Islas Falkland</option>
<option value="Islas Marianas del norte" >Islas Marianas del norte</option>
<option value="Islas Marshall" >Islas Marshall</option>
<option value="Islas menores de Estados Unidos" >Islas menores de Estados Unidos</option>
<option value="Islas Palau" >Islas Palau</option>
<option value="Islas Salomón" >Islas Salomón</option>
<option value="Islas Tokelau" >Islas Tokelau</option>
<option value="Islas Turks y Caicos" >Islas Turks y Caicos</option>
<option value="Islas Vírgenes EE.UU." >Islas Vírgenes EE.UU.</option>
<option value="Islas Vírgenes Reino Unido" >Islas Vírgenes Reino Unido</option>
<option value="Israel" >Israel</option>
<option value="Italia" >Italia</option>
<option value="Jamaica" >Jamaica</option>
<option value="Japón" >Japón</option>
<option value="Jordania" >Jordania</option>
<option value="Kazajistán" >Kazajistán</option>
<option value="Kenia" >Kenia</option>
<option value="Kirguizistán" >Kirguizistán</option>
<option value="Kiribati" >Kiribati</option>
<option value="Kuwait" >Kuwait</option>
<option value="Laos" >Laos</option>
<option value="Lesoto" >Lesoto</option>
<option value="Letonia" >Letonia</option>
<option value="Líbano" >Líbano</option>
<option value="Liberia" >Liberia</option>
<option value="Libia" >Libia</option>
<option value="Liechtenstein" >Liechtenstein</option>
<option value="Lituania" >Lituania</option>
<option value="Luxemburgo" >Luxemburgo</option>
<option value="Macao R. A. E" >Macao R. A. E</option>
<option value="Madagascar" >Madagascar</option>
<option value="Malasia" >Malasia</option>
<option value="Malawi" >Malawi</option>
<option value="Maldivas" >Maldivas</option>
<option value="Malí" >Malí</option>
<option value="Malta" >Malta</option>
<option value="Marruecos" >Marruecos</option>
<option value="Martinica" >Martinica</option>
<option value="Mauricio" >Mauricio</option>
<option value="Mauritania" >Mauritania</option>
<option value="Mayotte" >Mayotte</option>
<option value="México" >México</option>
<option value="Micronesia" >Micronesia</option>
<option value="Moldavia" >Moldavia</option>
<option value="Mónaco" >Mónaco</option>
<option value="Mongolia" >Mongolia</option>
<option value="Montserrat" >Montserrat</option>
<option value="Mozambique" >Mozambique</option>
<option value="Namibia" >Namibia</option>
<option value="Nauru" >Nauru</option>
<option value="Nepal" >Nepal</option>
<option value="Nicaragua" >Nicaragua</option>
<option value="Níger" >Níger</option>
<option value="Nigeria" >Nigeria</option>
<option value="Niue" >Niue</option>
<option value="Norfolk" >Norfolk</option>
<option value="Noruega" >Noruega</option>
<option value="Nueva Caledonia" >Nueva Caledonia</option>
<option value="Nueva Zelanda" >Nueva Zelanda</option>
<option value="Omán" >Omán</option>
<option value="Panamá" >Panamá</option>
<option value="Papua Nueva Guinea" >Papua Nueva Guinea</option>
<option value="Paquistán" >Paquistán</option>
<option value="Paraguay" >Paraguay</option>
<option value="Perú" >Perú</option>
<option value="Pitcairn" >Pitcairn</option>
<option value="Polinesia francesa" >Polinesia francesa</option>
<option value="Polonia" >Polonia</option>
<option value="Portugal" >Portugal</option>
<option value="Puerto Rico" >Puerto Rico</option>
<option value="Qatar" >Qatar</option>
<option value="Reino Unido" >Reino Unido</option>
<option value="República Centroafricana" >República Centroafricana</option>
<option value="República Checa" >República Checa</option>
<option value="República de Sudáfrica" >República de Sudáfrica</option>
<option value="República Democrática del Congo Zaire" >República Democrática del Congo Zaire</option>
<option value="República Dominicana" >República Dominicana</option>
<option value="Reunión" >Reunión</option>
<option value="Ruanda" >Ruanda</option>
<option value="Rumania" >Rumania</option>
<option value="Rusia" >Rusia</option>
<option value="Samoa" >Samoa</option>
<option value="Samoa occidental" >Samoa occidental</option>
<option value="San Kitts y Nevis" >San Kitts y Nevis</option>
<option value="San Marino" >San Marino</option>
<option value="San Pierre y Miquelon" >San Pierre y Miquelon</option>
<option value="San Vicente e Islas Granadinas" >San Vicente e Islas Granadinas</option>
<option value="Santa Helena" >Santa Helena</option>
<option value="Santa Lucía" >Santa Lucía</option>
<option value="Santo Tomé y Príncipe" >Santo Tomé y Príncipe</option>
<option value="Senegal" >Senegal</option>
<option value="Serbia y Montenegro" >Serbia y Montenegro</option>
<option value="Sychelles" >Seychelles</option>
<option value="Sierra Leona" >Sierra Leona</option>
<option value="Singapur" >Singapur</option>
<option value="Siria" >Siria</option>
<option value="Somalia" >Somalia</option>
<option value="Sri Lanka" >Sri Lanka</option>
<option value="Suazilandia" >Suazilandia</option>
<option value="Sudán" >Sudán</option>
<option value="Suecia" >Suecia</option>
<option value="Suiza" >Suiza</option>
<option value="Surinam" >Surinam</option>
<option value="Svalbard" >Svalbard</option>
<option value="Tailandia" >Tailandia</option>
<option value="Taiwán" >Taiwán</option>
<option value="Tanzania" >Tanzania</option>
<option value="Tayikistán" >Tayikistán</option>
<option value="Territorios británicos del océano Indico" >Territorios británicos del océano Indico</option>
<option value="Territorios franceses del sur" >Territorios franceses del sur</option>
<option value="Timor Oriental" >Timor Oriental</option>
<option value="Togo" >Togo</option>
<option value="Tonga" >Tonga</option>
<option value="Trinidad y Tobago" >Trinidad y Tobago</option>
<option value="Túnez" >Túnez</option>
<option value="Turkmenistán" >Turkmenistán</option>
<option value="Turquía" >Turquía</option>
<option value="Tuvalu" >Tuvalu</option>
<option value="Ucrania" >Ucrania</option>
<option value="Uganda" >Uganda</option>
<option value="Uruguay" >Uruguay</option>
<option value="Uzbekistán" >Uzbekistán</option>
<option value="Vanuatu" >Vanuatu</option>
<option value="Venezuela" >Venezuela</option>
<option value="Vietnam" >Vietnam</option>
<option value="Wallis y Futuna" >Wallis y Futuna</option>
<option value="Yemen" >Yemen</option>
<option value="Zambia" >Zambia</option>
<option value="Zimbabue" >Zimbabue</option>
</select></td></tr>     
                                            <tr><td style="width:20px;vertical-align:top;border: 1px solid #ddd;height:30px"><input type="date" id="opa3" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:20px;border: 1px solid #ddd;height:30px"><input type="date" id="opb3" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:80%;border: 1px solid #ddd;height:30px"><select name="pais3" id="pais3"><option value="" selected></option>
<option value="Afganistán" >Afganistán</option>
<option value="Albania" >Albania</option>
<option value="Alemania" >Alemania</option>
<option value="Andorra" >Andorra</option>
<option value="Angola" >Angola</option>
<option value="Anguila" >Anguila</option>
<option value="Antártida" >Antártida</option>
<option value="Antigua y Barbuda" >Antigua y Barbuda</option>
<option value="Antillas holandesas" >Antillas holandesas</option>
<option value="Arabia Saudí" ">Arabia Saudí</option>
<option value="Argelia" >Argelia</option>
<option value="Argentina" >Argentina</option>
<option value="Armenia" >Armenia</option>
<option value="Aruba" >Aruba</option>
<option value="Australia" >Australia</option>
<option value="Austria" >Austria</option>
<option value="Azerbaiyán" >Azerbaiyán</option>
<option value="Bahamas" >Bahamas</option>
<option value="Bahrein" >Bahrein</option>
<option value="Bangladesh" >Bangladesh</option>
<option value="Barbados" >Barbados</option>
<option value="Bélgica" >Bélgica</option>
<option value="Belice" >Belice</option>
<option value="Benín" >Benín</option>
<option value="Bermudas" >Bermudas</option>
<option value="Bhután" >Bhután</option>
<option value="Bielorrusia" >Bielorrusia</option>
<option value="Birmania" >Birmania</option>
<option value="Bolivia" >Bolivia</option>
<option value="Bosnia y Herzegovina" >Bosnia y Herzegovina</option>
<option value="Botsuana" >Botsuana</option>
<option value="Brasil" >Brasil</option>
<option value="Brunei" >Brunei</option>
<option value="Bulgaria" >Bulgaria</option>
<option value="Burkina Faso" >Burkina Faso</option>
<option value="Burundi" >Burundi</option>
<option value="Cabo Verde" >Cabo Verde</option>
<option value="Camboya" >Camboya</option>
<option value="Camerún" >Camerún</option>
<option value="Canadá" >Canadá</option>
<option value="Chad" >Chad</option>
<option value="Chile" >Chile</option>
<option value="China" >China</option>
<option value="Chipre" >Chipre</option>
<option value="Ciudad estado del Vaticano" >Ciudad estado del Vaticano</option>
<option value="Colombia" >Colombia</option>
<option value="Comores" >Comores</option>
<option value="Congo" >Congo</option>
<option value="Corea" >Corea</option>
<option value="Corea del Norte" >Corea del Norte</option>
<option value="Costa del Marfíl" >Costa del Marfíl</option>
<option value="Costa Rica" >Costa Rica</option>
<option value="Croacia" >Croacia</option>
<option value="Cuba" >Cuba</option>
<option value="Dinamarca" >Dinamarca</option>
<option value="Djibouri" >Djibouri</option>
<option value="Dominica" >Dominica</option>
<option value="Ecuador" >Ecuador</option>
<option value="Egipto" >Egipto</option>
<option value="El Salvador" >El Salvador</option>
<option value="Emiratos Arabes Unidos" >Emiratos Arabes Unidos</option>
<option value="Eritrea" >Eritrea</option>
<option value="Eslovaquia" >Eslovaquia</option>
<option value="Eslovenia" >Eslovenia</option>
<option value="España" >España</option>
<option value="Estados Unidos" >Estados Unidos</option>
<option value="Estonia" >Estonia</option>
<option value="c" >Etiopía</option>
<option value="Ex-República Yugoslava de Macedonia" >Ex-República Yugoslava de Macedonia</option>
<option value="Filipinas" >Filipinas</option>
<option value="Finlandia" >Finlandia</option>
<option value="Francia" >Francia</option>
<option value="Gabón" >Gabón</option>
<option value="Gambia" >Gambia</option>
<option value="Georgia" >Georgia</option>
<option value="Georgia del Sur y las islas Sandwich del Sur" >Georgia del Sur y las islas Sandwich del Sur</option>
<option value="Ghana" >Ghana</option>
<option value="Gibraltar" >Gibraltar</option>
<option value="Granada" >Granada</option>
<option value="Grecia" >Grecia</option>
<option value="Groenlandia" >Groenlandia</option>
<option value="Guadalupe" >Guadalupe</option>
<option value="Guam" >Guam</option>
<option value="Guatemala" >Guatemala</option>
<option value="Guayana" >Guayana</option>
<option value="Guayana francesa" >Guayana francesa</option>
<option value="Guinea" >Guinea</option>
<option value="Guinea Ecuatorial" >Guinea Ecuatorial</option>
<option value="Guinea-Bissau" >Guinea-Bissau</option>
<option value="Haití" >Haití</option>
<option value="Holanda" >Holanda</option>
<option value="Honduras" >Honduras</option>
<option value="Hong Kong R. A. E" >Hong Kong R. A. E</option>
<option value="Hungría" >Hungría</option>
<option value="India" >India</option>
<option value="Indonesia" >Indonesia</option>
<option value="Irak" >Irak</option>
<option value="Irán" >Irán</option>
<option value="Irlanda" >Irlanda</option>
<option value="Isla Bouvet" >Isla Bouvet</option>
<option value="Isla Christmas" >Isla Christmas</option>
<option value="Isla Heard e Islas McDonald" >Isla Heard e Islas McDonald</option>
<option value="Islandia" >Islandia</option>
<option value="Islas Caimán" >Islas Caimán</option>
<option value="Islas Cook" >Islas Cook</option>
<option value="Islas de Cocos o Keeling" >Islas de Cocos o Keeling</option>
<option value="Islas Faroe" >Islas Faroe</option>
<option value="Islas Fiyi" >Islas Fiyi</option>
<option value="Islas Malvinas Islas Falkland" >Islas Malvinas Islas Falkland</option>
<option value="Islas Marianas del norte" >Islas Marianas del norte</option>
<option value="Islas Marshall" >Islas Marshall</option>
<option value="Islas menores de Estados Unidos" >Islas menores de Estados Unidos</option>
<option value="Islas Palau" >Islas Palau</option>
<option value="Islas Salomón" >Islas Salomón</option>
<option value="Islas Tokelau" >Islas Tokelau</option>
<option value="Islas Turks y Caicos" >Islas Turks y Caicos</option>
<option value="Islas Vírgenes EE.UU." >Islas Vírgenes EE.UU.</option>
<option value="Islas Vírgenes Reino Unido" >Islas Vírgenes Reino Unido</option>
<option value="Israel" >Israel</option>
<option value="Italia" >Italia</option>
<option value="Jamaica" >Jamaica</option>
<option value="Japón" >Japón</option>
<option value="Jordania" >Jordania</option>
<option value="Kazajistán" >Kazajistán</option>
<option value="Kenia" >Kenia</option>
<option value="Kirguizistán" >Kirguizistán</option>
<option value="Kiribati" >Kiribati</option>
<option value="Kuwait" >Kuwait</option>
<option value="Laos" >Laos</option>
<option value="Lesoto" >Lesoto</option>
<option value="Letonia" >Letonia</option>
<option value="Líbano" >Líbano</option>
<option value="Liberia" >Liberia</option>
<option value="Libia" >Libia</option>
<option value="Liechtenstein" >Liechtenstein</option>
<option value="Lituania" >Lituania</option>
<option value="Luxemburgo" >Luxemburgo</option>
<option value="Macao R. A. E" >Macao R. A. E</option>
<option value="Madagascar" >Madagascar</option>
<option value="Malasia" >Malasia</option>
<option value="Malawi" >Malawi</option>
<option value="Maldivas" >Maldivas</option>
<option value="Malí" >Malí</option>
<option value="Malta" >Malta</option>
<option value="Marruecos" >Marruecos</option>
<option value="Martinica" >Martinica</option>
<option value="Mauricio" >Mauricio</option>
<option value="Mauritania" >Mauritania</option>
<option value="Mayotte" >Mayotte</option>
<option value="México" >México</option>
<option value="Micronesia" >Micronesia</option>
<option value="Moldavia" >Moldavia</option>
<option value="Mónaco" >Mónaco</option>
<option value="Mongolia" >Mongolia</option>
<option value="Montserrat" >Montserrat</option>
<option value="Mozambique" >Mozambique</option>
<option value="Namibia" >Namibia</option>
<option value="Nauru" >Nauru</option>
<option value="Nepal" >Nepal</option>
<option value="Nicaragua" >Nicaragua</option>
<option value="Níger" >Níger</option>
<option value="Nigeria" >Nigeria</option>
<option value="Niue" >Niue</option>
<option value="Norfolk" >Norfolk</option>
<option value="Noruega" >Noruega</option>
<option value="Nueva Caledonia" >Nueva Caledonia</option>
<option value="Nueva Zelanda" >Nueva Zelanda</option>
<option value="Omán" >Omán</option>
<option value="Panamá" >Panamá</option>
<option value="Papua Nueva Guinea" >Papua Nueva Guinea</option>
<option value="Paquistán" >Paquistán</option>
<option value="Paraguay" >Paraguay</option>
<option value="Perú" >Perú</option>
<option value="Pitcairn" >Pitcairn</option>
<option value="Polinesia francesa" >Polinesia francesa</option>
<option value="Polonia" >Polonia</option>
<option value="Portugal" >Portugal</option>
<option value="Puerto Rico" >Puerto Rico</option>
<option value="Qatar" >Qatar</option>
<option value="Reino Unido" >Reino Unido</option>
<option value="República Centroafricana" >República Centroafricana</option>
<option value="República Checa" >República Checa</option>
<option value="República de Sudáfrica" >República de Sudáfrica</option>
<option value="República Democrática del Congo Zaire" >República Democrática del Congo Zaire</option>
<option value="República Dominicana" >República Dominicana</option>
<option value="Reunión" >Reunión</option>
<option value="Ruanda" >Ruanda</option>
<option value="Rumania" >Rumania</option>
<option value="Rusia" >Rusia</option>
<option value="Samoa" >Samoa</option>
<option value="Samoa occidental" >Samoa occidental</option>
<option value="San Kitts y Nevis" >San Kitts y Nevis</option>
<option value="San Marino" >San Marino</option>
<option value="San Pierre y Miquelon" >San Pierre y Miquelon</option>
<option value="San Vicente e Islas Granadinas" >San Vicente e Islas Granadinas</option>
<option value="Santa Helena" >Santa Helena</option>
<option value="Santa Lucía" >Santa Lucía</option>
<option value="Santo Tomé y Príncipe" >Santo Tomé y Príncipe</option>
<option value="Senegal" >Senegal</option>
<option value="Serbia y Montenegro" >Serbia y Montenegro</option>
<option value="Sychelles" >Seychelles</option>
<option value="Sierra Leona" >Sierra Leona</option>
<option value="Singapur" >Singapur</option>
<option value="Siria" >Siria</option>
<option value="Somalia" >Somalia</option>
<option value="Sri Lanka" >Sri Lanka</option>
<option value="Suazilandia" >Suazilandia</option>
<option value="Sudán" >Sudán</option>
<option value="Suecia" >Suecia</option>
<option value="Suiza" >Suiza</option>
<option value="Surinam" >Surinam</option>
<option value="Svalbard" >Svalbard</option>
<option value="Tailandia" >Tailandia</option>
<option value="Taiwán" >Taiwán</option>
<option value="Tanzania" >Tanzania</option>
<option value="Tayikistán" >Tayikistán</option>
<option value="Territorios británicos del océano Indico" >Territorios británicos del océano Indico</option>
<option value="Territorios franceses del sur" >Territorios franceses del sur</option>
<option value="Timor Oriental" >Timor Oriental</option>
<option value="Togo" >Togo</option>
<option value="Tonga" >Tonga</option>
<option value="Trinidad y Tobago" >Trinidad y Tobago</option>
<option value="Túnez" >Túnez</option>
<option value="Turkmenistán" >Turkmenistán</option>
<option value="Turquía" >Turquía</option>
<option value="Tuvalu" >Tuvalu</option>
<option value="Ucrania" >Ucrania</option>
<option value="Uganda" >Uganda</option>
<option value="Uruguay" >Uruguay</option>
<option value="Uzbekistán" >Uzbekistán</option>
<option value="Vanuatu" >Vanuatu</option>
<option value="Venezuela" >Venezuela</option>
<option value="Vietnam" >Vietnam</option>
<option value="Wallis y Futuna" >Wallis y Futuna</option>
<option value="Yemen" >Yemen</option>
<option value="Zambia" >Zambia</option>
<option value="Zimbabue" >Zimbabue</option>
</select></td></tr>     
                                            <tr><td style="width:20px;vertical-align:top;border: 1px solid #ddd;height:30px"><input type="date" id="opa4" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:20px;border: 1px solid #ddd;height:30px"><input type="date" id="opb4" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:80%;border: 1px solid #ddd;height:30px"><select name="pais4" id ="pais4"><option value="" selected></option>
<option value="Afganistán" >Afganistán</option>
<option value="Albania" >Albania</option>
<option value="Alemania" >Alemania</option>
<option value="Andorra" >Andorra</option>
<option value="Angola" >Angola</option>
<option value="Anguila" >Anguila</option>
<option value="Antártida" >Antártida</option>
<option value="Antigua y Barbuda" >Antigua y Barbuda</option>
<option value="Antillas holandesas" >Antillas holandesas</option>
<option value="Arabia Saudí" ">Arabia Saudí</option>
<option value="Argelia" >Argelia</option>
<option value="Argentina" >Argentina</option>
<option value="Armenia" >Armenia</option>
<option value="Aruba" >Aruba</option>
<option value="Australia" >Australia</option>
<option value="Austria" >Austria</option>
<option value="Azerbaiyán" >Azerbaiyán</option>
<option value="Bahamas" >Bahamas</option>
<option value="Bahrein" >Bahrein</option>
<option value="Bangladesh" >Bangladesh</option>
<option value="Barbados" >Barbados</option>
<option value="Bélgica" >Bélgica</option>
<option value="Belice" >Belice</option>
<option value="Benín" >Benín</option>
<option value="Bermudas" >Bermudas</option>
<option value="Bhután" >Bhután</option>
<option value="Bielorrusia" >Bielorrusia</option>
<option value="Birmania" >Birmania</option>
<option value="Bolivia" >Bolivia</option>
<option value="Bosnia y Herzegovina" >Bosnia y Herzegovina</option>
<option value="Botsuana" >Botsuana</option>
<option value="Brasil" >Brasil</option>
<option value="Brunei" >Brunei</option>
<option value="Bulgaria" >Bulgaria</option>
<option value="Burkina Faso" >Burkina Faso</option>
<option value="Burundi" >Burundi</option>
<option value="Cabo Verde" >Cabo Verde</option>
<option value="Camboya" >Camboya</option>
<option value="Camerún" >Camerún</option>
<option value="Canadá" >Canadá</option>
<option value="Chad" >Chad</option>
<option value="Chile" >Chile</option>
<option value="China" >China</option>
<option value="Chipre" >Chipre</option>
<option value="Ciudad estado del Vaticano" >Ciudad estado del Vaticano</option>
<option value="Colombia" >Colombia</option>
<option value="Comores" >Comores</option>
<option value="Congo" >Congo</option>
<option value="Corea" >Corea</option>
<option value="Corea del Norte" >Corea del Norte</option>
<option value="Costa del Marfíl" >Costa del Marfíl</option>
<option value="Costa Rica" >Costa Rica</option>
<option value="Croacia" >Croacia</option>
<option value="Cuba" >Cuba</option>
<option value="Dinamarca" >Dinamarca</option>
<option value="Djibouri" >Djibouri</option>
<option value="Dominica" >Dominica</option>
<option value="Ecuador" >Ecuador</option>
<option value="Egipto" >Egipto</option>
<option value="El Salvador" >El Salvador</option>
<option value="Emiratos Arabes Unidos" >Emiratos Arabes Unidos</option>
<option value="Eritrea" >Eritrea</option>
<option value="Eslovaquia" >Eslovaquia</option>
<option value="Eslovenia" >Eslovenia</option>
<option value="España" >España</option>
<option value="Estados Unidos" >Estados Unidos</option>
<option value="Estonia" >Estonia</option>
<option value="c" >Etiopía</option>
<option value="Ex-República Yugoslava de Macedonia" >Ex-República Yugoslava de Macedonia</option>
<option value="Filipinas" >Filipinas</option>
<option value="Finlandia" >Finlandia</option>
<option value="Francia" >Francia</option>
<option value="Gabón" >Gabón</option>
<option value="Gambia" >Gambia</option>
<option value="Georgia" >Georgia</option>
<option value="Georgia del Sur y las islas Sandwich del Sur" >Georgia del Sur y las islas Sandwich del Sur</option>
<option value="Ghana" >Ghana</option>
<option value="Gibraltar" >Gibraltar</option>
<option value="Granada" >Granada</option>
<option value="Grecia" >Grecia</option>
<option value="Groenlandia" >Groenlandia</option>
<option value="Guadalupe" >Guadalupe</option>
<option value="Guam" >Guam</option>
<option value="Guatemala" >Guatemala</option>
<option value="Guayana" >Guayana</option>
<option value="Guayana francesa" >Guayana francesa</option>
<option value="Guinea" >Guinea</option>
<option value="Guinea Ecuatorial" >Guinea Ecuatorial</option>
<option value="Guinea-Bissau" >Guinea-Bissau</option>
<option value="Haití" >Haití</option>
<option value="Holanda" >Holanda</option>
<option value="Honduras" >Honduras</option>
<option value="Hong Kong R. A. E" >Hong Kong R. A. E</option>
<option value="Hungría" >Hungría</option>
<option value="India" >India</option>
<option value="Indonesia" >Indonesia</option>
<option value="Irak" >Irak</option>
<option value="Irán" >Irán</option>
<option value="Irlanda" >Irlanda</option>
<option value="Isla Bouvet" >Isla Bouvet</option>
<option value="Isla Christmas" >Isla Christmas</option>
<option value="Isla Heard e Islas McDonald" >Isla Heard e Islas McDonald</option>
<option value="Islandia" >Islandia</option>
<option value="Islas Caimán" >Islas Caimán</option>
<option value="Islas Cook" >Islas Cook</option>
<option value="Islas de Cocos o Keeling" >Islas de Cocos o Keeling</option>
<option value="Islas Faroe" >Islas Faroe</option>
<option value="Islas Fiyi" >Islas Fiyi</option>
<option value="Islas Malvinas Islas Falkland" >Islas Malvinas Islas Falkland</option>
<option value="Islas Marianas del norte" >Islas Marianas del norte</option>
<option value="Islas Marshall" >Islas Marshall</option>
<option value="Islas menores de Estados Unidos" >Islas menores de Estados Unidos</option>
<option value="Islas Palau" >Islas Palau</option>
<option value="Islas Salomón" >Islas Salomón</option>
<option value="Islas Tokelau" >Islas Tokelau</option>
<option value="Islas Turks y Caicos" >Islas Turks y Caicos</option>
<option value="Islas Vírgenes EE.UU." >Islas Vírgenes EE.UU.</option>
<option value="Islas Vírgenes Reino Unido" >Islas Vírgenes Reino Unido</option>
<option value="Israel" >Israel</option>
<option value="Italia" >Italia</option>
<option value="Jamaica" >Jamaica</option>
<option value="Japón" >Japón</option>
<option value="Jordania" >Jordania</option>
<option value="Kazajistán" >Kazajistán</option>
<option value="Kenia" >Kenia</option>
<option value="Kirguizistán" >Kirguizistán</option>
<option value="Kiribati" >Kiribati</option>
<option value="Kuwait" >Kuwait</option>
<option value="Laos" >Laos</option>
<option value="Lesoto" >Lesoto</option>
<option value="Letonia" >Letonia</option>
<option value="Líbano" >Líbano</option>
<option value="Liberia" >Liberia</option>
<option value="Libia" >Libia</option>
<option value="Liechtenstein" >Liechtenstein</option>
<option value="Lituania" >Lituania</option>
<option value="Luxemburgo" >Luxemburgo</option>
<option value="Macao R. A. E" >Macao R. A. E</option>
<option value="Madagascar" >Madagascar</option>
<option value="Malasia" >Malasia</option>
<option value="Malawi" >Malawi</option>
<option value="Maldivas" >Maldivas</option>
<option value="Malí" >Malí</option>
<option value="Malta" >Malta</option>
<option value="Marruecos" >Marruecos</option>
<option value="Martinica" >Martinica</option>
<option value="Mauricio" >Mauricio</option>
<option value="Mauritania" >Mauritania</option>
<option value="Mayotte" >Mayotte</option>
<option value="México" >México</option>
<option value="Micronesia" >Micronesia</option>
<option value="Moldavia" >Moldavia</option>
<option value="Mónaco" >Mónaco</option>
<option value="Mongolia" >Mongolia</option>
<option value="Montserrat" >Montserrat</option>
<option value="Mozambique" >Mozambique</option>
<option value="Namibia" >Namibia</option>
<option value="Nauru" >Nauru</option>
<option value="Nepal" >Nepal</option>
<option value="Nicaragua" >Nicaragua</option>
<option value="Níger" >Níger</option>
<option value="Nigeria" >Nigeria</option>
<option value="Niue" >Niue</option>
<option value="Norfolk" >Norfolk</option>
<option value="Noruega" >Noruega</option>
<option value="Nueva Caledonia" >Nueva Caledonia</option>
<option value="Nueva Zelanda" >Nueva Zelanda</option>
<option value="Omán" >Omán</option>
<option value="Panamá" >Panamá</option>
<option value="Papua Nueva Guinea" >Papua Nueva Guinea</option>
<option value="Paquistán" >Paquistán</option>
<option value="Paraguay" >Paraguay</option>
<option value="Perú" >Perú</option>
<option value="Pitcairn" >Pitcairn</option>
<option value="Polinesia francesa" >Polinesia francesa</option>
<option value="Polonia" >Polonia</option>
<option value="Portugal" >Portugal</option>
<option value="Puerto Rico" >Puerto Rico</option>
<option value="Qatar" >Qatar</option>
<option value="Reino Unido" >Reino Unido</option>
<option value="República Centroafricana" >República Centroafricana</option>
<option value="República Checa" >República Checa</option>
<option value="República de Sudáfrica" >República de Sudáfrica</option>
<option value="República Democrática del Congo Zaire" >República Democrática del Congo Zaire</option>
<option value="República Dominicana" >República Dominicana</option>
<option value="Reunión" >Reunión</option>
<option value="Ruanda" >Ruanda</option>
<option value="Rumania" >Rumania</option>
<option value="Rusia" >Rusia</option>
<option value="Samoa" >Samoa</option>
<option value="Samoa occidental" >Samoa occidental</option>
<option value="San Kitts y Nevis" >San Kitts y Nevis</option>
<option value="San Marino" >San Marino</option>
<option value="San Pierre y Miquelon" >San Pierre y Miquelon</option>
<option value="San Vicente e Islas Granadinas" >San Vicente e Islas Granadinas</option>
<option value="Santa Helena" >Santa Helena</option>
<option value="Santa Lucía" >Santa Lucía</option>
<option value="Santo Tomé y Príncipe" >Santo Tomé y Príncipe</option>
<option value="Senegal" >Senegal</option>
<option value="Serbia y Montenegro" >Serbia y Montenegro</option>
<option value="Sychelles" >Seychelles</option>
<option value="Sierra Leona" >Sierra Leona</option>
<option value="Singapur" >Singapur</option>
<option value="Siria" >Siria</option>
<option value="Somalia" >Somalia</option>
<option value="Sri Lanka" >Sri Lanka</option>
<option value="Suazilandia" >Suazilandia</option>
<option value="Sudán" >Sudán</option>
<option value="Suecia" >Suecia</option>
<option value="Suiza" >Suiza</option>
<option value="Surinam" >Surinam</option>
<option value="Svalbard" >Svalbard</option>
<option value="Tailandia" >Tailandia</option>
<option value="Taiwán" >Taiwán</option>
<option value="Tanzania" >Tanzania</option>
<option value="Tayikistán" >Tayikistán</option>
<option value="Territorios británicos del océano Indico" >Territorios británicos del océano Indico</option>
<option value="Territorios franceses del sur" >Territorios franceses del sur</option>
<option value="Timor Oriental" >Timor Oriental</option>
<option value="Togo" >Togo</option>
<option value="Tonga" >Tonga</option>
<option value="Trinidad y Tobago" >Trinidad y Tobago</option>
<option value="Túnez" >Túnez</option>
<option value="Turkmenistán" >Turkmenistán</option>
<option value="Turquía" >Turquía</option>
<option value="Tuvalu" >Tuvalu</option>
<option value="Ucrania" >Ucrania</option>
<option value="Uganda" >Uganda</option>
<option value="Uruguay" >Uruguay</option>
<option value="Uzbekistán" >Uzbekistán</option>
<option value="Vanuatu" >Vanuatu</option>
<option value="Venezuela" >Venezuela</option>
<option value="Vietnam" >Vietnam</option>
<option value="Wallis y Futuna" >Wallis y Futuna</option>
<option value="Yemen" >Yemen</option>
<option value="Zambia" >Zambia</option>
<option value="Zimbabue" >Zimbabue</option>
</select></td></tr>     
                                            <tr><td style="width:20px;vertical-align:top;border: 1px solid #ddd;height:30px"><input type="date" id="opa5" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:20px;border: 1px solid #ddd;height:30px"><input type="date" id="opb5" style="width:100%;height:30px;"></td><td style="vertical-align:top;width:80%;border: 1px solid #ddd;height:30px">
                                                <select name="pais5" id="pais5"><option value="" selected></option>
<option value="Afganistán" >Afganistán</option>
<option value="Albania" >Albania</option>
<option value="Alemania" >Alemania</option>
<option value="Andorra" >Andorra</option>
<option value="Angola" >Angola</option>
<option value="Anguila" >Anguila</option>
<option value="Antártida" >Antártida</option>
<option value="Antigua y Barbuda" >Antigua y Barbuda</option>
<option value="Antillas holandesas" >Antillas holandesas</option>
<option value="Arabia Saudí" ">Arabia Saudí</option>
<option value="Argelia" >Argelia</option>
<option value="Argentina" >Argentina</option>
<option value="Armenia" >Armenia</option>
<option value="Aruba" >Aruba</option>
<option value="Australia" >Australia</option>
<option value="Austria" >Austria</option>
<option value="Azerbaiyán" >Azerbaiyán</option>
<option value="Bahamas" >Bahamas</option>
<option value="Bahrein" >Bahrein</option>
<option value="Bangladesh" >Bangladesh</option>
<option value="Barbados" >Barbados</option>
<option value="Bélgica" >Bélgica</option>
<option value="Belice" >Belice</option>
<option value="Benín" >Benín</option>
<option value="Bermudas" >Bermudas</option>
<option value="Bhután" >Bhután</option>
<option value="Bielorrusia" >Bielorrusia</option>
<option value="Birmania" >Birmania</option>
<option value="Bolivia" >Bolivia</option>
<option value="Bosnia y Herzegovina" >Bosnia y Herzegovina</option>
<option value="Botsuana" >Botsuana</option>
<option value="Brasil" >Brasil</option>
<option value="Brunei" >Brunei</option>
<option value="Bulgaria" >Bulgaria</option>
<option value="Burkina Faso" >Burkina Faso</option>
<option value="Burundi" >Burundi</option>
<option value="Cabo Verde" >Cabo Verde</option>
<option value="Camboya" >Camboya</option>
<option value="Camerún" >Camerún</option>
<option value="Canadá" >Canadá</option>
<option value="Chad" >Chad</option>
<option value="Chile" >Chile</option>
<option value="China" >China</option>
<option value="Chipre" >Chipre</option>
<option value="Ciudad estado del Vaticano" >Ciudad estado del Vaticano</option>
<option value="Colombia" >Colombia</option>
<option value="Comores" >Comores</option>
<option value="Congo" >Congo</option>
<option value="Corea" >Corea</option>
<option value="Corea del Norte" >Corea del Norte</option>
<option value="Costa del Marfíl" >Costa del Marfíl</option>
<option value="Costa Rica" >Costa Rica</option>
<option value="Croacia" >Croacia</option>
<option value="Cuba" >Cuba</option>
<option value="Dinamarca" >Dinamarca</option>
<option value="Djibouri" >Djibouri</option>
<option value="Dominica" >Dominica</option>
<option value="Ecuador" >Ecuador</option>
<option value="Egipto" >Egipto</option>
<option value="El Salvador" >El Salvador</option>
<option value="Emiratos Arabes Unidos" >Emiratos Arabes Unidos</option>
<option value="Eritrea" >Eritrea</option>
<option value="Eslovaquia" >Eslovaquia</option>
<option value="Eslovenia" >Eslovenia</option>
<option value="España" >España</option>
<option value="Estados Unidos" >Estados Unidos</option>
<option value="Estonia" >Estonia</option>
<option value="c" >Etiopía</option>
<option value="Ex-República Yugoslava de Macedonia" >Ex-República Yugoslava de Macedonia</option>
<option value="Filipinas" >Filipinas</option>
<option value="Finlandia" >Finlandia</option>
<option value="Francia" >Francia</option>
<option value="Gabón" >Gabón</option>
<option value="Gambia" >Gambia</option>
<option value="Georgia" >Georgia</option>
<option value="Georgia del Sur y las islas Sandwich del Sur" >Georgia del Sur y las islas Sandwich del Sur</option>
<option value="Ghana" >Ghana</option>
<option value="Gibraltar" >Gibraltar</option>
<option value="Granada" >Granada</option>
<option value="Grecia" >Grecia</option>
<option value="Groenlandia" >Groenlandia</option>
<option value="Guadalupe" >Guadalupe</option>
<option value="Guam" >Guam</option>
<option value="Guatemala" >Guatemala</option>
<option value="Guayana" >Guayana</option>
<option value="Guayana francesa" >Guayana francesa</option>
<option value="Guinea" >Guinea</option>
<option value="Guinea Ecuatorial" >Guinea Ecuatorial</option>
<option value="Guinea-Bissau" >Guinea-Bissau</option>
<option value="Haití" >Haití</option>
<option value="Holanda" >Holanda</option>
<option value="Honduras" >Honduras</option>
<option value="Hong Kong R. A. E" >Hong Kong R. A. E</option>
<option value="Hungría" >Hungría</option>
<option value="India" >India</option>
<option value="Indonesia" >Indonesia</option>
<option value="Irak" >Irak</option>
<option value="Irán" >Irán</option>
<option value="Irlanda" >Irlanda</option>
<option value="Isla Bouvet" >Isla Bouvet</option>
<option value="Isla Christmas" >Isla Christmas</option>
<option value="Isla Heard e Islas McDonald" >Isla Heard e Islas McDonald</option>
<option value="Islandia" >Islandia</option>
<option value="Islas Caimán" >Islas Caimán</option>
<option value="Islas Cook" >Islas Cook</option>
<option value="Islas de Cocos o Keeling" >Islas de Cocos o Keeling</option>
<option value="Islas Faroe" >Islas Faroe</option>
<option value="Islas Fiyi" >Islas Fiyi</option>
<option value="Islas Malvinas Islas Falkland" >Islas Malvinas Islas Falkland</option>
<option value="Islas Marianas del norte" >Islas Marianas del norte</option>
<option value="Islas Marshall" >Islas Marshall</option>
<option value="Islas menores de Estados Unidos" >Islas menores de Estados Unidos</option>
<option value="Islas Palau" >Islas Palau</option>
<option value="Islas Salomón" >Islas Salomón</option>
<option value="Islas Tokelau" >Islas Tokelau</option>
<option value="Islas Turks y Caicos" >Islas Turks y Caicos</option>
<option value="Islas Vírgenes EE.UU." >Islas Vírgenes EE.UU.</option>
<option value="Islas Vírgenes Reino Unido" >Islas Vírgenes Reino Unido</option>
<option value="Israel" >Israel</option>
<option value="Italia" >Italia</option>
<option value="Jamaica" >Jamaica</option>
<option value="Japón" >Japón</option>
<option value="Jordania" >Jordania</option>
<option value="Kazajistán" >Kazajistán</option>
<option value="Kenia" >Kenia</option>
<option value="Kirguizistán" >Kirguizistán</option>
<option value="Kiribati" >Kiribati</option>
<option value="Kuwait" >Kuwait</option>
<option value="Laos" >Laos</option>
<option value="Lesoto" >Lesoto</option>
<option value="Letonia" >Letonia</option>
<option value="Líbano" >Líbano</option>
<option value="Liberia" >Liberia</option>
<option value="Libia" >Libia</option>
<option value="Liechtenstein" >Liechtenstein</option>
<option value="Lituania" >Lituania</option>
<option value="Luxemburgo" >Luxemburgo</option>
<option value="Macao R. A. E" >Macao R. A. E</option>
<option value="Madagascar" >Madagascar</option>
<option value="Malasia" >Malasia</option>
<option value="Malawi" >Malawi</option>
<option value="Maldivas" >Maldivas</option>
<option value="Malí" >Malí</option>
<option value="Malta" >Malta</option>
<option value="Marruecos" >Marruecos</option>
<option value="Martinica" >Martinica</option>
<option value="Mauricio" >Mauricio</option>
<option value="Mauritania" >Mauritania</option>
<option value="Mayotte" >Mayotte</option>
<option value="México" >México</option>
<option value="Micronesia" >Micronesia</option>
<option value="Moldavia" >Moldavia</option>
<option value="Mónaco" >Mónaco</option>
<option value="Mongolia" >Mongolia</option>
<option value="Montserrat" >Montserrat</option>
<option value="Mozambique" >Mozambique</option>
<option value="Namibia" >Namibia</option>
<option value="Nauru" >Nauru</option>
<option value="Nepal" >Nepal</option>
<option value="Nicaragua" >Nicaragua</option>
<option value="Níger" >Níger</option>
<option value="Nigeria" >Nigeria</option>
<option value="Niue" >Niue</option>
<option value="Norfolk" >Norfolk</option>
<option value="Noruega" >Noruega</option>
<option value="Nueva Caledonia" >Nueva Caledonia</option>
<option value="Nueva Zelanda" >Nueva Zelanda</option>
<option value="Omán" >Omán</option>
<option value="Panamá" >Panamá</option>
<option value="Papua Nueva Guinea" >Papua Nueva Guinea</option>
<option value="Paquistán" >Paquistán</option>
<option value="Paraguay" >Paraguay</option>
<option value="Perú" >Perú</option>
<option value="Pitcairn" >Pitcairn</option>
<option value="Polinesia francesa" >Polinesia francesa</option>
<option value="Polonia" >Polonia</option>
<option value="Portugal" >Portugal</option>
<option value="Puerto Rico" >Puerto Rico</option>
<option value="Qatar" >Qatar</option>
<option value="Reino Unido" >Reino Unido</option>
<option value="República Centroafricana" >República Centroafricana</option>
<option value="República Checa" >República Checa</option>
<option value="República de Sudáfrica" >República de Sudáfrica</option>
<option value="República Democrática del Congo Zaire" >República Democrática del Congo Zaire</option>
<option value="República Dominicana" >República Dominicana</option>
<option value="Reunión" >Reunión</option>
<option value="Ruanda" >Ruanda</option>
<option value="Rumania" >Rumania</option>
<option value="Rusia" >Rusia</option>
<option value="Samoa" >Samoa</option>
<option value="Samoa occidental" >Samoa occidental</option>
<option value="San Kitts y Nevis" >San Kitts y Nevis</option>
<option value="San Marino" >San Marino</option>
<option value="San Pierre y Miquelon" >San Pierre y Miquelon</option>
<option value="San Vicente e Islas Granadinas" >San Vicente e Islas Granadinas</option>
<option value="Santa Helena" >Santa Helena</option>
<option value="Santa Lucía" >Santa Lucía</option>
<option value="Santo Tomé y Príncipe" >Santo Tomé y Príncipe</option>
<option value="Senegal" >Senegal</option>
<option value="Serbia y Montenegro" >Serbia y Montenegro</option>
<option value="Sychelles" >Seychelles</option>
<option value="Sierra Leona" >Sierra Leona</option>
<option value="Singapur" >Singapur</option>
<option value="Siria" >Siria</option>
<option value="Somalia" >Somalia</option>
<option value="Sri Lanka" >Sri Lanka</option>
<option value="Suazilandia" >Suazilandia</option>
<option value="Sudán" >Sudán</option>
<option value="Suecia" >Suecia</option>
<option value="Suiza" >Suiza</option>
<option value="Surinam" >Surinam</option>
<option value="Svalbard" >Svalbard</option>
<option value="Tailandia" >Tailandia</option>
<option value="Taiwán" >Taiwán</option>
<option value="Tanzania" >Tanzania</option>
<option value="Tayikistán" >Tayikistán</option>
<option value="Territorios británicos del océano Indico" >Territorios británicos del océano Indico</option>
<option value="Territorios franceses del sur" >Territorios franceses del sur</option>
<option value="Timor Oriental" >Timor Oriental</option>
<option value="Togo" >Togo</option>
<option value="Tonga" >Tonga</option>
<option value="Trinidad y Tobago" >Trinidad y Tobago</option>
<option value="Túnez" >Túnez</option>
<option value="Turkmenistán" >Turkmenistán</option>
<option value="Turquía" >Turquía</option>
<option value="Tuvalu" >Tuvalu</option>
<option value="Ucrania" >Ucrania</option>
<option value="Uganda" >Uganda</option>
<option value="Uruguay" >Uruguay</option>
<option value="Uzbekistán" >Uzbekistán</option>
<option value="Vanuatu" >Vanuatu</option>
<option value="Venezuela" >Venezuela</option>
<option value="Vietnam" >Vietnam</option>
<option value="Wallis y Futuna" >Wallis y Futuna</option>
<option value="Yemen" >Yemen</option>
<option value="Zambia" >Zambia</option>
<option value="Zimbabue" >Zimbabue</option>
</select>

                                                                                                                                                                                                                                                                                                                                              </td></tr>     
                                            <!--<tr><td style="width:20px;vertical-align:top;border: 1px solid #ddd"></td><td style="vertical-align:top;width:20px;border: 1px solid #ddd"></td><td style="vertical-align:top;width:80%;border: 1px solid #ddd"></td></tr>     
                                            <tr><td style="width:20px;vertical-align:top;border: 1px solid #ddd"></td><td style="vertical-align:top;width:20px;border: 1px solid #ddd"></td><td style="vertical-align:top;width:80%;border: 1px solid #ddd"></td></tr>     
                                            <tr><td style="width:20px;vertical-align:top;border: 1px solid #ddd"></td><td style="vertical-align:top;width:20px;border: 1px solid #ddd"></td><td style="vertical-align:top;width:80%;border: 1px solid #ddd"></td></tr>     
                                            <tr><td style="width:20px;vertical-align:top;border: 1px solid #ddd"></td><td style="vertical-align:top;width:20px;border: 1px solid #ddd"></td><td style="vertical-align:top;width:80%;border: 1px solid #ddd"></td></tr>     
                                        -->
                                        </tbody>
                                    </table>

                                         </div></td>
                                 </tr>
                             </tbody>
                         </table>

                         <br /> 
                         <B>Esta Declaración Jurada deberá remitirse por el Sistema GDE, firmada por el agente, al usuario RRHHMDS</B>
                         
                         <div style="margin-bottom:30pt;padding-left:80%;margin-top:20pt; " >                     
                             <input style="margin: 0 auto;" class="botonAzul" type="button" value="Enviar" onclick="GuardarDDJJ()">                     
	                     </div>
                     </div>
                    </td>
                 </tr>
             </tbody></table>                      
            </div>               

               </div> 

        
           </div> 

        </div>

    

        
    </form>
</body>


<script type="text/javascript" src="../MAU/VistaDePermisosDeUnUsuario.js"></script>
<script type="text/javascript" src="../MAU/Autorizador.js"></script>
<script type="text/javascript" src="../MAU/RepositorioDeFuncionalidades.js"></script>
<script type="text/javascript" src="../MAU/RepositorioDeUsuarios.js"></script>
<script type="text/javascript" src="../MAU/NodoEnArbolDeFuncionalidades.js"></script>
<script type="text/javascript" src="../MAU/AdministradorDeUsuarios.js"></script>
<script type="text/javascript" src="../MAU/Usuario.js"></script>
<script type="text/javascript" src="../MAU/HabilitadorDeControles.js"></script>

<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>

<script type="text/javascript" src="../Scripts/RepositorioDePersonas.js"></script>
<script type="text/javascript" src="../Scripts/Persona.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDePersonas.js"></script>


<script type="text/javascript" src="../MAU/VistaDeAreasAdministradas.js"></script>
<script type="text/javascript" src="../MAU/VistaDeAreaAdministrada.js"></script>
<script type="text/javascript" src="../Scripts/Area.js"></script>
<script type="text/javascript" src="../Scripts/SelectorDeAreas.js"></script>
<script type="text/javascript" src="../Scripts/RepositorioDeAreas.js"></script>

<script type="text/javascript" src="../Scripts/alertify.js"></script>
<script type="text/javascript" src="../Scripts/ControlesImagenes/VistaThumbnail.js"></script>
<script type="text/javascript" src="../scripts/vex-2.1.1/js/vex.combined.min.js"></script>

<script type="text/javascript" src="../Scripts/select2-3.4.4/Select2.min.js"></script>
<script type="text/javascript" src="../Scripts/select2-3.4.4/select2_locale_es.js"></script>

<script type="text/javascript" src="../Scripts/Spin.js"></script>

<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/jsPortal/RepoFirmaDigital.js"></script>

<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>

<script type="text/javascript" src="imprimirRecibo.js"></script>

<script type="text/javascript" >

    var agenteActual = '';

    $(document).ready(function ($) {
             
        Backend.start(function () {
           //Permisos.init();
            
            
 
        });  
        

    });

    function base64ToArrayBuffer(data) {
    var binaryString = window.atob(data);
    var binaryLen = binaryString.length;
    var bytes = new Uint8Array(binaryLen);
    for (var i = 0; i < binaryLen; i++) {
        var ascii = binaryString.charCodeAt(i);
        bytes[i] = ascii;
    }
    return bytes;
    };

    var btn_combo_anio = $('#cmb_anio').change(function () {
            $('#cmb_meses').change();
            var anio_combo = $("#cmb_anio option:selected").val();
            var day = new Date();
            mes_para_inhabilitar = day.getMonth() + 2;
            var anio = day.getFullYear();

            //inhabilito lo meses que no estan vigentes para este año y si esta seleccionado un mes deshailitado reseteo al mes actual
            if (anio_combo == anio) {
                $("#cmb_meses option").each(function () {
                    if (mes_para_inhabilitar <= $(this).val()) {
                        $(this).attr('disabled', 'disabled');
                        if ($("#cmb_meses option:selected").val() == $(this).val()) {
                             $("#cmb_meses").val(day.getMonth() + 1);
                    }
                        
                    }
                });
            } else {
                $("#cmb_meses option").each(function () {
                    $(this).removeAttr('disabled');
                });
            }
            
    });


    
     function getTiposLiquidacion() {
        Backend.GetTiposLiquidacion()
        .onSuccess(function (tiposLiquidacion) {
            /*tiposLiquidacion es la respuesta*/
            var tiposLiquidaciones = document.getElementById("tiposLiquidaciones");
            var i;

            var resp = JSON.parse(tiposLiquidacion);
            var longitud; //tamaño de la lista de tipos de liquidacion
            longitud = Object.keys(resp).length;
            
            var item;
            var capaInicio = ''; //representa la capa que muestran a las liquidaciones
            var capaFin = '';
            var columnaAcumulada = '';
            capaInicio = '<table class="table-condensed" style="width:94%"><tbody class="list">';

            capaFin = '</tbody></table>';
            var capaFilas = '';

            item = '<tr>';
            //genero la lista de radiobutton
            for (i = 0; i < longitud; i++) {
                item = item + '<td><input type="radio" class="radio_listado" id="' + resp[i].Id + '" style="cursor: pointer;margin: 0px;" value="' + resp[i].Descripcion + '"  />'+ resp[i].Descripcion+'</td>';
                if ((i+1) % 2 == 0) {

                    columnaAcumulada = columnaAcumulada + item + '</tr>';
                    capaFilas = capaFilas + columnaAcumulada;
                    columnaAcumulada = '';
                    item = '<tr>';
                } else {
                    columnaAcumulada = columnaAcumulada + item;
                    item = '';
                }               
                

            }
            if (longitud % 2 != 0) {
                capaFilas = capaFilas + columnaAcumulada+'<td></td></tr>';
            }
            
            tiposLiquidaciones.innerHTML = capaInicio + capaFilas + capaFin;

            /*permite solo seleccionar un checkbox a la vez del grupo de clase chk_listado*/
            $('.radio_listado').click(function () {
               $('.radio_listado').not(this).prop('checked', false);
            });

        })
        .onError(function (e) {

        });

    }

    

    /*retorna si se esta en modo historico o no*/
    function importarRecibos() {

        //obtengo la lista de radio button con un nombre de clase determinado
        var lista = document.getElementsByClassName("radio_listado");
        var i;
        var valorTipoLiquidacion = -1;
        var comprobaciones = true;

        for (i = 0; i < lista.length; i++) {
            //si hay algo seleccionado
            if (lista[i].checked) {
                valorTipoLiquidacion = lista[i].id;
            }
        } 
        if (valorTipoLiquidacion == -1) {
            alertify.alert("", "Debe seleccionar un Tipo de Liquidación."); comprobaciones = false;
        } else {
            if (document.getElementById("descripcionImportacion").value == '') {
                alertify.alert("", "Debe ingresar una Descripción.");comprobaciones = false;
            } else {
                if (document.getElementById("archivo1").value == "") {
                    alertify.alert("", "Debe seleccionar un archivo de origen.");comprobaciones = false;
                } else {
                    if ($("#cmb_anio option:selected").val() == '') {
                        alertify.alert("", "Debe ingresar un Año.");comprobaciones = false;
                    } else {
                        if ($("#cmb_meses option:selected").val() == '') {
                            alertify.alert("", "Debe ingresar un Mes."); comprobaciones = false;
                        } else {
                            //controlo que tenga un registro por lo menos
                            var fstChar = contenidoArchivo.charAt(0);
                            if (fstChar != 1) {
                                alertify.alert("El archivo seleccionado no contiene recibos."); comprobaciones = false;
                            }
                        }        
                    }        
                }  
            }        
        }
         

        if (comprobaciones) {
            var frm = document.form1;
            var archivo = frm.archivo1.value;
            var nom = archivo.substring(archivo.lastIndexOf("\\") + 1, archivo.length);
            var nomSinExtension = archivo.substring(archivo.lastIndexOf("\\") + 1, archivo.length - 4);
            //alert(nom);
            //alert(contenidoArchivo);

            var spinner = new Spinner({ scale: 2 });
            spinner.spin($("html")[0]);
            Backend.GetArchivoImportado(nom).
            onSuccess(function (respuestaJSON) {                
                var resp = JSON.parse(respuestaJSON);
                if (resp.tipoDeRespuesta == "archivoImportado.ok") {
                    spinner.stop();
                    //el archivo con ese nombre ya existe
                    alertify.alert("El archivo ya fue importado.");
                } else {                    
                    //controlo la importacion
                    Backend.ImportarRecibos($("#cmb_meses option:selected").val(),$("#cmb_anio option:selected").val(),document.getElementById("descripcionImportacion").value,valorTipoLiquidacion,contenidoArchivo,nom).
                            onSuccess(function (respuestaJSON) {
                                spinner.stop(); 
                                var resp = JSON.parse(respuestaJSON);
                                if (resp.result == "archivoImportado.ok") {
                                    alertify.success("La importación fue exitosa. Se importaron " + resp.cantRegistros+ " recibos.");
                                } else {
                                    alertify.error(""+resp.error);
                                }
                            })
                            .onError(function (e) {
                                spinner.stop();
                                alertify.error("No se ha podido realizar la importación");
                            });

                    
                    
                }
            })
            .onError(function (e) {
                spinner.stop();
            });
    

        }
        
         
    }

    function mostrar(id){
        document.getElementById(id).style.display = 'inline';
    }
    function ocultar(id){
        document.getElementById(id).style.display = 'none';
    }

    function GuardarDDJJ() {

        var compno = document.getElementById("compno");
        var compsi = document.getElementById("compsi");
        var comp1 = document.getElementById("comp1");
        var comp2 = document.getElementById("comp2");
        var comp3 = document.getElementById("comp3");
        var comp4 = document.getElementById("comp4");
        var djj1 = document.getElementById("djj1");
        var djj2 = document.getElementById("djj2");
        var fi1 = document.getElementById("opa1");
        var fh1 = document.getElementById("opb1");
        var n1 = document.getElementById("pais1");
        var fi2 = document.getElementById("opa2");
        var fh2 = document.getElementById("opb2");
        var n2 = document.getElementById("pais2");
        var fi3 = document.getElementById("opa3");
        var fh3 = document.getElementById("opb3");
        var n3 = document.getElementById("pais3");
        var fi4 = document.getElementById("opa4");
        var fh4 = document.getElementById("opb4");
        var n4 = document.getElementById("pais4");
        var fi5 = document.getElementById("opa5");
        var fh5 = document.getElementById("opb5");
        var n5 = document.getElementById("pais5");

        if (compno.checked) { v1 = "x" }
        else { v1 = "" }
        if (compsi.checked) { v2 = "x" }
        else { v2 = "" }
        if (comp1.checked) { v3 = "x" }
        else { v3 = "" }
        if (comp2.checked) { v4 = "x" }
        else { v4 = "" }
        if (comp3.checked) { v5 = "x" }
        else { v5 = "" }
        if (comp4.checked) { v6 = "x" }
        else { v6 = "" }
        if (djj1.checked) { v7 = "x" }
        else { v7 = "" }
        if (djj2.checked) { v8 = "x" }
        else { v8 = "" }
                
        Backend.GuardarDDJJCOVID19(v1, v2, v3, v4, v5, v6, v7, v8, fi1.value, fh1.value, $("#pais1 option:selected").val(), fi2.value, fh2.value, $("#pais2 option:selected").val(), fi3.value, fh3.value, $("#pais3 option:selected").val(), fi4.value, fh4.value, $("#pais4 option:selected").val(), fi5.value, fh5.value, $("#pais5 option:selected").val()/*,""*/)     
        .onSuccess(function (resp) {
            
            //var dataURI = "data:application/pdf;base64," +resp.Respuesta;
            // window.open(dataURI);
            var link = document.createElement('a');
            link.download = 'Test.pdf';
            link.href= "data:application/pdf;base64," +resp.Respuesta;
            link.textContent = 'Download PDF';
            link.click();
            document.body.appendChild(link);
        })
        .onError(function (e) {
            alert("0");
            });


        

    }

</script> 
</html>
