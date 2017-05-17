<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FormMiArea.ascx.cs" Inherits="BarraMenu_FormMiArea" %>
<script type="text/javascript">

    $(document).ready(function () {
        Legajo.getAreaDeLaPersona();
    });

    $(function () {
        $('a[rel*=leanModal]').leanModal({ top: 200, closeButton: ".modal_close" });
    });


</script>
<div id="mi_area">
    <div id="signup-ct">
        <div id="signup-header">
            <h2 style="color: #fff;">
                Datos de mi área</h2>
            <p>
            </p>
            <a class="modal_close" href="#"></a>
        </div>
        <div id="contenido_form">
            <div class="datos_del_area">
                <div style="text-align: center; margin-bottom: -10px;">
                    INFORMACIÓN DE MI ÁREA</div>
                <br />
                <label style="font-size: 11px;" id="resumen_area">
                </label>
            </div>
        </div>
    </div>
</div>
<asp:TextBox ID="urlAjax" runat="server" Text="" Style="display: none;" />
