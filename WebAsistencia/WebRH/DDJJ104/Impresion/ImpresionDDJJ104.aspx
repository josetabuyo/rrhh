<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpresionDDJJ104.aspx.cs" Inherits="DDJJ104_Impresion_ImpresionDDJJ104" %>

<%--<%@ Register Src="~/DDJJ104/Impresion/PlanillaDDJJ104.ascx" TagName="PlanillaDDJJ104" TagPrefix="uc1" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">    
    <title>Impresión Declaración Jurada DDJJ104</title>
    <style>
        .SaltoDePagina
        {
            page-break-after: always;
        }
        .style1
        {
            font-family: "New Century Schoolbook";
        }
    </style>
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" style="margin:10px">
    <div>
        
        <img src="../../Imagenes/Escudo.JPG" width="40px" height="50px" alt="" />
        <br />
        <label>Ministerio de Desarrollo Social</label>

        <br />
        <br />

        <div>FORMULARIO DE DECLARACION JURADA</div>
        <div>CERTIFICACION DE SERVICIOS</div>
        <br />
        <div>DECISION ADMINISTRATIVA Nº 104/2001</div>
        <div>(Resolución SME 34/01)<br/></div>
        <br />
        <div>Por el presente, certifico con carácter de Declaración Jurada, en mi condición de titular de la COORDINACION DE LOS CENTROS DE REFERENCIA dependiente de la DIRECCION NACIONAL DE GESTION DE LOS CENTROS DE REFERENCIA -SUBSECRETARIA DE ORGANIZACION COMUITARIA, SECRETARIA DE ORGANIZACION Y COMUNICACION COMUNITARIA ubicada en 9 DE JULIO 1925, que las personas citadas en el listado adjuntos han cumplimentado la prestación de servicios correspondiente al mes de " + mes + " del año " + anio + " ,"del Personal que trabaja directa o indirectamente con los Centros de Referencia:-</div>

        <br />
            <div ID="PanelImpresion" runat="server" align="center" style="width: 100% ; height:100%">cualquier boludez</div>
        <br />
        <asp:Button ID="BtnImprimir" class="btn" runat="server" Text="Imprimir" />
    </div>
    </form>
</body>
</html>

