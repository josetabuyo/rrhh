var AdministradorDeMensajes = function (mostrador_de_mensajes, div_mensaje) {
    this.mostradorDeMensajes = mostrador_de_mensajes;
    this.div_mensaje = div_mensaje;
};

AdministradorDeMensajes.prototype = {
    informarAlUsuario: function () {
        var div = $('#' + this.div_mensaje)
        this.mostradorDeMensajes.mostrar(div.text());

    }
};

