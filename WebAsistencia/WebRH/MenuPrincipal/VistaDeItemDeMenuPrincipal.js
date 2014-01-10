var VistaDeItemDeMenuPrincipal = function (item) {
    this.ui = $("#plantillas .item_de_menu_principal").clone();
    this.link = this.ui.find("a");
    this.link.attr("href", item.Acceso.Url);
    this.link.attr("data-original-title", item.Descripcion);
    this.link.attr("href", item.Acceso.Url);
};

VistaDeItemDeMenuPrincipal.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};