var VistaAlerta = function (alerta) {
    var _this = this;
    this.alerta = alerta;
    this.ui = $("#plantillas_barra_menu .ui_mensaje_alerta").clone();
    this.ui.find(".titulo_mensaje_alerta").text(alerta.Titulo);
    this.ui.find(".contenido_mensaje_alerta").text(alerta.Descripcion);
    this.ui.find("#btn_ok").click(function () {
        Backend.MarcarAlertaComoLeida(alerta.Id).onSuccess(function () {
            _this.ui.remove();
            _this.alQuitar();
        });
    });
};

VistaAlerta.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};


var VistaSolicitudDeCambioImagen = function (solicitud) {
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

VistaSolicitudDeCambioImagen.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};