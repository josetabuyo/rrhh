<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PanelDeControl.aspx.cs" Inherits="FormularioConcursar_PanelDeControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%= Referencias.Css("../")%>    

     <script type="text/javascript" src="../Scripts/bootstrap/js/jquery.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    <div class="navbar">
    <div class="navbar-inner">
    <div class="container">
        <a class="btn btn-navbar" data-toggle="collapse" data-target=".navbar-responsive-collapse">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        </a>
        <a class="brand" href="#">Postular</a>
        <div class="nav-collapse navbar-responsive-collapse">
        <ul class="nav"  runat="server">
        <li><a href="#" >Postulaciones</a></li>
        <li><a href="#" >Notificaciones</a></li>
        <li><a href="#" >Mis Postulaciones</a></li>
        <li><a href="Pantalla1.aspx" >MI CV</a></li>
        </ul>
        <ul class="nav pull-right" runat="server">
            <li class="divider-vertical"></li>                                  
        </ul>
        <ul class="nav pull-right"  runat="server">
        </ul>
        </div><!-- /.nav-collapse -->
    </div>
    </div><!-- /navbar-inner -->
</div><!-- /navbar -->
    </div>
    </form>
</body>
 <%= Referencias.Javascript("../") %>

</html>
