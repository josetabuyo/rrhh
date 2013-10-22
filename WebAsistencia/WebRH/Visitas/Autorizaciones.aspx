<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Visitas.master" AutoEventWireup="true"
    CodeFile="Autorizaciones.aspx.cs" Inherits="Visitas_Autorizaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
    <script src="JScript/val.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <div style="text-align: center;" class="caja caja-sombra sombra1 sombra2">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3" class="TituloPagina" >
                        Ingresar nueva autorización
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="tdDesControl">
                                Funcionario:
                            </td>
                            <td style="text-align: left;">
                                <div class="inputs">
                                    <asp:DropDownList ID="DropDownList_Funcionarios" runat="server" Width="100%" 
                                        AutoPostBack="True" 
                                        onselectedindexchanged="DropDownList_Funcionarios_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td style="width: 20px;">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl">
                                Documento:
                            </td>
                            <td style="text-align: left;">
                                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                                    <tr>
                                        <td>
                                            <div class="inputs">
                                                <asp:TextBox ID="txtDoc" runat="server" Width="290px" MaxLength="8"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td style="vertical-align: top;">
                                            <asp:ImageButton ID="ImageButton_BusDoc" runat="server" ImageUrl="~/Visitas/Imagenes/search-24x24.png"
                                                Width="26px" Height="26px" CssClass="submit" CausesValidation="False" 
                                                onclick="ImageButton_BusDoc_Click" />
                                            <asp:ImageButton ID="ImageButton_DelDoc" runat="server" ImageUrl="~/Visitas/Imagenes/xion-24x24.png"
                                                Width="26px" Height="26px" CssClass="submit" CausesValidation="False" 
                                                onclick="ImageButton_DelDoc_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Doc" runat="server"
                                    ControlToValidate="txtDoc" ErrorMessage="El campo documento debe ser una expresión numérica."
                                    Font-Bold="True" Font-Size="X-Large" ValidationExpression="\d{1,9}">*</asp:RegularExpressionValidator>
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
                                                <asp:TextBox ID="txtApellido" runat="server" Width="290px" MaxLength="32"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td style="vertical-align: top;">
                                            <asp:ImageButton ID="ImageButton_BusApe" runat="server" ImageUrl="~/Visitas/Imagenes/search-24x24.png"
                                                Width="26px" Height="26px" CssClass="submit" CausesValidation="False" 
                                                onclick="ImageButton_BusApe_Click" />
                                            <asp:ImageButton ID="ImageButton_DelApe" runat="server" ImageUrl="~/Visitas/Imagenes/xion-24x24.png"
                                                Width="26px" Height="26px" CssClass="submit" CausesValidation="False" 
                                                onclick="ImageButton_DelApe_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Nombre0" runat="server" ControlToValidate="txtApellido"
                                    ErrorMessage="El campo apellido es obligatorio." Font-Bold="True" Font-Size="X-Large">*</asp:RequiredFieldValidator>
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
                                                <asp:TextBox ID="txtNombre" runat="server" Width="290px" MaxLength="32"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td style="vertical-align: top;">
                                            <asp:ImageButton ID="ImageButton_BusNom" runat="server" ImageUrl="~/Visitas/Imagenes/search-24x24.png"
                                                Width="26px" Height="26px" CssClass="submit" CausesValidation="False" 
                                                onclick="ImageButton_BusNom_Click" />
                                            <asp:ImageButton ID="ImageButton_DelNom" runat="server" ImageUrl="~/Visitas/Imagenes/xion-24x24.png"
                                                Width="26px" Height="26px" CssClass="submit" CausesValidation="False" 
                                                onclick="ImageButton_DelNom_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Nombre" runat="server" Font-Bold="True"
                                    Font-Size="X-Large" ErrorMessage="El campo nombre es obligatorio." ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl">
                                Telefono:
                            </td>
                            <td style="text-align: left;">
                                <div class="inputs">
                                    <asp:TextBox ID="txtTelefono" runat="server" MaxLength="12"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Tel" runat="server"
                                    ErrorMessage="El campo telefono debe ser una expresión numérica." ControlToValidate="txtTelefono"
                                    Font-Bold="True" Font-Size="X-Large" ValidationExpression="\d{1,12}">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl">
                                Motivo:
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="DropDownListMotivo" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl">
                                Lugar:
                            </td>
                            <td style="text-align: left;">
                                <div class="inputs">
                                    <asp:TextBox ID="txtLugar" runat="server" Width="98%" MaxLength="64"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl">
                                Representa a:
                            </td>
                            <td style="text-align: left;">
                                <div class="inputs">
                                    <asp:TextBox ID="txtRepresenta" runat="server" Width="98%" MaxLength="64"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl">
                                Acompañantes:
                            </td>
                            <td style="text-align: left;">
                                <div class="inputs">
                                    <asp:TextBox ID="txtAcomp" runat="server" MaxLength="2" ></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator_Acomp" runat="server"
                                    ControlToValidate="txtAcomp" ErrorMessage="El campo acompañantes debe ser una expresión numérica."
                                    Font-Bold="True" Font-Size="X-Large" ValidationExpression="\d{1,2}">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <div style="padding-left: 90px; text-align: left;">
                                    <asp:ValidationSummary ID="ValidationSummary_AgrAut" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdDesControl">
                                <asp:HiddenField ID="HiddenField_IdPersona" runat="server" />
                            </td>
                            <td style="text-align: left; padding: 10px 0 5px;">
                                <asp:Button ID="Button_Agregar" runat="server" Text="Agregar Autorización" CssClass="btn btn-primary"
                                    Width="220px" onclick="Button_Agregar_Click" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align: top; padding-right: 10px">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="vertical-align: top; text-align: center; width: 300px;">
                                <strong>Seleccionar días:</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Calendar ID="Calendar_SelDias" runat="server" BackColor="White" BorderColor="#999999"
                                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="Black" Height="180px" Width="100%" 
                                    OnSelectionChanged="Calendar_SelDias_SelectionChanged" 
                                    ondayrender="Calendar_SelDias_DayRender">
                                    <DayHeaderStyle BackColor="#D0DDF8" Font-Bold="True" Font-Size="7pt" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#FFFFFF" Font-Bold="True" ForeColor="Black" />
                                    <TitleStyle BackColor="#799EEC" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#F8F9FA" />
                                </asp:Calendar>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; padding: 5px;">
                                <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Red" ></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="vertical-align: top;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="vertical-align: top; text-align: center; width: 300px;">
                                <strong>Días autorizados:</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListBox ID="ListBox_DiasSeleccionados" runat="server" Width="100%" 
                                    Height="210px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; padding: 5px 0 15px 0; ">
                                <asp:Label ID="lblContadorDias" runat="server" Text="" ForeColor="Blue" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:Button ID="Button_QuitarDiaSel" runat="server" 
                                    Text="Quitar Día Autorizado" CssClass="btn btn-primary" 
                                    CausesValidation="False" onclick="Button_QuitarDiaSel_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="divPersonas" runat="server" style="background-image:url('Imagenes/fondoBusq.png'); bottom: 0px; top: 0px; left: 0; text-align: center;">
        <div id="divGridViewPersonas" runat="server">
            <asp:GridView ID="GridView_Personas" runat="server" BackColor="White" 
                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                EnableModelValidation="True" ForeColor="Black" GridLines="None"
                onrowdatabound="GridView_Personas_RowDataBound"
                onselectedindexchanged="GridView_Personas_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ItemStyle-Font-Bold ="true" />
                </Columns>
                <EmptyDataTemplate>
                    <strong>.: No se encontraron personas para la búsqueda efectuada :.</strong>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#EFF5FB" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
            <br />
            <asp:Button ID="Button_CancelarBusqueda" runat="server" 
                Text="Cancelar" CssClass="btn btn-primary" 
                CausesValidation="False" onclick="Button_CancelarBusqueda_Click"/>        
        </div>
    </div>
</asp:Content>
