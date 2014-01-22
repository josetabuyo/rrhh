var VistaDePermisosDeUnUsuario = function (opt) {
    $.extend(this, opt, true);
    this.start();
};

VistaDePermisosDeUnUsuario.prototype.start = function () {
    var _this = this;
    this.repositorioDeFuncionalidades.todasLasFuncionalidades(
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
                debugLevel: 0,
                onClick: function (node, event) {
                    if (node.getEventTargetType(event) == 'checkbox') {
                        if (node.isSelected()) {
                            _this.servicioDeSeguridad.denegarPermisoA(
                                _this.usuario,
                                node.data.title,
                                function () {
                                    node.select(false);
                                },
                                function () { alert("error al denegar permisos"); }
                            );
                        }
                        else {
                            _this.servicioDeSeguridad.concederPermisoA(
                                _this.usuario,
                                node.data.title,
                                function () {
                                    node.select(true);
                                },
                                function () { alert("error al conceder permisos"); }
                            );
                        }
                        return false;
                    }
                }
            });
            _this.arbol = _this.ui.dynatree('getTree');
            _this.ui.dynatree("getRoot").visit(function (node) {
                node.expand(true);
            });
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
    this.usuario = un_usuario;
    var _this = this;
    this.repositorioDeFuncionalidades.funcionalidadesPara(un_usuario,
        function (permisos) { //on success
            for (var i = 0; i < permisos.length; i++) {
                var nodo = _this.arbol.getNodeByKey(permisos[i].Id);
                if (permisos[i].tipo == "Concedido") {
                    nodo.select(true);
                }
                if (permisos[i].tipo == "Denegado") {
                    nodo.select(false);
                }
            }
        },
        function (error) { //on error
            alert('error');
        }
    );
};