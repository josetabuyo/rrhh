<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormCaptchaRecupero.aspx.cs" Inherits="RegistroPostular_FormCaptchaRecupero" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="PantallaRegistro.css" rel="stylesheet" type="text/css" />
<%= Referencias.Css("../")%> 
    <title></title>
   <script type="text/javascript" src="PantallaRegistro.js">  </script>
    <script type="text/javascript">
        function RecuperoOk() {
            PantallaRegistro.paso4();
        }
        function RecuperoError() {
            PantallaRegistro.paso5();
        }
</script>
</head>
<body>
    <div id="div_error_captcha">
        <br />
        <asp:Label ID="lb_mensajeError" CssClass="lbl_mensaje_campo" runat="server" />
    </div>
    <div id="div_general_captcha">
        <form id="form1" runat="server">
            <div>
                <br />
                <asp:Label ID="lbMail" CssClass="lbl_titulo_campo" Text="E-mail:"  runat="server" />
                <asp:TextBox ID="txt_mail_recupero" runat="server" EnableViewState="False" Width= "200px"> </asp:TextBox>
            </div>     
            <div>
                <asp:Label ID="lbIngreseLosDigitos" CssClass="lbl_titulo_campo" Text="Dígitos:" runat="server" />
                <asp:TextBox ID="txtImg" runat="server" EnableViewState="False" Width= "150px"> </asp:TextBox>
                <br />
                <asp:Label ID="lbImagen" CssClass="lbl_titulo_campo" Text=" Imagen: " runat="server"/>
                <asp:Image ID="imgCaptcha" ImageUrl="Captcha.ashx" runat="server" />
                <asp:Button ID="btn_recuperar" Text="Recuperar" runat="server" OnClick="btn_recuperar_Click" class="btn btn-primary" style="float:right;" />
                <br /><br />
                <label Style="color:Olive; font-size: 12px; font-style: oblique"> Ingrese los dígitos de la imagen verificadora antes de enviar los datos</label>    
            </div>
        </form>
     
    </div>
</body>
</html>
