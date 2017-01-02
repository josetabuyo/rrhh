var MenuPrincipal = function (opt) {
    $.extend(this, opt, true);
    var _this = this;

    var cargar_menu = function () {
        _this.autorizador.getMenu(
            "PRINCIPAL",
            function (menu) {
                switch (menu.Items.length) {
                    case 0: break;
                    case 1:
                        window.location.href = menu.Items[0].Acceso.Url;
                        break;
                    default:
                        for (var i = 0; i < menu.Items.length; i++) {
                            var item_de_menu = new VistaDeItemDeMenuPrincipal(menu.Items[i]);
                            item_de_menu.dibujarEn(_this.ui);
                        }
                }
            },
            function () {
                alertify.alert("", "error al obtener el menú")
            });
    };

    Backend.GetUsuarioLogueado().onSuccess(function (usuario) {
        var levantar_prompt = function () {
            alertify.prompt("Ingrese su mail", "Para continuar debe ingresar una dirección de correo válida", "", function (ev, mail) {
                Backend.ModificarMiMail(mail).onSuccess(function (ok) {
                    if (ok) {
                        alertify.success("Mail modificado correctamente");
                        cargar_menu();         
                    }
                    else alertify.error("Error al modificar el mail");
                }).onError(function () {
                    alertify.error("Error al modificar el mail");
                });
            }, function () {
                setTimeout(function () { levantar_prompt(); }, 100);
            });
        };
        if (usuario.MailRegistro == '') {
            levantar_prompt();
        } else {
            cargar_menu();
        }
    });

};