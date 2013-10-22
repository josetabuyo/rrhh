<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Visitas.master" AutoEventWireup="true"
    CodeFile="Acreditaciones.aspx.cs" Inherits="Visitas_Acreditacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <asp:Panel runat="server" ID="Panel_Acreditacion" DefaultButton="Button_Buscar">
    <div style="text-align: center;" class="caja caja-sombra sombra1 sombra2" >
        <table border="0" cellpadding="0" cellspacing="0" width="90%">
            <tr>
                <td colspan="3" class="TituloPagina">
                        <asp:Label ID="lblTitulo" runat="server" Text="Acreditaciones"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdSubTitulo" style="width: 350px;">
                    <strong>Buscar autorizaciones para hoy:</strong>
                </td>
                <td class="tdSubTitulo">
                    <strong>Autorizaciones para hoy:</strong>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <table border="0" cellpadding="0" cellspacing="0" width="270px">
                        <tr>
                            <td class="tdDesControl">
                                Documento:
                            </td>
                            <td style="text-align: left;">
                                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                                    <tr>
                                        <td>
                                            <div class="inputs">
                                                <asp:TextBox ID="txtDoc" runat="server" Width="150px" MaxLength="8"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl">
                                Apellido:
                            </td>
                            <td style="text-align: left;">
                                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                                    <tr>
                                        <td>
                                            <div class="inputs">
                                                <asp:TextBox ID="txtApellido" runat="server" Width="150px" MaxLength="32"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl">
                                Nombre:
                            </td>
                            <td style="text-align: left;">
                                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                                    <tr>
                                        <td>
                                            <div class="inputs">
                                                <asp:TextBox ID="txtNombre" runat="server" Width="150px" MaxLength="32"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl" colspan="2" style="text-align: center; padding: 15px 0 0 0;">
                                <asp:Button ID="Button_Buscar" runat="server" Text="Buscar Autorización" CssClass="btn btn-primary"
                                    Width="220px" onclick="Button_Buscar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align: top;">
                    <asp:GridView ID="GridView_Personas" runat="server" BorderColor="#DEDFDE"
                        BorderStyle="None" BorderWidth="2px" CellPadding="4" EnableModelValidation="True"
                        ForeColor="Black" GridLines="None" Width="98%" 
                        onrowdatabound="GridView_Personas_RowDataBound" 
                        onselectedindexchanged="GridView_Personas_SelectedIndexChanged" >
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" >
                            <ControlStyle Font-Bold="True" />
                            </asp:CommandField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div class="divEmptyGrid">
                                <i>.: No se encontraron autorizaciones para hoy :.</i>
                            </div>
                        </EmptyDataTemplate>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#FBF2EF" />
                        <SelectedRowStyle Font-Bold="True" ForeColor="#0074CC" Font-Italic="true" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>    
    </asp:Panel>
    <div id="divAutorizacion" runat="server" 
        style="background-image:url('Imagenes/fondoBusq.png'); bottom: 0px; top: 0px; left: 0; text-align: center;">
        <div id="divGridViewAutorizaciones" runat="server">
            <asp:DetailsView ID="DetailsView_Autorizacion" runat="server" CellPadding="4" 
                EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                Height="50px" Caption="<div class='TituloPagina'> Autorización </div>" >
                <AlternatingRowStyle BackColor="White" />
                <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                <EditRowStyle BackColor="#2461BF" />
                <FieldHeaderStyle BackColor="#CCCCCC" ForeColor="White" Font-Bold="True" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF5FB" />
            </asp:DetailsView>
            <br />
            <asp:Button ID="Button_Acreditar" runat="server" 
                Text="Acreditar" CssClass="btn btn-primary"
                CausesValidation="False" onclick="Button_Aceptar_Click"/>

        &nbsp;
            <asp:Button ID="Button_Cancelar" runat="server" 
                Text="Cancelar" CssClass="btn btn-primary"
                CausesValidation="False" onclick="Button_Cancelar_Click"/>

        </div>
    </div>
</asp:Content>
