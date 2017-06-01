var VistaSolicitudDeCambioDeImagen = function (solicitud) {
    this.ui = $("#plantillas_barra_menu .ui_tarea").clone();
    this.ui.find(".titulo_tarea").text("Solicitud de cambio de imagen pendiente");
    this.ui.find(".descripcion_tarea").text("Solicitante:" + "(" + solicitud.usuario.Alias.replace(' ', '') + ") " + solicitud.usuario.Owner.Apellido + ", " + solicitud.usuario.Owner.Nombre + " DNI:" + solicitud.usuario.Owner.Documento);
    var _this = this;

    this.ui.click(function () {
        menu_tareas.contraer();
        $("#plantillas_barra_menu").append($("<div>").load("../Componentes/AdministradorSolicitudCambioImagen.htm", function () {
            var admin = new AdministradorSolicitudCambioImagen(solicitud);
            admin.alResolver = function () {
                _this.ui.remove();
                _this.alQuitar();
            };
        }));
    });
};

VistaSolicitudDeCambioDeImagen.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};