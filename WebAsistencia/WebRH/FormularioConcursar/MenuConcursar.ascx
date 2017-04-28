<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuConcursar.ascx.cs" Inherits="FormularioConcursar_MenuConcursar" %>

<style type="text/css">
.nav-collapse .nav > li > a:hover, .nav-collapse .dropdown-menu a:hover {
background-color:#0088cc !important;

}

.nav-collapse .nav > li > a:active, .nav-collapse .dropdown-menu a:active {
background-color:#0088cc !important;

}

.navbar .nav > li > a:hover {
color:#fff !important;

}

.navbar .nav .active > a 
{
    color:#fff !important;
    background-color:#0088cc !important;
}

.navbar .nav 
{
    float:none;
}
            
.navbar-inner 
{
    padding:0px !important;
}



</style>

<div class="navbar" style="font-size: 15px; z-index:0">

            <div class="navbar-inner" >
                <div class="container">
                    <a class="btn btn-navbar" data-toggle="collapse" style="background-color:#4FB7ED;"  data-target=".navbar-responsive-collapse">
                        <span class="sr-only" style="color:#fff;">Click para desplegar</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </a>
                    <a class="brand" href="#"></a>
                    <div class="nav-collapse navbar-responsive-collapse">
                   
                    <ul id="MenuNavegacion" class="nav"  runat="server">
                        <li id="tab_panel" ><a href="PanelDeControl.aspx"  >Inicio</a></li>
                        <li id="tab_cv"><a href="CargaInformacionPersonal.aspx" >Cargar/Editar Mi Currículum</a></li>
                        <li id="tab_cargos"><a href="Postulaciones.aspx" >Postularme/Cargos Disponibles</a></li>
                        <li id="tab_info"><a href="Informacion.aspx" >Más Información</a></li>
                        <li id="tab_adm" RequiereFuncionalidad="15" style="cursor:pointer;" class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" runat="server">Administración</a>
                            <ul id="subMenu_administracion" runat="server" class="dropdown-menu">
                                <li RequiereFuncionalidad="14" class="dropdown"><a  href="EtapasPostulacion.aspx" runat="server">Cambiar Etapas de Postulaciones</a></li>
                                <li RequiereFuncionalidad="15" class="dropdown"><a  href="EtapaPreInscripcionDocumental.aspx"  runat="server">Inscripción documental (operador)</a></li>
                                <li RequiereFuncionalidad="16" class="dropdown"><a  href="EtapaInscripcionDocumental.aspx"  runat="server">Inscripción documental (comité)</a></li>
                                <li RequiereFuncionalidad="17" class="dropdown"><a  href="EtapaAdmision.aspx" runat="server">Etapa de Admisión</a></li>
                                <li RequiereFuncionalidad="20" class="dropdown"><a  href="InscripcionManual.aspx" runat="server">Inscripción Manual</a></li>
                                <li RequiereFuncionalidad="19" class="dropdown"><a  href="TableroControl.aspx" runat="server">Tablero de Control</a></li>
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
