<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PruebaGDE.aspx.cs" Inherits="PruebaGDE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prueba GDE</title>
    <%= Referencias.Css("")%>
    <link rel="stylesheet" href="Scripts/select2-3.4.4/select2.css" />
    <script src="https://paec.gde.gob.ar/auth/js/keycloak.js"></script>

 
</head>
<body id="bodyLogin">
    <div id="contenedor">     
       <form id="form1" runat="server">
        <asp:Button ID="ImageButton3" class="btn" runat="server" Text="INICIAR SESION GDE"
                    OnClick="btnLogin_Click" EnableViewState="False" Style="text-align: center" />
        


         <p><a href="http://autenticar.gob.ar/auth/realms/sigirh-ds-gde/protocol/openid-connect/logout?redirect_uri=http://server/app/close-session" class="btn btn-primary btn-lg">CERRAR SESION</a></p>

       <div id="loginAlertaInvalido" class="alert  alert-error" runat="server">
                     <a class="close" data-dismiss="alert">×</a> <strong>Error</strong> El nombre de
                                usuario o la contraseña ingresados no son v&aacute;lidos o el usuario está dado de baja.
                </div> 

           <input type="button" id="btnProbar" value="Probar autenticacion" />
           </form>
    </div>
    <%= Referencias.Javascript("") %>
     <script src="keycloakConfig.js"></script>
</body>
      
    <script type="text/javascript">


        Backend.start(function () {
            $(document).ready(function () {

               var keycloak = Keycloak(keycloakConfig); 

                keycloak.init({ onLoad: 'login-required', flow: 'implicit' }).success(function(authenticated) {
                    alert(authenticated ? 'authenticated' : 'not authenticated');
                    console.log(authenticated)
                }).error(function (e) {
                        console.log(e);
                        alert('failed to initialize');
                });

                $("#btnProbar").click(function () {
                    document.getElementById('username').innerText = keycloak.subject;
                    var url = 'http://localhost:8080/restfulservice';

                    var req = new XMLHttpRequest(); req.open('GET', url, true);
                    req.setRequestHeader('Accept', 'application/json');
                    req.setRequestHeader('Authorization', 'Bearer ' + keycloak.token);
                    req.onreadystatechange = function () {
                        if (req.readyState == 4) {
                            if (req.status == 200) {
                                alert('Success');
                            }
                            else if (req.status == 403) {
                                alert('Forbidden');
                            }
                        }
                    }
                    req.send();

                });

               

                /*keycloak.updateToken(30).success(function() {
                    loadData();
                }).error(function () {
                    alert('Failedto refresh token'); 
                ); */


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
