var VistaDeAreasAdministradas = function (opt) {
    $.extend(this, opt, true);
    this.start();
};

VistaDeAreasAdministradas.prototype.start = function () {
    this.div_lista_areas = this.ui.find("#lista_areas_administradas");
    var _this = this;
    this.selector_de_areas = new SelectorDeAreas({
        ui: this.ui.find("#selector_area_administrada"),
        repositorioDeAreas: this.repositorioDeAreas,
        placeholder: "ingrese el área que desea agregar",
        alSeleccionarUnArea: function (area) {
            _this.autorizador.asignarAreaAUnUsuario(_this.usuario.Id, area.id,
            function () { //on success
                var vista_area = new VistaDeAreaAdministrada({ 
                    area: area,
                    usuario: _this.usuario,
                    autorizador: _this.autorizador
                });
                vista_area.dibujarEn(_this.div_lista_areas);
                _this.selector_de_areas.limpiar();
            },
            function () { //on error
                alertify.error("Error al asignar el área");
            });
        }
    });
};

VistaDeAreasAdministradas.prototype.setUsuario = function (un_usuario) {
    var _this = this;
    this.usuario = un_usuario;
    this.div_lista_areas.html('');
    this.autorizador.areasAdministradasPor(un_usuario.Id, function (areas_del_usuario) {
        for (var i = 0; i < areas_del_usuario.length; i++) {
            var vista_area = new VistaDeAreaAdministrada({ area: areas_del_usuario[i],
                usuario: un_usuario,
                autorizador: _this.autorizador
            });
            vista_area.dibujarEn(_this.div_lista_areas);
        }
    }, function () {
        alertify.alert("error al obtener las areas administradas por el usuario")
    });
};