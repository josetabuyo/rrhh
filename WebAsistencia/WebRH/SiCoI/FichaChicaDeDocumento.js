var FichaChicaDeDocumento = function (documento, ui, fabrica_de_fichas, areaDelUsuario) {
    this.ui = ui;
    this.fabrica_de_fichas = fabrica_de_fichas;
    this.documento = documento;
    this.area_del_usuario = areaDelUsuario;
    this.start();
}
FichaChicaDeDocumento.prototype = {
    start: function () {
        this.ticket = this.ui.find("#ficha_chica_contenido_ticket");
        this.tipo = this.ui.find("#ficha_chica_contenido_tipo");
        this.categoria = this.ui.find("#ficha_chica_contenido_categoria");
        this.extracto = this.ui.find("#ficha_chica_contenido_extracto");
        this.area_actual = this.ui.find("#ficha_chica_contenido_area_actual");
        this.boton_desplegar = this.ui.find("#ficha_chica_boton_desplegar");
        this.boton_enviar = this.ui.find("#ficha_chica_boton_enviar_documento");

        var self = this;
        this.boton_enviar.click(function () {
            var post_url;
            var post_data;
            if (self.area_del_usuario.id == self.documento.areaActual.id) {
                post_url = "../AjaxWS.asmx/TransicionarDocumento";
                post_data = JSON.stringify({
                    id_documento: self.documento.id,
                    id_area_origen: self.documento.areaActual.id,
                    id_area_destino: self.documento.areaDestino.id
                });
            } else {
                post_url = "../AjaxWS.asmx/TransicionarDocumentoConAreaIntermedia";
                post_data = JSON.stringify({
                    id_documento: self.documento.id,
                    id_area_origen: self.documento.areaActual.id,
                    id_area_intermedia: self.area_del_usuario.id,
                    id_area_destino: self.documento.areaDestino.id
                });
            }

            $.ajax({
                url: post_url,
                type: "POST",
                data: post_data,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (respuestaJson) {
                    var respuesta = JSON.parse(respuestaJson.d);
                    if (respuesta.tipoDeRespuesta == "envioDeDocumento.ok") {
                        self.mostrarDocumento(respuesta.documento);
                        self.actualizarFichaGrande();
                    }
                    if (respuesta.tipoDeRespuesta == "envioDeDocumento.error") {
                        alert("Error al enviar el documento: " + respuesta.error);
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
        });

        this.boton_desplegar.click(function () {
            self.toggleFichaGrande();
            self.boton_desplegar.toggleClass("icon-plus-sign");
            self.boton_desplegar.toggleClass("icon-minus-sign");
        });
        this.mostrarDocumento(this.documento);
    },
    actualizarFichaGrande: function () {
        if (this.ficha_grande === undefined) return;
        this.ficha_grande.mostrarDocumento(this.documento);
    },
    toggleFichaGrande: function () {
        if (this.ficha_grande === undefined) {
            this.ficha_grande = this.fabrica_de_fichas.crearFichaGrande(this.documento, this);
            this.ui.addClass("ficha_chica_de_documento_expandida");
            this.ficha_grande.dibujarEn(this.ui);
            this.extracto.text(this.documento.extracto);
            return;
        }
        this.ficha_grande.borrar();
        this.ui.removeClass("ficha_chica_de_documento_expandida");
        this.ficha_grande = undefined;
        this.mostrarDocumento(this.documento);
    },
    mostrarDocumento: function (documento) {
        this.documento = documento;
        this.ticket.text(this.documento.ticket);
        this.tipo.text(this.documento.tipo.descripcion);
        this.categoria.text(this.documento.categoria.descripcion);
        this.extracto.text(this.extractoResumido());
        this.area_actual.text(this.documento.areaActual.descripcion);
        this.boton_enviar.toggle(this.documento.areaDestino.id >= 0);
    },
    dibujarEn: function (panel) {
        panel.append(this.ui);
    },
    extractoResumido: function () {
        var lineas = this.documento.extracto.split(/\r\n|\r|\n/g);
        if (lineas.length == 1) return this.documento.extracto;
        var primera_linea = lineas[0];
        if (primera_linea.length < 120) return primera_linea + "...";
        return primera_linea.substr(0, 120) + "...";
    },
    getAreaResumida: function (descripcion) {
        descripcion = descripcion.replace("Direccion", "Dir.");
        descripcion = descripcion.replace("Dirección", "Dir.");
        descripcion = descripcion.replace("dirección", "Dir.");
        descripcion = descripcion.replace("direccion", "Dir.");
        return this.getTextoresumido(descripcion);
    },
    getTextoresumido: function (texto) {
        if (texto.length < 20) return texto;
        var textoResumido = $("<div>");
        textoResumido.text(texto.substring(0, 20) + "...");
        textoResumido.attr("title", texto);
        return textoResumido;
    }
}