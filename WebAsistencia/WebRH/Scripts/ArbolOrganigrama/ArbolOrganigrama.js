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
    var cuerpo_area = vista_area.find("#area");
    var cont_areas_dependientes = vista_area.children("#areas_dependientes");
    div_nombre.text(area.nombre);

    var btn_expandir = vista_area.find("#btn_expandir");
    var btn_contraer = vista_area.find("#btn_contraer");
    btn_expandir.click(function () {
        cont_areas_dependientes.show();
        btn_expandir.hide();
        btn_contraer.show();
    });
    btn_contraer.click(function () {
        cont_areas_dependientes.hide();
        btn_contraer.hide();
        btn_expandir.show();
    });
    btn_contraer.click();

    switch (area.jerarquia) {
        case 1000: 
            cuerpo_area.addClass("ministerio");
            break;
        case 900:
            cuerpo_area.addClass("secretaria");
            break;
        case 800:
            cuerpo_area.addClass("subsecretaria");
            break;
        case 700:
            cuerpo_area.addClass("direccion");
            break;
        case 600:
            cuerpo_area.addClass("subdireccion");
            break;
        case 500:
            cuerpo_area.addClass("coordinacion");
            break;
    }
    var es_area_del_usuario = _.findWhere(this.areasUsuario, { Id: area.id }) && true;
    if (es_area_del_usuario || es_area_hija_de_una_del_usuario) {
        div_nombre.addClass("area_del_usuario");
        div_nombre.click(function () {
            _this.vistaArbol.find(".area_seleccionada_en_arbol").each(function (ia, v_area) {
                $(v_area).removeClass("area_seleccionada_en_arbol");
            });
            div_nombre.addClass("area_seleccionada_en_arbol");
            _this.call_alSeleccionar(area);
        });
    }
    contenedor.append(vista_area);
    var hay_algun_area_del_usuario_en_esta_rama = false;
    _.forEach(area.areasDependientes, function (area_dep) {
        if (_this.dibujarArea(area_dep, cont_areas_dependientes, es_area_del_usuario || es_area_hija_de_una_del_usuario))
            hay_algun_area_del_usuario_en_esta_rama = true;
    });
    if (es_area_del_usuario || es_area_hija_de_una_del_usuario || hay_algun_area_del_usuario_en_esta_rama) {
        btn_expandir.click();
    }
    if (area.areasDependientes.length == 0) {
        btn_expandir.hide();
        btn_contraer.hide();
    }
    return es_area_del_usuario || es_area_hija_de_una_del_usuario || hay_algun_area_del_usuario_en_esta_rama;
};

ArbolOrganigrama.prototype.alSeleccionar = function (callback) {
    if(!this.callbacks_seleccionar) this.callbacks_seleccionar = []; 
    this.callbacks_seleccionar.push(callback);
}

ArbolOrganigrama.prototype.call_alSeleccionar = function (area) {
    _.forEach(this.callbacks_seleccionar, function(cb){
        cb(area);
    });
}