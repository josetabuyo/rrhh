<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaDeReportesAlumnos.aspx.cs" Inherits="SACC_FormPlanillaDeReportesAlumnos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%= Referencias.Css("../")%>
    <script src="../Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    <link id="link3" rel="stylesheet" href="Estilos/EstilosSACC.css" type="text/css" runat="server" /> 
     <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="../Estilos/alertify.default.css"  />
     <script type="text/javascript" src="Scripts/modernizr.custom.js" ></script>

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
    

            <div >
                <div class="main">
                    <section>
                        <input id="showLeft" style="margin: 5px;" class="btn btn-primary " type="button" value="Ver Reportes" ></input>
                    </section>   
                </div>
            </div>

             <input type="hidden" class="btn btn-primary " id="accion" value="" runat="server" />
               <nav class="cbp-spmenu cbp-spmenu-left" id="cbp-spmenu-s1" style="z-index:9999; margin-top:120px;">
                    <h3>Alumnos</h3>
                    <div class="cbp-spmenu-vertical">
                    <a id="modalidad" href="FormPlanillaDeReportesAlumnos.aspx?accion=modalidad">Por Modalidad</a>
                    <a href="FormPlanillaDeReportesAlumnos.aspx?accion=ciclo">Por Ciclo</a>
                    <a href="FormPlanillaDeReportesAlumnos.aspx?accion=organismo">Por Organismo</a>
                    <a href="FormPlanillaDeReportesAlumnos.aspx?accion=materia">Materia Sin Cursar</a>
                    </div>
                    <h3>Materias</h3>
                     <div class="cbp-spmenu-vertical">
                    <a href="FormPlanillaDeReportesAlumnos.aspx?accion=materia">Por Materias</a>
                    </div>
                </nav>




    <div id="panelAlumno" class="div_izquierdo">
    <fieldset>
        <legend class="subtitulos">Reportes</legend>
             <div class="estilo_formulario" style="overflow:hidden; width: 95%;">

                <div id="div_parametros" style="display: none;" > 
                  <legend id="lb_parametros">Parámetros</legend>
                    <div><asp:DropDownList ID="cmbCampo" runat="server" enableviewstate="true">
                        <asp:ListItem Value="-1" class="placeholder" Selected="true">Todos</asp:ListItem></asp:DropDownList>
                         <label style="margin-left: 10px"> Fecha Desde</label>
                            <input type="text" id="idFechaDesde" class="text_10caracteres hasDatepicker"/>
                        <label style="margin-left: 10px"> Fecha Hasta</label>
                            <input type="text" id="idFechaHasta" class="text_10caracteres hasDatepicker"/>
                            <input type="button" id="btn_buscarReportes" class="btn btn-primary"  value="Buscar" style="margin: 10px;"/>   
                    </div>
                  <legend id="lb_grafico">Gráfico</legend>
                        <div id="dibujo_grafico" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
                </div> 
            </div>    
     </fieldset>
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
               <%-- <p><asp:Button ID="btn_exportal_excel" Text="Exportar a Excel" runat="server" OnClick="btnExportarAlumnos_Click" class=" btn btn-primary" style="float:right;" /></p>--%>
       </fieldset>
    </div>

    <asp:HiddenField ID="tipo_busqueda" runat="server" />


    <asp:HiddenField ID="cursosJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="alumnosJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="nro_total" runat="server" EnableViewState="true"/>
<%--    <asp:HiddenField ID="idFechaDesde" value="01/01/2013" runat="server" />
    <asp:HiddenField ID="idFechaHasta" value="31/12/2013" runat="server" />--%>

    </form>
</body>
     <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="Scripts/highcharts.js"></script>
    <script type="text/javascript" src="Scripts/exporting.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="Scripts/classie.js" ></script>
    <script type="text/javascript" src="Scripts/Reportes.js"></script>
    <script type="text/javascript" src="Scripts/AdministradorDeMensajes.js"></script>
    <script type="text/javascript" src="../Scripts/placeholder_ie.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>


    
<script type="text/javascript">

    //Al presionarse Enter luego de Ingresar el DNI, se fuerza a realizar la búsqueda de dicho DNI para no tener que hacer necesariamente un click en el botón Buscar
    function CapturarTeclaEnter(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 13) && (node.type == "text")) { return false }
    }
    document.onkeypress = CapturarTeclaEnter;



    var BuscarPorModalidad = function () {

       HabilitarParametros();
       AdministradorPlanilla();
    }

    var HabilitarParametros = function () {
        $('#btnBuscarCampo').show();
//        $('#idFechaDesde').show();
//        $('#idFechaHasta').show();
//        $('#cmbCampo').show();
//        $('#lblCampo').show();
        $('#parametros').show();
    
    }


    var AdministradorPlanilla = function () {


        var items_pantalla = {
            alumnos: JSON.parse($('#alumnosJSON').val()),
            // alumnoGlobal: $("<div>"),
            planillaAlumnosDisponibles: $("<div>"),
            cmbCombo: $("#cmbCampo"),
            //panelAlumnoDisponibles: $("#panelAlumnoDisponibles"),
            contenedorAlumnosDisponibles: $('#grillaAlumnosDisponibles'),
            fechaDesde: $('#idFechaDesde'),
            fechaHasta: $('#idFechaHasta'),
            //            botonAsignarAlumno: $("#Img1"),
            //            botonDesAsignarAlumno: $("#Img2"),
            botonModalidad: $("#btn_modalidad"),
            //cmbCursos: $("#cmbCursos"),
            cmbCampo: $("#cmbCampo"),
            canvasPie: document.getElementById("dibujo_grafico")
            //cursosJSON: JSON.parse($('#cursosJSON').val())
        }


        var modulo_inscripcion = new PaginaReporteAlumnos(items_pantalla);


        modulo_inscripcion.PrimeraBusqueda();
        // modulo_inscripcion.BuscarPorOrganismo();

    };

    var DeterminarReporteEnPantalla = function (accion) {

        if (accion == "") {
            $('#div_parametros').hide();
            $('#search').hide();
            $('#lb_grafico').hide();
            $('#referencias').hide();
            
        } else {
            $('#div_parametros').show();
            $('#lb_grafico').show();
            $('#referencias').show();

            if (accion == "modalidad") {
                $('#lb_parametros').text(" Parámetros - Por Modalidad");
                $('#btnBuscarCampo').show();}

            if (accion == "organismo") {
                $('#lb_parametros').text(" Parámetros - Por Organismo");}

            if (accion == "ciclo") {
                $('#lb_parametros').text(" Parámetros - Por Ciclo");}

            if (accion == "materia") {
                $('#lb_parametros').text(" Parámetros - Por Materia");}
        }

        AdministradorPlanilla();
    }

    $(document).ready(function () {

        DeterminarReporteEnPantalla($("#accion").val());
  });


//Funciones para el Menú Lateral Izquierdo

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