var EtapaPreInscripcionDocumental = {
    mostrarPostulacion: function () {
        var _this = this;
        _this.btn_guardar = $("#btn_guardar");
        _this.btn_buscar_postulacion = $("#btn_buscar_postulacion");

        var pantalla;

        _this.btn_buscar_postulacion.click(function () {
            _this.BuscarPostulaciones();
        });


        _this.btn_guardar.click(function () {

            var lista_foliables = $(".foliables");
            var lista_documentacion_recibida = [];
            var postulacion = $("#postulacion");

            for (var i = 0; i < lista_foliables.length; i++) {
                var documentacionRecibida = {};
                var item = {};
                var id = lista_foliables[i].id;
                var res = id.split("_");
                item.Id = parseInt(res[1]);
                item.IdTabla = parseInt(res[0]);
                item.Descripcion = "";
                documentacionRecibida.Id = lista_foliables[i].lastChild.id;
                //documentacionRecibida.Fecha = new Date(2014,04,01);
                documentacionRecibida.ItemCV = item;
                documentacionRecibida.IdPostulacion = postulacion[0].value;
                documentacionRecibida.Folio = lista_foliables[i].firstElementChild.value;
                //var folio = lista_foliables[i].lastChild.value;

                if (lista_foliables[i].lastChild.value != "") {
                    documentacionRecibida.FolioPersistido = lista_foliables[i].lastChild.value;
                    //$("#" + id)[0].data("folio", elementos[i].FolioPersistido);
                };

                lista_documentacion_recibida.push(documentacionRecibida);
            }

            //pantalla.DocumentacionRecibida = lista_documentacion_recibida;

            Backend.GuardarDocumentacionRecibida(postulacion[0].value, lista_documentacion_recibida)
             .onSuccess(function (resultado) {
                 if (resultado == true) {
                     alertify.alert('Se guardaron las fojas con éxito y ha pasado al estado de Preincripción Documental');
                 } else {
                     alertify.alert('Esta postulación ya estaba con el estado Preinscripción Documental. Se guardaron las fojas con éxito. ');
                 }

                 //location.reload();
             })
            .onError(function (error) {
                alertify.error(error.statusText);
            });

        });

    },
    BuscarPostulaciones: function () {
        var _this = this;
        var codigo = $("#txt_codigo_postulacion").val();
        var div_tabla_historial = $("#div_tabla_historial");
        $("#span_empleado").html("");
        $("#span_codigo").html("");
        $("#span_fecha").html("");
        $("#span_perfil").html("");
        $("#span_estado").html("");
        $("#requisitos_perfil").html("");
        $("#detalle_perfil").html("");
        $("#detalle_documentos").html("");
        $("#titulo_doc_oblig").remove();
        $("#titulo_doc_curric").remove();

        Backend.ejecutar("GetPostulacionesPorCodigo",
            [codigo],
            function (respuesta) {
                if (respuesta != null) _this.CompletarDatos(respuesta);
                else {
                    alertify.alert("Código no encontrado");
                }
            },
            function (errorThrown) {
                alertify.alert(errorThrown);
            }
        );


    },
    completarFoliosRecepcionados: function (elementos, div_caja_foliables) {
        if (elementos.length > 0) {
            for (var i = 0; i < elementos.length; i++) {
                var id = elementos[i].IdTabla + "_" + elementos[i].IdItemCV;

                var elemento = $("#" + id)[0];
                elemento.firstElementChild.value = elementos[i].Folio;
                elemento.lastChild.value = elementos[i].FolioPersistido;
                elemento.lastChild.id = elementos[i].Id;

            }
        }

    },
    CompletarDatos: function (datos_postulacion) {
        var _this = this;

        var BuscarUsuario = function () {
            this.generar = function (una_etapa) {
                for (var i = 0; i < usuarios.length; i++) {
                    if (parseInt(usuarios[i].Id, 10) == parseInt(una_etapa.IdUsuario, 10)) return usuarios[i].Owner.Nombre + " " + usuarios[i].Owner.Apellido;
                }
                return "";
            }
        }

        var div_tabla_historial = $("#div_tabla_historial");
        var span_empleado = $("#span_empleado");
        var span_codigo = $("#span_codigo");
        var span_fecha = $("#span_fecha");
        var span_perfil = $("#span_perfil");
        var span_etapa = $("#span_etapa");
        var postulacion = $("#postulacion");
        var idPostulacion = $("#idPostulacion");
        var usuarios = [];

        for (var i = 0; i < datos_postulacion.Etapas.length; i++) {
            var agregado = false;
            for (var j = 0; j < usuarios.length; j++) {
                if (usuarios[j].Owner.Id == datos_postulacion.Etapas[i].IdUsuario) agregado = true;
            }
            if (!agregado) usuarios.push(Backend.ejecutarSincronico("GetUsuarioPorId", [datos_postulacion.Etapas[i].IdUsuario]));
        }

        postulacion.val(JSON.stringify(datos_postulacion.Id));

        span_empleado.html(datos_postulacion.Postulante.Apellido + ", " + datos_postulacion.Postulante.Nombre); // new BuscarUsuario().generar(datos_postulacion.Etapas[0]));
        span_codigo.html(datos_postulacion.Numero);
        span_fecha.html(ConversorDeFechas.deIsoAFechaEnCriollo(datos_postulacion.FechaPostulacion));
        span_perfil.html(datos_postulacion.Perfil.Denominacion);


     
        localStorage.setItem("comite", datos_postulacion.Perfil.Comite.Numero);



        var ultima_etapa = datos_postulacion.Etapas.pop();
        span_etapa.html(ultima_etapa.Etapa.Descripcion)

        var fieldset_titulo_perfil = $("#cuadro_perfil");
        var fieldset_titulo_documentos = $("#cuadro_documentos");

        //var legend_perfil = $("<legend>");
        // legend_perfil.attr("id", "titulo_doc_oblig");
        var legend_documentos = $("<legend>");
        legend_documentos.attr("id", "titulo_doc_curric");

        //legend_perfil.html("Documentación Obligatoria del perfil");
        legend_documentos.html("Documentación del Curriculum");

        //fieldset_titulo_perfil.append(legend_perfil);
        fieldset_titulo_documentos.append(legend_documentos);

        $("#btn_guardar").attr("style", "display:inline");
        $("#btn_comprobantes").attr("style", "display:inline");
        $("#btn_caratula").attr("style", "display:inline");

        Backend.GetPantallaRecepcionDocumentacion(datos_postulacion)
                    .onSuccess(function (mi_pantalla) {
                        pantalla = mi_pantalla;
                        //var nombre_perfil = $("#nombre_perfil");
                        //nombre_perfil[0].innerHTML = mi_pantalla.Postulacion.Perfil.Denominacion;

                        // _this.armarPantallaPerfil(mi_pantalla, $('#requisitos_perfil'));
                        _this.armarPantalla(mi_pantalla.CuadroPerfil, $('#detalle_documentos'));
                        _this.armarPantalla(mi_pantalla.DocumentacionRequerida, $('#detalle_documentos'));
                        _this.completarFoliosRecepcionados(mi_pantalla.DocumentacionRecibida, $('#detalle_documentos'));
                    });
    },
    //    armarPantallaPerfil: function (pantalla, div_caja_foliables) {

    //        for (var i = 0; i < pantalla.RequisitosPerfil.length; i++) {
    //            var div_foliable = $('<div>');
    //            var descripcion_foliable = $('<p>');
    //            div_caja_foliables.attr("style", "margin: 5px; padding: 5px; background-color: #FBFBFB; border: dotted 1px; ");


    //            descripcion_foliable.text(pantalla.RequisitosPerfil[i]);
    //            div_caja_foliables.append(descripcion_foliable);

    //            div_caja_foliables.append(descripcion_foliable);
    //        }
    // },
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
                    var hidden = $("<input>");
                    hidden.attr("type", "hidden");
                    hidden.attr("id", 0);

                    var id = elementos[i].ItemsCv[j].IdTabla + "_" + elementos[i].ItemsCv[j].Id;
                    descripcion_item.attr("id", id);

                    descripcion_item.attr("class", "foliables");
                    descripcion_item.attr("style", "padding-bottom: 10px;");
                    var textbox_folio = $('<input>');
                    textbox_folio.attr("type", "textbox");
                    textbox_folio.attr("style", " width:40px; float: right; margin-right: 40%;");
                    textbox_folio.attr("placeholder", "Fojas");

                    descripcion_item.text(elementos[i].ItemsCv[j].Descripcion);
                    descripcion_item.append(textbox_folio);
                    descripcion_item.append(hidden);
                    div_caja_foliables.append(descripcion_item);

                }

            }

        }
    }
}





