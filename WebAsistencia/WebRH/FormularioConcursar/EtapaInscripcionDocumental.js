var EtapaInscripcionDocumental = {
    mostrarPostulacion: function (postulacion) {
        var _this = this;
        _this.btn_guardar = $("#btn_guardar");
        var pantalla;


        Backend.GetPantallaRecepcionDocumentacion(postulacion)
                    .onSuccess(function (mi_pantalla) {
                        pantalla = mi_pantalla;
                        var nombre_perfil = $("#nombre_perfil");
                        nombre_perfil[0].innerHTML = mi_pantalla.Postulacion.Perfil.Denominacion;

                        _this.armarPantallaPerfil(mi_pantalla, $('#requisitos_perfil'));
                        _this.armarPantalla(mi_pantalla.CuadroPerfil, $('#detalle_perfil'));
                        _this.armarPantalla(mi_pantalla.DocumentacionRequerida, $('#detalle_documentos'));
                        _this.completarFoliosRecepecionados(mi_pantalla.DocumentacionRecibida, $('#detalle_documentos'));
                    });

        _this.btn_guardar.click(function () {

            var lista_foliables = $(".foliables");
            var lista_documentacion_recibida = [];

            for (var i = 0; i < lista_foliables.length; i++) {
                var documentacionRecibida = {};
                var item = {};
                var id = lista_foliables[i].id;
                var res = id.split("_");
                item.Id = parseInt(res[1]);
                item.IdTabla = parseInt(res[0]);
                item.Descripcion = "";
                documentacionRecibida.Id = 0;
                //documentacionRecibida.Fecha = new Date(2014,04,01);
                documentacionRecibida.ItemCV = item;
                documentacionRecibida.IdPostulacion = postulacion.Id;
                documentacionRecibida.Folio = lista_foliables[i].firstElementChild.value;

                lista_documentacion_recibida.push(documentacionRecibida);
            }

            //pantalla.DocumentacionRecibida = lista_documentacion_recibida;

            Backend.GuardarDocumentacionRecibida(lista_documentacion_recibida)
             .onSuccess(function (resultado) {
                 alert(resultado);

             });

        });

    },
    completarFoliosRecepecionados: function (elementos, div_caja_foliables) {
        if (elementos.length > 0) {
            for (var i = 0; i < elementos.length; i++) {
                var id = elementos[i].IdTabla + "_" + elementos[i].IdItemCV;
                $("#" + id)[0].firstElementChild.value = elementos[i].Folio;
            }
        }

    },
    armarPantallaPerfil: function (pantalla, div_caja_foliables) {

        for (var i = 0; i < pantalla.RequisitosPerfil.length; i++) {
            var div_foliable = $('<div>');
            var descripcion_foliable = $('<p>');
            div_caja_foliables.attr("style", "margin:5px; background-color:#F3F5FF; ");

            descripcion_foliable.text(pantalla.RequisitosPerfil[i]);
            div_caja_foliables.append(descripcion_foliable);

            div_caja_foliables.append(descripcion_foliable);
        }
    },
    armarPantalla: function (elementos, div_caja_foliables) {

        if (elementos.length > 0) {
            // var div_caja_foliables = $('#detalle_perfil');
            for (var i = 0; i < elementos.length; i++) {
                var div_foliable = $('<div>');
                var descripcion_foliable = $('<p>');
                descripcion_foliable.attr("style", "font-size:13px; font-weight:bold;");

                descripcion_foliable.text(elementos[i].DescripcionRequisito);

                div_caja_foliables.append(descripcion_foliable);

                for (var j = 0; j < elementos[i].ItemsCv.length; j++) {
                    var descripcion_item = $('<p>');
                    descripcion_item.attr("id", elementos[i].ItemsCv[j].IdTabla + "_" + elementos[i].ItemsCv[j].Id);
                    descripcion_item.attr("class", "foliables");
                    descripcion_item.attr("style", "padding-bottom: 10px;");
                    var textbox_folio = $('<input>');
                    textbox_folio.attr("type", "textbox");
                    textbox_folio.attr("style", " width:40px; float: right; margin-right: 40%;");
                    textbox_folio.attr("placeholder", "Folio");

                    descripcion_item.text(elementos[i].ItemsCv[j].Descripcion);
                    descripcion_item.append(textbox_folio);
                    div_caja_foliables.append(descripcion_item);

                }

            }

        }
    }
}





