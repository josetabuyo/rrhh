<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="MAU_Usuarios" %>

<%@ Register src="~/BarraMenu/BarraMenu.ascx" tagname="BarraMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="link1" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />
    <link id="link2" rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css" type="text/css" runat="server" />
    <title>RRHH - Administraci&oacute;n de Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:BarraMenu ID="BarraMenu1" runat="server" Feature="<span style='font-size:20px; font-weight: bold;'>M.A.U.</span> <br/> Módulo de Administración <br/> de Usuarios" UrlImagenes="../Imagenes/" UrlEstilos="../Estilos/" />
    </div>
        <br />
            <button type="button" class="btn btn-large btn-block btn-primary">Alta de Usuario</button><br /><br />
            <button type="button" class="btn btn-large btn-block">Permisos de Usuarios</button>
    </form>
</body>
</html>
