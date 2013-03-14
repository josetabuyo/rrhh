<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FReportePorAreaYProvincia.aspx.cs" Inherits="FormularioReportes_FReportesViaticos" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.0.30930.28736, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Src="~/BarraMenu/BarraMenu.ascx" TagName="BarraMenu" TagPrefix="uc8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes de Viaticos</title>
    <link rel="stylesheet" type="text/css" href="../Scripts/jquery-ui-1.8.12.custom.css" />
    <link rel="stylesheet" type="text/css" href="../Scripts/jquery.checkboxtree.css" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server" />
         <uc8:BarraMenu ID="BarraMenu" runat="server" />   
        <asp:Label ID="Label1" runat="server" Text="Reporte por Area y Provincia"></asp:Label>
    <div>
    <asp:BulletedList ID="BulletedList1" runat="server"></asp:BulletedList>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <ul id="tree1">
        <li><input type="checkbox"><label>Node 1</label>
            <ul>
                <li><input type="checkbox"><label>Node 1.1</label>
                    <ul>
                        <li><input type="checkbox"><label>Node 1.1.1</label>
                    </ul>
            </ul>
            <ul>
                <li><input type="checkbox"><label>Node 1.2</label>
                    <ul>
                        <li><input type="checkbox"><label>Node 1.2.1</label>
                        <li><input type="checkbox"><label>Node 1.2.2</label>
                        <li><input type="checkbox"><label>Node 1.2.3</label>
                            <ul>
                                <li><input type="checkbox"><label>Node 1.2.3.1</label>
                                <li><input type="checkbox"><label>Node 1.2.3.2</label>
                            </ul>
                        <li><input type="checkbox"><label>Node 1.2.4</label>
                        <li><input type="checkbox"><label>Node 1.2.5</label>
                        <li><input type="checkbox"><label>Node 1.2.6</label>
                    </ul>
            </ul>
        <li><input type="checkbox"><label>Node 2</label>
            <ul>
                <li><input type="checkbox"><label>Node 2.1</label>
                    <ul>
                        <li><input type="checkbox"><label>Node 2.1.1</label>
                    </ul>
                <li><input type="checkbox"><label>Node 2.2</label>
                    <ul>
                        <li><input type="checkbox"><label>Node 2.2.1</label>
                        <li><input type="checkbox"><label>Node 2.2.2</label>
                        <li><input type="checkbox"><label>Node 2.2.3</label>
                            <ul>
                                <li><input type="checkbox"><label>Node 2.2.3.1</label>
                                <li><input type="checkbox"><label>Node 2.2.3.2</label>
                            </ul>
                        <li><input type="checkbox"><label>Node 2.2.4</label>
                        <li><input type="checkbox"><label>Node 2.2.5</label>
                        <li><input type="checkbox"><label>Node 2.2.6</label>
                    </ul>
            </ul>
    </ul>



        <asp:RadioButton ID="RadioButton1" runat="server" 
            Text="Direccion De Diseño y Desarrollo Organizacional para la Gestion de Personas" />
        <asp:TextBox ID="TBFechaDesde" runat="server" CssClass="input-small" name = "TBFechaDesde" MaxLength="10" />
        <cc1:CalendarExtender ID="TextBox1_CalendarExtender" Format="dd/MM/yyyy" runat="server" 
                TargetControlID="TBFechaDesde" />
         <asp:TextBox ID="TBFechaHasta"  runat="server" CssClass="input-small" MaxLength="10" />
           <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="TBFechaHasta" />
        
        <asp:ListBox ID="DDLProvincias" Width="150px" runat="server" 
            SelectionMode="Multiple"></asp:ListBox>
        <asp:Button ID="btn_buscar" runat="server" onclick="Button1_Click" Text="Button" />
        <asp:Table ID="TablaResultado" runat="server">
        </asp:Table>
        
    </div>
    </form>
</body>

    <script type="text/javascript" src="../Scripts/jquery-1.4.4.js"> </script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.12.custom.min.js"></script>

    <script type="text/javascript" src="../Scripts/jquery.checkboxtree.js"></script>

    <script type="text/javascript" >
        $('#tree1').checkboxTree();
    </script>
</html>
