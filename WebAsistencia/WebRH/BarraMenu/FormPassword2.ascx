<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FormPassword2.ascx.cs" Inherits="BarraMenu_FormPassword" %>



<%--    <link id="link4" rel="stylesheet" href="../bootstrap/css/bootstrap.css" type="text/css" runat="server" />--%>
<%--     <link id="link3" rel="stylesheet" href="../Estilos/Estilos.css" type="text/css" runat="server" /> --%>
<%--    <script type="text/javascript" src="../bootstrap/js/jquery.js"> </script>--%>

    <!--script type="text/javascript" src="FormPassword2.js" />        -->

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
                                <input id="pass_actual" type="password" class="posicionamiento_input_cambio_pass"/>
                               <%-- <asp:TextBox ID="passActual" runat="server" />--%>
				              </div>
				              <div class="txt-fld">
				                <label for="">Nueva Contrase&ntilde;a</label>
                                 <input id="pass_nueva" type="password" class="posicionamiento_input_cambio_pass" />
                               <%-- <asp:TextBox ID="passNueva" runat="server" />--%>
				               
				              </div>
				              <div class="txt-fld">
				                <label for="">Repetir Contrase&ntilde;a</label>
                                <input id="pass_nueva_repetida" type="password" class="posicionamiento_input_cambio_pass" />
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

              
