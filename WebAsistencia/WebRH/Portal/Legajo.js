var spinner;
var mes;
var consultas_sin_leer = 0;

var Legajo = {
    init: function () {

    },
    getEstudios: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetEstudios()
            .onSuccess(function (estudiosJSON) {

                spinner.stop();

                var estudios = JSON.parse(estudiosJSON);

                var _this = this;
                $("#tabla_estudios").empty();
                var divGrilla = $("#tabla_estudios");
                //var tabla = resultado;
                var columnas = [];

                columnas.push(new Columna("Titulo", { generar: function (un_estudio) { return un_estudio.titulo } }));
                columnas.push(new Columna("Nivel", { generar: function (un_estudio) { return un_estudio.nombreDeNivel } }));
                columnas.push(new Columna("Institución", { generar: function (un_estudio) { return un_estudio.nombreUniversidad } }));
                columnas.push(new Columna("F. Egreso", { generar: function (un_estudio) {
                    var fecha_sin_hora = un_estudio.fechaEgreso.split("T");
                    var fecha = fecha_sin_hora[0].split("-");
                    return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
                }
                }));

                _this.Grilla = new Grilla(columnas);
                _this.Grilla.SetOnRowClickEventHandler(function (un_estudio) { });
                _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                _this.Grilla.CargarObjetos(estudios);
                _this.Grilla.DibujarEn(divGrilla);
                $('.table-hover').removeClass("table-hover");
                //_this.BuscadorDeTablaDetalle();

                /* $.each(estudios, function (key, value) {
                var estudio = $(".cajaEstudioOculta").clone();
                estudio.find(".nivel").html(value.nombreDeNivel);
                estudio.find(".titulo").html(value.titulo);
                var fecha_sin_hora = value.fechaEgreso.split("T");
                var fecha = fecha_sin_hora[0].split("-");
                estudio.find(".fecha").html(fecha[2] + "/" + fecha[1] + "/" + fecha[0]);
                estudio.addClass("caja_estudio_posta"); // attr('style', 'margin:10px; border-bottom:1px solid;');
                estudio.removeClass("cajaEstudioOculta");

                $('#listadoEstudios').append(estudio);
                });*/

            })
            .onError(function (e) {
                spinner.stop();
            });
    },
    getDatosPersonales: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetDatosPersonales()
            .onSuccess(function (datos) {

                var data = $.parseJSON(datos);

                if (!$.isEmptyObject(data)) {

                    $('#mensaje').html("");

                    $('#legajo').html(data.Legajo);
                    $('#fechaNac').html(data.FechaNacimiento);
                    $('#edad').html(data.Edad);
                    $('#cuil').html(data.Cuil);
                    $('#sexo').html(data.Sexo);
                    $('#estadoCivil').html(data.EstadoCivil);
                    $('#dni').html(data.Documento);
                    $('#domicilio').html(data.Domicilio);
                    $('#cargo').html(data.Cargo);

                }

                spinner.stop();

            })
            .onError(function (e) {
                spinner.stop();
            });

    },
    getDatosFamiliares: function () {

        Backend.GetFamiliares()
            .onSuccess(function (familiaresJSON) {

                var familiares = JSON.parse(familiaresJSON);

                var _this = this;
                $("#tabla_familiar").empty();
                var divGrilla = $("#tabla_familiar");
                //var tabla = resultado;
                var columnas = [];

                columnas.push(new Columna("Parentesco", { generar: function (un_familiar) { return un_familiar.Parentesco } }));
                columnas.push(new Columna("Apellido", { generar: function (un_familiar) { return un_familiar.Apellido } }));
                columnas.push(new Columna("Nombre", { generar: function (un_familiar) { return un_familiar.Nombre } }));
                columnas.push(new Columna("N doc", { generar: function (un_familiar) { return un_familiar.Documento } }));
                columnas.push(new Columna("Tipo DNI", { generar: function (un_familiar) { return un_familiar.TipoDNI } }));


                _this.Grilla = new Grilla(columnas);
                _this.Grilla.SetOnRowClickEventHandler(function (un_familiar) { });
                _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                _this.Grilla.CargarObjetos(familiares);
                _this.Grilla.DibujarEn(divGrilla);
                $('.table-hover').removeClass("table-hover");


            })
            .onError(function (e) {

            });

    },
    getPsicofisicos: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetPsicofisicos()
            .onSuccess(function (psicofisicosJSON) {
                spinner.stop();

                var psicofisicos = JSON.parse(psicofisicosJSON);

                var _this = this;
                $("#tabla_psicofisicos").empty();
                var divGrilla = $("#tabla_psicofisicos");
                //var tabla = resultado;
                var columnas = [];

                columnas.push(new Columna("Folio", { generar: function (un_examen) { return un_examen.Folio } }));
                columnas.push(new Columna("Motivo", { generar: function (un_examen) { return un_examen.Motivo } }));
                columnas.push(new Columna("Resultado", { generar: function (un_examen) { return un_examen.Resultado } }));
                columnas.push(new Columna("Organismo", { generar: function (un_examen) { return un_examen.Organismo } }));


                _this.Grilla = new Grilla(columnas);
                _this.Grilla.SetOnRowClickEventHandler(function (un_examen) { });
                _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                _this.Grilla.CargarObjetos(psicofisicos);
                _this.Grilla.DibujarEn(divGrilla);
                $('.table-hover').removeClass("table-hover");


            })
            .onError(function (e) {
                spinner.stop();
            });



    },

    getDatosLicencias: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetLicenciasEnTramite()
                    .onSuccess(function (licenciasJSON) {
                        var licencias = [];
                        if (licenciasJSON != "") {
                            licencias = JSON.parse(licenciasJSON);
                        }

                        var _this = this;
                        $("#tablaLicenciasEnTramite").empty();
                        var divGrilla = $("#tablaLicenciasEnTramite");
                        var columnas = [];
                        columnas.push(new Columna("Tipo de Licencia", { generar: function (una_licencia) { return una_licencia.Descripcion } }));
                        columnas.push(new Columna("Fecha Desde", { generar: function (una_licencia) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_licencia.Desde) } }));
                        columnas.push(new Columna("FEcha Hasta", { generar: function (una_licencia) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_licencia.Hasta) } }));
                        columnas.push(new Columna("Estado", { generar: function (una_licencia) { return una_licencia.Estado } }));
                        _this.Grilla = new Grilla(columnas);
                        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.Grilla.CargarObjetos(licencias);
                        _this.Grilla.DibujarEn(divGrilla);
                        $('.table-hover').removeClass("table-hover");


                    })
                    .onError(function (e) {

                    });


        Backend.GetLicenciasOrdinariasDisponibles()
                    .onSuccess(function (licenciasJSON) {
                        var licencias = [];
                        if (licenciasJSON != "") {
                            licencias = JSON.parse(licenciasJSON).Detalle;
                        }
                        var _this = this;
                        $("#tablaLicenciasOrdinariasDisponibles").empty();
                        var divGrilla = $("#tablaLicenciasOrdinariasDisponibles");
                        var columnas = [];
                        columnas.push(new Columna("Año", { generar: function (una_licencia) { return una_licencia.Periodo } }));
                        columnas.push(new Columna("Días Disponibles", { generar: function (una_licencia) { return una_licencia.Disponible } }));

                        _this.Grilla = new Grilla(columnas);
                        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.Grilla.CargarObjetos(licencias);
                        _this.Grilla.DibujarEn(divGrilla);
                        $('.table-hover').removeClass("table-hover");

                        spinner.stop();
                    })
                    .onError(function (e) {
                        spinner.stop();
                    });

        Backend.GetAnalisisLicenciaOrdinariaUsuarioLogueado()
                    .onSuccess(function (analisisJSON) {
                        var lineas = [];
                        if (analisisJSON != "") {
                            lineas = JSON.parse(analisisJSON).lineas;
                        }
                        var _this = this;
                        var numeroParaGrilla = function (numero) {

                            if (numero == 0) {
                                return "";
                            } else {
                                return numero;
                            }
                        }
                        var fechaParaGrilla = function (str_fecha) {
                            if (str_fecha == "0001-01-01T00:00:00") {
                                return "";
                            }
                            var fh = new Date(str_fecha);
                            var dia = fh.getDate() + 1;
                            var mes = fh.getMonth() + 1;
                            var str = dia + '/' + mes + '/' + fh.getFullYear();
                            return str;
                        }

                        $("#tablaHistoricoLicenciasOrdinarias").empty();
                        var divGrilla = $("#tablaHistoricoLicenciasOrdinarias");
                        var columnas = [];
                        columnas.push(new Columna("Periodo", { generar: function (una_linea) { return numeroParaGrilla(una_linea.PeriodoAutorizado); } }));
                        columnas.push(new Columna("Autorizados", { generar: function (una_linea) { return numeroParaGrilla(una_linea.CantidadDiasAutorizados); } }));
                        columnas.push(new Columna("Utilizados", { generar: function (una_linea) { return una_linea.CantidadDiasDescontados } }));
                        columnas.push(new Columna("Desde", { generar: function (una_linea) {
                            if (una_linea.PerdidaPorVencimiento == true) {
                                return "Vencidas";
                            } else if (una_linea.PerdidaExplicitamente == true) {
                                return una_linea.Observacion;
                            } else {
                                return fechaParaGrilla(una_linea.LicenciaDesde);
                            }
                        }
                        }));
                        columnas.push(new Columna("Hasta", { generar: function (una_linea) { return fechaParaGrilla(una_linea.LicenciaHasta) } }));

                        _this.Grilla = new Grilla(columnas);
                        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.Grilla.CargarObjetos(lineas);
                        _this.Grilla.DibujarEn(divGrilla);
                        $('.table-hover').removeClass("table-hover");

                        spinner.stop();

                    })
                    .onError(function (e) {
                        spinner.stop();
                    });


    },
    ConvertirAMonedaOVacio: function (numero) {
        var _this = this;
        if (numero == null) {
            return "";
        }
        var _this = this;
        if (numero == 0) return "";
        return '$ ' + _this.ConvertirANumeroConPuntos(numero.toFixed(2).toString().replace(".", ","));

        if (numero == "0") {
            return "";
        } else {
            return "$ " + numero;
        }
    },
    ConvertirANumeroConPuntos: function (n) {

        if (n == null) {
            return "";
        }

        n = n.toString()
        while (true) {
            var n2 = n.replace(/(\d)(\d{3})($|,|\.)/g, '$1.$2$3')
            if (n == n2) break
            n = n2
        }
        return n;
    },

    getReciboDeSueldo: function (liquidacion) {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetRecibo(liquidacion)
            .onSuccess(function (reciboJSON) {
                spinner.stop();

                $("#tabla_recibo_encabezado tbody tr").remove();
                $("#tabla_recibo_encabezado").show();
                $("#bloque_final").show();


                var recibo = JSON.parse(reciboJSON);
                var detalle = "";
                var _this = this;

                $('#celdaLegajo').html(recibo.Cabecera.Legajo);
                $('#celdaNombre').html(recibo.Cabecera.Agente);
                $('#celdaCUIL').html(recibo.Cabecera.CUIL);
                $('#celdaOficina').html(recibo.Cabecera.Oficina);
                $('#celdaOrden').html(recibo.Cabecera.Orden);

                $('#bloque_final').show();
                $('#area').html(recibo.Cabecera.Area);
                $('#domicilio').html(recibo.Cabecera.Domicilio);
                $('#fechaLiquidacion').html(recibo.Cabecera.FechaLiquidacion);
                $('#categoria').html(recibo.Cabecera.NivelGrado);

                for (var i = 0; i < recibo.Detalle.length; i++) {

                    if (recibo.Detalle[i].Aporte != "0" || recibo.Detalle[i].Descuento != "0") {
                        detalle = detalle + "<tr><td>" + recibo.Detalle[i].Concepto + "</td><td class=\"columna_concepto\">"
                        + recibo.Detalle[i].Descripcion + "</td><td>" + Legajo.ConvertirAMonedaOVacio(recibo.Detalle[i].Aporte) + "</td><td colspan=\"2\">"
                        + Legajo.ConvertirAMonedaOVacio(recibo.Detalle[i].Descuento) + "</td></tr>";
                    }

                }

                detalle += "<tr style='border-bottom:none;' class='ultima_fila'><td style='border: none;'></td><td style='border: none;'></td><td class='celda_bruto_nombre'><strong>Bruto:</strong></td><td class='celda_bruto'>" + Legajo.ConvertirAMonedaOVacio(parseInt(recibo.Cabecera.Bruto)) + "</td><td class=''> " + Legajo.ConvertirAMonedaOVacio(parseInt(recibo.Cabecera.Descuentos)) + "</td></tr>";
                detalle += "<tr style='border:none;' class='ultima_fila'><td style='border: none;'></td><td style='border: none;'></td><td class='celda_neto'><strong>Neto:</strong></td><td class='celda_importe_neto' colspan='2'><strong>" + Legajo.ConvertirAMonedaOVacio(parseInt(recibo.Cabecera.Neto)) + "</strong></td></tr>";

                $("#tabla_recibo_encabezado > tbody ").append(detalle);


            })
            .onError(function (e) {
                spinner.stop();
            });
    },
    bindearBotonLiquidacion: function () {
        var _this = this;


        var btn_combo_anio = $('#cmb_anio').change(function () {
            var anio_combo = $("#cmb_anio option:selected").val();
            var day = new Date();
            mes = day.getMonth() + 2;
            var anio = day.getFullYear();

            //inhabilito lo meses que no estan vigentes para este año
            if (anio_combo == anio) {
                $("#cmb_meses option").each(function () {
                    if (mes <= $(this).val()) {
                        $(this).attr('disabled', 'disabled');
                    }
                });
            } else {
                $("#cmb_meses option").each(function () {
                    $(this).removeAttr('disabled');
                });
            }
        });

        var btn = $('#cmb_meses').change(function () {
            $("#tabla_recibo_encabezado tbody tr").remove();
            $("#tabla_recibo_encabezado").hide();
            $("#bloque_final").hide();

            var anio = $("#cmb_anio option:selected").val();
            mes = $("#cmb_meses option:selected").val() - 1;
            var div_controles = $("#caja_controles");
            div_controles.empty();

            var spinner = new Spinner({ scale: 2 });
            spinner.spin($("html")[0]);

            Backend.GetLiquidaciones(anio, mes)
                    .onSuccess(function (liquidacionesJSON) {
                        var liquidaciones = [];
                        if (liquidacionesJSON != "") {
                            liquidaciones = JSON.parse(liquidacionesJSON);


                            for (var i = 0; i < liquidaciones.length; i++) {

                                var texto_extra;

                                if (liquidaciones[i].Descripcion.toLowerCase().indexOf("extras") >= 0) {
                                    var mes_cobrado_valor = mes + 1;
                                    var mes_cobrado_texto = $("#cmb_meses option[value=" + mes_cobrado_valor + "]").text();
                                    var mes_liquidado_valor = mes - 1;
                                    var mes_liquidado_texto = $("#cmb_meses option[value=" + mes_liquidado_valor + "]").text();

                                    texto_extra = "(cobrado a principios del mes de " + mes_cobrado_texto + ", liquidación de " + mes_liquidado_texto + ")";
                                } else {
                                    var mes_cobrado_valor = mes + 1;
                                    var mes_cobrado_texto = $("#cmb_meses option[value=" + mes_cobrado_valor + "]").text();
                                    var mes_liquidado_valor = mes;
                                    var mes_liquidado_texto = $("#cmb_meses option[value=" + mes_liquidado_valor + "]").text();

                                    texto_extra = "(cobrado a principios del mes de " + mes_cobrado_texto + ", liquidación de " + mes_liquidado_texto + ")";
                                }

                                var radio = "<input style='margin-left:10px' type='radio' name='liquidacion' value='" + liquidaciones[i].Id + "'/> " + liquidaciones[i].Descripcion + ' ' + texto_extra + "<br/>";
                                div_controles.append(radio);

                            }

                            $('input[name=liquidacion]').change(function () {
                                var liquidacion = $('input[name=liquidacion]:checked').val();
                                _this.getReciboDeSueldo(liquidacion);
                            });

                            spinner.stop();
                        }


                    })
                    .onError(function (e) {
                        spinner.stop();
                    });

        });

    },
    GetDatosDesignaciones: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetDesignacionActual()
                    .onSuccess(function (designacionJSON) {
                        designacion = JSON.parse(designacionJSON);
                        $('#txt_sector').text(designacion.Sector);
                        $('#txt_nivel_grado').text(designacion.Nivel);
                        $('#txt_planta').text(designacion.Planta);
                        $('#txt_agrupamiento').text(designacion.Agrupamiento);
                        $('#txt_ingreso').text(designacion.IngresoMinisterio);
                        $('#txt_sector').text(designacion.Sector);

                    })
                    .onError(function (e) {

                    });



        Backend.GetDesignaciones()
                    .onSuccess(function (designacionesJSON) {
                        var designaciones = [];
                        if (designacionesJSON != "") {
                            designaciones = JSON.parse(designacionesJSON);
                        }
                        var _this = this;
                        $("#tablaDesignaciones").empty();
                        var divGrilla = $("#tablaDesignaciones");
                        var columnas = [];
                        columnas.push(new Columna("Tipo Acto", { generar: function (una_designacion) { return una_designacion.TipoActo } }));
                        columnas.push(new Columna("Nro Acto", { generar: function (una_designacion) { return una_designacion.NroActo } }));
                        columnas.push(new Columna("Fecha Acto", { generar: function (una_designacion) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_designacion.FechActo) } }));
                        columnas.push(new Columna("Motivo", { generar: function (una_designacion) { return una_designacion.Motivo } }));
                        columnas.push(new Columna("Situación de Revista", { generar: function (una_designacion) { return una_designacion.SituacionRevista } }));
                        columnas.push(new Columna("Folio", { generar: function (una_designacion) { return una_designacion.Folio } }));

                        _this.Grilla = new Grilla(columnas);
                        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.Grilla.CargarObjetos(designaciones);
                        _this.Grilla.DibujarEn(divGrilla);
                        $('.table-hover').removeClass("table-hover");

                        spinner.stop();
                    })
                    .onError(function (e) {
                        spinner.stop();
                    });
    },
    GetCarreraAdministrativa: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetCarreraAdministrativaPortal()
                    .onSuccess(function (carreraJSON) {
                        var carreras = [];
                        if (carreraJSON != "") {
                            carreras = JSON.parse(carreraJSON);
                        }
                        var _this = this;
                        $("#tablaCarreraAdministrativa").empty();
                        var divGrilla = $("#tablaCarreraAdministrativa");
                        var columnas = [];
                        columnas.push(new Columna("Organismo", { generar: function (una_carrera) { return una_carrera.Organismo } }));
                        columnas.push(new Columna("Regimen", { generar: function (una_carrera) { return una_carrera.Regimen } }));
                        columnas.push(new Columna("Agrupamiento", { generar: function (una_carrera) { return una_carrera.Agrupamiento } }));
                        columnas.push(new Columna("Nivel", { generar: function (una_carrera) { return una_carrera.Nivel } }));
                        columnas.push(new Columna("Grado", { generar: function (una_carrera) { return una_carrera.Grado } }));
                        columnas.push(new Columna("Cargo", { generar: function (una_carrera) { return una_carrera.Cargo } }));
                        columnas.push(new Columna("FechaDesde", { generar: function (una_carrera) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_carrera.FechaDesde) } }));
                        columnas.push(new Columna("FechaHasta", { generar: function (una_carrera) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_carrera.FechaHasta) } }));
                        columnas.push(new Columna("DescCausa", { generar: function (una_carrera) { return una_carrera.DescCausa } }));
                        columnas.push(new Columna("Folio", { generar: function (una_carrera) { return una_carrera.Folio } }));

                        _this.Grilla = new Grilla(columnas);
                        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.Grilla.CargarObjetos(carreras);
                        _this.Grilla.DibujarEn(divGrilla);
                        $('.table-hover').removeClass("table-hover");

                        spinner.stop();
                    })
                    .onError(function (e) {
                        spinner.stop();
                    });
    },
    getDocumentos: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetDocumentosDelLegajo()
            .onSuccess(function (documentosJSON) {

                spinner.stop();

                var documentos = JSON.parse(documentosJSON);

                var _this = this;
                $("#tabla_documentos").empty();
                var divGrilla = $("#tabla_documentos");
                //var tabla = resultado;
                var columnas = [];

                columnas.push(new Columna("Documento", { generar: function (un_documento) { return un_documento.Nombre } }));
                columnas.push(new Columna("Folio", { generar: function (un_documento) { return un_documento.Folio } }));


                _this.Grilla = new Grilla(columnas);
                _this.Grilla.SetOnRowClickEventHandler(function (un_documento) { });
                _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                _this.Grilla.CargarObjetos(documentos);
                _this.Grilla.DibujarEn(divGrilla);
                $('.table-hover').removeClass("table-hover");


            })
            .onError(function (e) {
                spinner.stop();
            });
    },
    getNombre: function () {
        Backend.GetUsuarioLogueado()
        .onSuccess(function (usuario) {
            $("#nombre_empleado").html(usuario.Owner.Apellido + ", " + usuario.Owner.Nombre);

            if (usuario.Owner.IdImagen >= 0) {
                var img = new VistaThumbnail({ id: usuario.Owner.IdImagen, contenedor: $(".imagen") });
            }
        })
        .onError(function (e) {

        });
        this.GetConsultasNoLeidas();
    },

    GetConsultasNoLeidas: function () {
        Backend.GetConsultasNoLeidas()
        .onSuccess(function (cantidad) {
            consultas_sin_leer = cantidad;
            if (cantidad > 0) {
                $("#link_consultas").html("Consultas (" + cantidad + ")");
                $("#link_nuevos_mensajes").show();
            } else {
                $("#link_nuevos_mensajes").hide();
            }
        })
        .onError(function (e) {
        });
    },

    MostrarDetalleDeConsulta: function (id, motivo, respuesta) {

        vex.defaultOptions.className = 'vex-theme-os';
        vex.open({
            afterOpen: function ($vexContent) {
                var ui = $("#pantalla_consulta_ticket").clone();
                $vexContent.append(ui);
                ui.show();
                ui.find("#btn_enviar_consulta").click(function () {
                    Backend.NuevaConsultaDePortal({
                        id_tipo_consulta: ui.find("#cmb_tipo_consulta").val(),
                        tipo_consulta: ui.find("#cmb_tipo_consulta option:selected").text(),
                        motivo: ui.find("#txt_motivo_consulta").val()
                    }).onSuccess(function (id_consulta) {
                        alertify.success("Consulta enviada con éxito");
                        vex.close();
                        Legajo.getConsultas();
                    }).onError(function (id_consulta) {
                        alertify.error("Error al enviar consulta");
                    });
                });
                return ui;
            },
            css: {
                'padding-top': "4%",
                'padding-bottom': "0%"
            },
            contentCSS: {
                width: "80%",
                height: "80%"
            }
        });





        Backend.MarcarConsultaComoLeida(id).onSuccess(function () { }).onError(function (e) { });
        this.GetConsultasNoLeidas();
    },

    TratarConsulta: function (nro_consulta, creador, tipo, motivo) {
        $('#btn_responder_consulta').show();
        $('#ta_respuesta').prop("disabled", false);
        $('#tablaConsultas').hide();
        $('#div_detalle_consulta').show();
        $('#txt_creador').val(creador.Apellido + ", " + creador.Nombre);
        $('#nroDocumentoCreador').val(creador.Documento);
        $('#txt_nro_consulta').val(nro_consulta);
        $('#txt_tipo').val(tipo);
        $('#ta_motivo').text(motivo);
        $('#legend_gestion').html("DETALLE CONSULTA");
        $('#search').hide();

    },

    VisualizarConsulta: function (nro_consulta, creador, tipo, motivo, respuesta) {
        this.TratarConsulta(nro_consulta, creador, tipo, motivo);
        $('#btn_responder_consulta').hide();
        $('#ta_respuesta').text(respuesta);
        $('#ta_respuesta').prop("disabled", true);
        $('#search').hide();
    },

    getConsultas: function () {
        var _this_original = this;
        Backend.GetConsultasDePortal()
                    .onSuccess(function (consultasJSON) {
                        var consultas = [];
                        if (consultasJSON != "") {
                            consultas = JSON.parse(consultasJSON);
                        }
                        var _this = this;
                        $("#tablaConsultas_noleidas").empty();
                        $("#tablaConsultas_pendientes").empty();
                        $("#tablaConsultas_historicas").empty();
                        var divGrilla_noleidas = $("#tablaConsultas_noleidas");
                        var divGrilla_pendientes = $("#tablaConsultas_pendientes");
                        var divGrilla_historicas = $("#tablaConsultas_historicas");
                        var columnas_noleidas = [];
                        var columnas_pendientes = [];
                        var columnas_historicas = [];
                        columnas_noleidas.push(new Columna("#", { generar: function (una_consulta) { return una_consulta.Id } }));
                        columnas_noleidas.push(new Columna("Fecha Creación", { generar: function (una_consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_consulta.fechaCreacion) } }));
                        columnas_noleidas.push(new Columna("Tipo de Consulta", { generar: function (una_consulta) { return una_consulta.tipo_consulta } }));
                        columnas_noleidas.push(new Columna("Responsable", { generar: function (una_consulta) { return una_consulta.contestador.Nombre } }));
                        columnas_noleidas.push(new Columna("Fecha Respuesta", { generar: function (una_consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_consulta.fechaContestacion) } }));
                        columnas_noleidas.push(new Columna('Detalle', {
                            generar: function (una_consulta) {
                                var btn_accion = $('<a>');
                                var img = $('<img>');
                                img.attr('src', '../Imagenes/detalle.png');
                                img.attr('width', '15px');
                                img.attr('height', '15px');
                                btn_accion.append(img);
                                btn_accion.click(function () {
                                    _this_original.MostrarDetalleDeConsulta(una_consulta.Id, una_consulta.motivo, una_consulta.respuesta);
                                });
                                return btn_accion;
                            }
                        }));

                        columnas_pendientes.push(new Columna("#", { generar: function (una_consulta) { return una_consulta.Id } }));
                        columnas_pendientes.push(new Columna("Fecha Creación", { generar: function (una_consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_consulta.fechaCreacion) } }));
                        columnas_pendientes.push(new Columna("Tipo de Consulta", { generar: function (una_consulta) { return una_consulta.tipo_consulta } }));
                        columnas_pendientes.push(new Columna("Estado", { generar: function (una_consulta) { return una_consulta.estado } }));
                        columnas_pendientes.push(new Columna('Detalle', {
                            generar: function (una_consulta) {
                                var btn_accion = $('<a>');
                                var img = $('<img>');
                                img.attr('src', '../Imagenes/detalle.png');
                                img.attr('width', '15px');
                                img.attr('height', '15px');
                                btn_accion.append(img);
                                btn_accion.click(function () {
                                    _this_original.MostrarDetalleDeConsulta(una_consulta.Id, una_consulta.motivo, una_consulta.respuesta);
                                });
                                return btn_accion;
                            }
                        }));

                        columnas_historicas.push(new Columna("#", { generar: function (una_consulta) { return una_consulta.Id } }));
                        columnas_historicas.push(new Columna("Fecha Creación", { generar: function (una_consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_consulta.fechaCreacion) } }));
                        columnas_historicas.push(new Columna("Tipo de Consulta", { generar: function (una_consulta) { return una_consulta.tipo_consulta } }));
                        columnas_historicas.push(new Columna("Estado", { generar: function (una_consulta) { return una_consulta.estado } }));
                        columnas_historicas.push(new Columna("Responsable", { generar: function (una_consulta) { return una_consulta.contestador.Nombre } }));
                        columnas_historicas.push(new Columna("Fecha Respuesta", { generar: function (una_consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_consulta.fechaContestacion) } }));
                        columnas_historicas.push(new Columna('Detalle', {
                            generar: function (una_consulta) {
                                var btn_accion = $('<a>');
                                var img = $('<img>');
                                img.attr('src', '../Imagenes/detalle.png');
                                img.attr('width', '15px');
                                img.attr('height', '15px');
                                btn_accion.append(img);
                                btn_accion.click(function () {
                                    _this_original.MostrarDetalleDeConsulta(una_consulta.Id, una_consulta.motivo, una_consulta.respuesta);
                                });
                                return btn_accion;
                            }
                        }));

                        _this.divGrilla_noleidas = new Grilla(columnas_noleidas);
                        _this.divGrilla_noleidas.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.divGrilla_noleidas.SetOnRowClickEventHandler(function (una_consulta) { });
                        _this.divGrilla_noleidas.CargarObjetos(_this_original.ConsultasNoLeidas(consultas));
                        _this.divGrilla_noleidas.DibujarEn(divGrilla_noleidas);

                        _this.divGrilla_pendientes = new Grilla(columnas_pendientes);
                        _this.divGrilla_pendientes.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.divGrilla_pendientes.SetOnRowClickEventHandler(function (una_consulta) { });
                        _this.divGrilla_pendientes.CargarObjetos(_this_original.ConsultasPendientes(consultas));
                        _this.divGrilla_pendientes.DibujarEn(divGrilla_pendientes);

                        _this.divGrilla_historicas = new Grilla(columnas_historicas);
                        _this.divGrilla_historicas.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.divGrilla_historicas.SetOnRowClickEventHandler(function (una_consulta) { });
                        _this.divGrilla_historicas.CargarObjetos(_this_original.ConsultasHistoricas(consultas));
                        _this.divGrilla_historicas.DibujarEn(divGrilla_historicas);
                        $('.table-hover').removeClass("table-hover");
                    })
                    .onError(function (e) {

                    });
    },
    ConsultasNoLeidas: function (consultas) {
        return $.grep(consultas, function (consulta) { return consulta.leida; });
    },
    ConsultasPendientes: function (consultas) {
        return $.grep(consultas, function (consulta) { return (consulta.id_estado != 7 && consulta.id_estado != 8) });
    },
    ConsultasHistoricas: function (consultas) {
        return consultas;
    },

    getConsultasHistoricasDeUnUsuario: function (idUsuario) {
        var _this_original = this;

        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetConsultasDePortalParaUnUsuario(idUsuario)
                    .onSuccess(function (consultasJSON) {
                        var consultas = [];
                        if (consultasJSON != "") {
                            consultas = JSON.parse(consultasJSON);
                        }
                        var _this = this;

                        $("#tablaConsultas").empty();

                        var divGrilla_historicas = $("#tablaConsultas");

                        var columnas_historicas = [];


                        columnas_historicas.push(new Columna("#", { generar: function (una_consulta) { return una_consulta.Id } }));
                        columnas_historicas.push(new Columna("Fecha Creación", { generar: function (una_consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_consulta.fechaCreacion) } }));
                        columnas_historicas.push(new Columna("Tipo de Consulta", { generar: function (una_consulta) { return una_consulta.tipo_consulta } }));
                        columnas_historicas.push(new Columna("Estado", { generar: function (una_consulta) { return una_consulta.estado } }));
                        columnas_historicas.push(new Columna("Creador", { generar: function (una_consulta) { return una_consulta.creador.Apellido + ', ' + una_consulta.creador.Nombre } }));
                        columnas_historicas.push(new Columna("Responsable", { generar: function (una_consulta) {
                            if (una_consulta.contestador.Apellido != "") {
                                return una_consulta.contestador.Apellido + ', ' + una_consulta.contestador.Nombre
                            } else {
                                return "<span style='color:red;'>PENDIENTE</span>";
                            }
                        }
                        }));
                        columnas_historicas.push(new Columna("Fecha Respuesta", { generar: function (una_consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_consulta.fechaContestacion) } }));
                        columnas_historicas.push(new Columna('Detalle', {
                            generar: function (una_consulta) {
                                var btn_accion = $('<a>');
                                var img = $('<img>');
                                img.attr('src', '../Imagenes/detalle.png');
                                img.attr('width', '15px');
                                img.attr('height', '15px');
                                btn_accion.append(img);
                                btn_accion.click(function () {
                                    _this_original.MostrarDetalleDeConsulta(una_consulta.Id, una_consulta.motivo, una_consulta.respuesta);
                                });
                                return btn_accion;
                            }
                        }));


                        _this.divGrilla_historicas = new Grilla(columnas_historicas);
                        _this.divGrilla_historicas.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.divGrilla_historicas.SetOnRowClickEventHandler(function (una_consulta) { });
                        _this.divGrilla_historicas.CargarObjetos(consultas);
                        _this.divGrilla_historicas.DibujarEn(divGrilla_historicas);
                        $('.table-hover').removeClass("table-hover");

                        $('#legend_gestion').html("CONSULTAS HISTÓRICAS DEL USUARIO");

                        spinner.stop();
                    })
                    .onError(function (e) {
                        spinner.stop();
                    });
    },
    GetComboTipoConsulta: function () {
        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetTiposDeConsultaDePortal()
                    .onSuccess(function (tiposconsultaJSON) {
                        //completo el combo
                        var tiposconsulta = JSON.parse(tiposconsultaJSON);
                        $.each(tiposconsulta, function (i, tipoconsulta) {
                            $('#cmb_tipo_consulta').append($('<option>', {
                                value: tipoconsulta.id,
                                text: tipoconsulta.descripcion,
                                placeholder: tipoconsulta.placeholder
                            }));
                        });

                        //una vez completado el combo bindeo el evento click de realizar consulta
                        $("#btn_nueva_consulta").click(function () {
                            vex.defaultOptions.className = 'vex-theme-os';
                            vex.open({
                                afterOpen: function ($vexContent) {
                                    var ui = $("#pantalla_alta_ticket").clone();
                                    $vexContent.append(ui);
                                    ui.show();
                                    ui.find("#cmb_tipo_consulta").change(function () {
                                        var textoCustomizado = this.options[this.selectedIndex].getAttribute('placeholder');
                                        ui.find("#txt_motivo_consulta").attr("placeholder", textoCustomizado); //[0].placeholder = textoCustomizado;
                                    });


                                    ui.find("#btn_enviar_consulta").click(function () {
                                        Backend.NuevaConsultaDePortal({
                                            id_tipo_consulta: ui.find("#cmb_tipo_consulta").val(),
                                            tipo_consulta: ui.find("#cmb_tipo_consulta option:selected").text(),
                                            motivo: ui.find("#txt_motivo_consulta").val()
                                        }).onSuccess(function (id_consulta) {
                                            alertify.success("Consulta enviada con éxito");
                                            vex.close();
                                            Legajo.getConsultas();
                                        }).onError(function (id_consulta) {
                                            alertify.error("Error al enviar consulta");
                                        });
                                    });
                                    return ui;
                                },
                                css: {
                                    'padding-top': "4%",
                                    'padding-bottom': "0%"
                                },
                                contentCSS: {
                                    width: "80%",
                                    height: "60%"
                                }
                            });

                        });
                        spinner.stop();
                    })
                    .onError(function (e) {
                        alert("No se han podido obtener los tipos de Consulta.");
                        spinner.stop();
                    });

    },

    VolverAConsulta: function () {
        $('#div_detalle_consulta').hide();
        $('#tablaConsultas').show();
        $('#search').show();
    },

    ResponderConsulta: function () {
        var id = parseInt($('#txt_nro_consulta').val());
        var respuesta = $('#ta_respuesta').val();
        Backend.ResponderConsulta(id, respuesta)
                    .onSuccess(function () {
                        $('#btn_volver_consulta').click();
                        $('#ta_respuesta').val("");
                        alertify("Se ha actualizado correctamente");
                    })
                    .onError(function (e) {
                    });
    },

    getConsultasParaGestion: function () {
        var _this = this;
        $('#btn_volver_consulta').click(function () {
            _this.VolverAConsulta();
        });
        $('#btn_responder_consulta').click(function () {
            _this.ResponderConsulta();
        });
        $('#btn_consultas_pendientes').click(function () {
            $('#div_detalle_consulta').hide();
            $('#tablaConsultas').show();
            $('#legend_gestion').html("CONSULTAS PENDIENTES");
            _this.getConsultasTodas(6);
        });
        $('#btn_consultas_historicas').click(function () {
            $('#div_detalle_consulta').hide();
            $('#tablaConsultas').show();
            $('#legend_gestion').html("CONSULTAS HISTÓRICAS");
            _this.getConsultasTodas(0);
        });
        $('#btn_consultas_pendientes').click();
    },

    getConsultasTodas: function (estado) {
        var _this_original = this;

        var spinner = new Spinner({ scale: 2 });
        spinner.spin($("html")[0]);

        Backend.GetConsultasTodasDePortal(estado)
                    .onSuccess(function (consultasJSON) {
                        var consultas = [];
                        if (consultasJSON != "") {
                            consultas = JSON.parse(consultasJSON);
                        }
                        var _this = this;
                        $("#tablaConsultas").empty();
                        var divGrilla = $("#tablaConsultas");
                        var columnas = [];
                        columnas.push(new Columna("#", { generar: function (una_consulta) { return una_consulta.Id } }));
                        columnas.push(new Columna("Fecha Creación", { generar: function (una_consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_consulta.fechaCreacion) } }));
                        columnas.push(new Columna("TipoDeConsulta", { generar: function (una_consulta) { return una_consulta.tipo_consulta } }));
                        columnas.push(new Columna("Creador", { generar: function (una_consulta) { return una_consulta.creador.Apellido + ", " + una_consulta.creador.Nombre } }));
                        columnas.push(new Columna("Estado", { generar: function (una_consulta) { return una_consulta.estado } }));
                        if (estado != 6) {
                            columnas.push(new Columna("Responsable", { generar: function (una_consulta) {
                                if (una_consulta.contestador.Apellido != "") {
                                    return una_consulta.contestador.Apellido + ', ' + una_consulta.contestador.Nombre
                                } else {
                                    return "<span style='color:red;'>PENDIENTE</span>";
                                }
                            }
                            }));
                        }
                        /*columnas.push(new Columna("Creador", { generar: function (una_consulta) {

                        var btn_accion = $('<a>');
                        btn_accion.html(una_consulta.creador.Apellido + ", " + una_consulta.creador.Nombre);
                        btn_accion.click(function () {
                        _this_original.getConsultasHistoricasDeUnUsuario(una_consulta.creador.Id);
                        });

                        return btn_accion;

                        }
                        }));*/
                        columnas.push(new Columna('Acciones', {
                            generar: function (una_consulta) {
                                var caja = $('<div>');
                                var btn_accion = $('<a>');
                                var img = $('<img>');
                                img.attr('width', '15px');
                                img.attr('height', '15px');
                                if (una_consulta.id_estado == 6) {

                                    img.attr('src', '../Imagenes/edit.png');
                                    img.attr('data-toggle', 'tooltip');
                                    img.attr('title', 'Responder');

                                    btn_accion.click(function () {
                                        _this_original.TratarConsulta(una_consulta.Id, una_consulta.creador, una_consulta.tipo_consulta, una_consulta.motivo);
                                    });

                                } else {
                                    img.attr('src', '../Imagenes/icons-lupa-finish.jpg');
                                    img.attr('data-toggle', 'tooltip');
                                    img.attr('title', 'Consultar');
                                    btn_accion.click(function () {
                                        _this_original.VisualizarConsulta(una_consulta.Id, una_consulta.creador, una_consulta.tipo_consulta, una_consulta.motivo, una_consulta.respuesta);
                                    });
                                }

                                var btn_accion_historico = $('<a>');
                                var img2 = $('<img>');
                                img2.attr('width', '15px');
                                img2.attr('height', '15px');
                                img2.attr('style', 'margin-left:15px');
                                img2.attr('src', '../Imagenes/historial_usuario.png');
                                img2.attr('data-toggle', 'tooltip');
                                img2.attr('title', 'Histórico de consultas del usuario');
                                btn_accion_historico.click(function () {
                                    _this_original.getConsultasHistoricasDeUnUsuario(una_consulta.creador.Id);
                                });

                                btn_accion.append(img);
                                caja.append(btn_accion);
                                btn_accion_historico.append(img2);
                                caja.append(btn_accion_historico);
                                return caja;
                            }
                        }));

                        _this.Grilla = new Grilla(columnas);
                        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.Grilla.SetOnRowClickEventHandler(function (una_consulta) { });
                        _this.Grilla.CargarObjetos(consultas);
                        _this.Grilla.DibujarEn(divGrilla);

                        $('#search').show();
                        var options = {
                            valueNames: ['TipoDeConsulta', 'Creador', 'Responsable', 'Desde', 'Hasta']
                        };

                        var featureList = new List('consultas', options);

                        $('.table-hover').removeClass("table-hover");

                        spinner.stop();
                    })
                    .onError(function (e) {
                        spinner.stop();
                    });
    },
    getConsultaIndividual: function (documento, ui) {
        var _this = this;
        Backend.GetConsultaRapida(documento).onSuccess(function (datos) {
            var data = $.parseJSON(datos);
            if (!$.isEmptyObject(data)) {
                ui.find("#panel_izquierdo").delay(300).animate({ "opacity": "1" }, 300);
                ui.find('#mensaje').html("");
                ui.find('#nombre_consulta').html(data.Apellido);
                ui.find('#legajo_consulta').html(data.Legajo);
                ui.find('#fechaNacimiento').html(data.FechaNacimiento);
                ui.find('#edad').html(data.Edad);
                ui.find('#cuil').html(data.Cuil);
                ui.find('#sexo').html(data.Sexo);
                ui.find('#estadoCivil').html(data.EstadoCivil);
                ui.find('#documento_consulta').html(data.Documento);
                ui.find('#domicilio').html(data.Domicilio);
                ui.find('#estudio').html(data.Estudio);
                ui.find('#nivel_grado').html(data.Nivel);
                ui.find('#sector').html(data.Sector);
                ui.find('#planta').html(data.Planta);
                ui.find('#cargo').html(data.Cargo);
                ui.find('#agrupamiento').html(data.Agrupamiento);
                ui.find('#ing_min').html(data.IngresoMinisterio);
                //$('#ant_min').html(data.AntMinisterio);
                //$('#estado').html(data.AntEstado);
                //$('#privada').html(data.AntPrivada);
                //$('#resta').html(data.RestaAnt);
                //$('#total').html(data.ANTTotalTotal);
                //$('#nombre').html(data.ANTTotalTotal);
                /*$('#btn_timeline').click(function () {
                Backend.GetCarreraAdministrativa(documento).onSuccess(function (datos) {
                $('#contenedor_timeLine').empty();
                _this.armarTimeline(datos);
                });
                })*/
            } else {
                ui.find('#panel_izquierdo').hide();
                ui.find('#mensaje').html("No se encontraron datos para la persona con documento " + documento);
            }
        });
    }

}
