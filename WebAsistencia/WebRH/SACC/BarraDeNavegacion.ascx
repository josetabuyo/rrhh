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
        <ul class="nav" id="menu_izquierdo" runat="server">
        </ul>
        <ul class="nav pull-right" id="Ul1" runat="server">
            <li class="divider-vertical"></li>                 
            <li><input type="text" class="search-query span2" placeholder="Busqueda rapida" /></li>                       
        </ul>
        <ul class="nav pull-right" id="menu_derecho" runat="server">                  
        </ul>
        </div><!-- /.nav-collapse -->
    </div>
    </div><!-- /navbar-inner -->
</div><!-- /navbar -->
<script type="text/javascript" src="Scripts/Menu.js"></script>