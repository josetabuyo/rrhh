var VistaDeItemDeMenuPrincipal = function (item) {
    this.ui = $("#plantillas .item_de_menu_principal").clone();
    this.link = this.ui.find("a");
    this.link.attr("href", item.Acceso.Url);
    this.link.attr("data-original-title", item.Descripcion);
    this.link.tooltip();

    var nombre_sin_espacios = item.NombreItem.split(' ').join('_');
    this.link.attr("id", nombre_sin_espacios);

    var style = document.createElement('style');
    style.type = 'text/css';
    style.innerHTML = "#" + nombre_sin_espacios + " { background:url('" + nombre_sin_espacios + ".png') no-repeat;}";
    style.innerHTML += "#" + nombre_sin_espacios + ":after { background:url('" + nombre_sin_espacios + "_after.png') no-repeat;}";
    document.getElementsByTagName('head')[0].appendChild(style);    
};

VistaDeItemDeMenuPrincipal.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};