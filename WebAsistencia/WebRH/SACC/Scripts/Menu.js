var Menu = function () {

}

Menu.prototype.getMenu = function (nombre_menu) {
    $.ajax({
        url: "../AjaxWS.asmx/GetMenu",
        type: "POST",
        data: JSON.stringify({ nombre_menu: nombre_menu }),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
};

var menu = new Menu();
menu.getMenu("MACC_IZQ");
menu.getMenu("MACC_CALIFICACIONES");