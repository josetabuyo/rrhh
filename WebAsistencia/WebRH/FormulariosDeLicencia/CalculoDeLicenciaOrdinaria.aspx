    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalculoDeLicenciaOrdinaria.aspx.cs"
    Inherits="FormulariosDeLicencia_CalculoDeLicenciaOrdinaria" %>

    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><title></title><style type="text/css">
        * 
        {
            box-sizing: border-box;
        }
        table 
        {
            border-spacing: 0;
            border-collapse: collapse;
            background-color: transparent;
            border-color: grey;
        }
        
        table th 
        {
            background-color: #f5f5f5;
        }
        
        th 
        {
            text-align: left;
            font-weight: bold;
        }
        
        table th, table td 
        {
            padding: 5px 15px;
            //border: 1px solid #dddddd;
        }
        body 
        {
            color: #333;
            font-size: 16px;
            line-height: 1.5em;
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif !important;
        }
        table td {

            //padding:0px;
            //border:0px;
        }
        
        .usufructo-a 
        {
            background-color: #C4FFDF;
        }
        
        .usufructo-b 
        {
            background-color: #C4DFFF;
        }
        
        .autorizacion-a 
        {
            background-color: #C4C4C4;
        }
        
        .autorizacion-b 
        {
        }
        
        .perdidas 
        {
            background-color: #FFAFA0;
        }
        
        .vencidas
        {
            background-color: #88FF00;
        }

    </style>
    <script type="text/javascript" src="Scripts/bootstrap/js/jquery.js"> </script>
    </head>
    
    
    <body><form id="form1" runat="server">
    <div>
 
        <asp:TextBox ID="textbox_dni" runat="server"></asp:TextBox>
 
 <asp:Button runat="server" Text="Buscar" />
      <asp:Table ID="tabla_analsis" runat="server">
     
        </asp:Table>
        <%--<table>
            <tr><td style="background-color:#FFAFA0; min-width:50px;"></td><td>Perdidas</td></tr>
            <tr><td style="background-color:#88FF00; min-width:50px;"></td><td>Vencidas</td></tr>
        </table>
    <div>
        <table>
            <tr>
                <td colspan="2">
                    Autorizados
                </td>
                <td colspan="3">
                    Usufructuados
                </td>
            </tr>
            <tr>
                <td>
                    Periodo
                </td>
                <td>
                    Dias Autorizados
                </td>
                <td>
                    Dias Descontados
                </td>
                <td>
                    Desde
                </td>
                <td>
                    Hasta
                </td>
            </tr>
            <tr>
                <td class="autorizacion-a">
                    2002
                </td>
                <td class="autorizacion-a">
                    35
                </td>
                <td class="usufructo-a">
                    15
                </td>
                <td class="usufructo-a">
                    10/10/2003
                </td>
                <td class="usufructo-a">
                    25/10/2003
                </td>
            </tr>
            <tr>
                <td class="autorizacion-a">
                </td>
                <td class="autorizacion-a">
                </td>
                <td class="usufructo-b">
                    20
                </td>
                <td class="usufructo-b">
                    05/01/2004
                </td>
                <td class="usufructo-b">
                    25/01/2004
                </td>
            </tr>
            <tr>
                <td class="autorizacion-b">
                    2003
                </td>
                <td class="autorizacion-b">
                    35
                </td>
                <td class="usufructo-a">
                    15
                </td>
                <td class="usufructo-a">
                    10/10/2004
                </td>
                <td class="usufructo-a">
                    25/10/2004
                </td>
            </tr>
            <tr>
                <td class="autorizacion-b">
                </td>
                <td class="autorizacion-b">
                </td>
                <td class="usufructo-b">
                    15
                </td>
                <td class="usufructo-b">
                    05/01/2005
                </td>
                <td class="usufructo-b">
                    30/01/2005
                </td>
            </tr>
            <tr>
                <td style="background-color: #C4C4C4">
                    2004
                </td>
                <td style="background-color: #C4C4C4">
                    35
                </td>
                <td class="usufructo-b">
                    5
                </td>
                <td class="usufructo-b">
                </td>
                <td class="usufructo-b">
                </td>
            </tr>
            <tr>
                <td  class="autorizacion-a">
                </td>
                <td  class="autorizacion-a">
                </td>
                <td  class="usufructo-a">
                    24
                </td>
                <td  class="usufructo-a">
                    08/01/2005
                </td>
                <td  class="usufructo-a">
                    01/02/2005
                </td>
            </tr>
            <tr>
                <td  class="autorizacion-a">
                </td>
                <td  class="autorizacion-a">
                </td>
                <td  class="perdidas">
                    6
                </td>
                <td  class="perdidas">
                    *
                </td>
                <td  class="perdidas">
                    *
                </td>
            </tr>


            <tr>
                <td class="autorizacion-b">2005
                </td>
                <td class="autorizacion-b">35
                </td>
                <td class="usufructo-b">
                    15
                </td>
                <td class="usufructo-b">
                    05/01/2005
                </td>
                <td class="usufructo-b">
                    30/01/2005
                </td>
            </tr>
        </table>
    </div>--%>
      
    </form>
</body>
</html>
