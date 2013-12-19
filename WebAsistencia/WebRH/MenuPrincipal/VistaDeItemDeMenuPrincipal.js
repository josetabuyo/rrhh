var VistaDeItemDeMenuPrincipal = function (item) {
    this.ui = $("#plantillas .item_de_menu_principal").clone();
    this.caption_item = this.ui.find("#caption_item");
    this.caption_item.text(item.NombreItem);
};

VistaDeItemDeMenuPrincipal.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};