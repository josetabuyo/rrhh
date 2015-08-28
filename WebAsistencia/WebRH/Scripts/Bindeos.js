/*
 * object.watch polyfill
 *
 * 2012-04-03
 *
 * By Eli Grey, http://eligrey.com
 * Public Domain.
 * NO WARRANTY EXPRESSED OR IMPLIED. USE AT YOUR OWN RISK.
 */
 
// object.watch
if (!Object.prototype.watch) {
    Object.defineProperty(Object.prototype, "watch", {
        enumerable: false
		, configurable: true
		, writable: false
		, value: function (path, handler) {
		    var datos_bindeo = this.navegarParaBindeo(path);
		    var obj = datos_bindeo.objeto;
		    var prop = datos_bindeo.propiedad;

		    if (!obj[prop + "_handlers"]) {
		        obj[prop + "_handlers"] = [];
		        obj[prop + "_"] = obj[prop];
		        if (delete obj[prop]) { // can't watch constants
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
		        }
		    }
		    obj[prop + "_handlers"].push(handler);
		}
    });
}
 
// object.unwatch
if (!Object.prototype.unwatch) {
    Object.defineProperty(Object.prototype, "unwatch", {
        enumerable: false
		, configurable: true
		, writable: false
		, value: function (path, handler) {
		    var datos_bindeo = this.navegarParaBindeo(path);
		    var obj = datos_bindeo.objeto;
		    var prop = datos_bindeo.propiedad;

		    if (handler) {
		        obj[prop + "_handlers"].splice(obj[prop + "_handlers"].indexOf(handler), 1);
		        return;
		    }
		    var val = obj[prop + "_"];
		    delete obj[prop];
		    delete obj[prop + "_handlers"];
		    delete obj[prop + "_"];
		    obj[prop] = val;
		}
    });
}

if (!Object.prototype.navegarParaBindeo) {
    Object.defineProperty(Object.prototype, "navegarParaBindeo", {
        enumerable: false
		, configurable: true
		, writable: false
		, value: function (path) {
		    var path_spliteado = path.split('.');
		    var objeto_a_bindear;
		    var propiedad_a_bindear;
		    if (path_spliteado.length == 1) {
		        objeto_a_bindear = this;
		        propiedad_a_bindear = path_spliteado[0];
		    } else {
		        objeto_a_bindear = this;
		        for (var i = 0; i < path_spliteado.length - 1; i++) {
		            objeto_a_bindear = objeto_a_bindear[path_spliteado[i]];
		        }
		        propiedad_a_bindear = path_spliteado[path_spliteado.length - 1];
		    }
		    return {
		        objeto: objeto_a_bindear,
		        propiedad: propiedad_a_bindear
		    }
		}
    });
}

if (!Object.prototype.setValorEnPath) {
    Object.defineProperty(Object.prototype, "setValorEnPath", {
        enumerable: false
		, configurable: true
		, writable: false
		, value: function (path, valor) {
		    var target = this.navegarParaBindeo(path);
		    target.objeto[target.propiedad] = valor;
		}
    });
}

if (!Object.prototype.getValorDePath) {
    Object.defineProperty(Object.prototype, "getValorDePath", {
        enumerable: false
		, configurable: true
		, writable: false
		, value: function (path, valor) {
		    var target = this.navegarParaBindeo(path);
		    return target.objeto[target.propiedad];
		}
    });
}