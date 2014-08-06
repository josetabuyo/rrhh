var MenuPrincipal = function (opt) {
    $.extend(this, opt, true);
    var _this = this;
    this.autorizador.getMenu(
        "PRINCIPAL",
        function (menu) {
            switch (menu.Items.length) {
                case 0: break;
                case 1:
                    window.location.href = menu.Items[0].Acceso.url;
                    break;
                default:
                    for (var i = 0; i < menu.Items.length; i++) {
                        var item_de_menu = new VistaDeItemDeMenuPrincipal(menu.Items[i]);
                        item_de_menu.dibujarEn(_this.ui);
                    }
            }
        },
        function () {
            alertify.alert("error al obtener el menú")
        });

};