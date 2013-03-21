<%@ page language="C#" autoeventwireup="true" inherits="Planillas, App_Web_py4bpz5b" %>

<%@ Register Src="ControlPlanillaDeFirma.ascx" TagName="ControlPlanillaDeFirma" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema RRHH - Planilla de Firmas</title>
    <style type="text/css">
        .style1
        {
            width: 305px;
        }
        #form1
        {
            width: 423px;
            height: 255px;
            margin-bottom: 5px;
        }
        
        .salto_de_pagina 
        {
            page-break-after:always;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div  style="text-align:center;width:86%; margin-right: 0px;">
            <asp:Panel runat="server" ID="Panel">
            </asp:Panel>
         </div>
                               
<%--        <table style="text-align:center;width:86%; margin-right: 0px;">
            <tr>
                <td class="style1">
                    <div style="width: 372px">
                        <asp:Table ID="Table1" runat="server">
                        </asp:Table>
                    </div>
                </td>
            </tr>
        </table>--%>
                    <uc1:ControlPlanillaDeFirma ID="ControlPlanillaDeFirma1" 
            runat="server" Visible="True" />
    </form>
</body>
</html>
