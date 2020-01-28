<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportarRecibos.aspx.cs" Inherits="Permisos_DefinicionDeUsuario" %>
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
        <link rel="stylesheet" href="recibo.css" />

        <script type="text/javascript" src="../Scripts/ConversorDeFechas.js" ></script>
        <link rel="stylesheet"  href="estilosPermisos.css" />
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
        <div class="caja_izq no-print"></div>
        <!--contenido derecho -->
         <div  class="caja_derxxxx papelxxx" style="margin-top:32px;float:left;width:80% ">
           <!--modulo de importacion de recibos -->
           <div id="subcontenidoBusquedaRecibosConformados" class="panelDerOcultable" style="display: inline;"> 

               <div style="width:80%;margin:20pt;-webkit-border-radius: 7px 7px 0px 0px;
-moz-border-radius: 7px 7px 0px 0px;border-radius: 7px 7px 0px 0px;border-collapse: collapse;border: 0px solid #1C6EA4;padding-left:40pt;text-align: left;margin: 0 auto;">
                   <table class="" style="width:90%;margin:0 20pt 20pt 20pt;-webkit-border-radius: 7px 7px 0px 0px;
-moz-border-radius: 7px 7px 0px 0px;border-radius: 7px 7px 0px 0px;border-collapse: collapse;border: 0px solid rgb(1,70,99);">
             <tbody>
                 <tr><td style="background-image: linear-gradient(to bottom, rgb(1,70,99), rgb(1,70,99))/*linear-gradient(to bottom, #2574AD, #2574AD)*/; color: #fff;font-size: 13pt;font-weight: bold;text-align:center;padding:10px">IMPORTACIÓN DE RECIBOS</td></tr>
                 <tr><td>
                     <div style="padding:10px; border:1px; border-color:rgb(1,70,99);border-style:solid">
                         <div style="margin-top:0px;">
                         <span style="float:left;padding-top:3px;padding-right:5px;">Archivo de Origen:</span><input  type="file" id="archivo1" name="archivo1" style="width:250pt;float:left;"/>
                         </div>
                         <br />
                         <hr class="barraHorizontal">
                         <br />
                         <select style="width:65px;" id="cmb_anio">
                         </select>
                         <select style="width:110px;" id="cmb_meses">
                         <option value="1">Enero</option>
                         <option value="2">Febrero</option>
                         <option value="3">Marzo</option>
                         <option value="4">Abril</option>
                         <option value="5">Mayo</option>
                         <option value="6">Junio</option>
                         <option value="7">Julio</option>
                         <option value="8">Agosto</option>
                         <option value="9">Septiembre</option>
                         <option value="10">Octubre</option>
                         <option value="11">Noviembre</option>
                         <option value="12">Diciembre</option>
                         </select>
                         Descripción: <input  type="text" id="descripcionImportacion"  style="width:260pt;position:relative;padding: 13px;margin: 0px;" maxlength="80"/>
                         <br /><br /><hr class="barraHorizontal">
                         <br /> 
                         <div style="font-weight: bold;">
                             Tipos de Liquidación:
                         </div>  
                         <div id="tiposLiquidaciones">
                
                         </div>
                         <div style="margin-bottom:30pt;padding-left:80%;margin-top:20pt; " >                     
                             <input style="margin: 0 auto;" class="botonAzul" type="button" value="Importar" onclick="importarRecibos()">                     
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

<script type="text/javascript" src="js/imprimirRecibo.js"></script>
<script type="text/javascript" src="../Scripts/Spin.js"></script>

<script type="text/javascript" src="Legajo.js"></script>
<script type="text/javascript" src="../Scripts/jsPortal/RepoFirmaDigital.js"></script>

<script type="text/javascript" >

   
    $(document).ready(function ($) {
             
        Backend.start(function () {
            //FAKE solo para probar la obtencion y descarga de un archivo
            /*Backend.GetReciboPDFDigital(980679, 0).
                onSuccess(function (respuestaJSON) { 
                    var resp = respuestaJSON;
                    var b64 =  resp.Respuesta;
                    var base64Data = b64;

                    if (true) {
                        Backend. GuardarReciboPDFFirmado(base64Data, 100, 980679, 2018, 11, 1).
                            onSuccess(function (respIdArchivo) {                
                                Backend. GetReciboPDFDigitalArchivado(respIdArchivo).
                                    onSuccess(function (respuestaJSON) {                
                                        var resp = respuestaJSON;
                        var b64 = resp.Respuesta;
                        var base64Data = b64;
                        var arrBuffer = base64ToArrayBuffer(base64Data);

                        // It is necessary to create a new blob object with mime-type explicitly set
                        // otherwise only Chrome works like it should
                        var newBlob = new Blob([arrBuffer], { type: "application/pdf" });

                        // IE doesn't allow using a blob object directly as link href
                        // instead it is necessary to use msSaveOrOpenBlob
                        if (window.navigator && window.navigator.msSaveOrOpenBlob) {
                            window.navigator.msSaveOrOpenBlob(newBlob);
                            return;
                        }

                        // For other browsers: 
                        // Create a link pointing to the ObjectURL containing the blob.
                        var data = window.URL.createObjectURL(newBlob);

                        var link = document.createElement('a');
                        document.body.appendChild(link); //required in FF, optional for Chrome
                        link.href = data; link.target = "_blank";
                        link.download = "980679.pdf";//este elemento hace que se descargue automaticamente si lo saco se abrira otra pagina
                        link.click();
                        window.URL.revokeObjectURL(data);
                        link.remove();
                                 
                                    })
                                    .onError(function (e) {
                        
                                    });                                 
                            })
                            .onError(function (e) {
                        
                            });
                    } else {
                        var resp = respuestaJSON;
                        var b64 = resp.Respuesta;
                        var base64Data = b64;
                        var arrBuffer = base64ToArrayBuffer(base64Data);

                        // It is necessary to create a new blob object with mime-type explicitly set
                        // otherwise only Chrome works like it should
                        var newBlob = new Blob([arrBuffer], { type: "application/pdf" });

                        // IE doesn't allow using a blob object directly as link href
                        // instead it is necessary to use msSaveOrOpenBlob
                        if (window.navigator && window.navigator.msSaveOrOpenBlob) {
                            window.navigator.msSaveOrOpenBlob(newBlob);
                            return;
                        }

                        // For other browsers: 
                        // Create a link pointing to the ObjectURL containing the blob.
                        var data = window.URL.createObjectURL(newBlob);

                        var link = document.createElement('a');
                        document.body.appendChild(link); //required in FF, optional for Chrome
                        link.href = data; link.target = "_blank";
                        link.download = "980679.pdf";//este elemento hace que se descargue automaticamente si lo saco se abrira otra pagina
                        link.click();
                        window.URL.revokeObjectURL(data);
                        link.remove();
                    }
            })
            .onError(function (e) {
                spinner.stop();
                });
           */
            //para cargar el menu izquierdo
            $(".caja_izq").load("SeccionIzquierda.htm", function () {
                var day = new Date();
                var mes = day.getMonth() + 1;
                var anio = day.getFullYear();
                               
                $("#cmb_anio").empty();

                for (var i = 0; i <= 2; i++) {
                     $("#cmb_anio").append('<option value=' + (anio - i).toString() + '>' + (anio - i).toString() + '</option>');
                                        
                }
                            
                $("#cmb_meses").val(mes);
                $("#cmb_anio").trigger('change');

                getTiposLiquidacion();
                 

            });
 
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

    /*******************funciones para la carga del archivo*****************/ 
    window.addEventListener('load', inicio, false);
    var contenidoArchivo = '';

    function inicio() {
        document.getElementById('archivo1').addEventListener('change', cargar, false);               
    }

    function cargar(ev) {
        /*document.getElementById('datos').innerHTML='Nombre del archivo:'+ev.target.files[0].name+'<br>'+
                                                   'Tamaño del archivo:'+ev.target.files[0].size+'<br>'+  
                                                   'Tipo MIME:'+ev.target.files[0].type;*/
        var arch=new FileReader();
        arch.addEventListener('load',leer,false);
        arch.readAsText(ev.target.files[0]);
    }
    
    function leer(ev) {
        contenidoArchivo = ev.target.result;
    }


    /*retorna si se esta en modo historico o no*/
    function importarRecibos() {

        //obtengo la lista de radio button con un nombre de clase determinado
        var lista = document.getElementsByClassName("radio_listado");
        var i;
        var valorTipoLiquidacion = -1;

        for (i = 0; i < lista.length; i++) {
            //si hay algo seleccionado
            if (lista[i].checked) {
                valorTipoLiquidacion = lista[i].value;
            }
        } 
        if (valorTipoLiquidacion == -1) {
            alertify.alert("","Debe seleccionar un Tipo de Liquidación.");
        }
        if (document.getElementById("descripcionImportacion").value == '') {
            alertify.alert("","Debe ingresar una Descripción.");
        }
        if (document.getElementById("archivo1").value == "") {
            alertify.alert("","Debe seleccionar un archivo de origen.");
        }        
        if ($("#cmb_anio option:selected").val() == '') {
            alertify.alert("","Debe ingresar un Año.");
        }
        if ($("#cmb_meses option:selected").val() == '') {
            alertify.alert("","Debe ingresar un Mes.");
        }

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
                    //controlo que tenga un registro por lo menos?VERRRRRR
                    //controlo la importacion
                    /*Backend.ImportarRecibos($("#cmb_meses option:selected").val(),$("#cmb_anio option:selected").val(),document.getElementById("descripcionImportacion").value,valorTipoLiquidacion,contenidoArchivo).
                        onSuccess(function (respuestaJSON) {
                            spinner.stop(); 
                            var resp = JSON.parse(respuestaJSON);
                            if (resp.result == "OK") {
                                alertify.success("La importación fue exitosa.");
                            } else {
                                alertify.error("No se ha podido realizar la importación");
                            }
                        })
                        .onError(function (e) {
                            spinner.stop();
                            alertify.error("No se ha podido realizar la importación");
                        });*/
                }
            })
            .onError(function (e) {
                spinner.stop();
            });
    
         
    }

</script> 
</html>
