<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Reportes_Reportes" %>

<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" type="text/css" href="Reportes.css" />
    <link rel="stylesheet" type="text/css" href="../Scripts/ArbolOrganigrama/ArbolOrganigrama.css" />
    <link rel="stylesheet" type="text/css" href="../Estilos/component.css" />
    <%= Referencias.Javascript("../")%>
    <script type="text/javascript" src="../Scripts/underscore-min.js"></script>
    <script type="text/javascript" src="Reportes.js"></script>
    <script type="text/javascript" src="../Scripts/ArbolOrganigrama/ArbolOrganigrama.js"></script>
    <script src="../Scripts/Graficos/classie.js" type="text/javascript"></script>
</head>
<body>
    <form id="Reportes" runat="server">
    <uc2:BarraMenu ID="BarraMenu" UrlPassword="../" runat="server" Feature="<span style='font-size:20px; font-weight: bold; padding-top:20px;'>Reportes</span> <br/> "
        UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
   
    <!--<h1 style="text-align: center; font-weight:200;">Reportes</h1>-->
    <input id="btn_consulta_rapida" style="display:block; float:right; margin-right:20px" type="button" class="btn btn-primary" RequiereFuncionalidad="32" value="Consulta Individual" />
    <div>
        <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-left" style="position:relative; top:0;" id="cbp-spmenu-s1" >
            <div id="contenedor_arbol_organigrama">
                <h2 class="titulo_organigrama">Organigrama</h2>
            </div>
             <input type="button" class="btn_organigrama" id="showLeftPush" value="Organigrama" />
             <div id="panel_derecho">
                <h2>Área Seleccionada: <span id="titulo_area"></span></h2>
                <h2>Gráfico Seleccionado: <span id="titulo_grafico"></span> </h2>
                <input id="btn_grafico_dotacion" style="display:none;" type="button" class="btn btn-primary" value="Gráfico Dotación" />
                <input id="btn_grafico_licencias" style="display:none;" type="button" class="btn btn-primary" value="Gráfico Licencias" />
             </div>
             
         </nav>

         <nav class="cbp-spmenu cbp-spmenu-vertical cbp-spmenu-right" style="position:relative; top:0;" id="cbp-spmenu-s2" >
            <div id="menu">
                <h2 id="">Gráficos</h2>
                <ul style="list-style: none;">
                    <li><a href="#">Dotación</a></li>
                    <li><a href="#">Licencias</a></li>
                    <li><a href="#">Rango Etáreo</a></li>
                    <li><a href="#">Horas Extras</a></li>
                    <li><a href="#">Otros</a></li>
                </ul>
            </div>
             <input type="button" class="btn_grafico" id="showRightPush" value="Gráficos" />
         </nav>
         
    </div>
    </form>
    <div id="plantillas">
        <div class="arbol_organigrama">
        </div>
        <div class="area_en_arbol">
            <div id="area">
                <div id="btn_expandir" class="btn_apertura">
                </div>
                <div id="btn_contraer" class="btn_apertura">
                </div>
                <div id="nombre_area">
                </div>
            </div>

            <div id="areas_dependientes">
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var menuLeft = document.getElementById('cbp-spmenu-s1'),
				menuRight = document.getElementById('cbp-spmenu-s2'),
				showLeftPush = document.getElementById('showLeftPush'),
				showRightPush = document.getElementById('showRightPush'),
				body = document.body;
       
        showLeftPush.onclick = function () {
            classie.toggle(this, 'active');
            classie.toggle(body, 'cbp-spmenu-push-toright');
            classie.toggle(menuLeft, 'cbp-spmenu-open');
            //disableOther('showLeftPush');
        };

        showRightPush.onclick = function () {
            classie.toggle(this, 'active');
            classie.toggle(body, 'cbp-spmenu-push-toleft');
            classie.toggle(menuRight, 'cbp-spmenu-open');

        };
        
			
		</script>
</body>
</html>
