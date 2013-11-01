var ServicioDePersonas = function (un_proveedor_ajax) {
    this.proveedor_ajax = un_proveedor_ajax;
};

ServicioDePersonas.prototype.buscarPersonas = function (criterio, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/BuscarPersonas",
        data: {
            criterio: criterio
        },
        success: function (personas_json) {
            var lista_personas = [];
            for (var i = 0; i < personas_json.length; i++) {
                var persona_json = personas_json[i];
                lista_personas.push(new Persona({
                    id: persona_json.Id,
                    nombre: persona_json.Nombre,
                    apellido: persona_json.Apellido,
                    legajo: persona_json.Legajo,
                    documento: persona_json.Documento
                }));
            }
            onSuccess(lista_personas);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};

ServicioDePersonas.prototype.buscarPersonasConLegajo = function (criterio, onSuccess, onError) {
    this.proveedor_ajax.postearAUrl({ url: "../AjaxWS.asmx/BuscarPersonasConLegajo",
        data: {
            criterio: criterio
        },
        success: function (personas_json) {
            var lista_personas = [];
            for (var i = 0; i < personas_json.length; i++) {
                var persona_json = personas_json[i];
                lista_personas.push(new Persona({
                    id: persona_json.Id,
                    nombre: persona_json.Nombre,
                    apellido: persona_json.Apellido,
                    legajo: persona_json.Legajo,
                    documento: persona_json.Documento
                }));
            }
            onSuccess(lista_personas);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            onerror(errorThrown);
        }
    });
};