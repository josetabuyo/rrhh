var ArbolOrganigrama = function (contenedor) {
    var _this = this;
    this.vistaArbol = $("#plantillas .arbol_organigrama").clone();
    contenedor.append(this.vistaArbol);
    Backend.GetArbolOrganigrama().onSuccess(function (area_raiz) {
        Backend.AreasAdministradasPor().onSuccess(function (areas_usuario) {
            _this.areasUsuario = areas_usuario;
            _this.dibujarArea(area_raiz, _this.vistaArbol);            
        });
    });
};

ArbolOrganigrama.prototype.dibujarArea = function (area, contenedor, es_area_hija_de_una_del_usuario) {
    var _this = this;
    var vista_area = $("#plantillas .area_en_arbol").clone();
    var div_nombre = vista_area.find("#nombre_area");
    div_nombre.text(area.nombre);
    var es_area_del_usuario = _.findWhere(this.areasUsuario, { Id: area.id }) && true;
    if (es_area_del_usuario || es_area_hija_de_una_del_usuario) {
        div_nombre.addClass("area_del_usuario");
        div_nombre.click(function () {
            _this.vistaArbol.find(".area_seleccionada_en_arbol").each(function (ia, v_area) {
                $(v_area).removeClass("area_seleccionada_en_arbol");
            });
            div_nombre.addClass("area_seleccionada_en_arbol");
        });
    }
    contenedor.append(vista_area);
    _.forEach(area.areasDependientes, function (area_dep) {
        _this.dibujarArea(area_dep, vista_area.children("#areas_dependientes"), es_area_del_usuario || es_area_hija_de_una_del_usuario);
    });
};