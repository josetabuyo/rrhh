var ABMComites = {

    completarDatos: function (comite) {
        var _this = this;
        this.ui = $("#contenedor_comites");

        var rh_form = new FormularioBindeado({
            formulario: this.ui,
            modelo: comite
        });
    }
}
