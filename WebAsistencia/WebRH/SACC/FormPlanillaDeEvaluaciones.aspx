<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormPlanillaDeEvaluaciones.aspx.cs" Inherits="SACC_FormPlanillaDeEvaluaciones" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Planilla De Evaluaciones</title>
    <%= Referencias.Css("../")%>
    <link id="link3" rel="stylesheet" href="EstilosSACC.css" type="text/css" runat="server" /> 
    <link rel="stylesheet" href="../Estilos/alertify.core.css" id="toggleCSS" />
    <link rel="stylesheet" href="../Estilos/alertify.default.css"  />
    <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>

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
        margin-top:8px;
        
    }
    
    .text_2caracteres:hover, .text_10caracteres:hover 
    {     
        border-color: rgb(255, 187, 187)!important;
    }
        

    
    </style>
</head>
<body class="marca_de_agua">
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.C.C</span> <br/> Módulo de Administración <br/> de Creación de Capacidades" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
        <fieldset>
            <legend class="subtitulos">Evaluaciones</legend>
            <div id="DivContenedor" runat="server" class="div_izquierdo2" style="margin:10px; z-index:999;  ">
                <label class="label_evaluaciones">Curso:</label>
                <select id="CmbCurso" onchange="javascript:cargar_instancias(this.value);" runat="server">
                    <option value="0">Seleccione</option>
                </select>
                <br />
                <div id="ContenedorInstancia">
                </div>                       
            <div>
            <div id="ContenedorPlanilla" style="display:inline-block"></div>
            <br />
            <input type="button" class="btn btn-primary " id="BtnGuardarEvaluaciones" onclick="javascript:admin_planilla.guardarPlanilla();" value="Guardar Cambios" style="display:none;" />
            <input type="button" class="btn btn-primary " id="BtnImprimir" onclick="javascript:admin_planilla.imprimirPlanilla();" value="Imprimir" style="display:none;" />
            <input type="hidden" class="btn btn-primary " id="accion" value="" runat="server" />
            </div>
            </div>
        </fieldset>
    </form>

   <%= Referencias.Javascript("../") %>
    <script type="text/javascript" src="Scripts/planilla_ingreso.js"></script>
    <script type="text/javascript" src="../Scripts/alertify.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap/js/bootstrap-dropdown.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>

</body>
<script type="text/javascript">
    var admin_planilla;
    function cargar_instancias(id_curso) {
        var instancias;
        var accion = $("#accion").val();
        var contenedor = $("#ContenedorInstancia");
        contenedor.html("");
        if (id_curso > 0) {
            if (accion == "c") {
                var etiqueta = $("<label>").text("Instancias");
                etiqueta.attr("class", "label_evaluaciones");
                instancias = $("<select>").attr("id", "Instancias").change(function () {
                    admin_planilla.cargarPlanilla();
                }).get(0);

                instancias.options.length = 0;
                contenedor.append(etiqueta).append($(instancias));
            } else {
                var instancias = $("<input>").attr("type", "hidden").attr("id", "Instancias");
                contenedor.append(instancias);
            }
            if (id_curso > 0) {
                var data_post = JSON.stringify({
                    'id_curso': id_curso
                });

                $.ajax({
                    url: "../AjaxWS.asmx/GetInstanciasDeEvaluacion",
                    type: "POST",
                    async: false,
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        if (accion == "c") {
                            if (respuesta.length > 1) {
                                instancias.add(new Option("Seleccione", "-1"));
                                instancias.add(new Option("Todos", 0));
                            }
                            for (var i = 0; i < respuesta.length; i++) {
                                instancias.add(new Option(respuesta[i].Descripcion, respuesta[i].Id));
                            }
                        } else {
                            instancias.val("0");
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            }
            admin_planilla.cargarPlanilla();    
        }else{
            admin_planilla.limpiarGrilla();
        }
    }

    var AdministradorDeEvaluaciones = function () {
        var _this = this;
        var pla;
        var planilla_original;
        var readonly = $("#accion").val() == "a";
        var contenedor_grilla = $("#ContenedorPlanilla");
        var btn_guardar = $("#BtnGuardarEvaluaciones");
        var btn_imprimir = $("#BtnImprimir");

        _this.limpiarGrilla = function () {
            contenedor_grilla.html("");
            btn_guardar.hide();
        }

        _this.cargarPlanilla = function () {
            _this.limpiarGrilla();
            var instancias = $("#Instancias").val();
            var cursos = $("#CmbCurso").val();
            if (instancias && instancias != "-1") {
                var data_post = JSON.stringify({
                    'id_curso': cursos,
                    'id_instancia': instancias
                });

                $.ajax({
                    url: "../AjaxWS.asmx/GetPlanillaEvaluaciones",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        if (respuesta.MensajeError === "") {
                            _this.dibujarGrilla(respuesta);
                            planilla_original = JSON.parse(respuestaJson.d);
                        }
                        else {
                            alertify.alert(respuesta.MensajeError);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            } else {
                contenedor_grilla.html("");
            }
        };
        _this.guardarPlanilla = function () {

            var evaluaciones = [];
            var calificaciones_no_validas = 0;
            for (var i = 0; i < pla.evaluaciones.length; i++) {
                var ev = pla.evaluaciones[i];
                if (ev.es_valida()) {
                    ev.Calificacion = ev.nota.html.val();
                    evaluaciones.push({ Id: ev.Id,
                        Calificacion: ev.nota.html.val(),
                        DNIAlumno: ev.DNIAlumno,
                        IdCurso: ev.IdCurso,
                        Fecha: ev.fecha.html.val(),
                        IdInstancia: ev.IdInstancia
                    });                  
                } else {
                    calificaciones_no_validas++;
                }


            }
            if (calificaciones_no_validas > 0) {
                alertify.alert("Hay calificaciones mal cargadas, no se puede realizar el guardado");
            } else {

                var data_post = JSON.stringify({
                    "evaluaciones_nuevas": JSON.stringify(evaluaciones),
                    "evaluaciones_originales": JSON.stringify(planilla_original.Evaluaciones)
                });
                $.ajax({
                    url: "../AjaxWS.asmx/GuardarEvaluaciones",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        if (respuesta.length > 0)
                            _this.MostrarDetalleErrores(respuesta);
                        alertify.alert("Las calificaciones se guardaron correctamente");
                        _this.cargarPlanilla();
                        
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            }

        };
        _this.dibujarGrilla = function (planilla) {
            var columnas = []

            var instancias = $("#Instancias");

            pla = new Planilla(planilla, readonly);

            if (instancias.val() >= 0) {
                columnas.push(new Columna("Nombre", { generar: function (fila) { return fila.alumno; } }));
                for (var i = 0; i < pla.instancias.length; i++) {
                    columnas.push(new Columna(pla.instancias.html(i), new GeneradorCalificacionEvaluacion(pla.instancias[i])));
                }

                var grilla = new Grilla(columnas);

                grilla.AgregarEstilo("tabla_macc");

                grilla.SetOnRowClickEventHandler(function () {
                    return true;
                });
                grilla.CargarObjetos(pla.grilla());
                grilla.DibujarEn(contenedor_grilla);
                if (readonly) {
                    btn_guardar.hide();
                    btn_imprimir.show();
                } else {
                    btn_guardar.show();
                    btn_imprimir.hide();
                }
            }

            //Estilos para ver coloreada la grilla en Internet Explorer
            $("tbody tr:even").css('background-color', '#E6E6FA');
            $("tbody tr:odd").css('background-color', '#9CB3D6 ');
        }

        _this.MostrarDetalleErrores = function (evaluaciones_con_errores) {
            var mensaje = "Se produjo un error al guardar las siguientes evaluaciones:\n\n";
            
            var alumnos = planilla_original.Alumnos;
            var instancias = planilla_original.Instancias;
            for (var i = 0; i < evaluaciones_con_errores.length; i++) {
                var alumno = Enumerable.From(alumnos)
                                       .Where(function (x) { return x.Documento == evaluaciones_con_errores[i].DNIAlumno }).First();
                var instancia = Enumerable.From(instancias)
                                       .Where(function (x) { return x.Id == evaluaciones_con_errores[i].IdInstancia }).First();

                mensaje += "Alumno: " + alumno.Nombre + " " + alumno.Apellido + " (" + instancia.Descripcion + ")\n";

            }

            alertify.alert(mensaje);
        }

        _this.imprimirPlanilla = function () {
            var w = window.open();

            w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap.css' type='text/css' />");
            w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap-responsive.css' type='text/css' />");
            w.document.write("<link  rel='stylesheet' href='../Estilos/Estilos.css' type='text/css'  />");
            w.document.write("<style>div_print{margin:20px;}.text_2caracteres{max-width: 20px;margin-left: 3px;}.text_10caracteres{max-width: 100px;margin-left: 17px;}</style>");
            w.document.write("<div class='div_print'><br>Curso: " + $("#CmbCurso option:selected").text() + "<br><br></div>");
            w.document.write(contenedor_grilla.html());
            w.print();
            //w.close();
        }

    }
    $(document).ready(function () {
        admin_planilla = new AdministradorDeEvaluaciones();

        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');
    });

    /**************************************************************************************************
    Pad a string to pad_length fillig it with pad_char.
    By default the function performs a left pad, unless pad_right is set to true.

    If the value of pad_length is negative, less than, or equal to the length of the input string, no padding takes place.
    **************************************************************************************************/
    String.prototype.pad = function (pad_char, pad_length, pad_right) {
        var result = this;
        if ((typeof pad_char === 'string') && (pad_char.length === 1) && (pad_length > this.length)) {
            var padding = new Array(pad_length - this.length + 1).join(pad_char); //thanks to http://stackoverflow.com/questions/202605/repeat-string-javascript/2433358#2433358
            result = (pad_right ? result + padding : padding + result);
        }
        return result;
    }
</script>
</html>
