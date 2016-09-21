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

        }

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

    }
}
