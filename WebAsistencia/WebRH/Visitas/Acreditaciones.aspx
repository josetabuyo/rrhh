<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Visitas.master" AutoEventWireup="true"
    CodeFile="Acreditaciones.aspx.cs" Inherits="Visitas_Acreditaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
    <link href="css/PrettyTableStyling.css" rel="stylesheet" type="text/css" />
    <link href="css/PrettyDialogStyling.css" rel="stylesheet" type="text/css" />
    <script src="JScript/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="JScript/jquery.quicksearch.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('input#<%=txtBuscar.ClientID%>').quicksearch('table#<%=GridView_Autorizaciones.ClientID%> tbody tr');
        });
        $(function () {
            /* For zebra striping */
            $("table tr:nth-child(odd)").addClass("odd-row");
            /* For cell text alignment */
            $("table td:first-child, table th:first-child").addClass("first");
            /* For removing the last border */
            $("table td:last-child, table th:last-child").addClass("last");
        });
    </script>
    <style type="text/css">
        #<%=txtBuscar.ClientID%>
        {            
            padding-left: 30px;
            padding-top: 8px;
            padding-bottom: 8px;    
            color:gray;
            background-image:url('Imagenes/search.png');
            background-repeat:no-repeat;
            background-position:left center;            
            width: 40%;
        }
        
        .btnPersona
        {
            margin-bottom: 10px;
        }

        .gvBusqPer
        {
            margin-bottom: 1%;
        }
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="Server">
    <asp:Panel runat="server" ID="Panel_Acred" DefaultButton="ImageButton_Refesh">
        <div style="text-align: center; width: 92%" class="caja caja-sombra sombra1 sombra2">
            <div class="TituloPagina">
                <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="txtSearch"></asp:TextBox>
                <script type="text/javascript">
                    document.getElementById('<%=txtBuscar.ClientID%>').focus();
                </script>
                &nbsp;<asp:ImageButton ID="ImageButton_Refesh" runat="server" 
                    CausesValidation="False" CssClass="btnPersona" Height="26px" 
                    ImageUrl="~/Visitas/Imagenes/refresh.png" 
                    Width="26px" onclick="ImageButton_Refesh_Click" />
            </div>
            <div>
                <asp:GridView ID="GridView_Autorizaciones" runat="server" EnableModelValidation="True"
                    OnPreRender="GridView_Autorizaciones_PreRender" DataKeyNames="Autorización" OnSelectedIndexChanged="GridView_Autorizaciones_SelectedIndexChanged"
                    Font-Size="X-Small" Width="98%" OnRowCommand="GridView_Autorizaciones_RowCommand">
                    <Columns>
                        <asp:CommandField SelectText="Acreditar" ShowSelectButton="True">
                            <ControlStyle ForeColor="#009933" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="divEmpyGridViewAutorizaciones" runat="server">
                <table border="0" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <td style="text-align: center">
                                <strong>No se encontraron autorizaciones para acreditar con fecha actual.</strong>
                            </td>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
        <div id="divAddPersona" runat="server" style="background-image: url('Imagenes/bgblack.png');
            bottom: 0px; top: 0px; left: 0; text-align: center; padding-top: 1%;">
            <table style="width: auto; margin-bottom: 1%;">
                <thead>
                    <tr>
                        <th scope="col" colspan="2" style="text-align: center">
                            Agregar Persona a la Autorizaci&oacute;n
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="tdDesControl">
                            Documento:
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtDoc" runat="server" Width="290px" MaxLength="8" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton_BusDoc" runat="server" ImageUrl="~/Visitas/Imagenes/search-24x24.png"
                                Width="26px" Height="26px" CssClass="btnPersona" CausesValidation="False" OnClick="ImageButton_BusAcomp_Click" />
                            <asp:ImageButton ID="ImageButton_DelDoc" runat="server" ImageUrl="~/Visitas/Imagenes/xion-24x24.png"
                                Width="26px" Height="26px" CssClass="btnPersona" CausesValidation="False" OnClick="ImageButton_DelAcomp_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdDesControl">
                            Apellido:
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtApellido" runat="server" Width="290px" MaxLength="32"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton_BusApe" runat="server" ImageUrl="~/Visitas/Imagenes/search-24x24.png"
                                Width="26px" Height="26px" CssClass="btnPersona" CausesValidation="False" OnClick="ImageButton_BusAcomp_Click" />
                            <asp:ImageButton ID="ImageButton_DelApe" runat="server" ImageUrl="~/Visitas/Imagenes/xion-24x24.png"
                                Width="26px" Height="26px" CssClass="btnPersona" CausesValidation="False" OnClick="ImageButton_DelAcomp_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdDesControl">
                            Nombre:
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtNombre" runat="server" Width="290px" MaxLength="32"></asp:TextBox>
                            <asp:ImageButton ID="ImageButton_BusNom" runat="server" ImageUrl="~/Visitas/Imagenes/search-24x24.png"
                                Width="26px" Height="26px" CssClass="btnPersona" CausesValidation="False" OnClick="ImageButton_BusAcomp_Click" />
                            <asp:ImageButton ID="ImageButton_DelNom" runat="server" ImageUrl="~/Visitas/Imagenes/xion-24x24.png"
                                Width="26px" Height="26px" CssClass="btnPersona" CausesValidation="False" OnClick="ImageButton_DelAcomp_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdDesControl">
                            Nro. Credencial:
                        </td>
                        <td style="text-align: left;">
                            <asp:TextBox ID="txtCredencial" runat="server" Width="290px" MaxLength="64"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Button ID="Button_AgregarAcomp" runat="server" Text="Agregar Persona" CssClass="btn btn-primary"
                                CausesValidation="False" OnClick="Button_AgregarAcomp_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button_Acreditar" runat="server" Text="Acreditar" CssClass="btn btn-primary"
                                CausesValidation="False" OnClick="Button_Acreditar_Click" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button_CancelarAcomp" runat="server" Text="Cancelar" CssClass="btn btn-primary"
                                CausesValidation="False" OnClick="Button_CancelarAcomp_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:GridView ID="GridView_Acomp" runat="server" EnableModelValidation="True" DataKeyNames="Id"
                OnRowDataBound="GridView_Acomp_RowDataBound" OnSelectedIndexChanged="GridView_Acomp_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Eliminar" ShowSelectButton="True">
                        <ControlStyle ForeColor="Red" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="divPersonasBusq" runat="server" style="background-image: url('Imagenes/bgblack.png');
            bottom: 0px; top: 0px; left: 0; text-align: center;">
            <div id="divGridViewPersonas">
                <asp:GridView ID="GridView_Personas" runat="server" EnableModelValidation="True"
                    CssClass="gvBusqPer" OnRowDataBound="GridView_Personas_RowDataBound" OnSelectedIndexChanged="GridView_Personas_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True">
                            <ControlStyle ForeColor="#009933" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
                <div id="divEmpyGridViewPersonas" runat="server">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <td style="text-align: center">
                                    <strong>No se encontraron personas con esos parametros de búsqueda.</strong>
                                </td>
                            </tr>
                        </thead>
                    </table>
                </div>
                <br />
                <asp:Button ID="Button_CancelarBusqueda" runat="server" Text="Cancelar" CssClass="btn btn-primary"
                    CausesValidation="False" OnClick="Button_CancelarBusqueda_Click" />
            </div>
        </div>
        <div id="divConfirmar" runat="server" style="background-image: url('Imagenes/bgblack.png');
            bottom: 0px; top: 0px; left: 0; text-align: center;">
            <div id="dialog">
                <div id="dialog-bg">
                    <div id="dialog-title">
                        <asp:Label ID="lblTituloMsj" runat="server"></asp:Label>
                    </div>
                    <div id="dialog-description">
                        <asp:Label ID="lblDescipMsj" runat="server"></asp:Label>
                    </div>
                    <div id="dialog-buttons">
                        <asp:LinkButton ID="lbConfirmar" runat="server" CssClass="large green button" OnClick="lbConfirmarEliminar_Click">Confirmar</asp:LinkButton>
                        <asp:LinkButton ID="lbAcreditar" runat="server" CssClass="large green button" 
                            onclick="lbAcreditar_Click">Acreditar</asp:LinkButton>
                        <asp:LinkButton ID="lbAceptar" runat="server" CssClass="large green button" 
                            OnClick="lbCancelar_Click">Aceptar</asp:LinkButton>
                        <asp:LinkButton ID="lbCancelar" runat="server" CssClass="large red button" OnClick="lbCancelar_Click">Cancelar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
