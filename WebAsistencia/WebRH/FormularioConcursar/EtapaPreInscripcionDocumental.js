var cantidadDeInformes = 0;
var EtapaPreInscripcionDocumental = {
    mostrarPostulacion: function () {
        var _this = this;
        _this.btn_guardar = $("#btn_guardar");
        _this.btn_buscar_postulacion = $("#btn_buscar_postulacion");
        _this.btn_comprobantes = $("#btn_comprobantes");
        _this.btn_AgregarInforme = $("#btnActualizarInformes");

        var pantalla;

        _this.btn_buscar_postulacion.click(function () {
            _this.BuscarPostulaciones();
        });

        _this.btn_comprobantes.click(function () {
            var nro_postulacion = $("#txt_codigo_postulacion").val();
            var dni_postulante = $("#span_dni_postulante").text();
            var fecha_postulacion = $("#span_fecha").text();
            Backend.ObtenerFolios(nro_postulacion, dni_postulante, fecha_postulacion)
             .onSuccess(function (respuesta) {

                 localStorage.setItem("nro_inscripcion", respuesta.codigo);
                 localStorage.setItem("fecha_inscripcion", respuesta.fecha);
                 if (respuesta.en_base) {
                     localStorage.setItem("ficha_inscripcion", respuesta.ficha_inscripcion);
                     localStorage.setItem("foto_carnet", respuesta.foto_carnet);
                     localStorage.setItem("fotocopia_dni", respuesta.fotocopia_dni);
                     localStorage.setItem("fotocopia_titulo", respuesta.fotocopia_titulo);
                     localStorage.setItem("Curri", respuesta.Curri);
                     localStorage.setItem("Docum_respaldo", respuesta.Docum_respaldo);
                 } else {
                     localStorage.setItem("ficha_inscripcion", "");
                     localStorage.setItem("foto_carnet", "");
                     localStorage.setItem("fotocopia_dni", "");
                     localStorage.setItem("fotocopia_titulo", "");
                     localStorage.setItem("Curri", "");
                     localStorage.setItem("Docum_respaldo", "");
                 }


                 window.open("AnexoIIICantHojas.aspx?id=" + respuesta.codigo + "&fh=" + respuesta.fecha + "&dni=" + respuesta.dni + "");
                 $("#somediv").dialog("close");
             });
        });


        _this.btn_guardar.click(function () {

            if ($('#checkValidacionInformes:checked').length == 0) {
                alertify.error('Debe validar todos los INFORMES');
                return;
            }

            if (!_this.todosLosInformesEstanCheckeados()) {
                alertify.error('Debe tildar todos los INFORMES');
                return;
            }

            alertify.confirm("", "¿Está seguro que desea imprimir el anexo de documentación?",
                function () {
                    var lista_foliables = $(".foliables");
                    var lista_documentacion_recibida = [];
                    var postulacion = $("#postulacion");

                    localStorage.setItem("empleado", $("#span_empleado").text());
                    localStorage.setItem("dni", $("#span_dni_postulante").text());
                    localStorage.setItem("idPostulante", $("#idPostulante").val());

                    _this.actualizarInformes();

                    Backend.PasarAEtapaInscripto(postulacion[0].value).onSuccess(function (resultado) {
                        if (resultado == true) {
                            _this.AbrirPopUpFolios();
                        } else {
                            alertify.alert("", 'Esta postulación ya poseé el estado Inscripción Documental.');
                        }
                    })
                       .onError(function (error) {
                           alertify.error(error.statusText);
                       });
                },
                function () {
                    alertify.error("Se ha cancelado la operación");
                }
            );

        });

        _this.btn_AgregarInforme.click(function () {
            if ($('#informeGrafico_00').val() == '') {
                alertify.error('Debe ingresar un N° De Informe GDE');
                return;
            }

            var codigo = $("#txt_codigo_postulacion").val();
            var informesNuevos = [];
            var inputsInformesNuevos = $('.informesGraficos');
            $.each(inputsInformesNuevos, function (key, value) {
                if (value.value != '') {
                    informesNuevos.push(value.value);
                }
            });

            var setDeInformes = [];
            setDeInformes[0] = [];
            setDeInformes[1] = [];
            setDeInformes[2] = informesNuevos;

            var jsonSetDeInformes = JSON.stringify(setDeInformes);

            Backend.ActualizarInformesGDEDeUnaPostulacion(codigo, jsonSetDeInformes)
                        .onSuccess(function (resultado) {
                            if (resultado == true) {
                                alertify.success("Exito", 'Se ha agregado el INFORME GDE');
                                $('#informeGrafico_00').val('');
                                _this.BuscarPostulaciones();
                            } else {
                                alertify.alert("", 'Ha sucedido un error');
                            }
                        })
                       .onError(function (error) {
                           alertify.error(error.statusText);
                       });

        });

    },
    todosLosInformesEstanCheckeados: function () {
        var inputsInformesAceptados = $('.checksInformesAceptados:checked');
        var inputsInformesRechazados = $('.checksInformesRechazados:checked');

        var totalChecks = inputsInformesAceptados.length + inputsInformesRechazados.length;

        if (cantidadDeInformes == totalChecks)
            return true;
        return false;
    },
    AbrirPopUpFolios: function () {
        $("#somediv").load("PanelDetalleDeFoliosAnexo.htm").dialog({ modal: true, resizable: false, title: 'Documentación', width: 360 });

    },

    BuscarPostulaciones: function () {
        var _this = this;
        var codigo = $("#txt_codigo_postulacion").val();
        var div_tabla_historial = $("#div_tabla_historial");
        $("#span_empleado").html("");
        $("#span_dni_postulante").html("");
        $("#span_codigo").html("");
        $("#span_fecha").html("");
        $("#span_perfil").html("");
        $("#span_estado").html("");
        $("#idPostulante").html("");
        $("#requisitos_perfil").html("");
        $("#detalle_perfil").html("");
        $("#detalle_documentos").html("");
        $("#span_gde").html("");
        $("#cuerpoTablaInformes").empty();
        $("#titulo_doc_oblig").remove();
        $("#titulo_doc_curric").remove();

        Backend.ejecutar("GetPostulacionesPorCodigo",
            [codigo],
            function (respuesta) {
                if (respuesta != null) {
                    _this.CompletarDatos(respuesta);
                }
                else {
                    alertify.alert("", "Código no encontrado");
                }
            },
            function (errorThrown) {
                alertify.alert("", errorThrown);
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
        var span_dni_postulante = $("#span_dni_postulante");
        var span_codigo = $("#span_codigo");
        var span_fecha = $("#span_fecha");
        var span_perfil = $("#span_perfil");
        var span_etapa = $("#span_etapa");
        var postulacion = $("#postulacion");
        var idPostulacion = $("#idPostulacion");
        var idPostulante = $("#idPostulante");
        var numerosDeInformeGDE = $("#span_gde");
        var usuarios = [];

        for (var i = 0; i < datos_postulacion.Etapas.length; i++) {
            var agregado = false;
            for (var j = 0; j < usuarios.length; j++) {
                if (usuarios[j].Owner.Id == datos_postulacion.Etapas[i].IdUsuario) agregado = true;
            }
            if (!agregado) usuarios.push(Backend.ejecutarSincronico("GetUsuarioPorId", [datos_postulacion.Etapas[i].IdUsuario]));
        }

        cantidadDeInformes = datos_postulacion.NumerosDeInformeGDE.length;
        for (var i = 0; i < datos_postulacion.NumerosDeInformeGDE.length; i++) {
            $("#span_gde").append(datos_postulacion.NumerosDeInformeGDE[i] + ', ');
            $("#cuerpoTablaInformes").append("<tr><td>" + datos_postulacion.NumerosDeInformeGDE[i] + "</td><td><input class='checksInformesAceptados' name='fooby[1][" + i + "]' type='checkbox' value='" + datos_postulacion.NumerosDeInformeGDE[i] + "' /></td><td><input class='checksInformesRechazados' name='fooby[1][" + i + "]' type='checkbox' value='" + datos_postulacion.NumerosDeInformeGDE[i] + "' /></td>");

        }

        $('#contenedorInformesGDE').show();

        postulacion.val(JSON.stringify(datos_postulacion.Id));
        var criterio = {}
        criterio.Id = datos_postulacion.Postulante.Id;
        var persona = Backend.ejecutarSincronico("BuscarPersonas", [JSON.stringify(criterio)]);

        span_empleado.html(datos_postulacion.Postulante.Apellido + ", " + datos_postulacion.Postulante.Nombre); // new BuscarUsuario().generar(datos_postulacion.Etapas[0]));
        span_dni_postulante.html(persona[0].Documento);
        idPostulante.val(datos_postulacion.Postulante.Id);
        span_codigo.html(datos_postulacion.Numero);
        span_fecha.html(ConversorDeFechas.deIsoAFechaEnCriollo(datos_postulacion.FechaPostulacion));
        span_perfil.html(datos_postulacion.Perfil.Denominacion);

        localStorage.setItem("comite", datos_postulacion.Perfil.Comite.Numero);

        var ultima_etapa = datos_postulacion.Etapas.pop();
        span_etapa.html(ultima_etapa.Etapa.Descripcion)
        if (ultima_etapa.Etapa.Id == 1) {
            $('#btn_guardar').show();
            $('#btn_comprobantes').hide();

            $('#contenedorInformesGDE').show();
            $('#contenedorInformesGDE').show();
        } else {
            $('#btn_guardar').hide();
            $('#btn_comprobantes').show();

            $('#contenedorInformesGDE').hide();
        }

        var fieldset_titulo_perfil = $("#cuadro_perfil");
        var fieldset_titulo_documentos = $("#cuadro_documentos");
        var legend_documentos = $("<legend>");
        legend_documentos.attr("id", "titulo_doc_curric");
        //$("#btn_caratula").attr("style", "display:inline");

        //FC: para los check
        // the selector will match all input controls of type :checkbox
        // and attach a click event handler 
        $("input:checkbox").on('click', function () {
            // in the handler, 'this' refers to the box clicked on
            var $box = $(this);
            if ($box.is(":checked")) {
                // the name of the box is retrieved using the .attr() method
                // as it is assumed and expected to be immutable
                var group = "input:checkbox[name='" + $box.attr("name") + "']";
                // the checked state of the group/box on the other hand will change
                // and the current value is retrieved using .prop() method
                $(group).prop("checked", false);
                $box.prop("checked", true);
            } else {
                $box.prop("checked", false);
            }
        });

    },
    actualizarInformes: function () {

        var inputsInformesAceptados = $('.checksInformesAceptados:checked');
        var inputsInformesRechazados = $('.checksInformesRechazados:checked');
        var inputsInformesNuevos = $('.informesGraficos');
        var codigo = $("#txt_codigo_postulacion").val();

        var informesNuevos = [];
        var informesAceptados = [];
        var informesRechazados = [];

        $.each(inputsInformesAceptados, function (key, value) {
            if (value.value != '') {
                informesAceptados.push(value.value);
            }
        });

        $.each(inputsInformesRechazados, function (key, value) {
            if (value.value != '') {
                informesRechazados.push(value.value);
            }
        });

        $.each(inputsInformesNuevos, function (key, value) {
            if (value.value != '') {
                informesNuevos.push(value.value);
            }
        });

        var setDeInformes = [];
        setDeInformes[0] = informesAceptados;
        setDeInformes[1] = informesRechazados;
        setDeInformes[2] = informesNuevos;

        var jsonSetDeInformes = JSON.stringify(setDeInformes);

        Backend.ActualizarInformesGDEDeUnaPostulacion(codigo, jsonSetDeInformes)
            .onSuccess(function (resultado) {
                if (resultado == true) {
                    alertify.success("Exito", 'Se han actualizado correctamente los INFORMES GDE');
                } else {
                    alertify.alert("", 'Ha sucedido un error en la actualización de los Informes');
                }
            })
            .onError(function (error) {
                alertify.error(error.statusText);
            });


    },
    armarPantalla: function (elementos, div_caja_foliables) {

        if (elementos.length > 0) {
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





