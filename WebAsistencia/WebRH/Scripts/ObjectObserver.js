var ObjectObserver = O_O = {
    watchear: function (objeto, path, handler) {
        var datos_bindeo = this.navegarParaBindeo(objeto, path);
        var obj = datos_bindeo.objeto;
        var prop = datos_bindeo.propiedad;

        if (!obj[prop + "_handlers"]) {
            obj[prop + "_handlers"] = [];
            obj[prop + "_"] = obj[prop];
            try {
                Object.defineProperty(obj, prop, {
                    get: function () {
                        return obj[prop + "_"];
                    },
                    set: function (val) {
                        obj[prop + "_handlers"].forEach(function (hnd) {
                            hnd.call(obj, prop, obj[prop + "_"], val);
                        });
                        obj[prop + "_"] = val;
                        return val;
                    },
                    enumerable: true,
                    configurable: true
                });
            } catch (e) {
                obj[prop + "_interval"] = setInterval(function () {
                    if (obj[prop] != obj[prop + "_"]) {
                        obj[prop + "_handlers"].forEach(function (hnd) {
                            hnd.call(obj, prop, obj[prop + "_"], obj[prop]);
                        });
                    }
                    obj[prop + "_"] = obj[prop];
                }, 50);
            }
        }
        obj[prop + "_handlers"].push(handler);
    },
    desWatchear: function (objeto, path, handler) {
        var datos_bindeo = this.navegarParaBindeo(objeto, path);
        var obj = datos_bindeo.objeto;
        var prop = datos_bindeo.propiedad;

        if (handler) {
            if (!obj[prop + "_handlers"]) return;
            var index = -1;
            for (var i = 0; i < obj[prop + "_handlers"].length; i++) {
                if (handler === obj[prop + "_handlers"][i]) index = i;
            }
            obj[prop + "_handlers"].splice(index, 1);
            return;
        }
        var val = obj[prop + "_"];
        delete obj[prop];
        delete obj[prop + "_handlers"];
        delete obj[prop + "_"];
        if (obj[prop + "_interval"]) {
            clearInterval(obj[prop + "_interval"]);
            delete obj[prop + "_interval"];
        }
        obj[prop] = val;
    },
    navegarParaBindeo: function (obj, path) {
        var path_spliteado = path.split('.');
        var objeto_a_bindear;
        var propiedad_a_bindear;
        if (path_spliteado.length == 1) {
            objeto_a_bindear = obj;
            propiedad_a_bindear = path_spliteado[0];
        } else {
            objeto_a_bindear = obj;
            for (var i = 0; i < path_spliteado.length - 1; i++) {
                objeto_a_bindear = objeto_a_bindear[path_spliteado[i]];
            }
            propiedad_a_bindear = path_spliteado[path_spliteado.length - 1];
        }
        return {
            objeto: objeto_a_bindear,
            propiedad: propiedad_a_bindear
        }
    },
    setValorEnPath: function (objeto, path, valor) {
        var target = this.navegarParaBindeo(objeto, path);
        target.objeto[target.propiedad] = valor;
    },
    getValorDePath: function (objeto, path) {
        var target = this.navegarParaBindeo(objeto, path);
        return target.objeto[target.propiedad];
    }
};