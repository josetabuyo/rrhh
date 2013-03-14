<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pases.aspx.cs" Inherits="FormulariosOtros_Pases" %>

<%@ Register src="ControlSeleccionDeArea.ascx" tagname="ControlSeleccionDeArea" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema RRHH - Buscador de áreas</title>
    <style type="text/css">
        .style1
        {
            width: 18px;
        }
        .style4
        {
            height: 16px;
        }
        .style5
        {
            width: 18px;
            height: 16px;
        }
    </style>
</head>
<body style="background-color:#8694A4;">
    <form id="form1" runat="server">
     
        <table style="width: 100%; text-align: center">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="width: 80%; background-color: #ffffff;
                        text-align: left">
                        <tr>
                            <td style="background-image: url('../Imagenes/bordeTabla2SupIzq.PNG'); width: 18px">
                                &nbsp;
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2Sup.PNG')">
                                &nbsp;
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2SupDer.PNG'); width: 21px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url('../Imagenes/bordeTabla2Izq.PNG'); width: 17px; height: 19px">
                            </td>
                            <td align="center" style="height: 19px">
                                    <uc1:ControlSeleccionDeArea ID="ControlSeleccionDeArea1" runat="server" />
                                <br />
                                <br />
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2Der.PNG'); width: 18px; height: 19px">
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url('../Imagenes/bordeTabla2Izq.PNG'); width: 5px">
                                &nbsp;
                            </td>
                            <td align="center">
                                <strong>&nbsp;<br />
                                </strong>
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2Der.PNG'); width: 18px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="font-size: 12pt; font-family: Times New Roman">
                            <td style="background-image: url('../Imagenes/bordeTabla2InfIzq.PNG')" 
                                class="style4">
                                &nbsp;
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2Inf.PNG')" 
                                class="style4">
                                &nbsp;
                            </td>
                            <td style="background-image: url('../Imagenes/bordeTabla2InfDer.PNG'); " 
                                class="style5">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
