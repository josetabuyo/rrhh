<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Permisos.aspx.cs" Inherits="MAU_Permisos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RRHH - Permisos de usuario</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <%= Referencias.Css("../")%>
    <link rel="stylesheet" href="Permisos.css" type="text/css"/>    
    <link href="ui.dynatree.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="selector_usuario">
                <input id="txt_buscador" type=text nullvalue="dni"/>
                <input id="btn_buscar_usuario" type=button value="buscar" class="btn btn-primary"/>
            </div>
            <div id="vista_permisos">
            </div>
        </div>
    </form>
</body>
<%= Referencias.Javascript("../")%>
<script type="text/javascript" src="SelectorDeUsuarios.js"></script>
<script type="text/javascript" src="VistaDePermisosDeUnUsuario.js"></script>
<script type="text/javascript" src="ServicioDeSeguridad.js"></script>
<script type="text/javascript" src="NodoEnArbolDeFuncionalidades.js"></script>
<script type="text/javascript" src="../Scripts/ProveedorAjax.js"></script>

<script type="text/javascript" src="jquery.dynatree.min.js" ></script>


<script type="text/javascript">
    $(document).ready(function () {
        selector_usuarios = new SelectorDeUsuarios({ ui: $('#selector_usuario') });
        vista_permisos = new VistaDePermisosDeUnUsuario({
            ui: $('#vista_permisos'),
            servicioDeSeguridad: new ServicioDeSeguridad(new ProveedorAjax())
        });
        selector_usuarios.alSeleccionarUnUsuario = function (el_usuario_seleccionado) {
            vista_permisos.setUsuario(el_usuario_seleccionado);
        };
    });
</script>
</html>
