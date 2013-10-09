var VistaDePermisosDeUnUsuario = function (opt) {
    $.extend(this, opt, true);
    this.start();
};

VistaDePermisosDeUnUsuario.prototype.start = function () {
    var _this = this;
    this.servicioDeSeguridad.getFuncionalidades(
        function (funcionalidades) { //on success
            _this.funcionalidades = funcionalidades;
            var nodos_funcionalidades = [];
            for (var i = 0; i < funcionalidades.length; i++) {
                nodos_funcionalidades.push(new NodoEnArbolDeFuncionalidades(funcionalidades[i]));
            }
            _this.ui.dynatree({
                checkbox: true,
                selectMode: 2,
                children: nodos_funcionalidades,
                debugLevel: 0
            });
            _this.arbol = _this.ui.dynatree('getTree');
        },
        function (error) { //on error
            alert(error);
        }
    );
};

VistaDePermisosDeUnUsuario.prototype.setUsuario = function (un_usuario) {
    this.arbol.visit(function (node) {
        node.select(false);
    }, true);
    var _this = this;
    this.servicioDeSeguridad.getPermisosPara(un_usuario,
        function (permisos) { //on success
            for (var i = 0; i < permisos.length; i++) {
                _this.arbol.getNodeByKey(permisos[i].funcionalidad.nombre).select();
            }
        },
        function (error) { //on error
            alert('error');
        }
    );
};