var Legajo = {
    init: function () {

    },
    getEstudios: function () {
        var data = JSON.stringify({
            doc: 123
        });

        Backend.GetEstudios(123)
            .onSuccess(function (estudiosJSON) {

                var estudios = JSON.parse(estudiosJSON);

                var _this = this;
                $("#tabla").empty();
                var divGrilla = $("#tabla");
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

            });
    },
    getDatosPersonales: function () {
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


            })
            .onError(function (e) {

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

        Backend.GetPsicofisicos()
            .onSuccess(function (psicofisicosJSON) {

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

            });



    },

    getDatosLicencias: function () {

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
                    })
                    .onError(function (e) {

                    });

    },

    ConvertirAMonedaOVacio: function (numero) {
        if (numero == "0") {
            return "";
        } else {
            return "$" + numero;
        }
    },

    getReciboDeSueldo: function (liquidacion) {
        Backend.GetRecibo(liquidacion)
            .onSuccess(function (reciboJSON) {
                $("#tabla_recibo_encabezado tbody tr").remove();
                $("#tabla_recibo_encabezado").show();


                var recibo = JSON.parse(reciboJSON);
                var detalle = "";
                var _this = this;

                $('#celdaLegajo').html(recibo.Cabecera.Legajo);
                $('#celdaNombre').html(recibo.Cabecera.Agente);
                $('#celdaCUIL').html(recibo.Cabecera.CUIL);
                $('#celdaOficina').html(recibo.Cabecera.Oficina);
                $('#celdaOrden').html(recibo.Cabecera.Orden);

                for (var i = 0; i < recibo.Detalle.length; i++) {

                    if (recibo.Detalle[i].Aporte != "0" || recibo.Detalle[i].Descuento != "0") {
                        detalle = detalle + "<tr><td>" + recibo.Detalle[i].Concepto + "</td><td class=\"columna_concepto\">"
                        + recibo.Detalle[i].Descripcion + "</td><td>" + Legajo.ConvertirAMonedaOVacio(recibo.Detalle[i].Aporte) + "</td><td colspan=\"2\">"
                        + Legajo.ConvertirAMonedaOVacio(recibo.Detalle[i].Descuento) + "</td></tr>";
                    }

                }

                detalle += "<tr class='ultima_fila'><td></td><td></td><td class='celda_neto'>Bruto:</td><td class=''> $ " + recibo.Cabecera.Bruto + "</td><td class=''> $ " + recibo.Cabecera.Descuentos + "</td></tr>";
                detalle += "<tr class='ultima_fila'><td></td><td></td><td class='celda_neto'>Neto:</td><td class='celda_importe_neto' colspan='2'>$ " + recibo.Cabecera.Neto + "</td></tr>";

                $("#tabla_recibo_encabezado > tbody ").append(detalle);


            })
            .onError(function (e) {

            });
    },
    bindearBotonLiquidacion: function () {
        var _this = this;
        var btn = $('#cmb_meses').change(function () {
            $("#tabla_recibo_encabezado tbody tr").remove();
            var anio = $("#cmb_anio option:selected").val();
            var mes = $("#cmb_meses option:selected").val();
            var div_controles = $("#caja_controles");
            div_controles.empty();


            Backend.GetLiquidaciones(anio, mes)
                    .onSuccess(function (liquidacionesJSON) {
                        var liquidaciones = [];
                        if (liquidacionesJSON != "") {
                            liquidaciones = JSON.parse(liquidacionesJSON);


                            for (var i = 0; i < liquidaciones.length; i++) {

                                var radio = "<input style='margin-left:10px' type='radio' name='liquidacion' value='" + liquidaciones[i].Id + "'>" + liquidaciones[i].Descripcion;
                                div_controles.append(radio);

                            }

                            $('input[name=liquidacion]').change(function () {
                                var liquidacion = $('input[name=liquidacion]:checked').val();
                                _this.getReciboDeSueldo(liquidacion);
                            });


                        }


                    })
                    .onError(function (e) {

                    });

        });

    },
    GetDatosDesignaciones: function () {

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
                    })
                    .onError(function (e) {

                    });
    },

    getConsultas: function () {
        Backend.GetConsultasDePortal()
                    .onSuccess(function (consultasJSON) {
                        var consultas = [];
                        if (consultasJSON != "") {
                            consultas = JSON.parse(consultasJSON);
                        }
                        var _this = this;
                        $("#tablaConsultas").empty();
                        var divGrilla = $("#tablaConsultas");
                        var columnas = [];
                        columnas.push(new Columna("Id", { generar: function (una_designacion) { return una_designacion.TipoActo } }));
                        columnas.push(new Columna("Fecha", { generar: function (una_designacion) { return una_designacion.NroActo } }));
                        columnas.push(new Columna("Tipo", { generar: function (una_designacion) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_designacion.FechActo) } }));
                        columnas.push(new Columna("Estado", { generar: function (una_designacion) { return una_designacion.SituacionRevista } }));
                        columnas.push(new Columna("Responsable", { generar: function (una_designacion) { return una_designacion.Folio } }));
                        columnas.push(new Columna("Fecha", { generar: function (una_designacion) { return una_designacion.SituacionRevista } }));
                        columnas.push(new Columna("Ver MASSSS", { generar: function (una_designacion) { return una_designacion.SituacionRevista } }));

                        _this.Grilla = new Grilla(columnas);
                        _this.Grilla.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.Grilla.CargarObjetos(designaciones);
                        _this.Grilla.DibujarEn(divGrilla);
                        $('.table-hover').removeClass("table-hover");
                    })
                    .onError(function (e) {

                    });


    }

}
