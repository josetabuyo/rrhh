var Componente = {
    start: function (credencial, ui, usuario) {
        var _this = this;
        this.ui = ui;
        ui.find("#credencial_vigente").hide();
        ui.find("#sin_credencial_vigente").hide();

        vex.defaultOptions.className = 'vex-theme-os';
        vex.close();
        vex.open({
            afterOpen: function ($vexContent) {
                //var ui = $("#plantillas_barra_menu #pantalla_credencial_vigente").clone();

                if (!usuario) {
                    Backend.GetUsuarioLogueado().onSuccess(function (usuario_logueado) {
                        Backend.GetCredencialesTodasDePortal().onSuccess(function (credenciales) {
                            _this.cargarCredencial($vexContent, usuario_logueado, credenciales);
                        });
                    });
                } else {
                    Backend.GetCredencialesDeUnaPersona(usuario.Owner.Id).onSuccess(function (credenciales) {
                        _this.cargarCredencial($vexContent, usuario, credenciales);
                    });
                }
                return ui;
            },
            css: {
                'padding-top': "4%",
                'padding-bottom': "0%"
            }
        });
    },
    cargarCredencial: function ($vexContent, usuario, credenciales) {
        var _this = this;
        var credencial_vigente = _.find(credenciales, function (c) { return c.Estado == "VIGENTE" });

        if (credencial_vigente) {
            this.ui.find("#credencial_vigente").show();
            this.ui.find("#apellido").text(usuario.Owner.Apellido);
            this.ui.find("#nombres").text(usuario.Owner.Nombre);
            this.ui.find("#documento").text(usuario.Owner.Documento);

            var src = "";
            if (credencial_vigente.Organismo == 'Ministerio de Desarrollo Social') {
                if (credencial_vigente.Tipo == 'Definitiva') src = '../BarraMenu/credencialMDS.jpg';
                if (credencial_vigente.Tipo == 'Externa') src = '../BarraMenu/credencialMDS_Externa.jpg';
            }
            if (credencial_vigente.Organismo == 'Ministerio de Salud') {
                if (credencial_vigente.Tipo == 'Definitiva') src = '../BarraMenu/credencialMSAL.jpg';
                if (credencial_vigente.Tipo == 'Externa') src = '../BarraMenu/credencialMSAL_Externa.jpg';
            }
            if (credencial_vigente.Organismo == 'Instituto Nacional de las Mujeres') {
                if (credencial_vigente.Tipo == 'Definitiva') src = '../BarraMenu/credencialINM.jpg';
                if (credencial_vigente.Tipo == 'Externa') src = '../BarraMenu/credencialINM_Externa.jpg';
            }

            this.ui.find("#imagen_credencial").attr('src', src);

            var img = new VistaThumbnail({
                id: credencial_vigente.IdFoto,
                contenedor: this.ui.find("#foto_usuario")
            });

            _this.ui.find("#codigo_barras").barcode(usuario.Owner.Documento.toString(), "code128", {
                showHRI: false,
                height: 10,
                width: 180
            });
        } else {
            this.ui.find("#sin_credencial_vigente").show();
        }

        Backend.PuedePedirCredencial().onSuccess(function (respuesta) {
            if (respuesta != 'OK') {
                _this.ui.find("#btn_renovar_credencial").attr('value', respuesta);
                _this.ui.find("#btn_realizar_solicitud").prop('disabled', true);
                return;
            }
            _this.ui.find("#btn_renovar_credencial").click(function () {
                var div = $("<div>");
                div.load(window.location.origin + '/Componentes/SolicitarRenovacionCredencial.htm', function () {
                    Componente.start({ usuario: usuario, credencial: credencial_vigente }, div);
                });
            });
        });


        $vexContent.css("width", "280px");
        $vexContent.append(_this.ui);
        _this.ui.show();

    }
};