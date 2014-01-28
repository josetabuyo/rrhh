var VistaDeAreasAdministradas = function (opt) {
    $.extend(this, opt, true);
    this.start();
};

VistaDeAreasAdministradas.prototype.start = function () {
    this.div_lista_areas = this.ui.find("#lista_areas_administradas");
};

VistaDeAreasAdministradas.prototype.setUsuario = function (un_usuario) {
    var _this = this;
    this.div_lista_areas.html('');
    this.autorizador.areasAdministradasPor(un_usuario.Id, function (areas_del_usuario) {
        for (var i = 0; i < areas_del_usuario.length; i++) {
            var vista_area = new VistaDeAreaAdministrada({ area: areas_del_usuario[i] });
            vista_area.dibujarEn(_this.div_lista_areas);
        }
    }, function () {
        alertify.alert("error al obtener las areas administradas por el usuario")
    });
};