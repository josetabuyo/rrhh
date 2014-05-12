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
                            _this.autorizador.denegarFuncionalidadA(
                                _this.usuario.Id,
                                node.data.key,
                                function () {
                                    node.select(false);
                                },
                                function () { alertify.alert("error al denegar permisos"); }
                            );
                        }
                        else {
                            _this.autorizador.concederFuncionalidadA(
                                _this.usuario.Id,
                                node.data.key,
                                function () {
                                    node.select(true);
                                },
                                function () { alertify.alert("error al conceder permisos"); }
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
            alertify.alert(error);
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
        function (funcionalidades) { //on success
            for (var i = 0; i < funcionalidades.length; i++) {
                var nodo = _this.arbol.getNodeByKey(funcionalidades[i].Id.toString());
                nodo.select(true);
            }
        },
        function (error) { //on error
            alertify.alert('error');
        }
    );
};