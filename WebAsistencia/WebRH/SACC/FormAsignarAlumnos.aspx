<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FormAsignarAlumnos.aspx.cs" Inherits="SACC_FormAsignarAlumnos" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<%@ Register Src="BarraDeNavegacion.ascx" TagName="BarraNavegacion" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <script type="text/javascript" src="../Scripts/Grilla.js"></script>
    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/linq.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap-dropdown.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <uc2:BarraMenu ID="BarraMenu" runat="server" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    <uc3:BarraNavegacion ID="BarraNavegacion" runat="server" />
        
        <div style="margin:20px;">
        <fieldset>
            <legend>Elija ciclo y curso:</legend>
            <div>
                <asp:DropDownList ID="cmbCiclo" runat="server"  EnableViewState="false">
                    <asp:ListItem Value="-1" class="placeholder" Selected="true">Ciclo</asp:ListItem>
                </asp:DropDownList>    
            </div>
            <div>
                <asp:DropDownList ID="cmbCursos" runat="server" EnableViewState="false">
                    <asp:ListItem Value="0" class="placeholder" Selected="true">Cursos</asp:ListItem>
                </asp:DropDownList>        
            </div>
        </fieldset>
        </div>
        <div class="btn_inscripcion_SACC">
            <label id="descripcionCursoSeleccionado"></label> 
        </div>

    <div id="panelAlumnoDisponibles" style="margin-left:20px" class="div_izquierdo_inscripcion">
    <fieldset>
        <legend>Listado de Alumnos Para Inscribir</legend>
        <div style="float:left" class="tablas_alumnos" id="grillaAlumnosDisponibles" runat="server"></div>
    </fieldset>

    </div>
    <div style="margin-top:200px;float: left; padding-right:50px; width: 7%;">

        <p><img alt="" src="../Imagenes/Botones/Botones SACC/flecha_der.png" onclick="AsignarAlumno()"  height="40"  id="Img1" /></p>
        <p><img alt="" src="../Imagenes/Botones/Botones SACC/flecha_izq.png" onclick="DesasignarAlumno()"  height="40"  id="Img2" /></p>             
        <p><label id="mensaje" ></label></p>
        
        <asp:Button ID="btnGrabar" Text="Guardar Inscriptos" runat="server" OnClick="btnGrabarAsignacion_Click" class=" btn btn-primary boton_main_documentos" Visible="true"/> 
    </div>


    <div id="panelAlumnosAsignados" class="div_derecho_inscripcion">
    <fieldset>
        <legend>Listado de Alumnos Asignados al Curso de <span id="nombreDeCurso"></span></legend> 
        <div class="tablas_alumnos" id="grillaAlumnosAsignados" runat="server"></div>      
    </fieldset>
    </div>

    <asp:HiddenField ID="cursosJSON" runat="server" />
    <asp:HiddenField ID="idCursoSeleccionado" runat="server" />
    <asp:HiddenField ID="alumnosJSON" runat="server" EnableViewState="true"/>
    <asp:HiddenField ID="idAlumnoAVer" runat="server" />
    <asp:HiddenField ID="alumnosEnGrillaParaGuardar" runat="server" />

    </form>
</body>

<script type="text/javascript">
    var planillaAlumnosDisponibles;
    var planillaAlumnosAsignados;
    var contenedorAlumnosDisponibles;
    var contenedorAlumnosAsignados;
    var alumnoGlobal;

    var AdministradorPlanilla = function () {
        var alumnos = JSON.parse($('#alumnosJSON').val());
        var panelAlumnoDisponibles = $("#panelAlumnoDisponibles");
        var panelAlumnoAsignados = $("#panelAlumnosAsignados");
        contenedorAlumnosDisponibles = $('#grillaAlumnosDisponibles');
        contenedorAlumnosAsignados = $('#grillaAlumnosAsignados');
        var columnas = [];

        var cmbCursos = $("#cmbCursos");
        var cmbCiclo = $("#cmbCiclo");
        var cursosJSON = JSON.parse($('#cursosJSON').val());
        var idCursoSeleccionado = $("#idCursoSeleccionado");

        columnas.push(new Columna("Documento", { generar: function (un_alumno) { return un_alumno.Documento; } }));
        columnas.push(new Columna("Nombre", { generar: function (un_alumno) { return un_alumno.Nombre; } }));
        columnas.push(new Columna("Apellido", { generar: function (un_alumno) { return un_alumno.Apellido; } }));
        columnas.push(new Columna("Modalidad", { generar: function (un_alumno) { return un_alumno.Modalidad.Descripcion; } }));
        //columnas.push(new Columna("Pertenece A", { generar: function (un_alumno) { return un_alumno.area.descripcion; } }));

        planillaAlumnosDisponibles = new Grilla(columnas);
        planillaAlumnosAsignados = new Grilla(columnas);

        planillaAlumnosDisponibles.CargarObjetos(alumnos);
        planillaAlumnosDisponibles.DibujarEn(contenedorAlumnosDisponibles);

        planillaAlumnosDisponibles.SetOnRowClickEventHandler(function (un_alumno) {
            alumnoGlobal = un_alumno;
        });

        planillaAlumnosAsignados.SetOnRowClickEventHandler(function (un_alumno) {
            alumnoGlobal = un_alumno;
        });

        var completarCombosDeCiclo = function () {
            //idCicloSeleccionado.val("");

//            for (var i = 0; i < 4; i++) {
//                //var curso = cursosJSON[i];
//                var ciclo;
//                var listItem = $('<option>');
//                // alert(JSON.stringify(curso));
//                listItem.val(i);
//                listItem.text(i);
//                cmbCiclo.append(listItem);
//            }

            cmbCiclo.change(function (e) {
                var cicloSeleccionado = cmbCiclo.find('option:selected').val();
                if (cicloSeleccionado == -1) {
                    cmbCursos.empty();
                    for (var i = 0; i < cursosJSON.length; i++) {
                        var curso = cursosJSON[i];
                        var listItem = $('<option>');
                        // alert(JSON.stringify(curso));
                        listItem.val(curso.Id);
                        listItem.text(curso.Nombre);
                        cmbCursos.append(listItem);
                    }
                    return;
                }

                var queryResult = Enumerable.From(cursosJSON)
                .Where(function (x) { return x.Materia.Ciclo.Id == cicloSeleccionado }).ToArray();

                cmbCursos.empty();

                for (var i = 0; i < queryResult.length; i++) {
                    var curso = queryResult[i];
                    var listItem = $('<option>');
                    // alert(JSON.stringify(curso));
                    listItem.val(curso.Id);
                    listItem.text(curso.Nombre);
                    cmbCursos.append(listItem);
                }

                cmbCursos.change();
            });
        }

        var completarcombosDeCursos = function () {
            idCursoSeleccionado.val("");

            for (var i = 0; i < cursosJSON.length; i++) {
                var curso = cursosJSON[i];
                var listItem = $('<option>');
                // alert(JSON.stringify(curso));
                listItem.val(curso.Id);
                listItem.text(curso.Nombre);
                cmbCursos.append(listItem);
            }

            cmbCursos.change(function (e) {
                var idSeleccionado = cmbCursos.find('option:selected').val();
                idCursoSeleccionado.val(idSeleccionado);

                var cursoSeleccionado;
                for (var i = 0; i < cursosJSON.length; i++) {
                    var curso = cursosJSON[i];
                    if (curso.Id == idSeleccionado) cursoSeleccionado = curso;
                }
                if (cursoSeleccionado !== undefined) {

                    var queryResult = Enumerable.From(alumnos)
                                      .Where(function (x) { return x.Modalidad.Id == cursoSeleccionado.Materia.Modalidad.Id }).ToArray();

                    planillaAlumnosAsignados.BorrarContenido();
                    planillaAlumnosAsignados.CargarObjetos(cursoSeleccionado.Alumnos);
                    planillaAlumnosAsignados.DibujarEn(contenedorAlumnosAsignados);
                    $("#alumnosEnGrillaParaGuardar").val(JSON.stringify(planillaAlumnosAsignados.Objetos));
                    //$("#descripcionCursoSeleccionado").text(cursoSeleccionado.nombre);
                    $("#mensaje").text("");
                    $("#nombreDeCurso").text(cursoSeleccionado.Nombre);
                    MostrarAlumnosQueNoEstanEnElCursoSeleccionado(cursoSeleccionado, queryResult);

                }
                else {

                }
            });
        }

        completarcombosDeCursos();
        completarCombosDeCiclo();

        function MostrarAlumnosQueNoEstanEnElCursoSeleccionado(cursoSeleccionado, query_alumnos_modalidad) {
            planillaAlumnosDisponibles.BorrarContenido();
            planillaAlumnosDisponibles.CargarObjetos(query_alumnos_modalidad);
            var alumnos_filtrados_curso = planillaAlumnosDisponibles.QuitarObjetosExistentes(cursoSeleccionado.Alumnos);
            planillaAlumnosDisponibles.BorrarContenido();
            planillaAlumnosDisponibles.CargarObjetos(alumnos_filtrados_curso);
        }
    };

    $(document).ready(function () {
        AdministradorPlanilla();
    });


    function AsignarAlumno() {
        if (!planillaAlumnosAsignados.ContieneElemento(alumnoGlobal)) {
            planillaAlumnosDisponibles.QuitarObjeto(contenedorAlumnosDisponibles, alumnoGlobal);
            planillaAlumnosAsignados.CargarObjeto(alumnoGlobal);
            planillaAlumnosAsignados.DibujarEn(contenedorAlumnosAsignados);
            alumnoGlobal = null;
            $("#alumnosEnGrillaParaGuardar").val(JSON.stringify(planillaAlumnosAsignados.Objetos));
            $("#mensaje").text("Agregado al Curso");
        }
        else {
            $("#mensaje").text("Existe en el Curso");
        }
    }

    function DesasignarAlumno() {
        if (!planillaAlumnosDisponibles.ContieneElemento(alumnoGlobal)) {
            planillaAlumnosAsignados.QuitarObjeto(contenedorAlumnosAsignados, alumnoGlobal);
            planillaAlumnosDisponibles.CargarObjeto(alumnoGlobal);
            planillaAlumnosDisponibles.DibujarEn(contenedorAlumnosDisponibles);
            alumnoGlobal = null;
            $("#alumnosEnGrillaParaGuardar").val(JSON.stringify(planillaAlumnosAsignados.Objetos));
            $("#mensaje").text("Quitado del Curso");
        }
        else {
            $("#mensaje").text("Existe en el Curso");
        }
    }


</script>
</html>
