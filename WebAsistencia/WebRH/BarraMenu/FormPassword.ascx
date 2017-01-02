<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FormPassword.ascx.cs" Inherits="BarraMenu_FormPassword" %>



<%--    <link id="link4" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />--%>
<%--     <link id="link3" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> --%>
<%--    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>--%>

    <script type="text/javascript">
        function CapturarTeclaEnter(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type == "password")) { $("#pass").click();return false;}
        }


        $(document).ready(function () {
            //Al presionarse Enter luego de Ingresar el DNI, se fuerza a realizar la búsqueda de dicho DNI para no tener que hacer necesariamente un click en el botón Buscar

            document.onkeypress = CapturarTeclaEnter;

            $("#pass").click(function () {

                var pass_actual = $('#pass_actual').val();
                var pass_nueva = $('#pass_nueva').val();
                var pass_nueva_repetida = $('#pass_nueva_repetida').val();

                if (!(ValidarCamposVacios(pass_actual, pass_nueva, pass_nueva_repetida))) {
                    return false;
                }

                if (pass_nueva != pass_nueva_repetida) {
                    alertify.alert("", "Las contrase&ntilde;as no coinciden");
                    return;
                }
                //FC: agregar estas validaciones cuando salgamos a produccion
                if (pass_nueva.length < 8) {
                    alertify.alert("", "La contrase&ntilde;a debe ser tener al menos 8 d&iacute;gitos ");
                    return;
                }

                if (pass_nueva == pass_actual) {
                    alertify.alert("", "La contrase&ntilde;a debe ser distinta de la actual");
                    return;
                }

                var matches = pass_nueva.match(/\d+/g);
                if (matches == null) {
                    alertify.alert('', 'La contrase&ntilde;a debe tener algun n&uacute;mero');
                    return false;
                }

                var data_post = JSON.stringify({
                    pass_actual: pass_actual,
                    pass_nueva: pass_nueva
                });
                _this = this;

                $.ajax({
                    url: $('#BarraMenu_FormPassword_urlAjax').val().concat("AjaxWS.asmx/CambiarPassword"),
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        if (respuesta.tipoDeRespuesta == "cambioPassword.ok") {

                            alertify.alert("", "Se cambio la contrase&ntilde;a correctamente");
                            $(".modal_close").click();
                            $('#pass_actual').val("");
                            $('#pass_nueva').val("");
                            $('#pass_nueva_repetida').val("");
                            return;
                        }

                        if (respuesta.tipoDeRespuesta == "cambioPassword.error") {
                            alertify.alert("", "La contrase&ntilde;a actual no es correcta");
                            $(".modal_close").click();
                            return;
                        }

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            });
        });

        var ValidarCamposVacios = function (pass_actual, pass_nueva, pass_nueva_repetida) {
            if (pass_actual == "" || pass_nueva == "" || pass_nueva_repetida == "") {
                alertify.alert("", "Complete todos los campos");
                return false;
            }
            return true;
        };


        $(function () {
            $('a[rel*=leanModal]').leanModal({ top: 200, closeButton: ".modal_close" });
        });


    </script>

<%--      <script type="text/javascript" src="../Scripts/jquery.leanModal.min.js"></script>--%>


                <div id="signup" >
			        <div id="signup-ct">
				        <div id="signup-header">
					        <h2 style="color:#fff;">Cambio de Contrase&ntilde;a</h2>
					        <p></p>
					        <a class="modal_close" href="#"></a>
				        </div>
							<div id="contenido_form">
				              <div class="txt-fld">
				                <label for="">Contrase&ntilde;a actual</label>
                                <input id="pass_actual" type="password" />
                               <%-- <asp:TextBox ID="passActual" runat="server" />--%>
				              </div>
				              <div class="txt-fld">
				                <label for="">Nueva Contrase&ntilde;a</label>
                                 <input id="pass_nueva" type="password" />
                               <%-- <asp:TextBox ID="passNueva" runat="server" />--%>
				               
				              </div>
				              <div class="txt-fld">
				                <label for="">Repetir Contrase&ntilde;a</label>
                                <input id="pass_nueva_repetida" type="password" />
                               <%-- <asp:TextBox ID="passNuevaRepetida" runat="server" />--%>
				              </div>
				              <div class="btn-fld">
                              <p><span style="font-weight:bold;">Advertencia:</span> Ingresar al menos 8 d&iacute;gitos (n&uacute;meros y letras)</p>
                               
				                <input type="button" class="btn btn-primary" id="pass"  value="Cambiar" />
                              </div>
                            </div>	         
			        </div>
                </div> 

                <asp:TextBox ID="urlAjax" runat="server" Text=""  style="display:none;" />

              
