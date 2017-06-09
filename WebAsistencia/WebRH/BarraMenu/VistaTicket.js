var VistaTicket = function (ticket) {
    this.ui = $("#plantillas_barra_menu .ui_tarea").clone();
    this.ui.find(".titulo_tarea").text(ticket.tipoTicket.descripcion);
    this.ui.find(".descripcion_tarea").text(ticket.usuarioCreador.Owner.Apellido + ", " + ticket.usuarioCreador.Owner.Nombre + " DNI:" + ticket.usuarioCreador.Owner.Documento);
    var _this = this;

    this.ui.click(function () {
        menu_tareas.contraer();
//        $("#plantillas_barra_menu").append($("<div>").load("../Componentes/AdministradorSolicitudCambioImagen.htm", function () {
//            var admin = new AdministradorSolicitudCambioImagen(solicitud);
//            admin.alResolver = function () {
//                _this.ui.remove();
//                _this.alQuitar();
//            };
//        }));
    });
};

VistaTicket.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};