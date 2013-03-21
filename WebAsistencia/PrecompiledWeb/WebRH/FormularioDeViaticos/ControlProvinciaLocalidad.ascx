<%@ control language="C#" autoeventwireup="true" inherits="ControlProvinciaLocalidad, App_Web_e4vz2srb" %>

<style type="text/css">
    .style1
    {
        width: 4px;
    }
</style>


<table style="width: 120px">
        
<%--        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Pcia."></asp:Label></td>
            <td style="width: 70px">
           
                        <asp:DropDownList ID="DDLProvincias" runat="server" Width="120px" 
                            OnSelectedIndexChanged="DDLProvincias_SelectedIndexChanged" 
                            AutoPostBack="True"  >
                        </asp:DropDownList>
               
            </td>
        </tr>--%>
        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Loc."></asp:Label></td>
            <td style="width: 70px">
                <asp:DropDownList ID="DDLLocalidades" runat="server" Width="120px">
                </asp:DropDownList>              
            </td>
        
       
        
        </tr>
       
</table>
