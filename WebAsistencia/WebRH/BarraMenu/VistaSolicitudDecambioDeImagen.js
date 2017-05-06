var VistaSolicitudDeCambioDeImagen = function (solicitud) {
    this.ui = $("#plantillas_barra_menu .ui_solicitud_cambio_imagen").clone();
    this.ui.find(".titulo").text("Solicitud de cambio de imagen pendiente");
    this.ui.find(".descripcion").text("Solicitante:" + "(" + solicitud.usuario.Alias.replace(' ', '') + ") " + solicitud.usuario.Owner.Apellido + ", " + solicitud.usuario.Owner.Nombre + " DNI:" + solicitud.usuario.Owner.Documento);

    this.ui.click(function () {
        menu_tareas.contraer();
        $("#plantillas_barra_menu").append($("<div>").load("../Componentes/AdministradorSolicitudCambioImagen.htm", function () {
            var admin = new AdministradorSolicitudCambioImagen(solicitud);

        }));
    });
};

VistaSolicitudDeCambioDeImagen.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};