<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PruebaGDE.aspx.cs" Inherits="PruebaGDE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prueba GDE</title>
    <%= Referencias.Css("")%>
    <link rel="stylesheet" href="Scripts/select2-3.4.4/select2.css" />

</head>
<body id="bodyLogin">
    <div id="contenedor">     
       <form id="form1" runat="server">
        <asp:Button ID="ImageButton3" class="btn" runat="server" Text="Login"
                    OnClick="btnLogin_Click" EnableViewState="False" Style="text-align: center" />
        


          <button id="btnIniciarSesion">Iniciar Sesión GDE</button>

       <div id="loginAlertaInvalido" class="alert  alert-error" runat="server">
                     <a class="close" data-dismiss="alert">×</a> <strong>Error</strong> El nombre de
                                usuario o la contraseña ingresados no son v&aacute;lidos o el usuario está dado de baja.
                </div> 
           </form>
    </div>
    <%= Referencias.Javascript("") %>

</body>

    <script type="text/javascript">


        Backend.start(function () {
            $(document).ready(function () {

                $("#btnIniciarSesion").click(function () {

                      Backend.IniciarSesionGDE()
                          .onSuccess(function (rto) {
                              console.log(rto)
               
                        })
                        .onError(function (e) {
                            console.log(e)
                        });

                })
             
            });
        });

        
    </script>

</html>
