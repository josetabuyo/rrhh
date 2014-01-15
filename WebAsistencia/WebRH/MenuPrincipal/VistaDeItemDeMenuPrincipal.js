var VistaDeItemDeMenuPrincipal = function (item) {
    this.ui = $("#plantillas .item_de_menu_principal").clone();
    this.link = this.ui.find("a");
    this.link.attr("href", item.Acceso.Url);
    this.link.attr("data-original-title", item.Descripcion);
    this.link.tooltip();

    this.link.attr("id", item.NombreItem);

    var style = document.createElement('style');
    style.type = 'text/css';
    style.innerHTML = "#" + item.NombreItem + " { background:url('" + item.NombreItem + ".png') no-repeat;}";
    style.innerHTML += "#" + item.NombreItem + ":after { background:url('" + item.NombreItem + "_after.png') no-repeat;}";
    document.getElementsByTagName('head')[0].appendChild(style);    
};

VistaDeItemDeMenuPrincipal.prototype.dibujarEn = function (un_panel) {
    un_panel.append(this.ui);
};