<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaDeReportesAlumnos.aspx.cs" Inherits="SACC_FormPlanillaDeReportesAlumnos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link id="link9" rel="stylesheet" href="Estilos/EstilosSACC.css"  type="text/css" runat="server"/>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <link id="link4" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> 
    <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="../Estilos/alertify.default.css"  />
     <script type="text/javascript" src="Scripts/modernizr.custom.js" ></script>
<%--    <meta name = "viewport" content = "initial-scale = 1, user-scalable = no">
		<style>
			canvas{}
		</style>--%>

 <style type="text/css"> 
         
    .encabezado_fecha
    {
        text-align:center;        
        visibility:visible;
        background-color: transparent !important;
        color: White !important;
        border: none !important;
        cursor:default !important;
        width: 80px;
        margin-top:6px;
    }
    .nota_no_valida, .fecha_no_valida
    {
        background-color: #FF3300 !important;
    }
    .text_2caracteres
    {
        max-width: 20px;
        margin-left: 3px;
        border-width: 1px;
        border-style: solid;
        border-color: rgb(67, 58, 116)!important;
    }
    .text_10caracteres
    {
        max-width: 100px;
        margin-left: 17px;
        border-width: 2px;
        border-style: solid;
        border-color: rgb(67, 58, 116)!important;
    }
    
    .text_2caracteres:hover, .text_10caracteres:hover 
    {     
        border-color: rgb(255, 187, 187)!important;
    }
    </style>
   
</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
     <uc2:BarraMenu ID="BarraMenu" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
     <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
    
    <div id="panelAlumno"  class="div_izquierdo">
  
            <legend class="subtitulos">Reportes</legend>

             <div class="estilo_formulario" style="overflow: hidden; margin-right: 15px;">
               <div class="container">
                <div class="main">
                    <section>
                        <input id="showLeft" style="margin: 5px;" class="btn btn-primary " type="button" value="Ver Reportes" ></input>
                    </section>   
                </div>
            </div>

             <input type="hidden" class="btn btn-primary " id="accion" value="" runat="server" />
               <nav class="cbp-spmenu cbp-spmenu-left" id="cbp-spmenu-s1">
                    <h3>Alumnos</h3>
                    <div class="cbp-spmenu-vertical">
                    <a href="FormPlanillaDeReportesAlumnos.aspx?accion=modalidad">Por Modalidad</a>
                    <a href="FormPlanillaDeReportesAlumnos.aspx?accion=ciclo">Por Ciclo</a>
                    <a href="FormPlanillaDeReportesAlumnos.aspx?accion=organismo">Por Organismo</a>
                    <a href="FormPlanillaDeReportesAlumnos.aspx?accion=materia">Materia Sin Cursar</a>
                    </div>
                    <h3>Materias</h3>
                     <div class="cbp-spmenu-vertical">
                    <a href="FormPlanillaDeReportesAlumnos.aspx?accion=materia">Por Materias</a>
                    </div>
                </nav>

                <div id="div_parametros" style="margin-left: 250px; display:none;"> 
                  <legend id="lb_parametros">Parámetros</legend>
                   <p><asp:DropDownList ID="cmbCampo" runat="server" enableviewstate="true">
                <asp:ListItem Value="-1" class="placeholder" Selected="true">Todos</asp:ListItem></asp:DropDownList></p>
                 <asp:Button ID="btnBuscarCampo" Text="Buscar" runat="server" OnClick="btnBuscarCampo_Click" class=" btn btn-primary" style="float:right;" />
               
                               <%--<label> Fecha Desde</label>
               <input type="text" id="idFechaDesde" class="text_10caracteres hasDatepicker">
               <label> Fecha Hasta</label>
               <input type="text" id="idFechaHasta" class="text_10caracteres hasDatepicker">--%>
             
                </div>

            
            
              <%-- <legend>Gráfico</legend>
               <canvas id="canvas" height="350" width="350"></canvas>--%>
            </div> 
           
     
    </div>

    <div class="div_derecho">
        <fieldset>
            <legend class="subtitulos">Listado de Resultados</legend>
                <div class="estilo_formulario" style="width:95%; overflow:auto;">
                    <div id="grillaAlumnosDisponibles" runat="server">
                        <div class="input-append" style="clear:both;">   
                            <input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Filtrar Alumnos" />    
                        </div>
                    </div>
                </div>
                <p><asp:Button ID="btn_exportal_excel" Text="Exportar a Excel" runat="server" OnClick="btnExportarAlumnos_Click" class=" btn btn-primary" style="float:right;" /></p>
       </fieldset>
    </div>

    <asp:HiddenField ID="tipo_busqueda" runat="server" />

    <asp:HiddenField ID="cursosJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="alumnosJSON" runat="server" EnableViewState="true"/>
<%--    <asp:HiddenField ID="idFechaDesde" value="01/01/2013" runat="server" />
    <asp:HiddenField ID="idFechaHasta" value="31/12/2013" runat="server" />--%>

    </form>
</body>
   
    <script type="text/javascript" src="Scripts/classie.js" ></script>
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../SACC/Scripts/Reportes.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>  
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/list.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-transition.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-alert.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-modal.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-tab.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-tooltip.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-popover.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-button.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-typeahead.js"></script>
    <script type="text/javascript" src="../SACC/Scripts/AdministradorDeMensajes.js"></script>
    <script type="text/javascript" src="../SACC/Scripts/Chart.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/placeholder_ie.js"></script>


    
<script type="text/javascript">


    var BuscarPorModalidad = function () {

       // HabilitarParametros();
       // AdministradorPlanilla();
    }

    var HabilitarParametros = function () {
        $('#btnBuscarCampo').show();
        $('#idFechaDesde').show();
        $('#idFechaHasta').show();
//        $('#cmbCampo').show();
//        $('#lblCampo').show();
        $('#parametros').show();
    
    }


    var AdministradorPlanilla = function () {



        var items_pantalla = {
            //alumnos: JSON.parse($('#alumnosJSON').val()),
           // alumnoGlobal: $("<div>"),
            planillaAlumnosDisponibles: $("<div>"),
            //panelAlumnoDisponibles: $("#panelAlumnoDisponibles"),
            contenedorAlumnosDisponibles: $('#grillaAlumnosDisponibles'),
//            botonAsignarAlumno: $("#Img1"),
//            botonDesAsignarAlumno: $("#Img2"),
            botonModalidad: $("#btn_modalidad"),
            //cmbCursos: $("#cmbCursos"),
            cmbCampo: $("#cmbCampo")
            //cursosJSON: JSON.parse($('#cursosJSON').val())
        }


        var modulo_inscripcion = new PaginaReporteAlumnos(items_pantalla);

        modulo_inscripcion.BuscarPorModalidad();



//        var options = {
//            valueNames: ['Documento', 'Nombre', 'Apellido', 'Modalidad']
//        };

       // var featureListAlumnosDisponibles = new List('grillaAlumnosDisponibles', options);
    };

    var DeterminarReporteEnPantalla = function (accion) {

        if (accion == "") {
            $('#div_parametros').hide();

        } else {
            $('#div_parametros').show();

            if (accion == "modalidad") {
                $('#lb_parametros').text(" Parámetros - Por Modalidad");
                $('#btnBuscarCampo').show();

            }

            if (accion == "organismo") {
                $('#lb_parametros').text(" Parámetros - Por Organismo");

            }

            if (accion == "ciclo") {
                $('#lb_parametros').text(" Parámetros - Por Ciclo");

            }

            if (accion == "materia") {
                $('#lb_parametros').text(" Parámetros - Por Materia");

            }
        }

    }

    $(document).ready(function () {

        DeterminarReporteEnPantalla($("#accion").val());

//      $('#btnBuscarCampo').hide();
//      $('#idFechaDesde').hide();
//      $('#idFechaHasta').hide();
//      $('#cmbCampo').hide();
//      $('#lblCampo').hide();
//      $('#parametros').hide();


      //Estilos para ver coloreada la grilla en Internet Explorer
      $("tbody tr:even").css('background-color', '#E6E6FA');
      $("tbody tr:odd").css('background-color', '#9CB3D6 ');

      

  });

    
//    var PlanillaAlumnos;
//    var contenedorPlanilla;

//    var AdministradorPlanillaMensual = function () {
//        var Alumnos = JSON.parse($('#alumnosJSON').val());
//        //var nombreAlumno = Alumnos['nombre'];
//        var panelAlumno = $("#panelAlumno");

//        var listaPersonas = $('#personasJSON');
//        var selectorDePersonas = $('#input_dni');
//        var personaSeleccionada = $('#personaSeleccionada');

//        //crearInputAutocompletable(selectorDePersonas, listaPersonas, personaSeleccionada);

//        var EncabezadoPlanilla;
//        contenedorPlanilla = $('#ContenedorPlanilla');


////        PlanillaAlumnos = new Grilla(columnas);

//        PlanillaAlumnos.AgregarEstilo("tabla_macc");
//        //PlanillaAlumnos.agregarBuscador();

//        PlanillaAlumnos.SetOnRowClickEventHandler(function (un_alumno) {
//            panelAlumno.CompletarDatosAlumno(un_alumno);
//        });

//        PlanillaAlumnos.CargarObjetos(Alumnos);
//        PlanillaAlumnos.DibujarEn(contenedorPlanilla);



//        panelAlumno.CompletarDatosAlumno = function (un_alumno) {

//            $("#input_dni").val("");
//            $("#idAlumnoAVer").val(un_alumno.Id);
//            $("#lblDatoApellido").val(un_alumno.Apellido);
//            $("#lblDatoNombre").val(un_alumno.Nombre);
//            $("#lblDatoDocumento").val(un_alumno.Documento);
//            $("#lblDatoTelefono").val(un_alumno.Telefono);
//            $("#lblDatoMail").val(un_alumno.Mail);
//            $("#lblDatoDireccion").val(un_alumno.Direccion);
//            $("#cmbPlanDeEstudio").val(un_alumno.Modalidad.Id);
//            $("#idBaja").val(un_alumno.Baja);
//            $("#btnAgregarAlumno").attr("disabled", true);
//            $("#btnModificarAlumno").attr("disabled", false);
//            $("#btnQuitarAlumno").attr("disabled", false);
//        };

//        var options = {
//            valueNames: ['Documento', 'Nombre', 'Apellido', 'Modalidad']
//        };

//        var featureList = new List('ContenedorPlanilla', options);
//    }

//    function crearInputAutocompletable(input, lista, elementoSeleccionado) {
//        input.attr('data-source', lista.val());
//        input.attr("autocomplete", "off");
//        input.blur(function () {
//            try {
//                if (input.val() != '') {
//                    var itemSeleccionado = input.data().typeahead.$menu.find('.active').data().item;
//                    elementoSeleccionado.val(itemSeleccionado.value);
//                    input.val(itemSeleccionado.label);
//                }
//                else {
//                    elementoSeleccionado.val('');
//                }
//            }
//            catch (e) {
//                elementoSeleccionado.val('');
//                input.val('');
//            }
//        });
//    }


//    $(document).ready(function () {
//        AdministradorPlanillaMensual();

//        //Estilos para ver coloreada la grilla en Internet Explorer
//        $("tbody tr:even").css('background-color', '#E6E6FA');
//        $("tbody tr:odd").css('background-color', '#9CB3D6 ');

//    });

    //Gráficos
//    var pieData = [
//				{
//				    value: 30,
//				    color: "#F38630"
//				},
//				{
//				    value: 50,
//				    color: "#E0E4CC"
//				},
//				{
//				    value: 100,
//				    color: "#69D2E7"
//				}

//			];

//    var myPie = new Chart(document.getElementById("canvas").getContext("2d")).Pie(pieData);


  var menuLeft = document.getElementById('cbp-spmenu-s1'),
        showLeft = document.getElementById('showLeft'),
        body = document.body;

  showLeft.onclick = function () {
      classie.toggle(this, 'active');
      classie.toggle(menuLeft, 'cbp-spmenu-open');
      disableOther('showLeft');
  };
  
  function disableOther(button) {
      if (button !== 'showLeft') {
          classie.toggle(showLeft, 'disabled');
      } 
  }



</script>
</html>