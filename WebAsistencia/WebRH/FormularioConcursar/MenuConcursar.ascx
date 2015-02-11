<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuConcursar.ascx.cs" Inherits="FormularioConcursar_MenuConcursar" %>

<div class="navbar" style="font-size: 15px; ">
            <div class="navbar-inner" >
                <div class="container">
                    <a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-responsive-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </a>
                    <a class="brand" href="#"></a>
                    <div class="nav-collapse navbar-responsive-collapse">
                    <ul id="MenuNavegacion" class="nav"  runat="server">
                        <li><a href="PanelDeControl.aspx" >Panel de Control</a></li>
                        <li><a href="Informacion.aspx" >Información</a></li>
                        <li><a href="Postulaciones.aspx" >Cargos</a></li>
                        <li><a href="CargaInformacionPersonal.aspx" >MI CV</a></li>
                        <li RequiereFuncionalidad="14" style="cursor:pointer;" class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" runat="server">Administración</a>
                            <ul id="subMenu_administracion" runat="server" class="dropdown-menu">
                                <li RequiereFuncionalidad="14" class="dropdown"><a  href="EtapasPostulacion.aspx" runat="server">Cambiar Etapas de Postulaciones</a></li>
                                <li RequiereFuncionalidad="15" class="dropdown"><a  href="EtapaPreInscripcionDocumental.aspx"  runat="server">Preinscripción documental</a></li>
                                <li RequiereFuncionalidad="16" class="dropdown"><a  href="EtapaInscripcionDocumental.aspx"  runat="server">Inscripción documental</a></li>
                                <li RequiereFuncionalidad="17" class="dropdown"><a  href="EtapaAdmision.aspx" runat="server">Etapa de Admisión</a></li>
                            </ul>
                        
                        </li>
                    </ul>
       
                    <ul id="Ul2" class="nav pull-right"  runat="server">
                    </ul>
                    </div><!-- /.nav-collapse -->
                </div>
            </div><!-- /navbar-inner -->
        </div><!-- /navbar -->
        <script type="text/javascript" src="../MAU/HabilitadorDeControles.js"></script>
