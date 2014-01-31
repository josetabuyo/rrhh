var VistaDeItemDeMenuPrincipal = function (item) {
    this.ui = $("#plantillas .item_de_menu_principal").clone();
    this.link = this.ui.find("a");
    this.link.attr("href", item.Acceso.Url);
    //this.link.attr("data-original-title", item.Descripcion);
    this.link.tooltip();

    this.descriptor = this.ui.find("#descripcion_item");
    this.descriptor.text(item.Descripcion);

    var nombre_sin_espacios = item.NombreItem.split(' ').join('_');
    this.link.attr("id", nombre_sin_espacios);

    var estilo = "<style>";
    estilo += "#" + nombre_sin_espacios + " { background:url('" + nombre_sin_espacios + ".png') no-repeat;}";
    estilo += "#" + nombre_sin_espacios + ":after { background:url('" + nombre_sin_espacios + "_after.png') no-repeat;}";
    estilo += "</style>";

    $(estilo).appendTo("head");
};

VistaDeItemDeMenuPrincipal.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};