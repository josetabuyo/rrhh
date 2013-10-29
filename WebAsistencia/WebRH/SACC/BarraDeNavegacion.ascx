<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BarraDeNavegacion.ascx.cs" Inherits="SACC_BarraDeNavegacion" %>

<div class="navbar">
              <div class="navbar-inner">
                <div class="container">
                  <a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </a>
                  <a class="brand" href="#">MACC</a>
                  <div class="nav-collapse navbar-responsive-collapse">
                    <ul class="nav">
                      <li><a href="FormAsignarAlumnos.aspx">Inscripcion</a></li>
                      <li><a href="FormPlanillaAsistenciaAlumnos.aspx">Planilla de Asistencia</a></li>
                      <li class="dropdown" id="menu_evaluaciones" runat="server">
                          <a href="#" class="dropdown-toggle" data-toggle="dropdown">Evaluaciones</a>
                          <ul id="sub_menu_evaluaciones" class="dropdown-menu" runat="server">
                            <li><a href="FormPlanillaDeEvaluaciones.aspx?accion=c">Carga de Notas</a></li>
                            <li><a href="FormPlanillaDeEvaluaciones.aspx?accion=a">Bolet&iacute;n</a></li>
                          </ul>
                      </li>
                    </ul>
                    <ul class="nav pull-right">
<<<<<<< HEAD
                        <li class="dropdown" id="Li1" runat="server">
                              <a href="#" class="dropdown-toggle" data-toggle="dropdown">Reportes</a>
                              <ul id="Ul1" class="dropdown-menu" runat="server">
                                <li><a href="FormPlanillaDeReportesAlumnos.aspx">Listados de Alumnos</a></li>
                                <%--<li><a href="FormPlanillaDeReportesMaterias.aspx">Listados de Materias</a></li>--%>
                              </ul>
                          </li>

=======
                       <li><a href="FormPlanillaObservaciones.aspx">Observaciones</a></li>
>>>>>>> 3d0909cc8c0b3d6a9e09a38c4e8693864ede844c
                       <li class="dropdown" id="menu_parametria" runat="server">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Parametr&iacute;a <b class="caret"></b></a>
                        <ul id="sub_menu_parametria" class="dropdown-menu" runat="server">
                          <!--<li><a href="FormABMEspaciosFisicos.aspx">Espacios Físicos</a></li>
                          <li id="el_menu_materias" runat="server"><a href="FormABMMaterias.aspx">Materias</a></li>
                          <li><a href="FormABMDocentes.aspx">Docentes</a></li>
                          <li><a href="FormABMCursos.aspx">Cursos</a></li>
                          <asp:Table ID="ItemsDelMenu" runat="server" />-->
                        </ul>
                      </li>
                      <li class="divider-vertical"></li>                 
                      <li><input type="text" class="search-query span2" placeholder="Busqueda rapida" /></li>                       
                    </ul>
                  </div><!-- /.nav-collapse -->
                </div>
              </div><!-- /navbar-inner -->
            </div><!-- /navbar -->