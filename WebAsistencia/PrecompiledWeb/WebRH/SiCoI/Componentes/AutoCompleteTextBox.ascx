<%@ control language="C#" autoeventwireup="true" inherits="SiCoI_Componentes_AutoCompleteTextBox, App_Web_0xdkav13" %>
<link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
<script type="text/javascript">
    $(function () {
        $(".tb").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "SiCoI/Areas/Areas.asmx/AreasFormales",
                    data: "{ 'filtro_nombre': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                value: item.Alias
                            }
                        }))
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            },
            minLength: 2
        });
    });
</script>
<div class="demo">
    <div class="ui-widget">
        <label for="tbAuto">
            Area
        </label>
        <asp:TextBox ID="tbAuto" class="tb" runat="server">
        </asp:TextBox>
    </div>
</div>
