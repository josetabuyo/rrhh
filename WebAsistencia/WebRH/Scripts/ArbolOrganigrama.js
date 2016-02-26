var ArbolOrganigrama = function (data, contenedor) {
    this.vistaArbol = $("#plantillas .arbol_organigrama").clone();
    contenedor.append(this.vistaArbol);
    this.dibujarArea(data.areaRaiz, this.vistaArbol);    
};

ArbolOrganigrama.prototype.dibujarArea = function (area, contenedor) {
    var _this = this;
    var vista_area = $("#plantillas .area_en_arbol").clone();
    var div_nombre = vista_area.find("#nombre_area");
    div_nombre.text(area.nombre);
    div_nombre.click(function () {
        _this.vistaArbol.find(".area_seleccionada_en_arbol").each(function (ia, v_area) {
            $(v_area).removeClass("area_seleccionada_en_arbol");
        });
        div_nombre.addClass("area_seleccionada_en_arbol");
    });
    contenedor.append(vista_area);
    _.forEach(area.areasDependientes, function (area_dep) {
        _this.dibujarArea(area_dep, vista_area.find("#areas_dependientes"))
    });
};